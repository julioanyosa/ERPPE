using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Reflection;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Configuracion;
using Halley.CapaLogica.Ventas;
using RRV.Seguridad;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas.VentasPavo
{
    public partial class ListGenerarVales : UITemplateAccess
    {

       DataTable dtVales2 = new DataTable("Vales");

        DataTable Dtempresas = new DataTable();
        TextFunctions ObjTextFunctions = new TextFunctions();

        #region constructor

        DataSet ds;
        DataTable dtDetalle;
        string NumComprobrante;
        string direccion;

        public ListGenerarVales()
        {
            InitializeComponent();
        }
        #endregion

        #region metodos definidos

        public static byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void Limpiar()
        {
            NumComprobrante = null;
            direccion = null;
            ds.Clear();
            lblCajero.Text = string.Empty;
            lblCliente.Text = string.Empty;
            lblDocumento.Text = string.Empty;
            lblNomSede.Text = string.Empty;
            lblSedeID.Text = string.Empty;
            lblTipoComporbante.Text = string.Empty;
            lblVendedor.Text = string.Empty;
            txtNumComprobante.Text = string.Empty;
        }

        #endregion

        #region eventos del control

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                NumComprobrante =string.Concat(AppSettings.EmpresaID,txtNumComprobante.Text);
                ds = new DataSet();
                ds = new CL_Vales().getNumComprobante(NumComprobrante, Convert.ToInt32(CboTipoComprobante.SelectedValue));

                if (ds.Tables[0].Rows.Count != 0)
                {
                    DataRow fila = ds.Tables["comprobante"].Rows[0];
                    NumComprobrante = fila["NumComprobante"].ToString();
                    direccion = fila["Direccion"].ToString();
                    lblTipoComporbante.Text = fila["NomTipoComprobante"].ToString();
                    lblSedeID.Text = fila["SedeID"].ToString();
                    lblNomSede.Text = fila["NomSede"].ToString();
                    lblCliente.Text = fila["RazonSocial"].ToString();
                    lblDocumento.Text = fila["NroDocumento"].ToString();
                    lbl.Text = string.Concat(fila["TipoDocumento"].ToString(), " :");
                    lblVendedor.Text = fila["Vendedor"].ToString();
                    lblCajero.Text = fila["Cajero"].ToString();

                    tdbgVentas.SetDataBinding(ds.Tables["detalleComprobante"], null, true);


                    //aca se crea los vales
                    Cursor = Cursors.WaitCursor;


                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                        objCrypto.Key = AppSettings.Key;
                        objCrypto.IV = AppSettings.IV;

                        dtDetalle = new DataTable();
                        dtDetalle = new CL_Vales().getdetalleVales(NumComprobrante, Convert.ToInt32(CboTipoComprobante.SelectedValue));

                        DataTable dtVales = new DataTable("Vales");
                        dtVales.Columns.Add("Comprobante", typeof(string));
                        dtVales.Columns.Add("Cliente", typeof(string));
                        dtVales.Columns.Add("Codigo", typeof(string));
                        dtVales.Columns.Add("Producto", typeof(string));
                        dtVales.Columns.Add("Peso", typeof(string));
                        dtVales.Columns.Add("NumVale", typeof(int));
                        dtVales.Columns.Add("CodBar", typeof(string));
                        dtVales.Columns.Add("Numeros", typeof(string));
                        dtVales.Columns.Add("Direccion", typeof(string));
                        dtVales.Columns.Add("Foto", typeof(Byte[]));

                        string cadena;
                        if (dtDetalle.Rows.Count == 0)
                        {

                            int UltimoNumVale = new CL_Vales().getUltimoVale();

                            foreach (DataRow fila2 in ds.Tables[1].Rows)
                            {
                                int cant = Convert.ToInt32(fila2["Cantidad"]);

                                for (int x = 0; x < cant; x++)
                                {
                                    UltimoNumVale++;
                                    DataRow row = dtVales.NewRow();
                                    row["Comprobante"] = NumComprobrante;
                                    row["Cliente"] = lblCliente.Text;
                                    row["Codigo"] = fila2["ProductoID"].ToString();
                                    row["Producto"] = fila2["NomProducto"].ToString().Remove(fila2["NomProducto"].ToString().IndexOf("X"));
                                    row["Peso"] = string.Concat(string.Format("{0:0.##}", fila2["Unidades"]), " KG");
                                    row["NumVale"] = UltimoNumVale;
                                    cadena = objCrypto.CifrarCadena(UltimoNumVale.ToString());

                                    row["CodBar"] = string.Concat("*", UltimoNumVale.ToString().PadLeft(4, '/'), cadena.Substring(0, 7), "*");
                                    row["Numeros"] = UltimoNumVale.ToString().PadLeft(4, '0');
                                    row["Direccion"] = direccion;
                                    row["Foto"] = ImageToByteArray((Image)Halley.Presentacion.Properties.Resources.ResourceManager.GetObject(fila2["Imagen"].ToString()));
                                    dtVales.Rows.Add(row);
                                }

                                //mostrar el inicio y el fin
                                int Inicio;
                                int Fin;

                                DataView DV = new DataView(dtVales, "", "NumVale ASC", DataViewRowState.CurrentRows);

                                Inicio = Convert.ToInt32(DV[0]["NumVale"]);
                                Fin = Convert.ToInt32(DV[DV.Count - 1]["NumVale"]);

                                LblValesEncontrados.Text = "Desde " + Inicio.ToString() + "\r\n" + "Hasta " + Fin.ToString();
                            }

                            new CL_Vales().Insert(AppSettings.UserID, lblSedeID.Text, dtVales, Convert.ToInt32(CboTipoComprobante.SelectedValue));
                        }
                        else
                        {
                            //mostrar el inicio y el fin
                            int Inicio;
                            int Fin;

                            DataView DV = new DataView(dtDetalle, "", "NumVale ASC", DataViewRowState.CurrentRows);

                            Inicio = Convert.ToInt32(DV[0]["NumVale"]);
                            Fin = Convert.ToInt32(DV[DV.Count - 1]["NumVale"]);

                            LblValesEncontrados.Text = "Desde " + Inicio.ToString() + "\r\n" + "Hasta " + Fin.ToString();
                        }
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message,"Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ListGenerarVales_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            DataTable DtTipoComprobante = new DataTable();
            DtTipoComprobante = new CL_Comprobante().getTipoComprobante();
            c1Combo.FillC1Combo1(CboTipoComprobante, DtTipoComprobante, "NomTipoComprobante", "TipoComprobanteID");

            dtVales2.Columns.Add("ID", typeof(int));
            dtVales2.Columns.Add("Comprobante", typeof(string));
            dtVales2.Columns.Add("Cliente", typeof(string));
            dtVales2.Columns.Add("Codigo", typeof(string));
            dtVales2.Columns.Add("Producto", typeof(string));
            dtVales2.Columns.Add("Peso", typeof(string));
            dtVales2.Columns.Add("NumVale", typeof(int));
            dtVales2.Columns.Add("CodBar", typeof(string));
            dtVales2.Columns.Add("Numeros", typeof(string));
            dtVales2.Columns.Add("Direccion", typeof(string));
            dtVales2.Columns.Add("Foto", typeof(Byte[]));
        }

        private void txtNumComprobante_TextChanged(object sender, EventArgs e)
        {
            if (txtNumComprobante.Text.Length != 0)
                btnBuscar.Enabled = true;
            else
                btnBuscar.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void ListGenerarVales_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;


                if (ds.Tables[0].Rows.Count != 0)
                {
                    Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                    objCrypto.Key = AppSettings.Key;
                    objCrypto.IV = AppSettings.IV;

                    dtDetalle = new DataTable();
                    dtDetalle = new CL_Vales().getdetalleVales(NumComprobrante, Convert.ToInt32(CboTipoComprobante.SelectedValue));

                    DataTable dtVales = new DataTable("Vales");
                    dtVales.Columns.Add("Comprobante", typeof(string));
                    dtVales.Columns.Add("Cliente", typeof(string));
                    dtVales.Columns.Add("Codigo", typeof(string));
                    dtVales.Columns.Add("Producto", typeof(string));
                    dtVales.Columns.Add("Peso", typeof(string));
                    dtVales.Columns.Add("NumVale", typeof(int));
                    dtVales.Columns.Add("CodBar", typeof(string));
                    dtVales.Columns.Add("Numeros", typeof(string));
                    dtVales.Columns.Add("Direccion", typeof(string));
                    dtVales.Columns.Add("Foto", typeof(Byte[]));

                    string cadena;                    
                    if (dtDetalle.Rows.Count == 0)
                    {
                        
                        int UltimoNumVale = new CL_Vales().getUltimoVale();

                        foreach (DataRow fila in ds.Tables[1].Rows)
                        {
                            int cant = Convert.ToInt32(fila["Cantidad"]);

                            for (int x = 0; x < cant; x++)
                            {
                                UltimoNumVale++;
                                DataRow row = dtVales.NewRow();
                                row["Comprobante"] = NumComprobrante;
                                row["Cliente"] = lblCliente.Text;
                                row["Codigo"] = fila["ProductoID"].ToString();
                                row["Producto"] =fila["NomProducto"].ToString().Remove(fila["NomProducto"].ToString().IndexOf("X"));
                                row["Peso"] = string.Concat(string.Format("{0:0.##}", fila["Unidades"]), " KG");
                                row["NumVale"] = UltimoNumVale;
                                cadena = objCrypto.CifrarCadena(UltimoNumVale.ToString());
                                
                                row["CodBar"] = string.Concat("*",UltimoNumVale.ToString().PadLeft(4, '/'),cadena.Substring(0, 7), "*");
                                row["Numeros"] = UltimoNumVale.ToString().PadLeft(4, '0');
                                row["Direccion"] = direccion;
                                row["Foto"] = ImageToByteArray((Image)Halley.Presentacion.Properties.Resources.ResourceManager.GetObject(fila["Imagen"].ToString()));
                                dtVales.Rows.Add(row);
                            }

                            //mostrar el inicio y el fin
                            int Inicio;
                            int Fin;

                            DataView DV = new DataView(dtVales, "", "NumVale ASC", DataViewRowState.CurrentRows);

                            Inicio = Convert.ToInt32(DV[0]["NumVale"]);
                            Fin = Convert.ToInt32(DV[DV.Count - 1]["NumVale"]);

                            LblValesEncontrados.Text = "Desde " + Inicio.ToString() + "\r\n" + "Hasta " + Fin.ToString();
                        }

                        new CL_Vales().Insert(AppSettings.UserID,lblSedeID.Text,dtVales, Convert.ToInt32(CboTipoComprobante.SelectedValue));
                    }
                    else
                    {
                        //mostrar el inicio y el fin
                        int Inicio;
                        int Fin;

                        DataView DV = new DataView(dtDetalle, "", "NumVale ASC", DataViewRowState.CurrentRows);

                        Inicio = Convert.ToInt32(DV[0]["NumVale"]);
                        Fin = Convert.ToInt32(DV[DV.Count - 1]["NumVale"]);

                        LblValesEncontrados.Text = "Desde " + Inicio.ToString() + "\r\n" + "Hasta " + Fin.ToString();

                        foreach (DataRow fila in dtDetalle.Rows)
                        {
                            DataRow row = dtVales.NewRow();
                            row["Comprobante"] = NumComprobrante;
                            row["Cliente"] = fila["RazonSocial"].ToString();
                            row["Producto"] = fila["NomProducto"].ToString().Remove(fila["NomProducto"].ToString().IndexOf("X"));
                            row["Peso"] = string.Concat(string.Format("{0:0.##}", fila["Unidades"]), " KG");
                            row["NumVale"] = fila["NumVale"];
                            cadena = objCrypto.CifrarCadena(fila["NumVale"].ToString());
                            
                            row["CodBar"] = string.Concat("*",fila["NumVale"].ToString().PadLeft(4, '/'),cadena.Substring(0, 7), "*");
                            row["Numeros"] = fila["NumVale"].ToString().PadLeft(4, '0');
                            row["Direccion"] = direccion;
                            row["Foto"] = ImageToByteArray((Image)Halley.Presentacion.Properties.Resources.ResourceManager.GetObject(fila["Imagen"].ToString()));
                            dtVales.Rows.Add(row);
                        }
                    }

                    ReporteNavideño.RepGeneraVales Obj_RepVale = new ReporteNavideño.RepGeneraVales();
                    Obj_RepVale.dtDetalleVales = dtVales;
                    if (Obj_RepVale.ShowDialog() == DialogResult.OK)
                    {
                        Limpiar();
                    }
                }
                //mostrar el numero de vale
                

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);                  
            }
        }

        #endregion

        private void txtNumComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) & Convert.ToDecimal(txtNumComprobante.Text.Length) > 0)
            {
                btnBuscar_Click(null, null);
            }
           
        }


        private void BtnEnHoja_Click(object sender, EventArgs e)
        {
            //generar los vales y despues impromir pero en hoja
            try
            {
                dtVales2.Rows.Clear();
                Cursor = Cursors.WaitCursor;

                if (ds.Tables[0].Rows.Count != 0 & TxtDesde.Text != "")
                {
                    Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                    objCrypto.Key = AppSettings.Key;
                    objCrypto.IV = AppSettings.IV;

                    dtDetalle = new DataTable();
                    dtDetalle = new CL_Vales().getdetalleVales(NumComprobrante, Convert.ToInt32(CboTipoComprobante.SelectedValue));



                    string cadena;
                    if (dtDetalle.Rows.Count == 0)
                    {
                        int UltimoNumVale = new CL_Vales().getUltimoVale();

                        foreach (DataRow fila in ds.Tables[1].Rows)
                        {
                            int cant = Convert.ToInt32(fila["Cantidad"]);

                            for (int x = 0; x < cant; x++)
                            {
                                UltimoNumVale++;
                                DataRow row = dtVales2.NewRow();
                                row["ID"] = x + 1;
                                row["Comprobante"] = NumComprobrante;
                                row["Cliente"] = lblCliente.Text;
                                row["Codigo"] = fila["ProductoID"].ToString();
                                row["Producto"] = fila["NomProducto"].ToString().Remove(fila["NomProducto"].ToString().IndexOf("X"));
                                row["Peso"] = string.Concat(string.Format("{0:0.##}", fila["Unidades"]), " KG");
                                row["NumVale"] = UltimoNumVale;
                                cadena = objCrypto.CifrarCadena(UltimoNumVale.ToString());

                                row["CodBar"] = string.Concat("*", UltimoNumVale.ToString().PadLeft(4, '/'), cadena.Substring(0, 7), "*");
                                row["Numeros"] = UltimoNumVale.ToString().PadLeft(4, '0');
                                row["Direccion"] = direccion;
                                row["Foto"] = ImageToByteArray((Image)Halley.Presentacion.Properties.Resources.ResourceManager.GetObject(fila["Imagen"].ToString() + "2"));
                                dtVales2.Rows.Add(row);
                            }
                        }

                        new CL_Vales().Insert(AppSettings.UserID, lblSedeID.Text, dtVales2, Convert.ToInt32(CboTipoComprobante.SelectedValue));
                    }
                    else
                    {
                        int X = 1;
                        foreach (DataRow fila in dtDetalle.Rows)
                        {
                            DataRow row = dtVales2.NewRow();
                            row["ID"] = X;
                            row["Comprobante"] = NumComprobrante;
                            row["Cliente"] = fila["RazonSocial"].ToString();
                            row["Producto"] = fila["NomProducto"].ToString().Remove(fila["NomProducto"].ToString().IndexOf("X"));
                            row["Peso"] = string.Concat(string.Format("{0:0.##}", fila["Unidades"]), " KG");
                            row["NumVale"] = fila["NumVale"];
                            cadena = objCrypto.CifrarCadena(fila["NumVale"].ToString());

                            row["CodBar"] = string.Concat("*", fila["NumVale"].ToString().PadLeft(4, '/'), cadena.Substring(0, 7), "*");
                            row["Numeros"] = fila["NumVale"].ToString().PadLeft(4, '0');
                            row["Direccion"] = direccion;
                            row["Foto"] = ImageToByteArray((Image)Halley.Presentacion.Properties.Resources.ResourceManager.GetObject(fila["Imagen"].ToString() + "2"));
                            dtVales2.Rows.Add(row);
                            ++X;
                        }
                    }

                    printDialog1.ShowDialog();
                    if (printDialog1.PrinterSettings.PrinterName != "")
                    {
                        Pd.Print();
                    }
                }
                else
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("No existen vales o no se ha ingresado el inicio del vale", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
                Pd.PrinterSettings.PrinterName = printDialog1.PrinterSettings.PrinterName;
                Pd.DefaultPageSettings.Landscape = true;
              
                int Vale = Convert.ToInt32(TxtDesde.Text);
                //buscra el primero
                DataRow[] customerRow = dtVales2.Select("Numvale = " + Vale);

                if (customerRow.Count() > 0)
                {
                    int EjeY = 20;
                    //primera impresión
                    System.Drawing.Font Fnt1 = new System.Drawing.Font("Arial", 15, FontStyle.Bold);
                    System.Drawing.Font Fnt2 = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    System.Drawing.Font Fnt3 = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
                    System.Drawing.Font Fnt4 = new System.Drawing.Font("Arial", 8, FontStyle.Regular);
                    System.Drawing.Font Fnt5 = new System.Drawing.Font("Arial", 20, FontStyle.Bold);

                    System.Drawing.Rectangle REC1 = new Rectangle(360, 15, 120, 45);
                    System.Drawing.Rectangle REC2 = new Rectangle(130, 70, 300, 45);
                    e.Graphics.DrawImage(Presentacion.Properties.Resources.HalleyLogo, REC1); //total pagar en letras

                    e.Graphics.DrawString(customerRow[0]["Comprobante"].ToString(), Fnt1, Brushes.Black, 130, EjeY); //total pagar en letras
                    EjeY = EjeY + 25;
                    e.Graphics.DrawString("CLIENTE", Fnt2, Brushes.Black, 130, EjeY); //total pagar en letras
                    EjeY = EjeY + 25;
                    e.Graphics.DrawString(customerRow[0]["cliente"].ToString(), Fnt2, Brushes.Black, REC2); //total pagar en letras
                    EjeY = EjeY + 40;
                    e.Graphics.DrawString("Producto: " + customerRow[0]["Producto"].ToString(), Fnt2, Brushes.Black, 50, EjeY); //total pagar en letras
                    EjeY = EjeY + 20;
                    e.Graphics.DrawString("FECHA DE VIGENCIA          |      HORARIO DE ATENCION\r\nDel 21 al 31 de Dic. del 2012 | De 7am a 1pm y de 3pm a 7pm", Fnt4, Brushes.Black, 50, EjeY); //total pagar en letras
                    EjeY = EjeY + 40;
                    e.Graphics.DrawString("LUGAR DE ENTREGA " + customerRow[0]["Direccion"].ToString(), Fnt4, Brushes.Black, 50, EjeY); //total pagar en letras
                    EjeY = EjeY + 20;
                    e.Graphics.DrawString("1-Si el producto excede al peso del vale, se deberá pagar la diferencia.\r\n2-Cualquier diferencia menor se canjeara con otros productos de la empresa.\r\n3-La diferencia por kilo sera cotizado con el precio actual.\r\n4-El portador del vale acepta las condiciones mencionadas.\r\n", Fnt4, Brushes.Black, 50, EjeY); //total pagar en letras
                    EjeY = EjeY + 60;
                    e.Graphics.DrawString(customerRow[0]["Peso"].ToString(), Fnt5, Brushes.Black, 380, 115); //total pagar en letras
                    e.Graphics.DrawString("N°: " + customerRow[0]["Numvale"].ToString(), Fnt2, Brushes.Black, 390, 145); //total pagar en letras
                    e.Graphics.DrawString(customerRow[0]["CodBar"].ToString(), TxtBarra.Font, Brushes.Black, 95, EjeY); //total pagar en letras
                    System.Drawing.Rectangle REC = new Rectangle(60, 20, 70, 70);

                    byte[] imageBuffer = (byte[])customerRow[0]["Foto"];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    e.Graphics.DrawImage(Image.FromStream(ms), REC); //total pagar en letras

                }
                Vale = Vale + 1;
                DataRow[] customerRow2 = dtVales2.Select("Numvale = " + Vale);
                int AlaDerecha = 580;
                int Aabajo = 350;

                if (customerRow2.Count() > 0)
                {
                    int EjeY = 20;
                    //primera impresión
                    System.Drawing.Font Fnt1 = new System.Drawing.Font("Arial", 15, FontStyle.Bold);
                    System.Drawing.Font Fnt2 = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    System.Drawing.Font Fnt3 = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
                    System.Drawing.Font Fnt4 = new System.Drawing.Font("Arial", 8, FontStyle.Regular);
                    System.Drawing.Font Fnt5 = new System.Drawing.Font("Arial", 20, FontStyle.Bold);

                    System.Drawing.Rectangle REC1 = new Rectangle(AlaDerecha + 320, 15, 120, 45);
                    System.Drawing.Rectangle REC2 = new Rectangle(AlaDerecha + 90, 70, 300, 45);
                    e.Graphics.DrawImage(Presentacion.Properties.Resources.HalleyLogo, REC1); //total pagar en letras

                    e.Graphics.DrawString(customerRow2[0]["Comprobante"].ToString(), Fnt1, Brushes.Black, AlaDerecha + 90, EjeY); //total pagar en letras
                    EjeY = EjeY + 25;
                    e.Graphics.DrawString("CLIENTE", Fnt2, Brushes.Black, AlaDerecha + 90, EjeY); //total pagar en letras
                    EjeY = EjeY + 25;
                    e.Graphics.DrawString(customerRow2[0]["cliente"].ToString(), Fnt2, Brushes.Black, REC2); //total pagar en letras
                    EjeY = EjeY + 40;
                    e.Graphics.DrawString("Producto: " + customerRow2[0]["Producto"].ToString(), Fnt2, Brushes.Black, AlaDerecha + 10, EjeY); //total pagar en letras
                    EjeY = EjeY + 20;
                    e.Graphics.DrawString("FECHA DE VIGENCIA          |      HORARIO DE ATENCION\r\nDel 21 al 31 de Dic. del 2012 | De 7am a 1pm y de 3pm a 7pm", Fnt4, Brushes.Black, AlaDerecha + 10, EjeY); //total pagar en letras
                    EjeY = EjeY + 40;
                    e.Graphics.DrawString("LUGAR DE ENTREGA " + customerRow2[0]["Direccion"].ToString(), Fnt4, Brushes.Black, AlaDerecha + 10, EjeY); //total pagar en letras
                    EjeY = EjeY + 20;
                    e.Graphics.DrawString("1-Si el producto excede al peso del vale, se deberá pagar la diferencia.\r\n2-Cualquier diferencia menor se canjeara con otros productos de la empresa.\r\n3-La diferencia por kilo sera cotizado con el precio actual.\r\n4-El portador del vale acepta las condiciones mencionadas.\r\n", Fnt4, Brushes.Black, AlaDerecha + 10, EjeY); //total pagar en letras
                    EjeY = EjeY + 60;
                    e.Graphics.DrawString(customerRow2[0]["Peso"].ToString(), Fnt5, Brushes.Black, AlaDerecha + 340, 115); //total pagar en letras
                    e.Graphics.DrawString("N°: " + customerRow2[0]["Numvale"].ToString(), Fnt2, Brushes.Black, AlaDerecha + 350, 145); //total pagar en letras
                    e.Graphics.DrawString(customerRow2[0]["CodBar"].ToString(), TxtBarra.Font, Brushes.Black, AlaDerecha + 55, EjeY); //total pagar en letras
                    System.Drawing.Rectangle REC = new Rectangle(AlaDerecha + 20, 20, 70, 70);

                    byte[] imageBuffer = (byte[])customerRow2[0]["Foto"];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    e.Graphics.DrawImage(Image.FromStream(ms), REC); //total pagar en letras

                }

                Vale = Vale + 1;
                DataRow[] customerRow3 = dtVales2.Select("Numvale = " + Vale);

                if (customerRow3.Count() > 0)
                {
                    int EjeY = 20;
                    //primera impresión
                    System.Drawing.Font Fnt1 = new System.Drawing.Font("Arial", 15, FontStyle.Bold);
                    System.Drawing.Font Fnt2 = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    System.Drawing.Font Fnt3 = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
                    System.Drawing.Font Fnt4 = new System.Drawing.Font("Arial", 8, FontStyle.Regular);
                    System.Drawing.Font Fnt5 = new System.Drawing.Font("Arial", 20, FontStyle.Bold);

                    System.Drawing.Rectangle REC1 = new Rectangle(360, Aabajo + 15, 120, 45);
                    System.Drawing.Rectangle REC2 = new Rectangle(130, Aabajo + 70, 300, 45);
                    e.Graphics.DrawImage(Presentacion.Properties.Resources.HalleyLogo, REC1); //total pagar en letras

                    e.Graphics.DrawString(customerRow3[0]["Comprobante"].ToString(), Fnt1, Brushes.Black, 130, Aabajo + EjeY); //total pagar en letras
                    EjeY = EjeY + 25;
                    e.Graphics.DrawString("CLIENTE", Fnt2, Brushes.Black, 130, Aabajo + EjeY); //total pagar en letras
                    EjeY = EjeY + 25;
                    e.Graphics.DrawString(customerRow3[0]["cliente"].ToString(), Fnt2, Brushes.Black, REC2); //total pagar en letras
                    EjeY = EjeY + 40;
                    e.Graphics.DrawString("Producto: " + customerRow3[0]["Producto"].ToString(), Fnt2, Brushes.Black, 50, Aabajo + EjeY); //total pagar en letras
                    EjeY = EjeY + 20;
                    e.Graphics.DrawString("FECHA DE VIGENCIA          |      HORARIO DE ATENCION\r\nDel 21 al 31 de Dic. del 2012 | De 7am a 1pm y de 3pm a 7pm", Fnt4, Brushes.Black, 50, Aabajo + EjeY); //total pagar en letras
                    EjeY = EjeY + 40;
                    e.Graphics.DrawString("LUGAR DE ENTREGA " + customerRow3[0]["Direccion"].ToString(), Fnt4, Brushes.Black, 50, Aabajo + EjeY); //total pagar en letras
                    EjeY = EjeY + 20;
                    e.Graphics.DrawString("1-Si el producto excede al peso del vale, se deberá pagar la diferencia.\r\n2-Cualquier diferencia menor se canjeara con otros productos de la empresa.\r\n3-La diferencia por kilo sera cotizado con el precio actual.\r\n4-El portador del vale acepta las condiciones mencionadas.\r\n", Fnt4, Brushes.Black, 50, Aabajo + EjeY); //total pagar en letras
                    EjeY = EjeY + 60;
                    e.Graphics.DrawString(customerRow3[0]["Peso"].ToString(), Fnt5, Brushes.Black, 380, Aabajo + 115); //total pagar en letras
                    e.Graphics.DrawString("N°: " + customerRow3[0]["Numvale"].ToString(), Fnt2, Brushes.Black, 390, Aabajo + 145); //total pagar en letras
                    e.Graphics.DrawString(customerRow3[0]["CodBar"].ToString(), TxtBarra.Font, Brushes.Black, 95, Aabajo + EjeY); //total pagar en letras
                    System.Drawing.Rectangle REC = new Rectangle(60, Aabajo + 20, 70, 70);

                    byte[] imageBuffer = (byte[])customerRow3[0]["Foto"];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    e.Graphics.DrawImage(Image.FromStream(ms), REC); //total pagar en letras

                }

                Vale = Vale + 1;
                DataRow[] customerRow4 = dtVales2.Select("Numvale = " + Vale);

                if (customerRow4.Count() > 0)
                {
                    int EjeY = 20;
                    //primera impresión
                    System.Drawing.Font Fnt1 = new System.Drawing.Font("Arial", 15, FontStyle.Bold);
                    System.Drawing.Font Fnt2 = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    System.Drawing.Font Fnt3 = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
                    System.Drawing.Font Fnt4 = new System.Drawing.Font("Arial", 8, FontStyle.Regular);
                    System.Drawing.Font Fnt5 = new System.Drawing.Font("Arial", 20, FontStyle.Bold);

                    System.Drawing.Rectangle REC1 = new Rectangle(AlaDerecha + 320, Aabajo + 15, 120, 45);
                    System.Drawing.Rectangle REC2 = new Rectangle(AlaDerecha + 90, Aabajo + 70, 300, 45);
                    e.Graphics.DrawImage(Presentacion.Properties.Resources.HalleyLogo, REC1); //total pagar en letras

                    e.Graphics.DrawString(customerRow4[0]["Comprobante"].ToString(), Fnt1, Brushes.Black, AlaDerecha + 90, Aabajo + EjeY); //total pagar en letras
                    EjeY = EjeY + 25;
                    e.Graphics.DrawString("CLIENTE", Fnt2, Brushes.Black, AlaDerecha + 90, Aabajo + EjeY); //total pagar en letras
                    EjeY = EjeY + 25;
                    e.Graphics.DrawString(customerRow4[0]["cliente"].ToString(), Fnt2, Brushes.Black, REC2); //total pagar en letras
                    EjeY = EjeY + 40;
                    e.Graphics.DrawString("Producto: " + customerRow4[0]["Producto"].ToString(), Fnt2, Brushes.Black, AlaDerecha + 10, Aabajo + EjeY); //total pagar en letras
                    EjeY = EjeY + 20;
                    e.Graphics.DrawString("FECHA DE VIGENCIA          |      HORARIO DE ATENCION\r\nDel 21 al 31 de Dic. del 2012 | De 7am a 1pm y de 3pm a 7pm", Fnt4, Brushes.Black, AlaDerecha + 10, Aabajo + EjeY); //total pagar en letras
                    EjeY = EjeY + 40;
                    e.Graphics.DrawString("LUGAR DE ENTREGA " + customerRow4[0]["Direccion"].ToString(), Fnt4, Brushes.Black, AlaDerecha + 10, Aabajo + EjeY); //total pagar en letras
                    EjeY = EjeY + 20;
                    e.Graphics.DrawString("1-Si el producto excede al peso del vale, se deberá pagar la diferencia.\r\n2-Cualquier diferencia menor se canjeara con otros productos de la empresa.\r\n3-La diferencia por kilo sera cotizado con el precio actual.\r\n4-El portador del vale acepta las condiciones mencionadas.\r\n", Fnt4, Brushes.Black, AlaDerecha + 10, Aabajo + EjeY); //total pagar en letras
                    EjeY = EjeY + 60;
                    e.Graphics.DrawString(customerRow4[0]["Peso"].ToString(), Fnt5, Brushes.Black, AlaDerecha + 340, Aabajo + 115); //total pagar en letras
                    e.Graphics.DrawString("N°: " + customerRow4[0]["Numvale"].ToString(), Fnt2, Brushes.Black, AlaDerecha + 350, Aabajo + 145); //total pagar en letras
                    e.Graphics.DrawString(customerRow4[0]["CodBar"].ToString(), TxtBarra.Font, Brushes.Black, AlaDerecha + 55, Aabajo + EjeY); //total pagar en letras
                    System.Drawing.Rectangle REC = new Rectangle(AlaDerecha + 20, Aabajo + 20, 70, 70);

                    byte[] imageBuffer = (byte[])customerRow4[0]["Foto"];
                    // Se crea un MemoryStream a partir de ese buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    e.Graphics.DrawImage(Image.FromStream(ms), REC); //total pagar en letras

                }
             
            
        }

        private void TxtDesde_TextChanged(object sender, EventArgs e)
        {
            if (TxtDesde.Text != "")
            {
                LblHasta.Text = "Hasta el\r\n" + (Convert.ToInt32(TxtDesde.Text) + 3).ToString();
            }
            else
                LblHasta.Text = "Hasta el\r\n0";
        }

        private void TxtDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.SoloNumero(sender, e, TxtDesde);
        }

       
    }
}

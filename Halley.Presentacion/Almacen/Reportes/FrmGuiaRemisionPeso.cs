using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;
using Halley.Utilitario;
using System.Drawing.Printing;
using System.Configuration;

namespace Halley.Presentacion.Almacen
{
    public partial class FrmGuiaRemisionPeso : Form
    {
        string ImpresoraGuiaRemitentePeso = AppSettings.ImpresoraGuiaRemitentePeso;

        private string _NumGuiaRemision;

        DataTable DtCabecera;
        DataTable DtDetalle;
        DataTable DtDetallePeso;
        //crear tablas para agregarlas a las listas
        DataTable DtTara;
        DataTable DtBruto;

        public string NumGuiaRemision
        {
            get { return _NumGuiaRemision; }
            set { _NumGuiaRemision = value; }
        }

        public FrmGuiaRemisionPeso()
        {
            InitializeComponent();
        }

        private void FrmGuiaRemisionPeso_Load(object sender, EventArgs e)
        {
            if (NumGuiaRemision != "")
            {
                Cursor = Cursors.WaitCursor;
                TxtGuia.Text = NumGuiaRemision;
                MostrarGuia(TxtGuia.Text);
                Cursor = Cursors.Default;
            }
        }

        private void MostrarGuia(string NumGuia)
        {
            #region Limpiar
            //Recorremos todos los textos y los limpiamos

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is C1.Win.C1Input.C1TextBox)
                {
                    C1.Win.C1Input.C1TextBox t = ctrl as C1.Win.C1Input.C1TextBox;
                    t.Text = "";
                }
                else if (ctrl is ToolStripContainer)
                {
                    foreach (Control c in ctrl.Controls)
                    {
                        if (c is ToolStripContentPanel)
                        {
                            foreach (Control d in c.Controls)
                            {
                                if (d is C1.Win.C1Input.C1TextBox)
                                {
                                    C1.Win.C1Input.C1TextBox t = d as C1.Win.C1Input.C1TextBox;
                                    t.Text = "";
                                }
                            }
                        }
                    }
                }
            }

            //Limpiar listas
            LstTara1.Items.Clear();
            LstTara2.Items.Clear();
            LstTara3.Items.Clear();
            LstTara4.Items.Clear();
            LstBruto1.Items.Clear();
            LstBruto2.Items.Clear();
            LstBruto3.Items.Clear();
            LstBruto4.Items.Clear();
            LstBruto5.Items.Clear();
            LstBruto6.Items.Clear();

            //label que muestra el estado
            LblEstado.Text = "";
            LblEstado.ForeColor = Color.Blue;
            BtnAnular.Visible = false;
#endregion

            #region Cabecera
            CL_GuiaRemision ObjCL_GuiaRemision = new CL_GuiaRemision();
            DtCabecera = new DataTable();
            DtDetalle = new DataTable();
            DtDetallePeso = new DataTable();

            DtCabecera = ObjCL_GuiaRemision.GetCabeceraGuiaRemision(NumGuia);
            

            
            if (DtCabecera.Rows.Count > 0)
            {
                DtDetalle = ObjCL_GuiaRemision.GetDetalleGuiaRemision(NumGuia,"D");
                DtDetallePeso = ObjCL_GuiaRemision.GetDetalleGuiaRemisionPeso(NumGuia);

                TxtEmpresa.Text = AppSettings.NomEmpresa;
                LblDireccion.Text = AppSettings.NomSede;
                TxtFechaEmision.Text = DateTime.Now.Date.ToString();
                TxtRuc.Text = AppSettings.RUCEmpresa;
                TxtNumGuiaRemision.Text = DtCabecera.Rows[0]["NumGuiaRemision"].ToString().Substring(2);
                TxtFechaInicioTraslado.Text = DtCabecera.Rows[0]["FechaSalida"].ToString();
                TxtDomicilioPartida.Text = DtCabecera.Rows[0]["DomicilioPartida"].ToString();
                TxtNroDomicilioPartida.Text = DtCabecera.Rows[0]["NroDomicilioPartida"].ToString();
                TxtIntDomicilioPartida.Text = DtCabecera.Rows[0]["InteriorDomicilioPartida"].ToString();
                TxtZonaDomicilioPartida.Text = DtCabecera.Rows[0]["ZonaDomicilioPartida"].ToString();
                TxtDisDomicilioPartida.Text = DtCabecera.Rows[0]["DistritoDomicilioPartida"].ToString();
                TxtProvDomicilioPartida.Text = DtCabecera.Rows[0]["ProvinciaDomicilioPartida"].ToString();
                TxtDepDomicilioPartida.Text = DtCabecera.Rows[0]["DepartamentoDomicilioPartida"].ToString();
                TxtDomicilioLlegada.Text = DtCabecera.Rows[0]["DomicilioLlegada"].ToString();
                TxtNroDomicilioLlegada.Text = DtCabecera.Rows[0]["NroDomicilioLlegada"].ToString();
                TxtIntDomicilioLlegada.Text = DtCabecera.Rows[0]["IntDomicilioLlegada"].ToString();
                TxtZonaDomicilioLlegada.Text = DtCabecera.Rows[0]["ZonaDomicilioLlegada"].ToString();
                TxtDisDomicilioLlegada.Text = DtCabecera.Rows[0]["DisDomicilioLlegada"].ToString();
                TxtProvDomicilioLlegada.Text = DtCabecera.Rows[0]["ProvDomicilioLlegada"].ToString();
                TxtDepDomicilioLlegada.Text = DtCabecera.Rows[0]["DepDomicilioLlegada"].ToString();
                TxtDestinatario.Text = DtCabecera.Rows[0]["Destinatario"].ToString();
                TxtRUCDestinatario.Text = DtCabecera.Rows[0]["RUCDestinatario"].ToString();
                TxtConfVehicular.Text = DtCabecera.Rows[0]["ConfiguracionVehicular"].ToString();
                TxtMarca.Text = DtCabecera.Rows[0]["Marca"].ToString();
                TxtPlaca.Text = DtCabecera.Rows[0]["Placa"].ToString();
                TxtNroConstInscripcion.Text = DtCabecera.Rows[0]["NroConstInscripcion"].ToString();
                TxtNroLicTransaportista.Text = DtCabecera.Rows[0]["NroLicTransportista"].ToString();
                TxtNombreChofer.Text = DtCabecera.Rows[0]["NombreChofer"].ToString();
                TxtNroJabas.Text = DtCabecera.Rows[0]["NroJabas"].ToString();
                TxtPesador.Text = DtCabecera.Rows[0]["Pesador"].ToString();
                TxtGalponero.Text = DtCabecera.Rows[0]["Galponero"].ToString();

                //estado de la guia
                int EstadoID;
                EstadoID = Convert.ToInt16(DtCabecera.Rows[0]["EstadoID"]);

                if (EstadoID == 0)
                {
                    LblEstado.Text = "PLANEADO";
                    LblEstado.ForeColor = Color.Blue;
                    BtnAnular.Visible = true;
                }
                else if (EstadoID == 10)
                {
                    LblEstado.Text = "ANULADO";
                    LblEstado.ForeColor = Color.Red;
                    BtnAnular.Visible = false;
                }
                else if (EstadoID == 11)
                {
                    LblEstado.Text = "CERRADO";
                    LblEstado.ForeColor = Color.Blue;
                    BtnAnular.Visible = false;
                }
            }
            else
                BtnAnular.Visible = false;
            #endregion

            #region Detalles

            //mostrar los productos (en este caso solo uno)
            if (DtCabecera.Rows.Count > 0)
            {
                decimal Tara = 0;
                decimal Neto = 0;
                decimal Bruto = 0;
                int Aves = 0;
                TxtProducto.Text = DtDetalle.Rows[0]["NomProducto"].ToString();
                Tara = Convert.ToDecimal(DtDetalle.Rows[0]["PesoTara"].ToString());
                Neto = Convert.ToDecimal(DtDetalle.Rows[0]["PesoNeto"].ToString());
                Bruto = Neto + Tara;
                TxtNeto.Text = Neto.ToString();
                TxtTara.Text = Tara.ToString();
                TxtBruto.Text = Bruto.ToString();
                Aves = Convert.ToInt16(DtDetalle.Rows[0]["CantidadEnviada"]);
                TxtAves.Text = Aves.ToString();
                TxtPesoPromedio.Text = (Neto / Aves).ToString("#,##0.00");

                DtTara = new DataTable();
                DtTara.Columns.Add("Peso", typeof(decimal));
                DtBruto = new DataTable();
                DtBruto.Columns.Add("Peso", typeof(decimal));

                foreach (DataRow Row in DtDetallePeso.Rows)
                {
                    string Tipo = Row["Tipo"].ToString();
                    decimal Peso = Convert.ToDecimal(Row["Peso"]);

                    if (Tipo == "T")
                    {
                        DataRow RowT = DtTara.NewRow();
                        RowT["Peso"] = Peso;
                        DtTara.Rows.Add(RowT);
                    }
                    else
                    {
                        DataRow RowB = DtBruto.NewRow();
                        RowB["Peso"] = Peso;
                        DtBruto.Rows.Add(RowB);
                    }
                }

               //llenar listas de tara
                int y = 0;
                foreach (DataRow Dr in DtTara.Rows)
                {
                    y++;
                    switch (y)
                    {
                        case 1:
                            LstTara1.Items.Add(Dr["Peso"]);
                            break;
                        case 2:
                            LstTara2.Items.Add(Dr["Peso"]);
                            break;
                        case 3:
                            LstTara3.Items.Add(Dr["Peso"]);
                            break;
                        case 4:
                            LstTara4.Items.Add(Dr["Peso"]);
                            y = 0;
                            break;
                    }
                }

                //llenar listas de peso bruto
                int j = 0;
                foreach (DataRow Dr in DtBruto.Rows)
                {
                    j++;
                    switch (j)
                    {
                        case 1:
                            LstBruto1.Items.Add(Dr["Peso"]);
                            break;
                        case 2:
                            LstBruto2.Items.Add(Dr["Peso"]);
                            break;
                        case 3:
                            LstBruto3.Items.Add(Dr["Peso"]);
                            break;
                        case 4:
                            LstBruto4.Items.Add(Dr["Peso"]);
                            break;
                        case 5:
                            LstBruto5.Items.Add(Dr["Peso"]);
                            break;
                        case 6:
                            LstBruto6.Items.Add(Dr["Peso"]);
                            j = 0;
                            break;
                    }
                }

            }
            #endregion
        }
        
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
           printDocument1.Print(); 
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //tamaño de la boleta
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("GuiaRemitentePeso", 840, 940);
            printDocument1.DefaultPageSettings.Margins.Left = 0;
            printDocument1.DefaultPageSettings.Margins.Right = 0;
            printDocument1.DefaultPageSettings.Margins.Top = 0;
            printDocument1.DefaultPageSettings.Margins.Bottom = 0;
            printDocument1.OriginAtMargins = true;

            //formato para alinear los numeros a la derecha
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;

            #region Imprimir tipo Granja
            e.Graphics.DrawString(TxtFechaEmision.Text.Substring(0,10), TxtFechaEmision.Font, Brushes.Black, 120, 183);
            e.Graphics.DrawString(TxtOrden.Text, TxtFechaEmision.Font, Brushes.Black, 325, 188);
            e.Graphics.DrawString(TxtNumGuiaRemision.Text, TxtFechaEmision.Font, Brushes.Black, 600, 165);
            e.Graphics.DrawString(TxtFechaInicioTraslado.Text.Substring(0, 10), TxtFechaEmision.Font, Brushes.Black, 84, 296);
            e.Graphics.DrawString(TxtDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 130, 220);
            e.Graphics.DrawString("Nro:" + TxtNroDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 43, 240);
            e.Graphics.DrawString("Int: " + TxtIntDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 172, 240);
            e.Graphics.DrawString("Zona: " + TxtZonaDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 295, 240);
            e.Graphics.DrawString(TxtDisDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 89, 260);
            e.Graphics.DrawString(TxtProvDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 210, 260);
            e.Graphics.DrawString(TxtDepDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 350, 260);
            e.Graphics.DrawString(TxtDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 535, 225);
            e.Graphics.DrawString("Nro: " + TxtNroDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 454, 240);
            e.Graphics.DrawString("Int: " + TxtIntDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 573, 240);
            e.Graphics.DrawString("Zona: " + TxtZonaDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 692, 240);
            e.Graphics.DrawString("Dist: " + TxtDisDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 454, 260);
            e.Graphics.DrawString("Prov: " + TxtProvDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 575, 260);
            e.Graphics.DrawString("Dep: " + TxtDepDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 702, 260);
            e.Graphics.DrawString(TxtDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 253, 288);
            e.Graphics.DrawString(TxtRUCDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 330, 318);
            
            e.Graphics.DrawString(TxtMarca.Text, TxtFechaEmision.Font, Brushes.Black, 170, 340);
            e.Graphics.DrawString(TxtPlaca.Text, TxtFechaEmision.Font, Brushes.Black, 273, 340);
            e.Graphics.DrawString(TxtNroConstInscripcion.Text, TxtFechaEmision.Font, Brushes.Black, 196, 357);
            e.Graphics.DrawString(TxtNroLicTransaportista.Text, TxtFechaEmision.Font, Brushes.Black, 200, 374);
            e.Graphics.DrawString(TxtConfVehicular.Text, TxtFechaEmision.Font, Brushes.Black, 230, 390);
            e.Graphics.DrawString(TxtRUCTransporte.Text, TxtFechaEmision.Font, Brushes.Black, 560, 390);
            e.Graphics.DrawString(TxtEmpresaTransporte.Text, TxtFechaEmision.Font, Brushes.Black, 454, 380);
            
            e.Graphics.DrawString(TxtGalpon.Text, TxtFechaEmision.Font, Brushes.Black, 67, 650);
            e.Graphics.DrawString(TxtMacho.Text, TxtFechaEmision.Font, Brushes.Black, 160, 650);
            e.Graphics.DrawString(TxtHembra.Text, TxtFechaEmision.Font, Brushes.Black, 233, 650);
            e.Graphics.DrawString(TxtNroJabas.Text, TxtFechaEmision.Font, Brushes.Black, 325, 650);
            e.Graphics.DrawString(TxtAves.Text, TxtFechaEmision.Font, Brushes.Black, 406, 650);
            e.Graphics.DrawString(TxtPesoPromedio.Text, TxtFechaEmision.Font, Brushes.Black, 491, 650);
            e.Graphics.DrawString(TxtHoraEntrada.Text, TxtFechaEmision.Font, Brushes.Black, 571, 650);
            e.Graphics.DrawString(TxtHoraSalida.Text, TxtFechaEmision.Font, Brushes.Black, 661, 650);
            e.Graphics.DrawString(TxtHoraLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 749, 650);
            e.Graphics.DrawString(TxtBruto.Text, TxtFechaEmision.Font, Brushes.Black, 190, 680);
            e.Graphics.DrawString(TxtTara.Text, TxtFechaEmision.Font, Brushes.Black, 278, 680);
            e.Graphics.DrawString(TxtNeto.Text, TxtFechaEmision.Font, Brushes.Black, 380, 680);
            e.Graphics.DrawString(TxtPrecioUnitario.Text, TxtFechaEmision.Font, Brushes.Black, 491, 680);
            e.Graphics.DrawString(TxtTotalImporte.Text, TxtFechaEmision.Font, Brushes.Black, 611, 680);
            e.Graphics.DrawString(TxtCodigoDespacho.Text, TxtFechaEmision.Font, Brushes.Black, 726, 680);

            e.Graphics.DrawString(TxtRecFactNro.Text, TxtFechaEmision.Font, Brushes.Black, 128, 848);
            e.Graphics.DrawString(TxtFecha.Text, TxtFechaEmision.Font, Brushes.Black, 301, 848);
            e.Graphics.DrawString(TxtCostoMinimo.Text, TxtFechaEmision.Font, Brushes.Black, 204, 873);
            e.Graphics.DrawString(TxtPesoTotal.Text, TxtFechaEmision.Font, Brushes.Black, 350, 873);
            e.Graphics.DrawString(TxtPesador.Text, TxtFechaEmision.Font, Brushes.Black, 490, 767);
            e.Graphics.DrawString(TxtNombreChofer.Text, TxtFechaEmision.Font, Brushes.Black, 684, 767);
            e.Graphics.DrawString(TxtGalponero.Text, TxtFechaEmision.Font, Brushes.Black, 570, 838);
            e.Graphics.DrawString(TxtProducto.Text, TxtFechaEmision.Font, Brushes.Black, 525, 900);

            #region Imprimir los Detalles

            //filtrar los productos en una nueva tabla
            if (DtCabecera.Rows.Count > 0)
            {
                int sum = 0;
                int Columna = 1;
                int Contar = 0;
                int InicioPeso = 412;
                foreach (DataRow Row in DtTara.Rows)
                {
                    Contar++;
                    if (Contar == 11 | Contar == 21 | Contar == 31)
                        sum = 0;

                    if (Contar < 11)
                        Columna = 1;
                    else if (Contar < 21)
                        Columna = 2;
                    else if (Contar < 31)
                        Columna = 3;

                    if (Columna == 1)
                    {
                        sum += 20;
                        e.Graphics.DrawString(Row["Peso"].ToString(), TxtDomicilioLlegada.Font, Brushes.Black, 120, InicioPeso + sum, formato);
                    }
                    if (Columna == 2)
                    {
                        sum += 20;
                        e.Graphics.DrawString(Row["Peso"].ToString(), TxtDomicilioLlegada.Font, Brushes.Black, 200, InicioPeso + sum, formato);
                    }
                    if (Columna == 3)
                    {
                        sum += 20;
                        e.Graphics.DrawString(Row["Peso"].ToString(), TxtDomicilioLlegada.Font, Brushes.Black, 285, InicioPeso + sum, formato);
                    }
                }

                sum = 0;
                Contar = 0;
                Columna = 1;
                foreach (DataRow Row in DtBruto.Rows)
                { 
                    Contar++;
                    if (Contar == 11 | Contar == 21 | Contar == 31 | Contar == 41 | Contar == 51 | Contar == 61)
                        sum = 0;

                    if (Contar < 11)
                        Columna = 1;
                    else if (Contar < 21)
                        Columna = 2;
                    else if (Contar < 31)
                        Columna = 3;
                    else if (Contar < 41)
                        Columna = 4;
                    else if (Contar < 51)
                        Columna = 5;
                    else if (Contar < 61)
                        Columna = 6;

                    if (Columna == 1)
                    {
                        sum += 20;
                        e.Graphics.DrawString(Row["Peso"].ToString(), TxtDomicilioLlegada.Font, Brushes.Black, 370, InicioPeso + sum, formato);
                    }
                    if (Columna == 2)
                    {
                        sum += 20;
                        e.Graphics.DrawString(Row["Peso"].ToString(), TxtDomicilioLlegada.Font, Brushes.Black, 450, InicioPeso + sum, formato);
                    }
                    if (Columna == 3)
                    {
                        sum += 20;
                        e.Graphics.DrawString(Row["Peso"].ToString(), TxtDomicilioLlegada.Font, Brushes.Black, 535, InicioPeso + sum, formato);
                    }
                    if (Columna == 4)
                    {
                        sum += 20;
                        e.Graphics.DrawString(Row["Peso"].ToString(), TxtDomicilioLlegada.Font, Brushes.Black, 623, InicioPeso + sum, formato);
                    }
                    if (Columna == 5)
                    {
                        sum += 20;
                        e.Graphics.DrawString(Row["Peso"].ToString(), TxtDomicilioLlegada.Font, Brushes.Black, 710, InicioPeso + sum, formato);
                    }
                    if (Columna == 6)
                    {
                        sum += 20;
                        e.Graphics.DrawString(Row["Peso"].ToString(), TxtDomicilioLlegada.Font, Brushes.Black, 790, InicioPeso + sum, formato);
                    }
                    
                }
            }
            #endregion

            #endregion
            
        }

        private void BtnConsultar_Click_1(object sender, EventArgs e)
        {
            if (TxtGuia.Text != "")
            {
                MostrarGuia(TxtGuia.Text);
            }
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea anular la guia de remisión Nro: " + TxtNumGuiaRemision.Text + ".?", "Guia de remisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //****************************** anular guia *****************************************

                #region Crear Tablas
                //tabla para actualizar el nuevo stock (agregar productos recepcionados)
                DataTable DtActuStockLocal = new DataTable();
                DtActuStockLocal.TableName = "StockAlmacen";
                DtActuStockLocal.Columns.Add("NumRequerimiento", typeof(string));
                DtActuStockLocal.Columns.Add("AlmacenID", typeof(string));
                DtActuStockLocal.Columns.Add("ProductoID", typeof(string));
                DtActuStockLocal.Columns.Add("StockAdicion", typeof(decimal));
                #endregion

                //actualizar datos del requerimiento
                CL_Requerimientos ObjCL_Requerimientos = new CL_Requerimientos();
                CL_GuiaRemision ObjCL_GuiaRemision = new CL_GuiaRemision();

                foreach (DataRow Row2 in DtDetalle.Rows)
                {
                    #region Actualizar Estado Requerimientos
                    string NumRequerimiento;
                    decimal CantidadTransito;
                    string ProductoID;


                    NumRequerimiento = Row2["NumRequerimiento"].ToString();
                    ProductoID = Row2["ProductoID"].ToString();
                    CantidadTransito = Convert.ToDecimal(Row2["CantidadEnviada"]);

                    bool Valor;

                    Valor = ObjCL_Requerimientos.UpdateDetalleRequerimientoAnulado(NumRequerimiento, CantidadTransito, ProductoID, AppSettings.UserID, AppSettings.SedeID);

                    if (Valor == false)
                        MessageBox.Show("ocurrio un error al intentar actualizar el requerimiento: \r\nNumRequerimiento: " + NumRequerimiento + "ProductoID: " + ProductoID + "\r\nCantidadTransito: " + CantidadTransito, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Valor = ObjCL_GuiaRemision.UpdateGuiaRemisionEstado(TxtGuia.Text, 10, "A", AppSettings.UserID, AppSettings.SedeID);
                    #endregion

                    #region llenar tabla para actualizar el stock local
                    DataRow DrR = DtActuStockLocal.NewRow();
                    DrR["NumRequerimiento"] = Row2["NumRequerimiento"];
                    DrR["AlmacenID"] = AppSettings.EmpresaID + AppSettings.SedeID + "000";
                    DrR["ProductoID"] = Row2["ProductoID"];
                    DrR["StockAdicion"] = Row2["CantidadEnviada"];
                    DtActuStockLocal.Rows.Add(DrR);
                    #endregion

                }

                #region agrupar para actualizar el stock local
                //Agrupar los productos apra almacenarlos
                DataTable DtProducto = new DataTable();
                DataTable DtActuStockLocal2 = new DataTable();
                DtActuStockLocal2.TableName = "StockAlmacen";
                DtActuStockLocal2.Columns.Add("NumRequerimiento", typeof(string));
                DtActuStockLocal2.Columns.Add("AlmacenID", typeof(string));
                DtActuStockLocal2.Columns.Add("ProductoID", typeof(string));
                DtActuStockLocal2.Columns.Add("StockAdicion", typeof(decimal));
                DtProducto = new BaseFunctions().SelectDistinct(DtActuStockLocal, "ProductoID", "AlmacenID");
                foreach (DataRow RowP in DtProducto.Rows)
                {
                    DataView Dv = new DataView(DtActuStockLocal);
                    Dv.RowFilter = "ProductoID = '" + RowP["ProductoID"] + "' and AlmacenID = '" + RowP["AlmacenID"] + "'";
                    decimal Suma = 0;
                    string NumRequerimiento = "";
                    foreach (DataRowView Drv in Dv) //sumar las cantidades por producto
                    {
                        Suma += Convert.ToDecimal(Drv["StockAdicion"]);
                        NumRequerimiento = Drv["NumRequerimiento"].ToString();
                    }
                    DataRow DrR = DtActuStockLocal2.NewRow();
                    DrR["NumRequerimiento"] = NumRequerimiento;
                    DrR["AlmacenID"] = RowP["AlmacenID"];
                    DrR["ProductoID"] = RowP["ProductoID"];
                    DrR["StockAdicion"] = Suma;
                    DtActuStockLocal2.Rows.Add(DrR);
                }

                #endregion
                #region Actualizar el stock
                CL_Almacen ObjCL_Almacen = new CL_Almacen();

                foreach (DataRow R in DtActuStockLocal2.Rows)
                {
                    ObjCL_Almacen.UpdateStockAdidion(R["AlmacenID"].ToString(), R["ProductoID"].ToString(), Convert.ToDecimal(R["StockAdicion"]), R["NumRequerimiento"].ToString(), "R");
                }
                #endregion
            }

            MessageBox.Show("Se termino de anular la guía", "Guia remitente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnVistaPrevia_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            //printDialog1.AllowSelection = true;
            //printDialog1.AllowSomePages = true;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                ImpresoraGuiaRemitentePeso = printDialog1.PrinterSettings.PrinterName;
                //*****************guardar la configuracion de la impresora en el appconfig**************
                if (ImpresoraGuiaRemitentePeso != AppSettings.ImpresoraGuiaRemitentePeso & ImpresoraGuiaRemitentePeso != "")
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    AppSettingsSection appSettings = config.AppSettings;

                    KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraGuiaRemitentePeso"];
                    setting.Value = ImpresoraGuiaRemitentePeso;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                //************************ fin guardar configuracion ***************************************
            }
        }

    }
     
}

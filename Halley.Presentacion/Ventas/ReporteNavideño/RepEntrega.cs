using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Xml;
using C1.Win.C1TrueDBGrid;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.Utilitario;
using System.Drawing.Imaging;
using System.Reflection;
using Halley.Configuracion;
using RRV.Seguridad;

namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    public partial class RepEntrega : UITemplateAccess
    {
        #region variables globales
        DataTable dt;
        DataTable dtDetalle;

        #endregion

        #region constructor

        public RepEntrega()
        {
            InitializeComponent();
        }

        #endregion

        #region eventos del control

        private void RepEntrega_RefreshClick()
        {
            cargar();
        }

        private void RepEntrega_ExportClick()
        {
            try
            {
                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;
                    string ruta = string.Concat(f.SelectedPath, @"\", "REGISTRO DE ENTREGA.xls");
                    new Office().DoExcell(ruta, dt, "REGISTRO DE ENTREGA DE PAVOS");
                    string _nM = string.Format(_msg, ruta);
                    MessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;

            }
        }

      

        private void RepEntrega_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            cargar();
        }

        #endregion

        #region metodo definidos

        public static byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public void cargar()
        {
            dt = new DataTable();
            dt = new CL_Vales().getReporteEntrega(AppSettings.SedeID);
            tdbgEntrega.SetDataBinding(dt, "", true);
        }
        
        #endregion

        private void tdbgEntrega_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                objCrypto.Key = AppSettings.Key;
                objCrypto.IV = AppSettings.IV;

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

                string NumComprobante = this.tdbgEntrega.Columns["NumComprobante"].Value.ToString();
                int NumVale = int.Parse(this.tdbgEntrega.Columns["NumVale"].Value.ToString());

                dtDetalle = new DataTable();
                dtDetalle = new CL_Vales().getdetalleVales(NumComprobante, NumVale);

                foreach (DataRow fila in dtDetalle.Rows)
                {
                    DataRow row = dtVales.NewRow();
                    row["Comprobante"] = NumComprobante;
                    row["Cliente"] = fila["RazonSocial"].ToString();
                    row["Producto"] = fila["NomProducto"].ToString().Remove(fila["NomProducto"].ToString().IndexOf("X"));
                    row["Peso"] = string.Concat(string.Format("{0:0.##}", fila["Unidades"]), " KG");
                    row["NumVale"] = fila["NumVale"];
                    cadena = objCrypto.CifrarCadena(fila["NumVale"].ToString());

                    row["CodBar"] = string.Concat("*", fila["NumVale"].ToString().PadLeft(4, '/'), cadena.Substring(0, 7), "*");
                    row["Numeros"] = fila["NumVale"].ToString().PadLeft(4, '0');
                    row["Direccion"] = fila["Direccion"];
                    row["Foto"] = ImageToByteArray((Image)Halley.Presentacion.Properties.Resources.ResourceManager.GetObject(fila["Imagen"].ToString()));
                    dtVales.Rows.Add(row);
                }

                ReporteNavideño.RepGeneraVales Obj_RepVale = new ReporteNavideño.RepGeneraVales();
                Obj_RepVale.dtDetalleVales = dtVales;
                Obj_RepVale.ShowDialog();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);  
            }
           

        }
    }
}

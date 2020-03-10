using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.Configuracion;
using Halley.Utilitario;
using System.Net;


namespace Halley.Presentacion.Ventas.Administracion
{
    public partial class FrmImprimirPuntos : Form
    {
        CL_Venta ObjCL_Venta = new CL_Venta();
        CL_Comprobante ObjCL_Comprobante = new CL_Comprobante();
        private TextFunctions ObjTextFunctions = new TextFunctions();

        public string RUC { get; set; }
        public string NombreEmpresa { get; set; }
        public string NroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public int ClienteID { get; set; }

        public string EmpresaID { get; set; }

        public FrmImprimirPuntos()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.USStandardFanfold;
            string formatoimprimir = ObjCL_Venta.FormatoPuntos(RUC, NombreEmpresa, TxtConcepto.Text, NroDocumento, RazonSocial, TxtPuntosUsar.Text,
                (Convert.ToInt32(LblPuntosDisponibles.Text) - Convert.ToInt32(TxtPuntosUsar.Text)).ToString(), DateTime.Now);
            e.Graphics.DrawString(formatoimprimir, TxtFormato.Font, Brushes.Black, 1, 1); //total pagar en letras

            ObtenerPuntos();
            TxtPuntosUsar.Text = "";
            TxtConcepto.Text = "";
        }

        private void ObtenerPuntos() {
            //otenemos los puntos 
            DataTable Dt = ObjCL_Comprobante.ObtenerPuntosCliente(ClienteID);
            int puntos = 0;

            if (Dt.Rows.Count > 0)
                puntos = Convert.ToInt32(Dt.Rows[0]["PuntosDisponibles"]);

            LblPuntosDisponibles.Text = puntos.ToString();
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            string impresora = "";
            DataView DV = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo ='" + "IMP_" + EmpresaID + "_TI'", "", DataViewRowState.CurrentRows);

            if (DV.Count > 0)
            {
                impresora = DV[0]["Data"].ToString();
            }
            else {
                MessageBox.Show("Debe seleccionar una impresora (tipo ticket).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            

            if (TxtPuntosUsar.Text.Length > 0 && Convert.ToInt32(TxtPuntosUsar.Text) <= Convert.ToInt32(LblPuntosDisponibles.Text) && TxtConcepto.Text != ""  & Convert.ToInt32(TxtPuntosUsar.Text) > 0)
            {
                ObjCL_Comprobante.InsertarPuntos(ClienteID, Convert.ToInt32(TxtPuntosUsar.Text) * -1, TxtConcepto.Text, AppSettings.UserID);
                printDocument1.PrinterSettings.PrinterName = impresora;
                printDocument1.Print();
            }
            else
            {
                if ((TxtPuntosUsar.Text != "" && Convert.ToInt32(TxtPuntosUsar.Text) > Convert.ToInt32(LblPuntosDisponibles.Text)) | Convert.ToInt32(TxtPuntosUsar.Text) <= 0)
                    ErrProvider.SetError(TxtPuntosUsar, "los puntos a cobrar deben ser menor a los puntos disponibles y mayor a cero");
                if (TxtPuntosUsar.Text == "")
                    ErrProvider.SetError(TxtPuntosUsar, "Ingrese puntos a cobrar");
                if (TxtConcepto.Text == "")
                    ErrProvider.SetError(TxtConcepto, "Ingrese un concepto.");
            }

        }

        private void FrmCierre_Load(object sender, EventArgs e)
        {
            String NombreHost;
            String DireccionIP;
            NombreHost = Dns.GetHostName();
            CapaLogica.Users.CL_Usuario ObjUsuario = new CapaLogica.Users.CL_Usuario();
            //obtenemos las imrpesoras
            DireccionIP = System.Net.Dns.GetHostByName(NombreHost).AddressList[0] + "";
            //MessageBox.Show(DireccionIP);
            //dar formato a la direccion IP
            string ACU = "";
            string NuevaIP = "";
            for (int X = 0; X < DireccionIP.Length; X++)
            {
                string Valor = DireccionIP.Substring(X, 1);
                if (Valor != ".")
                    ACU += Valor;
                else
                {
                    NuevaIP += ACU.PadLeft(3, '0') + ".";
                    ACU = "";
                }
            }
            NuevaIP += ACU.PadLeft(3, '0');

            //traer impresoras
            UTI_Datatables.Dt_Configuracion = ObjUsuario.USP_M_CONFIGURACION(2, 0, "", "", "", "", AppSettings.UserID, NuevaIP);

            ObtenerPuntos();

            LblEmpresa.Text = NombreEmpresa;
            LblNroDocumento.Text = NroDocumento;
            LblRazonSocial.Text = RazonSocial;
            LblRUC.Text = RUC;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtPuntosUsar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtPuntosUsar);
        }
    }
}

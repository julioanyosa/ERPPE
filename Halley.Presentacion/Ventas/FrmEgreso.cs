using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Configuracion;
using Halley.CapaLogica.Ventas;
using Halley.Entidad.Ventas;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas
{
    public partial class FrmEgreso : Form
    {
        TextFunctions ObjTextFunctions = new TextFunctions();
        CL_Pago ObjCL_Pago = new CL_Pago();

        string NomEmpresa = "";
        string RUC = "";

        private int _NumCaja;

        public int NumCaja
        {
            get { return _NumCaja; }
            set { _NumCaja = value; }
        }

        private string _EmpresaID;

        public string EmpresaID
        {
            get { return _EmpresaID; }
            set { _EmpresaID = value; }
        }

        private string _NomCaja;

        public string NomCaja
        {
          get { return _NomCaja; }
          set { _NomCaja = value; }
        }

        private DataTable _DtEmpresas;

        public DataTable DtEmpresas
        {
          get { return _DtEmpresas; }
          set { _DtEmpresas = value; }
        }

        public FrmEgreso()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            try
            {
                if (TxtCantidad.Text != "" & TxtConcepto.Text != "")
                {
                    //inserta un ingreso a la caja

                    //llenar el objPago
                    E_Pago ObjE_Pago = new E_Pago();
                    ObjE_Pago.PagoID = 0;
                    ObjE_Pago.NumComprobante = "";
                    ObjE_Pago.TipoComprobanteID = 0;
                    ObjE_Pago.Importe = Convert.ToDecimal(TxtCantidad.Text);
                    ObjE_Pago.FormaPagoID = 2;//contado
                    ObjE_Pago.UsuarioID = AppSettings.UserID;


                    //llenar la nota de ingreso
                    E_NotaIngreso ObjE_NotaIngreso = new E_NotaIngreso();
                    ObjE_NotaIngreso.Tipo = "E";//es salida
                    ObjE_NotaIngreso.Numcaja = NumCaja;
                    ObjE_NotaIngreso.EmpresaID = EmpresaID;
                    ObjE_NotaIngreso.Observacion = "Inicio dia";
                    ObjE_NotaIngreso.LugarPago = AppSettings.SedeID;

                    if (AppSettings.ImpresoraPago != "")
                    {
                        Int32 NotaIngresoID = 0;
                        NotaIngresoID = ObjCL_Pago.InsertPago(ObjE_Pago, ObjE_NotaIngreso, 12);

                        printDocument1.PrinterSettings.PrinterName = AppSettings.ImpresoraPago;
                        printDocument1.Print();
                        MessageBox.Show("Se registro correctamente la salida de caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("no se ha seleccionado la impresora de pago, no se imprimira el Egreso", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if(TxtCantidad.Text == "") ErrProvider.SetError(TxtCantidad, "Debe ingresar una cantidad valida.");
                    if (TxtConcepto.Text == "") ErrProvider.SetError(TxtConcepto, "Debe ingresar el concepto del egreso.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\rMetodo Ingresar inicio caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region boleta ticketera
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.USStandardFanfold;
            string FormatoTotalesTicket = ObjCL_Pago.FormatoTickeEgreso(NomEmpresa, AppSettings.NomSede, RUC, AppSettings.Usuario,Convert.ToDecimal(TxtCantidad.Text), NomCaja,TxtConcepto.Text);
            e.Graphics.DrawString(FormatoTotalesTicket, TxtConcepto.Font, Brushes.Black,1, 1); //total pagar en letras

            #endregion
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtCantidad);
        }

        private void FrmEgreso_Load(object sender, EventArgs e)
        {
            //obtener datos de la empresa
            DataView DV = new DataView(DtEmpresas);
            //string EmpresaID = "IH";
            DV.RowFilter = "EmpresaID = '" + EmpresaID + "'";
            NomEmpresa = DV[0]["NomEmpresa"].ToString();
            RUC = DV[0]["RUC"].ToString();

            LblEmpresa.Text = NomEmpresa;
        }
    }
}

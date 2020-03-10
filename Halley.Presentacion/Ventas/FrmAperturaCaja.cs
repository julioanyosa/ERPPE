using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.CapaLogica.Ventas;
using Halley.Entidad.Ventas;
using Halley.Configuracion;

namespace Halley.Presentacion.Ventas
{
    public partial class FrmAperturaCaja : Form
    {
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
        private string _NroDocumento;

        public string NroDocumento
        {
            get { return _NroDocumento; }
            set { _NroDocumento = value; }
        }
        private string _Cliente;

        public string Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private int _ClienteID;

        public int ClienteID
        {
            get { return _ClienteID; }
            set { _ClienteID = value; }
        }

        TextFunctions ObjTextFunctions = new TextFunctions();
        CL_Pago ObjCL_Pago = new CL_Pago();
        string NomEmpresa, RUC;
        Int32 NotaIngresoID = 0;

        public FrmAperturaCaja()
        {
            InitializeComponent();
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtCantidad);
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                ErrProvider.Clear();
                if (TxtCantidad.Text != "")
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
                    ObjE_NotaIngreso.Tipo = "C";
                    ObjE_NotaIngreso.Numcaja = NumCaja;
                    ObjE_NotaIngreso.EmpresaID = EmpresaID;
                    ObjE_NotaIngreso.Observacion = "Inicio dia";
                    ObjE_NotaIngreso.LugarPago = AppSettings.SedeID;

                    NotaIngresoID = ObjCL_Pago.InsertPago(ObjE_Pago, ObjE_NotaIngreso, 12);
                    MessageBox.Show("Se registro correctamente El ingreso de caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    ErrProvider.SetError(TxtCantidad, "Ingrese una cantidad valida.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\rMetodo Ingresar inicio caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region ticketera
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.USStandardFanfold;
            string FormatoTotalesTicket = ObjCL_Pago.FormatoTickeIngreso(NomEmpresa, Cliente, NroDocumento, AppSettings.NomSede, RUC, AppSettings.Usuario, Convert.ToDecimal(TxtImporte.Text), NomCaja, TxtConcepto.Text, NotaIngresoID);
            e.Graphics.DrawString(FormatoTotalesTicket, TxtConcepto.Font, Brushes.Black, 1, 1); //total pagar en letras

            #endregion
        }

        private void TxtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtImporte);
        }

        private void FrmAperturaCaja_Load(object sender, EventArgs e)
        {
            //obtener datos de la empresa
            DataView DV = new DataView(DtEmpresas);
            //string EmpresaID = "IH";
            DV.RowFilter = "EmpresaID = '" + EmpresaID + "'";
            NomEmpresa = DV[0]["NomEmpresa"].ToString();
            RUC = DV[0]["RUC"].ToString();

            LblEmpresa.Text = NomEmpresa;
            LblNroDocumento.Text = NroDocumento;
            LblCliente.Text = Cliente;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            try
            {
                if (TxtImporte.Text != "" & TxtConcepto.Text != "")
                {
                    if (ClienteID == 0 | ClienteID == 1 | ClienteID == 204 | ClienteID == 241 | ClienteID == 3032)
                    {
                        MessageBox.Show("Debe exigir datos que identifiquen al cliente\nNo puede ser uno generico (Clientes varios)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //inserta un ingreso a la caja

                    //llenar el objPagos
                    E_Pago ObjE_Pago = new E_Pago();
                    ObjE_Pago.PagoID = 0;
                    ObjE_Pago.NumComprobante = "";
                    ObjE_Pago.TipoComprobanteID = 0;
                    ObjE_Pago.Importe = Convert.ToDecimal(TxtImporte.Text);
                    ObjE_Pago.FormaPagoID = 2;//contado
                    ObjE_Pago.UsuarioID = AppSettings.UserID;


                    //llenar la nota de ingreso
                    E_NotaIngreso ObjE_NotaIngreso = new E_NotaIngreso();
                    ObjE_NotaIngreso.Tipo = "A";//es Adelanto
                    ObjE_NotaIngreso.Numcaja = NumCaja;
                    ObjE_NotaIngreso.EmpresaID = EmpresaID;
                    ObjE_NotaIngreso.Observacion = TxtConcepto.Text;
                    ObjE_NotaIngreso.LugarPago = AppSettings.SedeID;
                    ObjE_NotaIngreso.ClienteID = ClienteID;
                    ObjE_NotaIngreso.Estado = 0;

                    if (AppSettings.ImpresoraPago != "")
                    {
                        
                        NotaIngresoID = ObjCL_Pago.InsertPago(ObjE_Pago, ObjE_NotaIngreso, 12);

                        printDocument1.PrinterSettings.PrinterName = AppSettings.ImpresoraPago;
                        printDocument1.Print();
                        MessageBox.Show("Se registro correctamente el adelanto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("no se ha seleccionado la impresora de pago, no se imprimira el adelanto", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (TxtImporte.Text == "") ErrProvider.SetError(TxtImporte, "Debe ingresar una cantidad valida.");
                    if (TxtConcepto.Text == "") ErrProvider.SetError(TxtConcepto, "Debe ingresar el concepto del adelanto.");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\rMetodo Ingresar adelanto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes ObjFrmClientes = new FrmClientes();
            ObjFrmClientes.ShowDialog();
            Cliente = ObjFrmClientes.Cliente;
            ClienteID = ObjFrmClientes.ClienteID;
            NroDocumento = ObjFrmClientes.NroDocumento;
            ObjFrmClientes.Dispose();

            LblEmpresa.Text = NomEmpresa;
            LblNroDocumento.Text = NroDocumento;
            LblCliente.Text = Cliente;
        }
    }

}

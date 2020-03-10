using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas.Pagos
{
    public partial class FrmBuscarComprobante : Form
    {
        #region variables
        CL_Cliente ObjCL_Cliente = new CL_Cliente();
        CL_Venta ObjCL_Venta = new CL_Venta();
        #endregion

        #region propiedades
        private DataTable _DtClientes;
        private int _TipoComprobanteID;
        private string _NumComprobante;
        private string _EmpresaID;

        public DataTable DtClientes
        {
            get { return _DtClientes; }
            set { _DtClientes = value; }
        }
        public int TipoComprobanteID
        {
            get { return _TipoComprobanteID; }
            set { _TipoComprobanteID = value; }
        }
        public string NumComprobante
        {
            get { return _NumComprobante; }
            set { _NumComprobante = value; }
        }
        public string EmpresaID
        {
            get { return _EmpresaID; }
            set { _EmpresaID = value; }
        }
        #endregion

        public FrmBuscarComprobante()
        {
            InitializeComponent();
        }

        private void TdgPreciosBuscados_DoubleClick(object sender, EventArgs e)
        {
            if (TdgComprobantes.RowCount > 0)
            {
                TipoComprobanteID = Convert.ToInt32(TdgComprobantes.Columns["TipoComprobanteID"].Value);
                NumComprobante = TdgComprobantes.Columns["NumComprobante"].Value.ToString().Substring(2);
                EmpresaID = TdgComprobantes.Columns["NumComprobante"].Value.ToString().Substring(0,2);
                this.Close();
            }
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            try 
	        {	    
                ErrProvider .Clear();
		        if (DtpFechaIni.Value != null & DtpFechaFin.Value != null & useCliente1.cbCliente.SelectedValue != null & CboTipoVenta.SelectedIndex != -1)
                {
                    DataTable DTComprobantes = new DataTable();
                    DTComprobantes = ObjCL_Cliente.GetComprobantesCliente(Convert.ToInt32(useCliente1.cbCliente.Columns["ClienteID"].Value), DtpFechaIni.Value, DtpFechaFin.Value.AddDays(1), Convert.ToInt32(CboTipoVenta.SelectedValue));
                    TdgComprobantes.SetDataBinding(DTComprobantes, "", true);
                }
                else
                {
                    if (useCliente1.cbCliente.SelectedIndex == -1) { MessageBox.Show("No se ha seleccionado el cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                    if (CboTipoVenta.SelectedIndex == -1) {ErrProvider.SetError(CboTipoVenta,"Debe seleccionar el tipo de venta"); }
                }
	        }
	        catch (Exception ex)
	        {
		        MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
	        }

        }

        private void FrmBuscarComprobante_Load(object sender, EventArgs e)
        {
            DtpFechaIni.Value = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            DtpFechaFin.Value = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month).ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            useCliente1.Cargar(DtClientes);
            DataTable DtTipoVentas = new DataTable();
            DtTipoVentas = ObjCL_Venta.GetTiposVenta();
            c1Combo.FillC1Combo1(CboTipoVenta, DtTipoVentas, "NomTipoVenta", "TipoVentaID");
        }
    }
}

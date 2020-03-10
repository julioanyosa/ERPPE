using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.CapaLogica.Empresa;
using Halley.CapaLogica.Almacen;
using CrystalDecisions.CrystalReports.Engine;
using Halley.Presentacion.Ventas.Pagos;
using Halley.CapaLogica.Ventas;

namespace Halley.Presentacion.Almacen.Reportes
{
    public partial class Despachos : UITemplateAccess
    {
        CL_Producto ObjCL_Producto = new CL_Producto();
        Halley.Presentacion.CrystalReports.CrDespacho ObjCrDespacho = new CrystalReports.CrDespacho();
        DataTable DtClientes = new DataTable();
        DataTable DtTipoComprobantes = new DataTable();
        DataSet DsComprobante = new DataSet();
        CL_Venta ObjCL_Venta = new CL_Venta();

        public Despachos()
        {
            InitializeComponent();
        }

        private void ProductosPorSede_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            DtTipoComprobantes = new CL_Comprobante().getTipoComprobante();
            c1Combo.FillC1Combo1(cbComprobante, DtTipoComprobantes, "NomTipoComprobante", "TipoComprobanteID");
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            DtClientes = new CL_Cliente().GetClientes();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (TxtNumComprobante.Text != "" && cbComprobante.SelectedIndex != -1 & c1cboCia.SelectedIndex != -1)
                {
                    DsComprobante = ObjCL_Venta.GetComprobante2(c1cboCia.SelectedValue.ToString() + TxtNumComprobante.Text, Convert.ToInt32(cbComprobante.SelectedValue));
                    
                    ObjCrDespacho.SetDataSource(DsComprobante);

                    CrvVentasSede.ReportSource = ObjCrDespacho;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.InnerException.Message);
                MessageBox.Show(ex.Message);
                Cursor = Cursors.Default;
            }

            Cursor = Cursors.Default;
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            FrmBuscarComprobante ObjFrmBuscarComprobante = new FrmBuscarComprobante();
            ObjFrmBuscarComprobante.DtClientes = DtClientes.Copy();
            ObjFrmBuscarComprobante.ShowDialog();
            if (ObjFrmBuscarComprobante.TipoComprobanteID != 0)
            {
                c1cboCia.SelectedValue = ObjFrmBuscarComprobante.EmpresaID;
                cbComprobante.SelectedValue = ObjFrmBuscarComprobante.TipoComprobanteID;
                TxtNumComprobante.Text = ObjFrmBuscarComprobante.NumComprobante;
                btnGenerar_Click(null, null);
            }
        }
    }
}

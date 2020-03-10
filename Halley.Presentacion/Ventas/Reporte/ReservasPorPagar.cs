using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using CrystalDecisions.CrystalReports.Engine;
using Halley.Configuracion;
using Halley.CapaLogica.Empresa;
using Halley.Utilitario;
using Halley.CapaLogica.Almacen;
namespace Halley.Presentacion.Ventas.Reporte
{
    public partial class ReservasPorPagar : UITemplateAccess
    {

        CL_Venta ObjCL_Venta = new CL_Venta();
        DataTable DtComprobante = new DataTable();
        Halley.Presentacion.Ventas.CrystalReports.CrGetReservasEstadoPago ObjCrGetReservasEstadoPago = new Halley.Presentacion.Ventas.CrystalReports.CrGetReservasEstadoPago();
        DateTime Fecinicio;
        DateTime FecFin;
        string NomSede, EmpresaSede, ProductoID, Empresa;

        public ReservasPorPagar()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            DtpFechaIni.Value = DateTime.Now.Date;
            DtpFechaFin.Value = DateTime.Now.Date;
            ocultarToolStrip();
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            DataTable DtProductos = new CL_Producto().GetProductos();
            //c1Combo.FillC1Combo(this.CboProducto, DtProductos, "Alias", "ProductoID");
            CboProducto.HoldFields();
            CboProducto.DataSource = DtProductos;
            CboProducto.DisplayMember = "Alias";
            CboProducto.ValueMember = "ProductoID";

            //obtener todas las sedes
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            c1Combo.FillC1Combo(CboSede, Dtsedes, "NomSede", "SedeID");
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (DtpFechaIni.Value != null & DtpFechaFin.Value != null & CboSede.SelectedIndex != -1 & c1cboCia.SelectedIndex != -1 & CboProducto.SelectedIndex != -1)
                {
                    ProductoID = CboProducto.SelectedValue.ToString();
                    Fecinicio = DtpFechaIni.Value;
                    FecFin = DtpFechaFin.Value.AddDays(1);
                    EmpresaSede = c1cboCia.SelectedValue.ToString() + CboSede.SelectedValue.ToString();
                    Empresa = c1cboCia.Columns["NomEmpresa"].Value.ToString();
                    NomSede = CboSede.Columns["NomSede"].Value.ToString();
                    DtComprobante = ObjCL_Venta.GetReservasEstadoPago(Fecinicio, FecFin, EmpresaSede, ProductoID);
                    ObjCrGetReservasEstadoPago.SetDataSource(DtComprobante);

                    CrvVentasSede.ReportSource = ObjCrGetReservasEstadoPago;
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrGetReservasEstadoPago.ReportDefinition.ReportObjects["TxtTitulo"];
                    txt.Text = "EMPRESA: " + Empresa + ". SEDE: " + NomSede;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.InnerException.Message);
                MessageBox.Show(ex.Message);

            }

            Cursor = Cursors.Default;
        }

    }
}

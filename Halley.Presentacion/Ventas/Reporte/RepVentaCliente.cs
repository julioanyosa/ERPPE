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
using CrystalDecisions.ReportAppServer;
using Halley.Configuracion;
using Halley.Utilitario;
using Halley.CapaLogica.Empresa;

namespace Halley.Presentacion.Ventas.Reporte
{
    public partial class RepVentaCliente : UITemplateAccess
    {

        CL_Venta ObjCL_Venta = new CL_Venta();
        DataTable DtCajas = new DataTable();
        DataSet DS;
        string EmpresaID, SedeID;

        public RepVentaCliente()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            DtpFechaIni.Value = DateTime.Now.Date;
            DtpFechaFin.Value = DateTime.Now.Date;
            ocultarToolStrip();

            //traer los cajeros
            DtCajas = ObjCL_Venta.GetCajeros();
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            c1Combo.FillC1Combo(this.CboCajero, DtCajas, "Descripcion", "UserID");

            //obtener todas las sedes
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            c1Combo.FillC1Combo(CboSede, Dtsedes, "NomSede", "SedeID");

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (c1cboCia.SelectedIndex != -1 & CboSede.SelectedIndex != -1 & DtpFechaIni.Value != null & DtpFechaFin.Value != null & CboCajero.SelectedIndex != -1)
                {
                    EmpresaID = c1cboCia.SelectedValue.ToString();
                    SedeID = CboSede.SelectedValue.ToString();
                    DS = ObjCL_Venta.GetDetalleVentasComprobante(DtpFechaIni.Value, DtpFechaFin.Value.AddDays(1), Convert.ToInt32(CboCajero.SelectedValue), EmpresaID, SedeID);
                    Halley.Presentacion.Ventas.CrystalReports.CrVentasComprobante ObjCrpVentasComprobante = new Halley.Presentacion.Ventas.CrystalReports.CrVentasComprobante();
                    ObjCrpVentasComprobante.SetDataSource(DS);

                    CrvResumenVentas.ReportSource = ObjCrpVentasComprobante;
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["TxtReporte"];
                    txt.Text = "CUADRE DE CAJA DE " + DtpFechaIni.Value.Date.ToShortDateString().ToString() + " A " + DtpFechaFin.Value.Date.ToShortDateString().ToString();
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

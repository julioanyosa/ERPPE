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
using Halley.Utilitario;
using Halley.CapaLogica.Empresa;

namespace Halley.Presentacion.Ventas.Reporte
{
    public partial class ReporteAnuladoComprobante : UITemplateAccess
    {

        CL_Venta ObjCL_Venta = new CL_Venta();
        DataTable DtComprobantesAnulados = new DataTable();
        string EmpresaID, SedeID;

        public ReporteAnuladoComprobante()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            DtpFechaIni.Value = DateTime.Now.Date;
            DtpFechaFin.Value = DateTime.Now.Date;
            ocultarToolStrip();

            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");

            //obtener todas las sedes
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            c1Combo.FillC1Combo(CboSede, Dtsedes, "NomSede", "SedeID");

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (c1cboCia.SelectedIndex != -1 & CboSede.SelectedIndex != -1 & DtpFechaIni.Value != null & DtpFechaFin.Value != null)
                {
                    EmpresaID = c1cboCia.SelectedValue.ToString();
                    SedeID = CboSede.SelectedValue.ToString();
                    DtComprobantesAnulados = ObjCL_Venta.GetComprobantesAnulados(DtpFechaIni.Value, DtpFechaFin.Value.AddDays(1), EmpresaID, SedeID);
                    Halley.Presentacion.Ventas.CrystalReports.CrComprobantesAnulados ObjCrComprobantesAnulados = new Halley.Presentacion.Ventas.CrystalReports.CrComprobantesAnulados();
                    ObjCrComprobantesAnulados.SetDataSource(DtComprobantesAnulados);

                    CrvResumenVentas.ReportSource = ObjCrComprobantesAnulados;
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrComprobantesAnulados.ReportDefinition.ReportObjects["TxtTitulo"];
                    txt.Text = "COMPROBANTES ANULADOS DESDE " + DtpFechaIni.Value.Date.ToShortDateString().ToString() + " A " + DtpFechaFin.Value.Date.ToShortDateString().ToString();
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
    }
}

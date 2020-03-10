using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Halley.Configuracion;
using Halley.Utilitario;
using Halley.CapaLogica.Ventas;

namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    public partial class RepVentasVavidenhas : UITemplateAccess
    {

        CL_Venta ObjCL_Venta = new CL_Venta();
        Halley.Presentacion.Ventas.CrystalReports.CrGetVentasNavidenhasPorFecha ObjCrGetVentasNavidenhasPorFecha = new Halley.Presentacion.Ventas.CrystalReports.CrGetVentasNavidenhasPorFecha();
        DateTime Fecinicio;
        DateTime FecFin;
        DataTable DtVentasNavidenha = new DataTable();

        public RepVentasVavidenhas()
        {
            InitializeComponent();
        }

        private void RepVentasVavidenhas_Load(object sender, EventArgs e)
        {
            DtpFechaIni.Value = DateTime.Now.Date;
            DtpFechaFin.Value = DateTime.Now.Date;
            ocultarToolStrip();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                Fecinicio = DtpFechaIni.Value;
                FecFin = DtpFechaFin.Value.AddDays(1);

                if (DtpFechaIni.Value != null & DtpFechaFin.Value != null )
                {
                    DtVentasNavidenha = ObjCL_Venta.GetVentasNavidenhasPorFecha(Fecinicio, FecFin);
                    ObjCrGetVentasNavidenhasPorFecha.SetDataSource(DtVentasNavidenha);

                    CrvVentasNavidenha.ReportSource = ObjCrGetVentasNavidenhasPorFecha;
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrGetVentasNavidenhasPorFecha.ReportDefinition.ReportObjects["TxtTitulo"];
                    txt.Text = "Ventas de Productos navideños comprendidos entre: " + Fecinicio.Date.ToString().Substring(0, 10) + " y " + FecFin.Date.ToString().Substring(0, 10);
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

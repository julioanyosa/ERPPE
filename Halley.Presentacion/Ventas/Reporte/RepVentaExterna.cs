using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Configuracion;
using Halley.CapaLogica.Ventas;

namespace Halley.Presentacion.Ventas.Reporte
{
    public partial class RepVentaExterna : UITemplateAccess
    {
        public RepVentaExterna()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dt = new CL_Venta().getVentaExterna(AppSettings.EmpresaID, AppSettings.SedeID, dtpInicial.Value, dtpFinal.Value);

            Halley.Presentacion.CrystalReports.rpt_VentaExterna objVentaExterna = new Halley.Presentacion.CrystalReports.rpt_VentaExterna();
            objVentaExterna.SetDataSource(dt);
            this.crvVentaExterna.ReportSource = objVentaExterna;
        }
    }
}

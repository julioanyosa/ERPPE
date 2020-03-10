using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using RRV.Seguridad;
using Halley.Configuracion;

namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    public partial class RepGeneraVales : Form
    {
        #region variables globales
        public DataTable dtDetalleVales { get; set; }

        #endregion

        public RepGeneraVales()
        {
            InitializeComponent();
        }

        private void RepGeneraVales_Load(object sender, EventArgs e)
        {
            Halley.Presentacion.CrystalReports.rpt_GenerarVales ObjVales = new Halley.Presentacion.CrystalReports.rpt_GenerarVales();
            ObjVales.SetDataSource(dtDetalleVales);
            this.crvDetalle.ReportSource = ObjVales;
        }

        private void RepGeneraVales_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

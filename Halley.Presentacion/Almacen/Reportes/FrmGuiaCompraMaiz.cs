using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using CrystalDecisions.CrystalReports.Engine;  //importante esta libreria para que funcione
using Halley.Configuracion;

namespace Halley.Presentacion.Almacen.Reportes
{
	public partial class FrmGuiaCompraMaiz: Form
	{
        private string _NumHojaLiquidacion;

        public string NumHojaLiquidacion
        {
            get { return _NumHojaLiquidacion; }
            set { _NumHojaLiquidacion = value; }
        }
		public FrmGuiaCompraMaiz()
		{
			InitializeComponent();
		}

        private void FrmGuiaCompraMaiz_Load(object sender, EventArgs e)
        {
            try
            {
                if (NumHojaLiquidacion != "")
                {
                    TxtNroHojaLiquidacion.Text = NumHojaLiquidacion;
                    Cursor = Cursors.WaitCursor;
                    Halley.Presentacion.CrystalReports.CrGuiaCompraMaiz rpt = new CrystalReports.CrGuiaCompraMaiz();

                    DataSet DS = new DataSet();

                    DS = new CL_GuiaCompraMaiz().GetFormatoHojaLiquidacion(NumHojaLiquidacion);

                    rpt.SetDataSource(DS);
                    //Establecemos los datos al reporte
                    this.CrvGuiaCompraMaiz.ReportSource = rpt;
                    //Refrescamos nuestro reporte
                    this.CrvGuiaCompraMaiz.RefreshReport();
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            NumHojaLiquidacion = TxtNroHojaLiquidacion.Text;
            FrmGuiaCompraMaiz_Load(null, null);
        }
	}
}

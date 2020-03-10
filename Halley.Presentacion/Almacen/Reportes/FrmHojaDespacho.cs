using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Halley.CapaLogica.Almacen;
using CrystalDecisions.CrystalReports.Engine;  //importante esta libreria para que funcione
using Halley.Configuracion;

namespace Halley.Presentacion.Almacen.Reportes
{
    public partial class FrmHojaDespacho : Form
    {
        public FrmHojaDespacho()
        {
            InitializeComponent();
        }

        private string _NumHojaDespacho;

        public string NumHojaDespacho
        {
            get { return _NumHojaDespacho; }
            set { _NumHojaDespacho = value; }
        }



        private void FrmHojaDespacho_Load(object sender, EventArgs e)
        {

            try
            {
                CrystalReports.CrHojaDespacho rpt = new CrystalReports.CrHojaDespacho();
                DataSet DS = new DatasetReportes.DsHojaDespacho();
                DataTable Usp_GetCabeceraHojaDespacho = new DataTable();
                Usp_GetCabeceraHojaDespacho = new CL_HojaDespacho().GetCabeceraHojaDespacho(NumHojaDespacho);

                DataTable Usp_GetDetalleHojaDespacho = new DataTable();
                Usp_GetDetalleHojaDespacho = new CL_HojaDespacho().GetDetalleHojaDespacho(NumHojaDespacho);

                DS.Tables["Usp_GetCabeceraHojaDespacho"].Merge(Usp_GetCabeceraHojaDespacho);
                DS.Tables["Usp_GetDetalleHojaDespacho"].Merge(Usp_GetDetalleHojaDespacho);

                rpt.SetDataSource(DS);
                //Establecemos los datos al reporte
                this.CrvHojaDespacho.ReportSource = rpt;
                //Refrescamos nuestro reporte
                this.CrvHojaDespacho.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

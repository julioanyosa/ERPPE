using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Halley.CapaLogica.Ventas;
using Halley.CapaLogica.Empresa;
using Halley.Utilitario;
using Halley.Configuracion;

namespace Halley.Presentacion.Ventas.Reporte
{
    public partial class RptVendedor : UITemplateAccess
    {
        DataSet Ds = new DatasetReportes.DsVendedor();
        DataTable Usp_GetVendedores = new DataTable();
        DataTable DtSede = new DataTable();
        CL_Venta ObjCL_Venta = new CL_Venta();
        CL_Empresas ObjCL_Empresas = new CL_Empresas();

        public RptVendedor()
        {
            InitializeComponent();
        }

        private void RptVendedor_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            DtSede = ObjCL_Empresas.GetSedes();
            c1Combo.FillC1Combo(this.CboSede, DtSede, "NomSede", "SedeID");
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if(CboSede.SelectedIndex != -1)
                {


                    Halley.Presentacion.Ventas.CrystalReports.CrVendedor rpt = new Halley.Presentacion.Ventas.CrystalReports.CrVendedor();

                    Usp_GetVendedores.Clear();


                    Usp_GetVendedores = ObjCL_Venta.GetVendedores(CboSede.SelectedValue.ToString());
                    Ds.Tables["Usp_GetVendedores"].Clear();
                    Ds.Tables["Usp_GetVendedores"].Merge(Usp_GetVendedores);

                    rpt.SetDataSource(Ds);
                    //Establecemos los datos al reporte
                    this.CrvVendedores.ReportSource = rpt;
                    //pasar datos directo al crystal reports
                    rpt.DataDefinition.FormulaFields[1].Text = "'Vendedores de la sede: " + CboSede.Columns["NomSede"].Value.ToString() + "'";
                    //Refrescamos nuestro reporte
                    this.CrvVendedores.RefreshReport();
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

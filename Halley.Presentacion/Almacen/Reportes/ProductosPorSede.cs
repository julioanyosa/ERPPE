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

namespace Halley.Presentacion.Almacen.Reportes
{
    public partial class ProductosPorSede : UITemplateAccess
    {
        CL_Producto ObjCL_Producto = new CL_Producto();
        Halley.Presentacion.CrystalReports.CrGetStockPorSedes ObjCrpVentasSede = new CrystalReports.CrGetStockPorSedes();

        public ProductosPorSede()
        {
            InitializeComponent();
        }

        private void ProductosPorSede_Load(object sender, EventArgs e)
        {
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
                if (CboSede.SelectedIndex != -1 & c1cboCia.SelectedIndex != -1)
                {
                    DataTable DtStockSedes = new DataTable();
                    string EmpresaSede = c1cboCia.SelectedValue.ToString() + CboSede.SelectedValue.ToString();
                    DtStockSedes = ObjCL_Producto.GetStockPorSedes(EmpresaSede);
                    string NomSede = CboSede.Columns["NomSede"].Value.ToString();
                    string Empresa = c1cboCia.Columns["NomEmpresa"].Value.ToString();
                    ObjCrpVentasSede.SetDataSource(DtStockSedes);

                    CrvVentasSede.ReportSource = ObjCrpVentasSede;
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrpVentasSede.ReportDefinition.ReportObjects["TxtTitulo"];
                    txt.Text = "EMPRESA: " + Empresa + "   -   SEDE: " + NomSede;

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

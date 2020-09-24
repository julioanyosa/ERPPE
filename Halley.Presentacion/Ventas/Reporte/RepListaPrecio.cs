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
    public partial class RepListaPrecio : UITemplateAccess
    {

        CL_Venta ObjCL_Venta = new CL_Venta();
        DataTable DtComprobante = new DataTable();
        Halley.Presentacion.Ventas.CrystalReports.CrListaPrecios ObjCrListaPrecios = new Halley.Presentacion.Ventas.CrystalReports.CrListaPrecios();
        DateTime Fecinicio;
        DateTime FecFin;
        string NomSede, EmpresaID, SedeID, ProductoID, Empresa;

        public RepListaPrecio()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
          
            ocultarToolStrip();
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            DataTable DtProductos = new CL_Producto().GetProductos();
           

            //obtener todas las sedes
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            c1Combo.FillC1Combo(CboSede, Dtsedes, "NomSede", "SedeID");
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (CboSede.SelectedIndex != -1 & c1cboCia.SelectedIndex != -1 )
                {
                  
                    EmpresaID = c1cboCia.SelectedValue.ToString();
                    SedeID = CboSede.SelectedValue.ToString();
                    Empresa = c1cboCia.Columns["NomEmpresa"].Value.ToString();
                    NomSede = CboSede.Columns["NomSede"].Value.ToString();
                    DtComprobante = ObjCL_Venta.ListarPrecios(EmpresaID, SedeID);
                    ObjCrListaPrecios.SetDataSource(DtComprobante);

                    CrvVentasSede.ReportSource = ObjCrListaPrecios;
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrListaPrecios.ReportDefinition.ReportObjects["TxtTitulo1"];
                    txt.Text =  Empresa;

                    TextObject txt2;
                    txt2 = (TextObject)ObjCrListaPrecios.ReportDefinition.ReportObjects["TxtTitulo"];
                    txt2.Text = "LISTADO DE PRECIOS. SEDE: " + NomSede;
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

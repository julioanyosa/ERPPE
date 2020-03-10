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
    public partial class RepVales : UITemplateAccess
    {

        CL_Venta ObjCL_Venta = new CL_Venta();
        DateTime Fecinicio, FecFin;
        DataSet DS;

        public RepVales()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            DtpFechaIni.Value = DateTime.Now.Date;
            DtpFechaFin.Value = DateTime.Now.Date;
            ocultarToolStrip();

            //traer las empresas
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (DtpFechaIni.Value != null & DtpFechaFin.Value != null)
                {

                    Fecinicio = DtpFechaIni.Value;
                    FecFin = DtpFechaFin.Value.AddDays(1);

                    Halley.Presentacion.Ventas.CrystalReports.CrValesEmitidos ObjCrCrGetValesConsumo = new Halley.Presentacion.Ventas.CrystalReports.CrValesEmitidos();
                    DataTable DtVales = new DataTable();
                    DtVales = ObjCL_Venta.GetValesEmitidos(c1cboCia.SelectedValue.ToString(), Fecinicio, FecFin);
                    DataSet Ds = new DataSet();
                    DataTable Dt = new DataTable("Logo");
                    Dt.Columns.Add("Logo", typeof(byte[]));
                    Dt.Columns.Add("NomEmpresa", typeof(string));
                    DataRow Dr = Dt.NewRow();
                    // El campo productImage primero se almacena en un buffer
                    DataRow[] customerRow = UTI_Datatables.DtEmpresas.Select("EmpresaID = '" + c1cboCia.SelectedValue.ToString() + "'");
                    if (customerRow[0]["Logo"] != DBNull.Value)
                    {
                        Dr["Logo"] = customerRow[0]["Logo"];
                    }
                    else
                        Dr["Logo"] = DBNull.Value;
                    Dr["NomEmpresa"] = customerRow[0]["NomEmpresa"];

                    Dt.Rows.Add(Dr);
                    DtVales.TableName = "GetValesConsumo";
                    Ds.Tables.Add(Dt);
                    Ds.Tables.Add(DtVales);
                    ObjCrCrGetValesConsumo.SetDataSource(Ds);

                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrCrGetValesConsumo.ReportDefinition.ReportObjects["TxtTitulo"];
                    txt.Text = "Reporte de vales entre  " + Fecinicio.ToShortDateString() + " Y " + FecFin.AddDays(-1).ToShortDateString();
                    CrvValesConsumo.ReportSource = ObjCrCrGetValesConsumo;
                    CrvValesConsumo.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor = Cursors.Default;
        }
    }
}

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

namespace Halley.Presentacion.Ventas.Reporte
{
    public partial class VentasSede : UITemplateAccess
    {

        CL_Venta ObjCL_Venta = new CL_Venta();
        DataTable DtComprobante = new DataTable();
        Halley.Presentacion.Ventas.CrystalReports.CrVentasSede ObjCrpVentasSede = new Halley.Presentacion.Ventas.CrystalReports.CrVentasSede();
        DateTime Fecinicio;
        DateTime FecFin;
        string NomSede, EmpresaSede;

        public VentasSede()
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
                if (DtpFechaIni.Value != null & DtpFechaFin.Value != null & CboSede.SelectedIndex != -1 & c1cboCia.SelectedIndex != -1)
                {
                    Fecinicio = Convert.ToDateTime(DtpFechaIni.Value.ToShortDateString());
                    FecFin = Convert.ToDateTime(DtpFechaFin.Value.ToShortDateString());
                    EmpresaSede = c1cboCia.SelectedValue.ToString() + CboSede.SelectedValue.ToString();



                    DtComprobante = ObjCL_Venta.GetVentasSede(Fecinicio, FecFin, EmpresaSede);

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
                    DtComprobante.TableName = "Comprobante";
                    Ds.Tables.Add(Dt);
                    Ds.Tables.Add(DtComprobante);

                    NomSede = CboSede.Columns["NomSede"].Value.ToString();
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrpVentasSede.ReportDefinition.ReportObjects["TxtReporte1"];
                    txt.Text = "SEDE: " + NomSede;
                    TextObject txt2;
                    txt2 = (TextObject)ObjCrpVentasSede.ReportDefinition.ReportObjects["TxtReporte2"];
                    txt2.Text = "FECHA: " + Fecinicio.ToShortDateString().ToString() + " A " + DtpFechaFin.Value.ToShortDateString();
                    ObjCrpVentasSede.SetDataSource(Ds);
                    CrvVentasSede.ReportSource = ObjCrpVentasSede;
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

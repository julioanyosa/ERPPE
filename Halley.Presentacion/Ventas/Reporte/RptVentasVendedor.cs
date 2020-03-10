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
    public partial class RptVentasVendedor : UITemplateAccess
    {

        CL_Venta ObjCL_Venta = new CL_Venta();
        DataTable DtVentasVendedor = new DataTable();
        DateTime Fecinicio;
        DateTime FecFin;

        public RptVentasVendedor()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            c1cboCia.SelectedValue = AppSettings.EmpresaID;

            //obtener todas las sedes
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            c1Combo.FillC1Combo(CboSede, Dtsedes, "NomSede", "SedeID");
            CboSede.SelectedValue = AppSettings.SedeID;
            DtpFechaIni.Value = DateTime.Now.Date;
            DtpFechaFin.Value = DateTime.Now.Date;
            ocultarToolStrip();

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (DtpFechaIni.Value != null & DtpFechaFin.Value != null)
                {

                    Fecinicio = Convert.ToDateTime(DtpFechaIni.Value.ToShortDateString());
                    FecFin = Convert.ToDateTime(DtpFechaFin.Value.ToShortDateString());

                    if (RbDetallado.Checked == true)
                    {
                        Halley.Presentacion.Ventas.CrystalReports.CrGetVentasVendedor ObjCrCrGetVentasVendedor = new Halley.Presentacion.Ventas.CrystalReports.CrGetVentasVendedor();
                        DtVentasVendedor = ObjCL_Venta.GetVentasVendedor(CboSede.SelectedValue.ToString(), c1cboCia.SelectedValue.ToString(), Fecinicio, FecFin, "D");
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
                        DtVentasVendedor.TableName = "VentasVendedor";
                        Ds.Tables.Add(Dt);
                        Ds.Tables.Add(DtVentasVendedor);
                        ObjCrCrGetVentasVendedor.SetDataSource(Ds);

                        //pasar datos directo al crystal reports
                        TextObject txt;
                        txt = (TextObject)ObjCrCrGetVentasVendedor.ReportDefinition.ReportObjects["TxtTitulo"];
                        txt.Text = "VENTAS POR VENDEDORES ENTRE " + Fecinicio.ToString() + " Y " + FecFin.ToString();
                        CrvVentasSede.ReportSource = ObjCrCrGetVentasVendedor;
                    }
                    else if (RbResumido.Checked == true)
                    {
                        Halley.Presentacion.Ventas.CrystalReports.CrGetVentasVendedorResumido ObjCrCrGetVentasVendedor = new Halley.Presentacion.Ventas.CrystalReports.CrGetVentasVendedorResumido();
                        DtVentasVendedor = ObjCL_Venta.GetVentasVendedor(CboSede.SelectedValue.ToString(), c1cboCia.SelectedValue.ToString(), Fecinicio, FecFin, "R");
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
                        DtVentasVendedor.TableName = "GetVentasVendedorResumido";
                        Ds.Tables.Add(Dt);
                        Ds.Tables.Add(DtVentasVendedor);
                        ObjCrCrGetVentasVendedor.SetDataSource(Ds);

                        //pasar datos directo al crystal reports
                        TextObject txt;
                        txt = (TextObject)ObjCrCrGetVentasVendedor.ReportDefinition.ReportObjects["TxtTitulo"];
                        txt.Text = "Ventas por vendedores entre " + Fecinicio.ToShortDateString() + " Y " + FecFin.AddDays(-1).ToShortDateString();
                        CrvVentasSede.ReportSource = ObjCrCrGetVentasVendedor;
                    }
                    else if (RbProducto.Checked == true)
                    {
                        Halley.Presentacion.Ventas.CrystalReports.CrVentasProducto_R ObjCrCrGetVentasVendedor = new Halley.Presentacion.Ventas.CrystalReports.CrVentasProducto_R();
                        DtVentasVendedor = ObjCL_Venta.GetVentasVendedor(CboSede.SelectedValue.ToString(), c1cboCia.SelectedValue.ToString(), Fecinicio, FecFin, "E");
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
                        DtVentasVendedor.TableName = "RepConVales";
                        Ds.Tables.Add(Dt);
                        Ds.Tables.Add(DtVentasVendedor);
                        ObjCrCrGetVentasVendedor.SetDataSource(Ds);

                        //pasar datos directo al crystal reports
                        TextObject txt;
                        txt = (TextObject)ObjCrCrGetVentasVendedor.ReportDefinition.ReportObjects["TxtTitulo"];
                        txt.Text = "Ventas por productos entre " + Fecinicio.ToShortDateString() + " Y " + FecFin.AddDays(-1).ToShortDateString();
                        CrvVentasSede.ReportSource = ObjCrCrGetVentasVendedor;
                    }
                    else if (RbProductosVendedor.Checked == true)
                    {
                        Halley.Presentacion.Ventas.CrystalReports.CrVentasProducto_D ObjCrCrGetVentasVendedor = new Halley.Presentacion.Ventas.CrystalReports.CrVentasProducto_D();
                        DtVentasVendedor = ObjCL_Venta.GetVentasVendedor(CboSede.SelectedValue.ToString(), c1cboCia.SelectedValue.ToString(), Fecinicio, FecFin, "F");
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
                        DtVentasVendedor.TableName = "RepConVales";
                        Ds.Tables.Add(Dt);
                        Ds.Tables.Add(DtVentasVendedor);
                        ObjCrCrGetVentasVendedor.SetDataSource(Ds);

                        //pasar datos directo al crystal reports
                        TextObject txt;
                        txt = (TextObject)ObjCrCrGetVentasVendedor.ReportDefinition.ReportObjects["TxtTitulo"];
                        txt.Text = "Ventas por productos y vendedor entre " + Fecinicio.ToShortDateString() + " Y " + FecFin.AddDays(-1).ToShortDateString();
                        CrvVentasSede.ReportSource = ObjCrCrGetVentasVendedor;
                    }
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

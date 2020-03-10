using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.Configuracion;
using Halley.CapaLogica.Empresa;
using Halley.Utilitario;
using CrystalDecisions.CrystalReports.Engine;

namespace Halley.Presentacion.Ventas.Reporte
{
    public partial class RepPendientePago : UITemplateAccess
    {

        Halley.Presentacion.CrystalReports.CrGetVentasCredito ObjCrGetVentasCredito = new Halley.Presentacion.CrystalReports.CrGetVentasCredito();
        CL_Credito ObjCL_Credito = new CL_Credito();
        DateTime Fecinicio;
        DateTime FecFin;
        string EmpresaID;
        DataTable DtVentasCredito;

        public RepPendientePago()
        {
            InitializeComponent();
        }

        private void RepPendientePago_Load(object sender, EventArgs e)
        {
            DtpFechaIni.Value = DateTime.Now.Date;
            DtpFechaFin.Value = DateTime.Now.Date;
            ocultarToolStrip();

            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
             Cursor = Cursors.WaitCursor;
            try
            {
                if (DtpFechaIni.Value != null & DtpFechaFin.Value != null & c1cboCia.SelectedIndex != -1)
                {
                    Fecinicio = DtpFechaIni.Value;
                    FecFin = DtpFechaFin.Value.AddDays(1);
                    EmpresaID = c1cboCia.SelectedValue.ToString();

                    DtVentasCredito = ObjCL_Credito.GetVentasCredito(EmpresaID, Fecinicio, FecFin);

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
                    DtVentasCredito.TableName = "GetVentasCredito";
                    Ds.Tables.Add(Dt);
                    Ds.Tables.Add(DtVentasCredito);

                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrGetVentasCredito.ReportDefinition.ReportObjects["Txt1"];
                    txt.Text = "Ventas al credito entre " + DtpFechaIni.Value.ToShortDateString() + " y " + DtpFechaFin.Value.ToShortDateString();
                    
                    ObjCrGetVentasCredito.SetDataSource(Ds);
                    crvPendientePago.ReportSource = ObjCrGetVentasCredito;
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

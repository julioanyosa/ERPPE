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

namespace Halley.Presentacion.Compras.Reportes
{
    public partial class ComprasMaiz : UITemplateAccess
    {
        CL_Producto ObjCL_Producto = new CL_Producto();

        public ComprasMaiz()
        {
            InitializeComponent();
        }

        private void ComprasMaiz_Load(object sender, EventArgs e)
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
                if (c1cboCia.SelectedIndex != -1 & DtpFechaIni.Value != null & DtpFechaFin.Value != null)
                {
                    string EmpresaID = c1cboCia.SelectedValue.ToString();
                    DataTable DtComprobantesAnulados = new DataTable();
                    DtComprobantesAnulados = ObjCL_Producto.GetGuiaCompraMaizPorFecha(DtpFechaIni.Value, DtpFechaFin.Value.AddDays(1), EmpresaID);
                    Halley.Presentacion.CrystalReports.CrGetGuiaCompraMaizPorFecha ObjCrGetGuiaCompraMaizPorFecha = new Halley.Presentacion.CrystalReports.CrGetGuiaCompraMaizPorFecha();
                    ObjCrGetGuiaCompraMaizPorFecha.SetDataSource(DtComprobantesAnulados);

                    CrvGuiasCompras.ReportSource = ObjCrGetGuiaCompraMaizPorFecha;
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrGetGuiaCompraMaizPorFecha.ReportDefinition.ReportObjects["TxtTitulo"];
                    txt.Text = "COMPRAS HECHAS POR PESO DESDE: " + DtpFechaIni.Value.Date.ToShortDateString().ToString() + " A " + DtpFechaFin.Value.Date.ToShortDateString().ToString() + "DE LA EMPRESA: " + c1cboCia.Columns["NomEmpresa"].Value.ToString();
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

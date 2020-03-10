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
    public partial class RptPagos : UITemplateAccess
    {
        DataSet Ds = new DatasetReportes.DsPagosCredito();
        CL_Venta ObjCL_Venta = new CL_Venta();
        CL_Empresas ObjCL_Empresas = new CL_Empresas();
        CL_Credito ObjCL_Credito = new CL_Credito();
        CL_Pago ObjCL_Pago = new CL_Pago();
        Halley.Presentacion.Ventas.CrystalReports.CrPagosCredito rpt = new Halley.Presentacion.Ventas.CrystalReports.CrPagosCredito();

        public RptPagos()
        {
            InitializeComponent();
        }

        private void RptVendedor_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();

            useCliente1.Cargar(new CL_Cliente().GetClientes());
            useCliente1.btnRegistrar.Visible = false;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
               if(LstCreditos.SelectedIndex != -1)
                {
                    Ds = ObjCL_Pago.GetPagosCredito(Convert.ToInt32(LstCreditos.Columns["CreditoID"].Value));
                    rpt.SetDataSource(Ds);

                    //Establecemos los datos al reporte
                    this.CrvVendedores.ReportSource = rpt;
                    TextObject txt;
                    txt = (TextObject)rpt.ReportDefinition.ReportObjects["txt1"];
                    txt.Text = "Pagos del Cliente: " + useCliente1.cbNombre.Columns["RazonSocial"].Value.ToString();

                    TextObject txt2;
                    txt2 = (TextObject)rpt.ReportDefinition.ReportObjects["txt2"];
                    txt2.Text = "Pagos del credito: " + LstCreditos.Columns["NomCampanha"].Value.ToString();

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

        private void useCliente1_ComboValueChange()
        {
            GetCreditosCompra(Convert.ToInt32(useCliente1.cbCliente.SelectedValue));
        }

        private void GetCreditosCompra(int ClienteID)
        {
            //traer créditos
            DataTable DtCreditos = new DataTable();
            DtCreditos = ObjCL_Credito.GetCreditosCliente(ClienteID,"T");
            LstCreditos.HoldFields();
            LstCreditos.DataSource = DtCreditos;
        }

        private void LstCreditos_FetchRowStyle(object sender, C1.Win.C1List.FetchRowStyleEventArgs e)
        {
            string S = LstCreditos.Columns["EstadoID"].CellText(e.Row).ToString();
            if (S == "10")
            {
                e.CellStyle.BackColor = System.Drawing.Color.Red;
            }
        }

        private void BtnEntregarPuntos_Click(object sender, EventArgs e)
        {

        }
    }
}

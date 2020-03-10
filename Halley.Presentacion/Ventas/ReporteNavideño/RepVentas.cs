using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Users;
using Halley.Configuracion;
using CrystalDecisions.CrystalReports.Engine;
using Halley.Utilitario;
using Halley.CapaLogica.Ventas;
using Halley.CapaLogica.Almacen;


namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    public partial class RepVentas : UITemplateAccess
    {
        #region variables globales

        DataTable dt;
     
        #endregion

        #region constructor

        public RepVentas()
        {
            InitializeComponent();
        }

        #endregion

        #region eventos del control

        private void cbBusqueda_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbBusqueda.SelectedValue != null && cbBusqueda.SelectedValue.ToString().Equals("2"))
            {
                LoadReporte(2, new CL_Venta().get_ReporteDiferencial());
                Ocultar(false);
            }          
            else
            {
                Ocultar(true);
            }
        }

        private void cbPresentaciones_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbBusqueda.SelectedValue != null)
            {
                string codigo = cbPresentaciones.SelectedValue.ToString();
                string busqueda = cbBusqueda.SelectedValue.ToString();

                if (busqueda.Equals("1"))
                    LoadReporte(1, new CL_Venta().get_ReporteConVales(codigo));                
            }
        }

        private void RepVentas_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            Cargar();
        }

        #endregion

        #region metodos definidos

        private void Ocultar(bool valor)
        {
            cbPresentaciones.Visible = valor;
            lblPresentaciones.Visible = valor;
        }

        private void LoadReporte(int num, DataTable dtReporte)
        {
            dt = dtReporte;

            if (dt.Rows.Count == 0)
            {
                crvVentas.Visible = false;
                return;
            }

            crvVentas.Visible = true;
            if (num == 1)
            {
                Halley.Presentacion.CrystalReports.rpt_RepConVale ObjConVale = new Halley.Presentacion.CrystalReports.rpt_RepConVale();
                ObjConVale.SetDataSource(dt);

                crvVentas.ReportSource = ObjConVale;

                TextObject txt;
                txt = (TextObject)ObjConVale.ReportDefinition.ReportObjects["txtTotal"];
                txt.Text = string.Format("{0:0,0.0}", dt.Compute("Sum(Unidades)", ""));

                txt = (TextObject)ObjConVale.ReportDefinition.ReportObjects["txtTot"];
                txt.Text = string.Format("{0:0,0.0}", dt.Compute("Sum(PesoReal)", ""));

                txt = (TextObject)ObjConVale.ReportDefinition.ReportObjects["txtImporte"];
                txt.Text = string.Format("{0:C}", dt.Compute("Sum(Importe)", ""));
            }
            else if (num == 2)
            {
                Halley.Presentacion.CrystalReports.rpt_RepDiferencial ObjDiferencial = new Halley.Presentacion.CrystalReports.rpt_RepDiferencial();
                ObjDiferencial.SetDataSource(dt);

                crvVentas.ReportSource = ObjDiferencial;

                TextObject txt;
                txt = (TextObject)ObjDiferencial.ReportDefinition.ReportObjects["txtTotal"];
                txt.Text = string.Format("{0:C}", dt.Compute("sum(TotalPagado)", ""));
            }
        }

        private void Cargar()
        {
            DataTable dtCombo = new DataTable();
            dtCombo.Columns.Add("Indice", typeof(string));
            dtCombo.Columns.Add("Nombre", typeof(string));
            dtCombo.Rows.Add("1","Con Vale");            
            dtCombo.Rows.Add("2","Diferencial");

            c1Combo.FillC1Combo1(cbPresentaciones, new CL_Producto().getProductosNavideños(AppSettings.EmpresaID, AppSettings.SedeID), "NomProducto", "ProductoID");
            c1Combo.FillC1Combo1(cbBusqueda, dtCombo, "Nombre","Indice");   
        }
        #endregion

      
    }
}

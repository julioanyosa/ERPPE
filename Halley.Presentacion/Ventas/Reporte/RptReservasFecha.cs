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
using Halley.CapaLogica.Almacen;
using Halley.Utilitario;
using Halley.Configuracion;


namespace Halley.Presentacion.Ventas.Reporte
{
    public partial class RptReservasFecha : UITemplateAccess
    {
        DataTable DtDespachos = new DataTable();
        DataTable DtProductos = new DataTable();
        CL_Venta ObjCL_Venta = new CL_Venta();

        public RptReservasFecha()
        {
            InitializeComponent();
        }

        private void RptVendedor_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            DtpFechaIni.Value = DateTime.Now.Date;
            DtpFechaFin.Value = DateTime.Now.Date;
            //obtener lista de productos
            DtProductos = new CL_Producto().GetProductos();
            CboProducto.HoldFields();
            CboProducto.DataSource = DtProductos;
            CboProducto.DisplayMember = "Alias";
            CboProducto.ValueMember = "ProductoID";
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if(DtpFechaIni.Value !=  null & DtpFechaFin.Value != null & CboProducto.SelectedIndex != -1)
                {
                    DtDespachos = ObjCL_Venta.GetReservasRepProducto(DtpFechaIni.Value,DtpFechaFin.Value.AddDays(1),CboProducto.SelectedValue.ToString());
                    Halley.Presentacion.Ventas.CrystalReports.CrGetReservasRepProducto ObjCrpGetReservasRepProducto = new Halley.Presentacion.Ventas.CrystalReports.CrGetReservasRepProducto();
                    ObjCrpGetReservasRepProducto.SetDataSource(DtDespachos);

                    CrvReservas.ReportSource = ObjCrpGetReservasRepProducto;
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrpGetReservasRepProducto.ReportDefinition.ReportObjects["TxtTitulo"];
                    txt.Text = "Despachos requeridos entre " + DtpFechaIni.Value.Date.ToShortDateString().ToString() + " y " + DtpFechaFin.Value.Date.ToShortDateString().ToString() + " de " + CboProducto.Columns["Alias"].Value.ToString();
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

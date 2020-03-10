using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.VentasTemp;
using CrystalDecisions.CrystalReports.Engine;
using Halley.Configuracion;

namespace Halley.Presentacion.VentasTemp
{
    public partial class ReporteVentasPorProducto : UITemplateAccess
    {

        CL_VentasTemp ObjCL_VentasTemp = new CL_VentasTemp();
        DataTable DtVendedores = new DataTable();
        DataTable DtProductos = new DataTable();
        DataTable DtCajas = new DataTable();
        DataTable DtTipoDocumento = new DataTable();
        DataTable usp_GetDetalleVentasPorProducto = new DataTable();
        DataSet DS;

        public ReporteVentasPorProducto()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            cboFechaInicio.Value = DateTime.Now.Date;
            cboFechaFin.Value = DateTime.Now.Date;
            ocultarToolStrip();

            //traer todos los vendedores apra ver sus reportes
            DtVendedores = ObjCL_VentasTemp.GetUsuariosPerfil(54);//todos los  pertenecen al perfil ventas
            CboVendedores.HoldFields();
            CboVendedores.DataSource = DtVendedores;
            CboVendedores.DisplayMember = "Descripcion";
            CboVendedores.ValueMember = "UserID";

            //traer las cajas de la sede
            DtCajas = ObjCL_VentasTemp.GetCajasSede(AppSettings.EmpresaID + AppSettings.SedeID);

            CboCaja.HoldFields();
            CboCaja.DataSource = DtCajas;
            CboCaja.DisplayMember = "Descripcion";
            CboCaja.ValueMember = "Numcaja";

            //traer los productos
            DtProductos = ObjCL_VentasTemp.GetProductos();
            CboProductos.HoldFields();
            CboProductos.DataSource = DtProductos;
            CboProductos.DisplayMember = "Articulo";
            CboProductos.ValueMember = "ArticuloId";

            CboProductosCodigo.HoldFields();
            CboProductosCodigo.DataSource = DtProductos;
            CboProductosCodigo.DisplayMember = "Codigo";
            CboProductosCodigo.ValueMember = "ArticuloId";


            //traer los tipo de comprobante para filtrar
            DtTipoDocumento = ObjCL_VentasTemp.GetTipoDocumento();
            DataRow Dr = DtTipoDocumento.NewRow();
            Dr["TipoDocumento"] = 0;
            Dr["NomDocumento"] = "Ambos";
            DtTipoDocumento.Rows.Add(Dr);
            CboTipoComprobante.HoldFields();
            CboTipoComprobante.DataSource = DtTipoDocumento;
            CboTipoComprobante.DisplayMember = "NomDocumento";
            CboTipoComprobante.ValueMember = "TipoDocumento";

            DS = new DataSetsReportes.DsVentasProducto();//datatset tipeado
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (cboFechaInicio.Value.ToString() != "" & cboFechaFin.Value.ToString() != "" & CboProductos.SelectedValue.ToString() != "")
                {
                    DateTime FecIni;
                    DateTime FecFin;
                    FecIni = Convert.ToDateTime(cboFechaInicio.Value).Date;
                    FecFin = Convert.ToDateTime(cboFechaFin.Value).AddDays(1).Date;

                    //Creamos el documento 
                    ReportDocument rpt = new ReportDocument();
                    //Obtenemos el documento que se encuentra en nustra carpeta bin\debug\crReporte.rpt

                    rpt.Load(Application.StartupPath + "\\CrpVentasProducto.rpt");

                    //Lleanamos el reporte con la información que obtenemos de la base de datos
                    //NumHojaDespacho = "IH-HD201106140003";

                    usp_GetDetalleVentasPorProducto.Clear();

                   
                    if (TcSeleccion.SelectedIndex == 0 & CboVendedores.SelectedIndex != -1)
                        usp_GetDetalleVentasPorProducto = new CL_VentasTemp().GetDetalleVentasPorProducto(FecIni, FecFin, 0, Convert.ToInt16(CboVendedores.SelectedValue), Convert.ToInt32(CboProductos.SelectedValue));
                    if (TcSeleccion.SelectedIndex == 1)
                        usp_GetDetalleVentasPorProducto = new CL_VentasTemp().GetDetalleVentasPorProducto(FecIni, FecFin, Convert.ToInt16(CboCaja.SelectedValue), 0, Convert.ToInt32(CboProductos.SelectedValue));
                    DS.Tables["usp_GetDetalleVentasPorProducto"].Clear();
                    DS.Tables["usp_GetDetalleVentasPorProducto"].Merge(usp_GetDetalleVentasPorProducto);
                    
                    rpt.SetDataSource(DS);
                    //Establecemos los datos al reporte
                    this.CrvResumenVentas.ReportSource = rpt;
                    //pasar datos directo al crystal reports
                    rpt.DataDefinition.FormulaFields[0].Text = "'" + AppSettings.NomEmpresa + "'";
                    rpt.DataDefinition.FormulaFields[2].Text = "'" + AppSettings.NomSede + "'";
                    if (TcSeleccion.SelectedIndex == 0)
                        rpt.DataDefinition.FormulaFields[3].Text = "'Resumen de ventas por cajero ''" + CboVendedores.SelectedText + "'': del " + FecIni.ToString().Substring(1, 10) + " al " + cboFechaFin.Value.ToString().Substring(1, 10) + ".'' de " + CboProductos.Columns["Articulo"].Value.ToString() + ".'";
                    if (TcSeleccion.SelectedIndex == 1)
                        rpt.DataDefinition.FormulaFields[3].Text = "'Resumen de ventas por caja ''" + CboCaja.SelectedText + "'': del " + FecIni.ToString().Substring(1, 10) + " al " + cboFechaFin.Value.ToString().Substring(1, 10) + ".'' de " + CboProductos.Columns["Articulo"].Value.ToString() + ".'";
                    //Refrescamos nuestro reporte
                    this.CrvResumenVentas.RefreshReport();
                    CboTipoComprobante.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.InnerException.Message);
                MessageBox.Show(ex.Message);

            }

            Cursor = Cursors.Default;
        }

        private void CboTipoComprobante_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboTipoComprobante.SelectedIndex != -1 & CboProductos.SelectedIndex != -1)
            {
                DateTime FecIni;
                DateTime FecFin;
                FecIni = Convert.ToDateTime(cboFechaInicio.Value).Date;
                FecFin = Convert.ToDateTime(cboFechaFin.Value).AddDays(1).Date;
                ReportDocument rpt = new ReportDocument();
                rpt.Load(Application.StartupPath + "\\CrpVentasProducto.rpt");

                //filtrar y mostrar los datos
                DataView DvDetallefiltro = new DataView(usp_GetDetalleVentasPorProducto);
                
                //validar segun el tipo de documento
                if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 0) //son ambos
                {
                    //no se hace nada
                }
                else //filtra segun tipo
                {
                    DvDetallefiltro.RowFilter = "TipoDocumento = '" + Convert.ToInt16(CboTipoComprobante.SelectedValue) + "'";
                }


                DS.Tables["usp_GetDetalleVentasPorProducto"].Clear();
                DS.Tables["usp_GetDetalleVentasPorProducto"].Merge(DvDetallefiltro.ToTable());

                rpt.SetDataSource(DS);
                //Establecemos los datos al reporte
                this.CrvResumenVentas.ReportSource = rpt;
                //pasar datos directo al crystal reports
                rpt.Load(Application.StartupPath + "\\CrpVentasProducto.rpt");
                rpt.DataDefinition.FormulaFields[0].Text = "'" + AppSettings.NomEmpresa + "'";
                rpt.DataDefinition.FormulaFields[2].Text = "'" + AppSettings.NomSede + "'";
                if (TcSeleccion.SelectedIndex == 0)
                    rpt.DataDefinition.FormulaFields[3].Text = "'Resumen de ventas por cajero ''" + CboVendedores.SelectedText + "'': del " + FecIni.ToString().Substring(1, 10) + " al " + cboFechaFin.Value.ToString().Substring(1, 10)  + ".'' de " + CboProductos.Columns["Articulo"].Value.ToString() + ".'";
                if (TcSeleccion.SelectedIndex == 1)
                    rpt.DataDefinition.FormulaFields[3].Text = "'Resumen de ventas por caja ''" + CboCaja.SelectedText + "'': del " + FecIni.ToString().Substring(1, 10) + " al " + cboFechaFin.Value.ToString().Substring(1, 10) + ".'' de " + CboProductos.Columns["Articulo"].Value.ToString() + ".'";
                //Refrescamos nuestro reporte
                this.CrvResumenVentas.RefreshReport();
            }
        }

        private void CrvResumenVentas_Load(object sender, EventArgs e)
        {

        }

        
    }
}

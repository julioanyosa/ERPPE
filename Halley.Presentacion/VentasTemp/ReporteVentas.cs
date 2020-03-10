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
    public partial class ReporteVentas : UITemplateAccess
    {

        CL_VentasTemp ObjCL_VentasTemp = new CL_VentasTemp();
        DataTable DtVendedores = new DataTable();
        DataTable DtCajas = new DataTable();
        DataTable DtTipoDocumento = new DataTable();
        DataTable usp_GetDetalleVentasComprobante = new DataTable();
        DataSet DS;

        public ReporteVentas()
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

            DS = new DataSetsReportes.DsVentasComprobante();//datatset tipeado
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (cboFechaInicio.Value.ToString() != "" && cboFechaFin.Value.ToString() != "")
                {
                    DateTime FecIni;
                    DateTime FecFin;
                    FecIni = Convert.ToDateTime(cboFechaInicio.Value).Date;
                    FecFin = Convert.ToDateTime(cboFechaFin.Value).AddDays(1).Date;

                    //Creamos el documento 
                    ReportDocument rpt = new ReportDocument();
                    //Obtenemos el documento que se encuentra en nustra carpeta bin\debug\crReporte.rpt

                    rpt.Load(Application.StartupPath + "\\CrpVentasComprobante.rpt");

                    //Lleanamos el reporte con la información que obtenemos de la base de datos
                    //NumHojaDespacho = "IH-HD201106140003";

                    usp_GetDetalleVentasComprobante.Clear();
                    if (TcSeleccion.SelectedIndex == 0 & CboVendedores.SelectedIndex != -1)
                        usp_GetDetalleVentasComprobante = new CL_VentasTemp().GetDetalleVentasComprobante(FecIni, FecFin, 0, Convert.ToInt16(CboVendedores.SelectedValue));
                    if (TcSeleccion.SelectedIndex == 1)
                        usp_GetDetalleVentasComprobante = new CL_VentasTemp().GetDetalleVentasComprobante(FecIni, FecFin, Convert.ToInt16(CboCaja.SelectedValue), 0);
                    DS.Tables["usp_GetDetalleVentasComprobante"].Clear();
                    DS.Tables["usp_GetDetalleVentasComprobante"].Merge(usp_GetDetalleVentasComprobante);
                    
                    rpt.SetDataSource(DS);
                    //Establecemos los datos al reporte
                    this.CrvResumenVentas.ReportSource = rpt;
                    //pasar datos directo al crystal reports
                    rpt.DataDefinition.FormulaFields[0].Text = "'" + AppSettings.NomEmpresa + "'";
                    rpt.DataDefinition.FormulaFields[2].Text = "'" + AppSettings.NomSede + "'";
                    if (TcSeleccion.SelectedIndex == 0)
                        rpt.DataDefinition.FormulaFields[3].Text = "'Resumen de ventas por cajero ''" + CboVendedores.SelectedText + "'': del " + FecIni.ToString().Substring(1, 10) + " al " + cboFechaFin.Value.ToString().Substring(1, 10) + ".'";
                    if (TcSeleccion.SelectedIndex == 1)
                        rpt.DataDefinition.FormulaFields[3].Text = "'Resumen de ventas por caja ''" + CboCaja.SelectedText + "'': del " + FecIni.ToString().Substring(1, 10) + " al " + cboFechaFin.Value.ToString().Substring(1, 10) + ".'";
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
            if (CboTipoComprobante.SelectedIndex != -1)
            {
                DateTime FecIni;
                DateTime FecFin;
                FecIni = Convert.ToDateTime(cboFechaInicio.Value).Date;
                FecFin = Convert.ToDateTime(cboFechaFin.Value).AddDays(1).Date;
                ReportDocument rpt = new ReportDocument();
                rpt.Load(Application.StartupPath + "\\CrpVentasComprobante.rpt");

                //filtrar y mostrar los datos
                DataView DvDetallefiltro = new DataView(usp_GetDetalleVentasComprobante);
                
                //validar segun el tipo de documento
                if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 0) //son ambos
                {
                    //no se hace nada
                }
                else //filtra segun tipo
                {
                    DvDetallefiltro.RowFilter = "TipoDocumento = '" + Convert.ToInt16(CboTipoComprobante.SelectedValue) + "'";
                }


                DS.Tables["usp_GetDetalleVentasComprobante"].Clear();
                DS.Tables["usp_GetDetalleVentasComprobante"].Merge(DvDetallefiltro.ToTable());

                rpt.SetDataSource(DS);
                //Establecemos los datos al reporte
                this.CrvResumenVentas.ReportSource = rpt;
                //pasar datos directo al crystal reports
                rpt.Load(Application.StartupPath + "\\CrpVentasComprobante.rpt");rpt.DataDefinition.FormulaFields[0].Text = "'" + AppSettings.NomEmpresa + "'";
                rpt.DataDefinition.FormulaFields[2].Text = "'" + AppSettings.NomSede + "'";
                if (TcSeleccion.SelectedIndex == 0)
                    rpt.DataDefinition.FormulaFields[3].Text = "'Resumen de ventas por cajero ''" + CboVendedores.SelectedText + "'': del " + FecIni.ToString().Substring(1, 10) + " al " + cboFechaFin.Value.ToString().Substring(1, 10) + ".'";
                if (TcSeleccion.SelectedIndex == 1)
                    rpt.DataDefinition.FormulaFields[3].Text = "'Resumen de ventas por caja ''" + CboCaja.SelectedText + "'': del " + FecIni.ToString().Substring(1, 10) + " al " + cboFechaFin.Value.ToString().Substring(1, 10) + ".'";
                //Refrescamos nuestro reporte
                this.CrvResumenVentas.RefreshReport();
            }
        }

        
    }
}

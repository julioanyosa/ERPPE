using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Empresa;
using Halley.Utilitario;
using CrystalDecisions.CrystalReports.Engine;
using Halley.CapaLogica.Almacen;
using Halley.CapaLogica.Ventas;

namespace Halley.Presentacion.Auditoria.Ventas
{
    public partial class AuditoriaPrecio : UITemplateAccess
    {
        public AuditoriaPrecio()
        {
            InitializeComponent();
        }

        private void VariacionPrecio_Load(object sender, EventArgs e)
        {
            DtpFechaIni.Value = DateTime.Now.Date;
            DtpFechaFin.Value = DateTime.Now.Date;
            ocultarToolStrip();

            //obtener lso productos
            DataTable DtProductos = new CL_Producto().GetProductos();

            //agregar uno que indque 'todos'
            DataRow DrProducto = DtProductos.NewRow();
            DrProducto["ProductoID"] = "";
            DrProducto["NomProducto"] = "";
            DrProducto["Alias"] = "...Todos...";
            DrProducto["Almacen"] = "";
            DrProducto["SubFamiliaID"] = "";
            DrProducto["ProductoIDVentas"] = "";
            DrProducto["UnidadMedidaID"] = "";
            DtProductos.Rows.InsertAt(DrProducto,0);

            c1Combo.FillC1Combo(CboProducto, DtProductos, "Alias", "ProductoID");
            //traer los administradores
            c1Combo.FillC1Combo(CboAdministradores, new CL_Venta().GetAdministradores(), "Usuario", "UserID");
            
            //obtener todas las sedes
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            c1Combo.FillC1Combo(CboSede, Dtsedes, "NomSede", "SedeID");
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (c1cboCia.SelectedIndex != -1 & CboSede.SelectedIndex != -1 & DtpFechaIni.Value != null & DtpFechaFin.Value != null & CboAdministradores.SelectedIndex != -1)
                {
                    CL_Venta ObjCL_Venta = new CL_Venta();
                    DataTable DtAuditoriaPrecio = new DataTable();

                    string EmpresaID = c1cboCia.SelectedValue.ToString();
                    string SedeID = CboSede.SelectedValue.ToString();
                    DtAuditoriaPrecio = ObjCL_Venta.GetAuditoriaPrecio(EmpresaID + SedeID, DtpFechaIni.Value, DtpFechaFin.Value.AddDays(1), Convert.ToInt32(CboAdministradores.SelectedValue), CboProducto.SelectedValue.ToString());
                    Halley.Presentacion.Auditoria.Reportes.CrAuditoriaPrecio ObjCrAuditoriaPrecio = new Halley.Presentacion.Auditoria.Reportes.CrAuditoriaPrecio();
                    DataSet Ds = new DataSet();
                    DataTable Dt = new DataTable("Logo");
                    Dt.Columns.Add("Logo", typeof(byte[]));
                    Dt.Columns.Add("NomEmpresa", typeof(string));
                    DataRow Dr = Dt.NewRow();
                    // El campo productImage primero se almacena en un buffer
                    DataRow[] customerRow = UTI_Datatables.DtEmpresas.Select("EmpresaID = '" + EmpresaID + "'");
                    if (customerRow[0]["Logo"] != DBNull.Value)
                    {
                        Dr["Logo"] = customerRow[0]["Logo"];
                    }
                    else
                        Dr["Logo"] = DBNull.Value;
                    Dr["NomEmpresa"] = customerRow[0]["NomEmpresa"];

                    Dt.Rows.Add(Dr);
                    DtAuditoriaPrecio.TableName = "AuditoriaPrecio";
                    Ds.Tables.Add(Dt);
                    Ds.Tables.Add(DtAuditoriaPrecio);
                    ObjCrAuditoriaPrecio.SetDataSource(Ds);

                    //agregado para conectar el subreporte
                    ObjCrAuditoriaPrecio.SetDatabaseLogon("domserver", "@dmin1234N");

                    CrvResumenVentas.ReportSource = ObjCrAuditoriaPrecio;
                    CrvResumenVentas.Refresh();
                    //pasar datos directo al crystal reports
                    //TextObject txt;
                    //txt = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["TxtReporte"];
                    //txt.Text = "CUADRE DE CAJA DE " + DtpFechaIni.Value.Date.ToShortDateString().ToString() + " A " + DtpFechaFin.Value.Date.ToShortDateString().ToString();


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

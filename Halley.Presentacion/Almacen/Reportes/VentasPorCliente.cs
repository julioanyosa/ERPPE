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
using Halley.Utilitario;
using Halley.CapaLogica.Empresa;

namespace Halley.Presentacion.Almacen.Reportes
{
    public partial class VentasPorCliente : UITemplateAccess
    {
        CL_Venta ObjCL_Venta = new CL_Venta();
        DataTable DtVentasCliente = new DataTable();
        string EmpresaID;

        public VentasPorCliente()
        {
            InitializeComponent();
        }

        private void VentasPorCliente_Load(object sender, EventArgs e)
        {
            DataTable DtClientes = new DataTable();
            DtClientes = new CL_Cliente().GetClientes();
            DataRow Dr = DtClientes.NewRow();
            Dr["ClienteID"] = 0;
            Dr["TipoClienteID"] = 2;
            Dr["IDTipoDocumento"] = 1;
            Dr["NroDocumento"] = "000000000";
            Dr["RazonSocial"] = "TODOS";
            Dr["Alias"] = "";
            Dr["Contacto"] = "";
            Dr["TelefonoFijo"] = "";
            Dr["TelefonoMovil"] = "";
            Dr["Fax"] = "";
            Dr["Email"] = "";
            Dr["Direccion"] = "";
            Dr["DistritoId"] = 0;
            Dr["ProvinciaId"] = 0;
            Dr["Nombre1"] = "";
            Dr["Nombre2"] = "";
            Dr["Apellido1"] = "";
            Dr["Apellido2"] = "";
            Dr["PaisId"] = 0;
            Dr["NombreVia"] = "";
            Dr["DireccionViaId"] = 0;
            Dr["DireccionNumero"] = "";
            Dr["DireccionInterior"] = "";
            Dr["Observaciones"] = "";
            DtClientes.Rows.InsertAt(Dr, 0);
            useCliente1.Cargar(DtClientes);
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            ocultarToolStrip();
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                CrvVentasCliente.ReportSource = null;
                CrvVentasClienteDetallado.ReportSource = null;
                if (c1cboCia.SelectedIndex != -1 & DtpFechaIni.Value != null & DtpFechaFin.Value != null)
                {
                    EmpresaID = c1cboCia.SelectedValue.ToString();

                    DateTime fechaini = Convert.ToDateTime(DtpFechaIni.Value.ToShortDateString());
                    DateTime fechafin = Convert.ToDateTime(DtpFechaFin.Value.ToShortDateString());
                        

                    ReportDocument ObjCrVentasCliente = new ReportDocument();
                    if (TcVentasCliente.SelectedIndex == 0)
                    {
                        DtVentasCliente = ObjCL_Venta.GetVentasCliente(1, fechaini, fechafin, Convert.ToInt32(useCliente1.cbCliente.SelectedValue), EmpresaID);
                        ObjCrVentasCliente = new Halley.Presentacion.CrystalReports.CrVentasCliente();
                    }
                    else if (TcVentasCliente.SelectedIndex == 1)
                    {
                        DtVentasCliente = ObjCL_Venta.GetVentasCliente(2, fechaini, fechafin, Convert.ToInt32(useCliente1.cbCliente.SelectedValue), EmpresaID);
                        ObjCrVentasCliente = new Halley.Presentacion.CrystalReports.CrVentasClienteDetallado();
                    }

                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrVentasCliente.ReportDefinition.ReportObjects["TxtTitulo"];
                    txt.Text = "DATOS DESDE " + DtpFechaIni.Value.Date.ToShortDateString().ToString() + " A " + DtpFechaFin.Value.Date.ToShortDateString().ToString();

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
                    DtVentasCliente.TableName = "GetCierreDiario";
                    Ds.Tables.Add(Dt);
                    Ds.Tables.Add(DtVentasCliente);

                    ObjCrVentasCliente.SetDataSource(Ds);
                    if (TcVentasCliente.SelectedIndex == 0)
                    {
                        CrvVentasCliente.ReportSource = ObjCrVentasCliente;
                    }
                    else if (TcVentasCliente.SelectedIndex == 1)
                    {
                        CrvVentasClienteDetallado.ReportSource = ObjCrVentasCliente;
                    } 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
        }
    }
}

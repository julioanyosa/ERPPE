using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.CapaLogica.Ventas;
using Halley.CapaLogica.Empresa;
using Halley.Configuracion;
using Halley.CapaLogica.Contabilidad;
using CrystalDecisions.CrystalReports.Engine;

namespace Halley.Presentacion.Contabilidad.Operaciones
{
    public partial class RegistrarCuadre : UITemplateAccess
    {
        DateTime FechaIni, FechaFin;
        decimal DineroEntregado, Ingreso, Egreso, TotalVenta, TotalEntregar;
        DataTable DtCajas= new DataTable();
        CapaLogica.Ventas.CL_Venta ObjCL_Venta = new CapaLogica.Ventas.CL_Venta();
        CapaLogica.Contabilidad.CL_Venta ObjCL_VentaCon = new CapaLogica.Contabilidad.CL_Venta();
        string EmpresaID, SedeID, Empresa, Sede, Cajero;
        int CajeroID = 0;
        DataSet Ds = new DataSet();


        public RegistrarCuadre()
        {
            InitializeComponent();
        }

        private void RegistrarCuadre_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();

            DtpFechaIni.Value = DateTime.Now.Date;

            //traer los cajeros
            DtCajas = ObjCL_Venta.GetCajeros();
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            c1cboCia.SelectedValue = AppSettings.EmpresaID;
            c1Combo.FillC1Combo(this.CboCajero, DtCajas, "Descripcion", "UserID");

            //obtener todas las sedes
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            c1Combo.FillC1Combo(CboSede, Dtsedes, "NomSede", "SedeID");
            CboSede.SelectedValue = AppSettings.SedeID;
        }

        private void BtnGuardarCierre_Click(object sender, EventArgs e)
        {
            //almacena el cierre del dia
            try
            {
                ErrProvider.Clear();
                if (TxtDineroEntregado.Text != "" && Convert.ToDecimal(TxtDineroEntregado.Text) != 0 & FechaIni != null)
                {
                    DineroEntregado = Convert.ToDecimal(TxtDineroEntregado.Text);

                    if (TotalEntregar != 0 & DineroEntregado != 0)
                    {
                        Sede = CboSede.Columns["NomSede"].Value.ToString();
                        EmpresaID = c1cboCia.SelectedValue.ToString();
                        SedeID = CboSede.SelectedValue.ToString();
                        CajeroID = Convert.ToInt32(CboCajero.SelectedValue);
                        FechaIni = DtpFechaIni.Value;
                        ObjCL_Venta.InsertCierre(CajeroID, EmpresaID + SedeID, FechaIni, DineroEntregado, Ingreso, Egreso, TotalVenta,TotalEntregar, AppSettings.UserID);
                        MessageBox.Show("Se agrego el cierre correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("El dinero entregado y/o total a entregar debe ser diferente de 0.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (TxtDineroEntregado.Text == "" || Convert.ToDecimal(TxtDineroEntregado.Text) == 0) { ErrProvider.SetError(TxtDineroEntregado,"Ingrese una cantidad valida");}
                    if (FechaIni == null) { ErrProvider.SetError(DtpFechaIni, "tal vez no ha consultado ningún cierre."); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingresar Cierre().\n\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    
        private void BtnTotalDia_Click(object sender, EventArgs e)
        {
            limpiarVariables();
            //Traer los pagos del dia para registarlo
            if (c1cboCia.SelectedIndex != -1 & CboSede.SelectedIndex != -1 & DtpFechaIni.Value != null & CboCajero.SelectedIndex != -1)
            {
                DataTable DtCuadreCaja = new DataTable();
                
                Empresa = c1cboCia.Columns["NomEmpresa"].Value.ToString();
                Sede = CboSede.Columns["NomSede"].Value.ToString();
                EmpresaID = c1cboCia.SelectedValue.ToString();
                SedeID = CboSede.SelectedValue.ToString();
                Cajero = CboCajero.Columns["Usuario"].Value.ToString();
                CajeroID = Convert.ToInt32(CboCajero.SelectedValue);
                FechaIni = Convert.ToDateTime(DtpFechaIni.Value.ToShortDateString());
                FechaFin = FechaIni.AddDays(1);
                DtCuadreCaja = ObjCL_VentaCon.GetCuadreCaja(FechaIni, FechaFin, CajeroID, EmpresaID, SedeID);

                //mostrar en la pantalla
                Ingreso = Convert.ToDecimal(DtCuadreCaja.Rows[0]["PAGADO"]);
                Egreso = Convert.ToDecimal(DtCuadreCaja.Rows[1]["PAGADO"]);
                TotalVenta = Convert.ToDecimal(DtCuadreCaja.Rows[2]["PAGADO"]);
                TotalEntregar = Ingreso - Egreso + TotalVenta;
                LblIngreso.Text = Ingreso.ToString("C");
                LblEgreso.Text = Egreso.ToString("C");
                LblTotalPagos.Text = TotalVenta.ToString("C");
                LblEntregar.Text = TotalEntregar.ToString("C");

            }
        }

        private void limpiarVariables()
        {
            DineroEntregado = 0; Ingreso = 0; Egreso = 0; TotalVenta = 0; TotalEntregar = 0;
            DataTable DtCajas= new DataTable();
            EmpresaID = ""; SedeID = ""; Empresa = ""; Sede = ""; Cajero = "";
            CajeroID = 0;
        }

        private void BtnVercierre_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (DtpFechaIni.Value != null & c1cboCia.SelectedIndex != -1)
                {
                    Ds.Tables.Clear();
                    FechaIni = Convert.ToDateTime(DtpFechaCierre.Value.ToShortDateString());
                    EmpresaID = c1cboCia.SelectedValue.ToString();
                    DataTable dt = new DataTable();
                    dt = ObjCL_VentaCon.GetCierreDiario(FechaIni, EmpresaID);
                    dt.TableName = "GetCierreDiario";

                    DataTable Dt = new DataTable("Logo");
                    Dt.Columns.Add("Logo", typeof(byte[]));
                    Dt.Columns.Add("NomEmpresa", typeof(string));
                    Dt.Columns.Add("RUC", typeof(string));
                    Dt.Columns.Add("DomicilioFiscal", typeof(string));
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
                    Dr["RUC"] = customerRow[0]["RUC"];
                    Dr["DomicilioFiscal"] = customerRow[0]["DomicilioFiscal"];
                    Dt.Rows.Add(Dr);
                    Ds.Tables.Add(Dt.Copy());
                    Ds.Tables.Add(dt.Copy());


                    Halley.Presentacion.Contabilidad.CrystalReports.CrCierreDiario ObjCrpVentasComprobante = new Halley.Presentacion.Contabilidad.CrystalReports.CrCierreDiario();
                    ObjCrpVentasComprobante.SetDataSource(Ds);

                    CrvResumenVentas.ReportSource = ObjCrpVentasComprobante;
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["TxtReporte"];
                    txt.Text = "Cierre correspondiente a la fecha " + FechaIni.ToShortDateString() + ".";
                    CrvResumenVentas.Refresh();
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

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
using Halley.Configuracion;
using Halley.Utilitario;
using Halley.CapaLogica.Empresa;

namespace Halley.Presentacion.Ventas.Reporte
{
    public partial class ReporteVentas : UITemplateAccess
    {

        CL_Venta ObjCL_Venta = new CL_Venta();
        DataTable DtCajas = new DataTable();
        DataSet DS;
        string EmpresaID, SedeID, fechainicio, fechafin, Empresa, Sede, Cajero;
        int CajeroID = 0;
        decimal totb = 0, totf = 0, tott = 0, tottf = 0, toti = 0, tote = 0, DineroEntregado = 0, Entrega12 = 0, totbe = 0, totfe = 0;
        DateTime FechaIni, FechaFin;

        public ReporteVentas()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {

            DtpFechaIni.Value = DateTime.Now.Date;
            DtpFechaFin.Value = DateTime.Now.Date;
            ocultarToolStrip();
            pnlImprimir.Visible = false;

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

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (c1cboCia.SelectedIndex != -1 & CboSede.SelectedIndex != -1 & DtpFechaIni.Value != null & DtpFechaFin.Value != null & CboCajero.SelectedIndex != -1)
                {

                    //reiniciar variables
                    totb = 0; totf = 0; tott = 0; tottf = 0; toti = 0; tote = 0; DineroEntregado = 0; Entrega12 = 0; totbe = 0; totfe = 0;

                    Empresa = c1cboCia.Columns["NomEmpresa"].Value.ToString();
                    Sede = CboSede.Columns["NomSede"].Value.ToString();
                    EmpresaID = c1cboCia.SelectedValue.ToString();
                    SedeID = CboSede.SelectedValue.ToString();
                    Cajero = CboCajero.Columns["Usuario"].Value.ToString();
                    CajeroID = Convert.ToInt32(CboCajero.SelectedValue);
                    FechaIni = DtpFechaIni.Value;
                    FechaFin = DtpFechaFin.Value.AddDays(1);
                    DS = ObjCL_Venta.GetDetalleVentasComprobante(FechaIni, FechaFin, CajeroID, EmpresaID, SedeID);
                    Halley.Presentacion.Ventas.CrystalReports.CrVentasComprobante ObjCrpVentasComprobante = new Halley.Presentacion.Ventas.CrystalReports.CrVentasComprobante();

                    //tabla empresa
                    DataTable Dt = new DataTable("Logo");
                    Dt.Columns.Add("Logo", typeof(byte[]));
                    Dt.Columns.Add("NomEmpresa", typeof(string));
                    Dt.Columns.Add("RUC", typeof(string));
                    Dt.Columns.Add("DomicilioFiscal", typeof(string));
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
                    Dr["RUC"] = customerRow[0]["RUC"];
                    Dr["DomicilioFiscal"] = customerRow[0]["DomicilioFiscal"];
                    Dt.Rows.Add(Dr);
                    DS.Tables.Add(Dt.Copy());


                    ObjCrpVentasComprobante.SetDataSource(DS);

                    CrvResumenVentas.ReportSource = ObjCrpVentasComprobante;
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["TxtReporte"];
                    fechainicio = DtpFechaIni.Value.Date.ToShortDateString().ToString();
                    fechafin = DtpFechaFin.Value.Date.ToShortDateString().ToString();
                    txt.Text = "CUADRE DE CAJA DE " + fechainicio + " A " + fechafin;

                    DataView dv = new DataView(DS.Tables["Comprobante"]);
                    dv.RowFilter = "NomTipoComprobante='BOLETA' and FlgEst='True'";
                    if (dv.Count > 0)
                        totb = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "NomTipoComprobante='BOLETA' and FlgEst='True'"));

                    dv.RowFilter = "NomTipoComprobante='FACTURA' and FlgEst='True'";
                    if (dv.Count > 0)
                        totf = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "NomTipoComprobante='FACTURA' and FlgEst='True'"));


                    dv.RowFilter = "NomTipoComprobante='BOLETA ELECTRONICA' and FlgEst='True'";
                    if (dv.Count > 0)
                        totbe = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "NomTipoComprobante='BOLETA ELECTRONICA' and FlgEst='True'"));

                    dv.RowFilter = "NomTipoComprobante='FACTURA ELECTRONICA' and FlgEst='True'";
                    if (dv.Count > 0)
                        totfe = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "NomTipoComprobante='FACTURA ELECTRONICA' and FlgEst='True'"));

                
                    dv.RowFilter = "NomTipoComprobante='TICKET' and FlgEst='True'";
                    if (dv.Count > 0)
                        tott = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "NomTipoComprobante='TICKET' and FlgEst='True'"));

                    dv.RowFilter = "NomTipoComprobante='TICKET FACTURA' and FlgEst='True'";
                    if (dv.Count > 0)
                        tottf = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "NomTipoComprobante='TICKET FACTURA' and FlgEst='True'"));



                    dv.RowFilter = "(NomTipoComprobante='*SALDO INICIAL' or NomTipoComprobante='*INGRESO') and FlgEst='True'";
                    if (dv.Count > 0)
                        toti = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "(NomTipoComprobante='*SALDO INICIAL' or NomTipoComprobante='*INGRESO') and FlgEst='True'"));

                    dv.RowFilter = "NomTipoComprobante='*EGRESO' and FlgEst='True'";
                    if (dv.Count > 0)
                        tote = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "NomTipoComprobante='*EGRESO' and FlgEst='True'"));

                    TextObject txtb;
                    txtb = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txtb"];
                    txtb.Text = totb.ToString("C");

                    TextObject txtf;
                    txtf = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txtf"];
                    txtf.Text = totf.ToString("C");

                    TextObject txtbe;
                    txtbe = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txtbe"];
                    txtbe.Text = totbe.ToString("C");

                    TextObject txtfe;
                    txtfe = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txtfe"];
                    txtfe.Text = totfe.ToString("C");

                    TextObject txtt;
                    txtt = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txtt"];
                    txtt.Text = tott.ToString("C");

                    TextObject txttf;
                    txttf = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txttf"];
                    txttf.Text = tottf.ToString("C");

                    TextObject txti;
                    txti = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txti"];
                    txti.Text = toti.ToString("C");

                    TextObject txte;
                    txte = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txte"];
                    txte.Text = tote.ToString("C");

                    TextObject txts;
                    txts = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txts"];
                    txts.Text = (tott + tottf + totb + totf + toti - tote + totbe + totfe).ToString("C");

               

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.InnerException.Message);
                MessageBox.Show(ex.Message);

            }

            Cursor = Cursors.Default;
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            pnlImprimir.Visible = true;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.USStandardFanfold;
            string FormatoTotalesTicket = ObjCL_Venta.FormatoTickeCuadreCaja(Empresa, Sede, Cajero, totb, totf, tott + tottf, toti, tote, FechaIni, FechaFin, CajeroID, EmpresaID, SedeID, DS.Tables["Comprobante"], DineroEntregado, Entrega12);
            e.Graphics.DrawString(FormatoTotalesTicket, this.Font, Brushes.Black, 1, 1); //total pagar en letras

        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            if (TxtDineroEntregado.Text != "" && Convert.ToDecimal(TxtDineroEntregado.Text) != 0)
            {
                DineroEntregado = Convert.ToDecimal(TxtDineroEntregado.Text);
                if (TxtEntrega12.Text != "" && Convert.ToDecimal(TxtEntrega12.Text) != 0)
                {
                    Entrega12 = Convert.ToDecimal(TxtEntrega12.Text);
                }
                else
                    Entrega12 = 0;

                DataView DV = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo ='IMP_PA'", "", DataViewRowState.CurrentRows);

                if (DV.Count > 0 & (tott + totb + totf + toti - tote) != 0 & DineroEntregado != 0)
                {

                    printDocument1.PrinterSettings.PrinterName = DV[0]["Data"].ToString();
                    printDocument1.Print();
                    MessageBox.Show("Se imprimio los totales", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtDineroEntregado.Text = "";
                    TxtEntrega12.Text = "";
                    pnlImprimir.Visible = false;
                }
                else
                {
                    MessageBox.Show("no se ha seleccionado la impresora de pago\no no hay totales a imprimir\no no ingreso una cantidad\ncorrecta de dinero entregado, no se imprimira el cuadre de caja", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }


            }
            else
                MessageBox.Show("Ingrese una cantidad valida en el dinero entregado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TxtDineroEntregado.Text = "";
            TxtEntrega12.Text = "";
            pnlImprimir.Visible = false;
        }

        private void TxtDineroEntregado_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextFunctions ObjTextFunctions = new TextFunctions();
            ObjTextFunctions.ValidaNumero(sender, e, TxtDineroEntregado);
        }

        private void TxtEntrega12_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextFunctions ObjTextFunctions = new TextFunctions();
            ObjTextFunctions.ValidaNumero(sender, e, TxtEntrega12);
        }

        private void btnGenerar2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (c1cboCia.SelectedIndex != -1 & CboSede.SelectedIndex != -1 & DtpFechaIni.Value != null & DtpFechaFin.Value != null & CboCajero.SelectedIndex != -1)
                {

                    //reiniciar variables
                    totb = 0; totf = 0; tott = 0; toti = 0; tote = 0; DineroEntregado = 0; Entrega12 = 0;


                    Empresa = c1cboCia.Columns["NomEmpresa"].Value.ToString();
                    Sede = CboSede.Columns["NomSede"].Value.ToString();
                    EmpresaID = c1cboCia.SelectedValue.ToString();
                    SedeID = CboSede.SelectedValue.ToString();
                    Cajero = CboCajero.Columns["Usuario"].Value.ToString();
                    CajeroID = Convert.ToInt32(CboCajero.SelectedValue);
                    FechaIni = DtpFechaIni.Value;
                    FechaFin = DtpFechaFin.Value.AddDays(1);
                    DS = ObjCL_Venta.GetDetalleVentasComprobante2(FechaIni, FechaFin, CajeroID, EmpresaID, SedeID);
                    Halley.Presentacion.Ventas.CrystalReports.CrVentasComprobante2 ObjCrpVentasComprobante = new Halley.Presentacion.Ventas.CrystalReports.CrVentasComprobante2();

                    //tabla empresa
                    DataTable Dt = new DataTable("Logo");
                    Dt.Columns.Add("Logo", typeof(byte[]));
                    Dt.Columns.Add("NomEmpresa", typeof(string));
                    Dt.Columns.Add("RUC", typeof(string));
                    Dt.Columns.Add("DomicilioFiscal", typeof(string));
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
                    Dr["RUC"] = customerRow[0]["RUC"];
                    Dr["DomicilioFiscal"] = customerRow[0]["DomicilioFiscal"];
                    Dt.Rows.Add(Dr);
                    DS.Tables.Add(Dt.Copy());


                    ObjCrpVentasComprobante.SetDataSource(DS);

                    CrvResumenVentas.ReportSource = ObjCrpVentasComprobante;
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["TxtReporte"];
                    fechainicio = DtpFechaIni.Value.Date.ToShortDateString().ToString();
                    fechafin = DtpFechaFin.Value.Date.ToShortDateString().ToString();
                    txt.Text = "CUADRE DE CAJA DE " + fechainicio + " A " + fechafin;

                    DataView dv = new DataView(DS.Tables["Comprobante"]);
                    dv.RowFilter = "NomTipoComprobante='BOLETA' and FlgEst='True'";
                    if (dv.Count > 0)
                        totb = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "NomTipoComprobante='BOLETA' and FlgEst='True'"));

                    dv.RowFilter = "NomTipoComprobante='FACTURA' and FlgEst='True'";
                    if (dv.Count > 0)
                        totf = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "NomTipoComprobante='FACTURA' and FlgEst='True'"));


                    dv.RowFilter = "NomTipoComprobante='TICKET' and FlgEst='True'";
                    if (dv.Count > 0)
                        tott = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "NomTipoComprobante='TICKET' and FlgEst='True'"));

                    dv.RowFilter = "NomTipoComprobante='TICKET FACTURA' and FlgEst='True'";
                    if (dv.Count > 0)
                        tottf = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "NomTipoComprobante='TICKET FACTURA' and FlgEst='True'"));

                    dv.RowFilter = "(NomTipoComprobante='*SALDO INICIAL' or NomTipoComprobante='*INGRESO') and FlgEst='True'";
                    if (dv.Count > 0)
                        toti = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "(NomTipoComprobante='*SALDO INICIAL' or NomTipoComprobante='*INGRESO') and FlgEst='True'"));

                    dv.RowFilter = "NomTipoComprobante='*EGRESO' and FlgEst='True'";
                    if (dv.Count > 0)
                        tote = Convert.ToDecimal(DS.Tables["Comprobante"].Compute("Sum(Pagado)", "NomTipoComprobante='*EGRESO' and FlgEst='True'"));

                    TextObject txtb;
                    txtb = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txtb"];
                    txtb.Text = totb.ToString("C");

                    TextObject txtf;
                    txtf = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txtf"];
                    txtf.Text = totf.ToString("C");

                    TextObject txtt;
                    txtt = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txtt"];
                    txtt.Text = tott.ToString("C");

                    TextObject txttf;
                    txttf = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txttf"];
                    txttf.Text = tottf.ToString("C");

                    TextObject txti;
                    txti = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txti"];
                    txti.Text = toti.ToString("C");

                    TextObject txte;
                    txte = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txte"];
                    txte.Text = tote.ToString("C");

                    TextObject txts;
                    txts = (TextObject)ObjCrpVentasComprobante.ReportDefinition.ReportObjects["txts"];
                    txts.Text = (tott + tottf + totb + totf + toti - tote).ToString("C");

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

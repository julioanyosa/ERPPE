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
using Halley.CapaLogica.Contabilidad;
using Halley.Configuracion;
using CrystalDecisions.CrystalReports.Engine;
using Halley.CapaLogica.Ventas;
using System.Reflection;
using ThoughtWorks.QRCode.Codec;
using System.Net;

namespace Halley.Presentacion.Contabilidad.Reportes
{
    public partial class ConsolidadoVentas : UITemplateAccess
    {
        DateTime FecInicial;
        DateTime FecFinal;
        DataSet DsConsolidado;
        CapaLogica.Contabilidad.CL_Venta ObjCL_Venta = new CapaLogica.Contabilidad.CL_Venta();

        CrystalReports.CrConsolidadoVentas ObjCrCrGetVentasVendedor = new CrystalReports.CrConsolidadoVentas();


        CapaLogica.Ventas.CL_Venta objVenta = new CapaLogica.Ventas.CL_Venta();
        int hojaimpresa = 1;
        DataSet DS;
        DataTable dtcabecera;
        DataTable dtdetalle;
        Boolean ConCliente = true;

        DataTable DtDatosSede;


        public ConsolidadoVentas()
        {
            InitializeComponent();
        }

        private void ConsolidadoVentas_Load(object sender, EventArgs e)
        {
            DateTime fechatemp = DateTime.Today;

            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");

            if (c1cboCia.SelectedIndex != -1)
            {
                string EmpresaID = c1cboCia.SelectedValue.ToString();
            }

            //obtener año
            CboAnno.HoldFields();
            CboAnno.DataSource = c1Combo.Annos().Copy();
            CboAnno.DisplayMember = "Anno";
            CboAnno.ValueMember = "Anno";
            CboAnno.SelectedValue = fechatemp.Year;

            //obtener periodos
            CboPeriodo.HoldFields();
            CboPeriodo.DataSource = c1Combo.DtPeriodos().Copy();
            CboPeriodo.DisplayMember = "Descripcion";
            CboPeriodo.ValueMember = "Codigo";
            CboPeriodo.SelectedValue = fechatemp.Month.ToString("00");

            c1cboCia.SelectedValue = AppSettings.EmpresaID;
            c1Combo.FillC1Combo1(CboTipoComprobante, new CL_Comprobante().getTipoComprobante(), "NomTipoComprobante", "TipoComprobanteID");
            c1Combo.FillC1Combo1(CboTipoComprobanteListado, new CL_Comprobante().getTipoComprobante(), "NomTipoComprobante", "TipoComprobanteID");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {

                if (CboAnno.SelectedIndex != -1 & CboPeriodo.SelectedIndex != -1 & CboTipoComprobante.SelectedIndex != -1)
                {
                    FecInicial = new DateTime(Convert.ToInt16(CboAnno.SelectedValue.ToString()), Convert.ToInt16(CboPeriodo.SelectedValue.ToString()), 1);
                    FecFinal = new DateTime(Convert.ToInt16(CboAnno.SelectedValue.ToString()), Convert.ToInt16(CboPeriodo.SelectedValue.ToString()), 1).AddMonths(1);

                    DsConsolidado = ObjCL_Venta.GetConsolidadoDeVentas(FecInicial, FecFinal, Convert.ToInt16(CboTipoComprobante.SelectedValue), c1cboCia.SelectedValue.ToString());
                    DataTable Dt = new DataTable("Logo");
                    Dt.Columns.Add("Logo", typeof(byte[]));
                    Dt.Columns.Add("RUC", typeof(string));
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
                    Dr["RUC"] = customerRow[0]["RUC"];
                    Dt.Rows.Add(Dr);
                    DsConsolidado.Tables.Add(Dt);
                    ObjCrCrGetVentasVendedor.SetDataSource(DsConsolidado);

                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrCrGetVentasVendedor.ReportDefinition.ReportObjects["Txt1"];
                    txt.Text = "PERIODO: " + CboPeriodo.Columns["Descripcion"].Value.ToString() + " " + CboAnno.Columns["Anno"].Value.ToString();

                    TextObject txt2;
                    txt2 = (TextObject)ObjCrCrGetVentasVendedor.ReportDefinition.ReportObjects["Txt2"];
                    //txt2.Text = "Anexo de " + CboTipoComprobante.Columns["NomTipoComprobante"].Value.ToString();
                    txt2.Text = "REGISTRO AUXILIAR DE VENTAS";

                    //Agregar datos al subreporte
                    ObjCrCrGetVentasVendedor.Subreports[0].SetDataSource(DsConsolidado.Tables["RangoComprobantes"]);
                    CrvConsolidadoVentas.ReportSource = ObjCrCrGetVentasVendedor;

                    //cargar series
                    DataRow DRS = DsConsolidado.Tables["Series"].NewRow();
                    DRS["SERIE"] = "TOD";
                    DsConsolidado.Tables["Series"].Rows.InsertAt(DRS, 0);

                    cboSeries.HoldFields();
                    cboSeries.DisplayMember = "SERIE";
                    cboSeries.ValueMember = "SERIE";
                    cboSeries.DataSource = DsConsolidado.Tables["Series"];
                    cboSeries.SelectedIndex = 0;

                    //cargamos la grilla
                    DataTable DT = DsConsolidado.Tables[1].Copy();
                    TdgComprobantes.SetDataBinding(DT, "", true);

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.InnerException.Message);
                MessageBox.Show(ex.Message);

            }

            Cursor = Cursors.Default;
        }

        public void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }


        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            if (cboSeries.SelectedIndex != -1)
            {
                if (cboSeries.SelectedValue.ToString() != "TOD")
                {
                    DataView DV1 = new DataView(DsConsolidado.Tables["GetConsolidadoDeVentas"], "SERIE='" + cboSeries.SelectedValue.ToString() + "'", "NUMERO ASC", DataViewRowState.CurrentRows);
                    DataView DV2 = new DataView(DsConsolidado.Tables["RangoComprobantes"], "SERIE='" + cboSeries.SelectedValue.ToString() + "'", "FECHA ASC, SERIE ASC", DataViewRowState.CurrentRows);

                    DataSet DsFiltrado = new DataSet();

                    DsFiltrado.Tables.Add(DV1.ToTable("GetConsolidadoDeVentas"));
                    DsFiltrado.Tables.Add(DV2.ToTable("RangoComprobantes"));
                    DsFiltrado.Tables.Add(DsConsolidado.Tables["Logo"].Copy());
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrCrGetVentasVendedor.ReportDefinition.ReportObjects["Txt1"];
                    txt.Text = "PERIODO: " + CboPeriodo.Columns["Descripcion"].Value.ToString() + " " + CboAnno.Columns["Anno"].Value.ToString();

                    TextObject txt2;
                    txt2 = (TextObject)ObjCrCrGetVentasVendedor.ReportDefinition.ReportObjects["Txt2"];
                    txt2.Text = "REGISTRO AUXILIAR DE VENTAS";
                    //txt2.Text = "Anexo de " + CboTipoComprobante.Columns["NomTipoComprobante"].Value.ToString();

                    //Agregar datos al subreporte
                    ObjCrCrGetVentasVendedor.SetDataSource(DsFiltrado);
                    ObjCrCrGetVentasVendedor.Subreports[0].SetDataSource(DsFiltrado.Tables["RangoComprobantes"]);
                    CrvConsolidadoVentas.ReportSource = ObjCrCrGetVentasVendedor;
                }
                else
                {
                    //pasar datos directo al crystal reports
                    TextObject txt;
                    txt = (TextObject)ObjCrCrGetVentasVendedor.ReportDefinition.ReportObjects["Txt1"];
                    txt.Text = "PERIODO: " + CboPeriodo.Columns["Descripcion"].Value.ToString() + " " + CboAnno.Columns["Anno"].Value.ToString();

                    TextObject txt2;
                    txt2 = (TextObject)ObjCrCrGetVentasVendedor.ReportDefinition.ReportObjects["Txt2"];
                    txt2.Text = "Anexo de " + CboTipoComprobante.Columns["NomTipoComprobante"].Value.ToString();

                    //Agregar datos al subreporte
                    DsConsolidado.Tables["GetConsolidadoDeVentas"].DefaultView.Sort = "FECHA ASC, SERIE ASC, NUMERO ASC";
                    DsConsolidado.Tables["RangoComprobantes"].DefaultView.Sort = "FECHA ASC, SERIE ASC";
                    ObjCrCrGetVentasVendedor.SetDataSource(DsConsolidado);
                    ObjCrCrGetVentasVendedor.Subreports[0].SetDataSource(DsConsolidado.Tables["RangoComprobantes"]);
                    CrvConsolidadoVentas.ReportSource = ObjCrCrGetVentasVendedor;
                }
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (RbContable.Checked)
                Exportarexcel(1);
            else if (RbKardex.Checked)
                Exportarexcel(2);

        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (TdgComprobantes.RowCount > 0)
                {
                    string NumComprobante = this.TdgComprobantes.Columns["NumComprobante"].Value.ToString();
                    string SERIE = this.TdgComprobantes.Columns["SERIE"].Value.ToString();
                    string NUMERO = this.TdgComprobantes.Columns["NUMERO"].Value.ToString();
                    if (MessageBox.Show("¿Seguro que desea imprimir el comprobante " + SERIE + "-" + NUMERO + "?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Int64 ComprobanteId = Convert.ToInt64(this.TdgComprobantes.Columns["ComprobanteId"].Value);
                        hojaimpresa = 1;

                        DS = objVenta.ObtenerParaImpresion(ComprobanteId);
                        dtcabecera = DS.Tables[0];
                        dtdetalle = DS.Tables[1];

                        //seleccionar impresora

                        #region optener Nro IP
                        String NombreHost;
                        String DireccionIP;
                        NombreHost = Dns.GetHostName();
                        DireccionIP = System.Net.Dns.GetHostByName(NombreHost).AddressList[0] + "";
                        //MessageBox.Show(DireccionIP);
                        //dar formato a la direccion IP
                        string ACU = "";
                        string NuevaIP = "";
                        for (int X = 0; X < DireccionIP.Length; X++)
                        {
                            string Valor = DireccionIP.Substring(X, 1);
                            if (Valor != ".")
                                ACU += Valor;
                            else
                            {
                                NuevaIP += ACU.PadLeft(3, '0') + ".";
                                ACU = "";
                            }
                        }
                        NuevaIP += ACU.PadLeft(3, '0');
                        #endregion

                        //traer impresoras
                        CapaLogica.Users.CL_Usuario ObjUsuario = new CapaLogica.Users.CL_Usuario();
                        UTI_Datatables.Dt_Configuracion = ObjUsuario.USP_M_CONFIGURACION(2, 0, "", "", "", "", AppSettings.UserID, NuevaIP);

                        string EMPRESA_ID = dtcabecera.Rows[0]["EmpresaID"].ToString();
                        string TIPO_COMPROBANTE = "";

                        TIPO_COMPROBANTE = "TI";

                        //ahora se gauradara en una tabla Configuracion.Configuracion

                        DataView DV = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo ='" + "IMP_" + EMPRESA_ID + "_" + TIPO_COMPROBANTE + "'", "", DataViewRowState.CurrentRows);

                        if (DV.Count > 0)
                        {
                            printDocument1.PrinterSettings.PrinterName = DV[0]["Data"].ToString();
                            printDocument1.Print();
                        }
                        else
                        {
                            MessageBox.Show("No existe una impresora configurada, por favor agregela \n(seleccionar impresora ticket en venta)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }


                        if (printDocument1.PrinterSettings.PrinterName == "")
                        {
                            MessageBox.Show("Al parecer no se ha seleccionado la impresora. no se imprimira el comprobante.\n(seleccionar impresora ticket en venta)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Cursor = Cursors.Default;
                            return;
                        }
                        //fin seleccionar imrepsora
                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnConsultarListado_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {

                if (CboTipoComprobanteListado.SelectedIndex != -1)
                {

                    DataSet DS = ObjCL_Venta.GetConsolidadoDeVentas(Convert.ToDateTime(DtpFechaIniListado.Value.ToShortDateString()), Convert.ToDateTime(DtpFechaFinListado.Value.ToShortDateString()),
                        Convert.ToInt16(CboTipoComprobanteListado.SelectedValue), c1cboCia.SelectedValue.ToString());


                    //cargamos la grilla
                    DataTable DT = DS.Tables[1].Copy();
                    TdgComprobantes.SetDataBinding(DT, "", true);

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.InnerException.Message);
                MessageBox.Show(ex.Message);

            }

            Cursor = Cursors.Default;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            //formato para alinear los nuimeros a la derecha
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;
            //formato.LineAlignment = StringAlignment.Far;



            TextFunctions ObjTextFunctions = new TextFunctions();
            //obtener la cadena del total a pagar
            string TotalPagarLetras = ObjTextFunctions.enletras(dtcabecera.Rows[0]["Monto"].ToString());



            string NomEmpresa = dtcabecera.Rows[0]["NomEmpresa"].ToString();
            string RUC = dtcabecera.Rows[0]["RUC"].ToString();

            string SerieEticketera = "";
            string NroAutorizacion = "";


            string CodigoTipoComprobante = "03", TipoLetra = "B", TipoDocumentoCliente = "DNI";
            int Canticabecera = 31;
            string[] Formatoticket = new string[2];

            if (dtcabecera.Rows[0]["NroDocumentoCliente"].ToString() == "0")
                ConCliente = false;
            else
                ConCliente = true;

            if (hojaimpresa == 1)
            {

                if (Convert.ToInt16(dtcabecera.Rows[0]["TipoComprobanteID"]) == 4)//es boleta
                {

                    Formatoticket = objVenta.FormatoTicketFE(NomEmpresa, AppSettings.NomSede, dtcabecera.Rows[0]["NumComprobante"].ToString().Substring(2),
                    "BOLETA ELECTRONICA: ", dtdetalle, RUC, AppSettings.Usuario, Convert.ToDecimal(dtcabecera.Rows[0]["MontoPagado"]), dtcabecera.Rows[0]["NomCaja"].ToString(), SerieEticketera,
                    NroAutorizacion, TotalPagarLetras, dtcabecera.Rows[0]["RazonSocialCliente"].ToString(),
                    dtcabecera.Rows[0]["NroDocumentoCliente"].ToString(), dtcabecera.Rows[0]["DireccionCliente"].ToString(),
                    "", ConCliente, Convert.ToDateTime(dtcabecera.Rows[0]["AudCrea"]), Convert.ToDecimal(dtcabecera.Rows[0]["MontoPagado"]), Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]), "B",
                       DtDatosSede.Rows[0]["TelefonoCelular"].ToString(), DtDatosSede.Rows[0]["TelefonoFijo"].ToString(), Convert.ToDecimal(dtcabecera.Rows[0]["Monto"]), Convert.ToDecimal(dtcabecera.Rows[0]["TotalICBPER"]));
                    e.Graphics.DrawString(Formatoticket[0], TxtFormato.Font, Brushes.Black, 0, 0); //total pagar en letras


                }
                else if (Convert.ToInt16(dtcabecera.Rows[0]["TipoComprobanteID"]) == 5)//es factura
                {
                    CodigoTipoComprobante = "01";
                    TipoLetra = "F";
                    TipoDocumentoCliente = "RUC";
                    Canticabecera = 35;

                    Formatoticket = objVenta.FormatoTicketFE(NomEmpresa, AppSettings.NomSede, dtcabecera.Rows[0]["NumComprobante"].ToString().Substring(2),
                    "FACTURA ELECTRONICA: ", dtdetalle, RUC, AppSettings.Usuario, Convert.ToDecimal(dtcabecera.Rows[0]["MontoPagado"]), dtcabecera.Rows[0]["NomCaja"].ToString(), SerieEticketera,
                    NroAutorizacion, TotalPagarLetras, dtcabecera.Rows[0]["RazonSocialCliente"].ToString(),
                    dtcabecera.Rows[0]["NroDocumentoCliente"].ToString(), dtcabecera.Rows[0]["DireccionCliente"].ToString(),
                    "", ConCliente, Convert.ToDateTime(dtcabecera.Rows[0]["AudCrea"]), Convert.ToDecimal(dtcabecera.Rows[0]["MontoPagado"]), Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]), "F",
                       DtDatosSede.Rows[0]["TelefonoCelular"].ToString(), DtDatosSede.Rows[0]["TelefonoFijo"].ToString(), Convert.ToDecimal(dtcabecera.Rows[0]["Monto"]), Convert.ToDecimal(dtcabecera.Rows[0]["TotalICBPER"]));
                    e.Graphics.DrawString(Formatoticket[0], TxtFormato.Font, Brushes.Black, 0, 0); //total pagar en letras
                    //e.Graphics.DrawString(Convert.ToChar(27) + "i", TxtPrecio.Font, Brushes.Black, 0, 0); //total pagar en letras


                }


                /*imprimir el codigo de barras*/

                QRCodeEncoder objqrcode = new QRCodeEncoder();
                Image imgimage;
                Bitmap objbitmap;
                PictureBox Pimage = new PictureBox();
                string s;
                s = RUC + " | " + CodigoTipoComprobante + " | " + TipoLetra + dtcabecera.Rows[0]["NumComprobante"].ToString().Substring(2, 3) + " | " + "0" + dtcabecera.Rows[0]["NumComprobante"].ToString().Substring(6) + " | " + Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]).ToString("N2") + " | " + Convert.ToDecimal(dtcabecera.Rows[0]["Monto"]).ToString("N2") + " | " +
                    Convert.ToDateTime(dtcabecera.Rows[0]["AudCrea"]).ToShortDateString() + " | " + TipoDocumentoCliente + " | " + dtcabecera.Rows[0]["NroDocumentoCliente"].ToString();
                objqrcode.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                objqrcode.QRCodeScale = 3;
                objqrcode.QRCodeVersion = 6;
                objqrcode.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.L;
                imgimage = objqrcode.Encode(s);
                objbitmap = new Bitmap(imgimage);
                //objbitmap.Save("QRCode.jpg");
                //Pimage.ImageLocation = "QRCode.jpg";
                //CALCULAMOS AL CANTIDAD DE LINEAS
                int CantidadLineas = (Canticabecera * 14) + (Convert.ToInt32(Formatoticket[1]) * 14);
                e.Graphics.DrawImage(imgimage, new Point(70, CantidadLineas));


                if (Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]) == 0)
                {
                    string textofinal = "Bienes   transferidos  en   la  Amazonía\nRegión  Selva  para ser  cosumidos en la\nmisma.";
                    e.Graphics.DrawString(textofinal, TxtFormato.Font, Brushes.Black, 0, CantidadLineas + (14 * 11));
                }
                hojaimpresa = 2;
                e.HasMorePages = true;


            }

            else if (hojaimpresa == 2)
            {
                decimal total = Convert.ToDecimal(dtcabecera.Rows[0]["Monto"]) + Convert.ToDecimal(dtcabecera.Rows[0]["TotalICBPER"]) + Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]);

                if (Convert.ToInt16(dtcabecera.Rows[0]["TipoComprobanteID"]) == 4)//es boleta
                {
                    string[] Formatoticket2 = new string[2];
                    Formatoticket2 = objVenta.FormatoTicketFEResumido(NomEmpresa, AppSettings.NomSede, dtcabecera.Rows[0]["NumComprobante"].ToString().Substring(2),
                    "BOLETA ELECTRONICA: ", dtdetalle, RUC, AppSettings.Usuario, Convert.ToDecimal(dtcabecera.Rows[0]["MontoPagado"]), dtcabecera.Rows[0]["NomCaja"].ToString(), SerieEticketera,
                    NroAutorizacion, TotalPagarLetras, dtcabecera.Rows[0]["RazonSocialCliente"].ToString(),
                    dtcabecera.Rows[0]["NroDocumentoCliente"].ToString(), dtcabecera.Rows[0]["DireccionCliente"].ToString(),
                    "", ConCliente, Convert.ToDateTime(dtcabecera.Rows[0]["AudCrea"]), Convert.ToDecimal(dtcabecera.Rows[0]["MontoPagado"]),
                    Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]), "B", total, Convert.ToDecimal(dtcabecera.Rows[0]["TotalICBPER"]));
                    e.Graphics.DrawString(Formatoticket2[0], TxtFormato.Font, Brushes.Black, 0, 0); //total pagar en letras

                }
                else if (Convert.ToInt16(dtcabecera.Rows[0]["TipoComprobanteID"]) == 5)//es factura
                {
                    CodigoTipoComprobante = "01";
                    TipoLetra = "F";
                    TipoDocumentoCliente = "RUC";
                    Canticabecera = 35;

                    string[] Formatoticket2 = new string[2];
                    Formatoticket2 = objVenta.FormatoTicketFEResumido(NomEmpresa, AppSettings.NomSede, dtcabecera.Rows[0]["NumComprobante"].ToString().Substring(2),
                    "FACTURA ELECTRONICA: ", dtdetalle, RUC, AppSettings.Usuario, Convert.ToDecimal(dtcabecera.Rows[0]["Monto"]), dtcabecera.Rows[0]["NomCaja"].ToString(), SerieEticketera,
                    NroAutorizacion, TotalPagarLetras, dtcabecera.Rows[0]["RazonSocialCliente"].ToString(),
                    dtcabecera.Rows[0]["NroDocumentoCliente"].ToString(), dtcabecera.Rows[0]["DireccionCliente"].ToString(),
                    "", ConCliente, Convert.ToDateTime(dtcabecera.Rows[0]["AudCrea"]), Convert.ToDecimal(dtcabecera.Rows[0]["Monto"]),
                    Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]), "F", total, Convert.ToDecimal(dtcabecera.Rows[0]["TotalICBPER"]));
                    e.Graphics.DrawString(Formatoticket2[0], TxtFormato.Font, Brushes.Black, 0, 0); //total pagar en letras
                    //e.Graphics.DrawString(Convert.ToChar(27) + "i", TxtPrecio.Font, Brushes.Black, 0, 0); //total pagar en letras


                }



                e.HasMorePages = false;
            }





        }

        private void c1cboCia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c1cboCia.SelectedIndex != -1)
            {
                string EmpresaID = c1cboCia.SelectedValue.ToString();


                DtDatosSede = objVenta.ObtenerDatosSucursal(EmpresaID, AppSettings.SedeID);
            }
        }

        private void BtnExcelClientes_Click(object sender, EventArgs e)
        {
            Exportarexcel(4);
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            Exportarexcel(3);
        }


        private void Exportarexcel(Int16 tipo)
        {
            CapaLogica.Ventas.CL_Comprobante objCL_Comprobante = new CapaLogica.Ventas.CL_Comprobante();
            DateTime fi = Convert.ToDateTime(DtpFechaIni.Value.ToShortDateString());
            DateTime ff = Convert.ToDateTime(DtpFechaFin.Value.ToShortDateString());

            string nombrearchivo = "";
            if (tipo == 1)
            {

                nombrearchivo = "Contable" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString()
                    + DtpFechaIni.Value.ToShortDateString().Replace("/", "-") + "A" + DtpFechaFin.Value.ToShortDateString().Replace("/", "-");
            }
            else if (tipo == 2)
            {
                nombrearchivo = "Kardex" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString()
                   + DtpFechaIni.Value.ToShortDateString().Replace("/", "-") + "A" + DtpFechaFin.Value.ToShortDateString().Replace("/", "-");

            }
            else if (tipo == 3)
            {
                nombrearchivo = "Listado de Productos" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
            }
            else if (tipo == 4)
            {
                nombrearchivo = "Listado de Clientes" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
            }

            DataTable dt = objCL_Comprobante.ObtenerReportesParaSunat(c1cboCia.SelectedValue.ToString(), fi, ff, tipo);

            if (dt.Rows.Count > 0)
            {


                try
                {



                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        string filepath = fbd.SelectedPath + "\\" + nombrearchivo;

                        dt.ExportToExcel(filepath);
                    }





                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No existe información en el criterio buscado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


    }
    public static class My_DataTable_Extensions
    {
        /// <summary> 
        /// Export DataTable to Excel file 
        /// </summary> 
        /// <param name="DataTable">Source DataTable</param> 
        /// <param name="ExcelFilePath">Path to result file name</param> 
        public static void ExportToExcel(this System.Data.DataTable DataTable, string ExcelFilePath = null)
        {
            try
            {
                int ColumnsCount;

                if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook 
                Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                Excel.Workbooks.Add();

                // single worksheet 
                Microsoft.Office.Interop.Excel._Worksheet Worksheet = Excel.ActiveSheet;

                object[] Header = new object[ColumnsCount];

                // column headings    
                for (int i = 0; i < ColumnsCount; i++)
                    Header[i] = DataTable.Columns[i].ColumnName;

                Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
                HeaderRange.Value = Header;
                HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                HeaderRange.Font.Bold = true;

                // DataCells 
                int RowsCount = DataTable.Rows.Count;
                object[,] Cells = new object[RowsCount, ColumnsCount];

                for (int j = 0; j < RowsCount; j++)
                    for (int i = 0; i < ColumnsCount; i++)
                        Cells[j, i] = DataTable.Rows[j][i];

                Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value = Cells;

                // check fielpath 
                if (ExcelFilePath != null && ExcelFilePath != "")
                {
                    try
                    {
                        Worksheet.SaveAs(ExcelFilePath + ".xls");
                        Excel.Quit();
                        MessageBox.Show("Excel guardado!");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                         + ex.Message);
                    }
                }
                else // no filepath is given 
                {
                    Excel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
}

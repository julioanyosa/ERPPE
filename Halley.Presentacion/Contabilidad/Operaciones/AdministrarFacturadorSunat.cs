using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.CapaLogica.Ventas;
using Halley.CapaLogica.Empresa;
using Halley.Entidad.Ventas;
using System.IO;

namespace Halley.Presentacion.Contabilidad.Operaciones
{
    public partial class AdministrarFacturadorSunat : UITemplateAccess
    {

        CL_Comprobante objCL_Comprobante = new CL_Comprobante();
        int pagi = 1;


        string rutaarchivos = "";
        string ruc = "";
        string DomicilioFiscal, RutaXMLFE, RutaCDRFE, RutaCertificado, ClaveCertificado, UsuarioSOL, ClaveSol, RutaWS;
        int hojas = 0;

        public AdministrarFacturadorSunat()
        {
            InitializeComponent();
        }

        private void AdministrarFacturadorSunat_Load(object sender, EventArgs e)
        {
            LlenarCombos();
        }

        private void LlenarCombos()
        {
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");


            DataTable dtcom = new DataTable("t1");
            dtcom.Columns.Add("valor", typeof(string));
            dtcom.Columns.Add("texto", typeof(string));

            DataRow dr11 = dtcom.NewRow();
            dr11["valor"] = "0";
            dr11["texto"] = "TODOS";
            dtcom.Rows.Add(dr11);

           


            DataRow dr1 = dtcom.NewRow();
            dr1["valor"] = "4";
            dr1["texto"] = "BOLETA ELECTRÓNICA";
            dtcom.Rows.Add(dr1);

            DataRow dr2 = dtcom.NewRow();
            dr2["valor"] = "5";
            dr2["texto"] = "FACTURA ELECTRÓNICA";
            dtcom.Rows.Add(dr2);

            DataRow dr111 = dtcom.NewRow();
            dr111["valor"] = "1";
            dr111["texto"] = "BOLETA";
            dtcom.Rows.Add(dr111);

            DataRow dr112 = dtcom.NewRow();
            dr112["valor"] = "2";
            dr112["texto"] = "FACTURA";
            dtcom.Rows.Add(dr112);


            DataRow dr3 = dtcom.NewRow();
            dr3["valor"] = "10";
            dr3["texto"] = "RESUMEN DIARIO (BAJAS)";
            dtcom.Rows.Add(dr3);

            DataRow dr4 = dtcom.NewRow();
            dr4["valor"] = "11";
            dr4["texto"] = "CONFIRMACIÓN BAJA";
            dtcom.Rows.Add(dr4);


            DataTable dtpag = new DataTable("t3");
            dtpag.Columns.Add("valor", typeof(string));
            dtpag.Columns.Add("texto", typeof(string));

            DataRow drc10 = dtpag.NewRow();
            drc10["valor"] = "10";
            drc10["texto"] = "10";
            dtpag.Rows.Add(drc10);

            DataRow drc20 = dtpag.NewRow();
            drc20["valor"] = "20";
            drc20["texto"] = "20";
            dtpag.Rows.Add(drc20);

            DataRow drc50 = dtpag.NewRow();
            drc50["valor"] = "50";
            drc50["texto"] = "50";
            dtpag.Rows.Add(drc50);

            DataRow drc100 = dtpag.NewRow();
            drc100["valor"] = "100";
            drc100["texto"] = "100";
            dtpag.Rows.Add(drc100);

            c1Combo.FillC1Combo(this.CboTipoComprobante, dtcom, "texto", "valor");

            DataTable dtsunat = objCL_Comprobante.ObtenerEstadosSunat();

            DataRow dres1 = dtsunat.NewRow();
            dres1["Codigo"] = "  ";
            dres1["Descripcion"] = "TODOS";
            dtsunat.Rows.InsertAt(dres1, 0);


            c1Combo.FillC1Combo(this.CboEstadoSunat, dtsunat, "Descripcion", "Codigo");

            c1Combo.FillC1Combo(this.CboCantidadRegistros, dtpag, "texto", "valor");

            DataTable DtComprobante = new CL_Comprobante().getTipoComprobante();
            DataTable Dtempresas = new CL_Empresas().GetEmpresas();

            DataView DV = new DataView(DtComprobante, "TipoComprobanteID in(1,2,4,5)", "", DataViewRowState.CurrentRows);
            c1Combo.FillC1Combo1(CboComprobanteFacturadorSunat, DV.ToTable(), "NomTipoComprobante", "TipoComprobanteID");


        }



        private int Cargar(int pagina)
        {
            DataSet ds = objCL_Comprobante.ListarFacturadorSunat(c1cboCia.SelectedValue.ToString(), Convert.ToDateTime(DtpFechaIni.Value.ToShortDateString()),
                Convert.ToDateTime(DtpFechaFin.Value.ToShortDateString()), Convert.ToInt32(CboTipoComprobante.SelectedValue), CboEstadoSunat.SelectedValue.ToString(), pagina, Convert.ToInt32(CboCantidadRegistros.SelectedValue), 1);

            DataTable dt = ds.Tables[0];
            //rutaarchivos = ds.Tables[1].Rows[0]["rutaarchivos"].ToString();


            if (dt.Rows.Count > 0)
            {
                LblCantidad.Text = dt.Rows[0]["Cantidad"].ToString() + " registros encontrados";
                hojas = (Convert.ToInt32(dt.Rows[0]["Cantidad"]) / Convert.ToInt32(CboCantidadRegistros.SelectedValue)) + ((Convert.ToInt32(dt.Rows[0]["Cantidad"]) % Convert.ToInt32(CboCantidadRegistros.SelectedValue) > 0) ? 1 : 0);
                LblPagina.Text = pagina.ToString() + " de " + hojas.ToString();
            }
            else
            {
                LblCantidad.Text = "0 registros encontrados";
                LblPagina.Text = pagina.ToString() + " de " + hojas.ToString();
            }

            BtnPrimero.Enabled = true;
            BtnAnterior.Enabled = true;
            BtnSiguiente.Enabled = true;
            BtnUltimo.Enabled = true;

            if (hojas == pagina)
            {
                BtnSiguiente.Enabled = true;
                BtnUltimo.Enabled = false;
            }

            if (hojas == 1)
            {
                BtnPrimero.Enabled = false;
                BtnAnterior.Enabled = false;
            }



            TdgProductosFormulados.SetDataBinding(dt, "", true);
            return dt.Rows.Count;


        }


        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            pagi = 1;
            Cargar(pagi);
        }

        private void BtnActualizarinformacion_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Seguro que desea actualizar la infomación?, esta acción no se puede deshacer,\nadicionalmente eliminará los archivos ya aceptados por sunat", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //aca debera refrescar la información , los aceptados lo eliminara
                DataTable dt;
                dt = objCL_Comprobante.ObtenerFacturadorComprobantes(c1cboCia.SelectedValue.ToString());



                int td = 0;
                string numcom = "";
                DateTime? fecha = null;
                string mensaje = "";


                foreach (DataRow DR in dt.Rows)
                {

                    td = 0;
                    numcom = "";
                    fecha = null;
                    mensaje = "";

                    if (DR["TIP_DOCU"].ToString() == "01" | DR["TIP_DOCU"].ToString() == "03"
                        | DR["TIP_DOCU"].ToString() == "RA" | DR["TIP_DOCU"].ToString() == "RC")
                    {
                        if (DR["TIP_DOCU"].ToString() == "01")
                            td = 5;
                        else if (DR["TIP_DOCU"].ToString() == "03")
                            td = 4;
                        else if (DR["TIP_DOCU"].ToString() == "RA")
                            td = 11;
                        else if (DR["TIP_DOCU"].ToString() == "RC")
                            td = 10;


                        if (DR["FEC_ENVI"].ToString() != "")
                        {
                            fecha = Convert.ToDateTime(DR["FEC_ENVI"].ToString());
                        }
                        if (DR["IND_SITU"].ToString() == "03")
                            mensaje = "Aceptado por Sunat";
                        else if (DR["IND_SITU"].ToString() == "04")
                            mensaje = "Enviado y Aceptado SUNAT con Obs.";
                        else
                            mensaje = DR["DES_OBSE"].ToString();

                        if (DR["TIP_DOCU"].ToString() == "01" | DR["TIP_DOCU"].ToString() == "03")
                        {
                            numcom = c1cboCia.SelectedValue.ToString() + DR["NUM_DOCU"].ToString().Substring(1, 3) + "-" + DR["NUM_DOCU"].ToString().Substring(6);
                        }
                        else if (DR["TIP_DOCU"].ToString() == "RA" | DR["TIP_DOCU"].ToString() == "RC")
                        {
                            numcom = DR["NUM_DOCU"].ToString();
                        }
                        objCL_Comprobante.ActualizarDesdeFacturadorSunat(c1cboCia.SelectedValue.ToString(), numcom, td, fecha, mensaje, DR["IND_SITU"].ToString(), null);

                        if (DR["IND_SITU"].ToString() == "03" |
                            DR["IND_SITU"].ToString() == "04" |
                            DR["IND_SITU"].ToString() == "05" |
                             DR["IND_SITU"].ToString() == "11" |
                             DR["IND_SITU"].ToString() == "12")
                        {

                            if (DR["TIP_DOCU"].ToString() == "01" | DR["TIP_DOCU"].ToString() == "03")
                            {
                                System.IO.File.Delete(rutaarchivos + DR["NOM_ARCH"].ToString() + ".CAB");
                                System.IO.File.Delete(rutaarchivos + DR["NOM_ARCH"].ToString() + ".DET");
                                System.IO.File.Delete(rutaarchivos + DR["NOM_ARCH"].ToString() + ".LEY");
                                System.IO.File.Delete(rutaarchivos + DR["NOM_ARCH"].ToString() + ".TRI");
                            }
                            else if (DR["TIP_DOCU"].ToString() == "RC")
                            {
                                System.IO.File.Delete(rutaarchivos + DR["NOM_ARCH"].ToString() + ".RDI");
                            }
                            else if (DR["TIP_DOCU"].ToString() == "RA")
                            {
                                System.IO.File.Delete(rutaarchivos + DR["NOM_ARCH"].ToString() + ".CBA");
                            }

                            //eliminar de la bd
                            objCL_Comprobante.EliminarFacturadorComprobantes(DR["NOM_ARCH"].ToString(), c1cboCia.SelectedValue.ToString());
                        }


                    }


                }

                MessageBox.Show("Se termino de actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }




        private void BtnVolverGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TdgProductosFormulados.RowCount > 0)
                {
                    Int64 ComprobanteId = Convert.ToInt64(this.TdgProductosFormulados.Columns["ComprobanteId"].Value);
                    string EstadoSunat = this.TdgProductosFormulados.Columns["EstadoSunat"].Value.ToString();
                    if (EstadoSunat != "03" &
                          EstadoSunat != "04" &
                          EstadoSunat != "05" &
                           EstadoSunat != "11" &
                           EstadoSunat != "12")
                    {
                        string Comprobante = this.TdgProductosFormulados.Columns["Comprobante"].Value.ToString();
                        string TipoSunat = this.TdgProductosFormulados.Columns["TipoSunat"].Value.ToString();

                        string NOM_ARCH = ruc + "-" + TipoSunat + "-" + Comprobante;
                        if (MessageBox.Show("¿Seguro que desea generar los archivos txt del comprobante " + Comprobante + "?\nesta acción no se puede deshacer.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            objCL_Comprobante.GenerarTxtFacturadorSunat(ComprobanteId, LblRutaArchivo.Text);
                            objCL_Comprobante.EliminarFacturadorComprobantes(NOM_ARCH, c1cboCia.SelectedValue.ToString());
                            MessageBox.Show("Se termino de generar los archivos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Comprobantes ya aceptados no deben ser generados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnGenerarTxtFacturacionElectronica_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (CboComprobanteFacturadorSunat.SelectedIndex != -1 & TxtFechaGenerarFacturacionElectronicaIni.Value != null & TxtFechaGenerarFacturacionElectronicaFin.Value != null)
                {
                    if (MessageBox.Show("¿Seguro que desea generar los txt del facturador Sunat de fecha " + TxtFechaGenerarFacturacionElectronicaIni.Value.ToShortDateString() + ".?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        DateTime fechaini = Convert.ToDateTime(TxtFechaGenerarFacturacionElectronicaIni.Value.ToShortDateString());
                        DateTime fechafin = Convert.ToDateTime(TxtFechaGenerarFacturacionElectronicaFin.Value.ToShortDateString());
                        objCL_Comprobante.GenerarTxtFacturadorSunatVarios(c1cboCia.SelectedValue.ToString(), Convert.ToInt32(CboComprobanteFacturadorSunat.SelectedValue), fechaini, fechafin, LblRutaArchivo.Text);

                        MessageBox.Show("Se genero los archivos correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    if (TxtFechaGenerarFacturacionElectronicaIni.Value == null) ErrProvider.SetError(TxtFechaGenerarFacturacionElectronicaIni, "Seleccione una fecha.");
                    if (TxtFechaGenerarFacturacionElectronicaFin.Value == null) ErrProvider.SetError(TxtFechaGenerarFacturacionElectronicaFin, "Seleccione una fecha.");
                    if (CboComprobanteFacturadorSunat.SelectedIndex == -1) ErrProvider.SetError(CboComprobanteFacturadorSunat, "Seleccione un tipo de comprobante.");
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }

        private void BtnGenerarBajaBoletas_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (TxtFechaBaja.Value != null)
                {
                    if (MessageBox.Show("¿Seguro que desea generar el resumen diario de fecha " + TxtFechaBaja.Value.ToShortDateString() + ".?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        objCL_Comprobante.GenerarTxtFacturadorSunatResumenDiario(TxtFechaBaja.Value, c1cboCia.SelectedValue.ToString(), LblRutaArchivo.Text, false,4);

                        MessageBox.Show("Se genero el resumen diario correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    if (TxtFechaBaja.Value == null) ErrProvider.SetError(TxtFechaBaja, "Seleccione una fecha.");


                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }

        private void BtnSeleccionarRutaArchivo_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //E:\SFS_v1.2\bd\BDFacturador.db
                //E:\SFS_v1.2\sunat_archivos\sfs\DATA
                LblRutaArchivo.Text = folderBrowserDialog1.SelectedPath + "\\sunat_archivos\\sfs\\DATA";
                LblRutaBD.Text = folderBrowserDialog1.SelectedPath + "\\bd\\BDFacturador.db";

                if (LblRutaArchivo.Text != "" & LblRutaBD.Text != "")
                {
                    objCL_Comprobante.EditarDatosFacturadorSunat(c1cboCia.SelectedValue.ToString(), LblRutaArchivo.Text, LblRutaBD.Text);
                    rutaarchivos = LblRutaArchivo.Text + "\\";
                }
            }


        }



        private void BtnConfirmacionBajaFE_Click(object sender, EventArgs e)
        {

        }

        private void BtnConfirmacionBajaFE_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (TdgProductosFormulados.RowCount > 0)
                {
                    string NumComprobante = this.TdgProductosFormulados.Columns["NumComprobante"].Value.ToString();
                    string EstadoSunat = this.TdgProductosFormulados.Columns["EstadoSunat"].Value.ToString();
                    string TipoSunat = this.TdgProductosFormulados.Columns["TipoSunat"].Value.ToString();

                    if ((EstadoSunat == "03" |
                            EstadoSunat == "04" |
                        //  EstadoSunat == "05" |
                             EstadoSunat == "11" |
                             EstadoSunat == "12") & TipoSunat == "01")
                    {
                        DataTable dt1 = objCL_Comprobante.ObtenerDatosFacturdorSunat(c1cboCia.SelectedValue.ToString());
                        objCL_Comprobante.GenerarTxtFacturadorSunatComunicacionBaja(c1cboCia.SelectedValue.ToString(), NumComprobante, TxtMotivoEliminacion.Text, dt1.Rows[0]["RutaArchivosSunat"].ToString());
                        MessageBox.Show("Se genero el archivo de baja", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Solo se puede confirmar la baja de Facturas Enviadas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrimero_Click(object sender, EventArgs e)
        {

            pagi = 1;
            Cargar(pagi);
            BtnSiguiente.Enabled = true;
            BtnUltimo.Enabled = true;

            BtnAnterior.Enabled = false;
            BtnPrimero.Enabled = false;

        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (pagi > 1)
            {
                pagi = pagi - 1;
                Cargar(pagi);
                BtnSiguiente.Enabled = true;
            }
            else
            {
                BtnAnterior.Enabled = true;
                BtnPrimero.Enabled = false;
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (hojas >= pagi + 1)
            {
                pagi = pagi + 1;
                int res = Cargar(pagi);
            }
            else
            {
                BtnSiguiente.Enabled = false;
                BtnUltimo.Enabled = false;
            }


        }

        private void BtnUltimo_Click(object sender, EventArgs e)
        {
            pagi = hojas;
            Cargar(pagi);
            BtnSiguiente.Enabled = false;
            BtnUltimo.Enabled = false;
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            CapaLogica.Ventas.CL_Comprobante objCL_Comprobante = new CapaLogica.Ventas.CL_Comprobante();
            DateTime fi = Convert.ToDateTime(DtpFechaIni.Value.ToShortDateString());
            DateTime ff = Convert.ToDateTime(DtpFechaFin.Value.ToShortDateString());

            string nombrearchivo = "";


            nombrearchivo = "EmitidosDesde" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString()
                + DtpFechaIni.Value.ToShortDateString().Replace("/", "-") + "A" + DtpFechaFin.Value.ToShortDateString().Replace("/", "-");


            DataSet ds = objCL_Comprobante.ListarFacturadorSunat(c1cboCia.SelectedValue.ToString(), Convert.ToDateTime(DtpFechaIni.Value.ToShortDateString()),
        Convert.ToDateTime(DtpFechaFin.Value.ToShortDateString()), Convert.ToInt32(CboTipoComprobante.SelectedValue), CboEstadoSunat.SelectedValue.ToString(), 1, 1, 2);

            DataTable dt = ds.Tables[0];
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

        private void BtnEnviarFacturaOSE_Click(object sender, EventArgs e)
        {



            if (MessageBox.Show("¿Seguro que desea actualizar la infomación?, esta acción no se puede deshacer,\nadicionalmente eliminará los archivos ya aceptados por sunat", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                DataSet DS = objCL_Comprobante.ListarEnvioOSE(c1cboCia.SelectedValue.ToString(), Convert.ToDateTime(DtpFechaEnvioOSE.Value.ToShortDateString()));
                DataTable dt = DS.Tables[0];
                foreach (DataRow DR in dt.Rows)
                {
                    bool esresumen = false;
                    DateTime? fecha = null;
                    bool hayError = false;

                    string mensaje = "";
                    string numcom = "";
                    string estadosunat = "";
                    string NroTicket = null;

                    string rutafirmado = rutaarchivos.Substring(0, rutaarchivos.Length - 5) + "FIRMA";

                    int td = 0;
                    td = Convert.ToInt16(DR["TipoComprobanteID"]);

                    numcom = DR["NumComprobante"].ToString();
            

                    if (DR["TipoSunat"].ToString() == "RC" | DR["TipoSunat"].ToString() == "RA") {
                        esresumen = true;

                        //validamos que se haya generado todos los xml
                        DataTable Dtboletas = objCL_Comprobante.ObtenerComprobantesResumen(Convert.ToInt32(DR["ComprobanteId"]));
                        string listaSinGenerar = "";
                        foreach (DataRow Drbol in Dtboletas.Rows) {
                            if (File.Exists(rutafirmado + @"\" + ruc + "-" + Drbol["TipoSunat"].ToString() + "-" + Drbol["Comprobante"] + ".xml") == false)
                            {
                                listaSinGenerar = listaSinGenerar + Drbol["TipoSunat"].ToString() + "-" + Drbol["Comprobante"] + ", ";
                                hayError = true;
                                mensaje = "No ha sido generado el XML de la(s) boleta(s) " + listaSinGenerar;
                            }
                        }
                    }

                    if (hayError) {                   
                        estadosunat = "05";
                        objCL_Comprobante.ActualizarDesdeFacturadorSunat(c1cboCia.SelectedValue.ToString(), numcom, td, fecha, mensaje, estadosunat, NroTicket);
                        hayError = false;
                        continue;
                    }
                    RespuestaComunConArchivo2 respu = objCL_Comprobante.EnviarXMLFE(RutaWS, UsuarioSOL, ClaveSol, ruc, DR["TipoSunat"].ToString(), DR["Comprobante"].ToString(),
                        esresumen, rutafirmado, RutaCDRFE);

                    //elminamos archivos
                    if (respu.Exito == true)
                    {
                        if (DR["TipoSunat"].ToString() == "01" | DR["TipoSunat"].ToString() == "03")
                        {
                            System.IO.File.Delete(rutaarchivos + ruc + "-" + DR["TipoSunat"].ToString() + "-" + DR["Comprobante"].ToString() + ".CAB");
                            System.IO.File.Delete(rutaarchivos + ruc + "-" + DR["TipoSunat"].ToString() + "-" + DR["Comprobante"].ToString() + ".DET");
                            System.IO.File.Delete(rutaarchivos + ruc + "-" + DR["TipoSunat"].ToString() + "-" + DR["Comprobante"].ToString() + ".LEY");
                            System.IO.File.Delete(rutaarchivos + ruc + "-" + DR["TipoSunat"].ToString() + "-" + DR["Comprobante"].ToString() + ".TRI");

                        }


                        //tambien de la bd
                        objCL_Comprobante.EliminarFacturadorComprobantes(ruc + "-" + DR["TipoSunat"].ToString() + "-" + DR["Comprobante"].ToString(), c1cboCia.SelectedValue.ToString());

                        fecha = DateTime.Now;
                        mensaje = respu.MensajeRespuesta;
                        estadosunat = "03";

                        if (respu.NroTicket != "" & respu.NroTicket != null)
                            NroTicket = respu.NroTicket;
                    }
                    else
                    {
                        estadosunat = "05";
                        mensaje = (respu.MensajeRespuesta == "" | respu.MensajeRespuesta == null) ? respu.MensajeError : respu.MensajeRespuesta;
                    }

                    //actualizamos en bd   
                    objCL_Comprobante.ActualizarDesdeFacturadorSunat(c1cboCia.SelectedValue.ToString(), numcom, td, fecha, mensaje, estadosunat, NroTicket);

                }
                MessageBox.Show("Se termino de actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void BtnGenerarAltaBoletas_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (TxtFechaBaja.Value != null)
                {
                    if (MessageBox.Show("¿Seguro que desea generar el resumen diario de fecha " + TxtFechaBaja.Value.ToShortDateString() + ".?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        objCL_Comprobante.GenerarTxtFacturadorSunatResumenDiario(TxtFechaBaja.Value, c1cboCia.SelectedValue.ToString(), LblRutaArchivo.Text, true,4);

                        MessageBox.Show("Se genero el resumen diario correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    if (TxtFechaBaja.Value == null) ErrProvider.SetError(TxtFechaBaja, "Seleccione una fecha.");
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }

        private void BtnObtenerInformaciónTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (TdgProductosFormulados.RowCount > 0)
                {
                    string NumComprobante = this.TdgProductosFormulados.Columns["NumComprobante"].Value.ToString();
                    string EstadoSunat = this.TdgProductosFormulados.Columns["EstadoSunat"].Value.ToString();
                    string TipoSunat = this.TdgProductosFormulados.Columns["TipoSunat"].Value.ToString();
                    string NroTicket = this.TdgProductosFormulados.Columns["NroTicket"].Value.ToString();
                    int ComprobanteId = Convert.ToInt32(this.TdgProductosFormulados.Columns["ComprobanteId"].Value.ToString());


                    NumComprobante = NumComprobante.Replace("RC-", "").Replace("RA-", "");


                    if ((EstadoSunat == "03" |
                            EstadoSunat == "04" |
                             EstadoSunat == "11" |
                             EstadoSunat == "12") & TipoSunat == "RC" | TipoSunat == "RA")
                    {
                        RespuestaComunConArchivo2 respu = objCL_Comprobante.ConsultarTicketFE(RutaWS, UsuarioSOL, ClaveSol, ruc, NroTicket, NumComprobante, RutaCDRFE);

                        if (respu.Exito)
                        {
                            //borramos los archivos
                            if (TipoSunat == "RC")
                            {
                                System.IO.File.Delete(rutaarchivos + ruc + "-" + TipoSunat + "-" + NumComprobante + ".RDI");
                            }
                            else if (TipoSunat == "RA")
                            {
                                System.IO.File.Delete(rutaarchivos + ruc + "-" + TipoSunat + "-" + NumComprobante + ".CBA");
                            }

                            //eliminar de la bd
                            objCL_Comprobante.EliminarFacturadorComprobantes(ruc + "-" + TipoSunat + "-" + NumComprobante, c1cboCia.SelectedValue.ToString());

                            //borramos las boletas seleccionadas
                            DataTable DT = objCL_Comprobante.ActualizarTicketBaja(ComprobanteId, respu.MensajeRespuesta);
                            foreach (DataRow DR in DT.Rows)
                            {
                                System.IO.File.Delete(rutaarchivos + ruc + "-" + DR["TipoSunat"].ToString() + "-" + DR["Comprobante"].ToString() + ".CAB");
                                System.IO.File.Delete(rutaarchivos + ruc + "-" + DR["TipoSunat"].ToString() + "-" + DR["Comprobante"].ToString() + ".DET");
                                System.IO.File.Delete(rutaarchivos + ruc + "-" + DR["TipoSunat"].ToString() + "-" + DR["Comprobante"].ToString() + ".LEY");
                                System.IO.File.Delete(rutaarchivos + ruc + "-" + DR["TipoSunat"].ToString() + "-" + DR["Comprobante"].ToString() + ".TRI");


                                //eliminar de la bd
                                objCL_Comprobante.EliminarFacturadorComprobantes(ruc + "-" + DR["TipoSunat"].ToString() + "-" + DR["Comprobante"].ToString(), c1cboCia.SelectedValue.ToString());
                            }
                        }

                        MessageBox.Show("Se actualizo correctamente la información del ticket", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnBuscar_Click(null, null);

                    }
                    else
                    {
                        MessageBox.Show("Solo se puede consultar ticket de resumen y de baja y que ya hayan sido enviados.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void c1cboCia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c1cboCia.SelectedIndex != -1)
            {
                //obtener la ruta de la bd y carpeta
                DataTable dt1 = objCL_Comprobante.ObtenerDatosFacturdorSunat(c1cboCia.SelectedValue.ToString());
                LblRutaBD.Text = dt1.Rows[0]["RutaBDSunat"].ToString();
                LblRutaArchivo.Text = dt1.Rows[0]["RutaArchivosSunat"].ToString();
                rutaarchivos = dt1.Rows[0]["RutaArchivosSunat"].ToString() + "\\";
                ruc = dt1.Rows[0]["RUC"].ToString();
                DomicilioFiscal = dt1.Rows[0]["DomicilioFiscal"].ToString();
                RutaXMLFE = dt1.Rows[0]["RutaXMLFE"].ToString();
                RutaCDRFE = dt1.Rows[0]["RutaCDRFE"].ToString();
                RutaCertificado = dt1.Rows[0]["RutaCertificado"].ToString();
                ClaveCertificado = dt1.Rows[0]["ClaveCertificado"].ToString();
                UsuarioSOL = dt1.Rows[0]["UsuarioSOL"].ToString();
                ClaveSol = dt1.Rows[0]["ClaveSol"].ToString();
                RutaWS = dt1.Rows[0]["RutaWS"].ToString();
            }
        }

        private void BtnGenerarAltaBoletasContingencia_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (TxtFechaBaja.Value != null)
                {
                    if (MessageBox.Show("¿Seguro que desea generar el resumen diario de fecha " + TxtFechaBaja.Value.ToShortDateString() + ".?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        objCL_Comprobante.GenerarTxtFacturadorSunatResumenDiario(TxtFechaBaja.Value, c1cboCia.SelectedValue.ToString(), LblRutaArchivo.Text, true, 1);

                        MessageBox.Show("Se genero el resumen diario correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    if (TxtFechaBaja.Value == null) ErrProvider.SetError(TxtFechaBaja, "Seleccione una fecha.");
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }

        private void BtnGenerarBajaBoletasContngencia_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (TxtFechaBaja.Value != null)
                {
                    if (MessageBox.Show("¿Seguro que desea generar el resumen diario de fecha " + TxtFechaBaja.Value.ToShortDateString() + ".?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        objCL_Comprobante.GenerarTxtFacturadorSunatResumenDiario(TxtFechaBaja.Value, c1cboCia.SelectedValue.ToString(), LblRutaArchivo.Text, false, 1);

                        MessageBox.Show("Se genero el resumen diario correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    if (TxtFechaBaja.Value == null) ErrProvider.SetError(TxtFechaBaja, "Seleccione una fecha.");


                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }

        private void BtnEliminarGeneradas_Click(object sender, EventArgs e)
        {
            //papu
            try
            {
                Cursor = Cursors.WaitCursor;
                DataTable dt;
                dt = objCL_Comprobante.ObtenerFacturadorComprobantesEliminar(c1cboCia.SelectedValue.ToString());

                //recorremos y eliminamos
                foreach (DataRow DR in dt.Rows)
                {
                    if (DR["TIP_DOCU"].ToString() == "01" | DR["TIP_DOCU"].ToString() == "03")
                    {
                        System.IO.File.Delete(rutaarchivos + DR["NOM_ARCH"].ToString() + ".CAB");
                        System.IO.File.Delete(rutaarchivos + DR["NOM_ARCH"].ToString() + ".DET");
                        System.IO.File.Delete(rutaarchivos + DR["NOM_ARCH"].ToString() + ".LEY");
                        System.IO.File.Delete(rutaarchivos + DR["NOM_ARCH"].ToString() + ".TRI");

                        //eliminar de la bd
                        objCL_Comprobante.EliminarFacturadorComprobantes(DR["NOM_ARCH"].ToString(), c1cboCia.SelectedValue.ToString());
                    }

                }

                MessageBox.Show("Se eliminó los comprobantes generados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
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

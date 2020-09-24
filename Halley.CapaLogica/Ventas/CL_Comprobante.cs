using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Halley.CapaDatos.Ventas;
using Halley.Configuracion;
using Halley.Entidad.Ventas;
using Halley.Utilitario;
using System.Configuration;



namespace Halley.CapaLogica.Ventas
{
    public class CL_Comprobante
    {
        public DataTable getTipoComprobante()
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Comprobante.getTipoComprobante();
            return dtTMP;
        }

        public DataTable getTipoPago()
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Comprobante.getTipoPago();
            return dtTMP;
        }

        public DataTable getFormaPago()
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Comprobante.getFormaPago();
            return dtTMP;
        }

        public int getIGV()
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            int IGV;

            IGV = ObjCD_Comprobante.getIGV();
            return IGV;
        }

        public void InsertarIGV(int IGV, int UsuarioID)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            ObjCD_Comprobante.InsertarIGV(IGV, UsuarioID);

        }

        public DataTable GetSerieComprobantes(string EmpresaSede)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Comprobante.GetSerieComprobantes(EmpresaSede);
            return dtTMP;
        }

        public DataTable GetSerieGuiasT(string Sede)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Comprobante.GetSerieGuiasT(Sede);
            return dtTMP;
        }

        public DataTable GetCajasSede(string EmpresaSede)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Comprobante.GetCajasSede(EmpresaSede);
            return dtTMP;
        }

        public DataTable GetCajasSedeT(string DireccionIP)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Comprobante.GetCajasSedeT(DireccionIP);
            return dtTMP;
        }

        public DataTable InsertComprobante(E_Comprobante ObjComprobante, DataTable dtComprobante,
            int NumPedido, string Tipo, DataTable DTValesConsumo, DataTable DtBoucher, DataTable DtNotaIngreso)
        {
            string xml, xmlDetalle;
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);

            xml = new BaseFunctions().GetXML(dtComprobante).Replace("NewDataSet", "DocumentElement");
            xmlDetalle = xml.Replace("Table", "Comprobante");


            DataTable DT = ObjCD_Comprobante.InsertComprobante(ObjComprobante, xmlDetalle, NumPedido, Tipo, DTValesConsumo, DtBoucher, DtNotaIngreso);
            string tipo = "";
            if (ObjComprobante.TipoComprobanteID == 5)
                tipo = "01";
            else if (ObjComprobante.TipoComprobanteID == 4)
                tipo = "03";

            //string valor = GenerarSunat(ObjComprobante.TipoComprobanteID, DT.Rows[0]["NumComprobante"].ToString(), ObjComprobante.EmpresaID, tipo, "", "");
            
            string valor = "OK";
            DT.Columns.Add("respuesta", typeof(string));
            DT.Rows[0]["respuesta"] = valor;
            return DT;
        }


        public DataSet GenerarTxtFacturadorSunat(Int64 ID, string Ruta)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            DataSet dtTMP = new DataSet();

            dtTMP = ObjCD_Comprobante.GenerarTxtFacturadorSunat(ID, Ruta);
            return dtTMP;
        }

        public DataTable GenerarTxtFacturadorSunatVarios(string EmpresaID, int TipoComprobanteID, DateTime FechaIni, DateTime FechaFin, string Ruta)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Comprobante.GenerarTxtFacturadorSunatVarios(EmpresaID, TipoComprobanteID, FechaIni, FechaFin, Ruta);
            return dtTMP;
        }

        public string GenerarTxtFacturadorSunatResumenDiario(DateTime fecha, string EmpresaID, string Ruta, bool FlgEst, int TipoComprobanteID)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            return ObjCD_Comprobante.GenerarTxtFacturadorSunatResumenDiario(fecha, EmpresaID, Ruta, FlgEst, TipoComprobanteID);

        }

        public string GenerarTxtFacturadorSunatComunicacionBaja(string EmpresaID, string NumComprobante,string MotivoBaja,string Ruta)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            return ObjCD_Comprobante.GenerarTxtFacturadorSunatComunicacionBaja(EmpresaID, NumComprobante, MotivoBaja, Ruta);
            
        }
       
        public string GenerarSunat(Int32 TipoComprobanteID, string NumComprobante, string EmpresaID, string Tipo, string TipoNotaCredito, string DescripcionAnulacion)
        {
            /*
             TipoDocumento = 07  nota de credito
            NumComprobante2 para notacredito
             */
            try
            {
                DataSet ds = GetComprobanteFE(TipoComprobanteID, NumComprobante, EmpresaID, null, Tipo);
                DataTable dtc = ds.Tables[0];
                DataTable dtd = ds.Tables[1];

                if (dtc.Rows[0]["EmiteFE"].ToString() == "S" & (Tipo == "01" | Tipo == "03" | Tipo == "07"))
                {
                    string RUTA_WS_SUNAT = ConfigurationManager.AppSettings["RUTA_WS_SUNAT"];


                    ServicioEnviarComprobanteFE.FEServiceClient ServicioFE = new ServicioEnviarComprobanteFE.FEServiceClient();
                    ServicioEnviarComprobanteFE.Contribuyente emisor = new ServicioEnviarComprobanteFE.Contribuyente();
                    ServicioEnviarComprobanteFE.Contribuyente receptor = new ServicioEnviarComprobanteFE.Contribuyente();
                    ServicioEnviarComprobanteFE.DetalleDocumento[] detalle = new ServicioEnviarComprobanteFE.DetalleDocumento[dtd.Rows.Count];
                    ServicioEnviarComprobanteFE.DatoAdicional[] datosadicionales = new ServicioEnviarComprobanteFE.DatoAdicional[0];
                    //ServicioEnviarComprobanteFE.DocumentoRelacionado[] relacionados = new ServicioEnviarComprobanteFE.DocumentoRelacionado[0];

                    receptor.TipoDocumento = dtc.Rows[0]["TipoDocumentoIdentidadCliente"].ToString();
                    receptor.NroDocumento = dtc.Rows[0]["NumeroDocumentoIdentidadCliente"].ToString();
                    receptor.NombreLegal = dtc.Rows[0]["RazonSocialCliente"].ToString();


                    emisor.TipoDocumento = dtc.Rows[0]["TipoDocumentoEmisor"].ToString();
                    emisor.NroDocumento = dtc.Rows[0]["RUC"].ToString();
                    emisor.NombreLegal = dtc.Rows[0]["RazonSocial"].ToString();

                    TextFunctions ObjTextFunctions = new TextFunctions();
                    string TotalPagarLetras = ObjTextFunctions.enletras(dtc.Rows[0]["ImporteTotal"].ToString());

                    //ServicioEnviarComprobanteFE.DocumentoRelacionado sss = new ServicioEnviarComprobanteFE.DocumentoRelacionado();
                    //sss.NroDocumento = "";
                    //sss.TipoDocumento = "";

                    //ServicioEnviarComprobanteFE.DatoAdicional dar = new ServicioEnviarComprobanteFE.DatoAdicional();
                    //dar.Codigo = "";
                    //dar.Contenido = "";



                    int id = 0;
                    foreach (DataRow DR in dtd.Rows)
                    {
                        //ServicioEnviarComprobanteFE.DetalleDocumento dd = new ServicioEnviarComprobanteFE.DetalleDocumento();
                        ServicioEnviarComprobanteFE.DetalleDocumento dd = new ServicioEnviarComprobanteFE.DetalleDocumento();

                        dd.Cantidad = Convert.ToDecimal(DR["Cantidad"]);
                        dd.CodigoItem = DR["CodigoProducto"].ToString();
                        dd.Descripcion = DR["DescripcionProducto"].ToString();
                        dd.Descuento = Convert.ToDecimal(DR["DescuentoItem"]);
                        dd.Id = id + 1;
                        dd.Impuesto = Convert.ToDecimal(DR["MontoIgvItem"]);
                        dd.ImpuestoSelectivo = Convert.ToDecimal(DR["MontoISCItem"]);
                        dd.OtroImpuesto = 0;
                        dd.PrecioReferencial = Convert.ToDecimal(DR["ValorVentaItem"]);
                        dd.PrecioUnitario = Convert.ToDecimal(DR["PrecioVentaItem"]);
                        dd.Suma = Convert.ToDecimal(DR["Suma"]);
                        dd.TipoImpuesto = DR["AfectacionIGVItem"].ToString();
                        dd.TipoPrecio = "01";
                        dd.TotalVenta = Convert.ToDecimal(DR["TotalVenta"]);
                        dd.UnidadMedida = DR["CodigoUM"].ToString();
                        detalle[id] = dd;

                        id = id + 1;
                    }

                    //ServicioEnviarComprobanteFE.DocumentoElectronico _documento = new ServicioEnviarComprobanteFE.DocumentoElectronico()
                    ServicioEnviarComprobanteFE.DocumentoElectronico _documento = new ServicioEnviarComprobanteFE.DocumentoElectronico()
                    {
                        FechaEmision = DateTime.Today.ToShortDateString(),
                        IdDocumento = dtc.Rows[0]["NumComprobante2"].ToString(),
                        TotalIgv = Convert.ToDecimal(dtc.Rows[0]["SumatoriaIGV"]),
                        TotalIsc = Convert.ToDecimal(dtc.Rows[0]["SumatoriaISC"]),
                        TotalOtrosTributos = Convert.ToDecimal(dtc.Rows[0]["SumatoriaOtrosTributos"]),
                        Gravadas = Convert.ToDecimal(dtc.Rows[0]["OperacionesGravadas"]),
                        Exoneradas = Convert.ToDecimal(dtc.Rows[0]["ValorVentaOperacionesExoneradas"]),
                        Inafectas = Convert.ToDecimal(dtc.Rows[0]["OperacionesInafectas"]),
                        Gratuitas = Convert.ToDecimal(dtc.Rows[0]["Gratuitas"]),
                        TotalVenta = Convert.ToDecimal(dtc.Rows[0]["ImporteTotal"]),
                        DescuentoGlobal = Convert.ToDecimal(dtc.Rows[0]["DescuentosGlobales"]),
                        Moneda = dtc.Rows[0]["TipoMoneda"].ToString(),
                        CalculoIgv = Convert.ToDecimal(dtc.Rows[0]["DescuentosGlobales"]),
                        CalculoDetraccion = Convert.ToDecimal(dtc.Rows[0]["DescuentosGlobales"]),
                        CalculoIsc = Convert.ToDecimal(dtc.Rows[0]["DescuentosGlobales"]),
                        MonedaAnticipo = "",
                        TipoDocumento = dtc.Rows[0]["TipoDocumento"].ToString(),
                        TipoOperacion = dtc.Rows[0]["TipoOperacion"].ToString(),
                        TipoDocAnticipo = "",
                        MontoAnticipo = 0,
                        MontoDetraccion = 0,
                        MontoEnLetras = TotalPagarLetras,
                        MontoPercepcion = 0,
                        Emisor = emisor,
                        Receptor = receptor,
                        Items = detalle,
                        //Relacionados = relacionados,
                        DatoAdicionales = datosadicionales,
                        RutaXML = dtc.Rows[0]["RutaXMLFE"].ToString()

                    };

                    int NotaID = 0;
                    if (Tipo == "07")
                    {
                        ServicioEnviarComprobanteFE.Discrepancia[] discrepancias = new ServicioEnviarComprobanteFE.Discrepancia[1];
                        ServicioEnviarComprobanteFE.Discrepancia Discre = new ServicioEnviarComprobanteFE.Discrepancia();
                        Discre.NroReferencia = dtc.Rows[0]["NumComprobante2"].ToString();
                        Discre.Descripcion = DescripcionAnulacion;
                        Discre.Tipo = TipoNotaCredito;
                        discrepancias[0] = Discre;

                        //obtener nota credito

                        DataTable dtnota = InsertarNotaCreditoFE("07", EmpresaID, dtc.Rows[0]["NumComprobante2"].ToString().Substring(0, 4),
                            Convert.ToInt32(dtc.Rows[0]["NumComprobante2"].ToString().Substring(5, 8)), TipoComprobanteID,
                           Convert.ToDecimal(dtc.Rows[0]["ImporteTotal"]), DescripcionAnulacion, 0, Convert.ToInt32(dtc.Rows[0]["ClienteID"].ToString()), 51, "");

                        _documento.IdDocumento = dtnota.Rows[0]["NumeroComprobante"].ToString();
                        _documento.TipoDocumento = Tipo;
                        _documento.Discrepancias = discrepancias;

                        NotaID = Convert.ToInt32(dtnota.Rows[0]["NotaID"]);

                        ServicioEnviarComprobanteFE.DocumentoRelacionado[] Relacionados = new ServicioEnviarComprobanteFE.DocumentoRelacionado[1];
                        ServicioEnviarComprobanteFE.DocumentoRelacionado relacion = new ServicioEnviarComprobanteFE.DocumentoRelacionado();
                        relacion.NroDocumento = dtc.Rows[0]["NumComprobante2"].ToString();
                        relacion.TipoDocumento = dtc.Rows[0]["TipoDocumento"].ToString();
                        Relacionados[0] = relacion;
                        _documento.Relacionados = Relacionados;
                    }
                    else
                    {
                        ServicioEnviarComprobanteFE.DocumentoRelacionado[] Relacionados = new ServicioEnviarComprobanteFE.DocumentoRelacionado[0];
                        _documento.Relacionados = Relacionados;
                    }


                    ServicioEnviarComprobanteFE.DocumentoResponse respu = ServicioFE.GenerarXMLFactura(_documento);

                    if (respu.Exito == true)
                    {
                        //solo se envia factura, nota credito a sunat, boleta solo se guarda
                        if (Tipo == "01" | Tipo == "07")
                        {
                            ServicioEnviarComprobanteFE.RespuestaComunConArchivo2 RespuestaSunat = ServicioFE.EnviarSunat(Tipo,
                                dtc.Rows[0]["RutaXMLFE"].ToString(), dtc.Rows[0]["RutaCDRFE"].ToString(), dtc.Rows[0]["RutaCertificado"].ToString(), dtc.Rows[0]["ClaveCertificado"].ToString(), dtc.Rows[0]["RUC"].ToString(),
                                dtc.Rows[0]["UsuarioSOL"].ToString(), dtc.Rows[0]["ClaveSol"].ToString(), _documento.IdDocumento,
                                RUTA_WS_SUNAT, false);

                            if (Tipo == "07")
                                ActualizarNotaCredito(NotaID, Convert.ToInt64(RespuestaSunat.NroTicket), RespuestaSunat.MensajeError, (RespuestaSunat.Exito == true) ? "S" : "N", Convert.ToInt32(dtc.Rows[0]["ComprobanteId"]));

                            DataTable dtres;
                            if (Tipo == "01")
                                dtres = ActualizarComprobanteSunat(Convert.ToInt32(dtc.Rows[0]["ComprobanteId"]), (RespuestaSunat.Exito == true) ? "S" : "N");

                            if (RespuestaSunat.Exito == false)
                            {
                                throw new Exception(RespuestaSunat.MensajeError);
                            }
                            else
                            {
                                if (Tipo == "01")
                                {
                                    //GENERAR EMISIÓN FISICA
                                    if (dtc.Rows[0]["GenerarFisico"].ToString() == "S")
                                    {
                                        //string mensajeresp = ServicioFE.GenerarPdf(ds, dtc.Rows[0]["RutaXMLFE"].ToString(), dtc.Rows[0]["NumComprobante2"].ToString(), RespuestaSunat.MensajeRespuesta);
                                        //if (mensajeresp != "OK")
                                        //{
                                        //    return respu.MensajeError;
                                        //}
                                    }
                                }
                            }
                            return "OK";
                        }
                    }
                    else
                    {
                        return respu.MensajeError;
                    }

                }
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public void InsertComprobanteManual(string NumComprobante, E_Comprobante ObjComprobante, DataTable dtComprobante, int NumPedido, string Tipo, DataTable DTValesConsumo, DateTime AudCrea, DataTable DtBoucher)
        {
            string xml, xmlDetalle;
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);

            xml = new BaseFunctions().GetXML(dtComprobante).Replace("NewDataSet", "DocumentElement");
            xmlDetalle = xml.Replace("Table", "Comprobante");

            ObjCD_Comprobante.InsertComprobanteManual(NumComprobante, ObjComprobante, xmlDetalle, NumPedido, Tipo, DTValesConsumo, AudCrea, DtBoucher);
        }

        public void AnularComprobante(string NumComprobante, int TipoComprobanteID, int UsuarioID, string SedeIDE)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            ObjCD_Comprobante.AnularComprobante(NumComprobante, TipoComprobanteID, UsuarioID, SedeIDE);
        }

        public void InsertSerieGuia(string EmpresaSede, int TipoDocumento, string Serie, Int32 Numero, int UsuarioID, string NroAutorizacion, string SerieEticketera)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            ObjCD_Comprobante.InsertSerieComprobante(EmpresaSede, TipoDocumento, Serie, Numero, UsuarioID, NroAutorizacion, SerieEticketera);
        }

        public void UpdateSerieComprobante(string EmpresaSede, int TipoDocumento, string Serie, Int32 Numero, int UsuarioID, string NroAutorizacion, string SerieEticketera)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            ObjCD_Comprobante.UpdateSerieComprobante(EmpresaSede, TipoDocumento, Serie, Numero, UsuarioID, NroAutorizacion, SerieEticketera);
        }

        public void ELIMINAR_COMPROBANTES(string EmpresaID, string Serie, Int32 NumeroIni, Int32 numeroFin, int UsuarioID, int TipoComprobanteId)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            ObjCD_Comprobante.ELIMINAR_COMPROBANTES(EmpresaID, Serie, NumeroIni, numeroFin, UsuarioID, TipoComprobanteId);
        }

        public void ActualizarNotaCredito(Int32 NotaID, Int64 TicketSunat, string MensajeSunat, string EnviadoSunat, Int64 ComprobanteId)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            ObjCD_Comprobante.ActualizarNotaCredito(NotaID, TicketSunat, MensajeSunat, EnviadoSunat, ComprobanteId);
        }

        public DataTable ActualizarComprobanteSunat(int ComprobanteId, string EnviadoSunat)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            return ObjCD_Comprobante.ActualizarComprobanteSunat(ComprobanteId, EnviadoSunat);
        }

        public DataSet GetComprobanteFE(int? TipoComprobanteID, string NumComprobante, string EmpresaID, DateTime? Fecha, string Tipo)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            return objCD_Venta.GetComprobanteFE(TipoComprobanteID, NumComprobante, EmpresaID, Fecha, Tipo);
        }

        public DataTable InsertarNotaCreditoFE(string Tipo, string EmpresaID, string SerieRelacionado, Int32 NumeroRelacionado, int TipoComprobanteID,
 decimal Importe, string Concepto, decimal Descuento, int ClienteID, int UsuarioID, string SedeID)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            return ObjCD_Comprobante.InsertarNotaCreditoFE(Tipo, EmpresaID, SerieRelacionado, NumeroRelacionado, TipoComprobanteID,
    Importe, Concepto, Descuento, ClienteID, UsuarioID, SedeID);
        }

        public DataSet ListarFacturadorSunat(string EmpresaID, DateTime FechaIni, DateTime FechaFin, int TipoComprobanteId,
              string EstadoSunat, int pagenum, int pagesize, int tipo)
        {

            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            return ObjCD_Comprobante.ListarFacturadorSunat(EmpresaID, FechaIni, FechaFin, TipoComprobanteId, EstadoSunat, pagenum, pagesize, tipo);
        }

        public void ActualizarDesdeFacturadorSunat(string EmpresaID, string NumComprobante, int TipoComprobanteID, DateTime? fechaenvio,
           string mensaje, string EstadoSunat, string NroTicket)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            ObjCD_Comprobante.ActualizarDesdeFacturadorSunat(EmpresaID, NumComprobante, TipoComprobanteID, fechaenvio,
           mensaje, EstadoSunat, NroTicket);
        }

        public DataTable ObtenerDatosFacturdorSunat(string EmpresaID)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            return ObjCD_Comprobante.ObtenerDatosFacturdorSunat(EmpresaID);
        }


        public void EditarDatosFacturadorSunat(string EmpresaID, string RutaArchivosSunat, string RutaBDSunat)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            ObjCD_Comprobante.EditarDatosFacturadorSunat(EmpresaID, RutaArchivosSunat, RutaBDSunat);
        }

        public DataTable ObtenerEstadosSunat()
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            return ObjCD_Comprobante.ObtenerEstadosSunat();
        }

        public DataTable ObtenerReportesParaSunat(string EmpresaID, DateTime FechaIni, DateTime FechaFin, Int16 Tipo)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            return ObjCD_Comprobante.ObtenerReportesParaSunat(EmpresaID, FechaIni, FechaFin, Tipo);

        }
        #region sqllyte
        public DataTable ObtenerFacturadorComprobantes(string EmpresaID)
        {
            DataTable dt1 = ObtenerDatosFacturdorSunat(EmpresaID);
            string rutabd = "Data Source=" + dt1.Rows[0]["RutaBDSunat"].ToString() + ";Version=3;New=true;Compress=True;";
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(rutabd);
            return ObjCD_Comprobante.ObtenerFacturadorComprobantes();
        }

        public void EliminarFacturadorComprobantes(string nombrearchivo, string EmpresaID)
        {
            DataTable dt1 = ObtenerDatosFacturdorSunat(EmpresaID);
            string rutabd = "Data Source=" + dt1.Rows[0]["RutaBDSunat"].ToString() + ";Version=3;New=true;Compress=True;";
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(rutabd);
            ObjCD_Comprobante.EliminarFacturadorComprobantes(nombrearchivo);
        }
        #endregion



        public void InsertarPuntos(int ClienteID, int Puntos, string Concepto, int Usuario)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            ObjCD_Comprobante.InsertarPuntos( ClienteID, Puntos, Concepto, Usuario);
        }

        public DataTable ObtenerPuntosCliente(int ClienteID)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            return ObjCD_Comprobante.ObtenerPuntosCliente(ClienteID);

        }

      
        public RespuestaComunConArchivo2 EnviarXMLFE(string RutaWS, string usuario, string clave, string RucEmisor,
string TipoDocumento, string IdentificadorArchivo, bool EsResumen, string CarpetaXML, string CarpetaCdr)
        {
            ServicioEnviarComprobanteFE.FEServiceClient ServicioFE = new ServicioEnviarComprobanteFE.FEServiceClient();
            ServicioEnviarComprobanteFE.RespuestaComunConArchivo2 RespuestaSunat = ServicioFE.EnviarXML(RutaWS, usuario, clave, RucEmisor,
      TipoDocumento, IdentificadorArchivo, EsResumen, CarpetaXML, CarpetaCdr);

            RespuestaComunConArchivo2 objrespuesta = new RespuestaComunConArchivo2();
            objrespuesta.NombreArchivo = RespuestaSunat.NombreArchivo;
            objrespuesta.Exito = RespuestaSunat.Exito;
            objrespuesta.MensajeError = RespuestaSunat.MensajeError;
            objrespuesta.Pila = RespuestaSunat.Pila;
            objrespuesta.CodigoRespuesta = RespuestaSunat.CodigoRespuesta;
            objrespuesta.MensajeRespuesta = RespuestaSunat.MensajeRespuesta;
            objrespuesta.TramaZipCdr = RespuestaSunat.TramaZipCdr;
            objrespuesta.NroTicket = RespuestaSunat.NroTicket;
            return objrespuesta;
        }

        public DataTable ActualizarTicketBaja(int id, string mensaje)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            return ObjCD_Comprobante.ActualizarTicketBaja(id, mensaje);
        }

        public RespuestaComunConArchivo2 ConsultarTicketFE(string RutaWS, string usuario, string clave, string RucEmisor, string NroTicket,
         string IdentificadorArchivo, string CarpetaCdr)
        {
            ServicioEnviarComprobanteFE.FEServiceClient ServicioFE = new ServicioEnviarComprobanteFE.FEServiceClient();
            ServicioEnviarComprobanteFE.EnviarDocumentoResponse RespuestaSunat = ServicioFE.ObtenerTicket(RutaWS, usuario, clave, RucEmisor, NroTicket, IdentificadorArchivo, CarpetaCdr);

            RespuestaComunConArchivo2 objrespuesta = new RespuestaComunConArchivo2();
            objrespuesta.NombreArchivo = RespuestaSunat.NombreArchivo;
            objrespuesta.Exito = RespuestaSunat.Exito;
            objrespuesta.MensajeError = RespuestaSunat.MensajeError;
            objrespuesta.Pila = RespuestaSunat.Pila;
            objrespuesta.CodigoRespuesta = RespuestaSunat.CodigoRespuesta;
            objrespuesta.MensajeRespuesta = RespuestaSunat.MensajeRespuesta;
            objrespuesta.TramaZipCdr = RespuestaSunat.TramaZipCdr;
            return objrespuesta;
        }


        public DataSet ListarEnvioOSE(string EmpresaID, DateTime Fecha)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            return ObjCD_Comprobante.ListarEnvioOSE(EmpresaID, Fecha);
        }

        public DataTable ObtenerComprobantesResumen(int id)
        {
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(AppSettings.GetConnectionString);
            return ObjCD_Comprobante.ObtenerComprobantesResumen(id);
        }

        public DataTable ObtenerFacturadorComprobantesEliminar(string EmpresaID)
        {
            DataTable dt1 = ObtenerDatosFacturdorSunat(EmpresaID);
            string rutabd = "Data Source=" + dt1.Rows[0]["RutaBDSunat"].ToString() + ";Version=3;New=true;Compress=True;";
            CD_Comprobante ObjCD_Comprobante = new CD_Comprobante(rutabd);
            return ObjCD_Comprobante.ObtenerFacturadorComprobantesEliminar();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Halley.CapaDatos.Ventas;
using Halley.Configuracion;
using System.Data;
using Halley.Entidad.Ventas;
using Halley.Utilitario;
using System.Configuration;

namespace Halley.CapaLogica.Ventas
{
    public class CL_Venta
    {
        CL_NotaCredito ObjCL_NotaCredito = new CL_NotaCredito();
        int CantidadFilas = 0;

        public DataTable getVentaExterna(string EmpresaID, string SedeID, DateTime FecInicial, DateTime FecFinal)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Venta.getVentaExterna(EmpresaID, SedeID, FecInicial, FecFinal);
            return dtTMP;
        }

        public DataTable GetVentaDiferida(string Documento, string EmpresaID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetVentaDiferida(Documento, EmpresaID);
            return dt;
        }

        public void InsertVenta(string AlmacenID, string ProductoID, decimal Cantidad, int Movimiento, int UsuarioID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            objCD_Venta.InsertVenta(AlmacenID, ProductoID, Cantidad, Movimiento, UsuarioID);
        }

        public void InsertVentaDiferida(string ProductoID, decimal Cantidad, string Tipo, string Documento, string Cliente, string Tipo_Entidad, string NroEntidad, string EmpresaID, string NomSede, int UsuarioID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            objCD_Venta.InsertVentaDiferida(ProductoID, Cantidad, Tipo, Documento, Cliente, Tipo_Entidad, NroEntidad, EmpresaID, NomSede, UsuarioID);
        }

        public DataTable GetReservas(string ProductoID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetReservas(ProductoID);
            return dt;
        }

        public DataSet GetComprobante(string NumComprobante, int TipoComprobanteID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();
            Ds = objCD_Venta.GetComprobante(NumComprobante, TipoComprobanteID);
            return Ds;
        }

        public DataSet GetComprobante2(string NumComprobante, int TipoComprobanteID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();
            Ds = objCD_Venta.GetComprobante2(NumComprobante, TipoComprobanteID);
            return Ds;
        }

        public DataTable GetVendedores(string Sede)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetVendedores(Sede);
            return dt;
        }

        public DataTable get_ReporteDiferencial()
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.get_ReporteDiferencial();
            return dt;
        }

        public DataTable get_ReporteConVales(string ProductoID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.get_ReporteConVales(ProductoID);
            return dt;
        }

        public int GetNroTerminales(string SedeID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            int NroTerminales = 0;
            NroTerminales = objCD_Venta.GetNroTerminales(SedeID);
            return NroTerminales;
        }

        public DataTable GetReservasRepProducto(DateTime FechaInicio, DateTime FechaFin, string ProductoID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetReservasRepProducto(FechaInicio, FechaFin, ProductoID);
            return dt;
        }

        public DataTable GetCajeros()
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetCajeros();
            return dt;
        }

        public DataSet GetDetalleVentasComprobante(DateTime FechaIni, DateTime FechaFin, int Cajero, string EmpresaID, string SedeID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();

            Ds = objCD_Venta.GetDetalleVentasComprobante(FechaIni, FechaFin, Cajero, EmpresaID, SedeID);
            return Ds;
        }

        public DataTable GetVentasSede(DateTime FechaIni, DateTime FechaFin, string EmpresaSede)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetVentasSede(FechaIni, FechaFin, EmpresaSede);
            return dt;
        }

        public DataTable GetComprobantesAnulados(DateTime FechaIni, DateTime FechaFin, string EmpresaID, string SedeID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetComprobantesAnulados(FechaIni, FechaFin, EmpresaID, SedeID);
            return dt;
        }

        public DataTable GetVentasVendedor(string SedeID, string EmpresaID, DateTime FechaIni, DateTime FechaFin, string Tipo)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetVentasVendedor(SedeID, EmpresaID, FechaIni, FechaFin, Tipo);
            return dt;
        }
        public DataTable GetValesEmitidos(string EmpresaID, DateTime FechaIni, DateTime FechaFin)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetValesEmitidos(EmpresaID, FechaIni, FechaFin);
            return dt;
        }
        public DataTable GetReservasEstadoPago(DateTime FechaIni, DateTime FechaFin, string EmpresaSede, string ProductoID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetReservasEstadoPago(FechaIni, FechaFin, EmpresaSede, ProductoID);
            return dt;
        }

        public DataTable GetVentasPorProducto(DateTime FechaIni, DateTime FechaFin, string EmpresaID, string SedeID, string ProductoID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetVentasPorProducto(FechaIni, FechaFin, EmpresaID, SedeID, ProductoID);
            return dt;
        }

        public DataTable GetDetalleCrearGuias(string NumComprobante, int TipoComprobanteID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetDetalleCrearGuias(NumComprobante, TipoComprobanteID);
            return dt;
        }

        public DataTable GetServicios()
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetServicios();
            return dt;
        }

        public string FormatoTicketBoleta(string NomEmpresa, string Direccion, string Numcomprobante, string NombreComprobante,
            DataTable DTDetalles, string RUC, string Usuario, decimal Pagado, string Nomcaja, string NroSerieCaja,
            string NroAutorizacion, string TotalPagarLetras, string Nomcliente, string NroDocumento, string DireccionCliente,
            string Canasta, Boolean ConCliente, DateTime FECHA_IMPRESION, decimal MontoEntregado, decimal MontoIGV, string TipoTicket)
        {
            #region formato de etiquetera
            //calcular el apgo en letras

            //filtrar datos de la empresa para visualizar
            DataView DV_SEDEFILTRADA = new DataView(UTI_Datatables.Dt_Sedes, "SedeID = '" + AppSettings.SedeID + "'", "", DataViewRowState.CurrentRows);

            StringBuilder Stb = new StringBuilder();
            if (NomEmpresa.Length < 40)
            {
                Stb.Append(" ".PadLeft((40 - NomEmpresa.Length) / 2, ' ') + NomEmpresa + " ".PadLeft((40 - NomEmpresa.Length) / 2, ' ') + "\n");
            }
            else
                Stb.Append(NomEmpresa + "\n");
            //Stb.Append("Impreso en:\n");
            if (Direccion.Length < 40)
            {
                Stb.Append(" ".PadLeft((40 - Direccion.Length) / 2, ' ') + Direccion + " ".PadLeft((40 - Direccion.Length) / 2, ' ') + "\n");
            }
            else
                Stb.Append(CadenaFormateada(40, Direccion));
            Stb.Append(" ".PadLeft((40 - ("RUC : " + RUC).Length) / 2, ' ') + "RUC : " + RUC + " ".PadLeft((40 - ("RUC : " + RUC).Length) / 2, ' ') + "\n");
            Stb.Append("****************************************\n");
            Stb.Append("Nro Serie : " + NroSerieCaja + "        " + FECHA_IMPRESION.ToShortDateString() + "\n");
            Stb.Append("Nro Aut.  : " + NroAutorizacion + "     " + FECHA_IMPRESION.ToShortTimeString() + "\n");
            Stb.Append(DV_SEDEFILTRADA[0]["Distrito"].ToString() + "\n");
            Stb.Append(DV_SEDEFILTRADA[0]["Provincia"].ToString() + "\n");
            Stb.Append("****************************************\n");
            Stb.Append((TipoTicket == "F" ? "Ticket Factura N° " : NombreComprobante) + " " + Numcomprobante + "\n");
            if (Usuario.Length > 30)
                Stb.Append("Caja #:" + Nomcaja + " Cajero: " + Usuario.Substring(0, 30) + "\n");
            else
                Stb.Append("Caja #:" + Nomcaja + " Cajero: " + Usuario + "\n");
            //region delos datos del cliente
            if (ConCliente == true)
            {
                Stb.Append("****************************************\n");
                if (TipoTicket == "F")
                    Stb.Append("N° RUC: ");
                else
                    Stb.Append("N° Documento: ");

                Stb.Append(NroDocumento + "\n");
                Stb.Append((TipoTicket == "F" ? "Razón Social:\n" : "Cliente:\n"));
                Stb.Append(CadenaFormateada(40, Nomcliente));
                Stb.Append("Dirección:\n");
                Stb.Append(CadenaFormateada(40, DireccionCliente));
            }
            Stb.Append("****************************************\n");
            //detalles del comprobante
            Stb.Append("Cant.    Producto          P.vta   Impt\n");
            Stb.Append("****************************************\n");
            foreach (DataRow DR in DTDetalles.Rows)
            {
                Stb.Append(DetallePagoComprobante(Convert.ToDecimal(DR["Cantidad"]), DR["UnidadMedidaID"].ToString(), 40, DR["Alias"].ToString(), Convert.ToDecimal(DR["PrecioUnitario"]), Convert.ToDecimal(DR["Importe"])));
            }

            Stb.Append("****************************************\n");
            if (TipoTicket == "F")
                Stb.Append("IGV: ".PadRight(32, ' ') + MontoIGV.ToString("N2").PadLeft(8, ' ') + "\n");

            if (Canasta != "")
            {
                Stb.Append("Canasta: " + Canasta + "\n");
            }
            Stb.Append("Importe: " + Pagado.ToString("C").PadLeft(40 - 9, ' ') + "\n");
            TotalPagarLetras += " SOLES.";
            if (TotalPagarLetras.Length > 40)
            {
                Stb.Append(TotalPagarLetras.Substring(0, 40) + "\n");
                if (TotalPagarLetras.Substring(35).Length > 40)
                    Stb.Append(TotalPagarLetras.Substring(40, 40) + "\n\n");
                else
                    Stb.Append(TotalPagarLetras.Substring(40) + "\n\n");
            }
            else
                Stb.Append(TotalPagarLetras + "\n");

            Stb.Append("Monto entregado: " + MontoEntregado.ToString("C").PadLeft(40 - 17, ' ') + "\n");
            Stb.Append("Vuelto: " + (MontoEntregado - Pagado).ToString("C").PadLeft(32, ' ') + "\n");
            //Stb.Append(Convert.ToChar(27) + "i");//corte de la impresora



            //Stb.Append("Nro de Items: " + DTDetalles.Rows.Count.ToString() + "  *\n");
            //Stb.Append("*puede incluir servicio de flete y/o descuento.\n");


            //Stb.Append("***Por favor conserve su comprobante***");

            return Stb.ToString();
            #endregion

            //#region formato de etiquetera
            ////calcular el apgo en letras

            ////filtrar datos de la empresa para visualizar
            //DataView DV_SEDEFILTRADA = new DataView(UTI_Datatables.Dt_Sedes, "SedeID = '" + AppSettings.SedeID + "'", "", DataViewRowState.CurrentRows);

            //StringBuilder Stb = new StringBuilder();
            //if (NomEmpresa.Length < 40)
            //{
            //    Stb.Append(" ".PadLeft((40 - NomEmpresa.Length) / 2, ' ') + NomEmpresa + " ".PadLeft((40 - NomEmpresa.Length) / 2, ' ') + "\n");
            //}
            //else
            //    Stb.Append(NomEmpresa + "\n");
            ////Stb.Append("Impreso en:\n");
            //if (Direccion.Length < 40)
            //{
            //    Stb.Append(" ".PadLeft((40 - Direccion.Length) / 2, ' ') + Direccion + " ".PadLeft((40 - Direccion.Length) / 2, ' ') + "\n");
            //}
            //else
            //    Stb.Append(CadenaFormateada(40, Direccion)) ;
            //Stb.Append(" ".PadLeft((40 - ("RUC : " + RUC).Length) / 2, ' ') + "RUC : " + RUC + " ".PadLeft((40 - ("RUC : " + RUC).Length) / 2, ' ') + "\n");
            //Stb.Append("Nro Serie : " + NroSerieCaja + "   " + FECHA_IMPRESION.ToShortDateString() + "\n");
            //Stb.Append("Nro Aut. : " + NroAutorizacion + "   " + FECHA_IMPRESION.ToShortTimeString() + "\n");
            //Stb.Append(DV_SEDEFILTRADA[0]["Distrito"].ToString() + "\n");
            //Stb.Append(DV_SEDEFILTRADA[0]["Provincia"].ToString() + "\n");
            //Stb.Append("****************************************\n");
            //Stb.Append(NombreComprobante + " " + Numcomprobante + "\n");
            //if (Usuario.Length > 30)
            //   Stb.Append("Caja #:" + Nomcaja + " Cajero: " +  Usuario.Substring(0, 30) + "\n");
            //else
            //    Stb.Append("Caja #:" + Nomcaja + " Cajero: " + Usuario + "\n");
            ////region delos datos del cliente
            //if (ConCliente ==true)
            //{
            //    Stb.Append("****************************************\n");
            //    Stb.Append("Cliente:\n");
            //    Stb.Append(CadenaFormateada(40,Nomcliente));
            //    Stb.Append("Nro Documento: ");
            //    Stb.Append(NroDocumento + "\n");
            //    Stb.Append("Dirección:\n");
            //    Stb.Append(CadenaFormateada(40, DireccionCliente));
            //}
            //Stb.Append("****************************************\n");
            ////detalles del comprobante
            //Stb.Append("Cant.    Producto          P.vta   Impt\n");
            //Stb.Append("****************************************\n");
            //foreach (DataRow DR in DTDetalles.Rows)
            //{
            //    Stb.Append(DetallePagoComprobante(Convert.ToDecimal(DR["Cantidad"]), DR["UnidadMedidaID"].ToString(),DR["Alias"].ToString(), Convert.ToDecimal(DR["PrecioUnitario"]), Convert.ToDecimal(DR["Importe"])));
            //}
            //Stb.Append("****************************************\n");
            //if (Canasta != "")
            //{
            //    Stb.Append("Canasta: " + Canasta + "\n");
            //}
            //Stb.Append("Importe: " + Pagado.ToString("C") + "\n");
            //TotalPagarLetras += " NUEVOS SOLES.";
            //if (TotalPagarLetras.Length > 40)
            //{
            //    Stb.Append(TotalPagarLetras.Substring(0, 40) + "\n");
            //    if (TotalPagarLetras.Substring(35).Length > 40)
            //        Stb.Append(TotalPagarLetras.Substring(40, 40) + "\n\n");
            //    else
            //        Stb.Append(TotalPagarLetras.Substring(40) + "\n\n");
            //}
            //else
            //    Stb.Append(TotalPagarLetras);


            ////Stb.Append(Convert.ToChar(27) + "i");//corte de la impresora



            ////Stb.Append("Nro de Items: " + DTDetalles.Rows.Count.ToString() + "  *\n");
            ////Stb.Append("*puede incluir servicio de flete y/o descuento.\n");


            ////Stb.Append("***Por favor conserve su comprobante***");

            //return Stb.ToString();
            //#endregion
        }




        public string DetallePagoComprobante(decimal Cantidad, string UM, int Ancho, string Texto, decimal PrecionUnitario, decimal Importe)
        {
            string acumulado = UM + " ";
            string acumuladoRespuesta = "";

            for (int i = 0; i <= (Texto.Length - 1); i++)
            {
                acumulado += Texto.Substring(i, 1);

                if (acumulado.Length == 40)
                {
                    CantidadFilas = CantidadFilas + 1;
                    acumuladoRespuesta += acumulado + "\n";
                    acumulado = "";
                }
            }

            if (acumulado.Length > 0)
            {
                CantidadFilas = CantidadFilas + 1;
                acumuladoRespuesta += acumulado + "\n";
            }

            CantidadFilas = CantidadFilas + 1;
            acumuladoRespuesta += Cantidad.ToString("N2").PadLeft(6, ' ') + " ".PadLeft(Ancho - 27, ' ') + PrecionUnitario.ToString("N2").PadLeft(10, ' ') + " " + Importe.ToString("N2").PadLeft(10, ' ') + "\n";
            return acumuladoRespuesta;

        }

        //public string CadenaFormateada2(int Ancho, string Texto, string TextoPrecioSubtotal)
        //{
        //    bool AgregoSubtotal = false;

        //    string acumulado = "";
        //    string acumuladoRespuesta = "";

        //    for (int i = 0; i <= (Texto.Length - 1); i++)
        //    {
        //        acumulado += Texto.Substring(i, 1);
        //        if (acumulado.Length == Ancho & AgregoSubtotal == false)
        //        {
        //            CantidadFilas = CantidadFilas + 1;
        //            acumuladoRespuesta += acumulado.PadRight(Ancho - 1, ' ') + TextoPrecioSubtotal + "\n";
        //            acumulado = "";
        //            AgregoSubtotal = true;
        //        }
        //        else if (acumulado.Length == 40)
        //        {
        //            CantidadFilas = CantidadFilas + 1;
        //            acumuladoRespuesta += acumulado + "\n";
        //            acumulado = "";
        //        }

        //    }

        //    if (acumulado.Length > 0)
        //    {
        //        CantidadFilas = CantidadFilas + 1;
        //        acumuladoRespuesta += acumulado + "\n";
        //        acumulado = "";
        //    }
        //    return acumuladoRespuesta;

        //}

        //public string CadenaFormateada2(int Ancho, string Texto, string TextoPrecioSubtotal)
        //{
        //    bool AgregoSubtotal = false;
        //    if (Texto.Length <= Ancho)
        //    {
        //        CantidadFilas = CantidadFilas + 1;
        //        //return Texto + "          " + "\n";
        //        return Texto.TrimEnd().PadRight(Ancho - 1, ' ') + " " + TextoPrecioSubtotal + "\n";
        //    }
        //    //buscamos caracter en texto
        //    string Linea = "", nuevoTexto = Texto;
        //    string acumulado = "";
        //    while (nuevoTexto.Length > 0)
        //    {
        //        Linea = nuevoTexto.Substring(0, Ancho);
        //        if (Linea.Length < Ancho)
        //        {
        //            CantidadFilas = CantidadFilas + 1;
        //            // acumulado += "          " + Linea.TrimEnd().PadRight(Ancho, ' ') + " " + TextoPrecioSubtotal;
        //            acumulado += Linea.TrimEnd().PadRight(Ancho - 1, ' ') + " " + TextoPrecioSubtotal;
        //            return acumulado + "\n";
        //        }

        //        //buscamos el ultimo espacio
        //        int pos1 = 0;
        //        pos1 = Linea.LastIndexOf(" ");
        //        if (pos1 == -1)
        //            pos1 = Linea.Length;

        //        Linea = Linea.Substring(0, pos1);

        //        //acumularlo
        //        if (AgregoSubtotal == false)
        //        {
        //            CantidadFilas = CantidadFilas + 1;
        //            //           acumulado += "          " + Linea.TrimEnd().PadRight(Ancho, ' ') + " " + TextoPrecioSubtotal + "\n";
        //            acumulado += Linea.TrimEnd().PadRight(Ancho - 1, ' ') + " " + TextoPrecioSubtotal + "\n";
        //            AgregoSubtotal = true;
        //        }
        //        else
        //        {
        //            CantidadFilas = CantidadFilas + 1;
        //            acumulado += Linea.TrimEnd() + "\n";
        //        }
        //        //obtner nueva cadena nueva
        //        nuevoTexto = nuevoTexto.Substring(pos1).TrimStart();

        //        if (nuevoTexto.Length < Ancho)
        //        {
        //            CantidadFilas = CantidadFilas + 1;
        //            acumulado += "          " + nuevoTexto.TrimEnd();
        //            return acumulado + "\n";
        //        }
        //    }
        //    return acumulado + "\n";
        //}

        public string CadenaFormateada(int Ancho, string Texto)
        {
            if (Texto.Length < Ancho)
                return Texto.TrimEnd() + "\n";

            //buscamos caracter en texto
            string Linea = "", nuevoTexto = Texto;
            string acumulado = "";
            while (nuevoTexto.Length > 0)
            {
                Linea = nuevoTexto.Substring(0, Ancho);
                if (Linea.Length < Ancho)
                {
                    acumulado += Linea.Trim();
                    return acumulado + "\n";
                }

                //buscamos el ultimo espacio
                int pos1 = 0;
                pos1 = Linea.LastIndexOf(" ");
                Linea = Linea.Substring(0, pos1).Trim();

                //acumularlo
                acumulado += Linea + "\n";

                //obtner nueva cadena nueva
                nuevoTexto = nuevoTexto.Substring(pos1).Trim();

                if (nuevoTexto.Length < Ancho)
                {
                    acumulado += nuevoTexto.Trim();
                    return acumulado + "\n";
                }
            }
            return acumulado + "\n";
        }

        public DataTable GetTiposVenta()
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetTiposVenta();
            return dt;
        }

        public DataTable GetTotalTicketPorCaja(int NumCaja, DateTime FechaIni, DateTime FechaFin, string EmpresaID, string SedeID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetTotalTicketPorCaja(NumCaja, FechaIni, FechaFin, EmpresaID, SedeID);
            return dt;
        }

        public DataTable GetVentasNavidenhasPorFecha(DateTime FecIni, DateTime FecFin)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetVentasNavidenhasPorFecha(FecIni, FecFin);
            return dt;
        }

        public DataTable GetTicketsAnulados(DateTime FecIni, DateTime FecFin, string EmpresaID, string SedeID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetTicketsAnulados(FecIni, FecFin, EmpresaID, SedeID);
            return dt;
        }

        public DataTable GetAnulados(DateTime FecIni, DateTime FecFin, string EmpresaID, string SedeID, int UsuarioID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetAnulados(FecIni, FecFin, EmpresaID, SedeID, UsuarioID);
            return dt;
        }
        public DataTable GetDatosTicketera(string EmpresaSede)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetDatosTicketera(EmpresaSede);
            return dt;
        }

        public string FormatoTotalesTicket(string NomEmpresa, string Direccion, string RUC, DateTime FecIni, DateTime FecFin, int NumCaja, string EmpresaID, string SedeID, int UserID)
        {
            decimal TotalVentasDia = 0;
            decimal TotalEticketera = 0;
            string NumInicio = "";
            string NumFinal = "";
            string SerieEticketera;
            string NroAutorizacion;

            DataTable DtDatosTicketera = new DataTable();
            DtDatosTicketera = GetDatosTicketera(EmpresaID + SedeID);
            SerieEticketera = DtDatosTicketera.Rows[0]["SerieEticketera"].ToString();
            NroAutorizacion = DtDatosTicketera.Rows[0]["NroAutorizacion"].ToString();

            StringBuilder Stb = new StringBuilder();
            Stb.Append("       " + NomEmpresa.ToUpper() + "\n");
            Stb.Append("Impreso en:\n");
            if (Direccion.Length > 40)
            {
                Stb.Append(Direccion.Substring(0, 40) + "\n");
                if (Direccion.Substring(35).Length > 40)
                    Stb.Append(Direccion.Substring(40, 40) + "\n");
                else
                    Stb.Append(Direccion.Substring(40) + "\n");
            }
            else
                Stb.Append(Direccion + "\n");
            Stb.Append("RUC       : " + RUC + "\n");
            Stb.Append("Nro Serie : " + SerieEticketera + "\n");
            Stb.Append("Nro Aut.  : " + NroAutorizacion + "\n");
            Stb.Append("Fec Emi.  : " + DateTime.Now.ToString() + "\n\n");


            //obtener los tickets anulados para generar nota de credito
            DataTable DtAnulados = new DataTable();
            DtAnulados = GetTicketsAnulados(FecIni, FecFin, EmpresaID, SedeID);
            //si existen anulados se generara nota de credito
            if (DtAnulados.Rows.Count > 0)
            {
                decimal TotalAnulado = 0;

                //armar el concepto
                string Concepto = "Anulados:\n";
                foreach (DataRow DR in DtAnulados.Rows)
                {
                    Concepto += DR["NumComprobante"].ToString() + ", \n";
                }

                TotalAnulado = Convert.ToDecimal(DtAnulados.Compute("sum(Sumtotal)", ""));

                E_NotaCredito ObjE_NotaCredito = new E_NotaCredito();
                ObjE_NotaCredito.ClienteID = 0;
                ObjE_NotaCredito.NumCaja = NumCaja;
                ObjE_NotaCredito.NumComprobante = "";
                ObjE_NotaCredito.TipoComprobanteID = 0;
                ObjE_NotaCredito.Importe = TotalAnulado;
                ObjE_NotaCredito.descuento = 0;
                ObjE_NotaCredito.Concepto = Concepto;
                ObjE_NotaCredito.UsuarioID = UserID;
                ObjE_NotaCredito.SedeID = SedeID;

                string NotaCreditoID = ObjCL_NotaCredito.InsertNotaCreditoI(ObjE_NotaCredito, EmpresaID + SedeID);
                Stb.Append("********************************\n");
                Stb.Append("\n*********** NOTA DE CREDITO ***********\n");
                Stb.Append("Nro: " + NotaCreditoID.Substring(2) + "\n\n");
                Stb.Append("Tickets anulados:\n\n");
                foreach (DataRow DR in DtAnulados.Rows)
                {
                    Stb.Append("    * " + DR["NumComprobante"].ToString() + " " + Convert.ToDecimal(DR["Sumtotal"]).ToString("N2").PadLeft(10, ' ') + "\n");
                }

                Stb.Append("\nTotal monto por anulados: " + TotalAnulado.ToString("N2") + "\n");
                Stb.Append("********************************\n\n");
            }

            //obtener el total y el rango de comprobantes
            DataTable DtTotalesTicket = new DataTable();
            DtTotalesTicket = GetTotalTicketPorCaja(NumCaja, FecIni, FecFin, EmpresaID, SedeID);

            TotalVentasDia = Convert.ToDecimal(DtTotalesTicket.Rows[0]["TotalVentasDia"]);
            TotalEticketera = Convert.ToDecimal(DtTotalesTicket.Rows[0]["TotalEticketera"]);
            NumInicio = DtTotalesTicket.Rows[0]["NumInicio"].ToString();
            NumFinal = DtTotalesTicket.Rows[0]["NumFinal"].ToString();


            Stb.Append("****************  TOTALES ****************\n\n");
            Stb.Append("Venta total por concepto de los\n");
            Stb.Append("tickets:  " + NumInicio + " - " + NumFinal + ".\n\n");
            Stb.Append("Ventas día   : S/. " + TotalVentasDia.ToString("N2").PadLeft(13, ' ') + "\n\n");
            Stb.Append("Ventas Total : S/. " + TotalEticketera.ToString("N2").PadLeft(13, ' ') + "\n");

            return Stb.ToString();
        }

        public DataTable GetAdministradores()
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetAdministradores();
            return dt;
        }

        public DataTable GetAuditoriaPrecio(string EmpresaSede, DateTime FechaInicio, DateTime FechaFin, int UsuarioID, string ProductoID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetAuditoriaPrecio(EmpresaSede, FechaInicio, FechaFin, UsuarioID, ProductoID);
            return dt;
        }

        public DataTable GetDespachos(string SedeID, int TipoVentaID, int Minutos)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetDespachos(SedeID, TipoVentaID, Minutos);
            return dt;
        }

        public string FormatoTickeCuadreCaja(string NomEmpresa, string NomSede, string Usuario,
    decimal totb, decimal totf, decimal tott, decimal toti, decimal tote,
            DateTime FechaIni, DateTime FechaFin, int CajeroID, string EmpresaID,
            string SedeID, DataTable DtCuadreCaja, decimal DineroEntregado, decimal Entrega12)
        {
            #region formato de etiquetera
            StringBuilder Stb = new StringBuilder();
            Stb.Append(NomEmpresa + "\r\n");
            Stb.Append("Impreso en:\r\n");
            if (AppSettings.NomSede.Length > 35)
                Stb.Append(NomSede.Substring(0, 35) + "\r\n");
            else
                Stb.Append(NomSede + "\r\n");
            Stb.Append(DateTime.Now.ToString() + "\r\n");
            Stb.Append("********************************\r\n");
            Stb.Append("***Cajero: ");
            if (Usuario.Length > 28)
                Stb.Append(Usuario.Substring(0, 28) + "\r\n");
            else
                Stb.Append(Usuario + "\r\n");
            //imprimir los numeros de boletas y/o facturas

            //imprimir anulados
            //obtener los tickets anulados para generar nota de credito
            DataView DvAnulados = new DataView(DtCuadreCaja, "FlgEst = 'False'", "NumComprobante ASC", DataViewRowState.OriginalRows);
            //si existen anulados se generara nota de credito
            if (DvAnulados.Count > 0)
            {
                Stb.Append("********************************\r\n");
                Stb.Append("***COMPROBANTES ANULADOS\r\n");
                Stb.Append("********************************\r\n");
                foreach (DataRowView DR in DvAnulados)
                {
                    Stb.Append(DR["NumComprobante"].ToString() + " " + DR["NomTipoComprobante"].ToString() + "\r\n");
                }
            }

            //obtener el total y el rango de comprobantes
            DataTable DtTotalesTicket = new DataTable();
            DtTotalesTicket.Columns.Add("Inicial", typeof(string));
            DtTotalesTicket.Columns.Add("Final", typeof(string));
            DtTotalesTicket.Columns.Add("TipoID", typeof(int));
            DtTotalesTicket.Columns.Add("Tipo", typeof(string));

            //traer los comprobantes para iniciar el bucle
            DataTable DtComprobantes = new CL_Comprobante().getTipoComprobante();
            foreach (DataRow DR in DtComprobantes.Rows)
            {
                string Inicial, Final, Tipo;
                int TipoID;
                DataView Dv = new DataView(DtCuadreCaja, "NomTipoComprobante='" + DR["NomTipoComprobante"].ToString() + "'", "NumComprobante ASC", DataViewRowState.OriginalRows);
                if (Dv.Count > 0)
                {
                    Inicial = Dv[0]["NumComprobante"].ToString();
                    Dv.Sort = "NumComprobante DESC";
                    Final = Dv[0]["NumComprobante"].ToString();
                    TipoID = Convert.ToInt16(DR["TipoComprobanteID"]);
                    Tipo = DR["NomTipoComprobante"].ToString();

                    DataRow Drt = DtTotalesTicket.NewRow();
                    Drt["Inicial"] = Inicial;
                    Drt["Final"] = Final;
                    Drt["TipoID"] = TipoID;
                    Drt["Tipo"] = Tipo;
                    DtTotalesTicket.Rows.Add(Drt);
                }

            }

            if (DtTotalesTicket.Rows.Count > 0)
            {
                Stb.Append("********************************\r\n");
                Stb.Append("***RANGO DE COMPROBANTES\r\n");
                Stb.Append("********************************\r\n");
                foreach (DataRow DR in DtTotalesTicket.Rows)
                {
                    Stb.Append("*Tipo: " + DR["Tipo"].ToString() + "\r\n");
                    Stb.Append("-Inicio: " + DR["Inicial"].ToString() + "\r\n");
                    Stb.Append("-Final:  " + DR["Final"].ToString() + "\r\n\r\n");

                }
            }

            //imprimir totales
            decimal Total = 0, Diferencia = 0;
            Total = tott + totb + totf + toti - tote - Entrega12;
            Diferencia = DineroEntregado - Total;

            Stb.Append("********************************\r\n");
            Stb.Append("***INGRESOS\r\n");
            Stb.Append("********************************\r\n");
            Stb.Append("Ingreso      :" + toti.ToString("C").PadLeft(13, ' ') + "\r\n");
            Stb.Append("Total boleta :" + totb.ToString("C").PadLeft(13, ' ') + "\r\n");
            Stb.Append("Total factura:" + totf.ToString("C").PadLeft(13, ' ') + "\r\n");
            Stb.Append("Total Ticket :" + tott.ToString("C").PadLeft(13, ' ') + "\r\n");
            Stb.Append("********************************\r\n");
            Stb.Append("***EGRESOS\r\n");
            Stb.Append("********************************\r\n");
            Stb.Append("Egreso       :" + tote.ToString("C").PadLeft(13, ' ') + "\r\n");
            Stb.Append("Entrega 12 pm:" + Entrega12.ToString("C").PadLeft(13, ' ') + "\r\n");
            Stb.Append("Total Egreso :" + (Entrega12 + tote).ToString("C").PadLeft(13, ' ') + "\r\n");
            Stb.Append("********************************\r\n");
            Stb.Append("***RESUMEN\r\n");
            Stb.Append("********************************\r\n");
            Stb.Append("Deberia haber:" + Total.ToString("C").PadLeft(13, ' ') + "\r\n");
            Stb.Append("Hay          :" + DineroEntregado.ToString("C").PadLeft(13, ' ') + "\r\n");
            if (Diferencia > 0)
                Stb.Append("Sobra        :" + Diferencia.ToString("C").PadLeft(13, ' ') + "\r\n");
            else if (Diferencia < 0)
                Stb.Append("Falta        :" + Diferencia.ToString("C").PadLeft(13, ' ') + "\r\n");
            else if (Diferencia == 0)
                Stb.Append("Sobra        :" + Diferencia.ToString("C").PadLeft(13, ' ') + "\r\n");
            Stb.Append("********************************\r\n");

            return Stb.ToString();
            #endregion
        }

        public DataTable GetPrecioVariado()
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetPrecioVariado();
            return dt;
        }
        public DataTable GetProductosImpuestoBolsa()
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetProductosImpuestoBolsa();
            return dt;
        }

        public bool ExisteVale(string Numval)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            bool Valor = true;
            Valor = objCD_Venta.ExisteVale(Numval);
            return Valor;
        }

        public void InsertCierre(int Cajero, string EmpresaSede, DateTime Fecha, decimal DineroEntregado, decimal Ingreso, decimal Egreso, decimal TotalPagos, decimal TotalEntregar, int UsuarioID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            objCD_Venta.InsertCierre(Cajero, EmpresaSede, Fecha, DineroEntregado, Ingreso, Egreso, TotalPagos, TotalEntregar, UsuarioID);
        }

        public DataTable GetCierre(int Cajero, string EmpresaSede, DateTime Fecha)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetCierre(Cajero, EmpresaSede, Fecha);
            return dt;
        }

        //Imprimir la venta
        public DataTable GenerarComprobante(DataTable DtDetalleComprobante, string EmpresaID, string SedeID, int ClienteID, int TipoComprobanteID,
            string Direccion, int TipoVentaID, int TipoPagoId, int FormaPago, int NumCaja, decimal IGV, decimal Subtotal, decimal TotalIGV,
           decimal TotalPagar, int CreditoSeleccionado, int CreditoID, decimal CreditoDisponible, int VendedorID, int UserID, string SerieComprobante, string TipoTicket,
            DataTable DtValesConsumo, DataTable DtBoucher, DataTable DtNotaIngreso, decimal TotalICBPER, decimal Descuento, decimal MontoTotal)
        {
            DataTable DT = new DataTable();

            //Validar que no sea "Clientes varios en la factura"
            if (TotalPagar >= 700 & (ClienteID == 1 | ClienteID == 204 | ClienteID == 241 | ClienteID == 3032))
            {
                throw new Exception("si la venta pasa de S/.700 debe exigir datos que identifiquen al cliente");
            }
            else if (TipoComprobanteID.ToString() == "2" & (ClienteID == 1 | ClienteID == 204 | ClienteID == 241 | ClienteID == 3032))
            {
                throw new Exception("Si es factura debe exigir datos que identifiquen al cliente");
            }

            #region crear tabla y agregar el detalle de la compra
            DataTable DtDetalleComprobanteInsert = new DataTable("detallePedido");
            DtDetalleComprobanteInsert.Columns.Add("ProductoID", typeof(string));
            DtDetalleComprobanteInsert.Columns.Add("Cantidad", typeof(decimal));
            DtDetalleComprobanteInsert.Columns.Add("PrecioUnitario", typeof(decimal));
            DtDetalleComprobanteInsert.Columns.Add("Importe", typeof(decimal));
            DtDetalleComprobanteInsert.Columns.Add("FechaReserva", typeof(DateTime));
            DtDetalleComprobanteInsert.Columns.Add("EstadoID", typeof(int));
            DtDetalleComprobanteInsert.Columns.Add("AlmacenID", typeof(string));
            DtDetalleComprobanteInsert.Columns.Add("PesoNeto", typeof(decimal));
            DtDetalleComprobanteInsert.Columns.Add("HistoricoPrecioID", typeof(int));

            //insetar los detalles en la tabla creada
            foreach (DataRow Dr in DtDetalleComprobante.Rows)
            {
                DataRow DR = DtDetalleComprobanteInsert.NewRow();
                DR["ProductoID"] = Dr["ProductoID"];
                DR["Cantidad"] = Dr["Cantidad"];
                DR["PrecioUnitario"] = Dr["PrecioUnitario"];
                DR["Importe"] = Dr["Importe"];
                DR["FechaReserva"] = Dr["FechaReserva"];
                DR["EstadoID"] = Dr["EstadoID"];
                DR["AlmacenID"] = Dr["AlmacenID"];
                DR["PesoNeto"] = Dr["PesoNeto"];
                DR["HistoricoPrecioID"] = Dr["HistoricoPrecioID"];
                DtDetalleComprobanteInsert.Rows.Add(DR);
            }
            #endregion

            /*//validar que el vendedor es el cajero en terminal = 3
                        if(NroTerminales ==3)
                            VendedorID = AppSettings.UserID;*/

            //declarar para el estado
            int estadoID = 0;

            #region guardar el comprobante
            if (DtDetalleComprobanteInsert.Rows.Count > 0)
            {
                E_Comprobante ObjComprobante = new E_Comprobante();
                ObjComprobante.EmpresaID = EmpresaID;
                ObjComprobante.SedeID = SedeID;
                ObjComprobante.TipoComprobanteID = TipoComprobanteID;
                ObjComprobante.ClienteID = ClienteID;
                ObjComprobante.Direccion = Direccion;
                ObjComprobante.TipoVentaID = TipoVentaID;
                ObjComprobante.TipoPagoId = TipoPagoId;
                ObjComprobante.FormaPagoID = FormaPago;
                ObjComprobante.NumCaja = NumCaja;
                ObjComprobante.IGV = IGV;
                ObjComprobante.SubTotal = Subtotal;
                ObjComprobante.TotIgv = TotalIGV;
                ObjComprobante.TipoTicket = TipoTicket;
                if (TipoPagoId.ToString() == "1")//es credito
                {
                    if (CreditoSeleccionado != -1)
                    {
                        ObjComprobante.CreditoID = CreditoID;
                        estadoID = 14;//comprobante pendiente de pago

                        //validar que el credito disponible sea mayor o igual al monto de la compra
                        if (CreditoDisponible < (Subtotal + TotalIGV))
                        {
                            throw new Exception("El total del comprobante no debe ser mayor al crédito disponible.");
                        }
                    }
                    else
                    {
                        throw new Exception("Para la opción 'Venta Credito' el cliente debe tener un crédito y este crédito debe estar seleccionado en la lista 'Crédito'");
                    }
                }
                else if (TipoPagoId.ToString() == "2")//es contado
                {
                    estadoID = 12;//comprobante pagado
                }


                ObjComprobante.Vendedor = VendedorID;
                ObjComprobante.Cajero = UserID;
                ObjComprobante.Serie = SerieComprobante;
                ObjComprobante.EstadoID = estadoID;
                ObjComprobante.MontoPagado = TotalPagar;
                ObjComprobante.TotalICBPER = TotalICBPER;
                ObjComprobante.MontoTotal = MontoTotal;
                ObjComprobante.Descuento = Descuento;

                DT = new CL_Comprobante().InsertComprobante(ObjComprobante, DtDetalleComprobanteInsert, 0, "D", DtValesConsumo, DtBoucher, DtNotaIngreso);

                //DataSet dt4 = new CL_Comprobante().GenerarTxtFacturadorSunat(Convert.ToInt64(DT.Rows[0]["id"]));
            }
            #endregion

            return DT;
        }
        public string GetVerCorrelativo(string EmpresaSede, string NombreEmpresa, string NomSede)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Venta.GetVerCorrelativo(EmpresaSede);

            StringBuilder str = new StringBuilder();
            //recorrer la tabla y crear la cadena
            str.Append(NombreEmpresa + " - " + NomSede + "\n\n");
            foreach (DataRow DR in dtTMP.Rows)
            {
                str.Append(DR["TipoComprobanteID"].ToString() + "\t" + DR["NomTipoComprobante"].ToString() + " \t\tSerie: " + DR["Serie"] + " \tNumero: \t" + DR["Numero"].ToString() + "\n");
            }
            return str.ToString();
        }

        public DataTable ValorVale(Int32 NUMVALE)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.ValorVale(NUMVALE);
            return dt;
        }

        public DataTable VerificarCierre(Int32 Caja)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.VerificarCierre(Caja);
            return dt;
        }

        public DataTable GetVentasCliente(int Accion, DateTime FechaIni, DateTime FechaFin, int ClienteID, string EmpresaID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Venta.GetVentasCliente(Accion, FechaIni, FechaFin, ClienteID, EmpresaID);
            return dt;
        }


        public Boolean ValidarDocumento(int IDTipoDocumento, int TipoComprobanteID, int ClienteID, string TipoTicket)
        {
            Boolean Validado = false;
            if (TipoComprobanteID == 2 & IDTipoDocumento == 1) //es factura y es RUC
            {
                Validado = true;
                return Validado;
            }
            if (TipoComprobanteID == 5 & IDTipoDocumento == 1) //es factura electronica y es RUC
            {
                Validado = true;
                return Validado;
            }
            if (TipoComprobanteID == 1 & IDTipoDocumento == 2) //es boleta y es DNI 
            {
                Validado = true;
                return Validado;
            }
            if (TipoComprobanteID == 4 & IDTipoDocumento == 2) //es boleta electronica y es DNI 
            {
                Validado = true;
                return Validado;
            }
            if (TipoComprobanteID == 1 & ClienteID == 204) //es boleta y clientes varios
            {
                Validado = true;
                return Validado;
            }
            if (TipoComprobanteID == 4 & ClienteID == 204) //es boleta electronica y clientes varios
            {
                Validado = true;
                return Validado;
            }
            if (TipoComprobanteID == 3 & TipoTicket == "B") //es ticket boleta
            {
                Validado = true;
                return Validado;
            }
            if (TipoComprobanteID == 3 & TipoTicket == "F" & IDTipoDocumento == 1 & ClienteID != 1 & ClienteID != 204 & ClienteID != 241 & ClienteID != 3032) //es ticket factura con RUC
            {
                Validado = true;
                return Validado;
            }
            return Validado;
        }

        public DataSet GetDetalleVentasComprobante2(DateTime FechaIni, DateTime FechaFin, int Cajero, string EmpresaID, string SedeID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();

            Ds = objCD_Venta.GetDetalleVentasComprobante2(FechaIni, FechaFin, Cajero, EmpresaID, SedeID);
            return Ds;
        }

        public Boolean HABILITADOFE()
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            return objCD_Venta.HABILITADOFE();
        }

        public Boolean HABILITADOFE2(string EmpresaID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            return objCD_Venta.HABILITADOFE2(EmpresaID);
        }

        public string[] FormatoTicketFE(string NomEmpresa, string Direccion, string Numcomprobante, string NombreComprobante,
        DataTable DTDetalles, string RUC, string Usuario, decimal Pagado, string Nomcaja, string NroSerieCaja,
        string NroAutorizacion, string TotalPagarLetras, string Nomcliente, string NroDocumento, string DireccionCliente,
        string Canasta, Boolean ConCliente, DateTime FECHA_IMPRESION, decimal MontoEntregado, decimal MontoIGV, string TipoFE,
            string TelefonoCelular, string TelefonoFijo,decimal totalcomprobante, decimal TotalICBPER)
        {
            #region formato de etiquetera
            //calcular el apgo en letras
            string[] StrResultado = new string[2];

            //filtrar datos de la empresa para visualizar
            DataView DV_SEDEFILTRADA = new DataView(UTI_Datatables.Dt_Sedes, "SedeID = '" + AppSettings.SedeID + "'", "", DataViewRowState.CurrentRows);

            StringBuilder Stb = new StringBuilder();
            if (NomEmpresa.Length < 40)
            {
                Stb.Append(" ".PadLeft((40 - NomEmpresa.Length) / 2, ' ') + NomEmpresa + " ".PadLeft((40 - NomEmpresa.Length) / 2, ' ') + "\n");
            }
            else
                Stb.Append(NomEmpresa + "\n");
            //Stb.Append("Impreso en:\n");
            if (Direccion.Length < 40)
            {
                Stb.Append(" ".PadLeft((40 - Direccion.Length) / 2, ' ') + Direccion + " ".PadLeft((40 - Direccion.Length) / 2, ' ') + "\n");
            }
            else
                Stb.Append(CadenaFormateada(40, Direccion));
            Stb.Append(" ".PadLeft((40 - ("RUC : " + RUC).Length) / 2, ' ') + "RUC : " + RUC + " ".PadLeft((40 - ("RUC : " + RUC).Length) / 2, ' ') + "\n");

            if (TelefonoCelular != "")
                Stb.Append(" ".PadLeft((40 - ("Celular #:" + TelefonoCelular).Length) / 2, ' ') + "Celular #:" + TelefonoCelular + " ".PadLeft((40 - ("Celular #:" + TelefonoCelular).Length) / 2, ' ') + "\n");


            if (TelefonoFijo != "")
                Stb.Append(" ".PadLeft((40 - ("Tel. Fijo. #:" + TelefonoFijo).Length) / 2, ' ') + "Tel. Fijo. #:" + TelefonoFijo + " ".PadLeft((40 - ("Tel. Fijo. #:" + TelefonoFijo).Length) / 2, ' ') + "\n");

            Stb.Append("****************************************\n");
            Stb.Append("Nro Serie : " + NroSerieCaja + "        " + FECHA_IMPRESION.ToShortDateString() + "\n");
            //Stb.Append("Nro Aut.  : " + NroAutorizacion + "     " + FECHA_IMPRESION.ToShortTimeString() + "\n");
            Stb.Append(FECHA_IMPRESION.ToShortTimeString() + "\n");
            Stb.Append(DV_SEDEFILTRADA[0]["Distrito"].ToString() + "\n");
            Stb.Append(DV_SEDEFILTRADA[0]["Provincia"].ToString() + "\n");
            Stb.Append("****************************************\n");
            Stb.Append(NombreComprobante + " " + TipoFE + Numcomprobante.Substring(0, 3) + "-0" + Numcomprobante.Substring(4) + "\n");
            if (Usuario.Length > 30)
                Stb.Append("Caja #:" + Nomcaja + " Cajero: " + Usuario.Substring(0, 30) + "\n");
            else
                Stb.Append("Caja #:" + Nomcaja + " Cajero: " + Usuario + "\n");




            //region delos datos del cliente
            if (ConCliente == true)
            {
                Stb.Append("****************************************\n");
                if (TipoFE == "F")
                    Stb.Append("N° RUC: ");
                else
                    Stb.Append("N° Documento: ");

                Stb.Append(NroDocumento + "\n");
                Stb.Append("Razón Social:\n");
                Stb.Append(CadenaFormateada(40, Nomcliente));
                Stb.Append("Dirección:\n");
                Stb.Append(CadenaFormateada(40, DireccionCliente));
            }
            Stb.Append("****************************************\n");
            //detalles del comprobante
            Stb.Append("Cant.    Producto          P.vta   Impt\n");
            Stb.Append("****************************************\n");

            CantidadFilas = 0;
            decimal totalpordetalle = 0;
            foreach (DataRow DR in DTDetalles.Rows)
            {
                Stb.Append(DetallePagoComprobante(Convert.ToDecimal(DR["Cantidad"]), DR["UnidadMedidaID"].ToString(), 40, DR["Alias"].ToString(), Convert.ToDecimal(DR["PrecioUnitario"]), Convert.ToDecimal(DR["Importe"])));
                totalpordetalle = totalpordetalle + Convert.ToDecimal(DR["Importe"]);
            }

            Stb.Append("****************************************\n");

            if (Pagado == 0)
                Stb.Append("OP. GRATUITAS: ".PadRight(20, ' ') + totalpordetalle.ToString("C").PadLeft(20, ' ') + "\n");
            else
                Stb.Append("OP. GRATUITAS: ".PadRight(20, ' ') + 0.ToString("C").PadLeft(20, ' ') + "\n");

            if (MontoIGV == 0)
                Stb.Append("OP. EXONERADAS: ".PadRight(20, ' ') + (totalcomprobante - MontoIGV  - TotalICBPER).ToString("C").PadLeft(20, ' ') + "\n");
            else
                Stb.Append("OP. EXONERADAS: ".PadRight(20, ' ') + 0.ToString("C").PadLeft(20, ' ') + "\n");

            Stb.Append("OP. INAFECTA: ".PadRight(20, ' ') + 0.ToString("C").PadLeft(20, ' ') + "\n");

            if (MontoIGV == 0)
                Stb.Append("OP. GRAVADAS: ".PadRight(20, ' ') + 0.ToString("C").PadLeft(20, ' ') + "\n");
            else
                Stb.Append("OP. GRAVADAS: ".PadRight(20, ' ') + (totalcomprobante - MontoIGV - TotalICBPER).ToString("C").PadLeft(20, ' ') + "\n");

            Stb.Append("TOTAL DSCTO: ".PadRight(20, ' ') + 0.ToString("C").PadLeft(20, ' ') + "\n");
            Stb.Append("IGV: ".PadRight(20, ' ') + MontoIGV.ToString("C").PadLeft(20, ' ') + "\n");
            if (TotalICBPER > 0)
            {
                Stb.Append("Importe ICBPER:".PadRight(20, ' ') + TotalICBPER.ToString("C").PadLeft(20, ' ') + "\n"); 
            }
            if ((totalcomprobante > Pagado) && (totalcomprobante - Pagado) < Convert.ToDecimal(0.10))
            {
                Stb.Append("Redondeo: " + (Pagado - totalcomprobante).ToString("C").PadLeft(40 - 10, ' ') + "\n");
            }
            Stb.Append("IMPORTE TOTAL: ".PadRight(20, ' ') + totalcomprobante.ToString("C").PadLeft(20, ' ') + "\n\n");
            Stb.Append("TOTAL PAGO EFECTIVO S/: ".PadRight(25, ' ') + Pagado.ToString("C").PadLeft(15, ' ') + "\n\n");

            TotalPagarLetras += " SOLES.";
            if (TotalPagarLetras.Length > 40)
            {
                Stb.Append(TotalPagarLetras.Substring(0, 40) + "\n");
                if (TotalPagarLetras.Substring(35).Length > 40)
                    Stb.Append(TotalPagarLetras.Substring(40, 40) + "\n\n");
                else
                    Stb.Append(TotalPagarLetras.Substring(40) + "\n\n");
            }
            else
                Stb.Append(TotalPagarLetras + "\n");

            Stb.Append("Monto entregado: " + MontoEntregado.ToString("C").PadLeft(40 - 17, ' ') + "\n");
            Stb.Append("Vuelto: " + (MontoEntregado - Pagado).ToString("C").PadLeft(32, ' ') + "\n");

            if (Canasta != "")
            {
                Stb.Append("Canasta: " + Canasta + "\n");
            }

            Stb.Append("ESTA ES UNA REPRESENTACIÓN IMPRESA \nDE LA " + ((TipoFE == "F") ? "FACTURA ELECTRÓNICA" : "BOLETA ELECTRÓNICA") + "\n");

            //Stb.Append(Convert.ToChar(27) + "i");//corte de la impresora



            //Stb.Append("Nro de Items: " + DTDetalles.Rows.Count.ToString() + "  *\n");
            //Stb.Append("*puede incluir servicio de flete y/o descuento.\n");


            //Stb.Append("***Por favor conserve su comprobante***");

            StrResultado[0] = Stb.ToString();
            StrResultado[1] = CantidadFilas.ToString();

            return StrResultado;
            #endregion
        }


        public string[] FormatoTicketFEResumido(string NomEmpresa, string Direccion, string Numcomprobante, string NombreComprobante,
   DataTable DTDetalles, string RUC, string Usuario, decimal Pagado, string Nomcaja, string NroSerieCaja,
   string NroAutorizacion, string TotalPagarLetras, string Nomcliente, string NroDocumento, string DireccionCliente,
   string Canasta, Boolean ConCliente, DateTime FECHA_IMPRESION, decimal MontoEntregado, decimal MontoIGV, string TipoFE,decimal TotalComprobante, decimal TotalICBPER)
        {
            #region formato de etiquetera
            //calcular el apgo en letras
            string[] StrResultado = new string[2];

            //filtrar datos de la empresa para visualizar
            DataView DV_SEDEFILTRADA = new DataView(UTI_Datatables.Dt_Sedes, "SedeID = '" + AppSettings.SedeID + "'", "", DataViewRowState.CurrentRows);

            StringBuilder Stb = new StringBuilder();
            if (NomEmpresa.Length < 40)
            {
                Stb.Append(" ".PadLeft((40 - NomEmpresa.Length) / 2, ' ') + NomEmpresa + " ".PadLeft((40 - NomEmpresa.Length) / 2, ' ') + "\n");
            }
            else
                Stb.Append(NomEmpresa + "\n");
            //Stb.Append("Impreso en:\n");
            if (Direccion.Length < 40)
            {
                Stb.Append(" ".PadLeft((40 - Direccion.Length) / 2, ' ') + Direccion + " ".PadLeft((40 - Direccion.Length) / 2, ' ') + "\n");
            }
            else
                Stb.Append(CadenaFormateada(40, Direccion));
            Stb.Append(" ".PadLeft((40 - ("RUC : " + RUC).Length) / 2, ' ') + "RUC : " + RUC + " ".PadLeft((40 - ("RUC : " + RUC).Length) / 2, ' ') + "\n");
            Stb.Append("****************************************\n");
            Stb.Append("Nro Serie : " + NroSerieCaja + "        " + FECHA_IMPRESION.ToShortDateString() + "\n");
            //Stb.Append("Nro Aut.  : " + NroAutorizacion + "     " + FECHA_IMPRESION.ToShortTimeString() + "\n");
            Stb.Append(FECHA_IMPRESION.ToShortTimeString() + "\n");
            Stb.Append(DV_SEDEFILTRADA[0]["Distrito"].ToString() + "\n");
            Stb.Append(DV_SEDEFILTRADA[0]["Provincia"].ToString() + "\n");
            Stb.Append("****************************************\n");
            Stb.Append(NombreComprobante + " " + TipoFE + Numcomprobante.Substring(0, 3) + "-0" + Numcomprobante.Substring(4) + "\n");
            if (Usuario.Length > 30)
                Stb.Append("Caja #:" + Nomcaja + " Cajero: " + Usuario.Substring(0, 30) + "\n");
            else
                Stb.Append("Caja #:" + Nomcaja + " Cajero: " + Usuario + "\n");
            //region delos datos del cliente
            if (ConCliente == true)
            {
                Stb.Append("****************************************\n");
                if (TipoFE == "F")
                    Stb.Append("N° RUC: ");
                else
                    Stb.Append("N° Documento: ");

                Stb.Append(NroDocumento + "\n");
                Stb.Append("Razón Social:\n");
                Stb.Append(CadenaFormateada(40, Nomcliente));
                Stb.Append("Dirección:\n");
                Stb.Append(CadenaFormateada(40, DireccionCliente));
            }
            Stb.Append("****************************************\n");
            //detalles del comprobante
            Stb.Append("Cant.    Producto          P.vta   Impt\n");
            Stb.Append("****************************************\n");

            CantidadFilas = 0;
            foreach (DataRow DR in DTDetalles.Rows)
            {
                Stb.Append(DetallePagoComprobante(Convert.ToDecimal(DR["Cantidad"]), DR["UnidadMedidaID"].ToString(), 40, DR["Alias"].ToString(), Convert.ToDecimal(DR["PrecioUnitario"]), Convert.ToDecimal(DR["Importe"])));
            }

            Stb.Append("****************************************\n");
            if (TotalICBPER > 0)
                Stb.Append("Importe ICBPER:".PadRight(20, ' ') + TotalICBPER.ToString("C").PadLeft(20, ' ') + "\n");

            if ((TotalComprobante > Pagado) && (TotalComprobante - Pagado) < Convert.ToDecimal(0.10))
            {
                Stb.Append("Redondeo: " + (Pagado - TotalComprobante).ToString("C").PadLeft(40 - 10, ' ') + "\n");
            }
            Stb.Append("IMPORTE TOTAL: ".PadRight(20, ' ') + Pagado.ToString("C").PadLeft(20, ' ') + "\n\n");


            Stb.Append("Monto entregado: " + MontoEntregado.ToString("C").PadLeft(40 - 17, ' ') + "\n");
            Stb.Append("Vuelto: " + (MontoEntregado - Pagado).ToString("C").PadLeft(32, ' ') + "\n");


            //Stb.Append("***Por favor conserve su comprobante***");

            StrResultado[0] = Stb.ToString();
            StrResultado[1] = CantidadFilas.ToString();

            return StrResultado;
            #endregion
        }


        public void EnviarResumen(string EmpresaID, int UsuarioID, DateTime fecha)
        {
            try
            {


                string RUTA_WS_SUNAT = ConfigurationManager.AppSettings["RUTA_WS_SUNAT"];


                CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
                DataSet ds2 = objCD_Venta.DatosAnulacionFE(null, "", EmpresaID, "RC", UsuarioID);
                DataTable dtc2 = ds2.Tables[0];


                DataSet ds = new CL_Comprobante().GetComprobanteFE(null, "", EmpresaID, fecha, "");
                DataTable dtc = ds.Tables[0];
                DataTable dtd = ds.Tables[1];



                if (dtc.Rows[0]["EmiteFE"].ToString() == "S")
                {

                    //ServicioEnviarComprobanteFE.FEServiceClient ServicioFE = new ServicioEnviarComprobanteFE.FEServiceClient();
                    //ServicioEnviarComprobanteFE.Contribuyente emisor = new ServicioEnviarComprobanteFE.Contribuyente();
                    //ServicioEnviarComprobanteFE.Contribuyente receptor = new ServicioEnviarComprobanteFE.Contribuyente();
                    //                    ServicioEnviarComprobanteFE.DetalleDocumento[] detalle = new ServicioEnviarComprobanteFE.DetalleDocumento[dtd.Rows.Count];

                    ServicioEnviarComprobanteFE.FEServiceClient ServicioFE = new ServicioEnviarComprobanteFE.FEServiceClient();
                    ServicioEnviarComprobanteFE.Contribuyente emisor = new ServicioEnviarComprobanteFE.Contribuyente();


                    ServicioEnviarComprobanteFE.ResumenDiarioNuevo _documento = new ServicioEnviarComprobanteFE.ResumenDiarioNuevo();

                    double version = 1.1;

                    if (version == 1.0)
                    {
                        DataView view = new DataView(dtc);
                        DataTable DistinctSeries = view.ToTable(true, "Serie", "TipoDocumento");

                        ServicioEnviarComprobanteFE.GrupoResumenNuevo[] lista = new ServicioEnviarComprobanteFE.GrupoResumenNuevo[DistinctSeries.Rows.Count];

                        int id = 0;
                        foreach (DataRow DR in DistinctSeries.Rows)
                        {
                            ServicioEnviarComprobanteFE.GrupoResumenNuevo GR = new ServicioEnviarComprobanteFE.GrupoResumenNuevo();


                            GR.CorrelativoInicio = Convert.ToInt32(dtc.Compute("MIN(Numero)", "Serie='" + DR["Serie"].ToString() + "' AND TipoDocumento='" + DR["TipoDocumento"].ToString() + "'"));
                            GR.CorrelativoFin = Convert.ToInt32(dtc.Compute("MAX(Numero)", "Serie='" + DR["Serie"].ToString() + "' AND TipoDocumento='" + DR["TipoDocumento"].ToString() + "'"));
                            GR.Exoneradas = Convert.ToDecimal(dtc.Compute("sum(ValorVentaOperacionesExoneradas)", "Serie='" + DR["Serie"].ToString() + "' AND TipoDocumento='" + DR["TipoDocumento"].ToString() + "'"));
                            GR.Exportacion = 0;
                            GR.Gratuitas = Convert.ToDecimal(dtc.Compute("sum(Gratuitas)", "Serie='" + DR["Serie"].ToString() + "' AND TipoDocumento='" + DR["TipoDocumento"].ToString() + "'"));
                            GR.Gravadas = Convert.ToDecimal(dtc.Compute("sum(OperacionesGravadas)", "Serie='" + DR["Serie"].ToString() + "' AND TipoDocumento='" + DR["TipoDocumento"].ToString() + "'"));
                            GR.Id = id + 1;
                            GR.Inafectas = Convert.ToDecimal(dtc.Compute("sum(OperacionesInafectas)", "Serie='" + DR["Serie"].ToString() + "' AND TipoDocumento='" + DR["TipoDocumento"].ToString() + "'"));
                            GR.Moneda = (string)dtc.Compute("MIN(TipoMoneda)", "Serie='" + DR["Serie"].ToString() + "' AND TipoDocumento='" + DR["TipoDocumento"].ToString() + "'");
                            GR.Serie = DR["TipoDocumento"].ToString() == "01" ? "F" + DR["Serie"].ToString() : "B" + DR["Serie"].ToString();
                            GR.TipoDocumento = DR["TipoDocumento"].ToString();
                            GR.TotalDescuentos = Convert.ToDecimal(dtc.Compute("SUM(TotalDescuentos)", "Serie='" + DR["Serie"].ToString() + "' AND TipoDocumento='" + DR["TipoDocumento"].ToString() + "'"));
                            GR.TotalIgv = Convert.ToDecimal(dtc.Compute("sum(SumatoriaIGV)", "Serie='" + DR["Serie"].ToString() + "' AND TipoDocumento='" + DR["TipoDocumento"].ToString() + "'"));
                            GR.TotalIsc = Convert.ToDecimal(dtc.Compute("sum(SumatoriaISC)", "Serie='" + DR["Serie"].ToString() + "' AND TipoDocumento='" + DR["TipoDocumento"].ToString() + "'"));
                            GR.TotalOtrosImpuestos = Convert.ToDecimal(dtc.Compute("SUM(SumatoriaOtrosTributos)", "Serie='" + DR["Serie"].ToString() + "' AND TipoDocumento='" + DR["TipoDocumento"].ToString() + "'"));
                            GR.TotalVenta = Convert.ToDecimal(dtc.Compute("sum(ImporteTotal)", "Serie='" + DR["Serie"].ToString() + "' AND TipoDocumento='" + DR["TipoDocumento"].ToString() + "'"));
                            lista[id] = GR;
                            id = id + 1;
                        }


                        emisor.TipoDocumento = dtc.Rows[0]["TipoDocumentoEmisor"].ToString();
                        emisor.NroDocumento = dtc.Rows[0]["RUC"].ToString();
                        emisor.NombreLegal = dtc.Rows[0]["RazonSocial"].ToString();


                        _documento.Resumenes = lista;
                        _documento.Emisor = emisor;
                        _documento.FechaEmision = Convert.ToDateTime(dtc2.Rows[0]["Fecha"]).ToShortDateString();
                        _documento.FechaReferencia = fecha.ToShortDateString();


                        _documento.IdDocumento = "RC-" + Convert.ToDateTime(dtc2.Rows[0]["Fecha"]).Year.ToString() +
                            Convert.ToDateTime(dtc2.Rows[0]["Fecha"]).Month.ToString().PadLeft(2, '0') +
                            Convert.ToDateTime(dtc2.Rows[0]["Fecha"]).Day.ToString().PadLeft(2, '0') +
                                "-" + dtc2.Rows[0]["Numero"].ToString();
                        _documento.RutaXML = dtc2.Rows[0]["RutaXMLFE"].ToString();
                    }
                    else if (version == 1.1)
                    {


                        ServicioEnviarComprobanteFE.GrupoResumenNuevo[] lista = new ServicioEnviarComprobanteFE.GrupoResumenNuevo[dtc.Rows.Count];

                        int id = 0;
                        foreach (DataRow DR in dtc.Rows)
                        {
                            ServicioEnviarComprobanteFE.GrupoResumenNuevo GR = new ServicioEnviarComprobanteFE.GrupoResumenNuevo();
                            if (Convert.ToBoolean(DR["Estado"]) == false)
                                GR.CodigoEstadoItem = 3;
                            else
                                GR.CodigoEstadoItem = 1;

                            GR.IdDocumento = DR["NumComprobante2"].ToString();
                            GR.TipoDocumentoReceptor = DR["TipoDocumentoIdentidadCliente"].ToString();
                            GR.NroDocumentoReceptor = DR["NumeroDocumentoIdentidadCliente"].ToString();
                            GR.DocumentoRelacionado = "";
                            GR.TipoDocumentoRelacionado = "";

                            GR.CorrelativoInicio = Convert.ToInt32(DR["Numero"].ToString());
                            GR.CorrelativoFin = Convert.ToInt32(DR["Numero"].ToString());
                            GR.Exoneradas = Convert.ToDecimal(DR["ValorVentaOperacionesExoneradas"]);
                            GR.Exportacion = 0;
                            GR.Gratuitas = Convert.ToDecimal(DR["Gratuitas"]);
                            GR.Gravadas = Convert.ToDecimal(DR["OperacionesGravadas"]);
                            GR.Id = id + 1;
                            GR.Inafectas = Convert.ToDecimal(DR["OperacionesInafectas"]);
                            GR.Moneda = DR["TipoMoneda"].ToString();
                            GR.Serie = DR["TipoDocumento"].ToString() == "01" ? "F" + DR["Serie"].ToString() : "B" + DR["Serie"].ToString();
                            GR.TipoDocumento = DR["TipoDocumento"].ToString();
                            GR.TotalDescuentos = Convert.ToDecimal(DR["TotalDescuentos"]);
                            GR.TotalIgv = Convert.ToDecimal(DR["SumatoriaIGV"]);
                            GR.TotalIsc = Convert.ToDecimal(DR["SumatoriaISC"]);
                            GR.TotalOtrosImpuestos = Convert.ToDecimal(DR["SumatoriaOtrosTributos"]);
                            GR.TotalVenta = Convert.ToDecimal(DR["ImporteTotal"]);

                            lista[id] = GR;
                            id = id + 1;
                        }


                        emisor.TipoDocumento = dtc.Rows[0]["TipoDocumentoEmisor"].ToString();
                        emisor.NroDocumento = dtc.Rows[0]["RUC"].ToString();
                        emisor.NombreLegal = dtc.Rows[0]["RazonSocial"].ToString();


                        _documento.Resumenes = lista;
                        _documento.Emisor = emisor;
                        _documento.FechaEmision = Convert.ToDateTime(dtc2.Rows[0]["Fecha"]).ToShortDateString();
                        _documento.FechaReferencia = fecha.ToShortDateString();

                        _documento.IdDocumento = "RC-" + Convert.ToDateTime(dtc2.Rows[0]["Fecha"]).Year.ToString() +
                            Convert.ToDateTime(dtc2.Rows[0]["Fecha"]).Month.ToString().PadLeft(2, '0') +
                            Convert.ToDateTime(dtc2.Rows[0]["Fecha"]).Day.ToString().PadLeft(2, '0') +
                                "-" + dtc2.Rows[0]["Numero"].ToString();
                        _documento.RutaXML = dtc2.Rows[0]["RutaXMLFE"].ToString();
                    }





                    //ServicioEnviarComprobanteFE.DocumentoResponse respu =  ServicioFE.EnviarComprobanteFE(_documento);
                    ServicioEnviarComprobanteFE.DocumentoResponse respu = ServicioFE.GenerarXMLResumenDiario(_documento);

                    if (respu.Exito == true)
                    {
                        ServicioEnviarComprobanteFE.RespuestaComunConArchivo2 RespuestaSunat = ServicioFE.EnviarSunat("RC",
                            dtc.Rows[0]["RutaXMLFE"].ToString(), dtc.Rows[0]["RutaCDRFE"].ToString(), dtc.Rows[0]["RutaCertificado"].ToString(), dtc.Rows[0]["ClaveCertificado"].ToString(), dtc.Rows[0]["RUC"].ToString(),
                            dtc.Rows[0]["UsuarioSOL"].ToString(), dtc.Rows[0]["ClaveSol"].ToString(), _documento.IdDocumento,
                            RUTA_WS_SUNAT, true);

                        CL_Comprobante scom = new CL_Comprobante();
                        objCD_Venta.ActualizarBajaFE(Convert.ToInt32(dtc2.Rows[0]["BajaFEId"]), fecha, Convert.ToInt64(RespuestaSunat.NroTicket), RespuestaSunat.MensajeError);

                        if (RespuestaSunat.Exito == false)
                        {
                            //DataTable dtres = scom.ActualizarComprobanteSunat(Convert.ToInt32(dtc.Rows[0]["ComprobanteId"]), "N");
                            throw new Exception(RespuestaSunat.MensajeError);
                        }
                        else
                        {

                            //DataTable dtres = scom.ActualizarComprobanteSunat(Convert.ToInt32(dtc.Rows[0]["ComprobanteId"]), "B");

                        }
                    }
                    else
                    {
                        throw new Exception(respu.MensajeError);
                    }




                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataSet ObtenerParaImpresion(Int64 ComprobanteId)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();
            Ds = objCD_Venta.ObtenerParaImpresion(ComprobanteId);
            return Ds;
        }

        public DataSet ObtenerDatosCliente(string RUC)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();
            Ds = objCD_Venta.ObtenerDatosCliente(RUC);
            return Ds;
        }

        public void InsertarClientesSunat(string ruta)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            objCD_Venta.InsertarClientesSunat(ruta);
        }

        public DataTable ObtenerDatosSucursal(string EmpresaID, string SedeID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            return objCD_Venta.ObtenerDatosSucursal(EmpresaID, SedeID);
        }

        public string FormatoPuntos(string RUC, string NomEmpresa, string concepto, string NroDocumento, string Nomcliente,
            string PuntosUsados, string PuntosRestantes, DateTime FECHA_IMPRESION)
        {
            #region formato de etiquetera


            //filtrar datos de la empresa para visualizar

            StringBuilder Stb = new StringBuilder();
            if (NomEmpresa.Length < 40)
            {
                Stb.Append(" ".PadLeft((40 - NomEmpresa.Length) / 2, ' ') + NomEmpresa + " ".PadLeft((40 - NomEmpresa.Length) / 2, ' ') + "\n");
            }
            else
                Stb.Append(NomEmpresa + "\n");

           
            Stb.Append(" ".PadLeft((40 - ("RUC : " + RUC).Length) / 2, ' ') + "RUC : " + RUC + " ".PadLeft((40 - ("RUC : " + RUC).Length) / 2, ' ') + "\n");
            Stb.Append("****************************************\n");
            Stb.Append("Fecha : " + FECHA_IMPRESION.ToShortDateString() + "\n");

            Stb.Append("****************************************\n");


            //region delos datos del cliente

            Stb.Append("N° Documento: ");

            Stb.Append(NroDocumento + "\n");
            Stb.Append("Razón Social:\n");
            Stb.Append(CadenaFormateada(40, Nomcliente));
            Stb.Append("****************************************\n");
            Stb.Append("Concepto:\n");
            if (concepto.Length < 40)
            {
                Stb.Append(" ".PadLeft((40 - concepto.Length) / 2, ' ') + concepto + " ".PadLeft((40 - concepto.Length) / 2, ' ') + "\n");
            }
            else
                Stb.Append(CadenaFormateada(40, concepto));

            Stb.Append("****************************************\n");


            Stb.Append("Puntos usados: " + PuntosUsados.PadLeft(40 - 15, ' ') + "\n");
            Stb.Append("Puntos restantes: " + PuntosRestantes.PadLeft(40 - 18, ' ') + "\n");



            return Stb.ToString();
            #endregion
        }
    }




}

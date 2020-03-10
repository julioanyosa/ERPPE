using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Halley.CapaDatos.Ventas;
using Halley.Configuracion;
using Halley.Entidad.Ventas;
using Halley.Utilitario;

namespace Halley.CapaLogica.Ventas
{
    public class CL_Pago
    {

        public DataTable getventasprueba()
        {
            CD_Pago objCD_Pago = new CD_Pago(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Pago.getventasprueba();
            return dtTMP;
        }

        public DataTable GetComprobantesCredito(Int32 CreditoID)
        {
            CD_Pago objCD_Pago = new CD_Pago(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Pago.GetComprobantesCredito(CreditoID);
            return dtTMP;
        }
        

        public DataSet GetPagosBoleta(string NumComprobante, Int32 TipoComprobanteID)
        {
            CD_Pago objCD_Pago = new CD_Pago(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();

            Ds = objCD_Pago.GetPagosBoleta(NumComprobante, TipoComprobanteID);
            return Ds;
        }

        public DataTable GetCreditosTotal(Int32 ClienteID)
        {
            CD_Pago objCD_Pago = new CD_Pago(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Pago.GetCreditosTotal(ClienteID);
            return dtTMP;
        }

        public Int32 InsertPago(E_Pago ObjPago)
        {
            Int32 PagoID = 0;
            CD_Pago objCD_Pago = new CD_Pago(AppSettings.GetConnectionString);
            PagoID = objCD_Pago.InsertPago(ObjPago);
            return PagoID;
        }

        public Int32 InsertPago(E_Pago ObjPago, E_NotaIngreso ObjNotaIngreso, int EstadoID)
        {
            CD_Pago objCD_Pago = new CD_Pago(AppSettings.GetConnectionString);
            Int32 NotaIngresoID = 0;
            NotaIngresoID = objCD_Pago.InsertPago(ObjPago, ObjNotaIngreso, EstadoID);
            return NotaIngresoID;
        }

        public Int32 UpdateXMLEstadoComprobantes(DataTable DtEstadosComprobante, E_NotaIngreso ObjNotaIngreso)
        {
            Int32 NotaIngresoID;
            string Xml, xmlDetalle;

            Xml = new BaseFunctions().GetXML(DtEstadosComprobante).Replace("NewDataSet", "DocumentElement");
            xmlDetalle = Xml.Replace("Table", "Comprobante");

            CD_Pago objCD_Pago = new CD_Pago(AppSettings.GetConnectionString);
            NotaIngresoID = objCD_Pago.UpdateXMLEstadoComprobantes(Xml, ObjNotaIngreso);
            return NotaIngresoID;
        }

        public DataSet GetPagosCredito(Int32 CreditoID)
        {
            CD_Pago objCD_Pago = new CD_Pago(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();

            Ds = objCD_Pago.GetPagosCredito(CreditoID);
            return Ds;
        }

        public string FormatoNotaCreditoInterna(string NomEmpresa,string NomSede,string Ruc,string Usuario,int? NumCredito,string Monto)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.Append(NomEmpresa + "\n");
            cadena.Append("Impreso en:\n");
            if (AppSettings.NomSede.Length > 35)
                cadena.Append(NomSede.Substring(0, 35) + "\n");
            else
                cadena.Append(NomSede + "\n");
            cadena.Append("RUC: " + Ruc + "\n");
            cadena.Append("----------------------------------\n\n");            
            cadena.Append("Atendido Por: ");
            if (Usuario.Length > 28)
                cadena.Append(Usuario.Substring(0, 28) + "\n");
            else
                cadena.Append(Usuario + "\n");
            cadena.Append(DateTime.Now.ToString() + "\n");
            cadena.Append("----------------------------------\n\n");
            cadena.Append("VENTA NAVIDEÑA:\n");
            cadena.Append("Nro del Credito: " + NumCredito.ToString() + "\n");
            cadena.Append("Importe: " + Monto + "\n\n");   
        
            return cadena.ToString();
        }



        public string FormatoTicketPago(string NomEmpresa, Int32 CreditoID, string NomCampanha, string NomSede, string RUC, string Usuario, decimal Pagado, string Nomcaja)
        {
            #region formato de etiquetera
            StringBuilder Stb = new StringBuilder();
            Stb.Append(NomEmpresa + "\n");
            Stb.Append("Impreso en:\n");
            if (AppSettings.NomSede.Length > 35)
                Stb.Append(NomSede.Substring(0, 35) + "\n");
            else
                Stb.Append(NomSede + "\n");
            Stb.Append("RUC: " + RUC + "\n");
            Stb.Append("----------------------------------\n\n");
            Stb.Append("Caja #:" + Nomcaja + "\n");
            Stb.Append("Cajero: ");
            if (Usuario.Length > 28)
                Stb.Append(Usuario.Substring(0, 28) + "\n");
            else
                Stb.Append(Usuario + "\n");
            Stb.Append(DateTime.Now.ToString() + "\n");
            Stb.Append("----------------------------------\n\n");
            Stb.Append("Pago de la campaña:\n");
            Stb.Append("Nro del Credito: " + CreditoID.ToString() + "\n");
            if (NomCampanha.Length > 35)
                Stb.Append("Campaña: " + NomCampanha.Substring(0, 35) + "\n");
            else
                Stb.Append("Campaña: " + NomCampanha + "\n");
            Stb.Append("Importe: " + Pagado.ToString("C") + "\n\n");
            //Stb.Append("Vuelto: " + MontoDevolver.ToString("C") + "\n\n");
            Stb.Append("Por favor conserve su comprobante\n");

            return Stb.ToString();
            #endregion
        }

        public string FormatoTickeEgreso(string NomEmpresa, string NomSede, string RUC, string Usuario, decimal Pagado, string Nomcaja, string Concepto)
        {
            #region formato de etiquetera
            StringBuilder Stb = new StringBuilder();
            Stb.Append(NomEmpresa + "\n");
            Stb.Append("Impreso en:\n");
            if (AppSettings.NomSede.Length > 35)
                Stb.Append(NomSede.Substring(0, 35) + "\n");
            else
                Stb.Append(NomSede + "\n");
            Stb.Append("RUC: " + RUC + "\n");
            Stb.Append("----------------------------------\n\n");
            Stb.Append("Caja #:" + Nomcaja + "\n");
            Stb.Append("Cajero: ");
            if (Usuario.Length > 28)
                Stb.Append(Usuario.Substring(0, 28) + "\n");
            else
                Stb.Append(Usuario + "\n");
            Stb.Append(DateTime.Now.ToString() + "\n");
            Stb.Append("----------------------------------\n\n");
            Stb.Append("Concepto:\n\n");
            Stb.Append(CadenaFormateada(40, Concepto));
            Stb.Append("----------------------------------\n\n");
            Stb.Append("Importe: " + Pagado.ToString("C") + "\n\n");
            Stb.Append("*****Para control interno*****");

            return Stb.ToString();
            #endregion
        }

        public string FormatoTickeIngreso(string NomEmpresa, string Cliente, string NroDocumento, string NomSede, string RUC, string Usuario, decimal Pagado, string Nomcaja, string Concepto, Int32 NotaIngresoID)
        {
            #region formato de etiquetera
            StringBuilder Stb = new StringBuilder();
            Stb.Append(NomEmpresa + "\n");
            Stb.Append("Impreso en:\n");
            if (AppSettings.NomSede.Length > 35)
                Stb.Append(NomSede.Substring(0, 35) + "\n");
            else
                Stb.Append(NomSede + "\n");
            Stb.Append("RUC: " + RUC + "\n");
            Stb.Append("----------------------------------\n\n");
            Stb.Append("Nro Ingreso:   " + NotaIngresoID.ToString() + "\n");
            Stb.Append("Caja #:" + Nomcaja + "\n");
            Stb.Append("Cajero: ");
            if (Usuario.Length > 28)
                Stb.Append(Usuario.Substring(0, 28) + "\n");
            else
                Stb.Append(Usuario + "\n");
            Stb.Append(DateTime.Now.ToString() + "\n");
            Stb.Append("----------------------------------\n\n");
            Stb.Append("Nro documento:\n");
            Stb.Append( NroDocumento + "\n\n");
            Stb.Append("Cliente:\n");
            if (Cliente.Length > 40)
            {
                Stb.Append(Cliente.Substring(0, 40) + "\n");
                if (Cliente.Substring(40).Length > 40)
                    Stb.Append(Cliente.Substring(40, 40) + "\n");
                else
                    Stb.Append(Cliente.Substring(40) + "\n");
            }
            else
                Stb.Append(Cliente + "\n");
            Stb.Append("----------------------------------\n\n");
            Stb.Append("Concepto:\n\n");
            //if (Concepto.Length > 40)
            //{
            //    Stb.Append(Concepto.Substring(0, 40) + "\n");
            //    if (Concepto.Substring(35).Length > 40)
            //        Stb.Append(Concepto.Substring(40, 40) + "\n");
            //    else
            //        Stb.Append(Concepto.Substring(40) + "\n");
            //}
            //else
            //    Stb.Append(Concepto + "\n");

            Stb.Append(CadenaFormateada(40,Concepto));
            Stb.Append("----------------------------------\n\n");
            Stb.Append("Importe: " + Pagado.ToString("C") + "\n\n");
            Stb.Append("*****Conserve su comprobante*****");

            return Stb.ToString();
            #endregion
        }



        public void InsertValeConsumo(E_ValeConsumo ObjValeConsumo)
        {
            CD_Pago objCD_Pago = new CD_Pago(AppSettings.GetConnectionString);
            objCD_Pago.InsertValeConsumo(ObjValeConsumo);
        }

        public DateTime GetFechaHoraServidor()
        {
            CD_Pago objCD_Pago = new CD_Pago(AppSettings.GetConnectionString);
            DateTime FechaHoraServidor;

            FechaHoraServidor = objCD_Pago.GetFechaHoraServidor();
            return FechaHoraServidor;
        }

        public DataTable GetAdelantosCliente(Int32 ClienteID)
        {
            CD_Pago objCD_Pago = new CD_Pago(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Pago.GetAdelantosCliente(ClienteID);
            return dtTMP;
        }

        public string CadenaFormateada(int Ancho, string Texto)
        {
            if (Texto.Length < Ancho)
                return Texto.TrimEnd() + "\n\n";

            //buscamos caracter en texto
            string Linea = "", nuevoTexto = Texto;
            string acumulado = "";
            while (nuevoTexto.Length > 0)
            {
                Linea = nuevoTexto.Substring(0, Ancho);
                if (Linea.Length < Ancho)
                {
                    acumulado += Linea.TrimEnd();
                    return acumulado + "\n\n";
                }

                //buscamos el ultimo espacio
                int pos1 = 0;
                pos1 = Linea.LastIndexOf(" ");
                Linea = Linea.Substring(0,pos1);

                //acumularlo
                acumulado += Linea + "\n";

                //obtner nueva cadena nueva
                nuevoTexto = nuevoTexto.Substring(pos1);

                if (nuevoTexto.Length < Ancho)
                {
                    acumulado += nuevoTexto.TrimEnd();
                    return acumulado + "\n\n";
                }
            }
            return acumulado + "\n\n";
        }

     }
}

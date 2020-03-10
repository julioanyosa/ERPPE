using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Halley.CapaDatos.Ventas;
using Halley.Configuracion;
using System.Data;
using Halley.Entidad.Ventas;
using Halley.Utilitario;

namespace Halley.CapaLogica.Ventas
{
    public class CL_NotaCredito
    {

        public Int32 UpdateSerieGuiaN(string EmpresaSede, string SerieGuiaNID, Int32 NotaCredito)
        {
            CD_NotaCredito ObjCD_NotaCredito = new CD_NotaCredito(AppSettings.GetConnectionString);
            Int32 Valor;

            Valor = ObjCD_NotaCredito.UpdateSerieGuiaN(EmpresaSede, SerieGuiaNID, NotaCredito);
            return Valor;
        }

        public string InsertNotaCredito(E_NotaCredito ObjE_NotaCredito, string EmpresaSede)
        {
            CD_NotaCredito ObjCD_NotaCredito = new CD_NotaCredito(AppSettings.GetConnectionString);
            return ObjCD_NotaCredito.InsertNotaCredito(ObjE_NotaCredito, EmpresaSede);
        }
        
        public string InsertNotaCreditoI(E_NotaCredito ObjE_NotaCredito, string EmpresaSede)
        {
            CD_NotaCredito ObjCD_NotaCredito = new CD_NotaCredito(AppSettings.GetConnectionString);
            return ObjCD_NotaCredito.InsertNotaCreditoI(ObjE_NotaCredito, EmpresaSede);
        }

        public string InsertNotaCredito(E_NotaCredito ObjE_NotaCredito, DataTable DtDetalle, string EmpresaSede,bool ActualizaStock)
        {
            string xml;
            string xmlDetalle=null;
            CD_NotaCredito ObjCD_NotaCredito = new CD_NotaCredito(AppSettings.GetConnectionString);

            if (ActualizaStock == true)
            {
                xml = new BaseFunctions().GetXML(DtDetalle).Replace("NewDataSet", "DocumentElement");
                xmlDetalle = xml.Replace("Table", "DetalleComprobante");
            }

            return ObjCD_NotaCredito.InsertNotaCredito(ObjE_NotaCredito, xmlDetalle, EmpresaSede,ActualizaStock);
        }

        public DataSet GetComprobanteNotaCredito(string NumComprobante, int TipoComprobanteID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();
            Ds = objCD_Venta.GetComprobanteNotaCredito(NumComprobante, TipoComprobanteID);
            return Ds;
        }

        public string FormatoNotaCredito(string NomEmpresa, string NotaCreditoID, string NumComprobante, string TipoComprobante, string NomSede, string RUC, string Usuario, decimal Devolucion, string Nomcaja, string Concepto)
        {
            #region formato de etiquetera
            StringBuilder Stb = new StringBuilder();
            Stb.Append("Nota de credito Nro: " + NotaCreditoID + "\n\n");
            Stb.Append(NomEmpresa + "\n");
            Stb.Append("Impreso en:\n");
            if (AppSettings.NomSede.Length > 35)
                Stb.Append(NomSede.Substring(0, 35) + "\n");
            else
                Stb.Append(NomSede + "\n");
            Stb.Append("RUC: " + RUC + "\n");
            Stb.Append("----------------------------------\n\n");
            Stb.Append("Caja #: " + Nomcaja + "\n");
            Stb.Append("Cajero:\n");
            if (Usuario.Length > 35)
                Stb.Append(Usuario.Substring(0, 35) + "\n");
            else
                Stb.Append(Usuario + "\n");
            Stb.Append(DateTime.Now.ToString() + "\n");
            Stb.Append("----------------------------------\n\n");
            Stb.Append("Comprobante:\n");
            Stb.Append("Tipo del Comprobante: " + TipoComprobante + "\n");
            Stb.Append("Nro del comprobante: " + NumComprobante + "\n");
            Stb.Append("Valido por: " + Devolucion.ToString("C") + "\n\n");
            Stb.Append("----------------------------------\n\n");
            Stb.Append("Concepto:\n\n");
            string Acu = "";
            string Caracter = "";
            for (int X = 0; X < Concepto.Length; X++)
            {
                Caracter = Concepto.Substring(X, 1);
                Acu += Caracter;
                if (Acu.Length == 35)
                {
                    Stb.Append(Acu + "\n");
                    Acu = "";
                }
            }
            if(Acu.Length > 0)
                Stb.Append(Acu + "\n");

            Stb.Append("----------------------------------\n\n");
            Stb.Append("Por favor conserve su comprobante\n");

            return Stb.ToString();
            #endregion
        }
    }
}

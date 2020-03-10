using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Halley.CapaDatos.Ventas;
using Halley.Utilitario;
using Halley.Entidad.Ventas;
using System.Data;
using Halley.Configuracion;

namespace Halley.CapaLogica.Ventas
{
    public class CL_OrdenPedido
    {
        public int InsertOrdenPedido(E_OrdenPedido ObjPedido, DataTable dtPedido)
        {
            string xml,xmlDetalle; 
            CD_OrdenPedido objCD_OrdenPedido = new CD_OrdenPedido(AppSettings.GetConnectionString);
          
            xml=new BaseFunctions().GetXML(dtPedido).Replace("NewDataSet","DocumentElement");
            xmlDetalle=xml.Replace("Table","OrdenPedido");

           return objCD_OrdenPedido.InsertOrdenPedido(ObjPedido,xmlDetalle);
        }

        public int InsertOrdenPedido2(E_OrdenPedido ObjPedido, DataTable dtPedido)
        {
            string xml, xmlDetalle;
            CD_OrdenPedido objCD_OrdenPedido = new CD_OrdenPedido(AppSettings.GetConnectionString);

            xml = new BaseFunctions().GetXML(dtPedido).Replace("NewDataSet", "DocumentElement");
            xmlDetalle = xml.Replace("Table", "OrdenPedido");

            return objCD_OrdenPedido.InsertOrdenPedido2(ObjPedido, xmlDetalle);
        }

        public DataSet getOrdenPedido(string EmpresaID,string SedeId,int NumPedido)
        {
            CD_OrdenPedido objCD_OrdenPedido = new CD_OrdenPedido(AppSettings.GetConnectionString);
            DataSet dsPedido = new DataSet();
            dsPedido = objCD_OrdenPedido.getOrdenPedido(EmpresaID, SedeId, NumPedido);
            return dsPedido;
        }

        public DataSet getOrdenPedido2(int NumPedido)
        {
            CD_OrdenPedido objCD_OrdenPedido = new CD_OrdenPedido(AppSettings.GetConnectionString);
            DataSet dsPedido = new DataSet();
            dsPedido = objCD_OrdenPedido.getOrdenPedido2(NumPedido);
            return dsPedido;
        }
    }
}

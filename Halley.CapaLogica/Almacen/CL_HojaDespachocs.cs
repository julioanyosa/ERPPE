using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Halley.CapaDatos.Almacen;
using Halley.Configuracion;
using Halley.Entidad.Almacen;

namespace Halley.CapaLogica.Almacen
{
     public class CL_HojaDespacho
    {
         public string InsertHojaDespacho(E_HojaDespacho ObjHojaDespacho, string SedeID)
         {
             CD_HojaDespacho objCD_HojaDespacho = new CD_HojaDespacho(AppSettings.GetConnectionString);
             string Valor;

             Valor = objCD_HojaDespacho.InsertHojaDespacho(ObjHojaDespacho, SedeID);
             return Valor;
         }
         public bool InsertXMLDetalleHojaDespacho(string xml)
         {
             CD_HojaDespacho objCD_HojaDespacho = new CD_HojaDespacho(AppSettings.GetConnectionString);
             bool Valor;

             Valor = objCD_HojaDespacho.InsertXMLDetalleHojaDespacho(xml);
             return Valor;
         }

         public DataTable GetDetalleHojaDespacho(string NumHojaDespacho)
         {
             CD_HojaDespacho objCD_HojaDespacho = new CD_HojaDespacho(AppSettings.GetConnectionString);
             DataTable Temp = new DataTable();

             Temp = objCD_HojaDespacho.GetDetalleHojaDespacho(NumHojaDespacho);
             return Temp;
         }

         public DataTable GetCabeceraHojaDespacho(string NumHojaDespacho)
         {
             CD_HojaDespacho objCD_HojaDespacho = new CD_HojaDespacho(AppSettings.GetConnectionString);
             DataTable Temp = new DataTable();

             Temp = objCD_HojaDespacho.GetCabeceraHojaDespacho(NumHojaDespacho);
             return Temp;
         }


         public DataTable GetRecepcionHojaDespacho(string NumHojaDespacho)
         {
             CD_HojaDespacho objCD_HojaDespacho = new CD_HojaDespacho(AppSettings.GetConnectionString);
             DataTable Temp = new DataTable();

             Temp = objCD_HojaDespacho.GetRecepcionHojaDespacho(NumHojaDespacho);
             return Temp;
         }

         public DataTable GetDespachos(string NumComprobante, int TipoComprobanteID)
        {
            CD_HojaDespacho objCD_HojaDespacho = new CD_HojaDespacho(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_HojaDespacho.GetDespachos(NumComprobante, TipoComprobanteID);
            return Temp;
        }
     }
}

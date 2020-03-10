using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Halley.CapaDatos.Almacen;
using Halley.Configuracion;
using Halley.Entidad.Almacen;
using System.Data;

namespace Halley.CapaLogica.Almacen
{
    public class CL_GuiaTransportista
    {
        public string InsertGuiaTransportista(E_GuiaTransporte ObjGuiaTransportista, string EmpresaSede)
        {
            CD_GuiaTransportista objCD_GuiaTransportista = new CD_GuiaTransportista(AppSettings.GetConnectionString);
            string NumGuiaTransportista;

            NumGuiaTransportista = objCD_GuiaTransportista.InsertGuiaTransportista(ObjGuiaTransportista, EmpresaSede);
            return NumGuiaTransportista;
        }

        public bool InsertXMLDetalleGuiaTransporte(string xml)
        {
            CD_GuiaTransportista objCD_GuiaTransportista = new CD_GuiaTransportista(AppSettings.GetConnectionString);
            bool Valor;

            Valor = objCD_GuiaTransportista.InsertXMLDetalleGuiaTransporte(xml);
            return Valor;
        }

        public DataTable GetCabeceraGuiaTransportista(string NumGuiaTransportista)
        {
            CD_GuiaTransportista objCD_GuiaTransportista = new CD_GuiaTransportista(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_GuiaTransportista.GetCabeceraGuiaTransportista(NumGuiaTransportista);
            return Temp;
        }

        public DataTable GetDetalleGuiaTransportista(string NumGuiaTransportista, string TipoGuia)
        {
            CD_GuiaTransportista objCD_GuiaTransportista = new CD_GuiaTransportista(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_GuiaTransportista.GetDetalleGuiaTransportista(NumGuiaTransportista, TipoGuia);
            return Temp;
        }

        public DataTable GetSerieGuiaTransporte(string EmpresaSede)
        {
            CD_GuiaTransportista objCD_GuiaTransportista = new CD_GuiaTransportista(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_GuiaTransportista.GetSerieGuiaTransporte(EmpresaSede);
            return Temp;
        }

        public DataSet CrearGuiaTransporte(E_GuiaTransporte CabeceraGuiaTransporte, DataTable DtDetalleGuiaRemisionVenta, string EmpresaSede)
        {
            CD_GuiaTransportista objCD_GuiaTransportista = new CD_GuiaTransportista(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();
            Ds = objCD_GuiaTransportista.CrearGuiaTransporte(CabeceraGuiaTransporte, DtDetalleGuiaRemisionVenta, EmpresaSede);
            return Ds;
        }
    }
}

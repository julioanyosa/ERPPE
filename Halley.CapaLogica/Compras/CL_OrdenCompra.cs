using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Halley.CapaDatos.Almacen;
using Halley.Configuracion;
using System.Data;
using Halley.Entidad.Compras;

namespace Halley.CapaLogica.Compras
{
    public class CL_OrdenCompra
    {
        public DataTable InsertarCompra(DataTable dtCompra, E_OrdenCompra ObjOrdenCompra, string EmpresaID)
        {
            DataTable Dt = new DataTable();
            CD_OrdenCompra objCD_OrdenCompra = new CD_OrdenCompra(AppSettings.GetConnectionString);
            Dt = objCD_OrdenCompra.InsertarOrdenCompra(dtCompra, ObjOrdenCompra, EmpresaID);
            return Dt;
        }

        public DataTable GetRequerimientoCompra(string EmpresaID)
        {
            CD_OrdenCompra objCD_OrdenCompra = new CD_OrdenCompra(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_OrdenCompra.GetRequerimientoCompra(EmpresaID);
            return Temp;
        }

       

        public DataTable GetCabeceraRecepcionOrdenCompra(string NumOrdenCompra)
        {
            CD_OrdenCompra objCD_OrdenCompra = new CD_OrdenCompra(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_OrdenCompra.GetCabeceraRecepcionOrdenCompra(NumOrdenCompra);
            return Temp;
        }

        public DataTable GetRecepcionOrdenCompra(string NumOrdenCompra, string EmpresaSede)
        {
            CD_OrdenCompra objCD_OrdenCompra = new CD_OrdenCompra(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_OrdenCompra.GetRecepcionOrdenCompra(NumOrdenCompra, EmpresaSede);
            return Temp;
        }

        public bool UpdateXMLDetalleOCEstado(string xml, string Tipo)
        {
            CD_OrdenCompra objCD_OrdenCompra = new CD_OrdenCompra(AppSettings.GetConnectionString);
            bool Valor;

            Valor = objCD_OrdenCompra.UpdateXMLDetalleOCEstado(xml, Tipo);
            return Valor;
        }

        public bool UpdateFacturaOC(string NumOrdenCompra, string FacturaProveedor, int UsuarioID, string SedeID)
        {
            CD_OrdenCompra objCD_OrdenCompra = new CD_OrdenCompra(AppSettings.GetConnectionString);
            bool Valor;

            Valor = objCD_OrdenCompra.UpdateFacturaOC(NumOrdenCompra, FacturaProveedor, UsuarioID, SedeID);
            return Valor;
        }

        public DataTable GetOCPorProductos(string Alias, string EmpresaSede)
        {
            CD_OrdenCompra objCD_OrdenCompra = new CD_OrdenCompra(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_OrdenCompra.GetOCPorProductos(Alias, EmpresaSede);
            return Temp;
        }

    }
}

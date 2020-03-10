using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Halley.CapaDatos.Compras;
using Halley.Configuracion;
using System.Data;
using Halley.Entidad.Compras;

namespace Halley.CapaLogica.Compras
{
   public class CL_Proveedor
    {
        public DataTable GetProveedor()
        {
            CD_Proveedor objCD_Proveedor = new CD_Proveedor(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_Proveedor.GetProveedor();
            return Temp;
        }

         public DataTable GetTipoDocumento()
         {
             CD_Proveedor objCD_Proveedor = new CD_Proveedor(AppSettings.GetConnectionString);
             DataTable Temp = new DataTable();

             Temp = objCD_Proveedor.GetTipoDocumento();
             return Temp;
         }

         public DataTable GetProveedoresTipoDocumento(int IDTipoDocumento)
         {
             CD_Proveedor objCD_Proveedor = new CD_Proveedor(AppSettings.GetConnectionString);
             DataTable Temp = new DataTable();

             Temp = objCD_Proveedor.GetProveedoresTipoDocumento(IDTipoDocumento);
             return Temp;
         }

         public DataTable GetProveedorNroDocumento(string NroDocumento)
         {
             CD_Proveedor objCD_Proveedor = new CD_Proveedor(AppSettings.GetConnectionString);
             DataTable Temp = new DataTable();

             Temp = objCD_Proveedor.GetProveedorNroDocumento(NroDocumento);
             return Temp;
         }

        public Int32 InsertProveedor(E_Proveedor ObjProveedor)
        {
            CD_Proveedor objCD_Proveedor = new CD_Proveedor(AppSettings.GetConnectionString);
            Int32 IDProveedor = 0;

            IDProveedor = objCD_Proveedor.InsertProveedor(ObjProveedor);
            return IDProveedor;
        }

        public void UpdateProveedor(E_Proveedor ObjProveedor, string Tipo)
        {
            CD_Proveedor objCD_Proveedor = new CD_Proveedor(AppSettings.GetConnectionString);
            objCD_Proveedor.UpdateProveedor(ObjProveedor, Tipo);
        }
    }
}

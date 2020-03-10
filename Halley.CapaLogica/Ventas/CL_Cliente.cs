using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Halley.CapaDatos.Ventas;
using Halley.Configuracion;
using Halley.Entidad.Ventas;

namespace Halley.CapaLogica.Ventas
{
    public class CL_Cliente
    {

        public DataTable GetClientes()
        {
            CD_Cliente objCD_Cliente = new CD_Cliente(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Cliente.GetClientes();
            return dtTMP;
        }

        public DataTable GetClienteDocumento(string NroDocumento)
        {
            CD_Cliente objCD_Cliente = new CD_Cliente(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Cliente.GetClienteDocumento(NroDocumento);
            return dtTMP;
        }

        public DataTable GetTipoDocumento()
        {
            CD_Cliente objCD_Cliente = new CD_Cliente(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Cliente.GetTipoDocumento();
            return dtTMP;
        }

        public DataTable GetTipoCliente()
        {
            CD_Cliente objCD_Cliente = new CD_Cliente(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Cliente.GetTipoCliente();
            return dtTMP;
        }


        public Int32 InsertCliente(E_Cliente ObjCliente)
        {
            Int32 ClienteID = 0;
            CD_Cliente objCD_Cliente = new CD_Cliente(AppSettings.GetConnectionString);
            ClienteID = objCD_Cliente.InsertCliente(ObjCliente);
            return ClienteID;
        }

        public void UpdateCliente(E_Cliente ObjCliente, string Tipo)
        {
            CD_Cliente objCD_Cliente = new CD_Cliente(AppSettings.GetConnectionString);
            objCD_Cliente.UpdateCliente(ObjCliente, Tipo);
        }

        public DataSet GetUbicacion()
        {
            CD_Cliente objCD_Cliente = new CD_Cliente(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();
            Ds = objCD_Cliente.GetUbicacion();
            return Ds;
        }

        public DataTable GetPais()
        {
            CD_Cliente objCD_Cliente = new CD_Cliente(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Cliente.GetPais();
            return dtTMP;
        }

        public DataTable GetComprobantesCliente(int ClienteID, DateTime FechaIni, DateTime FechaFin, int TipoVentaID)
        {
            CD_Cliente objCD_Cliente = new CD_Cliente(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Cliente.GetComprobantesCliente(ClienteID, FechaIni, FechaFin, TipoVentaID);
            return dtTMP;
        }
    }
}

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
    public class CL_Credito
    {
        public DataTable GetVentasCredito(string EmpresaID, DateTime FechaIni, DateTime FechaFin)
        {
            CD_Credito objCD_Credito = new CD_Credito(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Credito.GetVentasCredito(EmpresaID, FechaIni, FechaFin);
            return dtTMP;
        }

        public DataTable GetCreditosCliente(int ClienteID, string Tipo)
        {
            CD_Credito objCD_Credito = new CD_Credito(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Credito.GetCreditosCliente(ClienteID, Tipo);
            return dtTMP;
        }

        public DataTable GetCreditosClienteConDeuda(int ClienteID)
        {
            CD_Credito objCD_Credito = new CD_Credito(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Credito.GetCreditosClienteConDeuda(ClienteID);
            return dtTMP;
        }

        public DataTable GetCreditosClienteConDeudaSede(int ClienteID, string SedeIDCredito)
        {
            CD_Credito objCD_Credito = new CD_Credito(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Credito.GetCreditosClienteConDeudaSede(ClienteID, SedeIDCredito);
            return dtTMP;
        }

        
        public DataTable GetFechasCompra(int ClienteID)
        {
            CD_Credito objCD_Credito = new CD_Credito(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Credito.GetFechasCompra(ClienteID);
            return dtTMP;
        }

        public Int32 InsertCredito(E_Credito ObjCredito)
        {
            CD_Credito objCD_Credito = new CD_Credito(AppSettings.GetConnectionString);
            Int32 CreditoID = 0;

            CreditoID = objCD_Credito.InsertCredito(ObjCredito);
            return CreditoID;
        }
        public void UpdateCredito(E_Credito ObjCredito)
        {
            CD_Credito objCD_Credito = new CD_Credito(AppSettings.GetConnectionString);
            objCD_Credito.UpdateCredito(ObjCredito);
        }
    }
}

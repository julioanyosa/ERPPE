using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;


namespace Halley.CapaDatos.Contabilidad
{
    public class CD_Venta
    {

        string connectionString;
        public CD_Venta(string ConnectionString)
		{
			connectionString = ConnectionString;
		}


        public DataTable GetConsolidadoDeVentas(DateTime FechaIni, DateTime FechaFin, int TipoComprobanteID, string EmpresaID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[contabilidad].[Usp_GetConsolidadoDeVentas]");
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.Int, TipoComprobanteID);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlCommand.CommandTimeout = 150;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetCuadreCaja(DateTime FechaIni, DateTime FechaFin, int Cajero, string EmpresaID, string SedeID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Contabilidad].[Usp_GetCuadreCaja]");
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@Cajero", SqlDbType.Int, Cajero);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            SqlCommand.CommandTimeout = 150;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetCierreDiario(DateTime FechaIni, string EmpresaID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Contabilidad].[Usp_GetCierreDiario]");
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlCommand.CommandTimeout = 150;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }
    }
}

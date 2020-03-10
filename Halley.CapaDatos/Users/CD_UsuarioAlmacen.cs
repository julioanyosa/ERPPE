using System;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Halley.CapaDatos.Users
{
    public class CD_UsuarioAlmacen
    {
        string connectionString;

        public CD_UsuarioAlmacen(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

        public DataTable Obtener(int UserID, string AlmacenID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_UsuarioAlmacen]");

            SqlClient.AddInParameter(SqlCommand, "@UserID", SqlDbType.TinyInt, UserID);
            SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.Char, AlmacenID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }
    }
}

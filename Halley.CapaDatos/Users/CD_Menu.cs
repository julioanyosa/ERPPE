using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Halley.CapaDatos.Users
{
    public class CD_Menu
    {
        string connectionString;
		public CD_Menu(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

        public DataTable Obtener(int MenuID, string NomMenu,int MenuTipoID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_Menu]");

            SqlClient.AddInParameter(SqlCommand, "@MenuID", SqlDbType.Int, MenuID);
            SqlClient.AddInParameter(SqlCommand, "@NomMenu", SqlDbType.VarChar, NomMenu);
            SqlClient.AddInParameter(SqlCommand, "@MenuTipoID", SqlDbType.Int, MenuTipoID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetMenuAcceso()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_Users_MenuAcceso]");

            dtTmp = SqlClient.ExecuteDataSet(SqlCommand).Tables[0];
            SqlCommand.Dispose();
            return dtTmp;
        }
    }
}

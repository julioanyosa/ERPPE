using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Halley.Entidad.Almacen;
using Halley.Entidad.Empresa;

namespace Halley.CapaDatos.Empresa
{
    public class CD_Chofer
    {
        string connectionString;
        public CD_Chofer(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

        public DataTable GetChoferes()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Empresa.Usp_GetChoferes");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetChoferesID(string DNI)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Empresa].[Usp_GetChoferesID]");
            SqlClient.AddInParameter(SqlCommand, "@DNI", SqlDbType.Char, DNI);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public void UpdateChofer(E_Chofer ObjChofer, string Tipo)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Empresa].[Usp_UpdateChofer]");

                SqlClient.AddInParameter(SqlCommand, "@ChoferID", SqlDbType.Int, ObjChofer.ChoferID);
                SqlClient.AddInParameter(SqlCommand, "@NomChofer", SqlDbType.VarChar, ObjChofer.NomChofer);
                SqlClient.AddInParameter(SqlCommand, "@ApeChofer", SqlDbType.VarChar, ObjChofer.ApeChofer);
                SqlClient.AddInParameter(SqlCommand, "@DNI", SqlDbType.Char, ObjChofer.DNI);
                SqlClient.AddInParameter(SqlCommand, "@Licencia", SqlDbType.VarChar, ObjChofer.Licencia);
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, ObjChofer.EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjChofer.UsuarioID);
                SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, Tipo);

                SqlClient.ExecuteNonQuery(SqlCommand, tran);

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public void InsertChofer(E_Chofer ObjChofer)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Empresa].[Usp_InsertChofer]");

                SqlClient.AddInParameter(SqlCommand, "@ChoferID", SqlDbType.Int, ObjChofer.ChoferID);
                SqlClient.AddInParameter(SqlCommand, "@NomChofer", SqlDbType.VarChar, ObjChofer.NomChofer);
                SqlClient.AddInParameter(SqlCommand, "@ApeChofer", SqlDbType.VarChar, ObjChofer.ApeChofer);
                SqlClient.AddInParameter(SqlCommand, "@DNI", SqlDbType.Char, ObjChofer.DNI);
                SqlClient.AddInParameter(SqlCommand, "@Licencia", SqlDbType.VarChar, ObjChofer.Licencia);
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, ObjChofer.EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjChofer.UsuarioID);

                SqlClient.ExecuteNonQuery(SqlCommand, tran);

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }
    }
}

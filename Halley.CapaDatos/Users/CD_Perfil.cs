using System;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Halley.CapaDatos.Users
{
    public class CD_Perfil
    {
        string connectionString;

		public CD_Perfil(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

        public DataTable Obtener(int PerfilID, string NomPerfil)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_Perfil]");

            SqlClient.AddInParameter(SqlCommand, "@PerfilID", SqlDbType.TinyInt, PerfilID);
            SqlClient.AddInParameter(SqlCommand, "@NomPerfil", SqlDbType.Int, NomPerfil);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public int Insertar_Perfil(int PerfilID, string NomPerfil, bool FlgEst, int UsuarioID, string xml)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_insert_Perfil]");

                SqlClient.AddOutParameter(SqlCommand, "@PerfilID", SqlDbType.TinyInt, 0);
                SqlClient.AddInParameter(SqlCommand, "@NomPerfil", SqlDbType.VarChar, NomPerfil);
                SqlClient.AddInParameter(SqlCommand, "@FlgEst", SqlDbType.Bit, FlgEst);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.ExecuteNonQuery(SqlCommand, tran);
                int _PerfilID;
                _PerfilID = Convert.ToInt32(SqlClient.GetParameterValue(SqlCommand, "@PerfilID"));

                // Registrar los accesos del perfil
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Usuario].[usp_insertXML_Acceso]");
                SqlClient.AddInParameter(SqlCommandAccess, "@PerfilID", SqlDbType.TinyInt, _PerfilID);
                SqlClient.AddInParameter(SqlCommandAccess, "@FlgEst", SqlDbType.Bit, FlgEst);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommandAccess, "@XML", SqlDbType.Xml, xml);
                SqlClient.ExecuteNonQuery(SqlCommandAccess, tran);

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommand.Dispose();
                return _PerfilID;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void Modificar_Perfil(int PerfilID, string NomPerfil, bool FlgEst, int UsuarioID, string xml)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_update_Perfil]");

                SqlClient.AddInParameter(SqlCommand, "@PerfilID", SqlDbType.TinyInt, PerfilID);
                SqlClient.AddInParameter(SqlCommand, "@NomPerfil", SqlDbType.VarChar, NomPerfil);
                SqlClient.AddInParameter(SqlCommand, "@FlgEst", SqlDbType.Bit, FlgEst);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.ExecuteNonQuery(SqlCommand, tran);

                // Registrar los accesos del perfil
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Usuario].[usp_insertXML_Acceso]");
                SqlClient.AddInParameter(SqlCommandAccess, "@PerfilID", SqlDbType.TinyInt, PerfilID);
                SqlClient.AddInParameter(SqlCommandAccess, "@FlgEst", SqlDbType.Char, FlgEst);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommandAccess, "@XML", SqlDbType.Xml, xml);
                SqlClient.ExecuteNonQuery(SqlCommandAccess, tran);

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
        public void Eliminar(int PerfilID, int UsuarioID)
		{
			SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_delete_Perfil]");

			SqlClient.AddInParameter(SqlCommand,"@PerfilID", SqlDbType.Int, PerfilID);
            SqlClient.AddInParameter(SqlCommand,"@UsuarioID", SqlDbType.Int, UsuarioID);
			SqlClient.ExecuteNonQuery(SqlCommand);
		}
    
    }
}

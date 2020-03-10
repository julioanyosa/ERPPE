using System;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Halley.CapaDatos.Users
{
    public class CD_Usuario
    {
        string connectionString;
		public CD_Usuario(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

        public DataTable Obtener(int UserID, int PerfilID, string EmpresaID, string Usuario)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_Usuario]");

            SqlClient.AddInParameter(SqlCommand, "@UserID", SqlDbType.Int, UserID);
            SqlClient.AddInParameter(SqlCommand, "@PerfilID", SqlDbType.Int, PerfilID);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@Usuario", SqlDbType.VarChar, Usuario);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            SqlCommand.Dispose();
            return dtTmp;
        }

        public DataTable ObtenerAccesoPerfil(int PerfilID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_MenuAcceso_Por_Perfil]");
            SqlClient.AddInParameter(SqlCommand, "@PerfilID", SqlDbType.TinyInt, PerfilID);

            dtTmp = SqlClient.ExecuteDataSet(SqlCommand).Tables[0];
            SqlCommand.Dispose();
            return dtTmp;
        }

        public DataTable ObtenerAccesoUsuarioPerfil(int UserID, int PerfilID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_MenuAcceso_Por_UsuarioPerfil]");
            SqlClient.AddInParameter(SqlCommand, "@UserID", SqlDbType.Int, UserID);
            SqlClient.AddInParameter(SqlCommand, "@PerfilID", SqlDbType.TinyInt, PerfilID);

            dtTmp = SqlClient.ExecuteDataSet(SqlCommand).Tables[0];
            SqlCommand.Dispose();
            return dtTmp;
        }

        public int Insertar_Usuario(int UserID, int PerfilID, string EmpresaID, string Usuario, string Descripcion, string Password, string Correo,string Direccion,string Telefono, bool FlgMaster, bool FlgEst, int UsuarioID, string xml, string xmlUN)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_insert_Usuario]");

                SqlClient.AddOutParameter(SqlCommand, "@UserID", SqlDbType.Int, 0);
                SqlClient.AddInParameter(SqlCommand, "@PerfilID", SqlDbType.TinyInt, PerfilID);
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@Usuario", SqlDbType.VarChar, Usuario);
                SqlClient.AddInParameter(SqlCommand, "@Descripcion", SqlDbType.NVarChar, Descripcion);
                SqlClient.AddInParameter(SqlCommand, "@Password", SqlDbType.NVarChar, Password);
                SqlClient.AddInParameter(SqlCommand, "@Correo", SqlDbType.NVarChar, Correo);
                SqlClient.AddInParameter(SqlCommand, "@Direccion", SqlDbType.NVarChar, Direccion);
                SqlClient.AddInParameter(SqlCommand, "@Telefono", SqlDbType.NVarChar, Telefono);
                SqlClient.AddInParameter(SqlCommand, "@FlgMaster", SqlDbType.Bit, FlgMaster);
                SqlClient.AddInParameter(SqlCommand, "@FlgEst", SqlDbType.Bit, FlgEst);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.ExecuteNonQuery(SqlCommand, tran);
                int _UserID;
                _UserID = Convert.ToInt32(SqlClient.GetParameterValue(SqlCommand, "@UserID"));

                // Registrar los accesos personalizados del usuario
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Usuario].[usp_insertXML_AccesoUsuario]");
                SqlClient.AddInParameter(SqlCommandAccess, "@UserID", SqlDbType.Int, _UserID);
                SqlClient.AddInParameter(SqlCommandAccess, "@PerfilID", SqlDbType.Int, PerfilID);
                SqlClient.AddInParameter(SqlCommandAccess, "@FlgEst", SqlDbType.Bit, FlgEst);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommandAccess, "@XML", SqlDbType.Xml, xml);
                SqlClient.ExecuteNonQuery(SqlCommandAccess, tran);

                // Registrar los accesos personalizados del usuario por unidad de negocio
                DbCommand SqlCommandAccessUN = SqlClient.GetStoredProcCommand("[Usuario].[usp_insertXML_UsuarioAlmacen]");
                SqlClient.AddInParameter(SqlCommandAccessUN, "@UserID", SqlDbType.Int, _UserID);
                SqlClient.AddInParameter(SqlCommandAccessUN, "@FlgEst", SqlDbType.Bit, FlgEst);
                SqlClient.AddInParameter(SqlCommandAccessUN, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommandAccessUN, "@XML", SqlDbType.Xml, xmlUN);
                SqlClient.ExecuteNonQuery(SqlCommandAccessUN, tran);

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommand.Dispose();
                return UserID;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }
        public void Modificar_Usuario(int UserID, int PerfilID, string EmpresaID, string Usuario, string Descripcion, string Password, string Correo,string Direccion,string Telefono, bool FlgMaster, bool FlgEst, int UsuarioID, string xml, string xmlUN)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_update_Usuario]");

                SqlClient.AddInParameter(SqlCommand, "@UserID", SqlDbType.Int, UserID);
                SqlClient.AddInParameter(SqlCommand, "@PerfilID", SqlDbType.TinyInt, PerfilID);
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@Usuario", SqlDbType.VarChar, Usuario);
                SqlClient.AddInParameter(SqlCommand, "@Descripcion", SqlDbType.NVarChar, Descripcion);
                SqlClient.AddInParameter(SqlCommand, "@Password", SqlDbType.NVarChar, Password);
                SqlClient.AddInParameter(SqlCommand, "@Correo", SqlDbType.NVarChar, Correo);
                SqlClient.AddInParameter(SqlCommand, "@Direccion", SqlDbType.NVarChar, Direccion);
                SqlClient.AddInParameter(SqlCommand, "@Telefono", SqlDbType.NVarChar, Telefono);
                SqlClient.AddInParameter(SqlCommand, "@FlgMaster", SqlDbType.Bit, FlgMaster);
                SqlClient.AddInParameter(SqlCommand, "@FlgEst", SqlDbType.Bit, FlgEst);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.ExecuteNonQuery(SqlCommand, tran);

                // Registrar los accesos personalizados del usuario
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Usuario].[usp_insertXML_AccesoUsuario]");
                SqlClient.AddInParameter(SqlCommandAccess, "@UserID", SqlDbType.Int, UserID);
                SqlClient.AddInParameter(SqlCommandAccess, "@PerfilID", SqlDbType.Int, PerfilID);
                SqlClient.AddInParameter(SqlCommandAccess, "@FlgEst", SqlDbType.Bit, FlgEst);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommandAccess, "@XML", SqlDbType.Xml, xml);
                SqlClient.ExecuteNonQuery(SqlCommandAccess, tran);

                // Registrar los accesos personalizados del usuario por unidad de negocio
                DbCommand SqlCommandAccessUN = SqlClient.GetStoredProcCommand("[Usuario].[usp_insertXML_UsuarioAlmacen]");
                SqlClient.AddInParameter(SqlCommandAccessUN, "@UserID", SqlDbType.Int, UserID);
                SqlClient.AddInParameter(SqlCommandAccessUN, "@FlgEst", SqlDbType.Bit, FlgEst);
                SqlClient.AddInParameter(SqlCommandAccessUN, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommandAccessUN, "@XML", SqlDbType.Xml, xmlUN);
                SqlClient.ExecuteNonQuery(SqlCommandAccessUN, tran);

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
        public void Eliminar(int UserID)
		{
			SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_delete_Usuario]");

			SqlClient.AddInParameter(SqlCommand,"@UserID", SqlDbType.Int, UserID);
			SqlClient.ExecuteNonQuery(SqlCommand);
		}

        public DataTable GetSedesUsuario(int UserID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_Sedes]");

            SqlClient.AddInParameter(SqlCommand, "@UserID", SqlDbType.Int, UserID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            SqlCommand.Dispose();
            return dtTmp;
        }

        public DataTable USP_M_CONFIGURACION(int Accion, int ConfiguracionID, string EmpresaID,
            string Codigo, string Descripcion, string Data, int UsuarioID, string DireccionIP)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Configuracion].[USP_M_CONFIGURACION]");

            SqlClient.AddInParameter(SqlCommand, "@Accion", SqlDbType.Int, Accion);
            SqlClient.AddInParameter(SqlCommand, "@ConfiguracionID", SqlDbType.Int, ConfiguracionID);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@Codigo", SqlDbType.VarChar, Codigo);
            SqlClient.AddInParameter(SqlCommand, "@Descripcion", SqlDbType.VarChar, Descripcion);
            SqlClient.AddInParameter(SqlCommand, "@Data", SqlDbType.VarChar, Data);
            SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
            SqlClient.AddInParameter(SqlCommand, "@DireccionIP", SqlDbType.Char, DireccionIP);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            SqlCommand.Dispose();
            return dtTmp;
        }
 
    }
}

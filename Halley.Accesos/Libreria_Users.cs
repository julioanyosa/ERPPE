using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Halley.Configuracion;


namespace Halley.Accesos
{
    public class Libreria_Users
    {
        string connectionString = "";
        string _usuario = "";
        string _password = "";

        public Libreria_Users(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        public Libreria_Users(string ConnectionString, string usuario, string password, string menuApp)
        {
            connectionString=ConnectionString;
            _usuario=usuario;
            _password= password;
        }

        private string idUsuarioApp;

        public string IDUsuarioApp
        {
            get { return idUsuarioApp; }
            set { idUsuarioApp = value; }
        }

        public int LogOnUser(string psUserID, string psPassword)
        {
            int retorna = 0;

            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_Usuario]");

            SqlClient.AddInParameter(SqlCommand, "@UserID", SqlDbType.Int,0);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char,"0");
            SqlClient.AddInParameter(SqlCommand, "@PerfilID", SqlDbType.Int, 0);
            SqlClient.AddInParameter(SqlCommand, "@Usuario", SqlDbType.VarChar, psUserID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));

            if (dtTmp.Rows.Count == 0)
                throw new Exception("No existe este usuario registrado en la base de datos.");

            string _pass = string.Empty;

            foreach (DataRow dRow in dtTmp.Rows)
            {
                _pass = Convert.ToString(dRow["Password"]);
                retorna = Convert.ToInt32(dRow["perfilID"]);

                AppSettings.NomEmpresa = Convert.ToString(dRow["NomEmpresa"]);
                AppSettings.NomPerfil = Convert.ToString(dRow["NomPerfil"]);
                AppSettings.EmpresaID = Convert.ToString(dRow["EmpresaID"]);
                AppSettings.RUCEmpresa = Convert.ToString(dRow["RUC"]);
                AppSettings.UserEmail = Convert.ToString(dRow["Correo"]);
                AppSettings.ApeNom_Login = Convert.ToString(dRow["Descripcion"]);
                break;
            }

            if (_pass != psPassword)
            {
                retorna = 0;
                throw new Exception("La contraseña ingresada es incorrecta.");
            }

            return retorna;
        }

        public int ObtenerUsuarioID(string Usuario)
        {
            int retorna = 0;

            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_Usuario]");

            SqlClient.AddInParameter(SqlCommand, "@UserID", SqlDbType.Int, 0);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, "0");
            SqlClient.AddInParameter(SqlCommand, "@PerfilID", SqlDbType.Int, 0);
            SqlClient.AddInParameter(SqlCommand, "@Usuario", SqlDbType.VarChar, Usuario);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));

            foreach (DataRow dRow in dtTmp.Rows)
            {
                retorna = Convert.ToInt32(dRow["UserID"]);
            }

            return retorna;
        }

        public string Obtener_VentanasPermiso(string IDUsuarioApp, int perfilID)
        {
            StringBuilder retorna = new StringBuilder();

            DataTable dtAcceso = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_MenuAcceso_Por_NomUsuarioPerfil]");

            SqlClient.AddInParameter(SqlCommand, "@Usuario", SqlDbType.Char, IDUsuarioApp);
            SqlClient.AddInParameter(SqlCommand, "@perfilID", SqlDbType.Int, perfilID);
            dtAcceso = SqlClient.ExecuteDataSet(SqlCommand).Tables[0];

            foreach (DataRow dRow in dtAcceso.Rows)
            {
                retorna.Append(dRow["Clase"].ToString().Trim());
                retorna.Append(";");
            }

            return retorna.ToString();
        }

        public string Obtener_AlmacenUsuario(int UserID)
        {
            StringBuilder retorna = new StringBuilder();

            DataTable dtAcceso = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_UsuarioAlmacen]");

            SqlClient.AddInParameter(SqlCommand, "@UserID", SqlDbType.Int, UserID);
            SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.VarChar, null);
            dtAcceso = SqlClient.ExecuteDataSet(SqlCommand).Tables[0];

            foreach (DataRow dRow in dtAcceso.Rows)
            {
                retorna.Append("'");
                retorna.Append(dRow["AlmacenID"].ToString().Trim());
                retorna.Append("'");
                retorna.Append(",");
            }

            return retorna.ToString();
        }

        public DataTable Obtener_PermisoAcceso(string IDUsuarioApp, int perfilID)
        {
            DataTable dtAcceso = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_MenuAcceso_Por_NomUsuarioPerfil]");

            SqlClient.AddInParameter(SqlCommand, "@Usuario", SqlDbType.Char, IDUsuarioApp);
            SqlClient.AddInParameter(SqlCommand, "@perfilID", SqlDbType.Int, perfilID);
            dtAcceso = SqlClient.ExecuteDataSet(SqlCommand).Tables[0];

            return dtAcceso;
        }

        public DataTable Obtener(string Cadena)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_AlmacenCadena]");

            SqlClient.AddInParameter(SqlCommand, "@Cadena", SqlDbType.VarChar, Cadena);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable ObtenerPermisos()
        {
            DataTable dt = new DataTable();
            DataView dv = new DataView(AppSettings.Almacen);
            dv.RowFilter = "SedeID= '" + AppSettings.SedeID + "'";
            dt = dv.ToTable();
            return dt;
        }
    }
}

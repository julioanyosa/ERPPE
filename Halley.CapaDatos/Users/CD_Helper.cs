using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Halley.CapaDatos.Users
{
    public class CD_Helper
    {
        string connectionString;
        public CD_Helper(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        //Devolver un DataTable a partir de una cadena sql
        public DataTable GetSqlStringCommand(string sql)
        {
            DataTable tdTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(this.connectionString);
            DbCommand SqlCommand = SqlClient.GetSqlStringCommand(sql);
            tdTmp = SqlClient.ExecuteDataSet(SqlCommand).Tables[0];
            return tdTmp;
        }

        public DataSet GetDataSetSqlStringCommand(string sql)
        {
            DataSet tdTmp = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(this.connectionString);
            DbCommand SqlCommand = SqlClient.GetSqlStringCommand(sql);
            tdTmp = SqlClient.ExecuteDataSet(SqlCommand);
            return tdTmp;
        }

        //Devolver un DataTable a partir de una cadena sql
        public object ExecuteScalar(string sql)
        {
            object obj = new object();
            SqlDatabase SqlClient = new SqlDatabase(this.connectionString);
            DbCommand SqlCommand = SqlClient.GetSqlStringCommand(sql);
            obj = SqlClient.ExecuteScalar(SqlCommand);
            return obj;
        }

        public DataTable Get_UsersMenu(int UserID)
        {
            DataTable tdTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(this.connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Usuario].[usp_get_Menu_Perfil]");
            SqlClient.AddInParameter(SqlCommand, "@UserID", SqlDbType.VarChar, UserID);
            tdTmp = SqlClient.ExecuteDataSet(SqlCommand).Tables[0];

            return tdTmp;
        }

        //Obtener los datos del usuario logueado accediento a la vista vistaPersonal
        public DataTable Get_Usuario(int UserID, int PerfilID, string EmpresaID, string Usuario)
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

        public void SendMail(string Subject, string Mensaje, string To, string Copy, string Archivo)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Empresa.usp_Send_Mail");

            SqlClient.AddInParameter(SqlCommand, "@Subject", SqlDbType.VarChar, Subject);
            SqlClient.AddInParameter(SqlCommand, "@Mensaje", SqlDbType.VarChar, Mensaje);
            SqlClient.AddInParameter(SqlCommand, "@To", SqlDbType.VarChar, To.Trim());
            SqlClient.AddInParameter(SqlCommand, "@Copy", SqlDbType.VarChar, Copy);
            SqlClient.AddInParameter(SqlCommand, "@File", SqlDbType.VarChar, Archivo);
            SqlClient.ExecuteNonQuery(SqlCommand);

        }

        public void SendMail(string Subject, string Mensaje, string To)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Empresa.usp_SendMailSimple");

            SqlClient.AddInParameter(SqlCommand, "@Subject", SqlDbType.VarChar, Subject);
            SqlClient.AddInParameter(SqlCommand, "@Mensaje", SqlDbType.VarChar, Mensaje);
            SqlClient.AddInParameter(SqlCommand, "@To", SqlDbType.VarChar, To.Trim());
            SqlClient.ExecuteNonQuery(SqlCommand);

        }
    }
}

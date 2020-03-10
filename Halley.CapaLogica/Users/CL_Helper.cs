using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Halley.CapaDatos.Users;
using Halley.Configuracion;
using RRV.Seguridad;

namespace Halley.CapaLogica.Users
{
    public class CL_Helper
    {
        public DataTable GetSqlStringCommand(string sql)
        {
            CD_Helper objDL = new CD_Helper(AppSettings.GetConnectionString);
            DataTable dt = null;
            dt = objDL.GetSqlStringCommand(sql);
            return dt;
        }

        public bool AssignedMenu(string assembly)
        {
            bool assigned = AppSettings.AssignedMenu.Contains(assembly);
            return assigned;
        }

        public DataSet GetDataSetSqlStringCommand(string sql)
        {
            CD_Helper objDL = new CD_Helper(AppSettings.GetConnectionString);
            DataSet dt = null;
            dt = objDL.GetDataSetSqlStringCommand(sql);
            return dt;
        }

        public DataTable GetSqlStringCommand(string connection, string sql)
        {
            CD_Helper objDL = new CD_Helper(connection);
            DataTable dt = null;
            dt = objDL.GetDataSetSqlStringCommand(sql).Tables[0];
            return dt;
        }

        public object ExecuteScalar(string sql)
        {
            CD_Helper objDL = new CD_Helper(AppSettings.GetConnectionString);
            object value = null;
            value = objDL.ExecuteScalar(sql);
            return value;
        }

        public DataTable Get_UsersMenu(int UserID)
        {
            CD_Helper objDL = new CD_Helper(AppSettings.GetConnectionString);
            DataTable value;
            value = objDL.Get_UsersMenu(UserID);
            return value;
        }

        public DataTable Get_Usuario(int UserID, int PerfilID, string EmpresaID, string Usuario)
        {
            CD_Helper objDL = new CD_Helper(AppSettings.GetConnectionString);
            DataTable dt;
            dt = objDL.Get_Usuario(UserID,PerfilID, EmpresaID, Usuario);
            return dt;
        }

        public void SendMail(string Subject, string Mensaje, string To, string Copy, string File)
        {
            CD_Helper objDL = new CD_Helper(AppSettings.GetConnectionString);
            objDL.SendMail(Subject, Mensaje, To, Copy, File);
        }

        public void SendMail(string Subject, string Mensaje, string To)
        {
            CD_Helper objDL = new CD_Helper(AppSettings.GetConnectionString);
            objDL.SendMail(Subject, Mensaje, To);
        }

    }
}

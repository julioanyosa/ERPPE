using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Halley.CapaDatos.Users;
using Halley.Configuracion;
using Halley.Entidad.Users;

namespace Halley.CapaLogica.Users
{
    public class CL_Usuario
    {
        public static string Name
        {
            get { return "Usuario"; }
        }

        public bool ValidaUsuario(string Usuario, string Password)
        {
            bool valida = false;
            CD_Usuario objCD_Usuario = new CD_Usuario(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();
            dtTMP = objCD_Usuario.Obtener(0,0,"0",Usuario);
            if (dtTMP.Rows.Count != 0)
            {
                foreach (DataRow dRow in dtTMP.Rows)
                {
                    if (dRow["Password"].ToString() == Password)
                    {
                        valida = true;
                    }
                    else
                    {
                        valida = false;
                    }
                }
            }
            else
            { valida = false; }
            return valida;

        }

        public DataTable Obtener(int UserID, int PerfilID, string  EmpresaID, string Usuario)
        {
            CD_Usuario objCD_Usuario = new CD_Usuario(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Usuario.Obtener(UserID,PerfilID,EmpresaID,Usuario);
            return dtTMP;
        }

        public E_Usuario ObtenerUsuario(string Usuario)
        {
            E_Usuario objE = new E_Usuario();
            CD_Usuario objCD_Usuario = new CD_Usuario(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();
            dtTMP = objCD_Usuario.Obtener(0,0,"0",Usuario);

            foreach (DataRow dRow in dtTMP.Rows)
            {
                objE.UserID = Convert.ToInt32(dRow["UserID"]);
                objE.PerfilID = Convert.ToInt32(dRow["PerfilID"]);
                objE.EmpresaID = Convert.ToInt32(dRow["EmpresaID"]);
                objE.UnidadNegocioID = Convert.ToInt32(dRow["UnidadNegocioID"]);
                objE.PersonalID = Convert.ToInt32(dRow["PersonalID"]);
                objE.Usuario = dRow["Usuario"].ToString();
                objE.Descripcion = dRow["Descripcion"].ToString();
                objE.Password = dRow["Password"].ToString();
                objE.Correo = dRow["Correo"].ToString();
                objE.FlgMaster = Convert.ToBoolean(dRow["FlgMaster"]);
                objE.FlgEst = Convert.ToBoolean(dRow["FlgEst"]);
            }
            return objE;
        }

        public DataTable ObtenerAccesoPerfil(int PerfilID)
        {
            CD_Usuario objCD_Usuario = new CD_Usuario(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Usuario.ObtenerAccesoPerfil(PerfilID);
            return dtTMP;
        }
        public DataTable ObtenerAccesoUsuarioPerfil(int UserID, int PerfilID)
        {
            CD_Usuario objCD_Usuario = new CD_Usuario(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Usuario.ObtenerAccesoUsuarioPerfil(UserID, PerfilID);
            return dtTMP;
        }

        public int Insertar_Usuario(int UserID, int PerfilID, string EmpresaID, string Usuario, string Descripcion, string Password, string Correo,string Direccion,string Telefono, bool FlgMaster, bool FlgEst, int UsuarioID, string xml, string xmlUN)
        {
            int _UserID = 0;
            CD_Usuario objCD_Usuario = new CD_Usuario(AppSettings.GetConnectionString);
            _UserID = objCD_Usuario.Insertar_Usuario(0, PerfilID, EmpresaID, Usuario, Descripcion, Password, Correo,Direccion,Telefono, FlgMaster, FlgEst, UsuarioID, xml, xmlUN);
            return _UserID;
        }

        public void Modificar_Usuario(int UserID, int PerfilID, string EmpresaID, string Usuario, string Descripcion, string Password, string Correo,string Direccion,string Telefono, bool FlgMaster, bool FlgEst, int UsuarioID, string xml, string xmlUN)
        {
            CD_Usuario objCD_Usuario = new CD_Usuario(AppSettings.GetConnectionString);
            objCD_Usuario.Modificar_Usuario(UserID, PerfilID, EmpresaID, Usuario, Descripcion, Password, Correo,Direccion,Telefono, FlgMaster, FlgEst, UsuarioID, xml, xmlUN);
        }
        public void Eliminar(int UserID)
        {

            CD_Usuario objCD_Usuario = new CD_Usuario(AppSettings.GetConnectionString);
            objCD_Usuario.Eliminar(UserID);
        }
        public DataTable GetSedesUsuario(int UserID)
        {
            CD_Usuario objCD_Usuario = new CD_Usuario(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Usuario.GetSedesUsuario(UserID);
            return dtTMP;
        }

        public DataTable USP_M_CONFIGURACION(int Accion, int ConfiguracionID, string EmpresaID,
            string Codigo, string Descripcion, string Data, int UsuarioID, string DireccionIP)
        {
            CD_Usuario objCD_Usuario = new CD_Usuario(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Usuario.USP_M_CONFIGURACION(Accion, ConfiguracionID, EmpresaID,
            Codigo, Descripcion, Data, UsuarioID, DireccionIP);
            return dtTMP;
        }
    }
}

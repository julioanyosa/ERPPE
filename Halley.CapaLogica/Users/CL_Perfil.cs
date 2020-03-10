using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Halley.CapaDatos.Users;
using Halley.Configuracion;
using Halley.Entidad;

namespace Halley.CapaLogica.Users
{
    public class CL_Perfil
    {
        public static string Name
        {
            get { return "Perfil"; }
        }

        public DataTable Obtener(int PerfilID, string NomPerfil)
        {
            CD_Perfil objCD_Perfil = new CD_Perfil(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Perfil.Obtener(PerfilID,NomPerfil);
            return dtTMP;
        }

        public int Insertar_Perfil(int PerfilID, string NomPerfil, bool FlgEst, int UsuarioID, string xml)
        {
            int _perfilID = 0;
            CD_Perfil objCD_Perfil = new CD_Perfil(AppSettings.GetConnectionString);
            _perfilID = objCD_Perfil.Insertar_Perfil(0, NomPerfil, FlgEst, UsuarioID, xml);
            return _perfilID;
        }

        public void Modificar_Perfil(int PerfilID, string NomPerfil, bool FlgEst, int UsuarioID, string xml)
        {
            CD_Perfil objCD_Perfil = new CD_Perfil(AppSettings.GetConnectionString);
            objCD_Perfil.Modificar_Perfil(PerfilID, NomPerfil, FlgEst, UsuarioID, xml);
        }

        public void Eliminar(int PerfilID, int UsuarioID)
        {
            CD_Perfil objCD_Perfil = new CD_Perfil(AppSettings.GetConnectionString);
            objCD_Perfil.Eliminar(PerfilID,UsuarioID);
        }
    }
}

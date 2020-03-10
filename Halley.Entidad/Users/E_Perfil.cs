using System;
using System.Collections.Generic;
using System.Text;

namespace Halley.Entidad.Users
{
    public class E_Perfil
    {
        int _PerfilID;
        string _NomPerfil;
        bool _FlgEst;
        int _UsuarioID;

        public int PerfilID
        {
            get { return _PerfilID; }
            set { _PerfilID = value; }
        }
        public string NomPerfil
        {
            get { return _NomPerfil; }
            set { _NomPerfil = value; }
        }
        public bool FlgEst
        {
            get { return _FlgEst; }
            set { _FlgEst = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

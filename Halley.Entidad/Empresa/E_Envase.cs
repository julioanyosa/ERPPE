using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Empresa
{
    public class E_Envase
    {
        private string _EnvaseID;
        private string _NomEnvase;
        private int _UsuarioID;

        public string EnvaseID
        {
            get { return _EnvaseID; }
            set { _EnvaseID = value; }
        }
        public string NomEnvase
        {
            get { return _NomEnvase; }
            set { _NomEnvase = value; }
        }

        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

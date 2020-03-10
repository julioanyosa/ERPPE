using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Empresa
{
    public class E_Familia
    {
        private string _IDFamilia;
        private string _NomFamilia;
        private int _UsuarioID;

        public string IDFamilia
        {
            get { return _IDFamilia; }
            set { _IDFamilia = value; }
        }
        public string NomFamilia
        {
            get { return _NomFamilia; }
            set { _NomFamilia = value; }
        }

        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

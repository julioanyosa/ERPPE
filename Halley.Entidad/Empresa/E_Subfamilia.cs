using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Empresa
{
    public class E_Subfamilia
    {
        private string _SubFamiliaID;
        private string _IDFamilia;
        private string _NomSubFamilia;
        private int _UsuarioID;

        public string SubFamiliaID
        {
            get { return _SubFamiliaID; }
            set { _SubFamiliaID = value; }
        }
        public string IDFamilia
        {
            get { return _IDFamilia; }
            set { _IDFamilia = value; }
        }
        public string NomSubFamilia
        {
            get { return _NomSubFamilia; }
            set { _NomSubFamilia = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

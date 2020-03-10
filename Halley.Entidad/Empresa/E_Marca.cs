using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Empresa
{
    public class E_Marca
    {
        private Int32 _MarcaID;
        private string _NomMarca;
        private int _UsuarioID;

        public Int32 MarcaID
        {
            get { return _MarcaID; }
            set { _MarcaID = value; }
        }
        public string NomMarca
        {
            get { return _NomMarca; }
            set { _NomMarca = value; }
        }

        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Empresa
{
    public class E_Generico
    {
        private string _GenericoID;
        private string _NomGenerico;
        private int _UsuarioID;

        public string GenericoID
        {
            get { return _GenericoID; }
            set { _GenericoID = value; }
        }
        public string NomGenerico
        {
            get { return _NomGenerico; }
            set { _NomGenerico = value; }
        }

        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

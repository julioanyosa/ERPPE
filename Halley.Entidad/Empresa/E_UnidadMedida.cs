using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Empresa
{
    public class E_UnidadMedida
    {
        private string _UnidadMedidaID;
        private string _NomUnidadMedida;
        private int _UsuarioID;

        public string UnidadMedidaID
        {
            get { return _UnidadMedidaID; }
            set { _UnidadMedidaID = value; }
        }
        public string NomUnidadMedida
        {
            get { return _NomUnidadMedida; }
            set { _NomUnidadMedida = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

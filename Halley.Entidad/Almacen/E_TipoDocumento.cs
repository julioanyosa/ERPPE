using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Almacen
{
    public class E_TipoDocumento
    {

        private int _DocumentoID;
        private string _TipoContabilidad;
        private string _Descripcion;


        public int DocumentoID
        {
            get { return _DocumentoID; }
            set { _DocumentoID = value; }
        }
        public string TipoContabilidad
        {
            get { return _TipoContabilidad; }
            set { _TipoContabilidad = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
       
    }
}

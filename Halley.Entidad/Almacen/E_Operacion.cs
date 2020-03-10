using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Almacen
{
    public class E_Operacion
    {

        private string _OperacionID;
        private string _Descripcion;


        public string OperacionID
        {
            get { return _OperacionID; }
            set { _OperacionID = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
       
    }
}

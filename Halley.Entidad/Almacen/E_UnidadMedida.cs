using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Almacen
{
    public class E_UnidadMedida
    {
        private string _Cod_Unidad;
        private string _Des_Unidad;
        private bool _FlgEst;
        private int _Usuario;

        public string Cod_Unidad
        {
            get { return _Cod_Unidad; }
            set { _Cod_Unidad = value; }
        }
        public string Des_Unidad
        {
            get { return _Des_Unidad; }
            set { _Des_Unidad = value; }
        }

        public bool FlgEst
        {
            get { return _FlgEst; }
            set { _FlgEst = value; }
        }
        public int Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
    }
}

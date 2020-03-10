using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Almacen
{
    public class E_Producto
    {
        private string _ProductoID;
        private string _Des_Producto;
        private bool _Generico;
        private string _Cod_Envase;
        private string _Cod_Presentacion;
        private string _Cod_SubFamilia;
        private bool _FlgEst;
        private int _Usuario;

        public string ProductoID
        {
            get { return _ProductoID; }
            set { _ProductoID = value; }
        }
        public string Des_Producto
        {
            get { return _Des_Producto; }
            set { _Des_Producto = value; }
        }
        public bool Generico
        {
            get { return _Generico; }
            set { _Generico = value; }
        }
        public string Cod_Envase
        {
            get { return _Cod_Envase; }
            set { _Cod_Envase = value; }
        }
        public string Cod_Presentacion
        {
            get { return _Cod_Presentacion; }
            set { _Cod_Presentacion = value; }
        }
        public string Cod_SubFamilia
        {
            get { return _Cod_SubFamilia; }
            set { _Cod_SubFamilia = value; }
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

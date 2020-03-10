using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Empresa
{
    public class E_Presentacion
    {
        private string _PresentacionID;
        private string _NomPresentacion;
        private decimal _Unidades;
        private string _UnidadMedidaID;
        private int _UsuarioID;

        public string PresentacionID
        {
            get { return _PresentacionID; }
            set { _PresentacionID = value; }
        }
        public string NomPresentacion
        {
            get { return _NomPresentacion; }
            set { _NomPresentacion = value; }
        }
        public decimal Unidades
        {
            get { return _Unidades; }
            set { _Unidades = value; }
        }
        public string UnidadMedidaID
        {
            get { return _UnidadMedidaID; }
            set { _UnidadMedidaID = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Empresa
{
    public class E_Producto
    {
        private string _ProductoID;
        private int _MarcaID;
        private string _NomProducto;
        private string _Alias;
        private bool _Formulado;
        private string _Almacen;
        private string _UnidadMedidaID;
        private string _EnvaseID;
        private string _PresentacionID;
        private string _SubFamiliaID;
        private bool _DespachoPeso;
        private decimal _Peso;
        private int _UsuarioID;
        private string _ProductoIDPrincipal;
        private bool _Balanza;
        private int _IDExistencia;
        private decimal _CoeficienteTransformacion;

        public string ProductoID
        {
            get { return _ProductoID; }
            set { _ProductoID = value; }
        }
        public int MarcaID
        {
            get { return _MarcaID; }
            set { _MarcaID = value; }
        }
        public string NomProducto
        {
            get { return _NomProducto; }
            set { _NomProducto = value; }
        }
        public string Alias
        {
            get { return _Alias; }
            set { _Alias = value; }
        }
        public bool Formulado
        {
            get { return _Formulado; }
            set { _Formulado = value; }
        }
        public string Almacen
        {
            get { return _Almacen; }
            set { _Almacen = value; }
        }
        public string UnidadMedidaID
        {
            get { return _UnidadMedidaID; }
            set { _UnidadMedidaID = value; }
        }
        public string EnvaseID
        {
            get { return _EnvaseID; }
            set { _EnvaseID = value; }
        }
        public string PresentacionID
        {
            get { return _PresentacionID; }
            set { _PresentacionID = value; }
        }
        public string SubFamiliaID
        {
            get { return _SubFamiliaID; }
            set { _SubFamiliaID = value; }
        }
        public bool DespachoPeso
        {
            get { return _DespachoPeso; }
            set { _DespachoPeso = value; }
        }
        public decimal Peso
        {
            get { return _Peso; }
            set { _Peso = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
        public string ProductoIDPrincipal
        {
            get { return _ProductoIDPrincipal; }
            set { _ProductoIDPrincipal = value; }
        }
        public bool Balanza
        {
            get { return _Balanza; }
            set { _Balanza = value; }
        }
        public int IDExistencia
        {
            get { return _IDExistencia; }
            set { _IDExistencia = value; }
        }
        public decimal CoeficienteTransformacion
        {
            get { return _CoeficienteTransformacion; }
            set { _CoeficienteTransformacion = value; }
        }
    }
}

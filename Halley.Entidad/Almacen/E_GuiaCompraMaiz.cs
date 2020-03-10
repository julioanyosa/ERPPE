using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Almacen
{
    public class E_GuiaCompraMaiz
    {
        private string _NumGuiaMaiz;
        private int _IDProveedor;
        private string _ProductoID;
        private string _NombreProveedor;
        private string _DNI;
        private string _Procedencia;
        private decimal _PrecioUnitario;
        private string _Sacos;
        private int _TotalSaco;
        private decimal _TotalPeso;
        private string _Comentario;
        private int _UsuarioID;
        private decimal _Pagado;

        public string NumGuiaMaiz
        {
            get { return _NumGuiaMaiz; }
            set { _NumGuiaMaiz = value; }
        }
        public int IDProveedor
        {
            get { return _IDProveedor; }
            set { _IDProveedor = value; }
        }
        public string ProductoID
        {
            get { return _ProductoID; }
            set { _ProductoID = value; }
        }
        public string NombreProveedor
        {
            get { return _NombreProveedor; }
            set { _NombreProveedor = value; }
        }
        public string DNI
        {
            get { return _DNI; }
            set { _DNI = value; }
        }
        public string Procedencia
        {
            get { return _Procedencia; }
            set { _Procedencia = value; }
        }
        public decimal PrecioUnitario
        {
            get { return _PrecioUnitario; }
            set { _PrecioUnitario = value; }
        }
        public string Sacos
        {
            get { return _Sacos; }
            set { _Sacos = value; }
        }
        public int TotalSaco
        {
            get { return _TotalSaco; }
            set { _TotalSaco = value; }
        }
        public decimal TotalPeso
        {
            get { return _TotalPeso; }
            set { _TotalPeso = value; }
        }
        public string Comentario
        {
            get { return _Comentario; }
            set { _Comentario = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
        public decimal Pagado
        {
            get { return _Pagado; }
            set { _Pagado = value; }
        }
    }
}

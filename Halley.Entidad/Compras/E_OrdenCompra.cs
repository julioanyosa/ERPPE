using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Compras
{
    public class E_OrdenCompra
    {
        private string _NumOrdenCompra;
        private int _IDProveedor;
        private int _EstadoID;
        private DateTime _FechaEmision;
        private int _Cotizacion;
        private int _Moneda;
        private string _CondicionPago;
        private string _LugarEntrega;
        private string _FacturaProveedor;
        private string _Observacion;
        private string _Condicion;
        private int _DiasCredito;
        private decimal _Subtotal;
        private decimal _PorcIGV;
        private decimal _Descuento;
        private decimal _Otros;
        private decimal _Recargo;
        private string _SedeID;
        private int _UsuarioID;

        public string NumOrdenCompra
        {
            get { return _NumOrdenCompra; }
            set { _NumOrdenCompra = value; }
        }
        public int IDProveedor
        {
            get { return _IDProveedor; }
            set { _IDProveedor = value; }
        }
        public int EstadoID
        {
            get { return _EstadoID; }
            set { _EstadoID = value; }
        }
        public DateTime FechaEmision
        {
            get { return _FechaEmision; }
            set { _FechaEmision = value; }
        }
        public int Cotizacion
        {
            get { return _Cotizacion; }
            set { _Cotizacion = value; }
        }
        public int Moneda
        {
            get { return _Moneda; }
            set { _Moneda = value; }
        }
        public string CondicionPago
        {
            get { return _CondicionPago; }
            set { _CondicionPago = value; }
        }
        public string LugarEntrega
        {
            get { return _LugarEntrega; }
            set { _LugarEntrega = value; }
        }
        public string FacturaProveedor
        {
            get { return _FacturaProveedor; }
            set { _FacturaProveedor = value; }
        }
        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }
        public int DiasCredito
        {
            get { return _DiasCredito; }
            set { _DiasCredito = value; }
        }
        public decimal Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }
        public decimal PorcIGV
        {
            get { return _PorcIGV; }
            set { _PorcIGV = value; }
        }
        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }
        public decimal Otros
        {
            get { return _Otros; }
            set { _Otros = value; }
        }
        public decimal Recargo
        {
            get { return _Recargo; }
            set { _Recargo = value; }
        }
        public string SedeID
        {
            get { return _SedeID; }
            set { _SedeID = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

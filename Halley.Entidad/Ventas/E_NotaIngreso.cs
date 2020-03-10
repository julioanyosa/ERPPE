using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Ventas
{
    public class E_NotaIngreso
    {
        private int _NotaIngresoID;
        private string _Tipo;
        private int _Numcaja;
        private string _EmpresaID;
        private int _FormaPagoID;
        private string _Observacion;
        private string _LugarPago;
        private decimal _Importe;
        private int _ClienteID;
        private int _Estado;
        private int _UsuarioID;


        public int NotaIngresoID
        {
            get { return _NotaIngresoID; }
            set { _NotaIngresoID = value; }
        }
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
        public int Numcaja
        {
            get { return _Numcaja; }
            set { _Numcaja = value; }
        }
        public string EmpresaID
        {
            get { return _EmpresaID; }
            set { _EmpresaID = value; }
        }
        public int FormaPagoID
        {
            get { return _FormaPagoID; }
            set { _FormaPagoID = value; }
        }
        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }
        public string LugarPago
        {
            get { return _LugarPago; }
            set { _LugarPago = value; }
        }
        public decimal Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }
        public int ClienteID
        {
            get { return _ClienteID; }
            set { _ClienteID = value; }
        }
        public int Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Ventas
{
    public class E_Pago
    {
        private int _PagoID;
        private int _NotaIngresoID;
        private string _NumComprobante;
        private int _TipoComprobanteID;
        private decimal _Importe;
        private int? _FormaPagoID;
        private int _UsuarioID;

        public int PagoID
        {
            get { return _PagoID; }
            set { _PagoID = value; }
        }
        public int NotaIngresoID
        {
            get { return _NotaIngresoID; }
            set { _NotaIngresoID = value; }
        }
        public string NumComprobante
        {
            get { return _NumComprobante; }
            set { _NumComprobante = value; }
        }
        public int TipoComprobanteID
        {
            get { return _TipoComprobanteID; }
            set { _TipoComprobanteID = value; }
        }
        public decimal Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }
        public int? FormaPagoID
        {
            get { return _FormaPagoID; }
            set { _FormaPagoID = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Ventas
{
    public class E_NotaCredito
    {
        private string _NotaCreditoID;
        private int _ClienteID;
        private int _NumCaja;
        private string _NumComprobante;
        private int _TipoComprobanteID;
        private decimal _Importe;
        private string _Concepto;
        private int _UsuarioID;
        private string _SedeID;
        private decimal? _descuento;

        public decimal? descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }

        public string NotaCreditoID
        {
            get { return _NotaCreditoID; }
            set { _NotaCreditoID = value; }
        }
        public int ClienteID
        {
            get { return _ClienteID; }
            set { _ClienteID = value; }
        }
        public int NumCaja
        {
            get { return _NumCaja; }
            set { _NumCaja = value; }
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
        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
        public string SedeID
        {
            get { return _SedeID; }
            set { _SedeID = value; }
        }
    }
}

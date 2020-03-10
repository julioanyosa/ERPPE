using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Ventas
{
    public class E_ValeConsumo
    {
        private string _Numvale;
        private int _PagoID;
        private DateTime _FechaEmision;
        private decimal _Monto;
        private int _UsuarioID;

        public string Numvale
        {
            get { return _Numvale; }
            set { _Numvale = value; }
        }
        public int PagoID
        {
            get { return _PagoID; }
            set { _PagoID = value; }
        }
        public DateTime FechaEmision
        {
            get { return _FechaEmision; }
            set { _FechaEmision = value; }
        }
        public decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

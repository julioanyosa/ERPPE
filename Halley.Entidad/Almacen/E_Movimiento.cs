using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Almacen
{
    public class E_Movimiento
    {
        private int _MovimientoID;
        private string _NomMovimiento;
        private string _Tipo;


        public int MovimientoID
        {
            get { return _MovimientoID; }
            set { _MovimientoID = value; }
        }
        public string NomMovimiento
        {
            get { return _NomMovimiento; }
            set { _NomMovimiento = value; }
        }
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
       
    }
}

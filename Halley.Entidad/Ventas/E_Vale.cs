using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Ventas
{
    public class E_Vale
    {
        public string NumComprobante { get; set; }
        public int NumVale { get; set; }
        public string ProductoId { get; set;}
        public decimal? PesoActual { get; set; }
        public int UsuarioID { get; set; }
        public string NotaIngreso { get; set; }
        public string Tipo { get; set; }
    }
}

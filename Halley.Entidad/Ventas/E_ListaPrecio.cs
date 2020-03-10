using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Ventas
{
    public class E_ListaPrecio
    {
        public int ListaPrecioID { get; set; }
        public string EmpresaID { get; set; }
        public string SedeID { get; set; }
        public string ProductoID { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int UsuarioID { get; set; }
        public int Puntos { get; set; }
    }
}

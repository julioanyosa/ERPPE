using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Ventas
{
    public class E_OrdenPedido
    {
        public int ClienteID { get; set; }
        public int TipoVentaID { get; set; }
        public int? TipoComprobanteID { get; set; }
        public int? TipoPagoID { get; set; }
        public int? FormaPagoId { get; set; }
        public decimal IGV { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalIGV { get; set; }
        public int UsuarioID { get; set; }
        public string EmpresaID { get; set; }
        public string SedeID { get; set; }
        public string Comentario { get; set; }
        public bool Externa { get; set; }
        public bool Vale { get; set; }
        public int NumVale { get; set; }
        public decimal TotalICBPER { get; set; }
    }
}

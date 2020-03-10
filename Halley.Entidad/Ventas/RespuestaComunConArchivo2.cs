using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Ventas
{
    public class RespuestaComunConArchivo2
    {
        public string NombreArchivo { get; set; }

        public bool Exito { get; set; }

        public string MensajeError { get; set; }

        public string Pila { get; set; }

        public string CodigoRespuesta { get; set; }

        public string MensajeRespuesta { get; set; }

        public string TramaZipCdr { get; set; }

        public string NroTicket { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Halley.Configuracion
{
    public class Enums
    {
        public enum Movimiento
        {
            SALIDA_POR_VENTA=1,
            SALIDA_POR_TRANSFERENCIA=2,
            INGRESO_POR_COMPRA=3,
            INGRESO_POR_TRANSFERENCIA=4,
            SALIDA_POR_DESPERDICIO=6,
            INGRESO_POR_DESPERDICIO=7,
            SALIDA_POR_CONSUMO=8
        }

        public enum Comprobante
        {
            Pagado=12,
            Anulado=10,
            Pago_Parcial=13,
            Pendiente=14
        }
    }
}

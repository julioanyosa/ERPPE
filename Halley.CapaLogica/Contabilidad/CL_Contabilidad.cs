using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Halley.CapaDatos.Contabilidad;
using Halley.Configuracion;
using Halley.Entidad.Ventas;

namespace Halley.CapaLogica.Contabilidad
{
    public class CL_Contabilidad
    {

        public DataSet GetDatosCuenta()
        {

            CD_Contabilidad objCD_Contabilidad = new CD_Contabilidad(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();

            Ds = objCD_Contabilidad.GetDatosCuenta();
            return Ds;
        }

    }
}

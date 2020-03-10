using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Halley.Utilitario
{
    public class UTI_Datatables
    {
        private static DataTable _DtEmpresas;

        public static DataTable DtEmpresas
        {
            get { return UTI_Datatables._DtEmpresas; }
            set { UTI_Datatables._DtEmpresas = value; }
        }

        private static DataTable _Dt_Sedes;

        public static DataTable Dt_Sedes
        {
            get { return UTI_Datatables._Dt_Sedes; }
            set { UTI_Datatables._Dt_Sedes = value; }
        }

        private static DataTable _Dt_Configuracion;

        public static DataTable Dt_Configuracion
        {
            get { return UTI_Datatables._Dt_Configuracion; }
            set { UTI_Datatables._Dt_Configuracion = value; }
        }

        

    }
}

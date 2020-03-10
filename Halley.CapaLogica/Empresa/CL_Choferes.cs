using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Halley.CapaDatos.Empresa;
using Halley.Configuracion;
using Halley.Entidad.Empresa;

namespace Halley.CapaLogica.Empresa
{
    public class CL_Choferes
    {
        public DataTable GetChoferes()
        {
            CD_Chofer objCD_Chofer = new CD_Chofer(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Chofer.GetChoferes();
            return dtTMP;
        }

        public DataTable GetChoferesID(string DNI)
        {
            CD_Chofer objCD_Chofer = new CD_Chofer(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Chofer.GetChoferesID(DNI);
            return dtTMP;
        }

        public void UpdateChofer(E_Chofer ObjChofer, string Tipo)
        {
            CD_Chofer objCD_Chofer = new CD_Chofer(AppSettings.GetConnectionString);
            objCD_Chofer.UpdateChofer(ObjChofer, Tipo);
        }

        public void InsertChofer(E_Chofer ObjChofer)
        {
            CD_Chofer objCD_Chofer = new CD_Chofer(AppSettings.GetConnectionString);
            objCD_Chofer.InsertChofer(ObjChofer);
        }
    }
}

using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Halley.CapaDatos.Users;
using Halley.Configuracion;
using Halley.Entidad;

namespace Halley.CapaLogica.Users
{
    public class CL_UsuarioAlmacen
    {
        public static string Name
        {
            get { return "UsuarioAlmacen"; }
        }

        public DataTable Obtener(int UserID, string AlmacenID)
        {
            CD_UsuarioAlmacen objCD_UsuarioUnidadNegocio = new CD_UsuarioAlmacen(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_UsuarioUnidadNegocio.Obtener(UserID, AlmacenID);
            return dtTMP;
        }
    }
}

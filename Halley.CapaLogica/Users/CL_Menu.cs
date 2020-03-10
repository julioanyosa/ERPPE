using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Halley.CapaDatos.Users;
using Halley.Configuracion;

namespace Halley.CapaLogica.Users
{
    public class CL_Menu
    {
        public static string Name
        {
            get { return "Menu Acseso"; }
        }

        public DataTable Obtener(int MenuID, string NomMenu, int MenuTipoID)
        {
            CD_Menu objCD_Menu = new CD_Menu(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Menu.Obtener(MenuID,NomMenu,MenuTipoID);
            return dtTMP;

        }

        public DataTable GetMenuAcceso()
        {
            CD_Menu objCD_Users_Menu = new CD_Menu(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Users_Menu.GetMenuAcceso();
            return dtTMP;
        }

    }
}

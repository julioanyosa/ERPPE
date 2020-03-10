using System;
using System.Collections.Generic;
using System.Text;

namespace Halley.Utilitario
{
    public class StringSQL
    {
        public static string GetMenu()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select MenuID As [PK],NomMenu As [Descripción] From [Menu] ");
            sql.Append("Where # Like '@%'");
            return sql.ToString();
        }
        public static string GetPerfil()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select PerfilID As [PK],NomPerfil As [Descripción] From [Perfil] ");
	        sql.Append("Where # Like '@%'");
            return sql.ToString();
        }
        public static string GetUsuario()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select UserID As [PK],Usuario as [Usuario], Descripcion As [Descripción] From [Usuario] ");
            sql.Append("Where # Like '@%'");
            return sql.ToString();
        }
    }
}

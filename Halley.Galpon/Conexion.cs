using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Halley.Galpon
{
    public class Conexion
    {
        OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Usuario.mdb");

        public DataTable getUsuario(string usuario,string clave)
        {               
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from Usuario where usuario='"+usuario+"' and Clave='"+clave+"'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable getGalpon(int ID)
        {
            OleDbDataAdapter da1 = new OleDbDataAdapter("Select * from Almacen where IDUsuario="+ID+"", cn);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            return dt;
        }

        static string _usuarioId;

        public static string UsuarioId
        {
            get { return Conexion._usuarioId; }
            set { Conexion._usuarioId = value; }
        }

        static string _usuario;

        public static string Usuario
        {
            get { return Conexion._usuario; }
            set { Conexion._usuario = value; }
        }

        static DataTable _dtGalpon;

        public static DataTable dtGalpon
        {
            get { return Conexion._dtGalpon; }
            set { Conexion._dtGalpon = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Empresa
{
    public class E_Sede
    {
        private string _SedeID;
        private string _NomSede;
        private int _Numero;
        private int _Interior;
        private string _Zona;
        private string _Distrito;
        private string _Provincia;
        private string _Departamento;
        private int _UsuarioID;

        public string SedeID
        {
            get { return _SedeID; }
            set { _SedeID = value; }
        }
        public string NomSede
        {
            get { return _NomSede; }
            set { _NomSede = value; }
        }
        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }
        public int Interior
        {
            get { return _Interior; }
            set { _Interior = value; }
        }
        public string Zona
        {
            get { return _Zona; }
            set { _Zona = value; }
        }
        public string Distrito
        {
            get { return _Distrito; }
            set { _Distrito = value; }
        }
        public string Provincia
        {
            get { return _Provincia; }
            set { _Provincia = value; }
        }
        public string Departamento
        {
            get { return _Departamento; }
            set { _Departamento = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

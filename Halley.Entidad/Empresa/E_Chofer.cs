using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Empresa
{
    public class E_Chofer
    {
   		private int _ChoferID;
		private string _NomChofer;
		private string _ApeChofer;
		private string _DNI;
		private string _Licencia;
        private string _EmpresaID;
        private int _UsuarioID;

        public int ChoferID
        {
            get { return _ChoferID; }
            set { _ChoferID = value; }
        }
        public string NomChofer
        {
            get { return _NomChofer; }
            set { _NomChofer = value; }
        }
        public string ApeChofer
        {
            get { return _ApeChofer; }
            set { _ApeChofer = value; }
        }
        public string DNI
        {
            get { return _DNI; }
            set { _DNI = value; }
        }
        public string Licencia
        {
            get { return _Licencia; }
            set { _Licencia = value; }
        }
        public string EmpresaID
        {
            get { return _EmpresaID; }
            set { _EmpresaID = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Empresa
{
    public class E_Empresa
    {
        private string _EmpresaID;

        public string EmpresaID
        {
            get { return _EmpresaID; }
            set { _EmpresaID = value; }
        }
        private string _NomEmpresa;

        public string NomEmpresa
        {
            get { return _NomEmpresa; }
            set { _NomEmpresa = value; }
        }
        private string _RUC;

        public string RUC
        {
            get { return _RUC; }
            set { _RUC = value; }
        }
        private string _DomicilioFiscal;

        public string DomicilioFiscal
        {
            get { return _DomicilioFiscal; }
            set { _DomicilioFiscal = value; }
        }
        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private object _Logo;

        public object Logo
        {
            get { return _Logo; }
            set { _Logo = value; }
        }
        private int _UsuarioID;

        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }

      
    }
}

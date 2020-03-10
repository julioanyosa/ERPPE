using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Empresa
{
    public class E_Vehiculo
    {
        private string _Placa;
        private string _Marca;
        private int _CertificadoInscripcion;
        private string _ConfiguracionVehicular;
        private decimal _Tara;
        private decimal _PesoBruto;
        private string _EmpresaID;
        private int _UsuarioID;

        public string Placa
        {
            get { return _Placa; }
            set { _Placa = value; }
        }
        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }
        public int CertificadoInscripcion
        {
            get { return _CertificadoInscripcion; }
            set { _CertificadoInscripcion = value; }
        }
        public string ConfiguracionVehicular
        {
            get { return _ConfiguracionVehicular; }
            set { _ConfiguracionVehicular = value; }
        }
        public decimal Tara
        {
            get { return _Tara; }
            set { _Tara = value; }
        }
        public decimal PesoBruto
        {
            get { return _PesoBruto; }
            set { _PesoBruto = value; }
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

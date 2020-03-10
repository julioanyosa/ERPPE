using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Ventas
{
    public class E_Credito
    {
        private int _CreditoID;
        private int _ClienteID;
        private string _NomCampanha;
        private decimal _LineaCredito;
        private decimal _CreditoDisponible;
        private int _DiasFinanciar;
        private string _NumDeclaracionJurada;
        private string _SedeIDCredito;
        private DateTime _FechaInicio;
        private int _EstadoID;
        private int _UsuarioID;

        public int CreditoID
        {
            get { return _CreditoID; }
            set { _CreditoID = value; }
        }
        public int ClienteID
        {
            get { return _ClienteID; }
            set { _ClienteID = value; }
        }
        public string NomCampanha
        {
            get { return _NomCampanha; }
            set { _NomCampanha = value; }
        }
        public decimal LineaCredito
        {
            get { return _LineaCredito; }
            set { _LineaCredito = value; }
        }
        public decimal CreditoDisponible
        {
            get { return _CreditoDisponible; }
            set { _CreditoDisponible = value; }
        }
        public int DiasFinanciar
        {
            get { return _DiasFinanciar; }
            set { _DiasFinanciar = value; }
        }
        public string NumDeclaracionJurada
        {
            get { return _NumDeclaracionJurada; }
            set { _NumDeclaracionJurada = value; }
        }
        public string SedeIDCredito
        {
            get { return _SedeIDCredito; }
            set { _SedeIDCredito = value; }
        }
        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }
        public int EstadoID
        {
            get { return _EstadoID; }
            set { _EstadoID = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

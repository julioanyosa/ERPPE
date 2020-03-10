using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Almacen
{
    public class E_HojaDespacho
    {
        private string _EmpresaID;
        private string _EmpresaTransporte;
        private string _NombreChofer;
        private string _placa;
        private string _Carrosa;
        private DateTime _FechaLlegada;
        private DateTime _FechaSalida;
        private int _NumJabas;
        private decimal _PesoTotal;
        private decimal _PesoNeto;
        private Int32 _TotalAnimales;
        private decimal _TaraTotal;
        private int _UsuarioID;

        public string EmpresaID
        {
            get { return _EmpresaID; }
            set { _EmpresaID = value; }
        }
        public string EmpresaTransporte
        {
            get { return _EmpresaTransporte; }
            set { _EmpresaTransporte = value; }
        }
        public string NombreChofer
        {
            get { return _NombreChofer; }
            set { _NombreChofer = value; }
        }
        public string placa
        {
            get { return _placa; }
            set { _placa = value; }
        }
        public string Carrosa
        {
            get { return _Carrosa; }
            set { _Carrosa = value; }
        }
        public DateTime FechaLlegada
        {
            get { return _FechaLlegada; }
            set { _FechaLlegada = value; }
        }
        public DateTime FechaSalida
        {
            get { return _FechaSalida; }
            set { _FechaSalida = value; }
        }
        public int NumJabas
        {
            get { return _NumJabas; }
            set { _NumJabas = value; }
        }
        public decimal PesoTotal
        {
            get { return _PesoTotal; }
            set { _PesoTotal = value; }
        }
        public decimal PesoNeto
        {
            get { return _PesoNeto; }
            set { _PesoNeto = value; }
        }
        public Int32 TotalAnimales
        {
            get { return _TotalAnimales; }
            set { _TotalAnimales = value; }
        }
        public decimal TaraTotal
        {
            get { return _TaraTotal; }
            set { _TaraTotal = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }

    }
}

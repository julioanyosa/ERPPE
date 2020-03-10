using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Halley.Entidad.Almacen
{
    public class E_GuiaTransporte
    {
        private string _EmpresaID;
        private string _NumGuiaRemision;
        private string _DomicilioPartida;
        private int _NroDomicilioPartida;
        private int _IntDomicilioPartida;
        private string _ZonaDomicilioPartida;
        private string _DisDomicilioPartida;
        private string _ProvDomicilioPartida ;
        private string _DepDomicilioPartida ;
        private string _DomicilioLlegada;
        private int _NroDomicilioLlegada;
        private int _IntDomicilioLlegada;
        private string _ZonaDomicilioLlegada;
        private string _DisDomicilioLlegada ;
        private string _ProvDomicilioLlegada ;
        private string _DepDomicilioLlegada ;
        private string _Remitente;
        private string _RUCRemitente;
        private string _DireccionRemitente;
        private string _ObservacionRemitente;
        private string _Destinatario;
        private string _RUCDestinatario;
        private string _DireccionDestinatario;
        private string _ObservacionDestinatario;
        private string _Marca;
        private string _Placa;
        private string _Carrosa;
        private string _NombreChofer;
        private string _DNIChofer;
        private DateTime _FechaSalida;
        private string _ConfiguracionVehicular;
        private int _NroConstInscripcion;
        private string _NroLicTransportista;
        private string _TipoGuia;
        private int _UsuarioID;

        public string EmpresaID
        {
            get { return _EmpresaID; }
            set { _EmpresaID = value; }
        }
        public string NumGuiaRemision
        {
            get { return _NumGuiaRemision; }
            set { _NumGuiaRemision = value; }
        }
        public string DomicilioPartida
        {
            get { return _DomicilioPartida; }
            set { _DomicilioPartida = value; }
        }
        public int NroDomicilioPartida
        {
            get { return _NroDomicilioPartida; }
            set { _NroDomicilioPartida = value; }
        }
        public int IntDomicilioPartida
        {
            get { return _IntDomicilioPartida; }
            set { _IntDomicilioPartida = value; }
        }
        public string ZonaDomicilioPartida
        {
            get { return _ZonaDomicilioPartida; }
            set { _ZonaDomicilioPartida = value; }
        }
        public string DisDomicilioPartida
        {
            get { return _DisDomicilioPartida; }
            set { _DisDomicilioPartida = value; }
        }
        public string ProvDomicilioPartida
        {
            get { return _ProvDomicilioPartida; }
            set { _ProvDomicilioPartida = value; }
        }
        public string DepDomicilioPartida
        {
            get { return _DepDomicilioPartida; }
            set { _DepDomicilioPartida = value; }
        }
        public string DomicilioLlegada
        {
            get { return _DomicilioLlegada; }
            set { _DomicilioLlegada = value; }
        }
        public int NroDomicilioLlegada
        {
            get { return _NroDomicilioLlegada; }
            set { _NroDomicilioLlegada = value; }
        }
        public int IntDomicilioLlegada
        {
            get { return _IntDomicilioLlegada; }
            set { _IntDomicilioLlegada = value; }
        }

        public string ZonaDomicilioLlegada
        {
            get { return _ZonaDomicilioLlegada; }
            set { _ZonaDomicilioLlegada = value; }
        }
        public string DisDomicilioLlegada
        {
            get { return _DisDomicilioLlegada; }
            set { _DisDomicilioLlegada = value; }
        }
        public string ProvDomicilioLlegada
        {
            get { return _ProvDomicilioLlegada; }
            set { _ProvDomicilioLlegada = value; }
        }
        public string DepDomicilioLlegada
        {
            get { return _DepDomicilioLlegada; }
            set { _DepDomicilioLlegada = value; }
        }
        public string Remitente
        {
            get { return _Remitente; }
            set { _Remitente = value; }
        }
        public string RUCRemitente
        {
            get { return _RUCRemitente; }
            set { _RUCRemitente = value; }
        }
        public string DireccionRemitente
        {
            get { return _DireccionRemitente; }
            set { _DireccionRemitente = value; }
        }
        public string ObservacionRemitente
        {
            get { return _ObservacionRemitente; }
            set { _ObservacionRemitente = value; }
        }
        public string Destinatario
        {
            get { return _Destinatario; }
            set { _Destinatario = value; }
        }
        public string RUCDestinatario
        {
            get { return _RUCDestinatario; }
            set { _RUCDestinatario = value; }
        }
        public string DireccionDestinatario
        {
            get { return _DireccionDestinatario; }
            set { _DireccionDestinatario = value; }
        }
        public string ObservacionDestinatario
        {
            get { return _ObservacionDestinatario; }
            set { _ObservacionDestinatario = value; }
        }
        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }
        public string Placa
        {
            get { return _Placa; }
            set { _Placa = value; }
        }
        public string Carrosa
        {
            get { return _Carrosa; }
            set { _Carrosa = value; }
        }
        public string NombreChofer
        {
            get { return _NombreChofer; }
            set { _NombreChofer = value; }
        }
        public string DNIChofer
        {
            get { return _DNIChofer; }
            set { _DNIChofer = value; }
        }
        public DateTime FechaSalida
        {
            get { return _FechaSalida; }
            set { _FechaSalida = value; }
        }
        public string ConfiguracionVehicular
        {
            get { return _ConfiguracionVehicular; }
            set { _ConfiguracionVehicular = value; }
        }
        public Int32 NroConstInscripcion
        {
            get { return _NroConstInscripcion; }
            set { _NroConstInscripcion = value; }
        }
        public string NroLicTransportista
        {
            get { return _NroLicTransportista; }
            set { _NroLicTransportista = value; }
        }
        public string TipoGuia
        {
            get { return _TipoGuia; }
            set { _TipoGuia = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

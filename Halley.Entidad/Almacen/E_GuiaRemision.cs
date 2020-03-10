using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Almacen
{
    public class E_GuiaRemision
    {
        private string _EmpresaID;
        private int _NroJabas;
        private string _DesAnimal;
        private int _NroGalpon;
        private string _DomicilioPartida;
        private int _NroDomicilioPartida;
        private int _InteriorDomicilioPartida;
        private string _ZonaDomicilioPartida;
        private string _DistritoDomicilioPartida;
        private string _ProvinciaDomicilioPartida;
        private string _DepartamentoDomicilioPartida;
        private string _DomicilioLlegada;
        private int _NroDomicilioLlegada;
        private int _IntDomicilioLlegada;
        private string _ZonaDomicilioLlegada;
        private string _DisDomicilioLlegada;
        private string _ProvDomicilioLlegada;
        private string _DepDomicilioLlegada;
        /*private string _Remitente;
        private string _RUCRemitente;
        private string _DireccionRemitente;
        private string _ObservacionRemitente;*/
        private string _Destinatario;
        private string _RUCDestinatario;
        private string _DireccionDestinatario;
        private string _ObservacionDestinatario;
        private string _Marca;
        private string _Carrosa;
        private string _Placa;
        private string _NombreChofer;
        private string _DNIChofer;
        private DateTime _FechaSalida;
        private string _ConfiguracionVehicular;
        private int _NroConstInscripcion;
        private string _NroLicTransportista;
        private string _NroFactura;
        public string _EmpresaTransporte;
        private string _RUCTransporte;
        private string _Pesador;
        private string _Galponero;
        private string _TipoGuia;
        private int _UsuarioID;


        public string EmpresaID
        {
            get { return _EmpresaID; }
            set { _EmpresaID = value; }
        }
        public int NroJabas
        {
            get { return _NroJabas; }
            set { _NroJabas = value; }
        }
        public string DesAnimal
        {
            get { return _DesAnimal; }
            set { _DesAnimal = value; }
        }
        public int NroGalpon
        {
            get { return _NroGalpon; }
            set { _NroGalpon = value; }
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
        public int InteriorDomicilioPartida
        {
            get { return _InteriorDomicilioPartida; }
            set { _InteriorDomicilioPartida = value; }
        }
        public string ZonaDomicilioPartida
        {
            get { return _ZonaDomicilioPartida; }
            set { _ZonaDomicilioPartida = value; }
        }
        public string DistritoDomicilioPartida
        {
            get { return _DistritoDomicilioPartida; }
            set { _DistritoDomicilioPartida = value; }
        }
        public string ProvinciaDomicilioPartida
        {
            get { return _ProvinciaDomicilioPartida; }
            set { _ProvinciaDomicilioPartida = value; }
        }
        public string DepartamentoDomicilioPartida
        {
            get { return _DepartamentoDomicilioPartida; }
            set { _DepartamentoDomicilioPartida = value; }
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
        /*public string Remitente
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
        }*/
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
        public string NroFactura
        {
            get { return _NroFactura; }
            set { _NroFactura = value; }
        }

        public string EmpresaTransporte
        {
            get { return _EmpresaTransporte; }
            set { _EmpresaTransporte = value; }
        }
        public string RUCTransporte
        {
            get { return _RUCTransporte; }
            set { _RUCTransporte = value; }
        }
        public string Pesador
        {
            get { return _Pesador; }
            set { _Pesador = value; }
        }
        public string Galponero
        {
            get { return _Galponero; }
            set { _Galponero = value; }
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

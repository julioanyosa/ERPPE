using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Ventas
{
    public class E_Cliente
    {
        private int _ClienteID;
        private int _TipoClienteID;
        private int _IDTipoDocumento;
        private string _NroDocumento;
        private string _RazonSocial;
        private string _Alias;
        private string _Contacto;
        private string _TelefonoFijo;
        private string _TelefonoMovil;
        private string _Fax;
        private string _Email;
        private string _Direccion;
        private int _DistritoId;
        private int _ProvinciaId;
        private int _DepartamentoId;
        private string _Nombre1;
        private string _Nombre2;
        private string _Apellido1;
        private string _Apellido2;
        private int _PaisId;
        private string _NombreVia;
        private int _DireccionViaId;
        private string _DireccionNumero;
        private string _DireccionInterior;
        private string _Observaciones;
        private int _UsuarioID;


        public int ClienteID
        {
            get { return _ClienteID; }
            set { _ClienteID = value; }
        }
        public int TipoClienteID
        {
            get { return _TipoClienteID; }
            set { _TipoClienteID = value; }
        }
        public int IDTipoDocumento
        {
            get { return _IDTipoDocumento; }
            set { _IDTipoDocumento = value; }
        }
        public string NroDocumento
        {
            get { return _NroDocumento; }
            set { _NroDocumento = value; }
        }
        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }
        public string Alias
        {
            get { return _Alias; }
            set { _Alias = value; }
        }
        public string Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
        }
        public string TelefonoFijo
        {
            get { return _TelefonoFijo; }
            set { _TelefonoFijo = value; }
        }
        public string TelefonoMovil
        {
            get { return _TelefonoMovil; }
            set { _TelefonoMovil = value; }
        }
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public int DistritoId
        {
            get { return _DistritoId; }
            set { _DistritoId = value; }
        }
        public int ProvinciaId
        {
            get { return _ProvinciaId; }
            set { _ProvinciaId = value; }
        }
        public int DepartamentoId
        {
            get { return _DepartamentoId; }
            set { _DepartamentoId = value; }
        }
        public string Nombre1
        {
            get { return _Nombre1; }
            set { _Nombre1 = value; }
        }
        public string Nombre2
        {
            get { return _Nombre2; }
            set { _Nombre2 = value; }
        }
        public string Apellido1
        {
            get { return _Apellido1; }
            set { _Apellido1 = value; }
        }
        public string Apellido2
        {
            get { return _Apellido2; }
            set { _Apellido2 = value; }
        }
        public int PaisId
        {
            get { return _PaisId; }
            set { _PaisId = value; }
        }
        public string NombreVia
        {
            get { return _NombreVia; }
            set { _NombreVia = value; }
        }
        public int DireccionViaId
        {
            get { return _DireccionViaId; }
            set { _DireccionViaId = value; }
        }
        public string DireccionNumero
        {
            get { return _DireccionNumero; }
            set { _DireccionNumero = value; }
        }
        public string DireccionInterior
        {
            get { return _DireccionInterior; }
            set { _DireccionInterior = value; }
        }
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

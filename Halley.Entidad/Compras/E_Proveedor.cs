using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Compras
{
    public class E_Proveedor
    {
        private int _IDProveedor;
        private string _RazonSocial;
        private int _IDTipoDocumento;
        private string _NroDocumento;
        private string _Telefono;
        private string _Pais;
        private string _Region;
        private string _Direccion;
        private string _Contacto;
        private string _CargoContacto;
        private string _Email;

        private int _UsuarioID;

        public int IDProveedor
        {
            get { return _IDProveedor; }
            set { _IDProveedor = value; }
        }
        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
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
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string Pais
        {
            get { return _Pais; }
            set { _Pais = value; }
        }
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public string Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
        }
        public string CargoContacto
        {
            get { return _CargoContacto; }
            set { _CargoContacto = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
    }
}

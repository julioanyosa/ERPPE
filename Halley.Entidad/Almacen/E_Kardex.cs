using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Almacen
{
    public class E_Kardex
    {
        private int _KardexID;
        private string _AlmacenID;
        private string _AlmacenExterno;
        private string _ProductoID;
        private decimal _Cantidad;
        private int _MovimientoID;
        private string _NroDocumento;
        private string _TipoComprobante;
        private string _Serie;
        private int _Numero;
        private string _TipoOperacion;
        private decimal _CostoUnitario;
        private string _Ingreso;
        private int _UsuarioID;
        private DateTime _AudCrea;


        public int KardexID
        {
            get { return _KardexID; }
            set { _KardexID = value; }
        }
        public string AlmacenID
        {
            get { return _AlmacenID; }
            set { _AlmacenID = value; }
        }
        public string AlmacenExterno
        {
            get { return _AlmacenExterno; }
            set { _AlmacenExterno = value; }
        }
        public string ProductoID
        {
            get { return _ProductoID; }
            set { _ProductoID = value; }
        }
        public decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public int MovimientoID
        {
            get { return _MovimientoID; }
            set { _MovimientoID = value; }
        }
        public string NroDocumento
        {
            get { return _NroDocumento; }
            set { _NroDocumento = value; }
        }
        public string TipoComprobante
        {
            get { return _TipoComprobante; }
            set { _TipoComprobante = value; }
        }
        public string Serie
        {
            get { return _Serie; }
            set { _Serie = value; }
        }
        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }
        public string TipoOperacion
        {
            get { return _TipoOperacion; }
            set { _TipoOperacion = value; }
        }
        public decimal CostoUnitario
        {
            get { return _CostoUnitario; }
            set { _CostoUnitario = value; }
        }
        public string Ingreso
        {
            get { return _Ingreso; }
            set { _Ingreso = value; }
        }
        public int UsuarioID
        {
            get { return _UsuarioID; }
            set { _UsuarioID = value; }
        }
        public DateTime AudCrea
        {
            get { return _AudCrea; }
            set { _AudCrea = value; }
        }
    }
}

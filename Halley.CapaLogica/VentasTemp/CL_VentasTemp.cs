using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Halley.CapaDatos.VentasTemp;
using Halley.Configuracion;

namespace Halley.CapaLogica.VentasTemp
{
    public class CL_VentasTemp
    {

        public DataTable GetClientes()
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_VentasTemp.GetClientes();
            return dtTMP;
        }

        public DataTable GetProductos()
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_VentasTemp.GetProductos();
            return dtTMP;
        }

        public DataTable GetTipoDocumento()
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_VentasTemp.GetTipoDocumento();
            return dtTMP;
        }

        public DataTable GetSerieGuias(string EmpresaSede)
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_VentasTemp.GetSerieGuias(EmpresaSede);
            return dtTMP;
        }

        public DataTable GetCajasSede(string EmpresaSede)
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_VentasTemp.GetCajasSede(EmpresaSede);
            return dtTMP;
        }
        public DataTable GetDetalleVentasComprobante(DateTime FechaIni, DateTime FechaFin, int NumCaja, int UsuarioID)
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_VentasTemp.GetDetalleVentasComprobante(FechaIni, FechaFin, NumCaja, UsuarioID);
            return dtTMP;
        }

        public DataTable GetDetalleVentasPorProducto(DateTime FechaIni, DateTime FechaFin, int NumCaja, int UsuarioID, Int32 ArticuloId)
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_VentasTemp.GetDetalleVentasPorProducto(FechaIni, FechaFin, NumCaja, UsuarioID, ArticuloId);
            return dtTMP;
        }

        public void AnularGuia(string NumComprobante, int TipoDocumento)
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            objCD_VentasTemp.AnularGuia(NumComprobante, TipoDocumento);
        }

        public string InsertComprobante(string EmpresaSede, int NumCaja, int TipoDocumento, int GestorId, string Cliente, string Direccion, string Documento, string NroGuia, decimal Subtotal, decimal TotalIGV, int UsuarioID, string Serie, string xml)
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            string NumComprobante;
            NumComprobante = objCD_VentasTemp.InsertComprobante(EmpresaSede, NumCaja, TipoDocumento, GestorId, Cliente, Direccion, Documento, NroGuia, Subtotal, TotalIGV, UsuarioID, Serie, xml);
            return NumComprobante;
        }

        public DataTable GetUsuariosPerfil(int PerfilID)
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();
            dtTMP = objCD_VentasTemp.GetUsuariosPerfil(PerfilID);
            return dtTMP;
        }

        public void UpdatePrecioProducto(Int32 ArticuloId, decimal PrecioContado)
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            objCD_VentasTemp.UpdatePrecioProducto(ArticuloId, PrecioContado);
        }

        public Int32 InsertCliente(
            string Codigo,
            string Gestor,
            string Alias,
            int DistritoId,
            int ProvinciaId,
            int DepartamentoId,
            string Nombre1,
            string Nombre2,
            string Apellido1,
            string Apellido2,
            string Direccion,
            int DireccionViaId,
            string DireccionNombreVia,
            string DireccionNumero,
            string DireccionInterior,
            string Observaciones
            )
        {
            Int32 GestorId = 0;
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            GestorId = objCD_VentasTemp.InsertCliente(
            Codigo,
            Gestor,
            Alias,
            DistritoId,
            ProvinciaId,
            DepartamentoId,
            Nombre1,
            Nombre2,
            Apellido1,
            Apellido2,
            Direccion,
            DireccionViaId,
            DireccionNombreVia,
            DireccionNumero,
            DireccionInterior,
            Observaciones);
            return GestorId;
        }

        public DataSet GetUbicacion()
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();
            Ds = objCD_VentasTemp.GetUbicacion();
            return Ds;
        }

        public void UpdateSerieGuia(string EmpresaSede, int TipoDocumento, string Serie, Int32 Numero, int UsuarioID)
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            objCD_VentasTemp.UpdateSerieGuia(EmpresaSede, TipoDocumento, Serie, Numero, UsuarioID);
        }

        public void InsertSerieGuia(string EmpresaSede, int TipoDocumento, string Serie, Int32 Numero, int UsuarioID)
        {
            CD_VentasTemp objCD_VentasTemp = new CD_VentasTemp(AppSettings.GetConnectionString);
            objCD_VentasTemp.InsertSerieGuia(EmpresaSede, TipoDocumento, Serie, Numero, UsuarioID);
        }
    }
}

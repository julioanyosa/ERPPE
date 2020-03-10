using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Halley.CapaDatos.Ventas
{
    public class CD_Venta
    {

        string connectionString;

        public CD_Venta(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        public DataTable getVentaExterna(string EmpresaID, string SedeID, DateTime FecInicial, DateTime FecFinal)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_VentasExterna");

            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            SqlClient.AddInParameter(SqlCommand, "@FecIni", SqlDbType.Date, FecInicial);
            SqlClient.AddInParameter(SqlCommand, "@FecFin", SqlDbType.Date, FecFinal);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }
        public DataTable GetVentaDiferida(string Documento, string EmpresaID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.usp_get_VentaDiferida");

            SqlClient.AddInParameter(SqlCommand, "@NroDocumento", SqlDbType.VarChar, Documento);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public void InsertVenta(string AlmacenID, string ProductoID, decimal Cantidad, int Movimiento, int UsuarioID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommandVenta = SqlClient.GetStoredProcCommand("Ventas.usp_Insert_Venta");
                SqlClient.AddInParameter(SqlCommandVenta, "@AlmacenId", SqlDbType.Char, AlmacenID);
                SqlClient.AddInParameter(SqlCommandVenta, "@ProductoId", SqlDbType.VarChar, ProductoID);
                SqlClient.AddInParameter(SqlCommandVenta, "@Cantidad", SqlDbType.Decimal, Cantidad);
                SqlClient.AddInParameter(SqlCommandVenta, "@Movimiento", SqlDbType.TinyInt, Movimiento);
                SqlClient.AddInParameter(SqlCommandVenta, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.ExecuteNonQuery(SqlCommandVenta, tran);
                SqlCommandVenta.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void InsertVentaDiferida(string ProductoID, decimal Cantidad, string Tipo, string Documento, string Cliente, string Tipo_Entidad, string NroEntidad, string EmpresaID, string NomSede, int UsuarioID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommandVenta = SqlClient.GetStoredProcCommand("Ventas.usp_Insert_VentaDiferida");
                SqlClient.AddInParameter(SqlCommandVenta, "@ProductoId", SqlDbType.VarChar, ProductoID);
                SqlClient.AddInParameter(SqlCommandVenta, "@Cantidad", SqlDbType.Decimal, Cantidad);
                SqlClient.AddInParameter(SqlCommandVenta, "@Tipo_Documento", SqlDbType.Char, Tipo);
                SqlClient.AddInParameter(SqlCommandVenta, "@NroDocumento", SqlDbType.VarChar, Documento);
                SqlClient.AddInParameter(SqlCommandVenta, "@Cliente", SqlDbType.VarChar, Cliente);
                SqlClient.AddInParameter(SqlCommandVenta, "@Tipo_Entidad", SqlDbType.Char, Tipo_Entidad);
                SqlClient.AddInParameter(SqlCommandVenta, "@NroEntidad", SqlDbType.VarChar, NroEntidad);
                SqlClient.AddInParameter(SqlCommandVenta, "@EmpresaID", SqlDbType.Char, EmpresaID);
                SqlClient.AddInParameter(SqlCommandVenta, "@Sede", SqlDbType.Char, NomSede);
                SqlClient.AddInParameter(SqlCommandVenta, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.ExecuteNonQuery(SqlCommandVenta, tran);
                SqlCommandVenta.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetReservas(string ProductoID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetReservas");

            SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }


        public DataSet GetComprobante(string NumComprobante, int TipoComprobanteID)
        {
            DataSet dsPedido = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetComprobante");
            SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.TinyInt, TipoComprobanteID);

            dsPedido.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "Comprobante", "DetalleComprobante");
            return dsPedido;
        }

        public DataSet GetComprobante2(string NumComprobante, int TipoComprobanteID)
        {
            DataSet dsPedido = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetComprobante2");
            SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.TinyInt, TipoComprobanteID);

            dsPedido.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "Comprobante", "DetalleComprobante");
            return dsPedido;
        }

        public DataTable GetVendedores(string Sede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetVendedores");
            SqlClient.AddInParameter(SqlCommand, "@Sede", SqlDbType.Char, Sede);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable get_ReporteDiferencial()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_ReporteVentaDiferencial");


            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable get_ReporteConVales(string ProductoID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_ReporteConVales");
            SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public int GetNroTerminales(string SedeID)
        {
            int NroTerminales = 0;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetNroTerminales");
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);

            NroTerminales = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand));
            return NroTerminales;
        }

        public DataSet GetComprobanteNotaCredito(string NumComprobante, int TipoComprobanteID)
        {
            DataSet dsPedido = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetComprobanteNotaCredito");
            SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.TinyInt, TipoComprobanteID);

            dsPedido.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "Comprobante", "DetalleComprobante");
            return dsPedido;
        }

        public DataTable GetReservasRepProducto(DateTime FechaInicio, DateTime FechaFin, string ProductoID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetReservasRepProducto");
            SqlClient.AddInParameter(SqlCommand, "@FechaInicio", SqlDbType.SmallDateTime, FechaInicio);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetCajeros()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.usp_GetCajeros");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataSet GetDetalleVentasComprobante(DateTime FechaIni, DateTime FechaFin, int Cajero, string EmpresaID, string SedeID)
        {
            DataSet Ds = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[ventas].[usp_GetDetalleVentasComprobante]");
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@Cajero", SqlDbType.Int, Cajero);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            SqlCommand.CommandTimeout = 180;
            Ds.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "Comprobante", "Usuario");
            return Ds;
        }

        public DataTable GetVentasSede(DateTime FechaIni, DateTime FechaFin, string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.usp_GetVentasSede");
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.Date, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.Date, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetComprobantesAnulados(DateTime FechaIni, DateTime FechaFin, string EmpresaID, string SedeID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetComprobantesAnulados");
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetReservasEstadoPago(DateTime FechaIni, DateTime FechaFin, string EmpresaSede, string ProductoID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetReservasEstadoPago");
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
            SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetVentasPorProducto(DateTime FechaIni, DateTime FechaFin, string EmpresaID, string SedeID, string ProductoID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetVentasPorProducto");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.Date, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.Date, FechaFin);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetVentasVendedor(string SedeID, string EmpresaID, DateTime FechaIni, DateTime FechaFin, string Tipo)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetVentasVendedor");
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.Date, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.Date, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, Tipo);
            SqlCommand.CommandTimeout = 600;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetValesEmitidos(string EmpresaID, DateTime FechaIni, DateTime FechaFin)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[Usp_GetValesEmitidos]");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlCommand.CommandTimeout = 100;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }


        public DataTable GetDetalleCrearGuias(string NumComprobante, int TipoComprobanteID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetDetalleCrearGuias");
            SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.TinyInt, TipoComprobanteID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetServicios()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetServicios");
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetTiposVenta()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetTiposVenta");
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetTotalTicketPorCaja(int NumCaja, DateTime FechaIni, DateTime FechaFin, string EmpresaID, string SedeID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.usp_GetTotalTicketPorCaja");
            SqlClient.AddInParameter(SqlCommand, "@NumCaja", SqlDbType.Int, NumCaja);
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetVentasNavidenhasPorFecha(DateTime FecIni, DateTime FecFin)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetVentasNavidenhasPorFecha");
            SqlClient.AddInParameter(SqlCommand, "@FecIni", SqlDbType.SmallDateTime, FecIni);
            SqlClient.AddInParameter(SqlCommand, "@FecFin", SqlDbType.SmallDateTime, FecFin);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetTicketsAnulados(DateTime FecIni, DateTime FecFin, string EmpresaID, string SedeID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetTicketsAnulados");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            SqlClient.AddInParameter(SqlCommand, "@FecIni", SqlDbType.SmallDateTime, FecIni);
            SqlClient.AddInParameter(SqlCommand, "@FecFin", SqlDbType.SmallDateTime, FecFin);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetAnulados(DateTime FecIni, DateTime FecFin, string EmpresaID, string SedeID, int UsuarioID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[Usp_GetAnulados]");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            SqlClient.AddInParameter(SqlCommand, "@FecIni", SqlDbType.SmallDateTime, FecIni);
            SqlClient.AddInParameter(SqlCommand, "@FecFin", SqlDbType.SmallDateTime, FecFin);
            SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
            SqlCommand.CommandTimeout = 200;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }


        public DataTable GetDatosTicketera(string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[Usp_GetDatosTicketera]");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetAdministradores()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[usp_GetAdministradores]");
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetAuditoriaPrecio(string EmpresaSede, DateTime FechaInicio, DateTime FechaFin, int UsuarioID, string ProductoID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[usp_GetAuditoriaPrecio]");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
            SqlClient.AddInParameter(SqlCommand, "@FechaInicio", SqlDbType.SmallDateTime, FechaInicio);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
            SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetDespachos(string SedeID, int TipoVentaID, int Minutos)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetDespachos]");
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            SqlClient.AddInParameter(SqlCommand, "@TipoVentaID", SqlDbType.Int, TipoVentaID);
            SqlClient.AddInParameter(SqlCommand, "@Minutos", SqlDbType.Int, Minutos);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetPrecioVariado()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[Usp_GetPrecioVariado]");
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetProductosImpuestoBolsa()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetProductosImpuestoBolsa");
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public bool ExisteVale(string Numval)
        {
            bool Valor = true;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[Usp_VerificarValeConsumo]");
            SqlClient.AddInParameter(SqlCommand, "@Numvale", SqlDbType.Char, Numval);
            Valor = Convert.ToBoolean(SqlClient.ExecuteScalar(SqlCommand));
            return Valor;
        }

        public void InsertCierre(int Cajero, string EmpresaSede, DateTime Fecha, decimal DineroEntregado, decimal Ingreso, decimal Egreso, decimal TotalPagos, decimal TotalEntregar, int UsuarioID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommandVenta = SqlClient.GetStoredProcCommand("[Ventas].[Usp_InsertCierre]");
                SqlClient.AddInParameter(SqlCommandVenta, "@Cajero", SqlDbType.Int, Cajero);
                SqlClient.AddInParameter(SqlCommandVenta, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                SqlClient.AddInParameter(SqlCommandVenta, "@Fecha", SqlDbType.SmallDateTime, Fecha);
                SqlClient.AddInParameter(SqlCommandVenta, "@DineroEntregado", SqlDbType.Decimal, DineroEntregado);
                SqlClient.AddInParameter(SqlCommandVenta, "@Ingreso", SqlDbType.Decimal, Ingreso);
                SqlClient.AddInParameter(SqlCommandVenta, "@Egreso", SqlDbType.Decimal, Egreso);
                SqlClient.AddInParameter(SqlCommandVenta, "@TotalPagos", SqlDbType.Decimal, TotalPagos);
                SqlClient.AddInParameter(SqlCommandVenta, "@TotalEntregar", SqlDbType.Decimal, TotalEntregar);
                SqlClient.AddInParameter(SqlCommandVenta, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.ExecuteNonQuery(SqlCommandVenta, tran);
                SqlCommandVenta.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetCierre(int Cajero, string EmpresaSede, DateTime Fecha)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[Usp_GetCierre]");
            SqlClient.AddInParameter(SqlCommand, "@Cajero", SqlDbType.Int, Cajero);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
            SqlClient.AddInParameter(SqlCommand, "@Fecha", SqlDbType.SmallDateTime, Fecha);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetVerCorrelativo(string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[usp_GetVerCorrelativo]");

            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable ValorVale(Int32 NUMVALE)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[Usp_get_ValorVale]");

            SqlClient.AddInParameter(SqlCommand, "@NUMVALE", SqlDbType.Int, NUMVALE);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable VerificarCierre(Int32 Caja)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[VENTAS].[Usp_GetVerificarCierre]");

            SqlClient.AddInParameter(SqlCommand, "@Caja", SqlDbType.Int, Caja);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetVentasCliente(int Accion, DateTime FechaIni, DateTime FechaFin, int ClienteID, string EmpresaID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[usp_GetVentasCliente]");

            SqlClient.AddInParameter(SqlCommand, "@Accion", SqlDbType.Int, Accion);
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.Date, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.Date, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@ClienteID", SqlDbType.Int, ClienteID);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }


        public DataSet GetDetalleVentasComprobante2(DateTime FechaIni, DateTime FechaFin, int Cajero, string EmpresaID, string SedeID)
        {
            DataSet Ds = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[ventas].[usp_GetDetalleVentasComprobante2]");
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@Cajero", SqlDbType.Int, Cajero);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            SqlCommand.CommandTimeout = 180;
            Ds.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "Comprobante", "Usuario");
            return Ds;
        }

        public void GenerarFE(int TipoComprobanteId, string NumComprobante, DateTime? fini, DateTime? ffin, string EmpresaID, string IP)
        {
            try
            {
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.GenerarFE");
                SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteId", SqlDbType.Int, TipoComprobanteId);
                SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
                SqlClient.AddInParameter(SqlCommand, "@fini", SqlDbType.DateTime, fini);
                SqlClient.AddInParameter(SqlCommand, "@ffin", SqlDbType.DateTime, ffin);
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@IP", SqlDbType.Char, IP);


                SqlCommand.CommandTimeout = 180;
                SqlClient.ExecuteNonQuery(SqlCommand);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public Boolean HABILITADOFE()
        {
            Boolean habilitado = true;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("VENTAS.HABILITADOFE");
            //SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);

            habilitado = Convert.ToBoolean(SqlClient.ExecuteScalar(SqlCommand));
            return habilitado;
        }


        public Boolean HABILITADOFE2(string EmpresaID)
        {
            Boolean habilitado = true;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("VENTAS.HABILITADOFE2");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);

            habilitado = Convert.ToBoolean(SqlClient.ExecuteScalar(SqlCommand));
            return habilitado;
        }

        public DataSet GetComprobanteFE(int? TipoComprobanteID, string NumComprobante, string EmpresaID, DateTime? Fecha, string Tipo)
        {
            DataSet ds = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.GenerarFE_SUNAT");

            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.Int, TipoComprobanteID);
            SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@Fecha", SqlDbType.Date, Fecha);
            SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, Tipo);
            ds = SqlClient.ExecuteDataSet(SqlCommand);
            return ds;
        }

        public void ActualizarBajaFE(int BajaFEId, DateTime FechaReferencia, Int64 TicketSunat, string MensajeSunat)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommandVenta = SqlClient.GetStoredProcCommand("Ventas.ActualizarBajaFE");
                SqlClient.AddInParameter(SqlCommandVenta, "@BajaFEId", SqlDbType.Int, BajaFEId);
                SqlClient.AddInParameter(SqlCommandVenta, "@FechaReferencia", SqlDbType.Date, FechaReferencia);
                SqlClient.AddInParameter(SqlCommandVenta, "@TicketSunat", SqlDbType.BigInt, TicketSunat);
                SqlClient.AddInParameter(SqlCommandVenta, "@MensajeSunat", SqlDbType.VarChar, MensajeSunat);
                SqlClient.ExecuteNonQuery(SqlCommandVenta, tran);
                SqlCommandVenta.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public DataSet DatosAnulacionFE(int? TipoComprobanteID, string NumComprobante, string EmpresaID, string TipoSunat, int UsuarioID)
        {
            DataSet ds = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.DatosAnulacionFE");
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.Int, TipoComprobanteID);
            SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@TipoSunat", SqlDbType.Char, TipoSunat);
            SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
            ds = SqlClient.ExecuteDataSet(SqlCommand);
            return ds;
        }


        public DataSet ObtenerParaImpresion(Int64 ComprobanteId)
        {
            DataSet dsPedido = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ObtenerParaImpresion");
            SqlClient.AddInParameter(SqlCommand, "@ComprobanteId", SqlDbType.BigInt, ComprobanteId);

            dsPedido.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "Comprobante", "DetalleComprobante");
            return dsPedido;
        }


        public DataSet ObtenerDatosCliente(string RUC)
        {
            DataSet DS = new DataSet();
            try
            {
                DataSet ds = new DataSet();
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ObtenerDatosCliente");
                SqlClient.AddInParameter(SqlCommand, "@RUC", SqlDbType.VarChar, RUC);
                ds = SqlClient.ExecuteDataSet(SqlCommand);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    if (RUC.Length == 8)
                    {
                        var url = "https://www.sunat.gob.pe/ol-ti-itfisdenreg/itfisdenreg.htm?accion=obtenerDatosDni&numDocumento=" + RUC;
                        var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

                        using (var response = webrequest.GetResponse())
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            var result = reader.ReadToEnd();

                            dynamic data = JObject.Parse(result);

                            if (data.lista != null)
                            {

                                var json = JsonConvert.SerializeObject(data.lista);
                                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));



                                dt.Columns.Add("FUENTE", typeof(string));
                                dt.Rows[0]["FUENTE"] = "SUNAT";

                                dt.Columns.Add("NroDocumento", typeof(string));
                                dt.Columns.Add("DepartamentoId", typeof(int));
                                dt.Columns.Add("ProvinciaId", typeof(int));
                                dt.Columns.Add("DistritoId", typeof(int));
                                dt.Columns.Add("ClienteID", typeof(int));

                                dt.Rows[0]["NroDocumento"] = RUC;
                                dt.Rows[0]["DepartamentoId"] = 25;
                                dt.Rows[0]["ProvinciaId"] = 191;
                                dt.Rows[0]["DistritoId"] = 1815;
                                dt.Rows[0]["ClienteID"] = 0;

                                DS.Tables.Add(dt);
                            }


                        }
                    }
                    else if (RUC.Length == 11)
                    {
                        var url = "https://www.sunat.gob.pe/ol-ti-itfisdenreg/itfisdenreg.htm?accion=obtenerDatosRuc&nroRuc=" + RUC;
                        var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

                        using (var response = webrequest.GetResponse())
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            var result = reader.ReadToEnd();

                            dynamic data = JObject.Parse(result);

                            if (data.lista != null)
                            {

                                var json = JsonConvert.SerializeObject(data.lista);
                                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

                                dt.Columns.Add("FUENTE", typeof(string));
                                dt.Rows[0]["FUENTE"] = "SUNAT";

                                DataTable dtTmp1 = new DataTable();
                                SqlDatabase SqlClient1 = new SqlDatabase(connectionString);
                                DbCommand SqlCommand1 = SqlClient1.GetStoredProcCommand("[VENTAS].[ObtenerUbigeo]");

                                string ubigeo = dt.Rows[0]["iddepartamento"].ToString() + dt.Rows[0]["idprovincia"].ToString() + dt.Rows[0]["iddistrito"].ToString();
                                SqlClient1.AddInParameter(SqlCommand1, "@ubigeo", SqlDbType.Char, ubigeo);
                                dtTmp1.Load(SqlClient1.ExecuteReader(SqlCommand1));

                                dt.Columns.Add("NroDocumento", typeof(string));
                                dt.Columns.Add("DepartamentoId", typeof(int));
                                dt.Columns.Add("ProvinciaId", typeof(int));
                                dt.Columns.Add("DistritoId", typeof(int));
                                dt.Columns.Add("ClienteID", typeof(int));


                                dt.Rows[0]["NroDocumento"] = RUC;
                                if (dtTmp1.Rows.Count > 0)
                                {
                                    dt.Rows[0]["DepartamentoId"] = Convert.ToInt32(dtTmp1.Rows[0]["DepartamentoId"]);
                                    dt.Rows[0]["ProvinciaId"] = Convert.ToInt32(dtTmp1.Rows[0]["ProvinciaId"]);
                                    dt.Rows[0]["DistritoId"] = Convert.ToInt32(dtTmp1.Rows[0]["DistritoId"]);
                                }
                                else
                                {
                                    dt.Rows[0]["DepartamentoId"] = 25;
                                    dt.Rows[0]["ProvinciaId"] = 191;
                                    dt.Rows[0]["DistritoId"] = 1815;
                                }
                                dt.Rows[0]["ClienteID"] = 0;

                                DS.Tables.Add(dt);
                            }

                        }
                    }
                }
                else
                {
                    DS = ds;
                }

                if (DS.Tables.Count == 0)
                    DS = ds;

                return DS;

            }
            catch (Exception ex)
            {
                DataSet ds = new DataSet();
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ObtenerDatosCliente");
                SqlClient.AddInParameter(SqlCommand, "@RUC", SqlDbType.VarChar, RUC);
                ds = SqlClient.ExecuteDataSet(SqlCommand);


                return ds;
            }

        }

        public void InsertarClientesSunat(string ruta)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommandVenta = SqlClient.GetStoredProcCommand("Ventas.InsertarClientesSunat");
                SqlCommandVenta.CommandTimeout = 1200;
                SqlClient.AddInParameter(SqlCommandVenta, "@ruta", SqlDbType.VarChar, ruta);               
                SqlClient.ExecuteNonQuery(SqlCommandVenta, tran);
                SqlCommandVenta.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDatosSucursal(string EmpresaID, string SedeID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.ObtenerDatosSucursal");

            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }


    }
}

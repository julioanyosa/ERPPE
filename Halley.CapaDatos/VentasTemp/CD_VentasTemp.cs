using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Halley.CapaDatos.VentasTemp
{
    public class CD_VentasTemp
    {

        string connectionString;
        public CD_VentasTemp(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

        public DataTable GetClientes()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetClientes");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetProductos()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.GetProductos");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetTipoDocumento()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("ventas.Usp_GetTipoDocumento");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetSerieGuias(string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("ventas.Usp_GetSerieGuias");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetUsuariosPerfil(int PerfilID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[usp_GetUsuariosPerfil]");
            SqlClient.AddInParameter(SqlCommand, "@PerfilID", SqlDbType.TinyInt, PerfilID);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetCajasSede(string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[usp_GetCajasSede]");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetDetalleVentasComprobante(DateTime FechaIni, DateTime FechaFin, int NumCaja, int UsuarioID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[ventas].[usp_GetDetalleVentasComprobante]");
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@NumCaja", SqlDbType.Int, NumCaja);
            SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
            SqlCommand.CommandTimeout = 180;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetDetalleVentasPorProducto(DateTime FechaIni, DateTime FechaFin, int NumCaja, int UsuarioID, Int32 ArticuloId)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[ventas].[usp_GetDetalleVentasPorProducto]");
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@NumCaja", SqlDbType.Int, NumCaja);
            SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
            SqlClient.AddInParameter(SqlCommand, "@ArticuloId", SqlDbType.Int, ArticuloId);
            SqlCommand.CommandTimeout = 180;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public void AnularGuia(string NumComprobante, int TipoDocumento)
        {
            try
            {
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[ventas].[Usp_AnularGuia]");
                SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
                SqlClient.AddInParameter(SqlCommand, "@TipoDocumento", SqlDbType.Int, TipoDocumento);
                SqlCommand.CommandTimeout = 180;
                SqlClient.ExecuteNonQuery(SqlCommand);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        

        public string InsertComprobante(string EmpresaSede, int NumCaja, int TipoDocumento, int GestorId, string Cliente, string Direccion, string Documento, string NroGuia, decimal Subtotal, decimal TotalIGV, int UsuarioID, string Serie, string xml)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_InsertComprobante");

                SqlClient.AddInParameter(SqlCommand, "@TipoDocumento", SqlDbType.Int, TipoDocumento);
                SqlClient.AddInParameter(SqlCommand, "@NumCaja", SqlDbType.Int, NumCaja);
                SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                SqlClient.AddInParameter(SqlCommand, "@GestorId", SqlDbType.Int, GestorId);
                SqlClient.AddInParameter(SqlCommand, "@Cliente", SqlDbType.VarChar, Cliente);
                SqlClient.AddInParameter(SqlCommand, "@Direccion", SqlDbType.VarChar, Direccion);
                SqlClient.AddInParameter(SqlCommand, "@Documento", SqlDbType.VarChar, Documento);
                SqlClient.AddInParameter(SqlCommand, "@NroGuia", SqlDbType.VarChar, NroGuia);
                SqlClient.AddInParameter(SqlCommand, "@Subtotal", SqlDbType.Decimal, Subtotal);
                SqlClient.AddInParameter(SqlCommand, "@TotalIGV", SqlDbType.Decimal, TotalIGV);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommand, "@Serie", SqlDbType.Char, Serie);

                string NumComprobante;
                NumComprobante = SqlClient.ExecuteScalar(SqlCommand).ToString();

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("ventas.Usp_InsertXMLDetalleComprobante");
                SqlClient.AddInParameter(SqlCommandAccess, "@XML", SqlDbType.Xml, xml);
                SqlClient.AddInParameter(SqlCommandAccess, "@NumComprobante", SqlDbType.Char, NumComprobante);
                SqlClient.AddInParameter(SqlCommandAccess, "@TipoDocumento", SqlDbType.Int, TipoDocumento);
                SqlClient.ExecuteNonQuery(SqlCommandAccess, tran);

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();

                return NumComprobante;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public void UpdatePrecioProducto(Int32 ArticuloId, decimal PrecioContado)
        {
            try
            {
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[ventas].[UpdatePrecioProducto]");
                SqlClient.AddInParameter(SqlCommand, "@ArticuloId", SqlDbType.Int, ArticuloId);
                SqlClient.AddInParameter(SqlCommand, "@PrecioContado", SqlDbType.Decimal, PrecioContado);
                SqlCommand.CommandTimeout = 180;
                SqlClient.ExecuteNonQuery(SqlCommand);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public DataSet GetUbicacion()
        {
            DataSet ds = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            //Departamento
            DbCommand SqlCommand1 = SqlClient.GetStoredProcCommand("ventas.Usp_GetDepartamento");
            SqlCommand1.CommandTimeout = 200;
            ds.Load(SqlClient.ExecuteReader(SqlCommand1), LoadOption.PreserveChanges, "Departamento");
            //Distrito
            DbCommand SqlCommand2 = SqlClient.GetStoredProcCommand("ventas.Usp_GetDistrito");
            SqlCommand2.CommandTimeout = 200;
            ds.Load(SqlClient.ExecuteReader(SqlCommand2), LoadOption.PreserveChanges, "Distrito");
            //Provincia
            DbCommand SqlCommand3 = SqlClient.GetStoredProcCommand("ventas.Usp_GetProvincia");
            SqlCommand3.CommandTimeout = 200;
            ds.Load(SqlClient.ExecuteReader(SqlCommand3), LoadOption.PreserveChanges, "Provincia");
            //Via
            DbCommand SqlCommand4 = SqlClient.GetStoredProcCommand("ventas.Usp_GetVia");
            SqlCommand4.CommandTimeout = 200;
            ds.Load(SqlClient.ExecuteReader(SqlCommand4), LoadOption.PreserveChanges, "Via");

            return ds;
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
            try
            {

                Int32 GestorId = 0;
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("ventas.Usp_InsertCliente");
                SqlClient.AddInParameter(SqlCommand, "@Codigo", SqlDbType.NVarChar, Codigo);
                SqlClient.AddInParameter(SqlCommand, "@Gestor", SqlDbType.NVarChar, Gestor);
                SqlClient.AddInParameter(SqlCommand, "@Alias", SqlDbType.NVarChar, Alias);
                SqlClient.AddInParameter(SqlCommand, "@DistritoId", SqlDbType.Int, DistritoId);
                SqlClient.AddInParameter(SqlCommand, "@ProvinciaId", SqlDbType.Int, ProvinciaId);
                SqlClient.AddInParameter(SqlCommand, "@DepartamentoId", SqlDbType.Int, DepartamentoId);
                SqlClient.AddInParameter(SqlCommand, "@Nombre1", SqlDbType.NVarChar, Nombre1);
                SqlClient.AddInParameter(SqlCommand, "@Nombre2", SqlDbType.NVarChar, Nombre2);
                SqlClient.AddInParameter(SqlCommand, "@Apellido1", SqlDbType.NVarChar, Apellido1);
                SqlClient.AddInParameter(SqlCommand, "@Apellido2", SqlDbType.NVarChar, Apellido2);
                SqlClient.AddInParameter(SqlCommand, "@Direccion", SqlDbType.NVarChar, Direccion);
                SqlClient.AddInParameter(SqlCommand, "@DireccionViaId", SqlDbType.Int, DireccionViaId);
                SqlClient.AddInParameter(SqlCommand, "@DireccionNombreVia", SqlDbType.NVarChar, DireccionNombreVia);
                SqlClient.AddInParameter(SqlCommand, "@DireccionNumero", SqlDbType.NVarChar, DireccionNumero);
                SqlClient.AddInParameter(SqlCommand, "@DireccionInterior", SqlDbType.NVarChar, DireccionInterior);
                SqlClient.AddInParameter(SqlCommand, "@Observaciones", SqlDbType.NVarChar, Observaciones);
                
                SqlCommand.CommandTimeout = 180;
                GestorId = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand));
                return GestorId;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public void UpdateSerieGuia(string EmpresaSede, int TipoDocumento, string Serie, Int32 Numero, int UsuarioID)
        {
            try
            {
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[ventas].[Usp_UpdateSerieGuia]");
                SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                SqlClient.AddInParameter(SqlCommand, "@TipoDocumento", SqlDbType.Int, TipoDocumento);
                SqlClient.AddInParameter(SqlCommand, "@Serie", SqlDbType.Char, Serie);
                SqlClient.AddInParameter(SqlCommand, "@Numero", SqlDbType.Int, Numero);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                                
                SqlCommand.CommandTimeout = 180;
                SqlClient.ExecuteNonQuery(SqlCommand);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public void InsertSerieGuia(string EmpresaSede, int TipoDocumento, string Serie,  Int32 Numero, int UsuarioID)
        {
            try
            {
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[ventas].[Usp_InsertSerieGuia]");
                SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                SqlClient.AddInParameter(SqlCommand, "@TipoDocumento", SqlDbType.Int, TipoDocumento);
                SqlClient.AddInParameter(SqlCommand, "@Serie", SqlDbType.Char, Serie);
                SqlClient.AddInParameter(SqlCommand, "@Numero", SqlDbType.Int, Numero);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);

                SqlCommand.CommandTimeout = 180;
                SqlClient.ExecuteNonQuery(SqlCommand);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

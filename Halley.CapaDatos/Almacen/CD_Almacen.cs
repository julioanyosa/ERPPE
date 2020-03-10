using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Halley.CapaDatos.Almacen
{
    public class CD_Almacen
    {
        string connectionString;

        public CD_Almacen(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        public DataTable GetMovimiento()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_get_Movimiento");
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }


        public DataTable ObtenerAlmacen(string EmpresaID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[usp_get_Almacen]");

            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }
        public DataTable GetAlmacenCadenaStock(string Cadena, string ProductoID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetAlmacenCadenaStock]");

            SqlClient.AddInParameter(SqlCommand, "@Cadena", SqlDbType.VarChar, Cadena);
            SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetAlmacenCadena2(string Cadena)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetAlmacenCadena]");

            SqlClient.AddInParameter(SqlCommand, "@Cadena", SqlDbType.VarChar, Cadena);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetProductoAlmacenCadena(string cadena,string ProductoID,string Tipo)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_get_Producto_Por_AlmacenCadena");

            SqlClient.AddInParameter(SqlCommand, "@Cadena", SqlDbType.VarChar, cadena);
            SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
            SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, Tipo);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable Get_GuiaRemisionVenta(string Documento)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_Get_GuiaRemisionVenta_Por_Factura");

            SqlClient.AddInParameter(SqlCommand, "@NroFactura", SqlDbType.VarChar, Documento);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public bool UpdateStockSustraccion(string AlmacenID, string ProductoID, decimal StockSustraendo, string Tipo, string AlmacenExterno, int MovimientoID, string TipoComprobante, string Serie, int ?Numero, string TipoOperacion, int UsuarioID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                bool Valor;
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_UpdateStockSustraccion");
                SqlClient.AddInParameter(SqlCommandAccess, "@AlmacenID", SqlDbType.Char, AlmacenID);
                SqlClient.AddInParameter(SqlCommandAccess, "@ProductoID", SqlDbType.VarChar, ProductoID);
                SqlClient.AddInParameter(SqlCommandAccess, "@StockSustraendo", SqlDbType.Decimal, StockSustraendo);
                SqlClient.AddInParameter(SqlCommandAccess, "@Tipo", SqlDbType.Char, Tipo);
                SqlClient.AddInParameter(SqlCommandAccess, "@AlmacenExterno", SqlDbType.Char, AlmacenExterno);
                SqlClient.AddInParameter(SqlCommandAccess, "@MovimientoID", SqlDbType.TinyInt, MovimientoID);
                SqlClient.AddInParameter(SqlCommandAccess, "@TipoComprobante", SqlDbType.Char, TipoComprobante);
                SqlClient.AddInParameter(SqlCommandAccess, "@Serie", SqlDbType.Char, Serie);
                SqlClient.AddInParameter(SqlCommandAccess, "@Numero", SqlDbType.Int, Numero);
                SqlClient.AddInParameter(SqlCommandAccess, "@TipoOperacion", SqlDbType.Char, TipoOperacion);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                Valor = Convert.ToBoolean(SqlClient.ExecuteScalar(SqlCommandAccess, tran));

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();
                return Valor;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }
        public void UpdateStockAdidion(string AlmacenIDLocal, string ProductoID, decimal StockAdicion, string NumRequerimiento, string Tipo)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                bool Valor;
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_UpdateStockAdidion");
                SqlClient.AddInParameter(SqlCommandAccess, "@AlmacenIDLocal", SqlDbType.Char, AlmacenIDLocal);
                SqlClient.AddInParameter(SqlCommandAccess, "@ProductoID", SqlDbType.VarChar, ProductoID);
                SqlClient.AddInParameter(SqlCommandAccess, "@StockAdicion", SqlDbType.Decimal, StockAdicion);
                SqlClient.AddInParameter(SqlCommandAccess, "@NumRequerimiento", SqlDbType.Char, NumRequerimiento);
                SqlClient.AddInParameter(SqlCommandAccess, "@Tipo", SqlDbType.Char, Tipo);

                Valor = Convert.ToBoolean(SqlClient.ExecuteScalar(SqlCommandAccess, tran));

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();
              }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }
        public bool UpdateXMLStockAlmacen(string xml, int MovimientoID, int UsuarioID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_UpdateXMLStockAlmacen");
                SqlClient.AddInParameter(SqlCommandAccess, "@XML", SqlDbType.Xml, xml);
                SqlClient.AddInParameter(SqlCommandAccess, "@MovimientoID", SqlDbType.TinyInt, MovimientoID);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.ExecuteNonQuery(SqlCommandAccess, tran);

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public DataTable ObtenerAlmacen2(string EmpresaID, string SedeID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[usp_get_Almacen2]");

            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public void InsertStockAlmacen(string AlmacenID, string ProductoID, decimal Stock, decimal StockDisponible, decimal StockMinimo, decimal StockMaximo, int UsuarioID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Almacen].[Usp_InsertStockAlmacen]");
                SqlClient.AddInParameter(SqlCommandAccess, "@AlmacenID", SqlDbType.Char, AlmacenID);
                SqlClient.AddInParameter(SqlCommandAccess, "@ProductoID", SqlDbType.VarChar, ProductoID);
                SqlClient.AddInParameter(SqlCommandAccess, "@Stock", SqlDbType.Decimal, Stock);
                SqlClient.AddInParameter(SqlCommandAccess, "@StockDisponible", SqlDbType.Decimal, StockDisponible);
                SqlClient.AddInParameter(SqlCommandAccess, "@StockMinimo", SqlDbType.Decimal, StockMinimo);
                SqlClient.AddInParameter(SqlCommandAccess, "@StockMaximo", SqlDbType.Decimal, StockMaximo);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.ExecuteNonQuery(SqlCommandAccess, tran);

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();


            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }
        public Int32 UpdateStockAlmacen(string AlmacenID, string ProductoID, decimal Stock, decimal StockDisponible, decimal StockMinimo, decimal StockMaximo, int UsuarioID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                Int32 FilasAfectadas = 0;
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Almacen].[Usp_UpdateStockAlmacen]");
                SqlClient.AddInParameter(SqlCommandAccess, "@AlmacenID", SqlDbType.Char, AlmacenID);
                SqlClient.AddInParameter(SqlCommandAccess, "@ProductoID", SqlDbType.VarChar, ProductoID);
                SqlClient.AddInParameter(SqlCommandAccess, "@Stock", SqlDbType.Decimal, Stock);
                SqlClient.AddInParameter(SqlCommandAccess, "@StockDisponible", SqlDbType.Decimal, StockDisponible);
                SqlClient.AddInParameter(SqlCommandAccess, "@StockMinimo", SqlDbType.Decimal, StockMinimo);
                SqlClient.AddInParameter(SqlCommandAccess, "@StockMaximo", SqlDbType.Decimal, StockMaximo);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                FilasAfectadas = Convert.ToInt32(SqlClient.ExecuteNonQuery(SqlCommandAccess, tran));

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();
                return FilasAfectadas;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public DataTable getAlmacenDesperdicio(string EmpresaID, string SedeID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[usp_get_AlmacenDesperdicio_Por_Sede]");

            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetStockProducto(string ProductoID, string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetStockProducto");

            SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public void InsertXMLDespachos(string Xml, int UsuarioID, int MovimientoID)
        {

            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertXMLDespachos");

                SqlClient.AddInParameter(SqlCommand, "@Xml", SqlDbType.Xml, Xml);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommand, "@MovimientoID", SqlDbType.Int, MovimientoID);
                SqlClient.ExecuteNonQuery(SqlCommand, tran);


                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommand.Dispose();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }
    }
}

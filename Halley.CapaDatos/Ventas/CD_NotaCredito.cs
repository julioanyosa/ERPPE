using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Halley.Entidad.Ventas;

namespace Halley.CapaDatos.Ventas
{
    public class CD_NotaCredito
    {

        string connectionString;

        public CD_NotaCredito(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        public Int32 UpdateSerieGuiaN(string EmpresaSede, string SerieGuiaNID, Int32 NotaCredito)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                Int32 FilasAfectadas = 0;
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Ventas].[Usp_UpdateSerieGuiaN]");
                SqlClient.AddInParameter(SqlCommandAccess, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                SqlClient.AddInParameter(SqlCommandAccess, "@SerieGuiaNID", SqlDbType.Char, SerieGuiaNID);
                SqlClient.AddInParameter(SqlCommandAccess, "@NotaCredito", SqlDbType.Int, NotaCredito);
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

        public string InsertNotaCredito(E_NotaCredito ObjE_NotaCredito, string EmpresaSede)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();
            string NotaCreditoID;

            try
            {
                DbCommand SqlCommandVenta = SqlClient.GetStoredProcCommand("Ventas.Usp_Insert_NotaCreditoNavideño");
                SqlClient.AddInParameter(SqlCommandVenta, "@ClienteID", SqlDbType.Int, ObjE_NotaCredito.ClienteID);                
                SqlClient.AddInParameter(SqlCommandVenta, "@NumComprobante", SqlDbType.Char, ObjE_NotaCredito.NumComprobante);
                SqlClient.AddInParameter(SqlCommandVenta, "@TipoComprobanteID", SqlDbType.Int, ObjE_NotaCredito.TipoComprobanteID);
                SqlClient.AddInParameter(SqlCommandVenta, "@Importe", SqlDbType.Decimal, ObjE_NotaCredito.Importe);
                SqlClient.AddInParameter(SqlCommandVenta, "@Concepto", SqlDbType.VarChar, ObjE_NotaCredito.Concepto);
                SqlClient.AddInParameter(SqlCommandVenta, "@UsuarioID", SqlDbType.Int, ObjE_NotaCredito.UsuarioID);
                SqlClient.AddInParameter(SqlCommandVenta, "@SedeID", SqlDbType.Char, ObjE_NotaCredito.SedeID);                
                SqlClient.AddInParameter(SqlCommandVenta, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                NotaCreditoID = Convert.ToString(SqlClient.ExecuteScalar(SqlCommandVenta, tran));
                SqlCommandVenta.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                return NotaCreditoID;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

 
        }

        public string InsertNotaCredito(E_NotaCredito ObjE_NotaCredito, string XMLDetalle, string EmpresaSede,bool ActualizaStock)
         {
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();
             DbTransaction tran = tCnn.BeginTransaction();
             string NotaCreditoID;
             try
             {
                 DbCommand SqlCommandVenta = SqlClient.GetStoredProcCommand("Ventas.Usp_InsertNotaCredito");
                 SqlClient.AddInParameter(SqlCommandVenta, "@ClienteID", SqlDbType.Int, ObjE_NotaCredito.ClienteID);
                 SqlClient.AddInParameter(SqlCommandVenta, "@NumCaja", SqlDbType.Int, ObjE_NotaCredito.NumCaja);
                 SqlClient.AddInParameter(SqlCommandVenta, "@NumComprobante", SqlDbType.Char, ObjE_NotaCredito.NumComprobante);
                 SqlClient.AddInParameter(SqlCommandVenta, "@TipoComprobanteID", SqlDbType.Int, ObjE_NotaCredito.TipoComprobanteID);
                 SqlClient.AddInParameter(SqlCommandVenta, "@Importe", SqlDbType.Decimal, ObjE_NotaCredito.Importe);
                 SqlClient.AddInParameter(SqlCommandVenta, "@Concepto", SqlDbType.VarChar, ObjE_NotaCredito.Concepto);
                 SqlClient.AddInParameter(SqlCommandVenta, "@UsuarioID", SqlDbType.Int, ObjE_NotaCredito.UsuarioID);
                 SqlClient.AddInParameter(SqlCommandVenta, "@SedeID", SqlDbType.Char, ObjE_NotaCredito.SedeID);
                 SqlClient.AddInParameter(SqlCommandVenta, "@XMLDetalle", SqlDbType.Xml, XMLDetalle);
                 SqlClient.AddInParameter(SqlCommandVenta, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                 SqlClient.AddInParameter(SqlCommandVenta, "@ActualizaStock", SqlDbType.Bit, ActualizaStock);
                 SqlClient.AddInParameter(SqlCommandVenta, "@Descuento", SqlDbType.Decimal, ObjE_NotaCredito.descuento);

                 NotaCreditoID = Convert.ToString(SqlClient.ExecuteScalar(SqlCommandVenta, tran));
                 SqlCommandVenta.Dispose();

                 tran.Commit();
                 tCnn.Close();
                 tCnn.Dispose();
                 return NotaCreditoID;
             }
             catch (Exception ex)
             {
                 tran.Rollback();
                 throw new Exception(ex.Message);
             }
         }

        public string InsertNotaCreditoI(E_NotaCredito ObjE_NotaCredito, string EmpresaSede)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();
            string NotaCreditoID;
            try
            {
                DbCommand SqlCommandVenta = SqlClient.GetStoredProcCommand("Ventas.Usp_InsertNotaCreditoI");
                SqlClient.AddInParameter(SqlCommandVenta, "@ClienteID", SqlDbType.Int, ObjE_NotaCredito.ClienteID);
                SqlClient.AddInParameter(SqlCommandVenta, "@NumCaja", SqlDbType.Int, ObjE_NotaCredito.NumCaja);
                SqlClient.AddInParameter(SqlCommandVenta, "@NumComprobante", SqlDbType.Char, ObjE_NotaCredito.NumComprobante);
                SqlClient.AddInParameter(SqlCommandVenta, "@TipoComprobanteID", SqlDbType.Int, ObjE_NotaCredito.TipoComprobanteID);
                SqlClient.AddInParameter(SqlCommandVenta, "@Importe", SqlDbType.Decimal, ObjE_NotaCredito.Importe);
                SqlClient.AddInParameter(SqlCommandVenta, "@Concepto", SqlDbType.VarChar, ObjE_NotaCredito.Concepto);
                SqlClient.AddInParameter(SqlCommandVenta, "@UsuarioID", SqlDbType.Int, ObjE_NotaCredito.UsuarioID);
                SqlClient.AddInParameter(SqlCommandVenta, "@SedeID", SqlDbType.Char, ObjE_NotaCredito.SedeID);
                SqlClient.AddInParameter(SqlCommandVenta, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                SqlClient.AddInParameter(SqlCommandVenta, "@Descuento", SqlDbType.Decimal, ObjE_NotaCredito.descuento);

                NotaCreditoID = Convert.ToString(SqlClient.ExecuteScalar(SqlCommandVenta, tran));
                SqlCommandVenta.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                return NotaCreditoID;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }



    }
}

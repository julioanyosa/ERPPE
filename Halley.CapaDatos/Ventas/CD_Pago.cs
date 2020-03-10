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
    public class CD_Pago
    {

        string connectionString;

        public CD_Pago(string ConnectionString)
        {
            connectionString = ConnectionString;
        }



        public DataTable getventasprueba()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[Usp_getventasprueba]");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }


        public DataTable GetComprobantesCredito(Int32 CreditoID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetComprobantesCredito");

            SqlClient.AddInParameter(SqlCommand, "@CreditoID", SqlDbType.Int, CreditoID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataSet GetPagosBoleta(string NumComprobante, Int32 TipoComprobanteID)
        {
            DataSet Ds = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetPagosBoleta");

            SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.TinyInt, TipoComprobanteID);
            Ds.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "Pago", "Comprobante");
            return Ds;
        }

        public DataTable GetCreditosTotal(Int32 ClienteID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetCreditosTotal");

            SqlClient.AddInParameter(SqlCommand, "@ClienteID", SqlDbType.Int, ClienteID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public Int32 InsertPago(E_Pago ObjPago)
        {
            Int32 PagoID = 0;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_Insert_PagoNavideño");
                SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, ObjPago.NumComprobante);
                SqlClient.AddInParameter(SqlCommand, "@TipoComprobante", SqlDbType.Int, ObjPago.TipoComprobanteID);
                SqlClient.AddInParameter(SqlCommand, "@Importe", SqlDbType.Decimal, ObjPago.Importe);
                SqlClient.AddInParameter(SqlCommand, "@FormaPago", SqlDbType.Int, ObjPago.FormaPagoID);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjPago.UsuarioID);

                PagoID = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand, tran));
                SqlCommand.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();

                return PagoID;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public Int32 InsertPago(E_Pago ObjPago, E_NotaIngreso ObjNotaIngreso, int EstadoID)
        {
            Int32 NotaIngresoID = 0;
            try
            {

                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_InsertPago2");

                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, ObjNotaIngreso.EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@FormaPagoID", SqlDbType.TinyInt, ObjPago.FormaPagoID);
                SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, ObjNotaIngreso.Tipo);
                SqlClient.AddInParameter(SqlCommand, "@Numcaja", SqlDbType.Int, ObjNotaIngreso.Numcaja);
                SqlClient.AddInParameter(SqlCommand, "@Observacion", SqlDbType.VarChar, ObjNotaIngreso.Observacion);
                SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, ObjPago.NumComprobante);
                SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.TinyInt, ObjPago.TipoComprobanteID);
                SqlClient.AddInParameter(SqlCommand, "@LugarPago", SqlDbType.Char, ObjNotaIngreso.LugarPago);
                SqlClient.AddInParameter(SqlCommand, "@Importe", SqlDbType.Decimal, ObjPago.Importe);
                SqlClient.AddInParameter(SqlCommand, "@ClienteID", SqlDbType.Int, ObjNotaIngreso.ClienteID);
                SqlClient.AddInParameter(SqlCommand, "@Estado", SqlDbType.TinyInt, ObjNotaIngreso.Estado);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjPago.UsuarioID);

                SqlClient.AddInParameter(SqlCommand, "@EstadoID", SqlDbType.Int, EstadoID);
                NotaIngresoID = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NotaIngresoID;
        }

        public Int32 UpdateXMLEstadoComprobantes(string Xml, E_NotaIngreso ObjNotaIngreso)
        {
            Int32 NotaIngresoID = 0;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            
            DbTransaction tran = tCnn.BeginTransaction();
            
            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_UpdateXMLEstadoComprobantes");

                SqlClient.AddInParameter(SqlCommand, "@Xml", SqlDbType.Xml, Xml);
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, ObjNotaIngreso.EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@FormaPagoID", SqlDbType.TinyInt, ObjNotaIngreso.FormaPagoID);
                SqlClient.AddInParameter(SqlCommand, "@Numcaja", SqlDbType.Int, ObjNotaIngreso.Numcaja);
                SqlClient.AddInParameter(SqlCommand, "@Observacion", SqlDbType.VarChar, ObjNotaIngreso.Observacion);
                SqlClient.AddInParameter(SqlCommand, "@LugarPago", SqlDbType.Char, ObjNotaIngreso.LugarPago);
                SqlClient.AddInParameter(SqlCommand, "@Importe", SqlDbType.Decimal, ObjNotaIngreso.Importe);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjNotaIngreso.UsuarioID);
                NotaIngresoID = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand, tran));

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommand.Dispose();
                return NotaIngresoID;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public DataSet GetPagosCredito(Int32 CreditoID)
        {
            DataSet Ds = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetPagosCredito");

            SqlClient.AddInParameter(SqlCommand, "@CreditoID", SqlDbType.Int, CreditoID);
            Ds.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "Comprobante", "ComprobanteTotal");
            return Ds;
        }

        public void InsertValeConsumo(E_ValeConsumo ObjValeConsumo)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_InsertValeConsumo");
                SqlClient.AddInParameter(SqlCommand, "@Numvale", SqlDbType.VarChar, ObjValeConsumo.Numvale);
                SqlClient.AddInParameter(SqlCommand, "@PagoID", SqlDbType.Int, ObjValeConsumo.PagoID);
                SqlClient.AddInParameter(SqlCommand, "@FechaEmision", SqlDbType.SmallDateTime, ObjValeConsumo.FechaEmision);
                SqlClient.AddInParameter(SqlCommand, "@Monto", SqlDbType.Decimal, ObjValeConsumo.Monto);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjValeConsumo.UsuarioID);

                SqlClient.ExecuteNonQuery(SqlCommand, tran);
                SqlCommand.Dispose();

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


        public DateTime GetFechaHoraServidor()
        {
            DateTime FechaHoraServidor;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetFechaHoraServidor");
            FechaHoraServidor = Convert.ToDateTime(SqlClient.ExecuteScalar(SqlCommand));
            return FechaHoraServidor;
        }

        public DataTable GetAdelantosCliente(Int32 ClienteID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[Usp_GetAdelantosCliente]");

            SqlClient.AddInParameter(SqlCommand, "@ClienteID", SqlDbType.Int, ClienteID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }
    }
}

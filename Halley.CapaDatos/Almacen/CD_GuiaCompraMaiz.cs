using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Halley.Entidad.Almacen;
using Halley.Utilitario;

namespace Halley.CapaDatos.Almacen
{
    public class CD_GuiaCompraMaiz
    {
        string connectionString;
        public CD_GuiaCompraMaiz(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

        public string InsertHojaLiquidacion(E_GuiaCompraMaiz ObjGuiaCompraMaiz, string EmpresaID, string SedeID, string xml, string AlmacenID, string AlmacenExterno, string TipoOperacion)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();
            string Valor;

            try
            {
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Almacen].[Usp_InsertHojaLiquidacion]");
                SqlClient.AddInParameter(SqlCommandAccess, "@ProductoID", SqlDbType.VarChar, ObjGuiaCompraMaiz.ProductoID);
                SqlClient.AddInParameter(SqlCommandAccess, "@NombreProveedor", SqlDbType.VarChar, ObjGuiaCompraMaiz.NombreProveedor);
                SqlClient.AddInParameter(SqlCommandAccess, "@IDProveedor", SqlDbType.VarChar, ObjGuiaCompraMaiz.IDProveedor);
                SqlClient.AddInParameter(SqlCommandAccess, "@DNI", SqlDbType.Char, ObjGuiaCompraMaiz.DNI);
                SqlClient.AddInParameter(SqlCommandAccess, "@Procedencia", SqlDbType.VarChar, ObjGuiaCompraMaiz.Procedencia);
                SqlClient.AddInParameter(SqlCommandAccess, "@PrecioUnitario", SqlDbType.Decimal, ObjGuiaCompraMaiz.PrecioUnitario);
                SqlClient.AddInParameter(SqlCommandAccess, "@Sacos", SqlDbType.VarChar, ObjGuiaCompraMaiz.Sacos);
                SqlClient.AddInParameter(SqlCommandAccess, "@TotalSaco", SqlDbType.Int, ObjGuiaCompraMaiz.TotalSaco);
                SqlClient.AddInParameter(SqlCommandAccess, "@TotalPeso", SqlDbType.Decimal, ObjGuiaCompraMaiz.TotalPeso);
                SqlClient.AddInParameter(SqlCommandAccess, "@Comentario", SqlDbType.VarChar, ObjGuiaCompraMaiz.Comentario);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, ObjGuiaCompraMaiz.UsuarioID);
                SqlClient.AddInParameter(SqlCommandAccess, "@EmpresaID", SqlDbType.Char, EmpresaID);
                SqlClient.AddInParameter(SqlCommandAccess, "@SedeID", SqlDbType.Char, SedeID);
                SqlClient.AddInParameter(SqlCommandAccess, "@XML", SqlDbType.Xml, xml);
                SqlClient.AddInParameter(SqlCommandAccess, "@AlmacenID", SqlDbType.Char, AlmacenID);
                SqlClient.AddInParameter(SqlCommandAccess, "@AlmacenExterno", SqlDbType.Char, AlmacenExterno);
                SqlClient.AddInParameter(SqlCommandAccess, "@TipoOperacion", SqlDbType.Char, TipoOperacion);
                SqlClient.AddInParameter(SqlCommandAccess, "@Pagado", SqlDbType.Decimal, ObjGuiaCompraMaiz.Pagado);
	
                Valor = Convert.ToString(SqlClient.ExecuteScalar(SqlCommandAccess, tran));

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();
                return Valor;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                if (tCnn.State != ConnectionState.Closed)
                {
                    tCnn.Close();
                    tCnn.Dispose();
                }

                throw new Exception(ex.Message);
            }
        }

        public DataSet GetFormatoHojaLiquidacion(string NumHojaLiquidacion)
        {
            DataSet Ds = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_FormatoHojaLiquidacion]");

            SqlClient.AddInParameter(SqlCommand, "@NumHojaLiquidacion", SqlDbType.Char, NumHojaLiquidacion);

            Ds.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "Cabecera", "Detalle", "OperacionCajaBanco");
            return Ds;
        }

        public DataTable GetGuiaCompraMaizDNI(string DNI)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetHojaLiquidacionDNI]");

            SqlClient.AddInParameter(SqlCommand, "@DNI", SqlDbType.Char, DNI);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public void UpdateHojaLiquidacionEstado(string NumHojaLiquidacion, string SedeID, int EstadoID, int OperacionCajaBancoID, int TipoPagoID,
        decimal SaldoMovimiento, int UsuarioID, string Moneda, decimal TipoCambio, string DetalleTransaccion, string RUC, string BANCO, int CuentaCorrienteID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Almacen].[Usp_UpdateHojaLiquidacionEstado]");
                SqlClient.AddInParameter(SqlCommandAccess, "@NumHojaLiquidacion", SqlDbType.Char, NumHojaLiquidacion);
                SqlClient.AddInParameter(SqlCommandAccess, "@SedeID", SqlDbType.Char, SedeID);
                SqlClient.AddInParameter(SqlCommandAccess, "@EstadoID", SqlDbType.Int, EstadoID);
                SqlClient.AddInParameter(SqlCommandAccess, "@OperacionCajaBancoID", SqlDbType.Int, OperacionCajaBancoID);
                SqlClient.AddInParameter(SqlCommandAccess, "@TipoPagoID", SqlDbType.Int, TipoPagoID);
                SqlClient.AddInParameter(SqlCommandAccess, "@SaldoMovimiento", SqlDbType.Decimal, SaldoMovimiento);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommandAccess, "@Moneda", SqlDbType.Char, Moneda);
                SqlClient.AddInParameter(SqlCommandAccess, "@TipoCambio", SqlDbType.Decimal, TipoCambio);
                SqlClient.AddInParameter(SqlCommandAccess, "@DetalleTransaccion", SqlDbType.VarChar, DetalleTransaccion);
                SqlClient.AddInParameter(SqlCommandAccess, "@RUC", SqlDbType.VarChar, RUC);
                SqlClient.AddInParameter(SqlCommandAccess, "@BANCO", SqlDbType.VarChar, BANCO);
                SqlClient.AddInParameter(SqlCommandAccess, "@CuentaCorrienteID", SqlDbType.Int, CuentaCorrienteID);

                SqlClient.ExecuteNonQuery(SqlCommandAccess, tran);

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                if (tCnn.State != ConnectionState.Closed)
                {
                    tCnn.Close();
                    tCnn.Dispose();
                }
                throw new Exception(ex.Message);
            }
        }
    }
}

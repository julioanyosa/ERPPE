using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data;
using Halley.Entidad.Ventas;

namespace Halley.CapaDatos.Ventas
{
    public class CD_Vales
    {
        string connectionString;

        public CD_Vales(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        public DataTable getComprobanteNavidenho()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_ComprobantesNavidenho");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable getComprobante()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_Comprobante");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable getAsignacionPorComprobante(string NumComprobante)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_AsignacionVales_Por_Comprobante");
            SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public void UpdateAsignacion(string NumComprobante, string operacion, int UsuarioId, string xml)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();
            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_Update_AsignacionVales");
                SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
                SqlClient.AddInParameter(SqlCommand, "@Operacion", SqlDbType.Char, operacion);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Char, UsuarioId);
                SqlClient.AddInParameter(SqlCommand, "@XML", SqlDbType.Xml, xml);

                SqlClient.ExecuteNonQuery(SqlCommand, tran);
                SqlCommand.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
            }
            catch (EntitySqlException ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void InsertPesos(int UsuarioID,string AlmacenID,decimal PesoTot, string xmlPeso,string xmlProducto)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_insert_XMLPesoPavos");
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.Char, AlmacenID);
                SqlClient.AddInParameter(SqlCommand, "@PesoTotal", SqlDbType.Decimal, PesoTot);
                SqlClient.AddInParameter(SqlCommand, "@XMLPeso", SqlDbType.Xml, xmlPeso);
                SqlClient.AddInParameter(SqlCommand, "@XMLProducto", SqlDbType.Xml, xmlProducto);

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

        public void Insert(int UsuarioID, string SedeId, string XML, int TipoComprobanteID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_Insert_valesNavidenho");
                SqlClient.AddInParameter(SqlCommand, "@UsuarioGenera", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeId);
                SqlClient.AddInParameter(SqlCommand, "@XML", SqlDbType.Xml, XML);
                SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.Int, TipoComprobanteID);
                

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

        public int UpdateEntrega (E_Vale ObjVale)
        {

            int NumIngreso = 0;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();
            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_Update_EntregaNavidenha");
                SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, ObjVale.NumComprobante);
                SqlClient.AddInParameter(SqlCommand, "@NumVale", SqlDbType.Int, ObjVale.NumVale);
                SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ObjVale.ProductoId);
                SqlClient.AddInParameter(SqlCommand, "@PesoReal", SqlDbType.Decimal, ObjVale.PesoActual);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjVale.UsuarioID);
                SqlClient.AddInParameter(SqlCommand, "@NroCredito", SqlDbType.Char, ObjVale.NotaIngreso);
                SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, ObjVale.Tipo);

                NumIngreso = (int)SqlClient.ExecuteScalar(SqlCommand);
                
                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();

                return NumIngreso;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public DataTable getReporteEntrega(string SedeID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Ventas].[Usp_get_ReporteEntrega]");
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;

        }

        public DataTable getNumVale(int NumVale,string SedeID)
        {
            DataTable dt = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_NumVale");
            SqlClient.AddInParameter(SqlCommand, "@NumVale", SqlDbType.Int, NumVale);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);

            dt.Load(SqlClient.ExecuteReader(SqlCommand));
            return dt;
        }

        public DataSet gerNumComprobante(string NumComprobante, Int32 TipoComprobanteID)
        {
            DataSet dsComprobante = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_Get_GenerarVale_Por_Comprobante");
            SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.Int, TipoComprobanteID);

            dsComprobante.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "comprobante", "detalleComprobante");
            return dsComprobante;
        }

        public int getUltimoVale()
        {
            int UltimoVale = 0;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_Get_UltimoVale");

            UltimoVale = (int)SqlClient.ExecuteScalar(SqlCommand);
            return UltimoVale;
        }

        //public DataTable getdetalleVales(string NumComprobante,int NumVale)
        //{
        //    DataTable dt = new DataTable();
        //    SqlDatabase SqlClient = new SqlDatabase(connectionString);
        //    DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_Vale_Por_Comprobante");
        //    SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
        //    SqlClient.AddInParameter(SqlCommand, "@NumVale", SqlDbType.Int, NumVale);

        //    dt.Load(SqlClient.ExecuteReader(SqlCommand));
        //    return dt;
        //}

        public DataTable getdetalleVales(string NumComprobante, int TipoComprobanteID)
        {
            DataTable dt = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_AllVales_Por_Comprobante");
            SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.Int, TipoComprobanteID);

            dt.Load(SqlClient.ExecuteReader(SqlCommand));
            return dt;
        }

        public DataTable getProductosGenericos()
        {
            DataTable dt = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_ProductosNavidenhoGenerico");            

            dt.Load(SqlClient.ExecuteReader(SqlCommand));
            return dt;
        }


    }
}

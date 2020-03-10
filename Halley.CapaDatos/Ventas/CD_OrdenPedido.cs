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
    public class CD_OrdenPedido
    {
        string connectionString;

        public CD_OrdenPedido(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        public int InsertOrdenPedido(E_OrdenPedido ObjPedido, string XMLDetalle)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            int NumPedido = 0;

            try
            {
                DbCommand SqlCommandPedido = SqlClient.GetStoredProcCommand("Ventas.Usp_Insert_OrdenPedidoNavideño");
                SqlClient.AddInParameter(SqlCommandPedido, "@ClienteID", SqlDbType.Int, ObjPedido.ClienteID);                
                SqlClient.AddInParameter(SqlCommandPedido, "@TipoComprobanteID", SqlDbType.TinyInt, ObjPedido.TipoComprobanteID);
                SqlClient.AddInParameter(SqlCommandPedido, "@TipoPagoID", SqlDbType.TinyInt, ObjPedido.TipoPagoID);
                SqlClient.AddInParameter(SqlCommandPedido, "@FormaPagoID", SqlDbType.TinyInt, ObjPedido.FormaPagoId);
                SqlClient.AddInParameter(SqlCommandPedido, "@IGV", SqlDbType.Int, ObjPedido.IGV);
                SqlClient.AddInParameter(SqlCommandPedido, "@SubTotal", SqlDbType.Decimal, ObjPedido.SubTotal);
                SqlClient.AddInParameter(SqlCommandPedido, "@TotalIGV", SqlDbType.Decimal, ObjPedido.TotalIGV);
                SqlClient.AddInParameter(SqlCommandPedido, "@UsuarioID", SqlDbType.Int, ObjPedido.UsuarioID);
                SqlClient.AddInParameter(SqlCommandPedido, "@EmpresaID", SqlDbType.Char, ObjPedido.EmpresaID);
                SqlClient.AddInParameter(SqlCommandPedido, "@SedeID", SqlDbType.Char, ObjPedido.SedeID);
                SqlClient.AddInParameter(SqlCommandPedido, "@Comentario", SqlDbType.VarChar, ObjPedido.Comentario);
                SqlClient.AddInParameter(SqlCommandPedido, "@Externa", SqlDbType.Bit, ObjPedido.Externa);
                SqlClient.AddInParameter(SqlCommandPedido, "@Vale", SqlDbType.Bit, ObjPedido.Vale);
                SqlClient.AddInParameter(SqlCommandPedido, "@NumVale", SqlDbType.Int, ObjPedido.NumVale);
                SqlClient.AddInParameter(SqlCommandPedido, "@XMLDetalle", SqlDbType.Xml, XMLDetalle);

                NumPedido=(int)SqlClient.ExecuteScalar(SqlCommandPedido,tran);
                SqlCommandPedido.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();

                return NumPedido;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public int InsertOrdenPedido2(E_OrdenPedido ObjPedido, string XMLDetalle)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            int NumPedido = 0;

            try
            {
                DbCommand SqlCommandPedido = SqlClient.GetStoredProcCommand("Ventas.Usp_InsertOrdenPedido");
                SqlClient.AddInParameter(SqlCommandPedido, "@ClienteID", SqlDbType.Int, ObjPedido.ClienteID);
                SqlClient.AddInParameter(SqlCommandPedido, "@TipoVentaID", SqlDbType.TinyInt, ObjPedido.TipoVentaID);
                SqlClient.AddInParameter(SqlCommandPedido, "@TipoComprobanteID", SqlDbType.TinyInt, ObjPedido.TipoComprobanteID);
                SqlClient.AddInParameter(SqlCommandPedido, "@TipoPagoID", SqlDbType.TinyInt, ObjPedido.TipoPagoID);
                SqlClient.AddInParameter(SqlCommandPedido, "@FormaPagoID", SqlDbType.TinyInt, ObjPedido.FormaPagoId);
                SqlClient.AddInParameter(SqlCommandPedido, "@IGV", SqlDbType.Int, ObjPedido.IGV);
                SqlClient.AddInParameter(SqlCommandPedido, "@SubTotal", SqlDbType.Decimal, ObjPedido.SubTotal);
                SqlClient.AddInParameter(SqlCommandPedido, "@TotalIGV", SqlDbType.Decimal, ObjPedido.TotalIGV);
                SqlClient.AddInParameter(SqlCommandPedido, "@UsuarioID", SqlDbType.Int, ObjPedido.UsuarioID);
                SqlClient.AddInParameter(SqlCommandPedido, "@EmpresaID", SqlDbType.Char, ObjPedido.EmpresaID);
                SqlClient.AddInParameter(SqlCommandPedido, "@SedeID", SqlDbType.Char, ObjPedido.SedeID);
                SqlClient.AddInParameter(SqlCommandPedido, "@Comentario", SqlDbType.VarChar, ObjPedido.Comentario);
                SqlClient.AddInParameter(SqlCommandPedido, "@Externa", SqlDbType.Bit, ObjPedido.Externa);
                SqlClient.AddInParameter(SqlCommandPedido, "@Vale", SqlDbType.Bit, ObjPedido.Vale);
                SqlClient.AddInParameter(SqlCommandPedido, "@NumVale", SqlDbType.Int, ObjPedido.NumVale);
                SqlClient.AddInParameter(SqlCommandPedido, "@XMLDetalle", SqlDbType.Xml, XMLDetalle);

                NumPedido = (int)SqlClient.ExecuteScalar(SqlCommandPedido, tran);
                SqlCommandPedido.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();

                return NumPedido;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }


        public DataSet getOrdenPedido(string EmpresaID,string SedeID,int NumPedido)
        {
            DataSet dsPedido = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_OrdenPedido");
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            SqlClient.AddInParameter(SqlCommand, "@NumPedido", SqlDbType.Int, NumPedido);
                
            dsPedido.Load(SqlClient.ExecuteReader(SqlCommand),LoadOption.PreserveChanges,"Pedido","detallePedido");
            return dsPedido;
        }

        public DataSet getOrdenPedido2(int NumPedido)
        {
            DataSet dsPedido = new DataSet();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_OrdenPedido2");
            SqlClient.AddInParameter(SqlCommand, "@NumPedido", SqlDbType.Int, NumPedido);

            dsPedido.Load(SqlClient.ExecuteReader(SqlCommand), LoadOption.PreserveChanges, "Pedido", "detallePedido");
            return dsPedido;
        }

    }
}

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

namespace Halley.CapaDatos.Almacen
{
    public class CD_HojaDespacho
    {
        string connectionString;
        public CD_HojaDespacho(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

        public string InsertHojaDespacho(E_HojaDespacho ObjHojaDespacho, string SedeID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();
            string Valor;

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertHojaDespacho");
                SqlClient.AddInParameter(SqlCommandAccess, "@EmpresaID", SqlDbType.Char, ObjHojaDespacho.EmpresaID);
                SqlClient.AddInParameter(SqlCommandAccess, "@EmpresaTransporte", SqlDbType.VarChar, ObjHojaDespacho.EmpresaTransporte);
                SqlClient.AddInParameter(SqlCommandAccess, "@NombreChofer", SqlDbType.VarChar, ObjHojaDespacho.NombreChofer);
                SqlClient.AddInParameter(SqlCommandAccess, "@placa", SqlDbType.VarChar, ObjHojaDespacho.placa);
                SqlClient.AddInParameter(SqlCommandAccess, "@Carrosa", SqlDbType.VarChar, ObjHojaDespacho.Carrosa);
                SqlClient.AddInParameter(SqlCommandAccess, "@FechaLlegada", SqlDbType.DateTime, ObjHojaDespacho.FechaLlegada);
                SqlClient.AddInParameter(SqlCommandAccess, "@FechaSalida", SqlDbType.DateTime, ObjHojaDespacho.FechaSalida);
                SqlClient.AddInParameter(SqlCommandAccess, "@NumJabas", SqlDbType.Int, ObjHojaDespacho.NumJabas);
                SqlClient.AddInParameter(SqlCommandAccess, "@PesoTotal", SqlDbType.Decimal, ObjHojaDespacho.PesoTotal);
                SqlClient.AddInParameter(SqlCommandAccess, "@PesoNeto", SqlDbType.Decimal, ObjHojaDespacho.PesoNeto);
                SqlClient.AddInParameter(SqlCommandAccess, "@TotalAnimales", SqlDbType.Int, ObjHojaDespacho.TotalAnimales);
                SqlClient.AddInParameter(SqlCommandAccess, "@TaraTotal", SqlDbType.Decimal, ObjHojaDespacho.TaraTotal);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, ObjHojaDespacho.UsuarioID);
                SqlClient.AddInParameter(SqlCommandAccess, "@SedeID", SqlDbType.Char, SedeID);

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
                throw new Exception(ex.Message);
            }
        }

        public bool InsertXMLDetalleHojaDespacho(string xml)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertXMLDetalleHojaDespacho");
                SqlClient.AddInParameter(SqlCommandAccess, "@XML", SqlDbType.Xml, xml);
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

        public DataTable GetDetalleHojaDespacho(string NumHojaDespacho)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetDetalleHojaDespacho");

            SqlClient.AddInParameter(SqlCommand, "@NumHojaDespacho", SqlDbType.Char, NumHojaDespacho);
            
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }


        public DataTable GetCabeceraHojaDespacho(string NumHojaDespacho)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetCabeceraHojaDespacho");

            SqlClient.AddInParameter(SqlCommand, "@NumHojaDespacho", SqlDbType.Char, NumHojaDespacho);
            
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }
        public DataTable GetRecepcionHojaDespacho(string NumHojaDespacho)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetRecepcionHojaDespacho");

            SqlClient.AddInParameter(SqlCommand, "@NumHojaDespacho", SqlDbType.Char, NumHojaDespacho);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetDespachos(string NumComprobante, int TipoComprobanteID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetDespachos");

            SqlClient.AddInParameter(SqlCommand, "@NumComprobante", SqlDbType.Char, NumComprobante);
            SqlClient.AddInParameter(SqlCommand, "@TipoComprobanteID", SqlDbType.TinyInt, TipoComprobanteID);
            //SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }
        
    }
}

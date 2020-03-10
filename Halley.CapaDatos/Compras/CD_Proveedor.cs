using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Halley.Utilitario;
using Halley.Entidad.Compras;

namespace Halley.CapaDatos.Compras
{
    public class CD_Proveedor
    {

        string connectionString;

        public CD_Proveedor(string ConnectionString)
        {
             connectionString = ConnectionString;
        }

        public DataTable GetProveedor()
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Compra.usp_get_Proveedor");

             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

        public DataTable GetTipoDocumento()
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Empresa].[Usp_GetTipoDocumento]");

             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

        public DataTable GetProveedoresTipoDocumento(int IDTipoDocumento)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Empresa].[Usp_GetProveedoresTipoDocumento]");
             SqlClient.AddInParameter(SqlCommand, "@IDTipoDocumento", SqlDbType.Int, IDTipoDocumento);

             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

        public DataTable GetProveedorNroDocumento(string NroDocumento)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Compra].[Usp_GetProveedorNroDocumento]");
            SqlClient.AddInParameter(SqlCommand, "@NroDocumento", SqlDbType.VarChar, NroDocumento);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public void UpdateProveedor(E_Proveedor ObjProveedor, string Tipo)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Compra].[Usp_UpdateProveedor]");

                SqlClient.AddInParameter(SqlCommand, "@IDProveedor", SqlDbType.Int, ObjProveedor.IDProveedor);
                SqlClient.AddInParameter(SqlCommand, "@RazonSocial", SqlDbType.VarChar, ObjProveedor.RazonSocial);
                SqlClient.AddInParameter(SqlCommand, "@IDTipoDocumento", SqlDbType.Int, ObjProveedor.IDTipoDocumento);
                SqlClient.AddInParameter(SqlCommand, "@NroDocumento", SqlDbType.VarChar, ObjProveedor.NroDocumento);
                SqlClient.AddInParameter(SqlCommand, "@Telefono", SqlDbType.VarChar, ObjProveedor.Telefono);
                SqlClient.AddInParameter(SqlCommand, "@Pais", SqlDbType.VarChar, ObjProveedor.Pais);
                SqlClient.AddInParameter(SqlCommand, "@Region", SqlDbType.VarChar, ObjProveedor.Region);
                SqlClient.AddInParameter(SqlCommand, "@Direccion", SqlDbType.VarChar, ObjProveedor.Direccion);
                SqlClient.AddInParameter(SqlCommand, "@Contacto", SqlDbType.VarChar, ObjProveedor.Contacto);
                SqlClient.AddInParameter(SqlCommand, "@CargoContacto", SqlDbType.VarChar, ObjProveedor.CargoContacto);
                SqlClient.AddInParameter(SqlCommand, "@Email", SqlDbType.VarChar, ObjProveedor.Email);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjProveedor.UsuarioID);
                SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, Tipo);

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

        public Int32 InsertProveedor(E_Proveedor ObjProveedor)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                Int32 IDProveedor = 0;
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Compra].[Usp_InsertProveedor]");

                SqlClient.AddInParameter(SqlCommand, "@RazonSocial", SqlDbType.VarChar, ObjProveedor.RazonSocial);
                SqlClient.AddInParameter(SqlCommand, "@IDTipoDocumento", SqlDbType.Int, ObjProveedor.IDTipoDocumento);
                SqlClient.AddInParameter(SqlCommand, "@NroDocumento", SqlDbType.VarChar, ObjProveedor.NroDocumento);
                SqlClient.AddInParameter(SqlCommand, "@Telefono", SqlDbType.VarChar, ObjProveedor.Telefono);
                SqlClient.AddInParameter(SqlCommand, "@Pais", SqlDbType.VarChar, ObjProveedor.Pais);
                SqlClient.AddInParameter(SqlCommand, "@Region", SqlDbType.VarChar, ObjProveedor.Region);
                SqlClient.AddInParameter(SqlCommand, "@Direccion", SqlDbType.VarChar, ObjProveedor.Direccion);
                SqlClient.AddInParameter(SqlCommand, "@Contacto", SqlDbType.VarChar, ObjProveedor.Contacto);
                SqlClient.AddInParameter(SqlCommand, "@CargoContacto", SqlDbType.VarChar, ObjProveedor.CargoContacto);
                SqlClient.AddInParameter(SqlCommand, "@Email", SqlDbType.VarChar, ObjProveedor.Email);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjProveedor.UsuarioID);

                IDProveedor = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand, tran));

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommand.Dispose();
                return IDProveedor;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }

    }
}

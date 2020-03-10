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
    public class CD_Cliente
    {

        string connectionString;
        public CD_Cliente(string ConnectionString)
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

        public DataTable GetClienteDocumento(string NroDocumento)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetClienteDocumento");
            SqlClient.AddInParameter(SqlCommand, "@NroDocumento", SqlDbType.VarChar, NroDocumento);
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

        public DataTable GetTipoCliente()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetTipoCliente");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
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


        public Int32 InsertCliente(E_Cliente ObjCliente)
        {
            try
            {
                Int32 ClienteID = 0;
                SqlDatabase SqlClient = new SqlDatabase(connectionString);
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("ventas.Usp_InsertCliente");
                SqlClient.AddInParameter(SqlCommand, "@TipoClienteID", SqlDbType.Int, ObjCliente.TipoClienteID);    
                SqlClient.AddInParameter(SqlCommand, "@IDTipoDocumento", SqlDbType.Int, ObjCliente.IDTipoDocumento);
                SqlClient.AddInParameter(SqlCommand, "@NroDocumento", SqlDbType.VarChar, ObjCliente.NroDocumento);
                SqlClient.AddInParameter(SqlCommand, "@RazonSocial", SqlDbType.VarChar, ObjCliente.RazonSocial);
                SqlClient.AddInParameter(SqlCommand, "@Alias", SqlDbType.VarChar, ObjCliente.Alias);
                SqlClient.AddInParameter(SqlCommand, "@Contacto", SqlDbType.VarChar, ObjCliente.Contacto);
                SqlClient.AddInParameter(SqlCommand, "@TelefonoFijo", SqlDbType.VarChar, ObjCliente.TelefonoFijo);
                SqlClient.AddInParameter(SqlCommand, "@TelefonoMovil", SqlDbType.VarChar, ObjCliente.TelefonoMovil);
                SqlClient.AddInParameter(SqlCommand, "@Fax", SqlDbType.VarChar, ObjCliente.Fax);
                SqlClient.AddInParameter(SqlCommand, "@Email", SqlDbType.VarChar, ObjCliente.Email);
                SqlClient.AddInParameter(SqlCommand, "@Direccion", SqlDbType.VarChar, ObjCliente.Direccion);
                SqlClient.AddInParameter(SqlCommand, "@DistritoId", SqlDbType.Int, ObjCliente.DistritoId);
                SqlClient.AddInParameter(SqlCommand, "@ProvinciaId", SqlDbType.Int, ObjCliente.ProvinciaId);
                SqlClient.AddInParameter(SqlCommand, "@DepartamentoId", SqlDbType.Int, ObjCliente.DepartamentoId);
                SqlClient.AddInParameter(SqlCommand, "@Nombre1", SqlDbType.VarChar, ObjCliente.Nombre1);
                SqlClient.AddInParameter(SqlCommand, "@Nombre2", SqlDbType.VarChar, ObjCliente.Nombre2);
                SqlClient.AddInParameter(SqlCommand, "@Apellido1", SqlDbType.VarChar, ObjCliente.Apellido1);
                SqlClient.AddInParameter(SqlCommand, "@Apellido2", SqlDbType.VarChar, ObjCliente.Apellido2);
                SqlClient.AddInParameter(SqlCommand, "@PaisId", SqlDbType.Int, ObjCliente.PaisId);
                SqlClient.AddInParameter(SqlCommand, "@NombreVia", SqlDbType.VarChar, ObjCliente.NombreVia);
                SqlClient.AddInParameter(SqlCommand, "@DireccionViaId", SqlDbType.Int, ObjCliente.DireccionViaId);
                SqlClient.AddInParameter(SqlCommand, "@DireccionNumero", SqlDbType.VarChar, ObjCliente.DireccionNumero);
                SqlClient.AddInParameter(SqlCommand, "@DireccionInterior", SqlDbType.VarChar, ObjCliente.DireccionInterior);
                SqlClient.AddInParameter(SqlCommand, "@Observaciones", SqlDbType.VarChar, ObjCliente.Observaciones);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjCliente.UsuarioID);

                SqlCommand.CommandTimeout = 180;
                ClienteID = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand));
                return ClienteID;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateCliente(E_Cliente ObjCliente, string Tipo)
        {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();
             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("ventas.Usp_UpdateCliente");
                 SqlClient.AddInParameter(SqlCommand, "@ClienteID", SqlDbType.Int, ObjCliente.ClienteID);
                 SqlClient.AddInParameter(SqlCommand, "@TipoClienteID", SqlDbType.Int, ObjCliente.TipoClienteID);
                SqlClient.AddInParameter(SqlCommand, "@IDTipoDocumento", SqlDbType.Int, ObjCliente.IDTipoDocumento);
                SqlClient.AddInParameter(SqlCommand, "@NroDocumento", SqlDbType.VarChar, ObjCliente.NroDocumento);
                SqlClient.AddInParameter(SqlCommand, "@RazonSocial", SqlDbType.VarChar, ObjCliente.RazonSocial);
                SqlClient.AddInParameter(SqlCommand, "@Alias", SqlDbType.VarChar, ObjCliente.Alias);
                SqlClient.AddInParameter(SqlCommand, "@Contacto", SqlDbType.VarChar, ObjCliente.Contacto);
                SqlClient.AddInParameter(SqlCommand, "@TelefonoFijo", SqlDbType.VarChar, ObjCliente.TelefonoFijo);
                SqlClient.AddInParameter(SqlCommand, "@TelefonoMovil", SqlDbType.VarChar, ObjCliente.TelefonoMovil);
                SqlClient.AddInParameter(SqlCommand, "@Fax", SqlDbType.VarChar, ObjCliente.Fax);
                SqlClient.AddInParameter(SqlCommand, "@Email", SqlDbType.VarChar, ObjCliente.Email);
                SqlClient.AddInParameter(SqlCommand, "@Direccion", SqlDbType.VarChar, ObjCliente.Direccion);
                SqlClient.AddInParameter(SqlCommand, "@DistritoId", SqlDbType.Int, ObjCliente.DistritoId);
                SqlClient.AddInParameter(SqlCommand, "@ProvinciaId", SqlDbType.Int, ObjCliente.ProvinciaId);
                SqlClient.AddInParameter(SqlCommand, "@DepartamentoId", SqlDbType.Int, ObjCliente.DepartamentoId);
                SqlClient.AddInParameter(SqlCommand, "@Nombre1", SqlDbType.VarChar, ObjCliente.Nombre1);
                SqlClient.AddInParameter(SqlCommand, "@Nombre2", SqlDbType.VarChar, ObjCliente.Nombre2);
                SqlClient.AddInParameter(SqlCommand, "@Apellido1", SqlDbType.VarChar, ObjCliente.Apellido1);
                SqlClient.AddInParameter(SqlCommand, "@Apellido2", SqlDbType.VarChar, ObjCliente.Apellido2);
                SqlClient.AddInParameter(SqlCommand, "@PaisId", SqlDbType.Int, ObjCliente.PaisId);
                SqlClient.AddInParameter(SqlCommand, "@NombreVia", SqlDbType.VarChar, ObjCliente.NombreVia);
                SqlClient.AddInParameter(SqlCommand, "@DireccionViaId", SqlDbType.Int, ObjCliente.DireccionViaId);
                SqlClient.AddInParameter(SqlCommand, "@DireccionNumero", SqlDbType.VarChar, ObjCliente.DireccionNumero);
                SqlClient.AddInParameter(SqlCommand, "@DireccionInterior", SqlDbType.VarChar, ObjCliente.DireccionInterior);
                SqlClient.AddInParameter(SqlCommand, "@Observaciones", SqlDbType.VarChar, ObjCliente.Observaciones);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjCliente.UsuarioID);
                SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, Tipo);
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

        public DataTable GetPais()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Empresa.Usp_GetPais");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetComprobantesCliente(int ClienteID, DateTime FechaIni, DateTime FechaFin, int TipoVentaID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetComprobantesCliente");
            SqlClient.AddInParameter(SqlCommand, "@ClienteID", SqlDbType.Int, ClienteID);
            SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@TipoVentaID", SqlDbType.Int, TipoVentaID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }
    }
}

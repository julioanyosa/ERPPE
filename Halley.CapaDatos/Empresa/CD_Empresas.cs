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
using Halley.Entidad.Empresa;

namespace Halley.CapaDatos.Empresa
{
    public class CD_Empresas
    {
        string connectionString;
        public CD_Empresas(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

        public DataTable GetEmpresas()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Empresa.Usp_GetEmpresas");
            
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetSedes()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Empresa.Usp_GetSedes");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetAlmacenesEmpresa(string SedeID, string EmpresaID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Empresa.Usp_GetAlmacenesEmpresa");
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public void InsertSede(E_Sede ObjSede)
        {
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Empresa.Usp_InsertSede");
                 SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, ObjSede.SedeID);
                 SqlClient.AddInParameter(SqlCommand, "@NomSede", SqlDbType.VarChar, ObjSede.NomSede);
                 SqlClient.AddInParameter(SqlCommand, "@Numero", SqlDbType.Int, ObjSede.Numero);
                 SqlClient.AddInParameter(SqlCommand, "@Interior", SqlDbType.Int, ObjSede.Interior);
                 SqlClient.AddInParameter(SqlCommand, "@Zona", SqlDbType.VarChar, ObjSede.Zona);
                 SqlClient.AddInParameter(SqlCommand, "@Distrito", SqlDbType.VarChar, ObjSede.Distrito);
                 SqlClient.AddInParameter(SqlCommand, "@Provincia", SqlDbType.VarChar, ObjSede.Provincia);
                 SqlClient.AddInParameter(SqlCommand, "@Departamento", SqlDbType.VarChar, ObjSede.Departamento);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.VarChar, ObjSede.UsuarioID);

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

        public void UpdateSede(E_Sede ObjSede, string Tipo)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Empresa.Usp_UpdateSede");
                SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, ObjSede.SedeID);
                SqlClient.AddInParameter(SqlCommand, "@NomSede", SqlDbType.VarChar, ObjSede.NomSede);
                SqlClient.AddInParameter(SqlCommand, "@Numero", SqlDbType.Int, ObjSede.Numero);
                SqlClient.AddInParameter(SqlCommand, "@Interior", SqlDbType.Int, ObjSede.Interior);
                SqlClient.AddInParameter(SqlCommand, "@Zona", SqlDbType.VarChar, ObjSede.Zona);
                SqlClient.AddInParameter(SqlCommand, "@Distrito", SqlDbType.VarChar, ObjSede.Distrito);
                SqlClient.AddInParameter(SqlCommand, "@Provincia", SqlDbType.VarChar, ObjSede.Provincia);
                SqlClient.AddInParameter(SqlCommand, "@Departamento", SqlDbType.VarChar, ObjSede.Departamento);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.VarChar, ObjSede.UsuarioID);
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

        public DataTable GetAlmacenHalley()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Empresa.usp_GetAlmacenHalley");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public void InsertAlmacen(string AlmacenID, string Descripcion, string SedeID, string EmpresaID, string Telefono, string Tipo, int UsuarioID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertAlmacen");
                SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.Char, AlmacenID);
                SqlClient.AddInParameter(SqlCommand, "@Descripcion", SqlDbType.VarChar, Descripcion);
                SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@Telefono", SqlDbType.VarChar, Telefono);
                SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, Tipo);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.VarChar, UsuarioID);

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

        public void UpdateEmpresa(E_Empresa ObjEmpresa, string Tipo)
        {

            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Empresa].[Usp_UpdateEmpresa]");
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, ObjEmpresa.EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@NomEmpresa", SqlDbType.VarChar, ObjEmpresa.NomEmpresa);
                SqlClient.AddInParameter(SqlCommand, "@RUC", SqlDbType.Char, ObjEmpresa.RUC);
                SqlClient.AddInParameter(SqlCommand, "@DomicilioFiscal", SqlDbType.VarChar, ObjEmpresa.DomicilioFiscal);
                SqlClient.AddInParameter(SqlCommand, "@Telefono", SqlDbType.VarChar, ObjEmpresa.Telefono);
                SqlClient.AddInParameter(SqlCommand, "@Logo", SqlDbType.Image, ObjEmpresa.Logo);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjEmpresa.UsuarioID);
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

        public string InsertEmpresa(E_Empresa ObjEmpresa)
        {
            string EmpresaID = "";

            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Empresa].[Usp_InsertEmpresa]");
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, ObjEmpresa.EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@NomEmpresa", SqlDbType.VarChar, ObjEmpresa.NomEmpresa);
                SqlClient.AddInParameter(SqlCommand, "@RUC", SqlDbType.Char, ObjEmpresa.RUC);
                SqlClient.AddInParameter(SqlCommand, "@DomicilioFiscal", SqlDbType.VarChar, ObjEmpresa.DomicilioFiscal);
                SqlClient.AddInParameter(SqlCommand, "@Telefono", SqlDbType.VarChar, ObjEmpresa.Telefono);
                SqlClient.AddInParameter(SqlCommand, "@Logo", SqlDbType.Image, ObjEmpresa.Logo);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjEmpresa.UsuarioID);

                EmpresaID = Convert.ToString(SqlClient.ExecuteScalar(SqlCommand, tran));

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

            return EmpresaID;
        }

        public DataTable GetEmpresasMantenimiento()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Empresa].[Usp_GetEmpresasMantenimiento]");

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }
    }
}

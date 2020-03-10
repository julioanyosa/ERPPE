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
using Halley.Entidad.Empresa;

namespace Halley.CapaDatos.Empresa
{
    public class CD_Vehiculo
    {
         string connectionString;
         public CD_Vehiculo(string ConnectionString)
         {
             connectionString = ConnectionString;
         }

        public DataTable GetVehiculos()
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Empresa.Usp_GetVehiculos");

             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

        public DataTable GetVehiculosPlaca(string Placa)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Empresa].[Usp_GetVehiculosPlaca]");
            SqlClient.AddInParameter(SqlCommand, "@Placa", SqlDbType.VarChar, Placa);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public void UpdateVehiculos(E_Vehiculo ObjVehiculo, string Tipo)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Empresa].[Usp_UpdateVehiculos]");

                SqlClient.AddInParameter(SqlCommand, "@Placa", SqlDbType.VarChar, ObjVehiculo.Placa);
                SqlClient.AddInParameter(SqlCommand, "@Marca", SqlDbType.VarChar, ObjVehiculo.Marca);
                SqlClient.AddInParameter(SqlCommand, "@CertificadoInscripcion", SqlDbType.Int, ObjVehiculo.CertificadoInscripcion);
                SqlClient.AddInParameter(SqlCommand, "@ConfiguracionVehicular", SqlDbType.VarChar, ObjVehiculo.ConfiguracionVehicular);
                SqlClient.AddInParameter(SqlCommand, "@Tara", SqlDbType.Decimal, ObjVehiculo.Tara);
                SqlClient.AddInParameter(SqlCommand, "@PesoBruto", SqlDbType.Decimal, ObjVehiculo.PesoBruto);
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, ObjVehiculo.EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjVehiculo.UsuarioID);
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

        public void InsertVehiculos(E_Vehiculo ObjVehiculo)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Empresa].[Usp_InsertVehiculos]");

                SqlClient.AddInParameter(SqlCommand, "@Placa", SqlDbType.VarChar, ObjVehiculo.Placa);
                SqlClient.AddInParameter(SqlCommand, "@Marca", SqlDbType.VarChar, ObjVehiculo.Marca);
                SqlClient.AddInParameter(SqlCommand, "@CertificadoInscripcion", SqlDbType.Int, ObjVehiculo.CertificadoInscripcion);
                SqlClient.AddInParameter(SqlCommand, "@ConfiguracionVehicular", SqlDbType.VarChar, ObjVehiculo.ConfiguracionVehicular);
                SqlClient.AddInParameter(SqlCommand, "@Tara", SqlDbType.Decimal, ObjVehiculo.Tara);
                SqlClient.AddInParameter(SqlCommand, "@PesoBruto", SqlDbType.Decimal, ObjVehiculo.PesoBruto);
                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, ObjVehiculo.EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjVehiculo.UsuarioID);

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

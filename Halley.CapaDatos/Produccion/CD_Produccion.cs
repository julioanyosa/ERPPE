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

namespace Halley.CapaDatos.Produccion
{
    public class CD_Produccion
    {
        string connectionString;
        public CD_Produccion(string ConnectionString)
        {
            connectionString = ConnectionString;
        }
        public DataTable GetProductosFormulados()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Produccion.Usp_GetProductosFormulados");
            SqlCommand.CommandTimeout = 800;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetMateriasPrimas(string Cadena, string EmpresaID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Produccion].[Usp_GetMateriasPrimas]");
            SqlCommand.CommandTimeout = 800;
            SqlClient.AddInParameter(SqlCommand, "@Cadena", SqlDbType.VarChar, Cadena);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetMateriasPrimasHistorico(string Cadena, int MateriaPrimaHistoricoID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Produccion].[Usp_GetMateriasPrimasHistorico]");
            SqlCommand.CommandTimeout = 800;
            SqlClient.AddInParameter(SqlCommand, "@Cadena", SqlDbType.VarChar, Cadena);
            SqlClient.AddInParameter(SqlCommand, "@MateriaPrimaHistoricoID", SqlDbType.Int, MateriaPrimaHistoricoID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetMateriasPrimasProducto(string ProductoID, string EmpresaID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Produccion].[Usp_GetMateriasPrimasProducto]");
            
            SqlCommand.CommandTimeout = 120;
            SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetProductosMacroMicro()
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Produccion.Usp_GetProductosMacroMicro");
            SqlCommand.CommandTimeout = 120;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public bool UpdateXMLMateriaPrima(string xml, int UsuarioID, string EmpresaID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Produccion.Usp_UpdateXMLMateriaPrima");
                SqlClient.AddInParameter(SqlCommandAccess, "@XML", SqlDbType.Xml, xml);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommandAccess, "@EmpresaID", SqlDbType.Char, EmpresaID); 
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
                return false;
            }

        }

        public void InsertMateriaPrimaHistorico(string EmpresaID, int UsuarioID, DataTable DtMateriaPrimaHistoricoDetalle, DataTable DtProductosBatch)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            Int32 MateriaPrimaHistoricoID;

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Produccion].[Usp_InsertMateriaPrimaHistorico]");
                SqlClient.AddInParameter(SqlCommandAccess, "@EmpresaID", SqlDbType.Char, EmpresaID);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                MateriaPrimaHistoricoID = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommandAccess, tran));

                //crear nueva tabla y se agrega el codigo obntenido anteriormente
                DataTable DtHistoricoInsert = new DataTable();
                DtHistoricoInsert.Columns.Add("MateriaPrimaHistoricoID", typeof(Int32)).DefaultValue = MateriaPrimaHistoricoID;
                DtHistoricoInsert.Columns.Add("ProductoID", typeof(string));
                DtHistoricoInsert.Columns.Add("ProductoIDMateria", typeof(string));
                DtHistoricoInsert.Columns.Add("AlmacenMateria", typeof(string));
                DtHistoricoInsert.Columns.Add("Cantidad", typeof(decimal));


                foreach (DataRow DRT in DtMateriaPrimaHistoricoDetalle.Rows)
                {
                    DataRow DRH = DtHistoricoInsert.NewRow();
                    DRH["ProductoID"] = DRT["ProductoID"];
                    DRH["ProductoIDMateria"] = DRT["ProductoIDMateria"];
                    DRH["AlmacenMateria"] = DRT["AlmacenMateria"];
                    DRH["Cantidad"] = DRT["Cantidad"];
                    DtHistoricoInsert.Rows.Add(DRH);
                }

                //crear nueva tabla y se agrega el codigo obntenido anteriormente
                DataTable DtProductosBatch2 = new DataTable();
                DtProductosBatch2.Columns.Add("MateriaPrimaHistoricoID", typeof(Int32)).DefaultValue = MateriaPrimaHistoricoID;
                DtProductosBatch2.Columns.Add("ProductoID", typeof(string));
                DtProductosBatch2.Columns.Add("Batch", typeof(decimal));


                foreach (DataRow DRT in DtProductosBatch.Rows)
                {
                    DataRow DRH = DtProductosBatch2.NewRow();
                    DRH["ProductoID"] = DRT["ProductoID"];
                    DRH["Batch"] = DRT["Batch"];
                    DtProductosBatch2.Rows.Add(DRH);
                }

                //crear tabla y insertarlo en xml
                DtHistoricoInsert.TableName = "MateriaPrimaHistoricoDetalle";
                string xml = new BaseFunctions().GetXML(DtHistoricoInsert).Replace("NewDataSet", "DocumentElement");
                DbCommand SqlCommandDetalle = SqlClient.GetStoredProcCommand("[Produccion].[Usp_InsertXMLMateriaPrimaHistoricoDetalle]");
                SqlClient.AddInParameter(SqlCommandDetalle, "@XML", SqlDbType.Xml, xml);
                SqlClient.AddInParameter(SqlCommandDetalle, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.ExecuteNonQuery(SqlCommandDetalle, tran);
                SqlCommandDetalle.Dispose();

                //crear tabla y insertarlo en xml
                DtProductosBatch2.TableName = "MateriasPrimasFormulados";
                string xml2 = new BaseFunctions().GetXML(DtProductosBatch2).Replace("NewDataSet", "DocumentElement");
                DbCommand SqlCommandDetalle2 = SqlClient.GetStoredProcCommand("[Produccion].[Usp_InsertXMLMateriasPrimasFormulados]");
                SqlClient.AddInParameter(SqlCommandDetalle2, "@XML", SqlDbType.Xml, xml2);
                SqlClient.AddInParameter(SqlCommandDetalle2, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.ExecuteNonQuery(SqlCommandDetalle2, tran);
                SqlCommandDetalle2.Dispose();

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public DataTable GetMateriaPrimaHistoricoFechas(DateTime FechaInicio, DateTime FechaFin, string EmpresaID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Produccion].[Usp_GetMateriaPrimaHistoricoFechas]");
            SqlClient.AddInParameter(SqlCommand, "@FechaInicio", SqlDbType.SmallDateTime, FechaInicio);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            SqlCommand.CommandTimeout = 120;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetMateriasPrimasFormulados(int MateriaPrimaHistoricoID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Produccion].[Usp_GetMateriasPrimasFormulados]");
            SqlClient.AddInParameter(SqlCommand, "@MateriaPrimaHistoricoID", SqlDbType.Int, MateriaPrimaHistoricoID);
            SqlCommand.CommandTimeout = 60;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetStockProductosSede(string Cadena, string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Produccion].[Usp_GetStockProductosSede]");
            SqlClient.AddInParameter(SqlCommand, "@Cadena", SqlDbType.VarChar, Cadena);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
            SqlCommand.CommandTimeout = 120;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetDespachoInterno(string AlmacenDestino, string AlmacenOrigen)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Produccion].[Usp_GetDespachoInterno]");
            SqlClient.AddInParameter(SqlCommand, "@AlmacenDestino", SqlDbType.Char, AlmacenDestino);
            SqlClient.AddInParameter(SqlCommand, "@AlmacenOrigen", SqlDbType.Char, AlmacenOrigen);
            SqlCommand.CommandTimeout = 120;
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public void UpdateXMLMateriasPrimasFormuladosEstado(string xml, int UsuarioID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Produccion.Usp_UpdateXMLMateriasPrimasFormuladosEstado");
                SqlClient.AddInParameter(SqlCommandAccess, "@XML", SqlDbType.Xml, xml);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.ExecuteNonQuery(SqlCommandAccess, tran);

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }
    }
}

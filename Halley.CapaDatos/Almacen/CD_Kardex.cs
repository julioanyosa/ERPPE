using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using Halley.Entidad.Almacen;

namespace Halley.CapaDatos.Almacen
{
    public class CD_Kardex
    {
         string connectionString;

         public CD_Kardex(string ConnectionString)
         {
             connectionString = ConnectionString;
         }

         public DataTable getKardex(string EmpresaID, string ProductoID , int TipoMovimiento ,int UsuarioID, DateTime FechaInicial , DateTime FechaFinal)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_get_Kardex");

             if (ProductoID == "TODOS")
                 ProductoID = "";
             if (EmpresaID.Substring(2, 5) == "TODOS")
                 EmpresaID = EmpresaID.Substring(0, 2);

             SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.VarChar, EmpresaID);
             SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.Char, ProductoID);
             SqlClient.AddInParameter(SqlCommand, "@MovimientoID", SqlDbType.TinyInt, TipoMovimiento);
             SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
             SqlClient.AddInParameter(SqlCommand, "@FecInicial", SqlDbType.DateTime, FechaInicial);
             SqlClient.AddInParameter(SqlCommand, "@FecFinal", SqlDbType.DateTime, FechaFinal);

             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataTable getDTKardex2(string ProductoID, string EmpresaID, DateTime FechaInicial, DateTime FechaFinal, string Sede, int Accion)
         {
             if (ProductoID == "TODOS")
                 ProductoID = "";
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_get_Kardex2");

             SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.Char, ProductoID);
             SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.VarChar, EmpresaID);
             SqlClient.AddInParameter(SqlCommand, "@FecInicial", SqlDbType.DateTime, FechaInicial);
             SqlClient.AddInParameter(SqlCommand, "@FecFinal", SqlDbType.DateTime, FechaFinal);
             SqlClient.AddInParameter(SqlCommand, "@Sede", SqlDbType.Char, Sede);
             SqlClient.AddInParameter(SqlCommand, "@Accion", SqlDbType.Int, Accion);
             
             SqlCommand.CommandTimeout = 600;
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             if (Accion == 1)
             {
                 dtTmp.Columns["TipoOperacion"].ReadOnly = false;
                 dtTmp.Columns["PrecioUnitario"].ReadOnly = false;
                 dtTmp.Columns["Serie"].ReadOnly = false;
                 dtTmp.Columns["Numero"].ReadOnly = false;
                 dtTmp.Columns["CantidadReal"].ReadOnly = false;
                 dtTmp.Columns["Cantidad"].ReadOnly = false;
                 dtTmp.Columns["AudCrea"].ReadOnly = false;
                 dtTmp.Columns["UMContabilidad"].ReadOnly = false;
                 dtTmp.Columns["TipoContabilidad"].ReadOnly = false;
                 dtTmp.Columns["MovimientoID"].ReadOnly = false;
                 dtTmp.Columns["NomMovimiento"].ReadOnly = false;
             }
             return dtTmp;
         }


         public DataTable getKardex_Producto(string ProductoID, string SedeID)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_get_Producto_Kardex");

             SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.Char, ProductoID);
             SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
             
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public void InsertDesperdicio(string AlmacenID, int TipoMovimiento, int UsuarioID, string XML)
         {
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_InsertXML_Kardex_Desperdicio]");
                 SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.Char, AlmacenID);
                 SqlClient.AddInParameter(SqlCommand, "@MovimientoID", SqlDbType.TinyInt, TipoMovimiento);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                 SqlClient.AddInParameter(SqlCommand, "@XML", SqlDbType.Xml, XML);
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

         public void InsertConsumo(int UsuarioID, string XML)
         {
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_InsertXML_Kardex_Consumo]");
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                 SqlClient.AddInParameter(SqlCommand, "@XML", SqlDbType.Xml, XML);
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


         public void UpdateXMLKardex(string XML)
            {
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_UpdateXMLKardex]");
                 SqlClient.AddInParameter(SqlCommand, "@XML", SqlDbType.Xml, XML);
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

         public void UpdateXMLCierreMensual(string XML)
         {
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_UpdateXMLCierreMensual]");
                 SqlClient.AddInParameter(SqlCommand, "@XML", SqlDbType.Xml, XML);
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

         public DataTable GetTipoDocumento()
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetTipoDocumento]");
             SqlCommand.CommandTimeout = 50;
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));

             return dtTmp;
         }
         public DataTable GetOperacionKardex()
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetOperacionKardex]");
             SqlCommand.CommandTimeout = 50;
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));

             return dtTmp;
         }

         public DataTable GetMovimiento()
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetMovimiento]");
             SqlCommand.CommandTimeout = 50;
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));

             return dtTmp;
         }

         public int InsertKardex(E_Kardex ObjE_Kardex, string Xml, string Tipo)
         {
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 int KardexID=0;
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_InsertKardex]");
                 SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.Char, ObjE_Kardex.AlmacenID);
                 SqlClient.AddInParameter(SqlCommand, "@AlmacenExterno", SqlDbType.Char, ObjE_Kardex.AlmacenExterno);
                 SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ObjE_Kardex.ProductoID);
                 SqlClient.AddInParameter(SqlCommand, "@Cantidad", SqlDbType.Decimal, ObjE_Kardex.Cantidad);
                 SqlClient.AddInParameter(SqlCommand, "@MovimientoID", SqlDbType.TinyInt, ObjE_Kardex.MovimientoID);
                 SqlClient.AddInParameter(SqlCommand, "@TipoComprobante", SqlDbType.Char, ObjE_Kardex.TipoComprobante);
                 SqlClient.AddInParameter(SqlCommand, "@Serie", SqlDbType.VarChar, ObjE_Kardex.Serie);
                 SqlClient.AddInParameter(SqlCommand, "@Numero", SqlDbType.Int, ObjE_Kardex.Numero);
                 SqlClient.AddInParameter(SqlCommand, "@TipoOperacion", SqlDbType.Char, ObjE_Kardex.TipoOperacion);
                 SqlClient.AddInParameter(SqlCommand, "@CostoUnitario", SqlDbType.Decimal, ObjE_Kardex.CostoUnitario);
                 SqlClient.AddInParameter(SqlCommand, "@Ingreso", SqlDbType.Char, ObjE_Kardex.Ingreso);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjE_Kardex.UsuarioID);
                 SqlClient.AddInParameter(SqlCommand, "@AudCrea", SqlDbType.SmallDateTime, ObjE_Kardex.AudCrea);
                 SqlClient.AddInParameter(SqlCommand, "@XML", SqlDbType.Xml, Xml);
                 SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, Tipo);
                 KardexID = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand, tran));
                 SqlCommand.Dispose();

                 tran.Commit();
                 tCnn.Close();
                 tCnn.Dispose();

                 return KardexID;
             }
             catch (Exception ex)
             {
                 tran.Rollback();
                 throw new Exception(ex.Message);
             }
         }

         public bool Existekardex(E_Kardex ObjE_Kardex)
         {
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 bool Existe = true;
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_Existekardex]");
                 SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.Char, ObjE_Kardex.AlmacenID);
                 SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ObjE_Kardex.ProductoID);
                 SqlClient.AddInParameter(SqlCommand, "@TipoComprobante", SqlDbType.Char, ObjE_Kardex.TipoComprobante);
                 SqlClient.AddInParameter(SqlCommand, "@Serie", SqlDbType.Char, ObjE_Kardex.Serie);
                 SqlClient.AddInParameter(SqlCommand, "@Numero", SqlDbType.Int, ObjE_Kardex.Numero);
                 SqlClient.AddInParameter(SqlCommand, "@TipoOperacion", SqlDbType.Char, ObjE_Kardex.TipoOperacion);
                 Existe = Convert.ToBoolean(SqlClient.ExecuteScalar(SqlCommand, tran));
                 SqlCommand.Dispose();

                 tran.Commit();
                 tCnn.Close();
                 tCnn.Dispose();

                 return Existe;
             }
             catch (Exception ex)
             {
                 tran.Rollback();
                 throw new Exception(ex.Message);
             }
         }


         public int InsertCierreKardex(int Accion, string XML, int UsuarioID, string Almacen, string ProductoID, string EmpresaID, string Periodo, int Anno, bool CostoCero, decimal Cantidad, decimal CostoUnitario)
         {
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 if (CostoCero == true)
                 {
                     int totalAfectados = 0;

                    DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_InsertCierreKardex]");
                    SqlClient.AddInParameter(SqlCommand, "@Accion", SqlDbType.Int, Accion);
                    SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                    SqlClient.AddInParameter(SqlCommand, "@Almacen", SqlDbType.Char, Almacen);
                    SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
                    SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
                    SqlClient.AddInParameter(SqlCommand, "@Periodo", SqlDbType.Char, Periodo);
                    SqlClient.AddInParameter(SqlCommand, "@Anno", SqlDbType.Int, Anno);
                    SqlClient.AddInParameter(SqlCommand, "@Cantidad", SqlDbType.Decimal, Cantidad);
                    SqlClient.AddInParameter(SqlCommand, "@CostoUnitario", SqlDbType.Decimal, CostoUnitario);
                    totalAfectados = Convert.ToInt32(SqlClient.ExecuteNonQuery(SqlCommand, tran));
                    SqlCommand.Dispose();

                    tran.Commit();
                    tCnn.Close();
                    tCnn.Dispose();
  
                     return totalAfectados;
                 }
                 else
                 {
                     int totalAfectados = 0;
                     DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_InsertXMLCierreMensual]");
                     SqlClient.AddInParameter(SqlCommand, "@XML", SqlDbType.Xml, XML);
                     SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                     SqlClient.AddInParameter(SqlCommand, "@Periodo", SqlDbType.Char, Periodo);
                     SqlClient.AddInParameter(SqlCommand, "@Anno", SqlDbType.Int, Anno);
                     SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
                     totalAfectados = Convert.ToInt32(SqlClient.ExecuteNonQuery(SqlCommand, tran));
                     SqlCommand.Dispose();

                     tran.Commit();
                     tCnn.Close();
                     tCnn.Dispose();

                     return totalAfectados;
                 }
             }
             catch (Exception ex)
             {
                 tran.Rollback();
                 throw new Exception(ex.Message);
             }
         }

         public void UpdateMovimiento(E_Movimiento ObjMovimiento, string Tipo)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_UpdateMovimiento]");
                 SqlClient.AddInParameter(SqlCommand, "@MovimientoID", SqlDbType.TinyInt, ObjMovimiento.MovimientoID);
                 SqlClient.AddInParameter(SqlCommand, "@NomMovimiento", SqlDbType.VarChar, ObjMovimiento.NomMovimiento);
                 SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, ObjMovimiento.Tipo);
                 SqlClient.AddInParameter(SqlCommand, "@TipoM", SqlDbType.Char, Tipo);
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

         public void InserMovimiento(E_Movimiento ObjMovimiento)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_InsertMovimiento]");
                 SqlClient.AddInParameter(SqlCommand, "@MovimientoID", SqlDbType.TinyInt, ObjMovimiento.MovimientoID);
                 SqlClient.AddInParameter(SqlCommand, "@NomMovimiento", SqlDbType.VarChar, ObjMovimiento.NomMovimiento);
                 SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, ObjMovimiento.Tipo);

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

         public void UpdateOperacion(E_Operacion ObjOperacion, string Tipo)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_UpdateOperacionKardex]");
                 SqlClient.AddInParameter(SqlCommand, "@OperacionID", SqlDbType.Char, ObjOperacion.OperacionID);
                 SqlClient.AddInParameter(SqlCommand, "@Descripcion", SqlDbType.VarChar, ObjOperacion.Descripcion);
                 SqlClient.AddInParameter(SqlCommand, "@TipoM", SqlDbType.Char, Tipo);
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

         public void InsertOperacion(E_Operacion ObjOperacion)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_InsertOperacion]");
                 SqlClient.AddInParameter(SqlCommand, "@OperacionID", SqlDbType.Char, ObjOperacion.OperacionID);
                 SqlClient.AddInParameter(SqlCommand, "@Descripcion", SqlDbType.VarChar, ObjOperacion.Descripcion);

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

         public void UpdateTipoDocumento(E_TipoDocumento ObjTipoDocumento, string Tipo)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_UpdateTipoDocumento]");
                 SqlClient.AddInParameter(SqlCommand, "@DocumentoID", SqlDbType.Int, ObjTipoDocumento.DocumentoID);
                 SqlClient.AddInParameter(SqlCommand, "@TipoContabilidad", SqlDbType.Char, ObjTipoDocumento.TipoContabilidad);
                 SqlClient.AddInParameter(SqlCommand, "@Descripcion", SqlDbType.VarChar, ObjTipoDocumento.Descripcion);
                 SqlClient.AddInParameter(SqlCommand, "@TipoM", SqlDbType.Char, Tipo);
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

         public void InsertTipoDocumento(E_TipoDocumento ObjTipoDocumento)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_InsertTipoDocumento]");
                 SqlClient.AddInParameter(SqlCommand, "@DocumentoID", SqlDbType.Int, ObjTipoDocumento.DocumentoID);
                 SqlClient.AddInParameter(SqlCommand, "@TipoContabilidad", SqlDbType.Char, ObjTipoDocumento.TipoContabilidad);
                 SqlClient.AddInParameter(SqlCommand, "@Descripcion", SqlDbType.VarChar, ObjTipoDocumento.Descripcion);

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

         public void DeleteKardex(int KardexID)
         {
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_DeleteKardex]");
                 SqlClient.AddInParameter(SqlCommand, "@KardexID", SqlDbType.Int, KardexID);
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using Halley.Entidad.Empresa;
using Halley.Entidad.Ventas;

namespace Halley.CapaDatos.Almacen
{
    public class CD_Producto
    {
         string connectionString;
         public CD_Producto(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

         public DataTable ObtenerStock(string AlmacenID)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[usp_get_StockProducto]");

             SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.VarChar, AlmacenID);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }


         public DataTable ObtenerProductos(string SedeID)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.usp_get_Productos_Por_Sede");

             SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.VarChar, SedeID);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataTable GetMarca(string ProductoID)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_get_Marca_Por_Producto");
             SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.Char, ProductoID);

             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataTable BuscarProductoAlmacen(string EmpresaID, string ProductoID, string SedeID)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[usp_get_StockProductoAlmacen]");

             SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
             SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.Char, ProductoID);
             SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }


         public DataTable GetProductosPeso()
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetProductosPeso]");
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataTable GetProductos()
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetProductos]");
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }
         public DataTable GetProductosPrincipales(bool Valor)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetProductosPrincipales]");
             SqlClient.AddInParameter(SqlCommand, "@Valor", SqlDbType.Bit, Valor);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }
         public DataTable GetProductosDerivados(string ProductoID)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetProductosDerivados]");
             SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public void UpdateDerivado(string ProductoID, string ProductoIDPrincipal)
         {
             try
             {
                 SqlDatabase SqlClient = new SqlDatabase(connectionString);
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_UpdateDerivado]");
                 SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
                 SqlClient.AddInParameter(SqlCommand, "@ProductoIDPrincipal", SqlDbType.VarChar, ProductoIDPrincipal);
                 SqlClient.ExecuteNonQuery(SqlCommand);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }

         }

         public DataTable GetProductosStock(string EmpresaSede)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetProductosStock]");
             SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataTable GetProductosGenerico(string Generico, string EmpresaSede)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetProductosGenerico]");
             SqlClient.AddInParameter(SqlCommand, "@Generico", SqlDbType.Char, Generico);
             SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataTable GetProductosSubfamilia(string SubfamiliaID, string EmpresaSede)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetProductosSubfamilia]");
             SqlClient.AddInParameter(SqlCommand, "@SubfamiliaID", SqlDbType.Char, SubfamiliaID);
             SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataTable getProductos(string AlmacenID)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[usp_get_Producto_Por_Almacen]");

             SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.VarChar, AlmacenID);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataSet GetCaracteristicasProducto()
         {
             DataTable dtTmp1 = new DataTable();
             dtTmp1.TableName = "Envase";
             DataTable dtTmp2 = new DataTable();
             dtTmp2.TableName = "Marca";
             DataTable dtTmp3 = new DataTable();
             dtTmp3.TableName = "Presentacion";
             DataTable dtTmp4 = new DataTable();
             dtTmp4.TableName = "Subfamilia";
             DataTable dtTmp5 = new DataTable();
             dtTmp5.TableName = "UnidadMedida";
             DataTable dtTmp6 = new DataTable();
             dtTmp6.TableName = "Familia";
             DataTable dtTmp7 = new DataTable();
             dtTmp7.TableName = "Generico";
             DataTable dtTmp8 = new DataTable();
             dtTmp8.TableName = "Existencia";
             DataSet Ds = new DataSet();

             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand1 = SqlClient.GetStoredProcCommand("[Producto].[usp_GetEnvase]");
             dtTmp1.Load(SqlClient.ExecuteReader(SqlCommand1));

             DbCommand SqlCommand2 = SqlClient.GetStoredProcCommand("[Producto].[usp_GetMarca]");
             dtTmp2.Load(SqlClient.ExecuteReader(SqlCommand2));

             
             DbCommand SqlCommand3 = SqlClient.GetStoredProcCommand("[Producto].[usp_GetPresentacion]");
             dtTmp3.Load(SqlClient.ExecuteReader(SqlCommand3));

             
             DbCommand SqlCommand4 = SqlClient.GetStoredProcCommand("[Producto].[usp_GetSubfamilia]");
             dtTmp4.Load(SqlClient.ExecuteReader(SqlCommand4));

             
             DbCommand SqlCommand5 = SqlClient.GetStoredProcCommand("[Producto].[usp_GetUnidadMedida]");
             dtTmp5.Load(SqlClient.ExecuteReader(SqlCommand5));

             DbCommand SqlCommand6 = SqlClient.GetStoredProcCommand("[Producto].[usp_GetFamilia]");
             dtTmp6.Load(SqlClient.ExecuteReader(SqlCommand6));

             DbCommand SqlCommand7 = SqlClient.GetStoredProcCommand("[Producto].[usp_GetGenerico]");
             dtTmp7.Load(SqlClient.ExecuteReader(SqlCommand7));

             DbCommand SqlCommand8 = SqlClient.GetStoredProcCommand("[Producto].[usp_GetExistencia]");
             dtTmp8.Load(SqlClient.ExecuteReader(SqlCommand8));

             Ds.Tables.Add(dtTmp1);
             Ds.Tables.Add(dtTmp2);
             Ds.Tables.Add(dtTmp3);
             Ds.Tables.Add(dtTmp4);
             Ds.Tables.Add(dtTmp5);
             Ds.Tables.Add(dtTmp6);
             Ds.Tables.Add(dtTmp7);
             Ds.Tables.Add(dtTmp8);

             return Ds;
         }

         public string InsertProducto(E_Producto ObjProducto, string ProductoIDVentas)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_InsertProducto]");
                 SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ObjProducto.ProductoID);
                 SqlClient.AddInParameter(SqlCommand, "@MarcaID", SqlDbType.Int, ObjProducto.MarcaID);
                 SqlClient.AddInParameter(SqlCommand, "@NomProducto", SqlDbType.VarChar, ObjProducto.NomProducto);
                 SqlClient.AddInParameter(SqlCommand, "@Alias", SqlDbType.VarChar, ObjProducto.Alias);
                 SqlClient.AddInParameter(SqlCommand, "@Formulado", SqlDbType.Bit, ObjProducto.Formulado);
                 SqlClient.AddInParameter(SqlCommand, "@Almacen", SqlDbType.Char, ObjProducto.Almacen);
                 SqlClient.AddInParameter(SqlCommand, "@UnidadMedidaID", SqlDbType.Char, ObjProducto.UnidadMedidaID);
                 SqlClient.AddInParameter(SqlCommand, "@EnvaseID", SqlDbType.Char, ObjProducto.EnvaseID);
                 SqlClient.AddInParameter(SqlCommand, "@PresentacionID", SqlDbType.Char, ObjProducto.PresentacionID);
                 SqlClient.AddInParameter(SqlCommand, "@SubFamiliaID", SqlDbType.Char, ObjProducto.SubFamiliaID);
                 SqlClient.AddInParameter(SqlCommand, "@DespachoPeso", SqlDbType.Bit, ObjProducto.DespachoPeso);
                 SqlClient.AddInParameter(SqlCommand, "@Peso", SqlDbType.Decimal, ObjProducto.Peso);
                 SqlClient.AddInParameter(SqlCommand, "@Balanza", SqlDbType.Bit, ObjProducto.Balanza);
                 SqlClient.AddInParameter(SqlCommand, "@ProductoIDPrincipal", SqlDbType.VarChar, ObjProducto.ProductoIDPrincipal);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjProducto.UsuarioID);
                 SqlClient.AddInParameter(SqlCommand, "@IDExistencia", SqlDbType.Int, ObjProducto.IDExistencia);
                 
                 SqlClient.AddInParameter(SqlCommand, "@ProductoIDVentas", SqlDbType.VarChar, ProductoIDVentas);
                 SqlClient.AddInParameter(SqlCommand, "@CoeficienteTransformacion", SqlDbType.Decimal, ObjProducto.CoeficienteTransformacion);
                 SqlClient.ExecuteNonQuery(SqlCommand, tran);

                 tran.Commit();
                 tCnn.Close();
                 tCnn.Dispose();
                 SqlCommand.Dispose();
                 return ObjProducto.ProductoID;
             }
             catch (Exception ex)
             {
                 tran.Rollback();
                 throw new Exception(ex.Message);
             }

         }

         public void UpdateProducto(E_Producto ObjProducto, string Tipo, string ProductoIDVentas)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_UpdateProducto]");
                 SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ObjProducto.ProductoID);
                 SqlClient.AddInParameter(SqlCommand, "@MarcaID", SqlDbType.Int, ObjProducto.MarcaID);
                 SqlClient.AddInParameter(SqlCommand, "@NomProducto", SqlDbType.VarChar, ObjProducto.NomProducto);
                 SqlClient.AddInParameter(SqlCommand, "@Alias", SqlDbType.VarChar, ObjProducto.Alias);
                 SqlClient.AddInParameter(SqlCommand, "@Formulado", SqlDbType.Bit, ObjProducto.Formulado);
                 SqlClient.AddInParameter(SqlCommand, "@Almacen", SqlDbType.Char, ObjProducto.Almacen);
                 SqlClient.AddInParameter(SqlCommand, "@UnidadMedidaID", SqlDbType.Char, ObjProducto.UnidadMedidaID);
                 SqlClient.AddInParameter(SqlCommand, "@EnvaseID", SqlDbType.Char, ObjProducto.EnvaseID);
                 SqlClient.AddInParameter(SqlCommand, "@PresentacionID", SqlDbType.Char, ObjProducto.PresentacionID);
                 SqlClient.AddInParameter(SqlCommand, "@SubFamiliaID", SqlDbType.Char, ObjProducto.SubFamiliaID);
                 SqlClient.AddInParameter(SqlCommand, "@DespachoPeso", SqlDbType.Bit, ObjProducto.DespachoPeso);
                 SqlClient.AddInParameter(SqlCommand, "@Peso", SqlDbType.Decimal, ObjProducto.Peso);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjProducto.UsuarioID);
                 SqlClient.AddInParameter(SqlCommand, "@Balanza", SqlDbType.Bit, ObjProducto.Balanza);
                 SqlClient.AddInParameter(SqlCommand, "@ProductoIDPrincipal", SqlDbType.VarChar, ObjProducto.ProductoIDPrincipal);
                 SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, Tipo);
                 SqlClient.AddInParameter(SqlCommand, "@IDExistencia", SqlDbType.Int, ObjProducto.IDExistencia);
                 SqlClient.AddInParameter(SqlCommand, "@CoeficienteTransformacion", SqlDbType.Decimal, ObjProducto.CoeficienteTransformacion);

                 SqlClient.AddInParameter(SqlCommand, "@ProductoIDVentas", SqlDbType.VarChar, ProductoIDVentas);

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

         public void UpdateUnidadMedida(E_UnidadMedida ObjUnidadMedida, string Tipo)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Empresa].[Usp_UpdateUnidadMedida]");
                 SqlClient.AddInParameter(SqlCommand, "@UnidadMedidaID", SqlDbType.Char, ObjUnidadMedida.UnidadMedidaID);
                 SqlClient.AddInParameter(SqlCommand, "@NomUnidadMedida", SqlDbType.VarChar, ObjUnidadMedida.NomUnidadMedida);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjUnidadMedida.UsuarioID);
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

         public string InsertUnidadMedida(E_UnidadMedida ObjUnidadMedida)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_InsertUnidadMedida]");
                 SqlClient.AddInParameter(SqlCommand, "@UnidadMedidaID", SqlDbType.Char, ObjUnidadMedida.UnidadMedidaID);
                 SqlClient.AddInParameter(SqlCommand, "@NomUnidadMedida", SqlDbType.VarChar, ObjUnidadMedida.NomUnidadMedida);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjUnidadMedida.UsuarioID);

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

             return ObjUnidadMedida.UnidadMedidaID;

         }

         public void UpdateSubFamilia(E_Subfamilia ObjSubfamilia, string Tipo)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_UpdateSubFamilia]");
                 SqlClient.AddInParameter(SqlCommand, "@SubFamiliaID", SqlDbType.Char, ObjSubfamilia.SubFamiliaID);
                 SqlClient.AddInParameter(SqlCommand, "@IDFamilia", SqlDbType.Char, ObjSubfamilia.IDFamilia);
                 SqlClient.AddInParameter(SqlCommand, "@NomSubFamilia", SqlDbType.Char, ObjSubfamilia.NomSubFamilia);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjSubfamilia.UsuarioID);
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

         public string InsertSubFamilia(E_Subfamilia ObjSubfamilia)
         {
             string SubFamiliaID = "";
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_InsertSubFamilia]");
                 SqlClient.AddInParameter(SqlCommand, "@IDFamilia", SqlDbType.Char, ObjSubfamilia.IDFamilia);
                 SqlClient.AddInParameter(SqlCommand, "@NomSubFamilia", SqlDbType.Char, ObjSubfamilia.NomSubFamilia);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjSubfamilia.UsuarioID);

                 SubFamiliaID = Convert.ToString(SqlClient.ExecuteScalar(SqlCommand, tran));

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

             return SubFamiliaID;

         }

         public void UpdateEnvase(E_Envase ObjEnvase, string Tipo)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_UpdateEnvase]");
                 SqlClient.AddInParameter(SqlCommand, "@EnvaseID", SqlDbType.Char, ObjEnvase.EnvaseID);
                 SqlClient.AddInParameter(SqlCommand, "@NomEnvase", SqlDbType.VarChar, ObjEnvase.NomEnvase);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjEnvase.UsuarioID);
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

         public string InsertEnvase(E_Envase ObjEnvase)
         {
             string EnvaseID = "";
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_InsertEnvase]");
                 SqlClient.AddInParameter(SqlCommand, "@NomEnvase", SqlDbType.VarChar, ObjEnvase.NomEnvase);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjEnvase.UsuarioID);

                 EnvaseID = Convert.ToString(SqlClient.ExecuteScalar(SqlCommand, tran));

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

             return EnvaseID;
         }

         public void UpdateFamilia(E_Familia ObjFamilia, string Tipo)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_UpdateFamilia]");
                 SqlClient.AddInParameter(SqlCommand, "@IDFamilia", SqlDbType.Char, ObjFamilia.IDFamilia);
                 SqlClient.AddInParameter(SqlCommand, "@NomFamilia", SqlDbType.VarChar, ObjFamilia.NomFamilia);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjFamilia.UsuarioID);
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

         public string InsertFamilia(E_Familia ObjFamilia)
         {
             string IDFamilia = "";

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_InsertFamilia]");
                 SqlClient.AddInParameter(SqlCommand, "@NomFamilia", SqlDbType.VarChar, ObjFamilia.NomFamilia);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjFamilia.UsuarioID);

                 IDFamilia = Convert.ToString(SqlClient.ExecuteScalar(SqlCommand, tran));

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

             return IDFamilia;
         }

         public void UpdateMarca(E_Marca ObjMarca, string Tipo)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_UpdateMarca]");
                 SqlClient.AddInParameter(SqlCommand, "@MarcaID", SqlDbType.Int, ObjMarca.MarcaID);
                 SqlClient.AddInParameter(SqlCommand, "@NomMarca", SqlDbType.VarChar, ObjMarca.NomMarca);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjMarca.UsuarioID);
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

         public Int32 InsertMarca(E_Marca ObjMarca)
         {
             Int32 MarcaID = 0;
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_InsertMarca]");
                 SqlClient.AddInParameter(SqlCommand, "@NomMarca", SqlDbType.VarChar, ObjMarca.NomMarca);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjMarca.UsuarioID);

                 MarcaID = Convert.ToInt32(SqlClient.ExecuteScalar(SqlCommand, tran));

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

             return MarcaID;

         }

         public void UpdatePresentacion(E_Presentacion ObjPresentacion, string Tipo)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_UpdatePresentacion]");
                 SqlClient.AddInParameter(SqlCommand, "@PresentacionID", SqlDbType.Char, ObjPresentacion.PresentacionID);
                 SqlClient.AddInParameter(SqlCommand, "@NomPresentacion", SqlDbType.VarChar, ObjPresentacion.NomPresentacion);
                 SqlClient.AddInParameter(SqlCommand, "@Unidades", SqlDbType.Decimal, ObjPresentacion.Unidades);
                 SqlClient.AddInParameter(SqlCommand, "@UnidadMedidaID", SqlDbType.Char, ObjPresentacion.UnidadMedidaID);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjPresentacion.UsuarioID);
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

         public string InsertPresentacion(E_Presentacion ObjPresentacion)
         {
             string PresentacionID = "";
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_InsertPresentacion]");
                 SqlClient.AddInParameter(SqlCommand, "@NomPresentacion", SqlDbType.VarChar, ObjPresentacion.NomPresentacion);
                 SqlClient.AddInParameter(SqlCommand, "@Unidades", SqlDbType.Decimal, ObjPresentacion.Unidades);
                 SqlClient.AddInParameter(SqlCommand, "@UnidadMedidaID", SqlDbType.Char, ObjPresentacion.UnidadMedidaID);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjPresentacion.UsuarioID);

                 PresentacionID = Convert.ToString(SqlClient.ExecuteScalar(SqlCommand, tran));

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

             return PresentacionID;

         }

         public string InsertGenerico(E_Generico ObjGenerico)
         {
             string GenericoID = "";
             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_InsertGenerico]");
                 SqlClient.AddInParameter(SqlCommand, "@NomGenerico", SqlDbType.VarChar, ObjGenerico.NomGenerico);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjGenerico.UsuarioID);

                 GenericoID = Convert.ToString(SqlClient.ExecuteScalar(SqlCommand, tran));

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

             return GenericoID;
         }

         public void UpdateGenerico(E_Generico ObjGenerico, string Tipo)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {
                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_UpdateGenerico]");
                 SqlClient.AddInParameter(SqlCommand, "@GenericoID", SqlDbType.Char, ObjGenerico.GenericoID);
                 SqlClient.AddInParameter(SqlCommand, "@NomGenerico", SqlDbType.VarChar, ObjGenerico.NomGenerico);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjGenerico.UsuarioID);
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

         public DataTable GetProductosXNombre(string CadenaBuscar, string Tipo)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_GetProductosXNombre]");

             SqlClient.AddInParameter(SqlCommand, "@CadenaBuscar", SqlDbType.VarChar, CadenaBuscar);
             SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.VarChar, Tipo);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataTable getProductosNavideños(string EmpresaID, string SedeID)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_ProductosNavideños");

             SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.VarChar, EmpresaID);
             SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.VarChar, SedeID);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataTable getProductosNavideños(string GenericoID)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_ProductosNavideños_Por_Generico");

             SqlClient.AddInParameter(SqlCommand, "@GenericoID", SqlDbType.Char, GenericoID);             
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataTable getStockNavidad(string AlmacenID,string SedeID)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_StockProductoNavidenho");

             SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.Char, AlmacenID);
             SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

       
        #region ventas
         public DataTable GetProductosPrecio(string EmpresaSede, string Cadena, string Tipo)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetProductosPrecio");

             SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
             SqlClient.AddInParameter(SqlCommand, "@Cadena", SqlDbType.VarChar, Cadena);
             SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, Tipo);
             SqlCommand.CommandTimeout = 60;
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataTable getPresentaciones()
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_get_PresentacionesNavidenha");

             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }


         public void UpdatePrecio(E_ListaPrecio ObjListaPrecio, string SedeIDM)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {

                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Producto.Usp_UpdatePrecio");
                 SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, ObjListaPrecio.EmpresaID);
                 SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, ObjListaPrecio.SedeID);
                 SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ObjListaPrecio.ProductoID);
                 SqlClient.AddInParameter(SqlCommand, "@PrecioUnitario", SqlDbType.Decimal, ObjListaPrecio.PrecioUnitario);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjListaPrecio.UsuarioID);
                 SqlClient.AddInParameter(SqlCommand, "@SedeIDM", SqlDbType.Char, SedeIDM);

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

         public void UpdatePuntos(E_ListaPrecio ObjListaPrecio)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {

                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Producto.Usp_UpdatePuntos");
                 SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, ObjListaPrecio.EmpresaID);
                 SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, ObjListaPrecio.SedeID);
                 SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ObjListaPrecio.ProductoID);
                 SqlClient.AddInParameter(SqlCommand, "@Puntos", SqlDbType.Decimal, ObjListaPrecio.Puntos);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjListaPrecio.UsuarioID); 

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

         public DataTable GetProductosPrecioUpdate(string EmpresaSede, string Cadena, string Tipo)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_GetProductosPrecioUpdate");

             SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
             SqlClient.AddInParameter(SqlCommand, "@Cadena", SqlDbType.VarChar, Cadena);
             SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.Char, Tipo);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public DataTable GetStockPorSedes(string EmpresaSede)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.usp_GetStockPorSedes");

             SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }

         public void InsertPrecioNuevo(string AlmacenID, string ProductoID, int UsuarioID,  decimal PrecioUnitario, string SedeIDM)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             DbTransaction tran = tCnn.BeginTransaction();

             try
             {

                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Ventas.Usp_InsertPrecioNuevo");
                 SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.Char, AlmacenID);
                 SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
                 SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                 SqlClient.AddInParameter(SqlCommand, "@PrecioUnitario", SqlDbType.Decimal, PrecioUnitario);
                 SqlClient.AddInParameter(SqlCommand, "@SedeIDM", SqlDbType.Char, SedeIDM);

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
        
         public void UpdatePrecioBalanzaMasivo(string SEDEID, string EmpresaID)
         {

             SqlDatabase SqlClient = new SqlDatabase(connectionString);

             DbConnection tCnn;
             tCnn = SqlClient.CreateConnection();
             tCnn.Open();

             try
             {

                 DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Producto].[Usp_UpdatePrecioBalanzaMasivo]");
                 SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
                 SqlClient.AddInParameter(SqlCommand, "@SEDEID", SqlDbType.Char, SEDEID);
                 
                 SqlClient.ExecuteNonQuery(SqlCommand);

                 tCnn.Close();
                 tCnn.Dispose();
                 SqlCommand.Dispose();
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }


         public DataTable GetGuiaCompraMaizPorFecha(DateTime FechaIni, DateTime FechaFin, string EmpresaID)
         {
             DataTable dtTmp = new DataTable();
             SqlDatabase SqlClient = new SqlDatabase(connectionString);
             DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Compra.Usp_GetGuiaCompraMaizPorFecha");

             SqlClient.AddInParameter(SqlCommand, "@FechaIni", SqlDbType.SmallDateTime, FechaIni);
             SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
             SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
             dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
             return dtTmp;
         }
        #endregion
    }
}

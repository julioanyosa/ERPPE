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

namespace Halley.CapaDatos.Almacen
{
    public class CD_OrdenCompra
    {
        string connectionString;

        public CD_OrdenCompra(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

        public CD_OrdenCompra()
        {
 
        }

        #region   Propiedades

        private static string OrdenCompra { get; set; }

        private static DataTable dt { get; set; }

        #endregion




        public DataTable InsertarOrdenCompra(DataTable dtOrdenCompra, E_OrdenCompra ObjOrdenCompra, string EmpresaID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            string _NumOrdenCompra;
            decimal CantidadSolicitada, Costo, CostoIGV, Total;
            try
            {
                DbCommand SqlCommandCabecera = SqlClient.GetStoredProcCommand("Compra.Usp_Insert_OrdenCompra");
                SqlClient.AddInParameter(SqlCommandCabecera, "@EmpresaID", SqlDbType.Char, EmpresaID);
                SqlClient.AddInParameter(SqlCommandCabecera, "@ProveedorID", SqlDbType.Int, ObjOrdenCompra.IDProveedor);
                SqlClient.AddInParameter(SqlCommandCabecera, "@EstadoOC", SqlDbType.Int, 1);
                SqlClient.AddInParameter(SqlCommandCabecera, "@FlgEst", SqlDbType.Bit, "True");
                SqlClient.AddInParameter(SqlCommandCabecera, "@SedeEntrega", SqlDbType.Char, ObjOrdenCompra.LugarEntrega);
                SqlClient.AddInParameter(SqlCommandCabecera, "@UserID", SqlDbType.Int, ObjOrdenCompra.UsuarioID);
                SqlClient.AddInParameter(SqlCommandCabecera, "@SedeID", SqlDbType.Char, ObjOrdenCompra.SedeID);
                SqlClient.AddInParameter(SqlCommandCabecera, "@Observacion", SqlDbType.VarChar, ObjOrdenCompra.Observacion);
                SqlClient.AddInParameter(SqlCommandCabecera, "@Condicion", SqlDbType.VarChar, ObjOrdenCompra.Condicion);
                SqlClient.AddInParameter(SqlCommandCabecera, "@DiasCredito", SqlDbType.TinyInt, ObjOrdenCompra.DiasCredito);
                SqlClient.AddInParameter(SqlCommandCabecera, "@Subtotal", SqlDbType.Decimal, ObjOrdenCompra.Subtotal);
                SqlClient.AddInParameter(SqlCommandCabecera, "@PorcIGV", SqlDbType.Decimal, ObjOrdenCompra.PorcIGV);
                SqlClient.AddInParameter(SqlCommandCabecera, "@Descuento", SqlDbType.Decimal, ObjOrdenCompra.Descuento);
                SqlClient.AddInParameter(SqlCommandCabecera, "@Otros", SqlDbType.Char, ObjOrdenCompra.Otros);

                _NumOrdenCompra = Convert.ToString(SqlClient.ExecuteScalar(SqlCommandCabecera, tran));
                SqlCommandCabecera.Dispose();

                    //Registra las lineas de la Orden de Compra
                    DataTable dtDetalle = new BaseFunctions().SelectDistinct(dtOrdenCompra, "ProductoID","Descripcion","UM");
                    dtDetalle.Columns.Add("CantidadSolicitada", typeof(decimal));
                    dtDetalle.Columns.Add("Costo", typeof(decimal));
                    dtDetalle.Columns.Add("PorcIGV", typeof(decimal));
                    dtDetalle.Columns.Add("Total", typeof(decimal));
                    dtDetalle.Columns.Add("NumOrdenCompra", typeof(string));

                    int posicion = 0;
                    foreach (DataRow drow in dtDetalle.Rows)
                    {
                        CantidadSolicitada = (decimal)dtOrdenCompra.Compute("Sum(CantidadSolicitada)", "ProductoID = '" + drow["ProductoID"] + "'");
                        dtDetalle.Rows[posicion]["CantidadSolicitada"] = CantidadSolicitada;

                        Costo = (decimal)dtOrdenCompra.Compute("Sum(Costo)", "ProductoID = '" + drow["ProductoID"] + "'");
                        dtDetalle.Rows[posicion]["Costo"] = Costo;

                        CostoIGV = (decimal)dtOrdenCompra.Compute("Sum(PorcIGV)", "ProductoID = '" + drow["ProductoID"] + "'");
                        dtDetalle.Rows[posicion]["PorcIGV"] = CostoIGV;

                        Total = (decimal)dtOrdenCompra.Compute("Sum(Total)", "ProductoID = '" + drow["ProductoID"] + "'");
                        dtDetalle.Rows[posicion]["Total"] = Total;

                        dtDetalle.Rows[posicion]["NumOrdenCompra"] = _NumOrdenCompra;

                        posicion++;

                        CantidadSolicitada = 0; Costo = 0; CostoIGV = 0; Total = 0;
                    }

                    dtDetalle.TableName = "OrdenCompra";
                    string xml = new BaseFunctions().GetXML(dtDetalle).Replace("NewDataSet", "DocumentElement");
                    string xmlOC = xml.Replace("Table", "OrdenCompra");


                    DbCommand SqlCommandLinea = SqlClient.GetStoredProcCommand("Compra.Usp_InsertXMLDetalleOrdenCompra");
                    SqlClient.AddInParameter(SqlCommandLinea, "@NroOrdenCompra", SqlDbType.Char, _NumOrdenCompra);
                    SqlClient.AddInParameter(SqlCommandLinea, "@EstadoID", SqlDbType.Int, 1);
                    SqlClient.AddInParameter(SqlCommandLinea, "@XML", SqlDbType.Xml, xmlOC);
                    SqlClient.ExecuteNonQuery(SqlCommandLinea, tran);
                    SqlCommandLinea.Dispose();

                    //Registra los Requerimientos asociados a la Orden de Compra
                    DataTable dtReqOrdenCompra = new BaseFunctions().SelectDistinct(dtOrdenCompra, "NumRequerimiento");
                    dtReqOrdenCompra.TableName = "OrdenCompraRequerimiento";

                    string _xml = new BaseFunctions().GetXML(dtReqOrdenCompra).Replace("NewDataSet", "DocumentElement");
                    string _xmlOC = _xml.Replace("Table", "OrdenCompraRequerimiento");

                    DbCommand SqlCommandRequerimientoOrdenCompra = SqlClient.GetStoredProcCommand("Compra.Usp_InsertXMLRequerimiento_OrdenCompra");
                    SqlClient.AddInParameter(SqlCommandRequerimientoOrdenCompra, "@NroOrdenCompra", SqlDbType.Char, _NumOrdenCompra);
                    SqlClient.AddInParameter(SqlCommandRequerimientoOrdenCompra, "@XML", SqlDbType.Xml, _xmlOC);
                    SqlClient.ExecuteNonQuery(SqlCommandRequerimientoOrdenCompra, tran);
                    SqlCommandRequerimientoOrdenCompra.Dispose();

                    //Actualizar el estado Detalle de Requerimiento
                    dtOrdenCompra.TableName = "ActualizarDetalle";
                    string _xmlDet = new BaseFunctions().GetXML(dtOrdenCompra).Replace("NewDataSet", "DocumentElement");
                    string _xmlDetalle = _xmlDet.Replace("Table", "ActualizarDetalle");
                    DbCommand SqlCommandDetalle = SqlClient.GetStoredProcCommand("Compra.Usp_UpdateXMLDetalleRequerimiento_Compra");
                    SqlClient.AddInParameter(SqlCommandDetalle, "@XML", SqlDbType.Xml, _xmlDetalle);
                    SqlClient.AddInParameter(SqlCommandDetalle, "@UsuarioID", SqlDbType.Int, ObjOrdenCompra.UsuarioID);
                    SqlClient.AddInParameter(SqlCommandDetalle, "@SedeID", SqlDbType.Char, ObjOrdenCompra.SedeID);
                    SqlClient.ExecuteNonQuery(SqlCommandDetalle, tran);
                    SqlCommandDetalle.Dispose();
                    OrdenCompra = _NumOrdenCompra;
                           
                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();

                return dtDetalle;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }



        public DataTable GetRequerimientoCompra(string EmpresaID)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Compra.usp_get_Requerimiento_Compra");

            SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, EmpresaID);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }


        public DataTable GetRecepcionOrdenCompra(string NumOrdenCompra, string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetRecepcionOrdenCompra");

            SqlClient.AddInParameter(SqlCommand, "@NumOrdenCompra", SqlDbType.Char, NumOrdenCompra);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetCabeceraRecepcionOrdenCompra(string NumOrdenCompra)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetCabeceraRecepcionOrdenCompra");

            SqlClient.AddInParameter(SqlCommand, "@NumOrdenCompra", SqlDbType.Char, NumOrdenCompra);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public bool UpdateXMLDetalleOCEstado(string xml, string Tipo)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_UpdateXMLDetalleOCEstado");
                SqlClient.AddInParameter(SqlCommandAccess, "@XML", SqlDbType.Xml, xml);
                SqlClient.AddInParameter(SqlCommandAccess, "@Tipo", SqlDbType.Char, Tipo);
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

        public bool UpdateFacturaOC(string NumOrdenCompra, string FacturaProveedor, int UsuarioID, string SedeID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_UpdateFacturaOC");
                SqlClient.AddInParameter(SqlCommand, "@NumOrdenCompra", SqlDbType.Char, NumOrdenCompra);
                SqlClient.AddInParameter(SqlCommand, "@FacturaProveedor", SqlDbType.VarChar, FacturaProveedor);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
                SqlClient.ExecuteNonQuery(SqlCommand, tran);

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommand.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public DataTable GetOCPorProductos(string Alias, string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Compra].[Usp_GetOCPorProductos]");
            SqlClient.AddInParameter(SqlCommand, "@Alias", SqlDbType.VarChar, Alias);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

    }
}

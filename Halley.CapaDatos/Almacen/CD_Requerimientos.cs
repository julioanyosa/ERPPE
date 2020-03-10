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
using Halley.CapaDatos.Users;


namespace Halley.CapaDatos.Almacen
{
    public class CD_Requerimientos
    {
        string connectionString;
        public CD_Requerimientos(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

        public DataTable GetRequerimientos(string AlmacenID, string AlmacenIDLocal, string Estados, string Tipo, string EmpresaSede, string EmpresaSedeLocal)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetReqTransferencia");
            SqlCommand.CommandTimeout = 800;
            SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.Char, AlmacenID);
            SqlClient.AddInParameter(SqlCommand, "@AlmacenIDLocal", SqlDbType.Char, AlmacenIDLocal);
            SqlClient.AddInParameter(SqlCommand, "@Estados", SqlDbType.VarChar, Estados);
            SqlClient.AddInParameter(SqlCommand, "@Tipo", SqlDbType.VarChar, Tipo);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSedeLocal", SqlDbType.Char, EmpresaSedeLocal);
            
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public bool UpdateDetalleRequerimientoAnulado(string NumRequerimiento, decimal CantidadTransito, string ProductoID, int UsuarioID, string SedeID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_UpdateDetalleRequerimientoAnulado");
                SqlClient.AddInParameter(SqlCommandAccess, "@NumRequerimiento", SqlDbType.Char, NumRequerimiento);
                SqlClient.AddInParameter(SqlCommandAccess, "@CantidadTransito", SqlDbType.Decimal, CantidadTransito);
                SqlClient.AddInParameter(SqlCommandAccess, "@ProductoID", SqlDbType.VarChar, ProductoID);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommandAccess, "@SedeID", SqlDbType.Char, SedeID);
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

        public bool UpdateXMLDetalleRequerimientoEstado(string xml, string Tipo, int UsuarioID, string SedeID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_UpdateXMLDetalleRequerimientoEstado");
                SqlClient.AddInParameter(SqlCommandAccess, "@XML", SqlDbType.Xml, xml);
                SqlClient.AddInParameter(SqlCommandAccess, "@Tipo", SqlDbType.Char, Tipo);
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommandAccess, "@SedeID", SqlDbType.Char, SedeID);
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

        public void InsertarTransferencia(DataTable dtRequerimiento, int UserID, string EmpresaID, string SedeRequerimiento, string NombreUsuario)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            //tabla para almacenar los correos
            DataTable DtCorreos = new DataTable();
            DtCorreos.Columns.Add("NroRequerimiento", typeof(string));
            DtCorreos.Columns.Add("AlmacenSolicitante", typeof(string));
            DtCorreos.Columns.Add("Producto", typeof(string));
            DtCorreos.Columns.Add("Marca", typeof(string));
            DtCorreos.Columns.Add("UM", typeof(string));
            DtCorreos.Columns.Add("Cantidad", typeof(decimal));
            DtCorreos.Columns.Add("Correo", typeof(string));


            string _NroRequerimiento;

            try
            {
                //Traer los correos de los usuarios
                DataTable DtAlmacenes = new BaseFunctions().SelectDistinct(dtRequerimiento, "AlmacenID");
                DtAlmacenes.TableName = "Almacenes";
                
                string xml2 = new BaseFunctions().GetXML(DtAlmacenes).Replace("NewDataSet", "DocumentElement");
                string xmlCorreos = xml2.Replace("Table", "Almacenes");

                DataTable DTCorreosAlmacenes = new DataTable();
                SqlDatabase SqlClient2 = new SqlDatabase(connectionString);
                DbCommand SqlCommandCorreos = SqlClient2.GetStoredProcCommand("Almacen.Usp_GetXMLCorreos");
                SqlCommandCorreos.CommandTimeout = 800;
                SqlClient2.AddInParameter(SqlCommandCorreos, "@XML", SqlDbType.Xml, xmlCorreos);
                DTCorreosAlmacenes.Load(SqlClient2.ExecuteReader(SqlCommandCorreos));

                //filtrar para crear los requerimientos
                DataTable dtAlmacen = new BaseFunctions().SelectDistinct(dtRequerimiento,"Origen","AlmacenID","Almacen");
                foreach (DataRow drAlmacen in dtAlmacen.Rows)
                {
                    DataView dvProductos = new DataView(dtRequerimiento);
                    dvProductos.RowFilter = "AlmacenID='" + drAlmacen["AlmacenID"] + "' and Origen='" + drAlmacen["Origen"] + "'";

                    DbCommand SqlCommandCabecera = SqlClient.GetStoredProcCommand("Almacen.Usp_Insert_Requerimiento_Transferencia");                    
                    SqlClient.AddInParameter(SqlCommandCabecera, "@EmpresaID", SqlDbType.Char, EmpresaID);
                    SqlClient.AddInParameter(SqlCommandCabecera, "@AmacenID", SqlDbType.Char, drAlmacen["Origen"]);
                    SqlClient.AddInParameter(SqlCommandCabecera, "@AlmacenDestino", SqlDbType.Char, drAlmacen["AlmacenID"]);
                    SqlClient.AddInParameter(SqlCommandCabecera, "@TipoRequerimientoID", SqlDbType.Char,"T");
                    SqlClient.AddInParameter(SqlCommandCabecera, "@UserID", SqlDbType.Int, UserID);
                    SqlClient.AddInParameter(SqlCommandCabecera, "@FlgEst", SqlDbType.Bit, true);
                    _NroRequerimiento = Convert.ToString(SqlClient.ExecuteScalar(SqlCommandCabecera, tran));
                    SqlCommandCabecera.Dispose();

                    //XML
                    string xml = new BaseFunctions().GetXML(dvProductos.ToTable("Requerimiento")).Replace("NewDataSet", "DocumentElement");
                    string xmlReq=xml.Replace("Table","Requerimiento");

                    //Registra las lineas del Requerimiento de Transferencia
                    DbCommand SqlCommandLinea = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertXMLDetalleRequerimientoTransferencia");
                    SqlClient.AddInParameter(SqlCommandLinea, "@NroRequerimiento", SqlDbType.Char, _NroRequerimiento);
                    SqlClient.AddInParameter(SqlCommandLinea, "@EstadoID", SqlDbType.Int, 0);
                    SqlClient.AddInParameter(SqlCommandLinea, "@XML", SqlDbType.Xml, xmlReq);
                    SqlClient.AddInParameter(SqlCommandLinea, "@UsuarioID", SqlDbType.Int, UserID);
                    SqlClient.AddInParameter(SqlCommandLinea, "@SedeID", SqlDbType.Char, SedeRequerimiento);
                    SqlClient.ExecuteNonQuery(SqlCommandLinea, tran);
                    SqlCommandLinea.Dispose();


                    //agregar a la tabla de correos
                    
                    foreach (DataRowView Dv in dvProductos)
                    {
                        DataRow Row = DtCorreos.NewRow();
                        Row["NroRequerimiento"] = _NroRequerimiento;
                        Row["AlmacenSolicitante"] = Dv["Almacen"];
                        Row["Producto"] = Dv["Producto"];
                        Row["Marca"] = Dv["Marca"];
                        Row["UM"] = Dv["UM"];
                        Row["Cantidad"] = Dv["CantidadSolicitada"];

                        //filtrar el correo y agregarlo
                        DataView DvC = new DataView(DTCorreosAlmacenes);
                        DvC.RowFilter = "AlmacenID = '" + drAlmacen["AlmacenID"] + "'"; //filtrar por id del almacen
                        if (DvC.Count > 0)
                        {
                            Row["Correo"] = DvC[0]["Correo"];
                        }
                        else
                        {
                            Row["Correo"] = "";
                        }
                        DtCorreos.Rows.Add(Row);
                    }
                }

                //agrupar para enviar consolidado los correos
                DataView DvConsolidado = new DataView(DtCorreos);
                DataTable DtDistinctCorreo = new BaseFunctions().SelectDistinct(DtCorreos, "Correo");

                foreach (DataRow Dr in DtDistinctCorreo.Rows)
                {
                    DvConsolidado.RowFilter = "Correo = '" + Dr["Correo"] + "'";
                    DataTable DtTemp = new DataTable();
                    DtTemp = DvConsolidado.ToTable();
                    //tabla para crear el cuerpo
                    DataTable DtCuerpo = new BaseFunctions().SelectDistinct(DtTemp,"NroRequerimiento", "AlmacenSolicitante", "Producto", "Marca", "UM", "Cantidad");
                    //Destinatario
                    string Destinatario = Dr["Correo"].ToString();
                    //crear Cabecera mensaje
                    string Asunto = "Requerimiento de la Sede: " + SedeRequerimiento + ".";
                    //crear Mensaje
                    string Mensaje = "";
                    //Titulo
                    string Titulo = "Requerimiento del usuario: " + NombreUsuario + ".";
                    //cabecera
                    StringBuilder html = new StringBuilder();
                    /*html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
                    html.Append("<html>");
                    html.Append("  <head>");
                    html.Append("<title>www.rrv.com.pe/</title>");
                    html.Append("<meta http-equiv=\"Content-Type\"content=\"text/html; charset=UTF-8\" />");
                    html.Append("  </head>");
                    html.Append("<body>");*/
                    html.Append("<br>");
                    html.Append("<table><tr style=\"font-weight: bold;font-size: 15px;color: white\" bgcolor=\"#084B8A\"> <td>" + Titulo + "</td></table><br><br>");
                    html.Append("<table><tr style=\"font-weight: bold;font-size: 15px;color: black\" bgcolor=\"#FFFFFF\"> <td>" + DateTime.Today.ToLongDateString() + "</td></table><br><br>");
                    html.Append("<table><tr style=\"font-weight: bold;font-size: 15px;color: black\" bgcolor=\"#FFFFFF\"> <td>Estimado(a):<br><br></td></table><table><td>Se requiere los Siguientes Productos:</td></table><br><br>");
                    html.Append("<table border=1 cellpadding=1>");
                    //html.Append("<tr style=\"font-weight: bold;font-size: 10px;color: white;color: #F7F8E0;\">");
                    //html.Append("</tr><tr></tr>");
                    //html.Append("<tr></tr>");
                    //cuerpo
                    string bgColor1 = "", fontColor1 = "", bgColor2 = "", fontColor2 = "", bgColor3 = "", fontColor3 = "", FilaAcu = "";
                    Int16 Num = 0;

                    //formato de celdas
                    bgColor1 = " bgcolor=\"LightBlue\" ";
                    fontColor1 = " style=\"font-size: 12px;color: black;\" ";
                    bgColor2 = " bgcolor=\"#FFFFFF\" ";
                    fontColor2 = " style=\"font-size: 12px;color: black;\" ";
                    bgColor3 = " bgcolor=\"#FFFFFF\" ";
                    fontColor3 = " style=\"font-weight: bold; font-size: 14px;color: black;\" ";

                    //titulo de las columnas
                    FilaAcu += "<tr>";
                    for (int i = 0; i < DtCuerpo.Columns.Count; i++)
                    {
                        FilaAcu += "<td " + bgColor3 + " " + fontColor3 + ">" + DtCuerpo.Columns[i].ColumnName + "</td>";
                    }
                    FilaAcu += "</tr>";

                    //aca se crea el cuerpo
                    foreach (DataRow Drc in DtCuerpo.Rows)
                    {
                        FilaAcu += "<tr >";
                        foreach (DataColumn Dc in DtCuerpo.Columns)
                        {
                            //formato según el numero de fila
                            if (Num % 2 == 0)
                            {
                                FilaAcu += "<td " + bgColor1 + " " + fontColor1 + ">" + Drc[Dc].ToString() + "</td>";
                            }
                            else
                            {
                                FilaAcu += "<td " + bgColor2 + " " + fontColor2 + ">" + Drc[Dc].ToString() + "</td>";
                            }
                        }
                        Num++;
                        FilaAcu += "</tr>";
                    }
                    //bgColor1, fontColor1, bgColor2, fontColor2, bgColor3, fontColor3
                    html.Append(FilaAcu);

                    //pie
                    html.Append("  </table>");
                    html.Append("</p>");
                    /*html.Append(" </body>");
                    html.Append("</html>");*/
                    Mensaje = html.ToString();

                    //envio del correo
                    new CD_Helper(connectionString).SendMail(Asunto, Mensaje, Destinatario);
                }

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

        public void InsertarCompra(DataTable dtCompra, int UserID, string EmpresaID, string SedeID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();
            DbTransaction tran = tCnn.BeginTransaction();

            string _NroRequerimiento;

            try
            {
                DataTable dtAlmacen = new BaseFunctions().SelectDistinct(dtCompra,"AlmacenID");
                foreach (DataRow drAlmacen in dtAlmacen.Rows)
                {
                    DataView dvProductos = new DataView(dtCompra);
                    dvProductos.RowFilter = "AlmacenID='" + drAlmacen["AlmacenID"] + "'";

                    DbCommand SqlCommandCabecera = SqlClient.GetStoredProcCommand("Almacen.Usp_Insert_Requerimiento_Compra");
                    SqlClient.AddInParameter(SqlCommandCabecera, "@EmpresaID", SqlDbType.Char, EmpresaID);
                    SqlClient.AddInParameter(SqlCommandCabecera, "@AmacenID", SqlDbType.Char, drAlmacen["AlmacenID"]);                    
                    SqlClient.AddInParameter(SqlCommandCabecera, "@TipoRequerimientoID", SqlDbType.Char, "C");
                    SqlClient.AddInParameter(SqlCommandCabecera, "@UserID", SqlDbType.Int, UserID);
                    SqlClient.AddInParameter(SqlCommandCabecera, "@FlgEst", SqlDbType.Bit, true);
                    _NroRequerimiento = Convert.ToString(SqlClient.ExecuteScalar(SqlCommandCabecera, tran));
                    SqlCommandCabecera.Dispose();

                    //XML
                    string xml = new BaseFunctions().GetXML(dvProductos.ToTable("Compra")).Replace("NewDataSet", "DocumentElement");
                    string xmlReq = xml.Replace("Table", "Compra");

                    //Registra las lineas del Requerimiento de Transferencia
                    DbCommand SqlCommandLinea = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertXMLDetalleRequerimientoCompra");
                    SqlClient.AddInParameter(SqlCommandLinea, "@NroRequerimiento", SqlDbType.Char, _NroRequerimiento);
                    SqlClient.AddInParameter(SqlCommandLinea, "@EstadoID", SqlDbType.Int, 0);
                    SqlClient.AddInParameter(SqlCommandLinea, "@XML", SqlDbType.Xml, xmlReq);
                    SqlClient.AddInParameter(SqlCommandLinea, "@UsuarioID", SqlDbType.Int, UserID);
                    SqlClient.AddInParameter(SqlCommandLinea, "@SedeID", SqlDbType.Char, SedeID);
                    SqlClient.ExecuteNonQuery(SqlCommandLinea, tran);
                    SqlCommandLinea.Dispose();
                }
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

        public DataTable GetRequerimientosEstadoFecha(DateTime FechaInicio, DateTime FechaFin)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetRequerimientosEstadoFecha");
            SqlCommand.CommandTimeout = 800;
            SqlClient.AddInParameter(SqlCommand, "@FechaInicio", SqlDbType.SmallDateTime, FechaInicio);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetRequerimientoDetalleGuiaRemision(DateTime FechaInicio, DateTime FechaFin)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetRequerimientoDetalleGuiaRemision");
            SqlCommand.CommandTimeout = 800;
            SqlClient.AddInParameter(SqlCommand, "@FechaInicio", SqlDbType.SmallDateTime, FechaInicio);
            SqlClient.AddInParameter(SqlCommand, "@FechaFin", SqlDbType.SmallDateTime, FechaFin);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public Boolean UpdateDetalleRequerimientoAnular(string NumRequerimiento, decimal CantidadAumentar, string AlmacenID, string ProductoID, int UsuarioID, string SedeID)
        {
            Boolean Modifico = false;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_UpdateDetalleRequerimientoAnular");
            SqlCommand.CommandTimeout = 800;
            SqlClient.AddInParameter(SqlCommand, "@NumRequerimiento", SqlDbType.Char, NumRequerimiento);
            SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
            SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, UsuarioID);
            SqlClient.AddInParameter(SqlCommand, "@CantidadAumentar", SqlDbType.Decimal, CantidadAumentar);
            SqlClient.AddInParameter(SqlCommand, "@AlmacenID", SqlDbType.Char, AlmacenID);
            SqlClient.AddInParameter(SqlCommand, "@SedeID", SqlDbType.Char, SedeID);
            Modifico = Convert.ToBoolean(SqlClient.ExecuteScalar(SqlCommand));
            return Modifico;
        }
        

        #region Para Pollos y Maiz

        public DataTable GetTransferenciaPeso(string ProductoID, string EmpresaSede, string EmpresaSedeLocal, string Estados)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetTransferenciaPeso");

            SqlClient.AddInParameter(SqlCommand, "@ProductoID", SqlDbType.VarChar, ProductoID);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
            SqlClient.AddInParameter(SqlCommand, "@EmpresaSedeLocal", SqlDbType.Char, EmpresaSedeLocal);
            SqlClient.AddInParameter(SqlCommand, "@Estados", SqlDbType.VarChar, Estados);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        #endregion
    }
}

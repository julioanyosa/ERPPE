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
using Halley.Utilitario;

namespace Halley.CapaDatos.Almacen
{
    public class CD_GuiaTransportista
    {
        string connectionString;
        public CD_GuiaTransportista(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

      
        public string InsertGuiaTransportista(E_GuiaTransporte ObjGuiaTransportista, string EmpresaSede)
        {

            string NumGuiaTransportista;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                // Inserta la Guia de Transportista y devuelve el codigo de Guia de Transportista
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertGuiaTransportista");

                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, ObjGuiaTransportista.EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@NumGuiaRemision", SqlDbType.Char, ObjGuiaTransportista.NumGuiaRemision);
                SqlClient.AddInParameter(SqlCommand, "@DomicilioPartida", SqlDbType.VarChar, ObjGuiaTransportista.DomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@NroDomicilioPartida", SqlDbType.Int, ObjGuiaTransportista.NroDomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@IntDomicilioPartida", SqlDbType.Int, ObjGuiaTransportista.IntDomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@ZonaDomicilioPartida", SqlDbType.VarChar, ObjGuiaTransportista.ZonaDomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@DisDomicilioPartida", SqlDbType.VarChar, ObjGuiaTransportista.DisDomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@ProvDomicilioPartida", SqlDbType.VarChar, ObjGuiaTransportista.ProvDomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@DepDomicilioPartida", SqlDbType.VarChar, ObjGuiaTransportista.DepDomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@DomicilioLlegada", SqlDbType.VarChar, ObjGuiaTransportista.DomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@NroDomicilioLlegada", SqlDbType.Int, ObjGuiaTransportista.NroDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@IntDomicilioLlegada", SqlDbType.Int, ObjGuiaTransportista.IntDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@ZonaDomicilioLlegada", SqlDbType.VarChar, ObjGuiaTransportista.ZonaDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@DisDomicilioLlegada", SqlDbType.VarChar, ObjGuiaTransportista.DisDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@ProvDomicilioLlegada", SqlDbType.VarChar, ObjGuiaTransportista.ProvDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@DepDomicilioLlegada", SqlDbType.VarChar, ObjGuiaTransportista.DepDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@Remitente", SqlDbType.VarChar, ObjGuiaTransportista.Remitente);
                SqlClient.AddInParameter(SqlCommand, "@RUCRemitente", SqlDbType.Char, ObjGuiaTransportista.RUCRemitente);
                SqlClient.AddInParameter(SqlCommand, "@DireccionRemitente", SqlDbType.VarChar, ObjGuiaTransportista.DireccionRemitente);
                SqlClient.AddInParameter(SqlCommand, "@ObservacionRemitente", SqlDbType.VarChar, ObjGuiaTransportista.ObservacionRemitente);
                SqlClient.AddInParameter(SqlCommand, "@Destinatario", SqlDbType.VarChar, ObjGuiaTransportista.Destinatario);
                SqlClient.AddInParameter(SqlCommand, "@RUCDestinatario", SqlDbType.Char, ObjGuiaTransportista.RUCDestinatario);
                SqlClient.AddInParameter(SqlCommand, "@DireccionDestinatario", SqlDbType.VarChar, ObjGuiaTransportista.DireccionDestinatario);
                SqlClient.AddInParameter(SqlCommand, "@ObservacionDestinatario", SqlDbType.VarChar, ObjGuiaTransportista.ObservacionDestinatario);
                SqlClient.AddInParameter(SqlCommand, "@Marca", SqlDbType.VarChar, ObjGuiaTransportista.Marca);
                SqlClient.AddInParameter(SqlCommand, "@Placa", SqlDbType.VarChar, ObjGuiaTransportista.Placa);
                SqlClient.AddInParameter(SqlCommand, "@Carrosa", SqlDbType.VarChar, ObjGuiaTransportista.Carrosa);
                SqlClient.AddInParameter(SqlCommand, "@NombreChofer", SqlDbType.VarChar, ObjGuiaTransportista.NombreChofer);
                SqlClient.AddInParameter(SqlCommand, "@DNIChofer", SqlDbType.Char, ObjGuiaTransportista.DNIChofer);
                SqlClient.AddInParameter(SqlCommand, "@FechaSalida", SqlDbType.DateTime, ObjGuiaTransportista.FechaSalida);
                SqlClient.AddInParameter(SqlCommand, "@ConfiguracionVehicular", SqlDbType.VarChar, ObjGuiaTransportista.ConfiguracionVehicular);
                SqlClient.AddInParameter(SqlCommand, "@NroConstInscripcion", SqlDbType.Int, ObjGuiaTransportista.NroConstInscripcion);
                SqlClient.AddInParameter(SqlCommand, "@NroLicTransportista", SqlDbType.VarChar, ObjGuiaTransportista.NroLicTransportista);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjGuiaTransportista.UsuarioID);
                SqlClient.AddInParameter(SqlCommand, "@TipoGuia", SqlDbType.Char, ObjGuiaTransportista.TipoGuia);

                SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);

                NumGuiaTransportista = Convert.ToString(SqlClient.ExecuteScalar(SqlCommand, tran));

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommand.Dispose();
                return NumGuiaTransportista;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public bool InsertXMLDetalleGuiaTransporte(string xml)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertXMLDetalleGuiaTransporte");
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

        public DataTable GetCabeceraGuiaTransportista(string NumGuiaTransportista)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetCabeceraGuiaTransportista");

            SqlClient.AddInParameter(SqlCommand, "@NumGuiaTransportista", SqlDbType.Char, NumGuiaTransportista);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetDetalleGuiaTransportista(string NumGuiaTransportista, string TipoGuia)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetDetalleGuiaTransportista");

            SqlClient.AddInParameter(SqlCommand, "@NumGuiaTransportista", SqlDbType.Char, NumGuiaTransportista);
            SqlClient.AddInParameter(SqlCommand, "@TipoGuia", SqlDbType.Char, TipoGuia);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetSerieGuiaTransporte(string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetSerieGuiaTransporte");

            SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }


        public DataSet CrearGuiaTransporte(E_GuiaTransporte CabeceraGuiaTransporte, DataTable DtDetalleGuiaRemisionVenta, string EmpresaSede)
        {
            string NumGuiaTransportista;
            DataSet Ds = new DataSet();
            #region crear tabla cabecera
            DataTable DtCabecera = new DataTable("DtCabecera");
            DtCabecera.Columns.Add("NumGuiaTransportista", typeof(string));
            DtCabecera.Columns.Add("EmpresaID", typeof(string));
            DtCabecera.Columns.Add("NumGuiaRemision", typeof(string));
            DtCabecera.Columns.Add("DomicilioPartida", typeof(string));
            DtCabecera.Columns.Add("NroDomicilioPartida", typeof(Int32));
            DtCabecera.Columns.Add("IntDomicilioPartida", typeof(Int32));
            DtCabecera.Columns.Add("ZonaDomicilioPartida", typeof(string));
            DtCabecera.Columns.Add("DisDomicilioPartida", typeof(string));
            DtCabecera.Columns.Add("ProvDomicilioPartida", typeof(string));
            DtCabecera.Columns.Add("DepDomicilioPartida", typeof(string));
            DtCabecera.Columns.Add("DomicilioLlegada", typeof(string));
            DtCabecera.Columns.Add("NroDomicilioLlegada", typeof(Int32));
            DtCabecera.Columns.Add("IntDomicilioLlegada", typeof(Int32));
            DtCabecera.Columns.Add("ZonaDomicilioLlegada", typeof(string));
            DtCabecera.Columns.Add("DisDomicilioLlegada", typeof(string));
            DtCabecera.Columns.Add("ProvDomicilioLlegada", typeof(string));
            DtCabecera.Columns.Add("DepDomicilioLlegada", typeof(string));
            DtCabecera.Columns.Add("Remitente", typeof(string));
            DtCabecera.Columns.Add("RUCRemitente", typeof(string));
            DtCabecera.Columns.Add("DireccionRemitente", typeof(string));
            DtCabecera.Columns.Add("ObservacionRemitente", typeof(string));
            DtCabecera.Columns.Add("Destinatario", typeof(string));
            DtCabecera.Columns.Add("RUCDestinatario", typeof(string));
            DtCabecera.Columns.Add("DireccionDestinatario", typeof(string));
            DtCabecera.Columns.Add("ObservacionDestinatario", typeof(string));
            DtCabecera.Columns.Add("Marca", typeof(string));
            DtCabecera.Columns.Add("Placa", typeof(string));
            DtCabecera.Columns.Add("Carrosa", typeof(string));
            DtCabecera.Columns.Add("NombreChofer", typeof(string));
            DtCabecera.Columns.Add("DNIChofer", typeof(string));
            DtCabecera.Columns.Add("FechaSalida", typeof(DateTime));
            DtCabecera.Columns.Add("ConfiguracionVehicular", typeof(string));
            DtCabecera.Columns.Add("NroConstInscripcion", typeof(Int32));
            DtCabecera.Columns.Add("NroLicTransportista", typeof(string));
            DtCabecera.Columns.Add("UsuarioID", typeof(Int32));
            DtCabecera.Columns.Add("EstadoID", typeof(Int32));
            #endregion
            #region crear tabla detalle
            DataTable DtDetalleGuiaTransportista = new DataTable("DetalleGuiaRemisionVenta");
            DtDetalleGuiaTransportista.Columns.Add("NumGuiaTransportista", typeof(string));
            DtDetalleGuiaTransportista.Columns.Add("ProductoID", typeof(string));
            DtDetalleGuiaTransportista.Columns.Add("CantidadEnviada", typeof(decimal));
            DtDetalleGuiaTransportista.Columns.Add("NomProducto", typeof(string));
            DtDetalleGuiaTransportista.Columns.Add("UnidadMedidaID", typeof(string));
            DtDetalleGuiaTransportista.Columns.Add("PesoNeto", typeof(decimal));
            #endregion

            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            SqlDatabase SqlClientD = new SqlDatabase(connectionString);
            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();
            
            try
            {
                //acumular de 10
                DataTable NewDtDetalleGuiaRemisionVenta = DtDetalleGuiaRemisionVenta.Clone();
                foreach (DataRow Dr in DtDetalleGuiaRemisionVenta.Rows)
                {
                    NewDtDetalleGuiaRemisionVenta.ImportRow(Dr);
                    if (NewDtDetalleGuiaRemisionVenta.Rows.Count == 10)//maximo de lineas que puede contener una guia
                    {
                        //insertar la guia
                        DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertGuiaTransportista");
                        #region Cabecera guia
                        SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, CabeceraGuiaTransporte.EmpresaID);
                        SqlClient.AddInParameter(SqlCommand, "@NumGuiaRemision", SqlDbType.Char, CabeceraGuiaTransporte.NumGuiaRemision);
                        SqlClient.AddInParameter(SqlCommand, "@DomicilioPartida", SqlDbType.VarChar, CabeceraGuiaTransporte.DomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@NroDomicilioPartida", SqlDbType.Int, CabeceraGuiaTransporte.NroDomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@IntDomicilioPartida", SqlDbType.Int, CabeceraGuiaTransporte.IntDomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@ZonaDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaTransporte.ZonaDomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@DisDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaTransporte.DisDomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@ProvDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaTransporte.ProvDomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@DepDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaTransporte.DepDomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@DomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaTransporte.DomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@NroDomicilioLlegada", SqlDbType.Int, CabeceraGuiaTransporte.NroDomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@IntDomicilioLlegada", SqlDbType.Int, CabeceraGuiaTransporte.IntDomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@ZonaDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaTransporte.ZonaDomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@DisDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaTransporte.DisDomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@ProvDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaTransporte.ProvDomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@DepDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaTransporte.DepDomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@Remitente", SqlDbType.VarChar, CabeceraGuiaTransporte.Remitente);
                        SqlClient.AddInParameter(SqlCommand, "@RUCRemitente", SqlDbType.Char, CabeceraGuiaTransporte.RUCRemitente);
                        SqlClient.AddInParameter(SqlCommand, "@DireccionRemitente", SqlDbType.VarChar, CabeceraGuiaTransporte.DireccionRemitente);
                        SqlClient.AddInParameter(SqlCommand, "@ObservacionRemitente", SqlDbType.VarChar, CabeceraGuiaTransporte.ObservacionRemitente);
                        SqlClient.AddInParameter(SqlCommand, "@Destinatario", SqlDbType.VarChar, CabeceraGuiaTransporte.Destinatario);
                        SqlClient.AddInParameter(SqlCommand, "@RUCDestinatario", SqlDbType.Char, CabeceraGuiaTransporte.RUCDestinatario);
                        SqlClient.AddInParameter(SqlCommand, "@DireccionDestinatario", SqlDbType.VarChar, CabeceraGuiaTransporte.DireccionDestinatario);
                        SqlClient.AddInParameter(SqlCommand, "@ObservacionDestinatario", SqlDbType.VarChar, CabeceraGuiaTransporte.ObservacionDestinatario);
                        SqlClient.AddInParameter(SqlCommand, "@Marca", SqlDbType.VarChar, CabeceraGuiaTransporte.Marca);
                        SqlClient.AddInParameter(SqlCommand, "@Placa", SqlDbType.VarChar, CabeceraGuiaTransporte.Placa);
                        SqlClient.AddInParameter(SqlCommand, "@Carrosa", SqlDbType.VarChar, CabeceraGuiaTransporte.Carrosa);
                        SqlClient.AddInParameter(SqlCommand, "@NombreChofer", SqlDbType.VarChar, CabeceraGuiaTransporte.NombreChofer);
                        SqlClient.AddInParameter(SqlCommand, "@DNIChofer", SqlDbType.Char, CabeceraGuiaTransporte.DNIChofer);
                        SqlClient.AddInParameter(SqlCommand, "@FechaSalida", SqlDbType.DateTime, CabeceraGuiaTransporte.FechaSalida);
                        SqlClient.AddInParameter(SqlCommand, "@ConfiguracionVehicular", SqlDbType.VarChar, CabeceraGuiaTransporte.ConfiguracionVehicular);
                        SqlClient.AddInParameter(SqlCommand, "@NroConstInscripcion", SqlDbType.Int, CabeceraGuiaTransporte.NroConstInscripcion);
                        SqlClient.AddInParameter(SqlCommand, "@NroLicTransportista", SqlDbType.VarChar, CabeceraGuiaTransporte.NroLicTransportista);
                        SqlClient.AddInParameter(SqlCommand, "@TipoGuia", SqlDbType.Char, CabeceraGuiaTransporte.TipoGuia);
                        SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, CabeceraGuiaTransporte.UsuarioID);

                        SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                        #endregion
                        NumGuiaTransportista = Convert.ToString(SqlClient.ExecuteScalar(SqlCommand, tran));

                        #region Agregar Cabecera
                        DataRow DRC = DtCabecera.NewRow();
                        DRC["NumGuiaTransportista"] =  NumGuiaTransportista;
                        DRC["EmpresaID"] =  CabeceraGuiaTransporte.EmpresaID;
                        DRC["NumGuiaRemision"] =  CabeceraGuiaTransporte.NumGuiaRemision;
                        DRC["DomicilioPartida"] =  CabeceraGuiaTransporte.DomicilioPartida;
                        DRC["NroDomicilioPartida"] =  CabeceraGuiaTransporte.NroDomicilioPartida;
                        DRC["IntDomicilioPartida"] =  CabeceraGuiaTransporte.IntDomicilioPartida;
                        DRC["ZonaDomicilioPartida"] =  CabeceraGuiaTransporte.ZonaDomicilioPartida;
                        DRC["DisDomicilioPartida"] =  CabeceraGuiaTransporte.DisDomicilioPartida;
                        DRC["ProvDomicilioPartida"] =  CabeceraGuiaTransporte.ProvDomicilioPartida;
                        DRC["DepDomicilioPartida"] =  CabeceraGuiaTransporte.DepDomicilioPartida;
                        DRC["DomicilioLlegada"] =  CabeceraGuiaTransporte.DomicilioLlegada;
                        DRC["NroDomicilioLlegada"] =  CabeceraGuiaTransporte.NroDomicilioLlegada;
                        DRC["IntDomicilioLlegada"] =  CabeceraGuiaTransporte.IntDomicilioLlegada;
                        DRC["ZonaDomicilioLlegada"] =  CabeceraGuiaTransporte.ZonaDomicilioLlegada;
                        DRC["DisDomicilioLlegada"] =  CabeceraGuiaTransporte.DisDomicilioLlegada;
                        DRC["ProvDomicilioLlegada"] =  CabeceraGuiaTransporte.ProvDomicilioLlegada;
                        DRC["DepDomicilioLlegada"] =  CabeceraGuiaTransporte.DepDomicilioLlegada;
                        DRC["Remitente"] =  CabeceraGuiaTransporte.Remitente;
                        DRC["RUCRemitente"] =  CabeceraGuiaTransporte.RUCRemitente;
                        DRC["DireccionRemitente"] =  CabeceraGuiaTransporte.DireccionRemitente;
                        DRC["ObservacionRemitente"] =  CabeceraGuiaTransporte.ObservacionRemitente;
                        DRC["Destinatario"] =  CabeceraGuiaTransporte.Destinatario;
                        DRC["RUCDestinatario"] =  CabeceraGuiaTransporte.RUCDestinatario;
                        DRC["DireccionDestinatario"] =  CabeceraGuiaTransporte.DireccionDestinatario;
                        DRC["ObservacionDestinatario"] =  CabeceraGuiaTransporte.ObservacionDestinatario;
                        DRC["Marca"] =  CabeceraGuiaTransporte.Marca;
                        DRC["Placa"] =  CabeceraGuiaTransporte.Placa;
                        DRC["Carrosa"] =  CabeceraGuiaTransporte.Carrosa;
                        DRC["NombreChofer"] =  CabeceraGuiaTransporte.NombreChofer;
                        DRC["DNIChofer"] =  CabeceraGuiaTransporte.DNIChofer;
                        DRC["FechaSalida"] = CabeceraGuiaTransporte.FechaSalida;
                        DRC["ConfiguracionVehicular"] =  CabeceraGuiaTransporte.ConfiguracionVehicular;
                        DRC["NroConstInscripcion"] =  CabeceraGuiaTransporte.NroConstInscripcion;
                        DRC["NroLicTransportista"] =  CabeceraGuiaTransporte.NroLicTransportista;
                        DRC["UsuarioID"] =  CabeceraGuiaTransporte.UsuarioID;
                        DRC["EstadoID"] = 0;
                        DtCabecera.Rows.Add(DRC);
                        #endregion

                        string xml, xmlDetalle;
                        xml = new BaseFunctions().GetXML(NewDtDetalleGuiaRemisionVenta).Replace("NewDataSet", "DocumentElement");
                        xmlDetalle = xml.Replace("Table", "DetalleGuiaTransportista");

                        DbCommand SqlCommand2 = SqlClientD.GetStoredProcCommand("Almacen.Usp_Insert_XMLDetalleGuiaTransportistaVenta2");
                        SqlClientD.AddInParameter(SqlCommand2, "@XML", SqlDbType.Xml, xmlDetalle);
                        SqlClientD.AddInParameter(SqlCommand2, "@NumGuiaTransportista", SqlDbType.Char, NumGuiaTransportista);
                        SqlClientD.ExecuteNonQuery(SqlCommand2, tran);

                        #region agregar detalles
                        foreach (DataRow DR in NewDtDetalleGuiaRemisionVenta.Rows)
                        {
                            DataRow DRD = DtDetalleGuiaTransportista.NewRow();
                            DRD["NumGuiaTransportista"] = NumGuiaTransportista;
                            DRD["ProductoID"] = DR["ProductoID"];
                            DRD["CantidadEnviada"] = DR["CantidadEnviada"];
                            DRD["NomProducto"] = DR["NomProducto"];
                            DRD["UnidadMedidaID"] = DR["UnidadMedidaID"];
                            DRD["PesoNeto"] = DR["PesoNeto"];
                            DtDetalleGuiaTransportista.Rows.Add(DRD);
                        }
                        #endregion

                        SqlCommand2.Dispose();
                        SqlCommand.Dispose();

                        NewDtDetalleGuiaRemisionVenta.Rows.Clear();
                    }
                }

                if (NewDtDetalleGuiaRemisionVenta.Rows.Count < 10 & NewDtDetalleGuiaRemisionVenta.Rows.Count > 0)//en caso de que la guia sea menor que 10 
                {
                    //insertar la guia
                    DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertGuiaTransportista");
                    #region Cabecera guia
                    SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, CabeceraGuiaTransporte.EmpresaID);
                    SqlClient.AddInParameter(SqlCommand, "@NumGuiaRemision", SqlDbType.Char, CabeceraGuiaTransporte.NumGuiaRemision);
                    SqlClient.AddInParameter(SqlCommand, "@DomicilioPartida", SqlDbType.VarChar, CabeceraGuiaTransporte.DomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@NroDomicilioPartida", SqlDbType.Int, CabeceraGuiaTransporte.NroDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@IntDomicilioPartida", SqlDbType.Int, CabeceraGuiaTransporte.IntDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@ZonaDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaTransporte.ZonaDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@DisDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaTransporte.DisDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@ProvDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaTransporte.ProvDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@DepDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaTransporte.DepDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@DomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaTransporte.DomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@NroDomicilioLlegada", SqlDbType.Int, CabeceraGuiaTransporte.NroDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@IntDomicilioLlegada", SqlDbType.Int, CabeceraGuiaTransporte.IntDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@ZonaDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaTransporte.ZonaDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@DisDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaTransporte.DisDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@ProvDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaTransporte.ProvDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@DepDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaTransporte.DepDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@Remitente", SqlDbType.VarChar, CabeceraGuiaTransporte.Remitente);
                    SqlClient.AddInParameter(SqlCommand, "@RUCRemitente", SqlDbType.Char, CabeceraGuiaTransporte.RUCRemitente);
                    SqlClient.AddInParameter(SqlCommand, "@DireccionRemitente", SqlDbType.VarChar, CabeceraGuiaTransporte.DireccionRemitente);
                    SqlClient.AddInParameter(SqlCommand, "@ObservacionRemitente", SqlDbType.VarChar, CabeceraGuiaTransporte.ObservacionRemitente);
                    SqlClient.AddInParameter(SqlCommand, "@Destinatario", SqlDbType.VarChar, CabeceraGuiaTransporte.Destinatario);
                    SqlClient.AddInParameter(SqlCommand, "@RUCDestinatario", SqlDbType.Char, CabeceraGuiaTransporte.RUCDestinatario);
                    SqlClient.AddInParameter(SqlCommand, "@DireccionDestinatario", SqlDbType.VarChar, CabeceraGuiaTransporte.DireccionDestinatario);
                    SqlClient.AddInParameter(SqlCommand, "@ObservacionDestinatario", SqlDbType.VarChar, CabeceraGuiaTransporte.ObservacionDestinatario);
                    SqlClient.AddInParameter(SqlCommand, "@Marca", SqlDbType.VarChar, CabeceraGuiaTransporte.Marca);
                    SqlClient.AddInParameter(SqlCommand, "@Placa", SqlDbType.VarChar, CabeceraGuiaTransporte.Placa);
                    SqlClient.AddInParameter(SqlCommand, "@Carrosa", SqlDbType.VarChar, CabeceraGuiaTransporte.Carrosa);
                    SqlClient.AddInParameter(SqlCommand, "@NombreChofer", SqlDbType.VarChar, CabeceraGuiaTransporte.NombreChofer);
                    SqlClient.AddInParameter(SqlCommand, "@DNIChofer", SqlDbType.Char, CabeceraGuiaTransporte.DNIChofer);
                    SqlClient.AddInParameter(SqlCommand, "@FechaSalida", SqlDbType.DateTime, CabeceraGuiaTransporte.FechaSalida);
                    SqlClient.AddInParameter(SqlCommand, "@ConfiguracionVehicular", SqlDbType.VarChar, CabeceraGuiaTransporte.ConfiguracionVehicular);
                    SqlClient.AddInParameter(SqlCommand, "@NroConstInscripcion", SqlDbType.Int, CabeceraGuiaTransporte.NroConstInscripcion);
                    SqlClient.AddInParameter(SqlCommand, "@NroLicTransportista", SqlDbType.VarChar, CabeceraGuiaTransporte.NroLicTransportista);
                    SqlClient.AddInParameter(SqlCommand, "@TipoGuia", SqlDbType.Char, CabeceraGuiaTransporte.TipoGuia);
                    SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, CabeceraGuiaTransporte.UsuarioID);

                    SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                    #endregion
                    NumGuiaTransportista = Convert.ToString(SqlClient.ExecuteScalar(SqlCommand, tran));

                    #region Agregar Cabecera
                    DataRow DRC = DtCabecera.NewRow();
                    DRC["NumGuiaTransportista"] = NumGuiaTransportista;
                    DRC["EmpresaID"] = CabeceraGuiaTransporte.EmpresaID;
                    DRC["NumGuiaRemision"] = CabeceraGuiaTransporte.NumGuiaRemision;
                    DRC["DomicilioPartida"] = CabeceraGuiaTransporte.DomicilioPartida;
                    DRC["NroDomicilioPartida"] = CabeceraGuiaTransporte.NroDomicilioPartida;
                    DRC["IntDomicilioPartida"] = CabeceraGuiaTransporte.IntDomicilioPartida;
                    DRC["ZonaDomicilioPartida"] = CabeceraGuiaTransporte.ZonaDomicilioPartida;
                    DRC["DisDomicilioPartida"] = CabeceraGuiaTransporte.DisDomicilioPartida;
                    DRC["ProvDomicilioPartida"] = CabeceraGuiaTransporte.ProvDomicilioPartida;
                    DRC["DepDomicilioPartida"] = CabeceraGuiaTransporte.DepDomicilioPartida;
                    DRC["DomicilioLlegada"] = CabeceraGuiaTransporte.DomicilioLlegada;
                    DRC["NroDomicilioLlegada"] = CabeceraGuiaTransporte.NroDomicilioLlegada;
                    DRC["IntDomicilioLlegada"] = CabeceraGuiaTransporte.IntDomicilioLlegada;
                    DRC["ZonaDomicilioLlegada"] = CabeceraGuiaTransporte.ZonaDomicilioLlegada;
                    DRC["DisDomicilioLlegada"] = CabeceraGuiaTransporte.DisDomicilioLlegada;
                    DRC["ProvDomicilioLlegada"] = CabeceraGuiaTransporte.ProvDomicilioLlegada;
                    DRC["DepDomicilioLlegada"] = CabeceraGuiaTransporte.DepDomicilioLlegada;
                    DRC["Remitente"] = CabeceraGuiaTransporte.Remitente;
                    DRC["RUCRemitente"] = CabeceraGuiaTransporte.RUCRemitente;
                    DRC["DireccionRemitente"] = CabeceraGuiaTransporte.DireccionRemitente;
                    DRC["ObservacionRemitente"] = CabeceraGuiaTransporte.ObservacionRemitente;
                    DRC["Destinatario"] = CabeceraGuiaTransporte.Destinatario;
                    DRC["RUCDestinatario"] = CabeceraGuiaTransporte.RUCDestinatario;
                    DRC["DireccionDestinatario"] = CabeceraGuiaTransporte.DireccionDestinatario;
                    DRC["ObservacionDestinatario"] = CabeceraGuiaTransporte.ObservacionDestinatario;
                    DRC["Marca"] = CabeceraGuiaTransporte.Marca;
                    DRC["Placa"] = CabeceraGuiaTransporte.Placa;
                    DRC["Carrosa"] = CabeceraGuiaTransporte.Carrosa;
                    DRC["NombreChofer"] = CabeceraGuiaTransporte.NombreChofer;
                    DRC["DNIChofer"] = CabeceraGuiaTransporte.DNIChofer;
                    DRC["FechaSalida"] = CabeceraGuiaTransporte.FechaSalida;
                    DRC["ConfiguracionVehicular"] = CabeceraGuiaTransporte.ConfiguracionVehicular;
                    DRC["NroConstInscripcion"] = CabeceraGuiaTransporte.NroConstInscripcion;
                    DRC["NroLicTransportista"] = CabeceraGuiaTransporte.NroLicTransportista;
                    DRC["UsuarioID"] = CabeceraGuiaTransporte.UsuarioID;
                    DRC["EstadoID"] = 0;
                    DtCabecera.Rows.Add(DRC);
                    #endregion

                    string xml, xmlDetalle;
                    xml = new BaseFunctions().GetXML(NewDtDetalleGuiaRemisionVenta).Replace("NewDataSet", "DocumentElement");
                    xmlDetalle = xml.Replace("Table", "DetalleGuiaTransportista");

                    DbCommand SqlCommand2 = SqlClientD.GetStoredProcCommand("Almacen.Usp_Insert_XMLDetalleGuiaTransportistaVenta2");
                    SqlClientD.AddInParameter(SqlCommand2, "@XML", SqlDbType.Xml, xmlDetalle);
                    SqlClientD.AddInParameter(SqlCommand2, "@NumGuiaTransportista", SqlDbType.Char, NumGuiaTransportista);
                    SqlClientD.ExecuteNonQuery(SqlCommand2, tran);

                    #region agregar detalles
                    
                    foreach (DataRow DR in NewDtDetalleGuiaRemisionVenta.Rows)
                    {
                        DataRow DRD = DtDetalleGuiaTransportista.NewRow();
                        DRD["NumGuiaTransportista"] = NumGuiaTransportista;
                        DRD["ProductoID"] = DR["ProductoID"];
                        DRD["CantidadEnviada"] = DR["CantidadEnviada"];
                        DRD["NomProducto"] = DR["NomProducto"];
                        DRD["UnidadMedidaID"] = DR["UnidadMedidaID"];
                        DRD["PesoNeto"] = DR["PesoNeto"];
                        DtDetalleGuiaTransportista.Rows.Add(DRD);
                    }
                    #endregion

                    SqlCommand2.Dispose();
                    SqlCommand.Dispose();

                    NewDtDetalleGuiaRemisionVenta.Rows.Clear();
                }

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();

                Ds.Tables.Add(DtCabecera);
                Ds.Tables.Add(DtDetalleGuiaTransportista);

                return Ds;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                tCnn.Close();
                tCnn.Dispose();
                throw new Exception(ex.Message);
            }
        }
    }
}

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
using Halley.Configuracion;

namespace Halley.CapaDatos.Almacen
{
    public class CD_GuiaRemision
    {
        string connectionString;

        public CD_GuiaRemision(string ConnectionString)
		{
			connectionString = ConnectionString;
		}

        public string InsertGuiaRemitente_Venta(E_GuiaRemision Obj_GuiaRemision, E_GuiaTransporte ObjGuiaTransportista, DataTable dtGuiaRemision, string EmpresaSede, string Documento,int UsuarioID, bool Condicion)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();
            string _NumGuiaRemision;

            try
            {
                //Registra la cabecera de la guia de remision
                DbCommand SqlCommandGuiaCabecera = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertGuiaRemitente");

                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@EmpresaID", SqlDbType.Char, Obj_GuiaRemision.EmpresaID);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@NroJabas", SqlDbType.Int, Obj_GuiaRemision.NroJabas);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@DesAnimal", SqlDbType.VarChar, Obj_GuiaRemision.DesAnimal);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@NroGalpon", SqlDbType.Int, Obj_GuiaRemision.NroGalpon);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@DomicilioPartida", SqlDbType.VarChar, Obj_GuiaRemision.DomicilioPartida);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@NroDomicilioPartida", SqlDbType.Int, Obj_GuiaRemision.NroDomicilioPartida);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@InteriorDomicilioPartida", SqlDbType.Int, Obj_GuiaRemision.InteriorDomicilioPartida);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@ZonaDomicilioPartida", SqlDbType.VarChar, Obj_GuiaRemision.ZonaDomicilioPartida);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@DistritoDomicilioPartida", SqlDbType.VarChar, Obj_GuiaRemision.DistritoDomicilioPartida);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@ProvinciaDomicilioPartida", SqlDbType.VarChar, Obj_GuiaRemision.ProvinciaDomicilioPartida);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@DepartamentoDomicilioPartida", SqlDbType.VarChar, Obj_GuiaRemision.DepartamentoDomicilioPartida);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@DomicilioLlegada", SqlDbType.VarChar, Obj_GuiaRemision.DomicilioLlegada);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@NroDomicilioLlegada", SqlDbType.Int, Obj_GuiaRemision.NroDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@IntDomicilioLlegada", SqlDbType.Int, Obj_GuiaRemision.IntDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@ZonaDomicilioLlegada", SqlDbType.VarChar, Obj_GuiaRemision.ZonaDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@DisDomicilioLlegada", SqlDbType.VarChar, Obj_GuiaRemision.DisDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@ProvDomicilioLlegada", SqlDbType.VarChar, Obj_GuiaRemision.ProvDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@DepDomicilioLlegada", SqlDbType.VarChar, Obj_GuiaRemision.DepDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@Destinatario", SqlDbType.VarChar, Obj_GuiaRemision.Destinatario);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@RUCDestinatario", SqlDbType.Char, Obj_GuiaRemision.RUCDestinatario);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@DireccionDestinatario", SqlDbType.VarChar, Obj_GuiaRemision.DireccionDestinatario);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@ObservacionDestinatario", SqlDbType.VarChar, Obj_GuiaRemision.ObservacionDestinatario);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@Marca", SqlDbType.VarChar, Obj_GuiaRemision.Marca);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@Placa", SqlDbType.VarChar, Obj_GuiaRemision.Placa);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@Carrosa", SqlDbType.VarChar, Obj_GuiaRemision.Carrosa);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@NombreChofer", SqlDbType.VarChar, Obj_GuiaRemision.NombreChofer);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@DNIChofer", SqlDbType.Char, Obj_GuiaRemision.DNIChofer);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@FechaSalida", SqlDbType.DateTime, Obj_GuiaRemision.FechaSalida);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@ConfiguracionVehicular", SqlDbType.VarChar, Obj_GuiaRemision.ConfiguracionVehicular);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@NroConstInscripcion", SqlDbType.Int, Obj_GuiaRemision.NroConstInscripcion);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@NroLicTransportista", SqlDbType.VarChar, Obj_GuiaRemision.NroLicTransportista);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@NroFactura", SqlDbType.VarChar, Obj_GuiaRemision.NroFactura);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@EmpresaTransporte", SqlDbType.VarChar, Obj_GuiaRemision.EmpresaTransporte);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@RUCTransporte", SqlDbType.Char, Obj_GuiaRemision.RUCTransporte);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@Pesador", SqlDbType.VarChar, Obj_GuiaRemision.Pesador);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@Galponero", SqlDbType.VarChar, Obj_GuiaRemision.Galponero);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@TipoGuia", SqlDbType.Char, Obj_GuiaRemision.TipoGuia);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@UsuarioID", SqlDbType.Int, Obj_GuiaRemision.UsuarioID);
                SqlClient.AddInParameter(SqlCommandGuiaCabecera, "@EmpresaSede", SqlDbType.Char, EmpresaSede);

                _NumGuiaRemision = Convert.ToString(SqlClient.ExecuteScalar(SqlCommandGuiaCabecera, tran));
                SqlCommandGuiaCabecera.Dispose();

                //XML
                dtGuiaRemision.TableName = "DetalleGuiaRemisionVenta";
                string xml = new BaseFunctions().GetXML(dtGuiaRemision).Replace("NewDataSet", "DocumentElement");
                string xmlGuia = xml.Replace("Table", "DetalleGuiaRemisionVenta");

                //Registra las linas de la guia de remision
                DbCommand SqlCommandLineaGuiaRemision = SqlClient.GetStoredProcCommand("Almacen.Usp_Insert_XMLDetalleGuiaRemisionVenta");
                SqlClient.AddInParameter(SqlCommandLineaGuiaRemision, "@NumGuiaRemision", SqlDbType.Char, _NumGuiaRemision);
                SqlClient.AddInParameter(SqlCommandLineaGuiaRemision, "@NroDocumento", SqlDbType.VarChar, Documento);
                SqlClient.AddInParameter(SqlCommandLineaGuiaRemision, "@UsuarioID", SqlDbType.Int, UsuarioID);
                SqlClient.AddInParameter(SqlCommandLineaGuiaRemision, "@XML", SqlDbType.Xml, xmlGuia);
                SqlClient.ExecuteNonQuery(SqlCommandLineaGuiaRemision, tran);
                SqlCommandLineaGuiaRemision.Dispose();


                //Invoca para generar la guia de Transportista si es necesario
                if (Condicion == true)
                {
                    string _NumGuiaTransportista;

                    //Registra la cabecera de Guia de Transportista
                    DbCommand SqlCommandTransportistaCabecera = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertGuiaTransportista");

                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@EmpresaID", SqlDbType.Char, ObjGuiaTransportista.EmpresaID);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@NumGuiaRemision", SqlDbType.Char, _NumGuiaRemision);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@DomicilioPartida", SqlDbType.VarChar, ObjGuiaTransportista.DomicilioPartida);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@NroDomicilioPartida", SqlDbType.Int, ObjGuiaTransportista.NroDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@IntDomicilioPartida", SqlDbType.Int, ObjGuiaTransportista.IntDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@ZonaDomicilioPartida", SqlDbType.VarChar, ObjGuiaTransportista.ZonaDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@DisDomicilioPartida", SqlDbType.VarChar, ObjGuiaTransportista.DisDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@ProvDomicilioPartida", SqlDbType.VarChar, ObjGuiaTransportista.ProvDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@DepDomicilioPartida", SqlDbType.VarChar, ObjGuiaTransportista.DepDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@DomicilioLlegada", SqlDbType.VarChar, ObjGuiaTransportista.DomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@NroDomicilioLlegada", SqlDbType.Int, ObjGuiaTransportista.NroDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@IntDomicilioLlegada", SqlDbType.Int, ObjGuiaTransportista.IntDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@ZonaDomicilioLlegada", SqlDbType.VarChar, ObjGuiaTransportista.ZonaDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@DisDomicilioLlegada", SqlDbType.VarChar, ObjGuiaTransportista.DisDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@ProvDomicilioLlegada", SqlDbType.VarChar, ObjGuiaTransportista.ProvDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@DepDomicilioLlegada", SqlDbType.VarChar, ObjGuiaTransportista.DepDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@Remitente", SqlDbType.VarChar, ObjGuiaTransportista.Remitente);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@RUCRemitente", SqlDbType.Char, ObjGuiaTransportista.RUCRemitente);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@DireccionRemitente", SqlDbType.VarChar, ObjGuiaTransportista.DireccionRemitente);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@ObservacionRemitente", SqlDbType.VarChar, ObjGuiaTransportista.ObservacionRemitente);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@Destinatario", SqlDbType.VarChar, ObjGuiaTransportista.Destinatario);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@RUCDestinatario", SqlDbType.Char, ObjGuiaTransportista.RUCDestinatario);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@DireccionDestinatario", SqlDbType.VarChar, ObjGuiaTransportista.DireccionDestinatario);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@ObservacionDestinatario", SqlDbType.VarChar, ObjGuiaTransportista.ObservacionDestinatario);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@Marca", SqlDbType.VarChar, ObjGuiaTransportista.Marca);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@Placa", SqlDbType.VarChar, ObjGuiaTransportista.Placa);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@Carrosa", SqlDbType.VarChar, ObjGuiaTransportista.Carrosa);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@NombreChofer", SqlDbType.VarChar, ObjGuiaTransportista.NombreChofer);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@DNIChofer", SqlDbType.Char, ObjGuiaTransportista.DNIChofer);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@FechaSalida", SqlDbType.DateTime, ObjGuiaTransportista.FechaSalida);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@ConfiguracionVehicular", SqlDbType.VarChar, ObjGuiaTransportista.ConfiguracionVehicular);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@NroConstInscripcion", SqlDbType.Int, ObjGuiaTransportista.NroConstInscripcion);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@NroLicTransportista", SqlDbType.VarChar, ObjGuiaTransportista.NroLicTransportista);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@UsuarioID", SqlDbType.Int, ObjGuiaTransportista.UsuarioID);
                    SqlClient.AddInParameter(SqlCommandTransportistaCabecera, "@EmpresaSede", SqlDbType.Char, EmpresaSede);

                    _NumGuiaTransportista = Convert.ToString(SqlClient.ExecuteScalar(SqlCommandTransportistaCabecera, tran));
                    SqlCommandTransportistaCabecera.Dispose();

                    //Registra las de la guia de remision
                    DbCommand SqlCommandLineaGuiaTransportista = SqlClient.GetStoredProcCommand("Almacen.Usp_Insert_XMLDetalleGuiaTransportistaVenta");
                    SqlClient.AddInParameter(SqlCommandLineaGuiaTransportista, "@NumGuiaTransportista", SqlDbType.Char, _NumGuiaTransportista);
                    SqlClient.AddInParameter(SqlCommandLineaGuiaTransportista, "@XML", SqlDbType.Xml, xmlGuia);
                    SqlClient.ExecuteNonQuery(SqlCommandLineaGuiaTransportista, tran);
                    SqlCommandLineaGuiaTransportista.Dispose();
                }

                //Finaliza la transaccion
                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();

                return _NumGuiaRemision;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public DataTable Get_GuiaRemision(string NumDocumento)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.usp_get_GuiaRemisionVentaDiferida_Por_Documento");

            SqlClient.AddInParameter(SqlCommand, "@NroDocumento", SqlDbType.VarChar, NumDocumento);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public string InsertGuiaRemitente(E_GuiaRemision ObjGuiaRemision, string EmpresaSede)
        {

            string NumGuiaRemision;
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();


            try
            {
                // Inserta la Guia de remision y devuelve el codigo de Guia de Remision
                DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertGuiaRemitente");

                SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, ObjGuiaRemision.EmpresaID);
                SqlClient.AddInParameter(SqlCommand, "@NroJabas", SqlDbType.Int, ObjGuiaRemision.NroJabas);
                SqlClient.AddInParameter(SqlCommand, "@DesAnimal", SqlDbType.VarChar, ObjGuiaRemision.DesAnimal);
                SqlClient.AddInParameter(SqlCommand, "@NroGalpon", SqlDbType.Int, ObjGuiaRemision.NroGalpon);
                SqlClient.AddInParameter(SqlCommand, "@DomicilioPartida", SqlDbType.VarChar, ObjGuiaRemision.DomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@NroDomicilioPartida", SqlDbType.Int, ObjGuiaRemision.NroDomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@InteriorDomicilioPartida", SqlDbType.Int, ObjGuiaRemision.InteriorDomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@ZonaDomicilioPartida", SqlDbType.VarChar, ObjGuiaRemision.ZonaDomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@DistritoDomicilioPartida", SqlDbType.VarChar, ObjGuiaRemision.DistritoDomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@ProvinciaDomicilioPartida", SqlDbType.VarChar, ObjGuiaRemision.ProvinciaDomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@DepartamentoDomicilioPartida", SqlDbType.VarChar, ObjGuiaRemision.DepartamentoDomicilioPartida);
                SqlClient.AddInParameter(SqlCommand, "@DomicilioLlegada", SqlDbType.VarChar, ObjGuiaRemision.DomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@NroDomicilioLlegada", SqlDbType.Int, ObjGuiaRemision.NroDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@IntDomicilioLlegada", SqlDbType.Int, ObjGuiaRemision.IntDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@ZonaDomicilioLlegada", SqlDbType.VarChar, ObjGuiaRemision.ZonaDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@DisDomicilioLlegada", SqlDbType.VarChar, ObjGuiaRemision.DisDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@ProvDomicilioLlegada", SqlDbType.VarChar, ObjGuiaRemision.ProvDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@DepDomicilioLlegada", SqlDbType.VarChar, ObjGuiaRemision.DepDomicilioLlegada);
                SqlClient.AddInParameter(SqlCommand, "@Destinatario", SqlDbType.VarChar, ObjGuiaRemision.Destinatario);
                SqlClient.AddInParameter(SqlCommand, "@RUCDestinatario", SqlDbType.Char, ObjGuiaRemision.RUCDestinatario);
                SqlClient.AddInParameter(SqlCommand, "@DireccionDestinatario", SqlDbType.VarChar, ObjGuiaRemision.DireccionDestinatario);
                SqlClient.AddInParameter(SqlCommand, "@ObservacionDestinatario", SqlDbType.VarChar, ObjGuiaRemision.ObservacionDestinatario);
                SqlClient.AddInParameter(SqlCommand, "@Marca", SqlDbType.VarChar, ObjGuiaRemision.Marca);
                SqlClient.AddInParameter(SqlCommand, "@Placa", SqlDbType.VarChar, ObjGuiaRemision.Placa);
                SqlClient.AddInParameter(SqlCommand, "@Carrosa", SqlDbType.VarChar, ObjGuiaRemision.Carrosa);
                SqlClient.AddInParameter(SqlCommand, "@NombreChofer", SqlDbType.VarChar, ObjGuiaRemision.NombreChofer);
                SqlClient.AddInParameter(SqlCommand, "@DNIChofer", SqlDbType.Char, ObjGuiaRemision.DNIChofer);
                SqlClient.AddInParameter(SqlCommand, "@FechaSalida", SqlDbType.DateTime, ObjGuiaRemision.FechaSalida);
                SqlClient.AddInParameter(SqlCommand, "@ConfiguracionVehicular", SqlDbType.VarChar, ObjGuiaRemision.ConfiguracionVehicular);
                SqlClient.AddInParameter(SqlCommand, "@NroConstInscripcion", SqlDbType.Int, ObjGuiaRemision.NroConstInscripcion);
                SqlClient.AddInParameter(SqlCommand, "@NroLicTransportista", SqlDbType.VarChar, ObjGuiaRemision.NroLicTransportista);
                SqlClient.AddInParameter(SqlCommand, "@NroFactura", SqlDbType.VarChar, ObjGuiaRemision.NroFactura);
                SqlClient.AddInParameter(SqlCommand, "@EmpresaTransporte", SqlDbType.VarChar, ObjGuiaRemision.EmpresaTransporte);
                SqlClient.AddInParameter(SqlCommand, "@RUCTransporte", SqlDbType.Char, ObjGuiaRemision.RUCTransporte);
                SqlClient.AddInParameter(SqlCommand, "@Pesador", SqlDbType.VarChar, ObjGuiaRemision.Pesador);
                SqlClient.AddInParameter(SqlCommand, "@Galponero", SqlDbType.VarChar, ObjGuiaRemision.Galponero);
                SqlClient.AddInParameter(SqlCommand, "@TipoGuia", SqlDbType.Char, ObjGuiaRemision.TipoGuia);
                SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, ObjGuiaRemision.UsuarioID);
                
                SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                NumGuiaRemision = Convert.ToString(SqlClient.ExecuteScalar(SqlCommand, tran));

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommand.Dispose();
                return NumGuiaRemision;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public bool InsertXMLDetalleGuiaRemision(string xml)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertXMLDetalleGuiaRemision");
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

        public bool InsertXMLDetalleGuiaRemisionPeso(string xml)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertXMLDetalleGuiaRemisionPeso");
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

        public DataTable GetRecepcionGuiaRemisionPeso(string NumGuiaRemision)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetRecepcionGuiaRemisionPeso]");

            SqlClient.AddInParameter(SqlCommand, "@NumGuiaRemision", SqlDbType.Char, NumGuiaRemision);
            
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public bool UpdateXMLDetalleGuiaRemision(string xml, string Tipo)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_UpdateXMLDetalleGuiaRemision");
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

        public DataTable GetCabeceraGuiaRemision(string NumGuiaRemision)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetCabeceraGuiaRemision");

            SqlClient.AddInParameter(SqlCommand, "@NumGuiaRemision", SqlDbType.Char, NumGuiaRemision);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetDetalleGuiaRemision(string NumGuiaRemision, string TipoGuia)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetDetalleGuiaRemision");

            SqlClient.AddInParameter(SqlCommand, "@NumGuiaRemision", SqlDbType.Char, NumGuiaRemision);
            SqlClient.AddInParameter(SqlCommand, "@TipoGuia", SqlDbType.Char, TipoGuia);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public DataTable GetDetalleGuiaRemisionPeso(string NumGuiaRemision)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_GetDetalleGuiaRemisionPeso");

            SqlClient.AddInParameter(SqlCommand, "@NumGuiaRemision", SqlDbType.Char, NumGuiaRemision);

            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
            return dtTmp;
        }

        public bool UpdateGuiaRemisionEstado(string NumGuiaRemision, int EstadoID, string Tipo, int UsuarioID, string SedeID)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_UpdateGuiaRemisionEstado");
                SqlClient.AddInParameter(SqlCommandAccess, "@NumGuiaRemision", SqlDbType.Char, NumGuiaRemision);
                SqlClient.AddInParameter(SqlCommandAccess, "@EstadoID", SqlDbType.Int, EstadoID);
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

        public Int32 UpdateSerieGuiaT(string EmpresaSede, string SerieGuiaTID, Int32 GuiaTransporte)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                Int32 FilasAfectadas = 0;
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Almacen].[Usp_UpdateSerieGuiaT]");
                SqlClient.AddInParameter(SqlCommandAccess, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                SqlClient.AddInParameter(SqlCommandAccess, "@SerieGuiaTID", SqlDbType.Char, SerieGuiaTID);
                SqlClient.AddInParameter(SqlCommandAccess, "@GuiaTransporte", SqlDbType.Int, GuiaTransporte);
                FilasAfectadas = Convert.ToInt32(SqlClient.ExecuteNonQuery(SqlCommandAccess, tran));

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();
                return FilasAfectadas;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public Int32 UpdateSerieGuiaR(string EmpresaSede, string SerieGuiaRID, Int32 GuiaRemitente)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                Int32 FilasAfectadas = 0;
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Almacen].[Usp_UpdateSerieGuiaR]");
                SqlClient.AddInParameter(SqlCommandAccess, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                SqlClient.AddInParameter(SqlCommandAccess, "@SerieGuiaRID", SqlDbType.Char, SerieGuiaRID);
                SqlClient.AddInParameter(SqlCommandAccess, "@GuiaRemitente", SqlDbType.Int, GuiaRemitente);
                FilasAfectadas = Convert.ToInt32(SqlClient.ExecuteNonQuery(SqlCommandAccess, tran));

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();
                return FilasAfectadas;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public void InsertSerieGuia(string EmpresaSede, string SerieGuiaRID, Int32 GuiaRemitente, string SerieGuiaTID, Int32 GuiaTransporte,string SerieGuiaNID,Int32 NotaCredito)
        {
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {
                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Almacen].[Usp_InsertSerieGuia]");
                SqlClient.AddInParameter(SqlCommandAccess, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                SqlClient.AddInParameter(SqlCommandAccess, "@SerieGuiaRID", SqlDbType.Char, SerieGuiaRID);
                SqlClient.AddInParameter(SqlCommandAccess, "@GuiaRemitente", SqlDbType.Int, GuiaRemitente);
                SqlClient.AddInParameter(SqlCommandAccess, "@SerieGuiaTID", SqlDbType.Char, SerieGuiaTID);
                SqlClient.AddInParameter(SqlCommandAccess, "@GuiaTransporte", SqlDbType.Int, GuiaTransporte);
                SqlClient.AddInParameter(SqlCommandAccess, "@SerieGuiaNID", SqlDbType.Char, SerieGuiaNID);
                SqlClient.AddInParameter(SqlCommandAccess, "@NotaCredito", SqlDbType.Int, NotaCredito);
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

        public DataTable GetSerieGuia(string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            SqlDatabase SqlClient = new SqlDatabase(connectionString);
            DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("[Almacen].[Usp_GetSerieGuia]");
            SqlClient.AddInParameter(SqlCommandAccess, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
            dtTmp.Load(SqlClient.ExecuteReader(SqlCommandAccess));
            return dtTmp;
        }

        public DataSet CrearGuias(DataTable DtPesoBruto, DataTable DtTara, decimal Bruto, E_GuiaRemision ObjGuiaRemision, string SedeID, string CamionEmpresaID,
            string Codigo, string Requerimiento, decimal Neto, decimal Tara, decimal Cantidad, decimal Recibido, decimal Solicitado, decimal Transito,
            decimal NroJabas, string NomSede, string AlmacenIDLocal, E_GuiaTransporte ObjGuiaTransporte, string SedeDestino, int UserID)
        {
            #region variables
            DataTable DetalleGuiaRemision;
            DataTable DetalleGuiaTransporte;
            string NumGuiaRemision ="";
            string NumGuiaTransportista="";

            DataTable DtGuias = new DataTable();
            DataSet Ds = new DataSet();
            #endregion

            #region Crear Guias
            SqlDatabase SqlClient = new SqlDatabase(connectionString);

            DbConnection tCnn;
            tCnn = SqlClient.CreateConnection();
            tCnn.Open();

            DbTransaction tran = tCnn.BeginTransaction();

            try
            {

                //insertar guia remision y obtener el codigo de registro insertado
                NumGuiaRemision = new CD_GuiaRemision(connectionString).InsertGuiaRemitente(ObjGuiaRemision, ObjGuiaRemision.EmpresaID + SedeID);

                #region Crear Tablas
                //detalles de guia de remision
                DetalleGuiaRemision = new DataTable();
                DetalleGuiaRemision.TableName = "DetalleGuiaRemision";
                DetalleGuiaRemision.Columns.Add("NumGuiaRemision", typeof(string));
                DetalleGuiaRemision.Columns.Add("ProductoID", typeof(string));
                DetalleGuiaRemision.Columns.Add("NumRequerimiento", typeof(string));
                DetalleGuiaRemision.Columns.Add("PesoNeto", typeof(decimal));
                DetalleGuiaRemision.Columns.Add("PesoTara", typeof(decimal));
                DetalleGuiaRemision.Columns.Add("CantidadEnviada", typeof(decimal));
                DetalleGuiaRemision.Columns.Add("CantidadRecibida", typeof(decimal));
                DetalleGuiaRemision.Columns.Add("EstadoID", typeof(int));

                //detalles de guia de transporte
                DetalleGuiaTransporte = new DataTable();
                DetalleGuiaTransporte.TableName = "DetalleGuiaTransportista";
                DetalleGuiaTransporte.Columns.Add("NumGuiaTransportista", typeof(string));
                DetalleGuiaTransporte.Columns.Add("ProductoID", typeof(string));
                DetalleGuiaTransporte.Columns.Add("NumRequerimiento", typeof(string));
                DetalleGuiaTransporte.Columns.Add("PesoNeto", typeof(decimal));
                DetalleGuiaTransporte.Columns.Add("PesoTara", typeof(decimal));
                DetalleGuiaTransporte.Columns.Add("CantidadEnviada", typeof(decimal));

                //tabla para actualizar el estado del requerimiento
                DataTable DtActuEstadoReq = new DataTable();
                DtActuEstadoReq.TableName = "DetalleRequerimiento";
                DtActuEstadoReq.Columns.Add("NumRequerimiento", typeof(string));
                DtActuEstadoReq.Columns.Add("CantidadTransito", typeof(decimal));
                DtActuEstadoReq.Columns.Add("ProductoID", typeof(string));
                DtActuEstadoReq.Columns.Add("EstadoID", typeof(int));

                //tabla para insertar el detalle del peso
                DataTable DtDetalleGuiaRemisionPeso = new DataTable();
                DtDetalleGuiaRemisionPeso = DtPesoBruto.Clone();
                DtDetalleGuiaRemisionPeso.TableName = "DetalleGuiaRemisionPeso";

                //Para almacenar Las guias creadas (devolverlas)
                DtGuias.TableName = "DtGuias";
                DtGuias.Columns.Add("ProductoID", typeof(string));
                DtGuias.Columns.Add("NumHojaDespacho", typeof(string));
                DtGuias.Columns.Add("NumGuiaRemision", typeof(string));
                DtGuias.Columns.Add("NumRequerimiento", typeof(string));
                DtGuias.Columns.Add("NroFactura", typeof(string));
                DtGuias.Columns.Add("TotalPeso", typeof(decimal));
                DtGuias.Columns.Add("Motivo", typeof(string));
                DtGuias.Columns.Add("NumGuiaTransportista", typeof(string));
                DtGuias.Columns.Add("Bultos", typeof(string));
                DtGuias.Columns.Add("IDProveedor", typeof(int));
                DtGuias.Columns.Add("FechaHora", typeof(DateTime));
                DtGuias.Columns.Add("NomSede", typeof(string));
                #endregion


                //insertar guia transporte y obtener el codigo de registro insertado
                if (ObjGuiaTransporte.Placa != null)
                    NumGuiaTransportista = new CD_GuiaTransportista(connectionString).InsertGuiaTransportista(ObjGuiaTransporte, AppSettings.EmpresaID + AppSettings.SedeID);
                else
                    NumGuiaTransportista = ""; //no necesita guia de transporte

                //analizar el stock y si se logro la actualizacion crear las guias
                //mueve kardex
                bool Actualizo;

                DbCommand SqlCommandAccess = SqlClient.GetStoredProcCommand("Almacen.Usp_UpdateStockSustraccion");
                SqlClient.AddInParameter(SqlCommandAccess, "@AlmacenID", SqlDbType.Char, AlmacenIDLocal);
                SqlClient.AddInParameter(SqlCommandAccess, "@ProductoID", SqlDbType.VarChar, Codigo);
                SqlClient.AddInParameter(SqlCommandAccess, "@StockSustraendo", SqlDbType.Decimal, Cantidad);
                SqlClient.AddInParameter(SqlCommandAccess, "@Tipo", SqlDbType.Char, "S");
                SqlClient.AddInParameter(SqlCommandAccess, "@AlmacenExterno", SqlDbType.Char, ObjGuiaRemision.EmpresaID + SedeDestino + AlmacenIDLocal.Substring(7));
                SqlClient.AddInParameter(SqlCommandAccess, "@MovimientoID", SqlDbType.TinyInt, 2);
                SqlClient.AddInParameter(SqlCommandAccess, "@TipoComprobante", SqlDbType.Char, "09");
                SqlClient.AddInParameter(SqlCommandAccess, "@Serie", SqlDbType.Char, NumGuiaRemision.Substring(2, 3));
                SqlClient.AddInParameter(SqlCommandAccess, "@Numero", SqlDbType.Int, Convert.ToInt32(NumGuiaRemision.Substring(6)));
                SqlClient.AddInParameter(SqlCommandAccess, "@TipoOperacion", SqlDbType.Char, "11");
                SqlClient.AddInParameter(SqlCommandAccess, "@UsuarioID", SqlDbType.Int, UserID);
                Actualizo = Convert.ToBoolean(SqlClient.ExecuteScalar(SqlCommandAccess, tran));

                if (Actualizo == true)
                {
                    //para detalle guia remision
                    DataRow RowGR = DetalleGuiaRemision.NewRow();
                    RowGR["NumGuiaRemision"] = NumGuiaRemision;
                    RowGR["ProductoID"] = Codigo;
                    RowGR["NumRequerimiento"] = Requerimiento;
                    RowGR["PesoNeto"] = Neto;
                    RowGR["PesoTara"] = Tara;
                    RowGR["CantidadEnviada"] = Cantidad;
                    RowGR["CantidadRecibida"] = DBNull.Value;
                    RowGR["EstadoID"] = 2;
                    DetalleGuiaRemision.Rows.Add(RowGR);

                    //para detalle guia transporte
                    if (NumGuiaTransportista != "")
                    {
                        DataRow RowGT = DetalleGuiaTransporte.NewRow();
                        RowGT["NumGuiaTransportista"] = NumGuiaTransportista;
                        RowGT["ProductoID"] = Codigo;
                        RowGT["NumRequerimiento"] = Requerimiento;
                        RowGT["PesoNeto"] = Neto;
                        RowGT["PesoTara"] = Tara;
                        RowGT["CantidadEnviada"] = Cantidad;
                        DetalleGuiaTransporte.Rows.Add(RowGT);
                    }
                    #region Calcular estado requerimiento
                    DataRow RowD2 = DtActuEstadoReq.NewRow();
                    RowD2["ProductoID"] = Codigo;
                    RowD2["NumRequerimiento"] = Requerimiento;


                    //identificar el estado actual del requerimiento
                    if (SedeID == "001PU")
                    {
                        if (Recibido + Cantidad == Solicitado)
                        {
                            //transito DESTINO total
                            RowD2["EstadoID"] = 9;
                        }
                        else if (Recibido + Cantidad < Solicitado)
                        {
                            //transito DESTINO parcial
                            RowD2["EstadoID"] = 8;
                        }
                    }
                    else
                    {
                        if (Recibido + Transito + Cantidad == Solicitado)
                        {
                            //transito total
                            RowD2["EstadoID"] = 2;
                        }
                        else if (Recibido + Transito + Cantidad < Solicitado)
                        {
                            //transito parcial
                            RowD2["EstadoID"] = 6;
                        }
                    }

                    /*siempre va a estar en transito porque la
                     transferencia es entre almacenes y no pasa por industria*/
                    RowD2["CantidadTransito"] = Cantidad;
                    DtActuEstadoReq.Rows.Add(RowD2);
                    #endregion

                    //para insertar DetalleGuiaRemisionPeso
                    foreach (DataRow Row3 in DtPesoBruto.Rows)
                    {
                        DataRow Row = DtDetalleGuiaRemisionPeso.NewRow();
                        Row["NumGuiaRemision"] = NumGuiaRemision;
                        Row["Cantidad"] = Row3["Cantidad"];
                        Row["Peso"] = Row3["Peso"];
                        Row["Tipo"] = Row3["Tipo"];
                        DtDetalleGuiaRemisionPeso.Rows.Add(Row);
                    }
                    foreach (DataRow Row4 in DtTara.Rows)
                    {
                        DataRow Row = DtDetalleGuiaRemisionPeso.NewRow();
                        Row["NumGuiaRemision"] = NumGuiaRemision;
                        Row["Cantidad"] = Row4["Cantidad"];
                        Row["Peso"] = Row4["Peso"];
                        Row["Tipo"] = Row4["Tipo"];
                        DtDetalleGuiaRemisionPeso.Rows.Add(Row);
                    }
                }
                else
                {
                    tran.Rollback();
                    throw new Exception("No existe stock suficiente del producto: '" + Codigo + "'.");
                }

                #region Insertar con XML
                //insertar detalles guia remision
                bool Valor;
                if (DetalleGuiaRemision.Rows.Count > 0)
                {
                    string xml = new BaseFunctions().GetXML(DetalleGuiaRemision).Replace("NewDataSet", "DocumentElement");
                    Valor = new CD_GuiaRemision(connectionString).InsertXMLDetalleGuiaRemision(xml);
                }

                //insertar detalle del peso
                if (DtDetalleGuiaRemisionPeso.Rows.Count > 0)
                {
                    string xml = new BaseFunctions().GetXML(DtDetalleGuiaRemisionPeso).Replace("NewDataSet", "DocumentElement");
                    Valor = new CD_GuiaRemision(connectionString).InsertXMLDetalleGuiaRemisionPeso(xml);
                }

                //insertar detalle guia de transporte
                if (DetalleGuiaTransporte.Rows.Count > 0)
                {
                    string xml = new BaseFunctions().GetXML(DetalleGuiaTransporte).Replace("NewDataSet", "DocumentElement");
                    Valor = new CD_GuiaTransportista(connectionString).InsertXMLDetalleGuiaTransporte(xml);
                }

                //actualizar estado de los requerimientos
                if (DtActuEstadoReq.Rows.Count > 0)
                {
                    string xml = new BaseFunctions().GetXML(DtActuEstadoReq).Replace("NewDataSet", "DocumentElement");
                    Valor = new CD_Requerimientos(connectionString).UpdateXMLDetalleRequerimientoEstado(xml, "E", UserID, SedeID);
                }
                #endregion

                tran.Commit();
                tCnn.Close();
                tCnn.Dispose();
                SqlCommandAccess.Dispose();

                #region mostrar en grilla las guias
                //Agregar Guias creadas a la grilla y mostrarlos

                DataRow RowG = DtGuias.NewRow();
                RowG["ProductoID"] = Codigo;
                RowG["NumHojaDespacho"] = "";
                RowG["NumGuiaRemision"] = NumGuiaRemision;
                RowG["NumRequerimiento"] = Requerimiento;
                RowG["NroFactura"] = "";
                RowG["TotalPeso"] = Neto;
                RowG["Motivo"] = "Envio a varios lugares";
                RowG["NumGuiaTransportista"] = NumGuiaTransportista;
                RowG["Bultos"] = NroJabas + " unidades";
                RowG["IDProveedor"] = 0;
                RowG["FechaHora"] = DateTime.Now;
                RowG["NomSede"] = NomSede;
                DtGuias.Rows.Add(RowG);

                #endregion
                Ds.Tables.Add(DtGuias);
                return Ds;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }

            
            #endregion
        }

        public DataSet CrearGuiaRemitente(E_GuiaRemision CabeceraGuiaRemision, DataTable DtDetalleGuiaRemisionVenta, string EmpresaSede)
        {
            string NumGuiaRemision;
            DataSet Ds = new DataSet();
            #region crear tabla cabecera
            DataTable DtCabecera = new DataTable("DtCabecera");
            DtCabecera.Columns.Add("NumGuiaRemision", typeof(string));
            DtCabecera.Columns.Add("EmpresaID", typeof(string));
            DtCabecera.Columns.Add("NroJabas", typeof(Int32));
            DtCabecera.Columns.Add("DesAnimal", typeof(string));
            DtCabecera.Columns.Add("NroGalpon", typeof(Int32));
            DtCabecera.Columns.Add("DomicilioPartida", typeof(string));
            DtCabecera.Columns.Add("NroDomicilioPartida", typeof(Int32));
            DtCabecera.Columns.Add("InteriorDomicilioPartida", typeof(Int32));
            DtCabecera.Columns.Add("ZonaDomicilioPartida", typeof(string));
            DtCabecera.Columns.Add("DistritoDomicilioPartida", typeof(string));
            DtCabecera.Columns.Add("ProvinciaDomicilioPartida", typeof(string));
            DtCabecera.Columns.Add("DepartamentoDomicilioPartida", typeof(string));
            DtCabecera.Columns.Add("DomicilioLlegada", typeof(string));
            DtCabecera.Columns.Add("NroDomicilioLlegada", typeof(Int32));
            DtCabecera.Columns.Add("IntDomicilioLlegada", typeof(Int32));
            DtCabecera.Columns.Add("ZonaDomicilioLlegada", typeof(string));
            DtCabecera.Columns.Add("DisDomicilioLlegada", typeof(string));
            DtCabecera.Columns.Add("ProvDomicilioLlegada", typeof(string));
            DtCabecera.Columns.Add("DepDomicilioLlegada", typeof(string));
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
            DtCabecera.Columns.Add("NroFactura", typeof(string));
            DtCabecera.Columns.Add("EmpresaTransporte", typeof(string));
            DtCabecera.Columns.Add("RUCTransporte", typeof(string));
            DtCabecera.Columns.Add("Pesador", typeof(string));
            DtCabecera.Columns.Add("Galponero", typeof(string));
            DtCabecera.Columns.Add("UsuarioID", typeof(Int32));
            DtCabecera.Columns.Add("EstadoID", typeof(Int32));
            #endregion

            #region crear tabla detalle
            DataTable DtDetalleGuiaRemitente = new DataTable("DetalleGuiaRemisionVenta");
            DtDetalleGuiaRemitente.Columns.Add("NumGuiaRemision", typeof(string));
            DtDetalleGuiaRemitente.Columns.Add("ProductoID", typeof(string));
            DtDetalleGuiaRemitente.Columns.Add("CantidadEnviada", typeof(decimal));
            DtDetalleGuiaRemitente.Columns.Add("NomProducto", typeof(string));
            DtDetalleGuiaRemitente.Columns.Add("UnidadMedidaID", typeof(string));
            DtDetalleGuiaRemitente.Columns.Add("PesoNeto", typeof(decimal));
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
                        DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertGuiaRemitente");
                        #region Cabecera guia
                        SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, CabeceraGuiaRemision.EmpresaID);
                        SqlClient.AddInParameter(SqlCommand, "@NroJabas", SqlDbType.Int, CabeceraGuiaRemision.NroJabas);
                        SqlClient.AddInParameter(SqlCommand, "@DesAnimal", SqlDbType.VarChar, CabeceraGuiaRemision.DesAnimal);
                        SqlClient.AddInParameter(SqlCommand, "@NroGalpon", SqlDbType.Int, CabeceraGuiaRemision.NroGalpon);
                        SqlClient.AddInParameter(SqlCommand, "@DomicilioPartida", SqlDbType.VarChar, CabeceraGuiaRemision.DomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@NroDomicilioPartida", SqlDbType.Int, CabeceraGuiaRemision.NroDomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@InteriorDomicilioPartida", SqlDbType.Int, CabeceraGuiaRemision.InteriorDomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@ZonaDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaRemision.ZonaDomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@DistritoDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaRemision.DistritoDomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@ProvinciaDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaRemision.ProvinciaDomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@DepartamentoDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaRemision.DepartamentoDomicilioPartida);
                        SqlClient.AddInParameter(SqlCommand, "@DomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaRemision.DomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@NroDomicilioLlegada", SqlDbType.Int, CabeceraGuiaRemision.NroDomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@IntDomicilioLlegada", SqlDbType.Int, CabeceraGuiaRemision.IntDomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@ZonaDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaRemision.ZonaDomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@DisDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaRemision.DisDomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@ProvDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaRemision.ProvDomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@DepDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaRemision.DepDomicilioLlegada);
                        SqlClient.AddInParameter(SqlCommand, "@Destinatario", SqlDbType.VarChar, CabeceraGuiaRemision.Destinatario);
                        SqlClient.AddInParameter(SqlCommand, "@RUCDestinatario", SqlDbType.Char, CabeceraGuiaRemision.RUCDestinatario);
                        SqlClient.AddInParameter(SqlCommand, "@DireccionDestinatario", SqlDbType.VarChar, CabeceraGuiaRemision.DireccionDestinatario);
                        SqlClient.AddInParameter(SqlCommand, "@ObservacionDestinatario", SqlDbType.VarChar, CabeceraGuiaRemision.ObservacionDestinatario);
                        SqlClient.AddInParameter(SqlCommand, "@Marca", SqlDbType.VarChar, CabeceraGuiaRemision.Marca);
                        SqlClient.AddInParameter(SqlCommand, "@Placa", SqlDbType.VarChar, CabeceraGuiaRemision.Placa);
                        SqlClient.AddInParameter(SqlCommand, "@Carrosa", SqlDbType.VarChar, CabeceraGuiaRemision.Carrosa);
                        SqlClient.AddInParameter(SqlCommand, "@NombreChofer", SqlDbType.VarChar, CabeceraGuiaRemision.NombreChofer);
                        SqlClient.AddInParameter(SqlCommand, "@DNIChofer", SqlDbType.Char, CabeceraGuiaRemision.DNIChofer);
                        SqlClient.AddInParameter(SqlCommand, "@FechaSalida", SqlDbType.DateTime, CabeceraGuiaRemision.FechaSalida);
                        SqlClient.AddInParameter(SqlCommand, "@ConfiguracionVehicular", SqlDbType.VarChar, CabeceraGuiaRemision.ConfiguracionVehicular);
                        SqlClient.AddInParameter(SqlCommand, "@NroConstInscripcion", SqlDbType.Int, CabeceraGuiaRemision.NroConstInscripcion);
                        SqlClient.AddInParameter(SqlCommand, "@NroLicTransportista", SqlDbType.VarChar, CabeceraGuiaRemision.NroLicTransportista);
                        SqlClient.AddInParameter(SqlCommand, "@NroFactura", SqlDbType.VarChar, CabeceraGuiaRemision.NroFactura);
                        SqlClient.AddInParameter(SqlCommand, "@EmpresaTransporte", SqlDbType.VarChar, CabeceraGuiaRemision.EmpresaTransporte);
                        SqlClient.AddInParameter(SqlCommand, "@RUCTransporte", SqlDbType.Char, CabeceraGuiaRemision.RUCTransporte);
                        SqlClient.AddInParameter(SqlCommand, "@Pesador", SqlDbType.VarChar, CabeceraGuiaRemision.Pesador);
                        SqlClient.AddInParameter(SqlCommand, "@Galponero", SqlDbType.VarChar, CabeceraGuiaRemision.Galponero);
                        SqlClient.AddInParameter(SqlCommand, "@TipoGuia", SqlDbType.VarChar, CabeceraGuiaRemision.TipoGuia);
                        SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, CabeceraGuiaRemision.UsuarioID);

                        SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                        #endregion
                        NumGuiaRemision = Convert.ToString(SqlClient.ExecuteScalar(SqlCommand, tran));

                        #region Agregar Cabecera
                        DataRow DRC = DtCabecera.NewRow();
                        DRC["NumGuiaRemision"] = NumGuiaRemision;
                        DRC["EmpresaID"] = CabeceraGuiaRemision.EmpresaID;
                        DRC["NroJabas"] = CabeceraGuiaRemision.NroJabas;
                        DRC["DesAnimal"] = CabeceraGuiaRemision.DesAnimal;
                        DRC["NroGalpon"] = CabeceraGuiaRemision.NroGalpon;
                        DRC["DomicilioPartida"] = CabeceraGuiaRemision.DomicilioPartida;
                        DRC["NroDomicilioPartida"] = CabeceraGuiaRemision.NroDomicilioPartida;
                        DRC["InteriorDomicilioPartida"] = CabeceraGuiaRemision.InteriorDomicilioPartida;
                        DRC["ZonaDomicilioPartida"] = CabeceraGuiaRemision.ZonaDomicilioPartida;
                        DRC["DistritoDomicilioPartida"] = CabeceraGuiaRemision.DistritoDomicilioPartida;
                        DRC["ProvinciaDomicilioPartida"] = CabeceraGuiaRemision.ProvinciaDomicilioPartida;
                        DRC["DepartamentoDomicilioPartida"] = CabeceraGuiaRemision.DepartamentoDomicilioPartida;
                        DRC["DomicilioLlegada"] = CabeceraGuiaRemision.DomicilioLlegada;
                        DRC["NroDomicilioLlegada"] = CabeceraGuiaRemision.NroDomicilioLlegada;
                        DRC["IntDomicilioLlegada"] = CabeceraGuiaRemision.IntDomicilioLlegada;
                        DRC["ZonaDomicilioLlegada"] = CabeceraGuiaRemision.ZonaDomicilioLlegada;
                        DRC["DisDomicilioLlegada"] = CabeceraGuiaRemision.DisDomicilioLlegada;
                        DRC["ProvDomicilioLlegada"] = CabeceraGuiaRemision.ProvDomicilioLlegada;
                        DRC["DepDomicilioLlegada"] = CabeceraGuiaRemision.DepDomicilioLlegada;
                        DRC["Destinatario"] = CabeceraGuiaRemision.Destinatario;
                        DRC["RUCDestinatario"] = CabeceraGuiaRemision.RUCDestinatario;
                        DRC["DireccionDestinatario"] = CabeceraGuiaRemision.DireccionDestinatario;
                        DRC["ObservacionDestinatario"] = CabeceraGuiaRemision.ObservacionDestinatario;
                        DRC["Marca"] = CabeceraGuiaRemision.Marca;
                        DRC["Placa"] = CabeceraGuiaRemision.Placa;
                        DRC["Carrosa"] = CabeceraGuiaRemision.Carrosa;
                        DRC["NombreChofer"] = CabeceraGuiaRemision.NombreChofer;
                        DRC["DNIChofer"] = CabeceraGuiaRemision.DNIChofer;
                        DRC["FechaSalida"] = CabeceraGuiaRemision.FechaSalida;
                        DRC["ConfiguracionVehicular"] = CabeceraGuiaRemision.ConfiguracionVehicular;
                        DRC["NroConstInscripcion"] = CabeceraGuiaRemision.NroConstInscripcion;
                        DRC["NroLicTransportista"] = CabeceraGuiaRemision.NroLicTransportista;
                        DRC["NroFactura"] = CabeceraGuiaRemision.NroFactura;
                        DRC["EmpresaTransporte"] = CabeceraGuiaRemision.EmpresaTransporte;
                        DRC["RUCTransporte"] = CabeceraGuiaRemision.RUCTransporte;
                        DRC["Pesador"] = CabeceraGuiaRemision.Pesador;
                        DRC["Galponero"] = CabeceraGuiaRemision.Galponero;
                        DRC["UsuarioID"] = CabeceraGuiaRemision.UsuarioID;
                        DRC["EstadoID"] = 0;
                        DtCabecera.Rows.Add(DRC);

                        #endregion

                        string xml, xmlDetalle;
                        xml = new BaseFunctions().GetXML(NewDtDetalleGuiaRemisionVenta).Replace("NewDataSet", "DocumentElement");
                        xmlDetalle = xml.Replace("Table", "DetalleGuiaRemision");

                        DbCommand SqlCommand2 = SqlClientD.GetStoredProcCommand("Almacen.Usp_Insert_XMLDetalleGuiaRemisionVenta2");
                        SqlClientD.AddInParameter(SqlCommand2, "@XML", SqlDbType.Xml, xmlDetalle);
                        SqlClientD.AddInParameter(SqlCommand2, "@NumGuiaRemision", SqlDbType.Char, NumGuiaRemision);
                        SqlClientD.ExecuteNonQuery(SqlCommand2, tran);

                        #region agregar detalles

                        foreach (DataRow DR in NewDtDetalleGuiaRemisionVenta.Rows)
                        {
                            DataRow DRD = DtDetalleGuiaRemitente.NewRow();
                            DRD["NumGuiaRemision"] = NumGuiaRemision;
                            DRD["ProductoID"] = DR["ProductoID"];
                            DRD["CantidadEnviada"] = DR["CantidadEnviada"];
                            DRD["NomProducto"] = DR["NomProducto"];
                            DRD["UnidadMedidaID"] = DR["UnidadMedidaID"];
                            DRD["PesoNeto"] = DR["PesoNeto"];
                            DtDetalleGuiaRemitente.Rows.Add(DRD);
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
                    DbCommand SqlCommand = SqlClient.GetStoredProcCommand("Almacen.Usp_InsertGuiaRemitente");
                    #region Cabecera guia
                    SqlClient.AddInParameter(SqlCommand, "@EmpresaID", SqlDbType.Char, CabeceraGuiaRemision.EmpresaID);
                    SqlClient.AddInParameter(SqlCommand, "@NroJabas", SqlDbType.Int, CabeceraGuiaRemision.NroJabas);
                    SqlClient.AddInParameter(SqlCommand, "@DesAnimal", SqlDbType.VarChar, CabeceraGuiaRemision.DesAnimal);
                    SqlClient.AddInParameter(SqlCommand, "@NroGalpon", SqlDbType.Int, CabeceraGuiaRemision.NroGalpon);
                    SqlClient.AddInParameter(SqlCommand, "@DomicilioPartida", SqlDbType.VarChar, CabeceraGuiaRemision.DomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@NroDomicilioPartida", SqlDbType.Int, CabeceraGuiaRemision.NroDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@InteriorDomicilioPartida", SqlDbType.Int, CabeceraGuiaRemision.InteriorDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@ZonaDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaRemision.ZonaDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@DistritoDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaRemision.DistritoDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@ProvinciaDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaRemision.ProvinciaDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@DepartamentoDomicilioPartida", SqlDbType.VarChar, CabeceraGuiaRemision.DepartamentoDomicilioPartida);
                    SqlClient.AddInParameter(SqlCommand, "@DomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaRemision.DomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@NroDomicilioLlegada", SqlDbType.Int, CabeceraGuiaRemision.NroDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@IntDomicilioLlegada", SqlDbType.Int, CabeceraGuiaRemision.IntDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@ZonaDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaRemision.ZonaDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@DisDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaRemision.DisDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@ProvDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaRemision.ProvDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@DepDomicilioLlegada", SqlDbType.VarChar, CabeceraGuiaRemision.DepDomicilioLlegada);
                    SqlClient.AddInParameter(SqlCommand, "@Destinatario", SqlDbType.VarChar, CabeceraGuiaRemision.Destinatario);
                    SqlClient.AddInParameter(SqlCommand, "@RUCDestinatario", SqlDbType.Char, CabeceraGuiaRemision.RUCDestinatario);
                    SqlClient.AddInParameter(SqlCommand, "@DireccionDestinatario", SqlDbType.VarChar, CabeceraGuiaRemision.DireccionDestinatario);
                    SqlClient.AddInParameter(SqlCommand, "@ObservacionDestinatario", SqlDbType.VarChar, CabeceraGuiaRemision.ObservacionDestinatario);
                    SqlClient.AddInParameter(SqlCommand, "@Marca", SqlDbType.VarChar, CabeceraGuiaRemision.Marca);
                    SqlClient.AddInParameter(SqlCommand, "@Placa", SqlDbType.VarChar, CabeceraGuiaRemision.Placa);
                    SqlClient.AddInParameter(SqlCommand, "@Carrosa", SqlDbType.VarChar, CabeceraGuiaRemision.Carrosa);
                    SqlClient.AddInParameter(SqlCommand, "@NombreChofer", SqlDbType.VarChar, CabeceraGuiaRemision.NombreChofer);
                    SqlClient.AddInParameter(SqlCommand, "@DNIChofer", SqlDbType.Char, CabeceraGuiaRemision.DNIChofer);
                    SqlClient.AddInParameter(SqlCommand, "@FechaSalida", SqlDbType.DateTime, CabeceraGuiaRemision.FechaSalida);
                    SqlClient.AddInParameter(SqlCommand, "@ConfiguracionVehicular", SqlDbType.VarChar, CabeceraGuiaRemision.ConfiguracionVehicular);
                    SqlClient.AddInParameter(SqlCommand, "@NroConstInscripcion", SqlDbType.Int, CabeceraGuiaRemision.NroConstInscripcion);
                    SqlClient.AddInParameter(SqlCommand, "@NroLicTransportista", SqlDbType.VarChar, CabeceraGuiaRemision.NroLicTransportista);
                    SqlClient.AddInParameter(SqlCommand, "@NroFactura", SqlDbType.VarChar, CabeceraGuiaRemision.NroFactura);
                    SqlClient.AddInParameter(SqlCommand, "@EmpresaTransporte", SqlDbType.VarChar, CabeceraGuiaRemision.EmpresaTransporte);
                    SqlClient.AddInParameter(SqlCommand, "@RUCTransporte", SqlDbType.Char, CabeceraGuiaRemision.RUCTransporte);
                    SqlClient.AddInParameter(SqlCommand, "@Pesador", SqlDbType.VarChar, CabeceraGuiaRemision.Pesador);
                    SqlClient.AddInParameter(SqlCommand, "@Galponero", SqlDbType.VarChar, CabeceraGuiaRemision.Galponero);
                    SqlClient.AddInParameter(SqlCommand, "@TipoGuia", SqlDbType.VarChar, CabeceraGuiaRemision.TipoGuia);
                    SqlClient.AddInParameter(SqlCommand, "@UsuarioID", SqlDbType.Int, CabeceraGuiaRemision.UsuarioID);

                    SqlClient.AddInParameter(SqlCommand, "@EmpresaSede", SqlDbType.Char, EmpresaSede);
                    #endregion
                    NumGuiaRemision = Convert.ToString(SqlClient.ExecuteScalar(SqlCommand, tran));

                    #region Agregar Cabecera
                    DataRow DRC = DtCabecera.NewRow();
                    DRC["NumGuiaRemision"] = NumGuiaRemision;
                    DRC["EmpresaID"] = CabeceraGuiaRemision.EmpresaID;
                    DRC["NroJabas"] = CabeceraGuiaRemision.NroJabas;
                    DRC["DesAnimal"] = CabeceraGuiaRemision.DesAnimal;
                    DRC["NroGalpon"] = CabeceraGuiaRemision.NroGalpon;
                    DRC["DomicilioPartida"] = CabeceraGuiaRemision.DomicilioPartida;
                    DRC["NroDomicilioPartida"] = CabeceraGuiaRemision.NroDomicilioPartida;
                    DRC["InteriorDomicilioPartida"] = CabeceraGuiaRemision.InteriorDomicilioPartida;
                    DRC["ZonaDomicilioPartida"] = CabeceraGuiaRemision.ZonaDomicilioPartida;
                    DRC["DistritoDomicilioPartida"] = CabeceraGuiaRemision.DistritoDomicilioPartida;
                    DRC["ProvinciaDomicilioPartida"] = CabeceraGuiaRemision.ProvinciaDomicilioPartida;
                    DRC["DepartamentoDomicilioPartida"] = CabeceraGuiaRemision.DepartamentoDomicilioPartida;
                    DRC["DomicilioLlegada"] = CabeceraGuiaRemision.DomicilioLlegada;
                    DRC["NroDomicilioLlegada"] = CabeceraGuiaRemision.NroDomicilioLlegada;
                    DRC["IntDomicilioLlegada"] = CabeceraGuiaRemision.IntDomicilioLlegada;
                    DRC["ZonaDomicilioLlegada"] = CabeceraGuiaRemision.ZonaDomicilioLlegada;
                    DRC["DisDomicilioLlegada"] = CabeceraGuiaRemision.DisDomicilioLlegada;
                    DRC["ProvDomicilioLlegada"] = CabeceraGuiaRemision.ProvDomicilioLlegada;
                    DRC["DepDomicilioLlegada"] = CabeceraGuiaRemision.DepDomicilioLlegada;
                    DRC["Destinatario"] = CabeceraGuiaRemision.Destinatario;
                    DRC["RUCDestinatario"] = CabeceraGuiaRemision.RUCDestinatario;
                    DRC["DireccionDestinatario"] = CabeceraGuiaRemision.DireccionDestinatario;
                    DRC["ObservacionDestinatario"] = CabeceraGuiaRemision.ObservacionDestinatario;
                    DRC["Marca"] = CabeceraGuiaRemision.Marca;
                    DRC["Placa"] = CabeceraGuiaRemision.Placa;
                    DRC["Carrosa"] = CabeceraGuiaRemision.Carrosa;
                    DRC["NombreChofer"] = CabeceraGuiaRemision.NombreChofer;
                    DRC["DNIChofer"] = CabeceraGuiaRemision.DNIChofer;
                    DRC["FechaSalida"] = CabeceraGuiaRemision.FechaSalida;
                    DRC["ConfiguracionVehicular"] = CabeceraGuiaRemision.ConfiguracionVehicular;
                    DRC["NroConstInscripcion"] = CabeceraGuiaRemision.NroConstInscripcion;
                    DRC["NroLicTransportista"] = CabeceraGuiaRemision.NroLicTransportista;
                    DRC["NroFactura"] = CabeceraGuiaRemision.NroFactura;
                    DRC["EmpresaTransporte"] = CabeceraGuiaRemision.EmpresaTransporte;
                    DRC["RUCTransporte"] = CabeceraGuiaRemision.RUCTransporte;
                    DRC["Pesador"] = CabeceraGuiaRemision.Pesador;
                    DRC["Galponero"] = CabeceraGuiaRemision.Galponero;
                    DRC["UsuarioID"] = CabeceraGuiaRemision.UsuarioID;
                    DRC["EstadoID"] = 0;
                    DtCabecera.Rows.Add(DRC);

                    #endregion

                    string xml, xmlDetalle;
                    xml = new BaseFunctions().GetXML(NewDtDetalleGuiaRemisionVenta).Replace("NewDataSet", "DocumentElement");
                    xmlDetalle = xml.Replace("Table", "DetalleGuiaRemision");

                    DbCommand SqlCommand2 = SqlClient.GetStoredProcCommand("Almacen.Usp_Insert_XMLDetalleGuiaRemisionVenta2");
                    SqlClientD.AddInParameter(SqlCommand2, "@NumGuiaRemision", SqlDbType.Char, NumGuiaRemision);
                    SqlClientD.AddInParameter(SqlCommand2, "@XML", SqlDbType.Xml, xmlDetalle);
                    SqlClientD.ExecuteNonQuery(SqlCommand2, tran);

                    #region agregar detalles
                    
                    foreach (DataRow DR in NewDtDetalleGuiaRemisionVenta.Rows)
                    {
                        DataRow DRD = DtDetalleGuiaRemitente.NewRow();
                        DRD["NumGuiaRemision"] = NumGuiaRemision;
                        DRD["ProductoID"] = DR["ProductoID"];
                        DRD["CantidadEnviada"] = DR["CantidadEnviada"];
                        DRD["NomProducto"] = DR["NomProducto"];
                        DRD["UnidadMedidaID"] = DR["UnidadMedidaID"];
                        DRD["PesoNeto"] = DR["PesoNeto"];
                        DtDetalleGuiaRemitente.Rows.Add(DRD);
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
                Ds.Tables.Add(DtDetalleGuiaRemitente);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Halley.CapaDatos.Almacen;
using Halley.Configuracion;
using Halley.Entidad.Almacen;
using System.Data;

namespace Halley.CapaLogica.Almacen
{
    public class CL_GuiaRemision
    {

        public string InsertGuiaRemitente_Venta(E_GuiaRemision Obj_GuiaRemision,E_GuiaTransporte Obj_GuiaTransporte, DataTable dtVenta_Diferida, string EmpresaSede, string Documento,int UsuarioID,bool Condicion)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);

            //Creamos una tabla para la generación de guia de remision
            DataTable dtGuiaRemision;
            dtGuiaRemision = new DataTable();
            dtGuiaRemision.Columns.Add("ProductoID", typeof(string));                                               
            dtGuiaRemision.Columns.Add("Cantidad_Entregada", typeof(decimal));
            dtGuiaRemision.Columns.Add("CantidadEnviada", typeof(decimal));
            dtGuiaRemision.Columns.Add("Stock", typeof(decimal));
            dtGuiaRemision.Columns.Add("StockDisponible",typeof(decimal));
            dtGuiaRemision.Columns.Add("AlmacenID", typeof(string));
            dtGuiaRemision.Columns.Add("Cantidad_Diferida", typeof(decimal));

            //Filtrar  las lineas para la guia de remision
            foreach (DataRow Drow in dtVenta_Diferida.Rows)
            {
                if (Convert.ToDecimal(Drow["Despachar"]) != 0)
                {
                    DataRow row;
                    row = dtGuiaRemision.NewRow();
                    row["ProductoID"] = Drow["Codigo"].ToString();
                    row["Cantidad_Entregada"] = Drow["Cantidad_Entregada"].ToString();
                    row["CantidadEnviada"] = Drow["Despachar"].ToString();
                    row["Stock"] = Drow["Despachar"].ToString();
                    row["StockDisponible"] = Drow["Despachar"].ToString();
                    row["AlmacenID"] = Drow["AlmacenID"].ToString();
                    row["Cantidad_Diferida"] = Convert.ToDecimal(Drow["Cantidad_Entregada"].ToString()) + Convert.ToDecimal(Drow["Despachar"].ToString());
                    dtGuiaRemision.Rows.Add(row);
                }
            }
            return objCD_GuiaRemision.InsertGuiaRemitente_Venta(Obj_GuiaRemision,Obj_GuiaTransporte, dtGuiaRemision, EmpresaSede, Documento,UsuarioID,Condicion);
        }

        public string InsertGuiaRemitente(E_GuiaRemision ObjGuiaRemision, string EmpresaSede)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            string NumGuiaRemision;

            NumGuiaRemision = objCD_GuiaRemision.InsertGuiaRemitente(ObjGuiaRemision, EmpresaSede);
            return NumGuiaRemision;
        }
        public bool InsertXMLDetalleGuiaRemision(string xml)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            bool Valor;

            Valor = objCD_GuiaRemision.InsertXMLDetalleGuiaRemision(xml);
            return Valor;
        }
        public bool InsertXMLDetalleGuiaRemisionPeso(string xml)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            bool Valor;

            Valor = objCD_GuiaRemision.InsertXMLDetalleGuiaRemisionPeso(xml);
            return Valor;
        }

        public DataTable GetRecepcionGuiaRemisionPeso(string NumGuiaRemision)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_GuiaRemision.GetRecepcionGuiaRemisionPeso(NumGuiaRemision);
            return Temp;
        }

        public DataTable Get_GuiaRemision(string NumDocumento)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_GuiaRemision.Get_GuiaRemision(NumDocumento);
            return Temp;
        }

        public bool UpdateXMLDetalleGuiaRemision(string xml, string Tipo)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            bool Valor;

            Valor = objCD_GuiaRemision.UpdateXMLDetalleGuiaRemision(xml, Tipo);
            return Valor;
        }

        public DataTable GetCabeceraGuiaRemision(string NumGuiaRemision)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_GuiaRemision.GetCabeceraGuiaRemision(NumGuiaRemision);
            return Temp;
        }

        public DataTable GetDetalleGuiaRemision(string NumGuiaRemision, string TipoGuia)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_GuiaRemision.GetDetalleGuiaRemision(NumGuiaRemision, TipoGuia);
            return Temp;
        }

        public DataTable GetDetalleGuiaRemisionPeso(string NumGuiaRemision)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_GuiaRemision.GetDetalleGuiaRemisionPeso(NumGuiaRemision);
            return Temp;
        }

        public bool UpdateGuiaRemisionEstado(string NumGuiaRemision, int EstadoID, string Tipo, int UsuarioID, string SedeID)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            bool Valor;

            Valor = objCD_GuiaRemision.UpdateGuiaRemisionEstado(NumGuiaRemision, EstadoID, Tipo, UsuarioID, SedeID);
            return Valor;
        }

        public Int32 UpdateSerieGuiaT(string EmpresaSede, string SerieGuiaTID, Int32 GuiaTransporte)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            Int32 Valor;

            Valor = objCD_GuiaRemision.UpdateSerieGuiaT(EmpresaSede, SerieGuiaTID, GuiaTransporte);
            return Valor;
        }

        public Int32 UpdateSerieGuiaR(string EmpresaSede, string SerieGuiaRID, Int32 GuiaRemitente)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            Int32 Valor;

            Valor = objCD_GuiaRemision.UpdateSerieGuiaR(EmpresaSede, SerieGuiaRID, GuiaRemitente);
            return Valor;
        }

        public void InsertSerieGuia(string EmpresaSede, string SerieGuiaRID, Int32 GuiaRemitente, string SerieGuiaTID, Int32 GuiaTransporte, string SerieGuiaNID, Int32 NotaCredito)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            objCD_GuiaRemision.InsertSerieGuia(EmpresaSede, SerieGuiaRID, GuiaRemitente, SerieGuiaTID, GuiaTransporte,SerieGuiaNID,NotaCredito);

        }

        public DataTable GetSerieGuia(string EmpresaSede)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_GuiaRemision.GetSerieGuia(EmpresaSede);
            return Temp;
        }

        public DataSet CrearGuias(DataTable DtPesoBruto, DataTable DtTara, decimal Bruto, E_GuiaRemision ObjGuiaRemision, string SedeID, string CamionEmpresaID,
                                    string Codigo, string Requerimiento, decimal Neto, decimal Tara, decimal Cantidad, decimal Recibido, decimal Solicitado, decimal Transito,
                                    decimal NroJabas, string NomSede, string AlmacenIDLocal, E_GuiaTransporte ObjGuiaTransporte, string SedeDestino, int UserID)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();
            Ds = objCD_GuiaRemision.CrearGuias(DtPesoBruto, DtTara, Bruto, ObjGuiaRemision, SedeID, CamionEmpresaID, Codigo, Requerimiento, Neto, Tara,
                Cantidad, Recibido, Solicitado, Transito, NroJabas, NomSede, AlmacenIDLocal, ObjGuiaTransporte, SedeDestino, UserID);
            return Ds;
            

        }


        public DataSet CrearGuiaRemitente(E_GuiaRemision CabeceraGuiaRemision, DataTable DtDetalleGuiaRemision, string EmpresaSede)
        {
            CD_GuiaRemision objCD_GuiaRemision = new CD_GuiaRemision(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();
            Ds = objCD_GuiaRemision.CrearGuiaRemitente(CabeceraGuiaRemision, DtDetalleGuiaRemision, EmpresaSede);
            return Ds;
        }
    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Halley.CapaDatos.Ventas;
using Halley.Utilitario;
using Halley.Configuracion;
using Halley.Entidad.Ventas;

namespace Halley.CapaLogica.Ventas
{
    public class CL_Vales
    {

        public DataTable getComprobanteNavidenho()
        {
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Vale.getComprobanteNavidenho();
            return dtTMP;
        }

        public DataTable getAsignacionPorComprobante(string NumComprobante)
        {
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Vale.getAsignacionPorComprobante(NumComprobante);
            return dtTMP;
        }

        public DataTable getComprobante()
        {
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Vale.getComprobante();
            return dtTMP;
        }

        public void UpdateAsignacion(string NumComprobante, string operacion, int UsuarioId, DataTable dtOperacion)
        {
            string xml, xmlDetalle;
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);

            xml = new BaseFunctions().GetXML(dtOperacion).Replace("NewDataSet", "DocumentElement");
            xmlDetalle = xml.Replace("Table", "Asignacion");

            objCD_Vale.UpdateAsignacion(NumComprobante, operacion, UsuarioId, xmlDetalle);
        }


        public void Insert(int UsuarioID, string SedeID, DataTable dtVale, int TipoComprobanteID)
        {
            string xml, xmlDetalle;
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);

            xml = new BaseFunctions().GetXML(dtVale).Replace("NewDataSet", "DocumentElement");
            xmlDetalle = xml.Replace("Table", "Vales");

            objCD_Vale.Insert(UsuarioID, SedeID, xmlDetalle, TipoComprobanteID);
        }

        public void InsertPesos(int UsuarioID, string AlmacenID,decimal PesoTot, DataTable dtPeso,DataTable dtProducto)
        {
            string xml, xmlPeso, xmlProducto;
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);

            xml = new BaseFunctions().GetXML(dtPeso).Replace("NewDataSet", "DocumentElement");
            xmlPeso = xml.Replace("Table", "Peso");

            xml = null;
            dtProducto.TableName = "Producto";
            xml = new BaseFunctions().GetXML(dtProducto).Replace("NewDataSet", "DocumentElement");
            xmlProducto = xml.Replace("Table", "Producto");
            objCD_Vale.InsertPesos(UsuarioID, AlmacenID,PesoTot, xmlPeso, xmlProducto);
        }

        public int UpdateEntrega(E_Vale ObjVale)
        {
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);
            return objCD_Vale.UpdateEntrega(ObjVale);
        }


        public DataTable getReporteEntrega(string SedeID)
        {
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Vale.getReporteEntrega(SedeID);
            return dtTMP;
        }

        public DataRow getNumVale(int NumVale,string SedeID)
        {
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();
            dt = objCD_Vale.getNumVale(NumVale,SedeID);

            if (dt.Rows.Count == 0)
                return null;
            else
                return dt.Rows[0];
        }

        public DataSet getNumComprobante(string NumComprobante, Int32 TipoComprobanteID)
        {
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);
            DataSet dsComprobante = new DataSet();
            dsComprobante = objCD_Vale.gerNumComprobante(NumComprobante, TipoComprobanteID);
            return dsComprobante;
        }

        public int getUltimoVale()
        {
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);
            return objCD_Vale.getUltimoVale();            
        }

        public DataTable getdetalleVales(string NumComprobante, int TipoComprobanteID)
        {
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Vale.getdetalleVales(NumComprobante, TipoComprobanteID);
            return dtTMP;
        }

        //public DataTable getdetalleVales(string NumComprobante,int NumVale)
        //{
        //    CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);
        //    DataTable dtTMP = new DataTable();

        //    dtTMP = objCD_Vale.getdetalleVales(NumComprobante,NumVale);
        //    return dtTMP;
        //}

        public DataTable getProductosGenericos()
        {
            CD_Vales objCD_Vale = new CD_Vales(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Vale.getProductosGenericos();
            return dtTMP;
        }
    }
}

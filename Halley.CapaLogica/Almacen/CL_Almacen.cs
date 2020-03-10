using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Halley.CapaDatos.Users;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;
using Halley.CapaDatos.Almacen;
using Halley.Utilitario;

namespace Halley.CapaLogica.Almacen
{
    public class CL_Almacen
    {
        public static string Name
        {
            get { return "Almacen"; }
        }

        public DataTable GetMovimiento()
        {
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();

            dt = ObjCD_Almacen.GetMovimiento();
            return dt;
        }

        public DataTable ObtenerAlmacen(string EmpresaID)
        {
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();

            dt = ObjCD_Almacen.ObtenerAlmacen(EmpresaID);
            return dt;
        }

        public DataTable GetAlmacenCadenaStock(string Cadena, string ProductoID)
        {
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();

            dt = ObjCD_Almacen.GetAlmacenCadenaStock(Cadena, ProductoID);
            return dt;
        }

        public DataTable GetAlmacenCadena2(string Cadena)
        {
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();

            dt = ObjCD_Almacen.GetAlmacenCadena2(Cadena);
            return dt;
        }

        public DataTable Get_GuiaRemisionVenta(string Documento)
        {
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();

            dt = ObjCD_Almacen.Get_GuiaRemisionVenta(Documento);
            return dt;
        }

        public DataTable GetProductoAlmacenCadena(string Cadena,string ProductoID,string Tipo)
        {
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();

            dt = ObjCD_Almacen.GetProductoAlmacenCadena(Cadena,ProductoID,Tipo);
            return dt;
        }


        public bool UpdateStockSustraccion(string AlmacenID, string ProductoID, decimal StockSustraendo, string Tipo, string AlmacenDestino, int MovimientoID, string TipoComprobante, string Serie, int ?Numero, string TipoOperacion, int UsuarioID)
        {
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            bool Valor = false;

            Valor = ObjCD_Almacen.UpdateStockSustraccion(AlmacenID, ProductoID, StockSustraendo, Tipo, AlmacenDestino, MovimientoID, TipoComprobante, Serie,Numero,TipoOperacion, UsuarioID);
            return Valor;
        }

        public bool UpdateXMLStockAlmacen(string xml, int MovimientoID, int UsuarioID)
        {
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            bool Valor;

            Valor = ObjCD_Almacen.UpdateXMLStockAlmacen(xml, MovimientoID, UsuarioID);
            return Valor;

        }

        public void UpdateStockAdidion(string AlmacenIDLocal, string ProductoID, decimal StockAdicion, string NumRequerimiento, string Tipo)
        {
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            ObjCD_Almacen.UpdateStockAdidion(AlmacenIDLocal, ProductoID, StockAdicion, NumRequerimiento, Tipo);
        }

        public DataTable ObtenerAlmacen2(string EmpresaID, string SedeID)
        {
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            DataTable dt = new DataTable();

            dt = ObjCD_Almacen.ObtenerAlmacen2(EmpresaID, SedeID);
            return dt;
        }

        public void InsertStockAlmacen(string AlmacenID, string ProductoID, decimal Stock, decimal StockDisponible, decimal StockMinimo, decimal StockMaximo, int UsuarioID)
        {
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            ObjCD_Almacen.InsertStockAlmacen(AlmacenID, ProductoID, Stock, StockDisponible, StockMinimo, StockMaximo, UsuarioID);

        }

        public Int32 UpdateStockAlmacen(string AlmacenID, string ProductoID, decimal Stock, decimal StockDisponible, decimal StockMinimo, decimal StockMaximo, int UsuarioID)
        {
            Int32 FilasAfectadas = 0;
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            FilasAfectadas = ObjCD_Almacen.UpdateStockAlmacen(AlmacenID, ProductoID, Stock, StockDisponible, StockMinimo, StockMaximo, UsuarioID);
            return FilasAfectadas;
        }

        public DataTable getAlmacenDesperdicio(string EmpresaID, string SedeID)
        {
            DataTable dtTmp = new DataTable();
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            dtTmp = ObjCD_Almacen.getAlmacenDesperdicio(EmpresaID, SedeID);

            return dtTmp;
        }

        public void Transformar(DataTable DtProductosAgregar, string AlmacenIDT, string ProductoIDT, decimal StockSustraendo, int UserID)
        {

            #region bajar el producto terminado

            bool Actualizo = false;
            Actualizo = new CL_Almacen().UpdateStockSustraccion(AlmacenIDT, ProductoIDT, StockSustraendo, "D", AlmacenIDT, 9,"","",null, "", UserID);
            #endregion

            if (Actualizo == true)
            {
                //Agrupar los productos para almacenarlos
                DataTable DtProductoDis = new DataTable();
                DataTable DtActuStockLocal2 = new DataTable();
                DtActuStockLocal2.TableName = "StockAlmacen";

                DtActuStockLocal2.Columns.Add("AlmacenID", typeof(string));
                DtActuStockLocal2.Columns.Add("AlmacenOrigen", typeof(string));
                DtActuStockLocal2.Columns.Add("ProductoID", typeof(string));
                DtActuStockLocal2.Columns.Add("Adicion", typeof(decimal));
                DtActuStockLocal2.Columns.Add("NroDocumento", typeof(string));

                DtProductoDis = new BaseFunctions().SelectDistinct(DtProductosAgregar, "ProductoID", "Almacen");
                foreach (DataRow RowP in DtProductoDis.Rows)
                {
                    DataView Dv = new DataView(DtProductosAgregar);
                    Dv.RowFilter = "ProductoID = '" + RowP["ProductoID"] + "'";
                    decimal Suma = 0;
                    foreach (DataRowView Drv in Dv) //sumar las cantidades por producto
                    {
                        Suma += Convert.ToDecimal(Drv["Cantidad"]);
                    }
                    DataRow DrR = DtActuStockLocal2.NewRow();
                    DrR["AlmacenID"] = AlmacenIDT.Substring(0, 7) + Dv[0]["Almacen"];
                    DrR["AlmacenOrigen"] = AlmacenIDT;
                    DrR["ProductoID"] = Dv[0]["ProductoID"];
                    DrR["Adicion"] = Suma;
                    DrR["NroDocumento"] = null;
                    DtActuStockLocal2.Rows.Add(DrR);
                }

                #region actualizar con XML
                if (DtActuStockLocal2.Rows.Count > 0)
                {
                    bool Valor;
                    string xml1 = new BaseFunctions().GetXML(DtActuStockLocal2).Replace("NewDataSet", "DocumentElement");
                    Valor = new CL_Almacen().UpdateXMLStockAlmacen(xml1, 10, UserID);
                }
                #endregion
            }
            else
                throw new Exception("No existe stock suficiente");

        }

        public DataTable GetStockProducto(string ProductoID, string EmpresaSede)
        {
            DataTable dtTmp = new DataTable();
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);
            dtTmp = ObjCD_Almacen.GetStockProducto(ProductoID, EmpresaSede);

            return dtTmp;
        }

        public void InsertXMLDespachos(DataTable DtDespacho, int UsuarioID, int MovimientoID)
        {
            string xml, xmlDetalle;
            CD_Almacen ObjCD_Almacen = new CD_Almacen(AppSettings.GetConnectionString);

            xml = new BaseFunctions().GetXML(DtDespacho).Replace("NewDataSet", "DocumentElement");
            xmlDetalle = xml.Replace("Table", "Despacho");
            ObjCD_Almacen.InsertXMLDespachos(xmlDetalle, UsuarioID,MovimientoID);
        }
    }
}

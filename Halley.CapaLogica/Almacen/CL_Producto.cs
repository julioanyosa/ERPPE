using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Halley.CapaDatos.Almacen;
using Halley.Configuracion;
using System.Data;
using Halley.Entidad.Empresa;
using Halley.Entidad.Ventas;

namespace Halley.CapaLogica.Almacen
{
    public class CL_Producto
    {
        public static string Name
        {
            get { return "Producto"; }
        }

        public DataTable ObtenerStock(string AlmacenID)
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.ObtenerStock(AlmacenID);
            return dtTMP;
        
        }

        public DataTable ObtenerProductos(string SedeID)
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.ObtenerProductos(SedeID);
            return dtTMP;

        }


        public DataTable getProductos(string AlmacenID)
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.getProductos(AlmacenID);
            return dtTMP;

        }

        public DataTable GetMarca(string ProductoID)
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.GetMarca(ProductoID);
            return dtTMP;

        }

        public DataTable BuscarProductoAlmacen(string EmpresaID, string ProductoID, string SedeId)
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.BuscarProductoAlmacen(EmpresaID, ProductoID, SedeId);
            return dtTMP;
        }

        public DataTable GetProductosPeso()
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.GetProductosPeso();
            return dtTMP;
        
        }

        public DataTable GetProductos()
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.GetProductos();
            return dtTMP;
        }
        public DataTable GetProductosPrincipales(bool Valor)
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.GetProductosPrincipales(Valor);
            return dtTMP;
        }
        public DataTable GetProductosDerivados(string ProductoID)
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.GetProductosDerivados(ProductoID);
            return dtTMP;
        }
        public void UpdateDerivado(string ProductoID, string ProductoIDPrincipal)
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            ObjCD_Stock.UpdateDerivado(ProductoID, ProductoIDPrincipal);
        }
        public DataTable GetProductosStock(string EmpresaSede)
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.GetProductosStock(EmpresaSede);
            return dtTMP;

        }

        public DataTable GetProductosGenerico(string Generico, string EmpresaSede)
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.GetProductosGenerico(Generico, EmpresaSede);
            return dtTMP;
        }

        public DataTable GetProductosSubfamilia(string SubfamiliaID, string EmpresaSede)
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.GetProductosSubfamilia(SubfamiliaID, EmpresaSede);
            return dtTMP;
        }


        public DataSet GetCaracteristicasProducto()
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            DataSet Ds = new DataSet();

            Ds = ObjCD_Producto.GetCaracteristicasProducto();
            return Ds;
        }

        public string InsertProducto(E_Producto ObjProducto, string ProductoIDVentas)
         {
             string ProductoID;
             CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
             ProductoID = ObjCD_Producto.InsertProducto(ObjProducto, ProductoIDVentas);
             return ProductoID;
         }

        public void UpdateProducto(E_Producto ObjProducto, string Tipo, string ProductoIDVentas)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            ObjCD_Producto.UpdateProducto(ObjProducto, Tipo, ProductoIDVentas);
        }

         public void UpdateUnidadMedida(E_UnidadMedida ObjUnidadMedida, string Tipo)
         {
             CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
             ObjCD_Producto.UpdateUnidadMedida(ObjUnidadMedida, Tipo);
         }

        public string InsertUnidadMedida(E_UnidadMedida ObjUnidadMedida)
         {
             string UnidadMedidaID = "";
             CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
             UnidadMedidaID = ObjCD_Producto.InsertUnidadMedida(ObjUnidadMedida);
            return UnidadMedidaID;
         }

         public void UpdateSubFamilia(E_Subfamilia ObjSubfamilia, string Tipo)
         {
             CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
             ObjCD_Producto.UpdateSubFamilia(ObjSubfamilia, Tipo);
         }

         public string InsertSubFamilia(E_Subfamilia ObjSubfamilia)
         {
             string SubFamiliaID = "";
             CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
             SubFamiliaID = ObjCD_Producto.InsertSubFamilia(ObjSubfamilia);
             return SubFamiliaID;
         }

         public void UpdateEnvase(E_Envase ObjEnvase, string Tipo)
         {
             CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
             ObjCD_Producto.UpdateEnvase(ObjEnvase, Tipo);
         }

        public string InsertEnvase(E_Envase ObjEnvase)
        {
            string EnvaseID = "";
             CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
             EnvaseID = ObjCD_Producto.InsertEnvase(ObjEnvase);
             return EnvaseID;
        }

        public void UpdateFamilia(E_Familia ObjFamilia, string Tipo)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            ObjCD_Producto.UpdateFamilia(ObjFamilia, Tipo);
        }

        public string InsertFamilia(E_Familia ObjFamilia)
        {
            string IDFamilia = "";
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            IDFamilia = ObjCD_Producto.InsertFamilia(ObjFamilia);
            return IDFamilia;
        }

        public void UpdateMarca(E_Marca ObjMarca, string Tipo)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            ObjCD_Producto.UpdateMarca(ObjMarca, Tipo);
        }

        public Int32 InsertMarca(E_Marca ObjMarca)
        {
            Int32 MarcaID = 0;
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            MarcaID = ObjCD_Producto.InsertMarca(ObjMarca);
            return MarcaID;
        }

        public void UpdatePresentacion(E_Presentacion ObjPresentacion, string Tipo)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            ObjCD_Producto.UpdatePresentacion(ObjPresentacion, Tipo);
        }

        public string InsertPresentacion(E_Presentacion ObjPresentacion)
        {
            string PresentacionID = "";
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            PresentacionID = ObjCD_Producto.InsertPresentacion(ObjPresentacion);
            return PresentacionID;
        }

        public void UpdateEnvase(E_Generico ObjGenerico, string Tipo)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            ObjCD_Producto.UpdateGenerico(ObjGenerico, Tipo);
        }

        public string InsertGenerico(E_Generico ObjGenerico)
        {
            string GenericoID = "";
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            GenericoID = ObjCD_Producto.InsertGenerico(ObjGenerico);
            return GenericoID;
        }

        public DataTable GetProductosXNombre(string CadenaBuscar, string Tipo)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Producto.GetProductosXNombre(CadenaBuscar, Tipo);
            return dtTMP;
        }

        public DataTable getStockNavidad(string AlmacenID,string SedeID)
        {
            CD_Producto ObjCD_Stock = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Stock.getStockNavidad(AlmacenID, SedeID);
            return dtTMP;

        }

        public DataTable getProductosNavideños(string EmpresaID, string SedeID)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Producto.getProductosNavideños(EmpresaID, SedeID);
            return dtTMP;
        }

        public DataTable getProductosNavideños(string GenericoID)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Producto.getProductosNavideños(GenericoID);
            return dtTMP;
        }

      
        #region Ventas

        public DataTable GetProductosPrecio(string EmpresaSede, string Cadena, string Tipo)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Producto.GetProductosPrecio(EmpresaSede, Cadena, Tipo);
            return dtTMP;
        }

        public DataTable getPresentaciones()
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Producto.getPresentaciones();
            return dtTMP;
        }

        public void UpdatePrecio(E_ListaPrecio ObjListaPrecio, string SedeIDM)
        { 
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            ObjCD_Producto.UpdatePrecio(ObjListaPrecio, SedeIDM);
        }

        public void UpdatePuntos(E_ListaPrecio ObjListaPrecio)
        {

            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            ObjCD_Producto.UpdatePuntos(ObjListaPrecio);
        }
      

        DataTable GetProductosPrecioUpdate(string EmpresaSede, string Cadena, string Tipo)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Producto.GetProductosPrecioUpdate(EmpresaSede, Cadena, Tipo);
            return dtTMP;
        }
        public DataTable GetStockPorSedes(string EmpresaSede)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Producto.GetStockPorSedes(EmpresaSede);
            return dtTMP;
        }

        public void InsertPrecioNuevo(string AlmacenID, string ProductoID, int UsuarioID, decimal PrecioUnitario, string SedeIDM)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            ObjCD_Producto.InsertPrecioNuevo(AlmacenID, ProductoID, UsuarioID, PrecioUnitario, SedeIDM);
        }

        public DataTable GetGuiaCompraMaizPorFecha(DateTime FechaIni, DateTime FechaFin, string EmpresaID)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = ObjCD_Producto.GetGuiaCompraMaizPorFecha(FechaIni, FechaFin, EmpresaID);
            return dtTMP;
        }

        public void UpdatePrecioBalanzaMasivo(string SEDEID, string EmpresaID)
        {
            CD_Producto ObjCD_Producto = new CD_Producto(AppSettings.GetConnectionString);
            ObjCD_Producto.UpdatePrecioBalanzaMasivo(SEDEID, EmpresaID);
        }
        #endregion

    }
}

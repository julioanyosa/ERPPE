using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Halley.CapaDatos.Almacen;
using Halley.Configuracion;

namespace Halley.CapaLogica.Almacen
{
    public class CL_Requerimientos
    {
        public DataTable GetRequerimientos(string AlmacenID, string AlmacenIDLocal, string Estados, string Tipo, string EmpresaSede, string EmpresaSedeLocal)
        {
            CD_Requerimientos objCD_Requerimientos = new CD_Requerimientos(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Requerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, Estados, Tipo, EmpresaSede, EmpresaSedeLocal);
            return dtTMP;
        }

        public bool UpdateXMLDetalleRequerimientoEstado(string xml, string Tipo, int UsuarioID, string SedeID)
        {
            CD_Requerimientos objCD_Requerimientos = new CD_Requerimientos(AppSettings.GetConnectionString);
            bool Valor;

            Valor = objCD_Requerimientos.UpdateXMLDetalleRequerimientoEstado(xml, Tipo, UsuarioID, SedeID);
            return Valor;
        }

        public bool UpdateDetalleRequerimientoAnulado(string NumRequerimiento, decimal CantidadTransito, string ProductoID, int UsuarioID, string SedeID)
        {
            bool Valor;
            CD_Requerimientos objCD_Requerimientos = new CD_Requerimientos(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            Valor = objCD_Requerimientos.UpdateDetalleRequerimientoAnulado(NumRequerimiento, CantidadTransito, ProductoID, UsuarioID, SedeID);
            return Valor;
        }
        public void InsertarTransferencia(DataTable dtRequerimiento, int UserId, string EmpresaId, string SedeRequerimiento, string NombreUsuario)
        {
            CD_Requerimientos objCD_Requerimientos = new CD_Requerimientos(AppSettings.GetConnectionString);
            objCD_Requerimientos.InsertarTransferencia(dtRequerimiento, UserId, EmpresaId, SedeRequerimiento, NombreUsuario);
        }

        public void InsertarCompra(DataTable dtCompra, int UserId, string EmpresaId, string SedeID)
        {
            CD_Requerimientos objCD_Requerimientos = new CD_Requerimientos(AppSettings.GetConnectionString);
            objCD_Requerimientos.InsertarCompra(dtCompra, UserId, EmpresaId, SedeID);
        }

        public DataTable GetRequerimientosEstadoFecha(DateTime FechaInicio, DateTime FechaFin)
        {
            CD_Requerimientos objCD_Requerimientos = new CD_Requerimientos(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Requerimientos.GetRequerimientosEstadoFecha(FechaInicio, FechaFin);
            return dtTMP;
        }

        public DataTable GetRequerimientoDetalleGuiaRemision(DateTime FechaInicio, DateTime FechaFin)
        {
            CD_Requerimientos objCD_Requerimientos = new CD_Requerimientos(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Requerimientos.GetRequerimientoDetalleGuiaRemision(FechaInicio, FechaFin);
            return dtTMP;
        }

        public Boolean UpdateDetalleRequerimientoAnular(string NumRequerimiento, decimal CantidadAumentar, string AlmacenID, string ProductoID, int UsuarioID, string SedeID)
        {
            CD_Requerimientos objCD_Requerimientos = new CD_Requerimientos(AppSettings.GetConnectionString);
            Boolean Modifico = false;

            Modifico = objCD_Requerimientos.UpdateDetalleRequerimientoAnular(NumRequerimiento, CantidadAumentar, AlmacenID, ProductoID, UsuarioID, SedeID);
            return Modifico;
        }

        #region Para Pollos y Maiz
        public DataTable GetTransferenciaPeso(string ProductoID, string EmpresaSede, string EmpresaSedeLocal, string Estados)
        {
            CD_Requerimientos objCD_Requerimientos = new CD_Requerimientos(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Requerimientos.GetTransferenciaPeso(ProductoID, EmpresaSede, EmpresaSedeLocal, Estados);
            return dtTMP;
        }
        #endregion

    }
}

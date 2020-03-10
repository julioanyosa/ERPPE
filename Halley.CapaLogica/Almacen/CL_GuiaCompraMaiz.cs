using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Halley.CapaDatos.Almacen;
using Halley.Configuracion;
using Halley.Entidad.Almacen;
using Halley.Utilitario;

namespace Halley.CapaLogica.Almacen
{
    public class CL_GuiaCompraMaiz
    {
        public string InsertHojaLiquidacion(E_GuiaCompraMaiz ObjGuiaCompraMaiz, string EmpresaID, string SedeID, string xml, string AlmacenID, string AlmacenExterno, string TipoOperacion)
        {
            CD_GuiaCompraMaiz objCD_GuiaCompraMaiz = new CD_GuiaCompraMaiz(AppSettings.GetConnectionString);
            string Valor;

            Valor = objCD_GuiaCompraMaiz.InsertHojaLiquidacion(ObjGuiaCompraMaiz, EmpresaID, SedeID, xml, AlmacenID, AlmacenExterno, TipoOperacion);
            return Valor;
        }


        public DataSet GetFormatoHojaLiquidacion(string NumHojaLiquidacion)
        {
            CD_GuiaCompraMaiz objCD_OrdenCompra = new CD_GuiaCompraMaiz(AppSettings.GetConnectionString);
            DataSet Temp = new DataSet();

            Temp = objCD_OrdenCompra.GetFormatoHojaLiquidacion(NumHojaLiquidacion);


            DataTable Dt = new DataTable("Logo");
            Dt.Columns.Add("Logo", typeof(byte[]));
            Dt.Columns.Add("NomEmpresa", typeof(string));
            DataRow Dr = Dt.NewRow();
            // El campo productImage primero se almacena en un buffer
            DataRow[] customerRow = UTI_Datatables.DtEmpresas.Select("EmpresaID = '" + NumHojaLiquidacion.Substring(0,2) + "'");
            if (customerRow[0]["Logo"] != DBNull.Value)
            {
                Dr["Logo"] = customerRow[0]["Logo"];
            }
            else
                Dr["Logo"] = DBNull.Value;
            Dr["NomEmpresa"] = customerRow[0]["NomEmpresa"];

            Dt.Rows.Add(Dr);

            Temp.Tables.Add(Dt);
            return Temp;
        }


        public DataTable GetGuiaCompraMaizDNI(string DNI)
        {
            CD_GuiaCompraMaiz objCD_OrdenCompra = new CD_GuiaCompraMaiz(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_OrdenCompra.GetGuiaCompraMaizDNI(DNI);
            return Temp;
        }

        public void UpdateHojaLiquidacionEstado(string NumHojaLiquidacion, string SedeID, int EstadoID, int OperacionCajaBancoID, int TipoPagoID,
        decimal SaldoMovimiento, int UsuarioID, string Moneda, decimal TipoCambio, string DetalleTransaccion, string RUC, string BANCO, int CuentaCorrienteID)
        {
            CD_GuiaCompraMaiz objCD_OrdenCompra = new CD_GuiaCompraMaiz(AppSettings.GetConnectionString);
            objCD_OrdenCompra.UpdateHojaLiquidacionEstado(NumHojaLiquidacion, SedeID,  EstadoID, OperacionCajaBancoID, TipoPagoID,
            SaldoMovimiento, UsuarioID, Moneda, TipoCambio, DetalleTransaccion, RUC, BANCO, CuentaCorrienteID);
        }
    }
}

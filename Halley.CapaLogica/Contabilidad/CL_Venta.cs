using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Halley.CapaDatos.Contabilidad;
using Halley.Configuracion;
using Halley.Entidad.Ventas;

namespace Halley.CapaLogica.Contabilidad
{
    public class CL_Venta
    {

        public DataSet GetConsolidadoDeVentas(DateTime FechaIni, DateTime FechaFin, int TipoComprobanteID, string EmpresaID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Venta.GetConsolidadoDeVentas(FechaIni, FechaFin, TipoComprobanteID, EmpresaID);

            //crear tabla que muestre series y nuemro inicial y final y sus totales
            DataTable DtRangoComprobantes = new DataTable("RangoComprobantes");
            DtRangoComprobantes.Columns.Add("FECHA", typeof(DateTime));
            DtRangoComprobantes.Columns.Add("SERIE", typeof(string));
            DtRangoComprobantes.Columns.Add("NUMERO_INI", typeof(Int32));
            DtRangoComprobantes.Columns.Add("NUMERO_FIN", typeof(Int32));
            DtRangoComprobantes.Columns.Add("BASE", typeof(decimal));
            DtRangoComprobantes.Columns.Add("IGV", typeof(decimal));
            DtRangoComprobantes.Columns.Add("TotalICBPER", typeof(decimal));
            DtRangoComprobantes.Columns.Add("TOTAL", typeof(decimal));

            //OBTENER DISTINCT DE LAS FECHAS
            DataTable DtFechas = new DataTable();
            DtFechas = dtTMP.DefaultView.ToTable("Fechas", true, "FECHA");

            //OBTENER DISTINCT DE LAS SERIES
            DataTable DtSeries = new DataTable();
            DtSeries = dtTMP.DefaultView.ToTable("Series",true, "SERIE");
            DtSeries.DefaultView.Sort = "SERIE ASC";

            //Recorrer las fechas y ir obteniendo los resultados
            foreach (DataRow Dr in DtFechas.Rows)
            {
                //obtener dataview filtrado de fechas
                DataView Dv = new DataView(dtTMP, "FECHA = '" + Dr["FECHA"].ToString() + "'", "FECHA ASC", DataViewRowState.CurrentRows);
                //Ahora recorrer por series
                foreach (DataRow DR2 in DtSeries.Rows)
                {
                    DataTable DtFiltradoXFechas = new DataTable();
                    DtFiltradoXFechas = Dv.ToTable();
                    DataView DV2 = new DataView(DtFiltradoXFechas, "SERIE = '" + DR2["SERIE"].ToString() + "'", "NUMERO", DataViewRowState.CurrentRows);

                    DataTable DTFiltradoXSeries = new DataTable();
                    DTFiltradoXSeries = DV2.ToTable();

                    //agregar a la tabla creada
                    if (DTFiltradoXSeries.Rows.Count > 0)
                    {
                        decimal BASE_IMPONIBLE_OE = Convert.ToDecimal(DTFiltradoXSeries.Compute("sum(BASE_IMPONIBLE_OE)", ""));
                        decimal BASE_IMPONIBLE_OG = Convert.ToDecimal(DTFiltradoXSeries.Compute("sum(BASE_IMPONIBLE_OG)", ""));
                        decimal IGV = Convert.ToDecimal(DTFiltradoXSeries.Compute("sum(IGV)", ""));
                        decimal TotalICBPER = Convert.ToDecimal(DTFiltradoXSeries.Compute("sum(TotalICBPER)", ""));
                        
                        DataRow DRA = DtRangoComprobantes.NewRow();
                        DRA["FECHA"] = Dr["FECHA"];
                        DRA["SERIE"] = DR2["SERIE"];
                        DRA["NUMERO_INI"] = DTFiltradoXSeries.Rows[0]["NUMERO"];
                        DRA["NUMERO_FIN"] = DTFiltradoXSeries.Rows[DTFiltradoXSeries.Rows.Count - 1]["NUMERO"];
                        DRA["BASE"] = BASE_IMPONIBLE_OE + BASE_IMPONIBLE_OG;
                        DRA["IGV"] = IGV;
                        DRA["TotalICBPER"] = TotalICBPER;
                        DRA["TOTAL"] = BASE_IMPONIBLE_OE + BASE_IMPONIBLE_OG + IGV ;
                        DtRangoComprobantes.Rows.Add(DRA);
                    }
                    else
                    {
                        DataRow DRA = DtRangoComprobantes.NewRow();
                        DRA["FECHA"] = Dr["FECHA"];
                        DRA["SERIE"] = DR2["SERIE"];
                        DRA["NUMERO_INI"] = 0;
                        DRA["NUMERO_FIN"] = 0;
                        DRA["BASE"] = 0;
                        DRA["IGV"] = 0;
                        DRA["TotalICBPER"] = 0;
                        DRA["TOTAL"] = 0;
                        DtRangoComprobantes.Rows.Add(DRA);
                    }
                }
            }

            DataSet Ds = new DataSet();
            dtTMP.TableName = "GetConsolidadoDeVentas";
            Ds.Tables.Add(DtRangoComprobantes);
            Ds.Tables.Add(dtTMP);
            Ds.Tables.Add(DtSeries);

            return Ds;
        }


        public DataTable GetCuadreCaja(DateTime FechaIni, DateTime FechaFin, int Cajero, string EmpresaID, string SedeID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Venta.GetCuadreCaja(FechaIni, FechaFin, Cajero, EmpresaID, SedeID);
            return dtTMP;
        }

        public DataTable GetCierreDiario(DateTime FechaIni, string EmpresaID)
        {
            CD_Venta objCD_Venta = new CD_Venta(AppSettings.GetConnectionString);
            DataTable dtTMP = new DataTable();

            dtTMP = objCD_Venta.GetCierreDiario(FechaIni, EmpresaID);
            return dtTMP;
        }
    }
}

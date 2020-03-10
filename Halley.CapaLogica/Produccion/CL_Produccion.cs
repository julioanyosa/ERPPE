using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Halley.CapaDatos.Produccion;
using Halley.Configuracion;
using Halley.Utilitario;
using Halley.Entidad.Almacen;
using Halley.CapaLogica.Almacen;

namespace Halley.CapaLogica.Produccion
{
    public class CL_Produccion
    {

        public DataTable GetProductosFormulados()
        {
            CD_Produccion objCD_Produccion = new CD_Produccion(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_Produccion.GetProductosFormulados();
            return Temp;
        }

        public DataSet GetMateriasPrimas(DataTable DtProductosBatch, string EmpresaID, string SedeID)
        {

            string Cadena = "'";
            foreach (DataRow Dr in DtProductosBatch.Rows)
            {
                Cadena += Dr["ProductoID"].ToString() + "', '";
            }
            Cadena = "(" + Cadena.Substring(0, Cadena.Length - 3) + ")";

            CD_Produccion objCD_Produccion = new CD_Produccion(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();
            DataTable DtMAI = new DataTable();
            DataTable DtMII = new DataTable();
            DataTable DtProductosFiltrados = new DataTable();
            DtProductosFiltrados.TableName = "DtProductosFiltrados";

            //traer la tabla con formulas
            Temp = objCD_Produccion.GetMateriasPrimas(Cadena, EmpresaID);
            Temp.TableName = "Temp";

            //crear tablas
            DataTable DtStockLocalSede = new DataTable();
            DataTable DtPlanProduccionMAI = new DataTable();
            DtPlanProduccionMAI.TableName = "DtPlanProduccionMAI";
            DataTable DtPlanProduccionMII = new DataTable();
            DtPlanProduccionMII.TableName = "DtPlanProduccionMII";
            //crear tabla para almacenar la sumatoria de columnas con el batch
            DataTable DtSumatoria = new DataTable();
            DtSumatoria.Columns.Add("NomProducto", typeof(string));
            DtSumatoria.Columns.Add("Cantidad", typeof(decimal));

            //traer el stock local
            string Cadena2 = "'";
            foreach (DataRow Dr in Temp.Rows)
            {
                Cadena2 += Dr["ProductoIDMateria"].ToString() + "', '";
            }
            if (Cadena2.Length > 2)
            {
                Cadena2 = "(" + Cadena2.Substring(0, Cadena2.Length - 3) + ")";
                DtStockLocalSede = objCD_Produccion.GetStockProductosSede(Cadena2, EmpresaID + SedeID);
                DtStockLocalSede.TableName = "DtStockLocalSede";

                //filtrar macro y micro
                DataView Dv1 = new DataView(Temp);
                Dv1.RowFilter = "AlmacenMateria = 'MAI'";
                DtMAI = Dv1.ToTable();

                DataView Dv2 = new DataView(Temp);
                Dv2.RowFilter = "AlmacenMateria = 'MII'";
                DtMII = Dv2.ToTable();

                #region Macroinsumos
                //filtrar todos los productos para que se conviertan en columnas
                DataTable DtFiltro1 = new DataTable();
                DtFiltro1 = new BaseFunctions().SelectDistinct(DtMAI, "ProductoIDMateria", "NomProducto");

                //crear las columnas
                DtPlanProduccionMAI.Columns.Add("Batch", typeof(string));
                DtPlanProduccionMAI.Columns.Add("ProductoID", typeof(string));
                DtPlanProduccionMAI.Columns.Add("NomProducto", typeof(string));
                foreach (DataRow Dr in DtFiltro1.Rows)
                {
                    DtPlanProduccionMAI.Columns.Add(Dr["NomProducto"].ToString(), typeof(decimal));
                }

                //filtrar e ir agregando 
                foreach (DataRow dr2 in DtProductosBatch.Rows)
                {
                    DataRow DR = DtPlanProduccionMAI.NewRow();
                    DR["Batch"] = dr2["Batch"];
                    DR["ProductoID"] = dr2["ProductoID"];
                    DR["NomProducto"] = dr2["NomProducto"];
                    foreach (DataRow dr3 in DtFiltro1.Rows)
                    {
                        //filtrar e ir agregando
                        DataView Dv = new DataView(DtMAI);
                        Dv.RowFilter = "ProductoID = '" + dr2["ProductoID"] + "' and NomProducto = '" + dr3["NomProducto"] + "'";
                        if (Dv.Count > 0)
                            DR[dr3["NomProducto"].ToString()] = Convert.ToDecimal(Dv[0]["Cantidad"]) * Convert.ToDecimal(dr2["Batch"]);
                        else
                            DR[dr3["NomProducto"].ToString()] = 0;
                    }
                    DtPlanProduccionMAI.Rows.Add(DR);
                }

                //agregar las sumatorias de columnas
                DataRow DRs = DtPlanProduccionMAI.NewRow();
                DRs["Batch"] = null;
                DRs["ProductoID"] = null;
                DRs["NomProducto"] = "Totales: ";

                for (int x = 3; x < DtPlanProduccionMAI.Columns.Count; x++)
                {
                    decimal Valor = 0;
                    foreach (DataRow dr3 in DtPlanProduccionMAI.Rows)
                    {
                        Valor += Convert.ToDecimal(dr3[x]);
                    }
                    DRs[DtPlanProduccionMAI.Columns[x].ColumnName] = Valor;
                    //agregar a la tabla DtSumatoria lo recien sumado
                    DataRow DrSum = DtSumatoria.NewRow();
                    DrSum["NomProducto"] = DtPlanProduccionMAI.Columns[x].ColumnName;
                    DrSum["Cantidad"] = Valor;
                    DtSumatoria.Rows.Add(DrSum);
                }

                DtPlanProduccionMAI.Rows.Add(DRs);

                //agregar el stock Disponible Local
                DataRow DrStockDMAI = DtPlanProduccionMAI.NewRow();
                DrStockDMAI["Batch"] = null;
                DrStockDMAI["ProductoID"] = null;
                DrStockDMAI["NomProducto"] = "Disponible local: ";

                for (int x = 3; x < DtPlanProduccionMAI.Columns.Count; x++)
                {
                    //buscar el valor y agregarlo
                    DataView DvS = new DataView(DtStockLocalSede);
                    DvS.RowFilter = "NomProducto = '" + DtPlanProduccionMAI.Columns[x].ColumnName + "'";
                    if (DvS.Count == 1)
                        DrStockDMAI[DtPlanProduccionMAI.Columns[x].ColumnName] = DvS[0]["StockDisponible"];
                    else
                        DrStockDMAI[DtPlanProduccionMAI.Columns[x].ColumnName] = 0;
                }

                DtPlanProduccionMAI.Rows.Add(DrStockDMAI);

                //agregar el stock Local
                DataRow DrStockLMAI = DtPlanProduccionMAI.NewRow();
                DrStockLMAI["Batch"] = null;
                DrStockLMAI["ProductoID"] = null;
                DrStockLMAI["NomProducto"] = "Stock local: ";

                for (int x = 3; x < DtPlanProduccionMAI.Columns.Count; x++)
                {
                    //buscar el valor y agregarlo
                    DataView DvS = new DataView(DtStockLocalSede);
                    DvS.RowFilter = "NomProducto = '" + DtPlanProduccionMAI.Columns[x].ColumnName + "'";
                    if (DvS.Count == 1)
                        DrStockLMAI[DtPlanProduccionMAI.Columns[x].ColumnName] = DvS[0]["StockActual"];
                    else
                        DrStockLMAI[DtPlanProduccionMAI.Columns[x].ColumnName] = 0;
                }

                DtPlanProduccionMAI.Rows.Add(DrStockLMAI);
                #endregion

                #region Microinsumos
                //filtrar todos los productos para que se conviertan en columnas
                DataTable DtFiltro2 = new DataTable();
                DtFiltro2 = new BaseFunctions().SelectDistinct(DtMII, "ProductoIDMateria", "NomProducto");

                //crear las columnas
                DtPlanProduccionMII.Columns.Add("Batch", typeof(string));
                DtPlanProduccionMII.Columns.Add("ProductoID", typeof(string));
                DtPlanProduccionMII.Columns.Add("NomProducto", typeof(string));
                foreach (DataRow Dr in DtFiltro2.Rows)
                {
                    DtPlanProduccionMII.Columns.Add(Dr["NomProducto"].ToString(), typeof(decimal));
                }

                //filtrar e ir agregando 
                foreach (DataRow dr2 in DtProductosBatch.Rows)
                {
                    DataRow DR = DtPlanProduccionMII.NewRow();
                    DR["Batch"] = dr2["Batch"];
                    DR["ProductoID"] = dr2["ProductoID"];
                    DR["NomProducto"] = dr2["NomProducto"];
                    foreach (DataRow dr3 in DtFiltro2.Rows)
                    {
                        //filtrar e ir agregando
                        DataView Dv = new DataView(DtMII);
                        Dv.RowFilter = "ProductoID = '" + dr2["ProductoID"] + "' and NomProducto = '" + dr3["NomProducto"] + "'";
                        if (Dv.Count > 0)
                            DR[dr3["NomProducto"].ToString()] = Convert.ToDecimal(Dv[0]["Cantidad"]) * Convert.ToDecimal(dr2["Batch"]);
                        else
                            DR[dr3["NomProducto"].ToString()] = 0;
                    }
                    DtPlanProduccionMII.Rows.Add(DR);
                }

                //agregar las sumatorias de columnas
                DataRow DRs2 = DtPlanProduccionMII.NewRow();
                DRs2["Batch"] = null;
                DRs2["ProductoID"] = null;
                DRs2["NomProducto"] = "Totales: ";

                for (int x = 3; x < DtPlanProduccionMII.Columns.Count; x++)
                {
                    decimal Valor = 0;
                    foreach (DataRow dr3 in DtPlanProduccionMII.Rows)
                    {
                        Valor += Convert.ToDecimal(dr3[x]);
                    }
                    DRs2[DtPlanProduccionMII.Columns[x].ColumnName] = Valor;

                    //agregar a la tabla DtSumatoria lo recien sumado
                    DataRow DrSum = DtSumatoria.NewRow();
                    DrSum["NomProducto"] = DtPlanProduccionMII.Columns[x].ColumnName;
                    DrSum["Cantidad"] = Valor;
                    DtSumatoria.Rows.Add(DrSum);
                }

                DtPlanProduccionMII.Rows.Add(DRs2);

                //agregar el stock Disponible Local
                DataRow DrStockDMII = DtPlanProduccionMII.NewRow();
                DrStockDMII["Batch"] = null;
                DrStockDMII["ProductoID"] = null;
                DrStockDMII["NomProducto"] = "Disponible local: ";

                for (int x = 3; x < DtPlanProduccionMII.Columns.Count; x++)
                {
                    //buscar el valor y agregarlo
                    DataView DvS = new DataView(DtStockLocalSede);
                    DvS.RowFilter = "NomProducto = '" + DtPlanProduccionMII.Columns[x].ColumnName + "'";
                    if (DvS.Count == 1)
                        DrStockDMII[DtPlanProduccionMII.Columns[x].ColumnName] = DvS[0]["StockDisponible"];
                    else
                        DrStockDMII[DtPlanProduccionMII.Columns[x].ColumnName] = 0;
                }

                DtPlanProduccionMII.Rows.Add(DrStockDMII);

                //agregar el stock Local
                DataRow DrStockLMII = DtPlanProduccionMII.NewRow();
                DrStockLMII["Batch"] = null;
                DrStockLMII["ProductoID"] = null;
                DrStockLMII["NomProducto"] = "Stock local: ";

                for (int x = 3; x < DtPlanProduccionMII.Columns.Count; x++)
                {
                    //buscar el valor y agregarlo
                    DataView DvS = new DataView(DtStockLocalSede);
                    DvS.RowFilter = "NomProducto = '" + DtPlanProduccionMII.Columns[x].ColumnName + "'";
                    if (DvS.Count == 1)
                        DrStockLMII[DtPlanProduccionMII.Columns[x].ColumnName] = DvS[0]["StockActual"];
                    else
                        DrStockLMII[DtPlanProduccionMII.Columns[x].ColumnName] = 0;
                }

                DtPlanProduccionMII.Rows.Add(DrStockLMII);

                #endregion

                #region Crear Dataset y devolverlo
                DataSet Ds = new DataSet();
                Ds.Tables.Add(DtPlanProduccionMAI);
                Ds.Tables.Add(DtPlanProduccionMII);
                Ds.Tables.Add(Temp);
                Ds.Tables.Add(DtStockLocalSede);
                DtSumatoria.TableName = "DtSumatoria";
                Ds.Tables.Add(DtSumatoria);
                return Ds;
                #endregion
            }
            else
            {
                throw new Exception("Al parecer el producto no tiene formula definida.");
            }
        }

        public DataTable GetMateriasPrimasProducto(string ProductoID, string EmpresaID)
        {
            CD_Produccion objCD_Produccion = new CD_Produccion(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_Produccion.GetMateriasPrimasProducto(ProductoID, EmpresaID);
            return Temp;
        }

        public DataTable GetProductosMacroMicro()
        {
            CD_Produccion objCD_Produccion = new CD_Produccion(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_Produccion.GetProductosMacroMicro();
            return Temp;
        }

        public bool UpdateXMLMateriaPrima(string xml, int UsuarioID, string EmpresaID)
        {
            CD_Produccion objCD_Produccion = new CD_Produccion(AppSettings.GetConnectionString);
            bool Valor;

            Valor = objCD_Produccion.UpdateXMLMateriaPrima(xml, UsuarioID, EmpresaID);
            return Valor;
        }

        public void InsertMateriaPrimaHistorico(string EmpresaID, int UsuarioID, DataTable DtMateriaPrimaHistoricoDetalle, DataTable DtProductosBatch)
        {
            CD_Produccion objCD_Produccion = new CD_Produccion(AppSettings.GetConnectionString);
            objCD_Produccion.InsertMateriaPrimaHistorico(EmpresaID, UsuarioID, DtMateriaPrimaHistoricoDetalle, DtProductosBatch);
        }

        public DataTable GetMateriaPrimaHistoricoFechas(DateTime FechaInicio, DateTime FechaFin, string EmpresaID)
        {
            CD_Produccion objCD_Produccion = new CD_Produccion(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_Produccion.GetMateriaPrimaHistoricoFechas(FechaInicio, FechaFin, EmpresaID);
            return Temp;
        }

        public DataTable GetDtroductosBatchHistorico(int MateriaPrimaHistoricoID)
        {
            CD_Produccion objCD_Produccion = new CD_Produccion(AppSettings.GetConnectionString);
            DataTable DtProductosBatch;
            DtProductosBatch = new DataTable();
            DtProductosBatch.TableName = "DtProductosBatch";
            DtProductosBatch = objCD_Produccion.GetMateriasPrimasFormulados(MateriaPrimaHistoricoID);
            DtProductosBatch.Columns["Producir"].ReadOnly = false;
            return DtProductosBatch;
        }

        public DataSet GetMateriasPrimasHistorico(DataTable DtProductosBatch, int MateriaPrimaHistoricoID, string EmpresaID, string SedeID)
        {
            CD_Produccion objCD_Produccion = new CD_Produccion(AppSettings.GetConnectionString);
                        
            string Cadena = "'";
            foreach (DataRow Dr in DtProductosBatch.Rows)
            {
                Cadena += Dr["ProductoID"].ToString() + "', '";
            }
            Cadena = "(" + Cadena.Substring(0, Cadena.Length - 3) + ")";

            DataTable Temp = new DataTable();
            DataTable DtMAI = new DataTable();
            DataTable DtMII = new DataTable();
            
            //traer la tabla con formulas
            Temp = objCD_Produccion.GetMateriasPrimasHistorico(Cadena, MateriaPrimaHistoricoID);
            Temp.TableName = "Temp";

            //crear tablas
            DataTable DtStockLocalSede = new DataTable();
            DataTable DtPlanProduccionMAI = new DataTable();
            DtPlanProduccionMAI.TableName = "DtPlanProduccionMAI";
            DataTable DtPlanProduccionMII = new DataTable();
            DtPlanProduccionMII.TableName = "DtPlanProduccionMII";
            //crear tabla para almacenar la sumatoria de columnas con el batch
            DataTable DtSumatoria = new DataTable();
            DtSumatoria.Columns.Add("NomProducto", typeof(string));
            DtSumatoria.Columns.Add("Cantidad", typeof(decimal));

            //traer el stock local
            string Cadena2 = "'";
            foreach (DataRow Dr in Temp.Rows)
            {
                Cadena2 += Dr["ProductoIDMateria"].ToString() + "', '";
            }
            Cadena2 = "(" + Cadena2.Substring(0, Cadena2.Length - 3) + ")";
            DtStockLocalSede = objCD_Produccion.GetStockProductosSede(Cadena2, EmpresaID + SedeID);
            DtStockLocalSede.TableName = "DtStockLocalSede";

            //filtrar macro y micro
            DataView Dv1 = new DataView(Temp);
            Dv1.RowFilter = "AlmacenMateria = 'MAI'";
            DtMAI = Dv1.ToTable();

            DataView Dv2 = new DataView(Temp);
            Dv2.RowFilter = "AlmacenMateria = 'MII'";
            DtMII = Dv2.ToTable();

            #region Macroinsumos
            //filtrar todos los productos para que se conviertan en columnas
            DataTable DtFiltro1 = new DataTable();
            DtFiltro1 = new BaseFunctions().SelectDistinct(DtMAI, "ProductoIDMateria", "NomProducto");

            //crear las columnas
            DtPlanProduccionMAI.Columns.Add("Batch", typeof(string));
            DtPlanProduccionMAI.Columns.Add("ProductoID", typeof(string));
            DtPlanProduccionMAI.Columns.Add("NomProducto", typeof(string));
            foreach (DataRow Dr in DtFiltro1.Rows)
            {
                DtPlanProduccionMAI.Columns.Add(Dr["NomProducto"].ToString(), typeof(decimal));
            }

            //filtrar e ir agregando 
            foreach (DataRow dr2 in DtProductosBatch.Rows)
            {
                DataRow DR = DtPlanProduccionMAI.NewRow();
                DR["Batch"] = dr2["Batch"];
                DR["ProductoID"] = dr2["ProductoID"];
                DR["NomProducto"] = dr2["NomProducto"];
                foreach (DataRow dr3 in DtFiltro1.Rows)
                {
                    //filtrar e ir agregando
                    DataView Dv = new DataView(DtMAI);
                    Dv.RowFilter = "ProductoID = '" + dr2["ProductoID"] + "' and NomProducto = '" + dr3["NomProducto"] + "'";
                    if (Dv.Count > 0)
                        DR[dr3["NomProducto"].ToString()] = Convert.ToDecimal(Dv[0]["Cantidad"]) * Convert.ToDecimal(dr2["Batch"]);
                    else
                        DR[dr3["NomProducto"].ToString()] = 0;
                }
                DtPlanProduccionMAI.Rows.Add(DR);
            }

            //agregar las sumatorias de columnas
            DataRow DRs = DtPlanProduccionMAI.NewRow();
            DRs["Batch"] = null;
            DRs["ProductoID"] = null;
            DRs["NomProducto"] = "Totales: ";

            for (int x = 3; x < DtPlanProduccionMAI.Columns.Count; x++)
            {
                decimal Valor = 0;
                foreach (DataRow dr3 in DtPlanProduccionMAI.Rows)
                {
                    Valor += Convert.ToDecimal(dr3[x]);
                }
                DRs[DtPlanProduccionMAI.Columns[x].ColumnName] = Valor;

                //agregar a la tabla DtSumatoria lo recien sumado
                DataRow DrSum = DtSumatoria.NewRow();
                DrSum["NomProducto"] = DtPlanProduccionMAI.Columns[x].ColumnName;
                DrSum["Cantidad"] = Valor;
                DtSumatoria.Rows.Add(DrSum);
            }

            DtPlanProduccionMAI.Rows.Add(DRs);

            //agregar el stock Disponible Local
            DataRow DrStockDMAI = DtPlanProduccionMAI.NewRow();
            DrStockDMAI["Batch"] = null;
            DrStockDMAI["ProductoID"] = null;
            DrStockDMAI["NomProducto"] = "Disponible local: ";

            for (int x = 3; x < DtPlanProduccionMAI.Columns.Count; x++)
            {
                //buscar el valor y agregarlo
                DataView DvS = new DataView(DtStockLocalSede);
                DvS.RowFilter = "NomProducto = '" + DtPlanProduccionMAI.Columns[x].ColumnName + "'";
                if(DvS.Count == 1)
                    DrStockDMAI[DtPlanProduccionMAI.Columns[x].ColumnName] = DvS[0]["StockDisponible"];
                else
                    DrStockDMAI[DtPlanProduccionMAI.Columns[x].ColumnName] = 0;
            }

            DtPlanProduccionMAI.Rows.Add(DrStockDMAI);

            //agregar el stock Local
            DataRow DrStockLMAI = DtPlanProduccionMAI.NewRow();
            DrStockLMAI["Batch"] = null;
            DrStockLMAI["ProductoID"] = null;
            DrStockLMAI["NomProducto"] = "Stock local: ";

            for (int x = 3; x < DtPlanProduccionMAI.Columns.Count; x++)
            {
                //buscar el valor y agregarlo
                DataView DvS = new DataView(DtStockLocalSede);
                DvS.RowFilter = "NomProducto = '" + DtPlanProduccionMAI.Columns[x].ColumnName + "'";
                if (DvS.Count == 1)
                    DrStockLMAI[DtPlanProduccionMAI.Columns[x].ColumnName] = DvS[0]["StockActual"];
                else
                    DrStockLMAI[DtPlanProduccionMAI.Columns[x].ColumnName] = 0;
            }

            DtPlanProduccionMAI.Rows.Add(DrStockLMAI);

            #endregion

            #region Microinsumos
            //filtrar todos los productos para que se conviertan en columnas
            DataTable DtFiltro2 = new DataTable();
            DtFiltro2 = new BaseFunctions().SelectDistinct(DtMII, "ProductoIDMateria", "NomProducto");

            //crear las columnas
            DtPlanProduccionMII.Columns.Add("Batch", typeof(string));
            DtPlanProduccionMII.Columns.Add("ProductoID", typeof(string));
            DtPlanProduccionMII.Columns.Add("NomProducto", typeof(string));
            foreach (DataRow Dr in DtFiltro2.Rows)
            {
                DtPlanProduccionMII.Columns.Add(Dr["NomProducto"].ToString(), typeof(decimal));
            }

            //filtrar e ir agregando 
            foreach (DataRow dr2 in DtProductosBatch.Rows)
            {
                DataRow DR = DtPlanProduccionMII.NewRow();
                DR["Batch"] = dr2["Batch"];
                DR["ProductoID"] = dr2["ProductoID"];
                DR["NomProducto"] = dr2["NomProducto"];
                foreach (DataRow dr3 in DtFiltro2.Rows)
                {
                    //filtrar e ir agregando
                    DataView Dv = new DataView(DtMII);
                    Dv.RowFilter = "ProductoID = '" + dr2["ProductoID"] + "' and NomProducto = '" + dr3["NomProducto"] + "'";
                    if (Dv.Count > 0)
                        DR[dr3["NomProducto"].ToString()] = Convert.ToDecimal(Dv[0]["Cantidad"]) * Convert.ToDecimal(dr2["Batch"]);
                    else
                        DR[dr3["NomProducto"].ToString()] = 0;
                }
                DtPlanProduccionMII.Rows.Add(DR);
            }

            //agregar las sumatorias de columnas
            DataRow DRs2 = DtPlanProduccionMII.NewRow();
            DRs2["Batch"] = null;
            DRs2["ProductoID"] = null;
            DRs2["NomProducto"] = "Totales: ";

            for (int x = 3; x < DtPlanProduccionMII.Columns.Count; x++)
            {
                decimal Valor = 0;
                foreach (DataRow dr3 in DtPlanProduccionMII.Rows)
                {
                    Valor += Convert.ToDecimal(dr3[x]);
                }
                DRs2[DtPlanProduccionMII.Columns[x].ColumnName] = Valor;

                //agregar a la tabla DtSumatoria lo recien sumado
                DataRow DrSum = DtSumatoria.NewRow();
                DrSum["NomProducto"] = DtPlanProduccionMII.Columns[x].ColumnName;
                DrSum["Cantidad"] = Valor;
                DtSumatoria.Rows.Add(DrSum);

            }

            DtPlanProduccionMII.Rows.Add(DRs2);

            //agregar el stock Disponible Local
            DataRow DrStockDMII = DtPlanProduccionMII.NewRow();
            DrStockDMII["Batch"] = null;
            DrStockDMII["ProductoID"] = null;
            DrStockDMII["NomProducto"] = "Disponible local: ";

            for (int x = 3; x < DtPlanProduccionMII.Columns.Count; x++)
            {
                //buscar el valor y agregarlo
                DataView DvS = new DataView(DtStockLocalSede);
                DvS.RowFilter = "NomProducto = '" + DtPlanProduccionMII.Columns[x].ColumnName + "'";
                if (DvS.Count == 1)
                    DrStockDMII[DtPlanProduccionMII.Columns[x].ColumnName] = DvS[0]["StockDisponible"];
                else
                    DrStockDMII[DtPlanProduccionMII.Columns[x].ColumnName] = 0;
            }

            DtPlanProduccionMII.Rows.Add(DrStockDMII);

            //agregar el stock Local
            DataRow DrStockLMII = DtPlanProduccionMII.NewRow();
            DrStockLMII["Batch"] = null;
            DrStockLMII["ProductoID"] = null;
            DrStockLMII["NomProducto"] = "Stock local: ";

            for (int x = 3; x < DtPlanProduccionMII.Columns.Count; x++)
            {
                //buscar el valor y agregarlo
                DataView DvS = new DataView(DtStockLocalSede);
                DvS.RowFilter = "NomProducto = '" + DtPlanProduccionMII.Columns[x].ColumnName + "'";
                if (DvS.Count == 1)
                    DrStockLMII[DtPlanProduccionMII.Columns[x].ColumnName] = DvS[0]["StockActual"];
                else
                    DrStockLMII[DtPlanProduccionMII.Columns[x].ColumnName] = 0;
            }

            DtPlanProduccionMII.Rows.Add(DrStockLMII);

            #endregion

            #region Crear Dataset y devolverlo
            DataSet Ds = new DataSet();
            Ds.Tables.Add(DtPlanProduccionMAI);
            Ds.Tables.Add(DtPlanProduccionMII);
            Ds.Tables.Add(Temp);
            Ds.Tables.Add(DtStockLocalSede);
            DtSumatoria.TableName = "DtSumatoria";
            Ds.Tables.Add(DtSumatoria);
            return Ds;
            #endregion
        }

        public DataTable GetDespachoInterno(string AlmacenDestino, string AlmacenOrigen)
        {
            CD_Produccion objCD_Produccion = new CD_Produccion(AppSettings.GetConnectionString);
            DataTable Temp = new DataTable();

            Temp = objCD_Produccion.GetDespachoInterno(AlmacenDestino, AlmacenOrigen);
            return Temp;
        }

        public string DespachoInterno(DataTable DtProductosDespacho, int UsuarioID, string Empresa, string NomEmpresa, string Sede)
        {
            string NumHojaDespacho;
            string NumGuiaRemision;
            string NumGuiaTransportista;
            DataTable DetalleHojaDespacho = new DataTable();

            #region crear tablas
            //Insertar Hoja de despacho
            E_HojaDespacho ObjHojaDespacho = new E_HojaDespacho();
            ObjHojaDespacho.EmpresaID = Empresa;
            ObjHojaDespacho.EmpresaTransporte = NomEmpresa;
            ObjHojaDespacho.NombreChofer = "Sin chofer";
            ObjHojaDespacho.placa = "Sin Placa";
            ObjHojaDespacho.Carrosa = null;
            ObjHojaDespacho.FechaLlegada = DateTime.Now;
            ObjHojaDespacho.FechaSalida = DateTime.Now;
            ObjHojaDespacho.NumJabas = 0;
            ObjHojaDespacho.PesoTotal = 0;
            ObjHojaDespacho.PesoNeto = 0;
            ObjHojaDespacho.TotalAnimales = 0;
            ObjHojaDespacho.TaraTotal = 0;
            ObjHojaDespacho.UsuarioID = UsuarioID;

            NumHojaDespacho = new CL_HojaDespacho().InsertHojaDespacho(ObjHojaDespacho, Sede);

            //Tabla para insertar el detalle de la hoja de despacho
            DetalleHojaDespacho = new DataTable();
            DetalleHojaDespacho.TableName = "DetalleHojaDespacho";
            DetalleHojaDespacho.Columns.Add("ProductoID", typeof(string));
            DetalleHojaDespacho.Columns.Add("NumHojaDespacho", typeof(string));
            DetalleHojaDespacho.Columns.Add("NumGuiaRemision", typeof(string));
            DetalleHojaDespacho.Columns.Add("NumRequerimiento", typeof(string));
            DetalleHojaDespacho.Columns.Add("NroFactura", typeof(string));
            DetalleHojaDespacho.Columns.Add("TotalPeso", typeof(decimal));
            DetalleHojaDespacho.Columns.Add("Motivo", typeof(string));
            DetalleHojaDespacho.Columns.Add("NumGuiaTransportista", typeof(string));
            DetalleHojaDespacho.Columns.Add("Bultos", typeof(string));
            DetalleHojaDespacho.Columns.Add("IDProveedor", typeof(int));

            #endregion


                try
                {
                    #region crear tablas
                    //tabla para actualizar el estado del requerimiento
                    DataTable DtActuEstadoReq = new DataTable();
                    DtActuEstadoReq.TableName = "DetalleRequerimiento";
                    DtActuEstadoReq.Columns.Add("NumRequerimiento", typeof(string));
                    DtActuEstadoReq.Columns.Add("ProductoID", typeof(string));
                    DtActuEstadoReq.Columns.Add("CantidadRecibida", typeof(decimal));
                    DtActuEstadoReq.Columns.Add("EstadoID", typeof(int));

                    //tabla para actualizar el nuevo stock (agregar productos recepcionados)
                    DataTable DtActuStockLocal = new DataTable();
                    DtActuStockLocal.TableName = "StockAlmacen";
                    DtActuStockLocal.Columns.Add("AlmacenID", typeof(string));
                    DtActuStockLocal.Columns.Add("ProductoID", typeof(string));
                    DtActuStockLocal.Columns.Add("Adicion", typeof(decimal));
                    #endregion

                    NumGuiaRemision = Empresa + "PRO-0000001";

                    NumGuiaTransportista = "";

                    foreach (DataRow Row2 in DtProductosDespacho.Rows)
                    {
                        if (Convert.ToBoolean(Row2["Agregar"]) == true)
                        {
                            //analizar el stock y si se logro la actualizacion crear las guias
                            bool Actualizo = false;
                            //mueve kardex
                            //50 es para "GUIA SALIDA PRODUCCION"
                            Actualizo = new CL_Almacen().UpdateStockSustraccion(Row2["AlmacenOrigen"].ToString(), Convert.ToString(Row2["ProductoID"]), Convert.ToDecimal(Row2["CantidadSolicitada"]), "S", Empresa + Sede + "PRO", 2,"50", "PRO",null,"10",UsuarioID);
                            if (Actualizo == true)
                            {
                                //para estado requerimiento
                                DataRow RowD2 = DtActuEstadoReq.NewRow();
                                RowD2["NumRequerimiento"] = Row2["NumRequerimiento"];
                                RowD2["ProductoID"] = Row2["ProductoID"];
                                RowD2["CantidadRecibida"] = Row2["CantidadSolicitada"];
                                RowD2["EstadoID"] = 5; //Recepcion completa
                                DtActuEstadoReq.Rows.Add(RowD2);

                                //para detalle hoja despacho
                                DataRow RowHD = DetalleHojaDespacho.NewRow();
                                RowHD["ProductoID"] = Row2["ProductoID"];
                                RowHD["NumHojaDespacho"] = NumHojaDespacho;
                                RowHD["NumGuiaRemision"] = NumGuiaRemision;
                                RowHD["NumRequerimiento"] = Row2["NumRequerimiento"];
                                RowHD["NroFactura"] = "";
                                RowHD["TotalPeso"] = DBNull.Value;
                                RowHD["Motivo"] = Row2["Observacion"];
                                RowHD["NumGuiaTransportista"] = NumGuiaTransportista;
                                RowHD["Bultos"] = Row2["CantidadSolicitada"].ToString() + " " + Row2["UnidadMedidaID"].ToString();
                                RowHD["IDProveedor"] = DBNull.Value;
                                DetalleHojaDespacho.Rows.Add(RowHD);

                                #region actualiza el stock local
                                DataRow DrR = DtActuStockLocal.NewRow();
                                DrR["AlmacenID"] = Row2["AlmacenDestino"];
                                DrR["ProductoID"] = Row2["ProductoID"];
                                DrR["Adicion"] = Row2["CantidadSolicitada"];
                                DtActuStockLocal.Rows.Add(DrR);
                                #endregion

                            }
                            else
                                throw new Exception("No existe Stock suficiente en el almacen " + Row2["AlmacenOrigen"].ToString() + " del producto \r\n" + Row2["NomProducto"].ToString() + ".");
                        }
                    }//fin foreach

                    #region agrupar para actualizar el stock local
                    //Agrupar los productos apra almacenarlos
                    DataTable DtProducto = new DataTable();
                    DataTable DtActuStockLocal2 = new DataTable();
                    DtActuStockLocal2.TableName = "StockAlmacen";
                    DtActuStockLocal2.Columns.Add("AlmacenID", typeof(string));
                    DtActuStockLocal2.Columns.Add("AlmacenOrigen", typeof(string));
                    DtActuStockLocal2.Columns.Add("ProductoID", typeof(string));
                    DtActuStockLocal2.Columns.Add("Adicion", typeof(decimal));
                    DtActuStockLocal2.Columns.Add("NroDocumento", typeof(string));
                    DtProducto = new BaseFunctions().SelectDistinct(DtActuStockLocal, "ProductoID", "AlmacenID");
                    foreach (DataRow RowP in DtProducto.Rows)
                    {
                        DataView Dv = new DataView(DtActuStockLocal);
                        Dv.RowFilter = "ProductoID = '" + RowP["ProductoID"] + "' and AlmacenID = '" + RowP["AlmacenID"] + "'";
                        decimal Suma = 0;
                        foreach (DataRowView Drv in Dv) //sumar las cantidades por producto
                        {
                            Suma += Convert.ToDecimal(Drv["Adicion"]);
                        }
                        DataRow DrR = DtActuStockLocal2.NewRow();
                        DrR["AlmacenID"] = RowP["AlmacenID"];
                        DrR["AlmacenOrigen"] = Empresa + Sede + RowP["AlmacenID"].ToString().Substring(7);
                        DrR["ProductoID"] = RowP["ProductoID"];
                        DrR["Adicion"] = Suma;
                        DrR["NroDocumento"] = NumHojaDespacho;
                        DtActuStockLocal2.Rows.Add(DrR);
                    }

                    #endregion

                    #region Actualizar con Xml

                    //actualizar estado de los requerimientos
                    if (DtActuEstadoReq.Rows.Count > 0 & DtActuStockLocal2.Rows.Count > 0 & DetalleHojaDespacho.Rows.Count > 0)
                    {
                        bool Valor;
                        string xml = new BaseFunctions().GetXML(DtActuEstadoReq).Replace("NewDataSet", "DocumentElement");
                        Valor = new CL_Requerimientos().UpdateXMLDetalleRequerimientoEstado(xml, "I", UsuarioID, Sede);//interno
                        string xml1 = new BaseFunctions().GetXML(DtActuStockLocal2).Replace("NewDataSet", "DocumentElement");
                        Valor = new CL_Almacen().UpdateXMLStockAlmacen(xml1, 4, UsuarioID);
                        string xml2 = new BaseFunctions().GetXML(DetalleHojaDespacho).Replace("NewDataSet", "DocumentElement");
                        Valor = new CL_HojaDespacho().InsertXMLDetalleHojaDespacho(xml2);
                    }
                    #endregion

                    return NumHojaDespacho;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
        }

        public void AgregarProductosterminados(DataTable DtProductosBatch, DataTable DtTemp, string EmpresaID, string SedeId, int UserID, int MateriaPrimaHistoricoID)
        {
            //agrega a productos terminados lo ya producido
            try
            {
                //tabla para actualizar el nuevo stock (agregar productos recepcionados)
                DataTable DtActuStockLocal = new DataTable();
                DtActuStockLocal.TableName = "StockAlmacen";
                DtActuStockLocal.Columns.Add("AlmacenID", typeof(string));
                DtActuStockLocal.Columns.Add("AlmacenOrigen", typeof(string));
                DtActuStockLocal.Columns.Add("ProductoID", typeof(string));
                DtActuStockLocal.Columns.Add("Adicion", typeof(decimal));

                //tabla para actualizar el nuevo stock (agregar productos recepcionados)
                DataTable DtDisminuirStock = new DataTable();
                DtDisminuirStock.Columns.Add("AlmacenID", typeof(string));
                DtDisminuirStock.Columns.Add("ProductoID", typeof(string));
                DtDisminuirStock.Columns.Add("Cantidad", typeof(decimal));

                //tabla para cambiar el estado de lo producido
                DataTable DtEstadoProducido = new DataTable();
                DtEstadoProducido.TableName = "MateriasPrimasFormuladosEstado";
                DtEstadoProducido.Columns.Add("MateriaPrimaHistoricoID", typeof(Int32));
                DtEstadoProducido.Columns.Add("ProductoID", typeof(string));

                #region actualiza el stock local

                string Envase = "01"; //envase sacos
                string Presentacion = "0139"; //presentacion 50 Kg
                foreach (DataRow Row in DtProductosBatch.Rows)
                {
                    if (Convert.ToBoolean(Row["Producir"]) == true)
                    {
                        DataRow DrR = DtActuStockLocal.NewRow();
                        DrR["AlmacenID"] = EmpresaID + SedeId + "PTE";
                        DrR["AlmacenOrigen"] = EmpresaID + SedeId + "PRO";
                        DrR["ProductoID"] = Row["ProductoID"].ToString().Substring(0, 5) + Envase + Presentacion + Row["ProductoID"].ToString().Substring(11);
                        DrR["Adicion"] = Convert.ToDecimal(Row["Batch"]) * 30;// es por 20 porque un batch equivale a 20 sacos de 50 kg

                        #region Aca se agrega los ya terminados para cambiarles de estado
                        DataRow DrE = DtEstadoProducido.NewRow();
                        DrE["MateriaPrimaHistoricoID"] = MateriaPrimaHistoricoID;
                        DrE["ProductoID"] = Row["ProductoID"];
                        DtEstadoProducido.Rows.Add(DrE);
                        #endregion

                        #region Disminuir el insumo de almacen Produccion


                        //filtrar por el producto terminado y disminuirlo de "Produccion"
                        DataView DvDisProduccion = new DataView(DtTemp);
                        DvDisProduccion.RowFilter = "ProductoID = '" + Row["ProductoID"] + "'";

                        //recurrer vista filtrada y disminuir del almacen local
                        foreach (DataRowView Drv in DvDisProduccion)
                        {
                            DataRow DrDi = DtDisminuirStock.NewRow();
                            DrDi["AlmacenID"] = EmpresaID + SedeId + "PRO";
                            DrDi["ProductoID"] = Convert.ToString(Drv["ProductoIDMateria"]);
                            DrDi["Cantidad"] = Convert.ToDecimal(Drv["Cantidad"]) * Convert.ToDecimal(Row["Batch"]);
                            DtDisminuirStock.Rows.Add(DrDi);
                        }
                        #endregion

                        DtActuStockLocal.Rows.Add(DrR);
                   }
                }
                #endregion

                #region agrupar para actualizar el stock local
                //Agrupar los productos apra almacenarlos
                DataTable DtProducto = new DataTable();
                DataTable DtActuStockLocal2 = new DataTable();
                DtActuStockLocal2.TableName = "StockAlmacen";
                DtActuStockLocal2.Columns.Add("AlmacenID", typeof(string));
                DtActuStockLocal2.Columns.Add("AlmacenOrigen", typeof(string));
                DtActuStockLocal2.Columns.Add("ProductoID", typeof(string));
                DtActuStockLocal2.Columns.Add("Adicion", typeof(decimal));
                DtActuStockLocal2.Columns.Add("NroDocumento", typeof(string));
                DtProducto = new BaseFunctions().SelectDistinct(DtActuStockLocal, "ProductoID", "AlmacenID");
                foreach (DataRow RowP in DtProducto.Rows)
                {
                    DataView Dv = new DataView(DtActuStockLocal);
                    Dv.RowFilter = "ProductoID = '" + RowP["ProductoID"] + "' and AlmacenID = '" + RowP["AlmacenID"] + "'";
                    decimal Suma = 0;
                    foreach (DataRowView Drv in Dv) //sumar las cantidades por producto
                    {
                        Suma += Convert.ToDecimal(Drv["Adicion"]);
                    }
                    DataRow DrR = DtActuStockLocal2.NewRow();
                    DrR["AlmacenID"] = RowP["AlmacenID"];
                    DrR["AlmacenOrigen"] = Dv[0]["AlmacenOrigen"];
                    DrR["ProductoID"] = RowP["ProductoID"];
                    DrR["Adicion"] = Suma;
                    DrR["NroDocumento"] = null;
                    DtActuStockLocal2.Rows.Add(DrR);
                }

                #endregion

                #region agrupar para disminuir el stock de "Produccion"
                //Agrupar los productos apra almacenarlos
                DataTable DtProductoDis = new DataTable();
                DataTable DtActuStockLocal2Dis = new DataTable();
                DtActuStockLocal2Dis.Columns.Add("AlmacenID", typeof(string));
                DtActuStockLocal2Dis.Columns.Add("ProductoID", typeof(string));
                DtActuStockLocal2Dis.Columns.Add("Cantidad", typeof(decimal));

                DtProductoDis = new BaseFunctions().SelectDistinct(DtDisminuirStock, "ProductoID");
                foreach (DataRow RowP in DtProductoDis.Rows)
                {
                    DataView Dv = new DataView(DtDisminuirStock);
                    Dv.RowFilter = "ProductoID = '" + RowP["ProductoID"] + "'";
                    decimal Suma = 0;
                    foreach (DataRowView Drv in Dv) //sumar las cantidades por producto
                    {
                        Suma += Convert.ToDecimal(Drv["Cantidad"]);
                    }
                    DataRow DrR = DtActuStockLocal2Dis.NewRow();
                    DrR["AlmacenID"] = Dv[0]["AlmacenID"];
                    DrR["ProductoID"] = Dv[0]["ProductoID"];
                    DrR["Cantidad"] = Suma;
                    DtActuStockLocal2Dis.Rows.Add(DrR);
                }

                #endregion


                #region actualizar con XML
                if (DtActuStockLocal2.Rows.Count > 0)
                {
                    bool Valor;
                    string xml1 = new BaseFunctions().GetXML(DtActuStockLocal2).Replace("NewDataSet", "DocumentElement");
                    Valor = new CL_Almacen().UpdateXMLStockAlmacen(xml1, 4, UserID);
                    string xml2 = new BaseFunctions().GetXML(DtEstadoProducido).Replace("NewDataSet", "DocumentElement");
                    new CL_Produccion().UpdateXMLMateriasPrimasFormuladosEstado(xml2, UserID);
                }
                #endregion
                
                #region bucle para bajar el stock de produccion
                foreach(DataRow Dr in DtActuStockLocal2Dis.Rows)
                {
                    bool Actualizo = false;
                    Actualizo = new CL_Almacen().UpdateStockSustraccion(Dr["AlmacenID"].ToString(), Dr["ProductoID"].ToString(), Convert.ToDecimal(Dr["Cantidad"]), "D", null, 5, null, null,null, null, UserID);
                }
                #endregion


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateXMLMateriasPrimasFormuladosEstado(string xml, int UsuarioID)
        {
            CD_Produccion objCD_Produccion = new CD_Produccion(AppSettings.GetConnectionString);
            objCD_Produccion.UpdateXMLMateriasPrimasFormuladosEstado(xml, UsuarioID);
        }
    }
}

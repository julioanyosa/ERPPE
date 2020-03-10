using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Produccion;
using Halley.Configuracion;
using Halley.CapaLogica.Almacen;
using C1.Win.C1TrueDBGrid;
using Halley.Utilitario;

namespace Halley.Presentacion.Produccion
{
    public partial class PlanDeProduccion : UITemplateAccess
    {
        #region variables
        CL_Produccion ObjCL_Produccion = new CL_Produccion();
        DataTable DtProductosFormulados;
        DataTable DtProductosFormuladosA;
        DataTable DtProductosBatch;
        DataTable DtMateriaPrimaHistorico;
        DataSet Ds;
        Int32 MateriaPrimaHistoricoID = 0;
        #endregion

        public PlanDeProduccion()
        {
            InitializeComponent();
        }

        private void Produccion_Load(object sender, EventArgs e)
        {
            //cargar los productos que sean formulados
            DtProductosFormulados = new DataTable();
            DtProductosFormuladosA = new DataTable();//aca se guardara una copia que no sera alterada
            DtProductosFormulados = ObjCL_Produccion.GetProductosFormulados();
            DtProductosFormuladosA.Merge(DtProductosFormulados);
            TdgProductosFormulados.SetDataBinding(DtProductosFormulados, "", true);

            //instanciar la tabla pára los productos batch
            DtProductosBatch = new DataTable();
            DtProductosBatch.Columns.Add("ProductoID", typeof(string));
            DtProductosBatch.Columns.Add("NomProducto", typeof(string));
            DtProductosBatch.Columns.Add("Terminado", typeof(bool));
            DtProductosBatch.Columns.Add("Producir", typeof(bool));
            DtProductosBatch.Columns.Add("Batch", typeof(decimal));
            TdgFormuladosBatch.SetDataBinding(DtProductosBatch, "", true);

            cboFechaFin.Value = DateTime.Now;
            cboFechaInicio.Value = DateTime.Now;

            BtnGrabar.Visible = false;

            ocultarToolStrip();
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (TdgFormuladosBatch.RowCount > 0)
            {
                string ProductoID;
                ProductoID = this.TdgFormuladosBatch.Columns["ProductoID"].Value.ToString();

                foreach (DataRow Dr in DtProductosBatch.Rows)
                {
                    if (Dr["ProductoID"].ToString() == ProductoID)//si es la fila se graga a la otra tabla y de paso se borra
                    {
                        DataRow DrB = DtProductosFormulados.NewRow();
                        DrB["ProductoID"] = Dr["ProductoID"];
                        DrB["NomProducto"] = Dr["NomProducto"];
                        DtProductosFormulados.Rows.Add(DrB);// se agrega a la otra tabla

                        DtProductosBatch.Rows.Remove(Dr);//se elimina de la tabla
                        return;
                    }
                }

            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (TdgProductosFormulados.RowCount > 0)
            {
                string ProductoID;
                ProductoID = this.TdgProductosFormulados.Columns["ProductoID"].Value.ToString();

                foreach (DataRow Dr in DtProductosFormulados.Rows)
                {
                    if (Dr["ProductoID"].ToString() == ProductoID)//si es la fila se graga a la otra tabla y de paso se borra
                    {
                        DataRow DrB = DtProductosBatch.NewRow();
                        DrB["ProductoID"] = Dr["ProductoID"];
                        DrB["NomProducto"] = Dr["NomProducto"];
                        DrB["Terminado"] = false;
                        DrB["Producir"] = false;
                        DrB["Batch"] = 0;
                        DtProductosBatch.Rows.Add(DrB);// se agrega a la otra tabla

                        DtProductosFormulados.Rows.Remove(Dr);//se elimina de la tabla
                        return;
                    }
                }
            }
        }

        private void BtnMostrarPlan_Click(object sender, EventArgs e)
        {
            try
            {
                bool HayCero = false;
                foreach (DataRow Drv in DtProductosBatch.Rows)
                {
                    decimal val;
                    val = Convert.ToDecimal(Drv["Batch"]);
                    if (val == 0)
                        HayCero = true;
                }

                if (TcOpciones.SelectedIndex == 0)
                {
                    #region Actual
                    if (DtProductosBatch.Rows.Count > 0 && HayCero == false)
                    {
                        //traer todos las formulas del batch
                        Ds = new DataSet();
                        Ds = ObjCL_Produccion.GetMateriasPrimas(DtProductosBatch, AppSettings.EmpresaID, AppSettings.SedeID);

                        #region Microinsumos
                        TcProduccion.SelectedIndex = 0;
                        TdgMicro.SetDataBinding(Ds.Tables["DtPlanProduccionMII"], "", false);

                        this.TdgMicro.Columns["Batch"].Caption = "Batch";
                        this.TdgMicro.Splits[0].DisplayColumns["Batch"].Style.Locked = true;
                        this.TdgMicro.Splits[0].DisplayColumns["Batch"].Visible = true;
                        this.TdgMicro.Splits[0].DisplayColumns["Batch"].Width = 100;
                        this.TdgMicro.Splits[0].DisplayColumns["Batch"].Merge = ColumnMergeEnum.Free;

                        this.TdgMicro.Columns["ProductoID"].Caption = "ProductoID";
                        this.TdgMicro.Splits[0].DisplayColumns["ProductoID"].Style.Locked = true;
                        this.TdgMicro.Splits[0].DisplayColumns["ProductoID"].Visible = false;
                        this.TdgMicro.Splits[0].DisplayColumns["ProductoID"].Width = 280;
                        this.TdgMicro.Splits[0].DisplayColumns["ProductoID"].Merge = ColumnMergeEnum.Free;

                        this.TdgMicro.Columns["NomProducto"].Caption = "Producto Terminado";
                        this.TdgMicro.Splits[0].DisplayColumns["NomProducto"].Style.Locked = true;
                        this.TdgMicro.Splits[0].DisplayColumns["NomProducto"].Visible = true;
                        this.TdgMicro.Splits[0].DisplayColumns["NomProducto"].Width = 250;
                        this.TdgMicro.Splits[0].DisplayColumns["NomProducto"].Merge = ColumnMergeEnum.Free;

                        for (int x = 3; x < Ds.Tables["DtPlanProduccionMII"].Columns.Count; x++)
                        {
                            this.TdgMicro.Columns[Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName].Caption = Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName;
                            this.TdgMicro.Columns[Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName].NumberFormat = "FormatText Event";
                            this.TdgMicro.Splits[0].DisplayColumns[Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName].Style.Locked = true;
                            this.TdgMicro.Splits[0].DisplayColumns[Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName].Visible = true;
                            this.TdgMicro.Splits[0].DisplayColumns[Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName].Width = 230;
                            //this.TdgMicro.Splits[0].DisplayColumns["NomProducto"].Merge = ColumnMergeEnum.Free;
                        }
                        TdgMicro.EmptyRows = true;
                        #endregion

                        #region Macroinsumos
                        TcProduccion.SelectedIndex = 1;
                        TdgMacro.SetDataBinding(Ds.Tables["DtPlanProduccionMAI"], "", false);

                        this.TdgMacro.Columns["Batch"].Caption = "Batch";
                        this.TdgMacro.Splits[0].DisplayColumns["Batch"].Style.Locked = true;
                        this.TdgMacro.Splits[0].DisplayColumns["Batch"].Visible = true;
                        this.TdgMacro.Splits[0].DisplayColumns["Batch"].Width = 100;
                        this.TdgMacro.Splits[0].DisplayColumns["Batch"].Merge = ColumnMergeEnum.Free;

                        this.TdgMacro.Columns["ProductoID"].Caption = "ProductoID";
                        this.TdgMacro.Splits[0].DisplayColumns["ProductoID"].Style.Locked = true;
                        this.TdgMacro.Splits[0].DisplayColumns["ProductoID"].Visible = false;
                        this.TdgMacro.Splits[0].DisplayColumns["ProductoID"].Width = 280;
                        this.TdgMacro.Splits[0].DisplayColumns["ProductoID"].Merge = ColumnMergeEnum.Free;

                        this.TdgMacro.Columns["NomProducto"].Caption = "Producto Terminado";
                        this.TdgMacro.Splits[0].DisplayColumns["NomProducto"].Style.Locked = true;
                        this.TdgMacro.Splits[0].DisplayColumns["NomProducto"].Visible = true;
                        this.TdgMacro.Splits[0].DisplayColumns["NomProducto"].Width = 250;
                        this.TdgMacro.Splits[0].DisplayColumns["NomProducto"].Merge = ColumnMergeEnum.Free;

                        for (int x = 3; x < Ds.Tables["DtPlanProduccionMAI"].Columns.Count; x++)
                        {
                            this.TdgMacro.Columns[Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName].Caption = Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName;
                            this.TdgMacro.Columns[Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName].NumberFormat = "FormatText Event";
                            this.TdgMacro.Splits[0].DisplayColumns[Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName].Style.Locked = true;
                            this.TdgMacro.Splits[0].DisplayColumns[Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName].Visible = true;
                            this.TdgMacro.Splits[0].DisplayColumns[Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName].Width = 230;
                            //this.TdgMacro.Splits[0].DisplayColumns["NomProducto"].Merge = ColumnMergeEnum.Free;
                        }
                        TdgMacro.EmptyRows = true;
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("No se ha agregado todavia ningun producto terminado o un batch es iguala '0'.", "Error en Plan de produccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TcProduccion.SelectedIndex = 0;
                        DataTable dt1 = new DataTable();
                        DataTable dt2 = new DataTable();

                        TcProduccion.SelectedIndex = 0;
                        TdgMicro.SetDataBinding(dt1, "", true);
                        TcProduccion.SelectedIndex = 1;
                        TdgMacro.SetDataBinding(dt2, "", true);
                    }
                    #endregion
                }
                else if (TcOpciones.SelectedIndex == 1)
                {
                    #region Historico
                    if (LstHistorico.SelectedIndex != -1 & HayCero == false & DtProductosBatch.Rows.Count > 0)
                    {
                        //traer todos las formulas del batch
                        Ds = new DataSet();
                        Ds = ObjCL_Produccion.GetMateriasPrimasHistorico(DtProductosBatch, Convert.ToInt32(LstHistorico.SelectedValue), AppSettings.EmpresaID, AppSettings.SedeID);

                        #region Microinsumos
                        TcProduccion.SelectedIndex = 0;
                        TdgMicro.SetDataBinding(Ds.Tables["DtPlanProduccionMII"], "", false);

                        this.TdgMicro.Columns["Batch"].Caption = "Batch";
                        this.TdgMicro.Splits[0].DisplayColumns["Batch"].Style.Locked = true;
                        this.TdgMicro.Splits[0].DisplayColumns["Batch"].Visible = true;
                        this.TdgMicro.Splits[0].DisplayColumns["Batch"].Width = 100;
                        this.TdgMicro.Splits[0].DisplayColumns["Batch"].Merge = ColumnMergeEnum.Free;

                        this.TdgMicro.Columns["ProductoID"].Caption = "ProductoID";
                        this.TdgMicro.Splits[0].DisplayColumns["ProductoID"].Style.Locked = true;
                        this.TdgMicro.Splits[0].DisplayColumns["ProductoID"].Visible = false;
                        this.TdgMicro.Splits[0].DisplayColumns["ProductoID"].Width = 280;
                        this.TdgMicro.Splits[0].DisplayColumns["ProductoID"].Merge = ColumnMergeEnum.Free;

                        this.TdgMicro.Columns["NomProducto"].Caption = "Producto Terminado";
                        this.TdgMicro.Splits[0].DisplayColumns["NomProducto"].Style.Locked = true;
                        this.TdgMicro.Splits[0].DisplayColumns["NomProducto"].Visible = true;
                        this.TdgMicro.Splits[0].DisplayColumns["NomProducto"].Width = 250;
                        this.TdgMicro.Splits[0].DisplayColumns["NomProducto"].Merge = ColumnMergeEnum.Free;

                        for (int x = 3; x < Ds.Tables["DtPlanProduccionMII"].Columns.Count; x++)
                        {
                            this.TdgMicro.Columns[Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName].Caption = Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName;
                            this.TdgMicro.Columns[Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName].NumberFormat = "FormatText Event";
                            this.TdgMicro.Splits[0].DisplayColumns[Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName].Style.Locked = true;
                            this.TdgMicro.Splits[0].DisplayColumns[Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName].Visible = true;
                            this.TdgMicro.Splits[0].DisplayColumns[Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName].Width = 230;
                            //this.TdgMicro.Splits[0].DisplayColumns["NomProducto"].Merge = ColumnMergeEnum.Free;
                        }
                        TdgMicro.EmptyRows = true;
                        #endregion

                        #region Macroinsumos
                        TcProduccion.SelectedIndex = 1;
                        TdgMacro.SetDataBinding(Ds.Tables["DtPlanProduccionMAI"], "", false);

                        this.TdgMacro.Columns["Batch"].Caption = "Batch";
                        this.TdgMacro.Splits[0].DisplayColumns["Batch"].Style.Locked = true;
                        this.TdgMacro.Splits[0].DisplayColumns["Batch"].Visible = true;
                        this.TdgMacro.Splits[0].DisplayColumns["Batch"].Width = 100;
                        this.TdgMacro.Splits[0].DisplayColumns["Batch"].Merge = ColumnMergeEnum.Free;

                        this.TdgMacro.Columns["ProductoID"].Caption = "ProductoID";
                        this.TdgMacro.Splits[0].DisplayColumns["ProductoID"].Style.Locked = true;
                        this.TdgMacro.Splits[0].DisplayColumns["ProductoID"].Visible = false;
                        this.TdgMacro.Splits[0].DisplayColumns["ProductoID"].Width = 280;
                        this.TdgMacro.Splits[0].DisplayColumns["ProductoID"].Merge = ColumnMergeEnum.Free;

                        this.TdgMacro.Columns["NomProducto"].Caption = "Producto Terminado";
                        this.TdgMacro.Splits[0].DisplayColumns["NomProducto"].Style.Locked = true;
                        this.TdgMacro.Splits[0].DisplayColumns["NomProducto"].Visible = true;
                        this.TdgMacro.Splits[0].DisplayColumns["NomProducto"].Width = 250;
                        this.TdgMacro.Splits[0].DisplayColumns["NomProducto"].Merge = ColumnMergeEnum.Free;

                        for (int x = 3; x < Ds.Tables["DtPlanProduccionMAI"].Columns.Count; x++)
                        {
                            this.TdgMacro.Columns[Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName].Caption = Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName;
                            this.TdgMacro.Columns[Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName].NumberFormat = "FormatText Event";
                            this.TdgMacro.Splits[0].DisplayColumns[Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName].Style.Locked = true;
                            this.TdgMacro.Splits[0].DisplayColumns[Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName].Visible = true;
                            this.TdgMacro.Splits[0].DisplayColumns[Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName].Width = 230;
                            //this.TdgMacro.Splits[0].DisplayColumns["NomProducto"].Merge = ColumnMergeEnum.Free;
                        }
                        TdgMacro.EmptyRows = true;
                        #endregion

                    }
                    else
                    {
                        MessageBox.Show("No se ha agregado todavia ningun producto terminado o un Batch es igual a '0'.", "Error en Plan de produccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TcProduccion.SelectedIndex = 0;
                        DataTable dt1 = new DataTable();
                        DataTable dt2 = new DataTable();

                        TcProduccion.SelectedIndex = 0;
                        TdgMicro.SetDataBinding(dt1, "", true);
                        TcProduccion.SelectedIndex = 1;
                        TdgMacro.SetDataBinding(dt2, "", true);
                    }
                    #endregion
                    BtnProductoTerminado.Visible = true;
                }
                BtnGrabar.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TdgFormuladosBatch_DoubleClick(object sender, EventArgs e)
        {
            string ProductoID;
            string NomProducto;
            ProductoID = this.TdgFormuladosBatch.Columns["ProductoID"].Value.ToString();
            NomProducto = this.TdgFormuladosBatch.Columns["NomProducto"].Value.ToString();
            //mostrar las materias primas del producto para poder editarlas
            ModificarPlanProduccion ObjModificarPlanProduccion = new ModificarPlanProduccion();
            ObjModificarPlanProduccion.ProductoID = ProductoID;
            ObjModificarPlanProduccion.NomProducto = NomProducto;
            ObjModificarPlanProduccion.ShowDialog();
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Ds != null)//si datatset tiene tablas
                {
                    bool MenorqDisponible = false;
                    string Producto = "";

                    #region crear solicitud de transferencia
                    DataTable dtRequerimiento = new DataTable();
                    dtRequerimiento.Columns.Add("Origen", typeof(string));
                    dtRequerimiento.Columns.Add("Sede", typeof(string));
                    dtRequerimiento.Columns.Add("AlmacenID", typeof(string));
                    dtRequerimiento.Columns.Add("Almacen", typeof(string));
                    dtRequerimiento.Columns.Add("ProductoID", typeof(string));
                    dtRequerimiento.Columns.Add("Producto", typeof(string));
                    dtRequerimiento.Columns.Add("UM", typeof(string));
                    dtRequerimiento.Columns.Add("Marca", typeof(string));
                    dtRequerimiento.Columns.Add("Disponible", typeof(decimal));
                    dtRequerimiento.Columns.Add("CantidadSolicitada", typeof(decimal));
                    dtRequerimiento.Columns.Add("Observacion", typeof(string));


                    //#region Macroinsumos
                    //filtrar todos los productos para que se conviertan en columnas
                    DataTable DtFiltro1 = new DataTable();
                    DtFiltro1 = new BaseFunctions().SelectDistinct(Ds.Tables["Temp"], "ProductoIDMateria", "AlmacenMateria", "NomProducto");

                    //crear las columnas
                    DataTable DTAcu = new DataTable();
                    DTAcu.Columns.Add("ProductoIDMateria", typeof(string));
                    DTAcu.Columns.Add("Almacen", typeof(string));
                    DTAcu.Columns.Add("Cantidad", typeof(decimal));

                    //filtrar e ir agregando 
                    foreach (DataRow dr2 in DtFiltro1.Rows)
                    {
                        DataRow DR = DTAcu.NewRow();
                        DR["ProductoIDMateria"] = dr2["ProductoIDMateria"];
                        DR["Almacen"] = AppSettings.EmpresaID + AppSettings.SedeID + dr2["AlmacenMateria"];

                        //filtrar e ir agregando
                        DataView Dv = new DataView(Ds.Tables["DtSumatoria"]);
                        Dv.RowFilter = "NomProducto = '" + dr2["NomProducto"] + "'";
                        decimal Cantidad = 0;
                        Cantidad = Convert.ToDecimal(Dv[0]["Cantidad"]);
                        DR["Cantidad"] = Cantidad;
                        DTAcu.Rows.Add(DR);
                    }

                    foreach (DataRow DR in DTAcu.Rows)
                    {
                        DataRow row = dtRequerimiento.NewRow();
                        row["Origen"] = AppSettings.EmpresaID + AppSettings.SedeID + "PRO";//quien lo solicita
                        row["Sede"] = AppSettings.NomSede;
                        row["AlmacenID"] = DR["Almacen"];//quien debe darselo
                        row["Almacen"] = "PRODUCCION";
                        row["ProductoID"] = DR["ProductoIDMateria"];
                        row["Producto"] = "";
                        row["UM"] = "";
                        row["Marca"] = "";

                        //obtener el disponible
                        DataView DvS = new DataView(Ds.Tables["DtStockLocalSede"]);
                        DvS.RowFilter = "ProductoID = '" + DR["ProductoIDMateria"] + "'";
                        if (DvS.Count == 1)
                        {
                            row["Disponible"] = DvS[0]["StockDisponible"];
                            Producto = DvS[0]["NomProducto"].ToString();
                        }
                        else
                        {
                            row["Disponible"] = 0;
                            Producto = DR["ProductoIDMateria"].ToString();
                        }
                        //validar si lo solicitado es menor que lo disponible, sea el caso se creara el requerimiento de trasnferencia
                        if (Convert.ToDecimal(row["Disponible"]) < Convert.ToDecimal(DR["Cantidad"]))
                        {
                            MenorqDisponible = true;
                            break;
                        }
                        row["CantidadSolicitada"] = DR["Cantidad"];
                        row["Observacion"] = "para produccion del dia: " + DateTime.Now.ToString();
                        dtRequerimiento.Rows.Add(row);
                    }

                    #endregion

                    if (MenorqDisponible == false)
                    {
                        new CL_Requerimientos().InsertarTransferencia(dtRequerimiento, AppSettings.UserID, AppSettings.EmpresaID, AppSettings.NomSede, AppSettings.ApeNom_Login);
                        #region guardar historico
                        ObjCL_Produccion.InsertMateriaPrimaHistorico(AppSettings.EmpresaID, AppSettings.UserID, Ds.Tables["Temp"], DtProductosBatch);
                        #endregion
                        MessageBox.Show("Se guardo correctamente en el historial", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("El producto: " + Producto + " no tiene suficiente stock disponible, disminuyalo o espere que  cuente con el stock necesario.\r\n\r\n No se creo el requerimiento de transferencia ni se guardo el plan de producción.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnGrabar.Visible = false;
                    BtnNuevo_Click(null, null);
                }//fin si dataset tiene tablas
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ". Metodo  InsertMateriaPrimaHistorico().", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DtMateriaPrimaHistorico = new DataTable();
            DtProductosBatch.Clear();
            TdgFormuladosHistorico.SetDataBinding(DtProductosBatch, "", true);

            if (cboFechaInicio.Value.ToString() != "" && cboFechaFin.Value.ToString() != "")
            {
                DateTime FecIni;
                DateTime FecFin;
                FecIni = Convert.ToDateTime(cboFechaInicio.Value).Date;
                FecFin = Convert.ToDateTime(cboFechaFin.Value).AddDays(1).Date;

                DtMateriaPrimaHistorico = ObjCL_Produccion.GetMateriaPrimaHistoricoFechas(FecIni, FecFin, AppSettings.EmpresaID);
                LstHistorico.DataSource = DtMateriaPrimaHistorico;
                LstHistorico.DisplayMember = "AudCrea";
                LstHistorico.ValueMember = "MateriaPrimaHistoricoID";
            }
            else
                LstHistorico.DataSource = DtMateriaPrimaHistorico;
            
            Cursor = Cursors.Default;
        }

        private void LstHistorico_DoubleClick(object sender, EventArgs e)
        {
            if (LstHistorico.SelectedIndex != -1)
            {
                //traerme tabla batchs
                DtProductosBatch.Clear();
                MateriaPrimaHistoricoID = Convert.ToInt32(LstHistorico.SelectedValue);
                DtProductosBatch = ObjCL_Produccion.GetDtroductosBatchHistorico(MateriaPrimaHistoricoID);
                TdgFormuladosHistorico.SetDataBinding(DtProductosBatch, "", true);
                if (DtProductosBatch.Rows.Count > 0)
                    BtnMostrarPlan.Visible = true;
                else
                    BtnMostrarPlan.Visible = false;
            }
        }

        private void BtnQuitarHistorico_Click(object sender, EventArgs e)
        {
            if (TdgFormuladosHistorico.RowCount > 0)
            {
                string ProductoID;
                ProductoID = this.TdgFormuladosHistorico.Columns["ProductoID"].Value.ToString();

                foreach (DataRow Dr in DtProductosBatch.Rows)
                {
                    if (Dr["ProductoID"].ToString() == ProductoID)//si es la fila se graga a la otra tabla y de paso se borra
                    {
                        DtProductosBatch.Rows.Remove(Dr);//se elimina de la tabla
                        return;
                    }
                }

            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            TcOpciones_SelectedIndexChanged(null, null);
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            TcProduccion.SelectedIndex = 0;
            TdgMicro.SetDataBinding(dt1, "", true);
            TcProduccion.SelectedIndex = 1;
            TdgMacro.SetDataBinding(dt2, "", true);

        }

        private void TcOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            DtProductosBatch.Clear();
            BtnGrabar.Visible = false;
            if (TcOpciones.SelectedIndex == 0)
            {
                DtProductosFormulados.Clear();
                DtProductosFormulados.Merge(DtProductosFormuladosA);
                TdgProductosFormulados.SetDataBinding(DtProductosFormulados, "", true);
                TdgFormuladosBatch.SetDataBinding(DtProductosBatch, "", true);
                BtnMostrarPlan.Visible = true;
            }
            else if (TcOpciones.SelectedIndex == 1)
            {
                BtnProductoTerminado.Visible = true;
                TdgFormuladosHistorico.SetDataBinding(DtProductosBatch, "", true);
                DtMateriaPrimaHistorico = new DataTable();
                LstHistorico.DataSource = DtMateriaPrimaHistorico;
                BtnProductoTerminado.Visible = false;
                BtnMostrarPlan.Visible = false;
            }
        }

        private void TdgMicro_FetchRowStyle(object sender, FetchRowStyleEventArgs e)
        {
            Font MFont;
            MFont = new Font(this.TdgMicro.Font, FontStyle.Bold);
            //TdgMicro.CaptionStyle.Font = MFont;

            string S = TdgMicro.Columns["NomProducto"].CellText(e.Row).ToString();
            if (S == "Totales: ")
            {
                e.CellStyle.ForeColor = System.Drawing.Color.Black;
                e.CellStyle.Font = MFont;
            }
            if (S == "Disponible local: ")
            {
                e.CellStyle.ForeColor = System.Drawing.Color.Blue;
                e.CellStyle.Font = MFont;
            }
            if (S == "Stock local: ")
            {
                e.CellStyle.ForeColor = System.Drawing.Color.Green;
                e.CellStyle.Font = MFont;
            }
        }

        private void TdgMacro_FetchRowStyle(object sender, FetchRowStyleEventArgs e)
        {
            Font MFont;
            MFont = new Font(this.TdgMicro.Font, FontStyle.Bold);
            //TdgMicro.CaptionStyle.Font = MFont;

            string S = TdgMacro.Columns["NomProducto"].CellText(e.Row).ToString();
            if (S == "Totales: ")
            {
                e.CellStyle.ForeColor = System.Drawing.Color.Black;
                e.CellStyle.Font = MFont;
            }
            if (S == "Disponible local: ")
            {
                e.CellStyle.ForeColor = System.Drawing.Color.Blue;
                e.CellStyle.Font = MFont;
            }
            if (S == "Stock local: ")
            {
                e.CellStyle.ForeColor = System.Drawing.Color.Green;
                e.CellStyle.Font = MFont;
            }
        }

        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                    {
                        Cursor = Cursors.AppStarting;
                        Office ObjOffice = new Office();
                        ObjOffice.DoExcell(f.SelectedPath + @"\" + "PMAI" + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Hour.ToString() + "h" + DateTime.Now.Minute.ToString() + "min.xls", Ds.Tables["DtPlanProduccionMAI"], "Produccion usada para macroinsumos del día " + DateTime.Now.ToString());
                        ObjOffice.DoExcell(f.SelectedPath + @"\" + "PMII" + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Hour.ToString() + "h" + DateTime.Now.Minute.ToString() + "min.xls", Ds.Tables["DtPlanProduccionMII"], "Produccion usada para microinsumos del día " + DateTime.Now.ToString());
                        string _nM = string.Format(_msg, f.SelectedPath);
                        MessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }

        private void BtnProductoTerminado_Click(object sender, EventArgs e)
        {
            try
            {
                BtnProductoTerminado.Visible = false;
                Cursor = Cursors.WaitCursor;

                ObjCL_Produccion.AgregarProductosterminados(DtProductosBatch, Ds.Tables["Temp"], AppSettings.EmpresaID, AppSettings.SedeID, AppSettings.UserID, MateriaPrimaHistoricoID);
                MessageBox.Show("Se agrego correctamente a propductos terminados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
                BtnNuevo_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
            
        }

        private void TdgMicro_FormatText(object sender, FormatTextEventArgs e)
        {
            for (int x = 3; x < Ds.Tables["DtPlanProduccionMII"].Columns.Count; x++)
            {
                if(e.Column.DataField.ToString() ==Ds.Tables["DtPlanProduccionMII"].Columns[x].ColumnName)
                    if (e.Value.ToString().Trim() != "")
                        e.Value = string.Format("{0:0.00}", Convert.ToDecimal(e.Value));
            }
        }

        private void TdgMacro_FormatText(object sender, FormatTextEventArgs e)
        {
            for (int x = 3; x < Ds.Tables["DtPlanProduccionMAI"].Columns.Count; x++)
            {
                if(e.Column.DataField.ToString() ==Ds.Tables["DtPlanProduccionMAI"].Columns[x].ColumnName)
                    if (e.Value.ToString().Trim() != "")
                        e.Value = string.Format("{0:0.00}", Convert.ToDecimal(e.Value));
            }

        }

        private void TdgFormuladosHistorico_FetchCellStyle(object sender, FetchCellStyleEventArgs e)
        {
            //habilitar si se puede modificar la columna de recibido
            switch (e.Column.DataColumn.DataField)
            {
                case "Producir":
                    if (Convert.ToBoolean(this.TdgFormuladosHistorico[e.Row, "Terminado"].ToString().Trim()) == true)
                    {
                        e.CellStyle.Locked = true;
                        break;
                    }
                    break;
            }
        }

    }
}

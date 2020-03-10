using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.Entidad.Almacen;
using Halley.Utilitario;
using Halley.Configuracion;


namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class Requemientos : Form
    {
        private DataTable DtRequerimientos;
        private DataTable DtRequerimientosC;
        private DataTable DetallesRequerimientosReq;
        private DataTable DtTempFiltrar;
        private string AlmacenID;
        private string AlmacenIDLocal;
        private string EmpresaSedeLocal;
        DataTable DtTemp = new DataTable();

        private string _TipoRequerimiento;
        private DataTable _DtAlmacenes;
        private string _EmpresaIDUser;
        private string _EmpresaSede;
        private string _SedeId;

        DataTable DtAlmacenUsuario = new DataTable();

        #region Propiedades

        public string TipoRequerimiento
        {
            get { return _TipoRequerimiento; }
            set { _TipoRequerimiento = value; }
        }
        public DataTable DtAlmacenes
        {
            get { return _DtAlmacenes; }
            set { _DtAlmacenes = value; }
        }
        public string EmpresaIDUser
        {
            get { return _EmpresaIDUser; }
            set { _EmpresaIDUser = value; }
        }
        public string EmpresaSede
        {
            get { return _EmpresaSede; }
            set { _EmpresaSede = value; }
        }
         public string SedeId
        {
            get { return _SedeId; }
            set { _SedeId = value; }
        }
        #endregion

        public Requemientos()
        {
            InitializeComponent();
        }

        private void Requemientos_Load(object sender, EventArgs e)
        {
            #region Traer Datos
            //cargar almacenes de los requerimientos
            DtAlmacenes.DefaultView.Sort = "AlmacenID";
            CboAlmacen.HoldFields();
            CboAlmacen.DataSource = DtAlmacenes;
            CboAlmacen.DisplayMember = "Descripcion";
            CboAlmacen.ValueMember = "AlmacenID";
            #endregion
            this.c1SuperTooltip1.Show("<table><tr><td><parm><img src='res://Recepcion32x32.gif'></parm></td><td><b><parm>Seleccionar Marca</parm></b></td></tr></table><parm><hr noshade size=1 style='margin:2' color=Darker></parm><div style='margin:1 12'><parm>en la columna 'Almacen'<br>Seleccionar la marca que <br>desea despachar.</parm></div><parm><hr noshade size=1 style='margin:2' color=Darker></parm><table><tr>  <td><parm><img src='res://pollito32x32.gif'></parm></td>  <td><b><parm>Hacer doble click para <br>que aparezca.</parm></b></td></tr></table>", this.TdgRequerimientos, 850, 10, 4500);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
 
            //Agregar tabla a la propiedad del despacho para que se agregue a los detalles de la hoja de despacho
            DetallesRequerimientosReq = new DataTable();
            DetallesRequerimientosReq.Columns.Add("NumRequerimiento", typeof(string));
            DetallesRequerimientosReq.Columns.Add("IDProveedor", typeof(Int32));
            DetallesRequerimientosReq.Columns.Add("Proveedor", typeof(string));
            DetallesRequerimientosReq.Columns.Add("ProductoID", typeof(string));
            DetallesRequerimientosReq.Columns.Add("Producto", typeof(string));
            DetallesRequerimientosReq.Columns.Add("Factura", typeof(string));
            DetallesRequerimientosReq.Columns.Add("NumGuiaRemision", typeof(string));
            DetallesRequerimientosReq.Columns.Add("NumGuiaTransporte", typeof(string));
            DetallesRequerimientosReq.Columns.Add("Bultos", typeof(string));
            DetallesRequerimientosReq.Columns.Add("PesoTotal", typeof(decimal));
            DetallesRequerimientosReq.Columns.Add("CantidadDespachada", typeof(decimal));
            DetallesRequerimientosReq.Columns.Add("Motivo", typeof(string));
            DetallesRequerimientosReq.Columns.Add("Anular", typeof(bool));
            DetallesRequerimientosReq.Columns.Add("CantidadSolicitada", typeof(decimal));
            DetallesRequerimientosReq.Columns.Add("CantidadRecibida", typeof(decimal));
            DetallesRequerimientosReq.Columns.Add("CantidadTransito", typeof(decimal));
            DetallesRequerimientosReq.Columns.Add("AlmacenID", typeof(string));
            DetallesRequerimientosReq.Columns.Add("SProductoID", typeof(string));
            DetallesRequerimientosReq.Columns.Add("TipoRequerimiento", typeof(string));

            DetallesRequerimientosReq.Columns["Motivo"].ReadOnly = false;
            DetallesRequerimientosReq.Columns["Anular"].ReadOnly = false;
            DetallesRequerimientosReq.Columns["PesoTotal"].ReadOnly = false;
            

            foreach (DataRow Row in DtTemp.Rows)
            {
                if (Convert.ToBoolean(Row["Agregar"]) == true && Convert.ToDecimal(Row["CantidadDespachada"]) > 0)
                {
                    DataRow RowD = DetallesRequerimientosReq.NewRow();
                    RowD["NumRequerimiento"] = Row["NumRequerimiento"];
                    RowD["IDProveedor"] = Row["IDProveedor"];
                    RowD["Proveedor"] = Row["RazonSocial"];
                    RowD["ProductoID"] = Row["ProductoID"];
                    RowD["Producto"] = Row["NomProducto"];
                    RowD["Factura"] = Row["FacturaProveedor"];
                    RowD["NumGuiaRemision"] = DBNull.Value;
                    RowD["NumGuiaTransporte"] = DBNull.Value;
                    RowD["Bultos"] = DBNull.Value;
                    RowD["PesoTotal"] = Row["PesoTotal"];
                    RowD["CantidadDespachada"] = Row["CantidadDespachada"];
                    RowD["Motivo"] = DBNull.Value;
                    RowD["Anular"] = DBNull.Value;
                    RowD["CantidadSolicitada"] = Row["CantidadSolicitada"];
                    RowD["CantidadRecibida"] = Row["CantidadRecibida"];
                    RowD["CantidadTransito"] = Row["CantidadTransito"];
                    RowD["AlmacenID"] = Row["SAlmacenID"];
                    RowD["SProductoID"] = Row["SProductoID"];
                    RowD["TipoRequerimiento"] = TipoRequerimiento;
                    DetallesRequerimientosReq.Rows.Add(RowD);
                }

            }
            if (DetallesRequerimientosReq.Rows.Count > 0)
            {
                Halley.Presentacion.Almacen.Operaciones.Despacho.DetallesRequerimientos.Merge(DetallesRequerimientosReq);
                CruzarDatos();
            }
            else
            { MessageBox.Show("Sebe seleccionar al menos un requerimiento e ingresar una cantidad a despachar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CboAlmacen_SelectedValueChanged(object sender, EventArgs e)
        {
            //limpiar tabla
            Cursor = Cursors.WaitCursor;
            DtRequerimientos = new DataTable();
            DtTemp.Clear();

            //Traer los requerimientos

            CL_Requerimientos ObjRequerimientos = new CL_Requerimientos();
            AlmacenID = CboAlmacen.SelectedValue.ToString();
            AlmacenIDLocal = EmpresaIDUser + AppSettings.SedeID + AlmacenID.Substring(7, 3);
            EmpresaSedeLocal = AppSettings.EmpresaID + AppSettings.SedeID;

            if (AppSettings.SedeID == "001PU")// si la sede es "Industria" debe mostra los que estén en estado de industria
            {
                if (TipoRequerimiento == "C" && AlmacenID != "00000TODOS")
                {
                    DtRequerimientos = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "6,4,3,7", "CA", EmpresaSede, EmpresaSedeLocal);
                }
                else if (TipoRequerimiento == "C" && AlmacenID == "00000TODOS")
                {
                    DtRequerimientos = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "6,4,3,7", "CS", EmpresaSede, EmpresaSedeLocal);
                }
                else if (TipoRequerimiento == "T" && AlmacenID != "00000TODOS")
                {
                    DtRequerimientos = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,6,4,3,7", "TA", EmpresaSede, EmpresaSedeLocal);
                }
                else if (TipoRequerimiento == "T" && AlmacenID == "00000TODOS")
                {
                    DtRequerimientos = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,6,4,3,7", "TS", EmpresaSede, EmpresaSedeLocal);
                }
                /*else if (TipoRequerimiento == "A" && AlmacenID != "00000TODOS")
                {
                    DtRequerimientosC = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "6,4,3,7", "CA", EmpresaSede, EmpresaSedeLocal);
                    DtRequerimientosT = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "6,4,3,7", "TA", EmpresaSede, EmpresaSedeLocal);
                    DtRequerimientos.Merge(DtRequerimientosC);
                    DtRequerimientos.Merge(DtRequerimientosT);
                }
                else if (TipoRequerimiento == "A" && AlmacenID == "00000TODOS")
                {
                    DtRequerimientosC = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "6,4,3,7", "CS", EmpresaSede, EmpresaSedeLocal);
                    DtRequerimientosT = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "6,4,3,7", "TS", EmpresaSede, EmpresaSedeLocal);
                    DtRequerimientos.Merge(DtRequerimientosC);
                    DtRequerimientos.Merge(DtRequerimientosT);
                }*/
                
            }
            else if (AppSettings.SedeID == "001AL")// si la sede es "Lima" debe mostrar planeado, industriaparcial, transito parcial, transito  destino parcial
            {
                if (TipoRequerimiento == "C" && AlmacenID != "00000TODOS")
                {
                    DtRequerimientos = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "1,6,4,3", "CA", EmpresaSede, EmpresaSedeLocal);
                }
                else if (TipoRequerimiento == "C" && AlmacenID == "00000TODOS")
                {
                    DtRequerimientos = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "1,6,4,3", "CS", EmpresaSede, EmpresaSedeLocal);
                }
                else if (TipoRequerimiento == "T" && AlmacenID != "00000TODOS")
                {
                    DtRequerimientos = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,6,4,3", "TA", EmpresaSede, EmpresaSedeLocal);
                }
                else if (TipoRequerimiento == "T" && AlmacenID == "00000TODOS")
                {
                    DtRequerimientos = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,6,4,3", "TS", EmpresaSede, EmpresaSedeLocal);
                }
                /*else if (TipoRequerimiento == "A" && AlmacenID != "00000TODOS")
                {
                    DtRequerimientosC = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,6,4,3", "CA", EmpresaSede, EmpresaSedeLocal);
                    DtRequerimientosT = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,6,4,3", "TA", EmpresaSede, EmpresaSedeLocal);
                    DtRequerimientos.Merge(DtRequerimientosC);
                    DtRequerimientos.Merge(DtRequerimientosT);
                }
                else if (TipoRequerimiento == "A" && AlmacenID == "00000TODOS")
                {
                    DtRequerimientosC = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,6,4,3", "CS", EmpresaSede, EmpresaSedeLocal);
                    DtRequerimientosT = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,6,4,3", "TS", EmpresaSede, EmpresaSedeLocal);
                    DtRequerimientos.Merge(DtRequerimientosC);
                    DtRequerimientos.Merge(DtRequerimientosT);
                }*/
            }
            else //los demas
            {
                if (TipoRequerimiento == "C" && AlmacenID != "00000TODOS")
                {
                    DtRequerimientos = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "1,4,6", "CA", EmpresaSede, EmpresaSedeLocal);
                }
                else if (TipoRequerimiento == "C" && AlmacenID == "00000TODOS")
                {
                    DtRequerimientos = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "1,4,6", "CS", EmpresaSede, EmpresaSedeLocal);
                }
                else if (TipoRequerimiento == "T" && AlmacenID != "00000TODOS")
                {
                    DtRequerimientos = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,4,6", "TA", EmpresaSede, EmpresaSedeLocal);
                }
                else if (TipoRequerimiento == "T" && AlmacenID == "00000TODOS")
                {
                    DtRequerimientos = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,4,6", "TS", EmpresaSede, EmpresaSedeLocal);
                }
                /*else if (TipoRequerimiento == "A" && AlmacenID != "00000TODOS")
                {
                    DtRequerimientosC = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,4,6", "CA", EmpresaSede, EmpresaSedeLocal);
                    DtRequerimientosT = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,4,6", "TA", EmpresaSede, EmpresaSedeLocal);
                    DtRequerimientos.Merge(DtRequerimientosC);
                    DtRequerimientos.Merge(DtRequerimientosT);
                }
                else if (TipoRequerimiento == "A" && AlmacenID == "00000TODOS")
                {
                    DtRequerimientosC = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,4,6", "CS", EmpresaSede, EmpresaSedeLocal);
                    DtRequerimientosT = ObjRequerimientos.GetRequerimientos(AlmacenID, AlmacenIDLocal, "0,4,6", "TS", EmpresaSede, EmpresaSedeLocal);
                    DtRequerimientos.Merge(DtRequerimientosC);
                    DtRequerimientos.Merge(DtRequerimientosT);
                }*/
            }

            //cruzar datos de la tabla detalles de hoja de despacho para que no se muestren
            CruzarDatos();
            Cursor = Cursors.Default;
        }

        private void CruzarDatos()
        {
            if (Halley.Presentacion.Almacen.Operaciones.Despacho.DetallesRequerimientos.Rows.Count > 0)
            {
                DataView Dv = new DataView(Halley.Presentacion.Almacen.Operaciones.Despacho.DetallesRequerimientos);
                DtTemp = DtRequerimientos.Clone();
                foreach (DataRow RowR in DtRequerimientos.Rows)
                {
                    Dv.RowFilter = "NumRequerimiento = '" + RowR["NumRequerimiento"] + "' and ProductoID = '" + RowR["ProductoID"] + "'";
                    if (Dv.Count == 0)
                    {
                        //si no existe se agrega a una nueva tabla
                        DtTemp.ImportRow(RowR);
                    }
                }
            }
            else
            {
                DtTemp.Merge(DtRequerimientos);
            }

            //mostrar solo los requerimientos con su producto en la tabla
            DtTempFiltrar = new DataTable();
            DtTempFiltrar = DtTemp.Clone();
            DtTempFiltrar.Merge(DtTemp); //pasamos los datos del Dttemp al dtTempFiltrar
            DtTemp.Clear(); //limpiamos temp
            //filtramos por requerimiento y producto unico
            DataTable DtFiltro = new DataTable();
            DtFiltro = new BaseFunctions().SelectDistinct(DtTempFiltrar, "NumRequerimiento", "ProductoID", "NomProducto", "UnidadMedidaID", "Peso", "CantidadSolicitada", "CantidadRecibida", "CantidadTransito", "CantidadDespachada", "ObservacionD", "EstadoIDD", "NomEstado", "PrioridadID");
            //regresamos lo filtrado a la tabla temporal
            foreach (DataRow DRR in DtFiltro.Rows)
            {
                
                DataRow DR = DtTemp.NewRow();
                DR["SAlmacenID"] = "";
                DR["NumRequerimiento"] = DRR["NumRequerimiento"];
                DR["Agregar"] = false;
                DR["NumOrdenCompra"] = "";
                DR["ProductoID"] = DRR["ProductoID"];
                DR["NomProducto"] = DRR["NomProducto"];
                DR["UnidadMedidaID"] = DRR["UnidadMedidaID"];
                DR["Peso"] = DRR["Peso"];
                DR["IDProveedor"] = 0;
                DR["RazonSocial"] = "";
                DR["FacturaProveedor"] = "";
                DR["CantidadRecibidaOC"] = 0;
                DR["SAlmacen"] = "   ";
                DR["StockActual"] = 0;
                DR["StockDisponible"] = 0;
                DR["CantidadSolicitada"] = DRR["CantidadSolicitada"];
                DR["CantidadRecibida"] = DRR["CantidadRecibida"];
                DR["CantidadTransito"] = DRR["CantidadTransito"];
                DR["CantidadDespachada"] = DRR["CantidadDespachada"];
                DR["PesoTotal"] = 0;
                DR["ObservacionD"] = DRR["ObservacionD"];
                DR["EstadoIDD"] = DRR["EstadoIDD"];
                DR["NomEstado"] = DRR["NomEstado"];
                DR["PrioridadID"] = DRR["PrioridadID"];
                DR["SProductoID"] = "";
                DR["SNomMarca"] = "";
                DtTemp.Rows.Add(DR);
            }
            
            DtTemp.Columns["Agregar"].ReadOnly = false;
            DtTemp.Columns["CantidadDespachada"].ReadOnly = false;
            DtTemp.Columns["PesoTotal"].ReadOnly = false;
            DtTemp.Columns["IDProveedor"].ReadOnly = false;
            DtTemp.Columns["SAlmacen"].ReadOnly = false;

            TdgRequerimientos.SetDataBinding(DtTemp, "", true);
            this.TdgRequerimientos.Columns[10].Editor = this.c1NELith;// enlazar con control para que acepte solo numeros
        }

        private void TdgRequerimientos_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            if (this.TdgRequerimientos.RowCount > 0)
            {
                decimal valor = 0;
                

                if (AppSettings.SedeID == "001PU")
                {

                    if (Convert.ToDecimal(TdgRequerimientos.Columns["CantidadSolicitada"].Value) < Convert.ToDecimal(TdgRequerimientos.Columns["CantidadRecibida"].Value) + Convert.ToDecimal(TdgRequerimientos.Columns["CantidadDespachada"].Value))
                    {
                        MessageBox.Show("El total de lo recibido y despachado es mayor que lo solicitado", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        TdgRequerimientos.Columns["CantidadDespachada"].Value = 0;
                        e.Cancel = false;
                        return;
                    }
                    //if (Convert.ToDecimal(TdgRequerimientos.Columns["Stock"].Value) < Convert.ToDecimal(TdgRequerimientos.Columns["CantidadRecibida"].Value) + Convert.ToDecimal(TdgRequerimientos.Columns["CantidadDespachada"].Value))
                    if (Convert.ToDecimal(TdgRequerimientos.Columns["StockActual"].Value) < Convert.ToDecimal(TdgRequerimientos.Columns["CantidadDespachada"].Value))
                    {
                        MessageBox.Show("Lo despachado es mayor que el Stock", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        TdgRequerimientos.Columns["CantidadDespachada"].Value = 0;
                        e.Cancel = false;
                    }
                }
                else
                {
                    valor = Convert.ToDecimal(TdgRequerimientos.Columns["CantidadTransito"].Value) + Convert.ToDecimal(TdgRequerimientos.Columns["CantidadRecibida"].Value) + Convert.ToDecimal(TdgRequerimientos.Columns["CantidadDespachada"].Value);
                    if (valor > Convert.ToDecimal(TdgRequerimientos.Columns["StockActual"].Value))
                    {
                        MessageBox.Show("El total de enviado, transito y recibido '" + valor + "' es mayor que el stock", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        TdgRequerimientos.Columns["CantidadDespachada"].Value = 0;
                        e.Cancel = false;
                        return;
                    }
                    if (valor > Convert.ToDecimal(TdgRequerimientos.Columns["CantidadSolicitada"].Value))
                    {
                        MessageBox.Show("El total de enviado, transito y recibido '" + valor + "' es mayor que la cantidad solicitada", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        TdgRequerimientos.Columns["CantidadDespachada"].Value = 0;
                        e.Cancel = false;
                    }
                }
            }
            //TdgRequerimientos.Splits[0].DisplayColumns["Peso"].Style.Locked = false;
            TdgRequerimientos.Columns["PesoTotal"].Value = Convert.ToDecimal(TdgRequerimientos.Columns["CantidadDespachada"].Value) * Convert.ToDecimal(TdgRequerimientos.Columns["Peso"].Value);
            //TdgRequerimientos.Splits[0].DisplayColumns["Peso"].Style.Locked = true;
        }

        private void TdgRequerimientos_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {
            //darle el color a al celda segun su prioridad
            switch (e.Column.DataColumn.DataField)
            {
                case "PrioridadID":
                    if (this.TdgRequerimientos[e.Row, "PrioridadID"].ToString().Trim() == "M")
                    {
                        e.CellStyle.BackColor =  Color.Gold;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    }

                    if (this.TdgRequerimientos[e.Row, "PrioridadID"].ToString().Trim() == "B")
                    {
                        e.CellStyle.BackColor = Color.MediumSeaGreen;
                        break;
                    }

                    if (this.TdgRequerimientos[e.Row, "PrioridadID"].ToString().Trim() == "A")
                    {
                        e.CellStyle.BackColor = Color.Crimson;
                        break;
                    }
                    break;
            }
        }


        private void TdgRequerimientos_DoubleClick(object sender, EventArgs e)
        {
            //Llenar el dropdow con datos de los almacenes
            string NumRequerimiento;
            string ProductoID;

            //crear tabla para guardar lo filtrado
            DataTable DtAlmacenesF = new DataTable();
            DtAlmacenesF.Columns.Add("SAlmacenID", typeof(string));
            DtAlmacenesF.Columns.Add("NumOrdenCompra", typeof(string));
            DtAlmacenesF.Columns.Add("IDProveedor", typeof(int));
            DtAlmacenesF.Columns.Add("RazonSocial", typeof(string));
            DtAlmacenesF.Columns.Add("FacturaProveedor", typeof(string));
            DtAlmacenesF.Columns.Add("CantidadRecibidaOC", typeof(decimal));
            DtAlmacenesF.Columns.Add("SAlmacen", typeof(string));
            DtAlmacenesF.Columns.Add("StockActual", typeof(decimal));
            DtAlmacenesF.Columns.Add("StockDisponible", typeof(decimal));
            DtAlmacenesF.Columns.Add("SProductoID", typeof(string));
            DtAlmacenesF.Columns.Add("SNomMarca", typeof(string));


            NumRequerimiento = this.TdgRequerimientos.Columns["NumRequerimiento"].Value.ToString();
            ProductoID = this.TdgRequerimientos.Columns["ProductoID"].Value.ToString();

            DataView Dv = new DataView(DtTempFiltrar);

            Dv.RowFilter = "NumRequerimiento = '" + NumRequerimiento + "' and ProductoID = '" + ProductoID + "'";
            foreach (DataRowView Drv in Dv)
            {
                DataRow DR = DtAlmacenesF.NewRow();
                DR["SAlmacenID"] = Drv["SAlmacenID"];
                DR["NumOrdenCompra"] = Drv["NumOrdenCompra"];
                DR["IDProveedor"] = Drv["IDProveedor"];
                DR["RazonSocial"] = Drv["RazonSocial"];
                DR["FacturaProveedor"] = Drv["FacturaProveedor"];
                DR["CantidadRecibidaOC"] = Drv["CantidadRecibidaOC"];
                DR["SAlmacen"] = Drv["SAlmacen"];
                DR["StockActual"] = Drv["StockActual"];
                DR["StockDisponible"] = Drv["StockDisponible"];
                DR["SProductoID"] = Drv["SProductoID"];
                DR["SNomMarca"] = Drv["SNomMarca"];
                DtAlmacenesF.Rows.Add(DR);
            }
           
            //cargar formulario para obtener los datos
            SeleccionarMarcas ObjSeleccionarMarcas = new SeleccionarMarcas();
            ObjSeleccionarMarcas.DtDatos = DtAlmacenesF;
            ObjSeleccionarMarcas.ShowDialog();
            //DtAlmacenesF.Clear();
            //DtAlmacenesF.Merge(ObjSeleccionarMarcas.DtDatos);

            //llenar datos
            if (DtAlmacenesF.Rows.Count == 1)
            {
                if (DtAlmacenesF.Rows[0]["NumOrdenCompra"].ToString() + "" == "")
                {
                    this.TdgRequerimientos.Columns["SAlmacenID"].Value = DtAlmacenesF.Rows[0]["SAlmacenID"];
                    this.TdgRequerimientos.Columns["SAlmacen"].Value = DtAlmacenesF.Rows[0]["SAlmacen"];
                    this.TdgRequerimientos.Columns["StockActual"].Value = DtAlmacenesF.Rows[0]["StockActual"];
                    this.TdgRequerimientos.Columns["StockDisponible"].Value = DtAlmacenesF.Rows[0]["StockDisponible"];
                    this.TdgRequerimientos.Columns["SProductoID"].Value = DtAlmacenesF.Rows[0]["SProductoID"];
                    this.TdgRequerimientos.Columns["SNomMarca"].Value = DtAlmacenesF.Rows[0]["SNomMarca"];
                }
                else
                {
                    this.TdgRequerimientos.Columns["SAlmacenID"].Value = DtAlmacenesF.Rows[0]["SAlmacenID"];
                    this.TdgRequerimientos.Columns["NumOrdenCompra"].Value = DtAlmacenesF.Rows[0]["NumOrdenCompra"];
                    this.TdgRequerimientos.Columns["IDProveedor"].Value = DtAlmacenesF.Rows[0]["IDProveedor"];
                    this.TdgRequerimientos.Columns["RazonSocial"].Value = DtAlmacenesF.Rows[0]["RazonSocial"];
                    this.TdgRequerimientos.Columns["FacturaProveedor"].Value = DtAlmacenesF.Rows[0]["FacturaProveedor"];
                    this.TdgRequerimientos.Columns["CantidadRecibidaOC"].Value = DtAlmacenesF.Rows[0]["CantidadRecibidaOC"];
                    this.TdgRequerimientos.Columns["SAlmacen"].Value = DtAlmacenesF.Rows[0]["SAlmacen"];
                    this.TdgRequerimientos.Columns["StockActual"].Value = DtAlmacenesF.Rows[0]["StockActual"];
                    this.TdgRequerimientos.Columns["StockDisponible"].Value = DtAlmacenesF.Rows[0]["StockDisponible"];
                    this.TdgRequerimientos.Columns["SProductoID"].Value = DtAlmacenesF.Rows[0]["SProductoID"];
                    this.TdgRequerimientos.Columns["SNomMarca"].Value = DtAlmacenesF.Rows[0]["SNomMarca"];
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.Utilitario;
using Halley.Configuracion;
using C1.Win.C1TrueDBGrid;
using Halley.CapaLogica.Empresa;
using Halley.Entidad.Almacen;
using CrystalDecisions.CrystalReports.Engine;

namespace Halley.Presentacion.Almacen.Reportes
{
    public partial class Rep_Kardex : UITemplateAccess
    {
        #region Declaracion de Variables

        DataTable dt;
        DataTable dtKardex;
        DataTable dtProducto;
        public static DataTable DTMovimiento;
        public static DataTable DtTipoDocumento;
        public static DataTable DTOperacion;
        DataSet Ds = new DataSet();
        public static DataTable DtTemp = new DataTable();

        string ProductoId;
        int TipoMovimiento;
        DateTime FecInicial;
        DateTime FecFinal;

        #endregion

        #region Constructor

        public Rep_Kardex()
        {
            InitializeComponent();
            this.ocultarToolStrip();
            c1Combo.FillC1Combo(this.cbMovimiento, new CL_Almacen().GetMovimiento(), "NomMovimiento", "MovimientoID");
            
        }

        #endregion

        #region Eventos de los Controles

        private void Rep_Kardex_Load(object sender, EventArgs e)
        {
             DateTime fechatemp = DateTime.Today;

            dtpInicial.Value = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            dtpFinal.Value = DateTime.Today;

            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            //obtener año
            CboAnno.HoldFields();
            CboAnno.DataSource = c1Combo.Annos().Copy();
            CboAnno.DisplayMember = "Anno";
            CboAnno.ValueMember = "Anno";
            CboAnno.SelectedValue = DateTime.Now.Year;

            //obtener periodos
            CboPeriodo.HoldFields();
            CboPeriodo.DataSource = c1Combo.DtPeriodos().Copy();
            CboPeriodo.DisplayMember = "Descripcion";
            CboPeriodo.ValueMember = "Codigo";
            CboPeriodo.SelectedValue = DateTime.Now.Month.ToString().PadLeft(2,'0');

            c1cboCia.SelectedValue = AppSettings.EmpresaID;

            DataTable DtProductos = new DataTable();
            DtProductos = new CL_Producto().GetProductosPrincipales(true);
            DataRow DR = DtProductos.NewRow();
            DR["ProductoID"] = "TODOS";
            DR["NomProducto"] = "TODOS";
            DR["Alias"] = "TODOS";
            DR["Almacen"] = "TOD";
            DR["SubFamiliaID"] = 0;
            DR["ProductoIDVentas"] = "TODOS";
            DR["UnidadMedidaID"] = "NN";
            DR["NomMarca"] = "Sin Marca";
            DR["MarcaID"] = "0";
            DtProductos.Rows.InsertAt(DR, 0);


            cbProducto.HoldFields();
            cbProducto.DataSource = DtProductos;
            cbProducto.DisplayMember = "Alias";
            cbProducto.ValueMember = "ProductoID";
            cbProducto.SelectedIndex = 0;

            PnlPeriodo.Visible = false;

            //obtener todas las sedes
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            DataRow DR2 = Dtsedes.NewRow();
            DR2["SedeID"] = "TODOS";
            DR2["NomSede"] = "TODOS";
            DR2["Numero"] = 0;
            DR2["Interior"] = 0;
            DR2["Zona"] = "";
            DR2["Distrito"] = "TODOS";
            DR2["Provincia"] = "TODOS";
            DR2["Departamento"] = "TODOS";
            Dtsedes.Rows.InsertAt(DR2, 0);
            c1Combo.FillC1Combo(CboSede, Dtsedes, "NomSede", "SedeID");
            CboSede.SelectedValue = "TODOS";


            //Obtener Movimiento
            CL_Kardex ObjCL_Kardex = new CL_Kardex();
            DTMovimiento = new DataTable();
            DTMovimiento = ObjCL_Kardex.GetMovimiento();
            TddMovimiento.SetDataBinding(DTMovimiento, "", true);
            TddMovimiento.DisplayMember = "MovimientoID";
            TddMovimiento.ValueMember = "MovimientoID";

            //obtener tipo documento
            DtTipoDocumento = new DataTable();
            DtTipoDocumento = ObjCL_Kardex.GetTipoDocumento();
            TddTipoDocumento.SetDataBinding(DtTipoDocumento, "", true);
            TddTipoDocumento.DisplayMember = "TipoContabilidad";
            TddTipoDocumento.ValueMember = "TipoContabilidad";

            //obtener operacion
            DTOperacion = new DataTable();
            DTOperacion = ObjCL_Kardex.GetOperacionKardex();
            TddOperacionKardex.SetDataBinding(DTOperacion, "", true);
            TddOperacionKardex.DisplayMember = "OperacionID";
            TddOperacionKardex.ValueMember = "OperacionID";
        }


        private void ckbMovimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMovimiento.Checked)
            {
                cbMovimiento.SelectedIndex = -1;
                cbMovimiento.Enabled = false;
            }
            else
            {
                cbMovimiento.SelectedIndex = 1;
                cbMovimiento.Enabled = true;
            }
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ProductoId = "";
            TipoMovimiento = 0;
            if (RbRAngo.Checked == true)
            {
                FecInicial = Convert.ToDateTime(dtpInicial.Value.ToShortDateString());
                FecFinal = Convert.ToDateTime(this.dtpFinal.Value.AddDays(1).ToShortDateString());
            }
            else if (RbPeriodo.Checked == true)
            {
                FecInicial = new DateTime(Convert.ToInt16(CboAnno.SelectedValue.ToString()), Convert.ToInt16(CboPeriodo.SelectedValue.ToString()), 1);
                FecFinal = new DateTime(Convert.ToInt16(CboAnno.SelectedValue.ToString()), Convert.ToInt16(CboPeriodo.SelectedValue.ToString()), 1).AddMonths(1);
            }

            ProductoId = cbProducto.SelectedValue.ToString();

            if (ckbMovimiento.Checked == false)
            {
                TipoMovimiento = int.Parse(this.cbMovimiento.SelectedValue.ToString());
            }

            if (TcKardex.SelectedIndex == 0)//NORMAL
                get_Kardex(ProductoId.Trim(), TipoMovimiento, AppSettings.UserID, FecInicial.Date, FecFinal.Date);
            else if (TcKardex.SelectedIndex == 1)//PARA IMPRESION
                GetKardex2(1);
            else if (TcKardex.SelectedIndex == 2)//PRODUCTO REAL
                GetKardex2(2);
            else if (TcKardex.SelectedIndex == 3)//REPORTE CANTIDAD DE VENTAS
                GetKardexVenta(3);
            
        }


        #endregion

        #region Metodos Definidos

        void Habilitar(bool Boleano)
        {
            txtCodigo.Enabled = Boleano;
            txtExistencia_actual.Enabled = Boleano;
            txtUM.Enabled = Boleano;
            txtUltMovimiento.Enabled = Boleano;
        }

        void Limpiar()
        {
            txtCodigo.Clear();
            txtExistencia_actual.Clear();
            txtUltMovimiento.Clear();
            txtUM.Clear();
        }


        void get_Kardex(string ProductoId, int TipoMovimiento,int UsuarioID, DateTime FecInicial, DateTime FecFinal)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                Habilitar(true);
                Limpiar();
                          
                dt = new DataTable();
                dt = new CL_Kardex().getKardex(c1cboCia.SelectedValue.ToString() + CboSede.SelectedValue.ToString(), ProductoId, TipoMovimiento,UsuarioID, FecInicial, FecFinal);

                if (dt.Rows.Count == 0)
                {
                    Cursor = Cursors.Default;
                    this.tdbgKardex.SetDataBinding(null, "", true);
                    return;
                }

                if (ProductoId != "TODOS")
                {
                    dtProducto = new DataTable();
                    dtProducto = new CL_Kardex().getKardex_Producto(ProductoId, AppSettings.SedeID);

                    Habilitar(true);
                    txtCodigo.Text = dtProducto.Rows[0][0].ToString();
                    this.txtUM.Text = dtProducto.Rows[0][1].ToString();
                    txtExistencia_actual.Text = dtProducto.Rows[0][2].ToString();
                    txtUltMovimiento.Text = dtProducto.Rows[0][3].ToString();
                    Habilitar(false);
                }
                
                //Estructua del Kardex
                dtKardex = new DataTable();
                dtKardex.Columns.Add("Fecha", typeof(string));
                dtKardex.Columns.Add("ProductoID", typeof(string));
                dtKardex.Columns.Add("NomProducto", typeof(string));
                dtKardex.Columns.Add("UM", typeof(string));
                dtKardex.Columns.Add("Entrada", typeof(string));
                dtKardex.Columns.Add("Salida", typeof(string));
                dtKardex.Columns.Add("Documento", typeof(string));
                dtKardex.Columns.Add("Movimiento", typeof(string));
                dtKardex.Columns.Add("AlmacenOrigen", typeof(string));
                dtKardex.Columns.Add("AlmacenDestino", typeof(string));
                dtKardex.Columns.Add("SedeDestino", typeof(string));

                DateTime Fecha;
                foreach (DataRow drow in dt.Rows)
                {
                    DataRow Row;
                    Row = dtKardex.NewRow();

                    Fecha = Convert.ToDateTime(drow["AudCrea"]);
                    Row["Fecha"] = Fecha.ToString("dd/MM/yyyy");
                    Row["ProductoID"] = drow["ProductoID"].ToString();
                    Row["NomProducto"] = drow["Producto"].ToString();
                    Row["UM"] = drow["UnidadMedidaID"].ToString();

                    if (drow["Tipo"].ToString().Equals("S"))
                        Row["Salida"] = drow["Cantidad"].ToString();
                    else
                        Row["Entrada"] = drow["Cantidad"].ToString();

                    Row["Documento"] = drow["NroDocumento"].ToString();
                    Row["Movimiento"] = drow["NomMovimiento"].ToString();
                    Row["AlmacenOrigen"] = drow["Origen"].ToString();
                    Row["AlmacenDestino"] = drow["Destino"].ToString();
                    Row["SedeDestino"] = drow["NomSede"].ToString();
                    dtKardex.Rows.Add(Row);

                }

                this.tdbgKardex.SetDataBinding(dtKardex, "", false);

                if (ProductoId == "TODOS" && ckbMovimiento.Checked == true)
                    ConfigurarTdbGrid(80, 120, true, 350, true, 40, true, 90, 90, 150, 180, true, 200, 200, 300);

                else if (ProductoId == "TODOS" && ckbMovimiento.Checked == false)
                    ConfigurarTdbGrid(80, 120, true, 350, true, 40, true, 90, 90, 150, 0, false, 200, 200, 300);

                else if (ProductoId != "TODOS" && ckbMovimiento.Checked == true)
                    ConfigurarTdbGrid(80, 0, false, 0, false, 0, false, 90, 90, 150, 180, true, 200, 200, 300);
                else
                    ConfigurarTdbGrid(80, 0, false, 0, false, 0, false, 90, 90, 150, 0, false, 200, 200, 300);

                    Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        void ConfigurarTdbGrid(int Fecha, int Codigo, bool _Codigo, int Producto, bool _Producto, int UM,
                                      bool _UM, int Salida, int Entrada, int Documento, int Movimiento,bool _Movimiento, int AlmacenOrigen,
                                      int AlmacenDestino, int SedeDestino)
        {
            try
            {
                this.tdbgKardex.Columns["Fecha"].Caption = "Fecha";
                this.tdbgKardex.Splits[0].DisplayColumns["Fecha"].Style.Locked = true;
                this.tdbgKardex.Splits[0].DisplayColumns["Fecha"].Visible = true;
                this.tdbgKardex.Splits[0].DisplayColumns["Fecha"].Width = Fecha;
                this.tdbgKardex.Splits[0].DisplayColumns["Fecha"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

                this.tdbgKardex.Columns["ProductoID"].Caption = "Codigo";
                this.tdbgKardex.Splits[0].DisplayColumns["ProductoID"].Style.Locked = true;
                this.tdbgKardex.Splits[0].DisplayColumns["ProductoID"].Visible = _Codigo;
                this.tdbgKardex.Splits[0].DisplayColumns["ProductoID"].Width = Codigo;
                this.tdbgKardex.Splits[0].DisplayColumns["ProductoID"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

                this.tdbgKardex.Columns["NomProducto"].Caption = "Producto";
                this.tdbgKardex.Splits[0].DisplayColumns["NomProducto"].Style.Locked = true;
                this.tdbgKardex.Splits[0].DisplayColumns["NomProducto"].Visible = _Producto;
                this.tdbgKardex.Splits[0].DisplayColumns["NomProducto"].Width = Producto;
                this.tdbgKardex.Splits[0].DisplayColumns["NomProducto"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

                this.tdbgKardex.Columns["UM"].Caption = "UM";
                this.tdbgKardex.Splits[0].DisplayColumns["UM"].Style.Locked = true;
                this.tdbgKardex.Splits[0].DisplayColumns["UM"].Visible = _UM;
                this.tdbgKardex.Splits[0].DisplayColumns["UM"].Width = UM;
                this.tdbgKardex.Splits[0].DisplayColumns["UM"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
                
                this.tdbgKardex.Columns["Salida"].Caption = "Salida";
                this.tdbgKardex.Columns["Salida"].NumberFormat = "FormatText Event";
                this.tdbgKardex.Splits[0].DisplayColumns["Salida"].Style.Locked = true;
                this.tdbgKardex.Splits[0].DisplayColumns["Salida"].Visible = true;
                this.tdbgKardex.Splits[0].DisplayColumns["Salida"].Width = Salida;
                this.tdbgKardex.Splits[0].DisplayColumns["Salida"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
                this.tdbgKardex.Splits[0].DisplayColumns["Salida"].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;

                this.tdbgKardex.Columns["Entrada"].Caption = "Entrada";
                this.tdbgKardex.Columns["Entrada"].NumberFormat = "FormatText Event";
                this.tdbgKardex.Splits[0].DisplayColumns["Entrada"].Style.Locked = true;
                this.tdbgKardex.Splits[0].DisplayColumns["Entrada"].Visible = true;
                this.tdbgKardex.Splits[0].DisplayColumns["Entrada"].Width = Entrada;
                this.tdbgKardex.Splits[0].DisplayColumns["Entrada"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
                this.tdbgKardex.Splits[0].DisplayColumns["Entrada"].Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far;

                this.tdbgKardex.Columns["Documento"].Caption = "Documento";
                this.tdbgKardex.Splits[0].DisplayColumns["Documento"].Style.Locked = true;
                this.tdbgKardex.Splits[0].DisplayColumns["Documento"].Visible = true;
                this.tdbgKardex.Splits[0].DisplayColumns["Documento"].Width = Documento;
                this.tdbgKardex.Splits[0].DisplayColumns["Documento"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
               
                this.tdbgKardex.Columns["Movimiento"].Caption = "Tipo Movimiento";
                this.tdbgKardex.Splits[0].DisplayColumns["Movimiento"].Style.Locked = true;
                this.tdbgKardex.Splits[0].DisplayColumns["Movimiento"].Visible = _Movimiento;
                this.tdbgKardex.Splits[0].DisplayColumns["Movimiento"].Width = Movimiento;
                this.tdbgKardex.Splits[0].DisplayColumns["Movimiento"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
               
                this.tdbgKardex.Columns["AlmacenOrigen"].Caption = "Almacen Interno";
                this.tdbgKardex.Splits[0].DisplayColumns["AlmacenOrigen"].Style.Locked = true;
                this.tdbgKardex.Splits[0].DisplayColumns["AlmacenOrigen"].Visible = true;
                this.tdbgKardex.Splits[0].DisplayColumns["AlmacenOrigen"].Width = AlmacenOrigen;
                this.tdbgKardex.Splits[0].DisplayColumns["AlmacenOrigen"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
               
                this.tdbgKardex.Columns["AlmacenDestino"].Caption = "Almacen Externo";
                this.tdbgKardex.Splits[0].DisplayColumns["AlmacenDestino"].Style.Locked = true;
                this.tdbgKardex.Splits[0].DisplayColumns["AlmacenDestino"].Visible = true;
                this.tdbgKardex.Splits[0].DisplayColumns["AlmacenDestino"].Width = AlmacenDestino;
                this.tdbgKardex.Splits[0].DisplayColumns["AlmacenDestino"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
               
                this.tdbgKardex.Columns["SedeDestino"].Caption = "Sede Destino";
                this.tdbgKardex.Splits[0].DisplayColumns["SedeDestino"].Style.Locked = true;
                this.tdbgKardex.Splits[0].DisplayColumns["SedeDestino"].Visible = true;
                this.tdbgKardex.Splits[0].DisplayColumns["SedeDestino"].Width = SedeDestino;
                this.tdbgKardex.Splits[0].DisplayColumns["SedeDestino"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;
            }
            catch (Exception ex)
            {

                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        #endregion

        private void tdbgKardex_FormatText(object sender, FormatTextEventArgs e)
        {
            switch (e.Column.DataField.ToString())
            {
                case "Entrada":
                    if (e.Value.ToString().Trim() != "")
                        e.Value = string.Format("{0:0.00}", Convert.ToDecimal(e.Value));
                    break;
                case "Salida":
                    if (e.Value.ToString().Trim() != "")
                        e.Value = string.Format("{0:0.00}", Convert.ToDecimal(e.Value));
                    break;
            }
        }

        private void GetKardex2(int Accion)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if(RbNormal.Checked == true)
                    DtTemp = new CL_Kardex().getDTKardex_varios(ProductoId, c1cboCia.SelectedValue.ToString(), FecInicial, FecFinal, CboSede.SelectedValue.ToString(), 1);
                else if(RbAgrupadoVentas.Checked == true)
                    DtTemp = new CL_Kardex().getDTKardex_varios(ProductoId, c1cboCia.SelectedValue.ToString(), FecInicial, FecFinal, CboSede.SelectedValue.ToString(), 4);
                if(Accion == 1)
                    TdgKardexValorizado.SetDataBinding(DtTemp, "", true);
                else if (Accion == 2)
                    TdgKardexValorizadoReal.SetDataBinding(DtTemp, "", true);
                Cursor = Cursors.Default;
            }
            catch (Exception ex )
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void GetKardexVenta(Int16 Accion)
        {
            try
            {
                DataSet Ds2 = new DataSet();

                DataTable Dt = new DataTable("Logo");
                Dt.Columns.Add("Logo", typeof(byte[]));
                Dt.Columns.Add("NomEmpresa", typeof(string));
                Dt.Columns.Add("RUC", typeof(string));
                Dt.Columns.Add("DomicilioFiscal", typeof(string));
                DataRow Dr = Dt.NewRow();
                // El campo productImage primero se almacena en un buffer
                DataRow[] customerRow = UTI_Datatables.DtEmpresas.Select("EmpresaID = '" + c1cboCia.SelectedValue.ToString() + "'");
                if (customerRow[0]["Logo"] != DBNull.Value)
                {
                    Dr["Logo"] = customerRow[0]["Logo"];
                }
                else
                    Dr["Logo"] = DBNull.Value;
                Dr["NomEmpresa"] = customerRow[0]["NomEmpresa"];
                Dr["RUC"] = customerRow[0]["RUC"];
                Dr["DomicilioFiscal"] = customerRow[0]["DomicilioFiscal"];
                Dt.Rows.Add(Dr);
                Ds2.Tables.Add(Dt.Copy());
                

                string Titulo;
                string Producto;
                Cursor = Cursors.WaitCursor;
                DtTemp = new CL_Kardex().getDTKardex_varios(ProductoId, c1cboCia.SelectedValue.ToString(), FecInicial, FecFinal, CboSede.SelectedValue.ToString(), Accion);
                DtTemp.TableName = "GetKardex4";
                Halley.Presentacion.CrystalReports.CrRepKardex4 ObjCrCrRepKardex4 = new Halley.Presentacion.CrystalReports.CrRepKardex4();
                Ds2.Tables.Add(DtTemp.Copy());

                //pasar datos directo al crystal reports
                TextObject txt;
                Titulo = "SALIDAS DE INVENTARIOS POR PRODUCTOS DEL " + FecInicial.ToShortDateString() + " AL " + FecFinal.AddDays(-1).ToShortDateString();
                txt = (TextObject)ObjCrCrRepKardex4.ReportDefinition.ReportObjects["TxtTitulo"];
                txt.Text = Titulo;

                TextObject txt2;
                Producto = "PRODUCTO: " + cbProducto.Columns["Alias"].Value.ToString();
                txt2 = (TextObject)ObjCrCrRepKardex4.ReportDefinition.ReportObjects["TxtProducto"];
                txt2.Text = Producto;

                ObjCrCrRepKardex4.SetDataSource(Ds2);
                CrvKardex.ReportSource = ObjCrCrRepKardex4;
                CrvKardex.Refresh();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (dtpInicial.Value != null & dtpFinal.Value != null)
                {
                    Ds.Tables.Clear();
                    FecInicial = dtpInicial.Value;
                    FecFinal = dtpFinal.Value.AddDays(1);
                    dt = new DataTable();
                    dt = new CL_Kardex().getKardex2(DtTemp);

                    DataTable Dt = new DataTable("Logo");
                    Dt.Columns.Add("Logo", typeof(byte[]));
                    Dt.Columns.Add("NomEmpresa", typeof(string));
                    Dt.Columns.Add("RUC", typeof(string));
                    Dt.Columns.Add("DomicilioFiscal", typeof(string));
                    DataRow Dr = Dt.NewRow();
                    // El campo productImage primero se almacena en un buffer
                    DataRow[] customerRow = UTI_Datatables.DtEmpresas.Select("EmpresaID = '" + c1cboCia.SelectedValue.ToString() + "'");
                    if (customerRow[0]["Logo"] != DBNull.Value)
                    {
                        Dr["Logo"] = customerRow[0]["Logo"];
                    }
                    else
                        Dr["Logo"] = DBNull.Value;
                    Dr["NomEmpresa"] = customerRow[0]["NomEmpresa"];
                    Dr["RUC"] = customerRow[0]["RUC"];
                    Dr["DomicilioFiscal"] = customerRow[0]["DomicilioFiscal"];
                    Dt.Rows.Add(Dr);
                    Ds.Tables.Add(Dt.Copy());
                    Ds.Tables.Add(dt.Copy());

                    FrmKardexValorizado ObjFrmKardexValorizado = new FrmKardexValorizado();
                    ObjFrmKardexValorizado.Ds = Ds;
                    ObjFrmKardexValorizado.Titulo = "Periodo " + FecInicial.ToString() + " Y " + FecFinal.ToString();
                    ObjFrmKardexValorizado.Show();
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.InnerException.Message);
                MessageBox.Show(ex.Message);

            }

            Cursor = Cursors.Default;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Seguro que desea guardar los cambios?.\nEsta modificación no es reversible.","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //*********guardar los cambios realizados en el kardex
                //filtrar los modificados
                DataTable DTModificada = new DataTable("Modificados");
                DataTable DTModificadaCierre = new DataTable("Modificados");
                DataView DV = new DataView(DtTemp,"Tabla = 'K'","",DataViewRowState.ModifiedCurrent);
                DataView DV2 = new DataView(DtTemp, "Tabla = 'C'", "", DataViewRowState.ModifiedCurrent);
                //DTModificada = DtTemp.GetChanges(DataRowState.Modified);
                bool Mod1 = false, Mod2 = false;

                DTModificada = DV.ToTable();
                if(DTModificada != null && DTModificada.Rows.Count > 0)
                {
                    new CL_Kardex().UpdateXMLKardex(DTModificada);
                    Mod1 = true;
                }

                DTModificadaCierre = DV2.ToTable();
                if (DTModificadaCierre != null && DTModificadaCierre.Rows.Count > 0)
                {
                    new CL_Kardex().UpdateXMLCierreMensual(DTModificadaCierre);
                    Mod2 = true;
                    
                }

                if (Mod1 == true | Mod2 == true)
                {
                    DtTemp.AcceptChanges();
                    MessageBox.Show("Se realizo los cambios correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            Operaciones.FrmIngresarOperacion ObjFrmIngresarOperacion = new Operaciones.FrmIngresarOperacion();
            ObjFrmIngresarOperacion.EmpresaID = c1cboCia.SelectedValue.ToString();
            ObjFrmIngresarOperacion.DTMovimiento = DTMovimiento;
            ObjFrmIngresarOperacion.DTOperacion = DTOperacion;
            ObjFrmIngresarOperacion.DtTipoDocumento = DtTipoDocumento;
            ObjFrmIngresarOperacion.ShowDialog();
        }

        private void RbPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            if (RbPeriodo.Checked == true)
                PnlPeriodo.Visible = true;
            else if (RbRAngo.Checked == true)
                PnlPeriodo.Visible = false;
                
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TdgKardexValorizado.RowCount > 0 && TdgKardexValorizado.Columns["TipoOperacion"].Value.ToString() == "01")
                {
                    if (MessageBox.Show("¿Seguro que desea eliminar el registro por ventas?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        new CL_Kardex().DeleteKardex(Convert.ToInt32(TdgKardexValorizado.Columns["KardexID"].Value));
                        MessageBox.Show("Se elimino correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Eliminar
                        DataRow[] customerRow = DtTemp.Select("KardexID = '" + TdgKardexValorizado.Columns["KardexID"].Value.ToString() + "'");
                        customerRow[0].Delete();
                        DtTemp.AcceptChanges();
                    }
                }
                
                else if (TdgKardexValorizado.RowCount > 0 && MessageBox.Show("¿Seguro que desea eliminar el id: " + TdgKardexValorizado.Columns["KardexID"].Value.ToString() + "?.\nEsta modificación no es reversible.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        new CL_Kardex().DeleteKardex(Convert.ToInt32(TdgKardexValorizado.Columns["KardexID"].Value));
                        MessageBox.Show("Se elimino correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Eliminar
                        DataRow[] customerRow = DtTemp.Select("KardexID = '" + TdgKardexValorizado.Columns["KardexID"].Value.ToString() + "'");
                        customerRow[0].Delete();
                        DtTemp.AcceptChanges();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TdgKardexValorizado_AfterColEdit(object sender, ColEventArgs e)
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            //corregir la cantidad
            if (TdgKardexValorizado.RowCount > 0)
            {
                if (TdgKardexValorizado.Columns["UMContabilidad"].Value.ToString() == "07")//es unidad
                {
                    TdgKardexValorizado.Columns["Cantidad"].Value = Convert.ToDecimal(TdgKardexValorizado.Columns["FactorConversion"].Value) * Convert.ToDecimal(TdgKardexValorizado.Columns["CantidadReal"].Value);
                }
                else
                {
                    TdgKardexValorizado.Columns["Cantidad"].Value = Convert.ToDecimal(TdgKardexValorizado.Columns["FactorConversion"].Value) * Convert.ToDecimal(TdgKardexValorizado.Columns["CantidadReal"].Value) * Convert.ToDecimal(TdgKardexValorizado.Columns["Unidades"].Value);
                }
            }

        }

        private void TddMovimiento_RowChange(object sender, EventArgs e)
        {
             if (TdgKardexValorizado.RowCount > 0)
            {
                 //mostrar el movimiento
                TdgKardexValorizado.Columns["NomMovimiento"].Value = TddMovimiento.Columns["NomMovimiento"].Value;
            }
        }

    }
}

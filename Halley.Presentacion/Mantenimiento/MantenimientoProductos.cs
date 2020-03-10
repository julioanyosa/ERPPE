using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;
using Halley.Utilitario;
using Halley.CapaLogica.Empresa;
using Halley.Entidad.Empresa;

namespace Halley.Presentacion.Mantenimiento
{
    public partial class MantenimientoProductos : UITemplateAccess
    {
        CL_Producto ObjCL_Producto = new CL_Producto();
        public static DataSet Ds = new DataSet();
        private TextFunctions ObjTextFunctions = new TextFunctions();
        E_Producto ObjProducto = new E_Producto();
        DataTable DtProductos;
        DataTable DtAlmacenes;
        DataTable DtProductosBuscados = new DataTable();
        string TipoGuardar = "";
        string ProductoID = "";

        public MantenimientoProductos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            
            Ds = ObjCL_Producto.GetCaracteristicasProducto();
            CboGenerico.HoldFields();
            CboGenerico.DataSource = Ds.Tables["Generico"];
            CboGenerico.ValueMember = "GenericoID";
            CboGenerico.DisplayMember = "NomGenerico";
            CboEnvase.HoldFields();
            CboEnvase.DataSource = Ds.Tables["Envase"];
            CboEnvase.ValueMember = "EnvaseID";
            CboEnvase.DisplayMember = "NomEnvase";
            CboMarca.HoldFields();
            CboMarca.DataSource = Ds.Tables["Marca"];
            CboMarca.ValueMember = "MarcaID";
            CboMarca.DisplayMember = "NomMarca";
            CboPresentacion.HoldFields();
            CboPresentacion.DataSource = Ds.Tables["Presentacion"];
            CboPresentacion.ValueMember = "PresentacionID";
            CboPresentacion.DisplayMember = "NomPresentacion";
            CboSubfamilia.HoldFields();
            CboSubfamilia.DataSource = Ds.Tables["Subfamilia"];
            CboSubfamilia.ValueMember = "SubFamiliaID";
            CboSubfamilia.DisplayMember = "NomSubFamilia";
            CboUM.HoldFields();
            CboUM.DataSource = Ds.Tables["UnidadMedida"];
            CboUM.ValueMember = "UnidadMedidaID";
            CboUM.DisplayMember = "NomUnidadMedida";
            CboTipoExistencia.HoldFields();
            CboTipoExistencia.DataSource = Ds.Tables["Existencia"];
            CboTipoExistencia.ValueMember = "IDExistencia";
            CboTipoExistencia.DisplayMember = "Descripcion";

            //agregar empresa
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");

            //obtener todas las sedes
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            CboSede.HoldFields();
            CboSede.DataSource = Dtsedes;
            CboSede.DisplayMember = "NomSede";
            CboSede.ValueMember = "SedeID";

            //obtener lista de productos
            DtProductos = new CL_Producto().GetProductos();
            CboProducto.HoldFields();
            CboProducto.DataSource = DtProductos;
            CboProducto.DisplayMember = "Alias";
            CboProducto.ValueMember = "ProductoID";

            //traer los almacenes 
            DtAlmacenes = new DataTable();
            DtAlmacenes = new CL_Empresas().GetAlmacenHalley();
            CboAlmacenHalley.HoldFields();
            CboAlmacenHalley.DataSource = DtAlmacenes;
            CboAlmacenHalley.DisplayMember = "Descripcion";
            CboAlmacenHalley.ValueMember = "ID";

            ocultarToolStrip();

            lblEstado.Text = "";
            OcultarBotones(false, true, false, false, false, false);
            ReadOnly(true);

            PnlPrecio.Visible = false;
        }

        private void c1cboCia_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable DtAlmacenUsuario = new DataTable();
            if(c1cboCia.SelectedValue != null && CboSede.SelectedValue!=null)
            {
                //todos los almacenes
                DtAlmacenUsuario = new CL_Almacen().ObtenerAlmacen2(c1cboCia.SelectedValue.ToString(), CboSede.SelectedValue.ToString());
            }
            CboAlmacen.HoldFields();
            CboAlmacen.DataSource = DtAlmacenUsuario;
            CboAlmacen.DisplayMember = "Descripcion";
            CboAlmacen.ValueMember = "AlmacenID";
        }

        private void BtnGrabarStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (RbInsertarStock.Checked == true)
                {
                    ErrProvider.Clear();
                    if (c1cboCia.SelectedIndex != -1 & CboSede.SelectedIndex != -1 & CboProducto.SelectedIndex != -1 & TxtCantidad.Text != "" & TxtStockDisponible.Text != "" & TxtStockMaximo.Text != "" & TxtStockMinimo.Text != "" &
                        TxtCantidad.Text != "." & TxtStockDisponible.Text != "." & TxtStockMaximo.Text != "." & TxtStockMinimo.Text != ".")
                    {
                        CL_Almacen ObjCL_Almacen = new CL_Almacen();
                        ObjCL_Almacen.InsertStockAlmacen(CboAlmacen.SelectedValue.ToString(), CboProducto.SelectedValue.ToString(), Convert.ToDecimal(TxtCantidad.Text), Convert.ToDecimal(TxtStockDisponible.Text), Convert.ToDecimal(TxtStockMinimo.Text), Convert.ToDecimal(TxtStockMaximo.Text), AppSettings.UserID);
                        MessageBox.Show("se grabo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (c1cboCia.SelectedIndex == -1) { ErrProvider.SetError(c1cboCia, "Debe seleccionar una empresa"); }
                        if (CboSede.SelectedIndex == -1) { ErrProvider.SetError(CboSede, "Debe seleccionar una sede"); }
                        if (CboProducto.SelectedIndex == -1) { ErrProvider.SetError(CboProducto, "Debe seleccionar un producto"); }
                        if (TxtCantidad.Text == "" | TxtCantidad.Text == ".") { ErrProvider.SetError(TxtCantidad, "Debe ingresar una cantidad valida"); }
                        if (TxtStockDisponible.Text == "" | TxtStockDisponible.Text == ".") { ErrProvider.SetError(TxtStockDisponible, "Debe ingresar una cantidad valida"); }
                        if (TxtStockMaximo.Text == "" | TxtStockMaximo.Text == ".") { ErrProvider.SetError(TxtStockMaximo, "Debe ingresar una cantidad valida"); }
                        if (TxtStockMinimo.Text == "" | TxtStockMinimo.Text == ".") { ErrProvider.SetError(TxtStockMinimo, "Debe ingresar una cantidad valida"); }
                    }
                }
                else if (RbInsertarPrecio.Checked == true)
                {
                    ErrProvider.Clear();
                    if (c1cboCia.SelectedIndex != -1 & CboSede.SelectedIndex != -1 & CboProducto.SelectedIndex != -1 & TxtPrecio.Text != "" & TxtPrecio.Text != ".")
                    {
                        CL_Producto ObjCL_Producto = new CL_Producto();
                        ObjCL_Producto.InsertPrecioNuevo(CboAlmacen.SelectedValue.ToString(), CboProducto.SelectedValue.ToString(), AppSettings.UserID, Convert.ToDecimal(TxtPrecio.Text), AppSettings.SedeID);
                        MessageBox.Show("se grabo correctamente el precio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (c1cboCia.SelectedIndex == -1) { ErrProvider.SetError(c1cboCia, "Debe seleccionar una empresa"); }
                        if (CboSede.SelectedIndex == -1) { ErrProvider.SetError(CboSede, "Debe seleccionar una sede"); }
                        if (CboProducto.SelectedIndex == -1) { ErrProvider.SetError(CboProducto, "Debe seleccionar un producto"); }
                        if (TxtPrecio.Text == "" | TxtPrecio.Text == ".") { ErrProvider.SetError(TxtPrecio, "Debe ingresar una cantidad valida"); }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BtnUnidadMedida_Click(object sender, EventArgs e)
        {
            FrmUnidadMedida ObjFrmUnidadMedida = new FrmUnidadMedida();
            ObjFrmUnidadMedida.ShowDialog();
        }

        private void BtnEnvase_Click(object sender, EventArgs e)
        {
            FrmEnvase ObjFrmFrmEnvase = new FrmEnvase();
            ObjFrmFrmEnvase.ShowDialog();
        }

        private void BtnMarca_Click(object sender, EventArgs e)
        {
            FrmMarca ObjFrmMarca = new FrmMarca();
            ObjFrmMarca.ShowDialog();
        }

        private void BtnPresentacion_Click(object sender, EventArgs e)
        {
            FrmPresentacion ObjFrmPresentacion = new FrmPresentacion();
            ObjFrmPresentacion.ShowDialog();
        }

        private void BtnSubamilia_Click(object sender, EventArgs e)
        {
            FrmSubFamilia ObjFrmSubFamilia = new FrmSubFamilia();
            ObjFrmSubFamilia.ShowDialog();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            TipoGuardar = "Nuevo";
            OcultarBotones(false, false, true, false, true, false);
            ReadOnly(false);
            LimpiarTextos();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //desahcer
            ErrProvider.Clear();
            OcultarBotones(true, true, false, false, false, false);
            ReadOnly(false);
            LimpiarTextos();
            ReadOnly(true);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            TipoGuardar = "Actualizar";
            OcultarBotones(false, false, true, false, true, false);
            ReadOnly(false);

            //poner en readonly los controles q no deben modificarse
            CboGenerico.ReadOnly = true;
            CboEnvase.ReadOnly = true;
            CboPresentacion.ReadOnly = true;
            CboMarca.ReadOnly = true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ErrProvider.Clear();
                OcultarBotones(true, true, false, false, false, false);
                validarControles();

                if (validarControles() == false)
                {
                    OcultarBotones(false, false, true, false, true, false);
                    return;
                }
                ErrProvider.Clear();
                ObtenerDatosControles();
                //obtener el id de ventas
                string PIDVentas = "";
                if (TxtProductoIDVentas.Text == "")
                    PIDVentas = CboGenerico.SelectedValue.ToString() + CboEnvase.SelectedValue + CboPresentacion.SelectedValue + "." + CboMarca.SelectedValue;
                else
                    PIDVentas = TxtProductoIDVentas.Text;

                if (TipoGuardar == "Nuevo")
                {
                    //agregar
                    ProductoID = ObjCL_Producto.InsertProducto(ObjProducto, PIDVentas);
                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);

                    //agregar al combo
                    DataRow Dr = DtProductos.NewRow();
                    Dr["ProductoID"] = ProductoID;
                    Dr["NomProducto"] = TxtNomProducto.Text + " " + CboPresentacion.Columns["NomPresentacion"].Value.ToString();
                    Dr["Almacen"] = CboAlmacenHalley.SelectedValue.ToString();
                    Dr["Alias"] = ObjProducto.Alias;
                    Dr["SubFamiliaID"] = ObjProducto.SubFamiliaID;
                    Dr["ProductoIDVentas"] = TxtProductoIDVentas.Text;
                    Dr["UnidadMedidaID"] = ObjProducto.UnidadMedidaID;
                    DtProductos.Rows.Add(Dr);

                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Producto.UpdateProducto(ObjProducto, "A", PIDVentas);
                    
                    //actualizar tabla
                    if (DtProductosBuscados.Rows.Count > 0)
                    {
                        DataRow[] customerRow = DtProductosBuscados.Select("ProductoID = '" + ObjProducto.ProductoID + "'");
                        customerRow[0]["MarcaID"] = ObjProducto.MarcaID;
                        customerRow[0]["NomProducto"] = ObjProducto.NomProducto;
                        customerRow[0]["NomPresentacion"] = CboPresentacion.Columns["NomPresentacion"].Value.ToString();
                        customerRow[0]["Alias"] = ObjProducto.Alias;
                        customerRow[0]["Formulado"] = ObjProducto.Formulado;
                        customerRow[0]["Almacen"] = ObjProducto.Almacen;
                        customerRow[0]["UnidadMedidaID"] = ObjProducto.UnidadMedidaID;
                        customerRow[0]["EnvaseID"] = ObjProducto.EnvaseID;
                        customerRow[0]["PresentacionID"] = ObjProducto.PresentacionID;
                        customerRow[0]["SubFamiliaID"] = ObjProducto.SubFamiliaID;
                        customerRow[0]["DespachoPeso"] = ObjProducto.DespachoPeso;
                        customerRow[0]["Peso"] = ObjProducto.Peso;
                        customerRow[0]["ProductoIDVentas"] = TxtProductoIDVentas.Text;
                        customerRow[0]["Balanza"] = ObjProducto.Balanza;
                        customerRow[0]["IDExistencia"] = ObjProducto.IDExistencia;
                        customerRow[0]["CoeficienteTransformacion"] = ObjProducto.CoeficienteTransformacion;
                        if(ObjProducto.ProductoIDPrincipal == "SI")
                            customerRow[0]["ProductoIDPrincipal"] = ObjProducto.ProductoID;
                        else
                            customerRow[0]["ProductoIDPrincipal"] = "";
                    }
                    lblEstado.Text = "Se actualizó correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                TipoGuardar = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReadOnly(false);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarBotones(true, true, false, false, false, false);

                if (MessageBox.Show("¿Está seguro que desea eliminar el Producto?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Producto.UpdateProducto(ObjProducto, "E",TxtProductoIDVentas.Text);
                    lblEstado.Text = "Se eliminó el Producto:  " + TxtAlias.Text + ".";
                    lblEstado.ForeColor = Color.Red;
                }
                else
                    OcultarBotones(true, true, false, false, false, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadOnly(bool Valor)
        {
            CboGenerico.ReadOnly = Valor;
            TxtNomProducto.ReadOnly = Valor;
            TxtAlias.ReadOnly = Valor;
            TxtPeso.ReadOnly = Valor;
            TxtProductoIDVentas.ReadOnly = Valor;
            CboAlmacenHalley.ReadOnly = Valor;
            CboUM.ReadOnly = Valor;
            CboEnvase.ReadOnly = Valor;
            CboPresentacion.ReadOnly = Valor;
            CboSubfamilia.ReadOnly = Valor;
            CboMarca.ReadOnly = Valor;
            CboTipoExistencia.ReadOnly = Valor;
            txtCoeficienteTransformacion.ReadOnly = Valor;

            if (Valor == true)
            {
                ChkDespachoPeso.Enabled = false;
                ChkFormulado.Enabled = false;
                ChkPrincipal.Enabled = false;
                ChkBalanza.Enabled = false;
            }
            else
            {
                ChkDespachoPeso.Enabled = true;
                ChkFormulado.Enabled = true;
                ChkPrincipal.Enabled = true;
                ChkBalanza.Enabled = true;
            }
        }

        private bool validarControles()
        {
            if (CboGenerico.SelectedIndex == -1) { ErrProvider.SetError(CboGenerico, "Debe seleccionar el código genérico."); return false; }
            if (TxtNomProducto.Text == "") { ErrProvider.SetError(TxtNomProducto, "Debe Ingresar el nombre genérico del producto."); return false; }
            if (TxtAlias.Text == "") { ErrProvider.SetError(TxtAlias, "Debe Ingresar el alias."); return false; }
            if (TxtPeso.Text == "") { ErrProvider.SetError(TxtPeso, "Debe Ingresar el peso, si desconoce el peso coloque '0'."); return false; }
            if (CboAlmacenHalley.SelectedIndex == -1) { ErrProvider.SetError(CboAlmacenHalley, "Debe Seleccionar el almacen"); return false; }
            if (CboUM.SelectedIndex == -1) { ErrProvider.SetError(CboUM, "Debe seleccionar la UM."); return false; }
            if (CboEnvase.SelectedIndex == -1) { ErrProvider.SetError(CboEnvase, "Debe seleccionar el envase."); return false; }
            if (CboPresentacion.SelectedIndex == -1) { ErrProvider.SetError(CboPresentacion, "Debe la presentación."); return false; }
            if (CboSubfamilia.SelectedIndex == -1) { ErrProvider.SetError(CboSubfamilia, "Debe seleccionar la subfamilia."); return false; }
            if (CboMarca.SelectedIndex == -1) { ErrProvider.SetError(CboMarca, "Debe Seleccionar la marca."); return false; }
            if (CboTipoExistencia.SelectedIndex == -1) { ErrProvider.SetError(CboTipoExistencia, "Debe Seleccionar el tipo de existencia del producto."); return false; }
            if (txtCoeficienteTransformacion.Text == "") { ErrProvider.SetError(txtCoeficienteTransformacion, "Debe ingresar un número valido."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjProducto = new E_Producto();
            ObjProducto.ProductoID = CboGenerico.SelectedValue.ToString() + CboEnvase.SelectedValue + CboPresentacion.SelectedValue + "." + CboMarca.SelectedValue;
            ObjProducto.MarcaID = Convert.ToInt32(CboMarca.SelectedValue);
            ObjProducto.NomProducto = TxtNomProducto.Text;
            ObjProducto.Alias = TxtAlias.Text;
            ObjProducto.Formulado = ChkFormulado.Checked;
            ObjProducto.Almacen = CboAlmacenHalley.SelectedValue.ToString(); ;
            ObjProducto.UnidadMedidaID = CboUM.SelectedValue.ToString();
            ObjProducto.EnvaseID = CboEnvase.SelectedValue.ToString();
            ObjProducto.PresentacionID = CboPresentacion.SelectedValue.ToString();
            ObjProducto.SubFamiliaID = CboSubfamilia.SelectedValue.ToString();
            ObjProducto.DespachoPeso = ChkDespachoPeso.Checked;
            ObjProducto.Peso = Convert.ToDecimal(TxtPeso.Text);
            //este es un valor temporal, no se quedara con ese valor
            if(ChkPrincipal.Checked == true)
                ObjProducto.ProductoIDPrincipal = "SI";
            else
                ObjProducto.ProductoIDPrincipal = "NO";
            ObjProducto.Balanza = ChkBalanza.Checked;
            ObjProducto.IDExistencia = Convert.ToInt16(CboTipoExistencia.SelectedValue);
            ObjProducto.UsuarioID = AppSettings.UserID;
            ObjProducto.CoeficienteTransformacion = Convert.ToDecimal(txtCoeficienteTransformacion.Text);
        }

        private void LimpiarTextos()
        {
            CboGenerico.SelectedIndex = -1;
            TxtNomProducto.Text = "";
            TxtAlias.Text = "";
            TxtPeso.Text = "";
            TxtProductoIDVentas.Text = "";
            CboAlmacenHalley.SelectedIndex = -1;
            CboUM.Text = "";
            CboEnvase.SelectedIndex = -1;
            CboPresentacion.SelectedIndex = -1;
            CboSubfamilia.SelectedIndex = -1;
            CboMarca.SelectedIndex = -1;
            CboTipoExistencia.SelectedIndex = -1;
            txtCoeficienteTransformacion.Text = "1";
        }

        private void OcultarBotones(bool Buscar, bool Nuevo, bool Cancelar, bool Editar, bool Guardar, bool Eliminar)
        {
            BtnNuevo.Visible = Nuevo;
            BtnCancelar.Visible = Cancelar;
            BtnEditar.Visible = Editar;
            BtnGuardar.Visible = Guardar;
            BtnEliminar.Visible = Eliminar;
        }

        private void BtnGenerico_Click(object sender, EventArgs e)
        {
            FrmGenerico ObjFrmGenerico = new FrmGenerico();
            ObjFrmGenerico.ShowDialog();
        }

        private void CboGenerico_SelectedValueChanged(object sender, EventArgs e)
        {
            if(CboGenerico.SelectedIndex != -1)
                TxtNomProducto.Text = CboGenerico.Columns["NomGenerico"].Value.ToString();
            else
                TxtNomProducto.Text = "";
        }

        private void TxtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtPeso);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            lblEstado.Text = "";
            OcultarBotones(false, true, false, false, false, false);
            ReadOnly(false);
            LimpiarTextos();
            ReadOnly(true);

            DtProductosBuscados = new DataTable();
            if (RbAlias.Checked == true & TxtCadenaBuscar.Text != "")
                DtProductosBuscados = ObjCL_Producto.GetProductosXNombre(TxtCadenaBuscar.Text, "A");
            else if (RbNombre.Checked == true & TxtCadenaBuscar.Text != "")
                DtProductosBuscados = ObjCL_Producto.GetProductosXNombre(TxtCadenaBuscar.Text, "N");
            else
                ErrProvider.SetError(TxtCadenaBuscar, "Debe ingresar una cadena a buscar");
            tdgProductosBuscados.SetDataBinding(DtProductosBuscados, "", true);
        }


        private void TxtCadenaBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                BtnBuscar_Click(null, null);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 FilasAfectadas = 0;
                CL_Almacen ObjCL_Almacen = new CL_Almacen();
                FilasAfectadas = ObjCL_Almacen.UpdateStockAlmacen(CboAlmacen.SelectedValue.ToString(), CboProducto.SelectedValue.ToString(), Convert.ToDecimal(TxtCantidad.Text), Convert.ToDecimal(TxtStockDisponible.Text), Convert.ToDecimal(TxtStockMinimo.Text), Convert.ToDecimal(TxtStockMaximo.Text), AppSettings.UserID);
                if(FilasAfectadas ==1)
                    MessageBox.Show("se grabo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (FilasAfectadas == 0)//no actualizo nada
                    MessageBox.Show("No se actulizo ningun Producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RbInsertarStock_CheckedChanged(object sender, EventArgs e)
        {
            if (RbInsertarPrecio.Checked == true)
                PnlPrecio.Visible = true;
            else
                PnlPrecio.Visible = false;
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtPrecio);
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtCantidad);
        }

        private void TxtStockDisponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtStockDisponible);
        }

        private void TxtStockMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtStockMinimo);
        }

        private void TxtStockMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtStockMaximo);
        }


        private void tdgProductosBuscados_DoubleClick(object sender, EventArgs e)
        {
            ReadOnly(false);
            LimpiarTextos();
            if (tdgProductosBuscados.RowCount > 0)
            {
                CboGenerico.SelectedValue = tdgProductosBuscados.Columns["ProductoID"].Value.ToString().Substring(0, 5);
                TxtNomProducto.Text = tdgProductosBuscados.Columns["NomProducto"].Value.ToString();
                TxtAlias.Text = tdgProductosBuscados.Columns["Alias"].Value.ToString();
                TxtPeso.Text = tdgProductosBuscados.Columns["Peso"].Value.ToString();
                CboAlmacenHalley.SelectedValue = tdgProductosBuscados.Columns["Almacen"].Value.ToString();
                CboUM.SelectedValue = tdgProductosBuscados.Columns["UnidadMedidaID"].Value;
                CboEnvase.SelectedValue = tdgProductosBuscados.Columns["EnvaseID"].Value;
                CboPresentacion.SelectedValue = tdgProductosBuscados.Columns["PresentacionID"].Value;
                CboSubfamilia.SelectedValue = tdgProductosBuscados.Columns["SubFamiliaID"].Value;
                CboMarca.SelectedValue = tdgProductosBuscados.Columns["MarcaID"].Value;
                CboTipoExistencia.SelectedValue = tdgProductosBuscados.Columns["IDExistencia"].Value;
                ChkDespachoPeso.Checked = Convert.ToBoolean(tdgProductosBuscados.Columns["DespachoPeso"].Value);
                ChkFormulado.Checked = Convert.ToBoolean(tdgProductosBuscados.Columns["Formulado"].Value);
                TxtProductoIDVentas.Text = tdgProductosBuscados.Columns["ProductoIDVentas"].Value.ToString();
                ChkBalanza.Checked = Convert.ToBoolean(tdgProductosBuscados.Columns["Balanza"].Value);
                if (tdgProductosBuscados.Columns["ProductoID"].Value.ToString() == tdgProductosBuscados.Columns["ProductoIDPrincipal"].Value.ToString())
                    ChkPrincipal.Checked = true;
                else
                    ChkPrincipal.Checked = false;

                txtCoeficienteTransformacion.Text = tdgProductosBuscados.Columns["CoeficienteTransformacion"].Value.ToString();
                OcultarBotones(true, true, false, true, false, true);
            }
            ReadOnly(true);

        }

        private void txtCoeficienteTransformacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, txtCoeficienteTransformacion);
        }

    }
}

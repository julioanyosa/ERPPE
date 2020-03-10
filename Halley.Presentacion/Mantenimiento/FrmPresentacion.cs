using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Entidad.Empresa;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;
using Halley.Utilitario;

namespace Halley.Presentacion.Mantenimiento
{
    public partial class FrmPresentacion : Form
    {

        string TipoGuardar = "";
        string PresentacionID = "";
        E_Presentacion ObjPresentacion = new E_Presentacion();
        CL_Producto ObjCL_Producto = new CL_Producto();
        private TextFunctions ObjTextFunctions = new TextFunctions();

        public FrmPresentacion()
        {
            InitializeComponent();
        }

        private void FrmUnidadMedidacs_Load(object sender, EventArgs e)
        {
            TdgPresentacion.SetDataBinding(MantenimientoProductos.Ds.Tables["Presentacion"], "", true);
            CboUM.DataSource = MantenimientoProductos.Ds.Tables["UnidadMedida"];
            CboUM.ValueMember = "UnidadMedidaID";
            CboUM.DisplayMember = "NomUnidadMedida";
            lblEstado.Text = "";
            OcultarBotones(false, true, false, false, false, false);
            TxtPresentacionID.CharacterCasing = CharacterCasing.Upper;
            TxtNomPresentacion.CharacterCasing = CharacterCasing.Upper;
            ReadOnly(true);
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
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarBotones(true, true, false, false, false, false);
                validarControles();

                if (validarControles() == false)
                {
                    OcultarBotones(false, false, true, false, true, false);
                    return;
                }
                ErrProvider.Clear();
                ObtenerDatosControles();
                if (TipoGuardar == "Nuevo")
                {
                    //agregar
                    PresentacionID = ObjCL_Producto.InsertPresentacion(ObjPresentacion);
                    DataRow Dr = MantenimientoProductos.Ds.Tables["Presentacion"].NewRow();
                    Dr["PresentacionID"] = PresentacionID;
                    Dr["NomPresentacion"] = ObjPresentacion.NomPresentacion;
                    Dr["Unidades"] = ObjPresentacion.Unidades;
                    Dr["UnidadMedidaID"] = ObjPresentacion.UnidadMedidaID;
                    MantenimientoProductos.Ds.Tables["Presentacion"].Rows.Add(Dr);

                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Producto.UpdatePresentacion(ObjPresentacion, "A");

                    //actualizar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["Presentacion"].Select("PresentacionID = '" + ObjPresentacion.PresentacionID + "'");
                    customerRow[0]["NomPresentacion"] = ObjPresentacion.NomPresentacion;
                    customerRow[0]["Unidades"] = ObjPresentacion.Unidades;
                    customerRow[0]["UnidadMedidaID"] = ObjPresentacion.UnidadMedidaID;

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

                if (MessageBox.Show("¿Está seguro que desea eliminar la presentación?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Producto.UpdatePresentacion(ObjPresentacion, "E");
                    
                    //Eliminar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["Presentacion"].Select("PresentacionID = '" + ObjPresentacion.PresentacionID + "'");
                    customerRow[0].Delete();

                    lblEstado.Text = "Se eliminó la presentación:  " + TxtNomPresentacion.Text + ".";
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
            TxtPresentacionID.ReadOnly = Valor;
            TxtNomPresentacion.ReadOnly = Valor;
            TxtUnidades.ReadOnly = Valor;
            CboUM.ReadOnly = Valor;
        }

        private bool validarControles()
        {
            if (TxtNomPresentacion.Text == "") { ErrProvider.SetError(TxtNomPresentacion, "Debe Ingresar la descripcion de la UM."); return false; }
            if (TxtUnidades.Text == "") { ErrProvider.SetError(TxtUnidades, "Debe Ingresar el peso."); return false; }
            if (CboUM.SelectedIndex == -1) { ErrProvider.SetError(CboUM, "Debe seleccionar la UM."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjPresentacion = new E_Presentacion();
            ObjPresentacion.PresentacionID = TxtPresentacionID.Text;
            ObjPresentacion.NomPresentacion = TxtNomPresentacion.Text;
            ObjPresentacion.Unidades = Convert.ToDecimal(TxtUnidades.Text);
            ObjPresentacion.UnidadMedidaID = CboUM.SelectedValue.ToString();
            ObjPresentacion.UsuarioID = AppSettings.UserID;
        }

        private void LimpiarTextos()
        {
            TxtPresentacionID.Text = "";
            TxtNomPresentacion.Text = "";
            TxtUnidades.Text = "";
            CboUM.SelectedIndex = -1;
        }

        private void OcultarBotones(bool Buscar, bool Nuevo, bool Cancelar, bool Editar, bool Guardar, bool Eliminar)
        {
            BtnNuevo.Visible = Nuevo;
            BtnCancelar.Visible = Cancelar;
            BtnEditar.Visible = Editar;
            BtnGuardar.Visible = Guardar;
            BtnEliminar.Visible = Eliminar;
        }

        private void TdgUnidadMedida_DoubleClick(object sender, EventArgs e)
        {
            ReadOnly(false);
            TxtPresentacionID.Text = TdgPresentacion.Columns["PresentacionID"].Value.ToString();
            TxtNomPresentacion.Text = TdgPresentacion.Columns["NomPresentacion"].Value.ToString();
            TxtUnidades.Text = TdgPresentacion.Columns["Unidades"].Value.ToString();
            CboUM.SelectedValue = TdgPresentacion.Columns["UnidadMedidaID"].Value.ToString();
            ReadOnly(true);
            OcultarBotones(true, true, false, true, false, true);
        }

        private void TxtUnidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtUnidades);
        }

        private void BtnUnidadMedida_Click(object sender, EventArgs e)
        {
            FrmUnidadMedida ObjFrmUnidadMedida = new FrmUnidadMedida();
            ObjFrmUnidadMedida.ShowDialog();
        }
    }
}

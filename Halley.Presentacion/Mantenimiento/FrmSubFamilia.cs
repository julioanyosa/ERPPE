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

namespace Halley.Presentacion.Mantenimiento
{
    public partial class FrmSubFamilia : Form
    {

        string TipoGuardar = "";
        string SubFamiliaID = "";
        E_Subfamilia ObjSubFamilia = new E_Subfamilia();
        CL_Producto ObjCL_Producto = new CL_Producto();

        public FrmSubFamilia()
        {
            InitializeComponent();
        }

        private void FrmUnidadMedidacs_Load(object sender, EventArgs e)
        {
            TdgSubfamilia.SetDataBinding(MantenimientoProductos.Ds.Tables["SubFamilia"], "", true);
            CboFamilia.DataSource = MantenimientoProductos.Ds.Tables["Familia"];
            CboFamilia.ValueMember = "IDFamilia";
            CboFamilia.DisplayMember = "NomFamilia";
            lblEstado.Text = "";
            OcultarBotones(false, true, false, false, false, false);
            TxtSubFamiliaID.CharacterCasing = CharacterCasing.Upper;
            //TxtNomSubFamilia.CharacterCasing = CharacterCasing.Upper;
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
                    SubFamiliaID = ObjCL_Producto.InsertSubFamilia(ObjSubFamilia);
                    DataRow Dr = MantenimientoProductos.Ds.Tables["SubFamilia"].NewRow();
                    Dr["SubFamiliaID"] = SubFamiliaID;
                    Dr["NomSubFamilia"] = ObjSubFamilia.NomSubFamilia;
                    Dr["IDFamilia"] = ObjSubFamilia.IDFamilia;
                    MantenimientoProductos.Ds.Tables["SubFamilia"].Rows.Add(Dr);

                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Producto.UpdateSubFamilia(ObjSubFamilia, "A");

                    //actualizar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["SubFamilia"].Select("SubFamiliaID = '" + ObjSubFamilia.SubFamiliaID + "'");
                    customerRow[0]["NomSubFamilia"] = ObjSubFamilia.NomSubFamilia;
                    customerRow[0]["IDFamilia"] = ObjSubFamilia.IDFamilia;

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

                if (MessageBox.Show("¿Está seguro que desea eliminar la Subfamilia?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Producto.UpdateSubFamilia(ObjSubFamilia, "E");
                    
                    //Eliminar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["SubFamilia"].Select("SubFamiliaID = '" + ObjSubFamilia.SubFamiliaID + "'");
                    customerRow[0].Delete();

                    lblEstado.Text = "Se eliminó la Subfamilia:  " + TxtNomSubFamilia.Text + ".";
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
            TxtSubFamiliaID.ReadOnly = Valor;
            TxtNomSubFamilia.ReadOnly = Valor;
            CboFamilia.ReadOnly = Valor;
        }

        private bool validarControles()
        {
            if (CboFamilia.SelectedIndex == -1) { ErrProvider.SetError(CboFamilia, "Debe Seleccionar la Familia"); return false; }
            if (TxtNomSubFamilia.Text == "") { ErrProvider.SetError(TxtNomSubFamilia, "Debe Ingresar la descripcion de la UM."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjSubFamilia = new E_Subfamilia();
            ObjSubFamilia.SubFamiliaID = TxtSubFamiliaID.Text;
            ObjSubFamilia.NomSubFamilia = TxtNomSubFamilia.Text;
            if(CboFamilia.SelectedIndex != -1)
                ObjSubFamilia.IDFamilia = CboFamilia.SelectedValue.ToString();
            ObjSubFamilia.UsuarioID = AppSettings.UserID;
        }

        private void LimpiarTextos()
        {
            TxtSubFamiliaID.Text = "";
            TxtNomSubFamilia.Text = "";
            CboFamilia.SelectedIndex = -1;
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
            TxtSubFamiliaID.Text = TdgSubfamilia.Columns["SubFamiliaID"].Value.ToString();
            TxtNomSubFamilia.Text = TdgSubfamilia.Columns["NomSubFamilia"].Value.ToString();
            CboFamilia.SelectedValue = TdgSubfamilia.Columns["IDFamilia"].Value.ToString();
            ReadOnly(true);
            OcultarBotones(true, true, false, true, false, true);
        }

        private void BtnUnidadMedida_Click(object sender, EventArgs e)
        {
            FrmFamilia ObjFrmFamilia = new FrmFamilia();
            ObjFrmFamilia.ShowDialog();
        }
    }
}

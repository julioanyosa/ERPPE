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
    public partial class FrmGenerico : Form
    {

        string TipoGuardar = "";
        string GenericoID = "";
        E_Generico ObjGenerico = new E_Generico();
        CL_Producto ObjCL_Producto = new CL_Producto();

        public FrmGenerico()
        {
            InitializeComponent();
        }

        private void FrmUnidadMedidacs_Load(object sender, EventArgs e)
        {
            TdgEnvase.SetDataBinding(MantenimientoProductos.Ds.Tables["Generico"], "", true);
            lblEstado.Text = "";
            OcultarBotones(false, true, false, false, false, false);
            TxtGenericoID.CharacterCasing = CharacterCasing.Upper;
            //TxtNomEnvase.CharacterCasing = CharacterCasing.Upper;
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
                    GenericoID = ObjCL_Producto.InsertGenerico(ObjGenerico);
                    DataRow Dr = MantenimientoProductos.Ds.Tables["Generico"].NewRow();
                    Dr["GenericoID"] = GenericoID;
                    Dr["NomGenerico"] = ObjGenerico.NomGenerico;
                    MantenimientoProductos.Ds.Tables["Generico"].Rows.Add(Dr);

                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Producto.UpdateEnvase(ObjGenerico, "A");

                    //actualizar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["Generico"].Select("GenericoID = '" + ObjGenerico.GenericoID + "'");
                    customerRow[0]["NomGenerico"] = ObjGenerico.NomGenerico;

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

                if (MessageBox.Show("¿Está seguro que desea eliminar El generico?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Producto.UpdateEnvase(ObjGenerico, "E");
                    
                    //Eliminar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["Generico"].Select("GenericoID = '" + ObjGenerico.GenericoID + "'");
                    customerRow[0].Delete();

                    lblEstado.Text = "Se eliminó el Genérico:  " + TxtNomGenerico.Text + ".";
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
            TxtGenericoID.ReadOnly = Valor;
            TxtNomGenerico.ReadOnly = Valor;
        }

        private bool validarControles()
        {
            if (TxtNomGenerico.Text == "") { ErrProvider.SetError(TxtNomGenerico, "Debe Ingresar la descripcion del genérico."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjGenerico = new E_Generico();
            ObjGenerico.GenericoID = TxtGenericoID.Text;
            ObjGenerico.NomGenerico= TxtNomGenerico.Text;
            ObjGenerico.UsuarioID = AppSettings.UserID;
        }

        private void LimpiarTextos()
        {
            TxtGenericoID.Text = "";
            TxtNomGenerico.Text = "";
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
            TxtGenericoID.Text = TdgEnvase.Columns["GenericoID"].Value.ToString();
            TxtNomGenerico.Text = TdgEnvase.Columns["NomGenerico"].Value.ToString();
            ReadOnly(true);
            OcultarBotones(true, true, false, true, false, true);
        }
    }
}

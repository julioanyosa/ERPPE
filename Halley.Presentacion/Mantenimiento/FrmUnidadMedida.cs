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
    public partial class FrmUnidadMedida : Form
    {

        string TipoGuardar = "";
        string UnidadMedidaID = "";
        E_UnidadMedida ObjUnidadMedida = new E_UnidadMedida();
        CL_Producto ObjCL_Producto = new CL_Producto();

        public FrmUnidadMedida()
        {
            InitializeComponent();
        }

        private void FrmUnidadMedidacs_Load(object sender, EventArgs e)
        {
            TdgUnidadMedida.SetDataBinding(MantenimientoProductos.Ds.Tables["UnidadMedida"], "", true);
            lblEstado.Text = "";
            OcultarBotones(false, true, false, false, false, false);
            TxtUnidadMedidaID.CharacterCasing = CharacterCasing.Upper;
            //TxtNomUnidadMedida.CharacterCasing = CharacterCasing.Upper;
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
                    UnidadMedidaID = ObjCL_Producto.InsertUnidadMedida(ObjUnidadMedida);
                    DataRow Dr = MantenimientoProductos.Ds.Tables["UnidadMedida"].NewRow();
                    Dr["UnidadMedidaID"] = UnidadMedidaID;
                    Dr["NomUnidadMedida"] = ObjUnidadMedida.NomUnidadMedida;
                    MantenimientoProductos.Ds.Tables["UnidadMedida"].Rows.Add(Dr);

                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Producto.UpdateUnidadMedida(ObjUnidadMedida, "A");

                    //actualizar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["UnidadMedida"].Select("UnidadMedidaID = '" + ObjUnidadMedida.UnidadMedidaID + "'");
                    customerRow[0]["NomUnidadMedida"] = ObjUnidadMedida.NomUnidadMedida;

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

                if (MessageBox.Show("¿Está seguro que desea eliminar la UM?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Producto.UpdateUnidadMedida(ObjUnidadMedida, "E");
                    
                    //Eliminar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["UnidadMedida"].Select("UnidadMedidaID = '" + ObjUnidadMedida.UnidadMedidaID + "'");
                    customerRow[0].Delete();

                    lblEstado.Text = "Se eliminó la UM:  " + TxtUnidadMedidaID.Text + ".";
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
            TxtUnidadMedidaID.ReadOnly = Valor;
            TxtNomUnidadMedida.ReadOnly = Valor;
        }

        private bool validarControles()
        {
            if (TxtUnidadMedidaID.Text == "") { ErrProvider.SetError(TxtUnidadMedidaID, "Debe Ingresar el ID de la UM."); return false; }
            if (TxtNomUnidadMedida.Text == "") { ErrProvider.SetError(TxtNomUnidadMedida, "Debe Ingresar la descripcion de la UM."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjUnidadMedida = new E_UnidadMedida();
            ObjUnidadMedida.UnidadMedidaID = TxtUnidadMedidaID.Text;
            ObjUnidadMedida.NomUnidadMedida = TxtNomUnidadMedida.Text;
            ObjUnidadMedida.UsuarioID = AppSettings.UserID;
        }

        private void LimpiarTextos()
        {
            TxtUnidadMedidaID.Text = "";
            TxtNomUnidadMedida.Text = "";
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
            TxtUnidadMedidaID.Text = TdgUnidadMedida.Columns["UnidadMedidaID"].Value.ToString();
            TxtNomUnidadMedida.Text = TdgUnidadMedida.Columns["NomUnidadMedida"].Value.ToString();
            ReadOnly(true);
            OcultarBotones(true, true, false, true, false, true);
        }
    }
}

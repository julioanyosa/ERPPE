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
    public partial class FrmMarca : Form
    {

        string TipoGuardar = "";
        Int32 MarcaID = 0;
        E_Marca ObjMarca = new E_Marca();
        CL_Producto ObjCL_Producto = new CL_Producto();

        public FrmMarca()
        {
            InitializeComponent();
        }

        private void FrmUnidadMedidacs_Load(object sender, EventArgs e)
        {
            TdgEnvase.SetDataBinding(MantenimientoProductos.Ds.Tables["Marca"], "", true);
            lblEstado.Text = "";
            OcultarBotones(false, true, false, false, false, false);
            TxtMarcaID.CharacterCasing = CharacterCasing.Upper;
            //TxtNomMarca.CharacterCasing = CharacterCasing.Upper;
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
                    MarcaID = ObjCL_Producto.InsertMarca(ObjMarca);
                    DataRow Dr = MantenimientoProductos.Ds.Tables["Marca"].NewRow();
                    Dr["MarcaID"] = MarcaID;
                    Dr["NomMarca"] = ObjMarca.NomMarca;
                    MantenimientoProductos.Ds.Tables["Marca"].Rows.Add(Dr);

                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Producto.UpdateMarca(ObjMarca, "A");

                    //actualizar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["Marca"].Select("MarcaID = '" + ObjMarca.MarcaID + "'");
                    customerRow[0]["NomMarca"] = ObjMarca.NomMarca;

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

                if (MessageBox.Show("¿Está seguro que desea eliminar la Marca?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Producto.UpdateMarca(ObjMarca, "E");
                    
                    //Eliminar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["Marca"].Select("MarcaID = '" + ObjMarca.MarcaID + "'");
                    customerRow[0].Delete();

                    lblEstado.Text = "Se eliminó la Marca:  " + TxtNomMarca.Text + ".";
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
            TxtMarcaID.ReadOnly = Valor;
            TxtNomMarca.ReadOnly = Valor;
        }

        private bool validarControles()
        {
            if (TxtNomMarca.Text == "") { ErrProvider.SetError(TxtNomMarca, "Debe Ingresar la descripcion de la UM."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjMarca = new E_Marca();
            if (TxtMarcaID.Text != "")
                ObjMarca.MarcaID = Convert.ToInt32(TxtMarcaID.Text);
            ObjMarca.NomMarca = TxtNomMarca.Text;
            ObjMarca.UsuarioID = AppSettings.UserID;
        }

        private void LimpiarTextos()
        {
            TxtMarcaID.Text = "";
            TxtNomMarca.Text = "";
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
            TxtMarcaID.Text = TdgEnvase.Columns["MarcaID"].Value.ToString();
            TxtNomMarca.Text = TdgEnvase.Columns["NomMarca"].Value.ToString();
            ReadOnly(true);
            OcultarBotones(true, true, false, true, false, true);
        }
    }
}

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
    public partial class FrmFamilia : Form
    {

        string TipoGuardar = "";
        string IDFamilia = "";
        E_Familia ObjFamilia = new E_Familia();
        CL_Producto ObjCL_Producto = new CL_Producto();

        public FrmFamilia()
        {
            InitializeComponent();
        }

        private void FrmUnidadMedidacs_Load(object sender, EventArgs e)
        {
            TdgFamilia.SetDataBinding(MantenimientoProductos.Ds.Tables["Familia"], "", true);
            lblEstado.Text = "";
            OcultarBotones(false, true, false, false, false, false);
            TxtIDFamilia.CharacterCasing = CharacterCasing.Upper;
            //TxtNomFamilia.CharacterCasing = CharacterCasing.Upper;
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
                    IDFamilia = ObjCL_Producto.InsertFamilia(ObjFamilia);
                    DataRow Dr = MantenimientoProductos.Ds.Tables["Familia"].NewRow();
                    Dr["IDFamilia"] = IDFamilia;
                    Dr["NomFamilia"] = ObjFamilia.NomFamilia;
                    MantenimientoProductos.Ds.Tables["Familia"].Rows.Add(Dr);

                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Producto.UpdateFamilia(ObjFamilia, "A");

                    //actualizar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["Familia"].Select("IDFamilia = '" + ObjFamilia.IDFamilia + "'");
                    customerRow[0]["NomFamilia"] = ObjFamilia.NomFamilia;
                    customerRow[0]["IDFamilia"] = ObjFamilia.IDFamilia;

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

                if (MessageBox.Show("¿Está seguro que desea eliminar la Familia?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Producto.UpdateFamilia(ObjFamilia, "E");
                    
                    //Eliminar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["Familia"].Select("IDFamilia = '" + ObjFamilia.IDFamilia + "'");
                    customerRow[0].Delete();

                    lblEstado.Text = "Se eliminó la Familia:  " + TxtNomFamilia.Text + ".";
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
            TxtIDFamilia.ReadOnly = Valor;
            TxtNomFamilia.ReadOnly = Valor;
        }

        private bool validarControles()
        {
            if (TxtNomFamilia.Text == "") { ErrProvider.SetError(TxtNomFamilia, "Debe Ingresar la descripcion de la Familia."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjFamilia = new E_Familia();
            ObjFamilia.IDFamilia = TxtIDFamilia.Text;
            ObjFamilia.NomFamilia = TxtNomFamilia.Text;
            ObjFamilia.UsuarioID = AppSettings.UserID;
        }

        private void LimpiarTextos()
        {
            TxtIDFamilia.Text = "";
            TxtNomFamilia.Text = "";
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
            TxtIDFamilia.Text = TdgFamilia.Columns["IDFamilia"].Value.ToString();
            TxtNomFamilia.Text = TdgFamilia.Columns["NomFamilia"].Value.ToString();
            ReadOnly(true);
            OcultarBotones(true, true, false, true, false, true);
        }
    }
}

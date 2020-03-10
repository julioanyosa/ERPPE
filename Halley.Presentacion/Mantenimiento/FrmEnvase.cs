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
    public partial class FrmEnvase : Form
    {

        string TipoGuardar = "";
        string EnvaseID = "";
        E_Envase ObjEnvase = new E_Envase();
        CL_Producto ObjCL_Producto = new CL_Producto();

        public FrmEnvase()
        {
            InitializeComponent();
        }

        private void FrmUnidadMedidacs_Load(object sender, EventArgs e)
        {
            TdgEnvase.SetDataBinding(MantenimientoProductos.Ds.Tables["Envase"], "", true);
            lblEstado.Text = "";
            OcultarBotones(false, true, false, false, false, false);
            TxtEnvaseID.CharacterCasing = CharacterCasing.Upper;
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
                    EnvaseID = ObjCL_Producto.InsertEnvase(ObjEnvase);
                    DataRow Dr = MantenimientoProductos.Ds.Tables["Envase"].NewRow();
                    Dr["EnvaseID"] = EnvaseID;
                    Dr["NomEnvase"] = ObjEnvase.NomEnvase;
                    MantenimientoProductos.Ds.Tables["Envase"].Rows.Add(Dr);

                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Producto.UpdateEnvase(ObjEnvase, "A");

                    //actualizar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["Envase"].Select("EnvaseID = '" + ObjEnvase.EnvaseID + "'");
                    customerRow[0]["NomEnvase"] = ObjEnvase.NomEnvase;

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

                if (MessageBox.Show("¿Está seguro que desea eliminar El envase?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Producto.UpdateEnvase(ObjEnvase, "E");
                    
                    //Eliminar
                    DataRow[] customerRow = MantenimientoProductos.Ds.Tables["Envase"].Select("EnvaseID = '" + ObjEnvase.EnvaseID + "'");
                    customerRow[0].Delete();

                    lblEstado.Text = "Se eliminó el envase:  " + TxtNomEnvase.Text + ".";
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
            TxtEnvaseID.ReadOnly = Valor;
            TxtNomEnvase.ReadOnly = Valor;
        }

        private bool validarControles()
        {
            if (TxtNomEnvase.Text == "") { ErrProvider.SetError(TxtNomEnvase, "Debe Ingresar la descripcion de la UM."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjEnvase = new E_Envase();
            ObjEnvase.EnvaseID = TxtEnvaseID.Text;
            ObjEnvase.NomEnvase= TxtNomEnvase.Text;
            ObjEnvase.UsuarioID = AppSettings.UserID;
        }

        private void LimpiarTextos()
        {
            TxtEnvaseID.Text = "";
            TxtNomEnvase.Text = "";
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
            TxtEnvaseID.Text = TdgEnvase.Columns["EnvaseID"].Value.ToString();
            TxtNomEnvase.Text = TdgEnvase.Columns["NomEnvase"].Value.ToString();
            ReadOnly(true);
            OcultarBotones(true, true, false, true, false, true);
        }
    }
}

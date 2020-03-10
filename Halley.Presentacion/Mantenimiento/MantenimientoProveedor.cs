using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.CapaLogica.Compras;
using Halley.Entidad.Compras;
using Halley.Configuracion;

namespace Halley.Presentacion.Mantenimiento
{
    public partial class MantenimientoProveedor : UITemplateAccess
    {
        #region Variables
        string TipoGuardar = "";
        E_Proveedor ObjProveedor = new E_Proveedor();
        CL_Proveedor ObjCL_Proveedor = new CL_Proveedor();
        DataTable DtProveedor;
        private DataTable DtTipoDocumento = new DataTable();
        private TextFunctions ObjTextFunctions = new TextFunctions();
        #endregion

        public MantenimientoProveedor()
        {
            InitializeComponent();
        }

        private void MantenimientoVehiculos_Load(object sender, EventArgs e)
        {
            OcultarBotones(true, true, false, true, false, true);
            DtTipoDocumento = ObjCL_Proveedor.GetTipoDocumento();
            CboTipoDocumento.HoldFields();
            CboTipoDocumento.DataSource = DtTipoDocumento;
            CboTipoDocumento.DisplayMember = "TipoDocumento";
            CboTipoDocumento.ValueMember = "IDTipoDocumento";
            lblEstado.Text = "";
            ocultarToolStrip();
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
                    ObjCL_Proveedor.InsertProveedor(ObjProveedor);
                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Proveedor.UpdateProveedor(ObjProveedor, "A");
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

                if (MessageBox.Show("¿Está seguro que desea eliminar el Proveedor?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Proveedor.UpdateProveedor(ObjProveedor, "E");
                    lblEstado.Text = "Se eliminó el Proveedor con número de documento:  " + TxtNroDocumento.Text + ".";
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

        private void OcultarBotones(bool Buscar, bool Nuevo, bool Cancelar, bool Editar, bool Guardar, bool Eliminar)
        {
            btnBuscar.Visible = Buscar;
            BtnNuevo.Visible = Nuevo;
            BtnCancelar.Visible = Cancelar;
            BtnEditar.Visible = Editar;
            BtnGuardar.Visible = Guardar;
            BtnEliminar.Visible = Eliminar;
        }

        private void ReadOnly(bool Valor)
        {
            TxtIDProveedor.ReadOnly = Valor;
            TxtRazonSocial.ReadOnly = Valor;
            CboTipoDocumento.ReadOnly = Valor;
            TxtTelefono.ReadOnly = Valor;
            TxtNroDocumento.ReadOnly = Valor;
            TxtPais.ReadOnly = Valor;
            TxtRegion.ReadOnly = Valor;
            TxtDireccion.ReadOnly = Valor;
            TxtContacto.ReadOnly = Valor;
            TxtCargoContacto.ReadOnly = Valor;
            TxtEmail.ReadOnly = Valor;
        }


        private void Buscar()
        {
            ReadOnly(false);
            lblEstado.Text = "";
            ErrProvider.Clear();

            DtProveedor = new DataTable();
            ObtenerDatosControles();
            DtProveedor = ObjCL_Proveedor.GetProveedorNroDocumento(TxtNroDocumento2.Text);

            if (DtProveedor.Rows.Count > 0)
            {
                CboTipoDocumento.SelectedValue = DtProveedor.Rows[0]["IDTipoDocumento"];
                TxtIDProveedor.Value = DtProveedor.Rows[0]["IDProveedor"];
                TxtRazonSocial.Value = DtProveedor.Rows[0]["RazonSocial"];
                TxtTelefono.Value = DtProveedor.Rows[0]["Telefono"];
                TxtNroDocumento.Value = DtProveedor.Rows[0]["NroDocumento"];
                TxtPais.Value = DtProveedor.Rows[0]["Pais"];
                TxtRegion.Value = DtProveedor.Rows[0]["Region"];
                TxtDireccion.Value = DtProveedor.Rows[0]["Direccion"];
                TxtContacto.Value = DtProveedor.Rows[0]["Contacto"];
                TxtCargoContacto.Value = DtProveedor.Rows[0]["CargoContacto"];
                TxtEmail.Value = DtProveedor.Rows[0]["Email"];
                OcultarBotones(true, true, false, true, false, true);
            }
            else
            {
                LimpiarTextos();
                ReadOnly(true);
                lblEstado.Text = "No existe Proveedor con númerop de documento: " + TxtNroDocumento2.Text;
                lblEstado.ForeColor = Color.Red;
                OcultarBotones(true, true, false, false, false, false);
            }

            ReadOnly(true);
        }

        private bool validarControles()
        {
            if (CboTipoDocumento.SelectedValue == null) { ErrProvider.SetError(CboTipoDocumento, "Debe seleccionar una tipo de documento."); return false; }
            if (TxtRazonSocial.Text == "") { ErrProvider.SetError(TxtRazonSocial, "Debe Ingresar Nombre de persona o razon social."); return false; }
            if (TxtNroDocumento.Text == "") { ErrProvider.SetError(TxtNroDocumento, "Debe Ingresar numero de documento."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjProveedor = new E_Proveedor();
            if(TxtIDProveedor.Text != "")
            ObjProveedor.IDProveedor = Convert.ToInt32(TxtIDProveedor.Text);
            if (CboTipoDocumento.SelectedIndex != -1)
                ObjProveedor.IDTipoDocumento = Convert.ToInt32(CboTipoDocumento.SelectedValue);
            ObjProveedor.RazonSocial = TxtRazonSocial.Text;
            ObjProveedor.Telefono = TxtTelefono.Text;
            ObjProveedor.NroDocumento = TxtNroDocumento.Text;
            ObjProveedor.Pais = TxtPais.Text;
            ObjProveedor.Region = TxtRegion.Text;
            ObjProveedor.Direccion = TxtDireccion.Text;
            ObjProveedor.Contacto = TxtContacto.Text;
            ObjProveedor.CargoContacto = TxtCargoContacto.Text;
            ObjProveedor.Email = TxtEmail.Text;
            ObjProveedor.UsuarioID = AppSettings.UserID;
        }

        private void LimpiarTextos()
        {
            TxtIDProveedor.Text = "";
            CboTipoDocumento.SelectedIndex = -1;
            TxtRazonSocial.Text = "";
            TxtTelefono.Text = "";
            TxtNroDocumento.Text = "";
            TxtPais.Text = "";
            TxtRegion.Text = "";
            TxtDireccion.Text = "";
            TxtContacto.Text = "";
            TxtCargoContacto.Text = "";
            TxtEmail.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void TxtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtNroDocumento);
        }

    }
}

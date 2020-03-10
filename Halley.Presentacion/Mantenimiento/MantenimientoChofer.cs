using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.CapaLogica.Empresa;
using Halley.Entidad.Empresa;
using Halley.Configuracion;

namespace Halley.Presentacion.Mantenimiento
{
    public partial class MantenimientoChofer : UITemplateAccess
    {
        #region Variables
        string TipoGuardar = "";
        E_Chofer ObjChofer = new E_Chofer();
        CL_Choferes ObjCL_Choferes = new CL_Choferes();
        DataTable DtChofer;
        private TextFunctions ObjTextFunctions = new TextFunctions();
        #endregion

        public MantenimientoChofer()
        {
            InitializeComponent();
        }

        private void MantenimientoVehiculos_Load(object sender, EventArgs e)
        {
            OcultarBotones(true, true, false, true, false, true);
            lblEstado.Text = "";
            TxtNomChofer.CharacterCasing = CharacterCasing.Upper;
            TxtApeChofer.CharacterCasing = CharacterCasing.Upper;
            TxtDNI.CharacterCasing = CharacterCasing.Upper;
            TxtLicencia.CharacterCasing = CharacterCasing.Upper;
            c1Combo.FillC1Combo(this.CboEmpresa, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            CboEmpresa.SelectedIndex = -1;
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
                    ObjCL_Choferes.InsertChofer(ObjChofer);
                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Choferes.UpdateChofer(ObjChofer, "A");
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

                if (MessageBox.Show("¿Está seguro que desea eliminar el chofer?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Choferes.UpdateChofer(ObjChofer, "E");
                    lblEstado.Text = "Se eliminó el Chofer con Id Nro:  " + TxtChoferID.Text + ".";
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
            CboEmpresa.ReadOnly = Valor;
            TxtNomChofer.ReadOnly = Valor;
            TxtApeChofer.ReadOnly = Valor;
            TxtDNI.ReadOnly = Valor;
            TxtLicencia.ReadOnly = Valor;
        }


        private void Buscar()
        {
            ReadOnly(false);
            lblEstado.Text = "";
            ErrProvider.Clear();

            DtChofer = new DataTable();
            ObtenerDatosControles();
            DtChofer = ObjCL_Choferes.GetChoferesID(TxtDNI2.Text);

            if (DtChofer.Rows.Count > 0)
            {
                CboEmpresa.SelectedValue = DtChofer.Rows[0]["EmpresaID"];
                TxtChoferID.Value = DtChofer.Rows[0]["ChoferID"];
                TxtNomChofer.Value = DtChofer.Rows[0]["NomChofer"];
                TxtApeChofer.Value = DtChofer.Rows[0]["ApeChofer"];
                TxtDNI.Value = DtChofer.Rows[0]["DNI"];
                TxtLicencia.Value = DtChofer.Rows[0]["Licencia"];
                OcultarBotones(true, true, false, true, false, true);
            }
            else
            {
                LimpiarTextos();
                ReadOnly(true);
                lblEstado.Text = "No existe Chofer con el DNI: " + TxtChoferID.Text;
                lblEstado.ForeColor = Color.Red;
                OcultarBotones(true, true, false, false, false, false);
            }

            ReadOnly(true);
        }

        private bool validarControles()
        {
            if (CboEmpresa.SelectedValue == null) { ErrProvider.SetError(CboEmpresa, "Debe seleccionar una empresa."); return false; }
            if (TxtApeChofer.Text == "") { ErrProvider.SetError(TxtApeChofer, "Debe Ingresar una marca."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjChofer = new E_Chofer();
            if (TxtChoferID.Text != "")
                ObjChofer.ChoferID = Convert.ToInt32(TxtChoferID.Text);
            ObjChofer.NomChofer = TxtNomChofer.Text;
            ObjChofer.ApeChofer = TxtApeChofer.Text;
            ObjChofer.DNI = TxtDNI.Text;
            ObjChofer.Licencia = TxtLicencia.Text;
            if(CboEmpresa.SelectedIndex != -1)
                ObjChofer.EmpresaID = CboEmpresa.SelectedValue.ToString();
            ObjChofer.UsuarioID = AppSettings.UserID;
        }

        private void LimpiarTextos()
        {
            TxtChoferID.Text = "";
            TxtNomChofer.Text = "";
            TxtApeChofer.Text = "";
            TxtDNI.Text = "";
            TxtLicencia.Text = "";
            CboEmpresa.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void TxtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtDNI);
        }
    }
}

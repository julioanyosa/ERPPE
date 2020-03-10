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
    public partial class MantenimientoVehiculos : UITemplateAccess
    {
        #region Variables
        string TipoGuardar = "";
        E_Vehiculo ObjVehiculo = new E_Vehiculo();
        CL_Vehiculo ObjCL_Vehiculo = new CL_Vehiculo();
        DataTable Dtvehiculo;
        private TextFunctions ObjTextFunctions = new TextFunctions();
        #endregion

        public MantenimientoVehiculos()
        {
            InitializeComponent();
        }

        private void MantenimientoVehiculos_Load(object sender, EventArgs e)
        {
            OcultarBotones(true, true, false, true, false, true);
            lblEstado.Text = "";
            TxtPlaca.CharacterCasing = CharacterCasing.Upper;
            TxtPlaca2.CharacterCasing = CharacterCasing.Upper;
            TxtMarca.CharacterCasing = CharacterCasing.Upper;
            TxtConfiguracionVehicular.CharacterCasing = CharacterCasing.Upper;
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

                ObtenerDatosControles();
                ErrProvider.Clear();
                ObtenerDatosControles();
                if (TipoGuardar == "Nuevo")
                {
                    ObjCL_Vehiculo.InsertVehiculos(ObjVehiculo);
                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Vehiculo.UpdateVehiculos(ObjVehiculo, "A");
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

                if (MessageBox.Show("¿Está seguro que desea eliminar el vehículo?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Vehiculo.UpdateVehiculos(ObjVehiculo, "E");
                    lblEstado.Text = "Se eliminó el vehiculo con placa Nro: " + TxtPlaca.Text + ".";
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
            TxtPlaca.ReadOnly = Valor;
            TxtMarca.ReadOnly = Valor;
            TxtCertificadoInscripcion.ReadOnly = Valor;
            TxtConfiguracionVehicular.ReadOnly = Valor;
            TxtTara.ReadOnly = Valor;
            TxtPesoBruto.ReadOnly = Valor;
        }


        private void Buscar()
        {
            ReadOnly(false);
            lblEstado.Text = "";
            ErrProvider.Clear();

            Dtvehiculo = new DataTable();
            ObtenerDatosControles();
            Dtvehiculo = ObjCL_Vehiculo.GetVehiculosPlaca(TxtPlaca2.Text);

            if (Dtvehiculo.Rows.Count > 0)
            {
                CboEmpresa.SelectedValue = Dtvehiculo.Rows[0]["EmpresaID"];
                TxtPlaca.Value = Dtvehiculo.Rows[0]["Placa"];
                TxtMarca.Value = Dtvehiculo.Rows[0]["Marca"];
                TxtCertificadoInscripcion.Value = Dtvehiculo.Rows[0]["CertificadoInscripcion"];
                TxtConfiguracionVehicular.Value = Dtvehiculo.Rows[0]["ConfiguracionVehicular"];
                TxtTara.Value = Dtvehiculo.Rows[0]["Tara"];
                TxtPesoBruto.Value = Dtvehiculo.Rows[0]["PesoBruto"];
                OcultarBotones(true, true, false, true, false, true);
            }
            else
            {
                LimpiarTextos();
                ReadOnly(true);
                lblEstado.Text = "No existe vehículo con la placa: " + TxtPlaca2.Text;
                lblEstado.ForeColor = Color.Red;
                OcultarBotones(true, true, false, false, false, false);
            }

            ReadOnly(true);
        }

        private bool validarControles()
        {
            if (CboEmpresa.SelectedValue == null) { ErrProvider.SetError(CboEmpresa, "Debe seleccionar una empresa."); return false; }
            if (TxtMarca.Text == "") { ErrProvider.SetError(TxtMarca, "Debe Ingresar una marca."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjVehiculo = new E_Vehiculo();
            ObjVehiculo.Placa = TxtPlaca.Text;
            ObjVehiculo.Marca = TxtMarca.Text;
            if(TxtCertificadoInscripcion.Text != "")
                ObjVehiculo.CertificadoInscripcion = Convert.ToInt32(TxtCertificadoInscripcion.Text);
            ObjVehiculo.ConfiguracionVehicular = TxtConfiguracionVehicular.Text;
            if (TxtTara.Text != "")
                ObjVehiculo.Tara = Convert.ToDecimal(TxtTara.Text);
            if (TxtPesoBruto.Text != "")
                ObjVehiculo.PesoBruto = Convert.ToDecimal(TxtPesoBruto.Text);
            if(CboEmpresa.SelectedIndex != -1)
                ObjVehiculo.EmpresaID = CboEmpresa.SelectedValue.ToString();
            ObjVehiculo.UsuarioID = AppSettings.UserID;
        }

        private void LimpiarTextos()
        {
            TxtPlaca.Text = "";
            TxtMarca.Text = "";
            TxtCertificadoInscripcion.Text = "";
            TxtConfiguracionVehicular.Text = "";
            TxtTara.Text = "";
            TxtPesoBruto.Text = "";
            CboEmpresa.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void TxtCertificadoInscripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtCertificadoInscripcion);
        }

        private void TxtTara_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtTara);
        }

        private void TxtPesoBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtPesoBruto);
        }
    }
}

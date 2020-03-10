using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.Entidad.Ventas;
using Halley.Configuracion;
using Halley.Utilitario;

namespace Halley.Presentacion.Mantenimiento
{
    public partial class FrmCliente : Form
    {

        #region Variables
        string TipoGuardar = "";
        DataSet DsUbicacion = new DataSet();
        E_Cliente ObjCliente = new E_Cliente();
        CL_Cliente ObjCL_Cliente = new CL_Cliente();
        DataTable DtCliente = new DataTable();                
        private TextFunctions ObjTextFunctions = new TextFunctions();

        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public int IDCliente { get; set; }
        public string NroDocumento { get; set; }
        public int TipoCliente { get; set; }
        public int TipoDocumento { get; set; }

        #endregion


        
        

        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            OcultarBotones(true, true, false, true, false, true);
            //llenar los combos
            DsUbicacion = ObjCL_Cliente.GetUbicacion();

            c1Combo.FillC1Combo(CboDepartamento, DsUbicacion.Tables["Departamento"], "Departamento", "DepartamentoId");
            c1Combo.FillC1Combo(CboDistrito, DsUbicacion.Tables["Distrito"], "Distrito", "DistritoId");
            c1Combo.FillC1Combo(CboProvincia, DsUbicacion.Tables["Provincia"], "Provincia", "ProvinciaId");
            c1Combo.FillC1Combo(CboVia, DsUbicacion.Tables["Via"], "Via", "ViaId");
            c1Combo.FillC1Combo(CboTipoCliente, ObjCL_Cliente.GetTipoCliente(), "Cliente", "TipoClienteID");
            c1Combo.FillC1Combo(CboTipoDocumento, ObjCL_Cliente.GetTipoDocumento(), "TipoDocumento", "IDTipoDocumento");
            c1Combo.FillC1Combo(CboPais, ObjCL_Cliente.GetPais(), "Pais", "PaisId");

            //ocultar labels
            lbla.Visible = false;
            lbln.Visible = false;
            lblnd.Visible = false;
            lblrz.Visible = false;
            lbltc.Visible = false;
            lbltd.Visible = false;

            CboDepartamento.SelectedIndex = -1;
            CboDistrito.SelectedIndex = -1;
            CboProvincia.SelectedIndex = -1;
            CboTipoCliente.SelectedIndex = -1;
            CboTipoDocumento.SelectedIndex = -1;
            CboVia.SelectedIndex = -1;
            CboPais.SelectedIndex = -1;
            lblEstado.Text = "";
            ReadOnly(true);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarBotones(true, true, false, false, false, false);
                validarControles();
                TxtDireccion.Visible = true;
                LblDireccion.Visible = true;

                if (validarControles() == false)
                {
                    OcultarBotones(false, false, true, false, true, false);
                    return;
                }
                ErrProvider.Clear();
                ObtenerDatosControles();
                if (TipoGuardar == "Nuevo")
                {
                    Int32 ClienteID;
                    ClienteID = ObjCL_Cliente.InsertCliente(ObjCliente);
                    IDCliente = ClienteID;
                    NroDocumento = ObjCliente.NroDocumento;
                    RazonSocial = ObjCliente.RazonSocial;
                    Direccion = ObjCliente.Direccion;
                    TipoCliente = ObjCliente.TipoClienteID;
                    TipoDocumento = ObjCliente.IDTipoDocumento;

                    LimpiarTextos();
                    //MessageBox.Show("Se agrego Correctamente al cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Cliente.UpdateCliente(ObjCliente, "A");
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

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            CboTipoDocumento.Enabled = true;
            TipoGuardar = "Nuevo";
            OcultarBotones(false, false, true, false, true, false);
            ReadOnly(false);
            LimpiarTextos();
            //país Perú por defecto
            CboPais.SelectedValue = 168;
            TxtDireccion.Visible = false;
            LblDireccion.Visible = false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //desahcer
            TxtDireccion.Visible = true;
            LblDireccion.Visible = true;
            OcultarBotones(true, true, false, false, false, false);
            ReadOnly(false);
            LimpiarTextos();
            ReadOnly(true);

            lbla.Visible = false;
            lbln.Visible = false;
            lblnd.Visible = false;
            lblrz.Visible = false;
            lbltc.Visible = false;
            lbltd.Visible = false;
        }

        private void CboDepartamento_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboDepartamento.SelectedValue != null)
            {
                DataView DvProvincia = new DataView(DsUbicacion.Tables["Provincia"]);
                DvProvincia.RowFilter = "DepartamentoId='" + CboDepartamento.SelectedValue + "'";
                CboProvincia.HoldFields();
                CboProvincia.DataSource = DvProvincia;
                CboProvincia.DisplayMember = "Provincia";
                CboProvincia.ValueMember = "ProvinciaId";

                if(DtCliente.Rows.Count > 0)
                    CboProvincia.SelectedValue = DtCliente.Rows[0]["ProvinciaId"];
            }
        }

        private void CboProvincia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboProvincia.SelectedValue != null)
            {
                DataView DvDistrito = new DataView(DsUbicacion.Tables["Distrito"]);
                DvDistrito.RowFilter = "ProvinciaId='" + CboProvincia.SelectedValue + "'";
                CboDistrito.HoldFields();
                CboDistrito.DataSource = DvDistrito;
                CboDistrito.DisplayMember = "Distrito";
                CboDistrito.ValueMember = "DistritoId";

                if(DtCliente.Rows.Count > 0)
                    CboDistrito.SelectedValue = DtCliente.Rows[0]["DistritoId"];
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            TipoGuardar = "Actualizar";
            OcultarBotones(false, false, true, false, true, false);
            ReadOnly(false);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarBotones(true, true, false, false, false, false);

                if (MessageBox.Show("¿Está seguro que desea eliminar el chofer?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Cliente.UpdateCliente(ObjCliente, "E");
                    lblEstado.Text = "Se eliminó el Cliente con el Nro Documento:  " + TxtDocumento2.Text + ".";
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

        private void Buscar()
        {
            ReadOnly(false);
            lblEstado.Text = "";
            ErrProvider.Clear();

            // ObtenerDatosControles();
            DtCliente = ObjCL_Cliente.GetClienteDocumento(TxtDocumento2.Text);

            if (DtCliente.Rows.Count > 0)
            {
                CboVia.SelectedValue = DtCliente.Rows[0]["DireccionViaId"];
                CboTipoCliente.SelectedValue = DtCliente.Rows[0]["TipoClienteID"];
                CboTipoDocumento.SelectedValue = DtCliente.Rows[0]["IDTipoDocumento"];
                CboDistrito.SelectedValue = DtCliente.Rows[0]["DistritoId"];
                CboProvincia.SelectedValue = DtCliente.Rows[0]["ProvinciaId"];
                CboDepartamento.SelectedValue = DtCliente.Rows[0]["DepartamentoId"];
                CboPais.SelectedValue = DtCliente.Rows[0]["PaisId"];
                TxtClienteID.Value = DtCliente.Rows[0]["ClienteID"];
                TxtNroDocumento.Value = DtCliente.Rows[0]["NroDocumento"];
                TxtRazonSocial.Value = DtCliente.Rows[0]["RazonSocial"];
                TxtAlias.Value = DtCliente.Rows[0]["Alias"];
                TxtContacto.Value = DtCliente.Rows[0]["Contacto"];
                TxtTelefonoFijo.Value = DtCliente.Rows[0]["TelefonoFijo"];
                TxtTelefonoMovil.Value = DtCliente.Rows[0]["TelefonoMovil"];
                TxtFax.Value = DtCliente.Rows[0]["Fax"];
                TxtEmail.Value = DtCliente.Rows[0]["Email"];
                TxtDireccion.Value = DtCliente.Rows[0]["Direccion"];
                TxtNombreVia.Value = DtCliente.Rows[0]["NombreVia"];
                TxtNombre1.Value = DtCliente.Rows[0]["Nombre1"];
                TxtNombre2.Value = DtCliente.Rows[0]["Nombre2"];
                TxtApellido1.Value = DtCliente.Rows[0]["Apellido1"];
                TxtApellido2.Value = DtCliente.Rows[0]["Apellido2"];
                TxtDireccionNumero.Value = DtCliente.Rows[0]["DireccionNumero"];
                TxtDireccionInterior.Value = DtCliente.Rows[0]["DireccionInterior"];
                TxtObservacion.Value = DtCliente.Rows[0]["Observaciones"];
                OcultarBotones(true, true, false, true, false, true);
            }
            else
            {
                LimpiarTextos();
                ReadOnly(true);
                lblEstado.Text = "No existe Cliente con el Nro Ducumento: " + TxtDocumento2.Text;
                lblEstado.ForeColor = Color.Red;
                OcultarBotones(true, true, false, false, false, false);
            }

            ReadOnly(true);
        }

        private bool validarControles()
        {
            if (CboTipoCliente.SelectedValue == null) { ErrProvider.SetError(CboTipoCliente, "Debe seleccionar un tipo de cliente."); return false; }
            if (TxtNroDocumento.Text == "") { ErrProvider.SetError(TxtNroDocumento, "Debe Ingresar número de documento."); return false; }


            if (CboTipoDocumento.Text == "") { ErrProvider.SetError(CboTipoDocumento, "Debe Ingresar una tipo documento."); return false; }
            if(CboTipoDocumento.SelectedValue.ToString() == "1")//RUC
            {
                if (TxtRazonSocial.Text == "") { ErrProvider.SetError(TxtRazonSocial, "Debe Ingresar la razon social de la empresa o persona."); return false; }
                RazonSocial = TxtRazonSocial.Text;
            }
            if (CboTipoDocumento.SelectedValue.ToString() == "2")//DNI
            {
                if (TxtNombre1.Text == "") { ErrProvider.SetError(TxtNombre1, "Debe Ingresar un nombre de persona."); return false; }
                if (TxtApellido1.Text == "") { ErrProvider.SetError(TxtApellido1, "Debe Ingresar apellido paterno."); return false; }
                RazonSocial = (TxtApellido1.Text + " " + TxtApellido2.Text + ", " + TxtNombre1.Text + " " + TxtNombre2.Text).Replace("  "," ");
            }

            //obtener la direccion
            string Departamento = "";
            string Provincia = "";
            string Distrito = "";
            string Via = "";
            if (CboDepartamento.SelectedIndex != -1)
                Departamento = CboDepartamento.Columns["Departamento"].Value.ToString();
            else
            {ErrProvider.SetError(CboDepartamento, "Debe seleccionar el departamento."); return false;}
            if (CboProvincia.SelectedIndex != -1)
                Provincia = CboProvincia.Columns["Provincia"].Value.ToString();
            else
            { ErrProvider.SetError(CboProvincia, "Debe seleccionar la provincia."); return false; }
            if (CboDistrito.SelectedIndex != -1)
                Distrito = CboDistrito.Columns["Distrito"].Value.ToString();
            else
            { ErrProvider.SetError(CboDistrito, "Debe seleccionar el distrito."); return false; }
            if (CboVia.SelectedIndex != -1)
                Via = CboVia.Columns["Via"].Value.ToString();
            else
            { ErrProvider.SetError(CboVia, "Debe seleccionar el tipo de via."); return false; }
            Direccion = Via + " " + TxtNombreVia.Text + " " + TxtDireccionNumero.Text + " " + TxtDireccionInterior.Text + ", " + Provincia + ", " + Departamento + ", " + Distrito;
            return true;
        }

        private void LimpiarTextos()
        {
            CboTipoDocumento.SelectedIndex = -1;
            CboVia.SelectedIndex = -1;
            CboTipoCliente.SelectedIndex = -1;
            CboTipoDocumento.SelectedIndex = -1;
            CboDepartamento.SelectedIndex = -1;
            CboDistrito.SelectedIndex = -1;
            CboProvincia.SelectedIndex = -1;
            CboPais.SelectedIndex = -1;

            TxtClienteID.Text = "";
            TxtNroDocumento.Text = "";
            TxtRazonSocial.Text = "";
            TxtAlias.Text = "";
            TxtContacto.Text = "";
            TxtTelefonoFijo.Text = "";
            TxtTelefonoMovil.Text = "";
            TxtFax.Text = "";
            TxtEmail.Text = "";
            TxtDireccion.Text = "";
            TxtNombre1.Text = "";
            TxtNombre2.Text = "";
            TxtApellido1.Text = "";
            TxtApellido2.Text = "";
            TxtNombreVia.Text = "";
            TxtDireccionNumero.Text = "";
            TxtDireccionInterior.Text = "";
            TxtObservacion.Text = "";
        }

        private void ReadOnly(bool Valor)
        {
            CboTipoDocumento.ReadOnly = Valor;
            CboVia.ReadOnly = Valor;
            CboTipoCliente.ReadOnly = Valor;
            CboTipoDocumento.ReadOnly = Valor;
            CboDepartamento.ReadOnly = Valor;
            CboDistrito.ReadOnly = Valor;
            CboProvincia.ReadOnly = Valor;
            CboPais.ReadOnly = Valor;

            TxtClienteID.ReadOnly = Valor;
            TxtNroDocumento.ReadOnly = Valor;
            TxtRazonSocial.ReadOnly = Valor;
            TxtAlias.ReadOnly = Valor;
            TxtContacto.ReadOnly = Valor;
            TxtTelefonoFijo.ReadOnly = Valor;
            TxtTelefonoMovil.ReadOnly = Valor;
            TxtFax.ReadOnly = Valor;
            TxtEmail.ReadOnly = Valor;
            TxtDireccion.ReadOnly = Valor;
            TxtNombreVia.ReadOnly = Valor;
            TxtNombre1.ReadOnly = Valor;
            TxtNombre2.ReadOnly = Valor;
            TxtApellido1.ReadOnly = Valor;
            TxtApellido2.ReadOnly = Valor;
            TxtDireccionNumero.ReadOnly = Valor;
            TxtDireccionInterior.ReadOnly = Valor;
            TxtObservacion.ReadOnly = Valor;
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

        private void ObtenerDatosControles()
        {
            ObjCliente = new E_Cliente();
            if (TxtClienteID.Text != "")
                ObjCliente.ClienteID = Convert.ToInt32(TxtClienteID.Text);
            if (CboTipoCliente.SelectedIndex != -1)
                ObjCliente.TipoClienteID = Convert.ToInt16(CboTipoCliente.SelectedValue.ToString());
            if (CboTipoDocumento.SelectedIndex != -1)
                ObjCliente.IDTipoDocumento = Convert.ToInt16(CboTipoDocumento.SelectedValue.ToString());
            ObjCliente.NroDocumento = TxtNroDocumento.Text;
            ObjCliente.RazonSocial = RazonSocial;
            ObjCliente.Alias = TxtAlias.Text;
            ObjCliente.Contacto = TxtContacto.Text;
            ObjCliente.TelefonoFijo = TxtTelefonoFijo.Text;
            ObjCliente.TelefonoMovil = TxtTelefonoMovil.Text;
            ObjCliente.Fax = TxtFax.Text;
            ObjCliente.Email = TxtEmail.Text;
            ObjCliente.Direccion = Direccion;
            if (CboDistrito.SelectedIndex != -1)
                ObjCliente.DistritoId = Convert.ToInt16(CboDistrito.SelectedValue.ToString());
            if (CboProvincia.SelectedIndex != -1)
                ObjCliente.ProvinciaId = Convert.ToInt16(CboProvincia.SelectedValue.ToString());
            if (CboDepartamento.SelectedIndex != -1)
                ObjCliente.DepartamentoId = Convert.ToInt16(CboDepartamento.SelectedValue.ToString());
            ObjCliente.Nombre1 = TxtNombre1.Text;
            ObjCliente.Nombre2 = TxtNombre2.Text;
            ObjCliente.Apellido1 = TxtApellido1.Text;
            ObjCliente.Apellido2 = TxtApellido2.Text;
            if (CboPais.SelectedIndex != -1)
                ObjCliente.PaisId = Convert.ToInt16(CboPais.SelectedValue.ToString());
            ObjCliente.NombreVia = TxtNombreVia.Text;
            if (CboVia.SelectedIndex != -1)
                ObjCliente.DireccionViaId = Convert.ToInt16(CboVia.SelectedValue.ToString());
            ObjCliente.DireccionNumero = TxtDireccionNumero.Text;
            ObjCliente.DireccionInterior = TxtDireccionInterior.Text;
            ObjCliente.Observaciones = TxtObservacion.Text;
            ObjCliente.UsuarioID = AppSettings.UserID;
        }

        private void TxtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtNroDocumento);
        }

        private void TxtDocumento2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnBuscar_Click(null, null);
            }
            else
                ObjTextFunctions.ValidaNumero(sender, e, TxtDocumento2);
        }

        private void CboTipoCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboTipoCliente.SelectedIndex != -1)
            {
                if (CboTipoCliente.SelectedValue.ToString() == "1")//natural
                {
                    lbln.Visible = true;
                    lbla.Visible = true;
                    lblrz.Visible = false;
                    lblnd.Visible = true;
                    lbltc.Visible = true;
                    lbltd.Visible = true;
                    CboTipoDocumento.Enabled = true;
                }
                else
                {
                    lbln.Visible = false;
                    lbla.Visible = false;
                    lblrz.Visible = true;
                    lblnd.Visible = true;
                    lbltc.Visible = true;
                    lbltd.Visible = true;

                    CboTipoDocumento.SelectedValue = 1;
                    CboTipoDocumento.Enabled = false;
                }
            }
        }
    }
}

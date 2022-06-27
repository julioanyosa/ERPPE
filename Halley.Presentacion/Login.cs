using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Halley.Configuracion;
using Halley.CapaLogica.Users;
using Halley.Accesos;
using RRV.Seguridad;
using Halley.Utilitario;
using Halley.CapaLogica.Empresa; 

namespace Halley.Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //if (AppSettings.UserLatest.Length == 0)
            //    this.txtUsuario.Focus();
            //else
            //{
            //    this.txtUsuario.Text = AppSettings.UserLatest;
            //    this.txtPassword.Text = AppSettings.UserClave;
            //    this.txtPassword.Focus();
            //}
            LblVersion.Text = "24/09/2020_" + Application.ProductVersion;

            //Halley.CapaLogica.Ventas.CL_Venta aaa = new Halley.CapaLogica.Ventas.CL_Venta();
            //aaa.ObtenerDatosCliente("10430705739");
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            try
            {
                AppSettings.Usuario = this.txtUsuario.Text.Trim();
               // Obtener datos del personal o usuario logueado, como nombre completo
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                int _perfilID = 0;
                Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                objCrypto.Key = AppSettings.Key;
                objCrypto.IV = AppSettings.IV;

                string _password = objCrypto.CifrarCadena(this.txtPassword.Text.ToString());
                Libreria_Users objUser = new Libreria_Users(AppSettings.GetConnectionString);
                _perfilID = objUser.LogOnUser(this.txtUsuario.Value.ToString(), _password);

                AppSettings.Perfil = _perfilID;

                if (_perfilID != 0)
                {
                    AppSettings.UserID = objUser.ObtenerUsuarioID(this.txtUsuario.Value.ToString());
                    AppSettings.AssignedMenu = objUser.Obtener_VentanasPermiso(this.txtUsuario.Value.ToString().Trim(), _perfilID);
                    AppSettings.AlmacenAsignado = objUser.Obtener_AlmacenUsuario(AppSettings.UserID);
                    AppSettings.CadenaAlmacen = new BaseFunctions().CadenaUnidadNegocio(AppSettings.AlmacenAsignado);
                    AppSettings.Almacen = objUser.Obtener(AppSettings.CadenaAlmacen);
                    AppSettings.SedeID = AppSettings.Almacen.Rows[0][2].ToString();
                    AppSettings.NomSede = AppSettings.Almacen.Rows[0][3].ToString();
                    AppSettings.TelfSede = AppSettings.Almacen.Rows[0][4].ToString();
                    AppSettings.UbicacionSede = AppSettings.Almacen.Rows[0][9].ToString();
                    //AppSettings.AlmacenPermisos = objUser.ObtenerPermisos();
                    AppSettings.SedesPermiso = new CL_Usuario().GetSedesUsuario(AppSettings.UserID);
                    this.DialogResult = DialogResult.Yes;
                }

                //modificar el el app.config el usuario mas reciente
                new UpdateConfiguration().AppSettingsSectionModify("User", this.txtUsuario.Text);

                //traer los datos de las empresas que se usaran aapra los reportes
                UTI_Datatables.DtEmpresas = new CL_Empresas().GetEmpresasMantenimiento();
                UTI_Datatables.Dt_Sedes = new CL_Empresas().GetSedes();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.btnOk_Click(sender, e);
            }
        }

       
    }
}
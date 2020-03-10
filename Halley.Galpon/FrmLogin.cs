using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Halley.Galpon
{
    public partial class Login : Form
    {
        DataTable dt;
        string user, clave;
        int id;
        ListGalpon frmGalpon = new ListGalpon();

        public Login()
        {
            InitializeComponent();
          
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
         
            user = txtUsuario.Text;
            clave = txtPassword.Text;

            dt = new Conexion().getUsuario(user,clave);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Datos incorrectos", "Verique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
            }
            else
            {
                id = (int)dt.Rows[0][0];
                Conexion.dtGalpon = new Conexion().getGalpon(id);
                Conexion.Usuario = user;
                Conexion.UsuarioId = id.ToString();
                this.Hide();
                frmGalpon.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsuario.Text = "lennin";
        }
    }
}

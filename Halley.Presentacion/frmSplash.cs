using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Halley.Presentacion
{
    public partial class frmSplash : Form
    {
        int seconds;
        public frmSplash()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            seconds = seconds + 1;

            switch (seconds)
            {
                case 2:
                    Application.DoEvents();  
                    lblCarga.Text = "Cargando...";
                    break;
                case 3:
                    Application.DoEvents();  
                    lblCarga.Text = "Seguridad ...";
                    break;

                case 10:
                    Application.DoEvents();  
                    lblCarga.Text = "Listo";
                    break;
                case 11:
                    timer1.Enabled = false;
                    Close();
                    Dispose();
                    break;
            }
           
        }
    }
}
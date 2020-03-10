using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using C1.Win.C1Ribbon;
using Halley.CapaLogica.Users;
using Halley.Configuracion;
using RRV.Seguridad;

namespace Halley.Presentacion
{
    public partial class IDE : C1RibbonForm
    {

        C1.Win.C1Ribbon.VisualStyle vStyle = VisualStyle.Office2007Blue;
        Ribbon _ribbon;
        string _applicationName = "HALLEY";

        #region Ribbon Style Menu

        private void InitializeRibbonStyleMenu()
        {

            switch (AppSettings.RibbonStyle)
            {
                case "Office2007Blue":
                    vStyle = VisualStyle.Office2007Blue;
                    break;
                case "Office2007Silver":
                    vStyle = VisualStyle.Office2007Silver;
                    break;
                case "Office2007Black":
                    vStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Black;
                    break;
            }

            VisualStyle = vStyle;

            this.UpdateRibbonStyleMenuCheckMark();
            this.c1Ribbon1.VisualStyleChanged += delegate { this.UpdateRibbonStyleMenuCheckMark(); };

            this.Office2007BlueStyleButton.Click += delegate { this.VisualStyle = VisualStyle.Office2007Blue; };
            this.Office2007SilverStyleButton.Click += delegate { this.VisualStyle = VisualStyle.Office2007Silver; };
            this.Office2007BlackStyleButton.Click += delegate { this.VisualStyle = VisualStyle.Office2007Black; };

        }

        private void UpdateRibbonStyleMenuCheckMark()
        {
            //modificar el el app.config el usuario mas reciente
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection appSettings = config.AppSettings;

            KeyValueConfigurationElement setting = appSettings.Settings["RibbonStyle"];
            setting.Value = VisualStyle.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            //VisualStyle = vStyle;
            //switch (this.vStyle)
            switch (this.VisualStyle)
            {
                case VisualStyle.Office2007Blue:
                    this.Office2007BlueStyleButton.Pressed = true;
                    break;
                case VisualStyle.Office2007Black:
                    this.Office2007BlackStyleButton.Pressed = true;
                    break;
                case VisualStyle.Office2007Silver:
                    this.Office2007SilverStyleButton.Pressed = true;
                    break;
            }
        }

        #endregion

        public IDE()
        {
            InitializeComponent();

            this.InitializeRibbonStyleMenu();
            Controller.Model.StatusChanged += new Model.delegateStatusChanged(Model_StatusChanged);   

            //Cargar el splash
            frmSplash fSplash = new frmSplash();
            fSplash.ShowDialog();
        }

        void Model_StatusChanged(string assembly, UserControl userControl)
        {
            AppSettings.ControlChild = userControl;
        }

        void _ribbon_RibbonClick(string menuCodigo, string ensamblado, string modoCarga, string titulo, string clase)
        {
            if (new CL_Helper().AssignedMenu(ensamblado) == false || clase.Length == 0)
            {
                string _msg = "{0}.\r\rNo tiene el permiso para accesar a la ventana {1}.\rDe los contrario contacte con soporte tecnico para que le habiliten los permisos necesarios.";
                MessageBox.Show(string.Format(_msg,AppSettings.ApeNom_Login, titulo), "Accesos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Application.DoEvents();
                if (modoCarga == "1")
                {
                    Controller.NavigateTo(clase, ensamblado, titulo);
                }
                else
                { Controller.ShowModal(ensamblado, titulo, ""); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void IDE_Load(object sender, EventArgs e)
        {
            
            Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
            objCrypto.Key = AppSettings.Key;
            objCrypto.IV = AppSettings.IV;

            Controller.IDE = this;

            //Cargamos el Login
            Application.DoEvents();
            Login fLogin = new Login();
            fLogin.Owner = this;
            fLogin.ShowDialog();
            if (fLogin.DialogResult == DialogResult.Yes)
            {
                _ribbon = new Ribbon(this.c1Ribbon1, new CL_Helper().Get_UsersMenu(AppSettings.UserID));
                _ribbon.Fill();
                _ribbon.RibbonClick += new Ribbon.delegateRibbonClick(_ribbon_RibbonClick);
               
                fLogin.Close();
                fLogin.Dispose();
            }
            else
            { Application.Exit(); };

            this.Text = string.Format(_applicationName, AppSettings.Version);
            this.rblblUsuario.Text = AppSettings.Usuario;
            this.rblblServer.Text = new CL_Helper().ExecuteScalar("Select @@Servername").ToString();
            this.rblblEmpresa.Text = AppSettings.NomEmpresa;
            this.rblblPerfil.Text = AppSettings.NomPerfil;
            //this.rblblSede.Text = AppSettings.NomSede;

            //agregar al combo las sedes
            if (AppSettings.SedesPermiso != null)
            {
                foreach (DataRow Dr in AppSettings.SedesPermiso.Rows)
                {
                    RibbonButton rbutton;
                    rbutton = new RibbonButton();
                    rbutton.Text = Dr["NomSede"].ToString();
                    rbutton.ToolTip = Dr["NomSede"].ToString();
                    rbutton.LargeImage = (Image)Halley.Presentacion.Properties.Resources.ResourceManager.GetObject("Sede_16x16");
                    rbutton.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageBeforeText;
                    rbutton.Tag = Dr["SedeID"].ToString();
                    CboSede.Items.Add(rbutton);
                }
             
            }
            if(CboSede.Items.Count > 0)
                CboSede.SelectedIndex = 0;
        }

        private void c1DockingTab1_TabPageClosing(object sender, C1.Win.C1Command.TabPageCancelEventArgs e)
        {
            e.Cancel = true;
            C1.Win.C1Command.C1DockingTabPage page = e.TabPage as C1.Win.C1Command.C1DockingTabPage;
            System.Diagnostics.Debug.Assert(page != null);
            this.c1DockingTab1.TabPages.Remove(page);
        }

        private void c1DockingTab1_SelectedIndexChanging(object sender, C1.Win.C1Command.SelectedIndexChangingEventArgs e)
        {
            if (e.NewIndex != -1)
            {
                int _in = e.NewIndex;
                string[] _assembly = ((C1.Win.C1Command.C1DockingTab)(sender)).TabPages[_in].Tag.ToString().Split(';');
               
                //Buscar el control en el tab
                object[] obj = null;
                int _idx;
                _idx = _in;
                obj = this.c1DockingTab1.Controls.Find(_assembly[0], true);

                UserControl x = null;

                for (int i = 0; i <= obj.Length - 1; i++)
                {
                    if (obj[i].GetType().Name == _assembly[0])
                    {
                        x = (UserControl)obj[i];
                    }
                }
                AppSettings.ControlChild = x;
            }
        }

        private void rbCerrar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void CboSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboSede.SelectedIndex != -1)
            {
                int Indice = 0;
                Indice = CboSede.SelectedIndex;
                //filtrar los almacenes
                DataView Dv = new DataView(AppSettings.Almacen, "SedeID = '" + CboSede.Items[Indice].Tag.ToString().Trim() + "'", "SedeID ASC", DataViewRowState.OriginalRows);
                AppSettings.AlmacenPermisos = Dv.ToTable();
                this.rblblSede.Text = CboSede.Items[Indice].ToolTip;
                //cambiar la sede
                AppSettings.SedeID = CboSede.Items[Indice].Tag.ToString().Trim();
                AppSettings.NomSede = CboSede.Items[Indice].ToolTip;
            }
        }
    }

}
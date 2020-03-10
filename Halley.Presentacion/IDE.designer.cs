namespace Halley.Presentacion
{
    partial class IDE
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDE));
            this.c1Ribbon1 = new C1.Win.C1Ribbon.C1Ribbon();
            this.ribbonApplicationMenu1 = new C1.Win.C1Ribbon.RibbonApplicationMenu();
            this.rbCerrar = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonConfigToolBar1 = new C1.Win.C1Ribbon.RibbonConfigToolBar();
            this.RibbonStyleMenu = new C1.Win.C1Ribbon.RibbonMenu();
            this.ribbonToggleGroup1 = new C1.Win.C1Ribbon.RibbonToggleGroup();
            this.Office2007BlueStyleButton = new C1.Win.C1Ribbon.RibbonToggleButton();
            this.Office2007SilverStyleButton = new C1.Win.C1Ribbon.RibbonToggleButton();
            this.Office2007BlackStyleButton = new C1.Win.C1Ribbon.RibbonToggleButton();
            this.F1HelpButton = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonQat1 = new C1.Win.C1Ribbon.RibbonQat();
            this.c1StatusBar1 = new C1.Win.C1Ribbon.C1StatusBar();
            this.rblblEmpresa = new C1.Win.C1Ribbon.RibbonLabel();
            this.ribbonSeparator3 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.CboSede = new C1.Win.C1Ribbon.RibbonComboBox();
            this.rblblSede = new C1.Win.C1Ribbon.RibbonLabel();
            this.rblblPerfil = new C1.Win.C1Ribbon.RibbonLabel();
            this.ribbonSeparator4 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.rblblUsuario = new C1.Win.C1Ribbon.RibbonLabel();
            this.ribbonSeparator1 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.rblblServer = new C1.Win.C1Ribbon.RibbonLabel();
            this.c1DockingTab1 = new C1.Win.C1Command.C1DockingTab();
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Ribbon1
            // 
            this.c1Ribbon1.ApplicationMenuHolder = this.ribbonApplicationMenu1;
            this.c1Ribbon1.ConfigToolBarHolder = this.ribbonConfigToolBar1;
            this.c1Ribbon1.Name = "c1Ribbon1";
            this.c1Ribbon1.QatHolder = this.ribbonQat1;
            // 
            // ribbonApplicationMenu1
            // 
            this.ribbonApplicationMenu1.ID = "ribbonApplicationMenu1";
            this.ribbonApplicationMenu1.LargeImage = global::Halley.Presentacion.Properties.Resources.pollito32x32;
            this.ribbonApplicationMenu1.LeftPaneItems.Add(this.rbCerrar);
            // 
            // rbCerrar
            // 
            this.rbCerrar.ID = "rbCerrar";
            this.rbCerrar.LargeImage = global::Halley.Presentacion.Properties.Resources.Cerrar_32x32;
            this.rbCerrar.Text = "Cerrar Sesión";
            this.rbCerrar.Click += new System.EventHandler(this.rbCerrar_Click);
            // 
            // ribbonConfigToolBar1
            // 
            this.ribbonConfigToolBar1.ID = "ribbonConfigToolBar1";
            this.ribbonConfigToolBar1.Items.Add(this.RibbonStyleMenu);
            this.ribbonConfigToolBar1.Items.Add(this.F1HelpButton);
            // 
            // RibbonStyleMenu
            // 
            this.RibbonStyleMenu.ID = "RibbonStyleMenu";
            this.RibbonStyleMenu.Items.Add(this.ribbonToggleGroup1);
            this.RibbonStyleMenu.SmallImage = ((System.Drawing.Image)(resources.GetObject("RibbonStyleMenu.SmallImage")));
            this.RibbonStyleMenu.Text = "Estilo";
            // 
            // ribbonToggleGroup1
            // 
            this.ribbonToggleGroup1.ID = "ribbonToggleGroup1";
            this.ribbonToggleGroup1.Items.Add(this.Office2007BlueStyleButton);
            this.ribbonToggleGroup1.Items.Add(this.Office2007SilverStyleButton);
            this.ribbonToggleGroup1.Items.Add(this.Office2007BlackStyleButton);
            // 
            // Office2007BlueStyleButton
            // 
            this.Office2007BlueStyleButton.ID = "Office2007BlueStyleButton";
            this.Office2007BlueStyleButton.Text = "Office 2007 Azul";
            // 
            // Office2007SilverStyleButton
            // 
            this.Office2007SilverStyleButton.ID = "Office2007SilverStyleButton";
            this.Office2007SilverStyleButton.Text = "Office 2007 Plata";
            // 
            // Office2007BlackStyleButton
            // 
            this.Office2007BlackStyleButton.ID = "Office2007BlackStyleButton";
            this.Office2007BlackStyleButton.Text = "Office 2007 Negro";
            // 
            // F1HelpButton
            // 
            this.F1HelpButton.ID = "F1HelpButton";
            this.F1HelpButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("F1HelpButton.SmallImage")));
            this.F1HelpButton.Visible = false;
            // 
            // ribbonQat1
            // 
            this.ribbonQat1.ID = "ribbonQat1";
            // 
            // c1StatusBar1
            // 
            this.c1StatusBar1.LeftPaneItems.Add(this.rblblEmpresa);
            this.c1StatusBar1.LeftPaneItems.Add(this.ribbonSeparator3);
            this.c1StatusBar1.LeftPaneItems.Add(this.CboSede);
            this.c1StatusBar1.LeftPaneItems.Add(this.rblblSede);
            this.c1StatusBar1.Name = "c1StatusBar1";
            this.c1StatusBar1.RightPaneItems.Add(this.rblblPerfil);
            this.c1StatusBar1.RightPaneItems.Add(this.ribbonSeparator4);
            this.c1StatusBar1.RightPaneItems.Add(this.rblblUsuario);
            this.c1StatusBar1.RightPaneItems.Add(this.ribbonSeparator1);
            this.c1StatusBar1.RightPaneItems.Add(this.rblblServer);
            // 
            // rblblEmpresa
            // 
            this.rblblEmpresa.ID = "rblblEmpresa";
            this.rblblEmpresa.SmallImage = global::Halley.Presentacion.Properties.Resources.Sede_16x16;
            // 
            // ribbonSeparator3
            // 
            this.ribbonSeparator3.ID = "ribbonSeparator3";
            // 
            // CboSede
            // 
            this.CboSede.ID = "CboSede";
            this.CboSede.Label = "Sede";
            this.CboSede.SmallImage = global::Halley.Presentacion.Properties.Resources.Home_16x16;
            this.CboSede.SelectedIndexChanged += new System.EventHandler(this.CboSede_SelectedIndexChanged);
            // 
            // rblblSede
            // 
            this.rblblSede.ID = "rblblSede";
            this.rblblSede.SmallImage = global::Halley.Presentacion.Properties.Resources.Sede_16x161;
            // 
            // rblblPerfil
            // 
            this.rblblPerfil.ID = "rblblPerfil";
            this.rblblPerfil.SmallImage = ((System.Drawing.Image)(resources.GetObject("rblblPerfil.SmallImage")));
            // 
            // ribbonSeparator4
            // 
            this.ribbonSeparator4.ID = "ribbonSeparator4";
            // 
            // rblblUsuario
            // 
            this.rblblUsuario.ID = "rblblUsuario";
            this.rblblUsuario.SmallImage = global::Halley.Presentacion.Properties.Resources.User_16x16;
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.ID = "ribbonSeparator1";
            // 
            // rblblServer
            // 
            this.rblblServer.ID = "rblblServer";
            this.rblblServer.SmallImage = global::Halley.Presentacion.Properties.Resources.Servidor_16x16;
            // 
            // c1DockingTab1
            // 
            this.c1DockingTab1.CanCloseTabs = true;
            this.c1DockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1DockingTab1.Location = new System.Drawing.Point(0, 51);
            this.c1DockingTab1.Name = "c1DockingTab1";
            this.c1DockingTab1.SelectedTabBold = true;
            this.c1DockingTab1.ShowTabList = true;
            this.c1DockingTab1.Size = new System.Drawing.Size(784, 491);
            this.c1DockingTab1.TabIndex = 5;
            this.c1DockingTab1.TabsSpacing = 5;
            this.c1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.c1DockingTab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue;
            this.c1DockingTab1.SelectedIndexChanging += new C1.Win.C1Command.SelectedIndexChangingEventHandler(this.c1DockingTab1_SelectedIndexChanging);
            this.c1DockingTab1.TabPageClosing += new C1.Win.C1Command.TabPageCancelEventHandler(this.c1DockingTab1_TabPageClosing);
            // 
            // IDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.c1DockingTab1);
            this.Controls.Add(this.c1StatusBar1);
            this.Controls.Add(this.c1Ribbon1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IDE";
            this.Text = "PERUANA DE ENVASES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IDE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Ribbon.C1Ribbon c1Ribbon1;
        private C1.Win.C1Ribbon.RibbonConfigToolBar ribbonConfigToolBar1;
        private C1.Win.C1Ribbon.RibbonQat ribbonQat1;
        private C1.Win.C1Ribbon.C1StatusBar c1StatusBar1;
        private C1.Win.C1Ribbon.RibbonLabel rblblUsuario;
        private C1.Win.C1Ribbon.RibbonLabel rblblServer;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator1;
        private C1.Win.C1Ribbon.RibbonMenu RibbonStyleMenu;
        private C1.Win.C1Ribbon.RibbonButton F1HelpButton;
        private C1.Win.C1Ribbon.RibbonToggleGroup ribbonToggleGroup1;
        private C1.Win.C1Ribbon.RibbonToggleButton Office2007BlueStyleButton;
        private C1.Win.C1Ribbon.RibbonToggleButton Office2007SilverStyleButton;
        private C1.Win.C1Ribbon.RibbonToggleButton Office2007BlackStyleButton;
        public C1.Win.C1Command.C1DockingTab c1DockingTab1;
        private C1.Win.C1Ribbon.RibbonApplicationMenu ribbonApplicationMenu1;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator3;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator4;
        private C1.Win.C1Ribbon.RibbonLabel rblblEmpresa;
        private C1.Win.C1Ribbon.RibbonLabel rblblSede;
        private C1.Win.C1Ribbon.RibbonLabel rblblPerfil;
        private C1.Win.C1Ribbon.RibbonButton rbCerrar;
        private C1.Win.C1Ribbon.RibbonComboBox CboSede;
        
    }
}


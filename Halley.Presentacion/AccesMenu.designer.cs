namespace Halley.Presentacion
{
    partial class AccesMenu
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccesMenu));
            this.imgLista = new System.Windows.Forms.ImageList(this.components);
            this.lblMenu = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.grpPermisos = new System.Windows.Forms.GroupBox();
            this.chkAllowPrint = new System.Windows.Forms.CheckBox();
            this.chkAllowWrite = new System.Windows.Forms.CheckBox();
            this.chkAllowUpdate = new System.Windows.Forms.CheckBox();
            this.chkAllowDelete = new System.Windows.Forms.CheckBox();
            this.chkAllowRead = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLista
            // 
            this.imgLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLista.ImageStream")));
            this.imgLista.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLista.Images.SetKeyName(0, "Modulo_16x16.gif");
            this.imgLista.Images.SetKeyName(1, "Ventana_16x16.gif");
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(22, 46);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(38, 13);
            this.lblMenu.TabIndex = 3;
            this.lblMenu.Text = "label1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8, 8, 2, 8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpPermisos);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.lblMenu);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.splitContainer1.Size = new System.Drawing.Size(485, 264);
            this.splitContainer1.SplitterDistance = 219;
            this.splitContainer1.TabIndex = 10;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imgLista;
            this.treeView1.Location = new System.Drawing.Point(8, 8);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(209, 248);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // grpPermisos
            // 
            this.grpPermisos.Controls.Add(this.chkAllowPrint);
            this.grpPermisos.Controls.Add(this.chkAllowWrite);
            this.grpPermisos.Controls.Add(this.chkAllowUpdate);
            this.grpPermisos.Controls.Add(this.chkAllowDelete);
            this.grpPermisos.Controls.Add(this.chkAllowRead);
            this.grpPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPermisos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPermisos.Location = new System.Drawing.Point(0, 8);
            this.grpPermisos.Name = "grpPermisos";
            this.grpPermisos.Size = new System.Drawing.Size(262, 248);
            this.grpPermisos.TabIndex = 14;
            this.grpPermisos.TabStop = false;
            this.grpPermisos.Text = "Permisos ";
            // 
            // chkAllowPrint
            // 
            this.chkAllowPrint.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowPrint.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.chkAllowPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowPrint.Location = new System.Drawing.Point(22, 121);
            this.chkAllowPrint.Name = "chkAllowPrint";
            this.chkAllowPrint.Size = new System.Drawing.Size(88, 28);
            this.chkAllowPrint.TabIndex = 13;
            this.chkAllowPrint.Text = "Imprimir";
            this.chkAllowPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowPrint.UseVisualStyleBackColor = false;
            this.chkAllowPrint.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // chkAllowWrite
            // 
            this.chkAllowWrite.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowWrite.Image = global::Halley.Presentacion.Properties.Resources.save_16x16;
            this.chkAllowWrite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowWrite.Location = new System.Drawing.Point(131, 57);
            this.chkAllowWrite.Name = "chkAllowWrite";
            this.chkAllowWrite.Size = new System.Drawing.Size(84, 28);
            this.chkAllowWrite.TabIndex = 10;
            this.chkAllowWrite.Text = "   Escritura";
            this.chkAllowWrite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowWrite.UseVisualStyleBackColor = false;
            this.chkAllowWrite.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // chkAllowUpdate
            // 
            this.chkAllowUpdate.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowUpdate.Image = global::Halley.Presentacion.Properties.Resources.modify_16x16;
            this.chkAllowUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowUpdate.Location = new System.Drawing.Point(22, 91);
            this.chkAllowUpdate.Name = "chkAllowUpdate";
            this.chkAllowUpdate.Size = new System.Drawing.Size(96, 28);
            this.chkAllowUpdate.TabIndex = 11;
            this.chkAllowUpdate.Text = "Actualizar";
            this.chkAllowUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowUpdate.UseVisualStyleBackColor = false;
            this.chkAllowUpdate.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // chkAllowDelete
            // 
            this.chkAllowDelete.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowDelete.Image = global::Halley.Presentacion.Properties.Resources.delete_16x16;
            this.chkAllowDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowDelete.Location = new System.Drawing.Point(131, 91);
            this.chkAllowDelete.Name = "chkAllowDelete";
            this.chkAllowDelete.Size = new System.Drawing.Size(84, 28);
            this.chkAllowDelete.TabIndex = 12;
            this.chkAllowDelete.Text = "Eliminar";
            this.chkAllowDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowDelete.UseVisualStyleBackColor = false;
            this.chkAllowDelete.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // chkAllowRead
            // 
            this.chkAllowRead.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowRead.Image = global::Halley.Presentacion.Properties.Resources.database16x16;
            this.chkAllowRead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowRead.Location = new System.Drawing.Point(22, 57);
            this.chkAllowRead.Name = "chkAllowRead";
            this.chkAllowRead.Size = new System.Drawing.Size(88, 28);
            this.chkAllowRead.TabIndex = 9;
            this.chkAllowRead.Text = "Lectura  ";
            this.chkAllowRead.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowRead.UseVisualStyleBackColor = false;
            this.chkAllowRead.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 224);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(253, 32);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.Visible = false;
            // 
            // AccesMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AccesMenu";
            this.Size = new System.Drawing.Size(485, 264);
            this.Load += new System.EventHandler(this.AccesMenu_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpPermisos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private AS.NewMont.Win.Controls.LabelGroup labelGroup1;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imgLista;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grpPermisos;
        private System.Windows.Forms.CheckBox chkAllowPrint;
        private System.Windows.Forms.CheckBox chkAllowWrite;
        private System.Windows.Forms.CheckBox chkAllowUpdate;
        private System.Windows.Forms.CheckBox chkAllowDelete;
        private System.Windows.Forms.CheckBox chkAllowRead;
        private System.Windows.Forms.TreeView treeView1;
    }
}

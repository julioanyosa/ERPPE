namespace Halley.Presentacion.AdmUsuarios
{
    partial class FrmPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPerfil));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.accesMenu1 = new Halley.Presentacion.AccesMenu();
            this.c1TrueDBGrid1 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TxtDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.accesMenu1);
            this.splitContainer1.Panel2.Controls.Add(this.c1TrueDBGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(611, 588);
            this.splitContainer1.SplitterDistance = 61;
            this.splitContainer1.TabIndex = 21;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(93, 21);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(480, 22);
            this.TxtDescripcion.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Descripción:";
            // 
            // accesMenu1
            // 
            this.accesMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accesMenu1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accesMenu1.Location = new System.Drawing.Point(0, 0);
            this.accesMenu1.Name = "accesMenu1";
            this.accesMenu1.Perfil = false;
            this.accesMenu1.PerfilID = 0;
            this.accesMenu1.Size = new System.Drawing.Size(611, 523);
            this.accesMenu1.TabIndex = 23;
            this.accesMenu1.UserID = 0;
            // 
            // c1TrueDBGrid1
            // 
            this.c1TrueDBGrid1.AllowUpdate = false;
            this.c1TrueDBGrid1.CaptionHeight = 17;
            this.c1TrueDBGrid1.ColumnFooters = true;
            this.c1TrueDBGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1TrueDBGrid1.EmptyRows = true;
            this.c1TrueDBGrid1.ExtendRightColumn = true;
            this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
            this.c1TrueDBGrid1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1TrueDBGrid1.Images"))));
            this.c1TrueDBGrid1.Location = new System.Drawing.Point(0, 0);
            this.c1TrueDBGrid1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75D;
            this.c1TrueDBGrid1.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings")));
            this.c1TrueDBGrid1.RowHeight = 15;
            this.c1TrueDBGrid1.Size = new System.Drawing.Size(611, 523);
            this.c1TrueDBGrid1.TabIndex = 22;
            this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.Visible = false;
            this.c1TrueDBGrid1.PropBag = resources.GetString("c1TrueDBGrid1.PropBag");
            // 
            // FrmPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmPerfil";
            this.Size = new System.Drawing.Size(611, 613);
            this.Load += new System.EventHandler(this.FrmPerfil_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private AccesMenu accesMenu1;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid c1TrueDBGrid1;
        private System.Windows.Forms.TextBox TxtDescripcion;

    }
}

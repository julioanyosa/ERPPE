namespace Halley.Presentacion.Ventas
{
    partial class FrmVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentas));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAceptar = new C1.Win.C1Input.C1Button();
            this.C1TdbConsulta = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.txtDescripcion = new C1.Win.C1Input.C1TextBox();
            this.txtMarca = new C1.Win.C1Input.C1TextBox();
            this.txtCantidad = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Producto :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Marca :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(798, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Cantidad :";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(898, 23);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(72, 23);
            this.btnAceptar.TabIndex = 86;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // C1TdbConsulta
            // 
            this.C1TdbConsulta.AllowUpdate = false;
            this.C1TdbConsulta.CaptionHeight = 17;
            this.C1TdbConsulta.CausesValidation = false;
            this.C1TdbConsulta.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.C1TdbConsulta.EmptyRows = true;
            this.C1TdbConsulta.ExtendRightColumn = true;
            this.C1TdbConsulta.GroupByCaption = "Drag a column header here to group by that column";
            this.C1TdbConsulta.Images.Add(((System.Drawing.Image)(resources.GetObject("C1TdbConsulta.Images"))));
            this.C1TdbConsulta.Location = new System.Drawing.Point(9, 47);
            this.C1TdbConsulta.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.C1TdbConsulta.Name = "C1TdbConsulta";
            this.C1TdbConsulta.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.C1TdbConsulta.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.C1TdbConsulta.PreviewInfo.ZoomFactor = 75D;
            this.C1TdbConsulta.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("C1TdbConsulta.PrintInfo.PageSettings")));
            this.C1TdbConsulta.RowHeight = 18;
            this.C1TdbConsulta.Size = new System.Drawing.Size(764, 299);
            this.C1TdbConsulta.TabIndex = 87;
            this.C1TdbConsulta.Text = "Productos Genéricos";
            this.C1TdbConsulta.Visible = false;
            this.C1TdbConsulta.DoubleClick += new System.EventHandler(this.C1TdbConsulta_DoubleClick);
            this.C1TdbConsulta.PropBag = resources.GetString("C1TdbConsulta.PropBag");
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(9, 25);
            this.txtDescripcion.MaxLength = 200;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(384, 22);
            this.txtDescripcion.TabIndex = 88;
            this.txtDescripcion.Tag = null;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(419, 25);
            this.txtMarca.MaxLength = 17;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(354, 22);
            this.txtMarca.TabIndex = 89;
            this.txtMarca.Tag = null;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(801, 25);
            this.txtCantidad.MaxLength = 17;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(91, 22);
            this.txtCantidad.TabIndex = 90;
            this.txtCantidad.Tag = null;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.C1TdbConsulta);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmVentas";
            this.Size = new System.Drawing.Size(1260, 490);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.C1TdbConsulta, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.txtMarca, 0);
            this.Controls.SetChildIndex(this.txtCantidad, 0);
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1Button btnAceptar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid C1TdbConsulta;
        private C1.Win.C1Input.C1TextBox txtDescripcion;
        private C1.Win.C1Input.C1TextBox txtMarca;
        private C1.Win.C1Input.C1TextBox txtCantidad;
    }
}

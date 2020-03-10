namespace Halley.Presentacion.Almacen.Operaciones
{
    partial class FrmBuscarOC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuscarOC));
            this.TdgListaProductos = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtOrdenCompra = new C1.Win.C1Input.C1TextBox();
            this.BtnBuscarOrdenCompra = new C1.Win.C1Input.C1Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCerrar = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.TdgListaProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOrdenCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // TdgListaProductos
            // 
            this.TdgListaProductos.AllowUpdate = false;
            this.TdgListaProductos.AlternatingRows = true;
            this.TdgListaProductos.CaptionHeight = 17;
            this.TdgListaProductos.EmptyRows = true;
            this.TdgListaProductos.FilterBar = true;
            this.TdgListaProductos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TdgListaProductos.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgListaProductos.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgListaProductos.Images"))));
            this.TdgListaProductos.LinesPerRow = 2;
            this.TdgListaProductos.Location = new System.Drawing.Point(12, 69);
            this.TdgListaProductos.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightCell;
            this.TdgListaProductos.Name = "TdgListaProductos";
            this.TdgListaProductos.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgListaProductos.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgListaProductos.PreviewInfo.ZoomFactor = 75D;
            this.TdgListaProductos.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1TdgAlmacen.PrintInfo.PageSettings")));
            this.TdgListaProductos.RowHeight = 15;
            this.TdgListaProductos.Size = new System.Drawing.Size(882, 350);
            this.TdgListaProductos.TabIndex = 78;
            this.TdgListaProductos.Text = "c1TrueDBGrid1";
            this.TdgListaProductos.DoubleClick += new System.EventHandler(this.TdgListaProductos_DoubleClick);
            this.TdgListaProductos.PropBag = resources.GetString("TdgListaProductos.PropBag");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 26);
            this.label5.TabIndex = 80;
            this.label5.Text = "Ingresar\r\nNombre:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtOrdenCompra
            // 
            this.TxtOrdenCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtOrdenCompra.Location = new System.Drawing.Point(286, 21);
            this.TxtOrdenCompra.MaskInfo.ErrorMessage = "Ingrese un código valido";
            this.TxtOrdenCompra.MaskInfo.Inherit = ((C1.Win.C1Input.MaskInfoInheritFlags)((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive | C1.Win.C1Input.MaskInfoInheritFlags.EmptyAsNull)));
            this.TxtOrdenCompra.MaxLength = 17;
            this.TxtOrdenCompra.Name = "TxtOrdenCompra";
            this.TxtOrdenCompra.Size = new System.Drawing.Size(145, 22);
            this.TxtOrdenCompra.TabIndex = 79;
            this.TxtOrdenCompra.Tag = null;
            // 
            // BtnBuscarOrdenCompra
            // 
            this.BtnBuscarOrdenCompra.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnBuscarOrdenCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscarOrdenCompra.Location = new System.Drawing.Point(437, 22);
            this.BtnBuscarOrdenCompra.Name = "BtnBuscarOrdenCompra";
            this.BtnBuscarOrdenCompra.Size = new System.Drawing.Size(75, 22);
            this.BtnBuscarOrdenCompra.TabIndex = 81;
            this.BtnBuscarOrdenCompra.Text = "Mostrar";
            this.BtnBuscarOrdenCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscarOrdenCompra.UseVisualStyleBackColor = true;
            this.BtnBuscarOrdenCompra.Click += new System.EventHandler(this.BtnBuscarOrdenCompra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 34);
            this.label1.TabIndex = 82;
            this.label1.Text = "BUSCAR ORDENES\r\nDE COMPRA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Image = global::Halley.Presentacion.Properties.Resources.cerrar_16x16;
            this.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCerrar.Location = new System.Drawing.Point(808, 17);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(75, 22);
            this.BtnCerrar.TabIndex = 83;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FrmBuscarOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 430);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnBuscarOrdenCompra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtOrdenCompra);
            this.Controls.Add(this.TdgListaProductos);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmBuscarOC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar ordenes de compra";
            ((System.ComponentModel.ISupportInitialize)(this.TdgListaProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOrdenCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgListaProductos;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1TextBox TxtOrdenCompra;
        private C1.Win.C1Input.C1Button BtnBuscarOrdenCompra;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1Button BtnCerrar;
    }
}
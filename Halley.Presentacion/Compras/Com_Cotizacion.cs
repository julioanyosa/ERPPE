using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Compras;
using Halley.CapaLogica.Users;
using Halley.Configuracion;
using Halley.Utilitario;
using System.Diagnostics;
using C1.C1Pdf;
using System.IO;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;

namespace Halley.Presentacion.Compras
{
    public partial class Com_Cotizacion : UITemplateAccess
    {
        #region Declaracion de Variables

        DataTable dt;
        DataTable dtProveedor;
        DataTable dtCotizacion;

        #endregion


        #region Constructor

        public Com_Cotizacion()
        {
            InitializeComponent();
            this.ocultarToolStrip();
            c1Combo.FillC1Combo1(this.CbProveedor, GetProveedor(), "RazonSocial", "IDProveedor");
            Get_Requerimientos(AppSettings.EmpresaID);
        }

        #endregion

        #region Metodos Definidos

        public DataTable GetProveedor()
        {
            dtProveedor = new DataTable();
            dtProveedor = new CL_Proveedor().GetProveedor();
            return dtProveedor;
        }

        public void Get_Requerimientos(string EmpresaID)
        {
            dt = new DataTable();
            dt = new CL_OrdenCompra().GetRequerimientoCompra(EmpresaID);

            if (dt.Rows.Count == 0)
            {
                Cursor = Cursors.Default;
                this.C1TdbgRequerimiento.SetDataBinding(null, "", true);
                return;
            }


            C1TdbgRequerimiento.SetDataBinding(dt, "", true);
        }

        public void Configurar()
        {
            dtCotizacion = new DataTable();
            dtCotizacion.Columns.Add("NumRequerimiento", typeof(string));
            dtCotizacion.Columns.Add("ProductoID", typeof(string));
            dtCotizacion.Columns.Add("Descripcion", typeof(string));
            dtCotizacion.Columns.Add("UM", typeof(string));
            dtCotizacion.Columns.Add("NomMarca", typeof(string));
            dtCotizacion.Columns.Add("CantidadSolicitada", typeof(decimal));

            this.tdbgCotizacion.SetDataBinding(dtCotizacion, "", true);
            this.tdbgCotizacion.ColumnFooters = true;
        }

        #endregion

        #region Eventos de los controles

        private void tdbgCotizacion_AfterDelete(object sender, EventArgs e)
        {
            int Count = tdbgCotizacion.RowCount;
            this.tdbgCotizacion.Columns[1].FooterText = "Items : " + Count.ToString();
        }

        private void Com_Cotizacion_Load(object sender, EventArgs e)
        {
            Configurar();
        }

        private void C1TdbgRequerimiento_DoubleClick(object sender, EventArgs e)
        {
            string Requerimiento = this.C1TdbgRequerimiento.Columns["NumRequerimiento"].Value.ToString();
            string Codigo = this.C1TdbgRequerimiento.Columns["ProductoID"].Value.ToString();
            string Descripcion = this.C1TdbgRequerimiento.Columns["Descripcion"].Value.ToString();
            string UM = this.C1TdbgRequerimiento.Columns["UnidadMedidaID"].Value.ToString();
            string Marca = this.C1TdbgRequerimiento.Columns["NomMarca"].Value.ToString();
            decimal CantidadSolicitada = Convert.ToDecimal(this.C1TdbgRequerimiento.Columns["CantidadSolicitada"].Value.ToString());

            bool valor = false;
            foreach (DataRow drow in dtCotizacion.Rows)
            {
                if (drow["NumRequerimiento"].ToString() == Requerimiento.ToString() && drow["ProductoID"].ToString() == Codigo.ToString())
                {
                    valor = true;
                    break;
                }
            }
            if (valor == true)
            {
                MessageBox.Show("El Producto ya ah sido agregado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DataRow row;
                row = dtCotizacion.NewRow();
                row["NumRequerimiento"] = Requerimiento.ToString();
                row["ProductoID"] = Codigo.ToString();
                row["Descripcion"] = Descripcion.ToString();
                row["UM"] = UM.ToString();
                row["NomMarca"] = Marca.ToString();
                row["CantidadSolicitada"] = CantidadSolicitada.ToString();
                dtCotizacion.Rows.Add(row);
            }

            
            int Count = tdbgCotizacion.RowCount;
            this.tdbgCotizacion.Columns[1].FooterText = "Items : " + Count.ToString();
        }

        private void BtnCotizar_Click(object sender, EventArgs e)
        {
            CrearPdf();
            
        }

        #endregion

        #region Creacion de PDF

        public void CrearPdf()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (tdbgCotizacion.RowCount == 0)
                {
                    Cursor = Cursors.Default;
                    return;
                }

                if (CbProveedor.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione el Proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cursor = Cursors.Default;
                    return;
                }
                dtCotizacion.AcceptChanges();

                DataView dvProveedor = new DataView(dtProveedor);
                dvProveedor.RowFilter = "IDProveedor='" + CbProveedor.SelectedValue + "'";
                string EmailProveedor = Convert.ToString(dvProveedor[0][2]);
                string NomProveedor = Convert.ToString(dvProveedor[0][1]);
                //create pdf document
                this.PdfCotizacion.Clear();
                this.PdfCotizacion.DocumentInfo.Title = "COTIZACIÓN";

                //calculate page rect (discounting margins)
                RectangleF rcPage = GetPageRect();
                RectangleF rc = rcPage;

                Image img = Properties.Resources.HalleyLogo;
                Rectangle RC = new Rectangle(30, 12, 160, 44);
                PdfCotizacion.DrawImage(img, RC);
                PdfCotizacion.DrawRectangle(Pens.White, RC);

                // add title
                Font titleFont = new Font("Tahoma", 20, FontStyle.Regular);
                Font detalleFont = new Font("Tahoma", 15, FontStyle.Regular);

                rc = RenderParagraph(PdfCotizacion.DocumentInfo.Title, titleFont, rcPage, rc, false, 3);
                RenderParagraph("Proveedor : " + NomProveedor, detalleFont, rcPage, rc, false, 3);
                rc = RenderParagraph("Comprador : " + AppSettings.ApeNom_Login, detalleFont, rcPage, rc, false, 2);


                rc = RenderTable(rc, rcPage, dtCotizacion, "ProductoID", "Descripcion", "UM", "CantidadSolicitada");

                // second pass to number pages
                AddFooters();

                //enviar correo
                string NomArchivo = AppSettings.EmpresaID + "COTIZACION.pdf";
                string fileName = "\\\\192.168.1.21\\cotizacion\\" + NomArchivo;
                this.PdfCotizacion.Save(fileName);
                string ruta = "D:\\COTIZACION\\" + NomArchivo;

                string Asunto = "COTIZACIÓN " + AppSettings.NomEmpresa;
                string Mensaje = "Deseo que me cotizé los siguientes productos.\nAdjuntado en el pdf.\n\nREMITIR A: " + AppSettings.UserEmail;
                new CL_Helper().SendMail(Asunto, Mensaje, EmailProveedor, AppSettings.UserEmail, ruta);
                MessageBox.Show("Se envió la cotización correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtCotizacion.Rows.Clear();
                this.tdbgCotizacion.SetDataBinding(dtCotizacion, "", true);
                
                Get_Requerimientos(AppSettings.EmpresaID);
                //Process.Start(fileName);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        internal RectangleF GetPageRect()
        {
            RectangleF rcPage = this.PdfCotizacion.PageRectangle;
            rcPage.Inflate(-30, -30);
            return rcPage;
        }

        internal RectangleF RenderParagraph(string text, Font font, RectangleF rcPage, RectangleF rc, bool outline, int Tipo)
        {
            // if it won't fit this page, do a page break
            rc.Height = PdfCotizacion.MeasureString(text, font, rc.Width).Height;
            if (rc.Bottom > rcPage.Bottom)
            {
                PdfCotizacion.NewPage();
                rc.Y = rcPage.Top;
            }

            // draw the string
            StringFormat sf = new StringFormat();
            if (Tipo == 1)
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                PdfCotizacion.DrawString(text, font, Brushes.Black, rc, sf);
            }
            else if (Tipo == 2)
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                PdfCotizacion.DrawString(text, font, Brushes.Black, rc, sf);
            }
            else if (Tipo == 3)
            {
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                PdfCotizacion.DrawString(text, font, Brushes.Black, rc, sf);
            }


            //add headings to outline
            if (outline)
            {
                PdfCotizacion.DrawLine(Pens.Black, rc.X, rc.Y, rc.Right, rc.Y);
            }


            // update rectangle for next time
            rc.Offset(0, rc.Height);
            return rc;
        }

        private RectangleF RenderTable(RectangleF rc, RectangleF rcPage, DataTable dt, params string[] fields)
        {
            //Cargar la tabla de datos
            Font hdrFont = new Font("Tahoma", 8, FontStyle.Regular);
            Font txtFont = new Font("Tahoma", 7, FontStyle.Regular);

            rc = RenderTableHeader(hdrFont, rc, fields);
            foreach (DataRow dr in dt.Rows)
                rc = RenderTableRow(txtFont, hdrFont, rcPage, rc, fields, dr);
            return rc;
        }

        private void AddFooters()
        {
            Font fontHorz = new Font("Tahoma", 7, FontStyle.Bold);

            StringFormat sfRight = new StringFormat();
            sfRight.Alignment = StringAlignment.Far;

            for (int page = 0; page < PdfCotizacion.Pages.Count; page++)
            {
                // select page we want (could change PageSize)
                PdfCotizacion.CurrentPage = page;

                // build rectangles for rendering text
                RectangleF rcPage = GetPageRect();
                RectangleF rcFooter = rcPage;
                rcFooter.Y = rcFooter.Bottom + 6;
                rcFooter.Height = 12;
                RectangleF rcVert = rcPage;
                rcVert.X = rcPage.Right + 6;

                // add left-aligned footer
                string text = AppSettings.NomSede + " - " + AppSettings.UbicacionSede + "  TEL: " + AppSettings.TelfSede;
                PdfCotizacion.DrawString(text, fontHorz, Brushes.Black, rcFooter);

                // add right-aligned footer
                string TextVertical = string.Format("Page {0} of {1}", page + 1, PdfCotizacion.Pages.Count);
                PdfCotizacion.DrawString(TextVertical, fontHorz, Brushes.Black, rcFooter, sfRight);

                // draw lines on bottom and right of the page
                PdfCotizacion.DrawLine(Pens.Black, rcPage.Left, rcPage.Bottom, rcPage.Right, rcPage.Bottom);
            }
        }

        private RectangleF RenderTableHeader(Font font, RectangleF rc, params string[] fields)
        {
            // calculate cell width (same for all columns)
            RectangleF rcCell = rc;
            rcCell.Width = rc.Width / fields.Length;
            rcCell.Height = 0;

            // calculate cell height (max of all columns)
            foreach (string field in fields)
            {
                float height = PdfCotizacion.MeasureString(field, font, rcCell.Width).Height;
                rcCell.Height = Math.Max(rcCell.Height, height);
            }

            // render header cells
            StringFormat sf = new StringFormat();

            foreach (string field in fields)
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                PdfCotizacion.FillRectangle(Brushes.Black, rcCell);
                PdfCotizacion.DrawString(field, font, Brushes.White, rcCell, sf);
                rcCell.Offset(rcCell.Width, 0);
            }

            // update rectangle and return it
            rc.Offset(0, rcCell.Height);
            return rc;
        }

        private RectangleF RenderTableRow(Font font, Font hdrFont, RectangleF rcPage, RectangleF rc, string[] fields, DataRow dr)
        {
            // calculate cell width (same for all columns)
            RectangleF rcCell = rc;
            rcCell.Width = rc.Width / fields.Length;
            rcCell.Height = 0;

            // calculate cell height (max of all columns)
            rcCell.Inflate(-4, 0);
            foreach (string field in fields)
            {
                string text = dr[field].ToString();
                float height = PdfCotizacion.MeasureString(text, font, rcCell.Width).Height;
                rcCell.Height = Math.Max(rcCell.Height, height);
            }
            rcCell.Inflate(4, 0);

            // break page if we have to
            if (rcCell.Bottom > rcPage.Bottom)
            {
                PdfCotizacion.NewPage();
                rc = RenderTableHeader(hdrFont, rcPage, fields);
                rcCell.Y = rc.Y;
            }

            // center vertically just to show how
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Near;

            // render data cells
            Pen pen = new Pen(Brushes.Blue, 0.1f);
            foreach (string field in fields)
            {
                // get content
                string text = dr[field].ToString();

                // set horizontal alignment
                double d;
                sf.Alignment = (double.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out d))
                    ? StringAlignment.Near
                    : StringAlignment.Near;

                // render cell
                PdfCotizacion.DrawRectangle(pen, rcCell);
                rcCell.Inflate(-4, 0);
                PdfCotizacion.DrawString(text, font, Brushes.Black, rcCell, sf);
                rcCell.Inflate(4, 0);
                rcCell.Offset(rcCell.Width, 0);
            }
            pen.Dispose();

            // update rectangle and return it
            rc.Offset(0, rcCell.Height);
            return rc;
        }

        #endregion
    }
}

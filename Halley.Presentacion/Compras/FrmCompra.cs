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
using Halley.CapaLogica.Almacen;
using Halley.Entidad.Compras;

namespace Halley.Presentacion.Compras
{
    public partial class FrmCompra : UITemplateAccess
    {
        #region Declaracion de Variables

        DataTable dt;
        DataTable dtOrdenCompra;
        DataTable dtProveedor;
        TextFunctions ObjTextFunctions = new Utilitario.TextFunctions();

        #endregion

        #region Constructor

        public FrmCompra()
        {
            InitializeComponent();
            this.ocultarToolStrip();


        }


        #endregion

        #region Eventos de los controles

        private void Compra_Load(object sender, EventArgs e)
        {
            Configurar();
            TraerDatos();
            c1Combo.FillC1Combo1(this.CbProveedor, GetProveedor(), "RazonSocial", "IDProveedor");
        }

        private void TraerDatos()
        {
            Get_Requerimientos(AppSettings.EmpresaID);
        }

        private void BtnCompras_Click_1(object sender, EventArgs e)
        {
            if (this.C1TdbgRequerimiento.RowCount == 0)
            {
                return;
            }

            if (CbProveedor.SelectedValue == null | CboSedes.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el Proveedor y la sede donde se va a recepcionar la compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dtOrdenCompra.AcceptChanges();
            DataTable dtOrdenCompra_pdf = new DataTable();
            int ProveedorID = int.Parse(CbProveedor.SelectedValue.ToString());

            decimal Descuento = 0, Recargo = 0, Otro = 0, SubTotal = 0, PorIGV = 0;
            int DiasCredito=0;

            if(TxtDiasCredito.Text != "")
                DiasCredito = Convert.ToInt16(TxtDiasCredito.Text);
            if (Txtdescuento.Text != "")
                Descuento = Convert.ToDecimal(Txtdescuento.Text) * -1;
            if (txtRecargo.Text != "")
                Recargo = Convert.ToDecimal(txtRecargo.Text);
            if (TxtOtros.Text != "")
                Otro = Convert.ToDecimal(TxtOtros.Text);


            SubTotal = (Convert.ToDecimal(dtOrdenCompra.Compute("sum(Costo)", "")));
            PorIGV = (Convert.ToDecimal(dtOrdenCompra.Compute("sum(PorcIGV)", "")));

            //creando ObjOrdenCompra
            E_OrdenCompra ObjOrdenCompra = new E_OrdenCompra();
            ObjOrdenCompra.IDProveedor = ProveedorID;
            ObjOrdenCompra.LugarEntrega = CboSedes.SelectedValue.ToString();
            ObjOrdenCompra.Observacion = TxtObservacion.Text;
            ObjOrdenCompra.Condicion = TxtCondicion.Text;
            ObjOrdenCompra.SedeID = AppSettings.SedeID;
            ObjOrdenCompra.DiasCredito = DiasCredito;
            ObjOrdenCompra.Subtotal = SubTotal;
            ObjOrdenCompra.PorcIGV = PorIGV;
            ObjOrdenCompra.Recargo = Recargo;
            ObjOrdenCompra.Descuento = Descuento;
            ObjOrdenCompra.Otros = Otro;
            ObjOrdenCompra.UsuarioID = AppSettings.UserID;
            
            dtOrdenCompra_pdf =  new CL_OrdenCompra().InsertarCompra(dtOrdenCompra, ObjOrdenCompra,AppSettings.EmpresaID);
            string Orden_Compra = dtOrdenCompra_pdf.Rows[0]["NumOrdenCompra"].ToString();//en cualquir registro esta el num de orden decompra

            CrearPdfOC(dtOrdenCompra_pdf, Orden_Compra, CboSedes.Columns["NomSede"].Value.ToString(), ObjOrdenCompra);
            MessageBox.Show("Los registros se guardaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
            Get_Requerimientos(AppSettings.EmpresaID);
            dtOrdenCompra.Rows.Clear();
            this.CbProveedor.Text = "Seleccionar";
            CboSedes.SelectedIndex = -1;

            //limpiar textos
            txtRecargo.Text = "";
            TxtOtros.Text = "";
            TxtObservacion.Text = "";
            TxtDiasCredito.Text = "";
            Txtdescuento.Text = "";
            TxtCondicion.Text = "";
        }

        #endregion

        #region Metodos Definidos

        public DataTable GetProveedor()
        {
            dtProveedor = new DataTable();
            dtProveedor = new CL_Proveedor().GetProveedoresTipoDocumento(1);
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
            dtOrdenCompra = new DataTable();
            dtOrdenCompra.Columns.Add("NumRequerimiento", typeof(string));
            dtOrdenCompra.Columns.Add("ProductoID", typeof(string));
            dtOrdenCompra.Columns.Add("Descripcion", typeof(string));
            dtOrdenCompra.Columns.Add("UM", typeof(string));
            dtOrdenCompra.Columns.Add("NomMarca", typeof(string));
            dtOrdenCompra.Columns.Add("CantidadSolicitada", typeof(decimal));
            dtOrdenCompra.Columns.Add("Costo", typeof(decimal)).DefaultValue = 0;
            dtOrdenCompra.Columns.Add("PorcIGV", typeof(decimal)).DefaultValue = 0;
            dtOrdenCompra.Columns.Add("Total", typeof(decimal)).DefaultValue = 0;
            dtOrdenCompra.Columns["Costo"].ReadOnly =false;
            dtOrdenCompra.Columns["PorcIGV"].ReadOnly =false;
            dtOrdenCompra.Columns["Total"].ReadOnly = false;

            this.C1tdbCompra.SetDataBinding(dtOrdenCompra, "", true);
            this.C1tdbCompra.ColumnFooters = true;

            //traer sedes de la empresa
            DataTable dtUnidadNegocio = new CL_Almacen().ObtenerAlmacen(AppSettings.EmpresaID);
            DataTable dtSede = new BaseFunctions().SelectDistinct(dtUnidadNegocio, "SedeID", "NomSede");
            //agregar al combo sedes
            CboSedes.HoldFields();
            CboSedes.DataSource = dtSede;
            CboSedes.DisplayMember = "NomSede";
            CboSedes.ValueMember = "SedeID";
        }

        #endregion

        #region Creacion de PDF

        public void CrearPdfOC(DataTable dt, string NumOrdenCompra, string LugarEntrega, E_OrdenCompra ObjOrdenCompra)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (C1tdbCompra.RowCount == 0)
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

                DataView dvProveedor = new DataView(dtProveedor);
                dvProveedor.RowFilter = "IDProveedor='" + CbProveedor.SelectedValue + "'";
                string EmailProveedor = Convert.ToString(dvProveedor[0]["Email"]);
                string NomProveedor = Convert.ToString(dvProveedor[0]["RazonSocial"]);
                string RucProveedor = Convert.ToString(dvProveedor[0]["NroDocumento"]);
                string DireccionProveedor = Convert.ToString(dvProveedor[0]["Direccion"]);
                string ProveedorTelefono = Convert.ToString(dvProveedor[0]["Telefono"]);
                

                //create pdf document
                this.PdfOrdenCompra.Clear();
                this.PdfOrdenCompra.DocumentInfo.Title = "ORDEN COMPRA";


                RectangleF rcPageT = new RectangleF(200, 50, 200, 30);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                Font titleFont = new Font("Arial", 20, FontStyle.Regular);
                PdfOrdenCompra.DrawString("ORDEN COMPRA", titleFont, Brushes.Black, rcPageT, sf);
                   

                //calculate page rect (discounting margins)
                RectangleF rcPage = GetPageRect();
                RectangleF rc = rcPage;

                Image img = Properties.Resources.HalleyLogo;
                Rectangle RC = new Rectangle(30, 50, 160, 44);
                PdfOrdenCompra.DrawImage(img, RC);
                PdfOrdenCompra.DrawRectangle(Pens.White, RC);

                Rectangle RcCAbeceraIzq = new Rectangle(30, 100, 340, 45);
                Rectangle RcCAbeceraDer = new Rectangle(375, 100, 180, 45);
                Rectangle RcCAbeceraPro = new Rectangle(30, 150, 525, 45);
                
                Font detalleFont = new Font("Tahoma", 9, FontStyle.Regular);


                rc.Y = rc.Bottom + 5;
                StringFormat sfd = new StringFormat();
                sfd.Alignment = StringAlignment.Near;
                sfd.LineAlignment = StringAlignment.Near;

                StringFormat sfi = new StringFormat();
                sfi.Alignment = StringAlignment.Far;
                sfi.LineAlignment = StringAlignment.Far;

                StringBuilder sbizq = new StringBuilder();
                sbizq.Append(" " + AppSettings.NomEmpresa + "\n");
                sbizq.Append(" RUC: " + AppSettings.RUCEmpresa + "\n");
                sbizq.Append(" Dirección: " + LugarEntrega.PadRight(50,' ') + "Telefono: " + AppSettings.TelfSede);

                PdfOrdenCompra.DrawString(sbizq.ToString(), detalleFont, Brushes.Black, RcCAbeceraIzq, sfd);
                PdfOrdenCompra.DrawRectangle(Pens.Gray, RcCAbeceraIzq);

                StringBuilder sbder = new StringBuilder();
                sbder.Append(" ORDEN Nº: " + NumOrdenCompra + "\n");
                sbder.Append(" FECHA EMISIÓN: " + DateTime.Now.ToShortDateString() + "\n");
                sbder.Append(" CONDICIÓN: " + ObjOrdenCompra.Condicion + "\n");
                sbder.Append(" DIAS CREDITO: " + ObjOrdenCompra.DiasCredito + " dias");

                PdfOrdenCompra.DrawString(sbder.ToString(), detalleFont, Brushes.Black, RcCAbeceraDer, sfd);
                PdfOrdenCompra.DrawRectangle(Pens.Gray, RcCAbeceraDer);

                StringBuilder sbPro = new StringBuilder();
                sbPro.Append(" Proveedor: " + NomProveedor + "\n");
                sbPro.Append(" RUC: " + RucProveedor.PadRight(50,' ') + "Telefono: " + ProveedorTelefono + "\n");
                sbPro.Append(" Dirección: " + DireccionProveedor);

                PdfOrdenCompra.DrawString(sbPro.ToString(), detalleFont, Brushes.Black, RcCAbeceraPro, sfd);
                PdfOrdenCompra.DrawRectangle(Pens.Gray, RcCAbeceraPro);

                rc.Y = 200;
                rc = RenderTable(rc, rcPage, dt, "ProductoID", "Descripcion", "UM", "CantidadSolicitada", "Costo", "PorcIGV", "Total");

                //para los resumenes

                rc.Y += 10;

                Rectangle RcResumen = new Rectangle(Convert.ToInt16(rc.X), Convert.ToInt16(rc.Y), 525, 100);
                StringBuilder sbObs = new StringBuilder();
                sbObs.Append(" Observación:");
                PdfOrdenCompra.DrawString(sbObs.ToString(), detalleFont, Brushes.Black, RcResumen, sfd);
                PdfOrdenCompra.DrawRectangle(Pens.Gray, RcResumen);

                Rectangle RcObservacion = new Rectangle(Convert.ToInt16(rc.X + 90), Convert.ToInt16(rc.Y+5), 200, 80);
                StringBuilder sbTObs = new StringBuilder();
                sbTObs.Append(ObjOrdenCompra.Observacion);
                PdfOrdenCompra.DrawString(sbTObs.ToString(), detalleFont, Brushes.Black, RcObservacion, sfd);
                PdfOrdenCompra.DrawRectangle(Pens.Gray, RcObservacion);

                #region Calculando Valores
                decimal TOTAL = 0;

                TOTAL = ObjOrdenCompra.Subtotal + ObjOrdenCompra.PorcIGV - ObjOrdenCompra.Descuento + ObjOrdenCompra.Recargo + ObjOrdenCompra.Otros;

                #endregion

                

                Rectangle RcDetalleResumen1 = new Rectangle(Convert.ToInt16(rc.X + 295), Convert.ToInt16(rc.Y + 5), 100, 80);
                StringBuilder sbDRes1 = new StringBuilder();
                sbDRes1.Append("Sub Total : " + "\n");
                sbDRes1.Append("(-) % de Descuento : " +  "\n");
                sbDRes1.Append("(+) % de Recargo : " + "\n");
                sbDRes1.Append("(+ -) otros : " +  "\n");
                sbDRes1.Append("% I.G.V. :"+  "\n");
                sbDRes1.Append("TOTAL : ");
                PdfOrdenCompra.DrawString(sbDRes1.ToString(), detalleFont, Brushes.Black, RcDetalleResumen1, sfi);
                //PdfOrdenCompra.DrawRectangle(Pens.Gray, RcDetalleResumen1);

                Rectangle RcDetalleResumen2 = new Rectangle(Convert.ToInt16(rc.X + 395), Convert.ToInt16(rc.Y + 5), 100, 80);
                StringBuilder sbDRes2 = new StringBuilder();
                sbDRes2.Append(ObjOrdenCompra.Subtotal.ToString("C") + "\n");
                sbDRes2.Append(ObjOrdenCompra.Descuento.ToString("C") + "\n");
                sbDRes2.Append(ObjOrdenCompra.Recargo.ToString("C") + "\n");
                sbDRes2.Append(ObjOrdenCompra.Otros.ToString("C") + "\n");
                sbDRes2.Append(ObjOrdenCompra.PorcIGV.ToString("C") + "\n");
                sbDRes2.Append(TOTAL.ToString("C"));
                PdfOrdenCompra.DrawString(sbDRes2.ToString(), detalleFont, Brushes.Black, RcDetalleResumen2, sfi);
                //PdfOrdenCompra.DrawRectangle(Pens.Gray, RcDetalleResumen2);


                Rectangle RcMontoLetra = new Rectangle(Convert.ToInt16(rc.X + 20), Convert.ToInt16(rc.Y + 87), 400, 10);
                StringBuilder sbMle = new StringBuilder();
                sbMle.Append("Son: " + new TextFunctions().enletras(TOTAL.ToString()));
                PdfOrdenCompra.DrawString(sbMle.ToString() + " Nuevos Soles", detalleFont, Brushes.Black, RcMontoLetra, sfd);
                //PdfOrdenCompra.DrawRectangle(Pens.Gray, RcMontoLetra);

                //Agregar espacio para firmas

                Rectangle RcFirma = new Rectangle(Convert.ToInt16(rc.X), Convert.ToInt16(rc.Y) + 105, 525, 30);
                StringBuilder sbFir= new StringBuilder();
                sbFir.Append("\n                     Elaborado por: ___________________            Autorizado Por: ___________________");
                PdfOrdenCompra.DrawString(sbFir.ToString(), detalleFont, Brushes.Black, RcFirma, sfd);
                PdfOrdenCompra.DrawRectangle(Pens.Gray, RcFirma);

                // second pass to number pages
                AddFooters();

                //enviar correo
                string NomArchivo = NumOrdenCompra + ".pdf";
                string fileName = "D:\\ORDEN_COMPRA\\" + NomArchivo;
                this.PdfOrdenCompra.Save(fileName);
                
                string ruta = "D:\\ORDEN_COMPRA\\" + NomArchivo;

                string Asunto = "ORDEN_COMPRA " + AppSettings.NomEmpresa;
                string Mensaje = "Comprare los siguientes productos.\nAdjuntado en el pdf.";
                new CL_Helper().SendMail(Asunto, Mensaje, EmailProveedor, AppSettings.UserEmail, ruta);
                Process.Start(ruta);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        internal RectangleF RenderParagraph(string text, Font font, RectangleF rcPage, RectangleF rc, bool outline, int Tipo)
        {
            // if it won't fit this page, do a page break
            rc.Height = PdfOrdenCompra.MeasureString(text, font, rc.Width).Height;
            if (rc.Bottom > rcPage.Bottom)
            {
                PdfOrdenCompra.NewPage();
                rc.Y = rcPage.Top;
            }

            // draw the string
            StringFormat sf = new StringFormat();
            if (Tipo == 1)
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                PdfOrdenCompra.DrawString(text, font, Brushes.Black, rc, sf);
            }
            else if (Tipo == 2)
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                PdfOrdenCompra.DrawString(text, font, Brushes.Black, rc, sf);
            }
            else if (Tipo == 3)
            {
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                PdfOrdenCompra.DrawString(text, font, Brushes.Black, rc, sf);
            }


            //add headings to outline
            if (outline)
            {
                PdfOrdenCompra.DrawLine(Pens.Black, rc.X, rc.Y, rc.Right, rc.Y);
            }


            // update rectangle for next time
            rc.Offset(0, rc.Height);
            return rc;
        }


        internal RectangleF GetPageRect()
        {
            RectangleF rcPage = PdfOrdenCompra.PageRectangle;
            rcPage.Inflate(-30, -30);
            return rcPage;
        }

        private RectangleF RenderTable(RectangleF rc, RectangleF rcPage, DataTable dt, params string[] fields)
        {
            //Cargar la tabla de datos
            Font hdrFont = new Font("Arial", 8, FontStyle.Regular);
            Font txtFont = new Font("Arial", 7, FontStyle.Regular);

            rc = RenderTableHeader(hdrFont, rc, fields);
            foreach (DataRow dr in dt.Rows)
                rc = RenderTableRow(txtFont, hdrFont, rcPage, rc, fields, dr);
            return rc;
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
                float height = PdfOrdenCompra.MeasureString(field, font, rcCell.Width).Height;
                rcCell.Height = Math.Max(rcCell.Height, height);
            }

            // render header cells
            StringFormat sf = new StringFormat();

            foreach (string field in fields)
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                if (field == "ProductoID")
                    rcCell.Width = 75;
                else if (field == "Descripcion")
                    rcCell.Width = 220;
                else if (field == "UM")
                    rcCell.Width = 30;
                else if (field == "CantidadSolicitada")
                    rcCell.Width = 50;
                else if (field == "Costo")
                    rcCell.Width = 50;
                else if (field == "PorcIGV")
                    rcCell.Width = 50;
                else if (field == "Total")
                    rcCell.Width = 50;

                PdfOrdenCompra.FillRectangle(Brushes.Gray, rcCell);
                if (field == "ProductoID")
                    PdfOrdenCompra.DrawString("ID", font, Brushes.White, rcCell, sf);
                else if (field == "Descripcion")
                    PdfOrdenCompra.DrawString("Descripcion", font, Brushes.White, rcCell, sf);
                else if (field == "UM")
                    PdfOrdenCompra.DrawString("UM", font, Brushes.White, rcCell, sf);
                else if (field == "CantidadSolicitada")
                    PdfOrdenCompra.DrawString("Cantidad", font, Brushes.White, rcCell, sf);
                else if (field == "Costo")
                    PdfOrdenCompra.DrawString("Costo", font, Brushes.White, rcCell, sf);
                else if (field == "PorcIGV")
                    PdfOrdenCompra.DrawString("% IGV", font, Brushes.White, rcCell, sf);
                else if (field == "Total")
                    PdfOrdenCompra.DrawString("Total", font, Brushes.White, rcCell, sf);
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
                float height = PdfOrdenCompra.MeasureString(text, font, rcCell.Width).Height;
                rcCell.Height = Math.Max(rcCell.Height, height);
            }
            rcCell.Inflate(4, 0);

            // break page if we have to
            if (rcCell.Bottom > rcPage.Bottom)
            {
                PdfOrdenCompra.NewPage();
                rc = RenderTableHeader(hdrFont, rcPage, fields);
                rcCell.Y = rc.Y;
            }

            // center vertically just to show how
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Near;

            // render data cells
            Pen pen = new Pen(Brushes.Gray, 0.1f);
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
                if (field == "ProductoID")
                    rcCell.Width = 75;
                else if (field == "Descripcion")
                    rcCell.Width = 220;
                else if (field == "UM")
                    rcCell.Width = 30;
                else if (field == "CantidadSolicitada")
                {
                    rcCell.Width = 50;
                    sf.Alignment = StringAlignment.Far;
                }
                else if (field == "Costo")
                {
                    rcCell.Width = 50;
                    sf.Alignment = StringAlignment.Far;
                }
                else if (field == "PorcIGV")
                {
                    rcCell.Width = 50;
                    sf.Alignment = StringAlignment.Far;
                }
                else if (field == "Total")
                {
                    rcCell.Width = 50;
                    sf.Alignment = StringAlignment.Far;
                }
                PdfOrdenCompra.DrawRectangle(pen, rcCell);
                rcCell.Inflate(-4, 0);

                PdfOrdenCompra.DrawString(text, font, Brushes.Black, rcCell, sf);
                rcCell.Inflate(4, 0);
                rcCell.Offset(rcCell.Width, 0);
            }
            pen.Dispose();

            // update rectangle and return it
            rc.Offset(0, rcCell.Height);
            return rc;
        }

        private void AddFooters()
        {
            Font fontHorz = new Font("Tahoma", 7, FontStyle.Bold);

            StringFormat sfRight = new StringFormat();
            sfRight.Alignment = StringAlignment.Far;

            for (int page = 0; page < PdfOrdenCompra.Pages.Count; page++)
            {
                // select page we want (could change PageSize)
                PdfOrdenCompra.CurrentPage = page;

                // build rectangles for rendering text
                RectangleF rcPage = GetPageRect();
                RectangleF rcFooter = rcPage;
                rcFooter.Y = rcFooter.Bottom + 6;
                rcFooter.Height = 12;
                RectangleF rcVert = rcPage;
                rcVert.X = rcPage.Right + 6;

                // add left-aligned footer
                string text = AppSettings.NomSede + " - " + AppSettings.UbicacionSede + "  TEL: " + AppSettings.TelfSede;
                PdfOrdenCompra.DrawString(text, fontHorz, Brushes.Black, rcFooter);

                // add right-aligned footer
                string TextVertical = string.Format("Page {0} of {1}", page + 1, PdfOrdenCompra.Pages.Count);
                PdfOrdenCompra.DrawString(TextVertical, fontHorz, Brushes.Black, rcFooter, sfRight);

                // draw lines on bottom and right of the page
                PdfOrdenCompra.DrawLine(Pens.Black, rcPage.Left, rcPage.Bottom, rcPage.Right, rcPage.Bottom);
            }
        }

        #endregion

        private void C1tdbCompra_AfterDelete(object sender, EventArgs e)
        {
            int Count = C1tdbCompra.RowCount;
            this.C1tdbCompra.Columns[0].FooterText = "Items : " + Count.ToString();

        }

        private void C1tdbCompra_AfterColUpdate(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            Calcular();
        }

        private void Calcular()
        {
            if (C1tdbCompra.Columns["Costo"].Value + "" != "" & C1tdbCompra.Columns["PorcIGV"].Value + "" != "")
            {
                C1tdbCompra.Columns["Total"].Value = decimal.Round(Convert.ToDecimal(C1tdbCompra.Columns["Costo"].Value) + Convert.ToDecimal(C1tdbCompra.Columns["PorcIGV"].Value), 1);
            }
        }

        private void Txtdescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, Txtdescuento);
        }

        private void txtRecargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, txtRecargo);
        }

        private void TxtOtros_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtOtros);
        }

        private void TxtDiasCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.SoloNumero(sender, e, TxtDiasCredito);
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
            foreach (DataRow drow in dtOrdenCompra.Rows)
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
                row = dtOrdenCompra.NewRow();
                row["NumRequerimiento"] = Requerimiento.ToString();
                row["ProductoID"] = Codigo.ToString();
                row["Descripcion"] = Descripcion.ToString();
                row["UM"] = UM.ToString();
                row["NomMarca"] = Marca.ToString();
                row["CantidadSolicitada"] = CantidadSolicitada.ToString();
                dtOrdenCompra.Rows.Add(row);
            }
            int Count = C1tdbCompra.RowCount;
            this.C1tdbCompra.Columns[1].FooterText = "Items : " + Count.ToString();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            TraerDatos();
        }
    }
}

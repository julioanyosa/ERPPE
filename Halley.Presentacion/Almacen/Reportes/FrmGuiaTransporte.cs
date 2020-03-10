using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;
using Halley.Utilitario;
using System.Drawing.Printing;
using System.Configuration;

namespace Halley.Presentacion.Almacen
{
    public partial class FrmGuiaTransporte : Form
    {
        string ImpresoraGuiaTransportista = AppSettings.ImpresoraGuiaTransportista;
        CL_GuiaTransportista ObjCL_GuiaTransportista = new CL_GuiaTransportista();
        /// <summary>
        ///Variable utilizada cuando se genere una venta diferida
        private string _TipoGuia = null;

        public string TipoGuia
        {
            get { return _TipoGuia; }
            set { _TipoGuia = value; }
        }
        #region propiedades
        /// </summary>
        private string _NumGuiaTransportista;
        DataTable _DtCabecera;
        DataTable _DtDetalle;
        public DataTable DtCabecera
        {
            get { return _DtCabecera; }
            set { _DtCabecera = value; }
        }
        public DataTable DtDetalle
        {
            get { return _DtDetalle; }
            set { _DtDetalle = value; }
        }
        public string NumGuiaTransportista
        {
            get { return _NumGuiaTransportista; }
            set { _NumGuiaTransportista = value; }
        }
        #endregion
        public FrmGuiaTransporte()
        {
            InitializeComponent();
        }

        private void FrmGuiaTransporte_Load(object sender, EventArgs e)
        {
            if (NumGuiaTransportista + "" != "")
            {
                Cursor = Cursors.WaitCursor;
                TxtGuia.Text = NumGuiaTransportista;
                MostrarGuia(TxtGuia.Text);
                if (TxtGuia.Text.Substring(0, 2) == "IH")
                    CboTipoGuia.SelectedIndex = 0;
                else if (TxtGuia.Text.Substring(0, 2) == "CH")
                    CboTipoGuia.SelectedIndex = 1;
                else if (TxtGuia.Text.Substring(0, 2) == "GH")
                    CboTipoGuia.SelectedIndex = 2;
                else if (TxtGuia.Text.Substring(0, 2) == "TP")
                    CboTipoGuia.SelectedIndex = 3;
                Cursor = Cursors.Default;
            }
        }

        private void MostrarGuia(string NumGuia)
        {
            #region limpiar
            //Recorremos todos los textos y los limpiamos

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is C1.Win.C1Input.C1TextBox)
                {
                    C1.Win.C1Input.C1TextBox t = ctrl as C1.Win.C1Input.C1TextBox;
                    t.Text = "";
                }
                else if (ctrl is ToolStripContainer)
                {
                    foreach (Control c in ctrl.Controls)
                    {
                        if (c is ToolStripContentPanel)
                        {
                            foreach (Control d in c.Controls)
                            {
                                if (d is C1.Win.C1Input.C1TextBox)
                                {
                                    C1.Win.C1Input.C1TextBox t = d as C1.Win.C1Input.C1TextBox;
                                    t.Text = "";
                                }
                            }
                        }
                    }
                }
            }

            //Limpiar listas
            LstProducto.Items.Clear();
            LstUM.Items.Clear();
            LstPeso.Items.Clear();
            LstCantidad.Items.Clear();
            #endregion

            if (DtCabecera == null)//no se le paso datos de la guia
            {
                DtCabecera = ObjCL_GuiaTransportista.GetCabeceraGuiaTransportista(NumGuia);
            }
            else if (DtCabecera.Rows.Count == 0)
            {
                DtCabecera = ObjCL_GuiaTransportista.GetCabeceraGuiaTransportista(NumGuia);
            }

            #region Cabecera
            if (DtCabecera != null && DtCabecera.Rows.Count > 0)
            {
                if (DtDetalle == null)//no se le paso datos de la guia
                {
                    TipoGuia = DtCabecera.Rows[0]["TipoGuia"].ToString();//tipo de guia, segun eso trae los detalles (venta o interna)
                    DtDetalle = ObjCL_GuiaTransportista.GetDetalleGuiaTransportista(NumGuia, TipoGuia);
                }
                else if (DtDetalle.Rows.Count == 0)
                {
                    TipoGuia = DtCabecera.Rows[0]["TipoGuia"].ToString();//tipo de guia, segun eso trae los detalles (venta o interna)
                    DtDetalle = ObjCL_GuiaTransportista.GetDetalleGuiaTransportista(NumGuia, TipoGuia);
                }


                TxtEmpresa.Text = AppSettings.NomEmpresa;
                LblDireccion.Text = "Direccion del Lugar";
                TxtFechaEmision.Text = DateTime.Now.Date.ToString().Substring(0, 10);
                TxtRuc.Text = AppSettings.RUCEmpresa;
                TxtNumGuiatransporte.Text = DtCabecera.Rows[0]["NumGuiaTransportista"].ToString().Substring(2);
                TxtFechaInicioTraslado.Text = DtCabecera.Rows[0]["FechaSalida"].ToString().Substring(0,10);
                TxtDomicilioPartida.Text = DtCabecera.Rows[0]["DomicilioPartida"].ToString();
                TxtNroDomicilioPartida.Text = DtCabecera.Rows[0]["NroDomicilioPartida"].ToString();
                TxtIntDomicilioPartida.Text = DtCabecera.Rows[0]["IntDomicilioPartida"].ToString();
                TxtZonaDomicilioPartida.Text = DtCabecera.Rows[0]["ZonaDomicilioPartida"].ToString();
                TxtDisDomicilioPartida.Text = DtCabecera.Rows[0]["DisDomicilioPartida"].ToString();
                TxtProvDomicilioPartida.Text = DtCabecera.Rows[0]["ProvDomicilioPartida"].ToString();
                TxtDepDomicilioPartida.Text = DtCabecera.Rows[0]["DepDomicilioPartida"].ToString();
                TxtDomicilioLlegada.Text = DtCabecera.Rows[0]["DomicilioLlegada"].ToString();
                TxtNroDomicilioLlegada.Text = DtCabecera.Rows[0]["NroDomicilioLlegada"].ToString();
                TxtIntDomicilioLlegada.Text = DtCabecera.Rows[0]["IntDomicilioLlegada"].ToString();
                TxtZonaDomicilioLlegada.Text = DtCabecera.Rows[0]["ZonaDomicilioLlegada"].ToString();
                TxtDisDomicilioLlegada.Text = DtCabecera.Rows[0]["DisDomicilioLlegada"].ToString();
                TxtProvDomicilioLlegada.Text = DtCabecera.Rows[0]["ProvDomicilioLlegada"].ToString();
                TxtDepDomicilioLlegada.Text = DtCabecera.Rows[0]["DepDomicilioLlegada"].ToString();
                TxtRemitente.Text = DtCabecera.Rows[0]["Remitente"].ToString();
                TxtRUCRemitente.Text = DtCabecera.Rows[0]["RUCRemitente"].ToString();
                TxtDireccionRemitente.Text = DtCabecera.Rows[0]["DireccionRemitente"].ToString();
                TxtDestinatario.Text = DtCabecera.Rows[0]["Destinatario"].ToString();
                TxtRUCDestinatario.Text = DtCabecera.Rows[0]["RUCDestinatario"].ToString();
                TxtDireccionDestinatario.Text = DtCabecera.Rows[0]["DireccionDestinatario"].ToString();
                TxtConfVehicular.Text = DtCabecera.Rows[0]["ConfiguracionVehicular"].ToString();
                TxtMarca.Text = DtCabecera.Rows[0]["Marca"].ToString();
                TxtPlaca.Text = DtCabecera.Rows[0]["Placa"].ToString();
                TxtCarrosa.Text = DtCabecera.Rows[0]["Carrosa"].ToString();
                TxtNroConstInscripcion.Text = DtCabecera.Rows[0]["NroConstInscripcion"].ToString();
                TxtNroLicTransaportista.Text = DtCabecera.Rows[0]["NroLicTransportista"].ToString();
                TxtNombreChofer.Text = DtCabecera.Rows[0]["NombreChofer"].ToString();

                //estado de la guia
                int EstadoID;
                EstadoID = Convert.ToInt16(DtCabecera.Rows[0]["EstadoID"]);

                if (EstadoID == 0)
                {
                    LblEstado.Text = "PLANEADO";
                    LblEstado.ForeColor = Color.Blue;
                    BtnAnular.Visible = true;
                }
                else if (EstadoID == 10)
                {
                    LblEstado.Text = "ANULADO";
                    LblEstado.ForeColor = Color.Red;
                    BtnAnular.Visible = false;
                }
                else if (EstadoID == 11)
                {
                    LblEstado.Text = "CERRADO";
                    LblEstado.ForeColor = Color.Blue;
                    BtnAnular.Visible = false;
                }
            }
            else
                BtnAnular.Visible = false;
            #endregion

            #region Detalles

            //filtrar los productos en una nueva tabla
            if (DtCabecera.Rows.Count > 0)
            {
                DataTable DtDetalleFiltrado = new DataTable();
                DtDetalleFiltrado = new BaseFunctions().SelectDistinct(DtDetalle, "ProductoID");


                foreach (DataRow Row in DtDetalleFiltrado.Rows)
                {
                    string ProductoID = Row["ProductoID"].ToString();

                    //filtrar tabla para agrupar los datos por producto
                    DataView DvDetallefiltro = new DataView(DtDetalle);
                    DvDetallefiltro.RowFilter = "ProductoID = '" + ProductoID + "'";

                    string NomProducto;
                    string UnidadMedidaID;
                    decimal Peso = 0;
                    decimal CantidadEnviada = 0;
                    //decimal costo = 0;

                    ProductoID = DvDetallefiltro[0]["ProductoID"].ToString();
                    NomProducto = DvDetallefiltro[0]["NomProducto"].ToString();
                    UnidadMedidaID = DvDetallefiltro[0]["UnidadMedidaID"].ToString();

                    foreach (DataRowView Drv in DvDetallefiltro)
                    {
                        Peso += Convert.ToDecimal(Drv["PesoNeto"]);
                        CantidadEnviada += Convert.ToDecimal(Drv["CantidadEnviada"]);
                    }

                    LstProducto.Items.Add(NomProducto);
                    LstUM.Items.Add(UnidadMedidaID);
                    LstPeso.Items.Add(Peso);
                    LstCantidad.Items.Add(CantidadEnviada);
                    //LstCostoMinimo.Items.Add(costo);

                }
            }
            #endregion
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (CboTipoGuia.SelectedIndex == -1) //industria
            {
                MessageBox.Show("Primero debe seleccionar el formato de la guia a imprimir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
                printDocument1.Print(); 

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            #region novale
            //recorremos todas las cajas de texto y las imprimimos
            /*foreach (Control ctrl in this.Controls)
            {
                if (ctrl is C1.Win.C1Input.C1TextBox)
                {
                    C1.Win.C1Input.C1TextBox t = ctrl as C1.Win.C1Input.C1TextBox;
                    e.Graphics.DrawString(ctrl.Text, ctrl.Font, Brushes.Black, ctrl.Location.X, ctrl.Location.Y);
                }
                else if (ctrl is ToolStripContainer)
                {
                    foreach (Control c in ctrl.Controls)
                    {
                        if (c is ToolStripContentPanel)
                        {
                            foreach (Control d in c.Controls)
                            {
                                if (d is C1.Win.C1Input.C1TextBox)
                                {
                                    C1.Win.C1Input.C1TextBox t = d as C1.Win.C1Input.C1TextBox;
                                    e.Graphics.DrawString(t.Text, t.Font, Brushes.Black, t.Location.X, t.Location.Y);
                                }
                                if (d is ListBox)
                                {
                                    ListBox t = d as ListBox;
                                    int sum = 0;
                                    for (int x = 0; x < t.Items.Count; x++)
                                    {
                                        sum+=12;
                                        e.Graphics.DrawString(t.Items[x].ToString(), t.Font, Brushes.Black, t.Location.X, t.Location.Y + sum);
                                    }
                                    
                                }
                            }
                        }
                    }
                }
            }*/
            #endregion

            //tamaño de la boleta
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("GuiaTransporte", 840, 830);
            printDocument1.DefaultPageSettings.Margins.Left = 0;
            printDocument1.DefaultPageSettings.Margins.Right = 0;
            printDocument1.DefaultPageSettings.Margins.Top = 0;
            printDocument1.DefaultPageSettings.Margins.Bottom = 0;
            printDocument1.OriginAtMargins = true;

            //formato para alinear los nuimeros a la derecha
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;

            if (CboTipoGuia.SelectedIndex == 0) //industria
            {
                #region Imprimir tipo Industria
                e.Graphics.DrawString(TxtFechaEmision.Text, TxtFechaEmision.Font, Brushes.Black, 130, 164);
                e.Graphics.DrawString(TxtNumGuiatransporte.Text, TxtFechaEmision.Font, Brushes.Black, 600, 160);
                e.Graphics.DrawString(TxtFechaInicioTraslado.Text, TxtFechaEmision.Font, Brushes.Black, 300, 164);

                e.Graphics.DrawString(TxtDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 85, 215);
                e.Graphics.DrawString(TxtNroDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 255, 240);
                e.Graphics.DrawString(TxtIntDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 323, 240);
                e.Graphics.DrawString(TxtZonaDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 372, 240);
                e.Graphics.DrawString(TxtDisDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 100, 265);
                e.Graphics.DrawString(TxtProvDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 230, 265);
                e.Graphics.DrawString(TxtDepDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 355, 265);

                e.Graphics.DrawString(TxtDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 480, 215);
                e.Graphics.DrawString(TxtNroDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 630, 240);
                e.Graphics.DrawString(TxtIntDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 705, 240);
                e.Graphics.DrawString(TxtZonaDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 760, 240);
                e.Graphics.DrawString(TxtDisDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 490, 265);
                e.Graphics.DrawString(TxtProvDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 630, 265);
                e.Graphics.DrawString(TxtDepDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 730, 265);

                e.Graphics.DrawString(TxtRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 95, 315);
                e.Graphics.DrawString(TxtRUCRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 95, 332);
                //e.Graphics.DrawString(TxtDireccionRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 110, 356);
                e.Graphics.DrawString(TxtNumDocRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 255, 356);

                e.Graphics.DrawString(TxtDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 490, 315);
                e.Graphics.DrawString(TxtRUCDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 490, 332);
                //e.Graphics.DrawString(TxtDireccionDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 505, 356);
                e.Graphics.DrawString(TxtNumDocDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 635, 356);

                e.Graphics.DrawString(TxtMarca.Text, TxtFechaEmision.Font, Brushes.Black, 155, 600);
                e.Graphics.DrawString(TxtPlaca.Text, TxtFechaEmision.Font, Brushes.Black, 100, 624);
                e.Graphics.DrawString(TxtConfVehicular.Text, TxtFechaEmision.Font, Brushes.Black, 180, 636);
                e.Graphics.DrawString(TxtNroConstInscripcion.Text, TxtFechaEmision.Font, Brushes.Black, 220, 654);
                e.Graphics.DrawString(TxtNroLicTransaportista.Text, TxtFechaEmision.Font, Brushes.Black, 210, 674);

                e.Graphics.DrawString(TxtRazonSocialSub.Text, TxtFechaEmision.Font, Brushes.Black, 370, 618);
                e.Graphics.DrawString(txtRUCSub.Text, TxtFechaEmision.Font, Brushes.Black, 400, 667);

                e.Graphics.DrawString(TxtRUCEP.Text, TxtFechaEmision.Font, Brushes.Black, 600, 600);
                e.Graphics.DrawString(TxtNumDocEP.Text, TxtFechaEmision.Font, Brushes.Black, 710, 624);
                e.Graphics.DrawString(TxtApellidosEP.Text, TxtFechaEmision.Font, Brushes.Black, 580, 670);

                e.Graphics.DrawString(TxtObservaciones.Text, TxtFechaEmision.Font, Brushes.Black, 155, 714);

                #region Imprimir los Detalles

                //filtrar los productos en una nueva tabla
                if (DtCabecera.Rows.Count > 0)
                {
                    DataTable DtDetalleFiltrado = new DataTable();
                    DtDetalleFiltrado = new BaseFunctions().SelectDistinct(DtDetalle, "ProductoID");

                    int sum = 0;
                    foreach (DataRow Row in DtDetalleFiltrado.Rows)
                    {
                        string ProductoID = Row["ProductoID"].ToString();

                        //filtrar tabla para agrupar los datos por producto
                        DataView DvDetallefiltro = new DataView(DtDetalle);
                        DvDetallefiltro.RowFilter = "ProductoID = '" + ProductoID + "'";

                        string NomProducto;
                        string UnidadMedidaID;
                        decimal Peso = 0;
                        decimal CantidadEnviada = 0;
                        //decimal costo = 0;

                        ProductoID = DvDetallefiltro[0]["ProductoID"].ToString();
                        NomProducto = DvDetallefiltro[0]["NomProducto"].ToString();
                        UnidadMedidaID = DvDetallefiltro[0]["UnidadMedidaID"].ToString();

                        foreach (DataRowView Drv in DvDetallefiltro)
                        {
                            Peso += Convert.ToDecimal(Drv["PesoNeto"]);
                            CantidadEnviada += Convert.ToDecimal(Drv["CantidadEnviada"]);
                        }

                        sum += 20;
                        e.Graphics.DrawString(NomProducto, TxtFechaEmision.Font, Brushes.Black, 104, 387 + sum);
                        e.Graphics.DrawString(UnidadMedidaID, TxtFechaEmision.Font, Brushes.Black, 702, 387 + sum, formato);
                        e.Graphics.DrawString(CantidadEnviada.ToString("#,##0"), TxtFechaEmision.Font, Brushes.Black, 590, 387 + sum, formato);
                        e.Graphics.DrawString(Peso.ToString("#,##0"), TxtFechaEmision.Font, Brushes.Black, 658, 387 + sum, formato);
                    }
                }
                #endregion

                #endregion
            }

            if (CboTipoGuia.SelectedIndex == 1) //Comercial
            {
                #region Imprimir tipo Comercial
                e.Graphics.DrawString(TxtFechaEmision.Text, TxtFechaEmision.Font, Brushes.Black, 100, 154);
                e.Graphics.DrawString(TxtNumGuiatransporte.Text, TxtFechaEmision.Font, Brushes.Black, 600, 155);
                e.Graphics.DrawString(TxtFechaInicioTraslado.Text, TxtFechaEmision.Font, Brushes.Black, 285, 154);

                e.Graphics.DrawString(TxtDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 85, 200);
                e.Graphics.DrawString(TxtNroDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 80, 220);
                e.Graphics.DrawString(TxtIntDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 255, 220);
                e.Graphics.DrawString(TxtZonaDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 355, 220);
                e.Graphics.DrawString(TxtDisDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 100, 248);
                e.Graphics.DrawString(TxtProvDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 230, 248);
                e.Graphics.DrawString(TxtDepDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 355, 248);

                e.Graphics.DrawString(TxtDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 480, 200);
                e.Graphics.DrawString(TxtNroDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 470, 220);
                e.Graphics.DrawString(TxtIntDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 630, 220);
                e.Graphics.DrawString(TxtZonaDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 750, 220);
                e.Graphics.DrawString(TxtDisDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 490, 248);
                e.Graphics.DrawString(TxtProvDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 630, 248);
                e.Graphics.DrawString(TxtDepDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 750, 248);

                e.Graphics.DrawString(TxtRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 95, 300);
                e.Graphics.DrawString(TxtRUCRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 95, 322);
                e.Graphics.DrawString(TxtDireccionRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 110, 336);
                e.Graphics.DrawString(TxtNumDocRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 265, 350);

                e.Graphics.DrawString(TxtDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 490, 300);
                e.Graphics.DrawString(TxtRUCDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 490, 322);
                e.Graphics.DrawString(TxtDireccionDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 505, 336);
                e.Graphics.DrawString(TxtNumDocDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 655, 350);

                e.Graphics.DrawString(TxtMarca.Text, TxtFechaEmision.Font, Brushes.Black, 155, 600);
                e.Graphics.DrawString(TxtPlaca.Text, TxtFechaEmision.Font, Brushes.Black, 100, 618);
                e.Graphics.DrawString(TxtConfVehicular.Text, TxtFechaEmision.Font, Brushes.Black, 180, 636);
                e.Graphics.DrawString(TxtNroConstInscripcion.Text, TxtFechaEmision.Font, Brushes.Black, 220, 654);
                e.Graphics.DrawString(TxtNroLicTransaportista.Text, TxtFechaEmision.Font, Brushes.Black, 210, 672);

                e.Graphics.DrawString(TxtRazonSocialSub.Text, TxtFechaEmision.Font, Brushes.Black, 370, 618);
                e.Graphics.DrawString(txtRUCSub.Text, TxtFechaEmision.Font, Brushes.Black, 350, 667);

                e.Graphics.DrawString(TxtRUCEP.Text, TxtFechaEmision.Font, Brushes.Black, 600, 600);
                e.Graphics.DrawString(TxtNumDocEP.Text, TxtFechaEmision.Font, Brushes.Black, 710, 620);
                e.Graphics.DrawString(TxtApellidosEP.Text, TxtFechaEmision.Font, Brushes.Black, 618, 660);

                e.Graphics.DrawString(TxtObservaciones.Text, TxtFechaEmision.Font, Brushes.Black, 155, 704);

                #region Imprimir los Detalles

                //filtrar los productos en una nueva tabla
                if (DtCabecera.Rows.Count > 0)
                {
                    DataTable DtDetalleFiltrado = new DataTable();
                    DtDetalleFiltrado = new BaseFunctions().SelectDistinct(DtDetalle, "ProductoID");

                    int sum = 0;
                    foreach (DataRow Row in DtDetalleFiltrado.Rows)
                    {
                        string ProductoID = Row["ProductoID"].ToString();

                        //filtrar tabla para agrupar los datos por producto
                        DataView DvDetallefiltro = new DataView(DtDetalle);
                        DvDetallefiltro.RowFilter = "ProductoID = '" + ProductoID + "'";

                        string NomProducto;
                        string UnidadMedidaID;
                        decimal Peso = 0;
                        decimal CantidadEnviada = 0;
                        //decimal costo = 0;

                        ProductoID = DvDetallefiltro[0]["ProductoID"].ToString();
                        NomProducto = DvDetallefiltro[0]["NomProducto"].ToString();
                        UnidadMedidaID = DvDetallefiltro[0]["UnidadMedidaID"].ToString();

                        foreach (DataRowView Drv in DvDetallefiltro)
                        {
                            Peso += Convert.ToDecimal(Drv["PesoNeto"]);
                            CantidadEnviada += Convert.ToDecimal(Drv["CantidadEnviada"]);
                        }

                        sum += 20;
                        e.Graphics.DrawString(NomProducto, TxtFechaEmision.Font, Brushes.Black, 104, 392 + sum);
                        e.Graphics.DrawString(UnidadMedidaID, TxtFechaEmision.Font, Brushes.Black, 727, 392 + sum, formato);
                        e.Graphics.DrawString(CantidadEnviada.ToString("#,##0"), TxtFechaEmision.Font, Brushes.Black, 605, 392 + sum, formato);
                        e.Graphics.DrawString(Peso.ToString("#,##0"), TxtFechaEmision.Font, Brushes.Black, 673, 392 + sum, formato);
                    }
                }
                #endregion

                #endregion
            }

            if (CboTipoGuia.SelectedIndex == 2) //granja
            {
                #region Imprimir tipo Granja
                e.Graphics.DrawString(TxtFechaEmision.Text, TxtFechaEmision.Font, Brushes.Black, 100, 167);
                e.Graphics.DrawString(TxtNumGuiatransporte.Text, TxtFechaEmision.Font, Brushes.Black, 600, 163);
                e.Graphics.DrawString(TxtFechaInicioTraslado.Text, TxtFechaEmision.Font, Brushes.Black, 270, 167);

                e.Graphics.DrawString(TxtDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 85, 218);
                e.Graphics.DrawString(TxtNroDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 255, 243);
                e.Graphics.DrawString(TxtIntDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 323, 243);
                e.Graphics.DrawString(TxtZonaDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 372, 243);
                e.Graphics.DrawString(TxtDisDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 100, 268);
                e.Graphics.DrawString(TxtProvDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 230, 268);
                e.Graphics.DrawString(TxtDepDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 355, 268);

                e.Graphics.DrawString(TxtDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 480, 218);
                e.Graphics.DrawString(TxtNroDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 630, 243);
                e.Graphics.DrawString(TxtIntDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 705, 243);
                e.Graphics.DrawString(TxtZonaDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 760, 243);
                e.Graphics.DrawString(TxtDisDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 490, 268);
                e.Graphics.DrawString(TxtProvDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 630, 268);
                e.Graphics.DrawString(TxtDepDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 730, 268);

                e.Graphics.DrawString(TxtRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 95, 318);
                e.Graphics.DrawString(TxtRUCRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 95, 335);
                //e.Graphics.DrawString(TxtDireccionRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 110, 356);
                e.Graphics.DrawString(TxtNumDocRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 255, 359);

                e.Graphics.DrawString(TxtDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 490, 318);
                e.Graphics.DrawString(TxtRUCDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 490, 335);
                //e.Graphics.DrawString(TxtDireccionDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 505, 356);
                e.Graphics.DrawString(TxtNumDocDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 635, 359);

                e.Graphics.DrawString(TxtMarca.Text, TxtFechaEmision.Font, Brushes.Black, 155, 603);
                e.Graphics.DrawString(TxtPlaca.Text, TxtFechaEmision.Font, Brushes.Black, 100, 627);
                e.Graphics.DrawString(TxtConfVehicular.Text, TxtFechaEmision.Font, Brushes.Black, 180, 639);
                e.Graphics.DrawString(TxtNroConstInscripcion.Text, TxtFechaEmision.Font, Brushes.Black, 220, 657);
                e.Graphics.DrawString(TxtNroLicTransaportista.Text, TxtFechaEmision.Font, Brushes.Black, 210, 677);

                e.Graphics.DrawString(TxtRazonSocialSub.Text, TxtFechaEmision.Font, Brushes.Black, 370, 621);
                e.Graphics.DrawString(txtRUCSub.Text, TxtFechaEmision.Font, Brushes.Black, 400, 670);

                e.Graphics.DrawString(TxtRUCEP.Text, TxtFechaEmision.Font, Brushes.Black, 600, 603);
                e.Graphics.DrawString(TxtNumDocEP.Text, TxtFechaEmision.Font, Brushes.Black, 710, 627);
                e.Graphics.DrawString(TxtApellidosEP.Text, TxtFechaEmision.Font, Brushes.Black, 580, 673);

                e.Graphics.DrawString(TxtObservaciones.Text, TxtFechaEmision.Font, Brushes.Black, 155, 717);

                #region Imprimir los Detalles

                //filtrar los productos en una nueva tabla
                if (DtCabecera.Rows.Count > 0)
                {
                    DataTable DtDetalleFiltrado = new DataTable();
                    DtDetalleFiltrado = new BaseFunctions().SelectDistinct(DtDetalle, "ProductoID");

                    int sum = 0;
                    foreach (DataRow Row in DtDetalleFiltrado.Rows)
                    {
                        string ProductoID = Row["ProductoID"].ToString();

                        //filtrar tabla para agrupar los datos por producto
                        DataView DvDetallefiltro = new DataView(DtDetalle);
                        DvDetallefiltro.RowFilter = "ProductoID = '" + ProductoID + "'";

                        string NomProducto;
                        string UnidadMedidaID;
                        decimal Peso = 0;
                        decimal CantidadEnviada = 0;
                        //decimal costo = 0;

                        ProductoID = DvDetallefiltro[0]["ProductoID"].ToString();
                        NomProducto = DvDetallefiltro[0]["NomProducto"].ToString();
                        UnidadMedidaID = DvDetallefiltro[0]["UnidadMedidaID"].ToString();

                        foreach (DataRowView Drv in DvDetallefiltro)
                        {
                            Peso += Convert.ToDecimal(Drv["PesoNeto"]);
                            CantidadEnviada += Convert.ToDecimal(Drv["CantidadEnviada"]);
                        }

                        sum += 20;
                        e.Graphics.DrawString(NomProducto, TxtFechaEmision.Font, Brushes.Black, 104, 390 + sum);
                        e.Graphics.DrawString(UnidadMedidaID, TxtFechaEmision.Font, Brushes.Black, 702, 390 + sum, formato);
                        e.Graphics.DrawString(CantidadEnviada.ToString("#,##0"), TxtFechaEmision.Font, Brushes.Black, 590, 390 + sum, formato);
                        e.Graphics.DrawString(Peso.ToString("#,##0"), TxtFechaEmision.Font, Brushes.Black, 658, 390 + sum, formato);
                    }
                }
                #endregion

                #endregion
            }

            if (CboTipoGuia.SelectedIndex == 3) //Palavi
            {
                #region Imprimir tipo Palavi
                e.Graphics.DrawString(TxtFechaEmision.Text.Substring(0, 2), TxtFechaEmision.Font, Brushes.Black, 95, 220);
                e.Graphics.DrawString(TxtFechaEmision.Text.Substring(3, 2), TxtFechaEmision.Font, Brushes.Black, 135, 220);
                e.Graphics.DrawString(TxtFechaEmision.Text.Substring(6), TxtFechaEmision.Font, Brushes.Black, 175, 220);
                e.Graphics.DrawString(TxtNumGuiatransporte.Text, TxtFechaEmision.Font, Brushes.Black, 600, 220);
                e.Graphics.DrawString(TxtFechaInicioTraslado.Text.Substring(0, 2), TxtFechaEmision.Font, Brushes.Black, 300, 220);
                e.Graphics.DrawString(TxtFechaInicioTraslado.Text.Substring(3, 2), TxtFechaEmision.Font, Brushes.Black, 340, 220);
                e.Graphics.DrawString(TxtFechaInicioTraslado.Text.Substring(6), TxtFechaEmision.Font, Brushes.Black, 380, 220);

                e.Graphics.DrawString(TxtDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 85, 265);
                e.Graphics.DrawString(TxtNroDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 65, 285);
                e.Graphics.DrawString(TxtIntDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 220, 285);
                e.Graphics.DrawString(TxtZonaDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 310, 285);
                e.Graphics.DrawString(TxtDisDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 80, 302);
                e.Graphics.DrawString(TxtProvDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 190, 302);
                e.Graphics.DrawString(TxtDepDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 305, 302);

                e.Graphics.DrawString(TxtDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 480, 265);
                e.Graphics.DrawString(TxtNroDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 470, 285);
                e.Graphics.DrawString(TxtIntDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 630, 285);
                e.Graphics.DrawString(TxtZonaDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 750, 285);
                e.Graphics.DrawString(TxtDisDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 470, 302);
                e.Graphics.DrawString(TxtProvDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 585, 302);
                e.Graphics.DrawString(TxtDepDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 690, 302);

                e.Graphics.DrawString(TxtRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 50, 365);
                e.Graphics.DrawString(TxtRUCRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 190, 388);
                //e.Graphics.DrawString(TxtDireccionRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 110, 336);
                //e.Graphics.DrawString(TxtNumDocRemitente.Text, TxtFechaEmision.Font, Brushes.Black, 265, 350);

                e.Graphics.DrawString(TxtDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 430, 365);
                e.Graphics.DrawString(TxtRUCDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 570, 388);
                //e.Graphics.DrawString(TxtDireccionDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 505, 336);
                //e.Graphics.DrawString(TxtNumDocDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 655, 350);

                e.Graphics.DrawString(TxtMarca.Text, TxtFechaEmision.Font, Brushes.Black, 145, 646);
                e.Graphics.DrawString(TxtPlaca.Text, TxtFechaEmision.Font, Brushes.Black, 100, 662);
                e.Graphics.DrawString(TxtConfVehicular.Text, TxtFechaEmision.Font, Brushes.Black, 160, 675);
                e.Graphics.DrawString(TxtNroConstInscripcion.Text, TxtFechaEmision.Font, Brushes.Black, 160, 691);
                e.Graphics.DrawString(TxtNombreChofer.Text, TxtFechaEmision.Font, Brushes.Black, 145, 707);
                e.Graphics.DrawString(TxtNroLicTransaportista.Text, TxtFechaEmision.Font, Brushes.Black, 165, 722);

                e.Graphics.DrawString(TxtRazonSocialSub.Text, TxtFechaEmision.Font, Brushes.Black, 310, 670);
                e.Graphics.DrawString(txtRUCSub.Text, TxtFechaEmision.Font, Brushes.Black, 330, 683);

                e.Graphics.DrawString(TxtRUCEP.Text, TxtFechaEmision.Font, Brushes.Black, 670, 663);
                //e.Graphics.DrawString(TxtNumDocEP.Text, TxtFechaEmision.Font, Brushes.Black, 710, 655);
                e.Graphics.DrawString(TxtApellidosEP.Text, TxtFechaEmision.Font, Brushes.Black, 575, 643);

                e.Graphics.DrawString(TxtObservaciones.Text, TxtFechaEmision.Font, Brushes.Black, 150, 740);

                #region Imprimir los Detalles

                //filtrar los productos en una nueva tabla
                if (DtCabecera.Rows.Count > 0)
                {
                    DataTable DtDetalleFiltrado = new DataTable();
                    DtDetalleFiltrado = new BaseFunctions().SelectDistinct(DtDetalle, "ProductoID");

                    int sum = 0;
                    foreach (DataRow Row in DtDetalleFiltrado.Rows)
                    {
                        string ProductoID = Row["ProductoID"].ToString();

                        //filtrar tabla para agrupar los datos por producto
                        DataView DvDetallefiltro = new DataView(DtDetalle);
                        DvDetallefiltro.RowFilter = "ProductoID = '" + ProductoID + "'";

                        string NomProducto;
                        string UnidadMedidaID;
                        decimal Peso = 0;
                        decimal CantidadEnviada = 0;
                        //decimal costo = 0;

                        ProductoID = DvDetallefiltro[0]["ProductoID"].ToString();
                        NomProducto = DvDetallefiltro[0]["NomProducto"].ToString();
                        UnidadMedidaID = DvDetallefiltro[0]["UnidadMedidaID"].ToString();

                        foreach (DataRowView Drv in DvDetallefiltro)
                        {
                            Peso += Convert.ToDecimal(Drv["PesoNeto"]);
                            CantidadEnviada += Convert.ToDecimal(Drv["CantidadEnviada"]);
                        }

                        sum += 20;
                        e.Graphics.DrawString(NomProducto, TxtFechaEmision.Font, Brushes.Black, 170, 407 + sum);
                        e.Graphics.DrawString(UnidadMedidaID, TxtFechaEmision.Font, Brushes.Black, 135, 407 + sum, formato);
                        e.Graphics.DrawString(CantidadEnviada.ToString("#,##0"), TxtFechaEmision.Font, Brushes.Black, 98, 407 + sum, formato);
                        e.Graphics.DrawString(Peso.ToString("#,##0"), TxtFechaEmision.Font, Brushes.Black, 683, 407 + sum, formato);
                    }
                }
                #endregion

                #endregion
            }

        }

        private void BtnConsultar_Click_1(object sender, EventArgs e)
        {
            if (TxtGuia.Text != "")
            {
                if(DtCabecera != null)
                    DtCabecera.Rows.Clear();
                if(DtDetalle != null)
                DtDetalle.Rows.Clear();
                MostrarGuia(TxtGuia.Text);
            }
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea anular la guia de transporte Nro: " + TxtNumGuiatransporte.Text + ".?", "Guia de remisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CL_GuiaRemision objCL_GuiaRemision = new CL_GuiaRemision();
                bool Valor;
                Valor = objCL_GuiaRemision.UpdateGuiaRemisionEstado(TxtGuia.Text, 10, "T", AppSettings.UserID, AppSettings.SedeID);
            }
        }

        private void BtnVistaPrevia_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            //printDialog1.AllowSelection = true;
            //printDialog1.AllowSomePages = true;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                ImpresoraGuiaTransportista = printDialog1.PrinterSettings.PrinterName;
                //*****************guardar la configuracion de la impresora en el appconfig**************
                if (ImpresoraGuiaTransportista != AppSettings.ImpresoraGuiaTransportista & ImpresoraGuiaTransportista != "")
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    AppSettingsSection appSettings = config.AppSettings;

                    KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraGuiaTransportista"];
                    setting.Value = ImpresoraGuiaTransportista;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                //************************ fin guardar configuracion ***************************************

            }
        }


        
    }
     
}

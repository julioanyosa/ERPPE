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
    public partial class FrmGuiaRemision : Form
    {
        string ImpresoraGuiaRemitente = AppSettings.ImpresoraGuiaRemitente;
        CL_GuiaRemision ObjCL_GuiaRemision = new CL_GuiaRemision();
        #region propiedades
        private string _NumGuiaRemision;
        DataTable _DtCabecera;
        DataTable _DtDetalle;
        ///Variable utilizada cuando se genere una venta diferida
        private string _TipoGuia = null;
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
        public string NumGuiaRemision
        {
            get { return _NumGuiaRemision; }
            set { _NumGuiaRemision = value; }
        }
        public string TipoGuia
        {
            get { return _TipoGuia; }
            set { _TipoGuia = value; }
        }
        #endregion

        public FrmGuiaRemision()
        {
            InitializeComponent();
        }

        private void FrmGuiaRemision_Load(object sender, EventArgs e)
        {
            if (NumGuiaRemision != "")
            {
                Cursor = Cursors.WaitCursor;
                TxtGuia.Text = NumGuiaRemision;
                MostrarGuia(TxtGuia.Text);
                if (AppSettings.EmpresaID == "IH")
                    CboTipoGuia.SelectedIndex = 0;
                else if (AppSettings.EmpresaID == "CH")
                    CboTipoGuia.SelectedIndex = 1;
                else if (AppSettings.EmpresaID == "GH")
                    CboTipoGuia.SelectedIndex = 2;
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
                DtCabecera = ObjCL_GuiaRemision.GetCabeceraGuiaRemision(NumGuia);
            }
            else if(DtCabecera.Rows.Count == 0)
            {
                DtCabecera = ObjCL_GuiaRemision.GetCabeceraGuiaRemision(NumGuia);
            }
            #region Cabecera
            if (DtCabecera != null && DtCabecera.Rows.Count > 0)
            {
                if (DtDetalle == null)//no se le paso datos de la guia
                {
                    TipoGuia = DtCabecera.Rows[0]["TipoGuia"].ToString();//tipo de guia, segun eso trae los detalles (venta o interna)
                    DtDetalle = ObjCL_GuiaRemision.GetDetalleGuiaRemision(NumGuia, TipoGuia);
                }
                else if (DtDetalle.Rows.Count == 0)
                {
                    TipoGuia = DtCabecera.Rows[0]["TipoGuia"].ToString();//tipo de guia, segun eso trae los detalles (venta o interna)
                    DtDetalle = ObjCL_GuiaRemision.GetDetalleGuiaRemision(NumGuia, TipoGuia);
                }

                LblEmpresa.Text = AppSettings.NomEmpresa;
                LblDireccion.Text = "Direccion del Lugar";
                TxtFechaEmision.Text = DateTime.Now.Date.ToString().Substring(0, 9);
                LblRuc.Text = AppSettings.RUCEmpresa;
                TxtNumGuiaRemision.Text = DtCabecera.Rows[0]["NumGuiaRemision"].ToString().Substring(2);
                TxtFechaInicioTraslado.Text = DtCabecera.Rows[0]["FechaSalida"].ToString().Substring(0, 9);
                TxtDomicilioPartida.Text = DtCabecera.Rows[0]["DomicilioPartida"].ToString();
                TxtNroDomicilioPartida.Text = DtCabecera.Rows[0]["NroDomicilioPartida"].ToString();
                TxtIntDomicilioPartida.Text = DtCabecera.Rows[0]["InteriorDomicilioPartida"].ToString();
                TxtZonaDomicilioPartida.Text = DtCabecera.Rows[0]["ZonaDomicilioPartida"].ToString();
                TxtDisDomicilioPartida.Text = DtCabecera.Rows[0]["DistritoDomicilioPartida"].ToString();
                TxtProvDomicilioPartida.Text = DtCabecera.Rows[0]["ProvinciaDomicilioPartida"].ToString();
                TxtDepDomicilioPartida.Text = DtCabecera.Rows[0]["DepartamentoDomicilioPartida"].ToString();
                TxtDomicilioLlegada.Text = DtCabecera.Rows[0]["DomicilioLlegada"].ToString();
                TxtNroDomicilioLlegada.Text = DtCabecera.Rows[0]["NroDomicilioLlegada"].ToString();
                TxtIntDomicilioLlegada.Text = DtCabecera.Rows[0]["IntDomicilioLlegada"].ToString();
                TxtZonaDomicilioLlegada.Text = DtCabecera.Rows[0]["ZonaDomicilioLlegada"].ToString();
                TxtDisDomicilioLlegada.Text = DtCabecera.Rows[0]["DisDomicilioLlegada"].ToString();
                TxtProvDomicilioLlegada.Text = DtCabecera.Rows[0]["ProvDomicilioLlegada"].ToString();
                TxtDepDomicilioLlegada.Text = DtCabecera.Rows[0]["DepDomicilioLlegada"].ToString();
                TxtDestinatario.Text = DtCabecera.Rows[0]["Destinatario"].ToString();
                TxtRUCDestinatario.Text = DtCabecera.Rows[0]["RUCDestinatario"].ToString();
                TxtConfVehicular.Text = DtCabecera.Rows[0]["ConfiguracionVehicular"].ToString();
                TxtMarca.Text = DtCabecera.Rows[0]["Marca"].ToString();
                TxtPlaca.Text = DtCabecera.Rows[0]["Placa"].ToString();
                //TxtCarrosa.Text = DtCabecera.Rows[0]["Carrosa"].ToString();
                TxtNroConstInscripcion.Text = DtCabecera.Rows[0]["NroConstInscripcion"].ToString();
                TxtNroLicTransaportista.Text = DtCabecera.Rows[0]["NroLicTransportista"].ToString();
                if (DtCabecera.Rows[0]["NroFactura"].ToString() != "")
                    TxtNroFactura.Text = DtCabecera.Rows[0]["NroFactura"].ToString().Substring(1);
                TxtNombreChofer.Text = DtCabecera.Rows[0]["NombreChofer"].ToString();
                TxtTransportista2.Text = DtCabecera.Rows[0]["EmpresaTransporte"].ToString();
                TxtRucTransportista.Text = DtCabecera.Rows[0]["RUCTransporte"].ToString();

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

                //comprobante de pago
                if (TipoGuia == null)
                {
                    string TipoComprobante = "";
                    if (DtCabecera.Rows[0]["NroFactura"].ToString() != "")
                        TipoComprobante = DtCabecera.Rows[0]["NroFactura"].ToString().Substring(0, 1);
                    if (TipoComprobante == "B")//es boleta
                        TxtTipoComprobante.Text = "BOLETA";
                    else if (TipoComprobante == "F")//es factura
                        TxtTipoComprobante.Text = "FACTURA";
                }
                else
                {
                    TxtTipoComprobante.Text = TipoGuia;
                }
            }
            else
            {
                BtnAnular.Visible = false;
                DtCabecera = new DataTable();
                DtDetalle = new DataTable();
            }
            #endregion

            #region Detalles

            //filtrar los productos en una nueva tabla
            if (DtCabecera != null && DtCabecera.Rows.Count > 0)
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
            //tamaño de la boleta
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("GuiaRemitente", 840, 830);
            printDocument1.DefaultPageSettings.Margins.Left = 0;
            printDocument1.DefaultPageSettings.Margins.Right = 0;
            printDocument1.DefaultPageSettings.Margins.Top = 0;
            printDocument1.DefaultPageSettings.Margins.Bottom = 0;
            printDocument1.OriginAtMargins = true;

            //formato para alinear los numeros a la derecha
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;

            #region no vale
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
                                        sum += 12;
                                        e.Graphics.DrawString(t.Items[x].ToString(), t.Font, Brushes.Black, t.Location.X, t.Location.Y + sum, formato);
                                    }

                                }
                            }
                        }
                    }
                }
            }*/
            #endregion

        
            if (CboTipoGuia.SelectedIndex == 0) //industria
            {
                #region Imprimir tipo Industria
                e.Graphics.DrawString(TxtFechaEmision.Text, TxtFechaEmision.Font, Brushes.Black, 60, 154);
                e.Graphics.DrawString(TxtNumGuiaRemision.Text, TxtFechaEmision.Font, Brushes.Black, 580, 145);
                e.Graphics.DrawString(TxtFechaInicioTraslado.Text, TxtFechaEmision.Font, Brushes.Black, 225, 153);
                e.Graphics.DrawString(TxtDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 50, 200);
                e.Graphics.DrawString(TxtNroDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 170, 220);
                e.Graphics.DrawString(TxtIntDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 250, 220);
                e.Graphics.DrawString(TxtZonaDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 335, 220);
                e.Graphics.DrawString(TxtDisDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 90, 248);
                e.Graphics.DrawString(TxtProvDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 200, 248);
                e.Graphics.DrawString(TxtDepDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 320, 248);
                e.Graphics.DrawString(TxtDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 450, 200);
                e.Graphics.DrawString(TxtNroDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 570, 220);
                e.Graphics.DrawString(TxtIntDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 640, 220);
                e.Graphics.DrawString(TxtZonaDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 720, 220);
                e.Graphics.DrawString(TxtDisDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 470, 248);
                e.Graphics.DrawString(TxtProvDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 600, 248);
                e.Graphics.DrawString(TxtDepDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 720, 248);
                e.Graphics.DrawString(TxtDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 70, 304);
                e.Graphics.DrawString(TxtRUCDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 70, 326);
                e.Graphics.DrawString(txtDocIdentidad.Text, TxtFechaEmision.Font, Brushes.Black, 180, 343);

                e.Graphics.DrawString(TxtConfVehicular.Text, TxtFechaEmision.Font, Brushes.Black, 550, 293);
                e.Graphics.DrawString(TxtMarca.Text, TxtFechaEmision.Font, Brushes.Black, 570, 310);
                e.Graphics.DrawString(TxtPlaca.Text, TxtFechaEmision.Font, Brushes.Black, 665, 310);
                e.Graphics.DrawString(TxtNroConstInscripcion.Text, TxtFechaEmision.Font, Brushes.Black, 580, 327);
                e.Graphics.DrawString(TxtNroLicTransaportista.Text, TxtFechaEmision.Font, Brushes.Black, 560, 341);

                e.Graphics.DrawString(TxtTipoComprobante.Text, TxtFechaEmision.Font, Brushes.Black, 60, 710);
                e.Graphics.DrawString(TxtNroFactura.Text, TxtFechaEmision.Font, Brushes.Black, 60, 724);
                e.Graphics.DrawString(TxtNombreChofer.Text, TxtFechaEmision.Font, Brushes.Black, 475, 351);
                e.Graphics.DrawString(TxtTransportista2.Text, TxtFechaEmision.Font, Brushes.Black, 75, 625);

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
                        e.Graphics.DrawString(NomProducto, TxtDomicilioLlegada.Font, Brushes.Black, 22, 392 + sum);
                        e.Graphics.DrawString(UnidadMedidaID, TxtDomicilioLlegada.Font, Brushes.Black, 554, 392 + sum, formato);
                        e.Graphics.DrawString(CantidadEnviada.ToString("#,##0"), TxtDomicilioLlegada.Font, Brushes.Black, 633, 392 + sum, formato);
                        e.Graphics.DrawString(Peso.ToString("#,##0"), TxtDomicilioLlegada.Font, Brushes.Black, 697, 392 + sum, formato);
                    }
                }
                #endregion

                #endregion
            }

            if (CboTipoGuia.SelectedIndex == 1) //Comercial
            {
                #region Imprimir tipo Comercial
                e.Graphics.DrawString(TxtFechaEmision.Text, TxtFechaEmision.Font, Brushes.Black, 60, 154);
                e.Graphics.DrawString(TxtNumGuiaRemision.Text, TxtFechaEmision.Font, Brushes.Black, 680, 140);
                e.Graphics.DrawString(TxtFechaInicioTraslado.Text, TxtFechaEmision.Font, Brushes.Black, 225, 153);
                e.Graphics.DrawString(TxtDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 50, 200);
                e.Graphics.DrawString(TxtNroDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 170, 220);
                e.Graphics.DrawString(TxtIntDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 250, 220);
                e.Graphics.DrawString(TxtZonaDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 335, 220);
                e.Graphics.DrawString(TxtDisDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 90, 248);
                e.Graphics.DrawString(TxtProvDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 200, 248);
                e.Graphics.DrawString(TxtDepDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 320, 248);
                e.Graphics.DrawString(TxtDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 450, 200);
                e.Graphics.DrawString(TxtNroDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 450, 220);
                e.Graphics.DrawString(TxtIntDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 590, 220);
                e.Graphics.DrawString(TxtZonaDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 720, 220);
                e.Graphics.DrawString(TxtDisDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 470, 248);
                e.Graphics.DrawString(TxtProvDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 600, 248);
                e.Graphics.DrawString(TxtDepDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 720, 248);
                e.Graphics.DrawString(TxtDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 70, 300);
                e.Graphics.DrawString(TxtRUCDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 70, 326);
                e.Graphics.DrawString(txtDocIdentidad.Text, TxtFechaEmision.Font, Brushes.Black, 180, 343);
                //e.Graphics.DrawString(TxtConfVehicular.Text, TxtFechaEmision.Font, Brushes.Black, 570, 288);
                e.Graphics.DrawString(TxtMarca.Text, TxtFechaEmision.Font, Brushes.Black, 570, 300);
                e.Graphics.DrawString(TxtPlaca.Text, TxtFechaEmision.Font, Brushes.Black, 665, 300);
                e.Graphics.DrawString(TxtNroConstInscripcion.Text, TxtFechaEmision.Font, Brushes.Black, 580, 326);
                e.Graphics.DrawString(TxtNroLicTransaportista.Text, TxtFechaEmision.Font, Brushes.Black, 560, 343);
                e.Graphics.DrawString(TxtTipoComprobante.Text, TxtFechaEmision.Font, Brushes.Black, 60, 710);
                e.Graphics.DrawString(TxtNroFactura.Text, TxtFechaEmision.Font, Brushes.Black, 60, 724);
                //e.Graphics.DrawString(TxtNombreChofer.Text, TxtFechaEmision.Font, Brushes.Black, 495, 351);
                e.Graphics.DrawString(TxtTransportista2.Text, TxtFechaEmision.Font, Brushes.Black, 75, 625);

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
                        e.Graphics.DrawString(NomProducto, TxtDomicilioLlegada.Font, Brushes.Black, 22, 392 + sum);
                        e.Graphics.DrawString(UnidadMedidaID, TxtDomicilioLlegada.Font, Brushes.Black, 554, 392 + sum, formato);
                        e.Graphics.DrawString(CantidadEnviada.ToString("#,##0"), TxtDomicilioLlegada.Font, Brushes.Black, 633, 392 + sum, formato);
                        e.Graphics.DrawString(Peso.ToString("#,##0"), TxtDomicilioLlegada.Font, Brushes.Black, 697, 392 + sum, formato);
                    }
                }
                #endregion

                #endregion
            }

            if (CboTipoGuia.SelectedIndex == 2) //granja
            {
                #region Imprimir tipo Granja
                e.Graphics.DrawString(TxtFechaEmision.Text, TxtFechaEmision.Font, Brushes.Black, 60, 154);
                e.Graphics.DrawString(TxtNumGuiaRemision.Text, TxtFechaEmision.Font, Brushes.Black, 580, 150);
                e.Graphics.DrawString(TxtFechaInicioTraslado.Text, TxtFechaEmision.Font, Brushes.Black, 225, 153);
                e.Graphics.DrawString(TxtDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 50, 200);
                e.Graphics.DrawString(TxtNroDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 50, 220);
                e.Graphics.DrawString(TxtIntDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 210, 220);
                e.Graphics.DrawString(TxtZonaDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 300, 220);
                e.Graphics.DrawString(TxtDisDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 90, 248);
                e.Graphics.DrawString(TxtProvDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 180, 248);
                e.Graphics.DrawString(TxtDepDomicilioPartida.Text, TxtFechaEmision.Font, Brushes.Black, 320, 248);
                e.Graphics.DrawString(TxtDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 450, 200);
                e.Graphics.DrawString(TxtNroDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 440, 220);
                e.Graphics.DrawString(TxtIntDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 600, 220);
                e.Graphics.DrawString(TxtZonaDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 720, 220);
                e.Graphics.DrawString(TxtDisDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 470, 248);
                e.Graphics.DrawString(TxtProvDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 600, 248);
                e.Graphics.DrawString(TxtDepDomicilioLlegada.Text, TxtFechaEmision.Font, Brushes.Black, 720, 248);
                e.Graphics.DrawString(TxtDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 70, 307);
                e.Graphics.DrawString(TxtRUCDestinatario.Text, TxtFechaEmision.Font, Brushes.Black, 70, 326);
                e.Graphics.DrawString(txtDocIdentidad.Text, TxtFechaEmision.Font, Brushes.Black, 180, 343);
                e.Graphics.DrawString(TxtMarca.Text, TxtFechaEmision.Font, Brushes.Black, 570, 305);
                e.Graphics.DrawString(TxtPlaca.Text, TxtFechaEmision.Font, Brushes.Black, 665, 305);
                e.Graphics.DrawString(TxtNroConstInscripcion.Text, TxtFechaEmision.Font, Brushes.Black, 580, 322);
                e.Graphics.DrawString(TxtNroLicTransaportista.Text, TxtFechaEmision.Font, Brushes.Black, 560, 336);
                e.Graphics.DrawString(TxtTipoComprobante.Text, TxtFechaEmision.Font, Brushes.Black, 50, 700);
                e.Graphics.DrawString(TxtNroFactura.Text, TxtFechaEmision.Font, Brushes.Black, 50, 714);
                e.Graphics.DrawString(TxtNombreChofer.Text, TxtFechaEmision.Font, Brushes.Black, 475, 351);
                e.Graphics.DrawString(TxtTransportista2.Text, TxtFechaEmision.Font, Brushes.Black, 75, 615);

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
                        e.Graphics.DrawString(NomProducto, TxtDomicilioLlegada.Font, Brushes.Black, 22, 392 + sum);
                        e.Graphics.DrawString(UnidadMedidaID, TxtDomicilioLlegada.Font, Brushes.Black, 554, 392 + sum, formato);
                        e.Graphics.DrawString(CantidadEnviada.ToString("#,##0"), TxtDomicilioLlegada.Font, Brushes.Black, 643, 392 + sum, formato);
                        e.Graphics.DrawString(Peso.ToString("#,##0"), TxtDomicilioLlegada.Font, Brushes.Black, 697, 392 + sum, formato);
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
                if (DtCabecera != null)
                    DtCabecera.Rows.Clear();
                if (DtDetalle != null)
                    DtDetalle.Rows.Clear();
                MostrarGuia(TxtGuia.Text);
            }
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea anular la guia de remisión Nro: " + TxtNumGuiaRemision.Text + ".?", "Guia de remisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //****************************** anular guia *****************************************
                if (TipoGuia == "I")//es interno, mueve stock
                {
                    #region Crear Tablas
                    //tabla para actualizar el nuevo stock (agregar productos recepcionados)
                    DataTable DtActuStockLocal = new DataTable();
                    DtActuStockLocal.TableName = "StockAlmacen";
                    DtActuStockLocal.Columns.Add("NumRequerimiento", typeof(string));
                    DtActuStockLocal.Columns.Add("AlmacenID", typeof(string));
                    DtActuStockLocal.Columns.Add("ProductoID", typeof(string));
                    DtActuStockLocal.Columns.Add("StockAdicion", typeof(decimal));
                    #endregion

                    //actualizar datos del requerimiento
                    CL_Requerimientos ObjCL_Requerimientos = new CL_Requerimientos();

                    foreach (DataRow Row2 in DtDetalle.Rows)
                    {
                        #region Actualizar Estado Requerimientos
                        string NumRequerimiento;
                        decimal CantidadTransito;
                        string ProductoID;


                        NumRequerimiento = Row2["NumRequerimiento"].ToString();
                        ProductoID = Row2["ProductoID"].ToString();
                        CantidadTransito = Convert.ToDecimal(Row2["CantidadEnviada"]);

                        bool Valor;

                        Valor = ObjCL_Requerimientos.UpdateDetalleRequerimientoAnulado(NumRequerimiento, CantidadTransito, ProductoID, AppSettings.UserID, AppSettings.SedeID);

                        if (Valor == false)
                            MessageBox.Show("ocurrio un error al intentar actualizar el requerimiento: \r\nNumRequerimiento: " + NumRequerimiento + "ProductoID: " + ProductoID + "\r\nCantidadTransito: " + CantidadTransito, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Valor = ObjCL_GuiaRemision.UpdateGuiaRemisionEstado(TxtGuia.Text, 10, "A", AppSettings.UserID, AppSettings.SedeID);
                        #endregion

                        #region llenar tabla para actualizar el stock local
                        DataRow DrR = DtActuStockLocal.NewRow();
                        DrR["NumRequerimiento"] = Row2["NumRequerimiento"];
                        DrR["AlmacenID"] = AppSettings.EmpresaID + AppSettings.SedeID + "000";
                        DrR["ProductoID"] = Row2["ProductoID"];
                        DrR["StockAdicion"] = Row2["CantidadEnviada"];
                        DtActuStockLocal.Rows.Add(DrR);
                        #endregion

                    }

                    #region agrupar para actualizar el stock local
                    //Agrupar los productos apra almacenarlos
                    DataTable DtProducto = new DataTable();
                    DataTable DtActuStockLocal2 = new DataTable();
                    DtActuStockLocal2.TableName = "StockAlmacen";
                    DtActuStockLocal2.Columns.Add("NumRequerimiento", typeof(string));
                    DtActuStockLocal2.Columns.Add("AlmacenID", typeof(string));
                    DtActuStockLocal2.Columns.Add("ProductoID", typeof(string));
                    DtActuStockLocal2.Columns.Add("StockAdicion", typeof(decimal));
                    DtProducto = new BaseFunctions().SelectDistinct(DtActuStockLocal, "ProductoID", "AlmacenID");
                    foreach (DataRow RowP in DtProducto.Rows)
                    {
                        DataView Dv = new DataView(DtActuStockLocal);
                        Dv.RowFilter = "ProductoID = '" + RowP["ProductoID"] + "' and AlmacenID = '" + RowP["AlmacenID"] + "'";
                        decimal Suma = 0;
                        string NumRequerimiento = "";
                        foreach (DataRowView Drv in Dv) //sumar las cantidades por producto
                        {
                            Suma += Convert.ToDecimal(Drv["StockAdicion"]);
                            NumRequerimiento = Drv["NumRequerimiento"].ToString();
                        }
                        DataRow DrR = DtActuStockLocal2.NewRow();
                        DrR["NumRequerimiento"] = NumRequerimiento;
                        DrR["AlmacenID"] = RowP["AlmacenID"];
                        DrR["ProductoID"] = RowP["ProductoID"];
                        DrR["StockAdicion"] = Suma;
                        DtActuStockLocal2.Rows.Add(DrR);
                    }

                    #endregion
                    #region Actualizar el stock
                    CL_Almacen ObjCL_Almacen = new CL_Almacen();

                    foreach (DataRow R in DtActuStockLocal2.Rows)
                    {
                        ObjCL_Almacen.UpdateStockAdidion(R["AlmacenID"].ToString(), R["ProductoID"].ToString(), Convert.ToDecimal(R["StockAdicion"]), R["NumRequerimiento"].ToString(), "R");
                    }
                    #endregion
                    MessageBox.Show("Se termino de anular la guía", "Guia remitente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (TipoGuia == "V")//es venta, solo anula
                {
                    bool Valor;
                    Valor = ObjCL_GuiaRemision.UpdateGuiaRemisionEstado(TxtGuia.Text, 10, "A", AppSettings.UserID, AppSettings.SedeID);
                }
            }
        }

        private void BtnVistaPrevia_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            //printDialog1.AllowSelection = true;
            //printDialog1.AllowSomePages = true;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                ImpresoraGuiaRemitente = printDialog1.PrinterSettings.PrinterName;
                //*****************guardar la configuracion de la impresora en el appconfig**************
                if (ImpresoraGuiaRemitente != AppSettings.ImpresoraGuiaRemitente & ImpresoraGuiaRemitente != "")
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    AppSettingsSection appSettings = config.AppSettings;

                    KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraGuiaRemitente"];
                    setting.Value = ImpresoraGuiaRemitente;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                //************************ fin guardar configuracion ***************************************

            }
        }
    }
}

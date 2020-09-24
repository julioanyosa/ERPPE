using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;
using Halley.Utilitario;
using System.Configuration;
using Halley.Presentacion.Mantenimiento;
using Halley.Entidad.Ventas;
using Halley.CapaLogica.Empresa;
using System.Net;
using Halley.Presentacion.Almacen.Operaciones;
using ThoughtWorks.QRCode.Codec;

namespace Halley.Presentacion.Ventas
{
    public partial class Ventas : UITemplateAccess
    {
        #region Variables

        CL_Comprobante ObjComprobante = new CL_Comprobante();
        CL_Producto ObjCL_Producto = new CL_Producto();
        CL_Venta ObjCL_Venta = new CL_Venta();
        TextFunctions ObjTextFunctions = new TextFunctions();
        CL_Credito ObjCL_Credito = new CL_Credito();
        CL_Pago ObjCL_Pago = new CL_Pago();
        CapaLogica.Users.CL_Usuario ObjUsuario = new CapaLogica.Users.CL_Usuario();

        public static DataTable DtClientes = new DataTable();
        public static DataTable DtProductos = new DataTable();
        DataTable DtDetalleComprobante = new DataTable();
        DataTable DtTipoDocumento = new DataTable();
        DataTable DtserieGuias = new DataTable();
        DataTable DtCajas = new DataTable();
        DataTable DtFormaPago = new DataTable();
        DataTable DtTipoPago = new DataTable();
        DataTable DtVendedor = new DataTable();
        DataTable dtPedido = new DataTable();
        DataTable DtServicios = new DataTable();
        DataTable DtValesConsumo = new DataTable("ValesConsumo");
        DataTable DtBoucher = new DataTable("Boucher");
        DataTable Dtempresas = new DataTable();
        DataTable DtNotaIngreso = new DataTable("NotaIngreso");
        DataTable DtPreciosVariado = new DataTable();
        DataTable DtImpuestoBolsa = new DataTable();
        DataTable DtDatosSede;


        string NumComprobante = "";
        string EmpresaID;
        int NumCaja;
        string NomCaja = "";
        int NroTerminales = 0;
        int TipoPagoId = 0;
        DateTime FechaReserva;
        string AlmacenID = "";
        decimal descuento = 0;
        decimal DescontarporValesConsumo = 0;

        int IGV = 0;

        int hojaimpresa = 1;

        string Alias, UnidadMedidaID;
        decimal PrecioUnitario, Cantidad, PrecioVenta, StockDisponible, TotalIGV, Subtotal, TotalPagar, TotalComprobante, montoimpuestobolsa;
        string ProductoID, ProductoIDVentas, NomVendedor;
        Int32 VendedorID = 0, ClienteID, estadoID = 0, EstadoIDEntrega = 1, TipoVentaID = 0, NumPedido = 0, HistoricoPrecioID = 0;

        Boolean ConCliente = true;
        DateTime FECHA_IMPRESION;

        string NuevaIP = "";

        string TipoTicket = null;


        int DepartamentoId;
        int ProvinciaId;
        int DistritoId;
        string NombreVia;
        string DireccionNumero;
        string DireccionInterior;

        #endregion


        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {

            //crear tabla para enlazar a la grilla
            DtDetalleComprobante.Columns.Add("ProductoIDVentas", typeof(string));
            DtDetalleComprobante.Columns.Add("ProductoID", typeof(string));
            DtDetalleComprobante.Columns.Add("Alias", typeof(string));
            DtDetalleComprobante.Columns.Add("UnidadMedidaID", typeof(string));
            DtDetalleComprobante.Columns.Add("Cantidad", typeof(decimal)).DefaultValue = 0;
            DtDetalleComprobante.Columns.Add("PrecioUnitario", typeof(decimal));
            DtDetalleComprobante.Columns.Add("Importe", typeof(decimal)).DefaultValue = 0;
            DtDetalleComprobante.Columns.Add("FechaReserva", typeof(DateTime));
            DtDetalleComprobante.Columns.Add("EstadoID", typeof(int)).DefaultValue = 1;
            DtDetalleComprobante.Columns.Add("AlmacenID", typeof(string));
            DtDetalleComprobante.Columns.Add("Descuento", typeof(decimal)).DefaultValue = 0; ;
            DtDetalleComprobante.Columns.Add("PesoNeto", typeof(decimal));
            DtDetalleComprobante.Columns.Add("HistoricoPrecioID", typeof(int));


            TdgDocumento.SetDataBinding(DtDetalleComprobante, "", true);

            this.TdgDocumento.Columns[3].Editor = this.c1NELith;// enlazar con control para que acepte solo numeros

            //ocultar grilla de productos
            TdgListaProductos.Visible = false;

            //traer el nro de terminales
            NroTerminales = ObjCL_Venta.GetNroTerminales(AppSettings.SedeID);

            DtPreciosVariado = ObjCL_Venta.GetPrecioVariado();
            DtImpuestoBolsa = ObjCL_Venta.GetProductosImpuestoBolsa();

            //tarer empresas
            Dtempresas = new CL_Empresas().GetEmpresas();



            #region 1 terminal; 3 terminales (planta?)
            //validar según numero de terminales
            if (NroTerminales == 1 | NroTerminales == 3)
            {
                LblPedido.Visible = false;
                lblNumPedido.Visible = false;

                #region optener Nro IP
                String NombreHost;
                String DireccionIP;
                NombreHost = Dns.GetHostName();
                DireccionIP = System.Net.Dns.GetHostByName(NombreHost).AddressList[0] + "";
                //MessageBox.Show(DireccionIP);
                //dar formato a la direccion IP
                string ACU = "";
                NuevaIP = "";
                for (int X = 0; X < DireccionIP.Length; X++)
                {
                    string Valor = DireccionIP.Substring(X, 1);
                    if (Valor != ".")
                        ACU += Valor;
                    else
                    {
                        NuevaIP += ACU.PadLeft(3, '0') + ".";
                        ACU = "";
                    }
                }
                NuevaIP += ACU.PadLeft(3, '0');

                //traer impresoras
                UTI_Datatables.Dt_Configuracion = ObjUsuario.USP_M_CONFIGURACION(2, 0, "", "", "", "", AppSettings.UserID, NuevaIP);

                //traer las cajas de la sede
                DtCajas = ObjComprobante.GetCajasSedeT(NuevaIP);
                if (DtCajas.Rows.Count == 0)
                {
                    NumCaja = 0;
                    NomCaja = "No existe.";
                    MessageBox.Show("Esta direccion IP: #" + DireccionIP + "# no esta asociada a ninguna caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //if (NroTerminales == 1)//verificar si esta cerrado anteriormente
                    //{
                    //    DataTable DtCierre = new DataTable();
                    //    DtCierre = VerificarCierre(NumCaja);
                    //    if (DtCierre.Rows.Count > 0)
                    //    {
                    //        int Apertura = 0;
                    //        Apertura = Convert.ToInt16(DtCierre.Rows[0]["Estado"]);
                    //        if (Apertura == 1)
                    //        {
                    //            MessageBox.Show("Esta caja presenta una apertura anterior, de la fecha: " + DtCierre.Rows[0]["FechaApertura"].ToString() + ". Debe cerrarla para poder continuar con la venta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //            return;
                    //        }
                    //    }

                    //}
                }
                else
                {
                    NumCaja = Convert.ToInt32(DtCajas.Rows[0]["Numcaja"]);
                    NomCaja = DtCajas.Rows[0]["Descripcion"].ToString();
                }
                #endregion

                //traer los tipo de documento y las serie de las guias
                DtTipoDocumento = ObjComprobante.getTipoComprobante();

                CboTipoComprobante.ComboBox.DataSource = DtTipoDocumento;
                CboTipoComprobante.ComboBox.DisplayMember = "NomTipoComprobante";
                CboTipoComprobante.ComboBox.ValueMember = "TipoComprobanteID";

                DtserieGuias = ObjComprobante.GetSerieGuiasT(AppSettings.SedeID);//las series

                DtFormaPago = ObjComprobante.getFormaPago();
                CboFormaPago.ComboBox.DataSource = DtFormaPago;
                CboFormaPago.ComboBox.DisplayMember = "NomFormaPago";
                CboFormaPago.ComboBox.ValueMember = "FormaPagoID";

                DtTipoPago = ObjComprobante.getTipoPago();
                CboTipoPago.ComboBox.DataSource = DtTipoPago;
                CboTipoPago.ComboBox.DisplayMember = "NomTipoPago";
                CboTipoPago.ComboBox.ValueMember = "TipoPagoID";

                //traer vendedores
                DtVendedor = ObjCL_Venta.GetVendedores(AppSettings.SedeID);

                //mostrar cajero
                LblUsuario.Text = AppSettings.Usuario;
                ocultarToolStrip();
                CboTipoComprobante.ComboBox.SelectedIndex = -1;

                CboTipoPago.SelectedIndex = 1;

                LblCaja.Text = NomCaja;

                if (NroTerminales == 3) //venta federico basadre (vendedor y cajero es la msima persona)
                {
                    NomVendedor = AppSettings.Usuario;
                    LblVendedor.Text = NomVendedor;
                    VendedorID = AppSettings.UserID;
                }
                RbNormal.Checked = true;
            }
            #endregion
            #region dos terminales
            else if (NroTerminales == 2)
            {
                BtnGenerarGuias.Visible = false;
                VendedorID = AppSettings.UserID;
                BarraVentas.Visible = false;
                BtnImprimir.Text = "&Pedir";
                BtnImprimir.Image = Properties.Resources.Aceptar_16x16;
                LblVendedor.Visible = false;
                LblBoleta.Visible = false;
                LblFactura.Visible = false;
                LblB.Visible = false;
                LblF.Visible = false;
                LblCanasta.Visible = false;
                TxtCanasta.Visible = false;

                //RbNormal.Visible = fals;
                RbNormal.Checked = true;
            }
            #endregion


            //agregar empresa
            c1Combo.FillC1Combo(this.c1cboCia, Dtempresas, "NomEmpresa", "EmpresaID");

            //ocultar lista de creditos
            LstCreditos.Visible = false;
            ocultarToolStrip();
            TxtRazonSocial.Text = "CLIENTES VARIOS";
            c1cboCia.SelectedValue = AppSettings.EmpresaID;
            if (c1cboCia.SelectedIndex != -1)
                EmpresaID = c1cboCia.SelectedValue.ToString();

            //traer servicios otros
            DtServicios = ObjCL_Venta.GetServicios();

            this.TdgDocumento.Splits[0].DisplayColumns["Descuento"].Visible = false;

            BtnNuevoComprobante_Click(null, null);
        }

        #region Eventos Click
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if ((TxtNroDocumentoCliente.Text.Length != 8 &
                    TxtNroDocumentoCliente.Text.Length != 11) |
                    TxtRazonSocial.Text == "" | ClienteID == 0)
                {
                    MessageBox.Show("Busque un cliente válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TxtNroDocumentoCliente.Text.Length == 11
                    & TxtDireccion.Value.ToString() == "")
                {
                    MessageBox.Show("Ingrese la dirección del cliente en caso de RUC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                bool haycero = false;
                string Producto = "";
                foreach (DataRow DrC in DtDetalleComprobante.Rows)
                {
                    if (Convert.ToDecimal(DrC["Importe"]) == 0)
                    {
                        haycero = true;
                        Producto = DrC["Alias"].ToString();
                    }

                }

                #region tipo de venta
                if (RbNormal.Checked == true)
                    TipoVentaID = 4;
                else if (RbExterno.Checked == true)
                    TipoVentaID = 5;
                else if (RbReserva.Checked == true)
                    TipoVentaID = 3;
                else if (RbDiferida.Checked == true)
                    TipoVentaID = 6;
                #endregion


                //Validar si debe llevar nombres de cabecera el cliente
                if ((ClienteID == 1 | ClienteID == 204 | ClienteID == 241 | ClienteID == 3032) & TxtRazonSocial.Text.Contains("CLIENTES VA"))
                    ConCliente = false;
                else
                    ConCliente = true;

                if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 3)
                {
                    if (ChkEsTicketFactura.Checked == true)
                        TipoTicket = "F";
                    else
                        TipoTicket = "B";
                }
                else
                    TipoTicket = null;

                #region Una terminal
                if (NroTerminales == 1 | NroTerminales == 3)//la venta y la caja son la misma
                {

                    if (IsNumeric(TxtMontoPagado.Text) == false || Convert.ToDecimal(TxtMontoPagado.Text) < Convert.ToDecimal(TxtTotalPagar.Text))
                    {
                        MessageBox.Show("Ingrese monto a pagar válido y que sea mayor o igual al monto a pagar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtMontoPagado.Focus();
                        return;
                    }

                    if (ClienteID != 0 & CboTipoComprobante.ComboBox.SelectedValue != null & CboSerieGuia.ComboBox.SelectedValue != null & DtDetalleComprobante.Rows.Count > 0 & NumCaja != 0 & haycero == false & CboTipoPago.SelectedIndex != -1)
                    {
                        if (chkVendedor.Checked == true)
                            VendedorID = 0;
                        else if (chkVendedor.Checked == false)
                        {
                            if (VendedorID == 0)
                            { MessageBox.Show("Al parecer no se ha ingresado el vendedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); TxtProducto.Focus(); return; }
                        }


                        TipoPagoId = Convert.ToInt32(CboTipoPago.ComboBox.SelectedValue);


                        string EMPRESA_ID = c1cboCia.SelectedValue.ToString();
                        string TIPO_COMPROBANTE = "";
                        if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 1)
                        {
                            TIPO_COMPROBANTE = "BO";
                        }
                        else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 2)
                        {
                            TIPO_COMPROBANTE = "FA";
                        }
                        else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 3 |
                               Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 4 |
                               Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 5)
                        {
                            TIPO_COMPROBANTE = "TI";
                        }
                        //ahora se gauradara en una tabla Configuracion.Configuracion

                        DataView DV = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo ='" + "IMP_" + EMPRESA_ID + "_" + TIPO_COMPROBANTE + "'", "", DataViewRowState.CurrentRows);

                        if (DV.Count > 0)
                        {
                            printDocument1.PrinterSettings.PrinterName = DV[0]["Data"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No existe una impresora configurada, por favor agregela", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }


                        if (printDocument1.PrinterSettings.PrinterName == "")
                        {
                            MessageBox.Show("Al parecer no se ha seleccionado la impresora. no se imprimira el comprobante.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Cursor = Cursors.Default;
                            return;
                        }

                        //validar valores para el crédito
                        int CreditoID = 0;
                        decimal CreditoDisponible = 0;
                        if (LstCreditos.SelectedIndex != -1)
                        {
                            CreditoID = Convert.ToInt32(LstCreditos.Columns["CreditoID"].Value);
                            CreditoDisponible = Convert.ToDecimal(LstCreditos.Columns["CreditoDisponible"].Value);
                        }

                        //validar si es boleta o factura y que el tipo sea el correcto
                        Boolean Validado;
                        int tipodoc = 0;
                        if (TxtNroDocumentoCliente.Text.Length == 8)
                            tipodoc = 2;//es dni
                        if (TxtNroDocumentoCliente.Text.Length == 11)
                            tipodoc = 1;//es ruc



                        Validado = ObjCL_Venta.ValidarDocumento(tipodoc, Convert.ToInt32(CboTipoComprobante.ComboBox.SelectedValue), ClienteID, TipoTicket);

                        if (Validado == false) //No paso control de calidad
                        {
                            MessageBox.Show("En caso de boleta debe ser DNI, En caso de Factura solo RUC. Ticket acepta cualquiera", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        //aca modificar acacacacacacaca
                        DataTable dt = new DataTable();
                        dt = ObjCL_Venta.GenerarComprobante(DtDetalleComprobante, EmpresaID, AppSettings.SedeID, ClienteID, Convert.ToInt32(CboTipoComprobante.ComboBox.SelectedValue),
                                            TxtDireccion.Text, TipoVentaID, TipoPagoId, Convert.ToInt32(CboFormaPago.ComboBox.SelectedValue), NumCaja, IGV, Subtotal, TotalIGV,
                                            TotalPagar, LstCreditos.SelectedIndex, CreditoID, CreditoDisponible, VendedorID, AppSettings.UserID, CboSerieGuia.ComboBox.SelectedValue.ToString(),
                                            TipoTicket, DtValesConsumo, DtBoucher, DtNotaIngreso, montoimpuestobolsa, 0, TotalComprobante);




                        NumComprobante = dt.Rows[0]["NumComprobante"].ToString();
                        FECHA_IMPRESION = Convert.ToDateTime(dt.Rows[0]["FECHA_ACTUAL"].ToString());

                        if (dt.Rows[0]["respuesta"].ToString() != "OK" & dt.Rows[0]["respuesta"].ToString() != "")
                        {
                            MessageBox.Show(dt.Rows[0]["respuesta"].ToString(), "Error al mandar a sunat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (CboTipoComprobante.ComboBox.SelectedValue.ToString() == "1")//Es boleta
                            LblBoleta.Text = NumComprobante;
                        if (CboTipoComprobante.ComboBox.SelectedValue.ToString() == "2")//Es factura
                            LblFactura.Text = NumComprobante;

                        hojaimpresa = 1;
                        printDocument1.Print();//manda a imprimnir


                        //calcular la suma de los vales
                        if (DtValesConsumo.Rows.Count > 0)
                            DescontarporValesConsumo = Convert.ToDecimal(DtValesConsumo.Compute("sum(Monto)", ""));
                        if (DtBoucher.Rows.Count > 0)
                            DescontarporValesConsumo = Convert.ToDecimal(DtBoucher.Compute("sum(Monto)", ""));
                        if (DtNotaIngreso.Rows.Count > 0)
                            DescontarporValesConsumo = Convert.ToDecimal(DtNotaIngreso.Compute("sum(Importe)", ""));

                        #region mostrar formulario para calcular el vuelto
                        FrmPago ObjFrmPago = new FrmPago();
                        ObjFrmPago.Pago = Convert.ToDecimal(TxtMontoPagado.Text);
                        ObjFrmPago.TotalPagar = Convert.ToDecimal(TotalPagar - DescontarporValesConsumo);
                        ObjFrmPago.ShowDialog();
                        #endregion

                        #region validar varios
                        //MessageBox.Show("Se guardo correctamente el comprobante de pago", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //DtDetalleComprobante.Clear();
                        //TxtRazonSocial.Text = "CLIENTES VARIOS";
                        //TxtValorVenta.Value = 0;
                        //TxtIGV.Value = 0;
                        //TxtVentaNeta.Value = 0;
                        //TxtMontoPagado.Text = "0";
                        //TxtCanasta.Text = "";
                        //TxtDireccion.Value = "";
                        //DescontarporValesConsumo = 0;
                        //DtValesConsumo.Rows.Clear();// limpiar los vales
                        //DtBoucher.Rows.Clear();// limpiar los vales
                        //DtNotaIngreso.Rows.Clear();//limpia los adelantos
                        //CboFormaPago.ComboBox.SelectedValue = 1;//contado por defecto
                        //CboTipoComprobante.ComboBox.SelectedValue = 4;
                        //ClienteID = 0;

                        BtnNuevoComprobante_Click(null, null);
                        #endregion

                        Cursor = Cursors.Default;
                        if (NroTerminales == 1)
                        {
                            NomVendedor = "";
                            VendedorID = 0;
                        }
                        LblVendedor.Text = NomVendedor;
                        TxtProducto.Focus();

                    }
                    else
                    {
                        /*if (CboTipoComprobante.ComboBox.SelectedIndex == -1) { MessageBox.Show("Seleccione primero el tipo de comprobante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                        if (CboSerieGuia.ComboBox.SelectedIndex == -1) { MessageBox.Show("Seleccione la serie de la guia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                        if (TdgDocumento.RowCount == 0) { ErrProvider.SetError(TdgDocumento, "No hay Registros que procesar."); }
                        if (CboCaja.ComboBox.SelectedIndex == -1) { MessageBox.Show("No ha seleccionado una caja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                        if (CboTipoPago.SelectedIndex == -1) { MessageBox.Show("No ha seleccionado un tipo de pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                        if (haycero == true) { MessageBox.Show("Hay cero en el precio de venta del producto: " + Producto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        if (VendedorID == 0) { MessageBox.Show("Al parecer no se ha ingresado el vendedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); TxtCodigo.Focus(); }*/
                        if (CboTipoComprobante.ComboBox.SelectedIndex == -1) { ErrProvider.SetError(BtnImprimir, "Seleccione el tipo de comprobante."); }
                        if (CboSerieGuia.ComboBox.SelectedIndex == -1) { ErrProvider.SetError(BtnImprimir, "Seleccione la serie de la guía."); }
                        if (TdgDocumento.RowCount == 0) { ErrProvider.SetError(TdgDocumento, "No hay Registros que procesar."); }
                        if (NumCaja == 0) { ErrProvider.SetError(BarraVentas, "Esta terminal no esta asopciada a una caja."); }
                        if (CboTipoPago.SelectedIndex == -1) { ErrProvider.SetError(BtnImprimir, "Seleccione el tipo de pago"); }
                        if (haycero == true) { MessageBox.Show("Hay cero en el precio de venta del producto: " + Producto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        if (ClienteID == 0) { ErrProvider.SetError(TxtNroDocumentoCliente, "No se ha seleccionado un cliente."); }
                    }
                }
                #endregion

                #region Dos terminales
                else if (NroTerminales == 2)//la venta y la caja son diferentes
                {
                    if (ClienteID != 0 & DtDetalleComprobante.Rows.Count > 0 & haycero == false & VendedorID != 0)
                    {
                        #region crearpedido
                        E_OrdenPedido ObjOrdenPedido = new E_OrdenPedido()
                        {
                            ClienteID = ClienteID,
                            TipoComprobanteID = null,
                            TipoVentaID = TipoVentaID,
                            TipoPagoID = null,
                            FormaPagoId = null,
                            IGV = IGV,
                            SubTotal = Subtotal,
                            TotalIGV = TotalIGV,
                            UsuarioID = AppSettings.UserID,
                            EmpresaID = EmpresaID,
                            SedeID = AppSettings.SedeID,
                            Comentario = "",
                            Vale = false,
                            TotalICBPER = montoimpuestobolsa
                        };
                        if (RbExterno.Checked == true)
                            ObjOrdenPedido.Externa = true;
                        else
                            ObjOrdenPedido.Externa = false;

                        #region crear tabla y agregarle los pedidos
                        DataTable dtPedido = new DataTable("OrdenPedido");
                        dtPedido.Columns.Add("Codigo", typeof(string));
                        dtPedido.Columns.Add("Producto", typeof(string));
                        dtPedido.Columns.Add("Cantidad", typeof(decimal));
                        dtPedido.Columns.Add("PrecioUnitario", typeof(decimal));
                        dtPedido.Columns.Add("Importe", typeof(decimal), "Cantidad * PrecioUnitario");
                        dtPedido.Columns.Add("FechaReserva", typeof(DateTime));
                        dtPedido.Columns.Add("AlmacenID", typeof(string));
                        dtPedido.Columns.Add("HistoricoPrecioID", typeof(int));

                        foreach (DataRow DR in DtDetalleComprobante.Rows)
                        {
                            DataRow DRP = dtPedido.NewRow();
                            DRP["Codigo"] = DR["ProductoID"];
                            DRP["Producto"] = DR["Alias"];
                            DRP["Cantidad"] = DR["Cantidad"];
                            DRP["PrecioUnitario"] = DR["PrecioUnitario"];
                            DRP["FechaReserva"] = DR["FechaReserva"];
                            DRP["AlmacenID"] = DR["AlmacenID"];
                            DRP["HistoricoPrecioID"] = DR["HistoricoPrecioID"];
                            dtPedido.Rows.Add(DRP);
                        }
                        #endregion


                        if (TotalPagar >= 700 & (ClienteID == 1 | ClienteID == 204 | ClienteID == 241 | ClienteID == 3032))
                        {
                            MessageBox.Show("si la venta pasa de S/.700 debe exigir datos que identifiquen al cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        NumPedido = new CL_OrdenPedido().InsertOrdenPedido2(ObjOrdenPedido, dtPedido);
                        lblNumPedido.Text = NumPedido.ToString();

                        //MessageBox.Show("El pedido se genero correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("El Numero Pedido : " + lblNumPedido.Text, "PEDIDO", MessageBoxButtons.OK);

                        #endregion

                        #region validar varios
                        DtDetalleComprobante.Clear();
                        TxtRazonSocial.Text = "CLIENTES VARIOS";
                        TxtValorVenta.Value = 0;
                        TxtIGV.Value = 0;
                        TxtVentaNeta.Value = 0;
                        TxtTotalPagar.Value = 0;
                        TxtMontoPagado.Text = "0";
                        TxtDireccion.Value = "";
                        TxtProducto.Focus();
                        ChkDescuento.Checked = false;
                        ChkFlete.Checked = false;
                        TxtICBPER.Text = "0";
                        TxtICBPER.Value = 0;
                        #endregion
                    }
                    else
                    {
                        if (TdgDocumento.RowCount == 0) { ErrProvider.SetError(TdgDocumento, "No hay Registros que procesar."); }
                        if (haycero == true) { MessageBox.Show("Hay cero en el precio de venta del producto: " + Producto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        if (VendedorID == 0) { MessageBox.Show("Al parecer no se ha ingresado el vendedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); TxtProducto.Focus(); }
                    }
                }
                #endregion


                ChkAfecto.Checked = false;
                ErrProvider.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ".\t\nmetodo Imprimir()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVistaPrevia_Click(object sender, EventArgs e)
        {

            Pagos.FrmConfigurarImpresora ObjFrmConfigurarImpresora = new Pagos.FrmConfigurarImpresora();
            ObjFrmConfigurarImpresora.Show();

        }

        private void BtnNuevoComprobante2_Click(object sender, EventArgs e)
        {
            BtnNuevoComprobante_Click(null, null);
        }

        private void BtnNuevoComprobante_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("¿Esta seguro que desea cancelar la venta?", "Nueva venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //{
            TxtRazonSocial.Text = "CLIENTES VARIOS";
            DtDetalleComprobante.Clear();
            TxtIGV.Value = 0;
            TxtValorVenta.Value = 0;
            TxtVentaNeta.Value = 0;
            TxtTotalPagar.Value = 0;
            TxtMontoPagado.Text = "0";
            //TxtCodigo.Text = "";
            TxtProducto.Text = "";
            TxtPrecio.ReadOnly = false;
            TxtPrecio.Text = "";
            TxtPrecio.ReadOnly = true;
            TxtICBPER.Text = "0";
            TxtICBPER.Value = 0;
            if (RbReserva.Checked == false)
                TxtCantidad.Text = "";
            if (NroTerminales == 1)
                TxtCanasta.Text = "";
            Alias = "";
            ProductoID = "";
            if (NroTerminales == 1)
                VendedorID = 0;
            LblVendedor.Text = "";
            StockDisponible = 0;
            HistoricoPrecioID = 0;
            LblStock.Text = StockDisponible.ToString();
            DescontarporValesConsumo = 0;
            DtValesConsumo.Rows.Clear();// limpiar los vales
            DtBoucher.Rows.Clear();// limpiar los vales
            DtNotaIngreso.Rows.Clear();//limpia los adelantos
            ChkDescuento.Checked = false;
            ChkFlete.Checked = false;
            BtnSoloBoleta_Click(null, null);
            //}
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            BuscarProducto("", "", 0);
        }

        private void BtnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmCliente ObjFrmCliente = new FrmCliente();
            ObjFrmCliente.ShowDialog();

        }
        #endregion

        #region eventos Combo


        #endregion

        #region Eventos TextBox

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) & TxtCantidad.Text.Length > 0 && Convert.ToDecimal(TxtCantidad.Text) > 0)
            {
                //si el precio es modificable
                //if (TxtPrecio.ReadOnly == false)
                //{
                //    if (TxtPrecio.Text != "" && Convert.ToDecimal(TxtPrecio.Text) != 0)
                //    {
                //        if (Convert.ToDecimal(TxtPrecio.Text) < PrecioUnitario)//el precio no debe ser menro al de la lista
                //        {
                //            MessageBox.Show("El nuevo precio no debe ser menor al precio listado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return;
                //        }
                //    }
                //}

                if (RbDiferida.Checked == true | RbExterno.Checked == true | RbReserva.Checked == true)
                {
                    AgregarDetalle(Convert.ToDecimal(TxtCantidad.Text));
                }
                else if (RbNormal.Checked == true)
                {
                    if (Convert.ToDecimal(TxtCantidad.Text) <= StockDisponible)
                    {
                        AgregarDetalle(Convert.ToDecimal(TxtCantidad.Text));
                        StockDisponible = 0;
                        LblStock.Text = StockDisponible.ToString();
                    }
                    else
                        MessageBox.Show("Lo solicitado no puede ser mayor al stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
                ObjTextFunctions.ValidaNumero(sender, e, TxtCantidad);

            CalcularTotales();
        }

        private void AgregarDetalle(decimal CantidadA)
        {
            decimal NuevoPrecio;
            Cantidad = CantidadA;
            if (TxtPrecio.Text != "")
                PrecioUnitario = Convert.ToDecimal(TxtPrecio.Text);

            PrecioVenta = PrecioUnitario * Cantidad;

            //string cantidadTexto = PrecioVenta.ToString();
            ////se busca el punto
            //int posi = 0;
            //posi = cantidadTexto.IndexOf('.');
            //if (posi > 0)
            //{
            //    //se busca la posicion del punto y se agrega la cantidad correspondiente
            //    string cadenacontar = cantidadTexto.Substring(posi);
            //    if (cadenacontar.Length > 1)
            //    {
            //        int Numerovalidar = Convert.ToInt32(cantidadTexto.Substring(posi+2,1));
            //        if(Numerovalidar > 5)//si es mayor a cero se redondea
            //        {
            //            NuevoPrecio = Convert.ToDecimal(PrecioVenta.ToString()) + Convert.ToDecimal(0.1);
            //            NuevoPrecio = Convert.ToDecimal(NuevoPrecio.ToString().Substring(0, posi + 2));
            //        }
            //        else
            //        {
            //            NuevoPrecio = Convert.ToDecimal(PrecioVenta.ToString()) - Convert.ToDecimal("0.0" + Numerovalidar.ToString());
            //            NuevoPrecio = Convert.ToDecimal(NuevoPrecio.ToString().Substring(0, posi + 2));
            //        }

            //    }
            //    else
            //        NuevoPrecio = PrecioVenta;

            //}
            //else
            //    NuevoPrecio = PrecioVenta;

            NuevoPrecio = Math.Round(PrecioVenta, 2);

            if (RbNormal.Checked == true | RbExterno.Checked == true)
            {
                //buscar el producto y agregar en un mismo registro
                if (UnidadMedidaID != "KG")
                {
                    DataView dv = new DataView(DtDetalleComprobante, "ProductoID = '" + ProductoID + "'", "", DataViewRowState.CurrentRows);
                    if (dv.Count > 0)
                    {
                        foreach (DataRow DR in DtDetalleComprobante.Rows)
                        {
                            if (DR["ProductoID"].ToString() == ProductoID)
                            {
                                DR["Cantidad"] = Convert.ToDecimal(DR["Cantidad"]) + Cantidad;
                                DR["Importe"] = Convert.ToDecimal(DR["Importe"]) + NuevoPrecio;
                            }

                        }
                        DtDetalleComprobante.AcceptChanges();
                    }
                    else
                    {
                        DataRow Dr = DtDetalleComprobante.NewRow();
                        Dr["ProductoIDVentas"] = ProductoIDVentas;
                        Dr["ProductoID"] = ProductoID;
                        Dr["Alias"] = Alias;
                        Dr["UnidadMedidaID"] = UnidadMedidaID;
                        Dr["Cantidad"] = Cantidad;
                        Dr["PrecioUnitario"] = PrecioUnitario;
                        Dr["Importe"] = NuevoPrecio;
                        if (RbReserva.Checked == true)
                            Dr["FechaReserva"] = FechaReserva;
                        else
                            Dr["FechaReserva"] = DBNull.Value;
                        Dr["EstadoID"] = EstadoIDEntrega;
                        Dr["AlmacenID"] = AlmacenID;
                        Dr["HistoricoPrecioID"] = HistoricoPrecioID;
                        DtDetalleComprobante.Rows.Add(Dr);
                    }
                }
                else
                {
                    DataRow Dr = DtDetalleComprobante.NewRow();
                    Dr["ProductoIDVentas"] = ProductoIDVentas;
                    Dr["ProductoID"] = ProductoID;
                    Dr["Alias"] = Alias;
                    Dr["UnidadMedidaID"] = UnidadMedidaID;
                    Dr["Cantidad"] = Cantidad;
                    Dr["PrecioUnitario"] = PrecioUnitario;
                    Dr["Importe"] = NuevoPrecio;
                    if (RbReserva.Checked == true)
                        Dr["FechaReserva"] = FechaReserva;
                    else
                        Dr["FechaReserva"] = DBNull.Value;
                    Dr["EstadoID"] = EstadoIDEntrega;
                    Dr["AlmacenID"] = AlmacenID;
                    Dr["HistoricoPrecioID"] = HistoricoPrecioID;
                    DtDetalleComprobante.Rows.Add(Dr);
                }



            }
            else//si es reserva o diferida no deberian repetirse los items de venta
            {
                //buscar que no exista
                DataView Dv = new DataView(DtDetalleComprobante);
                Dv.RowFilter = "ProductoID = '" + ProductoID + "'";
                if (Dv.Count == 0)
                {
                    DataRow Dr = DtDetalleComprobante.NewRow();
                    Dr["ProductoIDVentas"] = ProductoIDVentas;
                    Dr["ProductoID"] = ProductoID;
                    Dr["Alias"] = Alias;
                    Dr["UnidadMedidaID"] = UnidadMedidaID;
                    Dr["Cantidad"] = Cantidad;
                    Dr["PrecioUnitario"] = PrecioUnitario;
                    Dr["Importe"] = NuevoPrecio;
                    if (RbReserva.Checked == true)
                        Dr["FechaReserva"] = FechaReserva;
                    else
                        Dr["FechaReserva"] = DBNull.Value;
                    Dr["EstadoID"] = EstadoIDEntrega;
                    DtDetalleComprobante.Rows.Add(Dr);
                }
                else
                    MessageBox.Show("El producto ya ha sido agregado al detalle. En reserva y diferida solo puede almacenar un item por comprobante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            TxtProducto.Text = "";
            if (RbReserva.Checked == false)
            {
                TxtCantidad.Text = "";
            }
            TxtPrecio.ReadOnly = false;
            TxtPrecio.Text = "";
            TxtPrecio.ReadOnly = true;
            //if (NroTerminales == 1)
            //    TxtCodigo.Focus();
            //if (NroTerminales == 3 | NroTerminales == 2)
            TxtProducto.Focus();
        }
        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                if (TxtCodigo.Text.Length > 0)
                {
                    TdgListaProductos.Visible = true;
                    DataView dv = new DataView(DtProductos);
                    dv.RowFilter = "ProductoIDVentas LIKE '" + TxtCodigo.Text + "%'";
                    this.TdgListaProductos.SetDataBinding(dv, "", true);
                }
                else
                    TdgListaProductos.Visible = false;
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        //private void TxtProducto_TextChanged(object sender, EventArgs e)
        //{
        //    /*try
        //    {
        //        if (TxtProducto.Text.Length > 0)
        //        {
        //            TdgListaProductos.Visible = true;
        //            DataView dv = new DataView(DtProductos);
        //            dv.RowFilter = "Alias LIKE '" + TxtProducto.Text + "%'";
        //            this.TdgListaProductos.SetDataBinding(dv, "", true);
        //        }
        //        else
        //            TdgListaProductos.Visible = false;
        //    }
        //    catch (Exception)
        //    {
        //        // MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }*/
        //}

        //private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)(Keys.Enter) & TxtCodigo.Text != "")
        //    {
        //        DtProductos = ObjCL_Producto.GetProductosPrecio(EmpresaID + AppSettings.SedeID, TxtCodigo.Text, "C");

        //        //si el producto es unico no es necesario mostrar la lista
        //        if (DtProductos.Rows.Count == 1)
        //        {

        //            AlmacenID = EmpresaID + AppSettings.SedeID + DtProductos.Rows[0]["Almacen"].ToString();

        //            if (EmpresaID == "" | AppSettings.SedeID == "" | DtProductos.Rows[0]["Almacen"].ToString() == "" | AlmacenID.Length != 10)
        //                MessageBox.Show("El codigo de almacen es = '" + AlmacenID + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //            StockDisponible = Convert.ToDecimal(DtProductos.Rows[0]["StockDisponible"]);
        //            LblStock.Text = StockDisponible.ToString();
        //            ProductoID = DtProductos.Rows[0]["ProductoID"].ToString();
        //            ProductoIDVentas = DtProductos.Rows[0]["ProductoIDVentas"].ToString();
        //            Alias = DtProductos.Rows[0]["Alias"].ToString();
        //            UnidadMedidaID = DtProductos.Rows[0]["UnidadMedidaID"].ToString();
        //            PrecioUnitario = Convert.ToDecimal(DtProductos.Rows[0]["PrecioUnitario"].ToString());
        //            HistoricoPrecioID = Convert.ToInt32(DtProductos.Rows[0]["HistoricoPrecioID"].ToString());

        //            if (StockDisponible > 0 | RbDiferida.Checked == true | RbReserva.Checked == true)
        //            {
        //                TxtCodigo.Text = ProductoIDVentas;
        //                TxtProducto.Text = Alias;
        //                TxtPrecio.ReadOnly = false;
        //                TxtPrecio.Text = PrecioUnitario.ToString();
        //                TxtPrecio.ReadOnly = true;
        //                if (RbReserva.Checked == true)
        //                {
        //                    BtnReserva_Click(null, null);
        //                }
        //                else
        //                {
        //                    TxtCantidad.Focus(); //establecer como foco la cantidad
        //                }
        //                CalcularTotales();
        //            }

        //        }
        //        else if (e.KeyChar == (char)(Keys.Escape))
        //        {
        //            if (TdgListaProductos.Visible == true)
        //                TdgListaProductos.Visible = false;
        //        }
        //        else if (DtProductos.Rows.Count == 0)
        //        {
        //            if (NroTerminales == 1)
        //                TxtCodigo.Focus();
        //            else if (NroTerminales == 2)
        //                TxtProducto.Focus();
        //        }
        //        else
        //        {
        //            TdgListaProductos.Visible = true;
        //            TdgListaProductos.SetDataBinding(DtProductos, "", true);
        //            TdgListaProductos.Focus();
        //        }
        //    }
        //}

        private void TxtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) & TxtProducto.Text != "")
            {
                string CodigoDeBarra = TxtProducto.Text;

                if (CodigoDeBarra.Length == 13 & CodigoDeBarra.Substring(0, 1) == "2")//es producto
                {
                    //se oculta la grilla
                    //ver si es por unidad o por precio

                    string UM = "";
                    UM = CodigoDeBarra.Substring(1, 1);
                    TdgListaProductos.Visible = false;
                    //descomponer el codigo
                    string Codigo = "";
                    string Articulo = "";
                    decimal Cantidad = 0;
                    Codigo = CodigoDeBarra.Substring(3, 4);
                    if (UM == "0")
                        Cantidad = Convert.ToDecimal(CodigoDeBarra.Substring(7, 5)) / 1000;
                    else
                        Cantidad = Convert.ToDecimal(CodigoDeBarra.Substring(7, 5));
                    BuscarProducto2(Codigo, Articulo, Cantidad);
                    Calcular();
                    CalcularTotales();

                }
                else if (CodigoDeBarra.Length == 13 & CodigoDeBarra.Substring(0, 1) == "V")//es vendedor
                {
                    if (DtVendedor.Rows.Count > 0)
                    {
                        VendedorID = Convert.ToInt32(CodigoDeBarra.Substring(1));
                        DataView Dv = new DataView(DtVendedor);
                        Dv.RowFilter = "UserID = " + VendedorID.ToString();
                        if (Dv.Count > 0)
                            NomVendedor = Dv[0]["Descripcion"].ToString();
                        else
                        {
                            NomVendedor = "";
                            VendedorID = 0;
                            MessageBox.Show("Este vendedor no existe o no pertenece a esta sede.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        LblVendedor.Text = NomVendedor;
                        TxtProducto.Text = "";
                        TxtProducto.Focus();

                    }

                }
                else
                {

                    BuscarProducto2(CodigoDeBarra, "", 1);
                    Calcular();
                    CalcularTotales();


                }



            }

            if (e.KeyChar == (char)(Keys.Escape))
            {
                if (TdgListaProductos.Visible == true)
                    TdgListaProductos.Visible = false;
            }
        }
        //private void TxtCodigo_KeyUp(object sender, KeyEventArgs e)
        //{
        //    ValidarCodigoBarra(TxtCodigo.Text);
        //}

        //private void TxtProducto_KeyUp(object sender, KeyEventArgs e)
        //{
        //    ValidarCodigoBarra(TxtProducto.Text);
        //}
        #endregion



        #region Metodos

        private void BuscarProducto(string Codigo, string Articulo, decimal Cantidad)
        {

            DataView Dv = new DataView(DtProductos);
            if (Codigo + "" != "" && Articulo + "" == "")
                Dv.RowFilter = "ProductoIDVentas = '" + Codigo + "'";
            if (Articulo + "" != "" && Codigo + "" == "")
                Dv.RowFilter = "Alias like '" + Articulo + "%'";
            if (Codigo + "" != "" && Articulo + "" != "")
                Dv.RowFilter = "ProductoIDVentas = '" + Codigo + "'";

            if (Dv.Count == 1)
            {
                //TdgDocumento.Columns["ProductoIDVentas"].Value = Dv[0]["ProductoIDVentas"];
                TdgDocumento.Columns["ProductoID"].Value = Dv[0]["ProductoID"];
                TdgDocumento.Columns["Alias"].Value = Dv[0]["Alias"];
                TdgDocumento.Columns["PrecioUnitario"].Value = Dv[0]["PrecioUnitario"];
                TdgDocumento.Columns["UnidadMedidaID"].Value = Dv[0]["UnidadMedidaID"];
                TdgDocumento.Columns["Cantidad"].Value = Cantidad;
            }
            else if (Dv.Count > 1 || Dv.Count == 0)
            {
                /*FrmListaProductos ObjFrmListaProductos = new FrmListaProductos();
                ObjFrmListaProductos.ShowDialog();
                if (ObjFrmListaProductos.Codigo != null)//validar que no sea vacio para que no lo agregue
                {
                    TdgDocumento.Columns["ArticuloId"].Value = ObjFrmListaProductos.ArticuloId;
                    TdgDocumento.Columns["Codigo"].Value = ObjFrmListaProductos.Codigo;
                    TdgDocumento.Columns["Articulo"].Value = ObjFrmListaProductos.Articulo;
                    TdgDocumento.Columns["ValorUnitario"].Value = ObjFrmListaProductos.ValorUnitario;
                    TdgDocumento.Columns["Simbolo"].Value = ObjFrmListaProductos.Simbolo;
                    TdgDocumento.Columns["Cantidad"].Value = Cantidad;
                }
                ObjFrmListaProductos.Dispose();*/
            }

        }

        private void BuscarProducto2(string Codigo, string Articulo, decimal Cantidad2)
        {
            DtProductos = ObjCL_Producto.GetProductosPrecio(EmpresaID + AppSettings.SedeID, Codigo, "C");

            if (DtProductos.Rows.Count == 1)
            {
                ProductoID = DtProductos.Rows[0]["ProductoID"].ToString();
                AlmacenID = EmpresaID + AppSettings.SedeID + DtProductos.Rows[0]["Almacen"].ToString();
                ProductoIDVentas = DtProductos.Rows[0]["ProductoIDVentas"].ToString();
                Alias = DtProductos.Rows[0]["Alias"].ToString();
                UnidadMedidaID = DtProductos.Rows[0]["UnidadMedidaID"].ToString();
                Cantidad = Cantidad2;
                PrecioUnitario = Convert.ToDecimal(DtProductos.Rows[0]["PrecioUnitario"]);
                PrecioVenta = PrecioUnitario * Cantidad;
                StockDisponible = Convert.ToDecimal(DtProductos.Rows[0]["StockDisponible"]);
                HistoricoPrecioID = Convert.ToInt32(DtProductos.Rows[0]["HistoricoPrecioID"]);
                LblStock.Text = StockDisponible.ToString();

                if (Cantidad2 <= StockDisponible)
                {
                    AgregarDetalle(Cantidad2);
                    StockDisponible = 0;
                    LblStock.Text = StockDisponible.ToString();
                }
                else
                    MessageBox.Show("Lo solicitado no puede ser mayor al stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                TxtProducto.Text = "";
                //TxtCodigo.Text = "";
                if (RbReserva.Checked != true)
                {
                    TxtCantidad.Text = "";
                }
                TxtProducto.Focus();

            }
            else if (DtProductos.Rows.Count == 0)
            {
                DtProductos = ObjCL_Producto.GetProductosPrecio(EmpresaID + AppSettings.SedeID, TxtProducto.Text, "A");
                if (DtProductos.Rows.Count == 1)
                {
                    AlmacenID = EmpresaID + AppSettings.SedeID + DtProductos.Rows[0]["Almacen"].ToString();
                    StockDisponible = Convert.ToDecimal(DtProductos.Rows[0]["StockDisponible"]);
                    LblStock.Text = StockDisponible.ToString();
                    ProductoID = DtProductos.Rows[0]["ProductoID"].ToString();
                    ProductoIDVentas = DtProductos.Rows[0]["ProductoIDVentas"].ToString();
                    Alias = DtProductos.Rows[0]["Alias"].ToString();
                    UnidadMedidaID = DtProductos.Rows[0]["UnidadMedidaID"].ToString();
                    PrecioUnitario = Convert.ToDecimal(DtProductos.Rows[0]["PrecioUnitario"].ToString());
                    HistoricoPrecioID = Convert.ToInt32(DtProductos.Rows[0]["HistoricoPrecioID"].ToString());

                    if (StockDisponible > 0 | RbDiferida.Checked == true | RbReserva.Checked == true)
                    {
                        //TxtCodigo.Text = ProductoIDVentas;
                        TxtProducto.Text = Alias;
                        TxtPrecio.ReadOnly = false;
                        TxtPrecio.Text = PrecioUnitario.ToString();
                        TxtPrecio.ReadOnly = true;
                        if (RbReserva.Checked == true)
                        {
                            BtnReserva_Click(null, null);
                        }
                        else
                        {
                            TxtCantidad.Focus(); //establecer como foco la cantidad
                        }
                        CalcularTotales();
                    }

                }
                else if (DtProductos.Rows.Count == 0)
                {
                    //if (NroTerminales == 1)
                    //    TxtCodigo.Focus();
                    //else if (NroTerminales == 2 | NroTerminales == 3)
                    TxtProducto.Text = "";
                    TxtProducto.Focus();
                }
                else
                {
                    TdgListaProductos.Visible = true;
                    TdgListaProductos.SetDataBinding(DtProductos, "", true);
                    TdgListaProductos.Focus();
                }
            }
            //else
            //{
            //    MessageBox.Show("No se encontro el producto, verifique su almacen principal, que tenga stock en su almacen principal y que tenga un precio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    TxtProducto.ReadOnly = false;
            //    TxtProducto.Text = "";
            //    TxtProducto.Focus();
            //    return;
            //}

        }

        private void CalcularTotales()
        {
            if (DtDetalleComprobante.Rows.Count > 0)
            {
                TotalIGV = Convert.ToDecimal(DtDetalleComprobante.Compute("sum(Importe) *  " + (Convert.ToDecimal(IGV) / 100), ""));
                Subtotal = Convert.ToDecimal(DtDetalleComprobante.Compute("sum(Importe)", "").ToString());

                //calculamos el iscb
                montoimpuestobolsa = 0;
                decimal impuestobolsa = 0;
                DataView DV2 = new DataView(DtImpuestoBolsa, "Descripcion = '" + DateTime.Now.Year.ToString() + "'", "", DataViewRowState.OriginalRows);
                if (DV2.Count > 0)
                    impuestobolsa = Convert.ToDecimal(DV2[0]["Valor"].ToString());


                foreach (DataRow DR in DtDetalleComprobante.Rows)
                {
                    DataView DV = new DataView(DtImpuestoBolsa, "Valor = '" + DR["ProductoID"] + "'", "", DataViewRowState.OriginalRows);
                    if (DV.Count > 0)
                        montoimpuestobolsa = montoimpuestobolsa + (impuestobolsa * Convert.ToDecimal(DR["Cantidad"]));
                }


                TotalComprobante = Convert.ToDecimal(DtDetalleComprobante.Compute("(sum(Importe) *  " + IGV + ") + sum(Importe)", "")) + montoimpuestobolsa;
                TotalPagar = Math.Floor(TotalComprobante) + (Math.Floor(((TotalComprobante - Math.Floor(TotalComprobante)) * 10)) / 10);

                //TxtIGV.Text = TotalIGV.ToString("C");
                //TxtValorVenta.Text = Subtotal.ToString("C");
                //TxtVentaNeta.Text = TotalPagar.ToString("C");

                TxtIGV.Text = TotalIGV.ToString("N2");
                TxtValorVenta.Text = Subtotal.ToString("N2");
                TxtVentaNeta.Text = TotalComprobante.ToString("N2");
                TxtTotalPagar.Text = TotalPagar.ToString("N2");
                TxtMontoPagado.Text = "0";
                TxtICBPER.Text = montoimpuestobolsa.ToString("N2");
            }
            else
            {
                TotalIGV = 0;
                Subtotal = 0;
                montoimpuestobolsa = 0;
                TotalPagar = 0;
                descuento = 0;
                TotalComprobante = 0;

                TxtIGV.Text = TotalIGV.ToString("C");
                TxtValorVenta.Text = Subtotal.ToString("C");
                TxtVentaNeta.Text = 0.ToString("C");
                TxtMontoPagado.Text = 0.ToString("N2");
                TxtTotalPagar.Text = 0.ToString("N2");
                TxtICBPER.Text = 0.ToString("N2");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //formato para alinear los nuimeros a la derecha
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;
            //formato.LineAlignment = StringAlignment.Far;

            //obtener la cadena del total a pagar
            string TotalComprobanteLetras = ObjTextFunctions.enletras(TotalPagar.ToString());

            string TotalPagarLetras = ObjTextFunctions.enletras(TotalPagar.ToString());


            //obtener datos de la empresa
            DataView DV = new DataView(Dtempresas);
            //string EmpresaID = "IH";
            DV.RowFilter = "EmpresaID = '" + EmpresaID + "'";
            string NomEmpresa = DV[0]["NomEmpresa"].ToString();
            string RUC = DV[0]["RUC"].ToString();

            string SerieEticketera;
            string NroAutorizacion;

            //SerieEticketera = CboSerieGuia.Columns["SerieEticketera"].Value.ToString();
            //NroAutorizacion = CboSerieGuia.Columns["NroAutorizacion"].Value.ToString();
            DataView dv1 = new DataView(DtserieGuias, "EmpresaID = '" + EmpresaID + "' and TipoDocumento = " + CboTipoComprobante.ComboBox.SelectedValue.ToString() + " and Serie = '" + CboSerieGuia.ComboBox.SelectedValue.ToString() + "'", "", DataViewRowState.CurrentRows);
            SerieEticketera = dv1[0]["SerieEticketera"].ToString();
            NroAutorizacion = dv1[0]["NroAutorizacion"].ToString();

            string CodigoTipoComprobante = "03", TipoLetra = "B", TipoDocumentoCliente = "DNI";

            string[] Formatoticket = new string[2];
            if (ObjCL_Venta.HABILITADOFE2(EmpresaID))
            {
                if (hojaimpresa == 1)
                {

                    if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 4)//es boleta
                    {

                        Formatoticket = ObjCL_Venta.FormatoTicketFE(NomEmpresa, AppSettings.NomSede, NumComprobante.Substring(2),
                        "BOLETA ELECTRONICA: ", DtDetalleComprobante, RUC, AppSettings.Usuario, TotalPagar, NomCaja, SerieEticketera,
                        NroAutorizacion, TotalPagarLetras, TxtRazonSocial.Text, TxtNroDocumentoCliente.Text, TxtDireccion.Value.ToString(),
                        TxtCanasta.Text, ConCliente, FECHA_IMPRESION, Convert.ToDecimal(TxtMontoPagado.Text), Convert.ToDecimal(TxtIGV.Text), "B",
                         DtDatosSede.Rows[0]["TelefonoCelular"].ToString(), DtDatosSede.Rows[0]["TelefonoFijo"].ToString(), Convert.ToDecimal(TxtVentaNeta.Text), montoimpuestobolsa);

                        e.Graphics.DrawString(Formatoticket[0], TxtFormato.Font, Brushes.Black, 0, 0); //total pagar en letras


                    }
                    else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 5)//es factura
                    {
                        CodigoTipoComprobante = "01";
                        TipoLetra = "F";
                        TipoDocumentoCliente = "RUC";


                        Formatoticket = ObjCL_Venta.FormatoTicketFE(NomEmpresa, AppSettings.NomSede, NumComprobante.Substring(2),
                        "FACTURA ELECTRONICA: ", DtDetalleComprobante, RUC, AppSettings.Usuario, TotalPagar, NomCaja, SerieEticketera,
                        NroAutorizacion, TotalPagarLetras, TxtRazonSocial.Text, TxtNroDocumentoCliente.Text, TxtDireccion.Value.ToString(),
                        TxtCanasta.Text, ConCliente, FECHA_IMPRESION, Convert.ToDecimal(TxtMontoPagado.Text), Convert.ToDecimal(TxtIGV.Text), "F",
                        DtDatosSede.Rows[0]["TelefonoCelular"].ToString(), DtDatosSede.Rows[0]["TelefonoFijo"].ToString(), Convert.ToDecimal(TxtVentaNeta.Text), montoimpuestobolsa);
                        e.Graphics.DrawString(Formatoticket[0], TxtFormato.Font, Brushes.Black, 0, 0); //total pagar en letras
                        //e.Graphics.DrawString(Convert.ToChar(27) + "i", TxtPrecio.Font, Brushes.Black, 0, 0); //total pagar en letras


                    }


                    /*imprimir el codigo de barras*/

                    QRCodeEncoder objqrcode = new QRCodeEncoder();
                    Image imgimage;
                    Bitmap objbitmap;
                    PictureBox Pimage = new PictureBox();
                    string s;
                    s = RUC + " | " + CodigoTipoComprobante + " | " + TipoLetra + NumComprobante.Substring(2, 3) + " | " + "0" + NumComprobante.Substring(6) + " | " + Convert.ToDecimal(TxtIGV.Text).ToString("N2") + " | " + Convert.ToDecimal(TxtVentaNeta.Text).ToString("N2") + " | " +
                        FECHA_IMPRESION.ToShortDateString() + " | " + TipoDocumentoCliente + " | " + TxtNroDocumentoCliente.Text;
                    objqrcode.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    objqrcode.QRCodeScale = 2;
                    objqrcode.QRCodeVersion = 6;
                    objqrcode.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.L;
                    imgimage = objqrcode.Encode(s);
                    objbitmap = new Bitmap(imgimage);
                    //objbitmap.Save("QRCode.jpg");
                    //Pimage.ImageLocation = "QRCode.jpg";
                    //CALCULAMOS AL CANTIDAD DE LINEAS
                    int CantidadLineas = ((Convert.ToInt32(Formatoticket[1]) + 2) * 13);
                    e.Graphics.DrawImage(imgimage, new Point(80, CantidadLineas));


                    if (Convert.ToDecimal(TxtIGV.Text) == 0)
                    {
                        string textofinal = "Bienes   transferidos  en   la  Amazonía\nRegión  Selva  para ser  cosumidos en la\nmisma.";
                        e.Graphics.DrawString(textofinal, TxtFormato.Font, Brushes.Black, 0, CantidadLineas + (14 * 11));
                        e.Graphics.DrawString("REVISE BIEN SU PRODUCTO ANTES DE\nRETIRARSE, NO SE ACEPTAN CAMBIOS NI\nDEVOLUCIONES. GRACIAS", TxtFormato.Font, Brushes.Black, 0, CantidadLineas + (18 * 11));
                    }
                    hojaimpresa = 2;
                    e.HasMorePages = true;


                }

                else if (hojaimpresa == 2)
                {

                    if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 4)//es boleta
                    {
                        string[] Formatoticket2 = new string[2];
                        Formatoticket2 = ObjCL_Venta.FormatoTicketFEResumido(NomEmpresa, AppSettings.NomSede, NumComprobante.Substring(2),
                        "BOLETA ELECTRONICA: ", DtDetalleComprobante, RUC, AppSettings.Usuario, TotalPagar, NomCaja, SerieEticketera,
                        NroAutorizacion, TotalPagarLetras, TxtRazonSocial.Text,
                        TxtNroDocumentoCliente.Text, TxtDireccion.Value.ToString(),
                        TxtCanasta.Text, ConCliente, FECHA_IMPRESION, Convert.ToDecimal(TxtMontoPagado.Text), Convert.ToDecimal(TxtIGV.Text), "B", TotalComprobante, montoimpuestobolsa);
                        e.Graphics.DrawString(Formatoticket2[0], TxtFormato.Font, Brushes.Black, 0, 0); //total pagar en letras


                    }
                    else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 5)//es factura
                    {
                        CodigoTipoComprobante = "01";
                        TipoLetra = "F";
                        TipoDocumentoCliente = "RUC";
                        string[] Formatoticket2 = new string[2];
                        Formatoticket2 = ObjCL_Venta.FormatoTicketFEResumido(NomEmpresa, AppSettings.NomSede, NumComprobante.Substring(2),
                        "FACTURA ELECTRONICA: ", DtDetalleComprobante, RUC, AppSettings.Usuario, TotalPagar, NomCaja, SerieEticketera,
                        NroAutorizacion, TotalPagarLetras, TxtRazonSocial.Text,
                        TxtNroDocumentoCliente.Text, TxtDireccion.Value.ToString(),
                        TxtCanasta.Text, ConCliente, FECHA_IMPRESION, Convert.ToDecimal(TxtMontoPagado.Text), Convert.ToDecimal(TxtIGV.Text), "F", TotalComprobante, montoimpuestobolsa);
                        e.Graphics.DrawString(Formatoticket2[0], TxtFormato.Font, Brushes.Black, 0, 0); //total pagar en letras
                        //e.Graphics.DrawString(Convert.ToChar(27) + "i", TxtPrecio.Font, Brushes.Black, 0, 0); //total pagar en letras


                    }



                    e.HasMorePages = false;
                }

            }

            #region Boleta
            if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 1)//es boleta
            {
                int sum = 0;
                sum += 12;
                e.Graphics.DrawString(TxtRazonSocial.Text, TxtPrecio.Font, Brushes.Black, 70 + AppSettings.BoletaEjeX, 156 + AppSettings.BoletaEjeY); //cliente
                if (TxtDireccion.Value.ToString().Length >= 30)
                    e.Graphics.DrawString(TxtDireccion.Value.ToString().Substring(0, 29), TxtPrecio.Font, Brushes.Black, 80 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //direccion larga
                else
                    e.Graphics.DrawString(TxtDireccion.Value.ToString(), TxtPrecio.Font, Brushes.Black, 80 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //direccion corta


                e.Graphics.DrawString(TxtCanasta.Text, TxtPrecio.Font, Brushes.Black, 40 + AppSettings.BoletaEjeX, 166 + AppSettings.BoletaEjeY); //canasta
                e.Graphics.DrawString(TxtNroDocumentoCliente.Text, TxtPrecio.Font, Brushes.Black, 326 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //ruc o DNI
                e.Graphics.DrawString(FECHA_IMPRESION.ToShortDateString(), TxtPrecio.Font, Brushes.Black, 240 + AppSettings.BoletaEjeX, 136 + AppSettings.BoletaEjeY); //dia
                e.Graphics.DrawString(NumComprobante.Substring(2), TxtPrecio.Font, Brushes.Black, 260 + AppSettings.BoletaEjeX, 117 + AppSettings.BoletaEjeY); //numero de comprobante
                //e.Graphics.DrawString(AppSettings.NomSede + "-Yarinacocha", TxtPrecio.Font, Brushes.Black, 180 + AppSettings.BoletaEjeX, 80 + AppSettings.BoletaEjeY); //direccion corta
                //e.Graphics.DrawString("Yarinacocha-Coronel Portillo-Ucayali", TxtPrecio.Font, Brushes.Black, 180 + AppSettings.BoletaEjeX, 93 + AppSettings.BoletaEjeY); //direccion corta


                int Suma = 238;
                foreach (DataRow Dr in DtDetalleComprobante.Rows)
                {
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Cantidad"]).ToString("#,##0.00") + " " + Dr["UnidadMedidaID"].ToString(), TxtPrecio.Font, Brushes.Black, 65 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //cantidad + UM
                    e.Graphics.DrawString(Dr["Alias"].ToString(), TxtPrecio.Font, Brushes.Black, 75 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY); //descripcion o producto
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["PrecioUnitario"]).ToString("#,##0.00"), TxtPrecio.Font, Brushes.Black, 320 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //precio unitario
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Importe"]).ToString("#,##0.00"), TxtPrecio.Font, Brushes.Black, 380 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //valor de venta
                    Suma += 14;
                }

                e.Graphics.DrawString(TxtVentaNeta.Text, TxtPrecio.Font, Brushes.Black, 370 + AppSettings.BoletaEjeX, 450 + AppSettings.BoletaEjeY, formato); //total
                e.Graphics.DrawString(TotalPagarLetras, TxtPrecio.Font, Brushes.Black, 45 + AppSettings.BoletaEjeX, 424 + AppSettings.BoletaEjeY); //tatal pagar en letras

            }
            #endregion
            #region Factura
            else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 2)//es factura
            {
                int sum = 0;
                sum += 12;
                e.Graphics.DrawString(TxtRazonSocial.Text, TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 117 + AppSettings.FacturaEjeY); //cliente
                //e.Graphics.DrawString(TxtDireccion.Value.ToString(), TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion
                if (TxtDireccion.Value.ToString().Length >= 95)
                    e.Graphics.DrawString(TxtDireccion.Value.ToString().Substring(0, 94), TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion
                else
                    e.Graphics.DrawString(TxtDireccion.Value.ToString(), TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion

                e.Graphics.DrawString(TxtNroDocumentoCliente.Text, TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //ruc o DNI
                e.Graphics.DrawString(FECHA_IMPRESION.Day.ToString(), TxtPrecio.Font, Brushes.Black, 570 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //dia
                e.Graphics.DrawString(FECHA_IMPRESION.ToString("MMMM"), TxtPrecio.Font, Brushes.Black, 650 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //mes
                e.Graphics.DrawString(FECHA_IMPRESION.Year.ToString().Substring(2), TxtPrecio.Font, Brushes.Black, 810 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //año
                e.Graphics.DrawString(NumComprobante.Substring(2), TxtPrecio.Font, Brushes.Black, 690 + AppSettings.FacturaEjeX, 147 + AppSettings.FacturaEjeY); //numero de comprobante

                int Suma = 230;
                foreach (DataRow Dr in DtDetalleComprobante.Rows)
                {
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Cantidad"]).ToString("#,##0.00") + " " + Dr["UnidadMedidaID"].ToString(), TxtPrecio.Font, Brushes.Black, 80 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //cantidad + UM
                    e.Graphics.DrawString(Dr["Alias"].ToString(), TxtPrecio.Font, Brushes.Black, 110 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY); //descripcion o producto
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["PrecioUnitario"]).ToString("#,##0.00"), TxtPrecio.Font, Brushes.Black, 665 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //precio unitario
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Importe"]).ToString("#,##0.00"), TxtPrecio.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //valor de venta
                    Suma += 14;
                }

                e.Graphics.DrawString(TxtValorVenta.Text, TxtPrecio.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 427 + AppSettings.FacturaEjeY, formato); //subtotal
                e.Graphics.DrawString(TxtIGV.Text, TxtPrecio.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 447 + AppSettings.FacturaEjeY, formato); //igv
                e.Graphics.DrawString(TxtVentaNeta.Text, TxtPrecio.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 477 + AppSettings.FacturaEjeY, formato); //total

                e.Graphics.DrawString(FECHA_IMPRESION.Day.ToString(), TxtPrecio.Font, Brushes.Black, 405 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //dia pie
                e.Graphics.DrawString(FECHA_IMPRESION.ToString("MMMM"), TxtPrecio.Font, Brushes.Black, 465 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //mes pie
                e.Graphics.DrawString(FECHA_IMPRESION.Year.ToString().Substring(2), TxtPrecio.Font, Brushes.Black, 545 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //año pie

                e.Graphics.DrawString(TotalPagarLetras, TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 407 + AppSettings.FacturaEjeY); //total pagar en letras
            }
            #endregion
            #region ticketera
            if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 3)//es ticket
            {


                string Formatoticket2 = ObjCL_Venta.FormatoTicketBoleta(NomEmpresa, AppSettings.NomSede, NumComprobante.Substring(2),
                "Ticket Nro: ", DtDetalleComprobante, RUC, AppSettings.Usuario, Convert.ToDecimal(TxtVentaNeta.Text), NomCaja, SerieEticketera,
                NroAutorizacion, TotalPagarLetras, TxtRazonSocial.Text,
                TxtNroDocumentoCliente.Text, TxtDireccion.Value.ToString(),
                TxtCanasta.Text, ConCliente, FECHA_IMPRESION, Convert.ToDecimal(TxtMontoPagado.Text), Convert.ToDecimal(TxtIGV.Text), TipoTicket);
                e.Graphics.DrawString(Formatoticket2, TxtPrecio.Font, Brushes.Black, 0, 0); //total pagar en letras
                //e.Graphics.DrawString(Convert.ToChar(27) + "i", TxtPrecio.Font, Brushes.Black, 0, 0); //total pagar en letras
            }
            #endregion

        }



        private void Calcular()
        {
            if (TdgDocumento.Columns["Cantidad"].Value + "" != "" & TdgDocumento.Columns["PrecioUnitario"].Value + "" != "")
            {
                TdgDocumento.Columns["Importe"].Value = decimal.Round(Convert.ToDecimal(TdgDocumento.Columns["Cantidad"].Value) * Convert.ToDecimal(TdgDocumento.Columns["PrecioUnitario"].Value), 1);
            }
        }
        #endregion


        private void CboTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DtTipoDocumento.Rows.Count > 0 && CboTipoComprobante.SelectedIndex != -1 & DtserieGuias.Rows.Count > 0 & EmpresaID != "")
            {
                DataView Dv = new DataView(DtserieGuias);
                Dv.RowFilter = "TipoDocumento = '" + Convert.ToInt32(CboTipoComprobante.ComboBox.SelectedValue) + "' and EmpresaID = '" + EmpresaID + "'";
                CboSerieGuia.ComboBox.DataSource = Dv;
                CboSerieGuia.ComboBox.DisplayMember = "Serie";
                CboSerieGuia.ComboBox.ValueMember = "Serie";
 
                DataView DVS = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo ='" + EmpresaID + "_SERIE_" + CboTipoComprobante.ComboBox.SelectedValue.ToString() + "'", "", DataViewRowState.CurrentRows);

                if (DVS.Count > 0)
                { 
                    CboSerieGuia.ComboBox.SelectedValue = DVS[0]["Data"].ToString();
                }


                 

                if (Dv.Count == 0)
                {
                    CboSerieGuia.SelectedIndex = -1;
                    CboSerieGuia.Text = "";
                }

                if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 1)//es boleta
                {
                    //tamaño de la boleta
                    printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("BoletaHalley", 510, 550);
                    printDocument1.DefaultPageSettings.Margins.Left = 0;
                    printDocument1.DefaultPageSettings.Margins.Right = 0;
                    printDocument1.DefaultPageSettings.Margins.Top = 0;
                    printDocument1.DefaultPageSettings.Margins.Bottom = 0;
                    printDocument1.OriginAtMargins = true;
                    //printDocument1.DefaultPageSettings.Landscape = false;
                }
                else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 2)//es factura
                {
                    //tamaño de la Factura
                    printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Facturalley", 845, 550);
                    printDocument1.DefaultPageSettings.Margins.Left = 0;
                    printDocument1.DefaultPageSettings.Margins.Right = 0;
                    printDocument1.DefaultPageSettings.Margins.Top = 0;
                    printDocument1.DefaultPageSettings.Margins.Bottom = 0;
                    printDocument1.OriginAtMargins = true;
                    //printDocument1.DefaultPageSettings.Landscape = false;
                }
                else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 3 |
                Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 4 |
                Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 5)//es ticket y FE
                {
                    printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.USStandardFanfold;
                    //MessageBox.Show(printDocument1.DefaultPageSettings.PaperSize.RawKind.ToString());
                }

                ValidarTipoFactura();

            }
            else
            {
                CboSerieGuia.SelectedIndex = -1;
                CboSerieGuia.Text = "";
            }
        }

        private void RbReserva_CheckedChanged(object sender, EventArgs e)
        {
            if (RbReserva.Checked == true)
            {
                TxtCantidad.Visible = true;
                TxtCantidad.Text = "";
                LblCantidad.Visible = false;
                TxtCantidad.Visible = false;
                //limpiar el detalle
                DtDetalleComprobante.Rows.Clear();
            }
            else
            {
                DtDetalleComprobante.Rows.Clear();
                TxtCantidad.Visible = true;
                TxtCantidad.Text = "";
                LblCantidad.Visible = true;

            }
        }

        private void CboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable DtCreditos = new DataTable();
            if (CboTipoPago.SelectedIndex != -1 && CboTipoPago.ComboBox.SelectedValue.ToString() == "1")//es credito
            {
                LstCreditos.Visible = true;
                CboFormaPago.Visible = false;
                PnlCreditos.Visible = true;

                //traer créditos
                DtCreditos = ObjCL_Credito.GetCreditosCliente(ClienteID, "A");
                LstCreditos.HoldFields();
                LstCreditos.DataSource = DtCreditos;
            }
            else
            {
                LstCreditos.Visible = false;
                CboFormaPago.Visible = true;
                PnlCreditos.Visible = false;
            }
        }

        private void BtnReserva_Click(object sender, EventArgs e)
        {
            //Alias = TxtProducto.Text;
            //ProductoID = TxtCodigo.Text;
            //if (Alias != "" & ProductoID != "")
            //{
            //    FrmReserva ObjFrmReserva = new FrmReserva();
            //    ObjFrmReserva.Alias = Alias;
            //    ObjFrmReserva.ProductoID = ProductoID;
            //    ObjFrmReserva.ShowDialog();

            //    if (ObjFrmReserva.Aprobado == true)
            //    {
            //        FechaReserva = ObjFrmReserva.FechaReserva;
            //        AgregarDetalle(ObjFrmReserva.Cantidad);
            //    }
            //    Calcular();
            //    CalcularTotales();
            //    TxtProducto.Text = "";
            //    //TxtCodigo.Text = "";
            //    if (RbReserva.Checked == false)
            //        TxtCantidad.Text = "";
            //    TxtPrecio.ReadOnly = false;
            //    TxtPrecio.Text = "";
            //    TxtPrecio.ReadOnly = true;
            //    TxtCodigo.Focus();
            //}
        }

        private void BtnGenerarGuias_Click(object sender, EventArgs e)
        {

            #region Crear tabla para enviar a crear guias
            DataTable DtDetalleGuiaRemisionVenta = new DataTable("DetalleGuiaRemisionVenta");
            DtDetalleGuiaRemisionVenta.Columns.Add("NomProducto", typeof(string));
            DtDetalleGuiaRemisionVenta.Columns.Add("UnidadMedidaID", typeof(string));
            DtDetalleGuiaRemisionVenta.Columns.Add("ProductoID", typeof(string));
            DtDetalleGuiaRemisionVenta.Columns.Add("CantidadEnviada", typeof(decimal));
            DtDetalleGuiaRemisionVenta.Columns.Add("PesoNeto", typeof(decimal));

            //añadir los detalles a una nueva tabla
            foreach (DataRow DR in DtDetalleComprobante.Rows)
            {
                DataRow DrD = DtDetalleGuiaRemisionVenta.NewRow();
                DrD["NomProducto"] = DR["Alias"];
                DrD["UnidadMedidaID"] = DR["UnidadMedidaID"];
                DrD["ProductoID"] = DR["ProductoID"];
                DrD["CantidadEnviada"] = DR["Cantidad"];
                DrD["PesoNeto"] = DR["PesoNeto"];
                DtDetalleGuiaRemisionVenta.Rows.Add(DrD);
            }
            #endregion

            #region validar que no haya "0" en el peso de los productos
            //agregar los que su cantidad se altero (osea mayor a 0)

            foreach (DataRow Dr in DtDetalleGuiaRemisionVenta.Rows)
            {
                bool HayPesoCero = true;
                string NomProducto = "";
                if (Dr["PesoNeto"].ToString() == "" || Dr["PesoNeto"].ToString() == "." | Dr["PesoNeto"] == DBNull.Value | Convert.ToDecimal(Dr["PesoNeto"].ToString()) == 0)
                {
                    HayPesoCero = true;
                    NomProducto = Dr["NomProducto"].ToString();
                    MessageBox.Show("Hay peso '0' en el producto: " + NomProducto + ". el peso no debe ser cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion


            FrmGuias ObjFrmGuias = new FrmGuias();
            ObjFrmGuias.DtDetalleGuiaRemisionVenta = DtDetalleGuiaRemisionVenta;
            ObjFrmGuias.DtTipoComprobante = DtTipoDocumento.Copy();
            ObjFrmGuias.Destinatario = TxtRazonSocial.Text;
            ObjFrmGuias.RUCDestinatario = TxtNroDocumentoCliente.Text;
            ObjFrmGuias.Remitente = c1cboCia.Columns["NomEmpresa"].ToString();
            ObjFrmGuias.RUCRemitente = c1cboCia.Columns["RUC"].ToString();
            ObjFrmGuias.DtServicios = DtServicios;
            ObjFrmGuias.ShowDialog();
        }

        private void ChkDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDescuento.Checked == true)
            {
                descuento = 0;
                //muestra el descuento
                this.TdgDocumento.Splits[0].DisplayColumns["Descuento"].Visible = true;
                //agrega el producto "descuento"
                DataView Dv = new DataView(DtServicios);
                Dv.RowFilter = "Tipo='-'";

                AlmacenID = EmpresaID + AppSettings.SedeID + "DES";//existe pero no vaa disminuir nada
                StockDisponible = 1;
                LblStock.Text = StockDisponible.ToString();
                ProductoID = Dv[0]["ProductoID"].ToString();
                ProductoIDVentas = Dv[0]["ProductoID"].ToString();
                Alias = Dv[0]["Alias"].ToString();
                UnidadMedidaID = Dv[0]["UnidadMedidaID"].ToString();
                PrecioUnitario = Convert.ToDecimal(Dv[0]["PrecioUnitario"].ToString());
                HistoricoPrecioID = 0;
                //calcular el descuento
                foreach (DataRow Dr in DtDetalleComprobante.Rows)
                {
                    descuento += Convert.ToDecimal(Dr["Descuento"]) * Convert.ToDecimal(Dr["Cantidad"]);
                }

                //actualizar el descuento
                AgregarDetalle(descuento * -1);
            }
            else
            {

                //actualizar descuento a 0
                foreach (DataRow Dr in DtDetalleComprobante.Rows)
                {
                    Dr["Descuento"] = 0;
                }

                //se quita la columna descuento
                this.TdgDocumento.Splits[0].DisplayColumns["Descuento"].Visible = false;


                //buscar el producto "descuento"
                DataView Dv = new DataView(DtServicios);
                Dv.RowFilter = "Tipo='-'";

                DataView Dv2 = new DataView(DtDetalleComprobante);
                Dv2.RowFilter = "ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'";
                if (Dv2.Count > 0)
                {
                    //se elimina el registro que contiene el descuento
                    DataRow[] customerRow = DtDetalleComprobante.Select("ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'");
                    customerRow[0].Delete();
                }

                Calcular();
                CalcularTotales();
            }
        }

        private void ChkFlete_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFlete.Checked == true)
            {
                //agrega el producto "flete"
                DataView Dv = new DataView(DtServicios);
                Dv.RowFilter = "Tipo='+'";

                AlmacenID = EmpresaID + AppSettings.SedeID + "DES"; //existe pero no vaa disminuir nada
                StockDisponible = 1;
                LblStock.Text = StockDisponible.ToString();
                ProductoID = Dv[0]["ProductoID"].ToString();
                ProductoIDVentas = Dv[0]["ProductoID"].ToString();
                Alias = Dv[0]["Alias"].ToString();
                UnidadMedidaID = Dv[0]["UnidadMedidaID"].ToString();
                PrecioUnitario = Convert.ToDecimal(Dv[0]["PrecioUnitario"].ToString());
                HistoricoPrecioID = 0;

                //actualizar el descuento
                AgregarDetalle(0);
            }
            else
            {
                //buscar el producto "flete"
                DataView Dv = new DataView(DtServicios);
                Dv.RowFilter = "Tipo='+'";

                //se elimina el registro que contiene el descuento
                DataView Dv2 = new DataView(DtDetalleComprobante);
                Dv2.RowFilter = "ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'";
                if (Dv2.Count > 0)
                {
                    DataRow[] customerRow = DtDetalleComprobante.Select("ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'");
                    customerRow[0].Delete();
                }
                Calcular();
                CalcularTotales();
            }
        }

        private void TdgDocumento_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            if (TdgDocumento.RowCount > 0)
            {
                if (TdgDocumento.Columns["Descuento"].Value.ToString() == "" | TdgDocumento.Columns["Descuento"].Value.ToString() == ".")
                {
                    e.Cancel = true;
                    TdgDocumento.Columns["Descuento"].Value = 0;
                    e.Cancel = false;
                    return;
                }
                if (TdgDocumento.Columns["Cantidad"].Value.ToString() == "" | TdgDocumento.Columns["Cantidad"].Value.ToString() == ".")
                {
                    e.Cancel = true;
                    TdgDocumento.Columns["Cantidad"].Value = 0;
                    e.Cancel = false;
                    return;
                }

            }
        }

        private void CboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboFormaPago.SelectedIndex != -1 && CboFormaPago.ComboBox.SelectedValue.ToString() == "5")//es vale
            {
                //aca aparece la ventana de los vales
                FrmValesConsumo ObjFrmValesConsumo = new FrmValesConsumo();
                ObjFrmValesConsumo.ShowDialog();
                if (ObjFrmValesConsumo.DtValesConsumo != null && ObjFrmValesConsumo.DtValesConsumo.Rows.Count > 0)
                    DtValesConsumo = ObjFrmValesConsumo.DtValesConsumo.Copy();
            }
            else if (CboFormaPago.SelectedIndex != -1 && CboFormaPago.ComboBox.SelectedValue.ToString() == "3")//es boucher
            {
                //aca aparece la ventana de los vales
                FrmBoucher ObjFrmBoucher = new FrmBoucher();
                ObjFrmBoucher.ShowDialog();
                if (ObjFrmBoucher.DtBoucher != null && ObjFrmBoucher.DtBoucher.Rows.Count > 0)
                    DtBoucher = ObjFrmBoucher.DtBoucher.Copy();
            }
            else
            {
                if (DtValesConsumo.Rows.Count > 0)
                {
                    MessageBox.Show("Se elimino los vales ingresados, en caso de que decida\npagar con vales vuelva a ingresarlos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (DtBoucher.Rows.Count > 0)
                {
                    MessageBox.Show("Se elimino los boucher, en caso de que decida\npagar con boucher vuelva a ingresarlos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                DtValesConsumo.Rows.Clear();
                DtBoucher.Rows.Clear();
            }
        }

        private void BtnInicioCaja_Click(object sender, EventArgs e)
        {
            //aperturar caja con una cantidad inicial de dinero
            FrmAperturaCaja ObjFrmAperturaCaja = new FrmAperturaCaja();
            ObjFrmAperturaCaja.DtEmpresas = Dtempresas;
            ObjFrmAperturaCaja.NumCaja = NumCaja;
            ObjFrmAperturaCaja.EmpresaID = EmpresaID;
            ObjFrmAperturaCaja.NomCaja = NomCaja;
            ObjFrmAperturaCaja.NroDocumento = TxtNroDocumentoCliente.Text;
            ObjFrmAperturaCaja.Cliente = TxtRazonSocial.Text;
            ObjFrmAperturaCaja.ClienteID = ClienteID;
            ObjFrmAperturaCaja.ShowDialog();
            ObjFrmAperturaCaja.Dispose();

        }

        private void BtnEgreso_Click(object sender, EventArgs e)
        {
            //registrar egresos
            FrmEgreso ObjFrmEgreso = new FrmEgreso();
            ObjFrmEgreso.NomCaja = NomCaja;
            ObjFrmEgreso.EmpresaID = EmpresaID;
            ObjFrmEgreso.NumCaja = NumCaja;
            ObjFrmEgreso.DtEmpresas = Dtempresas;
            ObjFrmEgreso.ShowDialog();
            ObjFrmEgreso.Dispose();
        }

        private void BtnAdelantos_Click(object sender, EventArgs e)
        {
            //aca se vè lso adelantos
            FrmAdelantos ObjFrmAdelantos = new FrmAdelantos();
            ObjFrmAdelantos.ClienteID = ClienteID;
            ObjFrmAdelantos.ShowDialog();
            DtNotaIngreso = ObjFrmAdelantos.DtNotaIngreso.Copy();
            //eliminar columnas innecesarias
            if (DtNotaIngreso.Columns.Count > 0)
            {
                DtNotaIngreso.Columns.Remove("NomEmpresa");
                DtNotaIngreso.Columns.Remove("Observacion");
                DtNotaIngreso.Columns.Remove("AudCrea");
            }
            ObjFrmAdelantos.Dispose(); //eliminamos el objeto???
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            if (CboSerieGuia.SelectedIndex != -1)
            {
                DataTable DtImpresora = new DataTable();
                DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, c1cboCia.SelectedValue.ToString(), c1cboCia.SelectedValue.ToString() + "_SERIE_" + CboTipoComprobante.ComboBox.SelectedValue.ToString(), "SERIE POR DEFECTO", CboSerieGuia.ComboBox.SelectedValue.ToString(), AppSettings.UserID, NuevaIP);

                UTI_Datatables.Dt_Configuracion = ObjUsuario.USP_M_CONFIGURACION(2, 0, "", "", "", "", AppSettings.UserID, NuevaIP);


                MessageBox.Show("Se actualizo la serie de la empresa '" + EmpresaID + "', de " + CboTipoComprobante.ComboBox.Text + " con la serie: " + CboSerieGuia.ComboBox.SelectedValue.ToString() + ".", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void c1cboCia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c1cboCia.SelectedIndex != -1)
            {
                EmpresaID = c1cboCia.SelectedValue.ToString();
                if (NroTerminales == 1)
                {
                    if (CboTipoComprobante.SelectedIndex != -1)
                    {
                        CboTipoComprobante_SelectedIndexChanged(null, null);
                        BtnNuevoComprobante_Click(null, null);
                    }
                }

                DtDatosSede = ObjCL_Venta.ObtenerDatosSucursal(EmpresaID, AppSettings.SedeID);
            }
            DtDetalleComprobante.Rows.Clear();
        }


        #region Eventos de Grillas
        private void TdgDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)(Keys.Enter) | e.KeyChar == (char)(Keys.Left) | e.KeyChar == (char)(Keys.Right))
            if (e.KeyChar == (char)(Keys.Enter))
            {
                decimal Cantidad;
                if (TdgDocumento.Columns["Cantidad"].Value + "" == "")
                    Cantidad = 0;
                else
                    Cantidad = Convert.ToDecimal(TdgDocumento.Columns["Cantidad"].Value);

                //BuscarProducto(TdgDocumento.Columns["ProductoID"].Value.ToString(), TdgDocumento.Columns["Alias"].Value.ToString(), Cantidad);
                SendKeys.Send("{DOWN}");
                //if (NroTerminales == 1)
                //    TxtCodigo.Focus();
                //else
                TxtProducto.Focus();
            }
            CalcularTotales();


        }

        private void TdgDocumento_BeforeInsert(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
            //validar el maximo de productos por boleta
            if (TdgDocumento.RowCount > 9)
            {
                MessageBox.Show("Solo se admite 10 productos por Comprobante. Para los proximos productos debera crear otra Comprobante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            CalcularTotales();
        }

        private void TdgListaProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) & TdgListaProductos.RowCount > 0)
            {
                AlmacenID = EmpresaID + AppSettings.SedeID + this.TdgListaProductos.Columns["Almacen"].Value.ToString();
                StockDisponible = Convert.ToDecimal(this.TdgListaProductos.Columns["StockDisponible"].Value);
                LblStock.Text = StockDisponible.ToString();
                ProductoID = this.TdgListaProductos.Columns["ProductoID"].Value.ToString();
                ProductoIDVentas = this.TdgListaProductos.Columns["ProductoIDVentas"].Value.ToString();
                Alias = this.TdgListaProductos.Columns["Alias"].Value.ToString();
                UnidadMedidaID = this.TdgListaProductos.Columns["UnidadMedidaID"].Value.ToString();
                PrecioUnitario = Convert.ToDecimal(this.TdgListaProductos.Columns["PrecioUnitario"].Value.ToString());
                HistoricoPrecioID = Convert.ToInt32(this.TdgListaProductos.Columns["HistoricoPrecioID"].Value.ToString());

                if (StockDisponible > 0 | RbDiferida.Checked == true | RbReserva.Checked == true)
                {
                    //TxtCodigo.Text = ProductoIDVentas;
                    TxtProducto.Text = Alias;
                    TxtPrecio.ReadOnly = false;
                    TxtPrecio.Text = PrecioUnitario.ToString();
                    TxtPrecio.ReadOnly = true;

                    //buscar el producto en la tabla DTpreciovariado, si lo encuentra, se puede modificar el precio
                    DataView DV = new DataView(DtPreciosVariado, "ProductoID = '" + ProductoID + "'", "", DataViewRowState.OriginalRows);

                    if (DV.Count > 0)
                        TxtPrecio.ReadOnly = false;

                    TdgListaProductos.Visible = false;
                    if (RbReserva.Checked == true)
                    {
                        BtnReserva_Click(null, null);
                    }
                    else
                    {
                        TxtCantidad.Focus(); //establecer como foco la cantidad
                    }
                    CalcularTotales();
                }
            }
            else if (e.KeyChar == (char)(Keys.Escape))
            {

                TdgListaProductos.Visible = false;

                //TxtCodigo.Text = "";
                TxtProducto.Text = "";
                TxtPrecio.ReadOnly = false;
                TxtPrecio.Text = "";
                TxtPrecio.ReadOnly = true;
                TdgListaProductos.Visible = false;

                //if (NroTerminales == 1)
                //    TxtCodigo.Focus(); //establecer como foco la cantidad
                //if (NroTerminales == 2 | NroTerminales == 3)
                TxtProducto.Focus();
                CalcularTotales();
            }

        }

        private void TdgDocumento_AfterDelete(object sender, EventArgs e)
        {
            Calcular();
            CalcularTotales();

        }

        private void TdgDocumento_FetchRowStyle(object sender, C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs e)
        {
            DataView Dv = new DataView(DtServicios);
            Dv.RowFilter = "Tipo='-'";
            //deshabilitar para que no se modifique el decuento

            string S = TdgDocumento.Columns["ProductoID"].CellText(e.Row).ToString();
            if (S == Dv[0]["ProductoID"].ToString())
            {
                e.CellStyle.BackColor = System.Drawing.Color.LightCoral;
            }

            DataView Dv2 = new DataView(DtServicios);
            Dv2.RowFilter = "Tipo='+'";
            //deshabilitar para que no se modifique el decuento

            string S2 = TdgDocumento.Columns["ProductoID"].CellText(e.Row).ToString();
            if (S2 == Dv2[0]["ProductoID"].ToString())
            {
                e.CellStyle.BackColor = System.Drawing.Color.LightSeaGreen;
            }

        }

        private void TdgDocumento_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {

            DataView Dv = new DataView(DtServicios);
            Dv.RowFilter = "Tipo='-'";
            //deshabilitar para que no se modifique el decuento
            switch (e.Column.DataColumn.DataField)
            {
                case "Cantidad":
                    if (this.TdgDocumento[e.Row, "ProductoID"].ToString().Trim() == Dv[0]["ProductoID"].ToString())
                    {
                        e.CellStyle.Locked = true;
                        break;
                    }
                    break;
                case "Descuento":
                    if (this.TdgDocumento[e.Row, "ProductoID"].ToString().Trim() == Dv[0]["ProductoID"].ToString())
                    {
                        e.CellStyle.Locked = true;
                        break;
                    }
                    break;

            }

            DataView Dv2 = new DataView(DtServicios);
            Dv2.RowFilter = "Tipo='+'";
            //deshabilitar para que no se modifique el decuento
            switch (e.Column.DataColumn.DataField)
            {
                case "Descuento":
                    if (this.TdgDocumento[e.Row, "ProductoID"].ToString().Trim() == Dv2[0]["ProductoID"].ToString())
                    {
                        e.CellStyle.Locked = true;
                        break;
                    }
                    break;

            }

        }

        private void TdgDocumento_AfterUpdate(object sender, EventArgs e)
        {
            //se actualiza la cantidad del descuento
            descuento = 0;
            //calcular el descuento
            foreach (DataRow Dr in DtDetalleComprobante.Rows)
            {
                descuento += Convert.ToDecimal(Dr["Descuento"]) * Convert.ToDecimal(Dr["Cantidad"]);
            }
            //agrega el producto "descuento"
            DataView Dv = new DataView(DtServicios);
            Dv.RowFilter = "Tipo='-'";

            DataView Dv2 = new DataView(DtDetalleComprobante);
            Dv2.RowFilter = "ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'";
            if (Dv2.Count > 0)
            {
                DataRow[] customerRow = DtDetalleComprobante.Select("ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'");
                customerRow[0]["Cantidad"] = decimal.Round(descuento * -1, 1);
                customerRow[0]["Importe"] = decimal.Round((descuento * -1) * Convert.ToDecimal(Dv[0]["PrecioUnitario"]), 1);
            }

            Calcular();
            CalcularTotales();

        }

        private void TdgDocumento_BeforeUpdate(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
            Calcular();
            CalcularTotales();

        }

        #endregion


        void ValidarTipoFactura()
        {
            if (TxtNroDocumentoCliente.Text.Length == 11 & Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 3)
            {
                ChkEsTicketFactura.Enabled = true;
                ChkEsTicketFactura.Checked = true;
                ChkEsTicketFactura.Enabled = false;
            }
            else
            {
                ChkEsTicketFactura.Enabled = true;
                ChkEsTicketFactura.Checked = false;
                ChkEsTicketFactura.Enabled = false;
            }
        }

        private void BtnVerCorrelativo_Click(object sender, EventArgs e)
        {
            if (EmpresaID != "")
            {
                //ver el correlativo para saber cual se vaa imprimir
                string Cadena = "";
                Cadena = ObjCL_Venta.GetVerCorrelativo(EmpresaID + AppSettings.SedeID, c1cboCia.Columns["NomEmpresa"].Value.ToString(), AppSettings.NomSede);
                MessageBox.Show(Cadena, "Serie y numero de comprobantes a punto de imprimirse.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCierre_Click(object sender, EventArgs e)
        {
            if (NumCaja != 0)
            {
                FrmCierre ObjFrmCierre = new FrmCierre();
                ObjFrmCierre.NumCaja = NumCaja;
                ObjFrmCierre.DtEmpresas = Dtempresas.Copy();
                ObjFrmCierre.ShowDialog();
            }
            else
                MessageBox.Show("La caja debe estar registrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }


        public static System.Boolean IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false
            return false;
        }

        private void TxtMontoPagado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtMontoPagado);
        }

        private void ChkAfecto_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAfecto.Checked == true)
                IGV = new CL_Comprobante().getIGV();
            else
                IGV = 0;

            CalcularTotales();
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtNroDocumentoCliente.Text.Length != 8 & TxtNroDocumentoCliente.Text.Length != 11)
                {
                    TxtRazonSocial.Text = "";
                    TxtDireccion.Value = "";
                    LblEstadoCliente.Text = "";
                    ClienteID = 0;
                    MessageBox.Show("El Nro del documento debe tener una longitud de 8 o 11 dígitos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                TxtRazonSocial.Text = "";
                TxtDireccion.Value = "";
                LblEstadoCliente.Text = "";
                DataSet DS = ObjCL_Venta.ObtenerDatosCliente(TxtNroDocumentoCliente.Text);

                if (DS.Tables[0].Rows.Count > 0)
                {
                    DataTable dtres = DS.Tables[0].Copy();

                    ClienteID = Convert.ToInt32(dtres.Rows[0]["ClienteID"]);
                    DepartamentoId = Convert.ToInt32(dtres.Rows[0]["DepartamentoId"]);
                    ProvinciaId = Convert.ToInt32(dtres.Rows[0]["ProvinciaId"]);
                    DistritoId = Convert.ToInt32(dtres.Rows[0]["DistritoId"]);

                    if (dtres.Rows[0]["FUENTE"].ToString() == "SUNAT" & TxtNroDocumentoCliente.Text.Length == 8)
                    {
                        TxtRazonSocial.Text = dtres.Rows[0]["nombresapellidos"].ToString();
                        TxtDireccion.Value = "";

                        NombreVia = "";
                        DireccionNumero = "";
                        DireccionInterior = "";
                    }
                    else if (dtres.Rows[0]["FUENTE"].ToString() == "SUNAT" & TxtNroDocumentoCliente.Text.Length == 11)
                    {
                        TxtRazonSocial.Text = dtres.Rows[0]["apenomdenunciado"].ToString();
                        TxtDireccion.Value = dtres.Rows[0]["direstablecimiento"].ToString();

                        NombreVia = "";
                        DireccionNumero = "";
                        DireccionInterior = "";

                    }
                    else if (dtres.Rows[0]["FUENTE"].ToString() == "CLIENTE" | dtres.Rows[0]["FUENTE"].ToString() == "PADRON")
                    {
                        TxtRazonSocial.Text = dtres.Rows[0]["RazonSocial"].ToString();
                        TxtDireccion.Value = dtres.Rows[0]["Direccion"].ToString();

                        NombreVia = dtres.Rows[0]["NombreVia"].ToString();
                        DireccionNumero = dtres.Rows[0]["DireccionNumero"].ToString();
                        DireccionInterior = dtres.Rows[0]["DireccionInterior"].ToString();

                        LblEstadoCliente.Text = "Estado: " + dtres.Rows[0]["ESTADO"].ToString() + ". Condicion domicilio: " + dtres.Rows[0]["CONDICION_DE_DOMICILIO"].ToString();
                    }

                    ClienteID = GuardarCliente(ClienteID);
                }
                else
                {
                    MessageBox.Show("El cliente debe ser ingresado de forma manual (Botón registrar)", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private int GuardarCliente(int cli)
        {
            if (cli == 0)
            {
                E_Cliente ObjCliente = new E_Cliente();



                if (TxtNroDocumentoCliente.Text.Length == 8)
                {
                    ObjCliente.TipoClienteID = 1;
                    ObjCliente.IDTipoDocumento = 2;
                }

                else if (TxtNroDocumentoCliente.Text.Length == 11)
                {
                    ObjCliente.TipoClienteID = 2;
                    ObjCliente.IDTipoDocumento = 1;
                }


                ObjCliente.NroDocumento = TxtNroDocumentoCliente.Text;
                ObjCliente.RazonSocial = TxtRazonSocial.Text;
                ObjCliente.Alias = TxtRazonSocial.Text;
                ObjCliente.Contacto = "";
                ObjCliente.TelefonoFijo = "";
                ObjCliente.TelefonoMovil = "";
                ObjCliente.Fax = "";
                ObjCliente.Email = "";
                ObjCliente.Direccion = TxtDireccion.Value.ToString();

                ObjCliente.DistritoId = DistritoId;
                ObjCliente.ProvinciaId = ProvinciaId;
                ObjCliente.DepartamentoId = DepartamentoId;
                ObjCliente.Nombre1 = "";
                ObjCliente.Nombre2 = "";
                ObjCliente.Apellido1 = "";
                ObjCliente.Apellido2 = "";
                ObjCliente.PaisId = 168;
                ObjCliente.NombreVia = NombreVia;
                //ObjCliente.DireccionViaId = Convert.ToInt16(CboVia.SelectedValue.ToString());
                ObjCliente.DireccionNumero = DireccionNumero;
                ObjCliente.DireccionInterior = DireccionInterior;
                ObjCliente.Observaciones = "";
                ObjCliente.UsuarioID = AppSettings.UserID;

                CL_Cliente ObjCL_Cliente = new CL_Cliente();
                int cliid = ObjCL_Cliente.InsertCliente(ObjCliente);
                return cliid;
            }
            else
                return cli;

        }

        private void BtnSoloBoleta_Click(object sender, EventArgs e)
        {
            ClienteID = 204;
            TxtNroDocumentoCliente.Text = "99999999";
            TxtRazonSocial.Text = "CLIENTES VARIOS";
            TxtDireccion.Value = "";
            CboTipoComprobante.ComboBox.SelectedValue = 4;
            LblEstadoCliente.Text = "";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Mantenimiento.FrmCliente ObjCli = new Mantenimiento.FrmCliente();

            if (ObjCli.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("se guardo volver a consultar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void TxtNroDocumentoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BtnBuscarCliente_Click(null, null);
            }
        }


    }
}



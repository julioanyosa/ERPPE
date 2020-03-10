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


namespace Halley.Presentacion.Ventas
{
    public partial class IngresoManualVenta : UITemplateAccess
    {
        #region Variables

        CL_Comprobante ObjComprobante = new CL_Comprobante();
        CL_Producto ObjCL_Producto = new CL_Producto();
        CL_Venta ObjCL_Venta = new CL_Venta();
        TextFunctions ObjTextFunctions = new TextFunctions();
        CL_Credito ObjCL_Credito = new CL_Credito();
        CL_Pago ObjCL_Pago = new CL_Pago();

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

        string ImpresoraBoletaPeruanaEnvase = AppSettings.ImpresoraBoletaPeruanaEnvase;
        string ImpresoraFacturaPeruanaEnvase = AppSettings.ImpresoraFacturaPeruanaEnvase;
        string ImpresoraTicketPeruanaEnvase = AppSettings.ImpresoraTicketPeruanaEnvase;

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

        decimal IGV = 0;

        string Alias, UnidadMedidaID;
        decimal PrecioUnitario, Cantidad, PrecioVenta, StockDisponible, TotalIGV, Subtotal, TotalPagar;
        string ProductoID, ProductoIDVentas, NomVendedor;
        Int32 VendedorID = 0, ClienteID, estadoID = 0, EstadoIDEntrega = 1, TipoVentaID = 0, NumPedido = 0, HistoricoPrecioID = 0;

        #endregion


        public IngresoManualVenta()
        {
            InitializeComponent();
        }

        private void Permisos()
        {
            DataTable dt = new DataTable();
            dt = AppSettings.AssignedPermission;
            foreach (DataRow row in dt.Rows)
            {

                if (Convert.ToInt64(row["MenuId"]) == 105 && Convert.ToBoolean(row["Actualizacion"]) == false)
                {
                    DtpFechaEmision.Enabled = false;
                    break;
                }
            }
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            //Verificar si tiene permisos para modificar la fecha
            Permisos();

            useCliente2.Cargar(new CL_Cliente().GetClientes());

            //crear tabla para enlazar a la grilla
            DtDetalleComprobante.Columns.Add("ProductoIDVentas", typeof(string));
            DtDetalleComprobante.Columns.Add("ProductoID", typeof(string));
            DtDetalleComprobante.Columns.Add("Alias", typeof(string));
            DtDetalleComprobante.Columns.Add("UnidadMedidaID", typeof(string));
            DtDetalleComprobante.Columns.Add("Cantidad", typeof(decimal)).DefaultValue = 0;
            DtDetalleComprobante.Columns.Add("PrecioUnitario", typeof(decimal));
            DtDetalleComprobante.Columns.Add("PrecioVenta", typeof(decimal)).DefaultValue = 0;
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


            #region optener Nro IP
            String NombreHost;
            String DireccionIP;
            NombreHost = Dns.GetHostName();
            DireccionIP = System.Net.Dns.GetHostByName(NombreHost).AddressList[0] + "";
            //MessageBox.Show(DireccionIP);
            //dar formato a la direccion IP
            string ACU = "";
            string NuevaIP = "";
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

            //traer las cajas de la sede
            DtCajas = ObjComprobante.GetCajasSedeT(NuevaIP);
            if (DtCajas.Rows.Count == 0)
            {
                NumCaja = 0;
                NomCaja = "No existe.";
                MessageBox.Show("Esta direccion IP: #" + DireccionIP + "# no esta asociada a ninguna caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            DtFormaPago = ObjComprobante.getFormaPago();
            CboFormaPago.ComboBox.DataSource = DtFormaPago;
            CboFormaPago.ComboBox.DisplayMember = "NomFormaPago";
            CboFormaPago.ComboBox.ValueMember = "FormaPagoID";

            DtTipoPago = ObjComprobante.getTipoPago();
            CboTipoPago.ComboBox.DataSource = DtTipoPago;
            CboTipoPago.ComboBox.DisplayMember = "NomTipoPago";
            CboTipoPago.ComboBox.ValueMember = "TipoPagoID";

            //obtener todas las sedes
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            CboSede.HoldFields();
            CboSede.DataSource = Dtsedes;
            CboSede.DisplayMember = "NomSede";
            CboSede.ValueMember = "SedeID";

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



            //agregar empresa
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");

            //ocultar lista de creditos
            LstCreditos.Visible = false;
            ocultarToolStrip();
            useCliente2.cbNombre.Text = "CLIENTES VARIOS";
            c1cboCia.SelectedValue = AppSettings.EmpresaID;
            if (c1cboCia.SelectedIndex != -1)
                EmpresaID = c1cboCia.SelectedValue.ToString();

            //traer servicios otros
            DtServicios = ObjCL_Venta.GetServicios();

            this.TdgDocumento.Splits[0].DisplayColumns["Descuento"].Visible = false;
        }

        #region Eventos Click
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChkGratuita.Checked) {
                    if (MessageBox.Show("¿Esta seguro que desea generar una venta gratuita?", "Nueva venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    {
                        return;
                    }
                }

                bool haycero = false;
                string Producto = "";
                foreach (DataRow DrC in DtDetalleComprobante.Rows)
                {
                    if (Convert.ToDecimal(DrC["PrecioVenta"]) == 0)
                    {
                        haycero = true;
                        Producto = DrC["Alias"].ToString();
                    }
                }

                //Validar que no sea "Clientes varios en la factura"
                if (TotalPagar >= 700 & (ClienteID == 1 | ClienteID == 204 | ClienteID == 241 | ClienteID == 3032))
                {
                    MessageBox.Show("si la venta pasa de S/.700 debe exigir datos que identifiquen al cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (CboTipoComprobante.ComboBox.SelectedValue.ToString() == "2" & (ClienteID == 1 | ClienteID == 204 | ClienteID == 241 | ClienteID == 3032))
                {
                    MessageBox.Show("Si es factura debe exigir datos que identifiquen al cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
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

                if (useCliente2.cbCliente.SelectedIndex != -1 & CboTipoComprobante.ComboBox.SelectedValue != null & TxtSerie.Text != "" & TxtSerie.Text.Length == 3 & DtDetalleComprobante.Rows.Count > 0 & NumCaja != 0 & haycero == false & CboTipoPago.SelectedIndex != -1 & CboSede.SelectedIndex != -1 & TxtNumcomprobante.Text.Length == 7)
                {
                    TipoPagoId = Convert.ToInt32(CboTipoPago.ComboBox.SelectedValue);

                    #region crear tabla y agregar el detalle de la compra
                    DataTable DtDetalleComprobanteInsert = new DataTable("detallePedido");
                    DtDetalleComprobanteInsert.Columns.Add("ProductoID", typeof(string));
                    DtDetalleComprobanteInsert.Columns.Add("Cantidad", typeof(decimal));
                    DtDetalleComprobanteInsert.Columns.Add("PrecioUnitario", typeof(decimal));
                    DtDetalleComprobanteInsert.Columns.Add("Importe", typeof(decimal));
                    DtDetalleComprobanteInsert.Columns.Add("FechaReserva", typeof(DateTime));
                    DtDetalleComprobanteInsert.Columns.Add("EstadoID", typeof(int));
                    DtDetalleComprobanteInsert.Columns.Add("AlmacenID", typeof(string));
                    DtDetalleComprobanteInsert.Columns.Add("PesoNeto", typeof(decimal));
                    DtDetalleComprobanteInsert.Columns.Add("HistoricoPrecioID", typeof(int));


                    //insetar los detalles en la tabla creada
                    foreach (DataRow Dr in DtDetalleComprobante.Rows)
                    {
                        DataRow DR = DtDetalleComprobanteInsert.NewRow();
                        DR["ProductoID"] = Dr["ProductoID"];
                        DR["Cantidad"] = Dr["Cantidad"];
                        DR["PrecioUnitario"] = Dr["PrecioUnitario"];
                        DR["Importe"] = Dr["PrecioVenta"];
                        DR["FechaReserva"] = Dr["FechaReserva"];
                        DR["EstadoID"] = Dr["EstadoID"];
                        DR["AlmacenID"] = Dr["AlmacenID"];
                        DR["PesoNeto"] = Dr["PesoNeto"];
                        DR["HistoricoPrecioID"] = Dr["HistoricoPrecioID"];

                        DtDetalleComprobanteInsert.Rows.Add(DR);
                    }
                    #endregion

                    #region guardar el comprobante
                    if (DtDetalleComprobanteInsert.Rows.Count > 0)
                    {
                        E_Comprobante ObjComprobante = new E_Comprobante();
                        ObjComprobante.EmpresaID = EmpresaID;
                        ObjComprobante.SedeID = CboSede.SelectedValue.ToString();
                        ObjComprobante.TipoComprobanteID = Convert.ToInt32(CboTipoComprobante.ComboBox.SelectedValue);
                        ObjComprobante.ClienteID = ClienteID;
                        ObjComprobante.Direccion = useCliente2.txtDireccion.Text;
                        ObjComprobante.TipoVentaID = TipoVentaID;
                        ObjComprobante.TipoPagoId = TipoPagoId;
                        ObjComprobante.FormaPagoID = Convert.ToInt32(CboFormaPago.ComboBox.SelectedValue);
                        ObjComprobante.NumCaja = NumCaja;
                        ObjComprobante.IGV = IGV;
                        ObjComprobante.SubTotal = (ChkGratuita.Checked) ? 0 : Subtotal;
                        ObjComprobante.TotIgv = TotalIGV;
                        if (CboTipoPago.ComboBox.SelectedValue.ToString() == "1")//es credito
                        {
                            if (LstCreditos.SelectedIndex != -1)
                            {
                                ObjComprobante.CreditoID = Convert.ToInt32(LstCreditos.Columns["CreditoID"].Value);
                                estadoID = 14;//comprobante pendiente de pago

                                //validar que el credito disponible sea mayor o igual al monto de la compra
                                if (Convert.ToDecimal(LstCreditos.Columns["CreditoDisponible"].Value) < (Subtotal + TotalIGV))
                                {
                                    MessageBox.Show("El total del comprobante no debe ser mayor al crédito disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Para la opción 'Venta Credito' el cliente debe tener un crédito y este crédito debe estar seleccionado en la lista 'Crédito'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        else if (CboTipoPago.ComboBox.SelectedValue.ToString() == "2")//es contado
                        {
                            estadoID = 12;//comprobante pagado
                        }


                        ObjComprobante.Vendedor = VendedorID;
                        ObjComprobante.Cajero = AppSettings.UserID;
                        ObjComprobante.Serie = TxtSerie.Text;
                        ObjComprobante.EstadoID = estadoID;

                        NumComprobante = EmpresaID + TxtSerie.Text + "-" + TxtNumcomprobante.Text;

                        //validar si es boleta o factura y que el tipo sea el correcto
                        Boolean Validado;
                        Validado = ObjCL_Venta.ValidarDocumento(Convert.ToInt16(useCliente2.cbCliente.Columns["IDTipoDocumento"].Value), Convert.ToInt32(CboTipoComprobante.ComboBox.SelectedValue), ClienteID, "B");

                        if (Validado == false) //No paso control de calidad
                        {
                            MessageBox.Show("En caso de boleta debe ser DNI, En caso de Factura solo RUC. Ticket acepta cualquiera", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        new CL_Comprobante().InsertComprobanteManual(NumComprobante, ObjComprobante, DtDetalleComprobanteInsert, 0, "D", DtValesConsumo, DtpFechaEmision.Value, DtBoucher);


                        //MessageBox.Show("El comprobante se generó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (CboTipoComprobante.ComboBox.SelectedValue.ToString() == "1")//Es boleta
                            LblBoleta.Text = NumComprobante;
                        if (CboTipoComprobante.ComboBox.SelectedValue.ToString() == "2")//Es factura
                            LblFactura.Text = NumComprobante;

                        #region validar varios
                        //MessageBox.Show("Se guardo correctamente el comprobante de pago", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DtDetalleComprobante.Clear();
                        useCliente2.cbNombre.Text = "CLIENTES VARIOS";
                        TxtValorVenta.Value = 0;
                        TxtIGV.Value = 0;
                        TxtVentaNeta.Value = 0;
                        useCliente2.txtDireccion.Text = "";
                        DescontarporValesConsumo = 0;
                        DtValesConsumo.Rows.Clear();// limpiar los vales
                        DtBoucher.Rows.Clear();// limpiar los vales
                        CboFormaPago.ComboBox.SelectedValue = 1;//contado por defecto
                        CboTipoPago.ComboBox.SelectedValue = 2;

                        //aumentar el numcomprobante a +1
                        TxtNumcomprobante.Text = (Convert.ToInt32(TxtNumcomprobante.Text) + 1).ToString().PadLeft(7, '0');
                        #endregion

                    }
                    #endregion
                    Cursor = Cursors.Default;
                    if (NroTerminales == 1)
                    {
                        NomVendedor = "";
                        VendedorID = 0;
                    }
                    LblVendedor.Text = NomVendedor;
                    TxtProducto.Focus();
                    ErrProvider.Clear();
                    MessageBox.Show("Se agrego correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (CboSede.SelectedIndex == -1) { ErrProvider.SetError(CboSede, "Sebe seleccionar una sede, de aqui se descontara los stock."); }
                    if (CboTipoComprobante.ComboBox.SelectedIndex == -1) { ErrProvider.SetError(BtnImprimir, "Seleccione el tipo de comprobante."); }
                    if (TxtSerie.Text.Length != 3) { ErrProvider.SetError(BtnImprimir, "La longitud de la serie no es la correcta."); }
                    if (TxtNumcomprobante.Text.Length != 7) { ErrProvider.SetError(BtnImprimir, "La longitud del numero de documento no es la correcta\rDebeser '0'. no es la correcta."); }
                    if (TdgDocumento.RowCount == 0) { ErrProvider.SetError(TdgDocumento, "No hay Registros que procesar."); }
                    if (NumCaja == 0) { ErrProvider.SetError(BtnImprimir, "Esta terminal no esta asopciada a una caja."); }
                    if (CboTipoPago.SelectedIndex == -1) { ErrProvider.SetError(BtnImprimir, "Seleccione el tipo de pago"); }
                    if (haycero == true) { MessageBox.Show("Hay cero en el precio de venta del producto: " + Producto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    if (useCliente2.cbCliente.SelectedIndex == -1) { ErrProvider.SetError(useCliente2.cbCliente, "No se ha seleccionado un cliente."); }
                }



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

        private void BtnImprimir2_Click(object sender, EventArgs e)
        {
            BtnImprimir_Click(null, null);
        }

        private void BtnNuevoComprobante2_Click(object sender, EventArgs e)
        {
            BtnNuevoComprobante_Click(null, null);
        }

        private void BtnNuevoComprobante_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("¿Esta seguro que desea cancelar la venta?", "Nueva venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //{
            useCliente2.cbNombre.Text = "CLIENTES VARIOS";
            DtDetalleComprobante.Clear();
            TxtIGV.Value = 0;
            TxtValorVenta.Value = 0;
            TxtVentaNeta.Value = 0;
            TxtCodigo.Text = "";
            TxtProducto.Text = "";
            TxtPrecio.Text = "";
            if (RbReserva.Checked == false)
                TxtCantidad.Text = "";
            Alias = "";
            ProductoID = "";
            if (NroTerminales == 1)
                VendedorID = 0;
            LblVendedor.Text = "";
            StockDisponible = 0;
            LblStock.Text = StockDisponible.ToString();
            ChkDescuento.Checked = false;
            ChkFlete.Checked = false;
            ChkGratuita.Checked = false;
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
            ErrProvider.Clear();
            if (e.KeyChar == (char)(Keys.Enter) & TxtCantidad.Text.Length > 0 && Convert.ToDecimal(TxtCantidad.Text) > 0)
            {
                if (Convert.ToDecimal(TxtCantidad.Text) <= StockDisponible)
                {
                    AgregarDetalle(Convert.ToDecimal(TxtCantidad.Text));
                    StockDisponible = 0;
                    LblStock.Text = StockDisponible.ToString();
                    TxtProducto.Focus();
                }
                else
                    MessageBox.Show("Lo solicitado no puede ser mayor al stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                ObjTextFunctions.ValidaNumero(sender, e, TxtCantidad);

            CalcularTotales();

        }

        private void AgregarDetalle(decimal CantidadA)
        {
            decimal NuevoPrecio;
            Cantidad = CantidadA;
            //PrecioVenta = PrecioUnitario * Cantidad;
            if (TxtPrecio.Text.Length == 0 & CantidadA != 0)
            {
                ErrProvider.SetError(TxtPrecio, "Debe ingresar una cantidad valida");
                TxtPrecio.Focus();
                return;
            }
            else if (TxtPrecio.Text.Length != 0)
            {
                PrecioVenta = Convert.ToDecimal(TxtPrecio.Text) * Cantidad;
            }
            else
            {
                PrecioVenta = 0;
            }


            if (ChkSinRedondeo.Checked == false)
                NuevoPrecio = Math.Round(PrecioVenta, 1);
            else
                NuevoPrecio = PrecioVenta;

            if (RbNormal.Checked == true | RbExterno.Checked == true)
            {
                DataRow Dr = DtDetalleComprobante.NewRow();
                Dr["ProductoIDVentas"] = ProductoIDVentas;
                Dr["ProductoID"] = ProductoID;
                Dr["Alias"] = Alias;
                Dr["UnidadMedidaID"] = UnidadMedidaID;
                Dr["Cantidad"] = Cantidad;
                if (TxtPrecio.Text.Length != 0)
                {
                    Dr["PrecioUnitario"] = Convert.ToDecimal(TxtPrecio.Text);
                }
                else
                {
                    Dr["PrecioUnitario"] = 0;
                }

                Dr["PrecioVenta"] = NuevoPrecio;
                if (RbReserva.Checked == true)
                    Dr["FechaReserva"] = FechaReserva;
                else
                    Dr["FechaReserva"] = DBNull.Value;
                Dr["EstadoID"] = EstadoIDEntrega;
                Dr["AlmacenID"] = AlmacenID;
                Dr["HistoricoPrecioID"] = HistoricoPrecioID;
                DtDetalleComprobante.Rows.Add(Dr);
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
                    Dr["PrecioUnitario"] = Convert.ToDecimal(TxtPrecio.Text);
                    Dr["PrecioVenta"] = PrecioVenta;
                    if (RbReserva.Checked == true)
                        Dr["FechaReserva"] = FechaReserva;
                    else
                        Dr["FechaReserva"] = DBNull.Value;
                    Dr["EstadoID"] = EstadoIDEntrega;
                    Dr["HistoricoPrecioID"] = HistoricoPrecioID;
                    DtDetalleComprobante.Rows.Add(Dr);
                }
                else
                    MessageBox.Show("El producto ya ha sido agregado al detalle. En reserva y diferida solo puede almacenar un item por comprobante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            TxtProducto.Text = "";
            TxtCodigo.Text = "";
            if (RbReserva.Checked == false)
            {
                TxtCantidad.Text = "";
            }
            TxtPrecio.Text = "";
            if (NroTerminales == 1)
                TxtCodigo.Focus();
            if (NroTerminales == 3 | NroTerminales == 2)
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

        private void TxtProducto_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                if (TxtProducto.Text.Length > 0)
                {
                    TdgListaProductos.Visible = true;
                    DataView dv = new DataView(DtProductos);
                    dv.RowFilter = "Alias LIKE '" + TxtProducto.Text + "%'";
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

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrProvider.Clear();
            if (e.KeyChar == (char)(Keys.Enter) & TxtCodigo.Text != "" & CboSede.SelectedIndex != -1)
            {
                DtProductos = ObjCL_Producto.GetProductosPrecio(EmpresaID + CboSede.SelectedValue.ToString(), TxtCodigo.Text, "C");

                //si el producto es unico no es necesario mostrar la lista
                if (DtProductos.Rows.Count == 1)
                {

                    AlmacenID = EmpresaID + CboSede.SelectedValue.ToString() + DtProductos.Rows[0]["Almacen"].ToString();

                    if (EmpresaID == "" | CboSede.SelectedValue.ToString() == "" | DtProductos.Rows[0]["Almacen"].ToString() == "" | AlmacenID.Length != 10)
                        MessageBox.Show("El codigo de almacen es = '" + AlmacenID + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                        TxtCodigo.Text = ProductoIDVentas;
                        TxtProducto.Text = Alias;
                        TxtPrecio.Text = PrecioUnitario.ToString();
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
                    if (NroTerminales == 1)
                        TxtCodigo.Focus();
                    else if (NroTerminales == 2)
                        TxtProducto.Focus();
                }
                else
                {
                    TdgListaProductos.Visible = true;
                    TdgListaProductos.SetDataBinding(DtProductos, "", true);
                    TdgListaProductos.Focus();
                }
            }
            else
            {
                if (CboSede.SelectedIndex == -1) { ErrProvider.SetError(CboSede, "Sebe seleccionar una sede, de aqui se descontara los stock."); }
            }
        }

        private void TxtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) & TxtProducto.Text != "" & CboSede.SelectedIndex != -1)
            {
                DtProductos = ObjCL_Producto.GetProductosPrecio(EmpresaID + CboSede.SelectedValue.ToString(), TxtProducto.Text, "A");
                if (DtProductos.Rows.Count == 1)
                {
                    AlmacenID = EmpresaID + CboSede.SelectedValue.ToString() + DtProductos.Rows[0]["Almacen"].ToString();
                    StockDisponible = Convert.ToDecimal(DtProductos.Rows[0]["StockDisponible"]);
                    LblStock.Text = StockDisponible.ToString();
                    ProductoID = DtProductos.Rows[0]["ProductoID"].ToString();
                    ProductoIDVentas = DtProductos.Rows[0]["ProductoIDVentas"].ToString();
                    Alias = DtProductos.Rows[0]["Alias"].ToString();
                    UnidadMedidaID = DtProductos.Rows[0]["UnidadMedidaID"].ToString();
                    PrecioUnitario = Convert.ToDecimal(DtProductos.Rows[0]["PrecioUnitario"].ToString());

                    if (StockDisponible > 0 | RbDiferida.Checked == true | RbReserva.Checked == true)
                    {
                        TxtCodigo.Text = ProductoIDVentas;
                        TxtProducto.Text = Alias;
                        TxtPrecio.Text = PrecioUnitario.ToString();
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
                    if (NroTerminales == 1)
                        TxtCodigo.Focus();
                    else if (NroTerminales == 2)
                        TxtProducto.Focus();
                }
                else
                {
                    TdgListaProductos.Visible = true;
                    TdgListaProductos.SetDataBinding(DtProductos, "", true);
                    TdgListaProductos.Focus();
                }
            }
            else
            {
                if (CboSede.SelectedIndex == -1) { ErrProvider.SetError(CboSede, "Sebe seleccionar una sede, de aqui se descontara los stock."); }
            }
        }
        private void TxtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            ValidarCodigoBarra(TxtCodigo.Text);
        }

        private void TxtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            ValidarCodigoBarra(TxtProducto.Text);
        }
        #endregion

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

                BuscarProducto(TdgDocumento.Columns["ProductoID"].Value.ToString(), TdgDocumento.Columns["Alias"].Value.ToString(), Cantidad);
                SendKeys.Send("{DOWN}");
                if (NroTerminales == 1)
                    TxtCodigo.Focus();
                else
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

        private void TdgDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            String CodigoBarra = TdgDocumento.Columns["Codigo"].Value.ToString();
            if (CodigoBarra.Length == 13 && CodigoBarra.Substring(0, 1) == "2")
            {
                //descomponer el codigo
                string Codigo = "";
                string Articulo = "";
                decimal Cantidad = 0;
                CodigoBarra = TdgDocumento.Columns["Codigo"].Value.ToString();
                Codigo = CodigoBarra.Substring(3, 4);
                Cantidad = Convert.ToDecimal(CodigoBarra.Substring(7, 5)) / 1000;
                BuscarProducto(Codigo, Articulo, Cantidad);
                Calcular();
                CalcularTotales();
                SendKeys.Send("{DOWN}");
            }
        }

        private void TdgListaProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) & TdgListaProductos.RowCount > 0 & CboSede.SelectedIndex != -1)
            {
                AlmacenID = EmpresaID + CboSede.SelectedValue.ToString() + this.TdgListaProductos.Columns["Almacen"].Value.ToString();
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
                    TxtCodigo.Text = ProductoIDVentas;
                    TxtProducto.Text = Alias;
                    TxtPrecio.Text = PrecioUnitario.ToString();
                    TdgListaProductos.Visible = false;
                    if (RbReserva.Checked == true)
                    {
                        BtnReserva_Click(null, null);
                    }
                    else
                    {
                        TxtPrecio.Focus(); //establecer como foco el precio
                    }
                    CalcularTotales();
                }
            }
            else if (e.KeyChar == (char)(Keys.Escape))
            {
                TdgListaProductos.Visible = false;

                TxtCodigo.Text = "";
                TxtProducto.Text = "";
                TxtPrecio.Text = "";
                TdgListaProductos.Visible = false;

                TxtProducto.Focus(); //establecer como foco la el producto
                CalcularTotales();
            }
            else
            {
                if (CboSede.SelectedIndex == -1) { ErrProvider.SetError(CboSede, "Sebe seleccionar una sede, de aqui se descontara los stock."); }
            }
        }



        private void TdgDocumento_AfterDelete(object sender, EventArgs e)
        {
            Calcular();
            CalcularTotales();
        }

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
                TdgDocumento.Columns["Codigo"].Value = Dv[0]["ProductoIDVentas"];
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
            DtProductos = ObjCL_Producto.GetProductosPrecio(EmpresaID + CboSede.SelectedValue.ToString(), Codigo, "C");

            if (DtProductos.Rows.Count == 1)
            {
                ProductoID = DtProductos.Rows[0]["ProductoID"].ToString();
                AlmacenID = EmpresaID + CboSede.SelectedValue.ToString() + DtProductos.Rows[0]["Almacen"].ToString();
                ProductoIDVentas = DtProductos.Rows[0]["ProductoIDVentas"].ToString();
                Alias = DtProductos.Rows[0]["Alias"].ToString();
                UnidadMedidaID = DtProductos.Rows[0]["UnidadMedidaID"].ToString();
                Cantidad = Cantidad2;
                PrecioUnitario = Convert.ToDecimal(DtProductos.Rows[0]["PrecioUnitario"]);
                PrecioVenta = PrecioUnitario * Cantidad;
                StockDisponible = Convert.ToDecimal(DtProductos.Rows[0]["StockDisponible"]);
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
                TxtCodigo.Text = "";
                if (RbReserva.Checked != true)
                {
                    TxtCantidad.Text = "";
                }
                TxtCodigo.Focus();

            }
            else
            {
                MessageBox.Show("No se encontro el producto, verifique su almacen principal, que tenga stock en su almacen principal y que tenga un precio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCodigo.ReadOnly = false;
                TxtCodigo.Text = "";
                TxtCodigo.Focus();
                return;
            }

        }

        private void CalcularTotales()
        {
            if (DtDetalleComprobante.Rows.Count > 0)
            {
                TotalIGV = Convert.ToDecimal(DtDetalleComprobante.Compute("sum(PrecioVenta) *  " + IGV, ""));
                Subtotal = Convert.ToDecimal(DtDetalleComprobante.Compute("sum(PrecioVenta)", "").ToString());
                TotalPagar = Convert.ToDecimal(DtDetalleComprobante.Compute("(sum(PrecioVenta) *  " + IGV + ") + sum(PrecioVenta)", ""));

                TxtIGV.Text = TotalIGV.ToString("C");
                TxtValorVenta.Text = Subtotal.ToString("C");
                TxtVentaNeta.Text = TotalPagar.ToString("C");
            }
            else
            {
                TotalIGV = 0;
                Subtotal = 0;
                TotalPagar = 0;
                descuento = 0;

                TxtIGV.Text = TotalIGV.ToString("C");
                TxtValorVenta.Text = Subtotal.ToString("C");
                TxtVentaNeta.Text = TotalPagar.ToString("C");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //formato para alinear los nuimeros a la derecha
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;
            //formato.LineAlignment = StringAlignment.Far;

            //obtener la cadena del total a pagar
            string TotalPagarLetras = ObjTextFunctions.enletras(TotalPagar.ToString());

            //validar boleta o factura
            #region Boleta
            if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 1)//es boleta
            {
                int sum = 0;
                sum += 12;
                e.Graphics.DrawString(useCliente2.cbNombre.Columns["RazonSocial"].Value.ToString(), TxtPrecio.Font, Brushes.Black, 70 + AppSettings.BoletaEjeX, 156 + AppSettings.BoletaEjeY); //cliente
                if (useCliente2.txtDireccion.Text.Length >= 30)
                    e.Graphics.DrawString(useCliente2.txtDireccion.Text.Substring(0, 29), TxtPrecio.Font, Brushes.Black, 80 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //direccion larga
                else
                    e.Graphics.DrawString(useCliente2.txtDireccion.Text, TxtPrecio.Font, Brushes.Black, 80 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //direccion corta

                e.Graphics.DrawString("", TxtPrecio.Font, Brushes.Black, 40 + AppSettings.BoletaEjeX, 166 + AppSettings.BoletaEjeY); //canasta
                e.Graphics.DrawString(useCliente2.cbCliente.Columns["NroDocumento"].Value.ToString(), TxtPrecio.Font, Brushes.Black, 326 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //ruc o DNI
                e.Graphics.DrawString(DateTime.Now.Date.ToString().Substring(0, 10), TxtPrecio.Font, Brushes.Black, 240 + AppSettings.BoletaEjeX, 136 + AppSettings.BoletaEjeY); //dia
                e.Graphics.DrawString(NumComprobante.Substring(2), TxtPrecio.Font, Brushes.Black, 260 + AppSettings.BoletaEjeX, 117 + AppSettings.BoletaEjeY); //numero de comprobante

                int Suma = 238;
                foreach (DataRow Dr in DtDetalleComprobante.Rows)
                {
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Cantidad"]).ToString("#,##0.00") + " " + Dr["UnidadMedidaID"].ToString(), TxtPrecio.Font, Brushes.Black, 65 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //cantidad + UM
                    e.Graphics.DrawString(Dr["Alias"].ToString(), TxtPrecio.Font, Brushes.Black, 75 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY); //descripcion o producto
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["PrecioUnitario"]).ToString("#,##0.00"), TxtPrecio.Font, Brushes.Black, 320 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //precio unitario
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["PrecioVenta"]).ToString("#,##0.00"), TxtPrecio.Font, Brushes.Black, 380 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //valor de venta
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
                e.Graphics.DrawString(useCliente2.cbNombre.Columns["RazonSocial"].Value.ToString(), TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 117 + AppSettings.FacturaEjeY); //cliente
                //e.Graphics.DrawString(useCliente2.txtDireccion.Text, TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion
                if (useCliente2.txtDireccion.Text.Length >= 95)
                    e.Graphics.DrawString(useCliente2.txtDireccion.Text.Substring(0, 94), TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion
                else
                    e.Graphics.DrawString(useCliente2.txtDireccion.Text, TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion

                e.Graphics.DrawString(useCliente2.cbCliente.Columns["NroDocumento"].Value.ToString(), TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //ruc o DNI
                e.Graphics.DrawString(DateTime.Now.Day.ToString(), TxtPrecio.Font, Brushes.Black, 570 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //dia
                e.Graphics.DrawString(DateTime.Now.ToString("MMMM"), TxtPrecio.Font, Brushes.Black, 650 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //mes
                e.Graphics.DrawString(DateTime.Now.Year.ToString().Substring(2), TxtPrecio.Font, Brushes.Black, 810 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //año
                e.Graphics.DrawString(NumComprobante.Substring(2), TxtPrecio.Font, Brushes.Black, 690 + AppSettings.FacturaEjeX, 147 + AppSettings.FacturaEjeY); //numero de comprobante

                int Suma = 230;
                foreach (DataRow Dr in DtDetalleComprobante.Rows)
                {
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Cantidad"]).ToString("#,##0.00") + " " + Dr["UnidadMedidaID"].ToString(), TxtPrecio.Font, Brushes.Black, 80 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //cantidad + UM
                    e.Graphics.DrawString(Dr["Alias"].ToString(), TxtPrecio.Font, Brushes.Black, 110 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY); //descripcion o producto
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["PrecioUnitario"]).ToString("#,##0.00"), TxtPrecio.Font, Brushes.Black, 665 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //precio unitario
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["PrecioVenta"]).ToString("#,##0.00"), TxtPrecio.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //valor de venta
                    Suma += 14;
                }

                e.Graphics.DrawString(TxtValorVenta.Text, TxtPrecio.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 427 + AppSettings.FacturaEjeY, formato); //subtotal
                e.Graphics.DrawString(TxtIGV.Text, TxtPrecio.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 447 + AppSettings.FacturaEjeY, formato); //igv
                e.Graphics.DrawString(TxtVentaNeta.Text, TxtPrecio.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 477 + AppSettings.FacturaEjeY, formato); //total

                e.Graphics.DrawString(DateTime.Now.Day.ToString(), TxtPrecio.Font, Brushes.Black, 405 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //dia pie
                e.Graphics.DrawString(DateTime.Now.ToString("MMMM"), TxtPrecio.Font, Brushes.Black, 465 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //mes pie
                e.Graphics.DrawString(DateTime.Now.Year.ToString().Substring(2), TxtPrecio.Font, Brushes.Black, 545 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //año pie

                e.Graphics.DrawString(TotalPagarLetras, TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 407 + AppSettings.FacturaEjeY); //total pagar en letras
            }
            #endregion

        }
        private void ValidarCodigoBarra(string CodigoDeBarra)
        {
            if (CodigoDeBarra.Length > 0)
            {
                if (CodigoDeBarra.Length == 13 & CodigoDeBarra.Substring(0, 1) == "2")//es producto
                {
                    //se oculta la grilla
                    TdgListaProductos.Visible = false;
                    //descomponer el codigo
                    string Codigo = "";
                    string Articulo = "";
                    decimal Cantidad = 0;
                    Codigo = CodigoDeBarra.Substring(3, 4);
                    Cantidad = Convert.ToDecimal(CodigoDeBarra.Substring(7, 5)) / 1000;
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
                        TxtCodigo.Text = "";
                        TxtProducto.Text = "";
                        TxtCodigo.Focus();
                    }
                }
            }
        }

        private void Calcular()
        {
            if (TdgDocumento.Columns["Cantidad"].Value + "" != "" & TdgDocumento.Columns["PrecioUnitario"].Value + "" != "")
            {
                TdgDocumento.Columns["PrecioVenta"].Value = decimal.Round(Convert.ToDecimal(TdgDocumento.Columns["Cantidad"].Value) * Convert.ToDecimal(TdgDocumento.Columns["PrecioUnitario"].Value), 1);
            }
        }
        #endregion



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

        private void useCliente2_ComboValueChange()
        {
            ClienteID = Convert.ToInt32(useCliente2.cbCliente.SelectedValue);
            if (CboTipoPago.SelectedIndex != -1 && CboTipoPago.ComboBox.SelectedValue.ToString() == "1")//es credito
            {
                CboTipoPago_SelectedIndexChanged(null, null);
            }
        }

        private void BtnReserva_Click(object sender, EventArgs e)
        {
            Alias = TxtProducto.Text;
            ProductoID = TxtCodigo.Text;
            if (Alias != "" & ProductoID != "")
            {
                FrmReserva ObjFrmReserva = new FrmReserva();
                ObjFrmReserva.Alias = Alias;
                ObjFrmReserva.ProductoID = ProductoID;
                ObjFrmReserva.ShowDialog();

                if (ObjFrmReserva.Aprobado == true)
                {
                    FechaReserva = ObjFrmReserva.FechaReserva;
                    AgregarDetalle(ObjFrmReserva.Cantidad);
                }
                Calcular();
                CalcularTotales();
                TxtProducto.Text = "";
                TxtCodigo.Text = "";
                if (RbReserva.Checked == false)
                    TxtCantidad.Text = "";
                TxtPrecio.Text = "";
                TxtCodigo.Focus();
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
                        BtnNuevoComprobante_Click(null, null);
                    }
                }
            }
            DtDetalleComprobante.Rows.Clear();
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
            ObjFrmGuias.Destinatario = useCliente2.cbNombre.Columns["RazonSocial"].ToString();
            ObjFrmGuias.RUCDestinatario = useCliente2.cbCliente.Columns["NroDocumento"].ToString();
            ObjFrmGuias.Remitente = c1cboCia.Columns["NomEmpresa"].ToString();
            ObjFrmGuias.RUCRemitente = c1cboCia.Columns["RUC"].ToString();
            ObjFrmGuias.DtServicios = DtServicios;
            ObjFrmGuias.ShowDialog();
        }

        private void TdgDocumento_BeforeUpdate(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
            Calcular();
            CalcularTotales();
        }

        private void ChkDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDescuento.Checked == true)
            {
                descuento = 1;
                //muestra el descuento
                //this.TdgDocumento.Splits[0].DisplayColumns["Descuento"].Visible = true;
                //agrega el producto "descuento"
                DataView Dv = new DataView(DtServicios);
                Dv.RowFilter = "Tipo='-'";

                AlmacenID = EmpresaID + CboSede.SelectedValue.ToString() + "DES";//existe pero no vaa disminuir nada
                StockDisponible = 1;
                LblStock.Text = StockDisponible.ToString();
                ProductoID = Dv[0]["ProductoID"].ToString();
                ProductoIDVentas = Dv[0]["ProductoID"].ToString();
                Alias = Dv[0]["Alias"].ToString();
                UnidadMedidaID = Dv[0]["UnidadMedidaID"].ToString();
                PrecioUnitario = Convert.ToDecimal(Dv[0]["PrecioUnitario"].ToString());
                //calcular el descuento
                foreach (DataRow Dr in DtDetalleComprobante.Rows)
                {
                    descuento += Convert.ToDecimal(Dr["Descuento"]) * Convert.ToDecimal(Dr["Cantidad"]);
                }

                //actualizar el descuento
                TxtPrecio.Text = "0";
                AgregarDetalle(descuento * -1);
                TxtPrecio.Text = "";
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

        private void TdgDocumento_AfterUpdate(object sender, EventArgs e)
        {
            ////se actualiza la cantidad del descuento
            //descuento = 0;
            ////calcular el descuento
            //foreach (DataRow Dr in DtDetalleComprobante.Rows)
            //{
            //    descuento += Convert.ToDecimal(Dr["Descuento"]) * Convert.ToDecimal(Dr["Cantidad"]);
            //}
            ////agrega el producto "descuento"
            //DataView Dv = new DataView(DtServicios);
            //Dv.RowFilter = "Tipo='-'";

            //DataView Dv2 = new DataView(DtDetalleComprobante);
            //Dv2.RowFilter = "ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'";
            //if (Dv2.Count > 0)
            //{
            //    DataRow[] customerRow = DtDetalleComprobante.Select("ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'");
            //    customerRow[0]["Cantidad"] = descuento * -1;
            //    customerRow[0]["PrecioVenta"] = decimal.Round((descuento * -1) * Convert.ToDecimal(Dv[0]["PrecioUnitario"]));
            //    //customerRow[0]["PrecioVenta"] = decimal.Round((descuento * -1) * Convert.ToDecimal(TdgDocumento.Columns["PrecioUnitario"].Value));
            //}

            //agrega el producto "descuento"
            DataView Dv = new DataView(DtServicios);
            Dv.RowFilter = "Tipo='-'";

            DataView Dv2 = new DataView(DtDetalleComprobante);
            Dv2.RowFilter = "ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'";
            if (Dv2.Count > 0)
            {
                descuento = Math.Abs(Convert.ToDecimal(Dv2[0]["Cantidad"]));
                DataRow[] customerRow = DtDetalleComprobante.Select("ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'");
                customerRow[0]["Cantidad"] = descuento * -1;
                customerRow[0]["PrecioUnitario"] = Convert.ToDecimal(Dv[0]["PrecioUnitario"]);
                customerRow[0]["PrecioVenta"] = decimal.Round((descuento * -1) * Convert.ToDecimal(Dv[0]["PrecioUnitario"]));
                //customerRow[0]["PrecioVenta"] = decimal.Round((descuento * -1) * Convert.ToDecimal(TdgDocumento.Columns["PrecioUnitario"].Value));
                DtDetalleComprobante.AcceptChanges();
            }
            Calcular();
            CalcularTotales();
        }

        private void TdgDocumento_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {

            DataView Dv = new DataView(DtServicios);
            Dv.RowFilter = "Tipo='-'";
            //deshabilitar para que no se modifique el decuento
            switch (e.Column.DataColumn.DataField)
            {
                //case "Cantidad":
                //    if (this.TdgDocumento[e.Row, "ProductoID"].ToString().Trim() == Dv[0]["ProductoID"].ToString())
                //    {
                //        e.CellStyle.Locked = true;
                //        break;
                //    }
                //    break;
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

        private void ChkFlete_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFlete.Checked == true)
            {
                //agrega el producto "flete"
                DataView Dv = new DataView(DtServicios);
                Dv.RowFilter = "Tipo='+'";

                AlmacenID = EmpresaID + CboSede.SelectedIndex.ToString() + "DES"; //existe pero no vaa disminuir nada
                StockDisponible = 1;
                LblStock.Text = StockDisponible.ToString();
                ProductoID = Dv[0]["ProductoID"].ToString();
                ProductoIDVentas = Dv[0]["ProductoID"].ToString();
                Alias = Dv[0]["Alias"].ToString();
                UnidadMedidaID = Dv[0]["UnidadMedidaID"].ToString();
                PrecioUnitario = Convert.ToDecimal(Dv[0]["PrecioUnitario"].ToString());

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

                Calcular();
                CalcularTotales();
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

        private void TdgDocumento_DoubleClick(object sender, EventArgs e)
        {
            TxtPrecio.Focus();
        }

        private void TxtPrecio_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) & TdgListaProductos.RowCount > 0 & CboSede.SelectedIndex != -1)
            {
                TxtCantidad.Focus();
            }
        }

        private void TdgListaProductos_DoubleClick(object sender, EventArgs e)
        {
            AlmacenID = EmpresaID + CboSede.SelectedValue.ToString() + this.TdgListaProductos.Columns["Almacen"].Value.ToString();
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
                TxtCodigo.Text = ProductoIDVentas;
                TxtProducto.Text = Alias;
                TxtPrecio.Text = PrecioUnitario.ToString();
                TdgListaProductos.Visible = false;
                if (RbReserva.Checked == true)
                {
                    BtnReserva_Click(null, null);
                }
                else
                {
                    TxtPrecio.Focus(); //establecer como foco el precio
                }
                CalcularTotales();
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (TxtCantidad.Text.Length > 0 && Convert.ToDecimal(TxtCantidad.Text) > 0)
            {
                if (Convert.ToDecimal(TxtCantidad.Text) <= StockDisponible)
                {
                    AgregarDetalle(Convert.ToDecimal(TxtCantidad.Text));
                    StockDisponible = 0;
                    LblStock.Text = StockDisponible.ToString();
                    TxtProducto.Focus();
                }
                else
                    MessageBox.Show("Lo solicitado no puede ser mayor al stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            CalcularTotales();
        }



    }
}





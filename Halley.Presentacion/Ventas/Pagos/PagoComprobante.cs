using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.Configuracion;
using Halley.CapaLogica.Ventas;
using Halley.CapaDatos.Ventas;
using Halley.Entidad.Ventas;
using System.Net;
using Halley.Presentacion.Almacen.Operaciones;
using Halley.Utilitario;
using Halley.CapaLogica.Empresa;
using ThoughtWorks.QRCode.Codec;

namespace Halley.Presentacion.Ventas.Pagos
{
    public partial class PagoComprobante : UITemplateAccess
    {
        #region variables globales
        DataTable DtCajas = new DataTable();
        DataTable DtCreditos = new DataTable();
        DataTable dtSerie;
        DataTable DtTipoComprobante;
        DataSet dsPedido = new DataSet();
        DataTable DtDetalleGuiaRemisionVenta = new DataTable("DetalleGuiaRemisionVenta");
        DataTable DtServicios = new DataTable();
        DataTable DtEmpresas = new DataTable();
        int NumPedido;
        int ClienteID;
        int VendedorID;
        int IGV;
        int estadoID;
        int? NumVale = null;
        int? formaPago;
        int TipoVentaID;
        decimal subTotal, TotalIGV, Total, TotalPagar, montoimpuestobolsa;
        string NumComprobante;
        bool validarCheck = false, vale;
        int NumCaja;
        string NomCaja = "";
        string EmpresaID = "";
        CL_Credito ObjCL_Credito = new CL_Credito();
        CL_Comprobante ObjComprobante = new CL_Comprobante();
        TextFunctions ObjTextFunctions = new TextFunctions();
        CL_Venta ObjCL_Venta = new CL_Venta();
        CL_NotaCredito ObjCL_NotaCredito = new CL_NotaCredito();
        DataTable DtValesConsumo = new DataTable("ValesConsumo");
        DataTable DtBoucher = new DataTable("Boucher");
        decimal DescontarporValesConsumo = 0;
        string NroDocumento = "", Cliente = "";
        DataTable DtNotaIngreso = new DataTable();
        string NuevaIP = "";
        int IDTipoDocumento = 0;
        string TipoTicket = null;

        Boolean ConCliente = true;
        DateTime FECHA_IMPRESION;
        CapaLogica.Users.CL_Usuario ObjUsuario = new CapaLogica.Users.CL_Usuario();


        DataTable Dtempresas = new DataTable();
        DataTable DtserieGuias = new DataTable();

        DataTable DtDatosSede;
        int hojaimpresa = 1;
        #endregion

        #region constructor
        public PagoComprobante()
        {
            InitializeComponent();
        }
        #endregion

        #region eventos de los controles


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (txtNumPedido.Text.Length > 0)
                {
                    NumPedido = int.Parse(txtNumPedido.Text);
                    dsPedido = new CL_OrdenPedido().getOrdenPedido2(NumPedido);

                    CboTipoComprobante.SelectedIndex = -1;

                    if (dsPedido.Tables["Pedido"].Rows.Count > 0)
                    {
                        IDTipoDocumento = (int)dsPedido.Tables["Pedido"].Rows[0]["IDTipoDocumento"];
                        ClienteID = (int)dsPedido.Tables["Pedido"].Rows[0]["ClienteID"];
                        lblCliente.Text = dsPedido.Tables["Pedido"].Rows[0]["RazonSocial"].ToString();
                        lblDocumento.Text = dsPedido.Tables["Pedido"].Rows[0]["NroDocumento"].ToString();
                        lblDireccion.Text = dsPedido.Tables["Pedido"].Rows[0]["Direccion"].ToString();
                        label11.Text = dsPedido.Tables["Pedido"].Rows[0]["TipoDocumento"].ToString();

                        VendedorID = (int)dsPedido.Tables["Pedido"].Rows[0]["UsuarioID"];
                        lblVendedor.Text = dsPedido.Tables["Pedido"].Rows[0]["Descripcion"].ToString();
                        lblComentario.Text = dsPedido.Tables["Pedido"].Rows[0]["Comentario"].ToString();

                        chkExterno.Checked = Convert.ToBoolean(dsPedido.Tables["Pedido"].Rows[0]["Externa"]);
                        vale = Convert.ToBoolean(dsPedido.Tables["Pedido"].Rows[0]["Vale"]);

                        LblEmpresa.Text = dsPedido.Tables["Pedido"].Rows[0]["NomEmpresa"].ToString();
                        LblRUC.Text = dsPedido.Tables["Pedido"].Rows[0]["RUC"].ToString();

                        if (dsPedido.Tables["Pedido"].Rows[0]["NumVale"] != DBNull.Value)
                            NumVale = Convert.ToInt32(dsPedido.Tables["Pedido"].Rows[0]["NumVale"]);

                        TipoVentaID = Convert.ToInt32(dsPedido.Tables["Pedido"].Rows[0]["TipoVentaID"]);

                        EmpresaID = dsPedido.Tables["Pedido"].Rows[0]["EmpresaID"].ToString();


                        DtDatosSede = ObjCL_Venta.ObtenerDatosSucursal(EmpresaID, AppSettings.SedeID);

                        CboTipoComprobante.Enabled = true;
                        cbTipoPago.Enabled = true;
                        cbFormaPago.Enabled = true;
                        /*}*/

                        IGV = (int)dsPedido.Tables["Pedido"].Rows[0]["IGV"];
                        subTotal = Convert.ToDecimal(dsPedido.Tables["Pedido"].Rows[0]["SubTotal"]);
                        TotalIGV = Convert.ToDecimal(dsPedido.Tables["Pedido"].Rows[0]["TotalIGV"]);
                        montoimpuestobolsa = Convert.ToDecimal(dsPedido.Tables["Pedido"].Rows[0]["TotalICBPER"]);

                       
                        Total = subTotal + TotalIGV + montoimpuestobolsa;
                        TotalPagar = Math.Floor(Total) + (Math.Floor(((Total - Math.Floor(Total)) * 10)) / 10);

                        lblSubTotal.Text = subTotal.ToString("C");
                        lblIGV.Text = TotalIGV.ToString("C");
                        lblTotVenta.Text = Total.ToString("C");
                        lblTotPagar.Text = TotalPagar.ToString("C");
                        TxtICBPER.Text = montoimpuestobolsa.ToString("C");

                        if (EmpresaID == "IH")
                            TxtMontoPagado.Text = TotalPagar.ToString();
                        else
                            TxtMontoPagado.Text = "0";

                        tdbgPedidos.SetDataBinding(dsPedido.Tables["detallePedido"], "", true);
                        dsPedido.Tables["detallePedido"].Columns["PesoNeto"].ReadOnly = false;
                        btnRegistrar.Enabled = true;
                        btnCancelar.Enabled = true;

                        if (ObjCL_Venta.HABILITADOFE2(EmpresaID))
                        {
                            CboTipoComprobante.SelectedValue = 4;
                        }
                        else
                        {
                            CboTipoComprobante.SelectedValue = 3;
                        }

                        cbTipoPago.SelectedValue = 2;
                        cbFormaPago.SelectedValue = 1;

                        ValidarTipoFactura();


                    }
                    else
                    {
                        Limpiar();
                        btnRegistrar.Enabled = false;
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListComprobante_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            Cargar();
            PnlCreditos.Visible = false;
            btnRegistrar.Enabled = false;
            #region varios
            CboTipoComprobante.SelectedValue = 3;
            cbTipoPago.SelectedValue = 2;
            cbFormaPago.SelectedValue = 1;
            #endregion

            //agregar empresa
            c1Combo.FillC1Combo(this.c1cboCia, DtEmpresas, "NomEmpresa", "EmpresaID");

            //traer impresoras
            UTI_Datatables.Dt_Configuracion = ObjUsuario.USP_M_CONFIGURACION(2, 0, "", "", "", "", AppSettings.UserID, NuevaIP);

            //tarer empresas
            Dtempresas = new CL_Empresas().GetEmpresas();
            DtserieGuias = ObjComprobante.GetSerieGuiasT(AppSettings.SedeID);//las series
        }

        void ValidarTipoFactura()
        {
            if (lblDocumento.Text.Length == 11 & Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3)
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

        private void cbComprobante_SelectedValueChanged(object sender, EventArgs e)
        {
            ValidarTipoFactura();

            if (CboTipoComprobante.SelectedIndex != -1 & dtSerie.Rows.Count > 0 & EmpresaID != "")
            {
                DataView Dv = new DataView(dtSerie);
                Dv.RowFilter = "TipoDocumento = '" + Convert.ToInt32(CboTipoComprobante.SelectedValue) + "' and EmpresaID = '" + EmpresaID + "'";
                c1Combo.FillC1Combo1(CboSerieGuia, Dv.ToTable(), "Serie", "Serie");

                if (Dv.Count == 0)
                {
                    CboSerieGuia.SelectedIndex = -1;
                    CboSerieGuia.Text = "";
                }
                else if (Dv.Count == 1)
                {
                    CboSerieGuia.SelectedIndex = 0;
                }

                //seleccionar la serie por defecto
                switch (CboTipoComprobante.SelectedValue.ToString())
                {
                    case "1":
                        if (EmpresaID == "PE")
                        {
                            if (AppSettings.PESerieDefectoBoleta != "")
                                CboSerieGuia.SelectedValue = AppSettings.PESerieDefectoBoleta;
                        }

                        break;
                    case "2":
                        if (EmpresaID == "PE")
                        {
                            if (AppSettings.PESerieDefectoFactura != "")
                                CboSerieGuia.SelectedValue = AppSettings.PESerieDefectoFactura;
                        }

                        break;
                    case "3":
                        if (EmpresaID == "PE")
                        {
                            if (AppSettings.PESerieDefectoTicket != "")
                                CboSerieGuia.SelectedValue = AppSettings.PESerieDefectoTicket;
                        }

                        break;
                }

                if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1)//es boleta
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
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2)//es factura
                {
                    //tamaño de la Factura
                    printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("FacturaHalley", 810, 550);
                    printDocument1.DefaultPageSettings.Margins.Left = 0;
                    printDocument1.DefaultPageSettings.Margins.Right = 0;
                    printDocument1.DefaultPageSettings.Margins.Top = 0;
                    printDocument1.DefaultPageSettings.Margins.Bottom = 0;
                    printDocument1.OriginAtMargins = true;
                    //printDocument1.DefaultPageSettings.Landscape = false;
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3 |
                 Convert.ToInt16(CboTipoComprobante.SelectedValue) == 4 |
                 Convert.ToInt16(CboTipoComprobante.SelectedValue) == 5)//es ticket
                {
                    printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.USStandardFanfold;
                    //MessageBox.Show(printDocument1.DefaultPageSettings.PaperSize.RawKind.ToString());
                }

            }
            else
            {
                CboSerieGuia.SelectedIndex = -1;
                CboSerieGuia.Text = "";
            }
        }

        private void txtNumPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) & Convert.ToDecimal(txtNumPedido.Text.Length) > 0)
            {
                btnBuscar_Click(null, null);
            }
            else
                new TextFunctions().SoloNumero(sender, e, txtNumPedido);
        }

        private void txtNumPedido_TextChanged(object sender, EventArgs e)
        {
            if (txtNumPedido.TextLength != 0)
                btnBuscar.Enabled = true;
            else
                btnBuscar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cbTipoPago_SelectedValueChanged(object sender, EventArgs e)
        {
            DtCreditos = new DataTable();
            if (cbTipoPago.SelectedValue != null)
            {
                if (cbTipoPago.SelectedValue.ToString() == "1")
                {
                    cbFormaPago.Text = "";
                    cbFormaPago.Enabled = false;
                    PnlCreditos.Visible = true;

                    //traer créditos
                    DtCreditos = ObjCL_Credito.GetCreditosCliente(ClienteID, "A");
                    LstCreditos.HoldFields();
                    LstCreditos.DataSource = DtCreditos;
                }
                else
                {
                    cbFormaPago.Visible = true;
                    PnlCreditos.Visible = false;
                    cbFormaPago.Text = "[Seleccionar]";
                    cbFormaPago.Enabled = true;
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Generar();

        }

        #endregion

        #region metodos definidos

        private void Generar()
        {
            try
            {

                if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3)
                {
                    if (ChkEsTicketFactura.Checked == true)
                        TipoTicket = "F";
                    else
                        TipoTicket = "B";
                }
                else
                    TipoTicket = null;


                if (IsNumeric(TxtMontoPagado.Text) == false || Convert.ToDecimal(TxtMontoPagado.Text) < TotalPagar)
                {
                    MessageBox.Show("Ingrese monto a pagar válido y que sea mayor o igual al monto a pagar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtMontoPagado.Focus();
                    return;
                }


                if (ClienteID == 1 | ClienteID == 204 | ClienteID == 241 | ClienteID == 3032)
                    ConCliente = false;
                else
                    ConCliente = true;


                if (CboTipoComprobante.SelectedValue.ToString() == "2" & (ClienteID == 1 | ClienteID == 204 | ClienteID == 241 | ClienteID == 3032))
                {
                    MessageBox.Show("Si es factura debe exigir datos que identifiquen al cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                validarCheck = false;
                Cursor = Cursors.WaitCursor;
                errValidar.Clear();
                btnRegistrar.Enabled = false;
                if (CboTipoComprobante.SelectedValue == null) { errValidar.SetError(CboTipoComprobante, "Seleccione el Comprobante"); validarCheck = true; }
                if (CboSerieGuia.SelectedValue == null) { errValidar.SetError(CboSerieGuia, "Seleccione la serie"); validarCheck = true; }
                if (LblCaja.Text == "") { errValidar.SetError(LblCaja, "No esta amarrado a una caja"); validarCheck = true; }
                if (cbTipoPago.SelectedValue == null) { errValidar.SetError(cbTipoPago, "Seleccione el tipo de pago"); validarCheck = true; }
                else if (cbFormaPago.SelectedValue == null && cbTipoPago.SelectedValue.ToString() != "1")
                {
                    errValidar.SetError(cbFormaPago, "Seleccione la forma de pago");
                    validarCheck = true;
                }

                if (validarCheck == true) { Cursor = Cursors.Default; btnRegistrar.Enabled = true; return; }
                else { validarCheck = false; }


                if (cbTipoPago.SelectedValue.ToString().Equals("1"))
                    estadoID = (int)Enums.Comprobante.Pendiente;
                else
                    estadoID = (int)Enums.Comprobante.Pagado;

                if (cbFormaPago.SelectedValue == null)
                    formaPago = null;
                else
                    formaPago = Convert.ToInt32(cbFormaPago.SelectedValue);

                E_Comprobante ObjComprobante = new E_Comprobante();
                E_Pago ObjPago = new E_Pago();

                //validar si es boleta o factura y que el tipo sea el correcto
                Boolean Validado;
                Validado = ObjCL_Venta.ValidarDocumento(IDTipoDocumento, Convert.ToInt32(CboTipoComprobante.SelectedValue), ClienteID, TipoTicket);

                if (Validado == false) //No paso control de calidad
                {
                    MessageBox.Show("En caso de boleta debe ser DNI, En caso de Factura solo RUC. Ticket acepta cualquiera", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Cursor = Cursors.Default;
                    btnRegistrar.Enabled = true;
                    return;
                }

                ObjComprobante.EmpresaID = EmpresaID;
                ObjComprobante.SedeID = AppSettings.SedeID;
                ObjComprobante.TipoComprobanteID = Convert.ToInt32(CboTipoComprobante.SelectedValue);
                ObjComprobante.ClienteID = ClienteID;
                ObjComprobante.Direccion = lblDireccion.Text;
                ObjComprobante.TipoVentaID = TipoVentaID;
                ObjComprobante.TipoPagoId = Convert.ToInt32(cbTipoPago.SelectedValue);
                ObjComprobante.FormaPagoID = formaPago;
                ObjComprobante.NumCaja = NumCaja;
                ObjComprobante.IGV = IGV;
                ObjComprobante.SubTotal = subTotal;
                ObjComprobante.TotIgv = TotalIGV;
                ObjComprobante.Vendedor = VendedorID;
                ObjComprobante.Cajero = AppSettings.UserID;
                ObjComprobante.Serie = CboSerieGuia.Text;
                ObjComprobante.TipoTicket = TipoTicket;

                if (cbTipoPago.SelectedValue.ToString() == "1")//es credito
                {
                    if (LstCreditos.SelectedIndex != -1)
                    {
                        ObjComprobante.CreditoID = Convert.ToInt32(LstCreditos.Columns["CreditoID"].Value);
                        estadoID = 14;//comprobante pendiente de pago

                        //validar que el credito disponible sea mayor o igual al monto de la compra
                        if (Convert.ToDecimal(LstCreditos.Columns["CreditoDisponible"].Value) < (subTotal + TotalIGV))
                        {
                            MessageBox.Show("El total del comprobante no debe ser mayor al crédito disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Cursor = Cursors.Default;
                            btnRegistrar.Enabled = true;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para la opción 'Venta Credito' el cliente debe tener un crédito y este crédito debe estar seleccionado en la lista 'Crédito'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnRegistrar.Enabled = true;
                        Cursor = Cursors.Default;
                        return;
                    }
                }
                else if (cbTipoPago.SelectedValue.ToString() == "2")//es contado
                {
                    estadoID = 12;//comprobante pagado
                }

                ObjComprobante.EstadoID = estadoID;
                ObjComprobante.Externa = chkExterno.Checked;
                ObjComprobante.Vale = vale;
                ObjComprobante.NumVale = NumVale;
                ObjComprobante.TotalICBPER = montoimpuestobolsa;
                ObjComprobante.MontoPagado = TotalPagar;

                //validar impresora
                string EMPRESA_ID = c1cboCia.SelectedValue.ToString();
                string TIPO_COMPROBANTE = "";
                if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1)
                {
                    TIPO_COMPROBANTE = "BO";
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2)
                {
                    TIPO_COMPROBANTE = "FA";
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3 |
                            Convert.ToInt16(CboTipoComprobante.SelectedValue) == 4 |
                            Convert.ToInt16(CboTipoComprobante.SelectedValue) == 5)
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
                    MessageBox.Show("Al parecer no se ha seleccionado la impresora. No se imprimira el comprobante.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnRegistrar.Enabled = true;
                    Cursor = Cursors.Default;
                    return;
                }
                else
                {
                    DataTable dt = new DataTable();

                    dt = new CL_Comprobante().InsertComprobante(ObjComprobante, dsPedido.Tables["detallePedido"], NumPedido, "D", DtValesConsumo, DtBoucher, DtNotaIngreso);

                    NumComprobante = dt.Rows[0]["NumComprobante"].ToString();
                    FECHA_IMPRESION = Convert.ToDateTime(dt.Rows[0]["FECHA_ACTUAL"].ToString());

                    hojaimpresa = 1;
                    printDocument1.Print();//manda a imprimnir

                    if (CboTipoComprobante.SelectedValue.ToString() == "1")//Es boleta
                        LblBoleta.Text = NumComprobante;
                    if (CboTipoComprobante.SelectedValue.ToString() == "2")//Es factura
                        LblFactura.Text = NumComprobante;

                    /*if (cbTipoPago.SelectedValue.ToString() == "2")//es contado
                    {
                        ObjPago.NumComprobante = NumComprobante;
                        ObjPago.TipoComprobanteID = ObjComprobante.TipoComprobanteID;
                        ObjPago.Importe = Total;
                        ObjPago.FormaPagoID = ObjComprobante.FormaPagoID;
                        ObjPago.UsuarioID = ObjComprobante.Cajero;

                        new CL_Pago().InsertPago(ObjPago);
                    }*/

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
                    DescontarporValesConsumo = 0;
                    DtValesConsumo.Rows.Clear();// limpiar los vales
                    DtBoucher.Rows.Clear();// limpiar los vales
                    DtNotaIngreso.Rows.Clear();//limpia los adelantos
                    #endregion
                    //MessageBox.Show("El comprobante se generó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //if (MessageBox.Show("¿Desea generar guias?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    //    BtnGenerarGuias_Click(null, null);
                    //}
                    BtnNuevoComprobante_Click(null, null);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor = Cursors.Default;
            }
        }

        private void Limpiar()
        {
            dsPedido.Clear();
            tdbgPedidos.SetDataBinding(null, "", true);
            txtNumPedido.Text = "";
            lblCliente.Text = "";
            lblDocumento.Text = "";
            lblDireccion.Text = "";
            lblVendedor.Text = "";
            lblComentario.Text = "";
            LblEmpresa.Text = "";
            LblRUC.Text = "";

            CboSerieGuia.Text = "";

            lblSubTotal.Text = "0";
            lblTotVenta.Text = "0";
         
            TxtICBPER.Text = "0";
            lblIGV.Text = "0";
            TxtMontoPagado.Text = "0";
            btnRegistrar.Enabled = false;
            btnCancelar.Enabled = false;
            DtCreditos.Rows.Clear();
            PnlCreditos.Visible = false;
            lblTotPagar.Text = "0";

            CboTipoComprobante.SelectedValue = 3;
            cbTipoPago.SelectedValue = 2;
            cbFormaPago.SelectedValue = 1;
            DescontarporValesConsumo = 0;
            DtValesConsumo.Rows.Clear();// limpiar los vales
            DtNotaIngreso.Rows.Clear();//limpia los adelantos
            DtBoucher.Rows.Clear();// limpiar los vales
        }

        private void Cargar()
        {
            DtTipoComprobante = new CL_Comprobante().getTipoComprobante();
            c1Combo.FillC1Combo1(CboTipoComprobante, DtTipoComprobante, "NomTipoComprobante", "TipoComprobanteID");
            c1Combo.FillC1Combo1(cbTipoPago, new CL_Comprobante().getTipoPago(), "NomTipoPago", "TipoPagoID");
            c1Combo.FillC1Combo1(cbFormaPago, new CL_Comprobante().getFormaPago(), "NomFormaPago", "FormaPagoID");

            #region optener Nro IP
            String NombreHost;
            String DireccionIP;
            NombreHost = Dns.GetHostName();
            DireccionIP = System.Net.Dns.GetHostByName(NombreHost).AddressList[0] + "";
            //MessageBox.Show(DireccionIP);
            //dar formato a la direccion IP
            string ACU = "";

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
            #endregion

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
                LblCaja.Text = NomCaja;
            }

            dtSerie = ObjComprobante.GetSerieGuiasT(AppSettings.SedeID);//las series
            cbTipoPago.SelectedIndex = 1;

            //traer servicios otros
            DtServicios = ObjCL_Venta.GetServicios();

            //traer empresas
            DtEmpresas = new CL_Empresas().GetEmpresas();
        }

        #endregion

        private void BtnGenerarGuias_Click(object sender, EventArgs e)
        {
            if (dsPedido.Tables.Count > 0)
            {
                #region Crear tabla para enviar a crear guias
                DtDetalleGuiaRemisionVenta = new DataTable("DetalleGuiaRemisionVenta");
                DtDetalleGuiaRemisionVenta.Columns.Add("NomProducto", typeof(string));
                DtDetalleGuiaRemisionVenta.Columns.Add("UnidadMedidaID", typeof(string));
                DtDetalleGuiaRemisionVenta.Columns.Add("ProductoID", typeof(string));
                DtDetalleGuiaRemisionVenta.Columns.Add("CantidadEnviada", typeof(decimal));
                DtDetalleGuiaRemisionVenta.Columns.Add("PesoNeto", typeof(decimal));

                //añadir los detalles a una nueva tabla
                foreach (DataRow DR in dsPedido.Tables["detallePedido"].Rows)
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
            }

            FrmGuias ObjFrmGuias = new FrmGuias();
            ObjFrmGuias.DtDetalleGuiaRemisionVenta = DtDetalleGuiaRemisionVenta;
            ObjFrmGuias.DtTipoComprobante = DtTipoComprobante.Copy();
            ObjFrmGuias.Destinatario = lblCliente.Text;
            ObjFrmGuias.RUCDestinatario = lblDocumento.Text;
            ObjFrmGuias.Remitente = LblEmpresa.Text;
            ObjFrmGuias.RUCRemitente = LblRUC.Text;
            ObjFrmGuias.DtServicios = DtServicios;
            ObjFrmGuias.ShowDialog();
        }

        private void BtnNuevoComprobante_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnImpresora_Click(object sender, EventArgs e)
        {
            FrmConfigurarImpresora ObjFrmConfigurarImpresora = new FrmConfigurarImpresora();
            ObjFrmConfigurarImpresora.Show();
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //formato para alinear los nuimeros a la derecha
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;
            //formato.LineAlignment = StringAlignment.Far;

            //obtener la cadena del total a pagar
            string TotalPagarLetras = ObjTextFunctions.enletras(Total.ToString());

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
            DataView dv1 = new DataView(DtserieGuias, "EmpresaID = '" + EmpresaID + "' and TipoDocumento = " + CboTipoComprobante.SelectedValue.ToString() + " and Serie = '" + CboSerieGuia.SelectedValue.ToString() + "'", "", DataViewRowState.CurrentRows);
            SerieEticketera = dv1[0]["SerieEticketera"].ToString();
            NroAutorizacion = dv1[0]["NroAutorizacion"].ToString();

            string CodigoTipoComprobante = "03", TipoLetra = "B", TipoDocumentoCliente = "DNI";
            int Canticabecera = 31;
            string[] Formatoticket = new string[2];

            if (ObjCL_Venta.HABILITADOFE2(EmpresaID))
            {

                if (hojaimpresa == 1)
                {
                    if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 4)//es boleta
                    {
                        Formatoticket = ObjCL_Venta.FormatoTicketFE(NomEmpresa, AppSettings.NomSede, NumComprobante.Substring(2),
                        "BOLETA ELECTRONICA: ", dsPedido.Tables["detallePedido"], RUC, AppSettings.Usuario, TotalPagar, NomCaja, SerieEticketera,
                        NroAutorizacion, TotalPagarLetras, dsPedido.Tables["Pedido"].Rows[0]["RazonSocial"].ToString(),
                        dsPedido.Tables["Pedido"].Rows[0]["NroDocumento"].ToString(), dsPedido.Tables["Pedido"].Rows[0]["Direccion"].ToString(),
                        "", ConCliente, FECHA_IMPRESION, Convert.ToDecimal(TxtMontoPagado.Text), TotalIGV, "B",
                        DtDatosSede.Rows[0]["TelefonoCelular"].ToString(), DtDatosSede.Rows[0]["TelefonoFijo"].ToString(), Total, montoimpuestobolsa);
                        e.Graphics.DrawString(Formatoticket[0], TxtFormatoticketera.Font, Brushes.Black, 0, 0); //total pagar en letras

                    }
                    else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 5)//es factura
                    {
                        CodigoTipoComprobante = "01";
                        TipoLetra = "F";
                        TipoDocumentoCliente = "RUC";
                        Canticabecera = 35;

                        Formatoticket = ObjCL_Venta.FormatoTicketFE(NomEmpresa, AppSettings.NomSede, NumComprobante.Substring(2),
                        "FACTURA ELECTRONICA: ", dsPedido.Tables["detallePedido"], RUC, AppSettings.Usuario, TotalPagar, NomCaja, SerieEticketera,
                        NroAutorizacion, TotalPagarLetras, dsPedido.Tables["Pedido"].Rows[0]["RazonSocial"].ToString(),
                        dsPedido.Tables["Pedido"].Rows[0]["NroDocumento"].ToString(), dsPedido.Tables["Pedido"].Rows[0]["Direccion"].ToString(),
                        "", ConCliente, FECHA_IMPRESION, Convert.ToDecimal(TxtMontoPagado.Text), TotalIGV, "F",
                        DtDatosSede.Rows[0]["TelefonoCelular"].ToString(), DtDatosSede.Rows[0]["TelefonoFijo"].ToString(), Total, montoimpuestobolsa);
                        e.Graphics.DrawString(Formatoticket[0], TxtFormatoticketera.Font, Brushes.Black, 0, 0); //total pagar en letras
                    }


                    /*imprimir el codigo de barras*/

                    QRCodeEncoder objqrcode = new QRCodeEncoder();
                    Image imgimage;
                    Bitmap objbitmap;
                    PictureBox Pimage = new PictureBox();
                    string s;
                    s = RUC + " | " + CodigoTipoComprobante + " | " + TipoLetra + NumComprobante.Substring(2) + " | " + TotalIGV.ToString("N2") + " | " + Total.ToString("N2") + " | " +
                        FECHA_IMPRESION.ToShortDateString() + " | " + TipoDocumentoCliente + " | " + dsPedido.Tables["Pedido"].Rows[0]["NroDocumento"].ToString();
                    objqrcode.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    objqrcode.QRCodeScale = 3;
                    objqrcode.QRCodeVersion = 6;
                    objqrcode.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.L;
                    imgimage = objqrcode.Encode(s);
                    objbitmap = new Bitmap(imgimage);
                    //objbitmap.Save("QRCode.jpg");
                    //Pimage.ImageLocation = "QRCode.jpg";
                    //CALCULAMOS AL CANTIDAD DE LINEAS
                    int CantidadLineas = (Canticabecera * 14) + (Convert.ToInt32(Formatoticket[1]) * 14);

                    e.Graphics.DrawImage(imgimage, new Point(70, CantidadLineas));

                    if (TotalIGV == 0)
                    {
                        string textofinal = "Bienes   transferidos  en   la  Amazonía\nRegión  Selva  para ser  cosumidos en la\nmisma.";
                        e.Graphics.DrawString(textofinal, TxtFormatoticketera.Font, Brushes.Black, 0, CantidadLineas + (14 * 11));

                        e.Graphics.DrawString("REVISE BIEN SU PRODUCTO ANTES DE\nRETIRARSE, NO SE ACEPTAN CAMBIOS NI\nDEVOLUCIONES. GRACIAS", TxtFormatoticketera.Font, Brushes.Black, 0, CantidadLineas + (18 * 11));
                    }


                    hojaimpresa = 2;
                    e.HasMorePages = true;
                }

                else if (hojaimpresa == 2)
                {

                    if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 4)//es boleta
                    {
                        string[] Formatoticket2 = new string[2];
                        Formatoticket2 = ObjCL_Venta.FormatoTicketFEResumido(NomEmpresa, AppSettings.NomSede, NumComprobante.Substring(2),
                        "BOLETA ELECTRONICA: ", dsPedido.Tables["detallePedido"], RUC, AppSettings.Usuario, Convert.ToDecimal(Total), NomCaja, SerieEticketera,
                        NroAutorizacion, TotalPagarLetras, dsPedido.Tables["Pedido"].Rows[0]["RazonSocial"].ToString(),
                        dsPedido.Tables["Pedido"].Rows[0]["NroDocumento"].ToString(), dsPedido.Tables["Pedido"].Rows[0]["Direccion"].ToString(),
                        "", ConCliente, FECHA_IMPRESION, Convert.ToDecimal(TxtMontoPagado.Text), Convert.ToDecimal(TotalIGV), "B", Total,montoimpuestobolsa);
                        e.Graphics.DrawString(Formatoticket2[0], TxtFormatoticketera.Font, Brushes.Black, 0, 0); //total pagar en letras


                    }
                    else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 5)//es factura
                    {
                        CodigoTipoComprobante = "01";
                        TipoLetra = "F";
                        TipoDocumentoCliente = "RUC";
                        Canticabecera = 35;

                        string[] Formatoticket2 = new string[2];
                        Formatoticket2 = ObjCL_Venta.FormatoTicketFEResumido(NomEmpresa, AppSettings.NomSede, NumComprobante.Substring(2),
                        "FACTURA ELECTRONICA: ", dsPedido.Tables["detallePedido"], RUC, AppSettings.Usuario, Convert.ToDecimal(Total), NomCaja, SerieEticketera,
                        NroAutorizacion, TotalPagarLetras, dsPedido.Tables["Pedido"].Rows[0]["RazonSocial"].ToString(),
                        dsPedido.Tables["Pedido"].Rows[0]["NroDocumento"].ToString(), dsPedido.Tables["Pedido"].Rows[0]["Direccion"].ToString(),
                        "", ConCliente, FECHA_IMPRESION, Convert.ToDecimal(TxtMontoPagado.Text), Convert.ToDecimal(TotalIGV), "F",Total,  montoimpuestobolsa);
                        e.Graphics.DrawString(Formatoticket2[0], TxtFormatoticketera.Font, Brushes.Black, 0, 0); //total pagar en letras
                        //e.Graphics.DrawString(Convert.ToChar(27) + "i", TxtPrecio.Font, Brushes.Black, 0, 0); //total pagar en letras


                    }



                    e.HasMorePages = false;
                }




                return;
            }

            //validar boleta o factura
            #region Boleta normal
            if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1)//es boleta
            {
                int sum = 0;
                sum += 12;
                e.Graphics.DrawString(lblCliente.Text, txtNumPedido.Font, Brushes.Black, 70 + AppSettings.BoletaEjeX, 156 + AppSettings.BoletaEjeY); //cliente
                if (lblDireccion.Text.Length >= 30)
                    e.Graphics.DrawString(lblDireccion.Text.Substring(0, 29), txtNumPedido.Font, Brushes.Black, 80 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //direccion larga
                else
                    e.Graphics.DrawString(lblDireccion.Text, txtNumPedido.Font, Brushes.Black, 80 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //direccion corta

                //e.Graphics.DrawString(TxtCanasta.Text, txtNumPedido.Font, Brushes.Black, 40 + AppSettings.BoletaEjeX, 166 + AppSettings.BoletaEjeY); //canasta
                e.Graphics.DrawString(lblDocumento.Text, txtNumPedido.Font, Brushes.Black, 326 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //ruc o DNI
                e.Graphics.DrawString(DateTime.Now.Date.ToString().Substring(0, 10), txtNumPedido.Font, Brushes.Black, 240 + AppSettings.BoletaEjeX, 136 + AppSettings.BoletaEjeY); //dia
                e.Graphics.DrawString(NumComprobante.Substring(2), txtNumPedido.Font, Brushes.Black, 260 + AppSettings.BoletaEjeX, 117 + AppSettings.BoletaEjeY); //numero de comprobante

                int Suma = 238;
                foreach (DataRow Dr in dsPedido.Tables["detallePedido"].Rows)
                {
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Cantidad"]).ToString("#,##0.00") + " " + Dr["UnidadMedidaID"].ToString(), txtNumPedido.Font, Brushes.Black, 65 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //cantidad + UM
                    e.Graphics.DrawString(Dr["Alias"].ToString(), txtNumPedido.Font, Brushes.Black, 75 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY); //descripcion o producto
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["PrecioUnitario"]).ToString("#,##0.00"), txtNumPedido.Font, Brushes.Black, 320 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //precio unitario
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Importe"]).ToString("#,##0.00"), txtNumPedido.Font, Brushes.Black, 380 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //valor de venta
                    Suma += 14;
                }

                e.Graphics.DrawString(lblSubTotal.Text, txtNumPedido.Font, Brushes.Black, 370 + AppSettings.BoletaEjeX, 450 + AppSettings.BoletaEjeY, formato); //total
                e.Graphics.DrawString(TotalPagarLetras, txtNumPedido.Font, Brushes.Black, 45 + AppSettings.BoletaEjeX, 424 + AppSettings.BoletaEjeY); //tatal pagar en letras

            }
            #endregion
            #region  ticketera
            if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3)//es ticket
            {


                string Formatoticket2 = ObjCL_Venta.FormatoTicketBoleta(NomEmpresa, AppSettings.NomSede, NumComprobante.Substring(2),
                    "Ticket Nro: ", dsPedido.Tables["detallePedido"], RUC, AppSettings.Usuario, Total, NomCaja, SerieEticketera,
                    NroAutorizacion, TotalPagarLetras, lblCliente.Text, lblDocumento.Text, lblDireccion.Text, "",
                    ConCliente, FECHA_IMPRESION, Convert.ToDecimal(TxtMontoPagado.Text), TotalIGV, TipoTicket);

                e.Graphics.DrawString(Formatoticket2, TxtFormatoticketera.Font, Brushes.Black, 1, 1); //total pagar en letras


            }
            #endregion

            #region Factura normal
            else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2)//es factura
            {
                int sum = 0;
                sum += 12;
                e.Graphics.DrawString(lblCliente.Text, txtNumPedido.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 117 + AppSettings.FacturaEjeY); //cliente
                //e.Graphics.DrawString(useCliente2.txtDireccion.Text, txtNumPedido.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion
                if (lblDireccion.Text.Length >= 95)
                    e.Graphics.DrawString(lblDireccion.Text.Substring(0, 94), txtNumPedido.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion
                else
                    e.Graphics.DrawString(lblDireccion.Text, txtNumPedido.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion

                e.Graphics.DrawString(lblDocumento.Text, txtNumPedido.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //ruc o DNI
                e.Graphics.DrawString(DateTime.Now.Day.ToString(), txtNumPedido.Font, Brushes.Black, 570 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //dia
                e.Graphics.DrawString(DateTime.Now.ToString("MMMM"), txtNumPedido.Font, Brushes.Black, 650 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //mes
                e.Graphics.DrawString(DateTime.Now.Year.ToString().Substring(2), txtNumPedido.Font, Brushes.Black, 805 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //año
                e.Graphics.DrawString(NumComprobante.Substring(2), txtNumPedido.Font, Brushes.Black, 690 + AppSettings.FacturaEjeX, 147 + AppSettings.FacturaEjeY); //numero de comprobante

                int Suma = 230;
                foreach (DataRow Dr in dsPedido.Tables["detallePedido"].Rows)
                {
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Cantidad"]).ToString("#,##0.00") + " " + Dr["UnidadMedidaID"].ToString(), txtNumPedido.Font, Brushes.Black, 80 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //cantidad + UM
                    e.Graphics.DrawString(Dr["Alias"].ToString(), txtNumPedido.Font, Brushes.Black, 110 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY); //descripcion o producto
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["PrecioUnitario"]).ToString("#,##0.00"), txtNumPedido.Font, Brushes.Black, 665 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //precio unitario
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Importe"]).ToString("#,##0.00"), txtNumPedido.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //valor de venta
                    Suma += 14;
                }

                e.Graphics.DrawString(lblSubTotal.Text, txtNumPedido.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 427 + AppSettings.FacturaEjeY, formato); //subtotal
                e.Graphics.DrawString(lblIGV.Text, txtNumPedido.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 447 + AppSettings.FacturaEjeY, formato); //igv
                e.Graphics.DrawString(lblTotPagar.Text, txtNumPedido.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 477 + AppSettings.FacturaEjeY, formato); //total

                e.Graphics.DrawString(DateTime.Now.Day.ToString(), txtNumPedido.Font, Brushes.Black, 405 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //dia pie
                e.Graphics.DrawString(DateTime.Now.ToString("MMMM"), txtNumPedido.Font, Brushes.Black, 465 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //mes pie
                e.Graphics.DrawString(DateTime.Now.Year.ToString().Substring(2), txtNumPedido.Font, Brushes.Black, 545 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //año pie

                e.Graphics.DrawString(TotalPagarLetras, txtNumPedido.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 407 + AppSettings.FacturaEjeY); //total pagar en letras
            }
            #endregion
        }

        private void tdbgPedidos_FetchRowStyle(object sender, C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs e)
        {
            DataView Dv = new DataView(DtServicios);
            Dv.RowFilter = "Tipo='-'";
            //deshabilitar para que no se modifique el decuento

            string S = tdbgPedidos.Columns["ProductoID"].CellText(e.Row).ToString();
            if (S == Dv[0]["ProductoID"].ToString())
            {
                e.CellStyle.BackColor = System.Drawing.Color.LightCoral;
            }

            DataView Dv2 = new DataView(DtServicios);
            Dv2.RowFilter = "Tipo='+'";
            //deshabilitar para que no se modifique el decuento

            string S2 = tdbgPedidos.Columns["ProductoID"].CellText(e.Row).ToString();
            if (S2 == Dv2[0]["ProductoID"].ToString())
            {
                e.CellStyle.BackColor = System.Drawing.Color.LightSeaGreen;
            }
        }


        private void cbFormaPago_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbFormaPago.SelectedIndex != -1 && cbFormaPago.SelectedValue.ToString() == "5")//es vale
            {
                //aca aparece la ventana de los vales
                FrmValesConsumo ObjFrmValesConsumo = new FrmValesConsumo();
                ObjFrmValesConsumo.ShowDialog();
                if (ObjFrmValesConsumo.DtValesConsumo != null && ObjFrmValesConsumo.DtValesConsumo.Rows.Count > 0)
                    DtValesConsumo = ObjFrmValesConsumo.DtValesConsumo.Copy();
            }
            else if (cbFormaPago.SelectedIndex != -1 && cbFormaPago.SelectedValue.ToString() == "3")//es boucher
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

        private void BtnEgreso_Click(object sender, EventArgs e)
        {
            errValidar.Clear();
            if (c1cboCia.SelectedIndex != -1)
            {
                //registrar egresos
                FrmEgreso ObjFrmEgreso = new FrmEgreso();
                ObjFrmEgreso.NomCaja = NomCaja;
                ObjFrmEgreso.EmpresaID = c1cboCia.SelectedValue.ToString();
                ObjFrmEgreso.NumCaja = NumCaja;
                ObjFrmEgreso.DtEmpresas = DtEmpresas;
                ObjFrmEgreso.ShowDialog();
                ObjFrmEgreso.Dispose();
            }
            else
                errValidar.SetError(c1cboCia, "Debe seleccionar una empresa");
        }

        private void BtnInicioCaja_Click(object sender, EventArgs e)
        {
            errValidar.Clear();
            if (c1cboCia.SelectedIndex != -1)
            {
                //aperturar caja con una cantidad inicial de dinero
                FrmAperturaCaja ObjFrmAperturaCaja = new FrmAperturaCaja();
                ObjFrmAperturaCaja.DtEmpresas = DtEmpresas;
                ObjFrmAperturaCaja.NumCaja = NumCaja;
                ObjFrmAperturaCaja.EmpresaID = c1cboCia.SelectedValue.ToString();
                ObjFrmAperturaCaja.NomCaja = NomCaja;
                ObjFrmAperturaCaja.NroDocumento = NroDocumento;
                ObjFrmAperturaCaja.Cliente = Cliente;
                ObjFrmAperturaCaja.ClienteID = ClienteID;
                ObjFrmAperturaCaja.ShowDialog();
                ObjFrmAperturaCaja.Dispose();
            }
            else
                errValidar.SetError(c1cboCia, "Debe seleccionar una empresa");
        }

        private void BtnNuevoComprobante2_Click(object sender, EventArgs e)
        {
            Limpiar();
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

        private void BtnVistaPrevia_Click(object sender, EventArgs e)
        {
            FrmConfigurarImpresora ObjFrmConfigurarImpresora = new FrmConfigurarImpresora();
            ObjFrmConfigurarImpresora.Show();
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            //almacenar la serie por defecto
            if (CboSerieGuia.SelectedIndex != -1)
            {
                UpdateConfiguration ObjUpdateConfiguration = new UpdateConfiguration();
                //seleccionar la serie por defecto
                switch (CboTipoComprobante.SelectedValue.ToString())
                {
                    case "1":

                        ObjUpdateConfiguration.AppSettingsSectionModify("PESerieDefectoBoleta", CboSerieGuia.SelectedValue.ToString());
                        break;
                    case "2":

                        ObjUpdateConfiguration.AppSettingsSectionModify("PESerieDefectoFactura", CboSerieGuia.SelectedValue.ToString());

                        break;
                    case "3":

                        ObjUpdateConfiguration.AppSettingsSectionModify("PESerieDefectoTicket", CboSerieGuia.SelectedValue.ToString());

                        break;
                }
                MessageBox.Show("Se actualizo la serie de la empresa '" + EmpresaID + "', de " + CboTipoComprobante.Columns["NomTipoComprobante"].Value.ToString() + " serie: " + CboSerieGuia.SelectedValue.ToString() + ".", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnVerCorrelativo_Click(object sender, EventArgs e)
        {
            if (c1cboCia.SelectedValue != null)
            {
                //ver el correlativo para saber cual se vaa imprimir
                string Cadena = "";
                Cadena = ObjCL_Venta.GetVerCorrelativo(c1cboCia.SelectedValue.ToString() + AppSettings.SedeID, c1cboCia.Columns["NomEmpresa"].Value.ToString(), AppSettings.NomSede);
                MessageBox.Show(Cadena, "Serie y numero de comprobantes a punto de imprimirse.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCierre_Click(object sender, EventArgs e)
        {
            if (NumCaja != 0)
            {
                FrmCierre ObjFrmCierre = new FrmCierre();
                ObjFrmCierre.NumCaja = NumCaja;
                ObjFrmCierre.DtEmpresas = DtEmpresas.Copy();
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


    }
}



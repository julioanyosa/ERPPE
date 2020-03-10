using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.CapaLogica.Almacen;
using Halley.CapaLogica.Ventas;
using Halley.Configuracion;
using Halley.Entidad.Ventas;

namespace Halley.Presentacion.Ventas.VentasPavo
{
    public partial class ListOrdenPedido : UITemplateAccess
    {
        #region variables globales

        DataTable dtPedido;

        bool registro = false, validarCheck;
        int items, IGV, NumPedido;
        decimal subTotal, totIGV, totPagar;
        int? tipoComprobante,tipoPago,formaPago;

        #endregion

        #region Constructor

        public ListOrdenPedido()
        {
            InitializeComponent();  
        }

        #endregion

        #region Eventos de los controles

        private void chkExterno_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExterno.Checked)
            {
                cbComprobante.Enabled = true;
                cbTipoPago.Enabled = true;
            }
            else
            {
                cbComprobante.Enabled = false;
                cbTipoPago.Enabled = false;
                cbFormaPago.Enabled = false;
                cbComprobante.Text = "[Seleccionar]";
                cbTipoPago.Text = "[Seleccionar]";
                cbFormaPago.Text = "[Seleccionar]";
            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            ReporteNavideño.RepStock ObjRep = new ReporteNavideño.RepStock();
            ObjRep.ShowDialog();
        }

        private void cbTipoPago_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbTipoPago.SelectedValue != null)
            {
                if (cbTipoPago.SelectedValue.ToString() == "1")
                {
                    cbFormaPago.Text = "";
                    cbFormaPago.Enabled = false;
                }
                else
                {
                    cbFormaPago.Text = "[Seleccionar]";
                    cbFormaPago.Enabled = true;
                }
            }
        }

        private void cbEliminarRegistro_Click(object sender, EventArgs e)
        {
            if (dtPedido.Rows.Count != 0)
            {
                tdbgPedidos.Delete();
                ContarRegistro();
                Calcular();
                Habilitar();
            }
        }

        private void tdbgPedidos_AfterUpdate(object sender, EventArgs e)
        {
            Calcular();
        }

        private void cbAgregarLinea_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedValue != null)
            AgregarLinea(cbProducto.SelectedValue.ToString());
            Habilitar();
        }

        private void ListOrdenPedido_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            Cargar();
            tPedido();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                errValidar.Clear();
                if (ucCliente.cbCliente.SelectedValue == null || ucCliente.cbCliente.SelectedValue == null)
                {
                    if (ucCliente.cbCliente.SelectedValue == null) { errValidar.SetError(ucCliente.cbCliente, "Ingrese el documento"); }
                    if (ucCliente.cbNombre.SelectedValue == null) { errValidar.SetError(ucCliente.cbNombre, "Ingrese el cliente"); }
                    Cursor = Cursors.Default;
                    return;
                }

                if (chkExterno.Checked == true)
                {
                    validarCheck = false;
                    if (cbComprobante.SelectedValue == null) { errValidar.SetError(cbComprobante, "Seleccione el Comprobante"); validarCheck = true; }
                    if (cbTipoPago.SelectedValue == null) 
                    {
                        errValidar.SetError(cbTipoPago, "Seleccione el tipo"); 
                        validarCheck = true; 
                    }
                    else if (cbFormaPago.SelectedValue == null && cbTipoPago.SelectedValue.ToString() != "1")
                    {                        
                        errValidar.SetError(cbFormaPago, "Seleccione la forma de pago");
                        validarCheck = true; 
                    }

                    if (validarCheck == true) { Cursor = Cursors.Default; return; }
                    else { validarCheck = false; }
                }

                for (int i = 0; i <= this.tdbgPedidos.RowCount - 1; i++)
                {
                    if (Convert.ToInt64(this.tdbgPedidos[i, "Cantidad"]) == 0)
                    {
                        MessageBox.Show("La cantidad no puede ser 0,Verique", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.tdbgPedidos.Row = i;
                        this.tdbgPedidos.Col = 3;
                        this.tdbgPedidos.Select();
                        Cursor = Cursors.Default;
                        return;
                    }
                }

                if (cbComprobante.SelectedValue == null)
                    tipoComprobante = null;
                else
                    tipoComprobante=Convert.ToInt32(cbComprobante.SelectedValue);

                if (cbTipoPago.SelectedValue == null)
                    tipoPago = null;
                else
                    tipoPago=Convert.ToInt32(cbTipoPago.SelectedValue);

                if (cbFormaPago.SelectedValue == null)
                    formaPago = null;
                else
                    formaPago=Convert.ToInt32(cbFormaPago.SelectedValue);

                E_OrdenPedido ObjOrdenPedido = new E_OrdenPedido()
                {
                    ClienteID = Convert.ToInt32(ucCliente.cbCliente.SelectedValue),
                    TipoComprobanteID = tipoComprobante,
                    TipoPagoID =tipoPago,
                    FormaPagoId = formaPago,
                    IGV = IGV,
                    SubTotal = subTotal,
                    TotalIGV = totIGV,
                    UsuarioID = AppSettings.UserID,
                    EmpresaID = AppSettings.EmpresaID,
                    SedeID = AppSettings.SedeID,
                    Comentario = txtComentario.Text,
                    Externa = chkExterno.Checked,
                    Vale = true,
                };

                NumPedido = new CL_OrdenPedido().InsertOrdenPedido(ObjOrdenPedido, dtPedido);
                lblNumPedido.Text = NumPedido.ToString();

                MessageBox.Show("El pedido se genero correctamente", "Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Information);
                MessageBox.Show("El Numero Pedido : " + lblNumPedido.Text, "PEDIDO", MessageBoxButtons.OK);
                Limpiar();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        #endregion

        #region Metodos definidos

        private void Limpiar()
        {
            dtPedido.Rows.Clear();
            chkExterno.Checked = false;            
            ucCliente.Limpiar();
            //lblNumPedido.Text = String.Empty;
            lblIGV.Text = "0";
            lblSubTotal.Text = "0";
            lblTotCantidad.Text = "0";
            lblTotPagar.Text = "0";

            txtComentario.Text = string.Empty;
            cbComprobante.Text = "[Seleccionar]";
            cbFormaPago.Text = "[Seleccionar]";
            cbProducto.Text = "[Seleccionar]";
            cbFormaPago.Text = "[Seleccionar]";
            cbTipoPago.Text = "[Seleccionar]";
            Habilitar();
            ContarRegistro();
        }

        private void Habilitar()
        {
            if (dtPedido.Rows.Count == 0)
            {
                btnEliminarRegistro.Enabled = false;
                btnCancelar.Enabled = false;
                btnRegistrar.Enabled = false;
            }
            else
            {
                btnEliminarRegistro.Enabled = true;
                btnCancelar.Enabled = true;
                btnRegistrar.Enabled = true;
            }
        }

        private void Calcular()
        {
            dtPedido.AcceptChanges();
            if (dtPedido.Rows.Count != 0)
            {
                subTotal = (decimal)dtPedido.Compute("Sum(Importe)", "");
                totIGV = subTotal * (IGV / 100);
                totPagar = subTotal + totIGV;

                lblTotCantidad.Text = dtPedido.Compute("Sum(Cantidad)", "").ToString();
                lblSubTotal.Text = subTotal.ToString("C");
                lblIGV.Text = totIGV.ToString("C");
                lblTotPagar.Text = totPagar.ToString("C");
            }
            else
            {
                lblTotCantidad.Text = "0";
                lblSubTotal.Text = "0";
                lblIGV.Text = "0";
                lblTotPagar.Text = "0";
            }
        }

        private void ContarRegistro()
        {
            items = tdbgPedidos.RowCount;
            this.tdbgPedidos.Columns[4].FooterText = "Items : " + items.ToString();
        }

        private void Cargar()
        {
            c1Combo.FillC1Combo1(cbProducto,new CL_Producto().getProductosNavideños(AppSettings.EmpresaID,AppSettings.SedeID),"NomProducto","ProductoID");
            c1Combo.FillC1Combo1(cbComprobante, new CL_Comprobante().getTipoComprobante(), "NomTipoComprobante", "TipoComprobanteID");
            c1Combo.FillC1Combo1(cbTipoPago, new CL_Comprobante().getTipoPago(), "NomTipoPago", "TipoPagoID");
            c1Combo.FillC1Combo1(cbFormaPago, new CL_Comprobante().getFormaPago(), "NomFormaPago", "FormaPagoID");
            ucCliente.Cargar(new CL_Cliente().GetClientes());
            IGV = new CL_Comprobante().getIGV();
        }

        private void tPedido()
        {
            dtPedido = new DataTable("OrdenPedido");
            dtPedido.Columns.Add("Codigo", typeof(string));
            dtPedido.Columns.Add("Producto", typeof(string));
            dtPedido.Columns.Add("Cantidad", typeof(int));
            dtPedido.Columns.Add("PrecioUnitario", typeof(decimal));
            dtPedido.Columns.Add("Importe", typeof(decimal),"Cantidad * PrecioUnitario");
            dtPedido.Columns.Add("AlmacenID", typeof(string));

            tdbgPedidos.SetDataBinding(dtPedido, "", true);
            this.tdbgPedidos.Columns["Cantidad"].Editor = this.c1NumericEdit1;
            ContarRegistro();
        }

        private void AgregarLinea(string Codigo)
        {
            foreach (DataRow row in dtPedido.Rows)
            {
                if (row["Codigo"].ToString()==Codigo)
                {
                    registro = true;
                    break;
                }
            }

            if (registro == false)
            {
                DataRow linea = dtPedido.NewRow();
                linea["Codigo"] = cbProducto.SelectedValue;
                linea["Producto"] = cbProducto.Columns["NomProducto"].Value;
                linea["Cantidad"] = 0;
                linea["PrecioUnitario"] = cbProducto.Columns["PrecioUnitario"].Value;
                linea["Importe"] = 0;
                linea["AlmacenID"] = AppSettings.EmpresaID + AppSettings.SedeID + cbProducto.Columns["Almacen"].Value.ToString();
                dtPedido.Rows.Add(linea);
                ContarRegistro();
            }
            else
            {
                MessageBox.Show("El Producto ya ah sido agregado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                registro = false;
            }
        }

        #endregion  

        private void tdbgPedidos_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            Calcular();
        }

        private void tdbgPedidos_AfterColUpdate(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            Calcular();
        }
    }
}

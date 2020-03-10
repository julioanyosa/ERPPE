using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;
using Halley.CapaLogica.Contabilidad;
using Halley.Utilitario;

namespace Halley.Presentacion.Compras
{
    public partial class PagoLiquidacion : UITemplateAccess
    {
        #region variables
        string NumHojaLiquidacion = "";
        int EstadoID = 0;
        DataSet DsDatosCuenta = new DataSet();
        Utilitario.TextFunctions ObjTextFunctions = new TextFunctions();
        #endregion
        public PagoLiquidacion()
        {
            InitializeComponent();
        }

        private void LstCodigos_DoubleClick(object sender, EventArgs e)
        {
            if (LstCodigos.SelectedIndex != -1)
            {
                NumHojaLiquidacion = LstCodigos.SelectedValue.ToString();
                TraerGuia(NumHojaLiquidacion);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            TxtReadOnly(false);
            Limpiar();
            TxtReadOnly(true);
            ErrProvider.Clear();
            if (TxtBuscar.Text != "")
            {
                //obtener las guias de liquidacion
                if (RbCodigo.Checked == true)
                {
                    NumHojaLiquidacion = TxtBuscar.Text;
                    TraerGuia(NumHojaLiquidacion);
                }
                else if (RbDNI.Checked == true)
                {
                    //devuelve una lista de codigos amarrados a un DNI
                    DataTable Dt = new DataTable();
                    Dt = new CL_GuiaCompraMaiz().GetGuiaCompraMaizDNI(TxtBuscar.Text);
                    LstCodigos.DataSource = Dt;
                    LstCodigos.DisplayMember = "AudCrea";
                    LstCodigos.ValueMember = "NumHojaLiquidacion";
                    if (Dt.Rows.Count == 1)
                    {
                        NumHojaLiquidacion = Dt.Rows[0]["NumHojaLiquidacion"].ToString();
                        TraerGuia(NumHojaLiquidacion);
                    }
                }
            }
            else
            {
                if (RbCodigo.Checked == true)
                {
                    ErrProvider.SetError(TxtBuscar, "Debe ingresar un código de liquidación a buscar.");
                }
                else if (RbDNI.Checked == true)
                {
                    ErrProvider.SetError(TxtBuscar, "Debe ingresar un DNI a Buscar");
                }
            }
            

        }

        private void TraerGuia(string NumHojaLiquidacion)
        {
            DataSet DS = new DataSet();
            
            #region Cabecera
            DS = new CL_GuiaCompraMaiz().GetFormatoHojaLiquidacion(NumHojaLiquidacion);
            if (DS.Tables["Cabecera"].Rows.Count > 0)
            {
                TxtReadOnly(false);
                TxtEstado.Text = DS.Tables["Cabecera"].Rows[0]["NomEstado"].ToString();
                TxNumHojaLiquidacion.Text = DS.Tables["Cabecera"].Rows[0]["NumHojaLiquidacion"].ToString();
                TxtAudCrea.Text = DS.Tables["Cabecera"].Rows[0]["AudCrea"].ToString();
                TxtProductoID.Text = DS.Tables["Cabecera"].Rows[0]["ProductoID"].ToString();
                TxtNomProducto.Text = DS.Tables["Cabecera"].Rows[0]["Alias"].ToString();
                TxtSacos.Text = DS.Tables["Cabecera"].Rows[0]["Sacos"].ToString();
                TxtNombreProveedor.Text = DS.Tables["Cabecera"].Rows[0]["NombreProveedor"].ToString();
                TxtTotalPeso.Text = DS.Tables["Cabecera"].Rows[0]["TotalPeso"].ToString();
                TxtTotalSaco.Text = DS.Tables["Cabecera"].Rows[0]["TotalSaco"].ToString();
                TxtProcedencia.Text = DS.Tables["Cabecera"].Rows[0]["Procedencia"].ToString();
                TxtDNI.Text = DS.Tables["Cabecera"].Rows[0]["DNI"].ToString();
                TxtPrecioUnitario.Text = DS.Tables["Cabecera"].Rows[0]["PrecioUnitario"].ToString();
                decimal TotalPagar = 0;
                TotalPagar = Convert.ToDecimal(TxtTotalPeso.Text) * Convert.ToDecimal(TxtPrecioUnitario.Text);
                TxtTotalPagar.Text = decimal.Round(TotalPagar,3).ToString();
                TxtComentario.Text = DS.Tables["Cabecera"].Rows[0]["Comentario"].ToString();
                TxtSede.Text = DS.Tables["Cabecera"].Rows[0]["NomSede"].ToString();
                TxtDireccion.Text = DS.Tables["Cabecera"].Rows[0]["Direccion"].ToString();
                EstadoID = Convert.ToInt16(DS.Tables["Cabecera"].Rows[0]["EstadoID"]);
                TxtPagado.Text = DS.Tables["Cabecera"].Rows[0]["Pagado"].ToString();

                GbLiquidacion.Enabled = true;
                TxtOperacionCajaBancoID.Enabled = true;
                TxtDescripcionOperacion.Enabled = true;
                TxtOperacionCajaBancoID.Text = DS.Tables["OperacionCajaBanco"].Rows[0]["OperacionCajaBancoID"].ToString();
                TxtDescripcionOperacion.Text = DS.Tables["OperacionCajaBanco"].Rows[0]["DescripcionOperacion"].ToString();
                TxtOperacionCajaBancoID.Enabled=false;
                TxtDescripcionOperacion.Enabled = false;
                TxtMontoAPagar.Text = decimal.Round(Convert.ToDecimal(TxtTotalPeso.Text) * Convert.ToDecimal(TxtPrecioUnitario.Text) - Convert.ToDecimal(TxtPagado.Text),3).ToString();

                //validar el panel "liquidar"
                if (EstadoID == 12)
                    GbLiquidacion.Enabled = false;
                else
                    GbLiquidacion.Enabled = true;
                
                TxtReadOnly(true);
                #endregion
                /*
                DataTable Usp_GetDetalleGuiaCompraMaiz = new DataTable();
                Usp_GetDetalleGuiaCompraMaiz = new CL_GuiaCompraMaiz().GetDetalleGuiaCompraMaiz(NumHojaLiquidacion);

                TdgDetalleGuiaMaiz.SetDataBinding(Usp_GetDetalleGuiaCompraMaiz, "", true);*/
            }
        }

        private void TxtReadOnly(Boolean Valor)
        {
            TxtEstado.ReadOnly = Valor;
            TxNumHojaLiquidacion.ReadOnly = Valor;
            TxtAudCrea.ReadOnly = Valor;
            TxtProductoID.ReadOnly = Valor;
            TxtNomProducto.ReadOnly = Valor;
            TxtSacos.ReadOnly = Valor;
            TxtNombreProveedor.ReadOnly = Valor;
            TxtTotalPeso.ReadOnly = Valor;
            TxtTotalSaco.ReadOnly = Valor;
            TxtProcedencia.ReadOnly = Valor;
            TxtDNI.ReadOnly = Valor;
            TxtPrecioUnitario.ReadOnly = Valor;
            TxtTotalPagar.ReadOnly = Valor;
            TxtComentario.ReadOnly = Valor;
            TxtDireccion.ReadOnly = Valor;
            TxtPagado.ReadOnly = Valor;
        }

        private void Limpiar()
        {
            TxtEstado.Text = "";
            TxNumHojaLiquidacion.Text = "";
            TxtAudCrea.Text = "";
            TxtProductoID.Text = "";
            TxtNomProducto.Text = "";
            TxtSacos.Text = "";
            TxtNombreProveedor.Text = "";
            TxtTotalPeso.Text = "";
            TxtTotalSaco.Text = "";
            TxtProcedencia.Text = "";
            TxtDNI.Text = "";
            TxtPrecioUnitario.Text = "";
            TxtTotalPagar.Text = "";
            TxtComentario.Text = "";
            TxtDireccion.Text = "";
            TxtPagado.Text = "";
            GbLiquidacion.Enabled = true;
            TxtDetalleTransaccion.Text = "";
            TxtDescripcionOperacion.Enabled = true;
            TxtDescripcionOperacion.Text = "";
            TxtOperacionCajaBancoID.Enabled = true;
            TxtOperacionCajaBancoID.Text = "";
            TxtMontoAPagar.Text = "";
            CboCuentaCorriente.SelectedIndex = -1;
            CboEntidadBancaria.SelectedIndex = -1;
            CboMoneda.SelectedIndex = -1;
            CboTipoPago.SelectedIndex = -1;
            DataTable Dt = new DataTable();
            LstCodigos.DataSource = Dt;
        }

        private void PagoLiquidacion_Load(object sender, EventArgs e)
        {
            TxtReadOnly(true);
            ocultarToolStrip();

            DsDatosCuenta = new CL_Contabilidad().GetDatosCuenta();
            //llenar los combos
            //filtrar los pagos
            DataView DtPagos = new DataView(DsDatosCuenta.Tables["TipoPago"], "TipoPagoID in (7,8)", "TipoPagoID ASC", DataViewRowState.CurrentRows);
            CboTipoPago.HoldFields();
            CboTipoPago.DataSource = DtPagos;
            CboTipoPago.DisplayMember = "Descripcion";
            CboTipoPago.ValueMember = "TipoPagoID";

            CboEntidadBancaria.HoldFields();
            CboEntidadBancaria.DataSource = DsDatosCuenta.Tables["EntidadBancaria"];
            CboEntidadBancaria.DisplayMember = "Descripcion";
            CboEntidadBancaria.ValueMember = "EntidadBancariaID";

            CboMoneda.HoldFields();
            CboMoneda.DataSource = DsDatosCuenta.Tables["Moneda"];
            CboMoneda.DisplayMember = "Descripcion";
            CboMoneda.ValueMember = "MonedaID";

        }   

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            TxtBuscar.Text = "";
            TxtReadOnly(false);
            Limpiar();
            TxtReadOnly(true);
        }

        private void MostraLista()
        {
            if (RbCodigo.Checked == true)
            {
                LstCodigos.Visible = false;
            }
            else if (RbDNI.Checked == true)
            {
                LstCodigos.Visible = true;
            }
        }

        private void RbDNI_CheckedChanged(object sender, EventArgs e)
        {
            MostraLista();
            TxtBuscar.Text = "";
            DataTable Dt = new DataTable();
            LstCodigos.DataSource = Dt;
        }

        private void BtnLiquidar_Click(object sender, EventArgs e)
        {
            try 
	        {
                ErrProvider.Clear();
                if (CboMoneda.SelectedIndex != -1 & CboTipoPago.SelectedIndex != -1 & TxtDetalleTransaccion.Text != "")
                {
                    if (MessageBox.Show("¿Seguro que desea liquidar esta compra?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && TxNumHojaLiquidacion.Text != "")
                    {
                        //liquidar
                        if (Convert.ToDecimal(TxtPagado.Text) + Convert.ToDecimal(TxtMontoAPagar.Text) == Convert.ToDecimal(TxtTotalPagar.Text))
                            EstadoID = 12;
                        else
                            EstadoID = 13;
                        if (Convert.ToInt16(CboTipoPago.SelectedValue) == 8)//efectivo
                            new CL_GuiaCompraMaiz().UpdateHojaLiquidacionEstado(NumHojaLiquidacion, AppSettings.SedeID, EstadoID, Convert.ToInt32(TxtOperacionCajaBancoID.Text), Convert.ToInt16(CboTipoPago.SelectedValue),
                         Convert.ToDecimal(TxtMontoAPagar.Text), AppSettings.UserID, CboMoneda.SelectedValue.ToString(), 0,TxtDetalleTransaccion.Text,null,null,0);
                        else if (Convert.ToInt16(CboTipoPago.SelectedValue) == 7)//cheque
                        {
                            if (CboEntidadBancaria.SelectedIndex != -1 & CboCuentaCorriente.SelectedIndex != -1)
                                new CL_GuiaCompraMaiz().UpdateHojaLiquidacionEstado(NumHojaLiquidacion, AppSettings.SedeID, EstadoID, Convert.ToInt32(TxtOperacionCajaBancoID.Text), Convert.ToInt16(CboTipoPago.SelectedValue),
                             Convert.ToDecimal(TxtMontoAPagar.Text), AppSettings.UserID, CboMoneda.SelectedValue.ToString(), 0, TxtDetalleTransaccion.Text, CboEntidadBancaria.Columns["RUC"].Value.ToString(), CboEntidadBancaria.Columns["Descripcion"].Value.ToString(), Convert.ToInt16(CboCuentaCorriente.SelectedValue));
                            else
                            {
                                if (CboEntidadBancaria.SelectedIndex == -1) ErrProvider.SetError(CboEntidadBancaria, "Debe seleccionar una entidad bancaria");
                                if (CboCuentaCorriente.SelectedIndex == -1) ErrProvider.SetError(CboCuentaCorriente, "Debe selecciona una cuenta corriente");
                                return;
                            }
                        }

                        MessageBox.Show("Se liquido el " + NumHojaLiquidacion, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtReadOnly(false);
                        Limpiar();
                        TxtReadOnly(true);
                    }
                }
                else
                {
                    if (CboMoneda.SelectedIndex == -1) ErrProvider.SetError(CboMoneda,"Debe seleccionar una moneda");
                    if(CboTipoPago.SelectedIndex == -1) ErrProvider.SetError(CboTipoPago,"Debe seleccionar un tipo de pago valido");
                    if (TxtDetalleTransaccion.Text == "") ErrProvider.SetError(TxtDetalleTransaccion, "Ingrese una descripción");
                }
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
	        }
        }

        private void CboEntidadBancaria_SelectedValueChanged(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            if (CboEntidadBancaria.SelectedIndex != -1 && CboMoneda.SelectedIndex != -1)
            {
                DataView DV = new DataView(DsDatosCuenta.Tables["CuentaCorriente"], "Moneda = '" + CboMoneda.Columns["Codigo"].Value.ToString() + "' and EntidadBancariaID = " + CboEntidadBancaria.SelectedValue.ToString() + " and EmpresaID = '" + NumHojaLiquidacion.Substring(0, 2) + "'", "", DataViewRowState.CurrentRows);
                CboCuentaCorriente.HoldFields();
                CboCuentaCorriente.DataSource = DV.ToTable();
                CboCuentaCorriente.DisplayMember = "NrocuentaCorriente";
                CboCuentaCorriente.ValueMember = "CuentaCorrienteID";
            }
            else
            {
                if (CboMoneda.SelectedIndex == -1) ErrProvider.SetError(CboMoneda, "Debe seleccionar una moneda válida.");
            }
        }

        private void CboTipoPago_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboTipoPago.SelectedIndex != -1 && CboTipoPago.Columns["CodigoContabilidad"].Value.ToString() == "007")
                PnlCuentaCorriente.Visible = true;
            else
                PnlCuentaCorriente.Visible = false;

        }

        private void TxtMontoAPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtMontoAPagar);
        }

        private void CboMoneda_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboTipoPago.SelectedIndex != -1 && CboTipoPago.Columns["CodigoContabilidad"].Value.ToString() == "007" & CboMoneda.SelectedIndex != -1)
            {
                CboEntidadBancaria_SelectedValueChanged(null, null);
            }
        }
    }
}

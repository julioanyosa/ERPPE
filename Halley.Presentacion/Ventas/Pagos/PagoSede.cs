using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.CapaLogica.Ventas;
using Halley.CapaLogica.Empresa;
using Halley.Entidad.Ventas;
using Halley.Configuracion;
using System.Configuration;
using System.Net;

namespace Halley.Presentacion.Ventas.Pagos
{
    public partial class PagoSede : UITemplateAccess
    {
        #region Variables
        CL_Credito ObjCL_Credito = new CL_Credito();
        CL_Pago ObjCL_Pago = new CL_Pago();
        CL_Comprobante ObjComprobante = new CL_Comprobante();
        string ImpresoraPago = AppSettings.ImpresoraPago;

        private TextFunctions ObjTextFunctions = new TextFunctions();
        DataTable DtPagosComprobante = new DataTable();
        DataTable DtComprobanteCredito = new DataTable();
        DataTable DtFormasPago = new DataTable();
        DataTable DtCajas = new DataTable();
        DataTable DtEmpresas = new DataTable();
        DataTable DtClientes = new DataTable();

        decimal ImporteComprobante = 0;
        decimal PorPagarComprobante = 0;
        decimal TotalPagadoComprobante = 0;
        int EstadoID = 0;//estado del comprobante
        string FormatoImpresion = "";

        int NumCaja;
        string NomCaja = "";
        #endregion

        public PagoSede()
        {
            InitializeComponent();
        }

        private void Pago_Load(object sender, EventArgs e)
        {
            DtFormasPago = new CL_Comprobante().getFormaPago();
            c1Combo.FillC1Combo1(cbComprobante, new CL_Comprobante().getTipoComprobante(), "NomTipoComprobante", "TipoComprobanteID");
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            c1Combo.FillC1Combo1(cbFormaPago, DtFormasPago, "NomFormaPago", "FormaPagoID");
            DtClientes = new CL_Cliente().GetClientes();
            useCliente1.Cargar(DtClientes);
            useCliente1.btnRegistrar.Visible = false;
            PnCampanha.Visible = true;
            PnComprobante.Visible = false;


            //traer empresas
            DtEmpresas = new CL_Empresas().GetEmpresas();

            TxtDeudaTotal.ReadOnly = true;
            TxtTotalPagado.ReadOnly = true;
            TxtPorPagar.ReadOnly = true;
            TxtImporteComprobante.ReadOnly = true;
            TxtPagadoComprobante.ReadOnly = true;
            TxtPorPagarComprobante.ReadOnly = true;
            TxtFechaEmision.ReadOnly = true;
            ocultarToolStrip();

            c1cboCia.SelectedValue = AppSettings.EmpresaID;
            cbFormaPago.SelectedValue = 1;

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

            LblCaja.Text = NomCaja;
            #endregion
        }

        private void GetCreditosCompra(int ClienteID)
        {
            //traer créditos
            DataTable DtCreditos = new DataTable();
            DtCreditos = ObjCL_Credito.GetCreditosClienteConDeudaSede(ClienteID, AppSettings.SedeID);//creditos que presentan deuda
            LstCreditos.HoldFields();
            LstCreditos.DataSource = DtCreditos;

            //listar las deudas totales
            DataTable DtCreditosTotal = new DataTable();
            DtCreditosTotal = ObjCL_Pago.GetCreditosTotal(ClienteID);

            decimal TotalCredito=0, TotalPagado=0, DeudaTotal=0;

            TotalCredito = Convert.ToDecimal(DtCreditosTotal.Rows[0]["TotalCredito"]);
            TotalPagado = Convert.ToDecimal(DtCreditosTotal.Rows[0]["TotalPagado"]);
            DeudaTotal = TotalCredito - TotalPagado;

            TxtDeudaTotal.ReadOnly = false;
            TxtTotalPagado.ReadOnly = false;
            TxtPorPagar.ReadOnly = false;
            TxtDeudaTotal.Text = TotalCredito.ToString("C");
            TxtTotalPagado.Text = TotalPagado.ToString("C");
            TxtPorPagar.Text = DeudaTotal.ToString("C");
            TxtDeudaTotal.ReadOnly = true;
            TxtTotalPagado.ReadOnly = true;
            TxtPorPagar.ReadOnly = true;
        }

        private void LstCreditos_DoubleClick(object sender, EventArgs e)
        {
            if (LstCreditos.ListCount > 0)
            {
                //obtener las boletas amarradas al credito
                DtComprobanteCredito = new DataTable();
                DtComprobanteCredito = ObjCL_Pago.GetComprobantesCredito(Convert.ToInt32(LstCreditos.Columns["CreditoID"].Value));
                LstComprobantes.HoldFields();
                LstComprobantes.DataSource = DtComprobanteCredito;
            }
        }

        private void useCliente1_ComboValueChange()
        {
            GetCreditosCompra(Convert.ToInt32(useCliente1.cbCliente.SelectedValue));
            useCliente1.txtDireccion.ReadOnly = true;
        }

        private void LstComprobantes_DoubleClick(object sender, EventArgs e)
        {
            if (LstComprobantes.ListCount > 0)
            {
                DetallePago(LstComprobantes.Columns["NumComprobante"].Value.ToString(), Convert.ToInt32(LstComprobantes.Columns["TipoComprobanteID"].Value));
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if(c1cboCia.SelectedIndex != -1 & TxtComprobante.Text != "" & cbComprobante.SelectedIndex != -1)
                DetallePago(c1cboCia.SelectedValue.ToString() + TxtComprobante.Text, Convert.ToInt32(cbComprobante.Columns["TipoComprobanteID"].Value));
        }

        private void DetallePago(string NumComprobante, int TipoComprobanteID)
        {

            //limpiar
            TotalPagadoComprobante = 0;
            ImporteComprobante = 0;
            PorPagarComprobante = 0;

            DtPagosComprobante = new DataTable();
            DataSet Ds = new DataSet();
            Ds= ObjCL_Pago.GetPagosBoleta(NumComprobante, TipoComprobanteID);
            DtPagosComprobante = Ds.Tables["Pago"];
            TdgPagosRealizados.SetDataBinding(DtPagosComprobante, "", true);

            //Mostrar Total Pagar por boleta

            TxtImporteComprobante.ReadOnly = false;
            if(Ds.Tables["Comprobante"].Rows.Count>0)
                ImporteComprobante = Convert.ToDecimal(Ds.Tables["Comprobante"].Rows[0]["TotalPagar"].ToString());
            TxtImporteComprobante.Text = ImporteComprobante.ToString("C");
            TxtImporteComprobante.ReadOnly = true;

            //calcular totales
            
            TxtPagadoComprobante.ReadOnly = false;
            if(DtPagosComprobante.Rows.Count > 0)
                TotalPagadoComprobante = Convert.ToDecimal(DtPagosComprobante.Compute("sum(Importe)", ""));//suma de créditos
            TxtPagadoComprobante.Text = TotalPagadoComprobante.ToString("C");
            TxtPagadoComprobante.ReadOnly = true;

            PorPagarComprobante = ImporteComprobante - TotalPagadoComprobante;
            TxtPorPagarComprobante.ReadOnly = false;
            TxtPorPagarComprobante.Text = PorPagarComprobante.ToString("C");
            TxtPorPagarComprobante.ReadOnly = true;

            //mostrar fecha de emisión:
            TxtFechaEmision.ReadOnly = false;
            if (Ds.Tables["Comprobante"].Rows.Count > 0)
                TxtFechaEmision.Text = Ds.Tables["Comprobante"].Rows[0]["AudCrea"].ToString();
            TxtFechaEmision.ReadOnly = true;
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            try
                {
                    ErrProvider.Clear();
                    string NumComprobante = "";
                    Int32 TipoComprobanteID = 0;

                    decimal Pagar = 0;
                    if(TxtPagar.Text !="" & TxtPagar.Text != ".")
                        Pagar=Convert.ToDecimal(TxtPagar.Text);

                    if (RbCampanha.Checked == true & LstComprobantes.ListCount > 0)
                    {
                        NumComprobante = LstComprobantes.Columns["NumComprobante"].Value.ToString();
                        TipoComprobanteID = Convert.ToInt32(LstComprobantes.Columns["TipoComprobanteID"].Value);
                    }
                    else if (RbComprobante.Checked == true & cbComprobante.SelectedIndex != -1 & c1cboCia.SelectedIndex != -1 & TxtComprobante.Text != "")
                    {
                        NumComprobante = c1cboCia.SelectedValue.ToString() + TxtComprobante.Text;
                        TipoComprobanteID = Convert.ToInt32(cbComprobante.Columns["TipoComprobanteID"].Value);
                    }

                    if (cbFormaPago.SelectedIndex != -1 & Pagar > 0 & NumComprobante != "" & TipoComprobanteID != 0 & PorPagarComprobante > 0 & PorPagarComprobante >= Pagar & NumCaja != 0)
                    {
                        if (MessageBox.Show("¿Seguro que desea registrar el pago?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //obtener datos de la empresa
                            DataView DV = new DataView(DtEmpresas);
                            string EmpresaID = NumComprobante.Substring(0,2);
                            DV.RowFilter = "EmpresaID = '" + EmpresaID + "'";
                            string NomEmpresa = DV[0]["NomEmpresa"].ToString();
                            string RUC = DV[0]["RUC"].ToString();

                            //llenar el objPago
                            E_Pago ObjE_Pago = new E_Pago();
                            ObjE_Pago.PagoID = 0;
                            ObjE_Pago.NumComprobante = NumComprobante;
                            ObjE_Pago.TipoComprobanteID = TipoComprobanteID;
                            ObjE_Pago.Importe = Convert.ToDecimal(TxtPagar.Text);
                            ObjE_Pago.FormaPagoID = Convert.ToInt32(cbFormaPago.SelectedValue);
                            ObjE_Pago.UsuarioID = AppSettings.UserID;

                            //llenar la nota de ingreso
                            E_NotaIngreso ObjE_NotaIngreso = new E_NotaIngreso();
                            ObjE_NotaIngreso.Numcaja = NumCaja;
                            ObjE_NotaIngreso.Tipo = "I";
                            ObjE_NotaIngreso.EmpresaID = AppSettings.EmpresaID;
                            ObjE_NotaIngreso.Observacion = TxtObservacion.Text;
                            ObjE_NotaIngreso.LugarPago = AppSettings.SedeID;

                            //calcular el estado del comporbante
                            if (PorPagarComprobante > Pagar)//todavia resta
                                EstadoID = 13;
                            else if (PorPagarComprobante == Pagar)//es el total de la deuda del comprobante
                                EstadoID = 12;

                            Int32 CreditoID=0;

                            if(RbCampanha.Checked ==true)
                                CreditoID = Convert.ToInt32(LstCreditos.Columns["CreditoID"].Value);

                            printDocument1.PrinterSettings.PrinterName = ImpresoraPago;

                            if (printDocument1.PrinterSettings.PrinterName != "")
                            {
                                FormatoImpresion = ObjCL_Pago.FormatoTicketPago(NomEmpresa, CreditoID, LstCreditos.Columns["NomCampanha"].Value.ToString(), AppSettings.NomSede, RUC, AppSettings.Usuario, Convert.ToDecimal(TxtPagar.Text), NomCaja);
                                //MessageBox.Show(FormatoImpresion, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Int32 NotaIngresoID = 0;
                                NotaIngresoID = ObjCL_Pago.InsertPago(ObjE_Pago, ObjE_NotaIngreso, EstadoID);
                                MessageBox.Show("Se registro correctamente el pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                printDocument1.Print();
                                LimpiarTodo();

                            }
                            else
                                MessageBox.Show("Debe seleccionar una impresora valida. no se guardara el pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            
                        }
                    }
                    else
                    {
                        if (NumCaja == 0) { ErrProvider.SetError(LblCaja, "Debe seleccionar una caja"); }
                        if (cbFormaPago.SelectedIndex == -1) {ErrProvider.SetError(cbFormaPago,"Debe seleccionar un tipo de pago");}
                        if (TxtPagar.Text == "" | TxtPagar.Text == ".") { ErrProvider.SetError(TxtPagar, "Debe ingresar un pago válido"); }
                        if (Pagar > PorPagarComprobante) { MessageBox.Show("Ha ingresado un pago mayor a la deuda","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
                    }
                    /*else if (Pagar == 0)
                        MessageBox.Show("No ha ingresado el monto a pagar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (PorPagarComprobante == 0)
                        MessageBox.Show("El comprobante ya esta pagado o no existe o no ha sido consultado todavia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
                     * */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarTodo()
        {
            //limpiar
            RbCampanha.Checked = true;
            useCliente1.cbCliente.SelectedIndex = -1;
            useCliente1.cbNombre.SelectedIndex = -1;
            useCliente1.txtDireccion.ReadOnly = false;
            useCliente1.txtDireccion.Text = "";
            useCliente1.txtDireccion.ReadOnly = true;
            DtPagosComprobante.Rows.Clear();
            DtComprobanteCredito.Rows.Clear();
            TxtDeudaTotal.ReadOnly = false;
            TxtDeudaTotal.Text = "";
            TxtDeudaTotal.ReadOnly = true;
            TxtTotalPagado.ReadOnly = false;
            TxtTotalPagado.Text = "";
            TxtTotalPagado.ReadOnly = true;
            TxtPorPagar.ReadOnly = false;
            TxtPorPagar.Text = "";
            TxtPorPagar.ReadOnly = true;
            TxtImporteComprobante.ReadOnly = false;
            TxtImporteComprobante.Text = "";
            TxtImporteComprobante.ReadOnly = true;
            TxtPagadoComprobante.ReadOnly = false;
            TxtPagadoComprobante.Text = "";
            TxtPagadoComprobante.ReadOnly = true;
            TxtPorPagarComprobante.ReadOnly = false;
            TxtPorPagarComprobante.Text = "";
            TxtPorPagarComprobante.ReadOnly = true;
            TxtFechaEmision.ReadOnly = false;
            TxtFechaEmision.Text = "";
            TxtFechaEmision.ReadOnly = true;
            TxtObservacion.Text = "";
            TxtPagar.Text = "";
            cbFormaPago.SelectedIndex = 1;
            FormatoImpresion = "";
        }
        private void RbCampanha_CheckedChanged(object sender, EventArgs e)
        {
            if (RbCampanha.Checked == true)
            {
                PnCampanha.Visible = true;
                PnComprobante.Visible = false;
                Limpiar();
            }
            else if (RbComprobante.Checked == true)
            {
                PnCampanha.Visible = false;
                PnComprobante.Visible = true;
                Limpiar();
            }
        }

        private void TxtPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtPagar);
        }

        private void Limpiar()
        {

            TxtImporteComprobante.ReadOnly = false;
            TxtPagadoComprobante.ReadOnly = false;
            TxtPorPagarComprobante.ReadOnly = false;
            TxtFechaEmision.ReadOnly = false;


            TxtImporteComprobante.Text = "";
            TxtPagadoComprobante.Text = "";
            TxtPorPagarComprobante.Text = "";
            TxtFechaEmision.Text = "";


            TxtImporteComprobante.ReadOnly = true;
            TxtPagadoComprobante.ReadOnly = true;
            TxtPorPagarComprobante.ReadOnly = true;
            TxtFechaEmision.ReadOnly = true;

            DtPagosComprobante.Clear();
        }

        private void BtnMultiplesPagos_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            if (DtComprobanteCredito.Rows.Count > 0 && NumCaja == 0)
            {
                FrmPagosMultiples ObjFrmPagosMultiples = new FrmPagosMultiples();
                ObjFrmPagosMultiples.DtComprobantes = DtComprobanteCredito;
                ObjFrmPagosMultiples.DtFormasPago = DtFormasPago;
                ObjFrmPagosMultiples.Numcaja = NumCaja;
                ObjFrmPagosMultiples.CreditoID = Convert.ToInt32(LstCreditos.Columns["CreditoID"].Value);
                ObjFrmPagosMultiples.NomCampanha = LstCreditos.Columns["NomCampanha"].Value.ToString();
                ObjFrmPagosMultiples.DtEmpresas = DtEmpresas;
                ObjFrmPagosMultiples.NomCaja = NomCaja;
                ObjFrmPagosMultiples.ShowDialog();
                ObjFrmPagosMultiples.Dispose();
                LimpiarTodo();
            }
            else
            {
                if (NumCaja == 0) { ErrProvider.SetError(LblCaja, "Esta caja no existe."); }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //formato para alinear los nuimeros a la derecha
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;
            //formato.LineAlignment = StringAlignment.Far;

            //obtener la cadena del total a pagar
            //string TotalPagarLetras = ObjTextFunctions.enletras(TotalPagar.ToString());

            e.Graphics.DrawString(FormatoImpresion, TxtFechaEmision.Font, Brushes.Black,1,1); //total pagar en letras

        }

        private void BtnImpresora_Click(object sender, EventArgs e)
        {
           printDialog1.Document = printDocument1;
            //printDialog1.AllowSelection = true;
            //printDialog1.AllowSomePages = true;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                ImpresoraPago = printDialog1.PrinterSettings.PrinterName;
                //*****************guardar la configuracion de la impresora en el appconfig**************
                if (ImpresoraPago != AppSettings.ImpresoraPago & ImpresoraPago != "")
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    AppSettingsSection appSettings = config.AppSettings;

                    KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraPago"];
                    setting.Value = ImpresoraPago;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                //************************ fin guardar configuracion ***************************************
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarComprobante ObjFrmBuscarComprobante = new FrmBuscarComprobante();
            ObjFrmBuscarComprobante.DtClientes = DtClientes.Copy();
            ObjFrmBuscarComprobante.ShowDialog();
            if (ObjFrmBuscarComprobante.TipoComprobanteID != 0)
            {
                c1cboCia.SelectedValue = ObjFrmBuscarComprobante.EmpresaID;
                cbComprobante.SelectedValue = ObjFrmBuscarComprobante.TipoComprobanteID;
                TxtComprobante.Text = ObjFrmBuscarComprobante.NumComprobante;
                BtnConsultar_Click(null, null);
            }
        }
    }
}

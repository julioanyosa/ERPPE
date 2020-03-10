using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Entidad.Ventas;
using Halley.CapaLogica.Ventas;
using Halley.Configuracion;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas.Administracion
{
    public partial class Credito : UITemplateAccess
    {
        CL_Credito ObjCL_Credito = new CL_Credito();
        private TextFunctions ObjTextFunctions = new TextFunctions();
        DataTable DtFechas = new DataTable();
        DataTable DtCreditos = new DataTable();
        string Accion = "";

        public Credito()
        {
            InitializeComponent();
        }

        private void Credito_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            useCliente1.Cargar(new CL_Cliente().GetClientes());
            DeFechaInicio.Value = DateTime.Now;
            habilitar(false);
        }

        private void BtnAprobar_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            try
            {
                //validar
                if (TxtLineaCredito.Text != "" & TxtDiasFinanciar.Text != "")
                {

                    //insertar crédito
                    Int32 CreditoID = 0;
                    if(LblCreditoID.Text != "")
                        CreditoID = Convert.ToInt32(LblCreditoID.Text);
                    //obtener datos del crédito
                    E_Credito ObjCredito = new E_Credito();
                    ObjCredito.CreditoID = CreditoID;
                    ObjCredito.ClienteID = Convert.ToInt32(useCliente1.cbCliente.Columns["ClienteID"].Value);
                    if (TxtNomCampanha.Text == "")
                        ObjCredito.NomCampanha = DeFechaInicio.Value.ToString();
                    else
                        ObjCredito.NomCampanha = TxtNomCampanha.Text;
                    ObjCredito.LineaCredito = Convert.ToDecimal(TxtLineaCredito.Text);
                    ObjCredito.DiasFinanciar = Convert.ToInt32(TxtDiasFinanciar.Text);
                    if (TxtCreditoDisponible.Text != "")
                        ObjCredito.CreditoDisponible = Convert.ToDecimal(TxtCreditoDisponible.Text);
                    ObjCredito.NumDeclaracionJurada = TxtNumDeclaracionJurada.Text;
                    ObjCredito.SedeIDCredito = AppSettings.SedeID;
                    ObjCredito.FechaInicio = Convert.ToDateTime(DeFechaInicio.Value);
                    ObjCredito.EstadoID = 0;//planeado
                    ObjCredito.UsuarioID = AppSettings.UserID;

                    if (Accion == "N")
                    {
                        CreditoID = ObjCL_Credito.InsertCredito(ObjCredito);
                        MessageBox.Show("Se guardo el crédito correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        habilitar(true);
                        limpiar();//limpiar
                        useCliente1_ComboValueChange(); //refrescar
                        habilitar(false);
                    }
                    else if (Accion == "M")
                    {
                        ObjCL_Credito.UpdateCredito(ObjCredito);
                        MessageBox.Show("Se edito el crédito correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        habilitar(true);
                        limpiar();//limpiar
                        useCliente1_ComboValueChange(); //refrescar
                        habilitar(false);
                    }
                    else if (Accion == "E")
                    {
                        if (MessageBox.Show("¿Seguro que desea anular el crédito?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ObjCredito.EstadoID = 10;
                            ObjCL_Credito.UpdateCredito(ObjCredito);
                            MessageBox.Show("Se deshabilito el crédito correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            habilitar(true);
                            limpiar();//limpiar
                            useCliente1_ComboValueChange(); //refrescar
                            habilitar(false);
                        }
                    }
                    Accion = "";
                    
                }
                else
                {
                    if (TxtLineaCredito.Text == "")
                        ErrProvider.SetError(TxtLineaCredito, "Ingrese el monto de crédito");
                    if (TxtDiasFinanciar.Text == "")
                        ErrProvider.SetError(TxtDiasFinanciar, "Ingrese los días a financiar el crédito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void GetCreditosCompra(int ClienteID)
        {
            //traer fechas de compra
            DtFechas = new DataTable();
            DtFechas = ObjCL_Credito.GetFechasCompra(ClienteID);
            TxtFechaInicial.ReadOnly = false;
            TxtFechaInicial.Text = DtFechas.Rows[0]["AudCrea"].ToString() + "";
            TxtFechaInicial.ReadOnly = true;
            TxtFechaFinal.ReadOnly = false;
            TxtFechaFinal.Text = DtFechas.Rows[1]["AudCrea"].ToString() + "";
            TxtFechaFinal.ReadOnly = true;

            //traer créditos
            DtCreditos = new DataTable();
            DtCreditos = ObjCL_Credito.GetCreditosCliente(ClienteID,"T");
            TdgCreditos.SetDataBinding(DtCreditos, "", true);

            TxtCreditosOtorgados.ReadOnly = false;
            TxtCreditosOtorgados.Text = DtCreditos.Compute("sum(LineaCredito)", "").ToString();//suma de créditos
            TxtCreditosOtorgados.ReadOnly = true;
        }

        private void TxtDiasFinanciar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.SoloNumero(sender, e, TxtDiasFinanciar);
        }

        private void TxtLineaCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtLineaCredito);
        }

        private void useCliente1_ComboValueChange()
        {
            GetCreditosCompra(Convert.ToInt32(useCliente1.cbCliente.SelectedValue));
        }

        private void limpiar()
        {
            DtFechas.Rows.Clear();
            DtCreditos.Rows.Clear();
            LblCreditoID.Text = "";
            TxtLineaCredito.Text = "";
            TxtDiasFinanciar.Text = "";
            DeFechaInicio.Value = null;
            TxtNomCampanha.Text = "";
            TxtNumDeclaracionJurada.Text = "";
            TxtCreditoDisponible.Text = "";
            DeFechaVencimiento.Value = null;
            DeFechaInicio.Value = null;
        }

        private void TdgCreditos_RowColChange(object sender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs e)
        {
            habilitar(true);
            ErrProvider.Clear();
            LblCreditoID.Text = TdgCreditos.Columns["CreditoID"].Value.ToString();
            TxtLineaCredito.Text = TdgCreditos.Columns["LineaCredito"].Value.ToString();
            TxtDiasFinanciar.Text = TdgCreditos.Columns["DiasFinanciar"].Value.ToString();
            DeFechaInicio.Value = TdgCreditos.Columns["FechaInicio"].Value.ToString();
            TxtNomCampanha.Text = TdgCreditos.Columns["NomCampanha"].Value.ToString();
            TxtNumDeclaracionJurada.Text = TdgCreditos.Columns["NumDeclaracionJurada"].Value.ToString();
            TxtCreditoDisponible.Text = TdgCreditos.Columns["CreditoDisponible"].Value.ToString();
            DeFechaVencimiento.Value = TdgCreditos.Columns["FechaVencimiento"].Value.ToString();
            habilitar(false);
            BtnAprobar.Visible = false;
            BtnModificar.Visible = true;
            BtnAnular.Visible = true;
        }

        private void habilitar(bool Valor)
        {
            TxtLineaCredito.Enabled = Valor;
            TxtDiasFinanciar.Enabled = Valor;
            DeFechaInicio.Enabled = Valor;
            TxtNomCampanha.Enabled = Valor;
            TxtNumDeclaracionJurada.Enabled = Valor;
            TxtCreditoDisponible.Enabled = Valor;
            DeFechaVencimiento.Enabled = Valor;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            habilitar(true);
            DeFechaVencimiento.Enabled = false;
            TxtCreditoDisponible.Enabled = false;
            BtnAprobar.Visible = true;
            BtnCancelar.Visible = true;
            BtnModificar.Visible = false;
            BtnNuevo.Visible = false;
            BtnAumentar.Visible = true;
            BtnAnular.Visible = false;
            Accion = "M";
            DeFechaVencimiento.Enabled = false;
            TxtCreditoDisponible.Enabled = false;
            TxtLineaCredito.Enabled = false;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            habilitar(true);
            LimpiarTexto();
            BtnAprobar.Visible = true;
            BtnCancelar.Visible = true;
            BtnNuevo.Visible = false;
            BtnModificar.Visible = false;
            BtnAumentar.Visible = false;
            BtnAnular.Visible = false;
            Accion = "N";
            DeFechaVencimiento.Enabled = false;
            TxtCreditoDisponible.Enabled = false;
        }

        private void LimpiarTexto()
        {
            LblCreditoID.Text = "";
            TxtLineaCredito.Text = "";
            TxtDiasFinanciar.Text = "";
            DeFechaInicio.Value = null;
            TxtNomCampanha.Text = "";
            TxtNumDeclaracionJurada.Text = "";
            TxtCreditoDisponible.Text = "";
            DeFechaVencimiento.Value = null;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            habilitar(true);
            LimpiarTexto();
            habilitar(false);
            BtnAprobar.Visible = false;
            BtnCancelar.Visible = false;
            BtnNuevo.Visible = true;
            BtnAumentar.Visible = false;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            TxtAumentar.Text = "0";
            PnlAumentar.Visible = false;
        }

        private void BtnAumentar_Click(object sender, EventArgs e)
        {
            PnlAumentar.Visible = true;
        }

        private void BtnAgregaAumento_Click(object sender, EventArgs e)
        {
            if (TxtAumentar.Text != "")
            {
                TxtLineaCredito.Enabled = true;
                TxtLineaCredito.Text = (Convert.ToDecimal(TxtLineaCredito.Text) + Convert.ToDecimal(TxtAumentar.Text)).ToString();
                TxtLineaCredito.Enabled = false;
                TxtCreditoDisponible.Enabled = true;
                TxtCreditoDisponible.Text = (Convert.ToDecimal(TxtCreditoDisponible.Text) + Convert.ToDecimal(TxtAumentar.Text)).ToString();
                TxtCreditoDisponible.Enabled = false;
            }
            TxtAumentar.Text = "0";
            PnlAumentar.Visible = false;
        }

        private void BtnDisminuir_Click(object sender, EventArgs e)
        {
            if (TxtAumentar.Text != "")
            {
                TxtLineaCredito.Enabled = true;
                TxtLineaCredito.Text = (Convert.ToDecimal(TxtLineaCredito.Text) - Convert.ToDecimal(TxtAumentar.Text)).ToString();
                TxtLineaCredito.Enabled = false;
                TxtCreditoDisponible.Enabled = true;
                TxtCreditoDisponible.Text = (Convert.ToDecimal(TxtCreditoDisponible.Text) - Convert.ToDecimal(TxtAumentar.Text)).ToString();
                TxtCreditoDisponible.Enabled = false;
            }
            TxtAumentar.Text = "0";
            PnlAumentar.Visible = false;
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            Accion = "E";
            BtnAprobar_Click(null, null);
        }

        private void TdgCreditos_FetchRowStyle(object sender, C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs e)
        {
            string S = TdgCreditos.Columns["EstadoID"].CellText(e.Row).ToString();
            if (S == "10")
            {
                e.CellStyle.BackColor = System.Drawing.Color.Red;
            }
        }

        private void BtncanjearPuntos_Click(object sender, EventArgs e)
        { 

            DataTable Dtempresas = new Halley.CapaLogica.Empresa.CL_Empresas().GetEmpresas();
            FrmImprimirPuntos ObjFrmImprimirPuntos = new FrmImprimirPuntos();
            ObjFrmImprimirPuntos.ClienteID = Convert.ToInt32(useCliente1.cbCliente.Columns["ClienteID"].Value);
            ObjFrmImprimirPuntos.EmpresaID = Dtempresas.Rows[0]["EmpresaID"].ToString();
            ObjFrmImprimirPuntos.RUC = Dtempresas.Rows[0]["RUC"].ToString();
            ObjFrmImprimirPuntos.NombreEmpresa = Dtempresas.Rows[0]["NomEmpresa"].ToString();
            ObjFrmImprimirPuntos.NroDocumento = useCliente1.cbCliente.Columns["NroDocumento"].Value.ToString();
            ObjFrmImprimirPuntos.RazonSocial = useCliente1.cbNombre.Columns["RazonSocial"].Value.ToString();
            ObjFrmImprimirPuntos.ShowDialog();
        }
         
    }
}

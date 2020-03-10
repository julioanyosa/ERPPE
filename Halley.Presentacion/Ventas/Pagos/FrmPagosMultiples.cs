using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.Utilitario;
using Halley.Configuracion;
using Halley.Entidad.Ventas;
using Halley.CapaLogica.Empresa;

namespace Halley.Presentacion.Ventas.Pagos
{

    public partial class FrmPagosMultiples : Form
    {
        #region Variables
        DataTable DtPM = new DataTable();
        string ImpresoraPago = AppSettings.ImpresoraPago;
        string FormatoImpresion = "";
        CL_Pago ObjCL_Pago = new CL_Pago();
        bool Actualizar = false;
        decimal MontoDigitado = 0;
        //decimal CantidadDescontar = 0;
        decimal MontoDevolver = 0;
        decimal TotalPagar = 0;
        #endregion

        #region Propiedades
        private int _Numcaja;
        private string _NomCaja;
        private Int32 _CreditoID;
        private string _NomCampanha;
        private DataTable _DtComprobantes;
        private DataTable _DtFormasPago;
        private DataTable _DtEmpresas;

        public int Numcaja
        {
            get { return _Numcaja; }
            set { _Numcaja = value; }
        }
        public string NomCaja
        {
            get { return _NomCaja; }
            set { _NomCaja = value; }
        }
        public Int32 CreditoID
        {
            get { return _CreditoID; }
            set { _CreditoID = value; }
        }
        public string NomCampanha
        {
            get { return _NomCampanha; }
            set { _NomCampanha = value; }
        }
        public DataTable DtComprobantes
        {
            get { return _DtComprobantes; }
            set { _DtComprobantes = value; }
        }
        public DataTable DtFormasPago
        {
            get { return _DtFormasPago; }
            set { _DtFormasPago = value; }
        }
        public DataTable DtEmpresas
        {
            get { return _DtEmpresas; }
            set { _DtEmpresas = value; }
        }
        #endregion
        public FrmPagosMultiples()
        {
            InitializeComponent();
        }

        private void FrmPagosMultiples_Load(object sender, EventArgs e)
        {
            //agregar columna de filtro
            DtPM = new DataTable();
            DtComprobantes.Columns.Add("Pagar", typeof(bool)).DefaultValue = false;
            DtComprobantes.Columns["Pagar"].ReadOnly = false;
            DataView DV = new DataView(DtComprobantes);
            DV.RowFilter = "EstadoID in(14,13)";
            DtPM = DV.ToTable();
            TdgMultiplesPagos.SetDataBinding(DtPM, "", true);

            c1Combo.FillC1Combo1(cbFormaPago, DtFormasPago, "NomFormaPago", "FormaPagoID");
            TxtMontoRestante.ReadOnly = true;
        }


        private void FrmPagosMultiples_FormClosed(object sender, FormClosedEventArgs e)
        {
            DtComprobantes.Columns.Remove("Pagar");
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            try
            {
           
                ErrProvider.Clear();
                //if (Actualizar == true && cbFormaPago.SelectedIndex != -1)
                if (TxtPagar.Text != "" & TxtPagar.Text != "." & cbFormaPago.SelectedIndex != -1)
                {
                    if (MessageBox.Show("¿Esta seguro que desea registrar el pago de los comprobantes seleccionados?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //obtener monto digitado
                        MontoDigitado = Convert.ToDecimal(TxtPagar.Text);

                        foreach (DataRow DREM in DtEmpresas.Rows)
                        {
                            string EmpresaID = DREM["EmpresaID"].ToString();
                            string NomEmpresa = DREM["NomEmpresa"].ToString();
                            string RUC = DREM["RUC"].ToString();

                            //construir tabla
                            DataTable DtComprobanteE = new DataTable("Comprobante");
                            DtComprobanteE.Columns.Add("EmpresaID", typeof(string));
                            DtComprobanteE.Columns.Add("FormaPagoID", typeof(int));
                            DtComprobanteE.Columns.Add("Observacion", typeof(string));
                            DtComprobanteE.Columns.Add("NumComprobante", typeof(string));
                            DtComprobanteE.Columns.Add("TipoComprobanteID", typeof(int));
                            DtComprobanteE.Columns.Add("LugarPago", typeof(string));
                            DtComprobanteE.Columns.Add("Importe", typeof(decimal));
                            DtComprobanteE.Columns.Add("EstadoID", typeof(string));

                            //llenar tabla
                            decimal Valor = 0;
                            foreach (DataRow Dr in DtPM.Rows)
                            {
                                if (Dr["Pagar"] != DBNull.Value)
                                {
                                    if (Dr["Pagar"].ToString() != "" & Convert.ToBoolean(Dr["Pagar"]) == true & Dr["NumComprobante"].ToString().Substring(0, 2) == EmpresaID)
                                    {
                                        Valor = MontoDigitado - Convert.ToDecimal(Dr["TotalPagar"]);
                                        if (Valor >= 0)
                                        {
                                            MontoDigitado = MontoDigitado - Convert.ToDecimal(Dr["TotalPagar"]);//calcular el nuevo monto digitado
                                            DataRow DRE = DtComprobanteE.NewRow();
                                            DRE["EmpresaID"] = Dr["NumComprobante"].ToString().Substring(0, 2);
                                            DRE["FormaPagoID"] = cbFormaPago.SelectedValue;
                                            DRE["Observacion"] = TxtObservacion.Text;
                                            DRE["NumComprobante"] = Dr["NumComprobante"];
                                            DRE["TipoComprobanteID"] = Dr["TipoComprobanteID"];
                                            DRE["LugarPago"] = AppSettings.SedeID;
                                            DRE["Importe"] = Dr["TotalPagar"];
                                            DRE["EstadoID"] = 12; //pagado
                                            DtComprobanteE.Rows.Add(DRE);
                                            MontoDevolver = MontoDigitado;

                                            TotalPagar += Convert.ToDecimal(Dr["TotalPagar"]);
                                        }
                                        else if (Valor < 0)
                                        {
                                            //seria una parte del pago
                                            DataRow DRE = DtComprobanteE.NewRow();
                                            DRE["EmpresaID"] = Dr["NumComprobante"].ToString().Substring(0, 2);
                                            DRE["FormaPagoID"] = cbFormaPago.SelectedValue;
                                            DRE["Observacion"] = TxtObservacion.Text;
                                            DRE["NumComprobante"] = Dr["NumComprobante"];
                                            DRE["TipoComprobanteID"] = Dr["TipoComprobanteID"];
                                            DRE["LugarPago"] = AppSettings.SedeID;
                                            DRE["Importe"] = MontoDigitado;
                                            DRE["EstadoID"] = 13; //pago parcial
                                            DtComprobanteE.Rows.Add(DRE);
                                            MontoDevolver = 0;
                                            TotalPagar += MontoDigitado;
                                            break;
                                        }
                                    }
                                }
                            }

                            //crear nota de ingreso
                            E_NotaIngreso ObjE_NotaIngreso = new E_NotaIngreso();
                            ObjE_NotaIngreso.EmpresaID = EmpresaID;
                            ObjE_NotaIngreso.Tipo = "I";
                            ObjE_NotaIngreso.Numcaja = Numcaja;
                            ObjE_NotaIngreso.FormaPagoID = Convert.ToInt16(cbFormaPago.SelectedValue);
                            ObjE_NotaIngreso.Observacion = TxtObservacion.Text;
                            ObjE_NotaIngreso.LugarPago = AppSettings.SedeID;
                            ObjE_NotaIngreso.Importe = MontoDigitado;
                            ObjE_NotaIngreso.UsuarioID = AppSettings.UserID;

                            //crear la nota de ingreso
                            Int32 NotaIngresoID = 0;
                            if (DtComprobanteE.Rows.Count > 0)
                            {
                                printDocument1.PrinterSettings.PrinterName = ImpresoraPago;
                                if (printDocument1.PrinterSettings.PrinterName != "")
                                {
                                    NotaIngresoID = ObjCL_Pago.UpdateXMLEstadoComprobantes(DtComprobanteE, ObjE_NotaIngreso);
                                    MessageBox.Show("Se almaceno los pagos correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    #region formato de etiquetera
                                    FormatoImpresion = ObjCL_Pago.FormatoTicketPago(NomEmpresa, CreditoID, NomCampanha, AppSettings.NomSede, RUC, AppSettings.Usuario.ToString(), TotalPagar, NomCaja);
                                    //MessageBox.Show(FormatoImpresion, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    #endregion
                                    printDocument1.Print();

                                    TotalPagar = 0;
                                }
                                else
                                    MessageBox.Show("Debe seleccionar una impresora valida. no se guardara el pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        
                    }
                    Close();
                }
                else
                {
                    if (cbFormaPago.SelectedIndex == -1) { ErrProvider.SetError(cbFormaPago,"Debe seleccionar una forma de pago");}
                    if (Actualizar == false)
                    {
                        ErrProvider.SetError(TxtPagar, "Tal vez el monto ingresado no cubre la cantidad de comprobantes a pagar");
                        MessageBox.Show("Tal vez el monto ingresado no cubre la cantidad de comprobantes a pagar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChkSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeleccionarTodo.Checked == true & this.TdgMultiplesPagos.RowCount > 0)
            {
                for (int i = 0; i <= this.TdgMultiplesPagos.RowCount - 1; i++)
                {
                    this.TdgMultiplesPagos[i, "Pagar"] = true;
                }
                this.TdgMultiplesPagos.Refresh();
            }
            else if (ChkSeleccionarTodo.Checked == false & this.TdgMultiplesPagos.RowCount > 0)
            {

                for (int i = 0; i <= this.TdgMultiplesPagos.RowCount - 1; i++)
                {
                    this.TdgMultiplesPagos[i, "Pagar"] = false;
                }
                this.TdgMultiplesPagos.Refresh();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(FormatoImpresion, TxtPagar.Font, Brushes.Black, 1, 1); //total pagar en letras
        }
    }
}

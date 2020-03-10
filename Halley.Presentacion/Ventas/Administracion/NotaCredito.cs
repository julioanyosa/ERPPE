using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.Utilitario;
using Halley.CapaLogica.Empresa;
using Halley.Entidad.Ventas;
using Halley.Configuracion;
using System.Net;

namespace Halley.Presentacion.Ventas.Administracion
{
    public partial class NotaCredito : UITemplateAccess
    {

        DataSet DsComprobante = new DataSet();
        DataTable DtDetalleComprobante = new DataTable("DetalleComprobante");
        DataTable DtCajas = new DataTable();
        CL_NotaCredito ObjCL_NotaCredito = new CL_NotaCredito();
        CL_Comprobante ObjComprobante = new CL_Comprobante();
        string NumComprobante, EmpresaID, SedeID;
        int TipoComprobanteID, ClienteID, NumCaja;
        string NotaCreditoID;
        decimal Importe;
        string NomCaja = "";

        public NotaCredito()
        {
            InitializeComponent();
        }

        private void NotaCredito_Load(object sender, EventArgs e)
        {
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

            LblCaja.Text = NomCaja;
            c1Combo.FillC1Combo1(cbComprobante, new CL_Comprobante().getTipoComprobante(), "NomTipoComprobante", "TipoComprobanteID");
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            this.TdgDetalleComprobante.Columns["Descontar"].Editor = this.c1NumericEdit1;// enlazar con control para que acepte solo numeros
            ocultarToolStrip();
            BtnRegistrar.Visible = false;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            Cursor = Cursors.WaitCursor;
            try
            {
                bool ActualizaStock = false;

                    if (LblDevolucion.Text != "" & TxtConcepto.Text != "" || rbOtros.Checked)
                    {
                        if (Importe > 0 || rbOtros.Checked ==true)
                        {
                            E_NotaCredito ObjE_NotaCredito = new E_NotaCredito();
                            ObjE_NotaCredito.ClienteID = ClienteID;
                            ObjE_NotaCredito.NumCaja = NumCaja;
                            ObjE_NotaCredito.NumComprobante = NumComprobante;
                            ObjE_NotaCredito.TipoComprobanteID = TipoComprobanteID;
                            if (rbOtros.Checked)
                                ObjE_NotaCredito.Importe = 0;
                            else
                                ObjE_NotaCredito.Importe = Importe;

                            if (rbDescuentos.Checked)
                                ObjE_NotaCredito.descuento = Convert.ToDecimal(txtDescuento.Text);
                            ObjE_NotaCredito.Concepto = TxtConcepto.Text;
                            ObjE_NotaCredito.UsuarioID = AppSettings.UserID;
                            ObjE_NotaCredito.SedeID = AppSettings.SedeID;

                            DataTable DT = new DataTable("DetalleComprobante");

                            if (rbNormal.Checked)
                            {
                                //eliminar columnas
                              
                                DataView DV = new DataView(DtDetalleComprobante);
                                DV.RowFilter = "Descontar > 0";
                                DT = DV.ToTable();
                                DT.Columns.Remove("NumComprobante");
                                DT.Columns.Remove("TipoComprobanteID");
                                DT.Columns.Remove("Alias");
                                DT.Columns.Remove("UnidadMedidaID");
                                DT.Columns.Remove("Cantidad");
                                DT.Columns.Remove("PrecioUnitario");
                                DT.Columns.Remove("Importe");
                                DT.Columns.Remove("EstadoID");

                                ActualizaStock = true;
                            }
                            else
                            {
                                ActualizaStock = false;
                            }

                            NotaCreditoID = ObjCL_NotaCredito.InsertNotaCredito(ObjE_NotaCredito, DT, EmpresaID + AppSettings.SedeID, ActualizaStock);
                            MessageBox.Show("Se creo la nota de credito correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           // MessageBox.Show(ObjCL_NotaCredito.FormatoNotaCredito(LblEmpresa.Text, NotaCreditoID, NumComprobante, cbComprobante.Columns["NomTipoComprobante"].Value.ToString(), AppSettings.NomSede, LblRUC.Text, AppSettings.Usuario, Importe, NomCaja, TxtConcepto.Text), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                }
                else
                {
                    if (TxtConcepto.Text == "") ErrProvider.SetError(TxtConcepto, "Debe ingresar el motivo de la devolución.");
                    if (LblDevolucion.Text == "" | LblDevolucion.Text == "0") ErrProvider.SetError(LblDevolucion, "El importe de devolución no debe ser cero.");
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
 
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            try
            {
                //traer detalles de las guias
                if (TxtNumComprobante.Text != "" && cbComprobante.SelectedIndex != -1 & c1cboCia.SelectedIndex != -1)
                {

                    DsComprobante = ObjCL_NotaCredito.GetComprobanteNotaCredito(c1cboCia.SelectedValue.ToString() + TxtNumComprobante.Text, Convert.ToInt32(cbComprobante.SelectedValue));
                    if (DsComprobante.Tables["Comprobante"].Rows.Count > 0)
                    {
                        NumComprobante = DsComprobante.Tables["Comprobante"].Rows[0]["NumComprobante"].ToString();
                        TipoComprobanteID = Convert.ToInt32(DsComprobante.Tables["Comprobante"].Rows[0]["TipoComprobanteID"]);
                        EmpresaID = DsComprobante.Tables["Comprobante"].Rows[0]["EmpresaID"].ToString();
                        ClienteID = Convert.ToInt32(DsComprobante.Tables["Comprobante"].Rows[0]["ClienteID"]);
                        SedeID = DsComprobante.Tables["Comprobante"].Rows[0]["SedeID"].ToString();
                        lblCliente.Text = DsComprobante.Tables["Comprobante"].Rows[0]["RazonSocial"].ToString();
                        lblDocumento.Text = DsComprobante.Tables["Comprobante"].Rows[0]["NroDocumento"].ToString();
                        LblTipoDocumento.Text = DsComprobante.Tables["Comprobante"].Rows[0]["TipoDocumento"].ToString();
                        LblAudCrea.Text = DsComprobante.Tables["Comprobante"].Rows[0]["AudCrea"].ToString();
                        lblDireccion.Text = DsComprobante.Tables["Comprobante"].Rows[0]["Direccion"].ToString();
                        LblVendedor.Text = DsComprobante.Tables["Comprobante"].Rows[0]["NomVendedor"].ToString();
                        LblEmpresa.Text = DsComprobante.Tables["Comprobante"].Rows[0]["NomEmpresa"].ToString();
                        LblRUC.Text = DsComprobante.Tables["Comprobante"].Rows[0]["RUC"].ToString();

                        lblMonto.Text = DsComprobante.Tables["Comprobante"].Rows[0]["MontoTotal"].ToString();

                        if (rbNormal.Checked)
                        {
                            #region llenarlos en una nueva tabla apra estructurarlo
                            DtDetalleComprobante = new DataTable("DetalleComprobante");
                            DtDetalleComprobante.Columns.Add("NumComprobante", typeof(string));
                            DtDetalleComprobante.Columns.Add("TipoComprobanteID", typeof(int));
                            DtDetalleComprobante.Columns.Add("ProductoID", typeof(string));
                            DtDetalleComprobante.Columns.Add("Alias", typeof(string));
                            DtDetalleComprobante.Columns.Add("UnidadMedidaID", typeof(string));
                            DtDetalleComprobante.Columns.Add("Cantidad", typeof(decimal));
                            DtDetalleComprobante.Columns.Add("PrecioUnitario", typeof(decimal));
                            DtDetalleComprobante.Columns.Add("Importe", typeof(decimal));
                            DtDetalleComprobante.Columns.Add("EstadoID", typeof(int));
                            DtDetalleComprobante.Columns.Add("AlmacenID", typeof(string));
                            DtDetalleComprobante.Columns.Add("Descontar", typeof(decimal)).DefaultValue = 0;

                            foreach (DataRow DR in DsComprobante.Tables["DetalleComprobante"].Rows)
                            {
                                DataRow DRD = DtDetalleComprobante.NewRow();
                                DRD["NumComprobante"] = DR["NumComprobante"];
                                DRD["TipoComprobanteID"] = DR["TipoComprobanteID"];
                                DRD["ProductoID"] = DR["ProductoID"];
                                DRD["Alias"] = DR["Alias"];
                                DRD["UnidadMedidaID"] = DR["UnidadMedidaID"];
                                DRD["Cantidad"] = DR["Cantidad"];
                                DRD["PrecioUnitario"] = DR["PrecioUnitario"];
                                DRD["Importe"] = DR["Importe"];
                                DRD["EstadoID"] = DR["EstadoID"];
                                DRD["AlmacenID"] = EmpresaID + SedeID + DR["Almacen"].ToString();
                                DtDetalleComprobante.Rows.Add(DRD);

                            }
                            #endregion

                            TdgDetalleComprobante.Visible = true;
                            DtDetalleComprobante.Columns["Descontar"].ReadOnly = false;
                            TdgDetalleComprobante.SetDataBinding(DtDetalleComprobante, "", true);
                            panel1.Visible = false;
                        }
                        else if (rbDescuentos.Checked)
                        {
                            TdgDetalleComprobante.Visible = false;
                            panel1.Visible = true;
                            txtDescuento.Focus();
                        }
                        else
                        {
                            TdgDetalleComprobante.Visible = false;
                            panel1.Visible = false;
                            LblDevolucion.Text = "0";
                            lblDireccion.ReadOnly = false;
                            lblDireccion.Focus();
                        }

                        BtnRegistrar.Visible = true;
                    }
                    else
                    {
                        Limpiar();
                        BtnRegistrar.Visible = false;                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Importe = 0;
                LblDevolucion.Text = Importe.ToString();
            }
        }

        private void Limpiar()
        {
            NumComprobante = "";
            TipoComprobanteID = 0;
            EmpresaID = "";
            ClienteID = 0;
            SedeID = "";
            lblCliente.Text = "";
            lblDocumento.Text = "";
            LblTipoDocumento.Text = "";
            LblAudCrea.Text = "";
            lblDireccion.Text = "";
            LblVendedor.Text = "";
            LblEmpresa.Text = "";
            LblRUC.Text = "";
            TxtConcepto.Text = "";
            DsComprobante.Clear();
            DtDetalleComprobante.Rows.Clear();
            Importe = 0;
            LblDevolucion.Text = Importe.ToString();
            txtDescuento.Text = "";
            panel1.Visible = false;
            BtnRegistrar.Visible = false;
            lblDireccion.ReadOnly = true;
        }

        private void TdgDetalleComprobante_AfterUpdate(object sender, EventArgs e)
        {
            if (DtDetalleComprobante.Rows.Count > 0)
            {
                //calcular el importe automaticamente
                Importe = 0;
                foreach (DataRow DR in DtDetalleComprobante.Rows)
                {
                    if (DR["Descontar"].ToString() != "." & DR["Descontar"].ToString() != "" & DR["Descontar"].ToString() != "0")
                        Importe += Convert.ToDecimal(DR["PrecioUnitario"]) * Convert.ToDecimal(DR["Descontar"]);
                }
                LblDevolucion.Text = Importe.ToString();
            }
        }

        private void TdgDetalleComprobante_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {

            if (Convert.ToDecimal(TdgDetalleComprobante.Columns["Descontar"].Value) > Convert.ToDecimal(TdgDetalleComprobante.Columns["Cantidad"].Value))
            {
                MessageBox.Show("La cantidad a descontar no puede ser mayor a la cantidad despachada.", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                TdgDetalleComprobante.Columns["Descontar"].Value = 0;
                e.Cancel = false;
                return;
            }
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtDescuento_TextChanged_1(object sender, EventArgs e)
        {
            if (txtDescuento.Text != "")
            {
                if (Convert.ToDecimal(txtDescuento.Text) <= 100)
                {
                    Importe = (Convert.ToDecimal(txtDescuento.Text) / 100 * Convert.ToDecimal(lblMonto.Text));
                    LblDevolucion.Text = Importe.ToString("C");
                }
                else
                {
                    txtDescuento.Text = "0";
                }
            }
        }

        private void txtDescuento_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            new TextFunctions().ValidaNumero(sender, e, txtDescuento);

        }
    }
}


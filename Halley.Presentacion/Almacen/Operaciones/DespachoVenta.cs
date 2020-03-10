using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Configuracion;
using Halley.CapaLogica;
using Halley.CapaLogica.Ventas;
using Halley.CapaLogica.Empresa;
using Halley.CapaLogica.Almacen;
using Halley.Utilitario;
using Halley.Entidad.Almacen;
using Halley.Presentacion.Ventas.Pagos;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class DespachoVenta : UITemplateAccess
    {

        #region Declaracion de variables
        string NomProducto = "";
        CL_Venta ObjCL_Venta = new CL_Venta();
        CL_Almacen ObjCL_Almacen = new CL_Almacen();
        DataSet DsComprobante = new DataSet();
        DataTable DtDespacho = new DataTable();
        DataTable DtTipoComprobantes = new DataTable();
        DataTable DtClientes = new DataTable();
        DataTable DtServicios = new DataTable();
        #endregion

  
        public DespachoVenta()
        {
            InitializeComponent();
            ocultarToolStrip();


        }


        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //limpiar grilla y caja s de texto
                DsComprobante.Clear();
                DataTable dt = new DataTable();
                TdgReservas.SetDataBinding(dt,"",true);
                ReadonlyTxt(false);
                txtCliente.Text = "";
                TxtNroDocumento.Text = "";
                TxtTipoDocumento.Text = "";
                TxtNomTipoVenta.Text = "";
                TxtAudCrea.Text = "";
                TxtDireccion.Text = "";
                TxtNomVendedor.Text = "";
                TxtNomSede.Text = "";
                TxtNomCajero.Text = "";
                ReadonlyTxt(true);
                //traer detalles de las guias
                if (TxtNumComprobante.Text != "" && cbComprobante.SelectedIndex != -1 & c1cboCia.SelectedIndex != -1)
                {
                    DsComprobante = ObjCL_Venta.GetComprobante(c1cboCia.SelectedValue.ToString() + TxtNumComprobante.Text, Convert.ToInt32(cbComprobante.SelectedValue));
                    if (DsComprobante.Tables["Comprobante"].Rows.Count > 0)
                    {
                        ReadonlyTxt(false);
                        txtCliente.Text = DsComprobante.Tables["Comprobante"].Rows[0]["RazonSocial"].ToString();
                        TxtNroDocumento.Text = DsComprobante.Tables["Comprobante"].Rows[0]["NroDocumento"].ToString();
                        TxtTipoDocumento.Text = DsComprobante.Tables["Comprobante"].Rows[0]["TipoDocumento"].ToString();
                        TxtNomTipoVenta.Text = DsComprobante.Tables["Comprobante"].Rows[0]["NomTipoVenta"].ToString();
                        TxtAudCrea.Text = DsComprobante.Tables["Comprobante"].Rows[0]["AudCrea"].ToString();
                        TxtDireccion.Text = DsComprobante.Tables["Comprobante"].Rows[0]["Direccion"].ToString();
                        TxtNomVendedor.Text = DsComprobante.Tables["Comprobante"].Rows[0]["NomVendedor"].ToString();
                        TxtNomSede.Text = DsComprobante.Tables["Comprobante"].Rows[0]["NomSede"].ToString();
                        TxtNomCajero.Text = DsComprobante.Tables["Comprobante"].Rows[0]["NomCajero"].ToString();
                        ReadonlyTxt(true);

                        DsComprobante.Tables["DetalleComprobante"].Columns["Despachar"].ReadOnly = false;
                        DsComprobante.Tables["DetalleComprobante"].Columns["StockDisponible"].ReadOnly = false;
                        DsComprobante.Tables["DetalleComprobante"].Columns["AlmacenID"].ReadOnly = false;
                        DsComprobante.Tables["DetalleComprobante"].Columns.Add("PesoNeto", typeof(decimal));
                        DsComprobante.Tables["DetalleComprobante"].Columns["PesoNeto"].ReadOnly = false;
                        TdgReservas.SetDataBinding(DsComprobante.Tables["DetalleComprobante"], "", true);

                        BtnDespachar.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadonlyTxt(bool Valor)
        {
            txtCliente.ReadOnly = Valor;
            TxtNroDocumento.ReadOnly = Valor;
            TxtTipoDocumento.ReadOnly = Valor;
            TxtNomTipoVenta.ReadOnly = Valor;
            TxtAudCrea.ReadOnly = Valor;
            TxtDireccion.ReadOnly = Valor;
            TxtNomVendedor.ReadOnly = Valor;
            TxtNomSede.ReadOnly = Valor;
            TxtNomCajero.ReadOnly = Valor;
        }

        private void DespachoVenta_Load(object sender, EventArgs e)
        {
            DtTipoComprobantes = new CL_Comprobante().getTipoComprobante();
            c1Combo.FillC1Combo1(cbComprobante, DtTipoComprobantes, "NomTipoComprobante", "TipoComprobanteID");
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            this.TdgReservas.Columns[13].Editor = this.c1NumericEdit1;// enlazar con control para que acepte solo numeros
            this.TdgReservas.Columns["PesoNeto"].Editor = this.c1NumericEdit1;// enlazar con control para que acepte solo numeros
            ocultarToolStrip();
            ReadonlyTxt(true);
            BtnGenerarGuias.Visible = false;

            DtClientes = new CL_Cliente().GetClientes();

            //traer servicios otros
            DtServicios = ObjCL_Venta.GetServicios();

            cbComprobante.SelectedValue = 3;
            c1cboCia.SelectedValue = AppSettings.EmpresaID;

            //traer tipo de venta
            DataTable DtTipoVentas = new DataTable();
            DtTipoVentas = ObjCL_Venta.GetTiposVenta();
            c1Combo.FillC1Combo1(CboTipoVenta, DtTipoVentas, "NomTipoVenta", "TipoVentaID");
            CboTipoVenta.SelectedValue = 6;//venta diferida

            //llenar los minutos
            c1Combo.FillC1Combo1(CboMinuto,c1Combo.DtMinutos(),"Minuto","Minuto");
            CboMinuto.SelectedValue = "60";//60 min
        }

        private void TdgReservas_DoubleClick(object sender, EventArgs e)
        {
            if (TdgReservas.RowCount > 0)
            {
                FrmAlmacenes ObjFrmDespachos = new FrmAlmacenes();
                ObjFrmDespachos.Alias = TdgReservas.Columns["Alias"].Value.ToString();
                ObjFrmDespachos.ProductoID = TdgReservas.Columns["ProductoID"].Value.ToString();
                ObjFrmDespachos.EmpresaSede = AppSettings.EmpresaID + AppSettings.SedeID;
                ObjFrmDespachos.ShowDialog();

                //asignar Stock disponible al registro
                if (ObjFrmDespachos.StockDisponible != 0)
                {
                    TdgReservas.Columns["StockDisponible"].Value = ObjFrmDespachos.StockDisponible;
                    TdgReservas.Columns["AlmacenID"].Value = ObjFrmDespachos.AlmacenID;
                }
            }
        }

        private void TdgReservas_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {
            //habilitar si se puede modificar la columna de descpachar
            switch (e.Column.DataColumn.DataField)
            {
                case "Despachar":
                    if (this.TdgReservas[e.Row, "EstadoID"].ToString().Trim() == "5")//atendido y recepcion parcial
                    {
                        e.CellStyle.Locked = true;
                        break;
                    }
                    break;
            }
        }

        private void BtnDespachar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TdgReservas.RowCount > 0)
                {
                    bool HayCero = true;
                    //registrar despacho
                    DtDespacho = new DataTable("Despacho");
                    DtDespacho.Columns.Add("AlmacenID", typeof(string));
                    DtDespacho.Columns.Add("NomProducto", typeof(string));
                    DtDespacho.Columns.Add("UnidadMedidaID", typeof(string));
                    DtDespacho.Columns.Add("TipoComprobanteID", typeof(int));
                    DtDespacho.Columns.Add("NumComprobante", typeof(string));
                    DtDespacho.Columns.Add("ProductoID", typeof(string));
                    DtDespacho.Columns.Add("CantidadEnviada", typeof(decimal));
                    DtDespacho.Columns.Add("EstadoID", typeof(int));
                    DtDespacho.Columns.Add("PesoNeto", typeof(decimal));

                    foreach (DataRow Dr in DsComprobante.Tables["DetalleComprobante"].Rows)
                    {
                        //agregar los que su cantidad se altero (osea mayor a 0)
                        if (Convert.ToDecimal(Dr["Despachar"]) > 0)
                        {
                            if (Dr["PesoNeto"].ToString() == "" || Dr["PesoNeto"].ToString() == "." | Dr["PesoNeto"] == DBNull.Value | Convert.ToDecimal(Dr["PesoNeto"].ToString()) == 0)
                            {
                                HayCero = true;
                                NomProducto = Dr["Alias"].ToString();
                                MessageBox.Show("Hay peso '0' en el producto: " + NomProducto + ". el peso no debe ser cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else
                                HayCero = false;

                            DataRow DRP = DtDespacho.NewRow();
                            DRP["AlmacenID"] = Dr["AlmacenID"];
                            DRP["NomProducto"] = Dr["Alias"];
                            DRP["UnidadMedidaID"] = Dr["UnidadMedidaID"];
                            DRP["TipoComprobanteID"] = Dr["TipoComprobanteID"];
                            DRP["NumComprobante"] = Dr["NumComprobante"];
                            DRP["ProductoID"] = Dr["ProductoID"];
                            DRP["CantidadEnviada"] = Dr["Despachar"];
                            if (Convert.ToDecimal(Dr["PorDespachar"]) == Convert.ToDecimal(Dr["Despachar"]))
                                DRP["EstadoID"] = 5;//recepcion completa
                            else if (Convert.ToDecimal(Dr["PorDespachar"]) > Convert.ToDecimal(Dr["Despachar"]))
                                DRP["EstadoID"] = 4;//recepcion parcial
                            DRP["PesoNeto"] = Dr["PesoNeto"];
                            DtDespacho.Rows.Add(DRP);
                        }
                    }

                    if (DtDespacho.Rows.Count > 0 & HayCero == false)
                    {
                        //insertar los despachos
                        ObjCL_Almacen.InsertXMLDespachos(DtDespacho, AppSettings.UserID, 1);//SALIDA POR VENTA
                        MessageBox.Show("Se realizó el despacho con exito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("¿Desea crear guías para este despacho?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            BtnGenerarGuias_Click(null, null);
                        BtnDespachar.Visible = false;
                        BtnGenerarGuias.Visible = true;
                        //Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void TdgReservas_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            if (this.TdgReservas.RowCount > 0)
            {
                if (Convert.ToDecimal(TdgReservas.Columns["Despachar"].Value) > Convert.ToDecimal(TdgReservas.Columns["PorDespachar"].Value))
                {
                    MessageBox.Show("La cantidad a despachar no debe ser mayor a lo que falta por despachar", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    TdgReservas.Columns["Despachar"].Value = 0;
                    e.Cancel = false;
                    return;
                }
                else if (Convert.ToDecimal(TdgReservas.Columns["Despachar"].Value) > Convert.ToDecimal(TdgReservas.Columns["StockDisponible"].Value))
                {
                    MessageBox.Show("La cantidad a despachar no debe ser mayor al stock disponible", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    TdgReservas.Columns["Despachar"].Value = 0;
                    e.Cancel = false;
                    return;
                }

                if (TdgReservas.Columns["Despachar"].Value.ToString() != "" & TdgReservas.Columns["Despachar"].Value.ToString() != "." & Convert.ToDecimal(TdgReservas.Columns["Peso"].Value) > 0)
                {
                    //calcular peso
                    TdgReservas.Columns["PesoNeto"].Value = Convert.ToDecimal(TdgReservas.Columns["Despachar"].Value) * Convert.ToDecimal(TdgReservas.Columns["Peso"].Value);
                }
                //else
                    //TdgReservas.Columns["PesoNeto"].Value = 0;
            }
        }

        private void Limpiar()
        {
            ReadonlyTxt(false);
            foreach (DataTable Dt in DsComprobante.Tables)
            {
                Dt.Rows.Clear();
            }
            DtDespacho.Rows.Clear();
            TdgReservas.SetDataBinding(DtDespacho, "", true);

            #region aca se limpia las cajas de texto
            txtCliente.Text = "";
            TxtNroDocumento.Text = "";
            TxtTipoDocumento.Text = "";
            TxtNomTipoVenta.Text = "";
            TxtAudCrea.Text = "";
            TxtDireccion.Text = "";
            TxtNomVendedor.Text = "";
            TxtNomSede.Text = "";
            TxtNomCajero.Text = "";
            #endregion
            cbComprobante.SelectedValue = 3;
            c1cboCia.SelectedValue = AppSettings.EmpresaID;
            BtnDespachar.Visible = true;
            ReadonlyTxt(true);
        }

        private void BtnGenerarGuias_Click(object sender, EventArgs e)
        {
            #region Crear tabla para enviar a crear guias
            DataTable DtDetalleGuiaRemisionVenta = new DataTable("DetalleGuiaRemisionVenta");
            DtDetalleGuiaRemisionVenta = DtDespacho.Copy();
            DtDetalleGuiaRemisionVenta.TableName = "DetalleGuiaRemisionVenta";
            DtDetalleGuiaRemisionVenta.Columns.Remove("AlmacenID");
            DtDetalleGuiaRemisionVenta.Columns.Remove("TipoComprobanteID");
            DtDetalleGuiaRemisionVenta.Columns.Remove("NumComprobante");
            DtDetalleGuiaRemisionVenta.Columns.Remove("EstadoID");
            #endregion
            FrmGuias ObjFrmGuias = new FrmGuias();
            ObjFrmGuias.DtTipoComprobante = DtTipoComprobantes.Copy();
            ObjFrmGuias.DtDetalleGuiaRemisionVenta = DtDetalleGuiaRemisionVenta;
            ObjFrmGuias.Destinatario = txtCliente.Text;
            ObjFrmGuias.RUCDestinatario = TxtNroDocumento.Text;
            ObjFrmGuias.Remitente = c1cboCia.Columns["NomEmpresa"].ToString();
            ObjFrmGuias.RUCRemitente = c1cboCia.Columns["RUC"].ToString();
            ObjFrmGuias.DtServicios = DtServicios.Copy();
            ObjFrmGuias.ShowDialog();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void TxtNumComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                BtnBuscar_Click(null, null);
            }
        }

        private void cbComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                BtnBuscar_Click(null, null);
            }
        }

        private void BtnVerEntregas_Click(object sender, EventArgs e)
        {
            if (TdgReservas.RowCount > 0)
            {
                FrmDespachos ObjFrmDespachos = new FrmDespachos();
                ObjFrmDespachos.NumComprobante = TdgReservas.Columns["NumComprobante"].Value.ToString();
                ObjFrmDespachos.TipoComprobanteID = Convert.ToInt32(TdgReservas.Columns["TipoComprobanteID"].Value);
                ObjFrmDespachos.ShowDialog();
            }
        }

        private void BtnGuiaTransporte_Click(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            FrmGuiaTransporte ObjFrmGuiaTransporte = new FrmGuiaTransporte();
            ObjFrmGuiaTransporte.DtCabecera = DT;
            ObjFrmGuiaTransporte.DtDetalle = DT;
            ObjFrmGuiaTransporte.ShowDialog();
        }

        private void BtnGuiaRemitente_Click(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            FrmGuiaRemision ObjFrmGuiaRemision = new FrmGuiaRemision();
            ObjFrmGuiaRemision.DtCabecera = DT;
            ObjFrmGuiaRemision.DtDetalle = DT;
            ObjFrmGuiaRemision.ShowDialog();
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            FrmBuscarComprobante ObjFrmBuscarComprobante = new FrmBuscarComprobante();
            ObjFrmBuscarComprobante.DtClientes = DtClientes.Copy();
            ObjFrmBuscarComprobante.ShowDialog();
            if (ObjFrmBuscarComprobante.TipoComprobanteID != 0)
            {
                c1cboCia.SelectedValue = ObjFrmBuscarComprobante.EmpresaID;
                cbComprobante.SelectedValue = ObjFrmBuscarComprobante.TipoComprobanteID;
                TxtNumComprobante.Text = ObjFrmBuscarComprobante.NumComprobante;
                BtnBuscar_Click(null, null);
            }
        }

        private void BtnUltimos_Click(object sender, EventArgs e)
        {
            if (CboMinuto.SelectedIndex != -1 & CboTipoVenta.SelectedIndex != -1)
            {
                DataTable DtUltimosDespachos = new DataTable();
                DtUltimosDespachos = ObjCL_Venta.GetDespachos(AppSettings.SedeID, Convert.ToInt16(CboTipoVenta.SelectedValue), Convert.ToInt16(CboMinuto.SelectedValue));
                TdgDespachos.SetDataBinding(DtUltimosDespachos, "", true);
            }
        }

        private void TdgDespachos_DoubleClick(object sender, EventArgs e)
        {
            if (TdgDespachos.RowCount > 0)
            {
                //obtener los datos y traer automaticamente los datos del despacho
                c1cboCia.SelectedValue = TdgDespachos.Columns["NumComprobante"].Value.ToString().Substring(0, 2);
                cbComprobante.SelectedValue = Convert.ToInt16(TdgDespachos.Columns["TipoComprobanteID"].Value.ToString());
                TxtNumComprobante.Text = TdgDespachos.Columns["NumComprobante"].Value.ToString().Substring(2);
                BtnBuscar_Click(null, null);
            }
        }
     }
}

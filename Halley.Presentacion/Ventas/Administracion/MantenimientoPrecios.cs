using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.Entidad.Ventas;
using Halley.Configuracion;
using Halley.Utilitario;
using Halley.CapaLogica.Empresa;
using Halley.CapaLogica.Ventas;

namespace Halley.Presentacion.Ventas.Administracion
{
    public partial class MantenimientoPrecios : UITemplateAccess
    {
        string ProductoID, TipoTransaccion;
        CL_Producto ObjCL_Producto = new CL_Producto();
        CL_Comprobante ObjCL_Comprobante = new CL_Comprobante();
        CL_Venta ObjCL_Venta = new CL_Venta();
        DataTable DtComprobante = new DataTable();
        DataTable DtserieGuias = new DataTable();
        TextFunctions ObjTextFunctions = new TextFunctions();
        public MantenimientoPrecios()
        {
            InitializeComponent();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            
            try
            {
                ErrProvider.Clear();
                Cursor = Cursors.WaitCursor;
                if (Cboempresa1.SelectedIndex != -1 & ProductoID != "" & TxtNuevoPrecio.Text != "." & TxtNuevoPrecio.Text != "." & TxtNuevoPrecio.Text != "")
                {
                    if (Convert.ToDecimal(TxtNuevoPrecio.Text) > 0)
                    {
                        //obtener nuevo precio
                        E_ListaPrecio ObjE_ListaPrecio = new E_ListaPrecio();
                        ObjE_ListaPrecio.EmpresaID = Cboempresa1.SelectedValue.ToString();
                        ObjE_ListaPrecio.SedeID = AppSettings.SedeID;
                        ObjE_ListaPrecio.ProductoID = ProductoID;
                        ObjE_ListaPrecio.PrecioUnitario = Convert.ToDecimal(TxtNuevoPrecio.Text);
                        ObjE_ListaPrecio.UsuarioID = AppSettings.UserID;
                        ObjCL_Producto.UpdatePrecio(ObjE_ListaPrecio, AppSettings.SedeID);
                        MessageBox.Show("Se actualizo correctamente el precio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarPrecio();
                    }
                    else
                        ErrProvider.SetError(TxtNuevoPrecio, "precio debe ser diferente de cero.");
                }
                else
                {
                    if (Cboempresa1.SelectedIndex == -1) ErrProvider.SetError(Cboempresa1, "Seleccione una empresa.");
                    if (TxtNuevoPrecio.Text == "." | TxtNuevoPrecio.Text == "")
                        ErrProvider.SetError(TxtNuevoPrecio, "Ingrese un precio valido");
                    else if (TxtNuevoPrecio.Text.Length > 0 && Convert.ToDecimal(TxtNuevoPrecio.Text) == 0)
                        ErrProvider.SetError(TxtNuevoPrecio, "precio debe ser diferente de cero.");
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }

        }

        private void MantenimientoPrecios_Load(object sender, EventArgs e)
        {
            //obtener todas las sedes
            DataTable Dtsedes = new CL_Empresas().GetSedes();
            DtComprobante = new CL_Comprobante().getTipoComprobante();
            DataTable Dtempresas = new CL_Empresas().GetEmpresas();
            c1Combo.FillC1Combo(this.Cboempresa1, Dtempresas.Copy(), "NomEmpresa", "EmpresaID");
            c1Combo.FillC1Combo(this.Cboempresa2, Dtempresas.Copy(), "NomEmpresa", "EmpresaID");
            c1Combo.FillC1Combo(this.Cboempresa3, Dtempresas.Copy(), "NomEmpresa", "EmpresaID");
           
            c1Combo.FillC1Combo(this.CboEmpresaE, Dtempresas.Copy(), "NomEmpresa", "EmpresaID");
            c1Combo.FillC1Combo1(cbComprobante, DtComprobante, "NomTipoComprobante", "TipoComprobanteID");
            c1Combo.FillC1Combo1(cbComprobante2, DtComprobante.Copy(), "NomTipoComprobante", "TipoComprobanteID");
            c1Combo.FillC1Combo1(CboComprobante, DtComprobante.Copy(), "NomTipoComprobante", "TipoComprobanteID");
 
            TxtIGV.Text = new CL_Comprobante().getIGV().ToString();
            ocultarToolStrip();
            Validar();
            PnlSerie.Visible = false;
            Permisos();
        }

        private void Permisos()
        {
            DataTable dt = new DataTable();
            dt = AppSettings.AssignedPermission;
            foreach (DataRow row in dt.Rows)
            {

                if (Convert.ToInt64(row["MenuId"]) == 34 && Convert.ToBoolean(row["Actualizacion"]) == false)
                {
                    GbAnular.Visible = false;
                }
                if (Convert.ToInt64(row["MenuId"]) == 34 && Convert.ToBoolean(row["Eliminacion"]) == false)
                {
                    GbEliminar.Visible = false;
                }
            }
        }

        private void Validar()
        {
            //traer la series y als guias
            if (Cboempresa3.SelectedIndex != -1)
                DtserieGuias = ObjCL_Comprobante.GetSerieComprobantes(Cboempresa3.SelectedValue.ToString() + AppSettings.SedeID);//las series
            BtnNuevaSerie.Visible = true;
            BtnCancelarSerie.Visible = false;
            BtnEditarSerie.Visible = true;
            BtnGuardarSerie.Visible = false;
            TxtNumero.ReadOnly = false;
            TxtNumero.Text = "";
            TxtNumero.ReadOnly = true;
            TxtSerieEticketera.ReadOnly = false;
            TxtNroAutorizacion.ReadOnly = false;
            TxtSerieEticketera.Text = "";
            TxtNroAutorizacion.Text = "";
            TxtSerieEticketera.ReadOnly = true;
            TxtNroAutorizacion.ReadOnly = true;
            PnlSerie.Visible = false;
        }

        private void TxtCodigoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrProvider.Clear();
            if (e.KeyChar == (char)(Keys.Enter) & TxtCodigoVenta.Text != "" & Cboempresa1.SelectedIndex != -1)
            {
                DataTable DtProductos = new DataTable();
                DtProductos = ObjCL_Producto.GetProductosPrecio(Cboempresa1.SelectedValue.ToString() + AppSettings.SedeID, TxtCodigoVenta.Text, "C");
                if (DtProductos.Rows.Count == 1)
                {
                    TxtCodigoVenta.Text = DtProductos.Rows[0]["ProductoIDVentas"].ToString();
                    ProductoID = DtProductos.Rows[0]["ProductoID"].ToString();
                    TxtCodigo.Text = DtProductos.Rows[0]["ProductoID"].ToString();
                    TxtProducto.Text = DtProductos.Rows[0]["Alias"].ToString();
                    LblUM.Text = DtProductos.Rows[0]["UnidadMedidaID"].ToString();
                    LblPrecioAnterior.Text = DtProductos.Rows[0]["PrecioUnitario"].ToString();
                    LblPuntoAnterior.Text = DtProductos.Rows[0]["Puntos"].ToString();
                }
                else if (DtProductos.Rows.Count > 1)//mostrarlo en una nueva ventana
                {
                    FrmPreciosBuscados ObjFrmPreciosBuscados = new FrmPreciosBuscados();
                    ObjFrmPreciosBuscados.DtProductos = DtProductos;
                    ObjFrmPreciosBuscados.ShowDialog();
                    TxtCodigoVenta.Text = ObjFrmPreciosBuscados.ProductoIDVentas;
                    ProductoID = ObjFrmPreciosBuscados.ProductoID;
                    TxtCodigo.Text = ObjFrmPreciosBuscados.ProductoID;
                    TxtProducto.Text = ObjFrmPreciosBuscados.Alias;
                    LblUM.Text = ObjFrmPreciosBuscados.UnidadMedidaID;
                    LblPrecioAnterior.Text = ObjFrmPreciosBuscados.PrecioUnitario;
                    LblPuntoAnterior.Text = ObjFrmPreciosBuscados.Puntos;
                }
                else
                {
                    LimpiarPrecio();
                }
            }
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrProvider.Clear();
            if (e.KeyChar == (char)(Keys.Enter) & TxtCodigo.Text != "")
            {
                DataTable DtProductos = new DataTable();
                DtProductos = ObjCL_Producto.GetProductosPrecio(AppSettings.EmpresaID + AppSettings.SedeID, TxtCodigo.Text, "I");
                if (DtProductos.Rows.Count == 1)
                {
                    TxtCodigoVenta.Text = DtProductos.Rows[0]["ProductoIDVentas"].ToString();
                    ProductoID = DtProductos.Rows[0]["ProductoID"].ToString();
                    TxtCodigo.Text = DtProductos.Rows[0]["ProductoID"].ToString();
                    TxtProducto.Text = DtProductos.Rows[0]["Alias"].ToString();
                    LblUM.Text = DtProductos.Rows[0]["UnidadMedidaID"].ToString();
                    LblPrecioAnterior.Text = DtProductos.Rows[0]["PrecioUnitario"].ToString();
                    LblPuntoAnterior.Text = DtProductos.Rows[0]["Puntos"].ToString();
                }
                else if (DtProductos.Rows.Count > 1)//mostrarlo en una nueva ventana
                {
                    FrmPreciosBuscados ObjFrmPreciosBuscados = new FrmPreciosBuscados();
                    ObjFrmPreciosBuscados.DtProductos = DtProductos;
                    ObjFrmPreciosBuscados.ShowDialog();
                    TxtCodigoVenta.Text = ObjFrmPreciosBuscados.ProductoIDVentas;
                    ProductoID = ObjFrmPreciosBuscados.ProductoID;
                    TxtCodigo.Text = ObjFrmPreciosBuscados.ProductoID;
                    TxtProducto.Text = ObjFrmPreciosBuscados.Alias;
                    LblUM.Text = ObjFrmPreciosBuscados.UnidadMedidaID;
                    LblPrecioAnterior.Text = ObjFrmPreciosBuscados.PrecioUnitario;
                    LblPuntoAnterior.Text = ObjFrmPreciosBuscados.Puntos;

                }
                else
                {
                    LimpiarPrecio();
                }
            }
        }

        private void TxtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrProvider.Clear();
            if (e.KeyChar == (char)(Keys.Enter) & TxtProducto.Text != "" & Cboempresa1.SelectedIndex != -1)
            {
                DataTable DtProductos = new DataTable();
                DtProductos = ObjCL_Producto.GetProductosPrecio(Cboempresa1.SelectedValue.ToString() + AppSettings.SedeID, TxtProducto.Text, "A");
                if (DtProductos.Rows.Count == 1)
                {
                    TxtCodigoVenta.Text = DtProductos.Rows[0]["ProductoIDVentas"].ToString();
                    ProductoID = DtProductos.Rows[0]["ProductoID"].ToString();
                    TxtCodigo.Text = DtProductos.Rows[0]["ProductoID"].ToString();
                    TxtProducto.Text = DtProductos.Rows[0]["Alias"].ToString();
                    LblUM.Text = DtProductos.Rows[0]["UnidadMedidaID"].ToString();
                    LblPrecioAnterior.Text = DtProductos.Rows[0]["PrecioUnitario"].ToString();
                    LblPuntoAnterior.Text = DtProductos.Rows[0]["Puntos"].ToString();
                }
                else if (DtProductos.Rows.Count > 1)//mostrarlo en una nueva ventana
                {
                    FrmPreciosBuscados ObjFrmPreciosBuscados = new FrmPreciosBuscados();
                    ObjFrmPreciosBuscados.DtProductos = DtProductos;
                    ObjFrmPreciosBuscados.ShowDialog();
                    TxtCodigoVenta.Text = ObjFrmPreciosBuscados.ProductoIDVentas;
                    ProductoID = ObjFrmPreciosBuscados.ProductoID;
                    TxtCodigo.Text = ObjFrmPreciosBuscados.ProductoID;
                    TxtProducto.Text = ObjFrmPreciosBuscados.Alias;
                    LblUM.Text = ObjFrmPreciosBuscados.UnidadMedidaID;
                    LblPrecioAnterior.Text = ObjFrmPreciosBuscados.PrecioUnitario;
                    LblPuntoAnterior.Text = ObjFrmPreciosBuscados.Puntos;
                }
                else
                {
                    LimpiarPrecio();
                }
            }
        }

        private void LimpiarPrecio()
        {
            TxtCodigoVenta.Text = "";
            TxtCodigo.Text = "";
            TxtProducto.Text = "";
            LblUM.Text = "";
            LblPrecioAnterior.Text = "";
            LblPuntoAnterior.Text = "";
            if (Cboempresa1.SelectedIndex == -1) { ErrProvider.SetError(Cboempresa1, "Debe seleccionar una empresa"); }
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (Cboempresa2.SelectedIndex != -1 & cbComprobante.SelectedValue != null && TxtComprobante.Text != "")
                {
                    if (MessageBox.Show("¿Seguro que desea anular el Comprobante Nro: " + TxtComprobante.Text + "?. Si se anula este comprobante no aparecera en el reporte de ventas del día.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        //if (Convert.ToInt32(cbComprobante.SelectedValue) == 5)
                        //{
                        //    DataTable dt1 = ObjCL_Comprobante.ObtenerDatosFacturdorSunat(Cboempresa2.SelectedValue.ToString());


                        //    ObjCL_Comprobante.GenerarTxtFacturadorSunatComunicacionBaja(Cboempresa2.SelectedValue.ToString(), Cboempresa2.SelectedValue.ToString() + TxtComprobante.Text, TxtMotivoEliminacion.Text, dt1.Rows[0]["RutaArchivosSunat"].ToString());

                        //}
                        
                            ObjCL_Comprobante.AnularComprobante(Cboempresa2.SelectedValue.ToString() + TxtComprobante.Text, Convert.ToInt32(cbComprobante.SelectedValue), AppSettings.UserID, AppSettings.SedeID);
                        
                        
                        MessageBox.Show("Se anulo el comprobante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    if (cbComprobante.SelectedIndex == -1) ErrProvider.SetError(cbComprobante, "Seleccione un tipo de comprobante.");
                    if (TxtComprobante.Text == "") ErrProvider.SetError(TxtComprobante, "ingrese un comprobante.");
                    if (Cboempresa2.SelectedIndex == -1) ErrProvider.SetError(Cboempresa2, "Seleccione una empresa.");
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }

        }

        private void BtnNuevaSerie_Click(object sender, EventArgs e)
        {
            BtnNuevaSerie.Visible = false;
            BtnCancelarSerie.Visible = true;
            BtnEditarSerie.Visible = false;
            BtnGuardarSerie.Visible = true;
            PnlSerie.Visible = true;
            TxtNumero.ReadOnly = false;
            TxtSerieEticketera.ReadOnly = false;
            TxtNroAutorizacion.ReadOnly = false;
            TipoTransaccion = "G";
            cbComprobante.SelectedIndex = -1;
        }

        private void BtnEditarSerie_Click(object sender, EventArgs e)
        {
            BtnNuevaSerie.Visible = false;
            BtnCancelarSerie.Visible = true;
            BtnEditarSerie.Visible = false;
            BtnGuardarSerie.Visible = true;
            TxtNumero.ReadOnly = false;
            TxtSerieEticketera.ReadOnly = false;
            TxtNroAutorizacion.ReadOnly = false;
            PnlSerie.Visible = false;
            TipoTransaccion = "E";
        }

        private void BtnCancelarSerie_Click(object sender, EventArgs e)
        {
            BtnNuevaSerie.Visible = true;
            BtnCancelarSerie.Visible = false;
            BtnEditarSerie.Visible = true;
            BtnGuardarSerie.Visible = false;
            TxtNumero.ReadOnly = true;
            TxtSerieEticketera.ReadOnly = true;
            TxtNroAutorizacion.ReadOnly = true;
            PnlSerie.Visible = false;
        }

        private void BtnGuardarSerie_Click(object sender, EventArgs e)
        {
            try
            {
                ErrProvider.Clear();
                Cursor = Cursors.WaitCursor;
                BtnNuevaSerie.Visible = true;
                BtnCancelarSerie.Visible = false;
                BtnEditarSerie.Visible = true;
                BtnGuardarSerie.Visible = false;
                TxtNumero.ReadOnly = true;
                TxtSerieEticketera.ReadOnly = true;
                TxtNroAutorizacion.ReadOnly = true;

                if (cbComprobante2.SelectedValue != null & TxtSerie.Text != "" & TxtNumero.Text != "" & TipoTransaccion == "G")
                {
                    ObjCL_Comprobante.InsertSerieGuia(Cboempresa3.SelectedValue.ToString() + AppSettings.SedeID, Convert.ToInt16(cbComprobante2.SelectedValue), TxtSerie.Text, Convert.ToInt32(TxtNumero.Text), AppSettings.UserID, TxtNroAutorizacion.Text, TxtSerieEticketera.Text);
                    MessageBox.Show("Se agrego correctamente la serie.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Validar();
                    Cursor = Cursors.Default;
                }
                else if (cbComprobante2.SelectedValue != null & CboSerieGuias.SelectedIndex != -1 & TxtNumero.Text != "" & TipoTransaccion == "E")
                {
                    ObjCL_Comprobante.UpdateSerieComprobante(Cboempresa3.SelectedValue.ToString() + AppSettings.SedeID, Convert.ToInt16(cbComprobante2.SelectedValue), CboSerieGuias.SelectedText, Convert.ToInt32(TxtNumero.Text), AppSettings.UserID, TxtNroAutorizacion.Text, TxtSerieEticketera.Text);
                    MessageBox.Show("Se actualizo correctamente la serie.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Validar();
                    Cursor = Cursors.Default;
                }
                else
                {
                    if (Cboempresa3.SelectedIndex == -1) ErrProvider.SetError(Cboempresa3, "Seleccione una empresa.");
                    if (TipoTransaccion == "G")
                        if (TxtSerie.Text == "") ErrProvider.SetError(TxtSerie, "Ingrese una serie valida.");
                        else if (TipoTransaccion == "E")
                            if (CboSerieGuias.SelectedIndex == -1) ErrProvider.SetError(CboSerieGuias, "Seleccione una serie de la guia.");
                    if (TxtNumero.Text == "") ErrProvider.SetError(TxtNumero, "Ingrese un numero valido");
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnNuevaSerie.Visible = false;
                BtnCancelarSerie.Visible = true;
                BtnEditarSerie.Visible = true;
                BtnGuardarSerie.Visible = true;
                TxtNumero.ReadOnly = false;
                TxtSerieEticketera.ReadOnly = false;
                TxtNroAutorizacion.ReadOnly = false;
                Cursor = Cursors.Default;
                ErrProvider.Clear();
            }
        }

        private void cbComprobante2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbComprobante2.SelectedIndex != -1 & DtserieGuias.Rows.Count > 0)
            {
                DataView Dv = new DataView(DtserieGuias);
                Dv.RowFilter = "TipoDocumento = '" + cbComprobante2.SelectedValue + "'";
                CboSerieGuias.HoldFields();
                CboSerieGuias.DataSource = Dv.ToTable();
                CboSerieGuias.DisplayMember = "Serie";
                CboSerieGuias.ValueMember = "Serie";
                //c1Combo.FillC1Combo1(CboSerieGuias, Dv.ToTable(), "", "Serie");
            }
        }



        private void CboSerieGuias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                TxtNroAutorizacion.ReadOnly = false;
                TxtSerieEticketera.ReadOnly = false;
                TxtNroAutorizacion.Text = CboSerieGuias.Columns["NroAutorizacion"].Value.ToString();
                TxtSerieEticketera.Text = CboSerieGuias.Columns["SerieEticketera"].Value.ToString();
            }
        }

        private void Cboempresa3_SelectedValueChanged(object sender, EventArgs e)
        {
            //traer la series y als guias
            DtserieGuias = ObjCL_Comprobante.GetSerieComprobantes(Cboempresa3.SelectedValue.ToString() + AppSettings.SedeID);//las series
            //c1Combo.FillC1Combo1(CboSerieGuias, DtserieGuias, "Serie", "Serie");
        }

        

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            if (TxtSerieE.Text == "" | TxtSerieE.TextLength != 3) { ErrProvider.SetError(TxtSerieE, "Ingrese una serie válida"); return; }
            if (CboComprobante.SelectedIndex == -1) { ErrProvider.SetError(CboComprobante, "Seleccione un tipo de comprobante"); return; }
            if (CboEmpresaE.SelectedIndex == -1) { ErrProvider.SetError(CboEmpresaE, "Seleccione una empresa"); return; }
            if (TxtNumIni.Text == "" | TxtNumFin.Text == "") { ErrProvider.SetError(TxtNumIni, "El número inicial y el final deben ser válidos."); return; }
            if (Convert.ToInt32(TxtNumIni.Text) > Convert.ToInt32(TxtNumFin.Text)) { ErrProvider.SetError(TxtNumIni, "El número inicial no puede ser mayor al  número final."); return; }

            if (MessageBox.Show("¿Seguro que desea eliminar estos comprobantes?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new CL_Comprobante().ELIMINAR_COMPROBANTES(CboEmpresaE.SelectedValue.ToString(), TxtSerieE.Text, Convert.ToInt32(TxtNumIni.Text), Convert.ToInt32(TxtNumFin.Text), AppSettings.UserID, Convert.ToInt16(CboComprobante.SelectedValue));
                MessageBox.Show("Se elimino los comprobantes", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void TxtNumIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.SoloNumero(sender, e, TxtNumIni);
        }

        private void TxtNumFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.SoloNumero(sender, e, TxtNumFin);
        }

    
        private void BtnNotaCredito_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (Cboempresa2.SelectedIndex != -1 & cbComprobante.SelectedValue != null && TxtComprobante.Text != "")
                {
                    if (MessageBox.Show("¿Seguro que desea Generar la nota de crédito con el Comprobante Nro: " + TxtComprobante.Text + "?.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string valor = ObjCL_Comprobante.GenerarSunat(Convert.ToInt32(cbComprobante.SelectedValue), Cboempresa2.SelectedValue.ToString() + TxtComprobante.Text, Cboempresa2.SelectedValue.ToString(), "07", "01", TxtMotivoEliminacion.Text);
                        if (valor != "OK")
                            MessageBox.Show(valor, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Se anulo el comprobante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    if (cbComprobante.SelectedIndex == -1) ErrProvider.SetError(cbComprobante, "Seleccione un tipo de comprobante.");
                    if (TxtComprobante.Text == "") ErrProvider.SetError(TxtComprobante, "ingrese un comprobante.");
                    if (Cboempresa2.SelectedIndex == -1) ErrProvider.SetError(Cboempresa2, "Seleccione una empresa.");
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }

        private void BtnModificarIGV_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            if (TxtIGV.Text != "")
            {
                new CL_Comprobante().InsertarIGV(Convert.ToInt16(TxtIGV.Text), AppSettings.UserID);
                MessageBox.Show("Se modificó correctamente el GV", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ErrProvider.SetError(TxtIGV, "Ingrese un Monto válido");
            }

        }

        private void TxtIGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.SoloNumero(sender, e, TxtIGV);
        }

        private void BtnActualizarClientesSunat_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.DefaultExt = "txt";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    ObjCL_Venta.InsertarClientesSunat(openFileDialog1.FileName);
                    Cursor = Cursors.Default;
                    MessageBox.Show("Se migro correctamente los clientes", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void BtnActualizarPuntos_Click(object sender, EventArgs e)
        {

            try
            {
                ErrProvider.Clear();
                Cursor = Cursors.WaitCursor;
                if (Cboempresa1.SelectedIndex != -1 & ProductoID != "" & TxtNuevosPuntos.Text != "." & TxtNuevosPuntos.Text != "." & TxtNuevosPuntos.Text != "")
                {
                    if (Convert.ToInt32(TxtNuevosPuntos.Text) > 0)
                    {
                        //obtener nuevo precio
                        E_ListaPrecio ObjE_ListaPrecio = new E_ListaPrecio();
                        ObjE_ListaPrecio.EmpresaID = Cboempresa1.SelectedValue.ToString();
                        ObjE_ListaPrecio.SedeID = AppSettings.SedeID;
                        ObjE_ListaPrecio.ProductoID = ProductoID;
                        ObjE_ListaPrecio.Puntos = Convert.ToInt32(TxtNuevosPuntos.Text);
                        ObjE_ListaPrecio.UsuarioID = AppSettings.UserID;
                        ObjCL_Producto.UpdatePuntos(ObjE_ListaPrecio);
                        MessageBox.Show("Se actualizo correctamente los puntos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarPrecio();
                    }
                    else
                        ErrProvider.SetError(TxtNuevosPuntos, "puntos debe ser diferente de cero.");
                }
                else
                {
                    if (Cboempresa1.SelectedIndex == -1) ErrProvider.SetError(Cboempresa1, "Seleccione una empresa.");
                    if (TxtNuevosPuntos.Text == "." | TxtNuevosPuntos.Text == "")
                        ErrProvider.SetError(TxtNuevosPuntos, "Ingrese un punto válido");
                    else if (TxtNuevosPuntos.Text.Length > 0 && Convert.ToInt32(TxtNuevosPuntos.Text) == 0)
                        ErrProvider.SetError(TxtNuevosPuntos, "puntos debe ser diferente de cero.");
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }





    }
}

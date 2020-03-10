using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.VentasTemp;
using Halley.Configuracion;

namespace Halley.Presentacion.VentasTemp
{
    public partial class MantenimientoPrecios : UITemplateAccess
    {
        CL_VentasTemp ObjCL_VentasTemp = new CL_VentasTemp();
        DataTable DtTipoDocumento = new DataTable();
        DataTable DtProductos = new DataTable();
        DataTable DtserieGuias = new DataTable();
        string TipoTransaccion = "";

        public MantenimientoPrecios()
        {
            InitializeComponent();
        }

        private void MantenimientoPrecios_Load(object sender, EventArgs e)
        {
            //traer los tipo de documento
            DtTipoDocumento = ObjCL_VentasTemp.GetTipoDocumento();

            CboTipoComprobante.HoldFields();
            CboTipoComprobante.DataSource = DtTipoDocumento;
            CboTipoComprobante.DisplayMember = "NomDocumento";
            CboTipoComprobante.ValueMember = "TipoDocumento";
            
            CboTipoComprobante2.HoldFields();
            CboTipoComprobante2.DataSource = DtTipoDocumento;
            CboTipoComprobante2.DisplayMember = "NomDocumento";
            CboTipoComprobante2.ValueMember = "TipoDocumento";

            //traer la series y als guias
            DtserieGuias = ObjCL_VentasTemp.GetSerieGuias(AppSettings.EmpresaID + AppSettings.SedeID);//las series

            //traer los productos
            DtProductos = ObjCL_VentasTemp.GetProductos();
            CboProductos.HoldFields();
            CboProductos.DataSource = DtProductos;
            CboProductos.DisplayMember = "Articulo";
            CboProductos.ValueMember = "ArticuloId";

            CboProductosCodigo.HoldFields();
            CboProductosCodigo.DataSource = DtProductos;
            CboProductosCodigo.DisplayMember = "Codigo";
            CboProductosCodigo.ValueMember = "ArticuloId";


        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (CboTipoComprobante.SelectedValue != null && TxtComprobante.Text != "")
            {
                if (MessageBox.Show("¿Seguro que desea anular el Comprobante Nro: " + TxtComprobante.Text + "?. Si se anula este comprobante no aparecera en el reporte de ventas del día.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    ObjCL_VentasTemp.AnularGuia(AppSettings.EmpresaID + TxtComprobante.Text, Convert.ToInt16(CboTipoComprobante.SelectedValue));
                    MessageBox.Show("Se anulo el comprobante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CboProductos_SelectedValueChanged(object sender, EventArgs e)
        {
            TxtPrecio.Value = CboProductos.Columns["Precio"].Value;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (CboProductos.SelectedValue != null && TxtPrecio.Text != "")
            {
                ObjCL_VentasTemp.UpdatePrecioProducto(Convert.ToInt32(CboProductos.SelectedValue),Convert.ToDecimal(TxtPrecio.Text));
                MessageBox.Show("Se actualizo con el nuevo precio: S/. " + TxtPrecio.Text + ".", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPrecio.ReadOnly = true;
                BtnEditar.Visible = true;
                BtnGuardar.Visible = false;
                BtnCancelar.Visible = false;
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            TxtPrecio.ReadOnly = false;
            BtnEditar.Visible = false;
            BtnGuardar.Visible = true;
            BtnCancelar.Visible = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TxtPrecio.ReadOnly = true;
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
            BtnCancelar.Visible = false;
        }



        private void BtnCancelarComprobante_Click(object sender, EventArgs e)
        {
            BtnNuevaSerie.Visible = true;
            BtnCancelarSerie.Visible = false;
            BtnEditarSerie.Visible = true;
            BtnGuardarSerie.Visible = false;
            TxtNumero.ReadOnly = true;
        }

        private void BtnEditarSerie_Click(object sender, EventArgs e)
        {
            BtnNuevaSerie.Visible = false;
            BtnCancelarSerie.Visible = true;
            BtnEditarSerie.Visible = false;
            BtnGuardarSerie.Visible = true;
            TxtNumero.ReadOnly = false;

            TipoTransaccion = "E";
        }

        private void BtnNuevaSerie_Click(object sender, EventArgs e)
        {
            BtnNuevaSerie.Visible = false;
            BtnCancelarSerie.Visible = true;
            BtnEditarSerie.Visible = false;
            BtnGuardarSerie.Visible = true;


            TipoTransaccion = "G";
            CboTipoComprobante2.SelectedIndex = -1;
        }

        private void BtnCancelarSerie_Click(object sender, EventArgs e)
        {
            BtnNuevaSerie.Visible = true;
            BtnCancelarSerie.Visible = false;
            BtnEditarSerie.Visible = true;
            BtnGuardarSerie.Visible = false;
            TxtNumero.ReadOnly = true;
        }

        private void BtnGuardarSerie_Click(object sender, EventArgs e)
        {
            try
            {
                BtnNuevaSerie.Visible = true;
                BtnCancelarSerie.Visible = false;
                BtnEditarSerie.Visible = true;
                BtnGuardarSerie.Visible = false;
                TxtNumero.ReadOnly = true;

                if (CboTipoComprobante2.SelectedValue != null & CboSerieGuias.Text != "" & TxtNumero.Text != "" & TipoTransaccion == "G")
                {
                    ObjCL_VentasTemp.InsertSerieGuia(AppSettings.EmpresaID + AppSettings.SedeID, Convert.ToInt16(CboTipoComprobante2.SelectedValue), CboSerieGuias.Text, Convert.ToInt32(TxtNumero.Text), AppSettings.UserID);
                    MessageBox.Show("Se agrego correctamente la serie.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MantenimientoPrecios_Load(null, null);
                }
                else if (CboTipoComprobante2.SelectedValue != null & CboSerieGuias.SelectedValue != null & TxtNumero.Text != "" & TipoTransaccion == "E")
                {
                    ObjCL_VentasTemp.UpdateSerieGuia(AppSettings.EmpresaID + AppSettings.SedeID, Convert.ToInt16(CboTipoComprobante2.SelectedValue), CboSerieGuias.SelectedText, Convert.ToInt32(TxtNumero.Text), AppSettings.UserID);
                    MessageBox.Show("Se actualizo correctamente la serie.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MantenimientoPrecios_Load(null, null);
                }
                else
                    MessageBox.Show("Debe seleccionar el tipo de comprobante, numero de serie e ingresar el numero del comprobante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnNuevaSerie.Visible = false;
                BtnCancelarSerie.Visible = true;
                BtnEditarSerie.Visible = true;
                BtnGuardarSerie.Visible = true;
                TxtNumero.ReadOnly = false;
            }
        }

        private void CboTipoComprobante2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboTipoComprobante2.SelectedIndex != -1 & CboTipoComprobante2.SelectedValue != null)
            {
                DataView Dv = new DataView(DtserieGuias);
                Dv.RowFilter = "TipoDocumento = '" + CboTipoComprobante2.SelectedValue + "'";
                CboSerieGuias.HoldFields();
                CboSerieGuias.DataSource = Dv;
                CboSerieGuias.DisplayMember = "Serie";
                CboSerieGuias.ValueMember = "Serie";
            }
        }

        private void CboSerieGuias_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboSerieGuias.SelectedIndex != -1)
            {
                TxtNumero.ReadOnly = false;
                TxtNumero.Text = CboSerieGuias.Columns["Numero"].Value.ToString();
                TxtNumero.ReadOnly = true;
            }
        }


    }
}

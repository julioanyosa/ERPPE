using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Configuracion;
using Halley.CapaLogica.Almacen;
using Halley.CapaLogica.Ventas;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas
{
    public partial class FrmVentasDiferidas :UITemplateAccess
    {

        #region Declaracion de variables

        DataTable dtProducto;
        DataTable dtDocumento;
        DataTable dtEntidad;

        string NomProducto;
        string Marca;
        string Almacen;

        string Tipo_Comprobante;

        #endregion

        #region Constructor

        public FrmVentasDiferidas()
        {
            InitializeComponent();
            ocultarToolStrip();

            GetProducto();
            c1Combo.FillC1Combo(cbDocumento, GetDocumento(), "Numero", "Tipo");
            c1Combo.FillC1Combo(cbEntidad, GetEntidad(), "Numero", "Tipo");
        }

        #endregion

        #region Metodo definidos

        public void GetProducto()
        {
            dtProducto = new DataTable();
            dtProducto = new CL_Producto().ObtenerProductos(AppSettings.SedeID);

            if (dtProducto.Rows.Count == 0)
            {               
                this.C1TdbConsulta.SetDataBinding(null, "", true);
                return;
            }

            C1TdbConsulta.SetDataBinding(dtProducto, "", true);
        }

        public DataTable GetDocumento()
        {

            dtDocumento = new DataTable();
            dtDocumento.Columns.Add("Tipo", typeof(string));
            dtDocumento.Columns.Add("Numero", typeof(string));

            DataRow ROW;
            ROW = dtDocumento.NewRow();
            ROW["Tipo"] = "B";
            ROW["Numero"] = "BOLETA";
            dtDocumento.Rows.Add(ROW);

            DataRow _ROW;
            _ROW = dtDocumento.NewRow();
            _ROW["Tipo"] = "F";
            _ROW["Numero"] = "FACTURA";
            dtDocumento.Rows.Add(_ROW);

            return dtDocumento;
           
        }

        public DataTable GetEntidad()
        {

            dtEntidad = new DataTable();
            dtEntidad.Columns.Add("Tipo", typeof(string));
            dtEntidad.Columns.Add("Numero", typeof(string));

            DataRow ROW;
            ROW = dtEntidad.NewRow();
            ROW["Tipo"] = "R";
            ROW["Numero"] = "RUC";
            dtEntidad.Rows.Add(ROW);

            DataRow _ROW;
            _ROW = dtEntidad.NewRow();
            _ROW["Tipo"] = "D";
            _ROW["Numero"] = "DNI";
            dtEntidad.Rows.Add(_ROW);

            return dtEntidad;

        }


        public void CrearVenta()
        {
            DataView dv = new DataView(dtProducto);
            dv.RowFilter = "NomProducto = '" + NomProducto + "' And NomMarca = '" + Marca + "' And AlmacenID = '" + Almacen + "'";

            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Realize un filtro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtCantidad.Text == "")
            {
                MessageBox.Show("Ingrese la cantidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Select();
                return;
            }

            decimal Cantidad = Convert.ToDecimal(txtCantidad.Text);

            if (dv.Count != 0)
            {
                new CL_Venta().InsertVenta(dv[0]["AlmacenID"].ToString(), dv[0]["ProductoID"].ToString(), Cantidad, 1, AppSettings.UserID);
                MessageBox.Show("venta generada correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCantidad.Text = "";
                txtDescripcion.Text = "";
                txtMarca.Text = "";
            }
        }

        #endregion

        #region Eventos de los controles

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CrearVenta();
        }

        private void btnVentaDiferida_Click(object sender, EventArgs e)
        {

            try
            {
                DataView dv = new DataView(dtProducto);
                dv.RowFilter = "NomProducto = '" + NomProducto + "' And NomMarca = '" + Marca + "' And AlmacenID = '" + Almacen + "'";

                if (txtDescripcion.Text == "")
                {
                    MessageBox.Show("Realize un filtro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Ingrese la cantidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidad.Select();
                    return;
                }

                decimal Cantidad = Convert.ToDecimal(txtCantidad.Text);
                if (dv.Count != 0)
                {
                    if (txtDocumento.Text == "")
                    {
                        MessageBox.Show("Ingrese la " + cbDocumento.SelectedText.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtDocumento.Select();
                        return;
                    }
                    else if (txtCliente.Text == "")
                    {
                        MessageBox.Show("Ingrese el cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCliente.Select();
                        return;
                    }
                    else if (this.txtNroEntidad.Text == "")
                    {
                        MessageBox.Show("Ingrese el " + cbEntidad.SelectedText.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCliente.Select();
                        return;
                    }

                    Tipo_Comprobante = cbDocumento.SelectedValue.ToString();

                    new CL_Venta().InsertVentaDiferida(dv[0]["ProductoID"].ToString(), Cantidad, Tipo_Comprobante, Tipo_Comprobante + txtDocumento.Text, txtCliente.Text, cbEntidad.SelectedValue.ToString(), txtNroEntidad.Text, AppSettings.EmpresaID, AppSettings.NomSede, AppSettings.UserID);
                    MessageBox.Show("venta generada correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCantidad.Text = "";
                    txtDescripcion.Text = "";
                    txtMarca.Text = "";
                    //txtCliente.Text = "";
                    //txtDocumento.Text = "";
                    //txtNroEntidad.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDescripcion.Text.Length > 0)
                {
                    C1TdbConsulta.Visible = true;
                    DataView dv = new DataView(dtProducto);
                    dv.RowFilter = "NomProducto LIKE '" + txtDescripcion.Text + "%'";
                    this.C1TdbConsulta.SetDataBinding(dv, "", true);
                }
                else
                    C1TdbConsulta.Visible = false;
            }
            catch (Exception)
            {
               // MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void C1TdbConsulta_DoubleClick(object sender, EventArgs e)
        {
            NomProducto = this.C1TdbConsulta.Columns["NomProducto"].Value.ToString();
            Marca = this.C1TdbConsulta.Columns["NomMarca"].Value.ToString();
            Almacen = this.C1TdbConsulta.Columns["AlmacenID"].Value.ToString();

            txtDescripcion.Text = NomProducto.ToString();
            txtMarca.Text = Marca.ToString();
            txtCantidad.Select();
            C1TdbConsulta.Visible = false;            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
             new TextFunctions().ValidaNumero(sender, e, txtCantidad);
        }

        private void txtNroEntidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            new TextFunctions().SoloNumero(sender, e, txtNroEntidad);
        }


        #endregion       

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;

namespace Halley.Presentacion.Ventas
{
    public partial class FrmNotaCredito : Form
    {

        DataSet DsComprobante = new DataSet();
        CL_Venta ObjCL_Venta = new CL_Venta();
        string NumComprobante,EmpresaID;
        int TipoComprobanteID, ClienteID;




        public FrmNotaCredito()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    //traer detalles de las guias
                    if (TxtNumComprobante.Text != "" && cbComprobante.SelectedIndex != -1 & c1cboCia.SelectedIndex != -1)
                    {
                        DsComprobante = ObjCL_Venta.GetComprobante(c1cboCia.SelectedValue.ToString() + TxtNumComprobante.Text, Convert.ToInt32(cbComprobante.SelectedValue));
                        if (DsComprobante.Tables["Comprobante"].Rows.Count > 0)
                        {
                            NumComprobante = DsComprobante.Tables["NumComprobante"].Rows[0]["RazonSocial"].ToString();
                            TipoComprobanteID = Convert.ToInt32(DsComprobante.Tables["NumComprobante"].Rows[0]["TipoComprobanteID"]);
                            EmpresaID = DsComprobante.Tables["NumComprobante"].Rows[0]["EmpresaID"].ToString();
                            ClienteID = Convert.ToInt32(DsComprobante.Tables["NumComprobante"].Rows[0]["ClienteID"]);
                            txtCliente.Text = DsComprobante.Tables["Comprobante"].Rows[0]["RazonSocial"].ToString();
                            lblDocumento.Text = DsComprobante.Tables["Comprobante"].Rows[0]["NroDocumento"].ToString();
                            LblTipoDocumento.Text = DsComprobante.Tables["Comprobante"].Rows[0]["TipoDocumento"].ToString();
                            LblAudCrea.Text = DsComprobante.Tables["Comprobante"].Rows[0]["AudCrea"].ToString();
                            lblDireccion.Text = DsComprobante.Tables["Comprobante"].Rows[0]["Direccion"].ToString();
                            LblVendedor.Text = DsComprobante.Tables["Comprobante"].Rows[0]["NomVendedor"].ToString();

                            DsComprobante.Tables["DetalleComprobante"].Columns["Descontar"].ReadOnly = false;
                            TdgDetalleComprobante.SetDataBinding(DsComprobante.Tables["DetalleComprobante"], "", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {

        }
    }
}

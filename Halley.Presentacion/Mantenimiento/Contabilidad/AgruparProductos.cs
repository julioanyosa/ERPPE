using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;

namespace Halley.Presentacion.Mantenimiento.Contabilidad
{
    public partial class AgruparProductos : UITemplateAccess
    {
        DataTable DtProductosNoPrincipales = new DataTable();
        DataTable DtProductosPrincipales = new DataTable();
        DataTable DtDerivados = new DataTable();
        CL_Producto ObjClProducto = new CL_Producto();
        public AgruparProductos()
        {
            InitializeComponent();
        }

        private void AgruparProductos_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            //obtener lista de productos
            DtProductosNoPrincipales = ObjClProducto.GetProductosPrincipales(false);
            tdgProductosBuscados.SetDataBinding(DtProductosNoPrincipales, "", true);

            DtProductosPrincipales = ObjClProducto.GetProductosPrincipales(true);
            LstProductosPrincipales.HoldFields();
            LstProductosPrincipales.DataSource = DtProductosPrincipales;
            LstProductosPrincipales.DisplayMember = "Alias";
            LstProductosPrincipales.ValueMember = "ProductoID";
        }

        private void LstProductosPrincipales_SelectedValueChanged(object sender, EventArgs e)
        {
            TraerDerivados();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //agregar como derivado y refrescar sus derivados del principal
                if (LstProductosPrincipales.SelectedIndex != -1)
                {
                    Int16 MarcaID = 0, MarcaIDPrincipal = 0;
                    MarcaID = Convert.ToInt16(tdgProductosBuscados.Columns["MarcaID"].Value);
                    MarcaIDPrincipal = Convert.ToInt16(LstProductosPrincipales.Columns["MarcaID"].Value);
                    //if (MarcaID == MarcaIDPrincipal)
                    //{
                        ObjClProducto.UpdateDerivado(tdgProductosBuscados.Columns["ProductoID"].Value.ToString(), LstProductosPrincipales.SelectedValue.ToString());
                        TraerDerivados();
                        MessageBox.Show("Se agrego correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                        //MessageBox.Show("El producto derivado debe ser de la misma marca", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TraerDerivados()
        {
            if (LstProductosPrincipales.SelectedIndex != -1)
            {
                //obtener los derivados de ese producto
                DtDerivados = ObjClProducto.GetProductosDerivados(LstProductosPrincipales.SelectedValue.ToString());
                LstDerivados.HoldFields();
                LstDerivados.DataSource = DtDerivados;
                LstDerivados.DisplayMember = "Alias";
                LstDerivados.ValueMember = "ProductoID";
            }
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            AgruparProductos_Load(null, null);
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            //filtrar los productos y mostrarlos en la lista
            //DataView DV = new DataView(DtProductosPrincipales, "Alias like '%" + TxtFiltro.Text + "%'", "Alias ASC", DataViewRowState.CurrentRows);
            DataView DV = new DataView();
            DV = DtProductosPrincipales.DefaultView;
            DV.RowFilter = "Alias like '%" + TxtFiltro.Text + "%'";
            DV.Sort = "Alias";
            tdgProductosBuscados.SetDataBinding(DtProductosNoPrincipales, "", true);
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;
using Halley.Utilitario;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class Transformacion : UITemplateAccess
    {
        DataTable DtProductos;
        DataTable DtProductosGenerico;
        DataTable DtProductosAgregar;
        DataTable DtDerivados;
        CL_Almacen ObjCL_Almacen = new CL_Almacen();
        private TextFunctions ObjTextFunctions = new TextFunctions();
        string Producto = "";

        public Transformacion()
        {
            InitializeComponent();
        }

        private void Transformacion_Load(object sender, EventArgs e)
        {
            //obtener lista de productos

            DtProductos =  new CL_Producto().GetProductosPrincipales(true);
            LstProductosPrincipales.HoldFields();
            LstProductosPrincipales.DataSource = DtProductos;
            LstProductosPrincipales.DisplayMember = "Alias";
            LstProductosPrincipales.ValueMember = "ProductoID";

            //crear tabla para despues agregar
            DtProductosAgregar = new DataTable();
            DtProductosAgregar.Columns.Add("ProductoID", typeof(string));
            DtProductosAgregar.Columns.Add("NomProducto", typeof(string));
            DtProductosAgregar.Columns.Add("Cantidad", typeof(decimal)).DefaultValue = 0;
            DtProductosAgregar.Columns.Add("Almacen", typeof(string));
            TdgProductosAgregar.SetDataBinding(DtProductosAgregar, "", true);

        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (LstDerivados.SelectedIndex != -1)
            {
                //verificar que no se repita el producto en la grilla
                DataView Dv = new DataView(DtProductosAgregar);
                Dv.RowFilter = "ProductoID = '" + LstDerivados.SelectedValue.ToString() + "'";

                if (Dv.Count == 0)
                {
                    DataRow DR = DtProductosAgregar.NewRow();
                    DR["ProductoID"] = LstDerivados.SelectedValue.ToString();
                    DR["NomProducto"] = LstDerivados.Columns["Alias"].Value.ToString();
                    DR["Almacen"] = LstDerivados.Columns["Almacen"].Value.ToString();
                    DtProductosAgregar.Rows.Add(DR);
                }
                //DtProductosAgregar.DefaultView;
            }
            else
                MessageBox.Show("No ha seleccionado ningun Producto derivado.","Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnTransformar_Click(object sender, EventArgs e)
        {
            try 
	        {
                ErrProvider.Clear();
		        bool Valor = true;
                Valor = HayCero();
                decimal Cantidad = 0;
                if(TxtCantidad.Text != "")
                    Cantidad = Convert.ToDecimal(TxtCantidad.Text);


                if (LstProductosPrincipales.SelectedIndex != -1 & TdgProductosAgregar.RowCount > 0 & Valor == false & Cantidad > 0)
                {
                    ObjCL_Almacen.Transformar(DtProductosAgregar, AppSettings.EmpresaID + AppSettings.SedeID + LstProductosPrincipales.Columns["Almacen"].Value.ToString(), LstProductosPrincipales.SelectedValue.ToString(), Cantidad, AppSettings.UserID);
                    MessageBox.Show("Se transformo el producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DtProductosAgregar.Clear();
                    LstProductosPrincipales.SelectedIndex = -1;
                    LstDerivados.SelectedIndex = -1;
                }
                else
                {
                    if (LstProductosPrincipales.SelectedIndex == -1) { ErrProvider.SetError(LstProductosPrincipales, "Debe seleccionar el producto principal a transformar."); }
                    if (TdgProductosAgregar.RowCount < 1) { ErrProvider.SetError(TdgProductosAgregar, "Debe haber agregado productos derivados."); }
                    if (TxtCantidad.Text == "") { ErrProvider.SetError(TxtCantidad, "Debe Ingresar la cantidad que vaa ser transformada."); }
                    if (Valor == true) { MessageBox.Show("Hay cantidad '0' en el producto: " + Producto + ".", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.Message + ". \r\n\r\nTransformar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
	        }

        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtCantidad);
        }

        private bool HayCero()
        {
            bool Valor = true;
            //validar que el peso no sea iguala 0
            foreach (DataRow Row in DtProductosAgregar.Rows)
            {

                if (Convert.ToDecimal(Row["cantidad"]) == 0)
                {
                    
                    Producto = Row["NomProducto"].ToString();
                    Valor = true;
                    break;
                }
                else
                    Valor = false;
            }
            return Valor;
        }

        private void LstProductosPrincipales_SelectedValueChanged(object sender, EventArgs e)
        {
            TraerDerivados();
        }

        private void TraerDerivados()
        {
            if (LstProductosPrincipales.SelectedIndex != -1)
            {
                //obtener los derivados de ese producto
                DtDerivados = new CL_Producto().GetProductosDerivados(LstProductosPrincipales.SelectedValue.ToString());
                LstDerivados.HoldFields();
                LstDerivados.DataSource = DtDerivados;
                LstDerivados.DisplayMember = "Alias";
                LstDerivados.ValueMember = "ProductoID";
            }
        }

    }
}

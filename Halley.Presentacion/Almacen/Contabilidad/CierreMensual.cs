using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Empresa;
using Halley.Utilitario;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;

namespace Halley.Presentacion.Almacen.Contabilidad
{
    public partial class CierreMensual : UITemplateAccess
    {
        TextFunctions ObjTextFunctions = new TextFunctions();
        public CierreMensual()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                string Mensaje ="";
                if(RbProducto.Checked ==true)
                    Mensaje = "¿Seguro que desea cerrar el kardex correspondiente"
                    + "\nEmpresa: " + c1cboCia.Columns["NomEmpresa"].Value.ToString()
                    + "\nal periodo " + CboPeriodo.Columns["Descripcion"].Value.ToString()
                    + "\naño " + CboAnno.Columns["Anno"].Value.ToString()
                    + "\nProductos: " + CboProducto.Columns["Alias"].Value.ToString() + "?";
                else if(RbAlmacen.Checked ==true)
                    Mensaje = "¿Seguro que desea cerrar el kardex correspondiente"
                    + "\nEmpresa: " + c1cboCia.Columns["NomEmpresa"].Value.ToString()
                    + "\nal periodo " + CboPeriodo.Columns["Descripcion"].Value.ToString()
                    + "\naño " + CboAnno.Columns["Anno"].Value.ToString()
                    + "\nAlmacenes: " + CboAlmacenHalley.Columns["Descripcion"].Value.ToString() + "?";

                if (MessageBox.Show(Mensaje, "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int totalAfectados = 0;

                    if (RbProducto.Checked == true)
                    {
                        if (RbConCosto.Checked == true)
                        {
                            totalAfectados = new CL_Kardex().InsertCierreKardex(1,AppSettings.UserID, "",CboProducto.SelectedValue.ToString(), c1cboCia.SelectedValue.ToString(), CboPeriodo.SelectedValue.ToString(), Convert.ToInt32(CboAnno.SelectedValue), false,0,0);
                        }
                        else if (RBCostoCero.Checked == true)
                        {
                            totalAfectados = new CL_Kardex().InsertCierreKardex(1,AppSettings.UserID, "", CboProducto.SelectedValue.ToString(), c1cboCia.SelectedValue.ToString(), CboPeriodo.SelectedValue.ToString(), Convert.ToInt32(CboAnno.SelectedValue), true,0,0);
                        }
                    }
                    else if (RbAlmacen.Checked == true)
                    {
                        if (RbConCosto.Checked == true)
                        {
                            DateTime FecInicial, FecFinal;
                            FecInicial = new DateTime(Convert.ToInt16(CboAnno.SelectedValue.ToString()), Convert.ToInt16(CboPeriodo.SelectedValue.ToString()), 1);
                            FecFinal = new DateTime(Convert.ToInt16(CboAnno.SelectedValue.ToString()), Convert.ToInt16(CboPeriodo.SelectedValue.ToString()), 1).AddMonths(1);
                            totalAfectados = new CL_Kardex().InsertCierreKardex(1,AppSettings.UserID, CboAlmacenHalley.SelectedValue.ToString(),"", c1cboCia.SelectedValue.ToString(),CboPeriodo.SelectedValue.ToString(),Convert.ToInt16(CboAnno.SelectedValue),false,0,0);
                        }
                        else if (RBCostoCero.Checked == true)
                        {
                            totalAfectados = new CL_Kardex().InsertCierreKardex(1, AppSettings.UserID, CboAlmacenHalley.SelectedValue.ToString(), "", c1cboCia.SelectedValue.ToString(), CboPeriodo.SelectedValue.ToString(), Convert.ToInt32(CboAnno.SelectedValue), true, 0, 0);
                        }
                    }

                    if (totalAfectados == 0)
                        MessageBox.Show("No se modifico ningun registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        MessageBox.Show("Se inserto el cierre correctamente.\n\nNro de registros afectados: " + totalAfectados.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insertar Cierre Mensual\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CierreMensual_Load(object sender, EventArgs e)
        {
            //agregar empresa
            DataTable DtEmpresas = new DataTable();
            DtEmpresas = new CL_Empresas().GetEmpresas();

            c1Combo.FillC1Combo(this.c1cboCia, DtEmpresas.Copy(), "NomEmpresa", "EmpresaID");

            c1Combo.FillC1Combo(this.c1cboCia2, DtEmpresas.Copy(), "NomEmpresa", "EmpresaID");


            //obtener lista de productos
            DataTable DtProductos = new DataTable();
            DtProductos = new CL_Producto().GetProductosPrincipales(true);
            CboProducto.HoldFields();
            CboProducto.DataSource = DtProductos.Copy();
            CboProducto.DisplayMember = "Alias";
            CboProducto.ValueMember = "ProductoID";


            //obtener lista de productos
            CboProducto2.HoldFields();
            CboProducto2.DataSource = DtProductos.Copy();
            CboProducto2.DisplayMember = "Alias";
            CboProducto2.ValueMember = "ProductoID";
            
            DataRow DR = DtProductos.NewRow();
            DR["ProductoID"] = "TODOS";
            DR["NomProducto"] = "TODOS";
            DR["Alias"] = "TODOS";
            DR["Almacen"] = "TOD";
            DR["SubFamiliaID"] = 0;
            DR["ProductoIDVentas"] = "TODOS";
            DR["UnidadMedidaID"] = "NN";
            DR["NomMarca"] = "Sin Marca";
            DR["MarcaID"] = "0";
            DtProductos.Rows.InsertAt(DR, 0);
            CboProducto.SelectedIndex = 0;

            //obtener año
            CboAnno.HoldFields();
            CboAnno.DataSource = c1Combo.Annos().Copy();
            CboAnno.DisplayMember = "Anno";
            CboAnno.ValueMember = "Anno";

            CboAnno2.HoldFields();
            CboAnno2.DataSource = c1Combo.Annos().Copy();
            CboAnno2.DisplayMember = "Anno";
            CboAnno2.ValueMember = "Anno";


            //obtener periodos
            CboPeriodo.HoldFields();
            CboPeriodo.DataSource = c1Combo.DtPeriodos().Copy();
            CboPeriodo.DisplayMember = "Descripcion";
            CboPeriodo.ValueMember = "Codigo";

            CboPeriodo2.HoldFields();
            CboPeriodo2.DataSource = c1Combo.DtPeriodos().Copy();
            CboPeriodo2.DisplayMember = "Descripcion";
            CboPeriodo2.ValueMember = "Codigo";

            //traer los almacenes 
            DataTable DtAlmacenes = new DataTable();
            DtAlmacenes = new CL_Empresas().GetAlmacenHalley();
            CboAlmacenHalley.HoldFields();
            CboAlmacenHalley.DataSource = DtAlmacenes;
            CboAlmacenHalley.DisplayMember = "Descripcion";
            CboAlmacenHalley.ValueMember = "ID";
            CboAlmacenHalley.SelectedIndex = 0;

            PnlProducto.Visible = false;
            //seleccion por defecto
            string MesAnterior = DateTime.Now.AddMonths(-1).Month.ToString().PadLeft(2,'0');
            CboPeriodo.SelectedValue = MesAnterior;
            CboAnno.SelectedValue = DateTime.Now.AddMonths(-1).Year;
            CboPeriodo2.SelectedValue = MesAnterior;
            CboAnno2.SelectedValue = DateTime.Now.AddMonths(-1).Year;
            ocultarToolStrip();

        }

        private void RbProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (RbAlmacen.Checked == true)
                PnlProducto.Visible = false;
            else if (RbProducto.Checked == true)
                PnlProducto.Visible = true;
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtCantidad);
        }

        private void TxtCostoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtCostoUnitario);
        }

        private void Btningresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtCantidad.Text != "" & TxtCostoUnitario.Text != "")
                {
                    //ingresar cierre mensual de forma manual
                    DateTime FecInicial, FecFinal;
                    int totalAfectados = 0;
                    FecInicial = new DateTime(Convert.ToInt16(CboAnno2.SelectedValue.ToString()), Convert.ToInt16(CboPeriodo2.SelectedValue.ToString()), 1);
                    FecFinal = new DateTime(Convert.ToInt16(CboAnno2.SelectedValue.ToString()), Convert.ToInt16(CboPeriodo2.SelectedValue.ToString()), 1).AddMonths(1);
                    totalAfectados = new CL_Kardex().InsertCierreKardex(2, AppSettings.UserID, "", CboProducto2.SelectedValue.ToString(), c1cboCia2.SelectedValue.ToString(), CboPeriodo2.SelectedValue.ToString(), Convert.ToInt16(CboAnno2.SelectedValue), true, Convert.ToDecimal(TxtCantidad.Text), Convert.ToDecimal(TxtCostoUnitario.Text));
                    if (totalAfectados > 0)
                    {
                        MessageBox.Show("Se ingreso correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                    MessageBox.Show("Ingrese Cantidad y Costo válidos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}

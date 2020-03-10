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
using Halley.Utilitario;
using C1.Win.C1Input;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class FrmTransferenciaPorDesperdicio : UITemplateAccess
    {
        #region Declaracione de variables

        DataTable dtProductos;
        DataTable dtSalidas;

        string AlmacenID, NomAlmacen, Codigo, Descripcion, UM, Marca;
        bool Estado;
        int Items, items;

        #endregion

        #region Constructor

        public FrmTransferenciaPorDesperdicio()
        {
            InitializeComponent();
            ocultarToolStrip();

            CargarCombos();            
        }

        #endregion

        #region Metodo definidos

        private void CargarCombos()
        {
            c1Combo.FillC1Combo(this.CbAlmacen, AppSettings.AlmacenPermisos, "Descripcion", "AlmacenID");
            c1Combo.FillC1Combo(this.CbDesperdicio, new CL_Almacen().getAlmacenDesperdicio(AppSettings.EmpresaID, AppSettings.SedeID), "Descripcion", "AlmacenID");            
        }

        private void ObtenerProductos(string AlmacenID)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                dtProductos = new DataTable();
                dtProductos = new CL_Producto().getProductos(AlmacenID);

                if (dtProductos.Rows.Count == 0)
                {
                    Cursor = Cursors.Default;
                    this.C1TdbgProducto.SetDataBinding(null, "", true);
                    return;
                }

                C1TdbgProducto.SetDataBinding(dtProductos, "", true);                
                items = C1TdbgProducto.RowCount;
                this.C1TdbgProducto.Columns[1].FooterText = "Items : " + items.ToString();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\nMetodo : ObtenerStock()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearTablaSalida()
        {
            dtSalidas = new DataTable();
            dtSalidas.Columns.Add("AlmacenID", typeof(string));
            dtSalidas.Columns.Add("NomAlmacen", typeof(string));
            dtSalidas.Columns.Add("Codigo", typeof(string));
            dtSalidas.Columns.Add("Descripcion", typeof(string));
            dtSalidas.Columns.Add("UM", typeof(string));
            dtSalidas.Columns.Add("Marca", typeof(string));
            dtSalidas.Columns.Add("Cantidad", typeof(decimal));
            dtSalidas.Columns.Add("Movimiento", typeof(int));

            C1TdbgSalida.SetDataBinding(dtSalidas, "", false);
            C1TdbgSalida.Caption = "SALIDAS POR DESPERDICIO";

            C1TdbgSalida.Splits[0].DisplayColumns["AlmacenID"].Visible = false;
            C1TdbgSalida.Splits[0].DisplayColumns["AlmacenID"].Width = 0;

            C1TdbgSalida.Columns["NomAlmacen"].Caption = "Almacen";
            C1TdbgSalida.Splits[0].DisplayColumns["NomAlmacen"].Style.Locked = true;
            C1TdbgSalida.Splits[0].DisplayColumns["NomAlmacen"].Visible = true;
            C1TdbgSalida.Splits[0].DisplayColumns["NomAlmacen"].Width = 150;
            C1TdbgSalida.Splits[0].DisplayColumns["NomAlmacen"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            C1TdbgSalida.Columns["Codigo"].Caption = "Codigo";
            C1TdbgSalida.Splits[0].DisplayColumns["Codigo"].Style.Locked = true;
            C1TdbgSalida.Splits[0].DisplayColumns["Codigo"].Visible = true;
            C1TdbgSalida.Splits[0].DisplayColumns["Codigo"].Width = 120;
            C1TdbgSalida.Splits[0].DisplayColumns["Codigo"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            C1TdbgSalida.Columns["Descripcion"].Caption = "Descripcion";
            C1TdbgSalida.Splits[0].DisplayColumns["Descripcion"].Style.Locked = true;
            C1TdbgSalida.Splits[0].DisplayColumns["Descripcion"].Visible = true;
            C1TdbgSalida.Splits[0].DisplayColumns["Descripcion"].Width = 500;
            C1TdbgSalida.Splits[0].DisplayColumns["Descripcion"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            C1TdbgSalida.Columns["UM"].Caption = "UM";
            C1TdbgSalida.Splits[0].DisplayColumns["UM"].Style.Locked = true;
            C1TdbgSalida.Splits[0].DisplayColumns["UM"].Visible = true;
            C1TdbgSalida.Splits[0].DisplayColumns["UM"].Width = 30;
            C1TdbgSalida.Splits[0].DisplayColumns["UM"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            C1TdbgSalida.Columns["Marca"].Caption = "Marca";
            C1TdbgSalida.Splits[0].DisplayColumns["Marca"].Style.Locked = true;
            C1TdbgSalida.Splits[0].DisplayColumns["Marca"].Visible = true;
            C1TdbgSalida.Splits[0].DisplayColumns["Marca"].Width = 250;
            C1TdbgSalida.Splits[0].DisplayColumns["Marca"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            C1TdbgSalida.Columns["Cantidad"].Caption = "Cantidad";
            C1TdbgSalida.Columns["Cantidad"].Editor = this.c1NumericEdit1;
            C1TdbgSalida.Splits[0].DisplayColumns["Cantidad"].Style.Locked = false;
            C1TdbgSalida.Splits[0].DisplayColumns["Cantidad"].Visible = true;
            C1TdbgSalida.Splits[0].DisplayColumns["Cantidad"].Width = 100;
            C1TdbgSalida.Splits[0].DisplayColumns["Cantidad"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            C1TdbgSalida.Splits[0].DisplayColumns["Movimiento"].Visible = false;
            C1TdbgSalida.Splits[0].DisplayColumns["Movimiento"].Width = 0;

            this.C1TdbgProducto.ColumnFooters = true;
            this.C1TdbgSalida.ColumnFooters = true;
        }

        private void setDataSalidas()
        {
            DataRow drow = dtSalidas.NewRow();
            drow["AlmacenID"] = AlmacenID;
            drow["NomAlmacen"] = NomAlmacen;
            drow["Codigo"] = Codigo;
            drow["Descripcion"] = Descripcion;
            drow["UM"] = UM;
            drow["Marca"] = Marca;
            drow["Cantidad"] = 0;
            drow["Movimiento"] = Enums.Movimiento.SALIDA_POR_DESPERDICIO;
            dtSalidas.Rows.Add(drow);
        }

        private void Guardar()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                for (int i = 0; i <= this.C1TdbgSalida.RowCount - 1; i++)
                {
                    if (this.C1TdbgSalida[i, "Cantidad"] == DBNull.Value ||Convert.ToDecimal(this.C1TdbgSalida[i, "Cantidad"]) == 0)
                    {
                        MessageBox.Show("Ingrese la cantidad de lo contrario elimine el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.C1TdbgSalida.Row = i;
                        this.C1TdbgSalida.Col = 7;
                        this.C1TdbgSalida.Select();
                        Cursor = Cursors.Default;
                        return;
                    }
                }
                this.C1TdbgSalida.Refresh();
                dtSalidas.AcceptChanges();

                DialogResult Mensaje = MessageBox.Show("¿Está seguro de registrar la información?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Mensaje == DialogResult.Yes)
                {                    
                    new CL_Kardex().InsertDesperdicio(dtSalidas, CbDesperdicio.SelectedValue.ToString(), Convert.ToInt16(Enums.Movimiento.INGRESO_POR_DESPERDICIO), AppSettings.UserID);
                    MessageBox.Show("Los registros se guardaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Finalizar();
                    CountTablaSalida();
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message , "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                          
        }

        private void Finalizar()
        {           
            dtSalidas.Rows.Clear();
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void CountTablaSalida()
        {
            Items = C1TdbgSalida.RowCount;
            this.C1TdbgSalida.Columns[1].FooterText = "Items : " + Items.ToString();
        }

        #endregion

        #region Eventos de los controles

        private void CbAlmacen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CbAlmacen.SelectedValue != null)
            {
                this.ObtenerProductos(CbAlmacen.SelectedValue.ToString());
            }
        }

        private void C1TdbgProducto_DoubleClick(object sender, EventArgs e)
        {
            if (dtProductos.Rows.Count != 0)
            {
                dtSalidas.AcceptChanges();

                AlmacenID = C1TdbgProducto.Columns["AlmacenID"].Value.ToString();
                NomAlmacen = CbAlmacen.Text.ToString();
                Codigo = C1TdbgProducto.Columns["ProductoID"].Value.ToString();
                Descripcion = C1TdbgProducto.Columns["Descripcion"].Value.ToString();
                UM = C1TdbgProducto.Columns["UnidadMedidaID"].Value.ToString();
                Marca = C1TdbgProducto.Columns["NomMarca"].Value.ToString();

                if (dtSalidas.Rows.Count == 0)
                {
                    setDataSalidas();
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
                else
                {
                    Estado = false;
                    foreach (DataRow row in dtSalidas.Rows)
                    {
                        if (row["AlmacenID"].ToString() == AlmacenID && row["Codigo"].ToString() == Codigo)
                        {
                            Estado = true;
                            break;
                        }
                    }

                    if (Estado == true)
                    {
                        MessageBox.Show("El Producto ya ah sido agregado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        setDataSalidas();
                    }
                }
                CountTablaSalida();
            }
        }

        private void FrmDespachoPorDesperdicio_Load(object sender, EventArgs e)
        {
            CrearTablaSalida();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult Mensaje = MessageBox.Show("¿Está seguro de cancelar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Mensaje == DialogResult.Yes)
            {
                Finalizar();
                CountTablaSalida();
            }
        }

        private void C1TdbgSalida_AfterDelete(object sender, EventArgs e)
        {
            CountTablaSalida();
        }
        
        #endregion
    }
}

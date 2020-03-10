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
    public partial class Ope_DespachoPorConsumo : UITemplateAccess
    {

        #region declaracion de variables

        DataTable dtProductos;
        DataTable dtConsumo;

        string AlmacenID, NomAlmacen, Codigo, Descripcion, UM, Marca;
        decimal StockActual, StockDisponible;
        bool Estado;
        int Items, items;
        int S;


        #endregion

        #region Contructor

        public Ope_DespachoPorConsumo()
        {
            InitializeComponent();
            ocultarToolStrip();

            CargarCombos();
        }

        #endregion

        #region Metodos definidos

        private void Guardar()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                for (int i = 0; i <= this.c1TdgConsumo.RowCount - 1; i++)
                {
                    if (this.c1TdgConsumo[i, "Cantidad"] == DBNull.Value || Convert.ToDecimal(this.c1TdgConsumo[i, "Cantidad"]) == 0)
                    {
                        MessageBox.Show("Ingrese la cantidad de lo contrario elimine el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.c1TdgConsumo.Row = i;
                        this.c1TdgConsumo.Col = 7;
                        this.c1TdgConsumo.Select();
                        Cursor = Cursors.Default;
                        return;
                    }
                }
                this.c1TdgConsumo.Refresh();
                dtConsumo.AcceptChanges();

                DialogResult Mensaje = MessageBox.Show("¿Está seguro de registrar la información?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Mensaje == DialogResult.Yes)
                {
                    new CL_Kardex().InsertConsumo(dtConsumo, AppSettings.UserID);
                    MessageBox.Show("Los registros se guardaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Finalizar();
                    CountTablaSalida();
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearTablaSalida()
        {
            dtConsumo = new DataTable();
            dtConsumo.Columns.Add("AlmacenID", typeof(string));
            dtConsumo.Columns.Add("NomAlmacen", typeof(string));
            dtConsumo.Columns.Add("Codigo", typeof(string));
            dtConsumo.Columns.Add("Descripcion", typeof(string));
            dtConsumo.Columns.Add("UM", typeof(string));
            dtConsumo.Columns.Add("Marca", typeof(string));
            dtConsumo.Columns.Add("StockActual", typeof(decimal));
            dtConsumo.Columns.Add("StockDisponible", typeof(decimal));
            dtConsumo.Columns.Add("Cantidad", typeof(decimal));
            dtConsumo.Columns.Add("Movimiento", typeof(int));

            c1TdgConsumo.SetDataBinding(dtConsumo, "", false);
            c1TdgConsumo.Caption = "SALIDAS POR CONSUMO";

            c1TdgConsumo.Splits[0].DisplayColumns["AlmacenID"].Visible = false;
            c1TdgConsumo.Splits[0].DisplayColumns["AlmacenID"].Width = 0;

            c1TdgConsumo.Columns["NomAlmacen"].Caption = "Almacen";
            c1TdgConsumo.Splits[0].DisplayColumns["NomAlmacen"].Style.Locked = true;
            c1TdgConsumo.Splits[0].DisplayColumns["NomAlmacen"].Visible = true;
            c1TdgConsumo.Splits[0].DisplayColumns["NomAlmacen"].Width = 150;
            c1TdgConsumo.Splits[0].DisplayColumns["NomAlmacen"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            c1TdgConsumo.Columns["Codigo"].Caption = "Codigo";
            c1TdgConsumo.Splits[0].DisplayColumns["Codigo"].Style.Locked = true;
            c1TdgConsumo.Splits[0].DisplayColumns["Codigo"].Visible = true;
            c1TdgConsumo.Splits[0].DisplayColumns["Codigo"].Width = 120;
            c1TdgConsumo.Splits[0].DisplayColumns["Codigo"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            c1TdgConsumo.Columns["Descripcion"].Caption = "Descripcion";
            c1TdgConsumo.Splits[0].DisplayColumns["Descripcion"].Style.Locked = true;
            c1TdgConsumo.Splits[0].DisplayColumns["Descripcion"].Visible = true;
            c1TdgConsumo.Splits[0].DisplayColumns["Descripcion"].Width = 450;
            c1TdgConsumo.Splits[0].DisplayColumns["Descripcion"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            c1TdgConsumo.Columns["UM"].Caption = "UM";
            c1TdgConsumo.Splits[0].DisplayColumns["UM"].Style.Locked = true;
            c1TdgConsumo.Splits[0].DisplayColumns["UM"].Visible = true;
            c1TdgConsumo.Splits[0].DisplayColumns["UM"].Width = 30;
            c1TdgConsumo.Splits[0].DisplayColumns["UM"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            c1TdgConsumo.Columns["Marca"].Caption = "Marca";
            c1TdgConsumo.Splits[0].DisplayColumns["Marca"].Style.Locked = true;
            c1TdgConsumo.Splits[0].DisplayColumns["Marca"].Visible = true;
            c1TdgConsumo.Splits[0].DisplayColumns["Marca"].Width = 250;
            c1TdgConsumo.Splits[0].DisplayColumns["Marca"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            c1TdgConsumo.Columns["StockActual"].Caption = "Stock Actual";
            c1TdgConsumo.Splits[0].DisplayColumns["StockActual"].Style.Locked = true;
            c1TdgConsumo.Splits[0].DisplayColumns["StockActual"].Visible = true;
            c1TdgConsumo.Splits[0].DisplayColumns["StockActual"].Width = 100;
            c1TdgConsumo.Splits[0].DisplayColumns["StockActual"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            c1TdgConsumo.Columns["StockDisponible"].Caption = "Stock Disponible";
            c1TdgConsumo.Splits[0].DisplayColumns["StockDisponible"].Style.Locked = true;
            c1TdgConsumo.Splits[0].DisplayColumns["StockDisponible"].Visible = true;
            c1TdgConsumo.Splits[0].DisplayColumns["StockDisponible"].Width = 100;
            c1TdgConsumo.Splits[0].DisplayColumns["StockDisponible"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            c1TdgConsumo.Columns["Cantidad"].Caption = "Cantidad";
            c1TdgConsumo.Columns["Cantidad"].Editor = this.c1NumericEdit1;
            c1TdgConsumo.Splits[0].DisplayColumns["Cantidad"].Style.Locked = false;
            c1TdgConsumo.Splits[0].DisplayColumns["Cantidad"].Visible = true;
            c1TdgConsumo.Splits[0].DisplayColumns["Cantidad"].Width = 100;
            c1TdgConsumo.Splits[0].DisplayColumns["Cantidad"].HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center;

            c1TdgConsumo.Splits[0].DisplayColumns["Movimiento"].Visible = false;
            c1TdgConsumo.Splits[0].DisplayColumns["Movimiento"].Width = 0;

            this.C1TdbgProducto.ColumnFooters = true;
            this.c1TdgConsumo.ColumnFooters = true;
        }

        private void ObtenerProductos(string AlmacenID)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                dtProductos = new DataTable();
                dtProductos = new CL_Producto().ObtenerStock(AlmacenID);

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

        private void setDataSalidas()
        {
            DataRow drow = dtConsumo.NewRow();
            drow["AlmacenID"] = AlmacenID;
            drow["NomAlmacen"] = NomAlmacen;
            drow["Codigo"] = Codigo;
            drow["Descripcion"] = Descripcion;
            drow["UM"] = UM;
            drow["Marca"] = Marca;
            drow["StockActual"] = StockActual;
            drow["StockDisponible"] = StockDisponible;
            drow["Cantidad"] = 0;
            drow["Movimiento"] = Enums.Movimiento.SALIDA_POR_CONSUMO;
            dtConsumo.Rows.Add(drow);
        }

        private void CargarCombos()
        {
            c1Combo.FillC1Combo(this.CbAlmacen, AppSettings.AlmacenPermisos, "Descripcion", "AlmacenID");            
        }

        private void CountTablaSalida()
        {
            Items = c1TdgConsumo.RowCount;
            this.c1TdgConsumo.Columns[1].FooterText = "Items : " + Items.ToString();
        }

        private void Finalizar()
        {
            dtConsumo.Rows.Clear();
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
        }



        #endregion

        #region Eventos de los controles

        private void C1TdbgProducto_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {
            switch (e.Col)
            {
                case 7:
                    S = int.Parse(C1TdbgProducto.Columns["Prioridad"].CellText(e.Row));
                    if (S >= 0 && S <= 2)
                        e.CellStyle.BackColor = System.Drawing.Color.Red;
                    else if (S > 2 && S <= 4)
                        e.CellStyle.BackColor = System.Drawing.Color.Yellow;
                    else
                        e.CellStyle.BackColor = System.Drawing.Color.Green;
                    break;
            }
        }

        private void CbAlmacen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CbAlmacen.SelectedValue != null)
            {
                this.ObtenerProductos(CbAlmacen.SelectedValue.ToString());
            }
        }

        private void Ope_DespachoPorConsumo_Load(object sender, EventArgs e)
        {
            CrearTablaSalida();
        }

        private void C1TdbgProducto_DoubleClick(object sender, EventArgs e)
        {
            if (dtProductos.Rows.Count != 0)
            {
                dtConsumo.AcceptChanges();

                AlmacenID = C1TdbgProducto.Columns["AlmacenID"].Value.ToString();
                NomAlmacen = CbAlmacen.Text.ToString();
                Codigo = C1TdbgProducto.Columns["ProductoID"].Value.ToString();
                Descripcion = C1TdbgProducto.Columns["Descripcion"].Value.ToString();
                UM = C1TdbgProducto.Columns["UnidadMedidaID"].Value.ToString();
                Marca = C1TdbgProducto.Columns["NomMarca"].Value.ToString();
                StockActual =Convert.ToDecimal(C1TdbgProducto.Columns["StockActual"].Value);
                StockDisponible = Convert.ToDecimal(C1TdbgProducto.Columns["StockDisponible"].Value);

                if (dtConsumo.Rows.Count == 0)
                {
                    setDataSalidas();
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
                else
                {
                    Estado = false;
                    foreach (DataRow row in dtConsumo.Rows)
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

        private void c1TdgConsumo_AfterDelete(object sender, EventArgs e)
        {
            CountTablaSalida();
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        #endregion

      

        

        

      

       




    }
}

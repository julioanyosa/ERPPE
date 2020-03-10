using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Halley.Configuracion;
using Halley.CapaLogica.Almacen;
using Halley.Utilitario;
using C1.Win.C1Input;

namespace Halley.Presentacion.Almacen.Reportes
{
    public partial class Rep_Stock : UITemplateAccess
    {
        #region Declaracion de Variables

        DataTable dtStock;
        DataTable dtProducto;
        DataTable dtRequerimiento;
        DataTable dtCompra;

        bool Rtipo;
        bool valor=true;

        int S;
        
        #endregion

        #region Contructor

        public Rep_Stock()
        {
            InitializeComponent();
            this.ocultarToolStrip();
            
        }

        #endregion

        #region Metodos Definidos


        public void Cargar()
        {
            c1Combo.FillC1Combo(this.CbAlmacen, AppSettings.AlmacenPermisos, "Descripcion", "AlmacenID");
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            Cargar();
            TcRequerimientos_SelectedIndexChanged(null, null);
            this.C1tdbDetalle.Columns["CantidadSolicitada"].Editor = this.c1NumericEdit1;// enlazar con control para que acepte solo numeros
            this.TdgCompras.Columns["CantidadSolicitada"].Editor = this.c1NumericEdit1;// enlazar con control para que acepte solo numeros
            this.TdgCompras.Columns["Duracion"].Editor = this.c1NumericEdit1;// enlazar con control para que acepte solo numeros
        }

        public void ObtenerStock(string AlmacenID)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                dtStock = new DataTable();
                dtStock = new CL_Producto().ObtenerStock(AlmacenID);

                if (dtStock.Rows.Count == 0)
                {
                    Cursor = Cursors.Default;
                    this.C1TdbgProducto.SetDataBinding(null, "", true);
                    return;
                }

                C1TdbgProducto.SetDataBinding(dtStock, "", true);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\nMetodo : ObtenerStock()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscarProducto(string EmpresaID, string ProductoID, string SedeID)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                dtProducto = new DataTable();
                dtProducto = new CL_Producto().BuscarProductoAlmacen(EmpresaID, ProductoID, SedeID);                
                
                if (dtProducto.Rows.Count == 0)
                {
                    Cursor = Cursors.Default;
                    this.c1TdgAlmacen.SetDataBinding(null, "", true);
                    return;
                }

                c1TdgAlmacen.SetDataBinding(dtProducto, "", true);

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\nMetodo : BuscarProducto()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Verificar(string Origen,string Sede, string AlmacenId, string ProductoID, decimal StockDisponible, decimal Cantidad)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int posicion = 0;
                foreach (DataRow dr in dtRequerimiento.Rows)
                {
                    if (dr["Origen"].ToString()==Origen && dr["Sede"].ToString()== Sede && dr["AlmacenID"].ToString() == AlmacenId && dr["ProductoID"].ToString() == ProductoID)
                    {
                        if (StockDisponible < Cantidad)
                        {
                            MessageBox.Show("Solicité menor al Stock Disponible.", "Verique", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dtRequerimiento.Rows[posicion]["CantidadSolicitada"] = 0;
                            break;
                        }
                        else
                        {
                            dtRequerimiento.Rows[posicion]["CantidadSolicitada"] = Cantidad;
                            break;
                        }
                    }
                    posicion++;
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\nMetodo : Verificar()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        #endregion

        #region Eventos




        private void CbProducto_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (valor == true)
            {
                if (CbProducto.Text.ToString() != "")
                {
                    BuscarProducto(AppSettings.EmpresaID, this.CbProducto.SelectedValue.ToString(), AppSettings.SedeID);
                }
                else
                {
                    this.c1TdgAlmacen.SetDataBinding(null, "", true);
                }
            }

        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (TcRequerimientos.SelectedIndex == 0)
                {
                    if (this.C1tdbDetalle.RowCount == 0)
                    {
                        Cursor = Cursors.Default;
                        return;
                    }
                }
                else if (TcRequerimientos.SelectedIndex == 1)
                {
                    if (this.TdgCompras.RowCount == 0)
                    {
                        Cursor = Cursors.Default;
                        return;
                    }
                }

                if (TcRequerimientos.SelectedIndex == 0)
                {
                    for (int i = 0; i <= this.C1tdbDetalle.RowCount - 1; i++)
                    {
                        if (this.C1tdbDetalle[i, "CantidadSolicitada"] == DBNull.Value || Convert.ToInt64(this.C1tdbDetalle[i, "CantidadSolicitada"]) == 0)
                        {
                            MessageBox.Show("La cantidad no puede ser 0 o vacia,Verique", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.C1tdbDetalle.Row = i;
                            this.C1tdbDetalle.Col = 9;
                            this.C1tdbDetalle.Select();
                            Cursor = Cursors.Default;
                            return;
                        }
                    }
                }
                else if (TcRequerimientos.SelectedIndex == 1)
                {
                    for (int i = 0; i <= this.TdgCompras.RowCount - 1; i++)
                    {
                        if (this.TdgCompras[i, "CantidadSolicitada"] == DBNull.Value || Convert.ToInt64(this.TdgCompras[i, "CantidadSolicitada"]) == 0)
                        {
                            MessageBox.Show("La cantidad no puede ser 0 o vacia,Verique", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.TdgCompras.Row = i;
                            this.TdgCompras.Col = 8;
                            this.TdgCompras.Select();
                            Cursor = Cursors.Default;
                            return;
                        }
                    }
                }


                this.C1tdbDetalle.Refresh();

                if (Rtipo == true)
                {
                    dtRequerimiento.AcceptChanges();
                    new CL_Requerimientos().InsertarTransferencia(dtRequerimiento, AppSettings.UserID, AppSettings.EmpresaID, AppSettings.NomSede, AppSettings.ApeNom_Login);
                }
                else
                {
                    dtCompra.AcceptChanges();
                    new CL_Requerimientos().InsertarCompra(dtCompra, AppSettings.UserID, AppSettings.EmpresaID, AppSettings.SedeID);
                }

                MessageBox.Show("Los registros se guardaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.C1tdbDetalle.SetDataBinding(null, "", true);
                //this.c1TdgAlmacen.SetDataBinding(null, "", true);
                //this.C1TdbgProducto.SetDataBinding(null, "", true);
                //this.CbProducto.DataSource = null;



                //dtCompra = null;
                //dtRequerimiento = null;
                if (dtCompra != null)
                    dtCompra.Rows.Clear();
                if(dtRequerimiento !=null)
                    dtRequerimiento.Rows.Clear();

                valor = true;

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar Requerimiento.\n\n" + ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dtCompra != null)
                dtCompra.Rows.Clear();
            if (dtRequerimiento != null)
                dtRequerimiento.Rows.Clear();
        }


        private void BtnProducto_Click_1(object sender, EventArgs e)
        {
            Rep_Producto ObjProducto = new Rep_Producto();

            if (ObjProducto.ShowDialog() == DialogResult.OK)
            {
                CbAlmacen.SelectedValue = ObjProducto.CodAlmacen;                
            }
        }


        #endregion

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            if (CbAlmacen.SelectedValue != null)
            {
                this.ObtenerStock(AppSettings.EmpresaID + AppSettings.SedeID + CbAlmacen.SelectedValue.ToString().Substring(7,3));

                if (dtStock.Rows.Count != 0)
                {
                    CbProducto.Enabled = true;

                    DataView dv = new DataView(dtStock);
                    dv.RowFilter = "Prioridad IN (0,1,2)";

                    c1Combo.FillC1Combo1(this.CbProducto, dv.ToTable(), "Descripcion", "ProductoID");
                }
                else
                {
                    CbProducto.Text = "";
                    CbProducto.Enabled = false;
                }
            }
        }

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

        private void C1TdbgProducto_DoubleClick(object sender, EventArgs e)
        {
            if (dtCompra != null && TcRequerimientos.SelectedIndex == 1)
            {
                string AlmacenID = this.C1TdbgProducto.Columns["AlmacenID"].Value.ToString();
                string ProductoID = this.C1TdbgProducto.Columns["ProductoID"].Value.ToString();
                string Descripcion = this.C1TdbgProducto.Columns["Descripcion"].Value.ToString();
                string Unidad = this.C1TdbgProducto.Columns["UnidadMedidaID"].Value.ToString();
                string Marca = this.C1TdbgProducto.Columns["NomMarca"].Value.ToString();
                decimal Stock = Convert.ToDecimal(this.C1TdbgProducto.Columns["StockActual"].Value.ToString());

                if (dtCompra.Rows.Count == 0)
                {
                    DataRow row;
                    row = dtCompra.NewRow();
                    row["AlmacenID"] = AlmacenID.ToString();
                    row["ProductoID"] = ProductoID.ToString();
                    row["Producto"] = Descripcion.ToString();
                    row["Marca"] = Marca.ToString();
                    row["CantidadSolicitada"] = 0;
                    row["UM"] = Unidad.ToString();
                    row["StockActual"] = Stock.ToString();
                    row["Duracion"] = 7;
                    row["Condicion"] = "A";
                    row["Observacion"] = "";
                    dtCompra.Rows.Add(row);
                }
                else
                {
                    bool valor = false;
                    foreach (DataRow drow in dtCompra.Rows)
                    {
                        if (drow["AlmacenID"].ToString() == AlmacenID.ToString() && drow["ProductoID"].ToString() == ProductoID.ToString())
                        {
                            valor = true;
                            break;
                        }
                    }
                    if (valor == true)
                    {
                        MessageBox.Show("El Producto ya ah sido agregado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        DataRow row;
                        row = dtCompra.NewRow();
                        row["AlmacenID"] = AlmacenID.ToString();
                        row["ProductoID"] = ProductoID.ToString();
                        row["Producto"] = Descripcion.ToString();
                        row["Marca"] = Marca.ToString();
                        row["CantidadSolicitada"] = 0;
                        row["UM"] = Unidad.ToString();
                        row["StockActual"] = Stock.ToString();
                        row["Duracion"] = 7;
                        row["Condicion"] = "A";
                        row["Observacion"] = "";
                        dtCompra.Rows.Add(row);
                    }

                }
                this.C1tdbDetalle.ColumnFooters = true;
                int Count = C1tdbDetalle.RowCount;
                this.C1tdbDetalle.Columns[1].FooterText = "Items : " + Count.ToString();
            }

        }

        private void c1TdgAlmacen_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {
            switch (e.Col)
            {
                case 12:
                    S = int.Parse(c1TdgAlmacen.Columns["Prioridad"].CellText(e.Row));
                    if (S >= 0 && S <= 2)
                        e.CellStyle.BackColor = System.Drawing.Color.Red;
                    else if (S > 2 && S <= 4)
                        e.CellStyle.BackColor = System.Drawing.Color.Yellow;
                    else
                        e.CellStyle.BackColor = System.Drawing.Color.Green;
                    break;
            }

        }

        private void c1TdgAlmacen_DoubleClick(object sender, EventArgs e)
        {
            if (c1TdgAlmacen.RowCount > 0)
            {
                if (dtRequerimiento != null)
                {
                    string Sede = this.c1TdgAlmacen.Columns["NomSede"].Value.ToString();
                    string AlmacenID = this.c1TdgAlmacen.Columns["AlmacenID"].Value.ToString();
                    string ProductoID = this.c1TdgAlmacen.Columns["ProductoID"].Value.ToString();

                    if (dtRequerimiento.Rows.Count == 0)
                    {
                        DataRow row;
                        row = dtRequerimiento.NewRow();
                        row["Origen"] = CbAlmacen.SelectedValue.ToString();
                        row["Sede"] = this.c1TdgAlmacen.Columns["NomSede"].Value.ToString();
                        row["AlmacenID"] = this.c1TdgAlmacen.Columns["AlmacenID"].Value.ToString();
                        row["Almacen"] = this.c1TdgAlmacen.Columns["Descripcion"].Value.ToString();
                        row["ProductoID"] = this.c1TdgAlmacen.Columns["ProductoID"].Value.ToString();
                        row["Producto"] = this.c1TdgAlmacen.Columns["NomProducto"].Value.ToString();
                        row["UM"] = this.c1TdgAlmacen.Columns["UnidadMedidaID"].Value.ToString();
                        row["Marca"] = this.c1TdgAlmacen.Columns["NomMarca"].Value.ToString();
                        row["Disponible"] = this.c1TdgAlmacen.Columns["StockDisponible"].Value.ToString();
                        dtRequerimiento.Rows.Add(row);
                    }
                    else
                    {
                        bool valor = false;
                        foreach (DataRow drow in dtRequerimiento.Rows)
                        {
                            if (drow["Origen"] == this.CbAlmacen.SelectedValue && drow["Sede"].ToString() == Sede.ToString() && drow["AlmacenID"].ToString() == AlmacenID.ToString() && drow["ProductoID"].ToString() == ProductoID.ToString())
                            {
                                valor = true;
                                break;
                            }
                        }

                        if (valor == true)
                        {
                            MessageBox.Show("El Producto ya ah sido agregado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            DataRow row;
                            row = dtRequerimiento.NewRow();
                            row["Origen"] = CbAlmacen.SelectedValue.ToString();
                            row["Sede"] = this.c1TdgAlmacen.Columns["NomSede"].Value.ToString();
                            row["AlmacenID"] = this.c1TdgAlmacen.Columns["AlmacenID"].Value.ToString();
                            row["Almacen"] = this.c1TdgAlmacen.Columns["Descripcion"].Value.ToString();
                            row["ProductoID"] = this.c1TdgAlmacen.Columns["ProductoID"].Value.ToString();
                            row["Producto"] = this.c1TdgAlmacen.Columns["NomProducto"].Value.ToString();
                            row["UM"] = this.c1TdgAlmacen.Columns["UnidadMedidaID"].Value.ToString();
                            row["Marca"] = this.c1TdgAlmacen.Columns["NomMarca"].Value.ToString();
                            row["Disponible"] = this.c1TdgAlmacen.Columns["StockDisponible"].Value.ToString();
                            dtRequerimiento.Rows.Add(row);
                        }

                    }

                    this.C1tdbDetalle.ColumnFooters = true;
                    int Count = C1tdbDetalle.RowCount;
                    this.C1tdbDetalle.Columns[1].FooterText = "Items : " + Count.ToString();

                }
            }

        }

        private void C1tdbDetalle_AfterColUpdate(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            if (this.C1tdbDetalle.RowCount > 0)
            {
                if (Rtipo == true)
                {
                    this.C1tdbDetalle.RefreshCol();
                    this.Verificar(this.C1tdbDetalle.Columns["Origen"].Value.ToString(),
                                    this.C1tdbDetalle.Columns["Sede"].Value.ToString(),
                                    this.C1tdbDetalle.Columns["AlmacenID"].Value.ToString(),
                                    this.C1tdbDetalle.Columns["ProductoID"].Value.ToString(),
                                    Convert.ToDecimal(this.C1tdbDetalle.Columns["Disponible"].Value.ToString()),
                                    Convert.ToDecimal(this.C1tdbDetalle.Columns["CantidadSolicitada"].Value.ToString()));
                }
            }

        }

        private void TdgCompras_AfterColUpdate(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            if (this.TdgCompras.RowCount > 0)
            {
                if (Rtipo == true)
                {
                    this.TdgCompras.RefreshCol();
                    this.Verificar(this.TdgCompras.Columns["Origen"].Value.ToString(),
                                    this.TdgCompras.Columns["Sede"].Value.ToString(),
                                    this.TdgCompras.Columns["AlmacenID"].Value.ToString(),
                                    this.TdgCompras.Columns["ProductoID"].Value.ToString(),
                                    Convert.ToDecimal(this.TdgCompras.Columns["Disponible"].Value.ToString()),
                                    Convert.ToDecimal(this.TdgCompras.Columns["CantidadSolicitada"].Value.ToString()));
                }
            }
        }

        private void TcRequerimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TcRequerimientos.SelectedIndex == 0)
            {
                Rtipo = true;
                dtRequerimiento = new DataTable();
                dtRequerimiento.Columns.Add("Origen", typeof(string));
                dtRequerimiento.Columns.Add("Sede", typeof(string));
                dtRequerimiento.Columns.Add("AlmacenID", typeof(string));
                dtRequerimiento.Columns.Add("Almacen", typeof(string));
                dtRequerimiento.Columns.Add("ProductoID", typeof(string));
                dtRequerimiento.Columns.Add("Producto", typeof(string));
                dtRequerimiento.Columns.Add("UM", typeof(string));
                dtRequerimiento.Columns.Add("Marca", typeof(string));
                dtRequerimiento.Columns.Add("Disponible", typeof(decimal));
                dtRequerimiento.Columns.Add("CantidadSolicitada", typeof(decimal));
                dtRequerimiento.Columns.Add("Observacion", typeof(string));

                this.C1tdbDetalle.SetDataBinding(dtRequerimiento, "", true);

            }
            else if (TcRequerimientos.SelectedIndex == 1)
            {
                Rtipo = false;
                dtCompra = new DataTable();
                dtCompra.Columns.Add("AlmacenID", typeof(string));
                dtCompra.Columns.Add("ProductoID", typeof(string));
                dtCompra.Columns.Add("Producto", typeof(string));
                dtCompra.Columns.Add("Marca", typeof(string));
                dtCompra.Columns.Add("CantidadSolicitada", typeof(decimal));
                dtCompra.Columns.Add("UM", typeof(string));
                dtCompra.Columns.Add("StockActual", typeof(decimal));
                dtCompra.Columns.Add("Duracion", typeof(Int32));
                dtCompra.Columns.Add("Condicion", typeof(string));
                dtCompra.Columns.Add("Observacion", typeof(string));


                this.TdgCompras.SetDataBinding(dtCompra, "", true);
            }
        }

        private void C1tdbDetalle_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            if (C1tdbDetalle.Columns["CantidadSolicitada"].Value.ToString() == "")
            {
                e.Cancel = true;
                C1tdbDetalle.Columns["CantidadSolicitada"].Value = 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.CapaLogica.Ventas;
using Halley.Utilitario;
using Halley.Configuracion;

namespace Halley.Presentacion.Ventas.VentasPavo
{
    public partial class ListPeso : UITemplateAccess
    {
        #region declaracion de variables

        DataTable dtPeso;
        DataTable dtPresentaciones;       

        decimal peso = 0, tot, pesoMinimo;
        int max = 19, i = 0, x = 2, items = 0, linea=1;
        string sum;
        
        #endregion

        #region constructor

        public ListPeso()
        {
            InitializeComponent();
        }

        #endregion

        #region eventos del control

        private void cbGenerico_SelectedValueChanged(object sender, EventArgs e)
        {
            dtPresentaciones = new DataTable("Producto");
            dtPresentaciones = new CL_Producto().getProductosNavideños(cbGenerico.SelectedValue.ToString());
            dtPresentaciones.Columns.Add("Cantidad", typeof(int));
            dtPresentaciones.Columns.Add("PesoActual", typeof(decimal));

            pesoMinimo = (decimal)dtPresentaciones.Compute("MIN(RangoInicial)", "");
            lblPesoMinimo.Text = pesoMinimo.ToString();
            Limpiar();           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DataTable dtPesoReal = new DataTable("Peso");                
                dtPesoReal.Columns.Add("PesoReal", typeof(decimal));

                foreach (DataRow fila in dtPeso.Rows)
                {
                    for (int x = 1; x <= 10; x++)
                    {
                        if (fila["Peso" + x + ""].ToString() != "" && fila["Peso" + x + ""].ToString() != "0" && Convert.ToDecimal(fila["Peso" + x + ""]) >= pesoMinimo)
                        {
                            DataRow row = dtPesoReal.NewRow();
                            row["PesoReal"] = fila["Peso" + x + ""];
                            dtPesoReal.Rows.Add(row);
                        }
                    }
                }

                if (dtPesoReal.Rows.Count == 0)
                {
                    MessageBox.Show("No existen pesos dentro del rango,Verique", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cursor = Cursors.Default;
                    return;
                }

                foreach (DataRow row in dtPesoReal.Rows)
                {
                    decimal peso = Convert.ToDecimal(row["PesoReal"]);
                    int x = 0;
                    decimal pesoActual = 0;
                    int posicion = 0;

                    foreach (DataRow fila in dtPresentaciones.Rows)
                    {
                        if (Convert.ToDecimal(fila["RangoInicial"]) <= peso && Convert.ToDecimal(fila["RangoFinal"]) > peso)
                        {
                            if (fila["Cantidad"].ToString() != "")
                            {
                                pesoActual = Convert.ToDecimal(fila["PesoActual"]);
                                x = Convert.ToInt32(fila["Cantidad"]);
                            }

                            dtPresentaciones.Rows[posicion]["Cantidad"] = x + 1;
                            dtPresentaciones.Rows[posicion]["PesoActual"] = pesoActual + peso;
                            break;
                        }
                        posicion++;
                    }
                }

                DataView dv = new DataView(dtPresentaciones);
                dv.RowFilter = "Not Cantidad IS NULL";

                decimal PesoTot =(decimal) dtPesoReal.Compute("SUM(PesoReal)","");

                new CL_Vales().InsertPesos(AppSettings.UserID, CbAlmacen.SelectedValue.ToString(),PesoTot, dtPesoReal, dv.ToTable());
                MessageBox.Show("Pesos guardados con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                
                dtPesoReal.Clear();

                for (int x = 0; dtPresentaciones.Rows.Count > x; x++)
                {
                    dtPresentaciones.Rows[x]["Cantidad"] = DBNull.Value;
                    dtPresentaciones.Rows[x]["PesoActual"] = DBNull.Value;
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tdgbPeso_AfterColUpdate(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            SumaPeso();
            Habilitar();
        }

        private void tdgbPeso_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {
            switch (e.Col)
            {
                case 1:
                    string p1 = tdgbPeso.Columns["Peso1"].CellText(e.Row);
                    if (p1 == "")
                        e.CellStyle.Locked = true;
                    else if (p1 == "0")
                        e.CellStyle.BackColor = Color.LimeGreen;
                    else if (Convert.ToDecimal(p1) < pesoMinimo)
                        e.CellStyle.BackColor = Color.LightCoral;
                    else
                        e.CellStyle.Locked = false;
                    break;
                case 2:
                    string p2 = tdgbPeso.Columns["Peso2"].CellText(e.Row);
                    if (p2 == "")
                        e.CellStyle.Locked = true;
                    else if (p2 == "0")
                        e.CellStyle.BackColor = Color.LimeGreen;
                    else if (Convert.ToDecimal(p2) < pesoMinimo)
                        e.CellStyle.BackColor = Color.LightCoral;
                    else
                        e.CellStyle.Locked = false;
                    break;
                case 3:
                    string p3 = tdgbPeso.Columns["Peso3"].CellText(e.Row);
                    if (p3 == "")
                        e.CellStyle.Locked = true;
                    else if (p3 == "0")
                        e.CellStyle.BackColor = Color.LimeGreen;
                    else if (Convert.ToDecimal(p3) < pesoMinimo)
                        e.CellStyle.BackColor = Color.LightCoral;
                    else
                        e.CellStyle.Locked = false;
                    break;
                case 4:
                    string p4 = tdgbPeso.Columns["Peso4"].CellText(e.Row);
                    if (p4 == "")
                        e.CellStyle.Locked = true;
                    else if (p4 == "0")
                        e.CellStyle.BackColor = Color.LimeGreen;
                    else if (Convert.ToDecimal(p4) < pesoMinimo)
                        e.CellStyle.BackColor = Color.LightCoral;
                    else
                        e.CellStyle.Locked = false;
                    break;
                case 5:
                    string p5 = tdgbPeso.Columns["Peso5"].CellText(e.Row);
                    if (p5 == "")
                        e.CellStyle.Locked = true;
                    else if (p5 == "0")
                        e.CellStyle.BackColor = Color.LimeGreen;
                    else if (Convert.ToDecimal(p5) < pesoMinimo)
                        e.CellStyle.BackColor = Color.LightCoral;
                    else
                        e.CellStyle.Locked = false;
                    break;
                case 6:
                    string p6 = tdgbPeso.Columns["Peso6"].CellText(e.Row);
                    if (p6 == "")
                        e.CellStyle.Locked = true;
                    else if (p6 == "0")
                        e.CellStyle.BackColor = Color.LimeGreen;
                    else if (Convert.ToDecimal(p6) < pesoMinimo)
                        e.CellStyle.BackColor = Color.LightCoral;
                    else
                        e.CellStyle.Locked = false;
                    break;
                case 7:
                    string p7 = tdgbPeso.Columns["Peso7"].CellText(e.Row);
                    if (p7 == "")
                        e.CellStyle.Locked = true;
                    else if (p7 == "0")
                        e.CellStyle.BackColor = Color.LimeGreen;
                    else if (Convert.ToDecimal(p7) < pesoMinimo)
                        e.CellStyle.BackColor = Color.LightCoral;
                    else
                        e.CellStyle.Locked = false;
                    break;
                case 8:
                    string p8 = tdgbPeso.Columns["Peso8"].CellText(e.Row);
                    if (p8 == "")
                        e.CellStyle.Locked = true;
                    else if (p8 == "0")
                        e.CellStyle.BackColor = Color.LimeGreen;
                    else if (Convert.ToDecimal(p8) < pesoMinimo)
                        e.CellStyle.BackColor = Color.LightCoral;
                    else
                        e.CellStyle.Locked = false;
                    break;
                case 9:
                    string p9 = tdgbPeso.Columns["Peso9"].CellText(e.Row);
                    if (p9 == "")
                        e.CellStyle.Locked = true;
                    else if (p9 == "0")
                        e.CellStyle.BackColor = Color.LimeGreen;
                    else if (Convert.ToDecimal(p9) < pesoMinimo)
                        e.CellStyle.BackColor = Color.LightCoral;
                    else
                        e.CellStyle.Locked = false;
                    break;
                case 10:
                    string p10 = tdgbPeso.Columns["Peso10"].CellText(e.Row);
                    if (p10 == "")
                        e.CellStyle.Locked = true;
                    else if (p10 == "0")
                        e.CellStyle.BackColor = Color.LimeGreen;
                    else if (Convert.ToDecimal(p10) < pesoMinimo)
                        e.CellStyle.BackColor = Color.LightCoral;
                    else
                        e.CellStyle.Locked = false;
                    break;
            }
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            if (txtPeso.TextLength != 0)
                btnAgregar.Enabled = true;
            else
                btnAgregar.Enabled = false;
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            new TextFunctions().ValidaNumero(sender, e, txtPeso);
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.btnAgregar_Click(sender, e);
            }
        }

        private void ListPesoPavos_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            c1Combo.FillC1Combo(this.CbAlmacen, AppSettings.AlmacenPermisos, "Descripcion", "AlmacenID");
            if (AppSettings.SedeID == "002VU")
                CbAlmacen.SelectedValue = "GH002VUFRI";
            else
                CbAlmacen.SelectedValue = "GH001VUFRI";
            CbAlmacen.Enabled = false;

            c1Combo.FillC1Combo(cbGenerico, new CL_Vales().getProductosGenericos(), "NomGenerico", "Generico");            
            ConfigurarTabla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtPeso.Text != "" && txtPeso.Text !="." && txtPeso.Text != "0")
            {
                peso = Convert.ToDecimal(txtPeso.Text);
                rowTabla(peso);
                Habilitar();
            }
        }

        #endregion

        #region metodos definidos

        private void Limpiar()
        {
            if (items != 0)
            {
                dtPeso.Rows.Clear();
                SumaPeso();
                items = 0;
                linea = 1;
                lblCantidad.Text = "0";
                lblPesoTotal.Text = "0";
                txtPeso.Focus();
                btnRegistrar.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }

        private void Habilitar()
        {
            if (dtPeso.Compute("SUM(Peso1)", "").ToString() == "0")
            {
                btnRegistrar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            else
            {
                btnRegistrar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void SumaPeso()
        {
            tot = 0;
            for (int x = 1; x < 11; x++)
            {
                sum = dtPeso.Compute("SUM(Peso"+ x +")", "").ToString();
                if (sum != "")
                {
                    tdgbPeso.Columns["Peso" + x + ""].FooterText = Convert.ToDecimal(sum).ToString("N2");
                    tot += Convert.ToDecimal(sum);
                }
                else
                {
                    tdgbPeso.Columns["Peso" + x + ""].FooterText = "0";
                }
            }
            lblPesoTotal.Text = tot.ToString("N2");
        }

        private void ConfigurarTabla()
        {
            dtPeso = new DataTable();
            dtPeso.Columns.Add("Nro", typeof(int));
            dtPeso.Columns.Add("Peso1", typeof(decimal));
            dtPeso.Columns.Add("Peso2", typeof(decimal));
            dtPeso.Columns.Add("Peso3", typeof(decimal));
            dtPeso.Columns.Add("Peso4", typeof(decimal));
            dtPeso.Columns.Add("Peso5", typeof(decimal));
            dtPeso.Columns.Add("Peso6", typeof(decimal));
            dtPeso.Columns.Add("Peso7", typeof(decimal));
            dtPeso.Columns.Add("Peso8", typeof(decimal));
            dtPeso.Columns.Add("Peso9", typeof(decimal));
            dtPeso.Columns.Add("Peso10", typeof(decimal));
            
            tdgbPeso.SetDataBinding(dtPeso, "", true);

            for (int x = 1; x <= 10; x++)
            {
                tdgbPeso.Columns["Peso" + x + ""].Editor = c1NumericEdit1;
            }
        }

        private void rowTabla(decimal peso)
        {
            if (dtPeso.Rows.Count <= max)
            {
                DataRow row = dtPeso.NewRow();
                row["Nro"] = linea;
                row["Peso1"] = peso;
                dtPeso.Rows.Add(row);
                items++;
                linea++;
            }
            else
            {
                if (i <= max)
                {
                    if (x < 11)
                    {
                        dtPeso.Rows[i][x] = peso;
                        i++;
                        items++;
                    }
                    else
                    {
                        MessageBox.Show("Registre los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        txtPeso.Clear();
                        btnRegistrar.Select();
                        return;
                    }
                }
                else
                {
                    i = 0;
                    x++;
                    if (x < 11)
                    {
                        dtPeso.Rows[i][x] = peso;
                        items++;
                    }
                    else
                    {
                        MessageBox.Show("Registre los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        btnRegistrar.Select();
                        txtPeso.Clear();
                        return;
                    }

                }
            }

            SumaPeso();
            txtPeso.Focus();
            txtPeso.Clear();
            lblCantidad.Text = items.ToString();
        }

        #endregion    

   
    }
}

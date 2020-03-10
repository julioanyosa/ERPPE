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
using Halley.Configuracion;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas.VentasPavo
{
    public partial class ListVales : UITemplateAccess
    {
        #region declaracion de variables

        DataTable dtPresentaciones;
       

        #endregion

        #region constructor

        public ListVales()
        {
            InitializeComponent();
        }

        #endregion

        #region eventos de los controles

        private void ListVales_ExportClick()
        {
            try
            {
                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;
                    string ruta = string.Concat(f.SelectedPath, @"\", "VALES GENERADOS.xls");
                    new Office().DoExcell(ruta, dtPresentaciones, "TOTAL VALES :  " + lblTotales.Text);
                    string _nM = string.Format(_msg, ruta);
                    MessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;

            }
        }

        private void ListVales_RefreshClick()
        {
            CalcularNumeros();
        }

       
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DataTable dt = new DataTable();
                dt = new CL_Vales().getComprobanteNavidenho();
                dt.Columns.Add("Inicial",typeof(int));
                dt.Columns.Add("Final", typeof(int));

                foreach (DataRow row in dtPresentaciones.Rows)
                {
                    if (row["Total"] == dt.Compute("SUM(Cantidad)", "ProductoID='" + row["Codigo"] + "'"))
                    {
                        MessageBox.Show("Se han agregado mas pedidos,actualize", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                        return;
                    }
                }

                foreach (DataRow row in dtPresentaciones.Rows)
                {
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "ProductoID='" + row["Codigo"].ToString()  + "'";

                    int ini = Convert.ToInt32(row["Inicial"]);
                    
                    int posicion = 0;
                    foreach (DataRowView fila in dv)
                    {
                        int cant = Convert.ToInt32(fila["Cantidad"]);
                        
                        dv[posicion]["Inicial"] = ini;
                        ini = ini + cant;
                        dv[posicion]["Final"] = ini;
                        posicion++;
                    } 
                }

                DataTable dtVale = new DataTable("Vales");
                dtVale.Columns.Add("NumVale", typeof(int));
                dtVale.Columns.Add("NumComprobante", typeof(string));
                dtVale.Columns.Add("ProductoID", typeof(string));

                UniqueConstraint PrimaryKey = new UniqueConstraint(dtVale.Columns["NumVale"], true);
                dtVale.Constraints.Add(PrimaryKey);

                foreach (DataRow row in dt.Rows)
                {
                    int fin = Convert.ToInt32(row["Final"]);

                    for (int ini = Convert.ToInt32(row["Inicial"]);ini<fin;ini++)
                    {
                        DataRow fila = dtVale.NewRow();
                        fila["NumVale"] = ini;
                        fila["NumComprobante"] = row["NumComprobante"];
                        fila["ProductoID"] = row["ProductoID"];
                        dtVale.Rows.Add(fila);
                    }
                }

                DialogResult Mensaje = MessageBox.Show("¿Está seguro de generar todo ahora?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Mensaje == DialogResult.Yes)
                {
                   // new CL_Vales().Insert(AppSettings.UserID, dtVale);
                    MessageBox.Show("Los numeros de vales se genero correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CalcularNumeros();
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void ListPresentaciones_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            CalcularNumeros();
        }

        #endregion

        #region metodos definidos

        private void Habilitar(bool valor)
        {
            lbl01.Visible = valor;
            lbl02.Visible = valor;
            lblFecha.Visible = valor;
            lblUsuario.Visible = valor;
            lblMensaje.Visible = valor;
        }

        private void CalcularNumeros()
        {
            try
            {
                int tot;
                int  f=0;

                dtPresentaciones = new DataTable();
                dtPresentaciones.Columns.Add("Codigo", typeof(string));
                dtPresentaciones.Columns.Add("Producto", typeof(string));
                dtPresentaciones.Columns.Add("UM", typeof(string));
                dtPresentaciones.Columns.Add("Total", typeof(int));
                dtPresentaciones.Columns.Add("Inicial", typeof(int)).DefaultValue = 0;
                dtPresentaciones.Columns.Add("Final", typeof(int)).DefaultValue = 0;

                DataTable dt = new DataTable();
                dt = new CL_Producto().getPresentaciones();

                foreach (DataRow row in dt.Rows)
                {
                    DataRow fila = dtPresentaciones.NewRow();
                    fila["Codigo"] = row["ProductoID"];
                    fila["Producto"] = row["NomProducto"];
                    fila["UM"] = row["UnidadMedidaID"];
                    fila["Total"] = row["Total"];

                    if (fila["Total"].ToString() != "0")
                    {
                        fila["Inicial"] = f + 1;
                        f = f + Convert.ToInt32(row["Total"]);
                        fila["Final"] = f;
                    }

                    if (row["Usuario"].ToString() == "")
                    {
                        btnGenerar.Enabled = true;
                        Habilitar(false);
                    }
                    else
                    {
                        lblUsuario.Text = row["Usuario"].ToString();
                        lblFecha.Text = row["Fecha"].ToString();
                        Habilitar(true);
                        btnGenerar.Enabled = false;
                    }

                    dtPresentaciones.Rows.Add(fila);
                }

                tot = Convert.ToInt32(dtPresentaciones.Compute("SUM(Total)", ""));
                lblTotales.Text = tot.ToString("N2");

                tdbgPresentaciones.SetDataBinding(dtPresentaciones, "", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion          
    }
}

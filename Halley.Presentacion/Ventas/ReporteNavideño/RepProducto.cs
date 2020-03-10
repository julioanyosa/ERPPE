using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.Configuracion;

namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    public partial class RepProducto : Form
    {
        #region propiedades

        public string NumComprobante { get; set; }
        public string Cliente { get; set; }

        #endregion

        #region variables globales

        DataTable dt;
        DataTable dtDetalle;
        DataTable dtDetVales;

        bool asignacion;
        bool asig;
        int Id=0;
        int NumVale;
        string ProductoId;
        string operacion;

        #endregion

        #region constructor

        public RepProducto()
        {
            InitializeComponent();
        }

        #endregion

        #region eventos de los controles

        private void tdbgdetalle_AfterColUpdate(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            try
            {
                if (operacion.Equals("I"))
                {
                    if (tdbgdetalle.Columns["NumVale"].Value != DBNull.Value)
                    {
                        Id = Convert.ToInt32(tdbgdetalle.Columns["ID"].Value);
                        NumVale = Convert.ToInt32(tdbgdetalle.Columns["NumVale"].Value);
                        ProductoId = tdbgdetalle.Columns["ProductoID"].Value.ToString();
                        asig = Convert.ToBoolean(tdbgdetalle.Columns["Asignacion"].Value);

                        DataView dv = new DataView(dtDetVales);
                        dv.RowFilter = "ID='" + Id + "'";
                        if (dv.Count != 0)
                        {
                            dv[0]["NumVale"] = NumVale;
                            dv[0]["Asignacion"] = asig;
                        }
                        else
                        {
                            dtDetVales.Rows.Add(Id, ProductoId, NumVale, asig);
                        }
                    }
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                DataView dv = new DataView(dtDetalle);
                dv.RowFilter = "ID='" + Id + "'";
                dv[0]["NumVale"] = DBNull.Value;
                dv[0]["Asignacion"] = false;
            }
        }

        private void tdbgdetalle_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {
            asignacion = Convert.ToBoolean(tdbgdetalle.Columns["Asignacion"].CellText(e.Row));
     
            if (asignacion == true){
                e.CellStyle.Locked = true;
            }else{
                e.CellStyle.Locked = false;
            }
        }

        private void RepProducto_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = new CL_Vales().getAsignacionPorComprobante(NumComprobante);

            dt.Columns["Asignacion"].ReadOnly = false;

            if (dt.Rows[0]["NumVale"] == DBNull.Value)
            {              
                dtDetalle = new DataTable();
                dtDetalle.Columns.Add("ID",typeof(int));
                dtDetalle.Columns.Add("ProductoID", typeof(string));
                dtDetalle.Columns.Add("NomProducto", typeof(string));
                dtDetalle.Columns.Add("NumVale", typeof(int));
                dtDetalle.Columns.Add("Asignacion",typeof(bool));
                dtDetalle.Columns.Add("FechaAsignacion",typeof(DateTime));
                
                foreach(DataRow row in dt.Rows)
                {
                    int cant=Convert.ToInt32(row["Cantidad"]);
                    for (int x = 0; x <cant ; x++)
                    {
                        DataRow fila = dtDetalle.NewRow();
                        fila["ID"] = Id++;
                        fila["ProductoID"] = row["ProductoID"];
                        fila["NomProducto"] = row["NomProducto"];
                        fila["NumVale"] = DBNull.Value;
                        fila["Asignacion"] = row["Asignacion"];
                        dtDetalle.Rows.Add(fila);
                    }
                }
                tdbgdetalle.SetDataBinding(dtDetalle, "", true);
                tdbgdetalle.Columns["NumVale"].Editor = this.c1NumericEdit1;
                tdbgdetalle.Splits[0].DisplayColumns["NumVale"].Style.Locked = false;
                Configurar();
                operacion = "I";
            }
            else
            {        
                tdbgdetalle.SetDataBinding(dt, "", true);
                tdbgdetalle.Splits[0].DisplayColumns["NumVale"].Style.Locked = true;
                operacion = "A";
            }
            lblCliente.Text = Cliente;
            lblComprobante.Text = NumComprobante;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (operacion.Equals("A"))
                Registrar(dt, operacion);
            else
                Registrar(dtDetalle, operacion);

        }

        #endregion

        #region metodos definidos

        private void Registrar(DataTable dt,string operacion)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DataView dv = new DataView(dt);
                if (operacion.Equals("A"))
                {
                    dv.RowFilter = "Asignacion='true' and FechaAsignacion IS NULL";

                    if (dv.Count == 0)
                    {
                        MessageBox.Show("Realize una operación", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                        return;
                    }
                }
                else
                {
                    if (dv.Count != dtDetVales.Rows.Count)
                    {
                        MessageBox.Show("Registre todos los vales", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                        return;
                    }
                }
                
                    DataTable dtOperacion = new DataTable("Asignacion");
                    dtOperacion.Columns.Add("ProductoID", typeof(string));
                    dtOperacion.Columns.Add("NumVale", typeof(int));
                    dtOperacion.Columns.Add("Asignacion", typeof(bool));

                    foreach (DataRowView row in dv)
                    {
                        DataRow fila = dtOperacion.NewRow();
                        fila["ProductoID"] = row["ProductoID"];
                        fila["NumVale"] = row["NumVale"];
                        fila["Asignacion"] = row["Asignacion"];
                        dtOperacion.Rows.Add(fila);
                    }

                    new CL_Vales().UpdateAsignacion(NumComprobante,operacion,AppSettings.UserID,dtOperacion);
                    MessageBox.Show("Registros actualizado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
               
                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Existen Numeros de vales ya registrados,verique la pantalla Registro de Vales", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void Configurar()
        {
            dtDetVales = new DataTable();
            dtDetVales.Columns.Add("ID", typeof(int));
            dtDetVales.Columns.Add("ProductoID", typeof(string));
            dtDetVales.Columns.Add("NumVale", typeof(int));
            dtDetVales.Columns.Add("Asignacion", typeof(bool));
            dtDetVales.Columns["ID"].Unique = true;
            dtDetVales.Columns["NumVale"].Unique = true;
        }

        #endregion
    }
}

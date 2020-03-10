using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

namespace Halley.Galpon
{
    public partial class ListGalpon : Form
    {
        #region Declaracion de variables
        DataTable dt;

        decimal Tara = 0, Bruto = 0, Neto = 0;
        int Cantidad = 0;
        #endregion

        #region Constructor
        public ListGalpon()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos denifidos

        private void Cargar()
        {
            dt = new DataTable();

            dt.Columns.Add("Peso", typeof(string));
            dt.Columns.Add("NroJabas", typeof(string));
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("UsuarioID", typeof(string));
            dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("AlmacenID", typeof(string));            
            dt.Columns.Add("NomAlmacen", typeof(string));
            dt.Columns.Add("Pesador", typeof(string));
            dt.Columns.Add("Galponero", typeof(string));
        }

        private void ExportarExcel(string _fileName)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Microsoft.Office.Interop.Excel._Application xlApl = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook xlLibro;
                    Microsoft.Office.Interop.Excel._Worksheet xlHoja;

                    xlLibro = xlApl.Workbooks.Add();
                    xlHoja = (Microsoft.Office.Interop.Excel._Worksheet)xlLibro.ActiveSheet;

                    for (int x = 0, y = 1; x < dt.Columns.Count; x++, y++)
                    {
                        xlHoja.Cells[1, y] = dt.Columns[x].ToString();
                    }

                    int row = 2;
                    foreach (DataRow fila in dt.Rows)
                    {
                        xlHoja.Cells[row, 1] = fila["Peso"];
                        xlHoja.Cells[row, 2] = fila["NroJabas"];
                        xlHoja.Cells[row, 3] = fila["Tipo"];
                        xlHoja.Cells[row, 4] = fila["UsuarioID"];
                        xlHoja.Cells[row, 5] = fila["Usuario"];
                        xlHoja.Cells[row, 6] = fila["AlmacenID"];
                        xlHoja.Cells[row, 7] = fila["NomAlmacen"];
                        xlHoja.Cells[row, 8] = fila["Pesador"];
                        xlHoja.Cells[row, 9] = fila["Galponero"];
                        row++;
                    }
                    if (!System.IO.File.Exists(f.SelectedPath + @"\" + _fileName + ".xls"))
                    {
                        xlApl.ActiveWorkbook.ProtectSharing(f.SelectedPath + @"\" + _fileName + ".xls", "12345", "123456", true);
                        string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                        xlLibro.Close();
                        xlApl.Quit();
                        MessageBox.Show(_nM, "Generar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        string msg = "El archivo existe en la siguiente ubicación.\n{0}";
                        string _nM = string.Format(msg, f.SelectedPath + @"\" + _fileName + ".xls");
                        MessageBox.Show(_nM, "Verique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void Limpiar()
        {
            txtBruto.Clear();
            txtNeto.Clear();
            txtNro.Clear();
            txtTara.Clear();
            dt.Rows.Clear();
        }

        private void AgregarLinea(string Peso, string NroJabas, string tipo,string UsuarioID,
                                  string Usuario, string AlmacenID,string NomAlmacen, string Pesador, string Galponero)
        {
            DataRow linea = dt.NewRow();
            linea["Peso"] = Peso;
            linea["NroJabas"] = NroJabas;
            linea["Tipo"] = tipo;
            linea["UsuarioID"] = UsuarioID;
            linea["Usuario"] = Usuario;
            linea["AlmacenID"] = AlmacenID;
            linea["NomAlmacen"] = NomAlmacen;
            linea["Pesador"] = Pesador;
            linea["Galponero"] = Galponero;
            dt.Rows.Add(linea);
        }

        

        #endregion

        #region Eventos de los controles

        private void c1Button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void ListGalpon_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Conexion.Usuario;
            new Utilitario().FillC1Combo(cbGalpon, Conexion.dtGalpon, "DesAlmacen", "IDAlmacen");
            Cargar();
        }

        private void ListGalpon_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void BtnBalanza_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            Balanza ObjBalanza = new Balanza();
            ObjBalanza.SerialPortBalanza = "COM1";
            if (RbPeso.Checked == true)
            {
                ObjBalanza.Titulo = "Peso bruto";
                ObjBalanza.VerCantidad = true;
            }
            else if (RbTara.Checked == true)
            {
                ObjBalanza.Titulo = "Peso Tara";
                ObjBalanza.VerCantidad = false;
            }
            if (ObjBalanza.ShowDialog() == DialogResult.OK)
            {
                if (RbTara.Checked)
                {
                    if (txtGalponero.Text != "" & txtUsuario.Text != "")
                    {
                        Tara += ObjBalanza.Peso;
                        txtTara.Text = Tara.ToString("N2");
                        AgregarLinea(ObjBalanza.Peso.ToString(), "0", "T", Conexion.UsuarioId, Conexion.Usuario, cbGalpon.SelectedValue.ToString(), cbGalpon.SelectedText, txtUsuario.Text, txtGalponero.Text);
                    }
                    else
                    {
                        if (txtGalponero.Text =="") ErrProvider.SetError(txtGalponero, "Debe ingresar el nombre completo del galponero");
                        if (txtUsuario.Text == "") ErrProvider.SetError(txtUsuario, "Debe ingresar el nombre completo del Pesador");
                    }
                }
                else
                {
                    if (txtGalponero.Text != "" & txtUsuario.Text != "")
                    {
                        Bruto += ObjBalanza.Peso;
                        Cantidad += ObjBalanza.Cantidad;

                        txtBruto.Text = Bruto.ToString("N2");
                        txtNro.Text = Cantidad.ToString();
                        AgregarLinea(ObjBalanza.Peso.ToString(), ObjBalanza.Cantidad.ToString(), "P", Conexion.UsuarioId, Conexion.Usuario, cbGalpon.SelectedValue.ToString(), cbGalpon.SelectedText, txtUsuario.Text, txtGalponero.Text);
                    }
                    else
                    {
                        if (txtGalponero.Text == "") ErrProvider.SetError(txtGalponero, "Debe ingresar el nombre completo del galponero");
                        if (txtUsuario.Text == "") ErrProvider.SetError(txtUsuario, "Debe ingresar el nombre completo del Pesador");
                    }
                }
                Neto = Bruto - Tara;
                if (Neto <= 0)
                    txtNeto.Text = "0";
                else
                    txtNeto.Text = Neto.ToString("N2");
            }
        }

        private void RbTara_CheckedChanged(object sender, EventArgs e)
        {
            if (RbTara.Checked == true)
            {
                RbTara.BackColor = Color.Black;
                RbPeso.BackColor = Color.White;
            }
            if (RbPeso.Checked == true)
            {
                RbPeso.BackColor = Color.Black;
                RbTara.BackColor = Color.White;
            }
        }

        private void RbPeso_CheckedChanged(object sender, EventArgs e)
        {
            if (RbTara.Checked == true)
            {
                RbTara.BackColor = Color.Black;
                RbPeso.BackColor = Color.White;
            }
            if (RbPeso.Checked == true)
            {
                RbPeso.BackColor = Color.Black;
                RbTara.BackColor = Color.White;
            }
        }
    
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el nombre del Pesador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }
            else if (txtGalponero.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el nombre del Galponero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGalponero.Focus();
                return;
            }
            else 
            {
                if (dt.Rows.Count != 0)
                {
                    string fileName = Conexion.Usuario + DateTime.Now.ToString("dd-MM-yyyy") + "-" + DateTime.Now.Hour.ToString() + "h" + DateTime.Now.Minute.ToString() + "min" + DateTime.Now.Second.ToString() + "seg";
                    ExportarExcel(fileName);
                }
            }
        }

        

        #endregion
    }
}

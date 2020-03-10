using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1TrueDBGrid;
using Halley.CapaLogica;
using Halley.Configuracion;
using Halley.Accesos;
using RRV.Seguridad;
using C1.Win.C1FlexGrid;

namespace Halley.Presentacion
{
    public partial class UITemplateAccess : UserControl
    {
        //Variables para definir los accesos
        //***********************************************
        bool _ACTIVO = false;
        bool _LECTURA = false;
        bool _ADICION = false;
        bool _ACTUALIZACION = false;
        bool _ELIMINACION = false;
        bool _IMPRESION = false;
        //***********************************************
        

        string _records = "{0} de {1}";
        //Declaracion de delegados para controlar los botones       
        public delegate void delegateNewClick();
        public delegate void delegateSaveClick();
        public delegate void delegateEditClick();
        public delegate void delegateUndoClick();
        public delegate void delegateDeleteClick();
        public delegate void delegatePrintClick();
        public delegate void delegateAddClick();
        public delegate void delegateRemoveClick();
        public delegate void delegateGetValue(string value);
        public delegate void delegateMostrar(string value);//recien agregado para mostra los datos

        public delegate void delegateRefreshClick();
        public delegate void delegateExportExcel();

        //Declaracion de eventos       
        public event delegateNewClick NewClick;
        public event delegateSaveClick SaveClick;
        public event delegateEditClick EditClick;
        public event delegateUndoClick UndoClick;
        public event delegateDeleteClick DeleteClick;
        public event delegatePrintClick PrintClick;
        public event delegateAddClick AddClick;
        public event delegateRemoveClick RemoveClick;
        public event delegateGetValue GetValue;
        public event delegateMostrar VerDatos;//recien agregado para mostra los datos

        public event delegateRefreshClick RefreshClick;
        public event delegateExportExcel ExportClick;



        C1FlexGrid _flex = new C1FlexGrid();

        public C1FlexGrid flex
        {
            get { return _flex; }
            set { _flex = value; }
        }

        C1TrueDBGrid _grid = new C1TrueDBGrid();

        public C1TrueDBGrid Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }

        DataTable _data;

        public DataTable Data
        {
            get { return _data; }
            set { _data = value; }
        }

        DataTable dtTemp = new DataTable();

        string _fileName = string.Empty;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        int _Valor = 0;

        public int Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }
           
        public void InitializeCounter()
        {
            this.txtRecord.Text = string.Format(_records, this.Grid.Bookmark + 1, this.Grid.RowCount.ToString());
        }
        public void Iniciar(DataTable dt)
        {
            this.txtRecord.Text = dt.Rows.Count.ToString();
            btnLast.Enabled = false;
            btnFirts.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            
        }


        public void Fields()
        {
            //Mostar las columnas de la grilla
            this.cboField.Items.Clear();
            for (int i = 0; i < _grid.Columns.Count; i++)
            {
                if (_grid.Splits[0].DisplayColumns[i].Visible == true)
                {
                    this.cboField.Items.Add(_grid.Splits[0].DisplayColumns[i].Name);
                }
            }

            //Mostar las columnas de la grilla
            this.cboWhere.Items.Clear();
            for (int i = 0; i < _grid.Columns.Count; i++)
            {
                if (_grid.Splits[0].DisplayColumns[i].Visible == true)
                {
                    this.cboWhere.Items.Add(_grid.Splits[0].DisplayColumns[i].DataColumn.DataField.ToString());
                }
            }
        }

        private void btnFirts_Click(object sender, EventArgs e)
        {
            this.Grid.MoveFirst();
            this.txtRecord.Text = string.Format(_records, this.Grid.Bookmark + 1, this.Grid.RowCount.ToString());
            VerDatos(Grid.Columns[0].Value.ToString());
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Grid.MovePrevious();
            this.txtRecord.Text = string.Format(_records, this.Grid.Bookmark + 1, this.Grid.RowCount.ToString());
            VerDatos(Grid.Columns[0].Value.ToString());
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Grid.MoveNext();
            this.txtRecord.Text = string.Format(_records, this.Grid.Bookmark + 1, this.Grid.RowCount.ToString());
            VerDatos(Grid.Columns[0].Value.ToString());
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.Grid.MoveLast();
            
            this.txtRecord.Text = string.Format(_records, this.Grid.Bookmark + 1, this.Grid.RowCount.ToString());
            VerDatos(Grid.Columns[0].Value.ToString());
        }

        

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_ADICION == false)
            {
                MessageBox.Show("No cuenta con el permiso de agregar registros.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (NewClick != null)
                NewClick();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_ADICION == false)
            {
                MessageBox.Show("No cuenta con el permiso de agregar registros.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (SaveClick != null)
                SaveClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_ACTUALIZACION == false)
            {
                MessageBox.Show("No cuenta con el permiso de modificar registros.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (EditClick != null)
                EditClick();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (UndoClick != null)
                UndoClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_ELIMINACION == false)
            {
                MessageBox.Show("No cuenta con el permiso de eliminar registros.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DeleteClick != null)
                DeleteClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (RefreshClick != null)
                RefreshClick();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_IMPRESION == false)
            {
                MessageBox.Show("No cuenta con el permiso de imprimir registros.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (PrintClick != null)
                PrintClick();
        
        }

        private void exportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExportExcel_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddClick != null)
                AddClick();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (RemoveClick != null)
                RemoveClick();
        }

        public UITemplateAccess()
        {
            InitializeComponent();
            if (AppSettings.GetConnectionString != null)
            {
                Libreria_Users objUser = new Libreria_Users(AppSettings.GetConnectionString);
                AppSettings.AssignedPermission = objUser.Obtener_PermisoAcceso(AppSettings.Usuario, AppSettings.Perfil);
            }
            this.txtRecord.Text = string.Format(_records, this.Grid.Bookmark + 1, this.Grid.RowCount.ToString());
        }

        private void UITemplateAccess_Load(object sender, EventArgs e)
        {
            this.dtpSearch.Visible = false;
            this.Accesos(((Halley.Presentacion.UITemplateAccess)(sender)).ToString());
           
        }

        private void cboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboWhere.SelectedIndex = this.cboField.SelectedIndex;
            if (_data != null)
            {
                if (_data.Columns[this.cboWhere.Text].DataType.ToString() == "System.DateTime")
                {
                    //int y = dtpSearch.Location.Y+3;
                    this.txtSearch.Visible = false;
                    this.dtpSearch.Visible = true;
                    this.dtpSearch.Location = new Point(650, (this.Height - 23));
                    //MessageBox.Show(dtpSearch.Location.X.ToString() + "," + this.dtpSearch.Location.Y.ToString());
                }
                else
                {
                    this.dtpSearch.Visible = false;
                    this.txtSearch.Visible = true;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_data != null)
                {
                    DataView dv = new DataView(_data);
                    switch (_data.Columns[this.cboWhere.Text].DataType.ToString())
                    {
                        case "System.String":
                            dv.RowFilter = this.cboWhere.Text + " Like '" + this.txtSearch.Text + "%'";
                            break;
                        case "System.Decimal":
                            if (this.txtSearch.Text.Length != 0)
                            {
                                dv.RowFilter = "Convert(" + this.cboWhere.Text + ",'System.Decimal') = " + Convert.ToDecimal(this.txtSearch.Text);
                            }
                            break;
                        case "System.Boolean":
                            dv.RowFilter = "Convert(" + this.cboWhere.Text + ",'System.String') Like '" + this.txtSearch.Text + "%'";
                            break;
                        case "System.Int32":
                            if (this.txtSearch.Text.Length != 0)
                            {
                                dv.RowFilter = "Convert(" + this.cboWhere.Text + ",'System.Int32') = " + Convert.ToInt32(this.txtSearch.Text);
                            }
                            break;
                        default:
                            dv.RowFilter = this.cboWhere.Text + " Like '" + this.txtSearch.Text + "%'";
                            break;
                    }
                    Grid.SetDataBinding(dv, "", true);
                    dtTemp = dv.ToTable();
                    InitializeCounter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dtpSearch_ValueChanged(object sender, EventArgs e)
        {
            try               
            {
                if (_data != null)
                {
                    DataView dv = new DataView(_data);
                    if (_data.Columns[this.cboWhere.Text].DataType.ToString() == "System.DateTime")
                    {
                        dv.RowFilter = this.cboWhere.Text + "=#" + this.dtpSearch.Value.ToShortDateString() + "#";
                    }
                    Grid.SetDataBinding(dv, "", true);
                    dtTemp = dv.ToTable();
                    InitializeCounter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

      

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {

                if (Valor == 1)
                {
                    string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                    FolderBrowserDialog f = new FolderBrowserDialog();
                    f.ShowDialog(this);
                    if (f.SelectedPath != "")
                    {
                        Cursor = Cursors.AppStarting;
                        Grid.ExportToExcel(f.SelectedPath + @"\" + _fileName + ".xls");
                        string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                        MessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Cursor = Cursors.Default;
                }
                else if (Valor == 2)
                {
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.DefaultExt = "xls";
                    dlg.FileName = "*.xls";
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;

                    // save grid as sheet in the book
                    FileFlags flags = FileFlags.IncludeFixedCells;
                    this.flex.SaveGrid(dlg.FileName, FileFormatEnum.Excel, flags);
                    MessageBox.Show("Se genero el archivo excel de forma satisfactoria.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.InnerException.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Modulo para la seguridad y permisos de los botones de mantenimiento
        void Accesos(string assembly)
        {
            DataView dv = new DataView(AppSettings.AssignedPermission);
            dv.RowFilter = "Clase='" + assembly + "'";

            foreach (DataRowView drv in dv)
            {
                _ACTIVO = Convert.ToBoolean(drv["Activo"]);
                _LECTURA = Convert.ToBoolean(drv["Lectura"]);
                _ADICION = Convert.ToBoolean(drv["Adicion"]);
                _ACTUALIZACION = Convert.ToBoolean(drv["Actualizacion"]);
                _ELIMINACION = Convert.ToBoolean(drv["Eliminacion"]);
                _IMPRESION = Convert.ToBoolean(drv["Impresion"]);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GetValue != null)
                    if (dtTemp.Rows.Count > 0)
                        GetValue(dtTemp.Rows[0][0].ToString());
            }
        }

        public void ocultarToolStrip()
        {
            this.toolStrip1.Visible = false;
        }

        #region "Controlar el menu emergente para las opciones de la barra de herramientas ..."


        private void actualizarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (RefreshClick != null)
                RefreshClick();
        }

        #endregion

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ExportClick != null)
                ExportClick();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PrintClick != null)
                PrintClick();
        }
      
    }
}

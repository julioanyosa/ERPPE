using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;

namespace Halley.Presentacion.Almacen.Reportes
{
    public partial class Rep_Producto : Form
    {
        #region declaracion de Variables

        DataTable dt;

        string _CodAlmacen;

        public string CodAlmacen
        {
            get { return _CodAlmacen; }
            set { _CodAlmacen = value; }
        }

        #endregion

        #region Constructor

        public Rep_Producto()
        {
            InitializeComponent();
            GetProducto();
        }

        #endregion

        #region Eventos de los controle

        private void C1TdbgProducto_DoubleClick(object sender, EventArgs e)
        {
            CodAlmacen = C1TdbgProducto.Columns["AlmacenID"].Value.ToString();
            this.DialogResult = DialogResult.OK;

        }

        #endregion

        #region Metodos definidos

        void GetProducto()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dt = new DataTable();
                dt = new CL_Almacen().GetProductoAlmacenCadena(AppSettings.CadenaAlmacen,"","A");

                if (dt.Rows.Count == 0)
                {
                    Cursor = Cursors.Default;
                    this.C1TdbgProducto.SetDataBinding(null, "", true);
                    return;
                }

                C1TdbgProducto.SetDataBinding(dt, "", true);
                
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}

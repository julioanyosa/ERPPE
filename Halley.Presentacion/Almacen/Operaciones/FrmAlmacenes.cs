using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class FrmAlmacenes : Form
    {
        #region Propiedades
        public string _Alias;
        public string _ProductoID;
        public string _EmpresaSede;
        public decimal _StockDisponible;
        public string _AlmacenID;

        public string Alias
        {
            get { return _Alias; }
            set { _Alias = value; }
        }
        public string ProductoID
        {
            get { return _ProductoID; }
            set { _ProductoID = value; }
        }
        public string EmpresaSede
        {
            get { return _EmpresaSede; }
            set { _EmpresaSede = value; }
        }
        public decimal StockDisponible
        {
            get { return _StockDisponible; }
            set { _StockDisponible = value; }
        }
        public string AlmacenID
        {
            get { return _AlmacenID; }
            set { _AlmacenID = value; }
        }

        #endregion
        #region Variables
        CL_Almacen ObjCL_Almacen = new CL_Almacen();
        #endregion
        public FrmAlmacenes()
        {
            InitializeComponent();
        }

        private void FrmDespachos_Load(object sender, EventArgs e)
        {
            //Stock Por productos
            DataTable DtStockProducto = new DataTable();
            DtStockProducto = ObjCL_Almacen.GetStockProducto(ProductoID, EmpresaSede);
            LstStocks.HoldFields();
            LstStocks.DataSource = DtStockProducto;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSeleccionarAlmacen_Click(object sender, EventArgs e)
        {
            if (LstStocks.SelectedIndex != -1)
            {
                StockDisponible = Convert.ToDecimal(LstStocks.Columns["StockDisponible"].Value);
                AlmacenID = LstStocks.Columns["AlmacenID"].Value.ToString();
                Close();
            }
            else
                MessageBox.Show("Debe seleccionar un almacen.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LstStocks_DoubleClick(object sender, EventArgs e)
        {
            BtnSeleccionarAlmacen_Click(null, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Compras;
using Halley.Configuracion;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class FrmBuscarOC : Form
    {
        string _NumOrdenCompra;

        public string NumOrdenCompra
        {
            get { return _NumOrdenCompra; }
            set { _NumOrdenCompra = value; }
        }

        CL_OrdenCompra ObjCL_OrdenCompra = new CL_OrdenCompra();

        public FrmBuscarOC()
        {
            InitializeComponent();
        }

        private void BtnBuscarOrdenCompra_Click(object sender, EventArgs e)
        {
            if (TxtOrdenCompra.Text != "")
            {
                DataTable Dt = new DataTable();
                Dt = ObjCL_OrdenCompra.GetOCPorProductos(TxtOrdenCompra.Text, AppSettings.EmpresaID + AppSettings.SedeID);
                TdgListaProductos.SetDataBinding(Dt, "", true);
            }
        }

        private void TdgListaProductos_DoubleClick(object sender, EventArgs e)
        {
            if (TdgListaProductos.RowCount > 0)
            {
                NumOrdenCompra = TdgListaProductos.Columns["NumOrdenCompra"].Value.ToString();
                this.Close();
            }
            else
                NumOrdenCompra = "";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            NumOrdenCompra = "";
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class SeleccionarMarcas : Form
    {
        public SeleccionarMarcas()
        {
            InitializeComponent();
        }
        #region propiedades
        DataTable _DtDatos;

        public DataTable DtDatos
        {
            get { return _DtDatos; }
            set { _DtDatos = value; }
        }

        #endregion

        private void SeleccionarMarcas_Load(object sender, EventArgs e)
        {
            TdgMarcas.SetDataBinding(DtDatos,"",true);
        }

        private void TdgMarcas_DoubleClick(object sender, EventArgs e)
        {
            //crear tabla para guardar lo filtrado
            DataTable DtAlmacenesF = new DataTable();
            DtAlmacenesF.Columns.Add("SAlmacenID", typeof(string));
            DtAlmacenesF.Columns.Add("NumOrdenCompra", typeof(string));
            DtAlmacenesF.Columns.Add("IDProveedor", typeof(int));
            DtAlmacenesF.Columns.Add("RazonSocial", typeof(string));
            DtAlmacenesF.Columns.Add("FacturaProveedor", typeof(string));
            DtAlmacenesF.Columns.Add("CantidadRecibidaOC", typeof(decimal));
            DtAlmacenesF.Columns.Add("SAlmacen", typeof(string));
            DtAlmacenesF.Columns.Add("StockActual", typeof(decimal));
            DtAlmacenesF.Columns.Add("StockDisponible", typeof(decimal));
            DtAlmacenesF.Columns.Add("SProductoID", typeof(string));
            DtAlmacenesF.Columns.Add("SNomMarca", typeof(string));


            DataRow DR = DtAlmacenesF.NewRow();
            DR["SAlmacenID"] = this.TdgMarcas.Columns["SAlmacenID"].Value;
            DR["NumOrdenCompra"] = this.TdgMarcas.Columns["NumOrdenCompra"].Value;
            DR["IDProveedor"] = this.TdgMarcas.Columns["IDProveedor"].Value;
            DR["RazonSocial"] = this.TdgMarcas.Columns["RazonSocial"].Value;
            DR["FacturaProveedor"] = this.TdgMarcas.Columns["FacturaProveedor"].Value;
            DR["CantidadRecibidaOC"] = this.TdgMarcas.Columns["CantidadRecibidaOC"].Value;
            DR["SAlmacen"] = this.TdgMarcas.Columns["SAlmacen"].Value;
            DR["StockActual"] = this.TdgMarcas.Columns["StockActual"].Value;
            DR["StockDisponible"] = this.TdgMarcas.Columns["StockDisponible"].Value;
            DR["SProductoID"] = this.TdgMarcas.Columns["SProductoID"].Value;
            DR["SNomMarca"] = this.TdgMarcas.Columns["SNomMarca"].Value;
            DtAlmacenesF.Rows.Add(DR);

            DtDatos.Clear();
            DtDatos.Merge(DtAlmacenesF);
            this.Close();
        }

        private void SeleccionarMarcas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Escape))
            {
                this.Close();
            }
        }

        private void TdgMarcas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}

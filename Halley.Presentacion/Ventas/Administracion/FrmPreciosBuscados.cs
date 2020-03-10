using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Halley.Presentacion.Ventas.Administracion
{
    public partial class FrmPreciosBuscados : Form
    {
        #region propiedades
        private DataTable _DtProductos;
        private string _ProductoIDVentas;
        private string _ProductoID;
        private string _Alias;
        private string _UnidadMedidaID;
        private string _PrecioUnitario;


        public DataTable DtProductos
        {
            get { return _DtProductos; }
            set { _DtProductos = value; }
        }
        public string ProductoIDVentas
        {
            get { return _ProductoIDVentas; }
            set { _ProductoIDVentas = value; }
        }
        public string ProductoID
        {
            get { return _ProductoID; }
            set { _ProductoID = value; }
        }
        public string Alias
        {
            get { return _Alias; }
            set { _Alias = value; }
        }
        public string UnidadMedidaID
        {
            get { return _UnidadMedidaID; }
            set { _UnidadMedidaID = value; }
        }
        public string PrecioUnitario
        {
            get { return _PrecioUnitario; }
            set { _PrecioUnitario = value; }
        }

        public string Puntos { get; set; }
        #endregion
        public FrmPreciosBuscados()
        {
            InitializeComponent();
        }

        private void FrmPreciosBuscados_Load(object sender, EventArgs e)
        {
            TdgPreciosBuscados.SetDataBinding(DtProductos, "", true);
        }

        private void TdgPreciosBuscados_DoubleClick(object sender, EventArgs e)
        {
            if (TdgPreciosBuscados.RowCount > 0)
            {
                ProductoIDVentas = TdgPreciosBuscados.Columns["ProductoIDVentas"].Value.ToString();
                ProductoID = TdgPreciosBuscados.Columns["ProductoID"].Value.ToString();
                Alias = TdgPreciosBuscados.Columns["Alias"].Value.ToString();
                UnidadMedidaID = TdgPreciosBuscados.Columns["UnidadMedidaID"].Value.ToString();
                PrecioUnitario = TdgPreciosBuscados.Columns["PrecioUnitario"].Value.ToString();
                Puntos = TdgPreciosBuscados.Columns["Puntos"].Value.ToString();
                this.Close();
            }
        }
    }
}

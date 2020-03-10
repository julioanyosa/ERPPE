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
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    public partial class RepStock : Form
    {
        #region constructor

        public RepStock()
        {
            InitializeComponent();
        }

        #endregion

        #region eventos de los controles

        private void RepStock_Load(object sender, EventArgs e)
        {
            c1Combo.FillC1Combo(this.CbAlmacen, AppSettings.AlmacenPermisos, "Descripcion", "AlmacenID");
            if (AppSettings.SedeID == "002VU")
                CbAlmacen.SelectedValue = "GH002VUFRI";
            else
                CbAlmacen.SelectedValue = "GH001VUFRI";
            CbAlmacen.Enabled = false;

            DataTable dt = new DataTable();
            dt = new CL_Producto().getStockNavidad(CbAlmacen.SelectedValue.ToString(),AppSettings.SedeID);

            tdbgStock.SetDataBinding(dt, "", true);

        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    public partial class RepComprobante : UITemplateAccess
    {
        #region variables globales
        DataTable dt;
        #endregion

        #region contructor

        public RepComprobante()
        {
            InitializeComponent();
        }

        #endregion

        #region eventos del control

        private void RepAsignacionVales_ExportClick()
        {
            try
            {
                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;
                    string ruta = string.Concat(f.SelectedPath, @"\", "COMPROBANTES.xls");
                    new Office().DoExcell(ruta, dt, "COMPROBANTES");
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

        private void RepAsignacionVales_RefreshClick()
        {
            cargar();
        }

        private void RepAsignacionVales_Load(object sender, EventArgs e)
        {
            ocultarToolStrip();
            cargar();
        }

        #endregion

        #region metodos definidos

        private void cargar()
        {
            dt = new DataTable();
            dt = new CL_Vales().getComprobante();

            if (dt.Rows.Count != 0)
            {
                tdbgClientes.SetDataBinding(dt, "", true);
                lblTot.Text = dt.Compute("Count(NroDocumento)", "NomTipoComprobante='BOLETA'").ToString();
                lblVales.Text = dt.Compute("Count(NroDocumento)", "NomTipoComprobante='FACTURA'").ToString();
            }
        }

        #endregion
    }
}

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

namespace Halley.Presentacion.Ventas.Reporte
{
    public partial class FrmCierre : Form
    {
        CL_Venta ObjCL_Venta = new CL_Venta();

        string _Texto;

        public string Texto
        {
            get { return _Texto; }
            set { _Texto = value; }
        }
        public FrmCierre()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.USStandardFanfold;
            e.Graphics.DrawString(Texto, TxtTexto.Font, Brushes.Black, 1, 1); //total pagar en letras
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            if (AppSettings.ImpresoraPago != "")
            {
                printDocument1.PrinterSettings.PrinterName = AppSettings.ImpresoraPago;
                printDocument1.Print();
            }
            else
                MessageBox.Show("Debe seleccionar una impresora de pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void FrmCierre_Load(object sender, EventArgs e)
        {
            TxtTexto.Text = Texto;
            TxtTexto.ReadOnly = true;
            TxtTexto.Select(1, 1);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

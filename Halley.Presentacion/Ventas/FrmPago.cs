using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas
{
    public partial class FrmPago : Form
    {
        private TextFunctions _TextFunctions = new TextFunctions();
        string indata;

        private decimal _Pago;
        private decimal _TotalPagar;
        private decimal _Devolucion;
        public decimal Pago
        {
            get { return _Pago; }
            set { _Pago = value; }
        }
        public decimal Devolucion
        {
            get { return _Devolucion; }
            set { _Devolucion = value; }
        }
        public decimal TotalPagar
        {
            get { return _TotalPagar; }
            set { _TotalPagar = value; }
        }

        public FrmPago()
        {
            InitializeComponent();
        }

        private void TxtPago_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtPago.Text.Length>0)
                TxtVuelto.Value = "S/. " + (Convert.ToDecimal(TxtPago.Text) - TotalPagar).ToString("N2");
        }

        private void TxtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            _TextFunctions.ValidaNumero(sender, e, TxtPago);
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPago_Load(object sender, EventArgs e)
        {
            TxtTotal.Text = TotalPagar.ToString("N2");
            if (Pago > 0)
            {
                TxtPago.Text = Pago.ToString();
                TxtVuelto.Value = "S/. " + (Convert.ToDecimal(TxtPago.Text) - TotalPagar).ToString("N2");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.CapaLogica.Ventas;

namespace Halley.Presentacion.Ventas
{
    public partial class FrmBoucher : Form
    {
        #region propiedades
        private DataTable _DtBoucher;

        public DataTable DtBoucher
        {
            get { return _DtBoucher; }
            set { _DtBoucher = value; }
        }
        #endregion

        #region variables
        TextFunctions ObjTextFunctions = new TextFunctions();
        DateTime FechaHoraServidor;
        #endregion
        public FrmBoucher()
        {
            InitializeComponent();
        }


        private void FrmValesConsumo_Load(object sender, EventArgs e)
        {
            DtBoucher = new DataTable();
            DtBoucher.Columns.Add("NroBoucher", typeof(string));
            DtBoucher.Columns.Add("Banco", typeof(string));
            DtBoucher.Columns.Add("Monto", typeof(decimal));
        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            if (TxtBanco.Text != "" & TxtMonto.Text != "" & TxtMonto.Text != "." & TxtNumBoucher.Text != "")
            {
                string NroBoucher;
                string Banco;
                decimal Monto;

                NroBoucher = TxtNumBoucher.Text;
                Banco = TxtBanco.Text;
                Monto = Convert.ToDecimal(TxtMonto.Text);

                AgregarDetalle(NroBoucher, Banco, Monto);
                this.Close();
            }
            else
            {
                if (TxtBanco.Text == "") { ErrProvider.SetError(TxtBanco, "Ingrese el banco"); }
                if (TxtMonto.Text == "" | TxtMonto.Text == ".") { ErrProvider.SetError(TxtMonto, "Ingrese monto valido"); }
                if (TxtNumBoucher.Text == "") { ErrProvider.SetError(TxtNumBoucher, "Ingrese Nro de Boucher"); }
            }
        }

        private void AgregarDetalle(string NroBoucher, string Banco, decimal Monto)
        {
            DataView Dv = new DataView(DtBoucher);
            Dv.RowFilter = "NroBoucher = '" + NroBoucher + "'";
            if (Dv.Count == 0)//no existe
            {
                DataRow DR = DtBoucher.NewRow();
                DR["NroBoucher"] = NroBoucher;
                DR["Banco"] = Banco;
                DR["Monto"] = Monto;
                DtBoucher.Rows.Add(DR);
            }
            else
                MessageBox.Show("Este vale ya se ingreso en la grilla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtMonto);
        }

    }
}

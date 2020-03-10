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
    public partial class FrmValesConsumo : Form
    {
        #region propiedades
        private DataTable _DtValesConsumo;

        public DataTable DtValesConsumo
        {
            get { return _DtValesConsumo; }
            set { _DtValesConsumo = value; }
        }
        #endregion

        #region variables
        TextFunctions ObjTextFunctions = new TextFunctions();
        DateTime FechaHoraServidor;
        #endregion
        public FrmValesConsumo()
        {
            InitializeComponent();
        }

        private void TxtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            string CodigoDeBarra = TxtCodigo.Text;
            if (CodigoDeBarra.Length > 2)
            {
                if (CodigoDeBarra.Length == 26 & CodigoDeBarra.Substring(0, 2) == "73")//es vale de consumo
                {
                    //descomponer el codigo
                    string Numvale;
	                DateTime FechaEmision;
                    decimal Monto;

                    Numvale = CodigoDeBarra.Substring(3, 10);
                    FechaEmision = Convert.ToDateTime(CodigoDeBarra.Substring(13, 2) + "/" + CodigoDeBarra.Substring(15, 2) + "/" + CodigoDeBarra.Substring(17,2));
                    Monto = Convert.ToDecimal(CodigoDeBarra.Substring(19)) / 100;

                    //mostrar en las cajitas
                    TxtNumValeConsumo.Text = Numvale;
                    DtpFechaEmision.Value = FechaEmision;
                    TxtMonto.Text = Monto.ToString();

                    AgregarDetalle(Numvale, FechaEmision, Monto);

                    TxtCodigo.Text = "";
                    TxtCodigo.Focus();
                }
            }
        }

        private void FrmValesConsumo_Load(object sender, EventArgs e)
        {
            DtValesConsumo = new DataTable();
            DtValesConsumo.Columns.Add("Numvale", typeof(string));
            DtValesConsumo.Columns.Add("FechaEmision", typeof(DateTime));
            DtValesConsumo.Columns.Add("Monto", typeof(decimal));

            TdgValesConsumo.SetDataBinding(DtValesConsumo, "", true);

            //obtener la fecha del servidor
            FechaHoraServidor = new CL_Pago().GetFechaHoraServidor();
        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            string Numvale;
            DateTime FechaEmision;
            decimal Monto;

            Numvale = TxtNumValeConsumo.Text;
            FechaEmision = Convert.ToDateTime(DtpFechaEmision.Value);
            Monto = Convert.ToDecimal(TxtMonto.Text);

            AgregarDetalle(Numvale, FechaEmision, Monto);
        }

        private void AgregarDetalle(string Numvale, DateTime FechaVencimiento, decimal Monto)
        {
            //verificar el vale en tiempo real para ver si se agrega
            bool Valor = true;
            Valor = new CL_Venta().ExisteVale(Numvale);
            if (Valor == false)//si el vale no existe se agrega
            {
                //buscar, si no se encuentra agregar a la tabla
                if (FechaVencimiento >= FechaHoraServidor)
                {
                    DataView Dv = new DataView(DtValesConsumo);
                    Dv.RowFilter = "Numvale = '" + Numvale + "'";
                    if (Dv.Count == 0)//no existe
                    {
                        DataRow DR = DtValesConsumo.NewRow();
                        DR["Numvale"] = Numvale;
                        DR["FechaEmision"] = FechaVencimiento;
                        DR["Monto"] = Monto;
                        DtValesConsumo.Rows.Add(DR);
                    }
                    else
                        MessageBox.Show("Este vale ya se ingreso en la grilla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Al parecer el vale ya paso la fecha de vencimiento. \n\nNo se agregara el vale.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Este vale ya esta registrado en el sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtMonto);
        }
    }
}

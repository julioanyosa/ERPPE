using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas
{
    public partial class FrmReserva : Form
    {
        #region Propiedades
        private string _Alias;
        private string _ProductoID;
        public bool _Aprobado;
        public DateTime _FechaReserva;
        public decimal _Cantidad;

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
        public bool Aprobado
        {
            get { return _Aprobado; }
            set { _Aprobado = value; }
        }
        public DateTime FechaReserva
        {
            get { return _FechaReserva; }
            set { _FechaReserva = value; }
        }
        public decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        #endregion

        CL_Venta ObjCL_Venta = new CL_Venta();
        TextFunctions ObjTextFunctions = new TextFunctions();

        public FrmReserva()
        {
            InitializeComponent();
        }

        private void FrmReserva_Load(object sender, EventArgs e)
        {
            TxtTotalReservado.ReadOnly = true;
            //traer las reservas del producto
            LbAlias.Text = Alias;
            DataTable DtReservas = new DataTable();
            DtReservas = ObjCL_Venta.GetReservas(ProductoID);
            TdgReservas.SetDataBinding(DtReservas, "", true);
            if (DtReservas.Rows.Count > 0)
            {
                TxtTotalReservado.ReadOnly = false;
                TxtTotalReservado.Text = DtReservas.Compute("sum(Cantidad)", "").ToString();
                TxtTotalReservado.ReadOnly = true;
            }
            Cantidad = 0;
            Aprobado = false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Aprobado = false;
            Close();
        }

        private void BtnReservar_Click(object sender, EventArgs e)
        {
            Aprobado = true;
            if (DeFechaReserva.Value.ToString() != "" & TxtCantidadReservar.Text != "" & TxtCantidadReservar.Text != ".")
            {
                if (Convert.ToDecimal(TxtCantidadReservar.Text) > 0)
                    Cantidad = Convert.ToDecimal(TxtCantidadReservar.Text);
                else
                {
                    MessageBox.Show("La cantidad debe ser mayor a cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FechaReserva = Convert.ToDateTime(DeFechaReserva.Value).Date;
                if(FechaReserva < DateTime.Now.Date)
                    MessageBox.Show("La fecha de reserva no puede ser menor a la fecha actual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Close();
            }
            else
                MessageBox.Show("Debe seleccionar la fecha de reserva e ingresar la cantidad a reservar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TxtCantidadReservar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtCantidadReservar);
        }
    }
}

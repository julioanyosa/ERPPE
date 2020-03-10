using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;

namespace Halley.Presentacion.Ventas
{
    public partial class FrmAdelantos : Form
    {
        DataTable DtTemporal = new DataTable();
        private int _ClienteID;

        public int ClienteID
        {
            get { return _ClienteID; }
            set { _ClienteID = value; }
        }
        private DataTable _DtNotaIngreso;

        public DataTable DtNotaIngreso
        {
            get { return _DtNotaIngreso; }
            set { _DtNotaIngreso = value; }
        }

        public FrmAdelantos()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DtNotaIngreso = DtTemporal.Copy();
            this.Close();
        }

        private void FrmAdelantos_Load(object sender, EventArgs e)
        {
            //traer todos los adelantos realizados por el cliente
            DtNotaIngreso = new DataTable();
            CL_Pago ObjCL_Pago = new CL_Pago();
            
            DtTemporal = ObjCL_Pago.GetAdelantosCliente(ClienteID);
            if (DtTemporal.Rows.Count > 0)
            {
                TdgAdelantosCliente.SetDataBinding(DtTemporal, "", true);
                this.c1SuperTooltip1.Show("<table><tr><td><parm><img src='res://Pollos_32x32.gif'></parm></td><td><b><parm>Validar adelantos</parm></b></td></tr></table><parm><hr noshade size=1 style='margin:2' color=Darker></parm><div style='margin:1 12'><parm>  Aca acepta todos<br>los adelantos recibidos.</parm></div><parm><hr noshade size=1 style='margin:2' color=Darker></parm><table><tr><td><parm><img src='res://pollito32x32.gif'></parm></td><td><b><parm>Puede quitar los que no necesita</parm></b></td></tr></table>", this.BtnAceptar, 50, 0, 5000);
            }
            else
            {
                MessageBox.Show("El cliente no tiene ningún adelanto de efectivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }

        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            //quita un adelanto (en caso de que el adelanto no sea para la venta a realizar)
            //Eliminar
            DataRow[] customerRow = DtTemporal.Select("NotaIngresoID = " + TdgAdelantosCliente.Columns["NotaIngresoID"].Value);
            customerRow[0].Delete();
        }
    }
}

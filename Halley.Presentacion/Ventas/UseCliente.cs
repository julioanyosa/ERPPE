using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas
{
    public partial class UseCliente : UserControl
    {
        #region Delegate
        public delegate void Del();
        public event Del ComboValueChange;
        #endregion

        #region declaraciones de variables

        DataTable dtCliente;

        #endregion

        #region constructor

        public UseCliente()
        {
            InitializeComponent();
        }

        #endregion

        #region metodo definidos

        public void Cargar(DataTable dt)
        {
            dtCliente = dt;
            c1Combo.FillC1Combo1(cbCliente, dtCliente, "NroDocumento", "ClienteID");
            c1Combo.FillC1Combo1(cbNombre, dtCliente, "RazonSocial", "ClienteID"); 
        }

        public void Limpiar()
        {
            cbCliente.Text = "[Seleccionar]";
            cbNombre.Text = "[Seleccionar]";
            txtDireccion.Text = string.Empty;
        }
   

        #endregion

        #region eventos de los controles

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Mantenimiento.FrmCliente ObjCli = new Mantenimiento.FrmCliente();

            if (ObjCli.ShowDialog() == DialogResult.OK)
            {
                DataRow fila = dtCliente.NewRow();
                fila["ClienteID"] = ObjCli.IDCliente;
                fila["RazonSocial"] = ObjCli.RazonSocial;
                fila["Direccion"] = ObjCli.Direccion;
                fila["NroDocumento"] = ObjCli.NroDocumento;
                fila["TipoClienteID"] = ObjCli.TipoCliente;
                fila["IDTipoDocumento"] = ObjCli.TipoDocumento;
                dtCliente.Rows.Add(fila);

                cbCliente.SelectedValue = ObjCli.IDCliente;

            }

        }

        private void cbCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbCliente.SelectedIndex != -1)
            {
                txtDireccion.ReadOnly = false;
                txtDireccion.Text = cbCliente.Columns["Direccion"].Value.ToString();
            }
            if (ComboValueChange != null)
                ComboValueChange();
        }

        #endregion
    }
}

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
    public partial class FrmClientes : Form
    {
        private string _NroDocumento;

        public string NroDocumento
        {
            get { return _NroDocumento; }
            set { _NroDocumento = value; }
        }
        private string _Cliente;

        public string Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }
        private int _ClienteID;

        public int ClienteID
        {
            get { return _ClienteID; }
            set { _ClienteID = value; }
        }

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            useCliente1.Cargar(new CL_Cliente().GetClientes());
            NroDocumento = useCliente1.cbCliente.Columns["NroDocumento"].Value.ToString();
            Cliente = useCliente1.cbNombre.Columns["RazonSocial"].Value.ToString();
            ClienteID = Convert.ToInt32(useCliente1.cbCliente.SelectedValue);
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            NroDocumento = useCliente1.cbCliente.Columns["NroDocumento"].Value.ToString();
            Cliente = useCliente1.cbNombre.Columns["RazonSocial"].Value.ToString();
            ClienteID = Convert.ToInt32(useCliente1.cbCliente.SelectedValue);
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;

namespace Halley.Presentacion.Almacen
{
    public partial class FrmDespachos : Form
    {
        #region Variables
        CL_HojaDespacho ObjCL_HojaDespacho = new CL_HojaDespacho();
        #endregion

        #region Propiedades
        public string _NumComprobante;
        public int _TipoComprobanteID;

        public string NumComprobante
        {
            get { return _NumComprobante; }
            set { _NumComprobante = value; }
        }
        public int TipoComprobanteID
        {
            get { return _TipoComprobanteID; }
            set { _TipoComprobanteID = value; }
        }
        #endregion
        public FrmDespachos()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDespachos_Load(object sender, EventArgs e)
        {
            //despachos
            TdgDespachos.SetDataBinding(ObjCL_HojaDespacho.GetDespachos(NumComprobante, TipoComprobanteID), "", true);
        }
    }
}

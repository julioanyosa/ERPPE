using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.Configuracion;
using Halley.CapaLogica.Produccion;
using Halley.Entidad.Almacen;
using Halley.CapaLogica.Almacen;

namespace Halley.Presentacion.Almacen.Operaciones
{
    public partial class DespachoInterno : UITemplateAccess
    {
        CL_Produccion ObjCL_Produccion = new CL_Produccion();
        DataTable DtProductosDespacho = new DataTable();
        string NumHojaDespacho = "";

        public DespachoInterno()
        {
            InitializeComponent();
        }

        private void DespachoInterno_Load(object sender, EventArgs e)
        {
            c1Combo.FillC1Combo(this.CbAlmacen, AppSettings.AlmacenPermisos, "Descripcion", "AlmacenID");
        }

        private void CbAlmacen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CbAlmacen.SelectedIndex != -1)
            {
                DtProductosDespacho = ObjCL_Produccion.GetDespachoInterno(AppSettings.EmpresaID + AppSettings.SedeID + "PRO", CbAlmacen.SelectedValue.ToString());
                DtProductosDespacho.Columns["Agregar"].ReadOnly=false;
                tdgDespachoInterno.SetDataBinding(DtProductosDespacho, "", true);
            }
        }

        private void BtnDespachar_Click(object sender, EventArgs e)
        {
            try
            {
                NumHojaDespacho = ObjCL_Produccion.DespachoInterno(DtProductosDespacho, AppSettings.UserID, AppSettings.EmpresaID, AppSettings.NomEmpresa, AppSettings.SedeID);
                MessageBox.Show("Se realizo la transferencia correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DtProductosDespacho.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {
            Reportes.FrmHojaDespacho ObjFrmHojaD = new Reportes.FrmHojaDespacho();
            ObjFrmHojaD.NumHojaDespacho = NumHojaDespacho;
            ObjFrmHojaD.ShowDialog();
        }

        private void ChkSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeleccionarTodo.Checked == true & this.tdgDespachoInterno.RowCount > 0)
            {
                for (int i = 0; i <= this.tdgDespachoInterno.RowCount - 1; i++)
                {
                    this.tdgDespachoInterno[i, "Agregar"] = true;
                }
                this.tdgDespachoInterno.Refresh();
            }
            else if (ChkSeleccionarTodo.Checked == false & this.tdgDespachoInterno.RowCount > 0)
            {

                for (int i = 0; i <= this.tdgDespachoInterno.RowCount - 1; i++)
                {
                    this.tdgDespachoInterno[i, "Agregar"] = false;
                }
                this.tdgDespachoInterno.Refresh();
            }
        }

        
    }
}

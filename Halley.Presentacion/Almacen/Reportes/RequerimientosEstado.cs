using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;

namespace Halley.Presentacion.Almacen.Reportes
{
    public partial class RequerimientosEstado : UITemplateAccess
    {
        #region variables globales
        CL_Requerimientos ObjCL_Requerimientos = new CL_Requerimientos();
        DataTable DtRequerimientoDetalleGuiaRemision = new DataTable();
        DataTable DtEstadoRequerimientos = new DataTable();
        #endregion

        public RequerimientosEstado()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (cboFechaInicio.Value.ToString() != "" && cboFechaFin.Value.ToString() != "")
            {
                DateTime FecIni;
                DateTime FecFin;
                FecIni = Convert.ToDateTime(cboFechaInicio.Value).Date;
                FecFin = Convert.ToDateTime(cboFechaFin.Value).AddDays(1).Date;

                DtEstadoRequerimientos = ObjCL_Requerimientos.GetRequerimientosEstadoFecha(FecIni, FecFin);

                
                DtRequerimientoDetalleGuiaRemision = ObjCL_Requerimientos.GetRequerimientoDetalleGuiaRemision(FecIni, FecFin);
                TdgEstadoRequerimientos.SetDataBinding(DtEstadoRequerimientos, "", true);

                DataView Dv = new DataView();
                TdgDetalleGuias.SetDataBinding(Dv, "", true);
            }
            Cursor = Cursors.Default;

        }

        private void RequerimientosEstado_Load(object sender, EventArgs e)
        {
            cboFechaFin.Value = DateTime.Now.Date;
            cboFechaInicio.Value = DateTime.Now.Date;
            ocultarToolStrip();
        }

        private void TdgEstadoRequerimientos_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {
            //darle el color a al celda segun su prioridad
            switch (e.Column.DataColumn.DataField)
            {
                case "PrioridadID":
                    if (this.TdgEstadoRequerimientos[e.Row, "PrioridadID"].ToString().Trim() == "M")
                    {
                        e.CellStyle.BackColor = Color.Gold;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    }

                    if (this.TdgEstadoRequerimientos[e.Row, "PrioridadID"].ToString().Trim() == "B")
                    {
                        e.CellStyle.BackColor = Color.MediumSeaGreen;
                        break;
                    }

                    if (this.TdgEstadoRequerimientos[e.Row, "PrioridadID"].ToString().Trim() == "A")
                    {
                        e.CellStyle.BackColor = Color.Crimson;
                        break;
                    }
                    break;
            }
        }

        private void ChkCabecera_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCabecera.Checked == true)
                TdgEstadoRequerimientos.GroupByAreaVisible = true;
            else
                TdgEstadoRequerimientos.GroupByAreaVisible = false;
        }

        private void TdgEstadoRequerimientos_RowColChange(object sender, C1.Win.C1TrueDBGrid.RowColChangeEventArgs e)
        {
            if (TdgEstadoRequerimientos.RowCount > 0)
            {
                //filtrar el detalle para mostrarlo
                DataView Dv = new DataView(DtRequerimientoDetalleGuiaRemision);
                Dv.RowFilter = "NumRequerimiento = '" + this.TdgEstadoRequerimientos.Columns["NumRequerimiento"].Value.ToString()+ "'";
                TdgDetalleGuias.SetDataBinding(Dv, "", true);
                TdgDetalleGuias.Refresh();
                
            }

        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (TdgEstadoRequerimientos.RowCount > 0)
            {
                if (MessageBox.Show("ESta seguro que desea cancelar el requerimiento: '" + TdgEstadoRequerimientos.Columns["NumRequerimiento"].Value.ToString() + "' del producto: '" + TdgEstadoRequerimientos.Columns["NomProducto"].Value.ToString() + "'.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //anular requerimiento
                    bool Modifico = false;
                    Modifico = ObjCL_Requerimientos.UpdateDetalleRequerimientoAnular(TdgEstadoRequerimientos.Columns["NumRequerimiento"].Value.ToString(), Convert.ToDecimal(TdgEstadoRequerimientos.Columns["CantidadSolicitada"].Value.ToString()), TdgEstadoRequerimientos.Columns["AlmacenDestino"].Value.ToString(), TdgEstadoRequerimientos.Columns["ProductoID"].Value.ToString(), AppSettings.UserID, AppSettings.SedeID);
                    if (Modifico == false)
                        MessageBox.Show("No se puede anular un requerimiento que no esté 'PLANEADO'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        MessageBox.Show("Se anulo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                }
            }
        }
    }
}

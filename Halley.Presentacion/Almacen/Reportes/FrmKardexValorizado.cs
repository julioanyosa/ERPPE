using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Halley.CapaLogica.Almacen;

namespace Halley.Presentacion.Almacen.Reportes
{
    public partial class FrmKardexValorizado : Form
    {

        DataSet _Ds;
        string _Titulo;

        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }

        public DataSet Ds
        {
          get { return _Ds; }
          set { _Ds = value; }
        }
        public FrmKardexValorizado()
        {
            InitializeComponent();
        }

        private void FrmKardexValorizado_Load(object sender, EventArgs e)
        {
            Halley.Presentacion.CrystalReports.CrKardex ObjCrCrGetVentasVendedor = new Halley.Presentacion.CrystalReports.CrKardex();
            ObjCrCrGetVentasVendedor.SetDataSource(Ds);
            CrvKardex.ReportSource = ObjCrCrGetVentasVendedor;
            //pasar datos directo al crystal reports
            TextObject txt;
            txt = (TextObject)ObjCrCrGetVentasVendedor.ReportDefinition.ReportObjects["TxtPeriodo"];
            txt.Text = Titulo;
            CrvKardex.Refresh();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            //actualiza los nuevos costos promedios contables
            //puede tomar tiempo
            try
            {
                if (MessageBox.Show("¿Seguro que desea guardar los cambios?.\nEsta modificación no es reversible.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //*********guardar los cambios realizados en el kardex
                    //filtrar los modificados (solo los de ventas)
                    DataTable DTModificada = new DataTable("Modificados");
                    DataTable DTModificadaCierre = new DataTable("Modificados");
                    //filtrado por venta y salida de produccion
                    DataView DV = new DataView(Ds.Tables["GetKardex"], "Tabla = 'K' and Operacion in('01','10')", "", DataViewRowState.CurrentRows);

                    DTModificada = DV.ToTable();
                    //cambiamos el nombre de als columnas apra que coincidan con la del xml
                    DTModificada.Columns["Operacion"].ColumnName = "TipoOperacion";
                    DTModificada.Columns["SCostoUnitario"].ColumnName = "PrecioUnitario";
                    DTModificada.Columns["SCantidad"].ColumnName = "Cantidad";
                    if (DTModificada != null && DTModificada.Rows.Count > 0)
                    {
                        new CL_Kardex().UpdateXMLKardex(DTModificada);
                        Ds.Tables["GetKardex"].AcceptChanges();
                        MessageBox.Show("Se realizo los cambios correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

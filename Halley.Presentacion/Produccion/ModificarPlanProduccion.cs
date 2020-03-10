using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Produccion;
using Halley.Utilitario;
using Halley.Configuracion;

namespace Halley.Presentacion.Produccion
{
    public partial class ModificarPlanProduccion : Form
    {
        CL_Produccion ObjCL_Produccion = new CL_Produccion();
        DataTable DtMateriasPrimas;
        DataTable DtMateriasPrimasDelet;
        DataTable DTProductosMacroMicro;

        public ModificarPlanProduccion()
        {
            InitializeComponent();
        }
        #region propiedades
        string _ProductoID;
        string _NomProducto;

        public string ProductoID
        {
            get { return _ProductoID; }
            set { _ProductoID = value; }
        }
        public string NomProducto
        {
            get { return _NomProducto; }
            set { _NomProducto = value; }
        }

        #endregion
        
        private void TdgMarcas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Escape))
            {
                this.Close();
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarPlanProduccion_Load(object sender, EventArgs e)
        {
            DtMateriasPrimas = new DataTable();
            LblProducto.Text = "Materias primas del producto: " + NomProducto;
            DtMateriasPrimas = ObjCL_Produccion.GetMateriasPrimasProducto(ProductoID, AppSettings.EmpresaID);
            DtMateriasPrimas.Columns.Add("Tipo", typeof(string));
            TdgMateriasPrimas.SetDataBinding(DtMateriasPrimas, "", true);

            DTProductosMacroMicro = new DataTable();
            DTProductosMacroMicro = ObjCL_Produccion.GetProductosMacroMicro();
            CboProductosMacroMicro.HoldFields();
            CboProductosMacroMicro.DataSource = DTProductosMacroMicro;
            CboProductosMacroMicro.DisplayMember = "NomProducto";
            CboProductosMacroMicro.ValueMember = "ProductoID";

            DtMateriasPrimasDelet = new DataTable();
            DtMateriasPrimasDelet = DtMateriasPrimas.Clone();

        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            //unir las dos tablas apra enviar a actualizacion (se uniran en DtMateriasPrimasDelet)
            foreach (DataRow dr in DtMateriasPrimas.Rows)
            {
                if (dr["Tipo"].ToString() != "")
                    DtMateriasPrimasDelet.ImportRow(dr);
            }
            //actualizar las cantidades con xml
            DtMateriasPrimasDelet.TableName = "MateriaPrima";
            if (DtMateriasPrimasDelet.Rows.Count > 0)
            {
                string xml = new BaseFunctions().GetXML(DtMateriasPrimasDelet).Replace("NewDataSet", "DocumentElement");
                bool Valor;
                Valor = new CL_Produccion().UpdateXMLMateriaPrima(xml, AppSettings.UserID, AppSettings.EmpresaID);
                if (Valor == false)
                    MessageBox.Show("Ocurrio un error al intentar actualizar las cantidades de las materias primas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Se actualizo correctamente las cantidades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (CboProductosMacroMicro.SelectedValue != null)
            {
                string ProductoIDMateria2;
                bool Agregar=true;
                ProductoIDMateria2 = CboProductosMacroMicro.Columns["ProductoID"].Value.ToString();
                foreach (DataRow Dr in DtMateriasPrimas.Rows) //verificar si existe para agregar
                {
                    if (Dr["ProductoIDMateria"].ToString() == ProductoIDMateria2)
                        Agregar = false;
                }

                if (Agregar == true)
                {
                    DataRow Dr = DtMateriasPrimas.NewRow();
                    Dr["ProductoID"] = ProductoID;
                    Dr["ProductoIDMateria"] = CboProductosMacroMicro.SelectedValue;
                    Dr["NomProducto"] = CboProductosMacroMicro.SelectedText;
                    Dr["AlmacenMateria"] = CboProductosMacroMicro.Columns["Almacen"].Value;
                    Dr["Cantidad"] = 0;
                    Dr["Tipo"] = "I";
                    DtMateriasPrimas.Rows.Add(Dr);
                }

                #region eliminar de la tabla dtmateriasprimasdelet para que no se duplique al momento de juntar las tablas
                string ProductoID2;
                ProductoID2 = ProductoID;
                ProductoIDMateria2 = CboProductosMacroMicro.Columns["ProductoID"].Value.ToString();
                foreach (DataRow Dr in DtMateriasPrimasDelet.Rows)
                {
                    if (Dr["ProductoID"].ToString() == ProductoID && Dr["ProductoIDMateria"].ToString() == ProductoIDMateria2)//si es la fila se graga a la otra tabla y de paso se borra
                    {
                        DtMateriasPrimasDelet.Rows.Remove(Dr);//se elimina de la tabla
                        return;
                    }
                }
                #endregion
            }
        }

        private void TdgMateriasPrimas_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            if (this.TdgMateriasPrimas.RowCount > 0)
            {
                if (TdgMateriasPrimas.Columns["Tipo"].Value != "I")
                    TdgMateriasPrimas.Columns["Tipo"].Value = "U";
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (TdgMateriasPrimas.RowCount > 0)
            {
                string ProductoID2;
                string ProductoIDMateria2;
                ProductoID2 = ProductoID;
                ProductoIDMateria2 = this.TdgMateriasPrimas.Columns["ProductoIDMateria"].Value.ToString();
                foreach (DataRow Dr in DtMateriasPrimas.Rows)
                {
                    if (Dr["ProductoID"].ToString() == ProductoID && Dr["ProductoIDMateria"].ToString() == ProductoIDMateria2)//si es la fila se graga a la otra tabla y de paso se borra
                    {
                        DataRow DR1 = DtMateriasPrimasDelet.NewRow();
                        DR1["ProductoID"] = Dr["ProductoID"];
                        DR1["ProductoIDMateria"] = Dr["ProductoIDMateria"];
                        DR1["NomProducto"] = Dr["NomProducto"];
                        DR1["AlmacenMateria"] = Dr["AlmacenMateria"];
                        DR1["Cantidad"] = Dr["Cantidad"];
                        DR1["Tipo"] = "D";
                        DtMateriasPrimasDelet.Rows.Add(DR1);

                        DtMateriasPrimas.Rows.Remove(Dr);//se elimina de la tabla
                        return;
                    }
                }

            }
        }
    }
}

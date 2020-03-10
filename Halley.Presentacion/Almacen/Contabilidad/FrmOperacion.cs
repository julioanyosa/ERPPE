using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Entidad.Almacen;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;
using Halley.Presentacion.Almacen.Operaciones;
using Halley.Utilitario;

namespace Halley.Presentacion.Almacen.Contabilidad
{
    public partial class FrmOperacion : Form
    {

        string TipoGuardar = "";
        E_Operacion ObjOperacion = new E_Operacion();
        CL_Kardex ObjCL_Kardex = new CL_Kardex();

        public FrmOperacion()
        {
            InitializeComponent();
        }

        private void FrmUnidadMedidacs_Load(object sender, EventArgs e)
        {
            TdgMovimientos.SetDataBinding(Halley.Presentacion.Almacen.Reportes.Rep_Kardex.DTOperacion, "", true);
            lblEstado.Text = "";
            OcultarBotones(false, true, false, false, false, false);
            ReadOnly(true);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            TipoGuardar = "Nuevo";
            OcultarBotones(false, false, true, false, true, false);
            ReadOnly(false);
            LimpiarTextos();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //desahcer
            OcultarBotones(true, true, false, false, false, false);
            ReadOnly(false);
            LimpiarTextos();
            ReadOnly(true);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            TipoGuardar = "Actualizar";
            OcultarBotones(false, false, true, false, true, false);
            ReadOnly(false);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarBotones(true, true, false, false, false, false);
                validarControles();

                if (validarControles() == false)
                {
                    OcultarBotones(false, false, true, false, true, false);
                    return;
                }
                ErrProvider.Clear();
                ObtenerDatosControles();
                if (TipoGuardar == "Nuevo")
                {
                    //agregar
                    ObjCL_Kardex.InsertOperacion(ObjOperacion);
                    DataRow Dr = Halley.Presentacion.Almacen.Reportes.Rep_Kardex.DTOperacion.NewRow();
                    Dr["OperacionID"] = ObjOperacion.OperacionID;
                    Dr["Descripcion"] = ObjOperacion.Descripcion;
                    Halley.Presentacion.Almacen.Reportes.Rep_Kardex.DTOperacion.Rows.Add(Dr);

                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Kardex.UpdateOperacion(ObjOperacion, "A");

                    //actualizar
                    DataRow[] customerRow = Halley.Presentacion.Almacen.Reportes.Rep_Kardex.DTOperacion.Select("OperacionID = '" + ObjOperacion.OperacionID + "'");
                    customerRow[0]["Descripcion"] = ObjOperacion.Descripcion;


                    lblEstado.Text = "Se actualizó correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                TipoGuardar = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReadOnly(false);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarBotones(true, true, false, false, false, false);

                if (MessageBox.Show("¿Está seguro que desea eliminar la operación?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Kardex.UpdateOperacion(ObjOperacion, "E");
                    
                    //Eliminar
                    DataRow[] customerRow = Halley.Presentacion.Almacen.Reportes.Rep_Kardex.DTOperacion.Select("OperacionID = '" + ObjOperacion.OperacionID + "'");
                    customerRow[0].Delete();

                    lblEstado.Text = "Se eliminó la operación:  " + TxtDescripcion.Text + ".";
                    lblEstado.ForeColor = Color.Red;
                }
                else
                    OcultarBotones(true, true, false, false, false, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadOnly(bool Valor)
        {
            TxtOperacionID.ReadOnly = Valor;
            TxtDescripcion.ReadOnly = Valor;
        }

        private bool validarControles()
        {
            if (TxtOperacionID.Text == "") { ErrProvider.SetError(TxtOperacionID, "Debe Ingresar el codigo del movimiento."); return false; }
            if (TxtDescripcion.Text == "") { ErrProvider.SetError(TxtDescripcion, "Debe Ingresar la descripcion del movimiento."); return false; }
           
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjOperacion = new E_Operacion();
            ObjOperacion.OperacionID = TxtOperacionID.Text;
            ObjOperacion.Descripcion = TxtDescripcion.Text;
        }

        private void LimpiarTextos()
        {
            TxtOperacionID.Text = "";
            TxtDescripcion.Text = "";
        }

        private void OcultarBotones(bool Buscar, bool Nuevo, bool Cancelar, bool Editar, bool Guardar, bool Eliminar)
        {
            BtnNuevo.Visible = Nuevo;
            BtnCancelar.Visible = Cancelar;
            BtnEditar.Visible = Editar;
            BtnGuardar.Visible = Guardar;
            BtnEliminar.Visible = Eliminar;
        }

        private void TxtOperacionID_KeyPress(object sender, KeyPressEventArgs e)
        {
            new TextFunctions().SoloNumero(sender, e, TxtOperacionID);
        }

        private void TdgMovimientos_DoubleClick(object sender, EventArgs e)
        {
            ReadOnly(false);
            TxtOperacionID.Text = TdgMovimientos.Columns["OperacionID"].Value.ToString();
            TxtDescripcion.Text = TdgMovimientos.Columns["Descripcion"].Value.ToString();
            ReadOnly(true);
            OcultarBotones(true, true, false, true, false, true);
        }

 
    }
}

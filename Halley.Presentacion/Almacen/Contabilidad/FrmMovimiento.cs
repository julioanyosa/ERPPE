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
    public partial class FrmMovimiento : Form
    {

        string TipoGuardar = "";
        E_Movimiento ObjMovimiento = new E_Movimiento();
        CL_Kardex ObjCL_Kardex = new CL_Kardex();

        public FrmMovimiento()
        {
            InitializeComponent();
        }

        private void FrmUnidadMedidacs_Load(object sender, EventArgs e)
        {
            TdgMovimientos.SetDataBinding(Halley.Presentacion.Almacen.Reportes.Rep_Kardex.DTMovimiento, "", true);
            lblEstado.Text = "";
            CboTipo.HoldFields();
            CboTipo.DataSource = c1Combo.DtTiposMovimientos();
            CboTipo.DisplayMember = "Descripcion";
            CboTipo.ValueMember = "Codigo";
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
                    ObjCL_Kardex.InserMovimiento(ObjMovimiento);
                    DataRow Dr = Halley.Presentacion.Almacen.Reportes.Rep_Kardex.DTMovimiento.NewRow();
                    Dr["MovimientoID"] = ObjMovimiento.MovimientoID;
                    Dr["NomMovimiento"] = ObjMovimiento.NomMovimiento;
                    Dr["Tipo"] = ObjMovimiento.Tipo;
                    Halley.Presentacion.Almacen.Reportes.Rep_Kardex.DTMovimiento.Rows.Add(Dr);

                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Kardex.UpdateMovimiento(ObjMovimiento, "A");

                    //actualizar
                    DataRow[] customerRow = Halley.Presentacion.Almacen.Reportes.Rep_Kardex.DTMovimiento.Select("MovimientoID = '" + ObjMovimiento.MovimientoID + "'");
                    customerRow[0]["NomMovimiento"] = ObjMovimiento.NomMovimiento;
                    customerRow[0]["Tipo"] = ObjMovimiento.Tipo;


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

                if (MessageBox.Show("¿Está seguro que desea eliminar el movimiento?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Kardex.UpdateMovimiento(ObjMovimiento, "E");
                    
                    //Eliminar
                    DataRow[] customerRow = Halley.Presentacion.Almacen.Reportes.Rep_Kardex.DTMovimiento.Select("MovimientoID = '" + ObjMovimiento.MovimientoID + "'");
                    customerRow[0].Delete();

                    lblEstado.Text = "Se eliminó el movimiento:  " + TxtNomMovimiento.Text + ".";
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
            TxtMovimientoID.ReadOnly = Valor;
            TxtNomMovimiento.ReadOnly = Valor;
            CboTipo.ReadOnly = Valor;
        }

        private bool validarControles()
        {
            if (TxtMovimientoID.Text == "") { ErrProvider.SetError(TxtMovimientoID, "Debe Ingresar el codigo del movimiento."); return false; }
            if (TxtNomMovimiento.Text == "") { ErrProvider.SetError(TxtNomMovimiento, "Debe Ingresar la descripcion del movimiento."); return false; }
            if (CboTipo.SelectedIndex == -1) { ErrProvider.SetError(CboTipo, "Debe seleccionar un tipo."); return false; }

            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjMovimiento = new E_Movimiento();
            ObjMovimiento.MovimientoID = Convert.ToInt16(TxtMovimientoID.Text);
            ObjMovimiento.NomMovimiento = TxtNomMovimiento.Text;
            ObjMovimiento.Tipo = CboTipo.SelectedValue.ToString();
        }

        private void LimpiarTextos()
        {
            TxtMovimientoID.Text = "";
            TxtNomMovimiento.Text = "";
            CboTipo.SelectedIndex = -1;
        }

        private void OcultarBotones(bool Buscar, bool Nuevo, bool Cancelar, bool Editar, bool Guardar, bool Eliminar)
        {
            BtnNuevo.Visible = Nuevo;
            BtnCancelar.Visible = Cancelar;
            BtnEditar.Visible = Editar;
            BtnGuardar.Visible = Guardar;
            BtnEliminar.Visible = Eliminar;
        }

        private void TdgMovimientos_DoubleClick(object sender, EventArgs e)
        {
            ReadOnly(false);
            TxtMovimientoID.Text = TdgMovimientos.Columns["MovimientoID"].Value.ToString();
            TxtNomMovimiento.Text = TdgMovimientos.Columns["NomMovimiento"].Value.ToString();
            CboTipo.SelectedValue = TdgMovimientos.Columns["Tipo"].Value.ToString();
            ReadOnly(true);
            OcultarBotones(true, true, false, true, false, true);
        }

        private void TxtMovimientoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            new TextFunctions().SoloNumero(sender, e, TxtMovimientoID);
        }


    }
}

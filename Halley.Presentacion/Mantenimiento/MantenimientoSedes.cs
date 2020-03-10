using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.CapaLogica.Empresa;
using Halley.Entidad.Empresa;
using Halley.Configuracion;

namespace Halley.Presentacion.Mantenimiento
{
    public partial class MantenimientoSedes : UITemplateAccess
    {
        #region Variables
        string TipoGuardar = "";
        E_Sede ObjSede = new E_Sede();
        CL_Empresas ObjCL_Empresas = new CL_Empresas();
        DataTable DtSede;
        DataTable DtAlmacenesHalley;
        DataTable DtTipoAlmacen;
        private TextFunctions ObjTextFunctions = new TextFunctions();
        #endregion

        public MantenimientoSedes()
        {
            InitializeComponent();
        }

        private void MantenimientoVehiculos_Load(object sender, EventArgs e)
        {

            //agregar producto
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");

            DtSede = ObjCL_Empresas.GetSedes();
            TdgSedes.SetDataBinding(DtSede, "", true);
            ocultarToolStrip();
            ReadOnly(true);

            //agregar sedes
            CboSede.HoldFields();
            CboSede.DataSource = DtSede;
            CboSede.DisplayMember = "NomSede";
            CboSede.ValueMember = "SedeID";

            //agregar almaceneshalley
            DtAlmacenesHalley = new DataTable();
            DtAlmacenesHalley = ObjCL_Empresas.GetAlmacenHalley();
            CboAlmacenesHalley.HoldFields();
            CboAlmacenesHalley.DataSource = DtAlmacenesHalley;
            CboAlmacenesHalley.DisplayMember = "Descripcion";
            CboAlmacenesHalley.ValueMember = "ID";

            //agregar Tipo de alamcenes
            DtTipoAlmacen = new DataTable();
            DtTipoAlmacen.Columns.Add("IDTipo", typeof(string));
            DtTipoAlmacen.Columns.Add("Descripcion", typeof(string));
            DataRow dr1 = DtTipoAlmacen.NewRow();
            dr1["IDTipo"] = "C";
            dr1["Descripcion"] = "Consumo";
            DtTipoAlmacen.Rows.Add(dr1);
            DataRow dr2 = DtTipoAlmacen.NewRow();
            dr2["IDTipo"] = "D";
            dr2["Descripcion"] = "Desperdicio";
            DtTipoAlmacen.Rows.Add(dr2);
            CboTipoAlmacen.HoldFields();
            CboTipoAlmacen.DataSource = DtTipoAlmacen;
            CboTipoAlmacen.DisplayMember = "Descripcion";
            CboTipoAlmacen.ValueMember = "IDTipo";

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

                ObtenerDatosControles();
                ErrProvider.Clear();
                ObtenerDatosControles();
                if (TipoGuardar == "Nuevo")
                {
                    ObjCL_Empresas.InsertSede(ObjSede);
                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);

                    //agregar
                    DataRow Dr = DtSede.NewRow();
                    Dr["SedeID"] = ObjSede.SedeID;
                    Dr["NomSede"] = ObjSede.NomSede;
                    Dr["Numero"] = ObjSede.Numero;
                    Dr["Interior"] = ObjSede.Interior;
                    Dr["Zona"] = ObjSede.Zona;
                    Dr["Distrito"] = ObjSede.Distrito;
                    Dr["Provincia"] = ObjSede.Provincia;
                    Dr["Departamento"] = ObjSede.Departamento;
                    DtSede.Rows.Add(Dr);
                }
                else if (TipoGuardar == "Actualizar")
                {
                    ObjCL_Empresas.UpdateSede(ObjSede, "A");
                    lblEstado.Text = "Se actualizó correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);

                    //actualizar
                    DataRow[] customerRow = DtSede.Select("SedeID = '" + ObjSede.SedeID + "'");
                    customerRow[0]["NomSede"] = ObjSede.NomSede;
                    customerRow[0]["Numero"] = ObjSede.Numero;
                    customerRow[0]["Interior"] = ObjSede.Interior;
                    customerRow[0]["Zona"] = ObjSede.Zona;
                    customerRow[0]["Distrito"] = ObjSede.Distrito;
                    customerRow[0]["Provincia"] = ObjSede.Provincia;
                    customerRow[0]["Departamento"] = ObjSede.Departamento;
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

                if (MessageBox.Show("¿Está seguro que desea eliminar la sede?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ObtenerDatosControles();
                    ObjCL_Empresas.UpdateSede(ObjSede, "E");
                    lblEstado.Text = "Se eliminó la sede: " + TxtNomSede.Text + ".";
                    lblEstado.ForeColor = Color.Red;

                    //Eliminar
                    DataRow[] customerRow = DtSede.Select("SedeID = '" + ObjSede.SedeID + "'");
                    customerRow[0].Delete();
                }
                else
                    OcultarBotones(true, true, false, false, false, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarBotones(bool Buscar, bool Nuevo, bool Cancelar, bool Editar, bool Guardar, bool Eliminar)
        {
            BtnNuevo.Visible = Nuevo;
            BtnCancelar.Visible = Cancelar;
            BtnEditar.Visible = Editar;
            BtnGuardar.Visible = Guardar;
            BtnEliminar.Visible = Eliminar;
        }

        private void ReadOnly(bool Valor)
        {
            TxtSedeID.ReadOnly = Valor;
            TxtNomSede.ReadOnly = Valor;
            TxtNumero.ReadOnly = Valor;
            TxtInterior.ReadOnly = Valor;
            TxtZona.ReadOnly = Valor;
            TxtDistrito.ReadOnly = Valor;
        }

        private bool validarControles()
        {
            if (TxtNomSede.Text == "") { ErrProvider.SetError(TxtNomSede, "Debe Ingresar una marca."); return false; }
            if (TxtSedeID.Text == "") { ErrProvider.SetError(TxtSedeID, "Debe Ingresar el codigo de la sede (5 digitos)."); return false; }
            return true;
        }

        private void ObtenerDatosControles()
        {
            ObjSede = new E_Sede();
            ObjSede.SedeID = TxtSedeID.Text;
            ObjSede.NomSede = TxtNomSede.Text;
            if(TxtNumero.Text != "")
                ObjSede.Numero = Convert.ToInt32(TxtNumero.Text);
            if (TxtInterior.Text != "")
                ObjSede.Interior = Convert.ToInt32(TxtInterior.Text);
            ObjSede.Zona = TxtZona.Text;
            ObjSede.Distrito = TxtDistrito.Text;
            ObjSede.Provincia = TxtProvincia.Text;
            ObjSede.Departamento = TxtDepartamento.Text;
            ObjSede.UsuarioID = AppSettings.UserID;
        }

        private void LimpiarTextos()
        {
            TxtSedeID.Text = "";
            TxtNomSede.Text = "";
            TxtNumero.Text = "";
            TxtInterior.Text = "";
            TxtZona.Text = "";
            TxtDistrito.Text = "";
            TxtProvincia.Text = "";
            TxtDepartamento.Text = "";
        }

        private void TxtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtNumero);
        }

        private void TxtInterior_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtInterior);
        }

        private void TdgSedes_DoubleClick(object sender, EventArgs e)
        {
            ReadOnly(false);
            TxtSedeID.Text = TdgSedes.Columns["SedeID"].Value.ToString();
            TxtNomSede.Text = TdgSedes.Columns["NomSede"].Value.ToString();
            TxtNumero.Text = TdgSedes.Columns["Numero"].Value.ToString();
            TxtInterior.Text = TdgSedes.Columns["Interior"].Value.ToString();
            TxtZona.Text = TdgSedes.Columns["Zona"].Value.ToString();
            TxtDistrito.Text = TdgSedes.Columns["Distrito"].Value.ToString();
            TxtProvincia.Text = TdgSedes.Columns["Provincia"].Value.ToString();
            TxtDepartamento.Text = TdgSedes.Columns["Departamento"].Value.ToString();
            ReadOnly(true);
            OcultarBotones(true, true, false, true, false, true);
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (c1cboCia.SelectedIndex != -1 & CboSede.SelectedIndex != -1 & CboAlmacenesHalley.SelectedIndex != -1 & CboTipoAlmacen.SelectedIndex != -1)
                {
                    string AlmacenID = "";
                    AlmacenID = c1cboCia.SelectedValue.ToString() + CboSede.SelectedValue.ToString() + CboAlmacenesHalley.SelectedValue.ToString();
                    ObjCL_Empresas.InsertAlmacen(AlmacenID, CboAlmacenesHalley.Columns["Descripcion"].Value.ToString(), CboSede.SelectedValue.ToString(), c1cboCia.SelectedValue.ToString(), TxtTelefono.Text, CboTipoAlmacen.SelectedValue.ToString(), AppSettings.UserID);
                    MessageBox.Show("Se asigno correctamente el Almacen", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (c1cboCia.SelectedIndex != -1) { ErrProvider.SetError(c1cboCia, "Debe Seleccionar una Empresa."); }
                    if (CboSede.SelectedIndex != -1) { ErrProvider.SetError(CboSede, "Debe seleccionar una Sede");}
                    if (CboAlmacenesHalley.SelectedIndex != -1) { ErrProvider.SetError(CboAlmacenesHalley, "Debe Seleccionar un Almacen.");}
                    if (CboTipoAlmacen.SelectedIndex != -1) { ErrProvider.SetError(CboTipoAlmacen, "Debe Seleccionar un tipo de Almacen."); }
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

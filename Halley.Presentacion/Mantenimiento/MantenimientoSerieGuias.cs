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
using Halley.CapaLogica.Almacen;
using Halley.CapaLogica.Ventas;

namespace Halley.Presentacion.Mantenimiento
{
    public partial class MantenimientoSerieGuias : UITemplateAccess
    {
        CL_GuiaRemision ObjCL_GuiaRemision = new CL_GuiaRemision();
        private TextFunctions ObjTextFunctions = new TextFunctions();
        string SerieT = "";
        string SerieR = "";
        string SerieN = "";
        Int32 NumeroR = 0;
        Int32 NumeroT = 0;
        Int32 NumeroN = 0;
        string TipoGuardar = "";

        public MantenimientoSerieGuias()
        {
            InitializeComponent();
        }

        private void MantenimientoSerieGuias_Load(object sender, EventArgs e)
        {
            //traer las empresas
            
            c1Combo.FillC1Combo(this.c1cboCiaR, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");

            //obtener todas las sedes
            DataTable DtsedesR = new CL_Empresas().GetSedes();
            DataTable DtSedesT = new DataTable();
            DtSedesT = DtsedesR.Copy();
            CboSedeR.HoldFields();
            CboSedeR.DataSource = DtsedesR;
            CboSedeR.DisplayMember = "NomSede";
            CboSedeR.ValueMember = "SedeID";

            ocultarToolStrip();

            lblEstado.Text = "";
            OcultarBotones(false, true, false, false, false, false);
            ReadOnly(true);


        }

        private void CboSedeR_SelectedValueChanged(object sender, EventArgs e)
        {
            //traer la serie y numero de las guias
            if (c1cboCiaR.SelectedIndex != -1 & CboSedeR.SelectedIndex != -1)
            {
                ReadOnly(false);
                LimpiarTextos();
                DataTable DtGuias = new DataTable();
                DtGuias = ObjCL_GuiaRemision.GetSerieGuia(c1cboCiaR.SelectedValue.ToString() + CboSedeR.SelectedValue.ToString());
                if (DtGuias.Rows.Count > 0)
                {
                    TxtNumeroR.Text = DtGuias.Rows[0]["GuiaRemitente"].ToString();
                    TxtNumeroT.Text = DtGuias.Rows[0]["GuiaTransporte"].ToString();
                    txtNumeroN.Text = DtGuias.Rows[0]["NotaCredito"].ToString();
                    TxtSerieR.Text = DtGuias.Rows[0]["SerieGuiaRID"].ToString();
                    TxtSerieT.Text = DtGuias.Rows[0]["SerieGuiaTID"].ToString();
                    txtSerieN.Text = DtGuias.Rows[0]["SerieGuiaNID"].ToString();
                }
                ReadOnly(true);
                OcultarBotones(true, true, false, true, false, true);  
            }

        }

        private void LimpiarTextos()
        {
            TxtNumeroR.Text = "";
            TxtNumeroT.Text = "";
            txtNumeroN.Text = "";
            TxtSerieR.Text = "";
            TxtSerieT.Text = "";
            txtSerieN.Text = "";
           
        }

        private void ReadOnly(bool Valor)
        {
            TxtNumeroR.ReadOnly = Valor;
            TxtNumeroT.ReadOnly = Valor;
            txtNumeroN.ReadOnly = Valor;
            TxtSerieR.ReadOnly = Valor;
            TxtSerieT.ReadOnly = Valor;
            txtSerieN.ReadOnly = Valor;
        }

        private void OcultarBotones(bool Buscar, bool Nuevo, bool Cancelar, bool Editar, bool Guardar, bool Eliminar)
        {
            BtnNuevo.Visible = Nuevo;
            BtnCancelar.Visible = Cancelar;
            BtnGuardar.Visible = Guardar;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ErrProvider.Clear();
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
                    ObjCL_GuiaRemision.InsertSerieGuia(c1cboCiaR.SelectedValue.ToString() + CboSedeR.SelectedValue.ToString(), SerieR,NumeroR,SerieT,NumeroT,SerieN,NumeroN);
                    lblEstado.Text = "Se guardo correctamente el registro";
                    lblEstado.ForeColor = Color.Black;
                    ReadOnly(true);

                }
                else if (TipoGuardar == "Actualizar" & RbR.Checked == true)
                {
                    int Valor = 0;
                    Valor = ObjCL_GuiaRemision.UpdateSerieGuiaR(c1cboCiaR.SelectedValue.ToString() + CboSedeR.SelectedValue.ToString(), SerieR, NumeroR);

                    //if (Valor > 0)
                    //{
                        lblEstado.Text = "Se actualizó correctamente el registro";
                        lblEstado.ForeColor = Color.Black;
                        ReadOnly(true);
                    //}
                    //else
                    //    MessageBox.Show("No se actualizo ningun registro, tal ves no exista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (TipoGuardar == "Actualizar" & RbT.Checked == true)
                {

                    Int32 Valor = 0;
                    Valor = ObjCL_GuiaRemision.UpdateSerieGuiaT(c1cboCiaR.SelectedValue.ToString() + CboSedeR.SelectedValue.ToString(), SerieT, NumeroT);

                    //if (Valor > 0)
                    //{
                        lblEstado.Text = "Se actualizó correctamente el registro";
                        lblEstado.ForeColor = Color.Black;
                        ReadOnly(true);
                    //}
                    //else
                    //    MessageBox.Show("No se actualizo ningun registro, tal ves no exista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (TipoGuardar == "Actualizar" & rbNotaCredito.Checked== true)
                {
                    int Valor = 0;
                    Valor = new  CL_NotaCredito().UpdateSerieGuiaN(c1cboCiaR.SelectedValue.ToString() + CboSedeR.SelectedValue.ToString(), SerieN, NumeroN);

                    //if (Valor > 0)
                    //{
                        lblEstado.Text = "Se actualizó correctamente el registro";
                        lblEstado.ForeColor = Color.Black;
                        ReadOnly(true);
                    //}
                    //else
                    //    MessageBox.Show("No se actualizo ningun registro, tal ves no exista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                TipoGuardar = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReadOnly(false);
            }
        }

        private bool validarControles()
        {
            if (TipoGuardar == "Actualizar" & RbR.Checked == true)
            {
                if (CboSedeR.SelectedIndex == -1) { ErrProvider.SetError(CboSedeR, "Debe seleccionar la sede."); return false; }
                if (c1cboCiaR.SelectedIndex == -1) { ErrProvider.SetError(c1cboCiaR, "Debe seleccionar la empresa."); return false; }
                if (TxtSerieR.Text == "" | TxtSerieR.Text.Length != 3) { ErrProvider.SetError(TxtSerieR, "Debe ingresar la serie de remisión y tener longitud de 3."); return false; }
                if (TxtNumeroR.Text == "") { ErrProvider.SetError(TxtNumeroR, "Debe ingresar el numero de remisión"); return false; }
                return true;
            }
            else if (TipoGuardar == "Actualizar" & RbT.Checked == true)
            {
                if (CboSedeR.SelectedIndex == -1) { ErrProvider.SetError(CboSedeR, "Debe seleccionar la sede."); return false; }
                if (c1cboCiaR.SelectedIndex == -1) { ErrProvider.SetError(c1cboCiaR, "Debe seleccionar la empresa."); return false; }
                if (TxtSerieT.Text == "" | TxtSerieT.Text.Length != 3) { ErrProvider.SetError(TxtSerieT, "Debe ingresar la serie de transporte y tener longitud de 3."); return false; }
                if (TxtNumeroT.Text == "") { ErrProvider.SetError(TxtNumeroT, "Debe ingresar el numero de transporte"); return false; }
                return true;
            }
            else if (TipoGuardar == "Actualizar" & rbNotaCredito.Checked == true)
            {
                if (CboSedeR.SelectedIndex == -1) { ErrProvider.SetError(CboSedeR, "Debe seleccionar la sede."); return false; }
                if (c1cboCiaR.SelectedIndex == -1) { ErrProvider.SetError(c1cboCiaR, "Debe seleccionar la empresa."); return false; }
                if (txtSerieN.Text == "" | TxtSerieT.Text.Length != 3) { ErrProvider.SetError(txtSerieN, "Debe ingresar la serie de Nota de credito y tener longitud de 3."); return false; }
                if (txtNumeroN.Text == "") { ErrProvider.SetError(txtNumeroN, "Debe ingresar el numero de la Nota de credito"); return false; }
                return true;
            }
            else if (TipoGuardar == "Nuevo")
            {
                if (CboSedeR.SelectedIndex == -1) { ErrProvider.SetError(CboSedeR, "Debe seleccionar la sede."); return false; }
                if (c1cboCiaR.SelectedIndex == -1) { ErrProvider.SetError(c1cboCiaR, "Debe seleccionar la empresa."); return false; }
                if (TxtSerieR.Text == "" | TxtSerieR.Text.Length != 3) { ErrProvider.SetError(TxtSerieR, "Debe ingresar la serie de remisión y tener longitud de 3."); return false; }
                if (TxtSerieT.Text == "" | TxtSerieT.Text.Length != 3) { ErrProvider.SetError(TxtSerieT, "Debe ingresar la serie de transporte y tener longitud de 3."); return false; }
                if (txtSerieN.Text == "" | TxtSerieT.Text.Length != 3) { ErrProvider.SetError(txtSerieN, "Debe ingresar la serie de transporte y tener longitud de 3."); return false; }
                if (TxtNumeroR.Text == "") { ErrProvider.SetError(TxtNumeroR, "Debe ingresar el numero de remisión"); return false; }
                if (TxtNumeroT.Text == "") { ErrProvider.SetError(TxtNumeroT, "Debe ingresar el numero de transporte"); return false; }
                if (txtNumeroN.Text == "") { ErrProvider.SetError(txtNumeroN, "Debe ingresar el numero de transporte"); return false; }
                return true;
            }
            return true;
        }

        private void ObtenerDatosControles()
        {
            SerieR = TxtSerieR.Text;
            SerieT = TxtSerieT.Text;
            SerieN = txtSerieN.Text;
            if(TxtNumeroR.Text != "")
                NumeroR = Convert.ToInt32(TxtNumeroR.Text);
            if (TxtNumeroT.Text != "")
                NumeroT = Convert.ToInt32(TxtNumeroT.Text);
            if (txtNumeroN.Text != "")
                NumeroN = Convert.ToInt32(txtNumeroN.Text);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //desahcer
            ErrProvider.Clear();
            OcultarBotones(true, true, false, false, false, false);
            ReadOnly(false);
            LimpiarTextos();
            ReadOnly(true);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            TipoGuardar = "Nuevo";
            OcultarBotones(false, false, true, false, true, false);
            ReadOnly(false);
            LimpiarTextos();
        }

        private void BtnEditar_Click_1(object sender, EventArgs e)
        {
            TipoGuardar = "Actualizar";
            OcultarBotones(false, false, true, false, true, false);
            ReadOnly(false);
        }

        private void TxtSerieT_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtSerieT);
        }

        private void TxtNumeroT_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtNumeroT);
        }

        private void TxtSerieR_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtSerieR);
        }

        private void TxtNumeroR_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtNumeroR);
        }

        private void txtSerieN_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, txtSerieN);
        }

        private void txtNumeroN_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, txtNumeroN);
        }
    }
}

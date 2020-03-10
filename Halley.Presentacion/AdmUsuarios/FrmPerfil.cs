using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1TrueDBGrid;
using Halley.Utilitario;
using Halley.Configuracion;
using Halley.CapaLogica.Users;


namespace Halley.Presentacion.AdmUsuarios
{
    public partial class FrmPerfil : UITemplateAccess
    {
        int _perfilID = 0;
        DataTable dt;

        public FrmPerfil()
        {
            InitializeComponent();
            this.NewClick += new delegateNewClick(frmPerfil_NewClick);
            this.SaveClick += new delegateSaveClick(frmPerfil_SaveClick);
            this.EditClick += new delegateEditClick(frmPerfil_EditClick);
            this.UndoClick += new delegateUndoClick(frmPerfil_UndoClick);
            this.DeleteClick += new delegateDeleteClick(frmPerfil_DeleteClick);
            this.RefreshClick += new delegateRefreshClick(frmPerfil_RefreshClick);
            this.PrintClick += new delegatePrintClick(frmPerfil_PrintClick);
            this.GetValue += new delegateGetValue(frmPerfil_GetValue);
        }

        void frmPerfil_GetValue(string value)
        {
            try
            {
                DataTable dt = new CL_Perfil().Obtener(Convert.ToInt32(value), null);
                foreach (DataRow dr in dt.Rows)
                {

                    _perfilID = Convert.ToInt32(dr["perfilID"]);
                    this.TxtDescripcion.Text = dr["NomPerfil"].ToString().Trim();
                    //Listar en el treevie los accesos del perfil
                    this.accesMenu1.Perfil = true;
                    this.accesMenu1.PerfilID = _perfilID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nMetodo : frmPerfil_GetValue()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            this.List();
            this.Data = dt;
            this.Grid = this.c1TrueDBGrid1;
            this.Fields();
            this.TxtDescripcion.ReadOnly = true;

           this.accesMenu1.PopulateMenu(0, new CL_Menu().GetMenuAcceso(), null);
        }

        void frmPerfil_PrintClick()
        {

        }

        void frmPerfil_RefreshClick()
        {
            this.List();
            this.Data = dt;
            this.Grid = this.c1TrueDBGrid1;
            this.Fields();
            this.InitializeCounter();
        }

        void frmPerfil_DeleteClick()
        {
            if (_perfilID == 0) return;

            try
            {
                if (MessageBox.Show("Estas seguro de Eliminar?, Existen  menus y usuarios asociado al perfil.", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CL_Perfil objPerfil = new CL_Perfil();
                    objPerfil.Eliminar(_perfilID,0);
                    this.accesMenu1.Clear();
                    this.TxtDescripcion.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nMetodo : frmPerfil_DeleteClick()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void frmPerfil_UndoClick()
        {

        }
        void frmPerfil_EditClick()
        {

        }

        void frmPerfil_SaveClick()
        {
            try
            {
                GuardarDatos();
                this.TxtDescripcion.Text = "";
                this.TxtDescripcion.ReadOnly = true;
                this.accesMenu1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nMetodo : frmPerfil_SaveClick()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void frmPerfil_NewClick()
        {
            _perfilID = 0;
            this.accesMenu1.Clear();
            this.TxtDescripcion.Text = "";
            this.TxtDescripcion.ReadOnly = false;
            this.TxtDescripcion.Select();
        }

        void GuardarDatos()
        {
            if (this.TxtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el nombre del perfil.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.TxtDescripcion.Select();
                return;
            }

            if (this.accesMenu1.Data.Rows.Count == 0)
            {
                MessageBox.Show("Debe activar la casilla de verificación de los sub-modulos del sistema.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.accesMenu1.Select();
                return;
            }


            CL_Perfil objPerfil = new CL_Perfil();
            if (_perfilID == 0)
            {
                string xml = new BaseFunctions().GetXML(this.accesMenu1.Data);
                _perfilID = objPerfil.Insertar_Perfil(0, this.TxtDescripcion.Text, true, 1, xml);
                MessageBox.Show("El perfil de grabó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string xml = new BaseFunctions().GetXML(this.accesMenu1.Data).Replace("NewDataSet", "DocumentElement");
                objPerfil.Modificar_Perfil(_perfilID, this.TxtDescripcion.Text, true, 1, xml.Replace("Table", "UsersAcceso"));
                MessageBox.Show("El perfil de modificó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void List()
        {
            try
            {
                dt = new DataTable();
                DataColumn dc;

                dt = new CL_Perfil().Obtener(0, null);
                dc = new DataColumn("Imagen", typeof(string)); dt.Columns.Add(dc);

                foreach (DataRow dr in dt.Rows)
                {
                    dr["Imagen"] = "     Imagen";//new BaseFunctions().GetImageFromByteArray(new BaseFunctions().Image2Bytes(Properties.Resources.record));
                }
                C1.Win.C1TrueDBGrid.ValueItemCollection v = this.c1TrueDBGrid1.Columns["Imagen"].ValueItems.Values;
                C1.Win.C1TrueDBGrid.ValueItem Item = new C1.Win.C1TrueDBGrid.ValueItem();

                Item.Value = "     Imagen";
                Item.DisplayValue = Properties.Resources.record;
                v.Add(Item);
                this.c1TrueDBGrid1.SetDataBinding(dt, "", true);
                this.c1TrueDBGrid1.Columns.Add(new C1DataColumn("Imagen", "Imagen", typeof(byte[])));

                this.c1TrueDBGrid1.Columns["Imagen"].ValueItems.Translate = true;

                this.InitializeCounter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nMetodo : List()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  
    }
}

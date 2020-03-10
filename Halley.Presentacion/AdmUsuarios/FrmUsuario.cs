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
using Halley.CapaLogica.Empresa;
using Halley.CapaLogica.Almacen;
using RRV.Seguridad;


namespace Halley.Presentacion.AdmUsuarios
{
    public partial class FrmUsuario : UITemplateAccess
    {
        int _UserID = 0;
        int _PerfilID = 0;
        DataTable dt;
        DataTable dtUnidadNegocioTemp;
        DataColumn dcAlmacen;
        bool Flag = false;

        public FrmUsuario()
        {
            InitializeComponent();
            this.NewClick += new delegateNewClick(frmUsuario_NewClick);
            this.SaveClick += new delegateSaveClick(frmUsuario_SaveClick);
            this.EditClick += new delegateEditClick(frmUsuario_EditClick);
            this.UndoClick += new delegateUndoClick(frmUsuario_UndoClick);
            this.DeleteClick += new delegateDeleteClick(frmUsuario_DeleteClick);
            this.RefreshClick += new delegateRefreshClick(frmUsuario_RefreshClick);
            this.PrintClick += new delegatePrintClick(frmUsuario_PrintClick);
           this.GetValue += new delegateGetValue(frmPerfil_GetValue);
           this.VerDatos += new delegateMostrar(frmPerfil_GetValue);
        }


        void frmPerfil_GetValue(string value)
        {
            try
            {
                LimpiarTextos();
                DataTable dt = new CL_Usuario().Obtener(Convert.ToInt32(value), 0, "0", null);
                foreach (DataRow dr in dt.Rows)
                {
                    
                    Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                    objCrypto.Key = AppSettings.Key;
                    objCrypto.IV = AppSettings.IV;

                    _UserID = Convert.ToInt32(dr["UserID"]);
                    _PerfilID = Convert.ToInt32(dr["PerfilID"]);
                    this.c1cboCia.SelectedValue = Convert.ToString(dr["EmpresaID"]);
                    this.txtDescripcion.Text = dr["Descripcion"].ToString().Trim();
                    this.txtUsuario.Text = dr["Usuario"].ToString().Trim();
                    if (dr["Password"].ToString().Trim().Length > 0)
                        this.txtPassword.Text = objCrypto.DescifrarCadena(dr["Password"].ToString().Trim());
                    this.txtCorreo.Text = dr["Correo"].ToString().Trim();
                    this.TxtDireccion.Text = dr["Direccion"].ToString().Trim();
                    this.TxtTelefono.Text = dr["Telefono"].ToString().Trim();
                    this.chkMaster.Checked = Convert.ToBoolean(dr["FlgMaster"]);
                    this.chkActivo.Checked = Convert.ToBoolean(dr["FlgEst"]);
                    this.c1cboPerfil.SelectedValue = Convert.ToInt32(dr["PerfilID"]);

                    //Listar en el treeview los accesos del perfil y del usuario
                    this.accesMenu1.Perfil = false;
                    this.accesMenu1.UserID = _UserID;
                    this.accesMenu1.PerfilID = _PerfilID;

                    //Listar en el treeview de unidades de negocio los accesos del usuario
                    DataTable dtTabla = new CL_UsuarioAlmacen().Obtener(_UserID, null);

                    //Limpiar DataTable
                    dtUnidadNegocioTemp.Rows.Clear();

                    //Limpiar CheckBox del Treeview
                    CheckAllNodes(this.tvwAlmacen.Nodes, false);

                    foreach (DataRow dRow in dtTabla.Rows)
                    {
                        DataRow drRow = dtUnidadNegocioTemp.NewRow();
                        drRow["UsuarioAlmacenID"] = Convert.ToInt32(dRow["UsuarioAlmacenID"]);
                        drRow["AlmacenID"] = dRow["AlmacenID"].ToString();
                        drRow["TipoOper"] = 3;
                        dtUnidadNegocioTemp.Rows.Add(drRow);
                        Flag = true;
                        CheckNodes(this.tvwAlmacen.Nodes, dRow["AlmacenID"].ToString());
                    }
                }
                Flag = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nMetodo : frmUsuario_GetValue()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                this.List();
                this.Data = dt;
                this.Grid = this.c1TrueDBGrid1;
                this.Fields();

                c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
                c1Combo.FillC1Combo(this.c1cboPerfil, new CL_Helper().GetSqlStringCommand("Select PerfilID,NomPerfil From Usuario.Perfil Where FlgEst=1 Order By NomPerfil"), "NomPerfil", "PerfilID");
                this.accesMenu1.PopulateMenu(0, new CL_Menu().GetMenuAcceso(), null);

                this.CargarEstructura();

               // Cargar las Unidades de Negocio
               CheckAllNodes(this.tvwAlmacen.Nodes, false);
             //  this.CargarUnidadNegocio(c1cboCia.SelectedValue.ToString());
               this.habilitar(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nMetodo : FrmUsuario_Load_GetValue()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void frmUsuario_PrintClick()
        {

        }

        void frmUsuario_RefreshClick()
        {
            this.List();
            this.Data = dt;
            this.Grid = this.c1TrueDBGrid1;
            this.Fields();
        }

        void frmUsuario_DeleteClick()
        {
            if (_UserID == 0) return;
            try
            {
                if (MessageBox.Show("Estas seguro de Eliminar?, Existen accesos asociado al usuario.", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CL_Usuario objUsuario = new CL_Usuario();
                    objUsuario.Eliminar(_UserID);
                    LimpiarTextos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        void frmUsuario_UndoClick()
        {

        }

        void frmUsuario_EditClick()
        {
            if (txtDescripcion.Text.Trim() != "")
            {
                habilitar(false);
            }

        }

        void frmUsuario_SaveClick()
        {
            try
            {
                GuardarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void frmUsuario_NewClick()
        {
            LimpiarTextos();
            habilitar(false);
            _UserID = 0;
        }

        void LimpiarTextos()
        {
            _UserID = 0;
           // this.c1cboCia.Text = "";
            //Seleccionar la Primera Empresa
            this.c1cboCia.SelectedIndex = 0;
            this.txtDescripcion.Text = "";
            this.txtDescripcion.Select();
            this.txtUsuario.Text = "";
            this.txtPassword.Text = "";
            this.txtCorreo.Text = "";
            this.TxtDireccion.Text = "";
            this.TxtTelefono.Text = "";
            this.chkMaster.Checked = false;
            this.chkActivo.Checked = true;
            this.c1cboPerfil.Text = "";
            this.accesMenu1.Clear();
            CheckAllNodes(this.tvwAlmacen.Nodes, false);
            dtUnidadNegocioTemp.Rows.Clear();
            this.txtDescripcion.Focus();
        }

        void habilitar(bool valor)
        {
            this.txtDescripcion.ReadOnly = valor;
            this.txtCorreo.ReadOnly = valor;
            this.TxtDireccion.ReadOnly = valor;
            this.txtPassword.ReadOnly = valor;
            this.TxtTelefono.ReadOnly = valor;
            this.txtUsuario.ReadOnly = valor;
            this.c1cboCia.ReadOnly = valor;
            this.c1cboPerfil.ReadOnly = valor; 
        }


        void GuardarDatos()
        {          
            if (this.txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar la descripción del usuario.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDescripcion.Select();
                return;
            }
            if (this.txtUsuario.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el usuario.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtUsuario.Select();
                return;
            }
            if (this.txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el password.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPassword.Select();
                return;
            }
            if (this.c1cboPerfil.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el perfil.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.c1cboPerfil.Select();
                return;
            }
            if (this.txtCorreo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el correo.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCorreo.Select();
                return;
            }
            if (this.dtUnidadNegocioTemp.Rows.Count == 0)
            {
                MessageBox.Show("Debe activar la casilla de verificación de los Almacenes.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tvwAlmacen.Select();
                return;
            }

            CL_Usuario objUsuario = new CL_Usuario();

            Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
            objCrypto.Key = AppSettings.Key;
            objCrypto.IV = AppSettings.IV;
            string Password = "";
            Password = objCrypto.CifrarCadena(this.txtPassword.Text.Trim());

            if (_UserID == 0)
            {
                foreach (DataRow drow in this.accesMenu1.Data.Rows)
                {
                    drow["TipoOper"] = 0;
                }
                string xml = new BaseFunctions().GetXML(this.accesMenu1.Data).Replace("NewDataSet", "DocumentElement");
                string xmlUN = new BaseFunctions().GetXML(dtUnidadNegocioTemp).Replace("NewDataSet", "DocumentElement");
                objUsuario.Insertar_Usuario(_UserID, Convert.ToInt32(this.c1cboPerfil.Columns[0].Value), Convert.ToString(this.c1cboCia.Columns[0].Value), txtUsuario.Text.Trim(), txtDescripcion.Text.Trim(), Password, txtCorreo.Text.Trim(),TxtDireccion.Text.Trim(),TxtTelefono.Text.Trim(), chkMaster.Checked, chkActivo.Checked, AppSettings.UserID, xml.Replace("Table", "Users_Acceso"), xmlUN.Replace("Table", "UsuarioUnidadNegocio"));
                MessageBox.Show("El usuario de grabó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
            }
            else
            {
                string xml = new BaseFunctions().GetXML(this.accesMenu1.Data).Replace("NewDataSet", "DocumentElement");
                string xmlUN = new BaseFunctions().GetXML(dtUnidadNegocioTemp).Replace("NewDataSet", "DocumentElement");
                objUsuario.Modificar_Usuario(_UserID, Convert.ToInt32(this.c1cboPerfil.Columns[0].Value), Convert.ToString(this.c1cboCia.Columns[0].Value), txtUsuario.Text.Trim(), txtDescripcion.Text.Trim(), Password, txtCorreo.Text.Trim(),TxtDireccion.Text.Trim(),TxtTelefono.Text.Trim(), chkMaster.Checked, chkActivo.Checked, AppSettings.UserID, xml.Replace("Table", "Users_Acceso"), xmlUN.Replace("Table", "UsuarioUnidadNegocio"));
                MessageBox.Show("El ususario de modificó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
            }
            habilitar(true);
        }

        private void c1cboPerfil_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable dt = new CL_Perfil().Obtener(Convert.ToInt32(c1cboPerfil.Columns[0].Value), null);
            foreach (DataRow dr in dt.Rows)
            {
                _PerfilID = Convert.ToInt32(dr["PerfilID"]);
                //Listar en el treevie los accesos del perfil
                this.accesMenu1.Perfil = true;
                this.accesMenu1.PerfilID = _PerfilID;
            }
        }

        public void List()
        {
            try
            {
                dt = new DataTable();
                DataColumn dc;

                dt = new CL_Usuario().Obtener(0, 0, "0", null);
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

        private void CheckAllNodes(TreeNodeCollection col, Boolean check)
        {
            foreach (TreeNode tN in col)
            {
                tN.Checked = check;
                this.CheckAllNodes(tN.Nodes, check);
            }
        }

        private void CheckNodes(TreeNodeCollection col, string UnidadNegocioID)
        {
            foreach (TreeNode tN in col)
            {
                string[] objectString = tN.Tag.ToString().Split(new char[] { ',' });

                if (objectString[0].ToString() == UnidadNegocioID)
                {
                    tN.Checked = true;
                    if (tN.Parent != null)
                    {
                        tN.Parent.Checked = true;
                    }
                }
                this.CheckNodes(tN.Nodes, UnidadNegocioID);
            }
        }

        private void CargarUnidadNegocio(string EmpresaID)
        {
            try
            {
                DataTable dtUnidadNegocio = new CL_Almacen().ObtenerAlmacen(EmpresaID);
                DataTable dtSede = new BaseFunctions().SelectDistinct(dtUnidadNegocio, "SedeID","NomSede");

                foreach (DataRow drow in dtSede.Rows)
                {
                    TreeNode _node = new TreeNode();
                    _node.Text = drow["NomSede"].ToString();
                    _node.Tag = drow["SedeID"].ToString();
                    _node.ImageIndex = 0;
                    _node.StateImageIndex = 0;
                    _node.SelectedImageIndex = 0;

                    this.tvwAlmacen.Nodes.Add(_node);

                    foreach (DataRow dRow in dtUnidadNegocio.Rows)
                    {
                        if (dRow["SedeID"].ToString() == drow["SedeID"].ToString())
                        {
                            TreeNode _nodesf = new TreeNode();
                            _nodesf.Text = dRow["Descripcion"].ToString();
                            _nodesf.Tag = dRow["AlmacenID"].ToString();
                            _nodesf.ImageIndex = 1;
                            _nodesf.SelectedImageIndex = 1;
                            _nodesf.StateImageIndex = 1;
                            _node.Nodes.Add(_nodesf);
                        }
                    }
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nMetodo : List()", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tvwUnidadNegocio_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //Para marcar y desmarcar todos los nodos            
            foreach (TreeNode oNodo in e.Node.Nodes)
            {
                string[] objectString = oNodo.Tag.ToString().Split(new char[] { ',' });

                if (Flag == false)
                    oNodo.Checked = e.Node.Checked;

                //insertar en el datatable solo las ventanas que es el ultimo nivel
                if (e.Node.Checked == true)
                {
                    if (Flag == false)
                        AgregarUnidadNegocio(objectString[0]);
                }
                if (e.Node.Checked == false)
                {
                    EliminarUnidadnegocio(objectString[0]);
                }
            }

            if (e.Node.Parent != null)
            {
                string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });

                if (!e.Node.Checked == true)
                {
                    //Desmarco
                    e.Node.Parent.NodeFont = new Font(this.tvwAlmacen.Font, FontStyle.Regular);
                    EliminarUnidadnegocio(objectString[0]);
                }
                else
                {
                    e.Node.Parent.NodeFont = new Font(this.tvwAlmacen.Font, FontStyle.Bold);
                    if (Flag == false)
                        AgregarUnidadNegocio(objectString[0]);
                }
            }
        }

        void AgregarUnidadNegocio(string UnidadNegocioID)
        {
            //verificar que no exista
            DataRow exist = dtUnidadNegocioTemp.Rows.Find(UnidadNegocioID);
            if (exist == null)
            {

                DataRow dr = dtUnidadNegocioTemp.NewRow();
                dr["UsuarioAlmacenID"] = 0;
                dr["AlmacenID"] = UnidadNegocioID;
                dr["TipoOper"] = 0;

                dtUnidadNegocioTemp.Rows.Add(dr);
                dr = null;
            }
            else
            {
                if (_UserID != 0)
                {
                    if (Convert.ToInt32(exist["TipoOper"]) != 3)
                    {
                        if (Convert.ToInt32(exist["TipoOper"]) == 2)
                        { exist["TipoOper"] = 1; }
                        if (Convert.ToInt32(exist["TipoOper"]) == 5)
                        { exist["TipoOper"] = 0; }
                    }
                }
            }
        }

        void EliminarUnidadnegocio(string UnidadNegocioID)
        {
            DataRow drExist = dtUnidadNegocioTemp.Rows.Find(UnidadNegocioID);
            if (drExist != null)
            {
                if (Convert.ToInt32(drExist["TipoOper"]) == 0)
                { drExist["TipoOper"] = 5; }
                if (Convert.ToInt32(drExist["TipoOper"]) == 1 || Convert.ToInt32(drExist["TipoOper"]) == 3)
                    drExist["TipoOper"] = 2;
            }
            drExist = null;
        }

        void CargarEstructura()
        {
            dtUnidadNegocioTemp = new DataTable("UsuarioAlmacen");
            dcAlmacen = new DataColumn("UsuarioAlmacenID", typeof(int)); dtUnidadNegocioTemp.Columns.Add(dcAlmacen);
            dcAlmacen = new DataColumn("AlmacenID", typeof(string)); dtUnidadNegocioTemp.Columns.Add(dcAlmacen);
            dcAlmacen = new DataColumn("TipoOper", typeof(int)); dcAlmacen.DefaultValue = 0; dtUnidadNegocioTemp.Columns.Add(dcAlmacen);
            //Crear PK de la tabla
            DataColumn[] pk = new DataColumn[1];
            pk[0] = dtUnidadNegocioTemp.Columns["AlmacenID"];
            dtUnidadNegocioTemp.PrimaryKey = pk;
        }

        private void tvwUnidadNegocio_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MessageBox.Show("No se permiten caracteres vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtUsuario.Text = this.txtUsuario.Text.ToString().TrimEnd();
                this.txtUsuario.Select(this.txtUsuario.Text.Length, 0);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MessageBox.Show("No se permiten caracteres vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPassword.Text = this.txtPassword.Text.ToString().TrimEnd();
                this.txtPassword.Select(this.txtPassword.Text.Length, 0);
            }
        }

        private void c1cboCia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c1cboCia.SelectedValue != null)
            {
                CheckAllNodes(this.tvwAlmacen.Nodes, false);
                this.tvwAlmacen.Nodes.Clear();
                this.CargarUnidadNegocio(c1cboCia.SelectedValue.ToString());
            }
        }

      

    }
}

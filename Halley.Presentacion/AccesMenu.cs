using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Users;

namespace Halley.Presentacion
{
    public partial class AccesMenu : UserControl
    {
        DataTable dtOptions;
        bool find = false;
       
        public DataTable Data
        {
            get { return dtOptions; }
            set { dtOptions = value; }
        }

        DataColumn dcOptions;
        int menuID = 0;

        public AccesMenu()
        {
            InitializeComponent();
            this.lblMenu.Text = "";
        }

        public void Clear()
        {
            perfilID = 0;
            CheckAllNodes(this.treeView1.Nodes, false);
            chkAllowRead.Checked = false;
            chkAllowWrite.Checked = false;
            chkAllowUpdate.Checked = false;
            chkAllowDelete.Checked = false;
            chkAllowPrint.Checked = false;

            //dtOptions.Rows.Clear();
            dtOptions = null;
            Table();
            this.dataGridView1.DataSource = dtOptions;
        }

        private void CheckAllNodes(TreeNodeCollection col, Boolean check)
        {
            foreach (TreeNode tN in col)
            {
                tN.Checked = check;

                this.CheckAllNodes(tN.Nodes, check);
            }
        }

        private void CheckNodes(TreeNodeCollection col, int menuID)
        {
            foreach (TreeNode tN in col)
            {
                string[] objectString = tN.Tag.ToString().Split(new char[] { ';' });                

                if (Convert.ToInt32(objectString[0]) == menuID)
                {
                    tN.Checked = true;
                    if (tN.Parent != null)
                    {
                        tN.Parent.Checked = true;
                    }
                }
                this.CheckNodes(tN.Nodes, menuID);
            }
        }

        void AccessByPerfilID(int perfilID)
        {
            CheckAllNodes(this.treeView1.Nodes, false);
            dtOptions = new CL_Usuario().ObtenerAccesoPerfil(perfilID);
            DataColumn[] pk = new DataColumn[1];
            pk[0] = dtOptions.Columns["MenuID"];
            dtOptions.PrimaryKey = pk;
            this.dataGridView1.DataSource = dtOptions;            

            foreach (DataRow dRow in dtOptions.Rows)
            {

                DataRow[] dRowE = dtOptions.Select("MenuID=" + Convert.ToInt32(dRow["MenuID"]));

                if (dRowE[0]["MenuID"].ToString().Trim() == dRow["MenuID"].ToString().Trim())
                {
                    //AGREGAR EL FLAG AQUI .....
                    find = true;
                    CheckNodes(this.treeView1.Nodes, Convert.ToInt32(dRow["MenuID"].ToString()));

                }
            }
            //AGREGAR EL FLAG AQUI .....
            find = false;
        }
        void AccessByperfilID(int perfilID,int User_Id)
        {
            CheckAllNodes(this.treeView1.Nodes, false);
            dtOptions = new CL_Usuario().ObtenerAccesoUsuarioPerfil(User_Id,perfilID);
            DataColumn[] pk = new DataColumn[1];
            pk[0] = dtOptions.Columns["MenuID"];
            dtOptions.PrimaryKey = pk;
            this.dataGridView1.DataSource = dtOptions;

            foreach (DataRow dRow in dtOptions.Rows)
            {

                DataRow[] dRowE = dtOptions.Select("MenuID=" + Convert.ToInt32(dRow["MenuID"]));

                if (dRowE[0]["MenuID"].ToString().Trim() == dRow["MenuID"].ToString().Trim())
                {
                    //AGREGAR EL FLAG AQUI .....
                    find = true;
                    CheckNodes(this.treeView1.Nodes, Convert.ToInt32(dRow["MenuID"].ToString()));

                }
            }
            //AGREGAR EL FLAG AQUI .....
            find = false;
        }
        void Table()
        {
            dtOptions = new DataTable("UsersAcceso");
            dcOptions = new DataColumn("PerfilID", typeof(int)); dtOptions.Columns.Add(dcOptions);
            dcOptions = new DataColumn("MenuID", typeof(int)); dtOptions.Columns.Add(dcOptions);
            dcOptions = new DataColumn("Activo", typeof(bool)); dcOptions.DefaultValue = true; dtOptions.Columns.Add(dcOptions);
            dcOptions = new DataColumn("Lectura", typeof(bool)); dcOptions.DefaultValue = true; dtOptions.Columns.Add(dcOptions);
            dcOptions = new DataColumn("Adicion", typeof(bool)); dcOptions.DefaultValue = true; dtOptions.Columns.Add(dcOptions);
            dcOptions = new DataColumn("Actualizacion", typeof(bool)); dcOptions.DefaultValue = true; dtOptions.Columns.Add(dcOptions);
            dcOptions = new DataColumn("Eliminacion", typeof(bool)); dcOptions.DefaultValue = true; dtOptions.Columns.Add(dcOptions);
            dcOptions = new DataColumn("Impresion", typeof(bool)); dcOptions.DefaultValue = true; dtOptions.Columns.Add(dcOptions);
            dcOptions = new DataColumn("TipoOper", typeof(int)); dcOptions.DefaultValue = 0; dtOptions.Columns.Add(dcOptions);
            //Crear PK de la tabla
            DataColumn[] pk = new DataColumn[1];
            pk[0] = dtOptions.Columns["MenuID"];
            dtOptions.PrimaryKey = pk;
        }

        private bool perfil;

        public bool Perfil
        {
            get { return perfil; }
            set { perfil = value; }
        }

        private int perfilID = 0;

        public int PerfilID
        {
            get { return perfilID; }
            set
            {
                perfilID = value;
                if (perfilID != 0)
                {
                    if (perfil == true)
                        AccessByPerfilID(perfilID);
                }
            }
        }

        private int userID = 0;

        public int UserID
        {
            get { return userID; }
            set
            {
                userID = value;
                if (userID != 0)
                {
                    AccessByperfilID(perfilID,userID);
                }
            }
        }

        public void PopulateMenu(int HijoID, DataTable menuAccess, TreeNode nodeParent)
        {
            DataView dvChild = new DataView(menuAccess);
            dvChild.RowFilter = "MenuPadreID=" + HijoID;
           
            foreach (DataRowView drvChild in dvChild)
            {
                TreeNode newNode = new TreeNode();
                newNode.Text = drvChild["NomMenu"].ToString();
                switch (drvChild["MenuTipoID"].ToString())
                {
                    case "1":
                        newNode.ImageIndex = 0;
                        newNode.SelectedImageIndex = 0;
                        break;
                    default:
                        newNode.ImageIndex = 1;
                        newNode.SelectedImageIndex = 1;
                        break;
                }

                newNode.Tag = drvChild["MenuID"].ToString() + ";" + drvChild["MenuTipoID"].ToString();
                if (nodeParent == null)
                {
                    this.treeView1.Nodes.Add(newNode);
                }
                else
                {
                    nodeParent.Nodes.Add(newNode);
                }
                PopulateMenu(Convert.ToInt32(drvChild["MenuID"]), menuAccess, newNode);
            }

        }

        private void AccesMenu_Load(object sender, EventArgs e)
        {
            Table();
            this.dataGridView1.DataSource = dtOptions;
        }

        void Add(int menuID)
        {
            //verificar que no exista
            DataRow exist = dtOptions.Rows.Find(menuID);
            if (exist == null)
            {

                DataRow dr = dtOptions.NewRow();
                dr["PerfilID"] = perfilID;
                dr["MenuID"] = menuID;
                dr["Activo"] = true;
                dr["Lectura"] = true;
                dr["Adicion"] = true;
                dr["Actualizacion"] = true;
                dr["Eliminacion"] = true;
                dr["Impresion"] = true;
                dr["TipoOper"] = 0;

                dtOptions.Rows.Add(dr);
                dr = null;
            }
            else
            {
                if (perfilID != 0)
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

        void Remove(int menuID)
        {
            //Borrar en bloque
            DataRow drExist = dtOptions.Rows.Find(menuID);
            if (drExist != null)
            {
                if (Convert.ToInt32(drExist["TipoOper"]) == 0)
                { drExist["TipoOper"] = 5; }
                if (Convert.ToInt32(drExist["TipoOper"]) == 1 || Convert.ToInt32(drExist["TipoOper"]) == 3)
                    drExist["TipoOper"] = 2;

            }
            //drExist.Delete();
            drExist = null;
        }

        void Update(int menuID, string permits, bool value)
        {
            DataRow drExist = dtOptions.Rows.Find(menuID);
            if (perfilID == 0)
            {
                if (drExist != null)
                {
                    drExist[permits] = value;
                }
            }
            else
            {
                drExist[permits] = value;                
                if (Convert.ToInt32(drExist["TipoOper"]) == 3)
                    drExist["TipoOper"] = 1;
                if (Convert.ToInt32(drExist["TipoOper"]) == 0)
                    drExist["TipoOper"] = 0;
            }
            drExist = null;
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {

            //Para marcar y desmarcar todos los nodos            
            foreach (TreeNode oNodo in e.Node.Nodes)
            {
                string[] objectString = oNodo.Tag.ToString().Split(new char[] { ';' });
                //AGREGAR EL FLAG AQUI .....
                if (find == false)
                    oNodo.Checked = e.Node.Checked;

                //insertar en el datatable solo las ventanas que es el ultimo nivel
                if (e.Node.Checked == true)
                {
                    if (objectString[1] == "4")
                    {
                        //AGREGAR EL FLAG AQUI .....
                        if (find == false)
                            Add(Convert.ToInt32(objectString[0]));
                    }
                }
                if (e.Node.Checked == false)
                {
                    Remove(Convert.ToInt32(objectString[0]));
                }
            }

            if (e.Node.Parent != null)
            {
                string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });
                //e.Node.Parent.Checked=true;
                if (!e.Node.Checked == true)
                {
                    //Desmarco
                    e.Node.Parent.NodeFont = new Font(this.treeView1.Font, FontStyle.Regular);
                    Remove(Convert.ToInt32(objectString[0]));

                }
                else
                {
                    e.Node.Parent.NodeFont = new Font(this.treeView1.Font, FontStyle.Bold);
                    //AGREGAR EL FLAG AQUI .....
                    if (find == false)
                        Add(Convert.ToInt32(objectString[0]));
                    //Marco
                }
            }

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });
            this.lblMenu.Text = e.Node.Text;
            menuID = Convert.ToInt32(objectString[0]);

            if (dtOptions.Rows.Count > 0)
            {
                DataRow drExist = dtOptions.Rows.Find(menuID);
                if (drExist != null)
                {
                    //Mostrar datos en los checkbox
                    this.chkAllowRead.Checked = Convert.ToBoolean(drExist["Lectura"]);
                    this.chkAllowWrite.Checked = Convert.ToBoolean(drExist["Adicion"]);
                    this.chkAllowUpdate.Checked = Convert.ToBoolean(drExist["Actualizacion"]);
                    this.chkAllowDelete.Checked = Convert.ToBoolean(drExist["Eliminacion"]);
                    this.chkAllowPrint.Checked = Convert.ToBoolean(drExist["Impresion"]);
                    // drExist["TypeOperDetail"] = 3;
                }
                else
                {
                    this.chkAllowRead.Checked = false;
                    this.chkAllowWrite.Checked = false;
                    this.chkAllowUpdate.Checked = false;
                    this.chkAllowDelete.Checked = false;
                    this.chkAllowPrint.Checked = false;
                }
                drExist = null;
            }
        }

        private void chkAllowRead_CheckedChanged(object sender, EventArgs e)
        {
            DataRow drExist = dtOptions.Rows.Find(menuID);
            if (drExist != null)
            {
                CheckBox obj = new CheckBox();
                obj = (CheckBox)sender;

                switch (obj.Name)
                {
                    case "chkAllowRead":
                        Update(menuID, "Lectura", chkAllowRead.Checked);
                        break;
                    case "chkAllowWrite":
                        Update(menuID, "Adicion", chkAllowWrite.Checked);
                        break;
                    case "chkAllowUpdate":
                        Update(menuID, "Actualizacion", chkAllowUpdate.Checked);
                        break;
                    case "chkAllowDelete":
                        Update(menuID, "Eliminacion", chkAllowDelete.Checked);
                        break;
                    case "chkAllowPrint":
                        Update(menuID, "Impresion", chkAllowPrint.Checked);
                        break;
                    default:
                        break;
                }
            }

        }

    }
}

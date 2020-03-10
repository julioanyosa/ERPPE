using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using C1.Win.C1Ribbon;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;

namespace Halley.Presentacion
{
    public class Ribbon
    {
        DataTable _data;
        C1Ribbon _objRibbon;

        public delegate void delegateRibbonClick(string menuCodigo, string ensamblado, string modoCarga, string titulo, string clase);
        public event delegateRibbonClick RibbonClick;


        public Ribbon(C1Ribbon objRibbon, DataTable data)
        {
            _data = data;
            _objRibbon = objRibbon;
        }

        public void Fill()
        {
            if (_data.Rows.Count == 0)
            {
                return;
            }

            //Obtenemos un DataView filtrando todos o que tengan el tipo Tab
            //entonces el campo MenuTipoID debe ser igual a 1
            DataView dvHijos = new DataView(_data);
            dvHijos.RowFilter = "MenuTipoID=1";

            foreach (DataRowView drvHijos in dvHijos)
            {
                RibbonTab rbTab;
                RibbonGroup rbGroup = new RibbonGroup();

                // Creamos el Tab
                rbTab = _objRibbon.Tabs.Add(drvHijos["NomMenu"].ToString().Trim());

                DataView dvGroups = new DataView(_data);
                dvGroups.RowFilter = "MenuPadreID=" + drvHijos["MenuID"].ToString().Trim();
                dvGroups.Sort = "MenuCodigo ASC";
                foreach (DataRowView drvGroupItem in dvGroups)
                {
                    // Creamos el Grupo
                    rbGroup = rbTab.Groups.Add(drvGroupItem["NomMenu"].ToString().Trim());

                    // Busquemos sus botones para agregar
                    DataView dvItems = new DataView(_data);
                    dvItems.RowFilter = "MenuPadreID=" + drvGroupItem["MenuID"].ToString().Trim();
                    dvItems.Sort = "MenuCodigo ASC";
                    foreach (DataRowView drvItem in dvItems)
                    {
                        if (Convert.ToInt32(drvItem["MenuTipoID"]) == 2)
                        {
                            // Creamos el Boton
                            RibbonButton rbutton;
                            rbutton = new RibbonButton();
                            rbutton.Text = drvItem["NomMenu"].ToString().Trim();
                            rbutton.ToolTip = drvItem["NomMenu"].ToString().Trim();
                            rbutton.ID = drvItem["MenuCodigo"].ToString().Trim() + ";" + drvItem["Ensamblado"].ToString().Trim() + ";" + drvItem["Clase"].ToString().Trim();

                            // Debe se asegurarse que el nombre de la imagen sin extension sea exactamente el mismo al
                            // ResourceImage de la base de datos    
                            if (drvItem["Imagen"].ToString().Trim() != "")
                            {
                                rbutton.LargeImage = (Image)Halley.Presentacion.Properties.Resources.ResourceManager.GetObject(drvItem["Imagen"].ToString().Trim());
                                if (Convert.ToBoolean(drvItem["LargeImage"]) == true)
                                {

                                    rbutton.TextImageRelation = TextImageRelation.ImageAboveText;
                                }
                                else
                                { rbutton.TextImageRelation = TextImageRelation.ImageBeforeText; }
                            }
                            rbutton.Tag = drvItem["ModoCargaVentana"].ToString().Trim();

                            rbGroup.Items.Add(rbutton);
                            // Asignamos el evento para saber cuando pulsamos el boton
                            rbutton.Click += new EventHandler(rbutton_Click);
                        }
                        else if (Convert.ToInt32(drvItem["MenuTipoID"]) == 3)
                        {
                            // Creamos los Separadores
                            RibbonSeparator rbSep = new RibbonSeparator();
                            rbSep.ID = drvItem["MenuCodigo"].ToString().Trim();
                            rbGroup.Items.Add(rbSep);
                        }
                        //agregado para ver el split
                        else if (Convert.ToInt32(drvItem["MenuTipoID"]) == 5)
                        {
                            // Creamos el SplitBoton
                            RibbonSplitButton Splitrbutton;
                            Splitrbutton = new RibbonSplitButton();
                            Splitrbutton.Text = drvItem["NomMenu"].ToString().Trim();
                            Splitrbutton.ToolTip = drvItem["NomMenu"].ToString().Trim();                            

                            // Debe se asegurarse que el nombre de la imagen sin extension sea exactamente el mismo al
                            // ResourceImage de la base de datos    
                            if (drvItem["Imagen"].ToString().Trim() != "")
                            {
                                Splitrbutton.LargeImage = (Image)Halley.Presentacion.Properties.Resources.ResourceManager.GetObject(drvItem["Imagen"].ToString().Trim());
                                if (Convert.ToBoolean(drvItem["LargeImage"]) == true)
                                {

                                    Splitrbutton.TextImageRelation = TextImageRelation.ImageAboveText;
                                }
                                else
                                { Splitrbutton.TextImageRelation = TextImageRelation.ImageBeforeText; }
                            }
                           
                            //agregado  para que el split tenga botenes hijos
                            DataView dvSplitHijos = new DataView(_data);
                            dvSplitHijos.RowFilter = "MenuPadreID=" + drvItem["MenuID"].ToString().Trim();
                            foreach (DataRowView drvSplit in dvSplitHijos)
                            {
                                if (Convert.ToInt32(drvSplit["MenuTipoID"]) == 2 && drvSplit["MenuCodigo"].ToString().Length == 10)
                                {
                                    // Creamos el Boton
                                    RibbonButton rbutton;
                                    rbutton = new RibbonButton();
                                    rbutton.Text = drvSplit["NomMenu"].ToString().Trim();
                                    rbutton.ToolTip = drvSplit["NomMenu"].ToString().Trim();
                                    rbutton.ID = drvSplit["MenuCodigo"].ToString().Trim() + ";" + drvSplit["Ensamblado"].ToString().Trim() + ";" + drvSplit["Clase"].ToString().Trim();

                                    // Debe se asegurarse que el nombre de la imagen sin extension sea exactamente el mismo al
                                    // ResourceImage de la base de datos    
                                    if (drvSplit["Imagen"].ToString().Trim() != "")
                                    {
                                        rbutton.LargeImage = (Image)Halley.Presentacion.Properties.Resources.ResourceManager.GetObject(drvSplit["Imagen"].ToString().Trim());
                                        if (Convert.ToBoolean(drvSplit["LargeImage"]) == true)
                                        {

                                            rbutton.TextImageRelation = TextImageRelation.ImageAboveText;
                                        }
                                        else
                                        { rbutton.TextImageRelation = TextImageRelation.ImageBeforeText; }
                                    }
                                    rbutton.Tag = drvSplit["ModoCargaVentana"].ToString().Trim();
                                  
                                    Splitrbutton.Items.Add(rbutton);
                                    // Asignamos el evento para saber cuando pulsamos el boton
                                    rbutton.Click += new EventHandler(rbutton_Click);
                                }
                            }
                            rbGroup.Items.Add(Splitrbutton);                           
                        }

                    }

                }
            }

            // poniendo el foco en el primer tab creado
            _objRibbon.Tabs[0].Selected = true;
        }

        void rbutton_Click(object sender, EventArgs e)
        {
            //Verificamos que se aya llamado al evento para luego invocarlo
            if (RibbonClick != null)
            {
                string[] _info = ((C1.Win.C1Ribbon.RibbonItem)(sender)).ID.ToString().Split(';');                
                RibbonClick(_info[0], _info[1], ((C1.Win.C1Ribbon.RibbonItem)(sender)).Tag.ToString(), ((C1.Win.C1Ribbon.RibbonButton)(sender)).Text, _info[2]);
            }

        }
    }
}

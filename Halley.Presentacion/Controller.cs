using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Command;
using System.Drawing;
using Halley.Configuracion;

namespace Halley.Presentacion
{
    public class Controller
    {
        public static Model Model = new Model();
        public static IDE IDE;

        public static void NavigateTo(string clase, string assembly, string titulo)
        {
            
            UITemplateAccess ustmp = (UITemplateAccess)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(assembly);
            string _name = ustmp.Name;

            if (IDE.c1DockingTab1.TabPages.IndexOfKey(ustmp.Name) == -1)
            {
                UITemplateAccess userControl = (UITemplateAccess)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(assembly);
                userControl.Dock = DockStyle.Fill;
                userControl.Tag = assembly;

                Model.onStatusChanged(assembly, userControl);


                C1DockingTabPage page = new C1DockingTabPage();
                page.Controls.Add(userControl);
                page.Text = titulo;
                page.Name = userControl.Name;
                page.Image = (Image)Halley.Presentacion.Properties.Resources.Form_16x16;

                page.Focus();
                page.Tag = userControl.Name+ ";"+ assembly;
                IDE.c1DockingTab1.TabPages.Add(page);
                IDE.c1DockingTab1.SelectedIndex = IDE.c1DockingTab1.TabPages.Count;
            }
            else
            {
                
                //Buscar el control en el tab
                IDE.c1DockingTab1.SelectedIndex = IDE.c1DockingTab1.TabPages.IndexOfKey(_name);

                object[] obj = null;
                int _idx;
                _idx= IDE.c1DockingTab1.Controls.IndexOfKey(ustmp.Name);
                obj = IDE.c1DockingTab1.Controls.Find(ustmp.Name, true);

                UserControl x = null;

                for (int i = 0; i <= obj.Length-1; i++)
                {
                    if (obj[i].GetType().Name == ustmp.Name)
                    {
                        x = (UserControl)obj[i];
                    }
                 }
                
                 Model.onStatusChanged(assembly, x);
            }

            ustmp = null;
        }

        public static void ShowModal(string assembly, string title, string formName)
        {
            Form f = new Form();
            f = (Form)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(assembly);

            f.Name = f.Name;
            f.Tag = title;
            f.Text = title;

            f.ShowDialog();

            f.Close();
            f.Dispose();
        }
    }
}

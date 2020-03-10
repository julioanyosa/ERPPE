using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Halley.Presentacion
{
    public class Model
    {
        //public EnumRecord.eRecord RecordStatus;


        public delegate void delegateStatusChanged(string assembly, UserControl userControl);
        public event delegateStatusChanged StatusChanged;

        public void onStatusChanged(string assembly, UserControl userControl)
        {

            StatusChanged(assembly, userControl);
        }

        public Model Clone()
        {
            return (Model)this.MemberwiseClone();
        }
    }
}

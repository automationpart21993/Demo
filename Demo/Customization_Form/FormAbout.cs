using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine
{
    public partial class FormAbout : Form
    {
        DeviceMain Device;
        public FormAbout(DeviceMain device)
        {
            Device = device;
            InitializeComponent();
            FormTranslate();
        }

        public void FormTranslate()
        {
            Text = (int)DeviceMain.Language == 0 ? "关于" : "About";
            Translate(this);
            Tb_Versions.Text = "20-06-22";
        }

        private void Translate(Control Control)
        {
            foreach (Control control in Control.Controls)
            {
                var t = Device.fabn.GetType().GetProperty(control.Name);
                if (t != null)
                {
                    string[] d = (string[])t.GetValue(Device.fabn);
                    control.Text = d[DeviceMain.Language];
                }
                Translate(control);
            }
        }
    }

}

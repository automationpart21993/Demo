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
    public partial class FormInit : Form
    {
        DeviceMain Device;
        public FormInit(DeviceMain device)
        {
            Device = device;
            InitializeComponent();
            FormTranslate();
        }

        private void FormInit_Load(object sender, EventArgs e)
        {

        }

        public void RateOfProgress(int index, bool result, int value)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    if (index == 0)
                    {
                        Inited_IOCard.BackColor = result ? Color.Lime : Color.Red;
                    }
                    else if (index == 1)
                    {
                        Inited_Scanner.BackColor = result ? Color.Lime : Color.Red;
                    }
                    else if (index == 2)
                    {
                        Inited_Scales.BackColor = result ? Color.Lime : Color.Red;
                    }
                    else if (index == 3)
                    {
                        Inited_OPTControl.BackColor = result ? Color.Lime : Color.Red;
                    }
                    else if (index == 4)
                    {
                        Inited_CCD.BackColor = result ? Color.Lime : Color.Red;
                    }
                    else if (index == 5)
                    {
                        Inited_NetWork.BackColor = result ? Color.Lime : Color.Red;
                    }
                    progressBar.Value = value;
                }));
            }
            catch (Exception ex)
            {
                DeviceMain.MsgShow(ex.Message, "警告", MessageBoxIcon.Information.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void FormTranslate()
        {
            Text = (int)DeviceMain.Language == 0 ? "程序初始化" : "Application Initialize";
            Translate(this);
        }

        private void Translate(Control Control)
        {
            foreach (Control control in Control.Controls)
            {
                var t = Device.fitn.GetType().GetProperty(control.Name);
                if (t != null)
                {
                    string[] d = (string[])t.GetValue(Device.fitn);
                    control.Text = d[DeviceMain.Language];
                }
                Translate(control);
            }
        }
    }
}

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
    public partial class FormMsgBox : Form
    {
        DeviceMain Device;
        private string DSN;
        private string Message;
        private int AutoClose = 0;
        public FormMsgBox(DeviceMain device, string dsn, string message,int autoclose=15)
        {
            Device = device;
            DSN = dsn;
            Message = message;
            AutoClose = autoclose;
            InitializeComponent();
        }

        public void FormTranslate()
        {
            Text = (int)DeviceMain.Language == 0 ? "NG信息" : "NG Information";
            Translate(this);
        }

        private void Translate(Control Control)
        {
            foreach (Control control in Control.Controls)
            {
                var t = Device.fmbn.GetType().GetProperty(control.Name);
                if (t != null)
                {
                    string[] d = (string[])t.GetValue(Device.fmbn);
                    control.Text = d[DeviceMain.Language];
                }
                Translate(control);
            }
        }

        private void FormMsgBox_Load(object sender, EventArgs e)
        {
            Info_DSN.Text = DSN;
            rtb_msg.Text = Message;
            FormTranslate();
            timer_AutoClose.Start();
        }

        private void timer_AutoClose_Tick(object sender, EventArgs e)
        {
            if (AutoClose == 0) Close();
            AutoClose--;
        }
    }
}

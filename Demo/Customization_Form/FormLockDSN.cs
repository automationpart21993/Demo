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
    public partial class FormLockDSN : Form
    {
        public DeviceMain Device;
        public static bool OpenForm = false;
        public FormLockDSN(DeviceMain device)
        {
            OpenForm = true;
            Device = device;
            InitializeComponent();
            Text = DeviceMain.Language == 0 ? "锁定DSN" : "Lock DSN";
            Btn_Confirm.Text= DeviceMain.Language == 0 ? "确认" : "Confirm";
        }

        private void FormLockDSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) Btn_Confirm.PerformClick();
        }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            Device.snc.Lock_DSN = Tb_LockDSN.Text.Replace(" ","").Replace("\r\n","");
            Tb_LockDSN.Clear();
            Close();
        }

        private void FormLockDSN_FormClosing(object sender, FormClosingEventArgs e)
        {
            OpenForm = false;
        }
    }
}

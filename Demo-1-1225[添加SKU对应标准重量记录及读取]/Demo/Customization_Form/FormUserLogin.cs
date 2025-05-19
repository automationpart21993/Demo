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
    public partial class FormUserLogin : Form
    {
        DeviceMain Device;
        public FormUserLogin(DeviceMain device)
        {
            Device = device;
            InitializeComponent();
            FormTranslate();
        }

        public void FormTranslate()
        {
            Text = (int)DeviceMain.Language == 0 ? "设置登陆" : "Setting Login";
            Translate(this);
        }

        private void Translate(Control Control)
        {
            foreach (Control control in Control.Controls)
            {
                var t = Device.fuln.GetType().GetProperty(control.Name);
                if (t != null)
                {
                    string[] d = (string[])t.GetValue(Device.fuln);
                    control.Text = d[DeviceMain.Language];
                }
                Translate(control);
            }
        }

        private void FormUserLogin_Load(object sender, EventArgs e)
        {
            if ((int)Device.pwc.DefaultUser == 0)
            {
                Tb_Password.Text = string.Empty;
            }
            else if ((int)Device.pwc.DefaultUser == 1)
            {
                Tb_Password.Text = Device.pwc.NormalPassword;
            }
            else if ((int)Device.pwc.DefaultUser == 2)
            {
                Tb_Password.Text = Device.pwc.AdministratorPassword;
            }
            else if ((int)Device.pwc.DefaultUser == 3)
            {
                Tb_Password.Text = Device.pwc.SuperAdministratorPassword;
            }
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tb_Password.Text))
            {
                DeviceMain.User = AccessLevel.Guest;
                DeviceMain.Notify("用户登陆:访客", "User Login:Guest");
                DeviceMain.Login = true;
                Close();
            }
            else if (Tb_Password.Text.Equals(Device.pwc.NormalPassword))
            {
                DeviceMain.User = AccessLevel.Normal;
                DeviceMain.Notify("用户登陆:一般用户", "User Login:Normal User");
                DeviceMain.Login = true;
                Close();
            }
            else if (Tb_Password.Text.Equals(Device.pwc.AdministratorPassword))
            {
                DeviceMain.User = AccessLevel.Administrator;
                DeviceMain.Notify("用户登陆:管理员", "User Login:Administrator");
                DeviceMain.Login = true;
                Close();
            }
            else if (Tb_Password.Text.Equals(Device.pwc.SuperAdministratorPassword))
            {
                DeviceMain.User = AccessLevel.SuperAdministrator;
                DeviceMain.Notify("用户登陆:超级管理员", "User Login:Super Administrator");
                DeviceMain.Login = true;
                Close();
            }
            else
            {
                if (DialogResult.Yes == DeviceMain.MsgShow("密码错误!是否以Guest用户登陆?", "The password is verify fail!Are you logged in as Guest?", "登陆失败", "Login Fail", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    DeviceMain.User = AccessLevel.Guest;
                    DeviceMain.Notify("用户登陆:访客", "User Login:Guest");
                    DeviceMain.Login = true;
                    Close();
                }
            }
        }

        private void Tb_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Btn_Login.PerformClick();
            }
        }
    }
}

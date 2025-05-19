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
    public partial class FormUserManagement : Form
    {
        DeviceMain Device;
        public FormUserManagement(DeviceMain device)
        {
            Device = device;
            InitializeComponent();
            FormTranslate();
        }

        public void FormTranslate()
        {
            Text = (int)DeviceMain.Language == 0 ? "用户管理" : "User Management";
            Translate(this);
        }

        private void Translate(Control Control)
        {
            foreach (Control control in Control.Controls)
            {
                var t = Device.fumn.GetType().GetProperty(control.Name);
                if (t != null)
                {
                    string[] d = (string[])t.GetValue(Device.fumn);
                    control.Text = d[DeviceMain.Language];
                }
                Translate(control);
            }
        }

        private void FormUserManagement_Load(object sender, EventArgs e)
        {
            timer_Flash.Start();
            Cbb_UserSelect.Items.Clear();
            Cbb_UserSelect.Items.Add(AccessLevel.Guest.ToString());
            Cbb_UserSelect.Items.Add(AccessLevel.Normal.ToString());
            Cbb_UserSelect.Items.Add(AccessLevel.Administrator.ToString());
            Cbb_UserSelect.Items.Add(AccessLevel.SuperAdministrator.ToString());
            Cbb_UserSelect.SelectedIndex = 0;
            Tb_OldPassWord.ReadOnly = true;
            Tb_NewPassWord.ReadOnly = true;
            if (Cbb_UserSelect.Text.Equals(Device.pwc.DefaultUser.ToString()))
            {
                Cb_DefaultUser.Checked = true;
            }
            else
            {
                Cb_DefaultUser.Checked = false;
            }
        }

        private void Cbb_UserSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tb_NewPassWord.Clear();
            Tb_OldPassWord.Clear();
            if (Cbb_UserSelect.SelectedIndex == 0)
            {
                Tb_OldPassWord.ReadOnly = true;
                Tb_NewPassWord.ReadOnly = true;
            }
            else
            {
                Tb_OldPassWord.ReadOnly = false;
                Tb_NewPassWord.ReadOnly = false;
            }
            if (Cbb_UserSelect.Text.Equals(Device.pwc.DefaultUser.ToString()))
            {
                Cb_DefaultUser.Checked = true;
            }
            else
            {
                Cb_DefaultUser.Checked = false;
            }
        }

        private void timer_Flash_Tick(object sender, EventArgs e)
        {
            if (Cbb_UserSelect.SelectedIndex == 0)
            {
                Tb_OldPassWord.BackColor = Color.Lime;
                Tb_NewPassWord.BackColor = Color.Lime;
            }
            else if (Cbb_UserSelect.SelectedIndex == 1)
            {
                Tb_OldPassWord.BackColor = Device.pwc.NormalPassword.Equals(Tb_OldPassWord.Text) ? Color.Lime : Color.Red;
                Tb_NewPassWord.BackColor = string.IsNullOrEmpty(Tb_NewPassWord.Text) ? Color.Red : Color.Lime;
            }
            else if (Cbb_UserSelect.SelectedIndex == 2)
            {
                Tb_OldPassWord.BackColor = Device.pwc.AdministratorPassword.Equals(Tb_OldPassWord.Text) ? Color.Lime : Color.Red;
                Tb_NewPassWord.BackColor = string.IsNullOrEmpty(Tb_NewPassWord.Text) ? Color.Red : Color.Lime;
            }
            else if (Cbb_UserSelect.SelectedIndex == 3)
            {
                Tb_OldPassWord.BackColor = Device.pwc.SuperAdministratorPassword.Equals(Tb_OldPassWord.Text) ? Color.Lime : Color.Red;
                Tb_NewPassWord.BackColor = string.IsNullOrEmpty(Tb_NewPassWord.Text) ? Color.Red : Color.Lime;
            }
        }

        private void Btn_Modification_Click(object sender, EventArgs e)
        {
            if (Cbb_UserSelect.SelectedIndex == 0)
            {
                if (Tb_OldPassWord.BackColor == Color.Lime && Tb_NewPassWord.BackColor == Color.Lime)
                {
                    if (Cb_DefaultUser.Checked)
                    {
                        Device.pwc.DefaultUser = AccessLevel.Guest;
                    }
                    Device.pwc.Save(DeviceMain.ConfigPath(2, Device.pwc), Device.pwc);
                    DeviceMain.Notify("用户设置已更改!", "User set is changed!");
                    DeviceMain.MsgShow("用户设置已更改!", "User set is changed!", "信息", "Information");
                    Close();
                }
            }
            else if (Cbb_UserSelect.SelectedIndex == 1)
            {
                if (Tb_OldPassWord.BackColor == Color.Lime && Tb_NewPassWord.BackColor == Color.Lime)
                {
                    if (!string.IsNullOrEmpty(Tb_NewPassWord.Text.Trim()))
                        Device.pwc.NormalPassword = Tb_NewPassWord.Text;
                    if (Cb_DefaultUser.Checked)
                    {
                        Device.pwc.DefaultUser = AccessLevel.Normal;
                    }
                    Device.pwc.Save(DeviceMain.ConfigPath(2, Device.pwc), Device.pwc);
                    DeviceMain.Notify("用户设置已更改!", "User set is changed!");
                    DeviceMain.MsgShow("用户设置已更改!", "User set is changed!", "信息", "Information");
                    Close();
                }
            }
            else if (Cbb_UserSelect.SelectedIndex == 2)
            {
                if (Tb_OldPassWord.BackColor == Color.Lime && Tb_NewPassWord.BackColor == Color.Lime)
                {
                    if (!string.IsNullOrEmpty(Tb_NewPassWord.Text.Trim()))
                        Device.pwc.AdministratorPassword = Tb_NewPassWord.Text;
                    if (Cb_DefaultUser.Checked)
                    {
                        Device.pwc.DefaultUser = AccessLevel.Administrator;
                    }
                    Device.pwc.Save(DeviceMain.ConfigPath(2, Device.pwc), Device.pwc);
                    DeviceMain.Notify("用户设置已更改!", "User set is changed!");
                    DeviceMain.MsgShow("用户设置已更改!", "User set is changed!", "信息", "Information");
                    Close();
                }
            }
            else if (Cbb_UserSelect.SelectedIndex == 3)
            {
                if (Tb_OldPassWord.BackColor == Color.Lime && Tb_NewPassWord.BackColor == Color.Lime)
                {
                    if (!string.IsNullOrEmpty(Tb_NewPassWord.Text.Trim()))
                        Device.pwc.SuperAdministratorPassword = Tb_NewPassWord.Text;
                    if (Cb_DefaultUser.Checked)
                    {
                        Device.pwc.DefaultUser = AccessLevel.SuperAdministrator;
                    }
                    Device.pwc.Save(DeviceMain.ConfigPath(2, Device.pwc), Device.pwc);
                    DeviceMain.Notify("用户设置已更改!", "User set is changed!");
                    DeviceMain.MsgShow("用户设置已更改!", "User set is changed!", "信息", "Information");
                    Close();
                }
            }
        }

        private void Cbb_UserSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}

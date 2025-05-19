using HalconDotNet;
using HelperCmd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine
{
    public partial class FormSetting : Form
    {
        DeviceMain Device = null;
        public bool hide = true;
        public FormSetting(DeviceMain device)
        {
            Device = device;
            InitializeComponent();
            if (Device.mac.Signal_Swithc)
            {
                Signal_SafeGuard.CardNo = 0;
                Station_Next_Ready.CardNo = 0;
                Station_Next_GetBox.CardNo = 0;
            }
            else
            {
                Signal_SafeGuard.CardNo = 1;
                Station_Next_Ready.CardNo = 1;
                Station_Next_GetBox.CardNo = 1;
            }
            FormTranslate();
            ControlsInit();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            AccessLevelChange();
            timer_IOFalsh.Start();
            timer_IOFalsh.Enabled = false;
            timer_CylinderFalsh.Start();
            timer_CylinderFalsh.Enabled = false;
            Tc_Setting.SelectedIndex = 0;
        }

        private void FormSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            hide = true;
            Hide();
        }

        private void FormSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 83)
            {
                Focus();
                Btn_SaveConfig.PerformClick();
            }
        }

        private void Tb_Weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (int)e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void OutputClick(object sender, EventArgs e)
        {
            ((Output)sender).Enabled = false;
            IO64.IO0640_Output_Click(((Output)sender), Device.ioc);
            ((Output)sender).Enabled = true;
        }

        private void btn_Output_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            Object obj = Device.GetType().GetProperty(btn.Name.Substring(btn.Name.IndexOf('_') + 1)).GetValue(Device);
            Output output = (Output)obj;
            bool IsOn = output.IsOn(Device.ioc);
            output.IO64Power(Device.ioc, IsOn ? false : true);
            btn.Enabled = true;
            if (IsOn)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
            }
            else
            {
                btn.BackColor = Color.Red;
                btn.ForeColor = Color.White;
            }
            btn.Focus();
        }

        private void ControlsInit()
        {
            Ppg_CCDConfig.SelectedObject = Device.ccc;
            Ppg_MachineConfig.SelectedObject = Device.mac;
            Ppg_OptLightConfig.SelectedObject = Device.olc;
            Ppg_ScalesConfig.SelectedObject = Device.slc;
            Ppg_ScannerConfig.SelectedObject = Device.snc;

            Device.ioc.ReadIOParamToControl(Device.ioc, Tblp_IODebug);
            Device.ioc.ReadIOParamToControl(Device.ioc, Tblp_CylinderDebug);

            Device.optlight = OptLightController;
            Device.optlight.Ch1Value = Device.olc.Channel_01_Black;
            Device.optlight.Ch2Value = Device.olc.Channel_02_Black;
            Device.optlight.Ch3Value = Device.olc.Channel_03_Retail;
            Device.optlight.Ch4Value = Device.olc.Channel_04_BOB;

            Device.Cyl_D01Intercept = Cyl_D01Intercept;
            Device.Cyl_D02Intercept = Cyl_D02Intercept;
            Device.Cyl_D02Weigh = Cyl_D02Weigh;
            Device.Cyl_D03Adjust = Cyl_D03Adjust;
            Device.Cyl_D03Clamp = Cyl_D03Clamp;
            Device.Cyl_D03Rotate = Cyl_D03Rotate;
            Device.Cyl_D03Forward = Cyl_D03Forward;
            Device.Cyl_D03Lifter = Cyl_D03Lifter;
            Device.Cyl_D03Carry = Cyl_D03Carry;

            Device.Cyl_D01Intercept_Org = Cyl_D01Intercept_Org;
            Device.Cyl_D01Intercept_On = Cyl_D01Intercept_On;
            Device.Cyl_D02Intercept_Org = Cyl_D02Intercept_Org;
            Device.Cyl_D02Intercept_On = Cyl_D02Intercept_On;
            Device.Cyl_D02Weigh_Org = Cyl_D02Weigh_Org;
            Device.Cyl_D02Weigh_On = Cyl_D02Weigh_On;
            Device.Cyl_D03Adjust_Left_Org = Cyl_D03Adjust_Left_Org;
            Device.Cyl_D03Adjust_Left_On = Cyl_D03Adjust_Left_On;
            Device.Cyl_D03Adjust_Right_Org = Cyl_D03Adjust_Right_Org;
            Device.Cyl_D03Adjust_Right_On = Cyl_D03Adjust_Right_On;
            Device.Cyl_D03Clamp_Org = Cyl_D03Clamp_Org;
            Device.Cyl_D03Clamp_On = Cyl_D03Clamp_On;
            Device.Cyl_D03Rotate_Org = Cyl_D03Rotate_Org;
            Device.Cyl_D03Rotate_On = Cyl_D03Rotate_On;
            Device.Cyl_D03Forward_Org = Cyl_D03Forward_Org;
            Device.Cyl_D03Forward_On = Cyl_D03Forward_On;
            Device.Cyl_D03Lifter_Org = Cyl_D03Lifter_Org;
            Device.Cyl_D03Lifter_On = Cyl_D03Lifter_On;
            Device.Cyl_D03Carry_Org = Cyl_D03Carry_Org;
            Device.Cyl_D03Carry_On = Cyl_D03Carry_On;

            Device.Belt_D01_Enable = Belt_D01_Enable;
            Device.Belt_D01_Direction = Belt_D01_Direction;
            Device.Belt_D01_Run = Belt_D01_Run;
            Device.Belt_D01_Alarm = Belt_D01_Alarm;
            Device.Belt_D02_Enable = Belt_D02_Enable;
            Device.Belt_D02_Direction = Belt_D02_Direction;
            Device.Belt_D02_Run = Belt_D02_Run;
            Device.Belt_D02_Alarm = Belt_D02_Alarm;
            Device.Belt_D03_Enable = Belt_D03_Enable;
            Device.Belt_D03_Direction = Belt_D03_Direction;
            Device.Belt_D03_Run = Belt_D03_Run;
            Device.Belt_D03_Alarm = Belt_D03_Alarm;

            Device.Signal_D01_Enter = Signal_D01_Enter;
            Device.Signal_D02_Enter = Signal_D02_Enter;
            Device.Signal_D03_Enter = Signal_D03_Enter;
            Device.Signal_NG_First = Signal_NG_First;
            Device.Signal_NG_Second = Signal_NG_Second;

            Device.Signal_EMG = Signal_EMG;
            Device.Signal_Reset = Signal_Reset;
            Device.Signal_Run = Signal_Run;
            Device.Signal_Stop = Signal_Stop;
            Device.Signal_SafeGuard = Signal_SafeGuard;
            Device.Beacon_Lamp_Red = Beacon_Lamp_Red;
            Device.Beacon_Lamp_Yellow = Beacon_Lamp_Yellow;
            Device.Beacon_Lamp_Green = Beacon_Lamp_Green;
            Device.Beacon_Buzzer = Beacon_Buzzer;

            Device.Station_Next_Ready = Station_Next_Ready;
            Device.Station_Next_GetBox = Station_Next_GetBox;
            Device.Station_GetReady_Input = Station_GetReady_Input;
            Device.Station_GetReady_Output = Station_GetReady_Output;
            Device.Station_NotPaste = Station_NotPaste;
            Device.Station_LabelType = Station_LabelType;
            Device.Station_SKUChange = Station_SKUChange;
        }

        public void FormTranslate()
        {
            //new Language().Change(Ppg_MachineConfig, (int)DeviceMain.Language == 1 ? true : false);
            Text = (int)DeviceMain.Language == 0 ? "设置及调试" : "Setting and Debug";
            Translate(this);
            Ppg_CCDConfig.Refresh();
            Ppg_MachineConfig.Refresh();
            Ppg_OptLightConfig.Refresh();
            Ppg_ScalesConfig.Refresh();
            Ppg_ScannerConfig.Refresh();
        }

        private void Translate(Control Control)
        {
            foreach (Control control in Control.Controls)
            {
                var t = Device.fstn.GetType().GetProperty(control.Name);
                if (t != null)
                {
                    if (control.GetType() == typeof(Input))
                    {
                        string[] d = (string[])t.GetValue(Device.fstn);
                        Input input = (Input)control;
                        input.IOText = d[DeviceMain.Language];
                    }
                    else if (control.GetType() == typeof(Output))
                    {
                        string[] d = (string[])t.GetValue(Device.fstn);
                        Output output = (Output)control;
                        output.IOText = d[DeviceMain.Language];
                    }
                    else if (control.GetType() == typeof(OptLightController.OptLightController))
                    {
                        string[] d = (string[])t.GetValue(Device.fstn);
                        OptLightController.OptLightController opt = (OptLightController.OptLightController)control;
                        if (DeviceMain.Language == 0)
                        {
                            opt.Channel1Text = d[0];
                            opt.Channel2Text = d[1];
                            opt.Channel3Text = d[2];
                            opt.Channel4Text = d[3];
                        }
                        else
                        {
                            opt.Channel1Text = d[4];
                            opt.Channel2Text = d[5];
                            opt.Channel3Text = d[6];
                            opt.Channel4Text = d[7];
                        }
                    }
                    else
                    {
                        string[] d = (string[])t.GetValue(Device.fstn);
                        control.Text = d[DeviceMain.Language];
                    }
                }
                Translate(control);
            }
        }

        private void timer_IOFalsh_Tick(object sender, EventArgs e)
        {
            IO64.CheckIOStatus(Device.ioc, Tblp_Input);
            IO64.CheckIOStatus(Device.ioc, Tblp_Output);
        }

        private void timer_CylinderFalsh_Tick(object sender, EventArgs e)
        {
            IO64.CheckIOStatus(Device.ioc, Tblp_Output_D01);
            IO64.CheckIOStatus(Device.ioc, Tblp_Output_D02);
            IO64.CheckIOStatus(Device.ioc, Tblp_Output_D03);
        }

        public void AccessLevelChange()
        {
            Btn_UserAccess.Text = DeviceMain.User.ToString();
            IO64.SetValueUnvisible(Tblp_Input);
            IO64.SetValueUnvisible(Tblp_Output);
            IO64.SetValueUnvisible(Tblp_Output_D01);
            IO64.SetValueUnvisible(Tblp_Output_D02);
            IO64.SetValueUnvisible(Tblp_Output_D03);
            Tblp_MachineConfig.Enabled = true;
            Tblp_SerialConfig.Enabled = true;
            Tblp_OptLightConfig.Enabled = false;
            Tblp_IODebug.Enabled = true;
            Tblp_CylinderDebug.Enabled = true;
            Tblp_StepDebug.Enabled = true;
            Tblp_OtherDebug.Enabled = true;
            Ppg_CCDConfig.Enabled = false;
            Btn_UserManagement.Visible = false;
            Btn_SaveConfig.Enabled = true;
            Gb_CCDDebug.Enabled = true;
            Btn_UpLoadPass.Visible = false;
            if ((int)DeviceMain.User == 0)
            {
                Status_Level_01.BackColor = Status_Level_02.BackColor = Status_Level_03.BackColor = Color.Red;
                Status_Level_01.ForeColor = Status_Level_02.ForeColor = Status_Level_03.ForeColor = Color.White;
                Btn_UserAccess.BackColor = Color.Red;
                Btn_UserAccess.ForeColor = Color.White;
                Tblp_MachineConfig.Enabled = false;
                Tblp_SerialConfig.Enabled = false;
                Tblp_IODebug.Enabled = false;
                Tblp_CylinderDebug.Enabled = false;
                Tblp_StepDebug.Enabled = false;
                Tblp_OtherDebug.Enabled = false;
                Btn_SaveConfig.Enabled = false;
            }
            else if ((int)DeviceMain.User == 1)
            {
                Status_Level_01.BackColor = Color.Lime;
                Status_Level_01.ForeColor = Color.Black;
                Status_Level_02.BackColor = Status_Level_03.BackColor = Color.Red;
                Status_Level_02.ForeColor = Status_Level_03.ForeColor = Color.White;
                Btn_UserAccess.BackColor = Color.White;
                Btn_UserAccess.ForeColor = Color.Black;
                Tblp_SerialConfig.Enabled = false;
                Tblp_StepDebug.Enabled = false;
                Tblp_OtherDebug.Enabled = false;
            }
            else if ((int)DeviceMain.User == 2)
            {
                Status_Level_03.BackColor = Color.Red;
                Status_Level_03.ForeColor = Color.White;
                Status_Level_01.BackColor = Status_Level_02.BackColor = Color.Lime;
                Status_Level_01.ForeColor = Status_Level_02.ForeColor = Color.Black;
                Btn_UserAccess.BackColor = Color.Blue;
                Btn_UserAccess.ForeColor = Color.White;
                IO64.SetValueVisible(Tblp_Input);
                IO64.SetValueVisible(Tblp_Output);
                IO64.SetValueVisible(Tblp_Output_D01);
                IO64.SetValueVisible(Tblp_Output_D02);
                IO64.SetValueVisible(Tblp_Output_D03);
            }
            else if ((int)DeviceMain.User == 3)
            {
                Status_Level_01.BackColor = Status_Level_02.BackColor = Status_Level_03.BackColor = Color.Lime;
                Status_Level_01.ForeColor = Status_Level_02.ForeColor = Status_Level_03.ForeColor = Color.Black;
                IO64.SetValueVisible(Tblp_Input);
                IO64.SetValueVisible(Tblp_Output);
                IO64.SetValueVisible(Tblp_Output_D01);
                IO64.SetValueVisible(Tblp_Output_D02);
                IO64.SetValueVisible(Tblp_Output_D03);
                Btn_UserAccess.BackColor = Color.Lime;
                Btn_UserAccess.ForeColor = Color.Black;
                Tblp_OptLightConfig.Enabled = true;
                Ppg_CCDConfig.Enabled = true;
                Btn_UserManagement.Visible = true;
                Btn_UpLoadPass.Visible = true;
            }
        }

        private void Tc_Setting_SelectedIndexChanged(object sender, EventArgs e)
        {
            Btn_SaveConfig.Visible = Tc_Setting.SelectedIndex < 5 ? true : false;
            if (Tc_Setting.SelectedIndex == 3)
            {
                timer_IOFalsh.Enabled = true;
                timer_CylinderFalsh.Enabled = false;
            }
            else if (Tc_Setting.SelectedIndex == 4)
            {
                timer_IOFalsh.Enabled = false;
                timer_CylinderFalsh.Enabled = true;
            }
            else
            {
                timer_IOFalsh.Enabled = false;
                timer_CylinderFalsh.Enabled = false;
                if (Tc_Setting.SelectedIndex == 6)
                {
                    Tb_CCD1_EXTime.Text = string.Format("{0}", Device.ccc.CCD1_ExTime);
                    Tb_CCD2_EXTime.Text = string.Format("{0}", Device.ccc.CCD2_RExTime);
                    Tb_CCD3_EXTime.Text = string.Format("{0}", Device.ccc.CCD3_ExTime);
                }
                if (Tc_Setting.SelectedIndex == 5)
                {
                    Btn_StatusFlash();
                }
            }
        }

        private void Btn_UserAccess_Click(object sender, EventArgs e)
        {
            new FormUserLogin(Device).ShowDialog();
            if (DeviceMain.Login)
            {
                DeviceMain.Login = false;
                AccessLevelChange();
            }
        }

        private void Btn_UserManagement_Click(object sender, EventArgs e)
        {
            new FormUserManagement(Device).ShowDialog();
        }

        private void Ppg_MachineConfig_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Device.Connect();
        }

        private void Btn_SaveConfig_Click(object sender, EventArgs e)
        {
            if (Tc_Setting.SelectedIndex == 0)
            {
                if (!Ppg_CCDConfig.Enabled)
                {
                    Device.mac.Save(DeviceMain.ConfigPath(2, Device.mac), Device.mac);
                    DeviceMain.Notify("配置保存:设备配置", "Config Save:Machine Config");
                }
                else
                {
                    Device.mac.Save(DeviceMain.ConfigPath(2, Device.mac), Device.mac);
                    Device.ccc.Save(DeviceMain.ConfigPath(2, Device.ccc), Device.ccc);
                    DeviceMain.Notify("配置保存:设备配置及CCD相机配置", "Config Save:Machine Config and CCD Config");
                }
            }
            else if (Tc_Setting.SelectedIndex == 1)
            {
                Device.snc.Save(DeviceMain.ConfigPath(2, Device.snc), Device.snc);
                Device.slc.Save(DeviceMain.ConfigPath(2, Device.slc), Device.slc);
                DeviceMain.Notify("配置保存:串口配置", "Config Save:Serial Config");
            }
            else if (Tc_Setting.SelectedIndex == 2)
            {
                Device.olc.Save(DeviceMain.ConfigPath(2, Device.olc), Device.olc);
                DeviceMain.Notify("配置保存:光源配置", "Config Save:OptLight Config");
            }
            else if (Tc_Setting.SelectedIndex == 3)
            {
                Device.ioc.SaveIOParamForControl(Device.ioc, Tp_IODebug, DeviceMain.ConfigPath(2, Device.ioc));
                DeviceMain.Notify("配置保存:IO配置", "Config Save:IO Config");
            }
            else if (Tc_Setting.SelectedIndex == 4)
            {
                Device.ioc.SaveIOParamForControl(Device.ioc, Tp_CylinderDebug, DeviceMain.ConfigPath(2, Device.ioc));
                DeviceMain.Notify("配置保存:气缸配置", "Config Save:Cylinder Config");
            }
            DeviceMain.MsgShow("配置保存成功!", "ConfigSaved!", "提示", "Tip");
        }

        private void Btn_VirtualAction_D01_Click(object sender, EventArgs e)
        {
            Btn_VirtualAction_D01.Enabled = false;
            Task Virtual = new Task(new Action(() =>
            {
                if (DialogResult.Yes == DeviceMain.MsgShow("是否启动入料段虚拟动作?", "Run D01 virtual action?", "提问", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Device.VirtualAction_D01();
                }

            }));
            Virtual.Start();
            while (!Virtual.IsCompleted) ShowInfo.Delay(1);
            Btn_VirtualAction_D01.Enabled = true;
        }

        private void Btn_VirtualAction_D02_Click(object sender, EventArgs e)
        {
            Btn_VirtualAction_D02.Enabled = false;
            Task Virtual = new Task(new Action(() =>
            {
                if (DialogResult.Yes == DeviceMain.MsgShow("是否启动检测段虚拟动作?", "Run D02 virtual action?", "提问", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Device.VirtualAction_D02();
                }
            }));
            Virtual.Start();
            while (!Virtual.IsCompleted) ShowInfo.Delay(1);
            Btn_VirtualAction_D02.Enabled = true;
        }

        private void Btn_VirtualAction_D03_Click(object sender, EventArgs e)
        {
            Btn_VirtualAction_D03.Enabled = false;
            Task Virtual = new Task(new Action(() =>
            {
                if (DialogResult.Yes == DeviceMain.MsgShow("是否启动翻转段虚拟动作?", "Run D03 virtual action?", "提问", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Device.VirtualAction_D03();
                }

            }));
            Virtual.Start();
            while (!Virtual.IsCompleted) ShowInfo.Delay(1);
            Btn_VirtualAction_D03.Enabled = true;
        }

        private void Btn_NGAction_Click(object sender, EventArgs e)
        {
            Btn_NGAction.Enabled = false;
            Task action = new Task(new Action(() =>
            {
                Device.NGAction();
            }));
            action.Start();
            while (!action.IsCompleted) ShowInfo.Delay(1);
            Btn_NGAction.Enabled = true;
        }

        private void Btn_PassAction_Click(object sender, EventArgs e)
        {
            Btn_PassAction.Enabled = false;
            Task action = new Task(new Action(() =>
            {
                Device.PASSAction();
            }));
            action.Start();
            while (!action.IsCompleted) ShowInfo.Delay(1);
            Btn_PassAction.Enabled = true;
        }

        private void Btn_CheckPath_Click(object sender, EventArgs e)
        {
            Rtb_GetData.Clear();
            Rtb_GetData.AppendText(Device.Test_CheckPath(Tb_DSN.Text));
        }

        private void Btn_GetRetailData_Click(object sender, EventArgs e)
        {
            Rtb_GetData.Clear();
            Rtb_GetData.AppendText(Device.Test_GetReatilData(Tb_DSN.Text));
        }

        private void Btn_GetBOBData_Click(object sender, EventArgs e)
        {
            Rtb_GetData.Clear();
            Rtb_GetData.AppendText(Device.Test_GetBOBData(Tb_DSN.Text));
        }

        private void Btn_GetClosure_Click(object sender, EventArgs e)
        {
            Rtb_GetData.Clear();
            Rtb_GetData.AppendText(Device.Test_GetClosure(Tb_DSN.Text));
        }

        private void Btn_UpLoadPass_Click(object sender, EventArgs e)
        {
            Rtb_GetData.Clear();
            try
            {
                Rtb_GetData.AppendText(Device.Test_UpLoadPass(Tb_DSN.Text, Convert.ToDouble(Tb_Weight.Text)));
            }
            catch(Exception ex)
            {
                Rtb_GetData.AppendText(ex.Message);
            }
        }

        private void EXTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void Btn_Type_Front_Click(object sender, EventArgs e)
        {
            double ModelScore = 0;
            Btn_Type_Front.Enabled = false;
            if ((int)Device.Status_D02 != 1)
            {
                Task Test = new Task(new Action(() =>
                  {
                      if (Device.Read_Type_Top(Device.mac.Product, out ModelScore))
                      {
                          DeviceMain.Notify("正面型号识别成功!", "Front Type discern success!");
                      }
                  }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_Type_Front.Enabled = true;
        }

        private void Btn_Color_Front_Click(object sender, EventArgs e)
        {
            Btn_Color_Front.Enabled = false;
            if ((int)Device.Status_D02 != 1)
            {
                Task Test = new Task(new Action(() =>
                {
                    if (Device.Read_Color_Top("JustBlack"))
                        DeviceMain.Notify("正面颜色识别完成!", "Front Color discern done!");
                }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_Color_Front.Enabled = true;
        }

        private void Btn_GLabel_Retail_Click(object sender, EventArgs e)
        {
            double ModelScore = 0;
            Btn_GLabel_Retail.Enabled = false;
            if ((int)Device.Status_D02 != 1)
            {
                Task Test = new Task(new Action(() =>
                  {
                      if (Device.Read_GLabel_Retail(out ModelScore))
                      {
                          DeviceMain.Notify("防伪标签识别成功!", "G Label discern success!");
                      }
                  }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_GLabel_Retail.Enabled = true;
        }

        private void Btn_Type_Retail_Click(object sender, EventArgs e)
        {
            double ModelScore = 0;
            Btn_Type_Retail.Enabled = false;
            if ((int)Device.Status_D02 != 1)
            {
                Task Test = new Task(new Action(() =>
                {
                    string[] add = { "JP", "NA" };
                    for (int i = 0; i < add.Length; i++)
                    {
                        if (Device.Read_Type_Reatil(Device.mac.Product, add[i], out ModelScore))
                        {
                            DeviceMain.Notify("侧面型号识别成功!", "Retail Type discern success!");
                            return;
                        }
                    }
                }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_Type_Retail.Enabled = true;
        }

        private void Btn_Memory_Retail_Click(object sender, EventArgs e)
        {
            double ModelScore = 0;
            Btn_Memory_Retail.Enabled = false;
            if ((int)Device.Status_D02 != 1)
            {
                Task Test = new Task(new Action(() =>
                {
                    string[] memory = { "64GB", "128GB", "256GB" };
                    string[] language = { "EN", "FR" };
                    for (int i = 0; i < memory.Length; i++)
                    {
                        for (int j = 0; j < language.Length; j++)
                        {
                            if (Device.Read_Memory_Retail(memory[i], language[j], out ModelScore))
                            {
                                DeviceMain.Notify("内存识别成功!", "Memory discern success!");
                                return;
                            }
                        }
                    }
                }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_Memory_Retail.Enabled = true;
        }

        private void Btn_Color_Retail_Click(object sender, EventArgs e)
        {
            double ModelScore = 0;
            Btn_Color_Retail.Enabled = false;
            if ((int)Device.Status_D02 != 1)
            {
                Task Test = new Task(new Action(() =>
                {
                    string[] color = { "Black", "Blue", "White", "Orange" };
                    string[] language = { "EN", "FR" };
                    for (int i = 0; i < color.Length; i++)
                    {
                        for (int j = 0; j < language.Length; j++)
                        {
                            if (Device.Read_Color_Retail(color[i], language[j],out ModelScore))
                            {
                                DeviceMain.Notify("侧面颜色识别成功!", "Retail Color discern success!");
                                return;
                            }
                        }
                    }
                }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_Color_Retail.Enabled = true;
        }

        private void Btn_BarCode_Retail_Click(object sender, EventArgs e)
        {
            Btn_BarCode_Retail.Enabled = false;
            if ((int)Device.Status_D02 != 1)
            {
                Task Test = new Task(new Action(() =>
                {
                    Device.Read_Barcode_Retail("Test", "Test","Test","Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test");
                    DeviceMain.Notify("条码识别完成!", "Retail BarCode discern done!");
                }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_BarCode_Retail.Enabled = true;
        }

        private void Btn_Type_BOB_Click(object sender, EventArgs e)
        {
            double ModelScore = 0;
            Btn_Type_BOB.Enabled = false;
            if ((int)Device.Status_D03 != 1)
            {
                Task Test = new Task(new Action(() =>
                {
                    if (Device.Read_Type_BOB(Device.mac.Product,out ModelScore))
                    {
                        DeviceMain.Notify("底面型号识别成功!", "BOB Type discern success!");
                    }
                }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_Type_BOB.Enabled = true;
        }

        private void Btn_Price_BOB_Click(object sender, EventArgs e)
        {
            double ModelScore = 0;
            Btn_Price_BOB.Enabled = false;
            if ((int)Device.Status_D03 != 1)
            {
                Task Test = new Task(new Action(() =>
                {
                    string[] memory = { "64GB", "128GB", "256GB" };
                    for (int i = 0; i < memory.Length; i++)
                    {
                        if (Device.Read_Price_BOB(memory[i],out ModelScore))
                        {
                            DeviceMain.Notify("底面价格识别成功!", "BOB Price discern success!");
                            return;
                        }
                    }
                }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_Price_BOB.Enabled = true;
        }

        private void Btn_Date_BOB_Click(object sender, EventArgs e)
        {
            double ModelScore = 0;
            Btn_Date_BOB.Enabled = false;
            if ((int)Device.Status_D03 != 1)
            {
                Task Test = new Task(new Action(() =>
                {
                    string[] Type = { "IN", "TW" };
                    for (int i = 0; i < Type.Length; i++)
                    {
                        if (Device.Read_Date_BOB(Type[i], out ModelScore))
                        {
                            DeviceMain.Notify("底面日期识别成功!", "BOB Date discern success!");
                            return;
                        }
                    }
                }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_Date_BOB.Enabled = true;
        }

        private void Btn_CCD1_TakePicture_Click(object sender, EventArgs e)
        {
            Btn_CCD1_TakePicture.Enabled = false;
            if ((int)Device.Status_D02 != 1)
            {
                Task Test = new Task(new Action(() =>
                {
                    Device.Take_Picture(1, Convert.ToInt32(Tb_CCD1_EXTime.Text));
                }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_CCD1_TakePicture.Enabled = true;
        }

        private void Btn_CCD2_TakePicture_Click(object sender, EventArgs e)
        {
            Btn_CCD2_TakePicture.Enabled = false;
            if ((int)Device.Status_D02 != 1)
            {
                Task Test = new Task(new Action(() =>
                {
                    Device.Take_Picture(2, Convert.ToInt32(Tb_CCD2_EXTime.Text));
                }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_CCD2_TakePicture.Enabled = true;
        }

        private void Btn_CCD3_TakePicture_Click(object sender, EventArgs e)
        {
            Btn_CCD3_TakePicture.Enabled = false;
            if ((int)Device.Status_D02 != 1)
            {
                Task Test = new Task(new Action(() =>
                {
                    Device.Take_Picture(3, Convert.ToInt32(Tb_CCD3_EXTime.Text));
                }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_CCD3_TakePicture.Enabled = true;
        }

        private void Btn_BeltAction_Click(object sender, EventArgs e)
        {
            Btn_BeltAction.Enabled = false;
            if (DialogResult.Yes == DeviceMain.MsgShow("确定回流彩盒吗?", "Do you want to backflow the box?", "警告", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Task Test = new Task(new Action(() =>
                {
                    Device.BeltContinuousAction(false, true, true, false, Belt_D01_Run, Belt_D02_Run, Belt_D03_Run);
                    ShowInfo.Delay(5000);
                    Device.BeltContinuousAction(false, false, false, false, Belt_D01_Run, Belt_D02_Run, Belt_D03_Run);
                }));
                Test.Start();
                while (!Test.IsCompleted) ShowInfo.Delay(1);
            }
            Btn_BeltAction.Enabled = true;
        }

        private void Btn_GetScannerResult_Click(object sender, EventArgs e)
        {
            Btn_GetScannerResult.Enabled = false;
            Tb_ScannerResult.Clear();
            try
            {
                bool check = false;
                Task trigger = new Task(new Action(() => { check = Device.scanner.ScannerTrigger(Device.snc.OverTime, (int)Device.mac.Runmod, Device.mac.SNLength, Device.snc.Length); }));
                trigger.Start();
                while (!trigger.IsCompleted)
                {
                    ShowInfo.Delay(10);
                }
                if (check)//扫码
                {
                    Tb_ScannerResult.Text = Device.scanner.ScannerResults;
                }
                else
                {
                    DeviceMain.MsgShow("扫码枪触发异常!", "Scanner Trigger wrong!", "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                DeviceMain.MsgShow("扫码枪触发异常!", "Scanner Trigger wrong!", "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Btn_GetScannerResult.Enabled = true;
            }
        }

        private void Btn_ScannerClose_Click(object sender, EventArgs e)
        {
            Device.scanner.ScannerClose();
        }

        private void Btn_ScannerOpen_Click(object sender, EventArgs e)
        {
            Device.scanner.ScannerClose();
            Device.scanner.IniScanner(Device.snc.ProtName.ToString(), (int)Device.snc.BanudRate, (int)Device.snc.DataBits, Device.snc.Parity, Device.snc.StopBits);
            Device.scanner.ScannerOpen();
        }

        private void Btn_GetScalesResult_Click(object sender, EventArgs e)
        {
            Btn_GetScalesResult.Enabled = false;
            Tb_ScalesResult.Clear();
            try
            {
                bool check = false;
                Task trigger = new Task(new Action(() => { check = Device.scales.ScalesTrigger(Device.slc.OverTime); }));
                trigger.Start();
                while (!trigger.IsCompleted)
                {
                    ShowInfo.Delay(10);
                }
                if (check)//扫码
                {
                    Tb_ScalesResult.Text = Device.scales.ScalesResults;
                }
                else
                {
                    DeviceMain.MsgShow("电子秤触发异常!", "Scales Trigger wrong!", "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                DeviceMain.MsgShow("电子秤触发异常!", "Scales Trigger wrong!", "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Btn_GetScalesResult.Enabled = true;
            }
        }

        private void Btn_ScalesClose_Click(object sender, EventArgs e)
        {
            Device.scales.ScalesClose();
        }

        private void Btn_ScalesOpen_Click(object sender, EventArgs e)
        {
            Device.scales.ScalesClose();
            Device.scales.IniScales(Device.slc.ProtName.ToString(), (int)Device.slc.BanudRate, (int)Device.slc.DataBits, Device.slc.Parity, Device.slc.StopBits);
            Device.scales.ScalesOpen();
        }

        private void Btn_OptLightClose_Click(object sender, EventArgs e)
        {
            Device.optlight.DestoryPortConnect();
        }

        private void Btn_OptLightOpen_Click(object sender, EventArgs e)
        {
            Device.optlight.DestoryPortConnect();
            Device.optlight.InitPort(Device.olc.ProtName.ToString());
        }

        private void Btn_StatusFlash()
        {
            CylStatus(Btn_Cyl_D01Intercept);
            CylStatus(Btn_Station_GetReady_Input);

            CylStatus(Btn_Cyl_D02Intercept);
            CylStatus(Btn_Cyl_D02Weigh);

            CylStatus(Btn_Cyl_D03Adjust);
            CylStatus(Btn_Cyl_D03Lifter);
            CylStatus(Btn_Cyl_D03Forward);
            CylStatus(Btn_Cyl_D03Clamp);
            CylStatus(Btn_Cyl_D03Rotate);
            CylStatus(Btn_Cyl_D03Carry);
            CylStatus(Btn_Station_GetReady_Output);
            CylStatus(Btn_Station_NotPaste);
            CylStatus(Btn_Station_LabelType);
            CylStatus(Btn_Station_SKUChange);

            CylStatus(Btn_Belt_D01_Enable);
            CylStatus(Btn_Belt_D01_Direction);
            CylStatus(Btn_Belt_D01_Run);
            CylStatus(Btn_Belt_D02_Enable);
            CylStatus(Btn_Belt_D02_Direction);
            CylStatus(Btn_Belt_D02_Run);
            CylStatus(Btn_Belt_D03_Enable);
            CylStatus(Btn_Belt_D03_Direction);
            CylStatus(Btn_Belt_D03_Run);

            CylStatus(Btn_Beacon_Lamp_Red);
            CylStatus(Btn_Beacon_Lamp_Yellow);
            CylStatus(Btn_Beacon_Lamp_Green);
            CylStatus(Btn_Beacon_Buzzer);
        }

        private void CylStatus(Button btn)
        {
            try
            {
                Object obj = Device.GetType().GetProperty(btn.Name.Substring(btn.Name.IndexOf('_') + 1)).GetValue(Device);
                Output output = (Output)obj;
                if (!output.IsOn(Device.ioc))
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.Black;
                }
                else
                {
                    btn.BackColor = Color.Red;
                    btn.ForeColor = Color.White;
                }
            }
            catch { }
        }

        private void Btn_CCD1_ReadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.InitialDirectory = Application.StartupPath;
            filedialog.Filter = "Format-bmp|*.bmp|Format-jpg|*.jpg|Format-jpeg|*.jpeg|Format-png|*.png";
            filedialog.RestoreDirectory = true;
            filedialog.FilterIndex = 1;
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                Device.Read_Image(1, filedialog.FileName);
                Device.CCD1.FitImage(new HImage(filedialog.FileName));
            }
        }

        private void Btn_CCD2_ReadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.InitialDirectory = Application.StartupPath;
            filedialog.Filter = "Format-bmp|*.bmp|Format-jpg|*.jpg|Format-jpeg|*.jpeg|Format-png|*.png";
            filedialog.RestoreDirectory = true;
            filedialog.FilterIndex = 1;
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                Device.Read_Image(2, filedialog.FileName);
                Device.CCD2.FitImage(new HImage(filedialog.FileName));
            }
        }

        private void Btn_CCD3_ReadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.InitialDirectory = Application.StartupPath;
            filedialog.Filter = "Format-bmp|*.bmp|Format-jpg|*.jpg|Format-jpeg|*.jpeg|Format-png|*.png";
            filedialog.RestoreDirectory = true;
            filedialog.FilterIndex = 1;
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                Device.Read_Image(3, filedialog.FileName);
                Device.CCD3.FitImage(new HImage(filedialog.FileName));
            }
        }

        private void Btn_CCD1_SavePicture_Click(object sender, EventArgs e)
        {
            SaveFileDialog filedialog = new SaveFileDialog();
            filedialog.InitialDirectory = Application.StartupPath;
            filedialog.Filter = "Format-bmp|*.bmp|Format-jpg|*.jpg|Format-jpeg|*.jpeg|Format-png|*.png";
            filedialog.RestoreDirectory = true;
            filedialog.FilterIndex = 1;
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                if (filedialog.FilterIndex == 1)
                    Device.Save_Image(1, filedialog.FileName, "bmp");
                if (filedialog.FilterIndex == 2)
                    Device.Save_Image(1, filedialog.FileName, "jpg");
                if (filedialog.FilterIndex == 3)
                    Device.Save_Image(1, filedialog.FileName, "jpeg");
                if (filedialog.FilterIndex == 4)
                    Device.Save_Image(1, filedialog.FileName, "png");
            }
        }

        private void Btn_CCD2_SavePicture_Click(object sender, EventArgs e)
        {
            SaveFileDialog filedialog = new SaveFileDialog();
            filedialog.InitialDirectory = Application.StartupPath;
            filedialog.Filter = "Format-bmp|*.bmp|Format-jpg|*.jpg|Format-jpeg|*.jpeg|Format-png|*.png";
            filedialog.RestoreDirectory = true;
            filedialog.FilterIndex = 1;
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                if (filedialog.FilterIndex == 1)
                    Device.Save_Image(2, filedialog.FileName, "bmp");
                if (filedialog.FilterIndex == 2)
                    Device.Save_Image(2, filedialog.FileName, "jpg");
                if (filedialog.FilterIndex == 3)
                    Device.Save_Image(2, filedialog.FileName, "jpeg");
                if (filedialog.FilterIndex == 4)
                    Device.Save_Image(2, filedialog.FileName, "png");
            }
        }

        private void Btn_CCD3_SavePicture_Click(object sender, EventArgs e)
        {
            SaveFileDialog filedialog = new SaveFileDialog();
            filedialog.InitialDirectory = Application.StartupPath;
            filedialog.Filter = "Format-bmp|*.bmp|Format-jpg|*.jpg|Format-jpeg|*.jpeg|Format-png|*.png";
            filedialog.RestoreDirectory = true;
            filedialog.FilterIndex = 1;
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                if (filedialog.FilterIndex == 1)
                    Device.Save_Image(3, filedialog.FileName, "bmp");
                if (filedialog.FilterIndex == 2)
                    Device.Save_Image(3, filedialog.FileName, "jpg");
                if (filedialog.FilterIndex == 3)
                    Device.Save_Image(3, filedialog.FileName, "jpeg");
                if (filedialog.FilterIndex == 4)
                    Device.Save_Image(3, filedialog.FileName, "png");
            }
        }
    }
}

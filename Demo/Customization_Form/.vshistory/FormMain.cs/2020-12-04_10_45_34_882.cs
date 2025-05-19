using HelperCmd;
using hWindControl;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine
{
    public partial class FormMain : Form
    {
        DeviceMain Device = new DeviceMain();
        FormSetting FS = null;
        FormInit FI = null;
        public FormMain()
        {
            Device.ConfigLoad();
            InitializeComponent();
            DeviceMain.Language = (int)Device.mac.Language;
            Device.log.Init(Rtb_Log, @"D:\DeviceData");
            FormTranslate();
            ControlsInit();
            FS = new FormSetting(Device);
            FI = new FormInit(Device);
            IPAddress[] ipaddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            foreach (IPAddress a in ipaddress)
            {
                if (a.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (!a.ToString().Contains("192.168"))
                    {
                        Text += String.Format("   [IPAddress]:[{0}]", a);
                    }
                }
            }
            Btn_LockDSN.Visible = Device.LockDSNEnable = Device.fabn.Tb_Versions[0].Equals("00.00.00");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Device.mac.Runmod = RunMod.Normal;
            Device.snc.Lock_DSN = string.Empty;
            bool NetworkStatus = false;
            FI.Show();
            FI.Activate();
            bool CCDinit = false;
            Task t = new Task(new Action(() => // 进行显示初始化信息action
            {
                FI.TopMost = true;
                DeviceMain.Notify("软件启动", "Application Running");
                if (Device.IOCardInit())
                {
                    FI.RateOfProgress(0, true, 20);
                    Device.OutputInit();
                }
                else
                {
                    FI.RateOfProgress(0, false, 20);
                    FI.TopMost = false;
                    DeviceMain.MsgShow("IO卡初始化失败!", "IOCard Initialization Fail!", "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (Device.ScannerInit())
                {
                    FI.RateOfProgress(1, true, 40);
                }
                else
                {
                    FI.RateOfProgress(1, false, 40);
                    FI.TopMost = false;
                    DeviceMain.MsgShow("扫码枪初始化失败!", "Scanner Initialization Fail!", "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (Device.ScalesInit())
                {
                    FI.RateOfProgress(2, true, 60);
                }
                else
                {
                    FI.RateOfProgress(2, false, 60);
                    FI.TopMost = false;
                    DeviceMain.MsgShow("电子秤初始化失败!", "Scales Initialization Fail!", "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (Device.OptLightInit())
                {
                    FI.RateOfProgress(3, true, 80);
                }
                else
                {
                    FI.RateOfProgress(3, false, 80);
                    FI.TopMost = false;
                    DeviceMain.MsgShow("光源控制器初始化失败!", "OptLight Initialization Fail!", "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                CCDinit = Device.CCDInit();
                if (CCDinit)
                {
                    FI.RateOfProgress(4, true, 100);
                }
                else
                {
                    FI.RateOfProgress(4, false, 100);
                    FI.TopMost = false;
                    DeviceMain.MsgShow("CCD初始化失败!", "CCD Initialization Fail!", "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (Device.NetworkInit())
                {
                    FI.RateOfProgress(5, true, 120);
                    NetworkStatus = true;
                }
                else
                {
                    FI.RateOfProgress(5, false, 120);
                    NetworkStatus = false;
                    FI.TopMost = false;
                    DeviceMain.MsgShow("网络连接初始化失败!", "Network Initialization Fail!", "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (DialogResult.Yes == DeviceMain.MsgShow("是否启用调试模式?", "Do you want to Change DebugMod?", "警告", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        Device.mac.Runmod = RunMod.Debug;
                    }
                }
                Device.Connect();
            }));
            t.Start();
            while (!t.IsCompleted)
            {
                ShowInfo.Delay(1);
            }
            FI.Close();
            timerstart();
            Status_Network.BackColor = NetworkStatus ? Color.Lime : Color.Red;
            Status_Network.ForeColor = NetworkStatus ? Color.Black : Color.White;
            Status_Network.Text = NetworkStatus ? (DeviceMain.Language == 0 ? "连接成功" : "Connect") : (DeviceMain.Language == 0 ? "连接失败" : "DisConnect");
            Device.Init_Machine();
            Device.NetWorkConnectCheck();
            new Task(new Action(() =>
            {
                ShowInfo.Delay(300);
                Activate();
                if (CCDinit) Device.CCDFit();
            })).Start();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Btn_Setting_Click(object sender, EventArgs e)
        {
            if (FS.hide)
            {
                new FormUserLogin(Device).ShowDialog();
                if (DeviceMain.Login)
                {
                    DeviceMain.Login = false;
                    FS.AccessLevelChange();
                    FS.Show();
                    FS.hide = false;
                }
            }
            else
            {
                FS.WindowState = FormWindowState.Normal;
                FS.Activate();
            }
        }

        private void ControlsInit()
        {
            Device.CCD1 = CCD1;
            Device.CCD2 = CCD2;
            Device.CCD3 = CCD3;
        }

        public void FormTranslate()
        {
            Translate(this);
        }

        private void Translate(Control Control)
        {
            foreach (Control control in Control.Controls)
            {
                var t = Device.fmnn.GetType().GetProperty(control.Name);
                if (t != null)
                {
                    if (control.GetType() == typeof(hWinCtrl))
                    {
                        string[] d = (string[])t.GetValue(Device.fmnn);
                        hWinCtrl CCD = (hWinCtrl)control;
                        CCD.WindowName = d[DeviceMain.Language];
                    }
                    else
                    {
                        string[] d = (string[])t.GetValue(Device.fmnn);
                        control.Text = d[DeviceMain.Language];
                    }
                }
                Translate(control);
            }
        }

        private void StatusShow(Button btn, DeviceMain.StationStatus station)
        {
            btn.Text = station.ToString();
            if ((int)station < 3)
            {
                btn.BackColor = Color.Lime;
                btn.ForeColor = Color.Black;
            }
            else if ((int)station < 4)
            {
                btn.BackColor = Color.Orange;
                btn.ForeColor = Color.Black;
            }
            else if ((int)station < 5)
            {
                btn.BackColor = Color.YellowGreen;
                btn.ForeColor = Color.Black;
            }
            else if ((int)station < 6)
            {
                btn.BackColor = Color.Yellow;
                btn.ForeColor = Color.Black;
            }
            else if ((int)station < 7)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
            }
            else if ((int)station < 8)
            {
                btn.BackColor = Color.Red;
                btn.ForeColor = Color.White;
            }
            else if ((int)station < 9)
            {
                btn.BackColor = Color.Black;
                btn.ForeColor = Color.White;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (DialogResult.Yes == DeviceMain.MsgShow("确认退出程序吗?", "Do you want to Exit?", "退出", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Device.Stop_Machine();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void timer_ProductionInfo_Tick(object sender, EventArgs e)
        {
            Tb_DSNShow.Text = Device.dataserver.StationLoc[2].DSN;
            Tb_WeightShow.Text = DeviceMain.Language == 0 ? string.Format("{0}克", Device.dataserver.StationLoc[2].Weight) : string.Format("{0}g", Device.dataserver.StationLoc[2].Weight);
            Tb_StandarShow.Text = DeviceMain.Language == 0 ? string.Format("{0}克", Device.dataserver.StationLoc[2].Standard) : string.Format("{0}g", Device.dataserver.StationLoc[2].Standard);
            Tb_StationIDShow.Text = Device.dataserver.StationLoc[2].StationID;
        }

        private void timer_TotalInfo_Tick(object sender, EventArgs e)
        {
            Tb_PassShow.Text = Device.toc.PassCount.ToString();
            Tb_NGShow.Text = Device.toc.NgCount.ToString();
            Tb_PassRateShow.Text = string.Format("{0} %", (Device.toc.PassRate * 100).ToString("000.000"));
            Tb_CircleTimeShow.Text = Device.CircleTime;
        }

        private void timer_CheckItems_Tick(object sender, EventArgs e)
        {
            Status_SnCheck.BackColor = Device.dataserver.StationLoc[2].DSNCheck ? Color.Lime : Color.Red;
            Status_WeighCheck.BackColor = Device.dataserver.StationLoc[2].Weight_Check ? Color.Lime : Color.Red;
            Status_Color_Top.BackColor = Device.dataserver.StationLoc[2].Color_Front_Check ? Color.Lime : Color.Red;
            Status_Color_Retail.BackColor = Device.dataserver.StationLoc[2].Color_Retail_Check ? Color.Lime : Color.Red;
            Status_Type_Top.BackColor = Device.dataserver.StationLoc[2].Type_Front_Check ? Color.Lime : Color.Red;
            Status_Type_Retail.BackColor = Device.dataserver.StationLoc[2].Type_Retail_Check ? Color.Lime : Color.Red;
            Status_Type_BOB.BackColor = Device.dataserver.StationLoc[2].Type_BOB_Check ? Color.Lime : Color.Red;
            Status_GLabel.BackColor = Device.dataserver.StationLoc[2].GLabel_Check ? Color.Lime : Color.Red;
            Status_Memory.BackColor = Device.dataserver.StationLoc[2].Memory_Check ? Color.Lime : Color.Red;
            Status_Barcode.BackColor = Device.dataserver.StationLoc[2].SkuCheck && Device.dataserver.StationLoc[2].IMEICheck ? Color.Lime : Color.Red;
            Status_Price.BackColor = Device.dataserver.StationLoc[2].Price_Check && Device.dataserver.StationLoc[2].Date_Check ? Color.Lime : Color.Red;
            Status_DataUpload.BackColor = Device.dataserver.StationLoc[2].DataUpload > 0 ? Color.Lime : Color.Red;
        }

        private void timer_StatusFlash_Tick(object sender, EventArgs e)
        {
            StatusShow(Info_Status_D01, Device.Status_D01);
            StatusShow(Info_Status_D02, Device.Status_D02);
            StatusShow(Info_Status_D03, Device.Status_D03);
        }

        private void timer_CircleTimeFlash_Tick(object sender, EventArgs e)
        {
            Info_CircleTime_D01.Text = Device.CircleTime_D01;
            Info_CircleTime_D02.Text = Device.CircleTime_D02;
            Info_CircleTime_D03.Text = Device.CircleTime_D03;
        }

        private void timer_SafeGuardandEMG_Tick(object sender, EventArgs e)
        {
            Status_SafeGuard.BackColor = Device.Signal_SafeGuard.IO64Power(Device.ioc) ? Color.Red : Color.Lime;
            Status_SafeGuard.ForeColor = Device.Signal_SafeGuard.IO64Power(Device.ioc) ? Color.White : Color.Black;
            Status_EMG.BackColor = Device.Signal_EMG.IO64Power(Device.ioc) ? Color.Red : Color.Lime;
            Status_EMG.ForeColor = Device.Signal_EMG.IO64Power(Device.ioc) ? Color.White : Color.Black;
        }

        private void timer_Network_Tick(object sender, EventArgs e)
        {
            //bool NetworkStatus = false;
            //Task chang = new Task(new Action(() =>
            // {
            //     NetworkStatus = Device.NetworkInit();
            //     Device.Connect();
            // }));
            //chang.Start();
            //while (!chang.IsCompleted) ShowInfo.Delay(1);
            //Status_Network.BackColor = NetworkStatus ? Color.Lime : Color.Red;
            //Status_Network.ForeColor = NetworkStatus ? Color.Black : Color.White;
            //Status_Network.Text = NetworkStatus ? (DeviceMain.Language == 0 ? "连接成功" : "Connect") : (DeviceMain.Language == 0 ? "连接失败" : "DisConnect");
            Status_Network.BackColor = DeviceMain.NetworkStatus ? Color.Lime : Color.Red;
            Status_Network.ForeColor = DeviceMain.NetworkStatus ? Color.Black : Color.White;
            Status_Network.Text = DeviceMain.NetworkStatus ? (DeviceMain.Language == 0 ? "连接成功" : "Connect") : (DeviceMain.Language == 0 ? "连接失败" : "DisConnect");
        }

        private void timer_RunMod_Tick(object sender, EventArgs e)
        {
            Status_RunMod.Text = Device.mac.Runmod.ToString();
            if ((int)Device.mac.Runmod == 0)
            {
                Status_RunMod.BackColor = Color.Lime;
            }
            else if ((int)Device.mac.Runmod == 1)
            {
                Status_RunMod.BackColor = Color.Yellow;
            }
            else if ((int)Device.mac.Runmod == 2)
            {
                Status_RunMod.BackColor = Color.Orange;
            }
            Label_Type.Text = DeviceMain.Language == 0 ? string.Format("机型:{0}", Device.mac.Product.ToString()) : string.Format("Type:{0}", Device.mac.Product.ToString());
            try
            {
                Label_Station.Text = Device.mac.StationID[(int)Device.mac.Product];
            }
            catch
            {

            }
        }

        private void timer_UPH_Tick(object sender, EventArgs e)
        {
            if (Device.UPHwatch.ElapsedMilliseconds > 3600000)
            {
                Device.UPHwatch.Restart();
                Device.BoxCount = 0;
            }
            info_UPH.Text = string.Format("{0}/{1}", Device.UPHwatch.Elapsed, Device.BoxCount);
        }

        private void timer_DSNSend_Tick(object sender, EventArgs e)
        {
            Tb_DSN_D01.Text = Device.dataserver.StationLoc[0].DSN;
            Tb_DSN_D02.Text = Device.dataserver.StationLoc[1].DSN;
        }

        private void timerstart()
        {
            timer_CheckItems.Start();
            timer_CircleTimeFlash.Start();
            timer_Network.Start();
            timer_ProductionInfo.Start();
            timer_RunMod.Start();
            timer_SafeGuardandEMG.Start();
            timer_StatusFlash.Start();
            timer_TotalInfo.Start();
            timer_UPH.Start();
            timer_DSNSend.Start();
        }

        private void Btn_About_Click(object sender, EventArgs e)
        {
            new FormAbout(Device).ShowDialog();
        }

        private void Status_Network_Click(object sender, EventArgs e)
        {
            bool NetworkStatus = false;
            Task chang = new Task(new Action(() =>
            {
                NetworkStatus = Device.NetworkInit();
                Device.Connect();
            }));
            chang.Start();
            while (!chang.IsCompleted) ShowInfo.Delay(1);
            Status_Network.BackColor = NetworkStatus ? Color.Lime : Color.Red;
            Status_Network.ForeColor = NetworkStatus ? Color.Black : Color.White;
            Status_Network.Text = NetworkStatus ? (DeviceMain.Language == 0 ? "连接成功" : "Connect") : (DeviceMain.Language == 0 ? "连接失败" : "DisConnect");
        }

        private void Btn_LanguageChange_Click(object sender, EventArgs e)
        {
            if (DeviceMain.Language == 0)
            {
                if (DialogResult.Yes == MessageBox.Show("当前语言为中文,是否需要切换语言?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    DeviceMain.Language = 1;
                    Device.mac.Language = FormLanguage.EN;
                    Device.mac.Save(DeviceMain.ConfigPath(2, Device.mac), Device.mac);
                    this.FormTranslate();
                    FS.FormTranslate();
                }
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("The current language is English, do you need to switch languages?", "Tip", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    DeviceMain.Language = 0;
                    Device.mac.Language = FormLanguage.ZH;
                    Device.mac.Save(DeviceMain.ConfigPath(2, Device.mac), Device.mac);
                    this.FormTranslate();
                    FS.FormTranslate();
                }

            }
        }

        private void Btn_CCDDebug_Click(object sender, EventArgs e)
        {
            DeviceMain.CCDDebug = false;
            if (!CCD1.Enabled)
            {
                if (Tb_PassWord.Text == Device.ccc.CCDDebug)
                {
                    DeviceMain.Notify("CCD调试用户登入.", "CCD debug user log in");
                    CCD1.Enabled = true;
                    CCD2.Enabled = true;
                    CCD3.Enabled = true;
                    DeviceMain.CCDDebug = true;
                }
                else
                {
                    DeviceMain.MsgShow("密码错误!", "Password is wrong!", "信息", "Information");
                }
                Tb_PassWord.Clear();
            }
            else
            {
                DeviceMain.Notify("CCD调试用户登出.", "CCD debug user log out");
                CCD1.Enabled = false;
                CCD2.Enabled = false;
                CCD3.Enabled = false;
            }
        }

        private void Tb_PassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Btn_CCDDebug.PerformClick();
            }
        }

        private void Btn_MachineStop_Click(object sender, EventArgs e)
        {
            DeviceMain.StopButton = true;
        }

        private void Btn_MachineReset_Click(object sender, EventArgs e)
        {
            DeviceMain.ResetButton = true;
        }

        private void Btn_MachineRun_Click(object sender, EventArgs e)
        {
            DeviceMain.RunButton = true;
        }

        private void Btn_D01Stop_Click(object sender, EventArgs e)
        {
            Device.Stop_D01();
        }

        private void Btn_D01Reset_Click(object sender, EventArgs e)
        {
            Device.Reset_D01();
        }

        private void Btn_D01Run_Click(object sender, EventArgs e)
        {
            Device.Run_D01();
        }

        private void Btn_D02Stop_Click(object sender, EventArgs e)
        {
            Device.Stop_D02();
        }

        private void Btn_D02Reset_Click(object sender, EventArgs e)
        {
            Device.Reset_D02();
        }

        private void Btn_D02Run_Click(object sender, EventArgs e)
        {
            Device.Run_D02();
        }

        private void Btn_D03Stop_Click(object sender, EventArgs e)
        {
            Device.Stop_D03();
        }

        private void Btn_D03Reset_Click(object sender, EventArgs e)
        {
            Device.Reset_D03();
        }

        private void Btn_D03Run_Click(object sender, EventArgs e)
        {
            Device.Run_D03();
        }

        private void Btn_MachineBuzzer_Click(object sender, EventArgs e)
        {
            Device.Beacon_Buzzer.IO64Power(Device.ioc, false);
        }

        private void Btn_ClearTotal_Click(object sender, EventArgs e)
        {
            //if (DialogResult.Yes == DeviceMain.MsgShow("是否需要清空产能数据?", "Do you want to  clear capacity data?", "警告", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            //{
            //    Device.toc.PassCount = 0;
            //    Device.toc.NgCount = 0;
            //    Device.toc.Save(DeviceMain.ConfigPath(2, Device.toc), Device.toc);
            //}
            DeviceMain.Notify(Device.IMEI2NeedCheck("GA02134-US"));
        }

        private void Btn_LockDSN_Click(object sender, EventArgs e)
        {
            new Task(new Action(() =>
             {
                 if (!FormLockDSN.OpenForm) new FormLockDSN(Device).ShowDialog();
             })).Start();
        }
    }
}

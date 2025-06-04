using HalconDotNet;
using HelperCmd;
using hWindControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine
{
    public partial class DeviceMain
    {
        #region 参数
        public static AccessLevel User = AccessLevel.Guest;
        public static Int32 Language = 0;
        public static Boolean Login = false;
        public static Boolean CCDDebug = false;
        public static Boolean NetworkStatus = false;
        public Boolean LockDSNEnable = false;

        public MachineConfig mac = new MachineConfig();
        public CCDConfig ccc = new CCDConfig();
        public ScannerConfig snc = new ScannerConfig();
        public ScalseConfig slc = new ScalseConfig();
        public OptLightConfig olc = new OptLightConfig();
        public IOConfig ioc = new IOConfig();
        public PassWordConfig pwc = new PassWordConfig();
        public TotalConfig toc = new TotalConfig();
        public WeightConfig wec = new WeightConfig();

        public FormAboutName fabn = new FormAboutName();
        public FormInitName fitn = new FormInitName();
        public FormMainName fmnn = new FormMainName();
        public FormMsgBoxName fmbn = new FormMsgBoxName();
        public FormSettingName fstn = new FormSettingName();
        public FormTotalName fton = new FormTotalName();
        public FormUserLoginName fuln = new FormUserLoginName();
        public FormUserManagementName fumn = new FormUserManagementName();

        public LogService log = new LogService();
        public DataService dataserver = new DataService(3);

        public Scanner scanner = null;
        public Scales scales = null;
        public OptLightController.OptLightController optlight = null;
        public HEngine hEngine = null;
        public hWinCtrl CCD1 = null;
        public hWinCtrl CCD2 = null;
        public hWinCtrl CCD3 = null;

        public HttpHelper http_D01 = null;
        public HttpHelper http_D02 = null;
        public HttpHelper http_D03 = null;
        public HttpHelper http_Test = null;

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public DeviceMain()
        {
            scanner = new Scanner();
            scales = new Scales();
            hEngine = new HEngine("halcon.hdev");
            http_D01 = new HttpHelper();
            http_D02 = new HttpHelper();
            http_D03 = new HttpHelper();
            http_Test = new HttpHelper();
        }

        #region Static静态函数

        public static DialogResult MsgShow(string zhmsg, string enmsg, string zhtitle, string entitle, MessageBoxButtons mbb = MessageBoxButtons.OK, MessageBoxIcon mbi = MessageBoxIcon.Information)
        {
            return MessageBox.Show(Language == 0 ? zhmsg : enmsg, Language == 0 ? zhtitle : entitle, mbb, mbi);
        }

        public static DialogResult MsgShow(string msg, string zhtitle, string entitle, MessageBoxButtons mbb = MessageBoxButtons.OK, MessageBoxIcon mbi = MessageBoxIcon.Information)
        {
            return MessageBox.Show(msg, Language == 0 ? zhtitle : entitle, mbb, mbi);
        }

        public static void Notify(string zh, string en, NotifyType type = NotifyType.Info)
        {
            if (type == NotifyType.Info)
            {
                NotifyG.Info((int)Language == 0 ? zh : en);
            }
            else if (type == NotifyType.Error)
            {
                NotifyG.Error((int)Language == 0 ? zh : en);
            }
            else if (type == NotifyType.Action)
            {
                NotifyG.Action((int)Language == 0 ? zh : en);
            }
            else if (type == NotifyType.Warn)
            {
                NotifyG.Warn((int)Language == 0 ? zh : en);
            }
        }

        public static void Notify(string msg, NotifyType type = NotifyType.Info)
        {
            if (type == NotifyType.Info)
            {
                NotifyG.Info(msg);
            }
            else if (type == NotifyType.Error)
            {
                NotifyG.Error(msg);
            }
            else if (type == NotifyType.Action)
            {
                NotifyG.Action(msg);
            }
            else if (type == NotifyType.Warn)
            {
                NotifyG.Warn(msg);
            }
        }

        public static string ConfigPath(int index, object config, bool islanguage = false)
        {
            if (!islanguage)
            {
                switch (index)
                {
                    case 0:
                        return string.Format(@"Config/DeviceConfig/{0}.Setting", config.GetType().Name);
                    case 1:
                        return string.Format(@"Config/DeviceConfig/{0}_Back", config.GetType().Name);
                    case 2:
                        return string.Format(@"Config/DeviceConfig/{0}", config.GetType().Name);
                }
            }
            else
            {
                switch (index)
                {
                    case 0:
                        return string.Format(@"Config/LanguageText/{0}.Setting", config.GetType().Name);
                    case 1:
                        return string.Format(@"Config/LanguageText/{0}_Back", config.GetType().Name);
                    case 2:
                        return string.Format(@"Config/LanguageText/{0}", config.GetType().Name);
                }
            }
            return string.Empty;
        }

        public static string MsgSelect(string zhmsg, string enmsg)
        {
            return Language == 0 ? zhmsg : enmsg;
        }

        #endregion

        #region 调用函数

        /// <summary>
        /// 交互地址格式化
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GroupAddress(string name)
        {
            return string.Format("http://{0}:{1}/{2}/", mac.IPAddress, mac.NetworkPort, name);
        }

        /// <summary>
        /// 配置文件检查
        /// </summary>
        private void CheckFile()
        {
            if (!Directory.Exists("Config"))
            {
                Directory.CreateDirectory("Config");
            }
            if (!Directory.Exists("Config/DeviceConfig"))
            {
                Directory.CreateDirectory("Config/DeviceConfig");
            }
            if (!Directory.Exists("Config/LanguageText"))
            {
                Directory.CreateDirectory("Config/LanguageText");
            }
            #region
            if (!File.Exists(ConfigPath(0, mac)))
            {
                mac.Save(ConfigPath(2, mac), mac);
            }
            if (!File.Exists(ConfigPath(0, ccc)))
            {
                ccc.Save(ConfigPath(2, ccc), ccc);
            }
            if (!File.Exists(ConfigPath(0, snc)))
            {
                snc.Save(ConfigPath(2, snc), snc);
            }
            if (!File.Exists(ConfigPath(0, slc)))
            {
                slc.Save(ConfigPath(2, slc), slc);
            }
            if (!File.Exists(ConfigPath(0, olc)))
            {
                olc.Save(ConfigPath(2, olc), olc);
            }
            if (!File.Exists(ConfigPath(0, ioc)))
            {
                ioc.Save(ConfigPath(2, ioc), ioc);
            }
            if (!File.Exists(ConfigPath(0, pwc)))
            {
                pwc.Save(ConfigPath(2, pwc), pwc);
            }
            if (!File.Exists(ConfigPath(0, toc)))
            {
                toc.Save(ConfigPath(2, toc), toc);
            }
            if (!File.Exists(ConfigPath(0, wec)))
            {
                wec.Save(ConfigPath(2, wec), wec);
            }
            #endregion

            #region
            if (!File.Exists(ConfigPath(0, fabn, true)))
            {
                fabn.Save(ConfigPath(2, fabn, true), fabn);
            }
            if (!File.Exists(ConfigPath(0, fitn, true)))
            {
                fitn.Save(ConfigPath(2, fitn, true), fitn);
            }
            if (!File.Exists(ConfigPath(0, fmnn, true)))
            {
                fmnn.Save(ConfigPath(2, fmnn, true), fmnn);
            }
            if (!File.Exists(ConfigPath(0, fmbn, true)))
            {
                fmbn.Save(ConfigPath(2, fmbn, true), fmbn);
            }
            if (!File.Exists(ConfigPath(0, fstn, true)))
            {
                fstn.Save(ConfigPath(2, fstn, true), fstn);
            }
            if (!File.Exists(ConfigPath(0, fton, true)))
            {
                fton.Save(ConfigPath(2, fton, true), fton);
            }
            if (!File.Exists(ConfigPath(0, fuln, true)))
            {
                fuln.Save(ConfigPath(2, fuln, true), fuln);
            }
            if (!File.Exists(ConfigPath(0, fumn, true)))
            {
                fumn.Save(ConfigPath(2, fumn, true), fumn);
            }
            #endregion
        }

        /// <summary>
        /// 配置加载
        /// </summary>
        private void LoadConfig()
        {
            #region
            try
            {
                mac = mac.Load(ConfigPath(2, mac));
                mac.Save(ConfigPath(1, mac), mac);
            }
            catch
            {
                mac = mac.Load(ConfigPath(1, mac));
            }
            try
            {
                ccc = ccc.Load(ConfigPath(2, ccc));
                ccc.Save(ConfigPath(1, ccc), ccc);
            }
            catch
            {
                ccc = ccc.Load(ConfigPath(1, ccc));
            }
            try
            {
                snc = snc.Load(ConfigPath(2, snc));
                snc.Save(ConfigPath(1, snc), snc);
            }
            catch
            {
                snc = snc.Load(ConfigPath(1, snc));
            }
            try
            {
                slc = slc.Load(ConfigPath(2, slc));
                slc.Save(ConfigPath(1, slc), slc);
            }
            catch
            {
                slc = slc.Load(ConfigPath(1, slc));
            }
            try
            {
                olc = olc.Load(ConfigPath(2, olc));
                olc.Save(ConfigPath(1, olc), olc);
            }
            catch
            {
                olc = olc.Load(ConfigPath(1, olc));
            }
            try
            {
                ioc = ioc.Load(ConfigPath(2, ioc));
                ioc.Save(ConfigPath(1, ioc), ioc);
            }
            catch
            {
                ioc = ioc.Load(ConfigPath(1, ioc));
            }
            try
            {
                pwc = pwc.Load(ConfigPath(2, pwc));
                pwc.Save(ConfigPath(1, pwc), pwc);
            }
            catch
            {
                pwc = pwc.Load(ConfigPath(1, pwc));
            }
            try
            {
                toc = toc.Load(ConfigPath(2, toc));
                toc.Save(ConfigPath(1, toc), toc);
            }
            catch
            {
                toc = toc.Load(ConfigPath(1, toc));
            }
            try
            {
                wec = wec.Load(ConfigPath(2, wec));
                wec.Save(ConfigPath(1, wec), wec);
            }
            catch
            {
                wec = wec.Load(ConfigPath(1, wec));
            }
            #endregion

            #region
            try
            {
                fabn = fabn.Load(ConfigPath(2, fabn, true));
                fabn.Save(ConfigPath(1, fabn, true), fabn);
            }
            catch
            {
                fabn = fabn.Load(ConfigPath(1, fabn, true));
            }
            try
            {
                fitn = fitn.Load(ConfigPath(2, fitn, true));
                fitn.Save(ConfigPath(1, fitn, true), fitn);
            }
            catch
            {
                fitn = fitn.Load(ConfigPath(1, fitn, true));
            }
            try
            {
                fmnn = fmnn.Load(ConfigPath(2, fmnn, true));
                fmnn.Save(ConfigPath(1, fmnn, true), fmnn);
            }
            catch
            {
                fmnn = fmnn.Load(ConfigPath(1, fmnn, true));
            }
            try
            {
                fmbn = fmbn.Load(ConfigPath(2, fmbn, true));
                fmbn.Save(ConfigPath(1, fmbn, true), fmbn);
            }
            catch
            {
                fmbn = fmbn.Load(ConfigPath(1, fmbn, true));
            }
            try
            {
                fstn = fstn.Load(ConfigPath(2, fstn, true));
                fstn.Save(ConfigPath(1, fstn, true), fstn);
            }
            catch
            {
                fstn = fstn.Load(ConfigPath(1, fstn, true));
            }
            try
            {
                fton = fton.Load(ConfigPath(2, fton, true));
                fton.Save(ConfigPath(1, fton, true), fton);
            }
            catch
            {
                fton = fton.Load(ConfigPath(1, fton, true));
            }
            try
            {
                fuln = fuln.Load(ConfigPath(2, fuln, true));
                fuln.Save(ConfigPath(1, fuln, true), fuln);
            }
            catch
            {
                fuln = fuln.Load(ConfigPath(1, fuln, true));
            }
            try
            {
                fumn = fumn.Load(ConfigPath(2, fumn, true));
                fumn.Save(ConfigPath(1, fumn, true), fumn);
            }
            catch
            {
                fumn = fumn.Load(ConfigPath(1, fumn, true));
            }
            #endregion
        }

        /// <summary>
        /// 配置文件检查并加载
        /// </summary>
        public void ConfigLoad()
        {
            CheckFile();
            LoadConfig();
        }

        /// <summary>
        /// 雷赛IO卡初始化
        /// </summary>
        /// <returns></returns>
        public bool IOCardInit()
        {
            return IOC0640.Init();
        }

        /// <summary>
        /// 扫码枪初始化
        /// </summary>
        /// <returns></returns>
        public bool ScannerInit()
        {
            return scanner.IniScanner(snc.ProtName.ToString(), (int)snc.BanudRate, (int)snc.DataBits, snc.Parity, snc.StopBits) && scanner.ScannerOpen();
        }

        /// <summary>
        /// 电子秤初始化
        /// </summary>
        /// <returns></returns>
        public bool ScalesInit()
        {
            return scales.IniScales(slc.ProtName.ToString(), (int)slc.BanudRate, (int)slc.DataBits, slc.Parity, slc.StopBits) && scales.ScalesOpen();
        }

        /// <summary>
        /// 光源控制器初始化
        /// </summary>
        /// <returns></returns>
        public bool OptLightInit()
        {
            return optlight.InitPort(olc.ProtName.ToString());
        }

        /// <summary>
        /// CCD初始化
        /// </summary>
        /// <returns></returns>
        public bool CCDInit()
        {
            try
            {
                if (hEngine.OpenSocket(CCD1, CCD2, CCD3))
                {
                    String imagePath = Path.Combine(Application.StartupPath, "Image");//拼接路径
                    HTuple hTuple = new HTuple("Open_Framegrabber", ccc.VirtualCCD.ToString(), imagePath, ccc.CCD1Name, ccc.CCD2Name, ccc.CCD3Name);
                    hEngine.SendTuple(hTuple);
                    hTuple = hEngine.ReceiveTuple();
                    if (hTuple[0] == 1)
                    {
                        CCD1.hv_AcHandle = new HFramegrabber(hTuple[1]);
                        CCD2.hv_AcHandle = new HFramegrabber(hTuple[2]);
                        CCD3.hv_AcHandle = new HFramegrabber(hTuple[3]);

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MsgShow(ex.Message, "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        /// <summary>
        /// 网络连接初始化
        /// </summary>
        /// <returns></returns>
        public bool NetworkInit()
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(mac.IPAddress, 500);
                return reply.Status == IPStatus.Success ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public void NetWorkConnectCheck()
        {
            new Task(new Action(() =>
            {
                while (true)
                {
                    try
                    {
                        Ping ping = new Ping();
                        PingReply reply = ping.Send(mac.IPAddress, 500);
                        NetworkStatus = reply.Status == IPStatus.Success ? true : false;
                    }
                    catch
                    {
                        NetworkStatus = false;
                    }
                    finally
                    {
                        Connect();
                    }
                    ShowInfo.Delay(1);
                }
            })).Start();
        }

        /// <summary>
        /// 检查网络连接
        /// </summary>
        public void Connect()
        {
            HttpInit(http_D01);
            HttpInit(http_D02);
            HttpInit(http_D03);
            HttpInit(http_Test);
        }

        /// <summary>
        /// 交互地址初始化
        /// </summary>
        /// <param name="httphelper"></param>
        private void HttpInit(HttpHelper httphelper)
        {
            try
            {
                if (!httphelper.StationID.Equals(mac.StationID[(int)mac.Product]))
                    httphelper.StationID = mac.StationID[(int)mac.Product];
                if (!httphelper.Url_Connect.Equals(GroupAddress(mac.Name_Connect)))
                    httphelper.Url_Connect = GroupAddress(mac.Name_Connect);
                if (!httphelper.Url_GetData.Equals(GroupAddress(mac.Name_GetData)))
                    httphelper.Url_GetData = GroupAddress(mac.Name_GetData);
                if (!httphelper.Url_GetClosure.Equals(mac.Name_GetClosureResult))
                    httphelper.Url_GetClosure = GroupAddress(mac.Name_GetClosureResult);
                if (!httphelper.Url_UpLoad.Equals(mac.Name_UpLoad))
                    httphelper.Url_UpLoad = GroupAddress(mac.Name_UpLoad);
            }
            catch(Exception ex)
            {
                Notify(string.Format("StationID填写出错:{0}", ex.Message), string.Format("StationID format error:{0}", ex.Message), NotifyType.Error);
            }
        }

        #endregion
    }
}

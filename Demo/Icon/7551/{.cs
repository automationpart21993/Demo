using HelperCmd;
using hWindControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Machine
{
    partial class FromMain
    {
        #region 参数

        ///// <summary>
        ///// 路由上传参数
        ///// </summary>
        //public ProductData prodata = new ProductData();
        ///// <summary>
        ///// SFC链接类初始化
        ///// </summary>
        //public SFC_FuseClient fuse = null;
        ///// <summary>
        ///// SFC链接类初始化
        ///// </summary>
        //public SFC_FuseClient link = null;
        /// <summary>
        /// http服务
        /// </summary>
        public HttpHelper D01HTTPSERVER = new HttpHelper();
        /// <summary>
        /// http服务
        /// </summary>
        public HttpHelper D02HTTPSERVER = new HttpHelper();
        /// <summary>
        /// http服务
        /// </summary>
        public HttpHelper D03HTTPSERVER = new HttpHelper();
        /// <summary>
        /// 数据服务实例化
        /// </summary>
        public DataService dataserver = new DataService();

        /// <summary>
        /// 工站状态
        /// </summary>
        public enum StationStatus
        {
            Init,
            Normal,
            Running,
            Finish,
            Stop,
            Error,
            Reset,
            Resetting,
            Pause
        }

        /// <summary>
        /// D01工站状态
        /// </summary>
        public StationStatus D01_Status = StationStatus.Init;
        /// <summary>
        /// D02工站状态
        /// </summary>
        public StationStatus D02_Status = StationStatus.Init;
        /// <summary>
        /// D03工站状态
        /// </summary>
        public StationStatus D03_Status = StationStatus.Init;

        /// <summary>
        /// D01工站状态缓存
        /// </summary>
        public StationStatus BufferStatus_D01 = StationStatus.Init;
        /// <summary>
        /// D02工站状态缓存
        /// </summary>
        public StationStatus BufferStatus_D02 = StationStatus.Init;
        /// <summary>
        /// D03工站状态缓存
        /// </summary>
        public StationStatus BufferStatus_D03 = StationStatus.Init;

        /// <summary>
        /// D01引擎线程
        /// </summary>
        public Thread D01_Activate = null;
        /// <summary>
        /// D02引擎线程
        /// </summary>
        public Thread D02_Activate = null;
        /// <summary>
        /// D03引擎线程
        /// </summary>
        public Thread D03_Activate = null;
        /// <summary>
        /// 设备引擎线程
        /// </summary>
        public Thread Machine_Activate = null;
        /// <summary>
        /// 门禁线程
        /// </summary>
        public Thread Safeguard_Activate = null;

        /// <summary>
        /// D01CT计时
        /// </summary>
        public Stopwatch D01CircleTime = new Stopwatch();
        /// <summary>
        /// D02CT计时
        /// </summary>
        public Stopwatch D02CircleTime = new Stopwatch();
        /// <summary>
        /// D03CT计时
        /// </summary>
        public Stopwatch D03CircleTime = new Stopwatch();

        /// <summary>
        /// 流程总CT计时
        /// </summary>
        public Stopwatch CircleTime = new Stopwatch();

        /// <summary>
        /// D01拉带状态
        /// </summary>
        public Boolean D01BeltStatus = false;
        /// <summary>
        /// D02拉带状态
        /// </summary>
        public Boolean D02BeltStatus = false;
        /// <summary>
        /// D03拉带状态
        /// </summary>
        public Boolean D03BeltStatus = false;
        /// <summary>
        /// 出料信号状态
        /// </summary>
        public Boolean OutReadyStatus = false;

        /// <summary>
        /// 开始按钮
        /// </summary>
        public Boolean StartButton = false;
        /// <summary>
        /// 停止按钮
        /// </summary>
        public Boolean StopButton = false;
        /// <summary>
        /// 复位按钮
        /// </summary>
        public Boolean ResetButton = false;

        /// <summary>
        /// D01空跑
        /// </summary>
        public Boolean D01Running = false;
        /// <summary>
        /// D02空跑
        /// </summary>
        public Boolean D02Running = false;
        /// <summary>
        /// D03空跑
        /// </summary>
        public Boolean D03Running = false;

        /// <summary>
        /// SFC链接状态
        /// </summary>
        public Boolean SFC_LinkStatus = false;

        /// <summary>
        /// 彩盒到位状态
        /// </summary>
        public Boolean ListenPlcae = true;

        public Boolean CCDSOCKET1 = false;
        public Boolean CCDSOCKET2 = false;

        /// <summary>
        /// SN文本
        /// </summary>
        public String TextSN = string.Empty;
        /// <summary>
        /// 重量文本
        /// </summary>
        public String TextWeight = string.Empty;

        /// <summary>
        /// D01CT文本
        /// </summary>
        public String D01ct = string.Empty;
        /// <summary>
        /// D02CT文本
        /// </summary>
        public String D02ct = string.Empty;
        /// <summary>
        /// D03CT文本
        /// </summary>
        public String D03ct = string.Empty;

        /// <summary>
        /// 检查路由的网址
        /// </summary>
        public String url_CONNECT = string.Empty;

        /// <summary>
        /// 获取数据的网址
        /// </summary>
        public String url_GETLABELDATA = string.Empty;

        /// <summary>
        /// 上传数据的网址
        /// </summary>
        public String url_UPLOADPASS = string.Empty;

        /// <summary>
        /// 标签判断的网址
        /// </summary>
        public String url_GETCLOSURE = string.Empty;

        #endregion

        /// <summary>
        /// 设备引擎函数
        /// </summary>
        public void Activateinit()
        {
            D01_Activate = new Thread(D01Engien) { IsBackground = true };
            D01_Activate.Start();
            D02_Activate = new Thread(D02Engien) { IsBackground = true };
            D02_Activate.Start();
            D03_Activate = new Thread(D03Engien) { IsBackground = true };
            D03_Activate.Start();
            Machine_Activate = new Thread(MachineEngien) { IsBackground = true };
            Machine_Activate.Start();
            Safeguard_Activate = new Thread(SafeGuard) { IsBackground = true };
            Safeguard_Activate.Start();
            new Thread(NGStation) { IsBackground = true }.Start();
        }

        #region 动作逻辑

        #region D01逻辑

        /// <summary>
        /// D01引擎
        /// </summary>
        public void D01Engien()
        {
            while (D01_Status != StationStatus.Stop && D01_Status != StationStatus.Error && D01_Status != StationStatus.Reset && D01_Status != StationStatus.Resetting && D01_Status != StationStatus.Init)
            {
                if ((D01InSignal.IO64Power(io) || (D01Running && prm.Running)) && D01_Status == StationStatus.Normal)
                {
                    D01_Status = StationStatus.Running;
                    D01Running = false;
                    OutReadySignal.IO64Power(io, false);
                    Thread.Sleep(prm.StopDelay_01);
                    if (!BeltConttol_D01(false))
                    {
                        D01Exception();
                        break;
                    }
                    D01CircleTime.Restart();
                    dataserver.StationLoc[0].StartTime = DateTime.Now;
                    dataserver.StationLoc[0].StationID = prm.StationID;
                    dataserver.StationLoc[0].PSN = ScanCode();
                    if (!prm.debugmod)
                    {
                        dataserver.StationLoc[0].GetData = GetSFCData();
                    }
                    if (D01_Status == StationStatus.Pause)
                    {
                        D01Pause();
                    }
                    if (!CylAction_Enterintercept(false))
                    {
                        D01Exception();
                        break;
                    }
                    Thread.Sleep(300);
                    D01_Status = StationStatus.Finish;
                }
                else if (D01_Status == StationStatus.Finish && D02_Status == StationStatus.Normal)
                {
                    if (!BeltConttol_D01(true))
                    {
                        D01Exception();
                        break;
                    }
                    string error = string.Empty;
                    D01CircleTime.Stop();
                    dataserver.StationLoc[0].CircleTime = dataserver.StationLoc[0].D01CircleTime = D01CircleTime.ElapsedMilliseconds;
                    D01ct = dataserver.StationLoc[0].CircleTime / 1000 + "Sce";
                    if (!dataserver.DataMove(0, "入料段(D01)", "检测段(D02)", out error))
                        Notify(error, error, false);
                    else
                        Notify(error, error);
                    Thread.Sleep(prm.CheckStatus_01);
                    if (D01InSignal.IO64Power(io))
                    {
                        Notify("入料段彩盒移动失败!", "Box move fail in D01!", false);
                        D01Exception();
                        break;
                    }
                    if (!CylAction_Enterintercept(true))
                    {
                        D01Exception();
                        break;
                    }
                    D01_Status = StationStatus.Normal;
                    OutReadySignal.IO64Power(io, true);
                    if (prm.Running)
                    {
                        Thread.Sleep(1000);
                        D01Running = true;
                    }
                }
                else if (D01_Status == StationStatus.Pause)
                {
                    D01Pause();
                }
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// D01异常处理
        /// </summary>
        public void D01Exception()
        {
            D01Running = false;
            dataserver.StationLoc[0] = new DataBit();
            D01_Status = StationStatus.Error;
            OutReadySignal.IO64Power(io, false);
            D01Belt.IO64Power(io, false);
            if (!OutBuzzer.IsOn(io))
            {
                OutBuzzer.IO64Power(io, true);
            }
            OutGreenLamp.IO64Power(io, false);
            OutYerrowLamp.IO64Power(io, true);
            OutRedLamp.IO64Power(io, false);
            Notify("入料段异常！", "D01 warning", false);
        }

        /// <summary>
        /// D01停止
        /// </summary>
        public void D01Stop()
        {
            D01Running = false;
            dataserver.StationLoc[0] = new DataBit();
            D01_Status = StationStatus.Stop;
            OutReadySignal.IO64Power(io, false);
            try
            {
                if (D01_Activate.IsAlive)
                {
                    D01_Activate.Abort();
                }
            }
            catch
            {
                if (D01_Activate.IsAlive)
                {
                    D01_Activate.Abort();
                }
            }
            D01Belt.IO64Power(io, false);
            OutBuzzer.IO64Power(io, false);
            OutGreenLamp.IO64Power(io, false);
            OutYerrowLamp.IO64Power(io, false);
            OutRedLamp.IO64Power(io, true);
            Notify("入料段停止动作!", "D01 Stop!", false);
        }

        /// <summary>
        /// D01复位
        /// </summary>
        /// <returns></returns>
        public bool D01Reset()
        {
            if (D01_Status == StationStatus.Stop || D01_Status == StationStatus.Error || D01_Status == StationStatus.Init)
            {
                D01Running = false;
                if (D01InSignal.IO64Power(io))
                {
                    Notify("彩盒未取出", "The box is not exit", false);
                    D01Exception();
                    return false;
                }
                OutReadySignal.IO64Power(io, false);
                //OutBuzzer.IO64Power(io, false);
                //OutGreenLamp.IO64Power(io, false);
                //OutYerrowLamp.IO64Power(io, true);
                //OutRedLamp.IO64Power(io, true);
                dataserver.StationLoc[0] = new DataBit();
                Notify("入料段开始复位.", "D01 to reset.");
                D01_Status = StationStatus.Resetting;
                if (!CylAction_Enterintercept(true))
                {
                    D01Exception();
                    return false;
                }
                if (!CylAction_Enterintercept(false))
                {
                    D01Exception();
                    return false;
                }
                //OutGreenLamp.IO64Power(io, true);
                //OutYerrowLamp.IO64Power(io, true);
                //OutRedLamp.IO64Power(io, false);
                D01_Status = StationStatus.Reset;
                Notify("入料段复位成功.", "D01 reset done");
                return true;
            }
            else if (D01_Status == StationStatus.Resetting)
            {
                Notify("入料段复位中......", "D01 resetting......", false);
                return false;
            }
            else
            {
                Notify("入料段状态正常!", "D01 status Normal!", false);
                return false;
            }
        }

        /// <summary>
        /// D01启动
        /// </summary>
        /// <returns></returns>
        public bool D01Start()
        {
            if (D01_Status == StationStatus.Reset)
            {
                dataserver.StationLoc[0] = new DataBit();
                if (!CylAction_Enterintercept(true))
                {
                    D01Exception();
                    return false;
                }
                D01_Status = StationStatus.Normal;
                if (!BeltConttol_D01(true))
                {
                    D01Exception();
                    return false;
                }
                D01_Activate = new Thread(D01Engien) { IsBackground = true };
                D01_Activate.Start();
                OutReadySignal.IO64Power(io, true);
                Notify("入料段启动成功!", "D01 start");
                if (prm.Running)
                {
                    D01Running = true;
                }
                return true;
            }
            else if (D01_Status == StationStatus.Pause && (!InSafeGuard.IO64Power(io) || !prm.SafeGuardEnable))
            {
                D01_Status = BufferStatus_D01;
                if (!BeltConttol_D01(D01BeltStatus))
                {
                    D01Exception();
                    return false;
                }
                OutReadySignal.IO64Power(io, OutReadyStatus);
                return true;
            }
            else
            {
                Notify("入料段状态错误,禁止启动!", "D01 status is wrong!", false);
                return false;
            }
        }

        /// <summary>
        /// D01暂停
        /// </summary>
        public void D01Pause()
        {
            D01BeltStatus = D01Belt.IsOn(io);
            D01Belt.IO64Power(io, false);
            OutReadyStatus = OutReadySignal.IsOn(io);
            OutReadySignal.IO64Power(io, false);
            while (D01_Status == StationStatus.Pause)
            {
                Thread.Sleep(1);
            }
        }

        #endregion

        #region D02逻辑

        /// <summary>
        /// D02引擎
        /// </summary>
        public void D02Engien()
        {
            while (D02_Status != StationStatus.Stop && D02_Status != StationStatus.Error && D02_Status != StationStatus.Reset && D02_Status != StationStatus.Resetting && D02_Status != StationStatus.Init)
            {
                if ((D02InSignal.IO64Power(io) || (D02Running && prm.Running)) && D02_Status == StationStatus.Normal)
                {
                    D02_Status = StationStatus.Running;
                    Thread.Sleep(prm.StopDelay_02);
                    if (!BeltConttol_D02(false))
                    {
                        D02Exception();
                        break;
                    }
                    D02CircleTime.Restart();

                    if (D02_Status == StationStatus.Pause)
                    {
                        D02Pause();
                    }
                    if (!CylAction_Weigh(true))
                    {
                        D02Exception();
                        break;
                    }

                    if (D02_Status == StationStatus.Pause)
                    {
                        D02Pause();
                    }
                    if (!CylAction_Weighintercept(false))
                    {
                        D02Exception();
                        break;
                    }

                    if (!prm.debugmod)
                    {
                        if (dataserver.StationLoc[1].GetData)
                        {
                            if (ColorBoxDetection())
                            {
                                dataserver.StationLoc[1].Result = "PASS";
                            }
                            CCDSOCKET1 = false;
                        }
                    }
                    else
                    {

                        if (prm.TestCCD)
                        {
                            CCDTest();
                        }
                        else
                        {
                            Thread.Sleep(Convert.ToInt32(prm.simulatedtime * 1000));
                        }
                        dataserver.StationLoc[1].Weight = ScalesCode();
                        if (dataserver.StationLoc[1].Weight.ToUpper().Contains("FAIL"))
                        {
                            dataserver.StationLoc[1].Msg = messages("称重异常:" + dataserver.StationLoc[1].Weight, "Weigh error:" + dataserver.StationLoc[1].Weight);
                        }
                        else
                        {
                            dataserver.StationLoc[1].Weight_Check = true;
                        }
                    }

                    if (D02_Status == StationStatus.Pause)
                    {
                        D02Pause();
                    }
                    if (!CylAction_Weigh(false))
                    {
                        D02Exception();
                        break;
                    }

                    D02_Status = StationStatus.Finish;
                }
                else if (D02_Status == StationStatus.Finish && D03_Status == StationStatus.Normal)
                {
                    if (!BeltConttol_D02(true))
                    {
                        D02Exception();
                        break;
                    }
                    string error = string.Empty;
                    D02CircleTime.Stop();
                    dataserver.StationLoc[1].D02CircleTime = D02CircleTime.ElapsedMilliseconds;
                    dataserver.StationLoc[1].CircleTime += D02CircleTime.ElapsedMilliseconds;
                    D02ct = dataserver.StationLoc[1].CircleTime / 1000 + "Sce";
                    if (!dataserver.DataMove(1, "检测段(D02)", "翻转段(D03)", out error))
                        Notify(error, error, false);
                    else
                        Notify(error, error);
                    Thread.Sleep(prm.CheckStatus_02);
                    if (D02InSignal.IO64Power(io))
                    {
                        Notify("检测段彩盒移动失败!", "Box move fail in D02!", false);
                        D02Exception();
                        break;
                    }
                    if (!CylAction_Weighintercept(true))
                    {
                        D02Exception();
                        break;
                    }
                    D02_Status = StationStatus.Normal;
                    if (prm.Running)
                    {
                        Thread.Sleep(1000);
                        D02Running = true;
                    }
                }
                else if (D02_Status == StationStatus.Pause)
                {
                    D02Pause();
                }
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// D02异常处理
        /// </summary>
        public void D02Exception()
        {
            D02Running = false;
            dataserver.StationLoc[1] = new DataBit();
            D02_Status = StationStatus.Error;
            D02Belt.IO64Power(io, false);
            if (!OutBuzzer.IsOn(io))
            {
                OutBuzzer.IO64Power(io, true);
            }
            OutGreenLamp.IO64Power(io, false);
            OutYerrowLamp.IO64Power(io, true);
            OutRedLamp.IO64Power(io, false);
            Notify("检测段异常！", "D02 warning", false);
        }

        /// <summary>
        /// D02停止
        /// </summary>
        public void D02Stop()
        {
            D02Running = false;
            dataserver.StationLoc[1] = new DataBit();
            D02_Status = StationStatus.Stop;
            try
            {
                if (D02_Activate.IsAlive)
                {
                    D02_Activate.Abort();
                }
            }
            catch
            {
                if (D02_Activate.IsAlive)
                {
                    D02_Activate.Abort();
                }
            }
            D02Belt.IO64Power(io, false);
            OutBuzzer.IO64Power(io, false);
            OutGreenLamp.IO64Power(io, false);
            OutYerrowLamp.IO64Power(io, false);
            OutRedLamp.IO64Power(io, true);
            CCDSOCKET1 = false;
            Notify("检测段停止动作!", "D02 stop", false);
        }

        /// <summary>
        /// D02复位
        /// </summary>
        /// <returns></returns>
        public bool D02Reset()
        {
            D02Running = false;
            if (D02_Status == StationStatus.Stop || D02_Status == StationStatus.Error || D02_Status == StationStatus.Init)
            {
                if (WeighCly.IsOn(io))
                {
                    CylAction_Weigh(false);
                }
                if (D02InSignal.IO64Power(io))
                {
                    Notify("彩盒未取出", "The box is not exit", false);
                    D02Exception();
                    return false;
                }
                //OutBuzzer.IO64Power(io, false);
                //OutGreenLamp.IO64Power(io, false);
                //OutYerrowLamp.IO64Power(io, true);
                //OutRedLamp.IO64Power(io, true);
                dataserver.StationLoc[1] = new DataBit();
                Notify("检测段开始复位.", "D02 to reset.");
                D02_Status = StationStatus.Resetting;

                if (!CylAction_Weighintercept(true))
                {
                    D02Exception();
                    return false;
                }
                if (!CylAction_Weighintercept(false))
                {
                    D02Exception();
                    return false;
                }
                if (!CylAction_Weigh(true))
                {
                    D02Exception();
                    return false;
                }
                if (!CylAction_Weigh(false))
                {
                    D02Exception();
                    return false;
                }

                //OutGreenLamp.IO64Power(io, true);
                //OutYerrowLamp.IO64Power(io, true);
                //OutRedLamp.IO64Power(io, false);
                D02_Status = StationStatus.Reset;
                Notify("检测段复位成功.", "D02 reset done.");
                return true;
            }
            else if (D02_Status == StationStatus.Resetting)
            {
                Notify("检测段复位中......", "D02 resetting", false);
                return false;
            }
            else
            {
                Notify("检测段状态正常!", "D01 status Normal!", false); ;
                return false;
            }
        }

        /// <summary>
        /// D02启动
        /// </summary>
        /// <returns></returns>
        public bool D02Start()
        {
            if (D02_Status == StationStatus.Reset)
            {
                dataserver.StationLoc[1] = new DataBit();
                if (!CylAction_Weighintercept(true))
                {
                    D02Exception();
                    return false;
                }
                D02_Status = StationStatus.Normal;
                if (!BeltConttol_D02(true))
                {
                    D02Exception();
                    return false;
                }
                D02_Activate = new Thread(D02Engien) { IsBackground = true };
                D02_Activate.Start();
                Notify("检测段启动成功!", "D03 start");
                if (prm.Running)
                {
                    D02Running = true;
                }
                return true;
            }
            else if (D02_Status == StationStatus.Pause && (!InSafeGuard.IO64Power(io) || !prm.SafeGuardEnable))
            {
                D02_Status = BufferStatus_D02;
                if (!BeltConttol_D02(D02BeltStatus))
                {
                    D02Exception();
                    return false;
                }
                return true;
            }
            else
            {
                Notify("检测段状态错误,禁止启动!", "D02 status wrong!", false);
                return false;
            }
        }

        /// <summary>
        /// D02暂停
        /// </summary>
        public void D02Pause()
        {
            D02BeltStatus = D02Belt.IsOn(io);
            D02Belt.IO64Power(io, false);
            while (D02_Status == StationStatus.Pause)
            {
                Thread.Sleep(1);
            }
        }

        #endregion

        #region D03逻辑

        /// <summary>
        /// D03引擎
        /// </summary>
        public void D03Engien()
        {
            while (D03_Status != StationStatus.Stop && D03_Status != StationStatus.Error && D03_Status != StationStatus.Reset && D03_Status != StationStatus.Resetting && D03_Status != StationStatus.Init)
            {
                if ((D03InSignal.IO64Power(io) || (D02Running && prm.Running)) && D03_Status == StationStatus.Normal)
                {
                    D03_Status = StationStatus.Running;
                    Thread.Sleep(prm.StopDelay_03);
                    if (!BeltConttol_D03(false))
                    {
                        D03Exception();
                        break;
                    }
                    D03CircleTime.Restart();
                    TextSN = dataserver.StationLoc[2].PSN;
                    TextWeight = dataserver.StationLoc[2].Weight;
                    #region 准备动作
                    if (D03_Status == StationStatus.Pause)
                    {
                        D03Pause();
                    }
                    if (!CylAction_Clamp(false))
                    {
                        D03Exception();
                        break;
                    }

                    if (D03_Status == StationStatus.Pause)
                    {
                        D03Pause();
                    }
                    if (!CylAction_SideAdjust(true))
                    {
                        D03Exception();
                        break;
                    }

                    if (D03_Status == StationStatus.Pause)
                    {
                        D03Pause();
                    }
                    if (!CylAction_SideAdjust(false))
                    {
                        D03Exception();
                        break;
                    }

                    if (D03_Status == StationStatus.Pause)
                    {
                        D03Pause();
                    }
                    if (!CylAction_Lifter(true))
                    {
                        LifterCly.IO64Power(io, false);
                        D03Exception();
                        break;
                    }

                    if (D03_Status == StationStatus.Pause)
                    {
                        D03Pause();
                    }
                    if (!CylAction_Forward(true))
                    {
                        ForwardCly.IO64Power(io, false);
                        D03Exception();
                        break;
                    }

                    if (D03_Status == StationStatus.Pause)
                    {
                        D03Pause();
                    }
                    if (!CylAction_Clamp(true))
                    {
                        ForwardCly.IO64Power(io, false);
                        D03Exception();
                        break;
                    }

                    if (D03_Status == StationStatus.Pause)
                    {
                        D03Pause();
                    }
                    if (!CylAction_Lifter(false))
                    {
                        D03Exception();
                        break;
                    }
                    #endregion

                    bool nextstaion = false;
                    if (prm.debugmod)
                    {
                        if (!prm.TestWeigh)
                        {
                            dataserver.StationLoc[2].Result = prm.ActionMod.ToString();
                        }
                        else
                        {
                            if (dataserver.StationLoc[2].Weight_Check)
                                dataserver.StationLoc[2].Result = "PASS";
                        }
                    }
                    if (prm.Running)
                    {
                        dataserver.StationLoc[2].Result = new Random().Next(0, 2) > 1 ? "PASS" : "FAIL";
                    }

                    if (!prm.debugmod && !prm.Running)
                    {
                        nextstaion = ThroughStation();
                    }

                ClyAction:
                    #region PASS
                    if (dataserver.StationLoc[2].Result.Equals("PASS"))
                    {
                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }

                        if (!RotateCly.IsOn(io))
                        {
                            if (!CylAction_Rotate(true))
                            {
                                RotateCly.IO64Power(io, false);
                                D03Exception();
                                break;
                            }
                        }
                        else
                        {
                            if (!CylAction_Rotate(false))
                            {
                                RotateCly.IO64Power(io, true);
                                D03Exception();
                                break;
                            }
                        }

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        if (!CylAction_Lifter(true))
                        {
                            LifterCly.IO64Power(io, false);
                            D03Exception();
                            break;
                        }

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        if (!CylAction_Clamp(false))
                        {
                            D03Exception();
                            break;
                        }

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        if (!CylAction_SideAdjust(true))
                        {
                            D03Exception();
                            break;
                        }

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        if (!CylAction_SideAdjust(false))
                        {
                            D03Exception();
                            break;
                        }


                        Thread ReadSideModle = new Thread(new ThreadStart(() =>
                        {
                            if (!prm.debugmod)
                            {
                                if (dataserver.StationLoc[2].NeedCheck)
                                {
                                    if (!SideLabelDetection())
                                    {
                                        dataserver.StationLoc[2].Result = "FAIL";
                                    }
                                    CCDSOCKET2 = false;
                                }
                                else
                                {
                                    dataserver.StationLoc[2].PhoneType_Check = true;
                                }
                            }
                            else
                            {
                                if (prm.TestBOBlabel)
                                {
                                    BOBTest();
                                }
                            }
                        })) { IsBackground = true };
                        if (!nextstaion)
                        {
                            ReadSideModle.Start();
                        }

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        if (!CylAction_Forward(false))
                        {
                            D03Exception();
                            break;
                        }

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        if (!CylAction_Lifter(false))
                        {
                            D03Exception();
                            break;
                        }

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        ClampCly.IO64Power(io, true);
                        while (ReadSideModle.IsAlive)
                        {
                            Thread.Sleep(1);
                        }
                        if (!prm.debugmod)
                        {
                            if (nextstaion) goto skipaction;
                            if (dataserver.StationLoc[2].Result == "FAIL") goto ClyAction;
                            dataserver.StationLoc[2].EndTime = DateTime.Now;
                            string response = string.Empty;
                            try
                            {
                                if (!D03HTTPSERVER.UploadPass(url_UPLOADPASS, dataserver.StationLoc[2].StationID, dataserver.StationLoc[2].PSN, SwitchData(), out response))
                                {
                                    Notify("数据上传失败:" + response, "Data upload failed:" + response, false);
                                    dataserver.StationLoc[2].Msg = messages("数据上传失败:" + response, "SFCData upload failed:" + response);
                                    dataserver.StationLoc[2].Result = "FAIL";
                                    goto ClyAction;
                                }
                                if (D03HTTPSERVER.CheckRoute(url_CONNECT, dataserver.StationLoc[2].StationID, dataserver.StationLoc[2].PSN, out response))
                                {
                                    Notify("推路由失败:产品未过站", "Data upload failed:this product is not pass", false);
                                    dataserver.StationLoc[2].Msg = messages("推路由失败:产品未过站", "Data upload failed:this product is not pass");
                                    dataserver.StationLoc[2].Result = "FAIL";
                                    goto ClyAction;
                                }
                                Notify("推路由成功:产品已过站", "Data upload done:this product is pass");
                                dataserver.StationLoc[2].Through_Check = true;

                            }
                            catch (Exception ex)
                            {
                                Notify(ex.Message, ex.Message);
                                dataserver.StationLoc[2].Result = dataserver.StationLoc[2].Result = "FAIL";
                                goto ClyAction;
                            }
                        }
                        else
                        {
                            dataserver.StationLoc[2].EndTime = DateTime.Now;
                        }
                        cfg.labPassCount++;
                    skipaction:
                        if (!prm.debugmod)
                        {
                            while (!ListenPlcae)
                            {
                                Thread.Sleep(1);
                            }
                            SKUChangeSignal.IO64Power(io, dataserver.StationLoc[2].SkuChange);
                            OutNotDecals.IO64Power(io, dataserver.StationLoc[2].NotDecals);
                            OutLargeLabel.IO64Power(io, dataserver.StationLoc[2].LargeLabel);
                            OutPassSignal.IO64Power(io, true);
                        }
                        else
                        {
                            if (prm.Communication)
                            {
                                while (!ListenPlcae)
                                {
                                    Thread.Sleep(1);
                                }
                                SKUChangeSignal.IO64Power(io, prm.SKUChange_Debug);
                                OutNotDecals.IO64Power(io, prm.NotPaste_Debug);
                                OutLargeLabel.IO64Power(io, prm.LargeLabel_Debug);
                                OutPassSignal.IO64Power(io, true);
                            }
                        }
                    }
                    #endregion
                    #region NG
                    else
                    {
                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        if (!CylAction_NGCarry(true))
                        {
                            NGCarryCly.IO64Power(io, false);
                            D03Exception();
                            break;
                        }

                        bool NGoccupy = false;
                        while (SecondNGBoxSignal.IO64Power(io))
                        {
                            if (!NGoccupy) { Notify("NG工位尚有彩盒未取出！", "NG box is not exit！", false); NGoccupy = true; }
                            while (SecondNGBoxSignal.IO64Power(io))
                            {
                                OutBuzzer.IO64Power(io, true);
                                Thread.Sleep(100);
                                OutBuzzer.IO64Power(io, false);
                                Thread.Sleep(300);
                            }
                        }

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        if (!CylAction_Lifter(true))
                        {
                            LifterCly.IO64Power(io, false);
                            D03Exception();
                            break;
                        }

                        new Thread(new ThreadStart(() =>
                        {
                            new MyMessagesBox(dataserver.StationLoc[2].Msg).ShowDialog();
                        })).Start();

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        if (!CylAction_Clamp(false))
                        {
                            D03Exception();
                            break;
                        }

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        if (!CylAction_Forward(false))
                        {
                            D03Exception();
                            break;
                        }

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        if (!CylAction_Lifter(false))
                        {
                            D03Exception();
                            break;
                        }

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        ClampCly.IO64Power(io, true);

                        if (D03_Status == StationStatus.Pause)
                        {
                            D03Pause();
                        }
                        if (!CylAction_NGCarry(false))
                        {
                            D03Exception();
                            break;
                        }

                        cfg.labNgCount++;
                        dataserver.StationLoc[2].EndTime = DateTime.Now;
                    }
                    #endregion

                    D03CircleTime.Stop();
                    dataserver.StationLoc[2].D03CircleTime = D03CircleTime.ElapsedMilliseconds;
                    dataserver.StationLoc[2].CircleTime += D03CircleTime.ElapsedMilliseconds;
                    D03ct = dataserver.StationLoc[2].CircleTime / 1000 + "Sce";
                    if (dataserver.StationLoc[2].DataSave(@"D:\DeviceData\生产数据"))
                    {
                        Notify("生产数据保存成功!", "Production data is saved!");
                    }
                    else
                    {
                        Notify("生产数据保存失败!", "Production data save fail!");
                    }
                    watch = CircleTime.Elapsed.TotalSeconds.ToString("0.0");
                    CircleTime.Restart();
                    D03_Status = StationStatus.Finish;
                }
                else if (D03_Status == StationStatus.Finish)
                {
                    // && (InReadySignal.IO64Power(io) || prm.debugmod)
                    if (dataserver.StationLoc[2].Result.Equals("PASS"))
                    {
                        if (!prm.debugmod)
                        {
                            while (!InReadySignal.IO64Power(io) || !ListenPlcae)
                            {
                                Thread.Sleep(1);
                            }
                            ListenPlcae = false;
                        }
                        else
                        {
                            while ((!InReadySignal.IO64Power(io) || !ListenPlcae) && prm.Communication)
                            {
                                Thread.Sleep(1);
                            }
                            if (prm.Communication)
                            {
                                ListenPlcae = false;
                            }
                        }
                    }
                    SKUChangeSignal.IO64Power(io, false);
                    OutNotDecals.IO64Power(io, false);
                    OutLargeLabel.IO64Power(io, false);
                    OutPassSignal.IO64Power(io, false);
                    if (!BeltConttol_D03(true))
                    {
                        D03Exception();
                        break;
                    }
                    dataserver.StationLoc[2] = new DataBit();
                    Thread.Sleep(prm.CheckStatus_03);
                    if (D03InSignal.IO64Power(io))
                    {
                        Notify("彩盒移动失败!", "Box move fail in D03!", false);
                        D03Exception();
                        break;
                    }
                    if (!prm.debugmod)
                    {
                        new Thread(ListenInPlaceSignal) { IsBackground = true }.Start();
                    }
                    else
                    {
                        if (prm.Communication)
                        {
                            new Thread(ListenInPlaceSignal) { IsBackground = true }.Start();
                        }
                    }
                    D03_Status = StationStatus.Normal;
                    if (prm.Running)
                    {
                        Thread.Sleep(1000);
                        D03Running = true;
                    }
                }
                else if (D03_Status == StationStatus.Pause)
                {
                    D03Pause();
                }
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// D03异常处理
        /// </summary>
        public void D03Exception()
        {
            D03Running = false;
            dataserver.StationLoc[2] = new DataBit();
            D03_Status = StationStatus.Error;
            OutPassSignal.IO64Power(io, false);
            D03Belt.IO64Power(io, false);
            if (!OutBuzzer.IsOn(io))
            {
                OutBuzzer.IO64Power(io, true);
            }
            OutGreenLamp.IO64Power(io, false);
            OutYerrowLamp.IO64Power(io, true);
            OutRedLamp.IO64Power(io, false);
            Notify("出料段异常！", "D03 warning", false);
        }

        /// <summary>
        /// D03停止
        /// </summary>
        public void D03Stop()
        {
            D03Running = false;
            dataserver.StationLoc[2] = new DataBit();
            D03_Status = StationStatus.Stop;
            OutPassSignal.IO64Power(io, false);
            try
            {
                if (D03_Activate.IsAlive)
                {
                    D03_Activate.Abort();
                }
            }
            catch
            {
                if (D03_Activate.IsAlive)
                {
                    D03_Activate.Abort();
                }
            }
            D03Belt.IO64Power(io, false);
            OutBuzzer.IO64Power(io, false);
            OutGreenLamp.IO64Power(io, false);
            OutYerrowLamp.IO64Power(io, false);
            OutRedLamp.IO64Power(io, true);
            CCDSOCKET2 = false;
            Notify("出料段停止动作!", "D03 stop", false);
        }

        /// <summary>
        /// D03复位
        /// </summary>
        /// <returns></returns>
        public bool D03Reset()
        {
            if (D03_Status == StationStatus.Stop || D03_Status == StationStatus.Error || D03_Status == StationStatus.Init)
            {
                D03Running = false;
                if (D03InSignal.IO64Power(io))
                {
                    Notify("彩盒未取出", "The box is not exit", false);
                    D03Exception();
                    return false;
                }
                OutPassSignal.IO64Power(io, false);
                dataserver.StationLoc[2] = new DataBit();
                Notify("出料段开始复位.", "D03 to reset.");
                D03_Status = StationStatus.Resetting;

                if (!CylAction_SideAdjust(true))
                {
                    D03Exception();
                    return false;
                }
                if (!CylAction_SideAdjust(false))
                {
                    D03Exception();
                    return false;
                }
                if (!CylAction_Lifter(false))
                {
                    D03Exception();
                    return false;
                }
                if (!CylAction_Forward(false))
                {
                    D03Exception();
                    return false;
                }
                if (!CylAction_Clamp(true))
                {
                    D03Exception();
                    return false;
                }
                if (!CylAction_Clamp(false))
                {
                    D03Exception();
                    return false;
                }
                if (!CylAction_Rotate(true))
                {
                    D03Exception();
                    return false;
                }
                if (!CylAction_Rotate(false))
                {
                    D03Exception();
                    return false;
                }
                if (!CylAction_NGCarry(false))
                {
                    D03Exception();
                    return false;
                }

                //OutGreenLamp.IO64Power(io, true);
                //OutYerrowLamp.IO64Power(io, true);
                //OutRedLamp.IO64Power(io, false);
                D03_Status = StationStatus.Reset;
                Notify("出料段复位成功.", "D03 reset done.");
                return true;
            }
            else if (D03_Status == StationStatus.Resetting)
            {
                Notify("出料段复位中......", "D03 resetting", false);
                return false;
            }
            else
            {
                Notify("出料段状态正常!", "D01 status Normal!", false); ;
                return false;
            }
        }

        /// <summary>
        /// D03启动
        /// </summary>
        /// <returns></returns>
        public bool D03Start()
        {
            if (D03_Status == StationStatus.Reset)
            {
                dataserver.StationLoc[2] = new DataBit();
                ClampCly.IO64Power(io, true);
                D03_Status = StationStatus.Normal;
                OutPassSignal.IO64Power(io, false);
                if (!BeltConttol_D03(true))
                {
                    D03Exception();
                    return false;
                }
                D03_Activate = new Thread(D03Engien) { IsBackground = true };
                D03_Activate.Start();
                Notify("出料段启动成功!", "D03 start!");
                ListenPlcae = true;
                if (prm.Running)
                {
                    D03Running = true;
                }
                return true;
            }
            else if (D03_Status == StationStatus.Pause && (!InSafeGuard.IO64Power(io) || !prm.SafeGuardEnable))
            {
                D03_Status = BufferStatus_D03;
                if (!BeltConttol_D03(D03BeltStatus))
                {
                    D03Exception();
                    return false;
                }
                return true;
            }
            else
            {
                Notify("出料段状态错误,禁止启动!", "D03 status wrong!", false);
                return false;
            }
        }

        /// <summary>
        /// D03暂停
        /// </summary>
        public void D03Pause()
        {
            D03BeltStatus = D03Belt.IsOn(io);
            D03Belt.IO64Power(io, false);
            while (D03_Status == StationStatus.Pause)
            {
                Thread.Sleep(1);
            }
        }

        #endregion

        #endregion

        #region 调用函数

        /// <summary>
        /// 扫码动作
        /// </summary>
        /// <returns></returns>
        public string ScanCode()
        {
            string error = string.Empty;
            string results = string.Empty;
            try
            {
                if (ScannerTrigger())//扫码
                {
                    results = ScannerResults;
                    if (string.IsNullOrEmpty(results))
                    {
                        if (prm.LanguageSelect == RunParam.languageselect.ZH)
                            return "FAIL:PSN数据为空";
                        else
                            return "FAIL:PSN is empty";
                    }
                    if (!prm.debugmod)
                    {
                        if (!D01HTTPSERVER.CheckRoute(url_CONNECT, prm.StationID, results, out error))//核对该SN的工站信息
                        {
                            return error;
                        }
                    }
                    return results;
                }
                else
                {
                    if (prm.LanguageSelect == RunParam.languageselect.ZH)
                        return "FAIL:扫码枪触发异常";
                    else
                        return "FAIL:Scanner gun trigger fail";
                }

            }
            catch
            {
                if (prm.LanguageSelect == RunParam.languageselect.ZH)
                    return "FAIL:扫码枪触发异常";
                else
                    return "FAIL:Scanner gun trigger fail";
            }
        }

        /// <summary>
        /// 称重动作
        /// </summary>
        /// <param name="pid">DSN</param>
        /// <returns></returns>
        public string ScalesCode(Boolean SKUChange = false)
        {
            string error = string.Empty;
            string results = string.Empty;
            double weight = 0.0;
            try
            {
                if (ScalesTrigger())//称重
                {
                    results = ScalesResults.Replace("\r\n", "").Replace("g", "").Replace(" ", "");
                    if (!prm.debugmod)
                    {
                        weight = Convert.ToDouble(results);

                        if (prm.WeighScheme == RunParam.weighscheme.First)
                        {
                            #region 第一套称重方案

                            if (SKUChange)
                            {
                                wc.WeighCount = 0;
                                wc.StandardWeight = weight;
                                wc.Save("WeighConfig", wc);
                            }
                            else
                            {
                                if (wc.StandardWeight <= 0)
                                {
                                    wc.WeighCount = 0;
                                    wc.StandardWeight = weight;
                                    wc.Save("WeighConfig", wc);
                                }
                            }
                            if (weight > wc.StandardWeight)
                            {
                                if (wc.WeighCount < 10)
                                {
                                    if (weight - wc.StandardWeight > prm.UpperLimit_First)
                                    {
                                        if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                            return "FAIL:" + results + "克重量超出设定范围";
                                        else
                                            return "FAIL:" + results + "g The weight is beyond the set range";
                                    }
                                    else
                                    {
                                        if (weight - wc.StandardWeight > prm.UpperLimit_Second)
                                        {
                                            wc.WeighCount = 0;
                                            wc.Save("WeighConfig", wc);
                                        }
                                        else
                                        {
                                            wc.WeighCount++;
                                            wc.Save("WeighConfig", wc);
                                        }
                                    }
                                }
                                else
                                {
                                    if (weight - wc.StandardWeight > prm.UpperLimit_Second)
                                    {
                                        if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                            return "FAIL:" + results + "克重量超出设定范围";
                                        else
                                            return "FAIL:" + results + "g The weight is beyond the set range";
                                    }
                                }
                            }
                            else
                            {
                                if (wc.WeighCount < 10)
                                {
                                    if (wc.StandardWeight - weight > prm.LowerLimit_First)
                                    {
                                        if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                            return "FAIL:" + results + "克重量超出设定范围";
                                        else
                                            return "FAIL:" + results + "g The weight is beyond the set range";
                                    }
                                    else
                                    {
                                        if (wc.StandardWeight - weight > prm.LowerLimit_Second)
                                        {
                                            wc.WeighCount = 0;
                                            wc.Save("WeighConfig", wc);
                                        }
                                        else
                                        {
                                            wc.WeighCount++;
                                            wc.Save("WeighConfig", wc);
                                        }
                                    }
                                }
                                else
                                {
                                    if (wc.StandardWeight - weight > prm.LowerLimit_Second)
                                    {
                                        if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                            return "FAIL:" + results + "克重量超出设定范围";
                                        else
                                            return "FAIL:" + results + "g The weight is beyond the set range";
                                    }
                                }
                            }

                            #endregion
                        }
                        else if (prm.WeighScheme == RunParam.weighscheme.Second)
                        {
                            #region  第二套称重方案

                            if (SKUChange)
                            {
                                wc.BoxCount = 0;
                                wc.Save("WeighConfig", wc);
                            }
                            else
                            {
                                if (wc.StandardWeight <= 0)
                                {
                                    wc.BoxCount = 0;
                                    wc.StandardWeight = weight;
                                    wc.Save("WeighConfig", wc);
                                }
                            }
                            if (wc.BoxCount < 10)
                            {
                                wc.WeightAccumuiation += weight;
                                wc.BoxCount++;
                                wc.Save("WeighConfig", wc);
                            }
                            else
                            {
                                if (wc.BoxCount == 10)
                                {
                                    wc.StandardWeight = wc.WeightAccumuiation / 10;
                                    wc.WeighCount = 0;
                                    wc.Save("WeighConfig", wc);
                                }
                                if (weight > wc.StandardWeight)
                                {
                                    if (wc.WeighCount < 10)
                                    {
                                        if (weight - wc.StandardWeight > prm.UpperLimit_First)
                                        {
                                            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                                return "FAIL:" + results + "克重量超出设定范围";
                                            else
                                                return "FAIL:" + results + "g The weight is beyond the set range";
                                        }
                                        else
                                        {
                                            if (weight - wc.StandardWeight > prm.UpperLimit_Second)
                                            {
                                                wc.WeighCount = 0;
                                                wc.Save("WeighConfig", wc);
                                            }
                                            else
                                            {
                                                wc.WeighCount++;
                                                wc.Save("WeighConfig", wc);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (weight - wc.StandardWeight > prm.UpperLimit_Second)
                                        {
                                            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                                return "FAIL:" + results + "克重量超出设定范围";
                                            else
                                                return "FAIL:" + results + "g The weight is beyond the set range";
                                        }
                                    }
                                }
                                else
                                {
                                    if (wc.WeighCount < 10)
                                    {
                                        if (wc.StandardWeight - weight > prm.LowerLimit_First)
                                        {
                                            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                                return "FAIL:" + results + "克重量超出设定范围";
                                            else
                                                return "FAIL:" + results + "g The weight is beyond the set range";
                                        }
                                        else
                                        {
                                            if (wc.StandardWeight - weight > prm.LowerLimit_Second)
                                            {
                                                wc.WeighCount = 0;
                                                wc.Save("WeighConfig", wc);
                                            }
                                            else
                                            {
                                                wc.WeighCount++;
                                                wc.Save("WeighConfig", wc);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (wc.StandardWeight - weight > prm.LowerLimit_Second)
                                        {
                                            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                                return "FAIL:" + results + "克重量超出设定范围";
                                            else
                                                return "FAIL:" + results + "g The weight is beyond the set range";
                                        }
                                    }
                                }
                            }

                            #endregion
                        }
                        else if (prm.WeighScheme == RunParam.weighscheme.Third)
                        {
                            #region 第三套称重方案

                            if (SKUChange)
                            {
                                wc.BoxCount = 0;
                                wc.StandardWeight = weight;
                                wc.Save("WeighConfig", wc);
                            }
                            else
                            {
                                if (wc.StandardWeight <= 0)
                                {
                                    wc.BoxCount = 0;
                                    wc.StandardWeight = weight;
                                    wc.Save("WeighConfig", wc);
                                }
                            }
                            if (wc.BoxCount < 10)
                            {
                                wc.WeightAccumuiation += weight;
                                wc.BoxCount++;
                                wc.Save("WeighConfig", wc);
                                if (weight > wc.StandardWeight)
                                {
                                    if (weight - wc.StandardWeight > prm.UpperLimit_First)
                                    {
                                        if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                            return "FAIL:" + results + "克重量超出设定范围";
                                        else
                                            return "FAIL:" + results + "g The weight is beyond the set range";
                                    }
                                }
                                else
                                {
                                    if (wc.StandardWeight - weight > prm.LowerLimit_First)
                                    {
                                        if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                            return "FAIL:" + results + "克重量超出设定范围";
                                        else
                                            return "FAIL:" + results + "g The weight is beyond the set range";
                                    }
                                }
                            }
                            else
                            {
                                if (wc.BoxCount == 10)
                                {
                                    wc.StandardWeight = wc.WeightAccumuiation / 10;
                                    wc.WeighCount = 0;
                                    wc.Save("WeighConfig", wc);
                                }
                                if (weight > wc.StandardWeight)
                                {
                                    if (wc.WeighCount < 10)
                                    {
                                        if (weight - wc.StandardWeight > prm.UpperLimit_First)
                                        {
                                            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                                return "FAIL:" + results + "克重量超出设定范围";
                                            else
                                                return "FAIL:" + results + "g The weight is beyond the set range";
                                        }
                                        else
                                        {
                                            if (weight - wc.StandardWeight > prm.UpperLimit_Second)
                                            {
                                                wc.WeighCount = 0;
                                                wc.Save("WeighConfig", wc);
                                            }
                                            else
                                            {
                                                wc.WeighCount++;
                                                wc.Save("WeighConfig", wc);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (weight - wc.StandardWeight > prm.UpperLimit_Second)
                                        {
                                            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                                return "FAIL:" + results + "克重量超出设定范围";
                                            else
                                                return "FAIL:" + results + "g The weight is beyond the set range";
                                        }
                                    }
                                }
                                else
                                {
                                    if (wc.WeighCount < 10)
                                    {
                                        if (wc.StandardWeight - weight > prm.LowerLimit_First)
                                        {
                                            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                                return "FAIL:" + results + "克重量超出设定范围";
                                            else
                                                return "FAIL:" + results + "g The weight is beyond the set range";
                                        }
                                        else
                                        {
                                            if (wc.StandardWeight - weight > prm.LowerLimit_Second)
                                            {
                                                wc.WeighCount = 0;
                                                wc.Save("WeighConfig", wc);
                                            }
                                            else
                                            {
                                                wc.WeighCount++;
                                                wc.Save("WeighConfig", wc);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (wc.StandardWeight - weight > prm.LowerLimit_Second)
                                        {
                                            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                                return "FAIL:" + results + "克重量超出设定范围";
                                            else
                                                return "FAIL:" + results + "g The weight is beyond the set range";
                                        }
                                    }
                                }
                            }

                            #endregion
                        }
                        else if (prm.WeighScheme == RunParam.weighscheme.Fourth)
                        {
                            #region 第四套称重方案

                            if (SKUChange)
                            {
                                wc.BoxCount = 0;
                                //wc.StandardWeight = weight;
                                wc.Save("WeighConfig", wc);
                            }
                            else
                            {
                                if (wc.StandardWeight <= 0)
                                {
                                    wc.BoxCount = 0;
                                    //wc.StandardWeight = weight;
                                    wc.Save("WeighConfig", wc);
                                }
                            }
                            wc.BoxCount++;
                            wc.WeightAccumuiation += weight;
                            wc.StandardWeight = weight / wc.BoxCount;
                            wc.Save("WeighConfig", wc);
                            if (weight > wc.StandardWeight)
                            {
                                if (weight - wc.StandardWeight > prm.UpperLimit_First)
                                {
                                    if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                        return "FAIL:" + results + "克重量超出设定范围";
                                    else
                                        return "FAIL:" + results + "g The weight is beyond the set range";
                                }
                            }
                            else
                            {
                                if (wc.StandardWeight - weight > prm.LowerLimit_First)
                                {
                                    if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                        return "FAIL:" + results + "克重量超出设定范围";
                                    else
                                        return "FAIL:" + results + "g The weight is beyond the set range";
                                }
                            }

                            #endregion
                        }
                        else if (prm.WeighScheme == RunParam.weighscheme.Fifth)
                        {
                            #region 第五套称重方案

                            if (SKUChange)
                            {
                                wc.BoxCount = 0;

                                wc.Save("WeighConfig", wc);
                            }
                            else
                            {
                                if (wc.StandardWeight <= 0)
                                {
                                    wc.BoxCount = 0;
                                    wc.Save("WeighConfig", wc);
                                }
                            }
                            if (wc.BoxCount < 10)
                            {
                                wc.WeightAccumuiation += weight;
                                wc.BoxCount++;
                                wc.StandardWeight = wc.WeightAccumuiation / wc.BoxCount;
                                wc.Save("WeighConfig", wc);
                                if (weight > wc.StandardWeight)
                                {
                                    if (weight - wc.StandardWeight > prm.UpperLimit_First)
                                    {
                                        if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                            return "FAIL:" + results + "克重量超出设定范围";
                                        else
                                            return "FAIL:" + results + "g The weight is beyond the set range";
                                    }
                                }
                                else
                                {
                                    if (wc.StandardWeight - weight > prm.LowerLimit_First)
                                    {
                                        if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                            return "FAIL:" + results + "克重量超出设定范围";
                                        else
                                            return "FAIL:" + results + "g The weight is beyond the set range";
                                    }
                                }
                            }
                            else
                            {
                                if (wc.BoxCount == 10)
                                {
                                    wc.StandardWeight = wc.WeightAccumuiation / 10;
                                    wc.WeighCount = 0;
                                    wc.Save("WeighConfig", wc);
                                }
                                if (weight > wc.StandardWeight)
                                {
                                    if (wc.WeighCount < 10)
                                    {
                                        if (weight - wc.StandardWeight > prm.UpperLimit_First)
                                        {
                                            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                                return "FAIL:" + results + "克重量超出设定范围";
                                            else
                                                return "FAIL:" + results + "g The weight is beyond the set range";
                                        }
                                        else
                                        {
                                            if (weight - wc.StandardWeight > prm.UpperLimit_Second)
                                            {
                                                wc.WeighCount = 0;
                                                wc.Save("WeighConfig", wc);
                                            }
                                            else
                                            {
                                                wc.WeighCount++;
                                                wc.Save("WeighConfig", wc);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (weight - wc.StandardWeight > prm.UpperLimit_Second)
                                        {
                                            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                                return "FAIL:" + results + "克重量超出设定范围";
                                            else
                                                return "FAIL:" + results + "g The weight is beyond the set range";
                                        }
                                    }
                                }
                                else
                                {
                                    if (wc.WeighCount < 10)
                                    {
                                        if (wc.StandardWeight - weight > prm.LowerLimit_First)
                                        {
                                            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                                return "FAIL:" + results + "克重量超出设定范围";
                                            else
                                                return "FAIL:" + results + "g The weight is beyond the set range";
                                        }
                                        else
                                        {
                                            if (wc.StandardWeight - weight > prm.LowerLimit_Second)
                                            {
                                                wc.WeighCount = 0;
                                                wc.Save("WeighConfig", wc);
                                            }
                                            else
                                            {
                                                wc.WeighCount++;
                                                wc.Save("WeighConfig", wc);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (wc.StandardWeight - weight > prm.LowerLimit_Second)
                                        {
                                            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                                return "FAIL:" + results + "克重量超出设定范围";
                                            else
                                                return "FAIL:" + results + "g The weight is beyond the set range";
                                        }
                                    }
                                }
                            }

                            #endregion
                        }
                    }
                    else
                    {
                        if (prm.TestWeigh)
                        {
                            weight = Convert.ToDouble(results);
                            if (weight > prm.Weight)
                            {
                                if (weight - prm.Weight > prm.UpperLimit_First)
                                {
                                    if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                        return "FAIL:" + results + "克重量超出设定范围";
                                    else
                                        return "FAIL:" + results + "g The weight is beyond the set range";
                                }
                            }
                            else
                            {
                                if (prm.Weight - weight > prm.LowerLimit_First)
                                {
                                    if (prm.LanguageSelect == RunParam.languageselect.ZH)
                                        return "FAIL:" + results + "克重量超出设定范围";
                                    else
                                        return "FAIL:" + results + "g The weight is beyond the set range";
                                }
                            }
                        }
                    }
                    return results + "g";
                }
                else
                {
                    if (prm.LanguageSelect == RunParam.languageselect.ZH)
                        return "FAIL:电子秤触发异常";
                    else
                        return "FAIL:Scales trigger fail";
                }
            }
            catch
            {
                if (prm.LanguageSelect == RunParam.languageselect.ZH)
                    return "FAIL:电子秤触发异常";
                else
                    return "FAIL:Scales trigger fail";
            }
        }

        /// <summary>
        /// 彩盒检测
        /// </summary>
        /// <returns></returns>
        public bool ColorBoxDetection()
        {
            #region 网络连接检查

            if (!SFCLinkStatus())
            {
                Notify("网络连接失败!", "Network connection fail ", false);
                dataserver.StationLoc[1].Msg = messages("网络连接失败!", "Network connection fail ");
                return false;
            }

            #endregion

            #region 检查PSN

            if (dataserver.StationLoc[1].PSN.ToUpper().Contains("FAIL"))
            {
                dataserver.StationLoc[1].Msg = messages("扫码异常:" + dataserver.StationLoc[1].PSN, "Scanner error:" + dataserver.StationLoc[1].PSN);
                return false;
            }
            if (!dataserver.StationLoc[1].PSN_Check)
                return false;

            if (prm.PhoneType == RunParam.LineTypeNo.B5)
            {
                dataserver.StationLoc[1].TypeName = prm.B5PhoneType;
            }
            else
            {
                dataserver.StationLoc[1].TypeName = prm.S5PhoneType;
            }

            #endregion

            #region 打光

            if (dataserver.StationLoc[1].Color_SFC.Equals("JustBlack"))
            {
                optLight.SetIntensity(1, alignLight.ch1_black);
                optLight.SetIntensity(2, alignLight.ch2_black);
            }
            else if (dataserver.StationLoc[1].Color_SFC.Equals("ClearlyWhite"))
            {
                optLight.SetIntensity(1, alignLight.ch1_white);
                optLight.SetIntensity(2, alignLight.ch2_white);
            }
            else
            {
                optLight.SetIntensity(1, alignLight.ch1_orange);
                optLight.SetIntensity(2, alignLight.ch2_orange);
            }

            optLight.SetIntensity(3, alignLight.ch3_GlogoLight);

            Thread.Sleep(Convert.ToInt32(prm.LightWaitTime * 1000));

            #endregion

            #region 视觉检测
            while (CCDSOCKET2)
            {
                Thread.Sleep(1);
            }
            Thread.Sleep(10);
            CCDSOCKET1 = true;
            string ImagePath = string.Empty;
            try
            {
                ImagePath = Path.Combine(@"D:\DeviceData\图片数据", DateTime.Now.ToString("yyyy-MM-dd"), dataserver.StationLoc[1].PSN);
                if (Directory.Exists(ImagePath))
                {
                    Directory.Delete(ImagePath, true);
                    Directory.CreateDirectory(ImagePath);
                }
                else
                {
                    Directory.CreateDirectory(ImagePath);
                }
            }
            catch
            {
                Notify("图片存储操作失败！", "Image save is failed", false);
                dataserver.StationLoc[1].Msg = messages("视觉异常:图片存储失败！", "Vision error:image save fail!");
                return false;
            }

            dataserver.StationLoc[1].ImagePath = ImagePath;
            //dataserver.StationLoc[1].TypeName = prm.PhoneType.ToString();

            if (!Take_Pictrue(0, Convert.ToInt32(prm.ccd1_exporsureTime)).Equals("true"))
            {
                dataserver.StationLoc[1].Msg = messages("视觉异常:正面相机拍照失败!", "Vision error:the front camera failed!");
                CCDSOCKET1 = false;
                return false;
            }
            if (!Save_Image(0, Path.Combine(ImagePath, dataserver.StationLoc[1].PSN + "正面原图")).Equals("true"))
            {
                dataserver.StationLoc[1].Msg = messages("视觉异常:正面相机图片保存出错!", "Vision error:the front camera image save failed!");
                CCDSOCKET1 = false;
                return false;
            }

            if (!ReadType_Top(prm.PhoneType.ToString(), prm.ccd1_exporsureTime))
            {
                dataserver.StationLoc[1].Msg = messages("视觉异常:正面型号识别失败!", "Vision error:Type_Top Identification of failure!");
                CCDSOCKET1 = false;
                return false;
            }
            SaveWindow(dataserver.StationLoc[1].PSN, "Type_Top", ImagePath, hWinCtrl1);
            dataserver.StationLoc[1].Type_Top_Check = true;

            if (!ReadColor_top(dataserver.StationLoc[1].Color_SFC))
            {
                dataserver.StationLoc[1].Msg = messages("视觉异常:正面颜色识别失败!", "Vision error:Color_Top Identification of failure!");
                CCDSOCKET1 = false;
                return false;
            }
            SaveWindow(dataserver.StationLoc[1].PSN, "Color_Top", ImagePath, hWinCtrl1);
            dataserver.StationLoc[1].Color_Top_Check = true;

            if (!Take_Pictrue(1, Convert.ToInt32(prm.ccd2_exporsureTime)).Equals("true"))
            {
                dataserver.StationLoc[1].Msg = messages("视觉异常:Retail相机拍照失败!", "Vision error:the retail camera failed!");
                CCDSOCKET1 = false;
                return false;
            }
            if (!Save_Image(1, Path.Combine(ImagePath, dataserver.StationLoc[1].PSN + "小侧面Glogo原图")).Equals("true"))
            {
                dataserver.StationLoc[1].Msg = messages("视觉异常:Retail相机图片保存出错!", "Vision error:the retail camera image save failed!");
                CCDSOCKET1 = false;
                return false;
            }

            if (!ReadGLogo_Retail(prm.ccd2_exporsureTime))
            {
                dataserver.StationLoc[1].Msg = messages("视觉异常:Retail防伪识别失败!", "Vision error:GLabel_Retail Identification of failure!");
                CCDSOCKET1 = false;
                return false;
            }
            SaveWindow(dataserver.StationLoc[1].PSN, "GLogo_Retail", ImagePath, hWinCtrl2);
            dataserver.StationLoc[1].GLogo_Check = true;

            optLight.SetIntensity(3, alignLight.ch3_RetailLight);

            if (!Take_Pictrue(1, Convert.ToInt32(prm.ccd3_exporsureTime)).Equals("true"))
            {
                dataserver.StationLoc[1].Msg = messages("视觉异常:Retail相机拍照失败!", "Vision error:the retail camera failed!");
                CCDSOCKET1 = false;
                return false;
            }
            if (!Save_Image(1, Path.Combine(ImagePath, dataserver.StationLoc[1].PSN + "小侧面原图")).Equals("true"))
            {
                dataserver.StationLoc[1].Msg = messages("视觉异常:Retail相机图片保存出错!", "Vision error:the retail camera image save failed!");
                return false;
            }

            if (!ReadType_Retail(dataserver.StationLoc[1].Add, prm.PhoneType.ToString(), prm.ccd3_exporsureTime))
            {
                dataserver.StationLoc[1].Msg = messages("视觉异常:Retail型号识别失败!", "Vision error:Type_Retail Identification of failure!");
                CCDSOCKET1 = false;
                return false;
            }
            SaveWindow(dataserver.StationLoc[1].PSN, "Type_Retail", ImagePath, hWinCtrl2);
            dataserver.StationLoc[1].Type_Retail_Check = true;

            //if (prm.democheck_switch)
            //{
            //    if (!ReadDemo_Retail())
            //    {
            //        dataserver.StationLoc[1].Msg = messages("视觉异常:Retail样机识别失败!", "Vision error:Demo_Retail Identification of failure!");
            //        return false;
            //    }
            //    SaveWindow(dataserver.StationLoc[1].PSN, "Demo_Retail", ImagePath, hWinCtrl2);
            //}

            if (!ReadMemory_Retail(dataserver.StationLoc[1].MemorySize_SFC, dataserver.StationLoc[1].LanguageType))
            {
                dataserver.StationLoc[1].Msg = messages("视觉异常:Retail内存识别失败!", "Vision error:Memory_Retail Identification of failure!");
                CCDSOCKET1 = false;
                return false;
            }
            SaveWindow(dataserver.StationLoc[1].PSN, "Memory_Retail", ImagePath, hWinCtrl2);
            dataserver.StationLoc[1].Memory_Check = true;

            if (!ReadColor_Retail(dataserver.StationLoc[1].Color_SFC, dataserver.StationLoc[1].LanguageType))
            {
                dataserver.StationLoc[1].Msg = messages("视觉异常:Retail颜色识别失败!", "Vision error:Color_Retail Identification of failure!");
                CCDSOCKET1 = false;
                return false;
            }
            SaveWindow(dataserver.StationLoc[1].PSN, "Color_Retail", ImagePath, hWinCtrl2);
            dataserver.StationLoc[1].Color_Check = dataserver.StationLoc[1].Color_Retail_Check = true;

            //if (!ReadBarcode_Retail(dataserver.StationLoc[1].IMEI_SFC, dataserver.StationLoc[1].SKU_SFC))
            //{
            //    dataserver.StationLoc[1].Msg = messages("视觉异常:Retail条码识别失败!", "Vision error:Barcode_Retail Identification of failure!");
            //    CCDSOCKET1 = false;
            //    return false;
            //}
            CCDSOCKET1 = false;
            SaveWindow(dataserver.StationLoc[1].PSN, "Barcode_Retail", ImagePath, hWinCtrl2);
            dataserver.StationLoc[1].Barcode_Check =
            dataserver.StationLoc[1].SKU_Check =
            dataserver.StationLoc[1].IMEI_Check = true;

            #endregion

            #region 称重

            dataserver.StationLoc[1].Weight = ScalesCode(dataserver.StationLoc[1].SkuChange);

            if (dataserver.StationLoc[1].Weight.ToUpper().Contains("FAIL"))
            {
                dataserver.StationLoc[1].Msg = messages("称重异常:" + dataserver.StationLoc[1].Weight, "Weigh error:" + dataserver.StationLoc[1].Weight);
                return false;
            }

            dataserver.StationLoc[1].Weight_Check = true;
            #endregion

            return true;
        }

        /// <summary>
        /// 分段获取数据
        /// </summary>
        /// <param name="response"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool GetDataString(string response, out string[] data)
        {
            //String[] dataname = { "imei1","sku","color","size","add" };
            //data = new string[dataname.Length];
            //for (int i = 0; i < data.Length; i++)
            //{
            //    data[i] = HttpHelper.GetjsonData(response, dataname[i]);
            //    if (string.IsNullOrEmpty(data[i])) return false;
            //}
            //return true;

            String[] dataname = { "imei1", "sku", "color" };
            data = new string[5];
            for (int i = 0; i < dataname.Length; i++)
            {
                data[i] = HttpHelper.GetjsonData(response, dataname[i]);
                if (string.IsNullOrEmpty(data[i])) return false;
            }
            data[3] = "128";
            data[4] = "EU";
            return true;
        }

        /// <summary>
        /// 获取彩盒数据
        /// </summary>
        /// <returns></returns>
        public bool GetSFCData()
        {

            #region 参数

            string language = string.Empty;
            string response = string.Empty;
            string[] data = new string[5];

            #endregion

            #region 检查PSN

            if (dataserver.StationLoc[0].PSN.ToUpper().Contains("FAIL") || string.IsNullOrEmpty(dataserver.StationLoc[0].PSN))
            {
                dataserver.StationLoc[0].Msg = messages("扫码异常:" + dataserver.StationLoc[0].PSN, "Scanner error:" + dataserver.StationLoc[0].PSN);
                return false;
            }
            dataserver.StationLoc[0].PSN_Check = true;

            #endregion

            #region 数据获取

            try
            {
                if (!D01HTTPSERVER.GetColorBoxData(url_GETLABELDATA, dataserver.StationLoc[0].PSN, "RETAIL", out response))
                {
                    Notify("彩盒数据获取失败!", "Color Box Data is cannot get!", false);
                    dataserver.StationLoc[0].Msg = messages("彩盒数据获取失败!", "Color Box Data is cannot get!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Notify(ex.Message, ex.Message);
                return false;
            }
            //response = response.Substring(response.IndexOf("data"), response.Length - response.IndexOf("data"));
            if (!GetDataString(response, out data))
            {
                Notify("彩盒数据获取失败!", "Color Box Data is cannot get!", false);
                dataserver.StationLoc[0].Msg = messages("彩盒数据获取失败!", "Color Box Data is cannot get!");
                return false;
            }
            if (data[2].ToUpper().Contains("BLK"))
            {
                data[2] = "JustBlack";
            }
            else if (data[2].ToUpper().Contains("WHITE"))
            {
                data[2] = "ClearlyWhite";
            }
            else if (data[2].ToUpper().Contains("ORANGE"))
            {
                data[2] = "Orange";
            }

            language = "EN";
            if (data[1].Contains("FR") && !data[1].Contains("FRN"))
            {
                language = "FR";
            }
            data[3] += "GB";

            dataserver.StationLoc[0].IMEI_SFC = data[0];
            dataserver.StationLoc[0].SKU_SFC = data[1];
            if (!dataserver.StationLoc[0].SKU_SFC.Equals(prm.SKU_Now))
            {
                prm.SKU_Now = dataserver.StationLoc[0].SKU_SFC;
                prm.Save("RunConfig", prm);
                dataserver.StationLoc[0].SkuChange = true;
            }
            dataserver.StationLoc[0].Color_SFC = data[2];
            dataserver.StationLoc[0].MemorySize_SFC = data[3];
            dataserver.StationLoc[0].Add = data[4];
            dataserver.StationLoc[0].LanguageType = language;

            if (prm.PhoneType == RunParam.LineTypeNo.S5)
            {
                for (int i = 0; i < prm.S5BOB.Length; i++)
                {
                    if (dataserver.StationLoc[0].SKU_SFC.Contains(prm.S5BOB[i]))
                    {
                        dataserver.StationLoc[0].NeedCheck = false;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < prm.S5BOB.Length; i++)
                {
                    if (dataserver.StationLoc[0].SKU_SFC.Contains(prm.S5BOB[i]))
                    {
                        dataserver.StationLoc[0].NeedCheck = false;
                        break;
                    }
                }
            }
            if (!D01HTTPSERVER.GetClosure(url_GETCLOSURE, dataserver.StationLoc[0].PSN, out response))
            {
                Notify("彩盒数据获取失败!", "Color Box Data is cannot get!", false);
                dataserver.StationLoc[0].Msg = messages("彩盒数据获取失败!", "Color Box Data is cannot get!");
                return false;
            }
            if (HttpHelper.GetjsonData(response, "closure", false).Equals("N"))
            {
                dataserver.StationLoc[0].NotDecals = true;
                goto goon;
            }
            for (int i = 0; i < prm.LargeLabel.Length; i++)
            {
                if (dataserver.StationLoc[0].Add.Equals(prm.LargeLabel[i]))
                {
                    dataserver.StationLoc[0].LargeLabel = true;
                    goto goon;
                }
            }
            #endregion

        goon:
            return true;

        }

        public bool ThroughStation()
        {
            string response = string.Empty;
            if (D03HTTPSERVER.CheckRoute(url_CONNECT, dataserver.StationLoc[2].StationID, dataserver.StationLoc[2].PSN, out response))
            {
                return false;
            }
            if (!HttpHelper.GetjsonData(response, "message", false).Equals(prm.NextStationName))
            {
                return false;
            }
            if (!D03HTTPSERVER.GetColorBoxData(url_GETLABELDATA, dataserver.StationLoc[2].PSN, "RETAIL", out response))
            {
                return false;
            }
            string add = "EU";
                //HttpHelper.GetjsonData(response, "add");
            if (!D03HTTPSERVER.GetClosure(url_GETLABELDATA, dataserver.StationLoc[2].PSN, out response))
            {
                return false;
            }
            if (HttpHelper.GetjsonData(response, "closure", false).Equals("N"))
            {
                dataserver.StationLoc[2].NotDecals = true;
            }
            else
            {
                for (int i = 0; i < prm.LargeLabel.Length; i++)
                {
                    if (add.Equals(prm.LargeLabel[i]))
                    {
                        dataserver.StationLoc[2].LargeLabel = true;
                    }
                }
            }
            dataserver.StationLoc[2].Result = "PASS";
            dataserver.StationLoc[2].Through_Check = true;
            dataserver.StationLoc[2].Msg = messages("产品已过站","Product is UploadPass");
            return true;
        }

        /// <summary>
        /// BOBlabel识别
        /// </summary>
        /// <returns></returns>
        public bool SideLabelDetection()
        {
            optLight.SetIntensity(4, alignLight.ch4_Light);
            Thread.Sleep(Convert.ToInt32(prm.LightWaitTime * 1000));
            while (CCDSOCKET1)
            {
                Thread.Sleep(1);
            }
            Thread.Sleep(10);
            CCDSOCKET2 = true;
            try
            {
                if (!Directory.Exists(dataserver.StationLoc[2].ImagePath))
                {
                    Directory.CreateDirectory(dataserver.StationLoc[2].ImagePath);
                }
            }
            catch
            {
                Notify("图片存储操作失败！", "Image save is failed", false);
                dataserver.StationLoc[2].Msg = messages("视觉异常:图片存储失败！", "Vision error:image save fail!");
                return false;
            }
            if (!Take_Pictrue(2, Convert.ToInt32(prm.ccd4_exporsureTime)).Equals("true"))
            {
                dataserver.StationLoc[2].Msg = messages("视觉异常:BOB相机拍照失败!", "Vision error:the bob camera failed!");
                CCDSOCKET2 = false;
                return false;
            }
            if (!Save_Image(2, Path.Combine(dataserver.StationLoc[2].ImagePath, dataserver.StationLoc[2].PSN + "大侧面原图")).Equals("true"))
            {
                dataserver.StationLoc[2].Msg = messages("视觉异常:BOB相机图片保存出错!", "Vision error:the boo camera image save failed!");
                CCDSOCKET2 = false;
                return false;
            }
            if (!ReadType_Side(prm.PhoneType.ToString(), prm.ccd4_exporsureTime))
            {
                dataserver.StationLoc[2].Msg = messages("视觉异常:BOB型号识别失败!", "Vision error:Type_BOB Identification of failure!");
                CCDSOCKET2 = false;
                return false;
            }
            SaveWindow(dataserver.StationLoc[2].PSN, "Type_Side", dataserver.StationLoc[2].ImagePath, hWinCtrl3);
            dataserver.StationLoc[2].Type_Side_Check = true;
            dataserver.StationLoc[2].PhoneType_Check = true;

            if (dataserver.StationLoc[2].SKU_SFC.Contains("IN"))
            {
                if (!ReadPrice_Side(dataserver.StationLoc[2].MemorySize_SFC))
                {
                    dataserver.StationLoc[2].Msg = messages("视觉异常:BOB价格识别失败!", "Vision error:Price_BOB Identification of failure!");
                    CCDSOCKET2 = false;
                    return false;
                }
                SaveWindow(dataserver.StationLoc[2].PSN, "Price_Side", dataserver.StationLoc[2].ImagePath, hWinCtrl3);
            }
            CCDSOCKET2 = false;
            dataserver.StationLoc[2].Price_Check = true;

            return true;
        }

        /// <summary>
        /// 交换数据到prodata用于数据上传
        /// </summary>
        public string SwitchData()
        {
            string data = string.Empty;
            data += string.Format("\"result\":\"{0}\",", dataserver.StationLoc[2].Result.ToUpper());
            data += string.Format("\"weight\":\"{0}\"", dataserver.StationLoc[2].Weight.Replace("g", ""));
            return data;
        }

        /// <summary>
        /// 保存窗口图片
        /// </summary>
        /// <param name="PSN">PSN条码</param>
        /// <param name="FileName">图片名称</param>
        /// <param name="FilePath">保存路径</param>
        /// <param name="ctrl">相机控件</param>
        public void SaveWindow(string PSN, string FileName, string FilePath, hWinCtrl ctrl)
        {
            //string directorPath = string.Empty;
            try
            {
                //directorPath = Path.Combine(FilePath, DateTime.Now.ToString("yyyy-MM-dd"), PSN);
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string fileNamePath = Path.Combine(FilePath, PSN + "_" + FileName);
                ctrl.SaveWindow(fileNamePath, ImgFormat.jpeg);
            }
            catch (Exception ex)
            {
                Notify("图片保存出错:" + ex.ToString(), "Image save failed:" + ex.ToString(), false);
            }
        }

        /// <summary>
        /// 保存原图
        /// </summary>
        /// <param name="PSN">PSN条码</param>
        /// <param name="FileName">图片名称</param>
        /// <param name="FilePath">保存路径</param>
        /// <param name="ctrl">相机控件</param>
        public void SaveImage(string PSN, string FileName, string FilePath, hWinCtrl ctrl)
        {
            //string directorPath = string.Empty;
            try
            {
                //directorPath = Path.Combine(FilePath, DateTime.Now.ToString("yyyy-MM-dd"), PSN);
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string fileNamePath = Path.Combine(FilePath, PSN + "_" + FileName);
                ctrl.SaveImage(ImgFormat.bmp.ToString(), fileNamePath);
            }
            catch (Exception ex)
            {
                Notify("图片保存出错:" + ex.ToString(), "Image save failed:" + ex.ToString(), false);
            }
        }

        /// <summary>
        /// 按钮监听
        /// </summary>
        public void MachineEngien()
        {
            while (true)
            {
                if (InEMG.IO64Power(io))
                {
                    D01Stop();
                    D02Stop();
                    D03Stop();
                    Notify("设备急停!", "Device is EMG", false);
                    new Thread(new ThreadStart(() =>
                    {
                        while (InEMG.IO64Power(io))
                        {
                            OutBuzzer.IO64Power(io, true);
                            Thread.Sleep(450);
                            OutBuzzer.IO64Power(io, false);
                            Thread.Sleep(450);
                        }
                    })) { IsBackground = true }.Start();
                    while (InEMG.IO64Power(io))
                    {
                        Thread.Sleep(1);
                    }
                }
                else if (InReset.IO64Power(io) || ResetButton)
                {
                    ResetButton = false;
                    OutGreenLamp.IO64Power(io, false);
                    OutYerrowLamp.IO64Power(io, true);
                    OutRedLamp.IO64Power(io, true);
                    Thread ThreadD01Reset = new Thread(new ThreadStart(() =>
                    {
                        if (D01_Status == StationStatus.Stop || D01_Status == StationStatus.Error || D01_Status == StationStatus.Init)
                        {
                            D01Reset();
                        }
                    }));
                    ThreadD01Reset.Start();
                    Thread ThreadD02Reset = new Thread(new ThreadStart(() =>
                    {
                        if (D02_Status == StationStatus.Stop || D02_Status == StationStatus.Error || D02_Status == StationStatus.Init)
                        {
                            D02Reset();
                        }
                    }));
                    ThreadD02Reset.Start();
                    Thread ThreadD03Reset = new Thread(new ThreadStart(() =>
                    {
                        if (D03_Status == StationStatus.Stop || D03_Status == StationStatus.Error || D03_Status == StationStatus.Init)
                        {
                            D03Reset();
                        }
                    }));
                    ThreadD03Reset.Start();
                    while (ThreadD01Reset.IsAlive || ThreadD02Reset.IsAlive || ThreadD03Reset.IsAlive)
                    {
                        Thread.Sleep(1);
                    }
                    //if (D01_Status == StationStatus.Stop || D01_Status == StationStatus.Error || D01_Status == StationStatus.Init)
                    //{
                    //    D01Reset();
                    //}
                    //if (D02_Status == StationStatus.Stop || D02_Status == StationStatus.Error || D02_Status == StationStatus.Init)
                    //{
                    //    D02Reset();
                    //}
                    //if (D03_Status == StationStatus.Stop || D03_Status == StationStatus.Error || D03_Status == StationStatus.Init)
                    //{
                    //    D03Reset();
                    //}
                    if (D01_Status != StationStatus.Error && D02_Status != StationStatus.Error && D03_Status != StationStatus.Error)
                    {
                        OutBuzzer.IO64Power(io, false);
                        OutGreenLamp.IO64Power(io, true);
                        OutYerrowLamp.IO64Power(io, true);
                        OutRedLamp.IO64Power(io, false);
                    }
                    else
                    {
                        //OutBuzzer.IO64Power(io, true);
                        OutGreenLamp.IO64Power(io, false);
                        OutYerrowLamp.IO64Power(io, true);
                        OutRedLamp.IO64Power(io, false);
                    }
                }
                else if (StopButton)
                {
                    StopButton = false;
                    D01Stop();
                    D02Stop();
                    D03Stop();
                    Notify("设备停止!", "Device Stop", false);
                }
                else if (InStart.IO64Power(io) || StartButton)
                {
                    StartButton = false;
                    if (D01_Status == StationStatus.Reset || D01_Status == StationStatus.Pause)
                    {
                        D01Start();
                    }
                    if (D02_Status == StationStatus.Reset || D02_Status == StationStatus.Pause)
                    {
                        D02Start();
                    }
                    if (D03_Status == StationStatus.Reset || D03_Status == StationStatus.Pause)
                    {
                        D03Start();
                    }
                    if (D01_Status == StationStatus.Normal || D01_Status == StationStatus.Running || D01_Status == StationStatus.Finish)
                    {
                        if (D02_Status == StationStatus.Normal || D02_Status == StationStatus.Running || D02_Status == StationStatus.Finish)
                        {
                            if (D03_Status == StationStatus.Normal || D03_Status == StationStatus.Running || D03_Status == StationStatus.Finish)
                            {
                                OutGreenLamp.IO64Power(io, true);
                                OutYerrowLamp.IO64Power(io, false);
                                OutRedLamp.IO64Power(io, false);
                                OutBuzzer.IO64Power(io, false);
                            }
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// 门禁监听
        /// </summary>
        public void SafeGuard()
        {
            while (true)
            {
                if (prm.SafeGuardEnable)
                {
                    if (InSafeGuard.IO64Power(io))
                    {
                        Notify("门禁触发!", "SafeGuard triggered", false);
                        OutGreenLamp.IO64Power(io, false);
                        OutYerrowLamp.IO64Power(io, true);
                        OutRedLamp.IO64Power(io, false);
                        while (InSafeGuard.IO64Power(io) && prm.SafeGuardEnable)
                        {
                            if (D01_Status == StationStatus.Normal || D01_Status == StationStatus.Running || D01_Status == StationStatus.Finish)
                            {
                                BufferStatus_D01 = D01_Status;
                                D01_Status = StationStatus.Pause;
                            }
                            if (D02_Status == StationStatus.Normal || D02_Status == StationStatus.Running || D02_Status == StationStatus.Finish)
                            {
                                BufferStatus_D02 = D02_Status;
                                D02_Status = StationStatus.Pause;
                            }
                            if (D03_Status == StationStatus.Normal || D03_Status == StationStatus.Running || D03_Status == StationStatus.Finish)
                            {
                                BufferStatus_D03 = D03_Status;
                                D03_Status = StationStatus.Pause;
                            }
                            OutBuzzer.IO64Power(io, true);
                            Thread.Sleep(300);
                            OutBuzzer.IO64Power(io, false);
                            Thread.Sleep(300);
                        }
                        Notify("门禁关闭!", "SafeGuard close");
                    }
                }
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// NG彩盒监听
        /// </summary>
        public void NGStation()
        {
            Stopwatch overtime = new Stopwatch();
            while (true)
            {
                while (D03_Status == StationStatus.Normal || D03_Status == StationStatus.Running || D03_Status == StationStatus.Finish || D03_Status == StationStatus.Pause)
                {
                    if (FirstNGBoxSignal.IO64Power(io))
                    {
                        overtime.Restart();
                        while (FirstNGBoxSignal.IO64Power(io))
                        {
                            if (overtime.ElapsedMilliseconds > 5000)
                            {
                                Notify("NG彩盒未取出！", "NG box is not exit", false);
                                overtime.Stop();
                                while (FirstNGBoxSignal.IO64Power(io))
                                {
                                    OutBuzzer.IO64Power(io, true);
                                    Thread.Sleep(100);
                                    OutBuzzer.IO64Power(io, false);
                                    Thread.Sleep(300);
                                }
                            }
                            Thread.Sleep(1);
                        }
                    }
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// 中英文信息显示
        /// </summary>
        /// <param name="zh_msg"></param>
        /// <param name="en_msg"></param>
        /// <returns></returns>
        public string messages(string zh_msg, string en_msg)
        {
            if (prm.LanguageSelect == RunParam.languageselect.ZH)
                return zh_msg;
            else
                return en_msg;
        }

        /// <summary>
        /// SFC链接状态监听
        /// </summary>
        /// <returns></returns>
        public bool SFCLinkStatus()
        {
            //try
            //{
            //    if (link.SFC_UserInfo(prm.StationID, prm.UserCode, prm.PassWord, prm.Language, prm.Site, prm.Bu))
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch
            //{
            //    return false;
            //}
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(prm.URL, 2000);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 彩盒到位信号监听
        /// </summary>
        public void ListenInPlaceSignal()
        {
            while (!InInPlaceSignal.IO64Power(io) && D03_Status != StationStatus.Stop && D03_Status != StationStatus.Error && D03_Status != StationStatus.Reset && D03_Status != StationStatus.Resetting && D03_Status != StationStatus.Init)
            {
                Thread.Sleep(1);
            }
            ListenPlcae = true;
        }

        /// <summary>
        /// 测试CCD
        /// </summary>
        public void CCDTest()
        {
            while (CCDSOCKET2)
            {
                Thread.Sleep(1);
            }
            Thread.Sleep(10);
            CCDSOCKET1 = true;
            string CCDTestInfo = string.Empty;
            string imagepath = Path.Combine(@"D:\DeviceData\图片数据", DateTime.Now.ToString("yyyy-MM-dd"), "Test");
            if (Directory.Exists(imagepath))
            {
                Directory.Delete(imagepath, true);
                Directory.CreateDirectory(imagepath);
            }
            else
            {
                Directory.CreateDirectory(imagepath);
            }
            optLight.SetIntensity(1, alignLight.ch1_black);
            optLight.SetIntensity(2, alignLight.ch2_black);
            Thread.Sleep(Convert.ToInt32(prm.LightWaitTime * 1000));
            Take_Pictrue(0, Convert.ToInt32(prm.ccd1_exporsureTime));
            Save_Image(0, Path.Combine(imagepath, "Test_正面原图"));
            CCDTestInfo = Type_top(prm.PhoneType.ToString(), prm.ccd1_exporsureTime, true);
            SaveWindow("Test", "Type_top", Path.Combine(imagepath), hWinCtrl1);
            Notify("TypeTop:" + CCDTestInfo, "TypeTop:" + CCDTestInfo);
            CCDTestInfo = Color_Top();
            SaveWindow("Test", "Color_Top", Path.Combine(imagepath), hWinCtrl1);
            Notify("ColorTop:" + CCDTestInfo, "ColorTop:" + CCDTestInfo);
            optLight.SetIntensity(3, alignLight.ch3_GlogoLight);
            Thread.Sleep(Convert.ToInt32(prm.LightWaitTime * 1000));
            Take_Pictrue(1, Convert.ToInt32(prm.ccd2_exporsureTime));
            Save_Image(1, Path.Combine(imagepath, "Test_小侧面Glogo原图"));
            CCDTestInfo = GLogo_Retail(prm.ccd2_exporsureTime, true);
            SaveWindow("Test", "GLogo_Retail", Path.Combine(imagepath), hWinCtrl2);
            Notify("GLabelRetail:" + CCDTestInfo, "GLabelRetail:" + CCDTestInfo);
            optLight.SetIntensity(3, alignLight.ch3_RetailLight);
            Thread.Sleep(Convert.ToInt32(prm.LightWaitTime * 1000));
            Take_Pictrue(1, Convert.ToInt32(prm.ccd3_exporsureTime));
            Save_Image(1, Path.Combine(imagepath, "Test_小侧面原图"));
            CCDTestInfo = Type_Retail("ADD", prm.PhoneType.ToString(), prm.ccd3_exporsureTime, true);
            SaveWindow("Test", "Type_Retail", Path.Combine(imagepath), hWinCtrl2);
            Notify("TypeRetail:" + CCDTestInfo, "TypeRetail:" + CCDTestInfo);
            CCDTestInfo = Memory_Retail("Memory", "Language", true);
            SaveWindow("Test", "Memory_Retail", Path.Combine(imagepath), hWinCtrl2);
            Notify("MemoryRetail:" + CCDTestInfo, "MemoryRetail:" + CCDTestInfo);
            CCDTestInfo = Color_Retail("Color", "Language", true);
            SaveWindow("Test", "Color_Retail", Path.Combine(imagepath), hWinCtrl2);
            Notify("ColorRetail:" + CCDTestInfo, "ColorRetail:" + CCDTestInfo);
            CCDTestInfo = Barcode_Retail();
            SaveWindow("Test", "Barcode_Retail", Path.Combine(imagepath), hWinCtrl2);
            CCDSOCKET1 = false;
            Notify("BarcodeRetail:" + CCDTestInfo, "BarcodeRetail:" + CCDTestInfo);
            Notify("测试结果仅供参考", "The Test results are for reference only");
        }

        /// <summary>
        /// 测试BOB
        /// </summary>
        public void BOBTest()
        {
            string CCDTestInfo = string.Empty;
            string imagepath = Path.Combine(@"D:\DeviceData\图片数据", DateTime.Now.ToString("yyyy-MM-dd"), "Test");
            if (!Directory.Exists(imagepath))
            {
                Directory.CreateDirectory(imagepath);
            }
            optLight.SetIntensity(1, alignLight.ch4_Light);
            Thread.Sleep(Convert.ToInt32(prm.LightWaitTime * 1000));
            while (CCDSOCKET1)
            {
                Thread.Sleep(1);
            }
            Thread.Sleep(10);
            CCDSOCKET2 = true;
            Take_Pictrue(2, Convert.ToInt32(prm.ccd4_exporsureTime));
            Save_Image(2, Path.Combine(imagepath, "Test_低面原图"));
            CCDTestInfo = Type_Side(prm.PhoneType.ToString(), prm.ccd4_exporsureTime, true);
            SaveWindow("Test", "Type_Side", Path.Combine(imagepath), hWinCtrl3);
            Notify("TypeSide:" + CCDTestInfo, "TypeSide:" + CCDTestInfo);
            CCDTestInfo = Price_Side("Memory", true);
            SaveWindow("Test", "Price_Side", Path.Combine(imagepath), hWinCtrl3);
            CCDSOCKET2 = false;
            Notify("PriceSide:" + CCDTestInfo, "PriceSide:" + CCDTestInfo);
            Notify("测试结果仅供参考", "The Test results are for reference only");
        }

        #region 气缸控制

        /// <summary>
        /// 气缸控制
        /// </summary>
        /// <param name="output">输出点</param>
        /// <param name="inputOrg">原点</param>
        /// <param name="inputOn">动点</param>
        /// <param name="on_off">触发信号，true：动点动作，false:原点动作</param>
        /// <returns></returns>
        public bool CylAction(Output output, Input inputOrg, Input inputOn, bool on_off)
        {
            Single time = 3000;
            output.IO64Power(io, on_off);
            if (on_off)
            {
                while (!inputOn.IO64Power(io))
                {
                    ShowInfo.Delay(100);
                    time -= 100;
                    if (time <= 0)
                    {
                        Notify(String.Format("{0}动点未到位！", output.IOText), String.Format("{0} Action point warning！", output.IOText), false);
                        if (DialogResult.OK == MessageBox.Show(output.IOText + "动点异常！\n点击确认可继续运行.\nAtion point warning!\npress OK can continue.", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            return true;
                        }
                        return false;
                    }
                }

            }
            else
            {
                while (!inputOrg.IO64Power(io))
                {
                    ShowInfo.Delay(100);
                    time -= 100;
                    if (time <= 0)
                    {
                        Notify(String.Format("{0}原点未到位！", output.IOText), String.Format("{0} Original point warning！", output.IOText), false);
                        if (DialogResult.OK == MessageBox.Show(output.IOText + "原点异常！\n点击确认可继续运行.\nOriginal point warning!\npress OK can continue.", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            return true;
                        }
                        return false;
                    }

                }
            }
            return true;
        }

        /// <summary>
        /// 称重气缸控制
        /// </summary>
        /// <param name="on_off">触发信号，true：动点动作，false:原点动作</param>
        /// <returns></returns>
        public bool CylAction_Weigh(bool on_off)
        {
            return CylAction(WeighCly, WeighClyOrg, WeighClyOn, on_off);
        }

        /// <summary>
        /// 两侧整形气缸控制
        /// </summary>
        /// <param name="on_off">触发信号，true：动点动作，false:原点动作</param>
        /// <returns></returns>
        public bool CylAction_SideAdjust(bool on_off)
        {
            Single time = 3000;
            SideAdjustCly.IO64Power(io, on_off);
            if (on_off)
            {
                while (!LeftSideAdjustClyOn.IO64Power(io) || !RightSideAdjustClyOn.IO64Power(io))
                {
                    ShowInfo.Delay(100);
                    time -= 100;
                    if (time <= 0)
                    {
                        Notify(String.Format("{0}动点未到位！", SideAdjustCly.IOText), String.Format("{0} Action point warning！", SideAdjustCly.IOText), false);
                        if (DialogResult.OK == MessageBox.Show(SideAdjustCly.IOText + "动点异常！\n点击确认可继续运行.\nAction point warning!\npress OK can continue.", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            return true;
                        }
                        return false;
                    }
                }

            }
            else
            {
                while (!LeftSideAdjustClyOrg.IO64Power(io) || !RightSideAdjustClyOrg.IO64Power(io))
                {
                    ShowInfo.Delay(100);
                    time -= 100;
                    if (time <= 0)
                    {
                        Notify(String.Format("{0}原点未到位！", SideAdjustCly.IOText), String.Format("{0} Original point warning！", SideAdjustCly.IOText), false);
                        if (DialogResult.OK == MessageBox.Show(SideAdjustCly.IOText + "原点异常！\n点击确认可继续运行.\nOriginal point warning!\npress OK can continue.", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            return true;
                        }
                        return false;
                    }

                }
            }
            return true;
        }

        /// <summary>
        /// 升降气缸控制
        /// </summary>
        /// <param name="on_off">触发信号，true：动点动作，false:原点动作</param>
        /// <returns></returns>
        public bool CylAction_Lifter(bool on_off)
        {
            return CylAction(LifterCly, LifterClyOrg, LifterClyOn, on_off);
        }

        /// <summary>
        /// 平移气缸控制
        /// </summary>
        /// <param name="on_off">触发信号，true：动点动作，false:原点动作</param>
        /// <returns></returns>
        public bool CylAction_Forward(bool on_off)
        {
            return CylAction(ForwardCly, ForwardClyOrg, ForwardClyOn, on_off);
        }

        /// <summary>
        /// 夹子气缸控制
        /// </summary>
        /// <param name="on_off">触发信号，true：动点动作，false:原点动作</param>
        /// <returns></returns>
        public bool CylAction_Clamp(bool on_off)
        {
            return CylAction(ClampCly, ClampClyOrg, ClampClyOn, on_off);
        }

        /// <summary>
        /// 旋转气缸控制
        /// </summary>
        /// <param name="on_off">触发信号，true：动点动作，false:原点动作</param>
        /// <returns></returns>
        public bool CylAction_Rotate(bool on_off)
        {
            return CylAction(RotateCly, RotateClyOrg, RotateClyOn, on_off);
        }

        /// <summary>
        /// NG搬运气缸控制
        /// </summary>
        /// <param name="on_off">触发信号，true：动点动作，false:原点动作</param>
        /// <returns></returns>
        public bool CylAction_NGCarry(bool on_off)
        {
            return CylAction(NGCarryCly, NGCarryClyOrg, NGCarryClyOn, on_off);
        }

        /// <summary>
        /// 称重阻挡气缸
        /// </summary>
        /// <param name="on_off">触发信号，true：动点动作，false:原点动作</param>
        /// <returns></returns>
        public bool CylAction_Weighintercept(bool on_off)
        {
            return CylAction(WeighinterceptCly, WeighinterceptClyOrg, WeighinterceptClyOn, on_off);
        }

        /// <summary>
        /// 入料阻挡气缸
        /// </summary>
        /// <param name="on_off">触发信号，true：动点动作，false:原点动作</param>
        /// <returns></returns>
        public bool CylAction_Enterintercept(bool on_off)
        {
            return CylAction(EnterinterceptCly, EnterinterceptClyOrg, EnterinterceptClyOn, on_off);
        }

        #endregion

        #region 拉带控制

        /// <summary>
        /// D01拉带控制
        /// </summary>
        /// <param name="on_off">true：启动拉带/false：停止拉带</param>
        /// <returns></returns>
        public bool BeltConttol_D01(bool on_off)
        {
            D01Belt.IO64Power(io, on_off);
            if (D01AlarmSignal.IO64Power(io))
            {
                Notify("拉带一报警,运动失败!", "D01Belt warning,boot failed!", false);
                return false;
            }
            return true;
        }

        /// <summary>
        /// D02拉带控制
        /// </summary>
        /// <param name="on_off">true：启动拉带/false：停止拉带</param>
        /// <returns></returns>
        public bool BeltConttol_D02(bool on_off)
        {
            D02Belt.IO64Power(io, on_off);
            if (D02AlarmSignal.IO64Power(io))
            {
                Notify("拉带二报警,运动失败!", "D02Belt warning,boot failed!", false);
                return false;
            }
            return true;
        }

        /// <summary>
        /// D03拉带控制
        /// </summary>
        /// <param name="on_off">true：启动拉带/false：停止拉带</param>
        /// <returns></returns>
        public bool BeltConttol_D03(bool on_off)
        {
            D03Belt.IO64Power(io, on_off);
            if (D03AlarmSignal.IO64Power(io))
            {
                Notify("拉带三报警,运动失败!", "D03Belt warning,boot failed!", false);
                return false;
            }
            return true;
        }

        #endregion

        #endregion

        #region 单步动作

        /// <summary>
        /// PASS翻转
        /// </summary>
        /// <returns></returns>
        public bool TurnOverAction()
        {
            if (!CylAction_Clamp(false))
                return false;

            if (!CylAction_SideAdjust(true))
                return false;

            if (!CylAction_SideAdjust(false))
                return false;

            if (!CylAction_Lifter(true))
            {
                LifterCly.IO64Power(io, false);
                return false;
            }

            if (!CylAction_Forward(true))
            {
                ForwardCly.IO64Power(io, false);
                return false;
            }

            if (!CylAction_Clamp(true))
            {
                ClampCly.IO64Power(io, false);
                return false;
            }

            if (!CylAction_Lifter(false))
                return false;

            if (!RotateCly.IsOn(io))
            {
                if (!CylAction_Rotate(true))
                {
                    RotateCly.IO64Power(io, false);
                    return false;
                }
            }
            else
            {
                if (!CylAction_Rotate(false))
                {
                    RotateCly.IO64Power(io, true);
                    return false;
                }
            }

            if (!CylAction_Lifter(true))
            {
                LifterCly.IO64Power(io, false);
                return false;
            }

            if (!CylAction_Clamp(false))
                return false;

            if (!CylAction_SideAdjust(true))
                return false;

            if (!CylAction_SideAdjust(false))
                return false;

            if (!CylAction_Forward(false))
                return false;

            if (!CylAction_Lifter(false))
                return false;

            ClampCly.IO64Power(io, true);

            //if (!CylAction_Rotate(false))
            //    return false;

            return true;
        }

        /// <summary>
        /// NG搬运
        /// </summary>
        /// <returns></returns>
        public bool NGAction()
        {
            if (!CylAction_Clamp(false))
                return false;

            if (!CylAction_SideAdjust(true))
                return false;

            if (!CylAction_SideAdjust(false))
                return false;

            if (!CylAction_Lifter(true))
            {
                LifterCly.IO64Power(io, false);
                return false;
            }

            if (!CylAction_Forward(true))
            {
                ForwardCly.IO64Power(io, false);
                return false;
            }

            if (!CylAction_Clamp(true))
            {
                ClampCly.IO64Power(io, false);
                return false;
            }

            if (!CylAction_Lifter(false))
                return false;

            if (!CylAction_NGCarry(true))
            {
                NGCarryCly.IO64Power(io, false);
                return false;
            }

            if (!CylAction_Lifter(true))
            {
                LifterCly.IO64Power(io, false);
                return false;
            }

            if (!CylAction_Clamp(false))
                return false;

            if (!CylAction_Forward(false))
                return false;

            if (!CylAction_Lifter(false))
                return false;

            if (!CylAction_NGCarry(false))
                return false;

            ClampCly.IO64Power(io, true);

            return true;
        }

        #endregion
    }
}

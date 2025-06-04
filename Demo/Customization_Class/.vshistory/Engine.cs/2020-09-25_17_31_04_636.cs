using HelperCmd;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine
{
    partial class DeviceMain
    {
        #region 参数设置

        public enum StationStatus : int
        {
            Wait, Running, Finish, Reset, Resetting, Pause, Init, Exception, Stop
        }

        public static Boolean StopButton = false;
        public static Boolean ResetButton = false;
        public static Boolean RunButton = false;

        public Int64 BoxCount = 0;

        public String CircleTime = string.Format("0:0:0");
        public String CircleTime_D01 = "0.000";
        private Stopwatch CT_D01 = new Stopwatch();
        public String CircleTime_D02 = "0.000";
        private Stopwatch CT_D02 = new Stopwatch();
        public String CircleTime_D03 = "0.000";
        private Stopwatch CT_D03 = new Stopwatch();
        public Stopwatch UPHwatch = new Stopwatch();
        public Stopwatch CT = new Stopwatch();

        public StationStatus Status_D01 = StationStatus.Init;
        public StationStatus BufferStatus_D01 = StationStatus.Pause;
        public StationStatus Status_D02 = StationStatus.Init;
        public StationStatus BufferStatus_D02 = StationStatus.Pause;
        public StationStatus Status_D03 = StationStatus.Init;
        public StationStatus BufferStatus_D03 = StationStatus.Pause;

        private Boolean station_getready_input = false;
        private Boolean station_getready_output = false;
        private Boolean buffer_D01_Enb = false;
        private Boolean buffer_D01_Dir = false;
        private Boolean buffer_D01_Run = false;
        private Boolean buffer_D02_Enb = false;
        private Boolean buffer_D02_Dir = false;
        private Boolean buffer_D02_Run = false;
        private Boolean buffer_D03_Enb = false;
        private Boolean buffer_D03_Dir = false;
        private Boolean buffer_D03_Run = false;
        private Boolean Signal_D01_Clear = false;
        private Boolean Signal_D02_Clear = false;

        private Thread Thread_D01_Engine { get; set; }
        private Thread Thread_D02_Engine { get; set; }
        private Thread Thread_D03_Engine { get; set; }
        private Thread Thread_Machine_Engine { get; set; }
        private Thread Thread_NG_Engine { get; set; }
        private Thread Thread_SafeGuard_Engine { get; set; }

        #endregion

        #region Stop停止

        public void Stop_Machine()
        {
            Task D01 = new Task(new Action(() =>
            {
                Stop_D01();
            }));
            Task D02 = new Task(new Action(() =>
            {
                Stop_D02();
            }));
            Task D03 = new Task(new Action(() =>
            {
                Stop_D03();
            }));
            D01.Start();
            D02.Start();
            D03.Start();
            while (!D01.IsCompleted || !D02.IsCompleted || !D03.IsCompleted)
            {
                ShowInfo.Delay(1);
            }
            Notify("设备停止!", "Device Stop!", NotifyType.Action);
            if ((int)Status_D01 == 8 && (int)Status_D02 == 8 && (int)Status_D03 == 8)
            {
                TowerAction(true, false, false, false);
            }
            ShowInfo.Delay(800);
        }

        public void Stop_D01()
        {
            Status_D01 = StationStatus.Stop;
            try
            {
                if (Thread_D01_Engine.IsAlive) Thread_D01_Engine.Abort();
            }
            catch
            {
                if (Thread_D01_Engine.IsAlive) Thread_D01_Engine.Abort();
            }
            Station_GetReady_Input.IO64Power(ioc, false);
            BeltAction(Belt_D01_Run, true, false, false, false);
            Notify("入料段:停止!", "D01:Stop!", NotifyType.Action);
            if ((int)Status_D02 < 3 || (int)Status_D03 < 3)
            {
                TowerAction(true, true, false);
            }
            else
            {
                TowerAction(true, false, false);
            }
        }

        public void Stop_D02()
        {
            Status_D02 = StationStatus.Stop;
            try
            {
                if (Thread_D02_Engine.IsAlive) Thread_D02_Engine.Abort();
            }
            catch
            {
                if (Thread_D02_Engine.IsAlive) Thread_D02_Engine.Abort();
            }
            BeltAction(Belt_D02_Run, true, false, false, false);
            Notify("检测段:停止!", "D02:Stop!", NotifyType.Action);
            CCD_D02_Running = false;
            if ((int)Status_D01 < 3 || (int)Status_D03 < 3)
            {
                TowerAction(true, true, false);
            }
            else
            {
                TowerAction(true, false, false);
            }
        }

        public void Stop_D03()
        {
            Status_D03 = StationStatus.Stop;
            try
            {
                if (Thread_D03_Engine.IsAlive) Thread_D03_Engine.Abort();
            }
            catch
            {
                if (Thread_D03_Engine.IsAlive) Thread_D03_Engine.Abort();
            }
            Station_GetReady_Output.IO64Power(ioc, false);
            BeltAction(Belt_D03_Run, true, false, false, false);
            Notify("翻转段:停止!", "D03:Stop!", NotifyType.Action);
            CCD_D03_Running = false;
            if ((int)Status_D01 < 3 || (int)Status_D02 < 3)
            {
                TowerAction(true, true, false);
            }
            else
            {
                TowerAction(true, false, false);
            }
        }

        #endregion

        #region Reset复位

        public void Reset_Machine()
        {
            if ((int)Status_D01 > 5 || (int)Status_D02 > 5 || (int)Status_D03 > 5)
            {
                Notify("设备开始复位!", "Device Resetting!", NotifyType.Action);
                Task D01 = new Task(new Action(() =>
                {
                    Reset_D01();
                }));
                Task D02 = new Task(new Action(() =>
                {
                    Reset_D02();
                }));
                Task D03 = new Task(new Action(() =>
                {
                    Reset_D03();
                }));
                D01.Start();
                D02.Start();
                D03.Start();
                while (!D01.IsCompleted || !D02.IsCompleted || !D03.IsCompleted)
                {
                    ShowInfo.Delay(1);
                }
                if ((int)Status_D01 < 4 && (int)Status_D02 < 4 && (int)Status_D03 < 4)
                {
                    TowerAction(false, true, true, false);
                    Notify("设备复位完成!", "Device Reset success!");
                }
            }
            else
            {
                Notify("设备状态错误,无法整机复位!", "Device status is warn,can not Reset machine!", NotifyType.Warn);
            }
            ShowInfo.Delay(800);
        }

        public bool Reset_D01()
        {
            if ((int)Status_D01 > 5)
            {
                if (Signal_D01_Enter.IO64Power(ioc))
                {
                    Notify("入料段:彩盒未取出!禁止复位", "D01:Box is not exit!forbid Reset", NotifyType.Warn);
                    return false;
                }
                Notify("入料段:开始复位.", "D01:Resetting......", NotifyType.Action);
                TowerAction(true, true, false, false);
                Status_D01 = StationStatus.Resetting;
                dataserver.StationLoc[0] = new DataBit();
                if (!CylAction(Cyl_D01Intercept, false))
                {
                    Exception_D01();
                    Notify("入料段:复位失败!", "D01:Reset fail!", NotifyType.Warn);
                    return false;
                }
                if (!BeltAction(Belt_D01_Run, false, false, false))
                {
                    Exception_D01();
                    Notify("入料段:复位失败!", "D01:Reset fail!", NotifyType.Warn);
                    return false;
                }
                Status_D01 = StationStatus.Reset;
                Notify("入料段:复位完成.", "D01:Reset done.", NotifyType.Action);
                if ((int)Status_D01 < 4 && (int)Status_D02 < 4 && (int)Status_D03 < 4)
                {
                    TowerAction(false, true, true, false);
                }
            }
            else
            {
                if ((int)Status_D01 > 2 || (int)Status_D02 > 2 || (int)Status_D03 > 2)
                {
                    Notify("入料段:状态错误!", "D01:Status error!", NotifyType.Warn);
                    return false;
                }
            }
            return true;
        }

        public bool Reset_D02()
        {
            if ((int)Status_D02 > 5)
            {
                Cyl_D02Weigh.IO64Power(ioc, false);
                if (Signal_D02_Enter.IO64Power(ioc))
                {
                    Notify("检测段:彩盒未取出!禁止复位", "D02:Box is not exit!forbid Reset", NotifyType.Warn);
                    return false;
                }
                Notify("检测段:开始复位.", "D02:Resetting......", NotifyType.Action);
                TowerAction(true, true, false, false);
                Status_D02 = StationStatus.Resetting;
                dataserver.StationLoc[1] = new DataBit();
                if (!CylContinuousAction(false, true, Cyl_D02Intercept, Cyl_D02Weigh))
                {
                    Exception_D02();
                    Notify("检测段:复位失败!", "D02:Reset fail!", NotifyType.Warn);
                    return false;
                }
                if (!BeltAction(Belt_D02_Run, false, false, false))
                {
                    Exception_D02();
                    Notify("检测段:复位失败!", "D02:Reset fail!", NotifyType.Warn);
                    return false;
                }
                Status_D02 = StationStatus.Reset;
                Notify("检测段:复位完成.", "D02:Reset done.", NotifyType.Action);
                if ((int)Status_D01 < 4 && (int)Status_D02 < 4 && (int)Status_D03 < 4)
                {
                    TowerAction(false, true, true, false);
                }
            }
            else
            {
                if ((int)Status_D01 > 2 || (int)Status_D02 > 2 || (int)Status_D03 > 2)
                {
                    Notify("检测段:状态错误!", "D03:Status error!", NotifyType.Warn);
                    return false;
                }
            }
            return true;
        }

        public bool Reset_D03()
        {
            if ((int)Status_D03 > 5)
            {
                if (Signal_D03_Enter.IO64Power(ioc))
                {
                    Notify("翻转段:彩盒未取出!禁止复位", "D03:Box is not exit!forbid Reset", NotifyType.Warn);
                    return false;
                }
                Notify("翻转段:开始复位.", "D03:Resetting......", NotifyType.Action);
                TowerAction(true, true, false, false);
                Status_D03 = StationStatus.Resetting;
                dataserver.StationLoc[2] = new DataBit();
                if (!CylActionDoubleSignal(Cyl_D03Adjust, false))
                {
                    Exception_D03();
                    Notify("翻转段:复位失败!", "D03:Reset fail!", NotifyType.Warn);
                    return false;
                }
                if (!CylContinuousAction(false, true, Cyl_D03Clamp, Cyl_D03Forward, Cyl_D03Lifter, Cyl_D03Carry, Cyl_D03Rotate))
                {
                    Exception_D03();
                    Notify("翻转段:复位失败!", "D03:Reset fail!", NotifyType.Warn);
                    return false;
                }
                if (!BeltAction(Belt_D03_Run, false, false, false))
                {
                    Exception_D03();
                    Notify("翻转段:复位失败!", "D03:Reset fail!", NotifyType.Warn);
                    return false;
                }
                Status_D03 = StationStatus.Reset;
                Notify("翻转段:复位完成.", "D03:Reset done.", NotifyType.Action);
                if ((int)Status_D01 < 4 && (int)Status_D02 < 4 && (int)Status_D03 < 4)
                {
                    TowerAction(false, true, true, false);
                }
            }
            else
            {
                if ((int)Status_D01 > 2 || (int)Status_D02 > 2 || (int)Status_D03 > 2)
                {
                    Notify("翻转段:状态错误!", "D03:Status error!", NotifyType.Warn);
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Run启动

        public void Run_Machine()
        {
            Task D01 = new Task(new Action(() =>
            {
                Run_D01();
            }));
            Task D02 = new Task(new Action(() =>
            {
                Run_D02();
            }));
            Task D03 = new Task(new Action(() =>
            {
                Run_D03();
            }));
            D01.Start();
            D02.Start();
            D03.Start();
            while (!D01.IsCompleted || !D02.IsCompleted || !D03.IsCompleted)
            {
                ShowInfo.Delay(1);
            }
            if ((int)Status_D01 < 3 && (int)Status_D02 < 3 && (int)Status_D03 < 3)
            {
                UPHwatch.Restart();
                TowerAction(false, false, true, false);
                Notify("设备启动!", "Device Running!", NotifyType.Action);
            }
            ShowInfo.Delay(800);
        }

        public bool Run_D01()
        {
            if ((int)Status_D01 == 3)
            {
                if (!CylAction(Cyl_D01Intercept, true))
                {
                    Exception_D01();
                    Notify("入料段:启动失败!", "D01:Run fail!", NotifyType.Warn);
                    return false;
                }
                Status_D01 = StationStatus.Wait;
                if (!BeltAction(Belt_D01_Run, false, false, true))
                {
                    Exception_D01();
                    Notify("入料段:启动失败!", "D01:Run fail!", NotifyType.Warn);
                    return false;
                }
                Thread_D01_Engine = new Thread(Engine_D01) { IsBackground = true };
                Thread_D01_Engine.Start();
                if ((int)mac.Runmod == 0) Station_GetReady_Input.IO64Power(ioc, true);
                else if ((int)mac.Runmod == 1 && mac.Communication) Station_GetReady_Input.IO64Power(ioc, true);
                if ((int)Status_D01 < 3 && (int)Status_D02 < 3 && (int)Status_D03 < 3) TowerAction(false, false, true, false);
                Notify("入料段:设备启动!", "D01:Device Running!", NotifyType.Action);
            }
            else if ((int)Status_D01 == 5)
            {
                Status_D01 = BufferStatus_D01;
                BeltAction(Belt_D01_Run, buffer_D01_Enb, buffer_D01_Dir, buffer_D01_Run);
                Station_GetReady_Input.IO64Power(ioc, station_getready_input);
                Notify("入料段:继续!", "D01:Continue", NotifyType.Action);
            }
            else
            {
                if ((int)Status_D01 > 3 || (int)Status_D02 > 3 || (int)Status_D03 > 3)
                {
                    Notify("入料段:状态错误!", "D01:Status error!", NotifyType.Warn);
                    return false;
                }
            }
            return true;
        }

        public bool Run_D02()
        {
            if ((int)Status_D02 == 3)
            {
                if (!CylAction(Cyl_D02Intercept, true))
                {
                    Exception_D02();
                    Notify("检测段:启动失败!", "D02:Run fail!", NotifyType.Warn);
                    return false;
                }
                Status_D02 = StationStatus.Wait;
                if (!BeltAction(Belt_D02_Run, false, false, true))
                {
                    Exception_D02();
                    Notify("检测段:启动失败!", "D02:Run fail!", NotifyType.Warn);
                    return false;
                }
                Thread_D02_Engine = new Thread(Engine_D02) { IsBackground = true };
                Thread_D02_Engine.Start();
                if ((int)Status_D01 < 3 && (int)Status_D02 < 3 && (int)Status_D03 < 3) TowerAction(false, false, true, false);
                Notify("检测段:设备启动!", "D02:Device Running!", NotifyType.Action);
            }
            else if ((int)Status_D02 == 5)
            {
                Status_D02 = BufferStatus_D02;
                BeltAction(Belt_D02_Run, buffer_D02_Enb, buffer_D02_Dir, buffer_D02_Run);
                Notify("检测段:继续!", "D02:Continue", NotifyType.Action);
            }
            else
            {
                if ((int)Status_D01 > 3 || (int)Status_D02 > 3 || (int)Status_D03 > 3)
                {
                    Notify("检测段:状态错误!", "D02:Status error!", NotifyType.Warn);
                    return false;
                }
            }
            return true;
        }

        public bool Run_D03()
        {
            if ((int)Status_D03 == 3)
            {
                CylAction(Cyl_D03Clamp, true);
                if (!CylAction(Cyl_D03Lifter, true))
                {
                    Exception_D03();
                    return false;
                }
                Status_D03 = StationStatus.Wait;
                if (!BeltAction(Belt_D03_Run, false, false, true))
                {
                    Exception_D03();
                    Notify("翻转段:启动失败!", "D03:Run fail!", NotifyType.Warn);
                    return false;
                }
                Thread_D03_Engine = new Thread(Engine_D03) { IsBackground = true };
                Thread_D03_Engine.Start();
                Station_GetReady_Output.IO64Power(ioc, false);
                if ((int)Status_D01 < 3 && (int)Status_D02 < 3 && (int)Status_D03 < 3) TowerAction(false, false, true, false);
                Notify("翻转段:设备启动!", "D03:Device Running!", NotifyType.Action);
            }
            else if ((int)Status_D03 == 5)
            {
                Status_D03 = BufferStatus_D03;
                BeltAction(Belt_D03_Run, buffer_D03_Enb, buffer_D03_Dir, buffer_D03_Run);
                Station_GetReady_Output.IO64Power(ioc, station_getready_output);
                Notify("翻转段:继续!", "D03:Continue", NotifyType.Action);
            }
            else
            {
                if ((int)Status_D01 > 3 || (int)Status_D02 > 3 || (int)Status_D03 > 3)
                {
                    Notify("翻转段:状态错误!", "D03:Status error!", NotifyType.Warn);
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Pause暂停

        public void Pause_D01()
        {
            Notify("入料段:暂停!", "D01:Pause", NotifyType.Action);
            buffer_D01_Enb = Belt_D01_Enable.IsOn(ioc);
            buffer_D01_Dir = Belt_D01_Direction.IsOn(ioc);
            buffer_D01_Run = Belt_D01_Run.IsOn(ioc);
            station_getready_input = Station_GetReady_Input.IsOn(ioc);
            Station_GetReady_Input.IO64Power(ioc, false);
            BeltAction(Belt_D01_Run, false, false, false);
            while ((int)Status_D01 == 5) ShowInfo.Delay(1);
        }

        public void Pause_D02()
        {
            Notify("检测段:暂停!", "D02:Pause", NotifyType.Action);
            buffer_D02_Enb = Belt_D02_Enable.IsOn(ioc);
            buffer_D02_Dir = Belt_D02_Direction.IsOn(ioc);
            buffer_D02_Run = Belt_D02_Run.IsOn(ioc);
            BeltAction(Belt_D02_Run, false, false, false);
            while ((int)Status_D02 == 5) ShowInfo.Delay(1);
        }

        public void Pause_D03()
        {
            Notify("翻转:暂停!", "D03:Pause", NotifyType.Action);
            buffer_D03_Enb = Belt_D03_Enable.IsOn(ioc);
            buffer_D03_Dir = Belt_D03_Direction.IsOn(ioc);
            buffer_D03_Run = Belt_D03_Run.IsOn(ioc);
            station_getready_output = Station_GetReady_Output.IsOn(ioc);
            Station_GetReady_Output.IO64Power(ioc, false);
            BeltAction(Belt_D03_Run, false, false, false);
            while ((int)Status_D03 == 5) ShowInfo.Delay(1);
        }

        #endregion

        #region Init初始化

        public bool Init_Machine()
        {
            Init_D01();
            Init_D02();
            Init_D03();
            Thread_Machine_Engine = new Thread(Engine_Machine) { IsBackground = true };
            Thread_NG_Engine = new Thread(Engine_NGSignal) { IsBackground = true };
            Thread_SafeGuard_Engine = new Thread(Engine_SafeGuard) { IsBackground = true };
            Thread_Machine_Engine.Start();
            Thread_NG_Engine.Start();
            Thread_SafeGuard_Engine.Start();
            return true;
        }

        private bool Init_D01()
        {
            Thread_D01_Engine = new Thread(Engine_D01) { IsBackground = true };
            Status_D01 = StationStatus.Init;
            return true;
        }

        private bool Init_D02()
        {
            Thread_D02_Engine = new Thread(Engine_D02) { IsBackground = true };
            Status_D02 = StationStatus.Init;
            return true;
        }

        private bool Init_D03()
        {
            Thread_D03_Engine = new Thread(Engine_D03) { IsBackground = true };
            Status_D03 = StationStatus.Init;
            return true;
        }

        #endregion

        #region Exception异常处理

        public void Exception_D01()
        {
            Status_D01 = StationStatus.Exception;
            Station_GetReady_Input.IO64Power(ioc, false);
            BeltAction(Belt_D01_Run, true, false, false, false);
            TowerAction(false, true, false, true);
            Notify("入料段:动作异常,停止!", "D01:Action exception,Stop!", NotifyType.Error);
        }

        public void Exception_D02()
        {
            Status_D02 = StationStatus.Exception;
            BeltAction(Belt_D02_Run, true, false, false, false);
            TowerAction(false, true, false, true);
            Notify("检测段:动作异常,停止!", "D02:Action exception,Stop!", NotifyType.Error);
        }

        public void Exception_D03()
        {
            Status_D03 = StationStatus.Exception;
            Station_GetReady_Output.IO64Power(ioc, false);
            BeltAction(Belt_D03_Run, true, false, false, false);
            TowerAction(false, true, false, true);
            Notify("翻转段:动作异常,停止!", "D03:Action exception,Stop!", NotifyType.Error);
        }

        #endregion

        #region Engine引擎

        public void Engine_Machine()
        {
            Thread Machine_Stop = new Thread(Stop_Machine) { IsBackground = true };
            Thread Machine_Reset = new Thread(Reset_Machine) { IsBackground = true };
            Thread Machine_Run = new Thread(Run_Machine) { IsBackground = true };
            while (true)
            {
                if (Signal_EMG.IO64Power(ioc))
                {
                    Notify("设备急停!", "Device is EMG!", NotifyType.Warn);
                    if (!Machine_Stop.IsAlive)
                    {
                        Machine_Stop = new Thread(Stop_Machine) { IsBackground = true };
                        Machine_Stop.Start();
                    }
                    while (Signal_EMG.IO64Power(ioc))
                    {
                        Status_D01 = StationStatus.Stop;
                        Status_D02 = StationStatus.Stop;
                        Status_D03 = StationStatus.Stop;
                        TowerAction(true, false, false, true);
                        ShowInfo.Delay(250);
                        TowerAction(false, false, false, false);
                        ShowInfo.Delay(250);
                    }
                    TowerAction(true, false, false, false);
                    Notify("释放急停!", "EMG is loosen!", NotifyType.Warn);
                }
                else if (Signal_Stop.IO64Power(ioc) || StopButton)
                {
                    StopButton = false;
                    if (Machine_Reset.IsAlive || Machine_Run.IsAlive) continue;
                    if (!Machine_Stop.IsAlive)
                    {
                        Machine_Stop = new Thread(Stop_Machine) { IsBackground = true };
                        Machine_Stop.Start();
                    }
                }
                else if (Signal_Reset.IO64Power(ioc) || ResetButton)
                {
                    ResetButton = false;
                    if (Machine_Stop.IsAlive || Machine_Run.IsAlive) continue;
                    if (!Machine_Reset.IsAlive)
                    {
                        Machine_Reset = new Thread(Reset_Machine) { IsBackground = true };
                        Machine_Reset.Start();
                    }
                }
                else if (Signal_Run.IO64Power(ioc) || RunButton)
                {
                    RunButton = false;
                    if (Machine_Stop.IsAlive || Machine_Reset.IsAlive) continue;
                    if (!Machine_Run.IsAlive)
                    {
                        Machine_Run = new Thread(Run_Machine) { IsBackground = true };
                        Machine_Run.Start();
                    }
                }
                ShowInfo.Delay(1);
            }
        }

        public void Engine_D01()
        {
            while ((int)Status_D01 < 3 || (int)Status_D01 == 5)
            {
                if ((int)Status_D01 == 0)
                {
                    if (Signal_D01_Enter.IO64Power(ioc) || (int)mac.Runmod == 2)
                    {
                        if ((int)mac.Runmod == 0) Station_GetReady_Input.IO64Power(ioc, false);
                        else if ((int)mac.Runmod == 1 && mac.Communication) Station_GetReady_Input.IO64Power(ioc, false);
                        if ((int)mac.Runmod == 2) ShowInfo.Delay(1000);
                        CT_D01.Restart();
                        ShowInfo.Delay(mac.Delay_D01);
                        if (!BeltAction(Belt_D01_Run, false, false, false))
                        {
                            Exception_D01();
                            break;
                        }
                        dataserver.StationLoc[0].MachineMod = mac.Runmod;
                        dataserver.StationLoc[0].StartTime = DateTime.Now;
                        Notify("入料段:开始动作", "D01:Action", NotifyType.Action);
                        Status_D01 = StationStatus.Running;
                    }
                }
                else if ((int)Status_D01 == 1)
                {
                    if (!CylAction(Cyl_D01Intercept, false))
                    {
                        Exception_D01();
                        break;
                    }
                    if ((int)Status_D01 == 5) Pause_D01();
                    dataserver.StationLoc[0].PhoneType = mac.Product;
                    if (!string.IsNullOrEmpty(snc.Lock_DSN) && LockDSNEnable) dataserver.StationLoc[0].DSN = snc.Lock_DSN;
                    else dataserver.StationLoc[0].DSN = ScannerDSN(dataserver.StationLoc[0].MachineMod, mac.SNLength, snc.Length);
                    snc.Lock_DSN = string.Empty;
                    if ((int)dataserver.StationLoc[0].MachineMod == 0)
                    {
                        dataserver.StationLoc[0].Check_D01 = dataserver.StationLoc[0].DSNCheck = D01Check(dataserver.StationLoc[0].DSN);
                    }
                    if ((int)Status_D01 == 5) Pause_D01();
                    Status_D01 = StationStatus.Finish;
                }
                else if ((int)Status_D01 == 2)
                {
                    if (Status_D02 == 0)
                    {
                        CT_D01.Stop();
                        CircleTime_D01 = MsgSelect(string.Format("{0}毫秒", CT_D01.ElapsedMilliseconds), string.Format("{0} ms", CT_D01.ElapsedMilliseconds));
                        dataserver.StationLoc[0].CircleTime += CT_D01.ElapsedMilliseconds;
                        dataserver.StationLoc[0].CircleTime_D01 = CT_D01.ElapsedMilliseconds;
                        int Runmod = (int)dataserver.StationLoc[0].MachineMod;
                        dataserver.DataMove(0, 1, new string[] { "入料段", "D01" }, new string[] { "检测段", "D02" }, Language);
                        if (!BeltAction(Belt_D01_Run, false, false, true))
                        {
                            Exception_D01();
                            break;
                        }
                        if (Runmod == 0 && mac.Switch_D01)
                        {
                            Signal_D01_Clear = false;
                            bool Exception = false;
                            Stopwatch overtime = new Stopwatch();
                            overtime.Start();
                            while (!Signal_D01_Clear)
                            {
                                if (overtime.ElapsedMilliseconds > mac.ClearOverTime)
                                {
                                    overtime.Stop();
                                    Exception = true;
                                    break;
                                }
                                ShowInfo.Delay(1);
                            }
                            if (Exception)
                            {
                                Notify("入料段:彩盒移动失败!", "D01:Box move fail!", NotifyType.Warn);
                                Exception_D01();
                                break;
                            }
                        }
                        else
                        {
                            ShowInfo.Delay(mac.Delay_D01_ClearStatus);
                            if (Signal_D01_Enter.IO64Power(ioc))
                            {
                                Notify("入料段:彩盒移动失败!", "D01:Box move fail!", NotifyType.Warn);
                                Exception_D01();
                                break;
                            }
                        }
                        if ((int)mac.Runmod == 0) Station_GetReady_Input.IO64Power(ioc, true);
                        else if ((int)mac.Runmod == 1 && mac.Communication) Station_GetReady_Input.IO64Power(ioc, true);
                        DeviceMain.Notify("入料段:彩盒流出", "D01:Box outflow", NotifyType.Action);
                        if (!CylAction(Cyl_D01Intercept, true))
                        {
                            Exception_D01();
                            break;
                        }
                        Status_D01 = StationStatus.Wait;
                    }
                }
                else if ((int)Status_D01 == 5)
                {
                    Pause_D01();
                }
                ShowInfo.Delay(1);
            }
        }

        public void Engine_D02()
        {
            while ((int)Status_D02 < 3 || (int)Status_D02 == 5)
            {
                if ((int)Status_D02 == 0)
                {
                    if (Signal_D02_Enter.IO64Power(ioc) || (int)dataserver.StationLoc[1].MachineMod == 2)
                    {
                        if ((int)dataserver.StationLoc[1].MachineMod == 0) Signal_D01_Clear = true;
                        else if ((int)dataserver.StationLoc[1].MachineMod == 2) ShowInfo.Delay(1000);
                        CT_D02.Restart();
                        ShowInfo.Delay(mac.Delay_D02);
                        if (!BeltAction(Belt_D02_Run, false, false, false))
                        {
                            Exception_D02();
                            break;
                        }
                        Notify("检测段:开始动作", "D02:Action", NotifyType.Action);
                        Status_D02 = StationStatus.Running;
                    }
                }
                else if ((int)Status_D02 == 1)
                {
                    if (!CylAction(Cyl_D02Intercept, false))
                    {
                        Exception_D02();
                        break;
                    }
                    if ((int)Status_D02 == 5) Pause_D02();
                    if ((int)dataserver.StationLoc[1].MachineMod == 0)
                    {
                        if (dataserver.StationLoc[1].Check_D01)
                        {
                            if (dataserver.StationLoc[1].DataUpload.Equals(0))
                            {
                                if (!CylAction(Cyl_D02Weigh, true))
                                {
                                    Exception_D02();
                                    break;
                                }
                                if ((int)Status_D02 == 5) Pause_D02();
                                ShowInfo.Delay(mac.Delay_D02_Weigh);
                                dataserver.StationLoc[1].Check_D02 = D02Check();
                            }
                            else
                            {
                                dataserver.StationLoc[1].Check_D02 = true;
                            }
                        }
                    }
                    else
                    {
                        if (!CylAction(Cyl_D02Weigh, true))
                        {
                            Exception_D02();
                            break;
                        }
                        if ((int)Status_D02 == 5) Pause_D02();
                        if (mac.CCDTest)
                        {
                            CCDTest_D02();
                        }
                        else
                        {
                            ShowInfo.Delay(6000);
                        }
                        string weight = ScalseWeight();
                        try
                        {
                            if (!string.IsNullOrEmpty(weight))
                                dataserver.StationLoc[1].Weight = Convert.ToDouble(weight);
                            else
                                dataserver.StationLoc[1].Weight = 0;
                        }
                        catch
                        {
                            dataserver.StationLoc[1].Weight = 0;
                        }
                    }
                    dataserver.StationLoc[1].Standard = wec.Standard;
                    if (!CylAction(Cyl_D02Weigh, false))
                    {
                        Exception_D02();
                        break;
                    }
                    if ((int)Status_D02 == 5) Pause_D02();
                    Status_D02 = StationStatus.Finish;
                }
                else if ((int)Status_D02 == 2)
                {
                    if (Status_D03 == 0)
                    {
                        CT_D02.Stop();
                        CircleTime_D02 = MsgSelect(string.Format("{0}毫秒", CT_D02.ElapsedMilliseconds), string.Format("{0} ms", CT_D02.ElapsedMilliseconds));
                        dataserver.StationLoc[1].CircleTime += CT_D02.ElapsedMilliseconds;
                        dataserver.StationLoc[1].CircleTime_D02 = CT_D02.ElapsedMilliseconds;
                        int Runmod = (int)dataserver.StationLoc[1].MachineMod;
                        dataserver.DataMove(1, 2, new string[] { "检测段", "D02" }, new string[] { "翻转段", "D03" }, Language);
                        if (!BeltAction(Belt_D02_Run, false, false, true))
                        {
                            Exception_D02();
                            break;
                        }
                        if (Runmod == 0 && mac.Switch_D02)
                        {
                            Signal_D02_Clear = false;
                            bool Exception = false;
                            Stopwatch overtime = new Stopwatch();
                            overtime.Start();
                            while (!Signal_D02_Clear)
                            {
                                if (overtime.ElapsedMilliseconds > mac.ClearOverTime)
                                {
                                    overtime.Stop();
                                    Exception = true;
                                    break;
                                }
                                ShowInfo.Delay(1);
                            }
                            if (Exception)
                            {
                                Notify("检测段:彩盒移动失败!", "D02:Box move fail!", NotifyType.Warn);
                                Exception_D02();
                                break;
                            }
                        }
                        else
                        {
                            ShowInfo.Delay(mac.Delay_D02_ClearStatus);
                            if (Signal_D02_Enter.IO64Power(ioc))
                            {
                                Notify("检测段:彩盒移动失败!", "D02:Box move fail!", NotifyType.Warn);
                                Exception_D02();
                                break;
                            }
                        }
                        DeviceMain.Notify("检测段:彩盒流出", "D02:Box outflow", NotifyType.Action);
                        if (!CylAction(Cyl_D02Intercept, true))
                        {
                            Exception_D02();
                            break;
                        }
                        Status_D02 = StationStatus.Wait;
                    }
                }
                else if ((int)Status_D02 == 5)
                {
                    Pause_D02();
                }
                ShowInfo.Delay(1);
            }
        }

        public void Engine_D03()
        {
            while ((int)Status_D03 < 3 || (int)Status_D03 == 5)
            {
                if ((int)Status_D03 == 0)
                {
                    if (Signal_D03_Enter.IO64Power(ioc) || (int)dataserver.StationLoc[2].MachineMod == 2)
                    {
                        if ((int)dataserver.StationLoc[2].MachineMod == 0) Signal_D02_Clear = true;
                        else if ((int)dataserver.StationLoc[2].MachineMod == 2) ShowInfo.Delay(1000);
                        CT_D03.Restart();
                        ShowInfo.Delay(mac.Delay_D03);
                        if (!BeltAction(Belt_D03_Run, false, false, false))
                        {
                            Exception_D03();
                            break;
                        }
                        Notify("翻转段:开始动作", "D03:Action", NotifyType.Action);
                        Status_D03 = StationStatus.Running;
                    }
                }
                else if ((int)Status_D03 == 1)
                {
                    bool CheckFail = false;
                    bool OOBE = false;
                Clamp_Action:
                    if (!CylActionDoubleSignal(Cyl_D03Adjust, true))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylActionDoubleSignal(Cyl_D03Adjust, false))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if ((int)dataserver.StationLoc[2].MachineMod == 0 && !CheckFail && dataserver.StationLoc[2].Check_D02 && dataserver.StationLoc[2].DataUpload < 3 && !dataserver.StationLoc[2].HaveBOB)
                    {
                        dataserver.StationLoc[2].Check_D03 = UpLoadPass(dataserver.StationLoc[2].DSN, out OOBE);
                        if (!dataserver.StationLoc[2].Check_D03)
                        {
                            if (!OOBE)
                            {
                                CheckFail = true;
                            }
                        }
                        else
                        {
                            if (dataserver.StationLoc[2].Closure.Equals("N"))
                            {
                                if (!CylAction(Cyl_D03Lifter, false))
                                {
                                    Exception_D03();
                                    break;
                                }
                                if ((int)Status_D03 == 5) Pause_D03();
                                while (!Station_Next_Ready.IO64Power(ioc)) ShowInfo.Delay(1);
                                Station_NotPaste.IO64Power(ioc, !dataserver.StationLoc[2].NeedPaste);
                                Station_LabelType.IO64Power(ioc, dataserver.StationLoc[2].LabelType);
                                Station_SKUChange.IO64Power(ioc, dataserver.StationLoc[2].SkuChange);
                                Station_GetReady_Output.IO64Power(ioc, dataserver.StationLoc[2].Check_D03);
                                BoxCount++;
                                toc.PassCount++;
                                goto Action_Finish;
                            }
                        }
                    }
                    if (!CylAction(Cyl_D03Clamp, false))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylAction(Cyl_D03Lifter, true))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylAction(Cyl_D03Forward, true))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylAction(Cyl_D03Clamp, true))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylAction(Cyl_D03Lifter, false))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (CheckFail && !OOBE && dataserver.StationLoc[2].HaveBOB)
                    {
                        if (!CylAction(Cyl_D03Rotate, !Cyl_D03Rotate.IsOn(ioc)))
                        {
                            Exception_D03();
                            break;
                        }
                        if ((int)Status_D03 == 5) Pause_D03();
                    }
                    if ((int)dataserver.StationLoc[2].MachineMod == 0)
                    {
                        if (!CheckFail)
                        {
                            if (dataserver.StationLoc[2].Check_D02)
                            {
                                if (dataserver.StationLoc[2].DataUpload < 3)
                                {
                                    if (OOBE)
                                    {
                                        if (!CylAction(Cyl_D03Rotate, !Cyl_D03Rotate.IsOn(ioc)))
                                        {
                                            Exception_D03();
                                            break;
                                        }
                                        if ((int)Status_D03 == 5) Pause_D03();
                                        goto NG_Action;
                                    }
                                    goto PASS_Action;
                                }
                                else
                                {
                                    if (!CylAction(Cyl_D03Rotate, !Cyl_D03Rotate.IsOn(ioc)))
                                    {
                                        Exception_D03();
                                        break;
                                    }
                                    if ((int)Status_D03 == 5) Pause_D03();
                                    Notify(string.Format("翻转段:->{0}!", mac.OOBEStationName), string.Format("D03:->{0}!", mac.OOBEStationName), NotifyType.Warn);
                                    dataserver.StationLoc[2].Message = MsgSelect(string.Format("下一站:{0}", mac.OOBEStationName), string.Format("Next Station:{0}", mac.OOBEStationName));
                                    goto NG_Action;
                                }
                            }
                            else goto NG_Action;
                        }
                        else
                        {
                            goto NG_Action;
                        }
                    }
                    else if ((int)dataserver.StationLoc[2].MachineMod == 1)
                    {
                        if (mac.WeighTest)
                        {
                            bool test = WeightTest(dataserver.StationLoc[2].Weight);
                            if (test) goto PASS_Action;
                            else goto NG_Action;
                        }
                        if ((int)mac.Debugmod == 0) goto PASS_Action;
                        else if ((int)mac.Debugmod == 1) goto NG_Action;
                        else
                        {
                            int rd = new Random().Next(0, 2);
                            if (rd == 0) goto PASS_Action;
                            else goto NG_Action;
                        }
                    }
                    else
                    {
                        if ((int)mac.Debugmod == 0) goto PASS_Action;
                        else if ((int)mac.Debugmod == 1) goto NG_Action;
                        else
                        {
                            int rd = new Random().Next(0, 2);
                            if (rd == 0) goto PASS_Action;
                            else goto NG_Action;
                        }
                    }
                #region PASS_Action
                PASS_Action:
                    if (!CylAction(Cyl_D03Rotate, !Cyl_D03Rotate.IsOn(ioc)))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylAction(Cyl_D03Lifter, true))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylAction(Cyl_D03Clamp, false))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylActionDoubleSignal(Cyl_D03Adjust, true))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    Thread CCD = new Thread(D03Check) { IsBackground = true };
                    CCD.Start();
                    if (!CylAction(Cyl_D03Forward, false))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylAction(Cyl_D03Lifter, false))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    Cyl_D03Clamp.IO64Power(ioc, true);
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylActionDoubleSignal(Cyl_D03Adjust, false))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    while (CCD.IsAlive)
                    {
                        if ((int)Status_D03 == 5) Pause_D03();
                        ShowInfo.Delay(1);
                    }
                    if ((int)dataserver.StationLoc[2].MachineMod == 0)
                    {
                        if (!dataserver.StationLoc[2].Check_D03)
                        {
                            CheckFail = true;
                            //NGBox = true;
                            goto Clamp_Action;
                        }
                        if (dataserver.StationLoc[2].HaveBOB)
                        {
                            dataserver.StationLoc[2].Check_D03 = UpLoadPass(dataserver.StationLoc[2].DSN, out OOBE);
                            if (!dataserver.StationLoc[2].Check_D03)
                            {
                                CheckFail = true;
                                //NGBox = true;
                                goto Clamp_Action;
                            }
                        }
                        while (!Station_Next_Ready.IO64Power(ioc)) ShowInfo.Delay(1);
                        Station_NotPaste.IO64Power(ioc, !dataserver.StationLoc[2].NeedPaste);
                        Station_LabelType.IO64Power(ioc, dataserver.StationLoc[2].LabelType);
                        Station_SKUChange.IO64Power(ioc, dataserver.StationLoc[2].SkuChange);
                        Station_GetReady_Output.IO64Power(ioc, dataserver.StationLoc[2].Check_D03);
                    }
                    else if ((int)dataserver.StationLoc[2].MachineMod == 1 && mac.Communication)
                    {
                        while (!Station_Next_Ready.IO64Power(ioc)) ShowInfo.Delay(1);
                        Station_NotPaste.IO64Power(ioc, mac.NotNeedPaste);
                        Station_LabelType.IO64Power(ioc, mac.LargeLabel);
                        Station_SKUChange.IO64Power(ioc, mac.SkuChange);
                        Station_GetReady_Output.IO64Power(ioc, true);
                    }
                    BoxCount++;
                    toc.PassCount++;
                    goto Action_Finish;
                #endregion
                #region NG_Action
                NG_Action:
                    if (Signal_NG_Second.IO64Power(ioc))
                    {
                        Notify("NG工位:NG彩盒未取出!", "NG Station:The NG box is not exit!", NotifyType.Warn);
                    }
                    while (Signal_NG_Second.IO64Power(ioc))
                    {
                        Beacon_Buzzer.IO64Power(ioc, true);
                        ShowInfo.Delay(130);
                        Beacon_Buzzer.IO64Power(ioc, false);
                        ShowInfo.Delay(130);
                    }
                    if (dataserver.StationLoc[2].IMEIAbnormal)
                    {
                        string response = string.Empty;
                        http_D02.UploadPass(dataserver.StationLoc[2].DSN, SwitchDataToFail("IM01"), out response);
                        dataserver.StationLoc[2].Message = string.Format("NG UpLoad:{0}",response);
                    }
                    if (!CylAction(Cyl_D03Carry, true))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylAction(Cyl_D03Lifter, true))
                    {
                        Exception_D03();
                        break;
                    }
                    new Task(new Action(() =>
                    {
                        new FormMsgBox(this, dataserver.StationLoc[2].DSN, dataserver.StationLoc[2].Message, mac.Tip_OverTime).ShowDialog();
                    })).Start();
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylAction(Cyl_D03Clamp, false))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylAction(Cyl_D03Forward, false))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylAction(Cyl_D03Lifter, false))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    CylAction(Cyl_D03Clamp, true);
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (!CylAction(Cyl_D03Carry, false))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    if (dataserver.StationLoc[2].DataUpload != 3)
                    {
                        if (!dataserver.StationLoc[2].Closure.Equals("O")) toc.NgCount++;
                        else
                        {
                            BoxCount++;
                            toc.PassCount++;
                        }
                    }
                    goto Action_Finish;
                #endregion
                #region Action_Finish
                Action_Finish:
                    toc.BoxCount = toc.PassCount + toc.NgCount;
                    if (toc.BoxCount > 30000)
                    {
                        toc.PassCount = 0;
                        toc.NgCount = 0;
                    }
                    try
                    {
                        toc.PassRate = (Double)toc.PassCount / (Double)toc.BoxCount;
                    }
                    catch
                    {
                        toc.PassRate = 0.0;
                    }
                    toc.Save(ConfigPath(2, toc), toc);
                    Status_D03 = StationStatus.Finish;
                    #endregion
                }
                else if ((int)Status_D03 == 2)
                {
                    CT_D03.Stop();
                    CircleTime_D03 = MsgSelect(string.Format("{0}毫秒", CT_D03.ElapsedMilliseconds), string.Format("{0} ms", CT_D03.ElapsedMilliseconds));
                    dataserver.StationLoc[2].CircleTime += CT_D03.ElapsedMilliseconds;
                    dataserver.StationLoc[2].CircleTime_D03 = CT_D03.ElapsedMilliseconds;
                    dataserver.StationLoc[2].CircleTime_Output = CT.ElapsedMilliseconds;
                    dataserver.StationLoc[2].EndTime = DateTime.Now;
                    dataserver.StationLoc[2].DataSave();
                    int mod = (int)dataserver.StationLoc[2].MachineMod;
                    bool Check_D03 = dataserver.StationLoc[2].Check_D03;
                    dataserver.StationLoc[2] = new DataBit();
                    CircleTime = string.Format("{0}", CT.Elapsed);
                    CT.Restart();
                    if (!BeltAction(Belt_D03_Run, false, false, true))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)mod == 1 && !mac.Communication) ShowInfo.Delay(mac.Delay_D03_ClearStatus);
                    else if ((int)mod == 2) ShowInfo.Delay(mac.Delay_D03_ClearStatus);
                    else while (!Station_Next_GetBox.IO64Power(ioc) && Check_D03) ShowInfo.Delay(1);
                    Station_GetReady_Output.IO64Power(ioc, false);
                    Station_NotPaste.IO64Power(ioc, false);
                    Station_LabelType.IO64Power(ioc, false);
                    Station_SKUChange.IO64Power(ioc, false);
                    if (Signal_D03_Enter.IO64Power(ioc))
                    {
                        Notify("翻转段:彩盒移动失败!", "D03:Box move fail!", NotifyType.Warn);
                        Exception_D03();
                        break;
                    }
                    DeviceMain.Notify("翻转段:彩盒流出", "D03:Box outflow", NotifyType.Action);
                    if (!CylAction(Cyl_D03Lifter, true))
                    {
                        Exception_D03();
                        break;
                    }
                    if ((int)Status_D03 == 5) Pause_D03();
                    Status_D03 = StationStatus.Wait;
                }
                else if ((int)Status_D03 == 5)
                {
                    Pause_D03();
                }
                ShowInfo.Delay(1);
            }
        }

        public void Engine_NGSignal()
        {
            while (true)
            {
                if ((int)Status_D03 < 3)
                {
                    if (Signal_NG_First.IO64Power(ioc))
                    {
                        bool NGtrigger = false;
                        Stopwatch outrime = new Stopwatch();
                        outrime.Start();
                        while (Signal_NG_First.IO64Power(ioc))
                        {
                            if (outrime.ElapsedMilliseconds > mac.NGOutTime * 1000 && !NGtrigger)
                            {
                                Notify("NG触发!请取走NG料!", "NG trigger,please take the NG box!", NotifyType.Error);
                                NGtrigger = true;
                                outrime.Stop();
                            }
                            if (NGtrigger)
                            {
                                Beacon_Buzzer.IO64Power(ioc, true);
                                ShowInfo.Delay(300);
                                Beacon_Buzzer.IO64Power(ioc, false);
                                ShowInfo.Delay(300);
                            }
                            if ((int)Status_D03 >= 3) break;
                            ShowInfo.Delay(1);
                        }
                        outrime.Stop();
                    }
                }
                ShowInfo.Delay(1);
            }
        }

        public void Engine_SafeGuard()
        {
            while (true)
            {
                if (mac.SafeGuardEnable)
                {
                    if (Signal_SafeGuard.IO64Power(ioc))
                    {
                        Notify("门禁触发!", "SafeGuard is trigger", NotifyType.Warn);
                        while (Signal_SafeGuard.IO64Power(ioc))
                        {
                            if ((int)Status_D01 < 3)
                            {
                                BufferStatus_D01 = Status_D01;
                                Status_D01 = StationStatus.Pause;
                            }
                            if ((int)Status_D02 < 3)
                            {
                                BufferStatus_D02 = Status_D02;
                                Status_D02 = StationStatus.Pause;
                            }
                            if ((int)Status_D03 < 3)
                            {
                                BufferStatus_D03 = Status_D03;
                                Status_D03 = StationStatus.Pause;
                            }
                            TowerAction(false, true, false, true);
                            if (!mac.SafeGuardEnable) break;
                            ShowInfo.Delay(1);
                        }
                        Notify("门禁释放!", "SafeGuard is release", NotifyType.Warn);
                        Beacon_Buzzer.IO64Power(ioc, false);
                    }
                }
                ShowInfo.Delay(1);
            }
        }

        #endregion

        #region VirtualAction虚拟动作

        public bool VirtualAction_D01()
        {
            if (((int)Status_D01 == 3 || (int)Status_D01 == 6) && !Signal_D01_Enter.IO64Power(ioc))
            {
                Status_D01 = StationStatus.Init;
                if (!CylAction(Cyl_D01Intercept, true))
                {
                    Exception_D01();
                    return false;
                }
                if (!BeltAction(Belt_D01_Run, false, false, true))
                {
                    Exception_D01();
                    return false;
                }
                while (!Signal_D01_Enter.IO64Power(ioc))
                {
                    ShowInfo.Delay(1);
                }
                ShowInfo.Delay(mac.Delay_D01);
                if (!BeltAction(Belt_D01_Run, false, false, false))
                {
                    Exception_D01();
                    return false;
                }
                if (!CylAction(Cyl_D01Intercept, false))
                {
                    Exception_D01();
                    return false;
                }
            }
            else
            {
                Notify("状态错误,虚拟动作启动失败!", "Status wrong,Virtual action fail!", NotifyType.Warn);
            }
            return true;
        }

        public bool VirtualAction_D02()
        {
            if (((int)Status_D02 == 3 || (int)Status_D02 == 6) && !Signal_D02_Enter.IO64Power(ioc))
            {
                Status_D02 = StationStatus.Init;
                if (!CylAction(Cyl_D02Intercept, true))
                {
                    Exception_D02();
                    return false;
                }
                if (!BeltAction(Belt_D02_Run, false, false, true))
                {
                    Exception_D02();
                    return false;
                }
                while (!Signal_D02_Enter.IO64Power(ioc))
                {
                    ShowInfo.Delay(1);
                }
                ShowInfo.Delay(mac.Delay_D02);
                if (!BeltAction(Belt_D02_Run, false, false, false))
                {
                    Exception_D02();
                    return false;
                }
                if (!CylAction(Cyl_D02Intercept, false))
                {
                    Exception_D02();
                    return false;
                }
            }
            else
            {
                Notify("状态错误,虚拟动作启动失败!", "Status wrong,Virtual action fail!", NotifyType.Warn);
            }
            return true;
        }

        public bool VirtualAction_D03()
        {
            if (((int)Status_D03 == 3 || (int)Status_D03 == 6) && !Signal_D03_Enter.IO64Power(ioc))
            {
                Status_D03 = StationStatus.Init;
                if (!BeltAction(Belt_D03_Run, false, false, true))
                {
                    Exception_D03();
                    return false;
                }
                while (!Signal_D03_Enter.IO64Power(ioc))
                {
                    ShowInfo.Delay(1);
                }
                ShowInfo.Delay(mac.Delay_D03);
                if (!BeltAction(Belt_D03_Run, false, false, false))
                {
                    Exception_D03();
                    return false;
                }
                if (!CylActionDoubleSignal(Cyl_D03Adjust, true))
                {
                    Exception_D03();
                    return false;
                }
                if (!CylActionDoubleSignal(Cyl_D03Adjust, false))
                {
                    Exception_D03();
                    return false;
                }
            }
            else
            {
                Notify("状态错误,虚拟动作启动失败!", "Status wrong,Virtual action fail!", NotifyType.Warn);
            }
            return true;
        }

        #endregion
    }
}

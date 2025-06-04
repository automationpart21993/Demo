using HelperCmd;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine
{
    partial class DeviceMain
    {
        #region IO

        public Output Cyl_D01Intercept { get; set; }
        public Output Cyl_D02Intercept { get; set; }
        public Output Cyl_D02Weigh { get; set; }
        public Output Cyl_D03Adjust { get; set; }
        public Output Cyl_D03Clamp { get; set; }
        public Output Cyl_D03Rotate { get; set; }
        public Output Cyl_D03Forward { get; set; }
        public Output Cyl_D03Lifter { get; set; }
        public Output Cyl_D03Carry { get; set; }

        public Input Cyl_D01Intercept_Org { get; set; }
        public Input Cyl_D01Intercept_On { get; set; }
        public Input Cyl_D02Intercept_Org { get; set; }
        public Input Cyl_D02Intercept_On { get; set; }
        public Input Cyl_D02Weigh_Org { get; set; }
        public Input Cyl_D02Weigh_On { get; set; }
        public Input Cyl_D03Adjust_Left_Org { get; set; }
        public Input Cyl_D03Adjust_Left_On { get; set; }
        public Input Cyl_D03Adjust_Right_Org { get; set; }
        public Input Cyl_D03Adjust_Right_On { get; set; }
        public Input Cyl_D03Clamp_Org { get; set; }
        public Input Cyl_D03Clamp_On { get; set; }
        public Input Cyl_D03Rotate_Org { get; set; }
        public Input Cyl_D03Rotate_On { get; set; }
        public Input Cyl_D03Forward_Org { get; set; }
        public Input Cyl_D03Forward_On { get; set; }
        public Input Cyl_D03Lifter_Org { get; set; }
        public Input Cyl_D03Lifter_On { get; set; }
        public Input Cyl_D03Carry_Org { get; set; }
        public Input Cyl_D03Carry_On { get; set; }

        public Output Belt_D01_Enable { get; set; }
        public Output Belt_D01_Direction { get; set; }
        public Output Belt_D01_Run { get; set; }
        public Input Belt_D01_Alarm { get; set; }
        public Output Belt_D02_Enable { get; set; }
        public Output Belt_D02_Direction { get; set; }
        public Output Belt_D02_Run { get; set; }
        public Input Belt_D02_Alarm { get; set; }
        public Output Belt_D03_Enable { get; set; }
        public Output Belt_D03_Direction { get; set; }
        public Output Belt_D03_Run { get; set; }
        public Input Belt_D03_Alarm { get; set; }

        public Input Signal_D01_Enter { get; set; }
        public Input Signal_D02_Enter { get; set; }
        public Input Signal_D03_Enter { get; set; }
        public Input Signal_NG_First { get; set; }
        public Input Signal_NG_Second { get; set; }

        public Input Signal_EMG { get; set; }
        public Input Signal_Reset { get; set; }
        public Input Signal_Run { get; set; }
        public Input Signal_Stop { get; set; }
        public Input Signal_SafeGuard { get; set; }
        public Output Beacon_Lamp_Red { get; set; }
        public Output Beacon_Lamp_Yellow { get; set; }
        public Output Beacon_Lamp_Green { get; set; }
        public Output Beacon_Buzzer { get; set; }

        public Input Station_Next_Ready { get; set; }
        public Input Station_Next_GetBox { get; set; }
        public Output Station_GetReady_Input { get; set; }
        public Output Station_GetReady_Output { get; set; }
        public Output Station_NotPaste { get; set; }
        public Output Station_LabelType { get; set; }
        public Output Station_SKUChange { get; set; }

        #endregion

        /// <summary>
        /// 气缸动作
        /// </summary>
        /// <param name="Cylinder">气缸</param>
        /// <param name="Action">True(动点)/False(原点)</param>
        /// <param name="CheckPoint">是否检查磁性开关</param>
        /// <param name="OutTime">检查磁性开关超时</param>
        /// <returns></returns>
        public bool CylAction(Output Cylinder, bool Action, bool CheckPoint = true, int OutTime = 3000)
        {
            Stopwatch overtime = new Stopwatch();
            Cylinder.IO64Power(ioc, Action);
            overtime.Start();
            if (CheckPoint)
            {
                if (Action)
                {
                    Input On = (Input)GetType().GetProperty(string.Format("{0}_On", Cylinder.IOName)).GetValue(this);
                    while (!On.IO64Power(ioc))
                    {
                        if (overtime.ElapsedMilliseconds > OutTime)
                        {
                            Beacon_Buzzer.IO64Power(ioc, true);
                            Notify(string.Format("气缸动点动作失败!\n气缸:{0}-点位:[{1}]\n动点:[{2}]-点位:[{3}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, On.IOText, On.Value), string.Format("Cylinder action fail!\nCylinder:[{0}]-Point:[{1}]\nOnpoint:[{2}]-Point:[{3}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, On.IOText, On.Value), NotifyType.Warn);
                            if (DialogResult.Yes == MsgShow(string.Format("气缸动点动作失败!\n气缸:[{0}]-点位:[{1}]\n动点:[{2}]-点位:[{3}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, On.IOText, On.Value), string.Format("Cylinder action fail!\nCylinder:[{0}]-Point:[{1}]\nOnpoint:[{2}]-Point:[{3}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, On.IOText, On.Value), "警告", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                            {
                                Beacon_Buzzer.IO64Power(ioc, false);
                                Notify("动作继续!", "Action continue!");
                                return true;
                            }
                            return false;
                        }
                        ShowInfo.Delay(10);
                    }
                }
                else
                {
                    Input Org = (Input)GetType().GetProperty(string.Format("{0}_Org", Cylinder.IOName)).GetValue(this);
                    while (!Org.IO64Power(ioc))
                    {
                        if (overtime.ElapsedMilliseconds > OutTime)
                        {
                            Beacon_Buzzer.IO64Power(ioc, true);
                            Notify(string.Format("气缸原点动作失败!\n气缸:[{0}]-点位:[{1}]\n原点:[{2}]-点位:[{3}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, Org.IOText, Org.Value), string.Format("Cylinder origin fail!\nCylinder:[{0}]-Point:[{1}]\nOrgpoint:[{2}]-Point:[{3}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, Org.IOText, Org.Value), NotifyType.Warn);
                            if (DialogResult.Yes == MsgShow(string.Format("气缸原点动作失败!\n气缸:[{0}]-点位:[{1}]\n原点:[{2}]-点位:[{3}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, Org.IOText, Org.Value), string.Format("Cylinder origin fail!\nCylinder:[{0}]-Point:[{1}]\nOrgpoint:[{2}]-Point:[{3}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, Org.IOText, Org.Value), "警告", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                            {
                                Beacon_Buzzer.IO64Power(ioc, false);
                                Notify("动作继续!", "Action continue!");
                                return true;
                            }
                            return false;
                        }
                        ShowInfo.Delay(10);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 多气缸连续动作
        /// </summary>
        /// <param name="Action">True(动点)/False(原点)</param>
        /// <param name="CheckPoint">是否检查磁性开关</param>
        /// <param name="Cylinder">气缸</param>
        /// <returns></returns>
        public bool CylContinuousAction(bool Action, bool CheckPoint, params Output[] Cylinder)
        {
            foreach (Output Cyl in Cylinder)
            {
                if (!CylAction(Cyl, Action, CheckPoint)) return false;
            }
            return true;
        }

        /// <summary>
        /// 双信号气缸动作
        /// </summary>
        /// <param name="Cylinder">气缸</param>
        /// <param name="Action">True(动点)/False(原点)</param>
        /// <param name="CheckPoint">是否检查磁性开关</param>
        /// <param name="OutTime">检查磁性开关超时</param>
        /// <returns></returns>
        public bool CylActionDoubleSignal(Output Cylinder, bool Action, bool CheckPoint = true, int OutTime = 3000)
        {
            Stopwatch overtime = new Stopwatch();
            Cylinder.IO64Power(ioc, Action);
            overtime.Start();
            if (CheckPoint)
            {
                if (Action)
                {
                    Input LeftOn = (Input)GetType().GetProperty(string.Format("{0}_Left_On", Cylinder.IOName)).GetValue(this);
                    Input RightOn = (Input)GetType().GetProperty(string.Format("{0}_Right_On", Cylinder.IOName)).GetValue(this);
                    while (!LeftOn.IO64Power(ioc) || !RightOn.IO64Power(ioc))
                    {
                        if (overtime.ElapsedMilliseconds > OutTime)
                        {
                            if (!LeftOn.IO64Power(ioc) && !RightOn.IO64Power(ioc))
                            {
                                Beacon_Buzzer.IO64Power(ioc, true);
                                Notify(string.Format("气缸动点动作失败!\n气缸:{0}-点位:[{1}]\n动点:[{2}][{3}]-点位:[{4}][{5}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, LeftOn.IOText, RightOn.IOText, LeftOn.Value, RightOn.Value), string.Format("Cylinder action fail!\nCylinder:[{0}]-Point:[{1}]\nOnpoint:[{2}][{3}]-Point:[{4}][{5}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, LeftOn.IOText, RightOn.IOText, LeftOn.Value, RightOn.Value), NotifyType.Warn);
                                if (DialogResult.Yes == MsgShow(string.Format("气缸动点动作失败!\n气缸:{0}-点位:[{1}]\n动点:[{2}][{3}]-点位:[{4}][{5}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, LeftOn.IOText, RightOn.IOText, LeftOn.Value, RightOn.Value), string.Format("Cylinder action fail!\nCylinder:[{0}]-Point:[{1}]\nOnpoint:[{2}][{3}]-Point:[{4}][{5}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, LeftOn.IOText, RightOn.IOText, LeftOn.Value, RightOn.Value), "警告", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                                {
                                    Beacon_Buzzer.IO64Power(ioc, false);
                                    Notify("动作继续!", "Action continue!");
                                    return true;
                                }
                                return false;
                            }
                            else if (!LeftOn.IO64Power(ioc))
                            {
                                Beacon_Buzzer.IO64Power(ioc, true);
                                Notify(string.Format("气缸动点动作失败!\n气缸:{0}-点位:[{1}]\n动点:[{2}]-点位:[{3}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, LeftOn.IOText, LeftOn.Value), string.Format("Cylinder action fail!\nCylinder:[{0}]-Point:[{1}]\nOnpoint:[{2}]-Point:[{3}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, LeftOn.IOText, LeftOn.Value), NotifyType.Warn);
                                if (DialogResult.Yes == MsgShow(string.Format("气缸动点动作失败!\n气缸:[{0}]-点位:[{1}]\n动点:[{2}]-点位:[{3}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, LeftOn.IOText, LeftOn.Value), string.Format("Cylinder action fail!\nCylinder:[{0}]-Point:[{1}]\nOnpoint:[{2}]-Point:[{3}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, LeftOn.IOText, LeftOn.Value), "警告", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                                {
                                    Beacon_Buzzer.IO64Power(ioc, false);
                                    Notify("动作继续!", "Action continue!");
                                    return true;
                                }
                                return false;
                            }
                            else if (!RightOn.IO64Power(ioc))
                            {
                                Beacon_Buzzer.IO64Power(ioc, true);
                                Notify(string.Format("气缸动点动作失败!\n气缸:{0}-点位:[{1}]\n动点:[{2}]-点位:[{3}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, RightOn.IOText, RightOn.Value), string.Format("Cylinder action fail!\nCylinder:[{0}]-Point:[{1}]\nOnpoint:[{2}]-Point:[{3}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, RightOn.IOText, RightOn.Value), NotifyType.Warn);
                                if (DialogResult.Yes == MsgShow(string.Format("气缸动点动作失败!\n气缸:[{0}]-点位:[{1}]\n动点:[{2}]-点位:[{3}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, RightOn.IOText, RightOn.Value), string.Format("Cylinder action fail!\nCylinder:[{0}]-Point:[{1}]\nOnpoint:[{2}]-Point:[{3}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, RightOn.IOText, RightOn.Value), "警告", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                                {
                                    Beacon_Buzzer.IO64Power(ioc, false);
                                    Notify("动作继续!", "Action continue!");
                                    return true;
                                }
                                return false;
                            }
                        }
                        ShowInfo.Delay(10);
                    }
                }
                else
                {
                    Input LeftOrg = (Input)GetType().GetProperty(string.Format("{0}_Left_Org", Cylinder.IOName)).GetValue(this);
                    Input RightOrg = (Input)GetType().GetProperty(string.Format("{0}_Right_Org", Cylinder.IOName)).GetValue(this);
                    while (!LeftOrg.IO64Power(ioc) || !RightOrg.IO64Power(ioc))
                    {
                        if (overtime.ElapsedMilliseconds > OutTime)
                        {
                            if (!LeftOrg.IO64Power(ioc) && !RightOrg.IO64Power(ioc))
                            {
                                Beacon_Buzzer.IO64Power(ioc, true);
                                Notify(string.Format("气缸原点动作失败!\n气缸:[{0}]-点位:[{1}]\n原点:[{2}][{3}]-点位:[{4}][{5}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, LeftOrg.IOText, RightOrg.IOText, LeftOrg.Value, RightOrg.Value), string.Format("Cylinder origin fail!\nCylinder:[{0}]-Point:[{1}]\nOrgpoint:[{2}][{3}]-Point:[{4}][{5}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, LeftOrg.IOText, RightOrg.IOText, LeftOrg.Value, RightOrg.Value), NotifyType.Warn);
                                if (DialogResult.Yes == MsgShow(string.Format("气缸原点动作失败!\n气缸:[{0}]-点位:[{1}]\n原点:[{2}][{3}]-点位:[{4}][{5}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, LeftOrg.IOText, RightOrg.IOText, LeftOrg.Value, RightOrg.Value), string.Format("Cylinder origin fail!\nCylinder:[{0}]-Point:[{1}]\nOrgpoint:[{2}][{3}]-Point:[{4}][{5}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, LeftOrg.IOText, RightOrg.IOText, LeftOrg.Value, RightOrg.Value), "警告", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                                {
                                    Beacon_Buzzer.IO64Power(ioc, false);
                                    Notify("动作继续!", "Action continue!");
                                    return true;
                                }
                                return false;
                            }
                            else if (!LeftOrg.IO64Power(ioc))
                            {
                                Beacon_Buzzer.IO64Power(ioc, true);
                                Notify(string.Format("气缸原点动作失败!\n气缸:[{0}]-点位:[{1}]\n原点:[{2}]-点位:[{3}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, LeftOrg.IOText, LeftOrg.Value), string.Format("Cylinder origin fail!\nCylinder:[{0}]-Point:[{1}]\nOrgpoint:[{2}]-Point:[{3}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, LeftOrg.IOText, LeftOrg.Value), NotifyType.Warn);
                                if (DialogResult.Yes == MsgShow(string.Format("气缸原点动作失败!\n气缸:[{0}]-点位:[{1}]\n原点:[{2}]-点位:[{3}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, LeftOrg.IOText, LeftOrg.Value), string.Format("Cylinder origin fail!\nCylinder:[{0}]-Point:[{1}]\nOrgpoint:[{2}]-Point:[{3}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, LeftOrg.IOText, LeftOrg.Value), "警告", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                                {
                                    Beacon_Buzzer.IO64Power(ioc, false);
                                    Notify("动作继续!", "Action continue!");
                                    return true;
                                }
                                return false;
                            }
                            else if (!RightOrg.IO64Power(ioc))
                            {
                                Beacon_Buzzer.IO64Power(ioc, true);
                                Notify(string.Format("气缸原点动作失败!\n气缸:[{0}]-点位:[{1}]\n原点:[{2}]-点位:[{3}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, RightOrg.IOText, RightOrg.Value), string.Format("Cylinder origin fail!\nCylinder:[{0}]-Point:[{1}]\nOrgpoint:[{2}]-Point:[{3}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, RightOrg.IOText, RightOrg.Value), NotifyType.Warn);
                                if (DialogResult.Yes == MsgShow(string.Format("气缸原点动作失败!\n气缸:[{0}]-点位:[{1}]\n原点:[{2}]-点位:[{3}]\n是否继续动作?", Cylinder.IOText, Cylinder.Value, RightOrg.IOText, RightOrg.Value), string.Format("Cylinder origin fail!\nCylinder:[{0}]-Point:[{1}]\nOrgpoint:[{2}]-Point:[{3}]\ndo you want to continue?", Cylinder.IOText, Cylinder.Value, RightOrg.IOText, RightOrg.Value), "警告", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                                {
                                    Beacon_Buzzer.IO64Power(ioc, false);
                                    Notify("动作继续!", "Action continue!");
                                    return true;
                                }
                                return false;
                            }

                        }
                        ShowInfo.Delay(10);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 拉带运动
        /// </summary>
        /// <param name="Belt">拉带</param>
        /// <param name="Enable">True(关闭使能)/False(开启使能)</param>
        /// <param name="Dir">True(正向)/False(反向)</param>
        /// <param name="Run">True(启动)/False(停止)</param>
        /// <param name="Alarm">是否检查报警</param>
        /// <returns></returns>
        public bool BeltAction(Output Belt, bool Enable, bool Dir, bool Run, bool Alarm = true)
        {
            Belt.IO64Power(ioc, false);
            string BeltName = Belt.IOName.Substring(0, Belt.IOName.LastIndexOf('_'));
            Output enable = (Output)GetType().GetProperty(string.Format("{0}_Enable", BeltName)).GetValue(this);
            Output dir = (Output)GetType().GetProperty(string.Format("{0}_Direction", BeltName)).GetValue(this);
            Input alarm = (Input)GetType().GetProperty(string.Format("{0}_Alarm", BeltName)).GetValue(this);
            enable.IO64Power(ioc, Enable);
            dir.IO64Power(ioc, Dir);
            Belt.IO64Power(ioc, Run);
            if (Alarm)
            {
                if (alarm.IO64Power(ioc))
                {
                    Notify(string.Format("拉带:[{0}]动作失败!", BeltName), string.Format("Belt:[{0}] action fail!", BeltName), NotifyType.Warn);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 拉带连续动作
        /// </summary>
        /// <param name="Enable">True(关闭使能)/False(开启使能)</param>
        /// <param name="Dir">True(正向)/False(反向)</param>
        /// <param name="Run">True(启动)/False(停止)</param>
        /// <param name="Alarm">是否检查报警</param>
        /// <param name="Belt">拉带</param>
        /// <returns></returns>
        public bool BeltContinuousAction(bool Enable, bool Dir, bool Run, bool Alarm, params Output[] Belt)
        {
            foreach (Output belt in Belt)
            {
                if (!BeltAction(belt, Enable, Dir, Run, Alarm)) return false;
            }
            return true;
        }

        /// <summary>
        /// 灯塔控制
        /// </summary>
        /// <param name="Lamp_Red">红灯</param>
        /// <param name="Lamp_Yellow">黄灯</param>
        /// <param name="Lamp_Green">绿灯</param>
        /// <param name="Buzzer">蜂鸣器</param>
        public void TowerAction(bool Lamp_Red, bool Lamp_Yellow, bool Lamp_Green, bool Buzzer)
        {
            Beacon_Lamp_Red.IO64Power(ioc, Lamp_Red);
            Beacon_Lamp_Yellow.IO64Power(ioc, Lamp_Yellow);
            Beacon_Lamp_Green.IO64Power(ioc, Lamp_Green);
            Beacon_Buzzer.IO64Power(ioc, Buzzer);
        }

        /// <summary>
        /// 灯塔控制
        /// </summary>
        /// <param name="Lamp_Red">红灯</param>
        /// <param name="Lamp_Yellow">黄灯</param>
        /// <param name="Lamp_Green">绿灯</param>
        public void TowerAction(bool Lamp_Red, bool Lamp_Yellow, bool Lamp_Green)
        {
            Beacon_Lamp_Red.IO64Power(ioc, Lamp_Red);
            Beacon_Lamp_Yellow.IO64Power(ioc, Lamp_Yellow);
            Beacon_Lamp_Green.IO64Power(ioc, Lamp_Green);
        }

        /// <summary>
        /// PASS翻转动作
        /// </summary>
        /// <returns></returns>
        public bool PASSAction()
        {
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
            if (!CylAction(Cyl_D03Clamp, false))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Lifter, true))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Forward, true))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Clamp, true))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Lifter, false))
            {
                Exception_D03();
                return false;
            }
            if (Cyl_D03Rotate.IsOn(ioc))
            {
                if (!CylAction(Cyl_D03Rotate, false))
                {
                    Exception_D03();
                    return false;
                }
            }
            else
            {
                if (!CylAction(Cyl_D03Rotate, true))
                {
                    Exception_D03();
                    return false;
                }
            }
            if (!CylAction(Cyl_D03Lifter, true))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Clamp, false))
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
            if (!CylAction(Cyl_D03Forward, false))
            {
                Exception_D03();
                return false;
            }
            Cyl_D03Clamp.IO64Power(ioc, true);
            if (!CylAction(Cyl_D03Lifter, false))
            {
                Exception_D03();
                return false;
            }
            return true;
        }

        /// <summary>
        /// NG夹取动作
        /// </summary>
        /// <returns></returns>
        public bool NGAction()
        {
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
            if (!CylAction(Cyl_D03Clamp, false))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Lifter, true))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Forward, true))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Clamp, true))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Lifter, false))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Carry, true))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Lifter, true))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Clamp, false))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Forward, false))
            {
                Exception_D03();
                return false;
            }
            Cyl_D03Clamp.IO64Power(ioc, true);
            if (!CylAction(Cyl_D03Lifter, false))
            {
                Exception_D03();
                return false;
            }
            if (!CylAction(Cyl_D03Carry, false))
            {
                Exception_D03();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 输出点位初始化
        /// </summary>
        public void OutputInit()
        {
            BeltContinuousAction(true, false, false, false, Belt_D01_Run, Belt_D02_Run, Belt_D03_Run);
            Station_GetReady_Input.IO64Power(ioc, false);
            Station_GetReady_Output.IO64Power(ioc, false);
        }
    }
}

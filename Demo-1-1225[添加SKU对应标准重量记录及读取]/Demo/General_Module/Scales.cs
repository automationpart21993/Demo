using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine
{
    public class Scales
    {
        #region 电子秤设置参数

        private Stopwatch ScalesOverTime = new Stopwatch();//用于接收数据计时
        private SerialPort scales = new SerialPort();
        private StringBuilder ScalesReceiveBuffer = new StringBuilder();
        public string ScalesResults { get { return Scalesresults; } }
        protected string Scalesresults = string.Empty;
        private bool ScalesIsReceving = false;

        #endregion

        #region 电子秤连接

        /// <summary>
        /// 电子称初始化
        /// </summary>
        /// <returns></returns>
        public bool IniScales(string ProtName,int BanudRate,int DataBits,Parity Parity,StopBits StopBits)
        {
            try
            {
                scales.PortName = ProtName;
                scales.BaudRate = BanudRate;
                scales.DataBits = DataBits;
                scales.Parity = Parity;
                scales.StopBits = StopBits;
                this.scales.DataReceived += new SerialDataReceivedEventHandler(ScalesReceive);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 开启电子称
        /// </summary>
        /// <returns></returns>
        public bool ScalesOpen()
        {
            try
            {
                //根据当前串口对象，来判断操作
                if (scales.IsOpen)
                {
                    //打开时点击，则关闭串口
                    scales.Close();
                }
                if (!scales.IsOpen)
                {
                    scales.Open();
                }
            }
            catch (Exception ex)
            {
                DeviceMain.MsgShow(string.Format("电子秤端口打开失败:{0}", ex.Message), string.Format("Scales open port fail:{0}", ex.Message), "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 关闭电子称
        /// </summary>
        /// <returns></returns>
        public bool ScalesClose()
        {
            try
            {
                if (scales.IsOpen)
                {
                    scales.Close();
                }
            }
            catch (Exception ex)
            {
                DeviceMain.Notify(string.Format("电子秤异常:{0}", ex.Message), string.Format("Scales exception:{0}", ex.Message), NotifyType.Warn);
                return false;
            }
            return true;
        }

        #endregion

        #region 电子秤触发及数据接收

        /// <summary>
        /// 触发电子称
        /// </summary>
        /// <returns></returns>
        public bool ScalesTrigger(int OverTime)
        {
            try
            {
                //清除状态
                ScalesIsReceving = false;
                ScalesReceiveBuffer.Clear();
                // _results.Clear();
                Scalesresults = string.Empty;
                scales.DiscardInBuffer();

                byte[] send = new byte[2] { 0x1B, 0x70 };
                scales.Write(send, 0, send.Length);
                //等待接收完数据
                ScalesOverTime.Restart();
                while (!ScalesIsReceving)
                {
                    if (ScalesOverTime.ElapsedMilliseconds > OverTime * 1000)
                    {
                        DeviceMain.Notify(string.Format("电子秤触发超时:{0}秒", OverTime), string.Format("Scales trigger is out time:{0} Sec", OverTime), NotifyType.Warn);
                        return false;
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                DeviceMain.Notify(string.Format("电子秤异常:{0}", ex.Message), string.Format("Scales exception:{0}", ex.Message), NotifyType.Warn);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScalesReceive(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(100);
                byte[] _data = new byte[scales.BytesToRead];
                scales.Read(_data, 0, _data.Length);
                Scalesresults = ScalesReceiveBuffer.Append(Encoding.ASCII.GetString(_data)).ToString();
                ScalesReceiveBuffer.Clear();
                ScalesIsReceving = true;
            }
            catch (Exception ex)
            {
                ScalesIsReceving = false;
                DeviceMain.Notify(string.Format("电子秤异常:{0}", ex.Message), string.Format("Scales exception:{0}", ex.Message), NotifyType.Warn);
            }
        }

        #endregion
    }
}

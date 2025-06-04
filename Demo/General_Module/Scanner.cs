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
    public class Scanner
    {
        #region 扫码设置参数

        private Stopwatch ScannerOverTime = new Stopwatch();//用于接收数据计时
        private SerialPort scanner = new SerialPort();
        private StringBuilder ScannerReceiveBuffer = new StringBuilder();
        public string ScannerResults { get { return Scannerresults; } }
        protected string Scannerresults = string.Empty;
        private bool ScannerIsReceving = false;

        #endregion

        #region 扫码枪连接

        /// <summary>
        /// 初始化扫码枪
        /// </summary>
        /// <returns></returns>
        public bool IniScanner(string ProtName, int BanudRate, int DataBits, Parity Parity, StopBits StopBits)
        {
            try
            {
                scanner.PortName = ProtName;
                scanner.BaudRate = BanudRate;
                scanner.DataBits = DataBits;
                scanner.Parity = Parity;
                scanner.StopBits = StopBits;
                this.scanner.DataReceived += new SerialDataReceivedEventHandler(Receive);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 打开扫码枪
        /// </summary>
        /// <returns></returns>
        public bool ScannerOpen()
        {
            try
            {
                if (scanner.IsOpen)
                {
                    scanner.Close();
                }
                if (!scanner.IsOpen)
                {
                    scanner.Open();
                }
            }
            catch (Exception ex)
            {
                DeviceMain.MsgShow(string.Format("扫码枪端口打开失败:{0}", ex.Message), string.Format("Scanner open port fail:{0}", ex.Message), "警告", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 关闭扫码枪
        /// </summary>
        /// <returns></returns>
        public bool ScannerClose()
        {
            try
            {
                if (scanner.IsOpen)
                {
                    scanner.Close();
                }
            }
            catch (Exception ex)
            {
                DeviceMain.Notify(string.Format("扫码枪异常:{0}", ex.Message), string.Format("Scanner exception:{0}", ex.Message), NotifyType.Warn);
                return false;
            }
            return true;
        }

        #endregion

        #region 扫码枪触发及数据接收

        /// <summary>
        /// 触发扫码枪
        /// </summary>
        /// <returns></returns>
        public bool ScannerTrigger(int OverTime,int barcode_Scanner_Mod,bool barcode_Scanner_Debug,int barcode_Scanner_Length)
        {
            try
            {
                //清除状态
                ScannerIsReceving = false;
                ScannerReceiveBuffer.Clear();
                Scannerresults = string.Empty;
                scanner.DiscardInBuffer();
                Barcode_Scanner_Mod = barcode_Scanner_Mod;
                Barcode_Scanner_Debug = barcode_Scanner_Debug;
                Barcode_Scanner_Length = barcode_Scanner_Length;
                byte[] scannerOpen = { 0x16, 0x54, 0x0D };
                byte[] scannerClose = { 0x16, 0x55, 0x0D };

                scanner.Write(scannerOpen, 0, scannerOpen.Length);
                Thread.Sleep(200);

                //等待接收完数据
                ScannerOverTime.Restart();
                while (!ScannerIsReceving)
                {
                    if (ScannerOverTime.ElapsedMilliseconds > OverTime * 1000)
                    {
                        DeviceMain.Notify(string.Format("扫码枪触发超时:{0}秒", OverTime), string.Format("Scanner trigger is out time:{0} Sec", OverTime), NotifyType.Warn);
                        scanner.Write(scannerClose, 0, scannerClose.Length);
                        return false;
                    }
                    Thread.Sleep(1);
                }
                scanner.Write(scannerClose, 0, scannerClose.Length);
            }
            catch (Exception ex)
            {
                DeviceMain.Notify(string.Format("扫码枪异常:{0}", ex.Message), string.Format("Scanner exception:{0}", ex.Message), NotifyType.Warn);
                return false;
            }
            return true;
        }

        #region 扫码枪触发模式设置参数

        /*
         * Barcode_Scanner_Length:条码固定长度
         * Barcode_Scanner_Mod:扫码枪运行模式
         * Barcode_Scanner_Debug:调试扫码枪开关
         */
        private int Barcode_Scanner_Length = 0;
        private int Barcode_Scanner_Mod = 0;
        private bool Barcode_Scanner_Debug = true;

        #endregion

        /// <summary>
        /// 扫码枪接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Receive(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] _data = new byte[scanner.BytesToRead];
                scanner.Read(_data, 0, _data.Length);
                ScannerReceiveBuffer.Append(Encoding.ASCII.GetString(_data));
                if (ScannerReceiveBuffer.ToString().Contains(" ")) ScannerReceiveBuffer = ScannerReceiveBuffer.Replace(" ", "");
                if (ScannerReceiveBuffer.ToString().Contains("\r")) ScannerReceiveBuffer = ScannerReceiveBuffer.Replace("\r", "");
                if (ScannerReceiveBuffer.ToString().Contains("\n")) ScannerReceiveBuffer = ScannerReceiveBuffer.Replace("\n", "");

                if (Barcode_Scanner_Mod == 0)
                {
                    if (ScannerReceiveBuffer.Length == Barcode_Scanner_Length)
                    {
                        Scannerresults = ScannerReceiveBuffer.ToString();
                        ScannerIsReceving = true;
                        ScannerReceiveBuffer.Clear();
                    }
                }
                else
                {
                    if (Barcode_Scanner_Debug)
                    {
                        if (ScannerReceiveBuffer.Length == Barcode_Scanner_Length)
                        {
                            Scannerresults = ScannerReceiveBuffer.ToString();
                            ScannerIsReceving = true;
                            ScannerReceiveBuffer.Clear();
                        }
                    }
                    else
                    {
                        Scannerresults = ScannerReceiveBuffer.ToString();
                        ScannerIsReceving = true;
                        ScannerReceiveBuffer.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                ScannerIsReceving = false;
                DeviceMain.Notify(string.Format("扫码枪异常:{0}", ex.Message), string.Format("Scanner exception:{0}", ex.Message), NotifyType.Warn);
            }
        }

        #endregion
    }
}

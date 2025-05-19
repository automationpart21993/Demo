using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Machine
{
    /// <summary>
    /// Log服务
    /// </summary>
    public class LogService
    {
        #region Log参数

        private DataHelper dataHelper;
        private RichTextBox rtbInfo = null;
        private bool LogSave = true;

        #endregion

        /// <summary>
        /// Log服务初始化
        /// </summary>
        /// <param name="rtb">RichTextBox控件</param>
        /// <param name="DataPath">数据保存地址</param>
        /// <returns></returns>
        public bool Init(RichTextBox rtb, string DataPath)
        {
            rtbInfo = rtb;
            LogSave = !string.IsNullOrEmpty(DataPath);
            dataHelper = new DataHelper();
            dataHelper.Init();
            dataHelper.FilePath = DataPath + @"\ApplicationLog\";
            dataHelper.Newline = "";
            NotifyG.EventHandlerNotify += ShowMessage_NotifyEventArgs;
            rtbInfo.TextChanged += rtbInfo_TextChanged;
            return true;
        }

        /// <summary>
        /// 文本框滚动
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public void rtbInfo_TextChanged(object obj, EventArgs e)
        {
            rtbInfo.SelectionStart = rtbInfo.TextLength;
            rtbInfo.ScrollToCaret();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="dm"></param>
        public void Save(string str)
        {
            try
            {
                if (Directory.Exists(dataHelper.FilePath) == false)
                {
                    Directory.CreateDirectory(dataHelper.FilePath);
                }
                dataHelper.Save(str);
            }
            catch
            {
                try
                {
                    dataHelper.FilePath = Path.Combine("D:", "DeviceDate", "Log//");
                    if (Directory.Exists(dataHelper.FilePath) == false)
                    {
                        Directory.CreateDirectory(dataHelper.FilePath);
                    }
                    dataHelper.Save(str);
                }
                catch { }
            }
        }

        /// <summary>
        /// Notify显示
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        public void ShowMessage_NotifyEventArgs(object obj, NotifyEventArgs args)
        {
            try
            {
                //信息框
                if (rtbInfo.InvokeRequired)
                {
                    rtbInfo.Invoke((MethodInvoker)delegate
                    {
                        rtbInfo.AppendText(args.Message);
                        if (LogSave) Save("[" + args.Type.ToString().PadRight(6) + "] " + args.Message);
                        #region
                        if (args.Type == NotifyType.Error)
                        {
                            rtbInfo.Select(rtbInfo.Text.LastIndexOf(args.Message), args.Message.Length);
                            rtbInfo.SelectionColor = Color.Red;
                        }
                        else if (args.Type == NotifyType.Info)
                        {
                            rtbInfo.Select(rtbInfo.Text.LastIndexOf(args.Message), args.Message.Length);
                            rtbInfo.SelectionColor = Color.Green;
                        }
                        else if (args.Type == NotifyType.Warn)
                        {
                            rtbInfo.Select(rtbInfo.Text.LastIndexOf(args.Message), args.Message.Length);
                            rtbInfo.SelectionColor = Color.Orange;
                        }
                        else if (args.Type == NotifyType.Action)
                        {
                            rtbInfo.Select(rtbInfo.Text.LastIndexOf(args.Message), args.Message.Length);
                            rtbInfo.SelectionColor = Color.Black;
                        }
                        #endregion
                    });
                }
                else
                {
                    rtbInfo.Invoke((MethodInvoker)delegate
                    {
                        rtbInfo.AppendText(args.Message);
                        if (LogSave) Save("[" + args.Type.ToString().PadRight(6) + "] " + args.Message);
                        #region
                        if (args.Type == NotifyType.Error)
                        {
                            rtbInfo.Select(rtbInfo.Text.LastIndexOf(args.Message), args.Message.Length);
                            rtbInfo.SelectionColor = Color.Red;
                        }
                        else if (args.Type == NotifyType.Info)
                        {
                            rtbInfo.Select(rtbInfo.Text.LastIndexOf(args.Message), args.Message.Length);
                            rtbInfo.SelectionColor = Color.Green;
                        }
                        else if (args.Type == NotifyType.Warn)
                        {
                            rtbInfo.Select(rtbInfo.Text.LastIndexOf(args.Message), args.Message.Length);
                            rtbInfo.SelectionColor = Color.Orange;
                        }
                        else if (args.Type == NotifyType.Action)
                        {
                            rtbInfo.Select(rtbInfo.Text.LastIndexOf(args.Message), args.Message.Length);
                            rtbInfo.SelectionColor = Color.Black;
                        }
                    });
                    #endregion
                }
                #region 清除信息
                if (rtbInfo.TextLength > 5000)
                {
                    rtbInfo.Clear();
                }
                #endregion
            }
            catch
            {
                //rtbInfo.AppendText(ex.ToString());
            }
        }
    }

    #region 支撑

    /// <summary>
    /// 提示信息事件数据
    /// </summary>
    public class NotifyEventArgs : EventArgs
    {
        #region Custruction
        public NotifyEventArgs(string message)
        {
            Message = message;
        }
        public NotifyEventArgs(NotifyType type, string message)
        {
            Message = message;
            Type = type;
        }
        #endregion

        #region Property
        /// <summary>
        /// 内容
        /// </summary>
        public string Message { get { return message; } set { message = value; } }
        private string message = string.Empty;
        /// <summary>
        /// 类型
        /// </summary>
        public NotifyType Type { get; set; }

        #endregion
    }

    /// <summary>
    /// 提示信息类
    /// </summary>
    public static class NotifyG
    {
        public static event EventHandler<NotifyEventArgs> EventHandlerNotify;
        /// <summary>
        /// 轮询方式的数据队列
        /// </summary>
        private static ConcurrentQueue<NotifyEventArgs> DataQueue = new ConcurrentQueue<NotifyEventArgs>();
        private static object lockNotify = new object();

        /// <summary>
        /// 添加错误提示信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(string msg)
        {
            Add(NotifyType.Error, msg + "\n");
        }
        /// <summary>
        /// 添加提示信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Info(string msg)
        {
            Add(NotifyType.Info, msg + "\n");
        }
        /// <summary>
        /// 添加警告提示信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Warn(string msg)
        {
            Add(NotifyType.Warn, msg + "\n");
        }
        /// <summary>
        /// 添加动作提示信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Action(string msg)
        {
            Add(NotifyType.Action, msg + "\n");
        }
        /// <summary>
        /// 添加提示信息
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="msg">内容</param>
        private static void Add(NotifyType type, string msg)
        {
            //开始处理
            if (EventHandlerNotify != null)
            {
                //如果有缓存数据则 则先处理完缓存数据
                while (DataQueue.Count() > 0)
                {
                    NotifyEventArgs result;
                    DataQueue.TryDequeue(out result);
                    EventHandlerNotify(null, result);
                    Thread.Sleep(1);
                }
                EventHandlerNotify(null, new NotifyEventArgs(type, String.Format("[{0}] :{1}", DateTime.Now.ToString("HH:mm:ss.ffff"), msg)));
                //EventHandlerNotify(null, new NotifyEventArgs(type, String.Format("{0} [{1}] :{2}", type.ToString(), DateTime.Now.ToString("HH:mm:ss.ffff"), msg)));
            }
            else
            {
                DataQueue.Enqueue(new NotifyEventArgs(type, String.Format("[{0}] :{1}", DateTime.Now.ToString("HH:mm:ss.ffff"), msg)));
                //DataQueue.Enqueue(new NotifyEventArgs(type, String.Format("{0} [{1}] :{2}", type.ToString(), DateTime.Now.ToString("HH:mm:ss.ffff"), msg)));
            }
        }
    }

    /// <summary>
    /// 数据操作
    /// </summary>
    public class DataHelper
    {
        #region Field
        /// <summary>
        /// Log锁
        /// </summary>
        private object LockObjLog = new object();
        #endregion

        #region Constructor
        public DataHelper() { }
        #endregion

        #region Property
        /// <summary>
        /// 保存路径
        /// </summary>
        public string FilePath { get { return filePath; } set { filePath = value; } }
        public string filePath = string.Format(@"{0}\", Environment.CurrentDirectory);

        /// <summary>
        /// 文件夹名称
        /// </summary>
        public string FileFoled { get { return fileFoled; } set { fileFoled = value; } }
        private string fileFoled = "Data";
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get { return fileName; } set { fileName = value; } }
        private string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".csv";

        /// <summary>
        /// 文件后缀
        /// </summary>
        public string FileSuffixe { get { return fileSuffixe; } set { fileSuffixe = value; } }
        private string fileSuffixe = ".csv";
        /// <summary>
        /// 换行符
        /// </summary>
        public string Newline { get { return newLine; } set { newLine = value; } }
        private string newLine = "\r\n";

        /// <summary>
        /// 是否保存
        /// </summary>
        public bool IsSave { get { return isSave; } set { isSave = value; } }
        private bool isSave = true;

        /// <summary>
        /// 保存多少天
        /// </summary>
        public int HowManyDays { get { return howManyDays; } set { howManyDays = value; } }
        public int howManyDays = 5;
        #endregion

        #region Method
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.filePath = string.Format(@"{0}\{1}\", Environment.CurrentDirectory, fileFoled);
            this.fileName = string.Format(@"{0}{1}", fileName, fileSuffixe);
        }
        /// <summary>
        /// 保存数据到CSV文件(托管式)
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="content"></param>
        /// <param name="enable"></param>
        public void Save(string content)
        {
            if (IsSave)
            {
                ThreadPool.QueueUserWorkItem(_save, content);
            }
        }
        /// <summary>
        /// 保存数据到CSV文件
        /// </summary>
        /// <param name="content"></param>
        private void _save(object obj)
        {
            try
            {
                lock (LockObjLog)
                {
                    FileName = DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
                    File.AppendAllText(FilePath + FileName, obj.ToString() + newLine, Encoding.Default);
                }
            }
            catch (Exception ex)
            {
                NotifyG.Error("写入数据记录失败:" + ex.Message);
            }
        }
        /// <summary>
        /// 将DataTable中数据写入到CSV文件中
        /// </summary>
        /// <param name="dt">提供保存数据的DataTable</param>
        /// <param name="fileName">CSV的文件路径</param>
        public void ConvertDataTableToVSV(DataTable dt, string fullPath)
        {
            FileInfo fi = new FileInfo(fullPath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            string data = "";
            //写出列名称
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                data += dt.Columns[i].ColumnName.ToString();
                if (i < dt.Columns.Count - 1)
                {
                    data += ",";
                }
            }
            sw.WriteLine(data);
            //写出各行数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(',') || str.Contains('"')
                        || str.Contains('\r') || str.Contains('\n')) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 将CSV文件的数据读取到DataTable中
        /// </summary>
        /// <param name="fileName">CSV文件路径</param>
        /// <returns>返回读取了CSV数据的DataTable</returns>
        public DataTable ReadCSV(string filePath)
        {
            DataTable dt = new DataTable();
            //FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            StreamReader sr = new StreamReader(filePath);
            //string fileContent = sr.ReadToEnd();
            //encoding = sr.CurrentEncoding;
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(tableHead[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    aryLine = strLine.Split(',');
                    if (aryLine.Length >= columnCount)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < columnCount; j++)
                        {
                            dr[j] = aryLine[j];
                        }
                        dt.Rows.Add(dr);
                    }
                }
                Thread.Sleep(10);
            }
            sr.Close();
            return dt;
        }

        /// <summary>
        /// 删除多余Log文件：支持文件名为"yyyyMMdd.csv"格式
        /// </summary>
        /// <param name="howManyDays"></param>
        public void DeleteOverFile()
        {
            DirectoryInfo theFolder = new DirectoryInfo(FilePath);
            FileInfo[] fileInfo = theFolder.GetFiles();
            foreach (FileInfo NextFile in fileInfo)
            {
                try
                {
                    if (int.Parse(DateTime.Now.AddDays(-HowManyDays).ToString("yyyyMMdd")) >= int.Parse(NextFile.Name.Substring(0, 8)))
                    {
                        File.Delete(FilePath + NextFile.Name);
                    }
                }
                catch (Exception ex)
                {
                    NotifyG.Error("删除Log文件失败:" + ex.Message);
                }
            }

        }

        #endregion
    }

    /// <summary>
    /// 提示信息类型
    /// </summary>
    public enum NotifyType
    {
        //调试、信息、警告、错误
        Info, Warn, Error, Null, Action
    }

    #endregion
}

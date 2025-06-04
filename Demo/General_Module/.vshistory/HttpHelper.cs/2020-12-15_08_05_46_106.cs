using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Machine
{
    //检测路径网址：http://IPAddress:Port/CONNECT/
    //上传数据网址：http://IPAddress:Port/GETLABELDATA/
    //获取数据网址：http://IPAddress:Port/UPLOADPASS/
    //获取封口网址：http://IPAddress:Port/GETCLOSURE/
    public class HttpHelper
    {
        #region Http内容类型(Content-Type)
        /// <summary>
        /// 资源类型：普通文本
        /// </summary>
        public const string TEXT_PLAIN = "text/plain";

        /// <summary>
        /// 资源类型：JSON字符串
        /// </summary>
        public const string APPLICATION_JSON = "application/json";

        /// <summary>
        /// 资源类型：未知类型(数据流)
        /// </summary>
        public const string APPLICATION_OCTET_STREAM = "application/octet-stream";

        /// <summary>
        /// 资源类型：表单数据(键值对)
        /// </summary>
        public const string WWW_FORM_URLENCODED = "application/x-www-form-urlencoded";

        /// <summary>
        /// 资源类型：表单数据(键值对)。编码方式为 gb2312
        /// </summary>
        public const string WWW_FORM_URLENCODED_GB2312 = "application/x-www-form-urlencoded;charset=gb2312";

        /// <summary>
        /// 资源类型：表单数据(键值对)。编码方式为 utf-8
        /// </summary>
        public const string WWW_FORM_URLENCODED_UTF8 = "application/x-www-form-urlencoded;charset=utf-8";

        /// <summary>
        /// 资源类型：多分部数据
        /// </summary>
        public const string MULTIPART_FORM_DATA = "multipart/form-data";
        #endregion

        #region 数据上传网址参数

        private string url_Connect = string.Empty;
        private string url_GetData = string.Empty;
        private string url_GetClosure = string.Empty;
        private string url_UpLoad = string.Empty;
        private string stationID = string.Empty;

        public string Url_Connect
        {
            get { return url_Connect; }
            set { url_Connect = value; }
        }
        public string Url_GetData
        {
            get { return url_GetData; }
            set { url_GetData = value; }
        }
        public string Url_GetClosure
        {
            get { return url_GetClosure; }
            set { url_GetClosure = value; }
        }
        public string Url_UpLoad
        {
            get { return url_UpLoad; }
            set { url_UpLoad = value; }
        }
        public string StationID
        {
            get { return stationID; }
            set { stationID = value; }
        }

        #endregion

        #region SFC交互

        /// <summary>
        /// POST方法(通用)
        /// </summary>
        /// <param name="url">网络地址</param>
        /// <param name="body">数据主体</param>
        /// <returns></returns>
        private string PostHttp(string url, string body)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = APPLICATION_JSON;
                httpWebRequest.Method = "POST";
                httpWebRequest.UserAgent = "WinForm";
                httpWebRequest.Timeout = 5000;
                httpWebRequest.Headers.Set("Pragma", "no-cahe");

                byte[] btBodys = Encoding.UTF8.GetBytes(body);
                httpWebRequest.ContentLength = btBodys.Length;
                httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                string responseContent = streamReader.ReadToEnd();

                httpWebResponse.Close();
                streamReader.Close();
                httpWebRequest.Abort();
                httpWebResponse.Close();

                return responseContent;
            }
            catch (Exception ex)
            {
                return string.Format("\"result\":\"FAIL\", \"message\": \"{0}\"", ex.Message);
            }

        }

        /// <summary>
        /// 数据上传
        /// </summary>
        /// <param name="dutID">DSN/IMEI</param>
        /// <param name="data">上传内容</param>
        /// <param name="response">返回讯息</param>
        /// <returns></returns>
        public bool UploadPass(string dutID, string data, out string response)
        {
            try
            {
                string body = "{" + string.Format("\"dut_id\":\"{0}\",\"station_id\":\"{1}\",\"data\":", dutID.ToUpper(), StationID) + "{";
                body += data + "}" + "}";
                response = PostHttp(Url_UpLoad, body);
                if (CheckError(ref response)) return true;
                return false;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 数据上传(自定义StationID)
        /// </summary>
        /// <param name="stationid">StationID</param>
        /// <param name="dutID">DSN/IMEI</param>
        /// <param name="data">上传内容</param>
        /// <param name="response">返回讯息</param>
        /// <returns></returns>
        public bool UploadPass(string stationid, string dutID, string data, out string response)
        {
            try
            {
                string body = "{" + string.Format("\"dut_id\":\"{0}\",\"station_id\":\"{1}\",\"data\":", dutID.ToUpper(), stationid) + "{";
                body += data + "}" + "}";
                response = PostHttp(Url_UpLoad, body);
                if (CheckError(ref response)) return true;
                return false;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 检查路径
        /// </summary>
        /// <param name="dutID">DSN/IEMI</param>
        /// <param name="response">返回讯息</param>
        /// <returns></returns>
        public bool CheckPath(string dutID, out string response)
        {
            try
            {
                string body = "{" + string.Format("\"dut_id\":\"{0}\",\"station_id\":\"{1}\"", dutID.ToUpper(), StationID) + "}";
                response = PostHttp(Url_Connect, body);
                if (CheckError(ref response)) return true;
                return false;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 检查路径(自定义StationID)
        /// </summary>
        /// <param name="stationid">StaionID</param>
        /// <param name="dutID">DSN/IEMI</param>
        /// <param name="response">返回讯息</param>
        /// <returns></returns>
        public bool CheckPath(string stationid, string dutID, out string response)
        {
            try
            {
                string body = "{" + string.Format("\"dut_id\":\"{0}\",\"station_id\":\"{1}\"", dutID.ToUpper(), stationid) + "}";
                response = PostHttp(Url_Connect, body);
                if (CheckError(ref response)) return true;
                return false;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="dutID">DSN/IMEI</param>
        /// <param name="labeltype">RETAIL/BOB</param>
        /// <param name="response">返回讯息</param>
        /// <returns></returns>
        public bool GetData(string dutID, string labeltype, out string response)
        {
            try
            {
                string body = "{" + string.Format("\"dut_id\":\"{0}\",\"LABEL_TYPE\":\"{1}\"", dutID.ToUpper(), labeltype) + "}";
                response = PostHttp(Url_GetData, body);
                if (CheckError(ref response)) return true;
                return false;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 返回封口标判别
        /// </summary>
        /// <param name="dutID">DSN/IMEI</param>
        /// <param name="response">返回讯息</param>
        /// <returns></returns>
        public bool GetClosure(string dutID, out string response)
        {
            try
            {
                string body = "{" + string.Format("\"dut_id\":\"{0}\"", dutID.ToUpper()) + "}";
                response = PostHttp(Url_GetClosure, body);
                if (CheckError(ref response)) return true;
                return false;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 检查是否错误(通用)
        /// </summary>
        /// <param name="error">讯息</param>
        /// <returns></returns>
        private bool CheckError(ref string response)
        {
            string temp = JsonConvert.DeserializeObject<string>(response);
            if (temp.Contains("\\")) temp = temp.Replace("\\", ";");
            JObject json = (JObject)JsonConvert.DeserializeObject(temp);
            string result = json["result"].ToString();
            string message = json["message"].ToString();
            if (result.ToUpper().Contains("PASS")/* && message.ToUpper().Contains("OK")*/)
            {
                return true;
            }
            //response = string.Format("result:{0},message:{1}", result, message);
            return false;
        }

        /// <summary>
        /// 获取Json字符串特定内容
        /// </summary>
        /// <param name="response">Json字符串</param>
        /// <param name="DataName">内容名称</param>
        /// <returns></returns>
        public static string GetjsonData(string response, string DataName, bool getdata = false)
        {
            try
            {
                string temp = JsonConvert.DeserializeObject<string>(response);
                if (temp.Contains("\\")) temp = temp.Replace("\\", ";");
                JObject json = (JObject)JsonConvert.DeserializeObject(temp);
                if (getdata)
                {
                    string data = json["data"].ToString().Replace("\r\n", "").Replace(" ", "");
                    json = (JObject)JsonConvert.DeserializeObject(data);
                }
                string result = json[DataName].ToString();
                if (result.Contains("=")) result = result.Replace("=", "");
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion
    }
}
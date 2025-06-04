using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine
{
    partial class DeviceMain
    {
        /// <summary>
        /// 触发扫码枪获取DSN
        /// </summary>
        /// <param name="mod">扫码枪运行模式</param>
        /// <param name="Debug">扫码枪调试模式</param>
        /// <param name="Length">条码长度</param>
        /// <returns></returns>
        public string ScannerDSN(RunMod mod, bool Debug, int Length)
        {
            if (!scanner.ScannerTrigger(snc.OverTime, (int)mod, Debug, Length))
            {
                return string.Empty;
            }
            string barcode = scanner.ScannerResults;
            if (barcode.Contains("\r\n")) barcode = barcode.Replace("\r\n", "");
            if (barcode.Contains(" ")) barcode = barcode.Replace(" ", "");
            return barcode;
        }

        /// <summary>
        /// 触发电子秤获取重量数据
        /// </summary>
        /// <returns></returns>
        public string ScalseWeight()
        {
            try
            {
                if (!scales.ScalesTrigger(slc.OverTime))
                {
                    return string.Empty;
                }
                string weight = scales.ScalesResults;
                if (weight.Contains("\r\n")) weight = weight.Replace("\r\n", "");
                if (weight.Contains("g")) weight = weight.Replace("g", "");
                if (weight.Contains(" ")) weight = weight.Replace(" ", "");
                return weight;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 检查重量
        /// </summary>
        /// <param name="weight">重量数据</param>
        /// <param name="WeightDetection">是否检查重量</param>
        /// <returns></returns>
        public bool WeightCheck(double weight, bool WeightDetection = true)
        {
            if (WeightDetection)//是否检测重量
            {

                if (dataserver.StationLoc[1].SkuChange || slc.Weight_Clear)//SKU改变或者需要清除重量标准值
                {
                    slc.Weight_Clear = false;
                    wec.Standard = weight;//重新记录首件重量作为标准值
                    wec.WeightSum = wec.SumCount = wec.BoxCount = 0;//清空重量累加记录及彩盒累加数量
                    wec.Save(ConfigPath(2, wec), wec);
                }
                else
                {
                    wec.Standard = wec.WeightSum / (double)wec.SumCount;//标准值等于重量累加除以彩盒累加数量
                }
                if (slc.UpperLimit_Second > slc.UpperLimit_First)
                {
                    slc.UpperLimit_Second = slc.UpperLimit_First;
                    Notify("检测段:第二上限大于第一上限,自动调整至第一上限!", "D02:The second upper limit is greater than the first upper limit, automatically adjust to the first upper limit!", NotifyType.Warn);
                    slc.Save(ConfigPath(2, slc), slc);
                }
                if (slc.LowerLimit_Second > slc.LowerLimit_First)
                {
                    slc.LowerLimit_Second = slc.LowerLimit_First;
                    Notify("检测段:第二下限大于第一下限,自动调整至第一下限!", "D02:The second lower limit is greater than the first lower limit, automatically adjust to the lower upper limit!", NotifyType.Warn);
                    slc.Save(ConfigPath(2, slc), slc);
                }
                if (wec.BoxCount < 10)//彩盒第二重量判断累加小于10
                {
                    if (weight > wec.Standard)//如果重量大于标准值
                    {
                        if ((weight - wec.Standard) > slc.UpperLimit_First)//重量-标准值大于第一上限设定范围
                        {
                            dataserver.StationLoc[1].Message = MsgSelect("称重异常:超出上限设定范围!", "Abnormal weighing:The value exceeds the upper limit!");
                            Notify("检测段:称重检测失败!", "D02:Weighing detection failure!", NotifyType.Warn);
                            return false;//跳出函数,不执行下面的代码
                        }
                        else//重量-标准值小于第一上限设定范围
                        {
                            if ((weight - wec.Standard) < slc.UpperLimit_Second)//重量-标准值小于第二上限设定范围
                            {
                                wec.BoxCount++;//彩盒第二重量判断累加
                                wec.Save(ConfigPath(2, wec), wec);
                            }
                            else//重量-标准值大于第二上限设定范围
                            {
                                wec.BoxCount = 0;//彩盒第二重量判断清零
                                wec.Save(ConfigPath(2, wec), wec);
                            }
                        }
                    }
                    else//如果重量小于标准值
                    {
                        if ((wec.Standard - weight) > slc.LowerLimit_First)//标准值-重量大于第一下限设定范围
                        {
                            dataserver.StationLoc[1].Message = MsgSelect("称重异常:超出下限设定范围!", "Abnormal weighing:The value exceeds the lower limit!");
                            Notify("检测段:称重检测失败!", "D02:Weighing detection failure!", NotifyType.Warn);
                            return false;//跳出函数,不执行下面的代码
                        }
                        else//标准值-重量小于第一下限设定范围
                        {
                            if ((wec.Standard - weight) < slc.LowerLimit_Second)//标准值-重量小于第二下限设定范围
                            {
                                wec.BoxCount++;//彩盒第二重量判断累加
                                wec.Save(ConfigPath(2, wec), wec);
                            }
                            else//标准值-重量大于第二下限设定范围
                            {
                                wec.BoxCount = 0;//彩盒第二重量判断清零
                                wec.Save(ConfigPath(2, wec), wec);
                            }
                        }
                    }
                }
                else//彩盒第二重量判断累加大于等于10
                {
                    if (weight > wec.Standard)//如果重量大于标准值
                    {
                        if ((weight - wec.Standard) > slc.UpperLimit_Second)//重量-标准值小于第二上限设定范围
                        {
                            dataserver.StationLoc[1].Message = MsgSelect("称重异常:超出上限设定范围!", "Abnormal weighing:The value exceeds the upper limit!");
                            Notify("检测段:称重检测失败!", "D02:Weighing detection failure!", NotifyType.Warn);
                            return false;//跳出函数,不执行下面的代码
                        }
                    }
                    else//如果重量小于标准值
                    {
                        if ((wec.Standard - weight) > slc.LowerLimit_Second)//标准值-重量小于第二下限设定范围
                        {
                            dataserver.StationLoc[1].Message = MsgSelect("称重异常:超出下限设定范围!", "Abnormal weighing:The value exceeds the lower limit!");
                            Notify("检测段:称重检测失败!", "D02:Weighing detection failure!", NotifyType.Warn);
                            return false;//跳出函数,不执行下面的代码
                        }
                    }
                }
                wec.WeightSum += weight;//重量累加
                wec.SumCount++;//彩盒累加数量
                wec.Save(ConfigPath(2, wec), wec);
                return true;//跳出函数,不执行下面的代码
            }
            else return true;//跳出函数,不执行下面的代码
        }

        /// <summary>
        /// DSN路径检查及产品数据获取
        /// </summary>
        /// <param name="DSN">DSN/IMEI</param>
        /// <returns></returns>
        public bool D01Check(string DSN)
        {
            if (string.IsNullOrEmpty(DSN))
            {
                Notify("入料段:扫码失败!", "D01:Scan barcod fail!", NotifyType.Warn);
                dataserver.StationLoc[0].Message = MsgSelect("扫码异常:条码为空!", "Scanner Exception:The DSN is empty!");
                return false;
            }
            try
            {
                if (!mac.StationID[(int)mac.Product].Contains(mac.Product.ToString()))
                {
                    Notify("入料段:机型选择与线体不匹配!", "D01:Machine selection and line body do not match!", NotifyType.Warn);
                    dataserver.StationLoc[0].Message = MsgSelect("检测异常:机型选择与线体不匹配!", "Detect Abnormal:The DSN is empty!");
                    return false;
                }
                dataserver.StationLoc[0].StationID = mac.StationID[(int)mac.Product];
            }
            catch
            {
                Notify("入料段:机型选择与线体不匹配!", "D01:Machine selection and line body do not match!", NotifyType.Warn);
                dataserver.StationLoc[0].Message = MsgSelect("检测异常:机型选择与线体不匹配!", "Detect Abnormal:The DSN is empty!");
                return false;
            }
            string response;
            if (!http_D01.CheckPath(DSN, out response))
            {
                string message = HttpHelper.GetjsonData(response, "message");
                if (message.Contains(mac.ClosureStationName))
                {
                    dataserver.StationLoc[0].DataUpload = 1;
                }
                else if (message.Contains(mac.PackingStationName))
                {
                    dataserver.StationLoc[0].DataUpload = 2;
                }
                else if (message.Contains(mac.OOBEStationName))
                {
                    dataserver.StationLoc[0].DataUpload = 3;
                }
                else
                {
                    Notify("入料段:彩盒路径异常!", "D01:Box route path exception!", NotifyType.Warn);
                    dataserver.StationLoc[0].Message = MsgSelect(string.Format("数据异常:彩盒路径异常!->:{0}", message), string.Format("Data Error:Box route path exception!->:{0}", message));
                    return false;
                }
            }
            #region getdata
            if (!http_D01.GetData(DSN, "RETAIL", out response))
            {
                Notify("入料段:彩盒数据获取失败!", "D01:Get box data fail!", NotifyType.Warn);
                dataserver.StationLoc[0].Message = MsgSelect("数据异常:彩盒数据获取失败!", "Data Error:Get box data fail!");
                return false;
            }
            dataserver.StationLoc[0].Sku = HttpHelper.GetjsonData(response, "sku", true);
            if (string.IsNullOrEmpty(dataserver.StationLoc[0].Sku))
            {
                Notify("入料段:彩盒数据获取[SKU]失败!", "D01:Get box data [SKU] fail!", NotifyType.Warn);
                dataserver.StationLoc[0].Message = MsgSelect("数据异常:彩盒数据获取[SKU]失败!", "Data Error:Get box data [SKU] fail!");
                return false;
            }
            dataserver.StationLoc[0].IMEI = HttpHelper.GetjsonData(response, "imei1", true);
            if (string.IsNullOrEmpty(dataserver.StationLoc[0].IMEI))
            {
                Notify("入料段:彩盒数据获取[IMEI1]失败!", "D01:Get box data [IMEI1] fail!", NotifyType.Warn);
                dataserver.StationLoc[0].Message = MsgSelect("数据异常:彩盒数据获取[IMEI1]失败!", "Data Error:Get box data [IMEI1] fail!");
                return false;
            }
            dataserver.StationLoc[0].IMEI2 = HttpHelper.GetjsonData(response, "imei2", true);
            dataserver.StationLoc[0].IMEI2NeedCheck = IMEI2NeedCheck(dataserver.StationLoc[0].Sku);
            if (string.IsNullOrEmpty(dataserver.StationLoc[0].IMEI2))
            {
                Notify("入料段:彩盒数据获取[IMEI2]失败!", "D01:Get box data [IMEI2] fail!", NotifyType.Warn);
                dataserver.StationLoc[0].Message = MsgSelect("数据异常:彩盒数据获取[IMEI2]失败!", "Data Error:Get box data [IMEI2] fail!");
                return false;
            }
            dataserver.StationLoc[0].Upc = HttpHelper.GetjsonData(response, "upc", true);
            if (string.IsNullOrEmpty(dataserver.StationLoc[0].Upc))
            {
                dataserver.StationLoc[0].Upc = HttpHelper.GetjsonData(response, "ean", true);
                if (string.IsNullOrEmpty(dataserver.StationLoc[0].Upc))
                {
                    Notify("入料段:彩盒数据获取[UPC/EAN]失败!", "D01:Get box data [UPC/EAN] fail!", NotifyType.Warn);
                    dataserver.StationLoc[0].Message = MsgSelect("数据异常:彩盒数据获取[UPC/EAN]失败!", "Data Error:Get box data [UPC/EAN] fail!");
                    return false;
                }
            }
            dataserver.StationLoc[0].EsimID = HttpHelper.GetjsonData(response, "esimid", true);
            if (string.IsNullOrEmpty(dataserver.StationLoc[0].EsimID))
            {
                Notify("入料段:彩盒数据获取[ESIMID]失败!", "D01:Get box data [ESIMID] fail!", NotifyType.Warn);
                dataserver.StationLoc[0].Message = MsgSelect("数据异常:彩盒数据获取[ESIMID]失败!", "Data Error:Get box data [ESIMID] fail!");
                return false;
            }
            dataserver.StationLoc[0].SimID = HttpHelper.GetjsonData(response, "simid", true);
            dataserver.StationLoc[0].SimIDNeedCheck = SIMIDNeedCheck(dataserver.StationLoc[0].Sku);
            if (dataserver.StationLoc[0].SimIDNeedCheck)
            {
                if (string.IsNullOrEmpty(dataserver.StationLoc[0].SimID))
                {
                    Notify("入料段:彩盒数据获取[SIMID]失败!", "D01:Get box data [SIMID] fail!", NotifyType.Warn);
                    dataserver.StationLoc[0].Message = MsgSelect("数据异常:彩盒数据获取[SIMID]失败!", "Data Error:Get box data [SIMID] fail!");
                    return false;
                }
            }
            dataserver.StationLoc[0].SoftwareVersion = HttpHelper.GetjsonData(response, "sv", true);
            dataserver.StationLoc[0].SoftwareVersionNeedCheck = SoftwareVersionNeedCheck(dataserver.StationLoc[0].Sku);
            if (dataserver.StationLoc[0].SoftwareVersionNeedCheck)
            {
                if (string.IsNullOrEmpty(dataserver.StationLoc[0].SoftwareVersion))
                {
                    Notify("入料段:彩盒数据获取[SoftwareVersion]失败!", "D01:Get box data [SoftwareVersion] fail!", NotifyType.Warn);
                    dataserver.StationLoc[0].Message = MsgSelect("数据异常:彩盒数据获取[SoftwareVersion]失败!", "Data Error:Get box data [SoftwareVersion] fail!");
                    return false;
                }
            }
            if (!dataserver.StationLoc[0].Sku.Equals(mac.NowSku))
            {
                mac.NowSku = dataserver.StationLoc[0].Sku;
                dataserver.StationLoc[0].SkuChange = true;
                mac.Save(ConfigPath(2, mac), mac);
            }
            dataserver.StationLoc[0].Color = HttpHelper.GetjsonData(response, "color", true);
            if (string.IsNullOrEmpty(dataserver.StationLoc[0].Color))
            {
                Notify("入料段:彩盒数据获取[COLOR]失败!", "D01:Get box data [COLOR] fail!", NotifyType.Warn);
                dataserver.StationLoc[0].Message = MsgSelect("数据异常:彩盒数据获取[COLOR]失败!", "Data Error:Get box data [COLOR] fail!");
                return false;
            }
            #endregion
            dataserver.StationLoc[0].Memory = "128";
            if (string.IsNullOrEmpty(dataserver.StationLoc[0].Memory))
            {
                Notify("入料段:彩盒数据获取失败!", "D01:Get box data fail!", NotifyType.Warn);
                dataserver.StationLoc[0].Message = MsgSelect("数据异常:彩盒数据获取失败!", "Data Error:Get box data fail!");
                return false;
            }
            dataserver.StationLoc[0].Add = "NA";
            if (dataserver.StationLoc[0].Sku.Contains('-'))
                dataserver.StationLoc[0].Add = dataserver.StationLoc[0].Sku.Substring(dataserver.StationLoc[0].Sku.LastIndexOf('-') + 1).ToUpper();
            else if (dataserver.StationLoc[0].Sku.Contains("GA02355") || dataserver.StationLoc[0].Sku.Contains("GA02416"))
                dataserver.StationLoc[0].Add = "FR";
            else if (dataserver.StationLoc[0].Sku.Contains("GA02363"))
                dataserver.StationLoc[0].Add = "JP";
            if (string.IsNullOrEmpty(dataserver.StationLoc[0].Add))
            {
                Notify("入料段:彩盒数据获取失败!", "D01:Get box data fail!", NotifyType.Warn);
                dataserver.StationLoc[0].Message = MsgSelect("数据异常:彩盒数据获取失败!", "Data Error:Get box data fail!");
                return false;
            }
            if (dataserver.StationLoc[0].Color.Contains(ccc.Code_Black))
            {
                dataserver.StationLoc[0].Color = "Black";
            }
            else if (dataserver.StationLoc[0].Color.Contains(ccc.Code_Blue))
            {
                dataserver.StationLoc[0].Color = "Blue";
            }
            else if (dataserver.StationLoc[0].Color.Contains(ccc.Code_White))
            {
                dataserver.StationLoc[0].Color = "White";
            }
            else if (dataserver.StationLoc[0].Color.Contains(ccc.Code_Orange))
            {
                dataserver.StationLoc[0].Color = "Orange";
            }
            if (dataserver.StationLoc[0].Memory.Contains("GB")) dataserver.StationLoc[0].Memory.Replace("GB", "");
            dataserver.StationLoc[0].Memory += "GB";
            if (dataserver.StationLoc[0].Add.Contains("FR"))
            {
                dataserver.StationLoc[0].LanguageType = "FR";
            }
            else
            {
                dataserver.StationLoc[0].LanguageType = "EN";
            }
            if (dataserver.StationLoc[0].PhoneType == ProductType.B5)
            {
                for (int i = 0; i < ccc.B5_ADDforHaveBob.Length; i++)
                {
                    if (dataserver.StationLoc[0].Add.Equals(ccc.B5_ADDforHaveBob[i]))
                    {
                        dataserver.StationLoc[0].HaveBOB = true;
                        break;
                    }
                }
            }
            else if (dataserver.StationLoc[0].PhoneType == ProductType.S5)
            {
                for (int i = 0; i < ccc.S5_ADDforHaveBob.Length; i++)
                {
                    if (dataserver.StationLoc[0].Add.Equals(ccc.S5_ADDforHaveBob[i]))
                    {
                        dataserver.StationLoc[0].HaveBOB = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ccc.B5M_ADDforHaveBob.Length; i++)
                {
                    if (dataserver.StationLoc[0].Add.Equals(ccc.B5M_ADDforHaveBob[i]))
                    {
                        dataserver.StationLoc[0].HaveBOB = true;
                        break;
                    }
                }
            }
            Notify(string.Format("SFCData:\n[1]DSN:{0}\n[2]IMEI1:{1}\n[3]IMEI2:{2}\n[4]SKU:{3}\n[5]UPC/EAN:{4}\n[6]SIMID:{5}\n[7]ESIMID:{6}\n[8]SoftwareVersion:{7}", DSN, dataserver.StationLoc[0].IMEI, dataserver.StationLoc[0].IMEI2, dataserver.StationLoc[0].Sku, dataserver.StationLoc[0].Upc,dataserver.StationLoc[0].SimID,dataserver.StationLoc[0].EsimID,dataserver.StationLoc[0].SoftwareVersion));
            return true;
        }

        /// <summary>
        /// CCD检查及重量检查
        /// </summary>
        /// <returns></returns>
        public bool D02Check()
        {
            if (!CCD_D02_Action())
            {
                return false;
            }
            string weight = ScalseWeight();
            if (string.IsNullOrEmpty(weight))
            {
                return false;
            }
            dataserver.StationLoc[1].Weight = Convert.ToDouble(weight);
            if (!WeightCheck(dataserver.StationLoc[1].Weight, ccc.WeightDetection)) return false;
            dataserver.StationLoc[1].Weight_Check = true;
            return true;
        }

        /// <summary>
        /// CCD检查及数据上传
        /// </summary>
        public void D03Check()
        {
            if ((int)dataserver.StationLoc[2].MachineMod == 0)
            {
                if (dataserver.StationLoc[2].DataUpload.Equals(0) && dataserver.StationLoc[2].HaveBOB)
                {
                    dataserver.StationLoc[2].Check_D03 = CCD_D03_Action();
                }
                else
                {
                    dataserver.StationLoc[2].Check_D03 = true;
                }
            }
            else
            {
                if (mac.CCDTest) CCDTest_D03();
                dataserver.StationLoc[2].Check_D03 = true;
            }
        }

        /// <summary>
        /// 数据上传
        /// </summary>
        /// <param name="DSN">DSN/IMEI</param>
        /// <param name="OOBE">是否为OOBE产品</param>
        /// <returns></returns>
        public bool UpLoadPass(string DSN, out bool OOBE)
        {
            OOBE = false;
            string response;
            string Code;
            if (dataserver.StationLoc[2].DataUpload.Equals(0))
            {
                if (!http_D03.UploadPass(DSN, SwitchData(dataserver.StationLoc[2].Weight), out response))
                {
                    Notify("翻转段:数据上传失败!", "D03:Data upload failed!", NotifyType.Warn);
                    Code = HttpHelper.GetjsonData(response, "message");
                    dataserver.StationLoc[2].Message = MsgSelect(string.Format("上传失败:[代码:0-{0}]!", Code), string.Format("Data upload fail:[Code:0-{0}]!", Code));
                    return false;
                }
                Code = HttpHelper.GetjsonData(response, "message");
                if (http_D03.CheckPath(DSN, out response))
                {
                    Notify("翻转段:数据上传失败!", "D03:Data upload failed!", NotifyType.Warn);
                    dataserver.StationLoc[2].Message = MsgSelect(string.Format("上传失败:[代码:0-{0}]!", Code), string.Format("Data upload fail:[Code:0-{0}]!", Code));
                    return false;
                }
            }
            if (!http_D03.GetClosure(DSN, out response))
            {
                Notify("翻转段:彩盒数据获取失败!", "D03:Get box data fail!", NotifyType.Warn);
                dataserver.StationLoc[2].Message = MsgSelect("数据异常:彩盒数据获取失败!", "Data Error:Get box data fail!");
                return false;
            }
            dataserver.StationLoc[2].Closure = HttpHelper.GetjsonData(response, "closure");
            if (string.IsNullOrEmpty(dataserver.StationLoc[2].Closure))
            {
                Notify("翻转段:彩盒数据获取失败!", "D03:Get box data fail!", NotifyType.Warn);
                dataserver.StationLoc[2].Message = MsgSelect("数据异常:彩盒数据获取失败!", "Data Error:Get box data fail!!");
                return false;
            }
            http_D03.CheckPath(DSN, out response);
            string message = HttpHelper.GetjsonData(response, "message");
            if (message.Equals(mac.ClosureStationName))
            {
                try
                {
                    if (!http_D03.UploadPass(mac.ClosureStationID[(int)mac.Product], DSN, SwitchData(0, false), out response))
                    {
                        Notify("翻转段:数据上传失败!", "D03:Data upload failed!", NotifyType.Warn);
                        Code = HttpHelper.GetjsonData(response, "message");
                        dataserver.StationLoc[2].Message = MsgSelect(string.Format("上传失败:[代码:1-{0}]!", Code), string.Format("Data upload fail:[Code:1-{0}]!", Code));
                        return false;
                    }
                    Code = HttpHelper.GetjsonData(response, "message");
                    if (http_D03.CheckPath(mac.ClosureStationID[(int)mac.Product], DSN, out response))
                    {
                        Notify("翻转段:数据上传失败!", "D03:Data upload failed!", NotifyType.Warn);
                        dataserver.StationLoc[2].Message = MsgSelect(string.Format("上传失败:[代码:1-{0}]!", Code), string.Format("Data upload fail:[Code:1-{0}]!", Code));
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Notify("翻转段:数据上传失败!", "D03:Data upload failed!", NotifyType.Warn);
                    dataserver.StationLoc[2].Message = MsgSelect(string.Format("上传失败:[代码:1-{0}]!", ex.Message), string.Format("Data upload fail:[Code:1-{0}]!", ex.Message));
                    return false;
                }
            }
            if (dataserver.StationLoc[2].Closure.Equals("Y"))
            {
                dataserver.StationLoc[2].NeedPaste = true;
                dataserver.StationLoc[2].LabelType = false;
            }
            else if (dataserver.StationLoc[2].Closure.Equals("N"))
            {
                dataserver.StationLoc[2].NeedPaste = false;
                dataserver.StationLoc[2].LabelType = false;
            }
            else if (dataserver.StationLoc[2].Closure.Equals("V") || dataserver.StationLoc[2].Closure.Equals("T"))
            {
                dataserver.StationLoc[2].NeedPaste = true;
                dataserver.StationLoc[2].LabelType = true;
            }
            else if (dataserver.StationLoc[2].Closure.Equals("O"))
            {
                Notify(string.Format("翻转段:->{0}!", mac.OOBEStationName), string.Format("D03:->{0}!", mac.OOBEStationName), NotifyType.Warn);
                dataserver.StationLoc[2].Message = MsgSelect(string.Format("下一站:{0}", mac.OOBEStationName), string.Format("Next Station:{0}", mac.OOBEStationName));
                OOBE = true;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 数据交换
        /// </summary>
        /// <param name="weight">重量数据</param>
        /// <param name="uploadweight">是否需要上传重量</param>
        /// <returns></returns>
        public string SwitchData(double weight, bool uploadweight = true)
        {
            string data = string.Empty;
            if (uploadweight)
            {
                data += string.Format("\"result\":\"{0}\",", "PASS");
                data += string.Format("\"weight\":\"{0}\"", weight);
            }
            else
            {
                data += string.Format("\"result\":\"{0}\"", "PASS");
            }
            return data;
        }

        public string[] ReadData(string filename)
        {
            string path = Path.Combine(Application.StartupPath, "Config", "DeviceConfig", filename);
            StreamReader streamread = new StreamReader(path);
            string str = streamread.ReadLine();
            string results = string.Empty;
            while (str != null)
            {
                results = results + str+",";
                str = streamread.ReadLine();
            }
            streamread.Close();
            if (string.IsNullOrEmpty(results))
            {
                return new string[] { };
            }
        }

        public string SwitchDataToFail(string error)
        {
            string data = string.Empty;
            if (error.Contains("*")) error = error.Substring(0, error.Length - 1);
            data += string.Format("\"result\":\"{0}\",", "FAIL");
            data += string.Format("\"error_code\":\"{0}\"", error);
            return data;
        }

        private String[] SKUFORIMEI2Check = new string[] { };

        public bool IMEI2NeedCheck(string SKU)
        {
            for(int i = 0; i < SKUFORIMEI2Check.Length; i++)
            {
                if (SKU.Equals(SKUFORIMEI2Check))
                {
                    return true;
                }
            }
            return false;
        }

        private String[] SKUFORSIMIDCheck = new string[] { };

        public bool SIMIDNeedCheck(string SKU)
        {
            for (int i = 0; i < SKUFORSIMIDCheck.Length; i++)
            {
                if (SKU.Equals(SKUFORSIMIDCheck))
                {
                    return true;
                }
            }
            return false;
        }

        private String[] SKUFORSoftwareVersionCheck = new string[] { };

        public bool SoftwareVersionNeedCheck(string SKU)
        {
            for (int i = 0; i < SKUFORSoftwareVersionCheck.Length; i++)
            {
                if (SKU.Equals(SKUFORSoftwareVersionCheck))
                {
                    return true;
                }
            }
            return false;
        }

        #region  测试

        /// <summary>
        /// 重量测试
        /// </summary>
        /// <param name="weight">重量测试</param>
        /// <returns></returns>
        public bool WeightTest(double weight)
        {
            if (weight > mac.WeighStandard)
            {
                if (weight - mac.WeighStandard > mac.UpperLimit)
                {
                    dataserver.StationLoc[1].Message = MsgSelect("称重异常:超出上限设定范围!", "Abnormal weighing:The value exceeds the upper limit!");
                    return false;
                }
            }
            else
            {
                if (mac.WeighStandard - weight > mac.LowerLimit)
                {
                    dataserver.StationLoc[1].Message = MsgSelect("称重异常:超出下限设定范围!", "Abnormal weighing:The value exceeds the lower limit!");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 路径检查按钮
        /// </summary>
        /// <param name="DSN">DSN/IMEI</param>
        /// <returns></returns>
        public string Test_CheckPath(string DSN)
        {
            DSN = DSN.ToUpper();
            string response;
            http_Test.CheckPath(DSN, out response);
            return string.Format("Check Route Result:\n{0}\n", response);
        }

        /// <summary>
        /// 获取RetailLabel数据按钮
        /// </summary>
        /// <param name="DSN">DSN/IMEI</param>
        /// <returns></returns>
        public string Test_GetReatilData(string DSN)
        {
            DSN = DSN.ToUpper();
            string response;
            http_Test.GetData(DSN, "RETAIL", out response);
            return string.Format("Get Retail Result:\n{0}\nIMEI1:{1}\n:SKU:{2}\nColor:{3}\nUPC:{4}\nEAN:{5}\nESIMID:{6}\n", response, HttpHelper.GetjsonData(response, "imei1", true), HttpHelper.GetjsonData(response, "sku", true), HttpHelper.GetjsonData(response, "color", true), HttpHelper.GetjsonData(response, "upc", true), HttpHelper.GetjsonData(response, "ean", true), HttpHelper.GetjsonData(response, "esimid", true));
        }

        /// <summary>
        /// 获取BOB数据按钮
        /// </summary>
        /// <param name="DSN">DSN/IMEI</param>
        /// <returns></returns>
        public string Test_GetBOBData(string DSN)
        {
            DSN = DSN.ToUpper();
            string response;
            http_Test.GetData(DSN, "BOB", out response);
            return string.Format("Get BOB Result:\n{0}\n", response);
        }

        /// <summary>
        /// 获取Closure数据按钮
        /// </summary>
        /// <param name="DSN">DSN/IMEI</param>
        /// <returns></returns>
        public string Test_GetClosure(string DSN)
        {
            DSN = DSN.ToUpper();
            string response;
            http_Test.GetClosure(DSN, out response);
            return string.Format("Get Closure Result:\n{0}\nClosure:{1}\n", response, HttpHelper.GetjsonData(response, "closure"));
        }

        /// <summary>
        /// 数据上传按钮
        /// </summary>
        /// <param name="DSN">DSN/IMEI</param>
        /// <returns></returns>
        public string Test_UpLoadPass(string DSN, double Weight)
        {
            DSN = DSN.ToUpper();
            string response;
            bool uploadresult = http_Test.UploadPass(DSN, SwitchData(Weight), out response);
            string result = string.Format("CCD Up Load PASS Result:\n{0}\n", response);
            if (uploadresult)
            {
                try
                {
                    if (DialogResult.Yes == MsgShow("是否继续上传?", "Do you want to continue uploadpass?", "Closure UploadPass", "Closure UploadPass", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        http_Test.UploadPass(mac.ClosureStationID[(int)mac.Product], DSN, SwitchData(Weight, false), out response);
                    result += string.Format("Closure Up Load PASS Result:\n{0}\n", response);
                }
                catch (Exception ex)
                {
                    result += ex.Message;
                }
            }
            return result;
        }

        #endregion
    }
}

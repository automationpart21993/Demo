using HalconDotNet;
using HelperCmd;
using hWindControl;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine
{
    partial class DeviceMain
    {
        #region 参数

        public static bool CCD_D02_Running = false;
        public static bool CCD_D03_Running = false;
        string ModelName = Path.Combine(Application.StartupPath, "ShapeModel");

        #endregion

        #region 视觉识别

        public bool Read_Date_BOB(string Type, out double ModelScore, bool CCDDetection = true)
        {
            ModelScore = Date_BOB(Type);
            if (CCDDetection) return ModelScore > 0;
            else return true;
        }

        private double Date_BOB(string Type, bool Test = false)
        {
            CCD3.Enabled = false;
            HTuple hTuple = new HTuple("Date_BOB",
                ccc.ModelScore_Date_BOB,
                ModelName,
                Test.ToString(),
                Type
                );
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD3.Enabled = CCDDebug;
            return Convert.ToDouble(hTuple.ToOArr()[0].ToString());
        }

        public bool Read_Price_BOB(string Memory, out double ModelScore, bool CCDDetection = true)
        {
            ModelScore = Price_BOB(Memory);
            if (CCDDetection) return ModelScore > 0;
            else return true;
        }

        private double Price_BOB(string Memory, bool Test = false)
        {
            CCD3.Enabled = false;
            HTuple hTuple = new HTuple("Price_BOB",
                Memory,
                ccc.ModelScore_Price_BOB,
                ModelName,
                Test.ToString(),
                Language
                );
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD3.Enabled = CCDDebug;
            return Convert.ToDouble(hTuple.ToOArr()[0].ToString());
        }

        public bool Read_Barcode_Retail(string Imei, string Imei2, string Sku, string Upc, string SimID, string EsimID, string SoftwareVersion, string ATTSKU, string GPN, string PN, string SN, bool CCDDetection = true)
        {
            if (CCDDetection)
            {
                if (string.IsNullOrEmpty(Imei) || string.IsNullOrEmpty(Sku) || string.IsNullOrEmpty(Upc) || string.IsNullOrEmpty(EsimID))
                    return false;
                if (dataserver.StationLoc[1].IMEI2NeedCheck && string.IsNullOrEmpty(Imei2)) return false;
                if (dataserver.StationLoc[1].SimIDNeedCheck && string.IsNullOrEmpty(SimID)) return false;
                if (dataserver.StationLoc[1].SoftwareVersionNeedCheck && string.IsNullOrEmpty(SoftwareVersion)) return false;
                if (dataserver.StationLoc[1].ATTSKUNeedToCheck && string.IsNullOrEmpty(ATTSKU)) return false;
                if (dataserver.StationLoc[1].GPNNeedToCheck && string.IsNullOrEmpty(GPN)) return false;
                if (dataserver.StationLoc[1].PNNeedToCheck && string.IsNullOrEmpty(PN)) return false;
                if (dataserver.StationLoc[1].SNNeedToCheck && string.IsNullOrEmpty(SN)) return false;
                string[] result = BarCode_Retail();
                for (int i = 0; i < result.Length; i++)
                {
                    if (!string.IsNullOrEmpty(result[i]))
                    {
                        if (result[i].Length == ccc.IMEILength && result[i].Substring(0, 2).Contains(ccc.IMEIInitial) && !dataserver.StationLoc[1].IMEICheck && !result[i].Equals(dataserver.StationLoc[1].IMEI2))
                        {
                            dataserver.StationLoc[1].IMEIAbnormal = true;
                            dataserver.StationLoc[1].Error_Code += result[i] + "*";
                        }
                        if (!dataserver.StationLoc[1].IMEICheck && result[i].Equals(Imei))
                        {   //ImeiCheck = true;
                            dataserver.StationLoc[1].IMEICheck = true;
                            dataserver.StationLoc[1].IMEIAbnormal = false;
                            Notify(string.Format("{0}:\nSFC-IMEI1:{1}\nCCD-Barcode:{2}", dataserver.StationLoc[1].DSN, Imei, result[i]));
                            dataserver.StationLoc[1].CCDIMEI = result[i];
                        }
                        else if (dataserver.StationLoc[1].IMEI2NeedCheck && !dataserver.StationLoc[1].ADDSCheck && !dataserver.StationLoc[1].IMEI2Check && (result[i].Equals(Imei2)))
                        {
                            dataserver.StationLoc[1].IMEI2Check = true;
                            Notify(string.Format("{0}:\nSFC-IMIE2:{1}\nCCD-Barcode:{2}", dataserver.StationLoc[1].DSN, Imei2, result[i]));
                            dataserver.StationLoc[1].CCDIMEI2 = result[i];
                        }
                        else if (dataserver.StationLoc[1].IMEI2NeedCheck && dataserver.StationLoc[1].ADDSCheck && !dataserver.StationLoc[1].IMEI2Check && (result[i].Equals("S" + Imei2)))
                        {
                            dataserver.StationLoc[1].IMEI2Check = true;
                            Notify(string.Format("{0}:\nSFC-IMIE2:{1}\nCCD-Barcode:{2}", dataserver.StationLoc[1].DSN, Imei2, result[i]));
                            dataserver.StationLoc[1].CCDIMEI2 = result[i];
                        }
                        else if (!dataserver.StationLoc[1].SkuCheck && result[i].Equals(Sku))
                        {   //SkuCheck = true;
                            dataserver.StationLoc[1].SkuCheck = true;
                            Notify(string.Format("{0}:\nSFC-SKU:{1}\nCCD-Barcode:{2}", dataserver.StationLoc[1].DSN, Sku, result[i]));
                            dataserver.StationLoc[1].CCDSku = result[i];
                        }
                        else if (!dataserver.StationLoc[1].UpcCheck && result[i].Contains(Upc))
                        {   //SkuCheck = true;
                            dataserver.StationLoc[1].UpcCheck = true;
                            Notify(string.Format("{0}:\nSFC-UPC/EAN:{1}\nCCD-Barcode:{2}", dataserver.StationLoc[1].DSN, Upc, result[i]));
                            dataserver.StationLoc[1].CCDUpc = result[i];
                        }
                        else if (dataserver.StationLoc[1].SimIDNeedCheck && !dataserver.StationLoc[1].SimIDCheck && result[i].Equals(SimID))
                        {
                            dataserver.StationLoc[1].SimIDCheck = true;
                            Notify(string.Format("{0}:\nSFC-SIMID:{1}\nCCD-Barcode:{2}", dataserver.StationLoc[1].DSN, SimID, result[i]));
                            dataserver.StationLoc[1].CCDSimID = result[i];
                        }
                        else if (!dataserver.StationLoc[1].EsimIDCheck && result[i].Equals(EsimID))
                        {   //SkuCheck = true;
                            dataserver.StationLoc[1].EsimIDCheck = true;
                            Notify(string.Format("{0}:\nSFC-EsimID:{1}\nCCD-Barcode:{2}", dataserver.StationLoc[1].DSN, EsimID, result[i]));
                            dataserver.StationLoc[1].CCDEsimID = result[i];
                        }
                        else if (dataserver.StationLoc[1].SoftwareVersionNeedCheck && !dataserver.StationLoc[1].SoftwareVersionCheck && result[i].Equals(SoftwareVersion))
                        {
                            dataserver.StationLoc[1].SoftwareVersionCheck = true;
                            Notify(string.Format("{0}:\nSFC-SoftwareVersion:{1}\nCCD-Barcode:{2}", dataserver.StationLoc[1].DSN, SoftwareVersion, result[i]));
                            dataserver.StationLoc[1].CCDSoftwareVersion = result[i];
                        }
                        else if (dataserver.StationLoc[1].ATTSKUNeedToCheck && !dataserver.StationLoc[1].ATTSKUCheck && result[i].Equals(ATTSKU))
                        {
                            dataserver.StationLoc[1].ATTSKUCheck = true;
                            Notify(string.Format("{0}:\nSFC-ATTSKU:{1}\nCCD-Barcode:{2}", dataserver.StationLoc[1].DSN, ATTSKU, result[i]));
                            dataserver.StationLoc[1].CCDATTSKU = result[i];
                        }
                        else if (dataserver.StationLoc[1].GPNNeedToCheck && !dataserver.StationLoc[1].GPNCheck && result[i].Equals(GPN))
                        {
                            dataserver.StationLoc[1].GPNCheck = true;
                            Notify(string.Format("{0}:\nSFC-GPN:{1}\nCCD-Barcode:{2}", dataserver.StationLoc[1].DSN, GPN, result[i]));
                            dataserver.StationLoc[1].CCDGPN = result[i];
                        }
                        else if (dataserver.StationLoc[1].PNNeedToCheck && !dataserver.StationLoc[1].PNCheck && result[i].Equals(PN))
                        {
                            dataserver.StationLoc[1].PNCheck = true;
                            Notify(string.Format("{0}:\nSFC-PN:{1}\nCCD-Barcode:{2}", dataserver.StationLoc[1].DSN, PN, result[i]));
                            dataserver.StationLoc[1].CCDPN = result[i];
                        }
                        else if (dataserver.StationLoc[1].SNNeedToCheck && !dataserver.StationLoc[1].SNCheck && result[i].Equals(SN))
                        {
                            dataserver.StationLoc[1].SNCheck = true;
                            Notify(string.Format("{0}:\nSFC-SN:{1}\nCCD-Barcode:{2}", dataserver.StationLoc[1].DSN, SN, result[i]));
                            dataserver.StationLoc[1].CCDSN = result[i];
                        }
                    }
                }
                bool rtb = dataserver.StationLoc[1].IMEICheck && dataserver.StationLoc[1].SkuCheck && dataserver.StationLoc[1].UpcCheck && dataserver.StationLoc[1].EsimIDCheck;
                if (dataserver.StationLoc[1].IMEI2NeedCheck)
                {
                    rtb = rtb && dataserver.StationLoc[1].IMEI2Check;
                }
                if (dataserver.StationLoc[1].SimIDNeedCheck)
                {
                    rtb = rtb && dataserver.StationLoc[1].SimIDCheck;
                }
                if (dataserver.StationLoc[1].SoftwareVersionNeedCheck)
                {
                    rtb = rtb && dataserver.StationLoc[1].SoftwareVersionCheck;
                }
                if (dataserver.StationLoc[1].ATTSKUNeedToCheck)
                {
                    rtb = rtb && dataserver.StationLoc[1].ATTSKUCheck;
                }
                if (dataserver.StationLoc[1].GPNNeedToCheck)
                {
                    rtb = rtb && dataserver.StationLoc[1].GPNCheck;
                }
                if (dataserver.StationLoc[1].PNNeedToCheck)
                {
                    rtb = rtb && dataserver.StationLoc[1].PNCheck;
                }
                if (dataserver.StationLoc[1].SNNeedToCheck)
                {
                    rtb = rtb && dataserver.StationLoc[1].SNCheck;
                }
                return rtb;
            }
            else
            {
                return true;
            }
        }

        private string[] BarCode_Retail()
        {
            CCD2.Enabled = false;
            string[] result = { string.Empty };
            HTuple hTuple = new HTuple("Barcode_Retail", ccc.Retail_Barcode_Size_Min, ccc.Retail_Barcode_Size_Max);
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
                result = new string[hTuple.ToOArr().Length];
                for (byte i = 0; i < result.Length; i++)
                {
                    result[i] = hTuple.ToOArr()[i].ToString();
                }
            }
            catch (Exception ex)
            {
                Notify(ex.ToString(), NotifyType.Warn);
            }
            CCD2.Enabled = CCDDebug;
            return result;
        }

        public bool Read_Memory_Retail(string Size, string Language, out double ModelScore, bool CCDDetection = true)
        {
            ModelScore = Memory_Retail(Size, Language);
            if (CCDDetection) return ModelScore > 0;
            else return true;
        }

        private double Memory_Retail(string Size, string Language, bool Test = false)
        {
            CCD2.Enabled = false;
            HTuple hTuple = new HTuple("Memory_Retail",
                Size,
                ccc.ModelScore_Memory_Retail,
                ModelName,
                Test.ToString(),
                Language
                );
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD2.Enabled = CCDDebug;
            return Convert.ToDouble(hTuple.ToOArr()[0].ToString());
        }

        public bool Read_Size_Retail(string Type, out double ModelScore, bool CCDDetection = true)
        {
            ModelScore = Size_Retail(Type);
            if (CCDDetection) return ModelScore > 0;
            else return true;
        }

        private double Size_Retail(string Type, bool Test = false)
        {
            CCD2.Enabled = false;
            HTuple hTuple = new HTuple("Size_Retail",
                Type,
                ccc.ModelScore_Size_Retail,
                ModelName,
                Test.ToString()
                );
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD2.Enabled = CCDDebug;
            return Convert.ToDouble(hTuple.ToOArr()[0].ToString());
        }

        public bool Read_GLabel_Retail(out double ModelScore, bool CCDDetection = true)
        {
            ModelScore = GLabel_Retail();
            if (CCDDetection) return ModelScore > 0;
            else return true;
        }

        private double GLabel_Retail(bool Test = false)
        {
            CCD2.Enabled = false;
            HTuple hTuple = new HTuple("GLabel_Retail",
                ccc.ModelScore_GLabel_Retail,
                ModelName,
                Test.ToString()
                );
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD2.Enabled = CCDDebug;
            return Convert.ToDouble(hTuple.ToOArr()[0].ToString());
        }

        public bool Read_Color_Retail(string Color, string Language, out double ModelScore, bool CCDDetection = true)
        {
            ModelScore = Color_Retail(Color, Language);
            if (CCDDetection) return ModelScore > 0;
            else return true;
        }

        private double Color_Retail(string Color, string Language, bool Test = false)
        {
            CCD2.Enabled = false;
            HTuple hTuple = new HTuple("Color_Retail",
                Color,
                ccc.ModelScore_Color_Retail,
                ModelName,
                Test.ToString(),
                Language
                );
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD2.Enabled = CCDDebug;
            return Convert.ToDouble(hTuple.ToOArr()[0].ToString());
        }

        public bool Read_Color_Top(string Color, bool CCDDetection = true)
        {
            if (CCDDetection) return Color_Top().Equals(Color);
            else return true;
        }

        private string Color_Top()
        {
            CCD1.Enabled = false;
            HTuple hTuple = new HTuple("Color_Top",
                ccc.ColorArea_Black,
                ccc.ColorArea_Blue,
                ccc.ColorArea_White,
                ModelName
                );
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD1.Enabled = CCDDebug;
            return hTuple.ToOArr()[0].ToString();
        }

        public bool Read_Type_BOB(ProductType Type, out double ModelScore, bool CCDDetection = true)
        {
            ModelScore = Type_BOB(Type);
            if (CCDDetection) return ModelScore > 0;
            else return true;
        }

        private double Type_BOB(ProductType Type, bool Test = false)
        {
            CCD3.Enabled = false;
            HTuple hTuple = new HTuple("Type_BOB",
                (int)Type,
                ccc.ModelScore_Type_BOB,
                ModelName,
                Test.ToString()
                );
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD3.Enabled = CCDDebug;
            return Convert.ToDouble(hTuple.ToOArr()[0].ToString());
        }

        public bool Read_Type_Reatil(ProductType Type, string ADD, out double ModelScore, bool CCDDetection = true)
        {
            ModelScore = Type_Retail(Type, ADD);
            if (CCDDetection) return ModelScore > 0;
            else return true;
        }

        private double Type_Retail(ProductType Type, string ADD, bool Test = false)
        {
            CCD2.Enabled = false;
            HTuple hTuple = new HTuple("Type_Retail",
                (int)Type,
                ccc.ModelScore_Type_Retail,
                ModelName,
                Test.ToString(),
                ADD
                );
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD2.Enabled = CCDDebug;
            return Convert.ToDouble(hTuple.ToOArr()[0].ToString());
        }

        public bool Read_Type_Top(ProductType Type, out double ModelScore, bool CCDDetection = true)
        {
            ModelScore = Type_Top(Type);
            if (CCDDetection) return ModelScore > 0;
            else return true;
        }

        private double Type_Top(ProductType Type, bool Test = false)
        {
            CCD1.Enabled = false;
            HTuple hTuple = new HTuple("Type_Top",
                (int)Type,
                ccc.ModelScore_Type_top,
                ModelName,
                Test.ToString()
                );
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD1.Enabled = CCDDebug;
            return Convert.ToDouble(hTuple.ToOArr()[0].ToString());
        }

        public string Take_Picture(int Camera, int ExposureTime)
        {
            hWindControl.hWinCtrl[] CCD = { null, CCD1, CCD2, CCD3 };
            CCD[Camera].Enabled = false;
            CCD[Camera].LoadImage(Path.Combine(Application.StartupPath, "Image", "Test.png"));
            CCD[Camera].FitImage(CCD[Camera].hImage);
            HTuple hTuple = new HTuple("Take_Pictrue", Camera, ExposureTime);
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD[Camera].Enabled = CCDDebug;
            return hTuple.ToOArr()[0].ToString();
        }

        public string Save_Image(int Camera, string Path, string ImageFormat = "jpeg")
        {
            hWindControl.hWinCtrl[] CCD = { null, CCD1, CCD2, CCD3 };
            CCD[Camera].Enabled = false;
            HTuple hTuple = new HTuple("SaveImage", Camera, Path, ImageFormat);
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD[Camera].Enabled = CCDDebug;
            return hTuple.ToOArr()[0].ToString();
        }

        public string Read_Image(int Camera, string Path)
        {
            hWindControl.hWinCtrl[] CCD = { null, CCD1, CCD2, CCD3 };
            CCD[Camera].Enabled = false;
            HTuple hTuple = new HTuple("ReadImage", Camera, Path);
            try
            {
                hEngine.SendTuple(hTuple);
                hTuple = hEngine.ReceiveTuple();
            }
            catch (Exception ex)
            {
                Notify(ex.Message, NotifyType.Warn);
            }
            CCD[Camera].Enabled = CCDDebug;
            return hTuple.ToOArr()[0].ToString();
        }

        #endregion

        #region 视觉检查

        /// <summary>
        /// D02段视觉调试
        /// </summary>
        public void CCDTest_D02()
        {
            string ImageSavePath = string.Format(@"D:\DeviceData\Image\{0}\Test\D02\", DateTime.Now.ToString("yyyy_MM_dd"));
            if (Directory.Exists(ImageSavePath)) Directory.Delete(ImageSavePath, true);
            string result;
            optlight.SetIntensity(1, olc.Channel_01_Black);
            optlight.SetIntensity(2, olc.Channel_02_Black);
            optlight.SetIntensity(3, olc.Channel_03_GLabel);
            CCD1.LoadImage(string.Format("{0}\\Image\\FitImage.png", Application.StartupPath));
            CCD1.FitImage(CCD1.hImage);
            CCD2.LoadImage(string.Format("{0}\\Image\\FitImage.png", Application.StartupPath));
            CCD2.FitImage(CCD2.hImage);
            while (CCD_D03_Running)
            {
                ShowInfo.Delay(1);
            }
            ShowInfo.Delay(50);
            while (CCD_D03_Running)
            {
                ShowInfo.Delay(1);
            }
            Notify("检测段:CCD测试开始", "D02:CCD Testing", NotifyType.Info);
            CCD_D02_Running = true;
            if (!Directory.Exists(ImageSavePath)) Directory.CreateDirectory(ImageSavePath);
            Take_Picture(1, ccc.CCD1_ExTime);
            Save_Image(1, string.Format("{0}Front_CCD1", ImageSavePath));
            result = Type_Top(mac.Product, true).ToString();
            Save_Window(1, string.Format("{0}Front_Type", ImageSavePath));
            Notify(string.Format("正面型号:{0}", result), string.Format("Type Top:{0}", result), NotifyType.Info);
            result = Color_Top();
            Save_Window(1, string.Format("{0}Front_Type", ImageSavePath));
            Notify(string.Format("正面颜色:{0}", result), string.Format("Color Top:{0}", result), NotifyType.Info);

            Take_Picture(2, ccc.CCD2_GExTime);
            Save_Image(2, string.Format("{0}GLabel_CCD2", ImageSavePath));
            result = GLabel_Retail(true).ToString();
            Save_Window(2, string.Format("{0}Retail_Glabel", ImageSavePath));
            Notify(string.Format("侧面防伪:{0}", result), string.Format("GLabel Retail:{0}", result), NotifyType.Info);

            optlight.SetIntensity(3, olc.Channel_03_Retail);
            Take_Picture(2, ccc.CCD2_RExTime);
            Save_Image(2, string.Format("{0}Retail_CCD2", ImageSavePath));
            result = Type_Retail(mac.Product, "", true).ToString();
            Save_Window(2, string.Format("{0}Retail_Type", ImageSavePath));
            Notify(string.Format("侧面型号:{0}", result), string.Format("Type Retail:{0}", result), NotifyType.Info);
            result = Memory_Retail("", "", true).ToString();
            Save_Window(2, string.Format("{0}Retail_Memory", ImageSavePath));
            Notify(string.Format("侧面内存:{0}", result), string.Format("Memory Retail:{0}", result), NotifyType.Info);
            result = Color_Retail("", "", true).ToString();
            Save_Window(2, string.Format("{0}Retail_Color", ImageSavePath));
            Notify(string.Format("侧面颜色:{0}", result), string.Format("Color Retail:{0}", result), NotifyType.Info);
            result = BarCode_Test();
            Save_Window(2, string.Format("{0}Retail_braCode", ImageSavePath));
            Notify(string.Format("侧面条码:{0}", result), string.Format("BarCode Retail:{0}", result), NotifyType.Info);
            CCD_D02_Running = false;
            Notify("检测段:CCD测试完成,结果仅供参考.", "D02:CCD Tested,The results are for reference only.", NotifyType.Info);
        }

        /// <summary>
        /// D03段视觉调试
        /// </summary>
        public void CCDTest_D03()
        {
            string ImageSavePath = string.Format(@"D:\DeviceData\Image\{0}\Test\D03\", DateTime.Now.ToString("yyyy_MM_dd"));
            if (Directory.Exists(ImageSavePath)) Directory.CreateDirectory(ImageSavePath);
            string result;
            optlight.SetIntensity(4, olc.Channel_04_BOB);
            CCD3.LoadImage(string.Format("{0}\\Image\\FitImage.png", Application.StartupPath));
            CCD3.FitImage(CCD3.hImage);
            while (CCD_D02_Running)
            {
                ShowInfo.Delay(1);
            }
            ShowInfo.Delay(50);
            while (CCD_D02_Running)
            {
                ShowInfo.Delay(1);
            }
            Notify("翻转段:CCD测试开始", "D03:CCD Testing", NotifyType.Info);
            CCD_D03_Running = true;
            if (!Directory.Exists(ImageSavePath)) Directory.CreateDirectory(ImageSavePath);
            Take_Picture(3, ccc.CCD3_ExTime);
            Save_Image(3, string.Format("{0}BOB_CCD3", ImageSavePath));
            result = Type_BOB(mac.Product, true).ToString();
            Save_Window(3, string.Format("{0}BOB_Type", ImageSavePath));
            Notify(string.Format("底面型号:{0}", result), string.Format("Type BOB:{0}", result), NotifyType.Info);
            result = Price_BOB("", true).ToString();
            Save_Window(3, string.Format("{0}BOB_Price", ImageSavePath));
            Notify(string.Format("底面价格:{0}", result), string.Format("Price BOB:{0}", result), NotifyType.Info);
            result = Date_BOB("", true).ToString();
            Save_Window(3, string.Format("{0}BOB_Date", ImageSavePath));
            Notify(string.Format("底面日期:{0}", result), string.Format("Date BOB:{0}", result), NotifyType.Info);
            CCD_D03_Running = false;
            Notify("翻转段:CCD测试完成,结果仅供参考.", "D03:CCD Tested,The results are for reference only.", NotifyType.Info);
        }

        /// <summary>
        /// D02段视觉检查
        /// </summary>
        /// <returns></returns>
        private bool CCD_D02_Action()
        {
            string DSN = dataserver.StationLoc[1].DSN;
            string ImageSavePath = string.Format(@"D:\DeviceData\Image\{0}\{1}\D02\", DateTime.Now.ToString("yyyy_MM_dd"), DSN);
            if (Directory.Exists(ImageSavePath)) Directory.Delete(ImageSavePath, true);
            if (dataserver.StationLoc[1].Color.Equals("Black"))
            {
                optlight.SetIntensity(1, olc.Channel_01_Black);
                optlight.SetIntensity(2, olc.Channel_02_Black);
            }
            else if (dataserver.StationLoc[1].Color.Equals("Blue"))
            {
                optlight.SetIntensity(1, olc.Channel_01_Blue);
                optlight.SetIntensity(2, olc.Channel_01_Blue);
            }
            else if (dataserver.StationLoc[1].Color.Equals("White"))
            {
                optlight.SetIntensity(1, olc.Channel_01_White);
                optlight.SetIntensity(2, olc.Channel_02_White);
            }
            else if (dataserver.StationLoc[1].Color.Equals("Orange"))
            {
                optlight.SetIntensity(1, olc.Channel_01_Orange);
                optlight.SetIntensity(2, olc.Channel_02_Orange);
            }
            else
            {
                Notify("检测段:颜色值为空!", "D02:The color value is empty!", NotifyType.Warn);
                return false;
            }
            optlight.SetIntensity(3, olc.Channel_03_GLabel);
            CCD1.LoadImage(string.Format("{0}\\Image\\FitImage.png", Application.StartupPath));
            CCD1.FitImage(CCD1.hImage);
            CCD2.LoadImage(string.Format("{0}\\Image\\FitImage.png", Application.StartupPath));
            CCD2.FitImage(CCD2.hImage);
            while (CCD_D03_Running) ShowInfo.Delay(1);
            ShowInfo.Delay(100);
            while (CCD_D03_Running) ShowInfo.Delay(1);
            CCD_D02_Running = true;
            if (!Directory.Exists(ImageSavePath)) Directory.CreateDirectory(ImageSavePath);
            if (!Take_Picture(1, ccc.CCD1_ExTime).Equals("1"))
            {
                Notify("检测段:CCD1拍照失败!", "D02:CCD1 take picture fail!", NotifyType.Warn);
                dataserver.StationLoc[1].Message = MsgSelect("CCD1拍照失败!", "CCD1 take picture fail");
                CCD_D02_Running = false;
                return false;
            }
            if (!Save_Image(1, string.Format("{0}CCD1_Front_{1}", ImageSavePath, dataserver, DSN)).Equals("1"))
            {
                Notify("检测段:CCD1照片保存失败!", "D02:CCD1 image save fail!", NotifyType.Warn);
                dataserver.StationLoc[1].Message = MsgSelect("CCD1照片保存失败!", "CCD1 image save fail");
                CCD_D02_Running = false;
                return false;
            }
            double ModelScore = 0;
            if (!Read_Type_Top(dataserver.StationLoc[1].PhoneType, out ModelScore, ccc.CCDDetection))
            {
                Save_Window(1, string.Format("{0}Front_Type_{1}", ImageSavePath, DSN));
                Notify("检测段:CCD1正面型号检测失败!", "D02:CCD1 Front Type check fail!", NotifyType.Warn);
                dataserver.StationLoc[1].Message = MsgSelect("视觉识别:CCD1正面型号检测失败!", "CCD Discern:CCD1 Front Type check fail");
                CCD_D02_Running = false;
                return false;
            }
            Save_Window(1, string.Format("{0}Front_Type_{1}", ImageSavePath, DSN));
            dataserver.StationLoc[1].Type_Front_Check = true;
            dataserver.StationLoc[1].Type_Front_ModelScore = ModelScore;
            if (!Read_Color_Top(dataserver.StationLoc[1].Color, ccc.CCDDetection))
            {
                Save_Window(1, string.Format("{0}Front_Color_{1}", ImageSavePath, DSN));
                Notify("检测段:CCD1正面颜色检测失败!", "D02:CCD1 Front Color check fail!", NotifyType.Warn);
                dataserver.StationLoc[1].Message = MsgSelect("视觉识别:CCD1正面颜色检测失败!", "CCD Discern:CCD1 Front Color check fail");
                CCD_D02_Running = false;
                return false;
            }
            Save_Window(1, string.Format("{0}Front_Color_{1}", ImageSavePath, DSN));
            dataserver.StationLoc[1].Color_Front_Check = true;
            if (!Take_Picture(2, ccc.CCD2_GExTime).Equals("1"))
            {
                Notify("检测段:CCD2拍照失败!", "D02:CCD2 take picture fail!", NotifyType.Warn);
                dataserver.StationLoc[1].Message = MsgSelect("CCD2拍照失败!", "CCD2 take picture fail");
                CCD_D02_Running = false;
                return false;
            }
            if (!Save_Image(2, string.Format("{0}CCD2_GLabel_{1}", ImageSavePath, DSN)).Equals("1"))
            {
                Notify("检测段:CCD2照片保存失败!", "D02:CCD2 image save fail!", NotifyType.Warn);
                dataserver.StationLoc[1].Message = MsgSelect("CCD2照片保存失败!", "CCD2 image save fail");
                CCD_D02_Running = false;
                return false;
            }
            int count = 0;
        ReCheck_01:
            if (!Read_GLabel_Retail(out ModelScore, ccc.CCDDetection))
            {
                if (count < ccc.Count_01)
                {
                    count++;
                    optlight.SetIntensity(3, olc.Channel_03_GLabel - (ccc.Reduce_Value_01 * count));
                    if (!Take_Picture(2, ccc.CCD2_GExTime).Equals("1"))
                    {
                        Notify("检测段:CCD2拍照失败!", "D02:CCD2 take picture fail!", NotifyType.Warn);
                        dataserver.StationLoc[1].Message = MsgSelect("CCD2拍照失败!", "CCD2 take picture fail");
                        CCD_D02_Running = false;
                        return false;
                    }
                    goto ReCheck_01;
                }
                else
                {
                    Save_Window(2, string.Format("{0}Retail_GLabel_{1}", ImageSavePath, DSN));
                    Notify("检测段:CCD2侧面防伪检测失败!", "D02:CCD2 Retail GLabel check fail!", NotifyType.Warn);
                    dataserver.StationLoc[1].Message = MsgSelect("视觉识别:CCD2侧面防伪检测失败!", "CCD Discern:CCD2 Retail GLabel check fail");
                    CCD_D02_Running = false;
                    return false;
                }
            }
            Save_Window(2, string.Format("{0}Retail_GLabel_{1}", ImageSavePath, DSN));
            dataserver.StationLoc[1].GLabel_Check = true;
            dataserver.StationLoc[1].GLabel_ModelScore = ModelScore;
            optlight.SetIntensity(3, olc.Channel_03_Retail);
            ShowInfo.Delay(ccc.Take_Delay);
            if (!Take_Picture(2, ccc.CCD2_RExTime).Equals("1"))
            {
                Notify("检测段:CCD2拍照失败!", "D02:CCD2 take picture fail!", NotifyType.Warn);
                dataserver.StationLoc[1].Message = MsgSelect("CCD2拍照失败!", "CCD2 take picture fail");
                CCD_D02_Running = false;
                return false;
            }
            if (!Save_Image(2, string.Format("{0}CCD2_Retail_{1}", ImageSavePath, DSN)).Equals("1"))
            {
                Notify("检测段:CCD2照片保存失败!", "D02:CCD2 image save fail!", NotifyType.Warn);
                dataserver.StationLoc[1].Message = MsgSelect("CCD2照片保存失败!", "CCD2 image save fail");
                CCD_D02_Running = false;
                return false;
            }
            if (!Read_Type_Reatil(dataserver.StationLoc[1].PhoneType, dataserver.StationLoc[1].Add, out ModelScore, ccc.CCDDetection))
            {
                Save_Window(2, string.Format("{0}Retail_Type_{1}", ImageSavePath, DSN));
                Notify("检测段:CCD2侧面型号检测失败!", "D02:CCD2 Retail Type check fail!", NotifyType.Warn);
                dataserver.StationLoc[1].Message = MsgSelect("视觉识别:CCD2侧面型号检测失败!", "CCD Discern:CCD2 Retail Type check fail");
                CCD_D02_Running = false;
                return false;
            }
            Save_Window(2, string.Format("{0}Retail_Type_{1}", ImageSavePath, DSN));
            dataserver.StationLoc[1].Type_Retail_Check = true;
            dataserver.StationLoc[1].Type_Retail_ModelScore = ModelScore;
            if (!Read_Size_Retail(dataserver.StationLoc[1].PhoneType.ToString(), out ModelScore, ccc.CCDDetection))
            {
                dataserver.StationLoc[1].Size_ModelScore = ModelScore;
                Save_Window(2, string.Format("{0}Retail_Size_{1}", ImageSavePath, DSN));
                Notify("检测段:CCD2侧面尺寸检测失败!", "D02:CCD2 Retail Size check fail!", NotifyType.Warn);
                dataserver.StationLoc[1].Message = MsgSelect("视觉识别:CCD2侧面尺寸检测失败!", "CCD Discern:CCD2 Retail Size check fail");
                CCD_D02_Running = false;
                return false;
            }
            Save_Window(2, string.Format("{0}Retail_Size_{1}", ImageSavePath, DSN));
            dataserver.StationLoc[1].Size_Check = true;
            dataserver.StationLoc[1].Size_ModelScore = ModelScore;
            if (!Read_Memory_Retail(dataserver.StationLoc[1].Memory, dataserver.StationLoc[1].LanguageType, out ModelScore, ccc.CCDDetection))
            {
                Save_Window(2, string.Format("{0}Retail_Memory_{1}", ImageSavePath, DSN));
                Notify("检测段:CCD2侧面内存检测失败!", "D02:CCD2 Retail Memory check fail!", NotifyType.Warn);
                dataserver.StationLoc[1].Message = MsgSelect("视觉识别:CCD2侧面内存检测失败!", "CCD Discern:CCD2 Retail Memory check fail");
                CCD_D02_Running = false;
                return false;
            }
            Save_Window(2, string.Format("{0}Retail_Memory_{1}", ImageSavePath, DSN));
            dataserver.StationLoc[1].Memory_Check = true;
            dataserver.StationLoc[1].Memory_ModelScore = ModelScore;
            if (!Read_Color_Retail(dataserver.StationLoc[1].Color, dataserver.StationLoc[1].LanguageType, out ModelScore, ccc.CCDDetection))
            {
                Save_Window(2, string.Format("{0}Retail_Color_{1}", ImageSavePath, DSN));
                Notify("检测段:CCD2侧面颜色检测失败!", "D02:CCD2 Retail Color check fail!", NotifyType.Warn);
                dataserver.StationLoc[1].Message = MsgSelect("视觉识别:CCD2侧面颜色检测失败!", "CCD Discern:CCD2 Retail Color check fail");
                CCD_D02_Running = false;
                return false;
            }
            Save_Window(2, string.Format("{0}Retail_Color_{1}", ImageSavePath, DSN));
            dataserver.StationLoc[1].Color_Retail_Check = true;
            dataserver.StationLoc[1].Color_Retail_ModelScore = ModelScore;
            count = 0;
        ReCheck_02:
            if (!Read_Barcode_Retail(dataserver.StationLoc[1].IMEI, dataserver.StationLoc[1].IMEI2, dataserver.StationLoc[1].Sku, dataserver.StationLoc[1].Upc, dataserver.StationLoc[1].SimID, dataserver.StationLoc[1].EsimID, dataserver.StationLoc[1].SoftwareVersion,dataserver.StationLoc[1].ATTSKU,dataserver.StationLoc[1].GPN,dataserver.StationLoc[1].PN,dataserver.StationLoc[1].SN, ccc.CCDDetection))
            {
                if (count < ccc.Count_02)
                {
                    count++;
                    optlight.SetIntensity(3, olc.Channel_03_Retail + (ccc.Reduce_Value_02 * count));
                    if (!Take_Picture(2, ccc.CCD2_RExTime).Equals("1"))
                    {
                        Notify("检测段:CCD2拍照失败!", "D02:CCD2 take picture fail!", NotifyType.Warn);
                        dataserver.StationLoc[1].Message = MsgSelect("CCD2拍照失败!", "CCD2 take picture fail");
                        CCD_D02_Running = false;
                        return false;
                    }
                    goto ReCheck_02;
                }
                else
                {
                    string[] notfound = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
                    if (!dataserver.StationLoc[1].SkuCheck)
                    {
                        notfound[0] = string.Format("[SFCData-SKU:{0}]", dataserver.StationLoc[1].Sku);
                        Notify("[SKU]未找到!", "[SKU] not found!", NotifyType.Error);
                    }
                    if (!dataserver.StationLoc[1].IMEICheck)
                    {
                        notfound[1] = string.Format("[SFCData-IMEI1:{0}]", dataserver.StationLoc[1].IMEI);
                        Notify("[IMEI1]未找到!", "[IMEI1] not found!", NotifyType.Error);
                    }
                    if (!dataserver.StationLoc[1].IMEI2Check && dataserver.StationLoc[1].IMEI2NeedCheck)
                    {
                        notfound[2] = string.Format("[SFCData-IMEI2:{0}]", dataserver.StationLoc[1].IMEI2);
                        Notify("[IMEI2]未找到!", "[IMEI2] not found!", NotifyType.Error);
                    }
                    if (!dataserver.StationLoc[1].UpcCheck)
                    {
                        notfound[3] = string.Format("[SFCData-UPC/EAN:{0}]", dataserver.StationLoc[1].Upc);
                        Notify("[UPC/EAN]未找到!", "[UPC/EAN] not found!", NotifyType.Error);
                    }
                    if (!dataserver.StationLoc[1].EsimIDCheck)
                    {
                        notfound[4] = string.Format("[SFCData-ESIMID:{0}]", dataserver.StationLoc[1].EsimID);
                        Notify("[ESIMID]未找到!", "[ESIMID] not found!", NotifyType.Error);
                    }
                    if (!dataserver.StationLoc[1].SimIDCheck && dataserver.StationLoc[1].SimIDNeedCheck)
                    {
                        notfound[5] = string.Format("[SFCData-SIMID:{0}]", dataserver.StationLoc[1].SimID);
                        Notify("[SIMID]未找到!", "[SIMID] not found!", NotifyType.Error);
                    }
                    if (!dataserver.StationLoc[1].SoftwareVersionCheck && dataserver.StationLoc[1].SoftwareVersionNeedCheck)
                    {
                        notfound[6] = string.Format("[SFCData-SoftwareVersion:{0}]", dataserver.StationLoc[1].SoftwareVersion);
                        Notify("[SoftwareVersion]未找到!", "[SoftwareVersion] not found!", NotifyType.Error);
                    }
                    if (!dataserver.StationLoc[1].ATTSKUCheck && dataserver.StationLoc[1].ATTSKUNeedToCheck)
                    {
                        notfound[7] = string.Format("[SFCData-ATTSKU:{0}]", dataserver.StationLoc[1].ATTSKU);
                        Notify("[ATTSKU]未找到!", "[ATTSKU] not found!", NotifyType.Error);
                    }
                    if (!dataserver.StationLoc[1].GPNCheck && dataserver.StationLoc[1].GPNNeedToCheck)
                    {
                        notfound[8] = string.Format("[SFCData-GPN:{0}]", dataserver.StationLoc[1].GPN);
                        Notify("[GPN]未找到!", "[GPN] not found!", NotifyType.Error);
                    }
                    if (!dataserver.StationLoc[1].PNCheck && dataserver.StationLoc[1].PNNeedToCheck)
                    {
                        notfound[9] = string.Format("[SFCData-PN:{0}]", dataserver.StationLoc[1].PN);
                        Notify("[PN]未找到!", "[PN] not found!", NotifyType.Error);
                    }
                    if (!dataserver.StationLoc[1].SNCheck && dataserver.StationLoc[1].SNNeedToCheck)
                    {
                        notfound[10] = string.Format("[SFCData-SN:{0}]", dataserver.StationLoc[1].SN);
                        Notify("[SN]未找到!", "[SN] not found!", NotifyType.Error);
                    }
                    Save_Window(2, string.Format("{0}Retail_Barcode_{1}", ImageSavePath, DSN));
                    Notify("检测段:CCD2侧面条码检测失败!", "D02:CCD2 Retail Barcode check fail!", NotifyType.Warn);
                    dataserver.StationLoc[1].Message = MsgSelect(string.Format("视觉识别:CCD2侧面条码检测失败!\n{0}{1}{2}{3}{4}{5}{6}", notfound[0], notfound[1], notfound[2], notfound[3], notfound[4], notfound[5], notfound[6]), string.Format("CCD Discern:CCD2 Retail Barcode check fail!\n{0}{1}{2}{3}{4}{5}{6}", notfound[0], notfound[1], notfound[2], notfound[3], notfound[4], notfound[5], notfound[6]));
                    CCD_D02_Running = false;
                    return false;
                }
            }
            Save_Window(2, string.Format("{0}Retail_Barcode_{1}", ImageSavePath, DSN));
            dataserver.StationLoc[1].IMEICheck = dataserver.StationLoc[1].SkuCheck = dataserver.StationLoc[1].UpcCheck = dataserver.StationLoc[1].EsimIDCheck = true;
            if (dataserver.StationLoc[1].IMEI2NeedCheck) dataserver.StationLoc[1].IMEI2Check = true;
            if (dataserver.StationLoc[1].SimIDNeedCheck) dataserver.StationLoc[1].SimIDCheck = true;
            if (dataserver.StationLoc[1].SoftwareVersionNeedCheck) dataserver.StationLoc[1].SoftwareVersionCheck = true;
            CCD_D02_Running = false;
            Notify("检测段:视觉检测完成!", "D02:CCD discern success!");
            return true;
        }

        /// <summary>
        /// D03段视觉检查
        /// </summary>
        /// <returns></returns>
        private bool CCD_D03_Action()
        {
            string DSN = dataserver.StationLoc[2].DSN;
            string ImageSavePath = string.Format(@"D:\DeviceData\Image\{0}\{1}\D03\", DateTime.Now.ToString("yyyy_MM_dd"), DSN);
            if (Directory.Exists(ImageSavePath)) Directory.Delete(ImageSavePath, true);
            optlight.SetIntensity(4, olc.Channel_04_BOB);
            CCD3.LoadImage(string.Format("{0}\\Image\\FitImage.png", Application.StartupPath));
            CCD3.FitImage(CCD3.hImage);
            while (CCD_D02_Running) ShowInfo.Delay(1);
            ShowInfo.Delay(100);
            while (CCD_D02_Running) ShowInfo.Delay(1);
            CCD_D03_Running = true;
            if (!Directory.Exists(ImageSavePath)) Directory.CreateDirectory(ImageSavePath);
            if (!Take_Picture(3, ccc.CCD3_ExTime).Equals("1"))
            {
                Notify("翻转段:CCD3拍照失败!", "D03:CCD3 take picture fail!", NotifyType.Warn);
                dataserver.StationLoc[2].Message = MsgSelect("CCD3拍照失败!", "CCD3 take picture fail");
                CCD_D03_Running = false;
                return false;
            }
            if (!Save_Image(3, string.Format("{0}CCD3_BOB_{1}", ImageSavePath, DSN)).Equals("1"))
            {
                Notify("翻转段:CCD3照片保存失败!", "D03:CCD3 image save fail!", NotifyType.Warn);
                dataserver.StationLoc[2].Message = MsgSelect("CCD3照片保存失败!", "CCD3 image save fail");
                CCD_D03_Running = false;
                return false;
            }
            double ModelScore = 0;
            if (!dataserver.StationLoc[2].Add.Contains("IN"))
            {
                if (!Read_Type_BOB(dataserver.StationLoc[2].PhoneType, out ModelScore, ccc.CCDDetection))
                {
                    Save_Window(3, string.Format("{0}BOB_Type_{1}", ImageSavePath, DSN));
                    Notify("翻转段:CCD3底面型号检测失败!", "D03:CCD3 BOB Type check fail!", NotifyType.Warn);
                    dataserver.StationLoc[2].Message = MsgSelect("视觉识别:CCD3底面型号检测失败!", "CCD Discern:CCD3 BOB Type check fail");
                    CCD_D03_Running = false;
                    return false;
                }
                Save_Window(3, string.Format("{0}BOB_Type_{1}", ImageSavePath, DSN));
            }
            dataserver.StationLoc[2].Type_BOB_Check = true;
            dataserver.StationLoc[2].Type_BOB_ModelScore = ModelScore;
            if (dataserver.StationLoc[2].Add.Contains("IN"))
            {
                if (!Read_Price_BOB(dataserver.StationLoc[2].Memory, out ModelScore, ccc.CCDDetection))
                {
                    Save_Window(3, string.Format("{0}BOB_Price_{1}", ImageSavePath, DSN));
                    Notify("翻转段:CCD3底面价格检测失败!", "D03:CCD3 BOB Price check fail!", NotifyType.Warn);
                    dataserver.StationLoc[2].Message = MsgSelect("视觉识别:CCD3底面价格检测失败!", "CCD Discern:CCD3 BOB Price check fail");
                    CCD_D03_Running = false;
                    return false;
                }
                Save_Window(3, string.Format("{0}BOB_Price_{1}", ImageSavePath, DSN));
                dataserver.StationLoc[2].Price_Check = true;
                dataserver.StationLoc[2].Price_ModelScore = ModelScore;
                if (!Read_Date_BOB("IN", out ModelScore, ccc.CCDDetection))
                {
                    Save_Window(3, string.Format("{0}BOB_Date_{1}", ImageSavePath, DSN));
                    Notify("翻转段:CCD3底面日期检测失败!", "D03:CCD3 BOB Date check fail!", NotifyType.Warn);
                    dataserver.StationLoc[1].Message = MsgSelect("视觉识别:CCD3底面日期检测失败!", "CCD Discern:CCD3 BOB Date check fail");
                    CCD_D03_Running = false;
                    return false;
                }
                Save_Window(3, string.Format("{0}BOB_Date_{1}", ImageSavePath, DSN));
                dataserver.StationLoc[2].Date_Check = true;
                dataserver.StationLoc[2].Date_ModelScore = ModelScore;
            }
            else if (dataserver.StationLoc[2].Add.Contains("TW")) //|| dataserver.StationLoc[2].Add.Contains("US") || dataserver.StationLoc[2].Add.Contains("CA"))
            {
                if (!Read_Date_BOB("TW", out ModelScore, ccc.CCDDetection))
                {
                    Save_Window(3, string.Format("{0}BOB_Date_{1}", ImageSavePath, DSN));
                    Notify("翻转段:CCD3底面日期检测失败!", "D03:CCD3 BOB Date check fail!", NotifyType.Warn);
                    dataserver.StationLoc[1].Message = MsgSelect("视觉识别:CCD3底面日期检测失败!", "CCD Discern:CCD3 BOB Date check fail");
                    CCD_D03_Running = false;
                    return false;
                }
                Save_Window(3, string.Format("{0}BOB_Date_{1}", ImageSavePath, DSN));
                dataserver.StationLoc[2].Date_Check = true;
                dataserver.StationLoc[2].Date_ModelScore = ModelScore;
            }
            CCD_D03_Running = false;
            Notify("翻转段:视觉检测完成!", "D03:CCD discern success!");
            return true;
        }

        /// <summary>
        /// 条码测试
        /// </summary>
        /// <returns></returns>
        private string BarCode_Test()
        {
            string result = string.Empty;
            string[] Result = BarCode_Retail();
            for (int i = 0; i < Result.Length; i++)
            {
                if (i < Result.Length - 1)
                    result += Result[i] + ",";
                else
                    result += Result[i];
            }
            return result;
        }

        /// <summary>
        /// 保存CCD控件窗口图片
        /// </summary>
        /// <param name="Index">CCD窗口索引(1,2,3)</param>
        /// <param name="FilePath">图片保存地址</param>
        public void Save_Window(int Index, string FilePath)
        {
            try
            {
                switch (Index)
                {
                    case 1:
                        CCD1.SaveWindow(FilePath, ImgFormat.jpeg);
                        break;
                    case 2:
                        CCD2.SaveWindow(FilePath, ImgFormat.jpeg);
                        break;
                    case 3:
                        CCD3.SaveWindow(FilePath, ImgFormat.jpeg);
                        break;
                }
            }
            catch (Exception ex)
            {
                Notify(string.Format("图片保存失败:{0}", ex.Message), string.Format("Image save fail:{0}", ex.Message), NotifyType.Warn);
            }
        }

        /// <summary>
        /// CCD控件刷新
        /// </summary>
        public void CCDFit()
        {
            if (!ccc.VirtualCCD)
            {
                CCD1.SetExposureTime(ccc.CCD1_ExTime);
                CCD2.SetExposureTime(ccc.CCD2_RExTime);
                CCD3.SetExposureTime(ccc.CCD3_ExTime);
                CCD1.GrabImage();
                CCD1.FitImage(CCD1.hImage);
                CCD2.GrabImage();
                CCD2.FitImage(CCD2.hImage);
                CCD3.GrabImage();
                CCD3.FitImage(CCD3.hImage);
            }
        }

        #endregion
    }
}

using HelperCmd;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Machine
{
    /// <summary>
    /// 数据服务
    /// </summary>
    public class DataService
    {

        #region 参数

        /// <summary>
        /// 工站数据实例化
        /// </summary>
        private DataBit[] stationloc = null;

        public DataBit[] StationLoc
        {
            get { return stationloc; }
            set { stationloc = value; }
        }

        #endregion

        #region 构造函数

        public DataService(int count = 1) { Init(count); }

        #endregion

        #region 初始化

        public void Init(int count)
        {
            stationloc = new DataBit[count];
            for (int i = 0; i < StationLoc.Length; i++)
            {
                StationLoc[i] = new DataBit();
            }
        }

        #endregion

        #region 数据移动

        public string DataMove(int NowDataIndex, int NextDataIndex, string[] NowStation, string[] NextStation, int Language, bool ClearData = true)
        {
            StationLoc[NextDataIndex] = StationLoc[NowDataIndex];
            if (ClearData)
            {
                StationLoc[NowDataIndex] = new DataBit();
            }
            return Language == 0 ? string.Format("数据移动:{0}--->{1}", NowStation[Language], NextStation[Language]) : string.Format("DataMove:{0}--->{1}", NowStation[Language], NextStation[Language]);
        }

        #endregion

    }

    /// <summary>
    /// 数据包,请根据实际需求修改参数及函数
    /// </summary>
    public class DataBit
    {
        #region 参数-根据实际需求自定义

        #region Data

        private ProductType phoneType = ProductType.S5;

        public ProductType PhoneType
        {
            get { return phoneType; }
            set { phoneType = value; }
        }

        private String dSN = string.Empty;

        public String DSN
        {
            get { return dSN; }
            set { dSN = value; }
        }

        private String iMEI = string.Empty;

        public String IMEI
        {
            get { return iMEI; }
            set { iMEI = value; }
        }

        private String iMEI2 = string.Empty;

        public String IMEI2
        {
            get { return iMEI2; }
            set { iMEI2 = value; }
        }

        private String upc = string.Empty;

        public String Upc
        {
            get { return upc; }
            set { upc = value; }
        }

        private String sku = string.Empty;

        public String Sku
        {
            get { return sku; }
            set { sku = value; }
        }

        private String esimID = string.Empty;

        public String EsimID
        {
            get { return esimID; }
            set { esimID = value; }
        }

        private String simID = string.Empty;

        public String SimID
        {
            get { return simID; }
            set { simID = value; }
        }

        private String softwareVersion = string.Empty;

        public String SoftwareVersion
        {
            get { return softwareVersion; }
            set { softwareVersion = value; }
        }

        private String ccdiMEI = string.Empty;

        public String CCDIMEI
        {
            get { return ccdiMEI; }
            set { ccdiMEI = value; }
        }

        private String ccdiMEI2 = string.Empty;

        public String CCDIMEI2
        {
            get { return ccdiMEI2; }
            set { ccdiMEI2 = value; }
        }

        private String ccdupc = string.Empty;

        public String CCDUpc
        {
            get { return ccdupc; }
            set { ccdupc = value; }
        }

        private String ccdsku = string.Empty;

        public String CCDSku
        {
            get { return ccdsku; }
            set { ccdsku = value; }
        }

        private String ccdEsimID = string.Empty;

        public String CCDEsimID
        {
            get { return ccdEsimID; }
            set { ccdEsimID = value; }
        }

        private String ccdSimID = string.Empty;

        public String CCDSimID
        {
            get { return ccdSimID; }
            set { ccdSimID = value; }
        }

        private String ccdSoftwareVersion = string.Empty;

        public String CCDSoftwareVersion
        {
            get { return ccdSoftwareVersion; }
            set { ccdSoftwareVersion = value; }
        }

        private Boolean iMEIAbnormal = false;

        public Boolean IMEIAbnormal
        {
            get { return iMEIAbnormal; }
            set { iMEIAbnormal = value; }
        }

        private String error_Code = string.Empty;

        public String Error_Code
        {
            get { return error_Code; }
            set { error_Code = value; }
        }

        private String memory = string.Empty;

        public String Memory
        {
            get { return memory; }
            set { memory = value; }
        }

        private String color = string.Empty;

        public String Color
        {
            get { return color; }
            set { color = value; }
        }

        private String add = string.Empty;

        public String Add
        {
            get { return add; }
            set { add = value; }
        }

        private String languageType = string.Empty;

        public String LanguageType
        {
            get { return languageType; }
            set { languageType = value; }
        }

        private Boolean needPaste = true;

        public Boolean NeedPaste
        {
            get { return needPaste; }
            set { needPaste = value; }
        }

        private Boolean labelType = false;

        public Boolean LabelType
        {
            get { return labelType; }
            set { labelType = value; }
        }

        private Boolean haveBOB = false;

        public Boolean HaveBOB
        {
            get { return haveBOB; }
            set { haveBOB = value; }
        }

        private Double weight = 0.0;

        public Double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private Double standard = 0.0;

        public Double Standard
        {
            get { return standard; }
            set { standard = value; }
        }

        private String closure = string.Empty;

        public String Closure
        {
            get { return closure; }
            set { closure = value; }
        }

        #endregion

        #region Check

        private Boolean dSNCheck = false;

        public Boolean DSNCheck
        {
            get { return dSNCheck; }
            set { dSNCheck = value; }
        }

        private Boolean iMEICheck = false;

        public Boolean IMEICheck
        {
            get { return iMEICheck; }
            set { iMEICheck = value; }
        }

        private Boolean iMEI2Check = false;

        public Boolean IMEI2Check
        {
            get { return iMEI2Check; }
            set { iMEI2Check = value; }
        }

        private Boolean skuCheck = false;

        public Boolean SkuCheck
        {
            get { return skuCheck; }
            set { skuCheck = value; }
        }

        private Boolean upcCheck = false;

        public Boolean UpcCheck
        {
            get { return upcCheck; }
            set { upcCheck = value; }
        }

        private Boolean simIDCheck = false;

        public Boolean SimIDCheck
        {
            get { return simIDCheck; }
            set { simIDCheck = value; }
        }

        private Boolean softwareVersionCheck = false;

        public Boolean SoftwareVersionCheck
        {
            get { return softwareVersionCheck; }
            set { softwareVersionCheck = value; }
        }

        private Boolean softwareVersionNeedCheck = false;

        public Boolean SoftwareVersionNeedCheck
        {
            get { return softwareVersionNeedCheck; }
            set { softwareVersionNeedCheck = value; }
        }

        private Boolean simIDNeedCheck = false;

        public Boolean SimIDNeedCheck
        {
            get { return simIDNeedCheck; }
            set { simIDNeedCheck = value; }
        }

        private Boolean iMEI2NeedCheck = false;

        public Boolean IMEI2NeedCheck
        {
            get { return iMEI2NeedCheck; }
            set { iMEI2NeedCheck = value; }
        }

        private Boolean esimIDCheck = false;

        public Boolean EsimIDCheck
        {
            get { return esimIDCheck; }
            set { esimIDCheck = value; }
        }

        private Boolean type_Front_Check = false;

        public Boolean Type_Front_Check
        {
            get { return type_Front_Check; }
            set { type_Front_Check = value; }
        }

        private Double type_Front_ModelScore = 0;

        public Double Type_Front_ModelScore
        {
            get { return type_Front_ModelScore; }
            set { type_Front_ModelScore = value; }
        }

        private Boolean type_Retail_Check = false;

        public Boolean Type_Retail_Check
        {
            get { return type_Retail_Check; }
            set { type_Retail_Check = value; }
        }

        private Double type_Retail_ModelScore = 0;

        public Double Type_Retail_ModelScore
        {
            get { return type_Retail_ModelScore; }
            set { type_Retail_ModelScore = value; }
        }

        private Boolean type_BOB_Check = false;

        public Boolean Type_BOB_Check
        {
            get { return type_BOB_Check; }
            set { type_BOB_Check = value; }
        }

        private Double type_BOB_ModelScore = 0;

        public Double Type_BOB_ModelScore
        {
            get { return type_BOB_ModelScore; }
            set { type_BOB_ModelScore = value; }
        }

        private Boolean color_Front_Check = false;

        public Boolean Color_Front_Check
        {
            get { return color_Front_Check; }
            set { color_Front_Check = value; }
        }

        private Boolean color_Retail_Check = false;

        public Boolean Color_Retail_Check
        {
            get { return color_Retail_Check; }
            set { color_Retail_Check = value; }
        }

        private Double color_Retail_ModelScore = 0;

        public Double Color_Retail_ModelScore
        {
            get { return color_Retail_ModelScore; }
            set { color_Retail_ModelScore = value; }
        }

        private Boolean gLabel_Check = false;

        public Boolean GLabel_Check
        {
            get { return gLabel_Check; }
            set { gLabel_Check = value; }
        }

        private Double gLabel_ModelScore = 0;

        public Double GLabel_ModelScore
        {
            get { return gLabel_ModelScore; }
            set { gLabel_ModelScore = value; }
        }

        private Boolean memory_Check = false;

        public Boolean Memory_Check
        {
            get { return memory_Check; }
            set { memory_Check = value; }
        }

        private Double memory_ModelScore = 0;

        public Double Memory_ModelScore
        {
            get { return memory_ModelScore; }
            set { memory_ModelScore = value; }
        }

        private Boolean size_Check = false;

        public Boolean Size_Check
        {
            get { return size_Check; }
            set { size_Check = value; }
        }

        private Double size_ModelScore = 0;

        public Double Size_ModelScore
        {
            get { return size_ModelScore; }
            set { size_ModelScore = value; }
        }

        private Boolean price_Check = false;

        public Boolean Price_Check
        {
            get { return price_Check; }
            set { price_Check = value; }
        }

        private Double price_ModelScore = 0;

        public Double Price_ModelScore
        {
            get { return price_ModelScore; }
            set { price_ModelScore = value; }
        }

        private Boolean date_Check = false;

        public Boolean Date_Check
        {
            get { return date_Check; }
            set { date_Check = value; }
        }

        private Double date_ModelScore = 0;

        public Double Date_ModelScore
        {
            get { return date_ModelScore; }
            set { date_ModelScore = value; }
        }

        private Int16 dataUpload = 0;

        public Int16 DataUpload
        {
            get { return dataUpload; }
            set { dataUpload = value; }
        }

        private Boolean weight_Check = false;

        public Boolean Weight_Check
        {
            get { return weight_Check; }
            set { weight_Check = value; }
        }

        private Boolean check_D01 = false;

        public Boolean Check_D01
        {
            get { return check_D01; }
            set { check_D01 = value; }
        }

        private Boolean check_D02 = false;

        public Boolean Check_D02
        {
            get { return check_D02; }
            set { check_D02 = value; }
        }

        private Boolean check_D03 = false;

        public Boolean Check_D03
        {
            get { return check_D03; }
            set { check_D03 = value; }
        }

        private Boolean skuChange = false;

        public Boolean SkuChange
        {
            get { return skuChange; }
            set { skuChange = value; }
        }

        #endregion

        #region Other

        private String stationID = string.Empty;

        public String StationID
        {
            get { return stationID; }
            set { stationID = value; }
        }

        private String message = string.Empty;

        public String Message
        {
            get { return message; }
            set { message = value; }
        }

        private Int64 circleTime = 0;

        public Int64 CircleTime
        {
            get { return circleTime; }
            set { circleTime = value; }
        }

        private DateTime startTime = DateTime.Now;

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        private DateTime endTime = DateTime.Now;

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private RunMod machineMod = RunMod.Normal;

        public RunMod MachineMod
        {
            get { return machineMod; }
            set { machineMod = value; }
        }

        private Int64 circleTime_D01 = 0;

        public Int64 CircleTime_D01
        {
            get { return circleTime_D01; }
            set { circleTime_D01 = value; }
        }

        private Int64 circleTime_D02 = 0;

        public Int64 CircleTime_D02
        {
            get { return circleTime_D02; }
            set { circleTime_D02 = value; }
        }

        private Int64 circleTime_D03 = 0;

        public Int64 CircleTime_D03
        {
            get { return circleTime_D03; }
            set { circleTime_D03 = value; }
        }

        private Int64 circleTime_Output = 0;

        public Int64 CircleTime_Output
        {
            get { return circleTime_Output; }
            set { circleTime_Output = value; }
        }

        #endregion

        #endregion

        #region 数据保存

        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="DataName">数据名称</param>
        /// <returns></returns>
        public bool DataSave()
        {
            #region
            //地址根据实际需求自定义
            string dataPath = Path.Combine(@"D:\DeviceData", "ProductData", "Production_Data", DateTime.Now.ToString("yyyy-MM-dd") + ".csv");
            try
            {
                bool rtn = false;

                #region 标题-根据实际需求自定义

                string title = string.Empty;

                title += "DSN" + ",";
                title += "MachineMod" + ",";
                title += "StartTime(开始时间)" + ",";
                title += "Endtime(结束时间)" + ",";
                title += "ThroughRoute" + ",";
                title += "StationID" + ",";
                title += "Type" + ",";
                title += "Imei1" + ",";
                title += "Imei2" + ",";
                title += "Sku" + ",";
                title += "Upc/Ean" + ",";
                title += "Simid" + ",";
                title += "ESimid" + ",";
                title += "SoftwareVersion" + ",";
                title += "CCDImei1" + ",";
                title += "CCDImei2" + ",";
                title += "CCDSku" + ",";
                title += "CCDUpc/Ean" + ",";
                title += "CCDSimid" + ",";
                title += "CCDESimid" + ",";
                title += "CCDSoftwareVersion" + ",";
                title += "Color" + ",";
                title += "Memory" + ",";
                title += "ADD" + ",";
                title += "Closure" + ",";
                title += "Weight" + ",";
                title += "WeightStandard" + ",";
                title += "DSNCheck" + ",";
                title += "FrontTypeCheck" + ",";
                title += "FrontTypeModelScore" + ",";
                title += "RetailTypeCheck" + ",";
                title += "RetailTypeModelScore" + ",";
                title += "BOBTypeCheck" + ",";
                title += "BOBTypeModelScore" + ",";
                title += "ImeiCheck" + ",";
                title += "SkuCheck" + ",";
                title += "Upc/EanCheck" + ",";
                title += "ForntColorCheck" + ",";
                title += "ReatilColorCheck" + ",";
                title += "ReatilModelScore" + ",";
                title += "MemoryCheck" + ",";
                title += "MemoryModelScore" + ",";
                title += "SizeCheck" + ",";
                title += "SizeModelScore" + ",";
                title += "GLabelCheck" + ",";
                title += "GLabelModelScore" + ",";
                title += "PriceCheck" + ",";
                title += "PriceModelScore" + ",";
                title += "DateCheck" + ",";
                title += "DateModelScore" + ",";
                title += "WeightCheck" + ",";
                title += "NeedPaste" + ",";
                title += "LabelType" + ",";
                title += "SkuChange" + ",";
                title += "HaveBOB" + ",";
                title += "D01 CircleTime" + ",";
                title += "D02 CircleTime" + ",";
                title += "D03 CircleTime" + ",";
                title += "CircleTime" + ",";
                title += "Output CircleTime" + ",";
                title += "D01 Check" + ",";
                title += "D02 Check" + ",";
                title += "D03 Check" + ",";
                title += "Message";


                #endregion

                if (!File.Exists(dataPath))
                {
                    rtn = ExcelCmd.WriteDataToCSVFile(dataPath, title);//写Title
                    if (!rtn)
                        return false;
                }

                #region 数据格式
                string[] titleCount = title.Split(',');
                string format = string.Empty;
                for (int i = 0; i < titleCount.Length; i++)
                {
                    format += "{" + i + "},";
                }
                format = format.Substring(0, format.LastIndexOf(','));
                #endregion

                #region 数据整理-根据实际需求自定义

                string Data = string.Empty;
                Data = string.Format(
                     format,
                     DSN,
                     MachineMod,
                     StartTime.ToString("HH:mm:ss"),
                     EndTime.ToString("HH:mm:ss"),
                     DataUpload,
                     StationID,
                     PhoneType,
                     IMEI,
                     Sku,
                     Upc,
                     CCDIMEI,
                     CCDSku,
                     CCDUpc,
                     Color,
                     Memory,
                     Add,
                     Closure,
                     Weight,
                     Standard,
                     DSNCheck,
                     Type_Front_Check,
                     Type_Front_ModelScore,
                     Type_Retail_Check,
                     Type_Retail_ModelScore,
                     Type_BOB_Check,
                     Type_BOB_ModelScore,
                     IMEICheck,
                     SkuCheck,
                     UpcCheck,
                     Color_Front_Check,
                     Color_Retail_Check,
                     Color_Retail_ModelScore,
                     Memory_Check,
                     Memory_ModelScore,
                     size_Check,
                     size_ModelScore,
                     GLabel_Check,
                     GLabel_ModelScore,
                     Price_Check,
                     Price_ModelScore,
                     Date_Check,
                     Date_ModelScore,
                     Weight_Check,
                     NeedPaste,
                     LabelType,
                     SkuChange,
                     HaveBOB,
                     CircleTime_D01 / (double)1000,
                     CircleTime_D02 / (double)1000,
                     CircleTime_D03 / (double)1000,
                     CircleTime / (double)1000,
                     CircleTime_Output / (double)1000,
                     Check_D01,
                     Check_D02,
                     Check_D03,
                     Message
                     );

                #endregion
                rtn = ExcelCmd.WriteDataToCSVFile(dataPath, Data);//写数据
                return rtn;
            }
            catch
            {
                return false;
            }
            #endregion
        }

        #endregion
    }

}

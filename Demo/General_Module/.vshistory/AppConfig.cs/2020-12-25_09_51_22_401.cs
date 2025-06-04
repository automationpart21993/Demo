using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelperCmd;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Machine
{
    #region 枚举

    public enum ProductType
    {
        S5, B5, B5M
    }

    public enum AccessLevel
    {
        Guest, Normal, Administrator, SuperAdministrator
    }

    public enum RunMod
    {
        Normal, Debug, DryRun
    }

    public enum SerialPortName
    {
        COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, COM10, COM11, COM12
    }

    public enum SerialBaudRate : int
    {
        BaudRate_2400 = 2400, BaudRate_4800 = 4800, BaudRate_9600 = 9600, BaudRate_14400 = 14400,
        BaudRate_19200 = 19200, BaudRate_38400 = 38400, BaudRate_56000 = 56000, BaudRate_57600 = 57600,
        BaudRate_115200 = 115200
    }

    public enum SerialDataBits : int
    {
        DataBits_5 = 5, DataBits_6 = 6, DataBits_7 = 7, DataBits_8 = 8
    }

    public enum FormLanguage
    {
        ZH, EN
    }

    public enum DebugMod
    {
        PASS, NG, Random
    }

    #endregion

    #region 配置

    public class MachineConfig : Setting<MachineConfig>
    {
        private const String BaseSet = "00-基础设置|Base Setting";

        #region 基础设置
        private RunMod runmod = RunMod.Normal;
        [Category(BaseSet), DisplayName("00-运行模式设置|Run Mod Set"), Description("设备运行模式设置|Machine Run Mod Set"), ReadOnly(true)]
        public RunMod Runmod
        {
            get { return runmod; }
            set { runmod = value; }
        }

        private FormLanguage language = FormLanguage.ZH;
        [Category(BaseSet), DisplayName("01-显示语言|Display Language"), Description("显示语言|Display Language"), ReadOnly(true)]
        public FormLanguage Language
        {
            get { return language; }
            set { language = value; }
        }

        private ProductType product = ProductType.S5;
        [Category(BaseSet), DisplayName("02-产品类型|Product Type"), Description("产品类型|Product Type")]
        public ProductType Product
        {
            get { return product; }
            set { product = value; }
        }

        private bool safeGuardEnable = false;
        [Category(BaseSet), DisplayName("03-门禁使能|Safe Guard Enable"), Description("门禁使能|Safe Guard Enable")]
        public bool SafeGuardEnable
        {
            get { return safeGuardEnable; }
            set { safeGuardEnable = value; }
        }

        private Double nGOutTime = 5;
        [Category(BaseSet), DisplayName("04-NG报警超时|NG Alarm Timeouts"), Description("NG报警超时|NG Alarm Timeouts")]
        public Double NGOutTime
        {
            get { return nGOutTime; }
            set { nGOutTime = value; }
        }

        private bool signal_Switch = true;
        [Category(BaseSet), DisplayName("05-信号切换|Signal Switch"), Description("信号切换|Signal Switch"), ReadOnly(true)]
        public bool Signal_Swithc
        {
            get { return signal_Switch; }
            set { signal_Switch = value; }
        }

        private int tip_OverTime = 60;
        [Category(BaseSet), DisplayName("06-提示超时|Tip OverTime"), Description("提示超时|Tip OverTime")]
        public int Tip_OverTime
        {
            get { return tip_OverTime; }
            set { tip_OverTime = value; }
        }


        private string nowSku = string.Empty;
        [Category(BaseSet), DisplayName("07-当前料号|Now Sku"), Description("当前料号|Now Sku"), ReadOnly(true)]
        public string NowSku
        {
            get { return nowSku; }
            set { nowSku = value; }
        }

        #endregion

        private const String NetworkSet = "01-网络设置|Network Setting";

        #region 网络连接设置

        private string iPAddress = string.Empty;
        [Category(NetworkSet), DisplayName("00-IP地址|IP Address"), Description("IP地址|IP Address")]
        public string IPAddress
        {
            get { return iPAddress; }
            set { iPAddress = value; }
        }

        private int networkPort = 8080;
        [Category(NetworkSet), DisplayName("01-端口号|Port"), Description("端口号|Port")]
        public int NetworkPort
        {
            get { return networkPort; }
            set { networkPort = value; }
        }

        private string[] stationID = { "S5_P1-L102PB_P-WEIGH-G_TEST1", "B5_P1-L102PA_P-WEIGH-G_TEST1", "B5M_P1-L102PA_P-WEIGH-G_TEST1" };
        [Category(NetworkSet), DisplayName("02-工站ID|Station ID"), Description("工站ID|Station ID")]
        public string[] StationID
        {
            get { return stationID; }
            set { stationID = value; }
        }

        private string[] closureStationID = { "S5_P1-L102PB_P-CLOSURELABEL_TEST1", "B5_P1-L102PA_P-CLOSURELABEL_TEST1", "B5M_P1-L102PA_P-CLOSURELABEL_TEST1" };
        [Category(NetworkSet), DisplayName("03-Closure工站ID|Closure Station ID"), Description("Closure工站ID|Closure Station ID")]
        public string[] ClosureStationID
        {
            get { return closureStationID; }
            set { closureStationID = value; }
        }

        private string closureStationName = string.Empty;
        [Category(NetworkSet), DisplayName("04-Closure工站名|Closure Station Name"), Description("Closure工站名|Closure Station Name")]
        public string ClosureStationName
        {
            get { return closureStationName; }
            set { closureStationName = value; }
        }

        private string packingStationName = string.Empty;
        [Category(NetworkSet), DisplayName("05-Packing工站名|Packing Station Name"), Description("Packing工站名|Packing Station Name")]
        public string PackingStationName
        {
            get { return packingStationName; }
            set { packingStationName = value; }
        }
        private string oOBEStationName = string.Empty;
        [Category(NetworkSet), DisplayName("06-OOBE工站名|OOBE Station Name"), Description("OOBE工站名|OOBE Station Name")]
        public string OOBEStationName
        {
            get { return oOBEStationName; }
            set { oOBEStationName = value; }
        }

        private string name_Connect = string.Empty;
        [Category(NetworkSet), DisplayName("07-检查路径网址|Check Route URL"), Description("检查路径网址|Check Route URL")]
        public string Name_Connect
        {
            get { return name_Connect; }
            set { name_Connect = value; }
        }

        private string name_GetData = string.Empty;
        [Category(NetworkSet), DisplayName("08-获取数据网址|Get Data URL"), Description("获取数据网址|Get Data URL")]
        public string Name_GetData
        {
            get { return name_GetData; }
            set { name_GetData = value; }
        }

        private string name_GetClosureResult = string.Empty;
        [Category(NetworkSet), DisplayName("09-获取封口网址|Get Clousre URL"), Description("获取数据网址|Get Clousre URL")]
        public string Name_GetClosureResult
        {
            get { return name_GetClosureResult; }
            set { name_GetClosureResult = value; }
        }

        private string name_GetDutData = string.Empty;
        [Category(NetworkSet), DisplayName("10-获取Dut数据网址|Get Dut Data URL"), Description("获取Dut数据网址|Get Dut Data URL")]
        public string Name_GetDutData
        {
            get { return name_GetDutData; }
            set { name_GetDutData = value; }
        }

        private string name_UpLoad = string.Empty;
        [Category(NetworkSet), DisplayName("11-数据上传网址|UpLoad Pass URL"), Description("数据上传网址|UpLoad Pass URL")]
        public string Name_UpLoad
        {
            get { return name_UpLoad; }
            set { name_UpLoad = value; }
        }

        #endregion

        private const String BeltSet = "02-拉带设置|Belt Setting";

        #region 拉带设置

        private int delay_D01 = 100;
        [Category(BeltSet), DisplayName("00-拉带一停止延时|Belt 01 Stop Delay"), Description("拉带一停止延时|Belt 01 Stop Delay")]
        public int Delay_D01
        {
            get { return delay_D01; }
            set { delay_D01 = value; }
        }

        private int delay_D02 = 100;
        [Category(BeltSet), DisplayName("01-拉带二停止延时|Belt 02 Stop Delay"), Description("拉带二停止延时|Belt 02 Stop Delay")]
        public int Delay_D02
        {
            get { return delay_D02; }
            set { delay_D02 = value; }
        }

        private int delay_D03 = 100;
        [Category(BeltSet), DisplayName("02-拉带三停止延时|Belt 03 Stop Delay"), Description("拉带三停止延时|Belt 03 Stop Delay")]
        public int Delay_D03
        {
            get { return delay_D03; }
            set { delay_D03 = value; }
        }

        private int delay_D01_ClearStatus = 300;
        [Category(BeltSet), DisplayName("03-拉带一状态清空延时|Belt 01 Status Clear Delay"), Description("拉带一状态清空延时|Belt 01 Status Clear Delay")]
        public int Delay_D01_ClearStatus
        {
            get { return delay_D01_ClearStatus; }
            set { delay_D01_ClearStatus = value; }
        }

        private int delay_D02_ClearStatus = 300;
        [Category(BeltSet), DisplayName("04-拉带二状态清空延时|Belt 02 Status Clear Delay"), Description("拉带二状态清空延时|Belt 02 Status Clear Delay")]
        public int Delay_D02_ClearStatus
        {
            get { return delay_D02_ClearStatus; }
            set { delay_D02_ClearStatus = value; }
        }

        private int delay_D03_ClearStatus = 300;
        [Category(BeltSet), DisplayName("05-拉带三状态清空延时|Belt 03 Status Clear Delay"), Description("拉带三状态清空延时|Belt 03 Status Clear Delay")]
        public int Delay_D03_ClearStatus
        {
            get { return delay_D03_ClearStatus; }
            set { delay_D03_ClearStatus = value; }
        }

        private int delay_D02_Weigh = 0;
        [Category(BeltSet), DisplayName("06-称重延时|Weigh Delay"), Description("称重延时|Weigh Delay")]
        public int Delay_D02_Weigh
        {
            get { return delay_D02_Weigh; }
            set { delay_D02_Weigh = value; }
        }

        private bool switch_D01 = false;
        [Category(BeltSet), DisplayName("07-D01状态清空模式开关|D01 Status Clear Mod Switch"), Description("D01状态清空模式开关|D01 Status Clear Mod Switch")]
        public bool Switch_D01
        {
            get { return switch_D01; }
            set { switch_D01 = value; }
        }

        private bool switch_D02 = true;
        [Category(BeltSet), DisplayName("08-D02状态清空模式开关|D02 Status Clear Mod Switch"), Description("D02状态清空模式开关|D02 Status Clear Mod Switch")]
        public bool Switch_D02
        {
            get { return switch_D02; }
            set { switch_D02 = value; }
        }

        private int clearOverTime = 2000;
        [Category(BeltSet), DisplayName("09-超时设置|Over Time"), Description("超时设置|Over Time")]
        public int ClearOverTime
        {
            get { return clearOverTime; }
            set { clearOverTime = value; }
        }

        #endregion

        private const String DebugSet = "03-调试模式|Debug Setting";

        #region 调试模式

        private DebugMod debugmod = DebugMod.PASS;
        private bool sNLength = true;
        [Category(DebugSet), DisplayName("01-条码测试|Barcode Discern"), Description("条码测试|Barcode Discern")]
        public bool SNLength
        {
            get { return sNLength; }
            set { sNLength = value; }
        }
        [Category(DebugSet), DisplayName("00-测试结果|Test Result"), Description("测试结果|Test Result")]
        public DebugMod Debugmod
        {
            get { return debugmod; }
            set { debugmod = value; }
        }

        private bool cCDTest = true;
        [Category(DebugSet), DisplayName("02-视觉测试|Visual Discern"), Description("视觉测试|Visual Discern")]
        public bool CCDTest
        {
            get { return cCDTest; }
            set { cCDTest = value; }
        }

        private bool weighTest = true;
        [Category(DebugSet), DisplayName("03-称重测试|Weigh Debug"), Description("称重测试|Weigh Debug")]
        public bool WeighTest
        {
            get { return weighTest; }
            set { weighTest = value; }
        }

        private double weighStandard = 100;
        [Category(DebugSet), DisplayName("04-重量标准|Weight Standard"), Description("重量标准|Weight Standard")]
        public double WeighStandard
        {
            get { return weighStandard; }
            set { weighStandard = value; }
        }

        private double upperLimit = 100;
        [Category(DebugSet), DisplayName("05-重量上限|Weight Upper Limit"), Description("重量上限|Weight Upper Limit")]
        public double UpperLimit
        {
            get { return upperLimit; }
            set { upperLimit = value; }
        }

        private double lowerLimit = 100;
        [Category(DebugSet), DisplayName("06-重量下限|Weight Lower Limit"), Description("重量下限|Weight Lower Limit")]
        public double LowerLimit
        {
            get { return lowerLimit; }
            set { lowerLimit = value; }
        }

        private bool communication = false;
        [Category(DebugSet), DisplayName("07-联机通讯|Communication"), Description("联机通讯|Communication")]
        public bool Communication
        {
            get { return communication; }
            set { communication = value; }
        }

        private bool notNeedPaste = false;
        [Category(DebugSet), DisplayName("08-无需贴标|Not Need Paste"), Description("无需贴标|Not Need Paste")]
        public bool NotNeedPaste
        {
            get { return notNeedPaste; }
            set { notNeedPaste = value; }
        }

        private bool largeLabel = false;
        [Category(DebugSet), DisplayName("09-需贴大标|Large Label"), Description("需贴大标|Large Label")]
        public bool LargeLabel
        {
            get { return largeLabel; }
            set { largeLabel = value; }
        }

        private bool skuChange = false;
        [Category(DebugSet), DisplayName("10-料号改变|Sku Changed"), Description("料号改变|Sku Changed")]
        public bool SkuChange
        {
            get { return skuChange; }
            set { skuChange = value; }
        }

        #endregion
    }

    public class CCDConfig : Setting<CCDConfig>
    {
        private const String BaseSet = "00-基础设置|Base Setting";

        #region 基础设置

        private bool virtualCCD = false;
        [Category(BaseSet), DisplayName("00-虚拟相机|Virtual CCD"), Description("虚拟相机|Virtual CCD")]
        public bool VirtualCCD
        {
            get { return virtualCCD; }
            set { virtualCCD = value; }
        }

        private string cCD1Name = "CCD1";
        [Category(BaseSet), DisplayName("01-相机一ID|CCD 01 ID"), Description("相机一ID|CCD 01 ID")]
        public string CCD1Name
        {
            get { return cCD1Name; }
            set { cCD1Name = value; }
        }

        private string cCD2Name = "CCD2";
        [Category(BaseSet), DisplayName("02-相机二ID|CCD 02 ID"), Description("相机二ID|CCD 02 ID")]
        public string CCD2Name
        {
            get { return cCD2Name; }
            set { cCD2Name = value; }
        }

        private string cCD3Name = "CCD3";
        [Category(BaseSet), DisplayName("03-相机三ID|CCD 03 ID"), Description("相机三ID|CCD 03 ID")]
        public string CCD3Name
        {
            get { return cCD3Name; }
            set { cCD3Name = value; }
        }

        private string cCDDebug = "CCD";
        [Category(BaseSet), DisplayName("04-CCD调试密码|CCD Debug Password"), Description("CCD调试密码|CCD Debug Password")]
        public string CCDDebug
        {
            get { return cCDDebug; }
            set { cCDDebug = value; }
        }

        #endregion

        private const String DataDifferentiateSet = "01-数据判别设置|Data Differentiate Setting";

        #region 数据判别


        private string[] b5_ADDforHaveBob = { "EU", "IN" };
        [Category(DataDifferentiateSet), DisplayName("00-B5有BOB标签ADD|B5 ADD For Have Bob"), Description("B5类型有BOB标签的ADD|B5 ADD For Have Bob")]
        public string[] B5_ADDforHaveBob
        {
            get { return b5_ADDforHaveBob; }
            set { b5_ADDforHaveBob = value; }
        }

        private string[] s5_ADDforHaveBob = { "EU", "IN" };
        [Category(DataDifferentiateSet), DisplayName("01-S5有BOB标签ADD|S5 ADD For Have Bob"), Description("S5类型有BOB标签的ADD|S5 ADD For Have Bob")]
        public string[] S5_ADDforHaveBob
        {
            get { return s5_ADDforHaveBob; }
            set { s5_ADDforHaveBob = value; }
        }

        private string[] b5M_ADDforHaveBob = { "EU", "IN" };
        [Category(DataDifferentiateSet), DisplayName("02-B5M有BOB标签ADD|B5M ADD For Have Bob"), Description("B5M类型有BOB标签的ADD|B5M ADD For Have Bob")]
        public string[] B5M_ADDforHaveBob
        {
            get { return b5M_ADDforHaveBob; }
            set { b5M_ADDforHaveBob = value; }
        }

        private int iMEILength = 15;
        [Category(DataDifferentiateSet), DisplayName("03-IMEI长度|IMEI Length"), Description("IMEI长度|IMEI Length")]
        public int IMEILength
        {
            get { return iMEILength; }
            set { iMEILength = value; }
        }

        private string iMEIInitial = "35";
        [Category(DataDifferentiateSet), DisplayName("04-IMEI首字母|IMEI Initial"), Description("IMEI首字母|IMEI Initial")]
        public string IMEIInitial
        {
            get { return iMEIInitial; }
            set { iMEIInitial = value; }
        }

        #endregion

        private const String ColorCode = "02-颜色代号|Color Code";

        #region 颜色代号

        private string code_Black = "BLK";
        [Category(ColorCode), DisplayName("01-黑色|Code Back"), Description("黑色|Code Back")]
        public string Code_Black
        {
            get { return code_Black; }
            set { code_Black = value; }
        }

        private string code_Blue = "BUE";
        [Category(ColorCode), DisplayName("02-蓝色|Code Blue"), Description("蓝色|Code Blue")]
        public string Code_Blue
        {
            get { return code_Blue; }
            set { code_Blue = value; }
        }

        private string code_White = "WHT";
        [Category(ColorCode), DisplayName("03-白色|Code White"), Description("白色|Code White")]
        public string Code_White
        {
            get { return code_White; }
            set { code_White = value; }
        }

        private string code_Orange = "ORG";
        [Category(ColorCode), DisplayName("04-橙色|Code Orange"), Description("橙色|Code Orange")]
        public string Code_Orange
        {
            get { return code_Orange; }
            set { code_Orange = value; }
        }

        #endregion

        private const String ExTimeSet = "03-曝光设置|Exposure Setting";

        #region  曝光设置

        private int cCD1_ExTime = 3000;
        [Category(ExTimeSet), DisplayName("00-CCD 01 曝光|CCD 01 Exposure"), Description("CCD 01 曝光|CCD 01 Exposure")]
        public int CCD1_ExTime
        {
            get { return cCD1_ExTime; }
            set { cCD1_ExTime = value; }
        }

        private int cCD2_GExTime = 3000;
        [Category(ExTimeSet), DisplayName("01-CCD 02 GLabel 曝光|CCD 02 GLabel Exposure"), Description("CCD 02 GLabel 曝光|CCD 02 GLabel Exposure")]
        public int CCD2_GExTime
        {
            get { return cCD2_GExTime; }
            set { cCD2_GExTime = value; }
        }

        private int cCD2_RExTime = 3000;
        [Category(ExTimeSet), DisplayName("02-CCD 02 Retail 曝光|CCD 02 Retail Exposure"), Description("CCD 02 Retail 曝光|CCD 02 Retail Exposure")]
        public int CCD2_RExTime
        {
            get { return cCD2_RExTime; }
            set { cCD2_RExTime = value; }
        }

        private int cCD3_ExTime = 3000;
        [Category(ExTimeSet), DisplayName("03-CCD 03 曝光|CCD 03 Exposure"), Description("CCD 03 曝光|CCD 03 Exposure")]
        public int CCD3_ExTime
        {
            get { return cCD3_ExTime; }
            set { cCD3_ExTime = value; }
        }

        private int take_Delay = 0;
        [Category(ExTimeSet), DisplayName("04-打光延时|OptLight Delay"), Description("打光延时|OptLight Delay")]
        public int Take_Delay
        {
            get { return take_Delay; }
            set { take_Delay = value; }
        }

        private int count_01 = 0;
        [Category(ExTimeSet), DisplayName("05-GLabel打光次数|GLabel OptLight Count"), Description("GLabel打光次数|GLabel OptLight Count")]
        public int Count_01
        {
            get { return count_01; }
            set { count_01 = value; }
        }

        private int reduce_Value_01 = 0;
        [Category(ExTimeSet), DisplayName("06-GLabel打光递减值|GLabel Light Reduce Value"), Description("GLabel打光递减值|GLabel Light Reduce Value")]
        public int Reduce_Value_01
        {
            get { return reduce_Value_01; }
            set { reduce_Value_01 = value; }
        }

        private int count_02 = 2;
        [Category(ExTimeSet), DisplayName("07-BarCode打光次数|BarCode OptLight Count"), Description("BarCode打光次数|BarCode OptLight Count")]
        public int Count_02
        {
            get { return count_02; }
            set { count_02 = value; }
        }

        private int reduce_Value_02 = 10;
        [Category(ExTimeSet), DisplayName("08-BarCode打光变化值|BarCode Light Change Value"), Description("BarCode打光递减值|BarCode Light Change Value")]
        public int Reduce_Value_02
        {
            get { return reduce_Value_02; }
            set { reduce_Value_02 = value; }
        }

        #endregion

        private const String ColorAreaSet = "04-阈值设置|Area Setting";

        #region 阈值设置

        private int colorArea_Black = 50;
        [Category(ColorAreaSet), DisplayName("00-黑色阈值设置|Black Area"), Description("黑色阈值设置|Black Area")]
        public int ColorArea_Black
        {
            get { return colorArea_Black; }
            set { colorArea_Black = value; }
        }

        private int colorArea_Blue = 80;
        [Category(ColorAreaSet), DisplayName("01-蓝色阈值设置|Blue Area"), Description("蓝色阈值设置|Blue Area")]
        public int ColorArea_Blue
        {
            get { return colorArea_Blue; }
            set { colorArea_Blue = value; }
        }

        private int colorArea_White = 100;
        [Category(ColorAreaSet), DisplayName("02-白色阈值设置|White Area"), Description("白色阈值设置|White Area")]
        public int ColorArea_White
        {
            get { return colorArea_White; }
            set { colorArea_White = value; }
        }

        #endregion

        private const String ModelScoreSet = "05-分数设置|ModelScore Setting";

        #region 分数设置

        private double modelScore_Type_top = 0.8;
        [Category(ModelScoreSet), DisplayName("00-正面型号识别分数|ModelScore For Front Type"), Description("正面型号识别分数|ModelScore For Front Type")]
        public double ModelScore_Type_top
        {
            get { return modelScore_Type_top; }
            set
            {
                if (value < 0.3) value = modelScore_Type_top;
                modelScore_Type_top = value;
            }
        }

        private double modelScore_Type_Retail = 0.8;
        [Category(ModelScoreSet), DisplayName("01-侧面型号识别分数|ModelScore For Retail Type"), Description("侧面型号识别分数|ModelScore For Retail Type")]
        public double ModelScore_Type_Retail
        {
            get { return modelScore_Type_Retail; }
            set
            {
                if (value < 0.3) value = modelScore_Type_Retail;
                modelScore_Type_Retail = value;
            }
        }

        private double modelScore_Type_BOB = 0.8;
        [Category(ModelScoreSet), DisplayName("02-底面型号识别分数|ModelScore For BOB Type"), Description("底面型号识别分数|ModelScore For BOB Type")]
        public double ModelScore_Type_BOB
        {
            get { return modelScore_Type_BOB; }
            set
            {
                if (value < 0.3) value = modelScore_Type_BOB;
                modelScore_Type_BOB = value;
            }
        }

        private double modelScore_Color_Retail = 0.8;
        [Category(ModelScoreSet), DisplayName("03-侧面颜色识别分数|ModelScore For Retail Color"), Description("侧面颜色识别分数|ModelScore For Retail Color")]
        public double ModelScore_Color_Retail
        {
            get { return modelScore_Color_Retail; }
            set
            {
                if (value < 0.3) value = modelScore_Color_Retail;
                modelScore_Color_Retail = value;
            }
        }

        private double modelScore_GLabel_Retail = 0.8;
        [Category(ModelScoreSet), DisplayName("04-侧面防伪识别分数|ModelScore For Retail GLabel"), Description("侧面防伪识别分数|ModelScore For Retail GLabel")]
        public double ModelScore_GLabel_Retail
        {
            get { return modelScore_GLabel_Retail; }
            set
            {
                if (value < 0.3) value = modelScore_GLabel_Retail;
                modelScore_GLabel_Retail = value;
            }
        }

        private double modelScore_Memory_Retail = 0.8;
        [Category(ModelScoreSet), DisplayName("05-侧面内存识别分数|ModelScore For Retail Memory"), Description("侧面内存识别分数|ModelScore For Retail Memory")]
        public double ModelScore_Memory_Retail
        {
            get { return modelScore_Memory_Retail; }
            set
            {
                if (value < 0.3) value = modelScore_Memory_Retail;
                modelScore_Memory_Retail = value;
            }
        }

        private double modelScore_Size_Retail = 0.8;
        [Category(ModelScoreSet), DisplayName("06-侧面大小识别分数|ModelScore For Retail Size"), Description("侧面大小识别分数|ModelScore For Retail Size")]
        public double ModelScore_Size_Retail
        {
            get { return modelScore_Size_Retail; }
            set
            {
                if (value < 0.3) value = modelScore_Size_Retail;
                modelScore_Size_Retail = value;
            }
        }

        private double modelScore_Price_BOB = 0.8;
        [Category(ModelScoreSet), DisplayName("07-底面价格识别分数|ModelScore For BOB Price"), Description("底面价格识别分数|ModelScore For BOB Price")]
        public double ModelScore_Price_BOB
        {
            get { return modelScore_Price_BOB; }
            set
            {
                if (value < 0.3) value = modelScore_Price_BOB;
                modelScore_Price_BOB = value;
            }
        }

        private double modelScore_Date_BOB = 0.8;
        [Category(ModelScoreSet), DisplayName("08-底面日期识别分数|ModelScore For BOB Date"), Description("底面日期识别分数|ModelScore For BOB Date")]
        public double ModelScore_Date_BOB
        {
            get { return modelScore_Date_BOB; }
            set
            {
                if (value < 0.3) value = modelScore_Date_BOB;
                modelScore_Date_BOB = value;
            }
        }

        #endregion

        private const String BarcodeSet = "06-条码识别设置|Barcode identification Set";

        #region 条码识别设置

        private double retail_Barcode_Size_Min = 1.5;
        [Category(BarcodeSet), DisplayName("00-Retail条码最小元素尺寸|Minimum element size of Retail barcode"), Description("Retail条码最小元素尺寸|Minimum element size of Retail barcode")]
        public double Retail_Barcode_Size_Min
        {
            get { return retail_Barcode_Size_Min; }
            set
            {
                if (value > Retail_Barcode_Size_Max) value = Retail_Barcode_Size_Max;
                retail_Barcode_Size_Min = value;
            }
        }

        private double retail_Barcode_Size_Max = 2;
        [Category(BarcodeSet), DisplayName("01-Retail条码最大元素尺寸|Maximum element size of Retail barcode"), Description("Retail条码最大元素尺寸|Maximum element size of Retail barcode")]
        public double Retail_Barcode_Size_Max
        {
            get { return retail_Barcode_Size_Max; }
            set
            {
                if (value < Retail_Barcode_Size_Min) value = Retail_Barcode_Size_Min;
                retail_Barcode_Size_Max = value;
            }
        }

        #endregion

        private const String EVTSet = "07-训线设置|DVT Setting";

        #region 训线设置

        private bool cCDDetection = true;
        [Category(EVTSet), DisplayName("00-视觉检测开关|CCD Detection Switch"), Description("视觉检测开关|CCD Detection Switch")]
        public bool CCDDetection
        {
            get { return cCDDetection; }
            set { cCDDetection = value; }
        }

        private bool weightDetection = true;
        [Category(EVTSet), DisplayName("01-称重检测开关|Weight Detection Switch"), Description("称重检测开关|Weight Detection Switch")]
        public bool WeightDetection
        {
            get { return weightDetection; }
            set { weightDetection = value; }
        }
        #endregion
    }

    public class ScannerConfig : Setting<ScannerConfig>
    {
        private const String BaseSet = "00-基础设置|Base Setting";

        #region 基础设置

        private SerialPortName protName = SerialPortName.COM1;
        [Category(BaseSet), DisplayName("00-串口号|Serial Prot"), Description("串口号|Serial Prot")]
        public SerialPortName ProtName
        {
            get { return protName; }
            set { protName = value; }
        }

        private SerialBaudRate banudRate = SerialBaudRate.BaudRate_115200;
        [Category(BaseSet), DisplayName("01-波特率|Serial BaudRate"), Description("波特率|Serial BaudRate")]
        public SerialBaudRate BanudRate
        {
            get { return banudRate; }
            set { banudRate = value; }
        }

        private SerialDataBits dataBits = SerialDataBits.DataBits_8;
        [Category(BaseSet), DisplayName("02-数据位长|Serial DataBits"), Description("数据位长|Serial DataBits")]
        public SerialDataBits DataBits
        {
            get { return dataBits; }
            set { dataBits = value; }
        }

        private Parity parity = Parity.None;
        [Category(BaseSet), DisplayName("03-奇偶校验位|Serial Parity"), Description("奇偶校验位|Serial Parity")]
        public Parity Parity
        {
            get { return parity; }
            set { parity = value; }
        }

        private StopBits stopBits = StopBits.One;
        [Category(BaseSet), DisplayName("04-停止位|Serial StopBits"), Description("停止位|Serial StopBits")]
        public StopBits StopBits
        {
            get { return stopBits; }
            set { stopBits = value; }
        }

        #endregion

        private const String OverTimeSet = "01-超时设置|OverTime Setting";

        #region 超时设置

        private Int32 overTime = 2;
        [Category(OverTimeSet), DisplayName("00-超时|OverTime"), Description("超时|OverTime")]
        public Int32 OverTime
        {
            get { return overTime; }
            set { overTime = value; }
        }

        #endregion

        private const String BarcodeSet = "02-条码设置|Barcode Setting";

        #region 条码设置

        private Int32 length = 14;
        [Category(BarcodeSet), DisplayName("00-条码长度|Barcode Length"), Description("条码长度|Barcode Length")]
        public Int32 Length
        {
            get { return length; }
            set { length = value; }
        }

        private String lock_DSN = string.Empty;
        [Category(BarcodeSet), DisplayName("01-锁定DSN|Lock DSN"), Description("锁定DSN|Lock DSN")]
        public String Lock_DSN
        {
            get { return lock_DSN; }
            set { lock_DSN = value; }
        }

        #endregion    
    }

    public class ScalseConfig : Setting<ScalseConfig>
    {
        private const String BaseSet = "00-基础设置|Base Setting";

        #region 基础设置

        private SerialPortName protName = SerialPortName.COM1;
        [Category(BaseSet), DisplayName("00-串口号|Serial Prot"), Description("串口号|Serial Prot")]
        public SerialPortName ProtName
        {
            get { return protName; }
            set { protName = value; }
        }

        private SerialBaudRate banudRate = SerialBaudRate.BaudRate_115200;
        [Category(BaseSet), DisplayName("01-波特率|Serial BaudRate"), Description("波特率|Serial BaudRate")]
        public SerialBaudRate BanudRate
        {
            get { return banudRate; }
            set { banudRate = value; }
        }

        private SerialDataBits dataBits = SerialDataBits.DataBits_8;
        [Category(BaseSet), DisplayName("02-数据位长|Serial DataBits"), Description("数据位长|Serial DataBits")]
        public SerialDataBits DataBits
        {
            get { return dataBits; }
            set { dataBits = value; }
        }

        private Parity parity = Parity.None;
        [Category(BaseSet), DisplayName("03-奇偶校验位|Serial Parity"), Description("奇偶校验位|Serial Parity")]
        public Parity Parity
        {
            get { return parity; }
            set { parity = value; }
        }

        private StopBits stopBits = StopBits.One;
        [Category(BaseSet), DisplayName("04-停止位|Serial StopBits"), Description("停止位|Serial StopBits")]
        public StopBits StopBits
        {
            get { return stopBits; }
            set { stopBits = value; }
        }

        #endregion

        private const String OverTimeSet = "01-超时设置|OverTime Setting";

        #region 超时设置

        private Int32 overTime = 2;
        [Category(OverTimeSet), DisplayName("00-超时|OverTime"), Description("超时|OverTime")]
        public Int32 OverTime
        {
            get { return overTime; }
            set { overTime = value; }
        }

        #endregion

        private const String WeighSet = "02-称重设置|Weigh Setting";

        #region 称重设置

        private double upperLimit_First = 8;
        [Category(WeighSet), DisplayName("00-第一判断上限|UpperLimit First"), Description("第一判断上限|UpperLimit First")]
        public double UpperLimit_First
        {
            get { return upperLimit_First; }
            set
            {
                if (value < 1 || value > 10) value = 8;
                upperLimit_First = value;
            }
        }

        private double lowerLimit_First = 8;
        [Category(WeighSet), DisplayName("01-第一判断下限|LowerLimit First"), Description("第一判断下限|LowerLimit First")]
        public double LowerLimit_First
        {
            get { return lowerLimit_First; }
            set
            {
                if (value < 1 || value > 10) value = 8;
                lowerLimit_First = value;
            }
        }

        private double upperLimit_Second = 2;
        [Category(WeighSet), DisplayName("02-第二判断上限|UpperLimit Second"), Description("第二判断上限|UpperLimit Second")]
        public double UpperLimit_Second
        {
            get { return upperLimit_Second; }
            set
            {
                if (value < 1 || value > 10 || value > upperLimit_First) value = upperLimit_First;
                upperLimit_Second = value;
            }
        }

        private double lowerLimit_Second = 2;
        [Category(WeighSet), DisplayName("03-第二判断下限|LowerLimit Second"), Description("第二判断下限|LowerLimit Second")]
        public double LowerLimit_Second
        {
            get { return lowerLimit_Second; }
            set
            {
                if (value < 1 || value > 10 || value > lowerLimit_First) value = lowerLimit_First;
                lowerLimit_Second = value;
            }
        }

        private bool weight_Clear = false;
        [Category(WeighSet), DisplayName("04-重量清除|Clear Weight"), Description("重量清除|Clear Weight")]
        public bool Weight_Clear
        {
            get { return weight_Clear; }
            set { weight_Clear = value; }
        }

        #endregion  
    }

    public class OptLightConfig : Setting<OptLightConfig>
    {
        private const String BaseSet = "01-基础设置|Base Setting";

        #region 基础设置

        private SerialPortName protName = SerialPortName.COM1;
        [Category(BaseSet), DisplayName("00-串口号|Serial Prot"), Description("串口号|Serial Prot")]
        public SerialPortName ProtName
        {
            get { return protName; }
            set { protName = value; }
        }

        #endregion

        private const String Channel_01Set = "01-通道一设置|Channel 01 Setting";

        #region 通道一设置

        private int channel_01_Black = 100;
        [Category(Channel_01Set), DisplayName("00-黑色|Black"), Description("黑色|Black")]
        public int Channel_01_Black
        {
            get { return channel_01_Black; }
            set { channel_01_Black = value; }
        }

        private int channel_01_Blue = 100;
        [Category(Channel_01Set), DisplayName("01-蓝色|Blue"), Description("蓝色|Blue")]
        public int Channel_01_Blue
        {
            get { return channel_01_Blue; }
            set { channel_01_Blue = value; }
        }

        private int channel_01_White = 100;
        [Category(Channel_01Set), DisplayName("02-白色|White"), Description("白色|White")]
        public int Channel_01_White
        {
            get { return channel_01_White; }
            set { channel_01_White = value; }
        }

        private int channel_01_Orange = 100;
        [Category(Channel_01Set), DisplayName("03-橙色|Orange"), Description("橙色|Orange")]
        public int Channel_01_Orange
        {
            get { return channel_01_Orange; }
            set { channel_01_Orange = value; }
        }

        #endregion

        private const String Channel_02Set = "02-通道二设置|Channel 02 Setting";

        #region 通道二设置

        private int channel_02_Black = 100;
        [Category(Channel_02Set), DisplayName("00-黑色|Black"), Description("黑色|Black")]
        public int Channel_02_Black
        {
            get { return channel_02_Black; }
            set { channel_02_Black = value; }
        }

        private int channel_02_Blue = 100;
        [Category(Channel_02Set), DisplayName("01-蓝色|Blue"), Description("蓝色|Blue")]
        public int Channel_02_Blue
        {
            get { return channel_02_Blue; }
            set { channel_02_Blue = value; }
        }

        private int channel_02_White = 100;
        [Category(Channel_02Set), DisplayName("02-白色|White"), Description("白色|White")]
        public int Channel_02_White
        {
            get { return channel_02_White; }
            set { channel_02_White = value; }
        }

        private int channel_02_Orange = 100;
        [Category(Channel_02Set), DisplayName("03-橙色|Orange"), Description("橙色|Orange")]
        public int Channel_02_Orange
        {
            get { return channel_02_Orange; }
            set { channel_02_Orange = value; }
        }

        #endregion

        private const String Channel_03Set = "03-通道三设置|Channel 03 Setting";

        #region 通道三设置

        private int channel_03_GLabel = 100;
        [Category(Channel_03Set), DisplayName("00-防伪标签|G Label"), Description("防伪标签|G Label")]
        public int Channel_03_GLabel
        {
            get { return channel_03_GLabel; }
            set { channel_03_GLabel = value; }
        }

        private int channel_03_Retail = 100;
        [Category(Channel_03Set), DisplayName("01-零售标签|Retail Label"), Description("零售标签|Retail Label")]
        public int Channel_03_Retail
        {
            get { return channel_03_Retail; }
            set { channel_03_Retail = value; }
        }

        #endregion

        private const String Channel_04Set = "03-通道四设置|Channel 04 Setting";

        #region 通道四设置

        private int channel_04_BOB = 100;
        [Category(Channel_04Set), DisplayName("00-BOB标签|BOB Label"), Description("BOB标签|BOB Label")]
        public int Channel_04_BOB
        {
            get { return channel_04_BOB; }
            set { channel_04_BOB = value; }
        }

        #endregion
    }

    public class IOConfig : Setting<IOConfig>
    {
        public ushort Cyl_D01Intercept;
        public ushort Cyl_D02Intercept;
        public ushort Cyl_D02Weigh;
        public ushort Cyl_D03Adjust;
        public ushort Cyl_D03Clamp;
        public ushort Cyl_D03Rotate;
        public ushort Cyl_D03Forward;
        public ushort Cyl_D03Lifter;
        public ushort Cyl_D03Carry;

        public ushort Cyl_D01Intercept_Org;
        public ushort Cyl_D01Intercept_On;
        public ushort Cyl_D02Intercept_Org;
        public ushort Cyl_D02Intercept_On;
        public ushort Cyl_D02Weigh_Org;
        public ushort Cyl_D02Weigh_On;
        public ushort Cyl_D03Adjust_Left_Org;
        public ushort Cyl_D03Adjust_Left_On;
        public ushort Cyl_D03Adjust_Right_Org;
        public ushort Cyl_D03Adjust_Right_On;
        public ushort Cyl_D03Clamp_Org;
        public ushort Cyl_D03Clamp_On;
        public ushort Cyl_D03Rotate_Org;
        public ushort Cyl_D03Rotate_On;
        public ushort Cyl_D03Forward_Org;
        public ushort Cyl_D03Forward_On;
        public ushort Cyl_D03Lifter_Org;
        public ushort Cyl_D03Lifter_On;
        public ushort Cyl_D03Carry_Org;
        public ushort Cyl_D03Carry_On;

        public ushort Belt_D01_Enable;
        public ushort Belt_D01_Direction;
        public ushort Belt_D01_Run;
        public ushort Belt_D01_Alarm;
        public ushort Belt_D02_Enable;
        public ushort Belt_D02_Direction;
        public ushort Belt_D02_Run;
        public ushort Belt_D02_Alarm;
        public ushort Belt_D03_Enable;
        public ushort Belt_D03_Direction;
        public ushort Belt_D03_Run;
        public ushort Belt_D03_Alarm;

        public ushort Signal_D01_Enter;
        public ushort Signal_D02_Enter;
        public ushort Signal_D03_Enter;
        public ushort Signal_NG_First;
        public ushort Signal_NG_Second;

        public ushort Signal_EMG;
        public ushort Signal_Reset;
        public ushort Signal_Run;
        public ushort Signal_Stop;
        public ushort Signal_SafeGuard;
        public ushort Beacon_Lamp_Red;
        public ushort Beacon_Lamp_Yellow;
        public ushort Beacon_Lamp_Green;
        public ushort Beacon_Buzzer;

        public ushort Station_Next_Ready;
        public ushort Station_Next_GetBox;
        public ushort Station_GetReady_Input;
        public ushort Station_GetReady_Output;
        public ushort Station_NotPaste;
        public ushort Station_LabelType;
        public ushort Station_SKUChange;
    }

    public class PassWordConfig : Setting<PassWordConfig>
    {
        private string normalPassword = "Normal";

        public string NormalPassword
        {
            get { return normalPassword; }
            set { normalPassword = value; }
        }

        private string administratorPassword = "Administrator";

        public string AdministratorPassword
        {
            get { return administratorPassword; }
            set { administratorPassword = value; }
        }

        private string superAdministratorPassword = "SuperAdministrator";

        public string SuperAdministratorPassword
        {
            get { return superAdministratorPassword; }
            set { superAdministratorPassword = value; }
        }

        private AccessLevel defaultUser = AccessLevel.Guest;

        public AccessLevel DefaultUser
        {
            get { return defaultUser; }
            set { defaultUser = value; }
        }
    }

    public class TotalConfig : Setting<TotalConfig>
    {
        private ulong passCount = 0;

        public ulong PassCount
        {
            get { return passCount; }
            set { passCount = value; }
        }

        private ulong ngCount = 0;

        public ulong NgCount
        {
            get { return ngCount; }
            set { ngCount = value; }
        }

        private ulong boxCount = 0;

        public ulong BoxCount
        {
            get { return boxCount; }
            set { boxCount = value; }
        }

        private double passRate = 0.0;

        public double PassRate
        {
            get { return passRate; }
            set { passRate = value; }
        }
    }

    public class WeightConfig : Setting<WeightConfig>
    {
        private double standard = 0.0;

        public double Standard
        {
            get { return standard; }
            set { standard = value; }
        }

        private ulong boxCount = 0;

        public ulong BoxCount
        {
            get { return boxCount; }
            set { boxCount = value; }
        }

        private double weightSum = 0.0;

        public double WeightSum
        {
            get { return weightSum; }
            set { weightSum = value; }
        }

        private ulong sumCount = 0;

        public ulong SumCount
        {
            get { return sumCount; }
            set { sumCount = value; }
        }

        private string[] sKU;

        public string[] SKU
        {
            get { return sKU; }
            set { sKU = value; }
        }

        private string[] SKU-Standard
    }

    #endregion

    #region 控件文本

    public class FormAboutName : Setting<FormAboutName>
    {
        private string[] label_Product = { "产品信息:", "Product Information:" };

        public string[] Label_Product
        {
            get { return label_Product; }
            set { label_Product = value; }
        }
        private string[] label_Versions = { "版本信息:", "Versions Information:" };

        public string[] Label_Versions
        {
            get { return label_Versions; }
            set { label_Versions = value; }
        }

        private string[] label_Company = { "制造商:", "Manufacturer:" };

        public string[] Label_Company
        {
            get { return label_Company; }
            set { label_Company = value; }
        }
        private string[] label_Project = { "项目:", "Project:" };

        public string[] Label_Project
        {
            get { return label_Project; }
            set { label_Project = value; }
        }
        private string[] label_Copyright = { "版权:", "Copyright:" };

        public string[] Label_Copyright
        {
            get { return label_Copyright; }
            set { label_Copyright = value; }
        }

        private string[] tb_Product = { "CCD称重", "CCD & Weigh" };

        public string[] Tb_Product
        {
            get { return tb_Product; }
            set { tb_Product = value; }
        }
        private string[] tb_Versions = { "01.00.00", "01.00.00" };

        public string[] Tb_Versions
        {
            get { return tb_Versions; }
            set { tb_Versions = value; }
        }
        private string[] tb_Company = { "东莞爱康电子科技", "东莞爱康电子科技" };

        public string[] Tb_Company
        {
            get { return tb_Company; }
            set { tb_Company = value; }
        }
        private string[] tb_Project = { "B5S5自动线", "B5S5 Auto Line" };

        public string[] Tb_Project
        {
            get { return tb_Project; }
            set { tb_Project = value; }
        }
        private string[] tb_Copyright = { "© Allegro 2019", "© Allegro 2019" };

        public string[] Tb_Copyright
        {
            get { return tb_Copyright; }
            set { tb_Copyright = value; }
        }
    }

    public class FormInitName : Setting<FormInitName>
    {
        private string[] init_Title = { "软件加载中......", "Software Initialization......" };

        public string[] Init_Title
        {
            get { return init_Title; }
            set { init_Title = value; }
        }
        private string[] init_IOCard = { "IO卡初始化", "IOCard Initialization" };

        public string[] Init_IOCard
        {
            get { return init_IOCard; }
            set { init_IOCard = value; }
        }
        private string[] init_Scales = { "电子秤初始化", "Scales Initialization" };

        public string[] Init_Scales
        {
            get { return init_Scales; }
            set { init_Scales = value; }
        }
        private string[] init_CCD = { "CCD相机初始化", "CCD Initialization" };

        public string[] Init_CCD
        {
            get { return init_CCD; }
            set { init_CCD = value; }
        }
        private string[] init_Scanner = { "扫码枪初始化", "Scanner Initialization" };

        public string[] Init_Scanner
        {
            get { return init_Scanner; }
            set { init_Scanner = value; }
        }
        private string[] init_OPTControl = { "光源初始化", "OPTControl Initialization" };

        public string[] Init_OPTControl
        {
            get { return init_OPTControl; }
            set { init_OPTControl = value; }
        }
        private string[] init_NetWork = { "网络初始化", "NetWork Initialization" };

        public string[] Init_NetWork
        {
            get { return init_NetWork; }
            set { init_NetWork = value; }
        }
    }

    public class FormMainName : Setting<FormMainName>
    {
        private string[] btn_Setting = { "设置", "Setting" };

        public string[] Btn_Setting
        {
            get { return btn_Setting; }
            set { btn_Setting = value; }
        }
        private string[] btn_About = { "关于", "About" };

        public string[] Btn_About
        {
            get { return btn_About; }
            set { btn_About = value; }
        }
        private string[] btn_Total = { "产能报告", "Total Report" };

        public string[] Btn_Total
        {
            get { return btn_Total; }
            set { btn_Total = value; }
        }
        private string[] btn_LanguageChange = { "语言切换", "Language Change" };

        public string[] Btn_LanguageChange
        {
            get { return btn_LanguageChange; }
            set { btn_LanguageChange = value; }
        }
        private string[] btn_LockDSN = { "锁定DSN", "Lock DSN" };

        public string[] Btn_LockDSN
        {
            get { return btn_LockDSN; }
            set { btn_LockDSN = value; }
        }
        private string[] cCD1 = { "相机一:彩盒正面", "CCD1:Color Box Front" };

        public string[] CCD1
        {
            get { return cCD1; }
            set { cCD1 = value; }
        }
        private string[] cCD2 = { "相机二:彩盒侧面", "CCD2:Color Box Side" };

        public string[] CCD2
        {
            get { return cCD2; }
            set { cCD2 = value; }
        }
        private string[] cCD3 = { "相机三:彩盒底面", "CCD3:Color Box Bottom" };

        public string[] CCD3
        {
            get { return cCD3; }
            set { cCD3 = value; }
        }
        private string[] gb_ProductionInfomation = { "产品信息", "Production Infomation" };

        public string[] Gb_ProductionInfomation
        {
            get { return gb_ProductionInfomation; }
            set { gb_ProductionInfomation = value; }
        }
        private string[] label_Weight = { "重量:", "Weight:" };

        public string[] Label_Weight
        {
            get { return label_Weight; }
            set { label_Weight = value; }
        }
        private string[] label_Standard = { "重量标准值:", "Standard Weight Value:" };

        public string[] Label_Standard
        {
            get { return label_Standard; }
            set { label_Standard = value; }
        }
        private string[] label_PassRate = { "良率:", "PassRate:" };

        public string[] Label_PassRate
        {
            get { return label_PassRate; }
            set { label_PassRate = value; }
        }
        private string[] info_SnCheck = { "路径检查", "DSN Check" };

        public string[] Info_SnCheck
        {
            get { return info_SnCheck; }
            set { info_SnCheck = value; }
        }
        private string[] info_WeighCheck = { "称重检查", "Weigh Check" };

        public string[] Info_WeighCheck
        {
            get { return info_WeighCheck; }
            set { info_WeighCheck = value; }
        }
        private string[] info_Color_Top = { "正面颜色检查", "Front Color Check" };

        public string[] Info_Color_Top
        {
            get { return info_Color_Top; }
            set { info_Color_Top = value; }
        }
        private string[] info_Color_Retail = { "侧面颜色检查", "Retail Color Check" };

        public string[] Info_Color_Retail
        {
            get { return info_Color_Retail; }
            set { info_Color_Retail = value; }
        }
        private string[] info_Type_Top = { "正面型号检查", "Pront Type Check" };

        public string[] Info_Type_Top
        {
            get { return info_Type_Top; }
            set { info_Type_Top = value; }
        }
        private string[] info_Type_Retail = { "侧面型号检查", "Retail Type Check" };

        public string[] Info_Type_Retail
        {
            get { return info_Type_Retail; }
            set { info_Type_Retail = value; }
        }
        private string[] info_Type_BOB = { "底面型号检查", "BOB Type Check" };

        public string[] Info_Type_BOB
        {
            get { return info_Type_BOB; }
            set { info_Type_BOB = value; }
        }
        private string[] info_GLabel = { "防伪标签检查", "Retail GLabel" };

        public string[] Info_GLabel
        {
            get { return info_GLabel; }
            set { info_GLabel = value; }
        }
        private string[] info_Memory = { "侧面内存检查", "Retail Mempry Check" };

        public string[] Info_Memory
        {
            get { return info_Memory; }
            set { info_Memory = value; }
        }
        private string[] info_Barcode = { "侧面条码检查", "Retail Barcode Check" };

        public string[] Info_Barcode
        {
            get { return info_Barcode; }
            set { info_Barcode = value; }
        }
        private string[] info_Price = { "底面信息检查", "BOB Information Check" };

        public string[] Info_Price
        {
            get { return info_Price; }
            set { info_Price = value; }
        }
        private string[] info_DataUpload = { "数据上传状态", "DataUpLoad Status" };

        public string[] Info_DataUpload
        {
            get { return info_DataUpload; }
            set { info_DataUpload = value; }
        }
        private string[] gb_RunningInformation = { "运行信息", "Running Information" };

        public string[] Gb_RunningInformation
        {
            get { return gb_RunningInformation; }
            set { gb_RunningInformation = value; }
        }
        private string[] gb_Operation = { "操作", "Operation" };

        public string[] Gb_Operation
        {
            get { return gb_Operation; }
            set { gb_Operation = value; }
        }
        private string[] gb_OPMachine = { "设备操作", "Machine Operation" };

        public string[] Gb_OPMachine
        {
            get { return gb_OPMachine; }
            set { gb_OPMachine = value; }
        }
        private string[] gb_OPD01 = { "入料段操作", "D01 Operation" };

        public string[] Gb_OPD01
        {
            get { return gb_OPD01; }
            set { gb_OPD01 = value; }
        }
        private string[] gb_OPD02 = { "检测段操作", "D02 Operation" };

        public string[] Gb_OPD02
        {
            get { return gb_OPD02; }
            set { gb_OPD02 = value; }
        }
        private string[] gb_OPD03 = { "翻转段操作", "D03 Operation" };

        public string[] Gb_OPD03
        {
            get { return gb_OPD03; }
            set { gb_OPD03 = value; }
        }
        private string[] btn_MachineStop = { "停止", "Stop" };

        public string[] Btn_MachineStop
        {
            get { return btn_MachineStop; }
            set { btn_MachineStop = value; }
        }
        private string[] btn_MachineReset = { "复位", "Reset" };

        public string[] Btn_MachineReset
        {
            get { return btn_MachineReset; }
            set { btn_MachineReset = value; }
        }
        private string[] btn_MachineRun = { "启动", "Run" };

        public string[] Btn_MachineRun
        {
            get { return btn_MachineRun; }
            set { btn_MachineRun = value; }
        }
        private string[] btn_D01Stop = { "停止", "Stop" };

        public string[] Btn_D01Stop
        {
            get { return btn_D01Stop; }
            set { btn_D01Stop = value; }
        }
        private string[] btn_D01Reset = { "复位", "Reset" };

        public string[] Btn_D01Reset
        {
            get { return btn_D01Reset; }
            set { btn_D01Reset = value; }
        }
        private string[] btn_D01Run = { "启动", "Run" };

        public string[] Btn_D01Run
        {
            get { return btn_D01Run; }
            set { btn_D01Run = value; }
        }
        private string[] btn_D02Stop = { "停止", "Stop" };

        public string[] Btn_D02Stop
        {
            get { return btn_D02Stop; }
            set { btn_D02Stop = value; }
        }
        private string[] btn_D02Reset = { "复位", "Reset" };

        public string[] Btn_D02Reset
        {
            get { return btn_D02Reset; }
            set { btn_D02Reset = value; }
        }
        private string[] btn_D02Run = { "启动", "Run" };

        public string[] Btn_D02Run
        {
            get { return btn_D02Run; }
            set { btn_D02Run = value; }
        }
        private string[] btn_D03Stop = { "停止", "Stop" };

        public string[] Btn_D03Stop
        {
            get { return btn_D03Stop; }
            set { btn_D03Stop = value; }
        }
        private string[] btn_D03Reset = { "复位", "Reset" };

        public string[] Btn_D03Reset
        {
            get { return btn_D03Reset; }
            set { btn_D03Reset = value; }
        }
        private string[] btn_D03Run = { "启动", "Run" };

        public string[] Btn_D03Run
        {
            get { return btn_D03Run; }
            set { btn_D03Run = value; }
        }
        private string[] btn_MachineBuzzer = { "取消警报", "Clear Alarm" };

        public string[] Btn_MachineBuzzer
        {
            get { return btn_MachineBuzzer; }
            set { btn_MachineBuzzer = value; }
        }
        private string[] btn_ClearTotal = { "清空产能", "Clear Capacity" };

        public string[] Btn_ClearTotal
        {
            get { return btn_ClearTotal; }
            set { btn_ClearTotal = value; }
        }
        private string[] label_PassWord = { "密码:", "Password:" };

        public string[] Label_PassWord
        {
            get { return label_PassWord; }
            set { label_PassWord = value; }
        }
        private string[] btn_CCDDebug = { "相机调试", "CCDDebug" };

        public string[] Btn_CCDDebug
        {
            get { return btn_CCDDebug; }
            set { btn_CCDDebug = value; }
        }

        private string[] status_EMG = { "急停状态", "Status EMG" };

        public string[] Status_EMG
        {
            get { return status_EMG; }
            set { status_EMG = value; }
        }

        private string[] status_SafeGuard = { "门禁状态", "Status SafeGuard" };

        public string[] Status_SafeGuard
        {
            get { return status_SafeGuard; }
            set { status_SafeGuard = value; }
        }
    }

    public class FormMsgBoxName : Setting<FormMsgBoxName>
    {

    }

    public class FormSettingName : Setting<FormSettingName>
    {
        private string[] btn_Beacon_Buzzer = { "蜂鸣器", "Buzzer" };

        public string[] Btn_Beacon_Buzzer
        {
            get { return btn_Beacon_Buzzer; }
            set { btn_Beacon_Buzzer = value; }
        }
        private string[] btn_Beacon_Lamp_Green = { "绿灯", "Lamp Green" };

        public string[] Btn_Beacon_Lamp_Green
        {
            get { return btn_Beacon_Lamp_Green; }
            set { btn_Beacon_Lamp_Green = value; }
        }
        private string[] btn_Beacon_Lamp_Yellow = { "黄灯", "Lamp Yellow" };

        public string[] Btn_Beacon_Lamp_Yellow
        {
            get { return btn_Beacon_Lamp_Yellow; }
            set { btn_Beacon_Lamp_Yellow = value; }
        }
        private string[] btn_Beacon_Lamp_Red = { "红灯", "Lamp Red" };

        public string[] Btn_Beacon_Lamp_Red
        {
            get { return btn_Beacon_Lamp_Red; }
            set { btn_Beacon_Lamp_Red = value; }
        }
        private string[] btn_Belt_D03_Run = { "拉带三启动", "Belt D03 Run" };

        public string[] Btn_Belt_D03_Run
        {
            get { return btn_Belt_D03_Run; }
            set { btn_Belt_D03_Run = value; }
        }
        private string[] btn_Belt_D02_Run = { "拉带二启动", "Belt D02 Run" };

        public string[] Btn_Belt_D02_Run
        {
            get { return btn_Belt_D02_Run; }
            set { btn_Belt_D02_Run = value; }
        }
        private string[] btn_Belt_D01_Run = { "拉带一启动", "Belt D01 Run" };

        public string[] Btn_Belt_D01_Run
        {
            get { return btn_Belt_D01_Run; }
            set { btn_Belt_D01_Run = value; }
        }
        private string[] btn_Belt_D03_Direction = { "拉带三方向", "Belt D03 Direction" };

        public string[] Btn_Belt_D03_Direction
        {
            get { return btn_Belt_D03_Direction; }
            set { btn_Belt_D03_Direction = value; }
        }
        private string[] btn_Belt_D02_Direction = { "拉带二方向", "Belt D02 Direction" };

        public string[] Btn_Belt_D02_Direction
        {
            get { return btn_Belt_D02_Direction; }
            set { btn_Belt_D02_Direction = value; }
        }
        private string[] btn_Belt_D01_Direction = { "拉带一方向", "Belt D01 Direction" };

        public string[] Btn_Belt_D01_Direction
        {
            get { return btn_Belt_D01_Direction; }
            set { btn_Belt_D01_Direction = value; }
        }
        private string[] btn_Belt_D03_Enable = { "拉带三使能", "Belt D03 Enable" };

        public string[] Btn_Belt_D03_Enable
        {
            get { return btn_Belt_D03_Enable; }
            set { btn_Belt_D03_Enable = value; }
        }
        private string[] btn_Belt_D02_Enable = { "拉带二使能", "Belt D02 Enable" };

        public string[] Btn_Belt_D02_Enable
        {
            get { return btn_Belt_D02_Enable; }
            set { btn_Belt_D02_Enable = value; }
        }
        private string[] btn_Belt_D01_Enable = { "拉带一使能", "Belt D01 Enable" };

        public string[] Btn_Belt_D01_Enable
        {
            get { return btn_Belt_D01_Enable; }
            set { btn_Belt_D01_Enable = value; }
        }
        private string[] btn_VirtualAction_D03 = { "翻转段虚拟动作", "Virtual Action D03" };

        public string[] Btn_VirtualAction_D03
        {
            get { return btn_VirtualAction_D03; }
            set { btn_VirtualAction_D03 = value; }
        }
        private string[] btn_PassAction = { "Pass动作", "Pass Action" };

        public string[] Btn_PassAction
        {
            get { return btn_PassAction; }
            set { btn_PassAction = value; }
        }
        private string[] btn_NGAction = { "NG动作", "NG Action" };

        public string[] Btn_NGAction
        {
            get { return btn_NGAction; }
            set { btn_NGAction = value; }
        }
        private string[] btn_Station_SKUChange = { "料号变更信号", "Signal SKUChange" };

        public string[] Btn_Station_SKUChange
        {
            get { return btn_Station_SKUChange; }
            set { btn_Station_SKUChange = value; }
        }
        private string[] btn_Station_LabelType = { "封口标签类型信号", "Signal ClosureLabtl Type" };

        public string[] Btn_Station_LabelType
        {
            get { return btn_Station_LabelType; }
            set { btn_Station_LabelType = value; }
        }
        private string[] btn_Station_NotPaste = { "无需贴标信号", "Signal NotPaste" };

        public string[] Btn_Station_NotPaste
        {
            get { return btn_Station_NotPaste; }
            set { btn_Station_NotPaste = value; }
        }
        private string[] btn_Station_GetReady_Output = { "出料准备信号", "Station GetReady Output" };

        public string[] Btn_Station_GetReady_Output
        {
            get { return btn_Station_GetReady_Output; }
            set { btn_Station_GetReady_Output = value; }
        }
        private string[] btn_Cyl_D03Carry = { "NG搬运气缸", "D03 Carry" };

        public string[] Btn_Cyl_D03Carry
        {
            get { return btn_Cyl_D03Carry; }
            set { btn_Cyl_D03Carry = value; }
        }
        private string[] btn_Cyl_D03Rotate = { "翻转旋转气缸", "D03 Rotate" };

        public string[] Btn_Cyl_D03Rotate
        {
            get { return btn_Cyl_D03Rotate; }
            set { btn_Cyl_D03Rotate = value; }
        }
        private string[] btn_Cyl_D03Clamp = { "翻转夹子气缸", "D03 Clamp" };

        public string[] Btn_Cyl_D03Clamp
        {
            get { return btn_Cyl_D03Clamp; }
            set { btn_Cyl_D03Clamp = value; }
        }
        private string[] btn_Cyl_D03Forward = { "翻转平移气缸", "D03 Forward" };

        public string[] Btn_Cyl_D03Forward
        {
            get { return btn_Cyl_D03Forward; }
            set { btn_Cyl_D03Forward = value; }
        }
        private string[] btn_Cyl_D03Lifter = { "翻转升降气缸", "D03 Lifter" };

        public string[] Btn_Cyl_D03Lifter
        {
            get { return btn_Cyl_D03Lifter; }
            set { btn_Cyl_D03Lifter = value; }
        }

        private string[] btn_Cyl_D03Adjust = { "翻转整形气缸", "D03 Adjust" };

        public string[] Btn_Cyl_D03Adjust
        {
            get { return btn_Cyl_D03Adjust; }
            set { btn_Cyl_D03Adjust = value; }
        }
        private string[] btn_VirtualAction_D02 = { "检测段虚拟动作", "Virtual Action D02" };

        public string[] Btn_VirtualAction_D02
        {
            get { return btn_VirtualAction_D02; }
            set { btn_VirtualAction_D02 = value; }
        }
        private string[] btn_Cyl_D02Weigh = { "检测称重气缸", "D02 Weigh" };

        public string[] Btn_Cyl_D02Weigh
        {
            get { return btn_Cyl_D02Weigh; }
            set { btn_Cyl_D02Weigh = value; }
        }
        private string[] btn_Cyl_D02Intercept = { "检测阻挡气缸", "D02 Intercept" };

        public string[] Btn_Cyl_D02Intercept
        {
            get { return btn_Cyl_D02Intercept; }
            set { btn_Cyl_D02Intercept = value; }
        }
        private string[] btn_VirtualAction_D01 = { "入料段虚拟动作", "Virtual Action D01" };

        public string[] Btn_VirtualAction_D01
        {
            get { return btn_VirtualAction_D01; }
            set { btn_VirtualAction_D01 = value; }
        }
        private string[] btn_Station_GetReady_Input = { "入料准备信号", "Station GetReady Input" };

        public string[] Btn_Station_GetReady_Input
        {
            get { return btn_Station_GetReady_Input; }
            set { btn_Station_GetReady_Input = value; }
        }
        private string[] btn_Cyl_D01Intercept = { "入料阻挡气缸", "D01 Intercept" };

        public string[] Btn_Cyl_D01Intercept
        {
            get { return btn_Cyl_D01Intercept; }
            set { btn_Cyl_D01Intercept = value; }
        }
        private string[] btn_BeltAction = { "回流彩盒", "BackFlow Box" };

        public string[] Btn_BeltAction
        {
            get { return btn_BeltAction; }
            set { btn_BeltAction = value; }
        }

        private string[] gb_Step_Beacon = { "灯塔", "Beacon" };

        public string[] Gb_Step_Beacon
        {
            get { return gb_Step_Beacon; }
            set { gb_Step_Beacon = value; }
        }
        private string[] gb_Step_Belt = { "拉带", "Belt" };

        public string[] Gb_Step_Belt
        {
            get { return gb_Step_Belt; }
            set { gb_Step_Belt = value; }
        }
        private string[] gb_Step_D03 = { "翻转段", "D03" };

        public string[] Gb_Step_D03
        {
            get { return gb_Step_D03; }
            set { gb_Step_D03 = value; }
        }
        private string[] gb_Step_D02 = { "检测段", "D02" };

        public string[] Gb_Step_D02
        {
            get { return gb_Step_D02; }
            set { gb_Step_D02 = value; }
        }
        private string[] gb_Step_D01 = { "入料段", "D01" };

        public string[] Gb_Step_D01
        {
            get { return gb_Step_D01; }
            set { gb_Step_D01 = value; }
        }

        private string[] btn_CheckPath = { "检查路径", "Check Route" };

        public string[] Btn_CheckPath
        {
            get { return btn_CheckPath; }
            set { btn_CheckPath = value; }
        }

        private string[] btn_GetRetailData = { "获取Retail数据", "Get Retail Data" };

        public string[] Btn_GetRetailData
        {
            get { return btn_GetRetailData; }
            set { btn_GetRetailData = value; }
        }

        private string[] btn_GetBOBData = { "获取BOB数据", "Get BOB Data" };

        public string[] Btn_GetBOBData
        {
            get { return btn_GetBOBData; }
            set { btn_GetBOBData = value; }
        }

        private string[] btn_GetDutData = { "获取Dut数据", "Get Dut Data" };

        public string[] Btn_GetDutData
        {
            get { return btn_GetDutData; }
            set { btn_GetDutData = value; }
        }

        private string[] btn_GetClosure = { "获取封口", "Get Closure" };

        public string[] Btn_GetClosure
        {
            get { return btn_GetClosure; }
            set { btn_GetClosure = value; }
        }

        private string[] btn_UpLoadPass = { "数据上传", "UpLoad Pass" };

        public string[] Btn_UpLoadPass
        {
            get { return btn_UpLoadPass; }
            set { btn_UpLoadPass = value; }
        }

        private string[] label_CCD1_EXTime = { "相机一曝光:", "CCD1 Exposure:" };

        public string[] Label_CCD1_EXTime
        {
            get { return label_CCD1_EXTime; }
            set { label_CCD1_EXTime = value; }
        }

        private string[] label_CCD2_EXTime = { "相机二曝光:", "CCD2 Exposure:" };

        public string[] Label_CCD2_EXTime
        {
            get { return label_CCD2_EXTime; }
            set { label_CCD2_EXTime = value; }
        }

        private string[] label_CCD3_EXTime = { "相机三曝光:", "CCD3 Exposure:" };

        public string[] Label_CCD3_EXTime
        {
            get { return label_CCD3_EXTime; }
            set { label_CCD3_EXTime = value; }
        }

        private string[] btn_CCD1_TakePicture = { "相机一拍照", "CCD1 Take:Pictrue" };

        public string[] Btn_CCD1_TakePicture
        {
            get { return btn_CCD1_TakePicture; }
            set { btn_CCD1_TakePicture = value; }
        }

        private string[] btn_CCD2_TakePicture = { "相机二拍照", "CCD2 Take:Pictrue" };

        public string[] Btn_CCD2_TakePicture
        {
            get { return btn_CCD2_TakePicture; }
            set { btn_CCD2_TakePicture = value; }
        }

        private string[] btn_CCD3_TakePicture = { "相机三拍照", "CCD3 Take:Pictrue" };

        public string[] Btn_CCD3_TakePicture
        {
            get { return btn_CCD3_TakePicture; }
            set { btn_CCD3_TakePicture = value; }
        }

        private string[] btn_CCD1_ReadPicture = { "相机一读取照片", "CCD1 Read:Pictrue" };

        public string[] Btn_CCD1_ReadPicture
        {
            get { return btn_CCD1_ReadPicture; }
            set { btn_CCD1_ReadPicture = value; }
        }

        private string[] btn_CCD2_ReadPicture = { "相机二读取照片", "CCD2 Read:Pictrue" };

        public string[] Btn_CCD2_ReadPicture
        {
            get { return btn_CCD2_ReadPicture; }
            set { btn_CCD2_ReadPicture = value; }
        }

        private string[] btn_CCD3_ReadPicture = { "相机三读取照片", "CCD3 Read:Pictrue" };

        public string[] Btn_CCD3_ReadPicture
        {
            get { return btn_CCD3_ReadPicture; }
            set { btn_CCD3_ReadPicture = value; }
        }

        private string[] btn_CCD1_SavePicture = { "相机一保存照片", "CCD1 Save:Pictrue" };

        public string[] Btn_CCD1_SavePicture
        {
            get { return btn_CCD1_SavePicture; }
            set { btn_CCD1_SavePicture = value; }
        }

        private string[] btn_CCD2_SavePicture = { "相机二保存照片", "CCD2 Save:Pictrue" };

        public string[] Btn_CCD2_SavePicture
        {
            get { return btn_CCD2_SavePicture; }
            set { btn_CCD2_SavePicture = value; }
        }

        private string[] btn_CCD3_SavePicture = { "相机三保存照片", "CCD3 Save:Pictrue" };

        public string[] Btn_CCD3_SavePicture
        {
            get { return btn_CCD3_SavePicture; }
            set { btn_CCD3_SavePicture = value; }
        }

        private string[] btn_Type_Front = { "正面型号识别", "Type Front Discern" };

        public string[] Btn_Type_Front
        {
            get { return btn_Type_Front; }
            set { btn_Type_Front = value; }
        }

        private string[] btn_Color_Front = { "正面颜色识别", "Color Front Discern" };

        public string[] Btn_Color_Front
        {
            get { return btn_Color_Front; }
            set { btn_Color_Front = value; }
        }

        private string[] btn_GLabel_Retail = { "防伪识别", "GLabel Discern" };

        public string[] Btn_GLabel_Retail
        {
            get { return btn_GLabel_Retail; }
            set { btn_GLabel_Retail = value; }
        }

        private string[] btn_Type_Retail = { "侧面型号识别", "Type Retail Discern" };

        public string[] Btn_Type_Retail
        {
            get { return btn_Type_Retail; }
            set { btn_Type_Retail = value; }
        }

        private string[] btn_Memory_Retail = { "内存识别", "Memory Discern" };

        public string[] Btn_Memory_Retail
        {
            get { return btn_Memory_Retail; }
            set { btn_Memory_Retail = value; }
        }

        private string[] btn_Color_Retail = { "侧面颜色识别", "Color Retail Discern" };

        public string[] Btn_Color_Retail
        {
            get { return btn_Color_Retail; }
            set { btn_Color_Retail = value; }
        }

        private string[] btn_BarCode_Retail = { "条码识别", "BarCode Discern" };

        public string[] Btn_BarCode_Retail
        {
            get { return btn_BarCode_Retail; }
            set { btn_BarCode_Retail = value; }
        }

        private string[] btn_Type_BOB = { "底面型号识别", "Type BOB Discern" };

        public string[] Btn_Type_BOB
        {
            get { return btn_Type_BOB; }
            set { btn_Type_BOB = value; }
        }

        private string[] btn_Price_BOB = { "价格识别", "Price Discern" };

        public string[] Btn_Price_BOB
        {
            get { return btn_Price_BOB; }
            set { btn_Price_BOB = value; }
        }

        private string[] btn_Date_BOB = { "日期识别", "Date Discern" };

        public string[] Btn_Date_BOB
        {
            get { return btn_Date_BOB; }
            set { btn_Date_BOB = value; }
        }

        private string[] gb_CCDDebug = { "相机调试", "CCD Debug" };

        public string[] Gb_CCDDebug
        {
            get { return gb_CCDDebug; }
            set { gb_CCDDebug = value; }
        }

        private string[] gb_SFCDebug = { "SFC调试", "SFC Debug" };

        public string[] Gb_SFCDebug
        {
            get { return gb_SFCDebug; }
            set { gb_SFCDebug = value; }
        }

        #region
        private string[] gb_OptLightConfig = { "光源配置", "OptLight Config" };

        public string[] Gb_OptLightConfig
        {
            get { return gb_OptLightConfig; }
            set { gb_OptLightConfig = value; }
        }
        private string[] btn_OptLightOpen = { "开启光源控制器", "Open OptLight Controller" };

        public string[] Btn_OptLightOpen
        {
            get { return btn_OptLightOpen; }
            set { btn_OptLightOpen = value; }
        }
        private string[] btn_OptLightClose = { "关闭光源控制器", "Close OptLight Controller" };

        public string[] Btn_OptLightClose
        {
            get { return btn_OptLightClose; }
            set { btn_OptLightClose = value; }
        }
        private string[] optLightController = { "通道一:彩盒正面左", "通道二:彩盒正面右", "通道三:彩盒零售标签", "通道四:彩盒底部标签", "Channel 01:Color Box Front Left", "Channel 02:Color Box Front Right", "Channel 03:Color Box Retail Label", "Channel 04:Color Box BOB Label" };

        public string[] OptLightController
        {
            get { return optLightController; }
            set { optLightController = value; }
        }
        private string[] gb_OptLightController = { "光源控制器", "OptLight Controller" };

        public string[] Gb_OptLightController
        {
            get { return gb_OptLightController; }
            set { gb_OptLightController = value; }
        }
        private string[] btn_GetScalesResult = { "测试电子秤", "Scales Debug" };

        public string[] Btn_GetScalesResult
        {
            get { return btn_GetScalesResult; }
            set { btn_GetScalesResult = value; }
        }
        private string[] btn_ScalesOpen = { "打开电子秤", "Open Scales" };

        public string[] Btn_ScalesOpen
        {
            get { return btn_ScalesOpen; }
            set { btn_ScalesOpen = value; }
        }
        private string[] btn_ScalesClose = { "关闭电子秤", "Close Scales" };

        public string[] Btn_ScalesClose
        {
            get { return btn_ScalesClose; }
            set { btn_ScalesClose = value; }
        }
        private string[] btn_GetScannerResult = { "测试扫码枪", "Scanner Debug" };

        public string[] Btn_GetScannerResult
        {
            get { return btn_GetScannerResult; }
            set { btn_GetScannerResult = value; }
        }
        private string[] btn_ScannerOpen = { "开启扫码枪", "Open Scanner" };

        public string[] Btn_ScannerOpen
        {
            get { return btn_ScannerOpen; }
            set { btn_ScannerOpen = value; }
        }
        private string[] btn_ScannerClose = { "关闭扫码枪", "Close Scanner" };

        public string[] Btn_ScannerClose
        {
            get { return btn_ScannerClose; }
            set { btn_ScannerClose = value; }
        }
        private string[] gb_ScalesConfig = { "电子秤配置", "Scales Config" };

        public string[] Gb_ScalesConfig
        {
            get { return gb_ScalesConfig; }
            set { gb_ScalesConfig = value; }
        }
        private string[] gb_ScannerConfig = { "扫码枪配置", "Scanner Config" };

        public string[] Gb_ScannerConfig
        {
            get { return gb_ScannerConfig; }
            set { gb_ScannerConfig = value; }
        }
        private string[] gb_CCDConfig = { "视觉配置", "CCD Config" };

        public string[] Gb_CCDConfig
        {
            get { return gb_CCDConfig; }
            set { gb_CCDConfig = value; }
        }
        private string[] gb_MachineConfig = { "设备配置", "Machine Config" };

        public string[] Gb_MachineConfig
        {
            get { return gb_MachineConfig; }
            set { gb_MachineConfig = value; }
        }
        private string[] tp_OtherDebug = { "    其他调试    ", "     OtherDebug     " };

        public string[] Tp_OtherDebug
        {
            get { return tp_OtherDebug; }
            set { tp_OtherDebug = value; }
        }
        private string[] tp_StepDebug = { "    动作调试    ", "      StepDebug     " };

        public string[] Tp_StepDebug
        {
            get { return tp_StepDebug; }
            set { tp_StepDebug = value; }
        }
        private string[] tp_CylinderDebug = { "    气缸调试    ", "    CylinderDebug   " };

        public string[] Tp_CylinderDebug
        {
            get { return tp_CylinderDebug; }
            set { tp_CylinderDebug = value; }
        }
        private string[] tp_IODebug = { "    IO调试    ", "       IODebug      " };

        public string[] Tp_IODebug
        {
            get { return tp_IODebug; }
            set { tp_IODebug = value; }
        }
        private string[] tp_OptLightConfig = { "    光源配置    ", "   OptLightConfig   " };

        public string[] Tp_OptLightConfig
        {
            get { return tp_OptLightConfig; }
            set { tp_OptLightConfig = value; }
        }
        private string[] tp_SerialCOnfig = { "    串口配置    ", "    SerailConfig    " };

        public string[] Tp_SerialConfig
        {
            get { return tp_SerialCOnfig; }
            set { tp_SerialCOnfig = value; }
        }
        private string[] tp_MachineConfig = { "    设备配置    ", "    MachineConfig   " };

        public string[] Tp_MachineConfig
        {
            get { return tp_MachineConfig; }
            set { tp_MachineConfig = value; }
        }
        private string[] btn_UserManagement = { "用户管理", "UserManagement" };

        public string[] Btn_UserManagement
        {
            get { return btn_UserManagement; }
            set { btn_UserManagement = value; }
        }
        private string[] status_Level_03 = { "CCD配置管理", "CCDConfig" };

        public string[] Status_Level_03
        {
            get { return status_Level_03; }
            set { status_Level_03 = value; }
        }
        private string[] status_Level_02 = { "IO配置管理", "IOConfig" };

        public string[] Status_Level_02
        {
            get { return status_Level_02; }
            set { status_Level_02 = value; }
        }
        private string[] status_Level_01 = { "设备配置管理", "MachineConfig" };

        public string[] Status_Level_01
        {
            get { return status_Level_01; }
            set { status_Level_01 = value; }
        }
        private string[] label_AccessLevel = { "用户等级:", "Access Level:" };

        public string[] Label_AccessLevel
        {
            get { return label_AccessLevel; }
            set { label_AccessLevel = value; }
        }
        private string[] btn_SaveConfig = { "保存配置", "SaveConfig" };

        public string[] Btn_SaveConfig
        {
            get { return btn_SaveConfig; }
            set { btn_SaveConfig = value; }
        }

        private string[] gb_Input = { "输入", "Input" };

        public string[] Gb_Input
        {
            get { return gb_Input; }
            set { gb_Input = value; }
        }
        private string[] gb_Output = { "输出", "Output" };

        public string[] Gb_Output
        {
            get { return gb_Output; }
            set { gb_Output = value; }
        }
        private string[] gb_Output_D01 = { "入料段气缸", "D01 Cylinder" };

        public string[] Gb_Output_D01
        {
            get { return gb_Output_D01; }
            set { gb_Output_D01 = value; }
        }
        private string[] gb_Output_D02 = { "检测段气缸", "D02 Cylinder" };

        public string[] Gb_Output_D02
        {
            get { return gb_Output_D02; }
            set { gb_Output_D02 = value; }
        }
        private string[] gb_Output_D03 = { "翻转段气缸", "D03 Cylinder" };

        public string[] Gb_Output_D03
        {
            get { return gb_Output_D03; }
            set { gb_Output_D03 = value; }
        }
        #endregion

        #region IO
        private string[] cyl_D01Intercept = { "入料阻挡气缸", "Cyl D01Intercept" };

        public string[] Cyl_D01Intercept
        {
            get { return cyl_D01Intercept; }
            set { cyl_D01Intercept = value; }
        }
        private string[] cyl_D02Intercept = { "检测阻挡气缸", "Cyl D02Intercept" };

        public string[] Cyl_D02Intercept
        {
            get { return cyl_D02Intercept; }
            set { cyl_D02Intercept = value; }
        }
        private string[] cyl_D02Weigh = { "称重气缸", "Cyl D02Weigh" };

        public string[] Cyl_D02Weigh
        {
            get { return cyl_D02Weigh; }
            set { cyl_D02Weigh = value; }
        }
        private string[] cyl_D03Adjust = { "翻转整形气缸", "Cyl D03Adjust" };

        public string[] Cyl_D03Adjust
        {
            get { return cyl_D03Adjust; }
            set { cyl_D03Adjust = value; }
        }
        private string[] cyl_D03Clamp = { "翻转夹子气缸", "Cyl D03Clamp" };

        public string[] Cyl_D03Clamp
        {
            get { return cyl_D03Clamp; }
            set { cyl_D03Clamp = value; }
        }
        private string[] cyl_D03Rotate = { "旋转气缸", "Cyl D03Rotate" };

        public string[] Cyl_D03Rotate
        {
            get { return cyl_D03Rotate; }
            set { cyl_D03Rotate = value; }
        }
        private string[] cyl_D03Forward = { "翻转平移气缸", "Cyl D03Forward" };

        public string[] Cyl_D03Forward
        {
            get { return cyl_D03Forward; }
            set { cyl_D03Forward = value; }
        }
        private string[] cyl_D03Lifter = { "翻转升降气缸", "Cyl D03Lifter" };

        public string[] Cyl_D03Lifter
        {
            get { return cyl_D03Lifter; }
            set { cyl_D03Lifter = value; }
        }
        private string[] cyl_D03Carry = { "NG搬运气缸", "Cyl NGCarry" };

        public string[] Cyl_D03Carry
        {
            get { return cyl_D03Carry; }
            set { cyl_D03Carry = value; }
        }

        private string[] cyl_D01Intercept_Org = { "原点", "Org" };

        public string[] Cyl_D01Intercept_Org
        {
            get { return cyl_D01Intercept_Org; }
            set { cyl_D01Intercept_Org = value; }
        }
        private string[] cyl_D01Intercept_On = { "动点", "On" };

        public string[] Cyl_D01Intercept_On
        {
            get { return cyl_D01Intercept_On; }
            set { cyl_D01Intercept_On = value; }
        }
        private string[] cyl_D02Intercept_Org = { "原点", "Org" };

        public string[] Cyl_D02Intercept_Org
        {
            get { return cyl_D02Intercept_Org; }
            set { cyl_D02Intercept_Org = value; }
        }
        private string[] cyl_D02Intercept_On = { "动点", "On" };

        public string[] Cyl_D02Intercept_On
        {
            get { return cyl_D02Intercept_On; }
            set { cyl_D02Intercept_On = value; }
        }
        private string[] cyl_D02Weigh_Org = { "原点", "Org" };

        public string[] Cyl_D02Weigh_Org
        {
            get { return cyl_D02Weigh_Org; }
            set { cyl_D02Weigh_Org = value; }
        }
        private string[] cyl_D02Weigh_On = { "动点", "On" };

        public string[] Cyl_D02Weigh_On
        {
            get { return cyl_D02Weigh_On; }
            set { cyl_D02Weigh_On = value; }
        }
        private string[] cyl_D03Adjust_Left_Org = { "左原点", "Left Org" };

        public string[] Cyl_D03Adjust_Left_Org
        {
            get { return cyl_D03Adjust_Left_Org; }
            set { cyl_D03Adjust_Left_Org = value; }
        }
        private string[] cyl_D03Adjust_Left_On = { "左动点", "Left On" };

        public string[] Cyl_D03Adjust_Left_On
        {
            get { return cyl_D03Adjust_Left_On; }
            set { cyl_D03Adjust_Left_On = value; }
        }
        private string[] cyl_D03Adjust_Right_Org = { "右原点", "Right Org" };

        public string[] Cyl_D03Adjust_Right_Org
        {
            get { return cyl_D03Adjust_Right_Org; }
            set { cyl_D03Adjust_Right_Org = value; }
        }
        private string[] cyl_D03Adjust_Right_On = { "有动点", "Right On" };

        public string[] Cyl_D03Adjust_Right_On
        {
            get { return cyl_D03Adjust_Right_On; }
            set { cyl_D03Adjust_Right_On = value; }
        }
        private string[] cyl_D03Clamp_Org = { "原点", "Org" };

        public string[] Cyl_D03Clamp_Org
        {
            get { return cyl_D03Clamp_Org; }
            set { cyl_D03Clamp_Org = value; }
        }
        private string[] cyl_D03Clamp_On = { "动点", "On" };

        public string[] Cyl_D03Clamp_On
        {
            get { return cyl_D03Clamp_On; }
            set { cyl_D03Clamp_On = value; }
        }
        private string[] cyl_D03Rotate_Org = { "原点", "Org" };

        public string[] Cyl_D03Rotate_Org
        {
            get { return cyl_D03Rotate_Org; }
            set { cyl_D03Rotate_Org = value; }
        }
        private string[] cyl_D03Rotate_On = { "动点", "On" };

        public string[] Cyl_D03Rotate_On
        {
            get { return cyl_D03Rotate_On; }
            set { cyl_D03Rotate_On = value; }
        }
        private string[] cyl_D03Forward_Org = { "原点", "Org" };

        public string[] Cyl_D03Forward_Org
        {
            get { return cyl_D03Forward_Org; }
            set { cyl_D03Forward_Org = value; }
        }
        private string[] cyl_D03Forward_On = { "动点", "On" };

        public string[] Cyl_D03Forward_On
        {
            get { return cyl_D03Forward_On; }
            set { cyl_D03Forward_On = value; }
        }
        private string[] cyl_D03Lifter_Org = { "原点", "Org" };

        public string[] Cyl_D03Lifter_Org
        {
            get { return cyl_D03Lifter_Org; }
            set { cyl_D03Lifter_Org = value; }
        }
        private string[] cyl_D03Lifter_On = { "动点", "On" };

        public string[] Cyl_D03Lifter_On
        {
            get { return cyl_D03Lifter_On; }
            set { cyl_D03Lifter_On = value; }
        }
        private string[] cyl_D03Carry_Org = { "原点", "Org" };

        public string[] Cyl_D03Carry_Org
        {
            get { return cyl_D03Carry_Org; }
            set { cyl_D03Carry_Org = value; }
        }
        private string[] cyl_D03Carry_On = { "动点", "On" };

        public string[] Cyl_D03Carry_On
        {
            get { return cyl_D03Carry_On; }
            set { cyl_D03Carry_On = value; }
        }

        private string[] belt_D01_Enable = { "拉带一使能", "D01 Belt Enale" };

        public string[] Belt_D01_Enable
        {
            get { return belt_D01_Enable; }
            set { belt_D01_Enable = value; }
        }
        private string[] belt_D01_Direction = { "拉带一方向", "D01 Belt Direction" };

        public string[] Belt_D01_Direction
        {
            get { return belt_D01_Direction; }
            set { belt_D01_Direction = value; }
        }
        private string[] belt_D01_Run = { "拉带一启动", "D01 Belt Run" };

        public string[] Belt_D01_Run
        {
            get { return belt_D01_Run; }
            set { belt_D01_Run = value; }
        }
        private string[] belt_D01_Alarm = { "拉带一报警", "D01 Belt Alarm" };

        public string[] Belt_D01_Alarm
        {
            get { return belt_D01_Alarm; }
            set { belt_D01_Alarm = value; }
        }
        private string[] belt_D02_Enable = { "拉带二使能", "D02 Belt Enale" };

        public string[] Belt_D02_Enable
        {
            get { return belt_D02_Enable; }
            set { belt_D02_Enable = value; }
        }
        private string[] belt_D02_Direction = { "拉带二方向", "D02 Belt Direction" };

        public string[] Belt_D02_Direction
        {
            get { return belt_D02_Direction; }
            set { belt_D02_Direction = value; }
        }
        private string[] belt_D02_Run = { "拉带二启动", "D02 Belt Run" };

        public string[] Belt_D02_Run
        {
            get { return belt_D02_Run; }
            set { belt_D02_Run = value; }
        }
        private string[] belt_D02_Alarm = { "拉带二报警", "D02 Belt Alarm" };

        public string[] Belt_D02_Alarm
        {
            get { return belt_D02_Alarm; }
            set { belt_D02_Alarm = value; }
        }
        private string[] belt_D03_Enable = { "拉带三使能", "D03 Belt Enale" };

        public string[] Belt_D03_Enable
        {
            get { return belt_D03_Enable; }
            set { belt_D03_Enable = value; }
        }
        private string[] belt_D03_Direction = { "拉带三方向", "D03 Belt Direction" };

        public string[] Belt_D03_Direction
        {
            get { return belt_D03_Direction; }
            set { belt_D03_Direction = value; }
        }
        private string[] belt_D03_Run = { "拉带三启动", "D03 Belt Run" };

        public string[] Belt_D03_Run
        {
            get { return belt_D03_Run; }
            set { belt_D03_Run = value; }
        }
        private string[] belt_D03_Alarm = { "拉带三报警", "D03 Belt Alarm" };

        public string[] Belt_D03_Alarm
        {
            get { return belt_D03_Alarm; }
            set { belt_D03_Alarm = value; }
        }

        private string[] signal_D01_Enter = { "拉带一感应", "Signal D01 Enter" };

        public string[] Signal_D01_Enter
        {
            get { return signal_D01_Enter; }
            set { signal_D01_Enter = value; }
        }
        private string[] signal_D02_Enter = { "拉带二感应", "Signal D02 Enter" };

        public string[] Signal_D02_Enter
        {
            get { return signal_D02_Enter; }
            set { signal_D02_Enter = value; }
        }
        private string[] signal_D03_Enter = { "拉带三感应", "Signal D03 Enter" };

        public string[] Signal_D03_Enter
        {
            get { return signal_D03_Enter; }
            set { signal_D03_Enter = value; }
        }
        private string[] signal_NG_First = { "第一NG感应", "Signal NG First" };

        public string[] Signal_NG_First
        {
            get { return signal_NG_First; }
            set { signal_NG_First = value; }
        }
        private string[] signal_NG_Second = { "第二NG感应", "Signal NG Second" };

        public string[] Signal_NG_Second
        {
            get { return signal_NG_Second; }
            set { signal_NG_Second = value; }
        }

        private string[] signal_EMG = { "急停信号", "Signal EMG" };

        public string[] Signal_EMG
        {
            get { return signal_EMG; }
            set { signal_EMG = value; }
        }
        private string[] signal_Stop = { "停止信号", "Signal Stop" };

        public string[] Signal_Stop
        {
            get { return signal_Stop; }
            set { signal_Stop = value; }
        }
        private string[] signal_Reset = { "复位信号", "Signal Reset" };

        public string[] Signal_Reset
        {
            get { return signal_Reset; }
            set { signal_Reset = value; }
        }
        private string[] signal_Run = { "启动信号", "Signal Run" };

        public string[] Signal_Run
        {
            get { return signal_Run; }
            set { signal_Run = value; }
        }
        private string[] signal_SafeGuard = { "门禁信号", "Signal SafeGuard" };

        public string[] Signal_SafeGuard
        {
            get { return signal_SafeGuard; }
            set { signal_SafeGuard = value; }
        }
        private string[] beacon_Lamp_Red = { "红灯", "Lamp Red" };

        public string[] Beacon_Lamp_Red
        {
            get { return beacon_Lamp_Red; }
            set { beacon_Lamp_Red = value; }
        }
        private string[] beacon_Lamp_Yellow = { "黄灯", "Lamp Yellow" };

        public string[] Beacon_Lamp_Yellow
        {
            get { return beacon_Lamp_Yellow; }
            set { beacon_Lamp_Yellow = value; }
        }
        private string[] beacon_Lamp_Green = { "绿灯", "Lamp Green" };

        public string[] Beacon_Lamp_Green
        {
            get { return beacon_Lamp_Green; }
            set { beacon_Lamp_Green = value; }
        }
        private string[] beacon_Buzzer = { "蜂鸣器", "Buzzer" };

        public string[] Beacon_Buzzer
        {
            get { return beacon_Buzzer; }
            set { beacon_Buzzer = value; }
        }

        private string[] station_Next_Ready = { "下一站要料", "Next Station Ready" };

        public string[] Station_Next_Ready
        {
            get { return station_Next_Ready; }
            set { station_Next_Ready = value; }
        }
        private string[] station_Next_GetBox = { "下一站到料", "Next Station GetBox" };

        public string[] Station_Next_GetBox
        {
            get { return station_Next_GetBox; }
            set { station_Next_GetBox = value; }
        }
        private string[] station_GetReady_Input = { "产品输入准备", "Station GetReady Input" };

        public string[] Station_GetReady_Input
        {
            get { return station_GetReady_Input; }
            set { station_GetReady_Input = value; }
        }
        private string[] station_GetReady_Output = { "产品输出准备", "Station GetReady Output" };

        public string[] Station_GetReady_Output
        {
            get { return station_GetReady_Output; }
            set { station_GetReady_Output = value; }
        }
        private string[] station_NotPaste = { "无需贴标", "Porduct NotPaste" };

        public string[] Station_NotPaste
        {
            get { return station_NotPaste; }
            set { station_NotPaste = value; }
        }
        private string[] station_LabelType = { "标签类型", "Porduct LabelType" };

        public string[] Station_LabelType
        {
            get { return station_LabelType; }
            set { station_LabelType = value; }
        }
        private string[] station_SKUChange = { "SKU变更", "SKUChange" };

        public string[] Station_SKUChange
        {
            get { return station_SKUChange; }
            set { station_SKUChange = value; }
        }
        #endregion
    }

    public class FormTotalName : Setting<FormTotalName>
    {

    }

    public class FormUserLoginName : Setting<FormUserLoginName>
    {
        private string[] label_Password = { "密码:", "Password:" };

        public string[] Label_Password
        {
            get { return label_Password; }
            set { label_Password = value; }
        }

        private string[] btn_Login = { "登陆", "Login" };

        public string[] Btn_Login
        {
            get { return btn_Login; }
            set { btn_Login = value; }
        }
    }

    public class FormUserManagementName : Setting<FormUserManagementName>
    {
        private string[] label_Title = { "请选择需要更改的用户类型", "Select the type of user you want to change" };

        public string[] Label_Title
        {
            get { return label_Title; }
            set { label_Title = value; }
        }
        private string[] label_OldPassword = { "旧密码", "Old Password:" };

        public string[] Label_OldPassword
        {
            get { return label_OldPassword; }
            set { label_OldPassword = value; }
        }
        private string[] label_NewPassword = { "新密码", "New Password:" };

        public string[] Label_NewPassword
        {
            get { return label_NewPassword; }
            set { label_NewPassword = value; }
        }
        private string[] cb_DefaultUser = { "设置为默认", "Set Default" };

        public string[] Cb_DefaultUser
        {
            get { return cb_DefaultUser; }
            set { cb_DefaultUser = value; }
        }
        private string[] btn_Modification = { "确认修改", "Modification" };

        public string[] Btn_Modification
        {
            get { return btn_Modification; }
            set { btn_Modification = value; }
        }
    }

    #endregion
}

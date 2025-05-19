namespace Machine
{
    partial class FormSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_SaveConfig = new System.Windows.Forms.Button();
            this.Tc_Setting = new System.Windows.Forms.TabControl();
            this.Tp_MachineConfig = new System.Windows.Forms.TabPage();
            this.Tblp_MachineConfig = new System.Windows.Forms.TableLayoutPanel();
            this.Gb_MachineConfig = new System.Windows.Forms.GroupBox();
            this.Ppg_MachineConfig = new System.Windows.Forms.PropertyGrid();
            this.Gb_CCDConfig = new System.Windows.Forms.GroupBox();
            this.Ppg_CCDConfig = new System.Windows.Forms.PropertyGrid();
            this.Tp_SerialConfig = new System.Windows.Forms.TabPage();
            this.Tblp_SerialConfig = new System.Windows.Forms.TableLayoutPanel();
            this.Gb_ScannerConfig = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_ScannerClose = new System.Windows.Forms.Button();
            this.Btn_GetScannerResult = new System.Windows.Forms.Button();
            this.Ppg_ScannerConfig = new System.Windows.Forms.PropertyGrid();
            this.Btn_ScannerOpen = new System.Windows.Forms.Button();
            this.Tb_ScannerResult = new System.Windows.Forms.TextBox();
            this.Gb_ScalesConfig = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_ScalesClose = new System.Windows.Forms.Button();
            this.Btn_GetScalesResult = new System.Windows.Forms.Button();
            this.Ppg_ScalesConfig = new System.Windows.Forms.PropertyGrid();
            this.Btn_ScalesOpen = new System.Windows.Forms.Button();
            this.Tb_ScalesResult = new System.Windows.Forms.TextBox();
            this.Tp_OptLightConfig = new System.Windows.Forms.TabPage();
            this.Tblp_OptLightConfig = new System.Windows.Forms.TableLayoutPanel();
            this.Gb_OptLightConfig = new System.Windows.Forms.GroupBox();
            this.Ppg_OptLightConfig = new System.Windows.Forms.PropertyGrid();
            this.Gb_OptLightController = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_OptLightOpen = new System.Windows.Forms.Button();
            this.OptLightController = new OptLightController.OptLightController();
            this.Btn_OptLightClose = new System.Windows.Forms.Button();
            this.Tp_IODebug = new System.Windows.Forms.TabPage();
            this.Tblp_IODebug = new System.Windows.Forms.TableLayoutPanel();
            this.Gb_Output = new System.Windows.Forms.GroupBox();
            this.Tblp_Output = new System.Windows.Forms.TableLayoutPanel();
            this.Belt_D02_Direction = new HelperCmd.Output();
            this.Belt_D01_Direction = new HelperCmd.Output();
            this.Belt_D02_Enable = new HelperCmd.Output();
            this.Belt_D01_Enable = new HelperCmd.Output();
            this.Belt_D03_Enable = new HelperCmd.Output();
            this.Belt_D03_Direction = new HelperCmd.Output();
            this.Belt_D01_Run = new HelperCmd.Output();
            this.Belt_D02_Run = new HelperCmd.Output();
            this.Belt_D03_Run = new HelperCmd.Output();
            this.Beacon_Lamp_Red = new HelperCmd.Output();
            this.Beacon_Lamp_Yellow = new HelperCmd.Output();
            this.Beacon_Lamp_Green = new HelperCmd.Output();
            this.Beacon_Buzzer = new HelperCmd.Output();
            this.Station_GetReady_Output = new HelperCmd.Output();
            this.Station_NotPaste = new HelperCmd.Output();
            this.Station_GetReady_Input = new HelperCmd.Output();
            this.Station_LabelType = new HelperCmd.Output();
            this.Station_SKUChange = new HelperCmd.Output();
            this.Gb_Input = new System.Windows.Forms.GroupBox();
            this.Tblp_Input = new System.Windows.Forms.TableLayoutPanel();
            this.Signal_Stop = new HelperCmd.Input();
            this.Station_Next_GetBox = new HelperCmd.Input();
            this.Station_Next_Ready = new HelperCmd.Input();
            this.Signal_EMG = new HelperCmd.Input();
            this.Signal_Reset = new HelperCmd.Input();
            this.Signal_Run = new HelperCmd.Input();
            this.Belt_D01_Alarm = new HelperCmd.Input();
            this.Belt_D02_Alarm = new HelperCmd.Input();
            this.Belt_D03_Alarm = new HelperCmd.Input();
            this.Signal_SafeGuard = new HelperCmd.Input();
            this.Signal_NG_Second = new HelperCmd.Input();
            this.Signal_NG_First = new HelperCmd.Input();
            this.Signal_D01_Enter = new HelperCmd.Input();
            this.Signal_D02_Enter = new HelperCmd.Input();
            this.Signal_D03_Enter = new HelperCmd.Input();
            this.Tp_CylinderDebug = new System.Windows.Forms.TabPage();
            this.Tblp_CylinderDebug = new System.Windows.Forms.TableLayoutPanel();
            this.Gb_Output_D03 = new System.Windows.Forms.GroupBox();
            this.Tblp_Output_D03 = new System.Windows.Forms.TableLayoutPanel();
            this.Cyl_D03Carry = new HelperCmd.Output();
            this.Cyl_D03Lifter = new HelperCmd.Output();
            this.Cyl_D03Forward = new HelperCmd.Output();
            this.Cyl_D03Rotate = new HelperCmd.Output();
            this.Cyl_D03Clamp_Org = new HelperCmd.Input();
            this.Cyl_D03Clamp_On = new HelperCmd.Input();
            this.Cyl_D03Rotate_Org = new HelperCmd.Input();
            this.Cyl_D03Rotate_On = new HelperCmd.Input();
            this.Cyl_D03Forward_Org = new HelperCmd.Input();
            this.Cyl_D03Forward_On = new HelperCmd.Input();
            this.Cyl_D03Lifter_Org = new HelperCmd.Input();
            this.Cyl_D03Lifter_On = new HelperCmd.Input();
            this.Cyl_D03Carry_Org = new HelperCmd.Input();
            this.Cyl_D03Carry_On = new HelperCmd.Input();
            this.Cyl_D03Adjust_Right_Org = new HelperCmd.Input();
            this.Cyl_D03Adjust_Left_Org = new HelperCmd.Input();
            this.Cyl_D03Adjust_Left_On = new HelperCmd.Input();
            this.Cyl_D03Adjust_Right_On = new HelperCmd.Input();
            this.Cyl_D03Clamp = new HelperCmd.Output();
            this.Cyl_D03Adjust = new HelperCmd.Output();
            this.Gb_Output_D02 = new System.Windows.Forms.GroupBox();
            this.Tblp_Output_D02 = new System.Windows.Forms.TableLayoutPanel();
            this.Cyl_D02Weigh_On = new HelperCmd.Input();
            this.Cyl_D02Intercept_On = new HelperCmd.Input();
            this.Cyl_D02Weigh_Org = new HelperCmd.Input();
            this.Cyl_D02Intercept_Org = new HelperCmd.Input();
            this.Cyl_D02Intercept = new HelperCmd.Output();
            this.Cyl_D02Weigh = new HelperCmd.Output();
            this.Gb_Output_D01 = new System.Windows.Forms.GroupBox();
            this.Tblp_Output_D01 = new System.Windows.Forms.TableLayoutPanel();
            this.Cyl_D01Intercept_On = new HelperCmd.Input();
            this.Cyl_D01Intercept = new HelperCmd.Output();
            this.Cyl_D01Intercept_Org = new HelperCmd.Input();
            this.Tp_StepDebug = new System.Windows.Forms.TabPage();
            this.Tblp_StepDebug = new System.Windows.Forms.TableLayoutPanel();
            this.Gb_Step_D02 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_VirtualAction_D02 = new System.Windows.Forms.Button();
            this.Btn_Cyl_D02Intercept = new System.Windows.Forms.Button();
            this.Btn_Cyl_D02Weigh = new System.Windows.Forms.Button();
            this.Gb_Step_D03 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_VirtualAction_D03 = new System.Windows.Forms.Button();
            this.Btn_PassAction = new System.Windows.Forms.Button();
            this.Btn_NGAction = new System.Windows.Forms.Button();
            this.Btn_Station_SKUChange = new System.Windows.Forms.Button();
            this.Btn_Station_LabelType = new System.Windows.Forms.Button();
            this.Btn_Station_NotPaste = new System.Windows.Forms.Button();
            this.Btn_Station_GetReady_Output = new System.Windows.Forms.Button();
            this.Btn_Cyl_D03Carry = new System.Windows.Forms.Button();
            this.Btn_Cyl_D03Rotate = new System.Windows.Forms.Button();
            this.Btn_Cyl_D03Clamp = new System.Windows.Forms.Button();
            this.Btn_Cyl_D03Forward = new System.Windows.Forms.Button();
            this.Btn_Cyl_D03Lifter = new System.Windows.Forms.Button();
            this.Btn_Cyl_D03Adjust = new System.Windows.Forms.Button();
            this.Gb_Step_D01 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_VirtualAction_D01 = new System.Windows.Forms.Button();
            this.Btn_Cyl_D01Intercept = new System.Windows.Forms.Button();
            this.Btn_Station_GetReady_Input = new System.Windows.Forms.Button();
            this.Gb_Step_Belt = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_Belt_D03_Run = new System.Windows.Forms.Button();
            this.Btn_Belt_D03_Direction = new System.Windows.Forms.Button();
            this.Btn_Belt_D03_Enable = new System.Windows.Forms.Button();
            this.Btn_Belt_D02_Run = new System.Windows.Forms.Button();
            this.Btn_Belt_D02_Direction = new System.Windows.Forms.Button();
            this.Btn_Belt_D02_Enable = new System.Windows.Forms.Button();
            this.Btn_Belt_D01_Run = new System.Windows.Forms.Button();
            this.Btn_Belt_D01_Direction = new System.Windows.Forms.Button();
            this.Btn_Belt_D01_Enable = new System.Windows.Forms.Button();
            this.Gb_Step_Beacon = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_BeltAction = new System.Windows.Forms.Button();
            this.Btn_Beacon_Buzzer = new System.Windows.Forms.Button();
            this.Btn_Beacon_Lamp_Green = new System.Windows.Forms.Button();
            this.Btn_Beacon_Lamp_Yellow = new System.Windows.Forms.Button();
            this.Btn_Beacon_Lamp_Red = new System.Windows.Forms.Button();
            this.Tp_OtherDebug = new System.Windows.Forms.TabPage();
            this.Tblp_OtherDebug = new System.Windows.Forms.TableLayoutPanel();
            this.Gb_CCDDebug = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_CCD3_SavePicture = new System.Windows.Forms.Button();
            this.Btn_CCD2_SavePicture = new System.Windows.Forms.Button();
            this.Btn_CCD3_ReadPicture = new System.Windows.Forms.Button();
            this.Btn_CCD2_ReadPicture = new System.Windows.Forms.Button();
            this.Btn_BarCode_Retail = new System.Windows.Forms.Button();
            this.Btn_Date_BOB = new System.Windows.Forms.Button();
            this.Btn_Price_BOB = new System.Windows.Forms.Button();
            this.Btn_Type_BOB = new System.Windows.Forms.Button();
            this.Btn_Color_Retail = new System.Windows.Forms.Button();
            this.Btn_Memory_Retail = new System.Windows.Forms.Button();
            this.Btn_Type_Retail = new System.Windows.Forms.Button();
            this.Btn_GLabel_Retail = new System.Windows.Forms.Button();
            this.Tb_CCD1_EXTime = new System.Windows.Forms.TextBox();
            this.Tb_CCD2_EXTime = new System.Windows.Forms.TextBox();
            this.Tb_CCD3_EXTime = new System.Windows.Forms.TextBox();
            this.Btn_CCD1_TakePicture = new System.Windows.Forms.Button();
            this.Btn_CCD2_TakePicture = new System.Windows.Forms.Button();
            this.Btn_CCD3_TakePicture = new System.Windows.Forms.Button();
            this.Label_CCD1_EXTime = new System.Windows.Forms.Label();
            this.Label_CCD2_EXTime = new System.Windows.Forms.Label();
            this.Label_CCD3_EXTime = new System.Windows.Forms.Label();
            this.Btn_Type_Front = new System.Windows.Forms.Button();
            this.Btn_Color_Front = new System.Windows.Forms.Button();
            this.Btn_CCD1_ReadPicture = new System.Windows.Forms.Button();
            this.Btn_CCD1_SavePicture = new System.Windows.Forms.Button();
            this.Gb_SFCDebug = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.Tb_Weight = new System.Windows.Forms.TextBox();
            this.Rtb_GetData = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_UpLoadPass = new System.Windows.Forms.Button();
            this.Btn_GetClosure = new System.Windows.Forms.Button();
            this.Btn_GetBOBData = new System.Windows.Forms.Button();
            this.Btn_GetRetailData = new System.Windows.Forms.Button();
            this.Btn_CheckPath = new System.Windows.Forms.Button();
            this.Tb_DSN = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_UserManagement = new System.Windows.Forms.Button();
            this.Status_Level_03 = new System.Windows.Forms.Button();
            this.Status_Level_02 = new System.Windows.Forms.Button();
            this.Label_AccessLevel = new System.Windows.Forms.Label();
            this.Btn_UserAccess = new System.Windows.Forms.Button();
            this.Status_Level_01 = new System.Windows.Forms.Button();
            this.timer_IOFalsh = new System.Windows.Forms.Timer(this.components);
            this.timer_CylinderFalsh = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.Tc_Setting.SuspendLayout();
            this.Tp_MachineConfig.SuspendLayout();
            this.Tblp_MachineConfig.SuspendLayout();
            this.Gb_MachineConfig.SuspendLayout();
            this.Gb_CCDConfig.SuspendLayout();
            this.Tp_SerialConfig.SuspendLayout();
            this.Tblp_SerialConfig.SuspendLayout();
            this.Gb_ScannerConfig.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.Gb_ScalesConfig.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.Tp_OptLightConfig.SuspendLayout();
            this.Tblp_OptLightConfig.SuspendLayout();
            this.Gb_OptLightConfig.SuspendLayout();
            this.Gb_OptLightController.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.Tp_IODebug.SuspendLayout();
            this.Tblp_IODebug.SuspendLayout();
            this.Gb_Output.SuspendLayout();
            this.Tblp_Output.SuspendLayout();
            this.Gb_Input.SuspendLayout();
            this.Tblp_Input.SuspendLayout();
            this.Tp_CylinderDebug.SuspendLayout();
            this.Tblp_CylinderDebug.SuspendLayout();
            this.Gb_Output_D03.SuspendLayout();
            this.Tblp_Output_D03.SuspendLayout();
            this.Gb_Output_D02.SuspendLayout();
            this.Tblp_Output_D02.SuspendLayout();
            this.Gb_Output_D01.SuspendLayout();
            this.Tblp_Output_D01.SuspendLayout();
            this.Tp_StepDebug.SuspendLayout();
            this.Tblp_StepDebug.SuspendLayout();
            this.Gb_Step_D02.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.Gb_Step_D03.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.Gb_Step_D01.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.Gb_Step_Belt.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.Gb_Step_Beacon.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.Tp_OtherDebug.SuspendLayout();
            this.Tblp_OtherDebug.SuspendLayout();
            this.Gb_CCDDebug.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.Gb_SFCDebug.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Btn_SaveConfig, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Tc_Setting, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel16, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 682);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Btn_SaveConfig
            // 
            this.Btn_SaveConfig.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_SaveConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_SaveConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_SaveConfig.ForeColor = System.Drawing.Color.White;
            this.Btn_SaveConfig.Location = new System.Drawing.Point(3, 640);
            this.Btn_SaveConfig.Name = "Btn_SaveConfig";
            this.Btn_SaveConfig.Size = new System.Drawing.Size(978, 39);
            this.Btn_SaveConfig.TabIndex = 0;
            this.Btn_SaveConfig.Text = "SaveConfig";
            this.Btn_SaveConfig.UseVisualStyleBackColor = false;
            this.Btn_SaveConfig.Click += new System.EventHandler(this.Btn_SaveConfig_Click);
            // 
            // Tc_Setting
            // 
            this.Tc_Setting.Controls.Add(this.Tp_MachineConfig);
            this.Tc_Setting.Controls.Add(this.Tp_SerialConfig);
            this.Tc_Setting.Controls.Add(this.Tp_OptLightConfig);
            this.Tc_Setting.Controls.Add(this.Tp_IODebug);
            this.Tc_Setting.Controls.Add(this.Tp_CylinderDebug);
            this.Tc_Setting.Controls.Add(this.Tp_StepDebug);
            this.Tc_Setting.Controls.Add(this.Tp_OtherDebug);
            this.Tc_Setting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tc_Setting.Location = new System.Drawing.Point(3, 43);
            this.Tc_Setting.Name = "Tc_Setting";
            this.Tc_Setting.SelectedIndex = 0;
            this.Tc_Setting.Size = new System.Drawing.Size(978, 591);
            this.Tc_Setting.TabIndex = 1;
            this.Tc_Setting.SelectedIndexChanged += new System.EventHandler(this.Tc_Setting_SelectedIndexChanged);
            // 
            // Tp_MachineConfig
            // 
            this.Tp_MachineConfig.Controls.Add(this.Tblp_MachineConfig);
            this.Tp_MachineConfig.Location = new System.Drawing.Point(4, 22);
            this.Tp_MachineConfig.Name = "Tp_MachineConfig";
            this.Tp_MachineConfig.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_MachineConfig.Size = new System.Drawing.Size(970, 565);
            this.Tp_MachineConfig.TabIndex = 0;
            this.Tp_MachineConfig.Text = "MachineConfig  ";
            this.Tp_MachineConfig.UseVisualStyleBackColor = true;
            // 
            // Tblp_MachineConfig
            // 
            this.Tblp_MachineConfig.ColumnCount = 2;
            this.Tblp_MachineConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_MachineConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_MachineConfig.Controls.Add(this.Gb_MachineConfig, 0, 0);
            this.Tblp_MachineConfig.Controls.Add(this.Gb_CCDConfig, 1, 0);
            this.Tblp_MachineConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tblp_MachineConfig.Location = new System.Drawing.Point(3, 3);
            this.Tblp_MachineConfig.Name = "Tblp_MachineConfig";
            this.Tblp_MachineConfig.RowCount = 1;
            this.Tblp_MachineConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_MachineConfig.Size = new System.Drawing.Size(964, 559);
            this.Tblp_MachineConfig.TabIndex = 0;
            // 
            // Gb_MachineConfig
            // 
            this.Gb_MachineConfig.Controls.Add(this.Ppg_MachineConfig);
            this.Gb_MachineConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_MachineConfig.Location = new System.Drawing.Point(3, 3);
            this.Gb_MachineConfig.Name = "Gb_MachineConfig";
            this.Gb_MachineConfig.Size = new System.Drawing.Size(476, 553);
            this.Gb_MachineConfig.TabIndex = 0;
            this.Gb_MachineConfig.TabStop = false;
            this.Gb_MachineConfig.Text = "MachineConfig";
            // 
            // Ppg_MachineConfig
            // 
            this.Ppg_MachineConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ppg_MachineConfig.Location = new System.Drawing.Point(3, 17);
            this.Ppg_MachineConfig.Name = "Ppg_MachineConfig";
            this.Ppg_MachineConfig.Size = new System.Drawing.Size(470, 533);
            this.Ppg_MachineConfig.TabIndex = 0;
            this.Ppg_MachineConfig.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.Ppg_MachineConfig_PropertyValueChanged);
            // 
            // Gb_CCDConfig
            // 
            this.Gb_CCDConfig.Controls.Add(this.Ppg_CCDConfig);
            this.Gb_CCDConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_CCDConfig.Location = new System.Drawing.Point(485, 3);
            this.Gb_CCDConfig.Name = "Gb_CCDConfig";
            this.Gb_CCDConfig.Size = new System.Drawing.Size(476, 553);
            this.Gb_CCDConfig.TabIndex = 1;
            this.Gb_CCDConfig.TabStop = false;
            this.Gb_CCDConfig.Text = "CCDConfig";
            // 
            // Ppg_CCDConfig
            // 
            this.Ppg_CCDConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ppg_CCDConfig.Enabled = false;
            this.Ppg_CCDConfig.Location = new System.Drawing.Point(3, 17);
            this.Ppg_CCDConfig.Name = "Ppg_CCDConfig";
            this.Ppg_CCDConfig.Size = new System.Drawing.Size(470, 533);
            this.Ppg_CCDConfig.TabIndex = 1;
            // 
            // Tp_SerialConfig
            // 
            this.Tp_SerialConfig.Controls.Add(this.Tblp_SerialConfig);
            this.Tp_SerialConfig.Location = new System.Drawing.Point(4, 22);
            this.Tp_SerialConfig.Name = "Tp_SerialConfig";
            this.Tp_SerialConfig.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_SerialConfig.Size = new System.Drawing.Size(970, 566);
            this.Tp_SerialConfig.TabIndex = 1;
            this.Tp_SerialConfig.Text = "SerialConfig  ";
            this.Tp_SerialConfig.UseVisualStyleBackColor = true;
            // 
            // Tblp_SerialConfig
            // 
            this.Tblp_SerialConfig.ColumnCount = 2;
            this.Tblp_SerialConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_SerialConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_SerialConfig.Controls.Add(this.Gb_ScannerConfig, 0, 0);
            this.Tblp_SerialConfig.Controls.Add(this.Gb_ScalesConfig, 1, 0);
            this.Tblp_SerialConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tblp_SerialConfig.Location = new System.Drawing.Point(3, 3);
            this.Tblp_SerialConfig.Name = "Tblp_SerialConfig";
            this.Tblp_SerialConfig.RowCount = 1;
            this.Tblp_SerialConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_SerialConfig.Size = new System.Drawing.Size(964, 560);
            this.Tblp_SerialConfig.TabIndex = 0;
            // 
            // Gb_ScannerConfig
            // 
            this.Gb_ScannerConfig.Controls.Add(this.tableLayoutPanel4);
            this.Gb_ScannerConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_ScannerConfig.Location = new System.Drawing.Point(3, 3);
            this.Gb_ScannerConfig.Name = "Gb_ScannerConfig";
            this.Gb_ScannerConfig.Size = new System.Drawing.Size(476, 554);
            this.Gb_ScannerConfig.TabIndex = 0;
            this.Gb_ScannerConfig.TabStop = false;
            this.Gb_ScannerConfig.Text = "ScannerConfig";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.Btn_ScannerClose, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.Btn_GetScannerResult, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.Ppg_ScannerConfig, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Btn_ScannerOpen, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.Tb_ScannerResult, 0, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(470, 534);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // Btn_ScannerClose
            // 
            this.Btn_ScannerClose.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_ScannerClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_ScannerClose.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_ScannerClose.ForeColor = System.Drawing.Color.White;
            this.Btn_ScannerClose.Location = new System.Drawing.Point(3, 397);
            this.Btn_ScannerClose.Name = "Btn_ScannerClose";
            this.Btn_ScannerClose.Size = new System.Drawing.Size(464, 29);
            this.Btn_ScannerClose.TabIndex = 4;
            this.Btn_ScannerClose.Text = "ScannerClose";
            this.Btn_ScannerClose.UseVisualStyleBackColor = false;
            this.Btn_ScannerClose.Click += new System.EventHandler(this.Btn_ScannerClose_Click);
            // 
            // Btn_GetScannerResult
            // 
            this.Btn_GetScannerResult.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_GetScannerResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_GetScannerResult.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_GetScannerResult.ForeColor = System.Drawing.Color.White;
            this.Btn_GetScannerResult.Location = new System.Drawing.Point(3, 467);
            this.Btn_GetScannerResult.Name = "Btn_GetScannerResult";
            this.Btn_GetScannerResult.Size = new System.Drawing.Size(464, 29);
            this.Btn_GetScannerResult.TabIndex = 2;
            this.Btn_GetScannerResult.Text = "GetScannerResult";
            this.Btn_GetScannerResult.UseVisualStyleBackColor = false;
            this.Btn_GetScannerResult.Click += new System.EventHandler(this.Btn_GetScannerResult_Click);
            // 
            // Ppg_ScannerConfig
            // 
            this.Ppg_ScannerConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ppg_ScannerConfig.Location = new System.Drawing.Point(0, 0);
            this.Ppg_ScannerConfig.Margin = new System.Windows.Forms.Padding(0);
            this.Ppg_ScannerConfig.Name = "Ppg_ScannerConfig";
            this.Ppg_ScannerConfig.Size = new System.Drawing.Size(470, 394);
            this.Ppg_ScannerConfig.TabIndex = 0;
            // 
            // Btn_ScannerOpen
            // 
            this.Btn_ScannerOpen.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_ScannerOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_ScannerOpen.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_ScannerOpen.ForeColor = System.Drawing.Color.White;
            this.Btn_ScannerOpen.Location = new System.Drawing.Point(3, 432);
            this.Btn_ScannerOpen.Name = "Btn_ScannerOpen";
            this.Btn_ScannerOpen.Size = new System.Drawing.Size(464, 29);
            this.Btn_ScannerOpen.TabIndex = 1;
            this.Btn_ScannerOpen.Text = "ScannerOpen";
            this.Btn_ScannerOpen.UseVisualStyleBackColor = false;
            this.Btn_ScannerOpen.Click += new System.EventHandler(this.Btn_ScannerOpen_Click);
            // 
            // Tb_ScannerResult
            // 
            this.Tb_ScannerResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_ScannerResult.Location = new System.Drawing.Point(3, 506);
            this.Tb_ScannerResult.Name = "Tb_ScannerResult";
            this.Tb_ScannerResult.Size = new System.Drawing.Size(464, 21);
            this.Tb_ScannerResult.TabIndex = 3;
            this.Tb_ScannerResult.Text = "ScannerResult";
            // 
            // Gb_ScalesConfig
            // 
            this.Gb_ScalesConfig.Controls.Add(this.tableLayoutPanel5);
            this.Gb_ScalesConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_ScalesConfig.Location = new System.Drawing.Point(485, 3);
            this.Gb_ScalesConfig.Name = "Gb_ScalesConfig";
            this.Gb_ScalesConfig.Size = new System.Drawing.Size(476, 554);
            this.Gb_ScalesConfig.TabIndex = 1;
            this.Gb_ScalesConfig.TabStop = false;
            this.Gb_ScalesConfig.Text = "ScalesConfig";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.Btn_ScalesClose, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.Btn_GetScalesResult, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.Ppg_ScalesConfig, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.Btn_ScalesOpen, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.Tb_ScalesResult, 0, 4);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(470, 534);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // Btn_ScalesClose
            // 
            this.Btn_ScalesClose.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_ScalesClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_ScalesClose.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_ScalesClose.ForeColor = System.Drawing.Color.White;
            this.Btn_ScalesClose.Location = new System.Drawing.Point(3, 397);
            this.Btn_ScalesClose.Name = "Btn_ScalesClose";
            this.Btn_ScalesClose.Size = new System.Drawing.Size(464, 29);
            this.Btn_ScalesClose.TabIndex = 4;
            this.Btn_ScalesClose.Text = "ScalesClose";
            this.Btn_ScalesClose.UseVisualStyleBackColor = false;
            this.Btn_ScalesClose.Click += new System.EventHandler(this.Btn_ScalesClose_Click);
            // 
            // Btn_GetScalesResult
            // 
            this.Btn_GetScalesResult.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_GetScalesResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_GetScalesResult.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_GetScalesResult.ForeColor = System.Drawing.Color.White;
            this.Btn_GetScalesResult.Location = new System.Drawing.Point(3, 467);
            this.Btn_GetScalesResult.Name = "Btn_GetScalesResult";
            this.Btn_GetScalesResult.Size = new System.Drawing.Size(464, 29);
            this.Btn_GetScalesResult.TabIndex = 2;
            this.Btn_GetScalesResult.Text = "GetScalesResult";
            this.Btn_GetScalesResult.UseVisualStyleBackColor = false;
            this.Btn_GetScalesResult.Click += new System.EventHandler(this.Btn_GetScalesResult_Click);
            // 
            // Ppg_ScalesConfig
            // 
            this.Ppg_ScalesConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ppg_ScalesConfig.Location = new System.Drawing.Point(0, 0);
            this.Ppg_ScalesConfig.Margin = new System.Windows.Forms.Padding(0);
            this.Ppg_ScalesConfig.Name = "Ppg_ScalesConfig";
            this.Ppg_ScalesConfig.Size = new System.Drawing.Size(470, 394);
            this.Ppg_ScalesConfig.TabIndex = 0;
            // 
            // Btn_ScalesOpen
            // 
            this.Btn_ScalesOpen.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_ScalesOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_ScalesOpen.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_ScalesOpen.ForeColor = System.Drawing.Color.White;
            this.Btn_ScalesOpen.Location = new System.Drawing.Point(3, 432);
            this.Btn_ScalesOpen.Name = "Btn_ScalesOpen";
            this.Btn_ScalesOpen.Size = new System.Drawing.Size(464, 29);
            this.Btn_ScalesOpen.TabIndex = 1;
            this.Btn_ScalesOpen.Text = "ScalesOpen";
            this.Btn_ScalesOpen.UseVisualStyleBackColor = false;
            this.Btn_ScalesOpen.Click += new System.EventHandler(this.Btn_ScalesOpen_Click);
            // 
            // Tb_ScalesResult
            // 
            this.Tb_ScalesResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_ScalesResult.Location = new System.Drawing.Point(3, 506);
            this.Tb_ScalesResult.Name = "Tb_ScalesResult";
            this.Tb_ScalesResult.Size = new System.Drawing.Size(464, 21);
            this.Tb_ScalesResult.TabIndex = 3;
            this.Tb_ScalesResult.Text = "ScalesResult";
            // 
            // Tp_OptLightConfig
            // 
            this.Tp_OptLightConfig.Controls.Add(this.Tblp_OptLightConfig);
            this.Tp_OptLightConfig.Location = new System.Drawing.Point(4, 22);
            this.Tp_OptLightConfig.Name = "Tp_OptLightConfig";
            this.Tp_OptLightConfig.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_OptLightConfig.Size = new System.Drawing.Size(970, 566);
            this.Tp_OptLightConfig.TabIndex = 2;
            this.Tp_OptLightConfig.Text = "OptLightConfig";
            this.Tp_OptLightConfig.UseVisualStyleBackColor = true;
            // 
            // Tblp_OptLightConfig
            // 
            this.Tblp_OptLightConfig.ColumnCount = 2;
            this.Tblp_OptLightConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_OptLightConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_OptLightConfig.Controls.Add(this.Gb_OptLightConfig, 1, 0);
            this.Tblp_OptLightConfig.Controls.Add(this.Gb_OptLightController, 0, 0);
            this.Tblp_OptLightConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tblp_OptLightConfig.Location = new System.Drawing.Point(3, 3);
            this.Tblp_OptLightConfig.Name = "Tblp_OptLightConfig";
            this.Tblp_OptLightConfig.RowCount = 1;
            this.Tblp_OptLightConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_OptLightConfig.Size = new System.Drawing.Size(964, 560);
            this.Tblp_OptLightConfig.TabIndex = 0;
            // 
            // Gb_OptLightConfig
            // 
            this.Gb_OptLightConfig.Controls.Add(this.Ppg_OptLightConfig);
            this.Gb_OptLightConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_OptLightConfig.Location = new System.Drawing.Point(485, 3);
            this.Gb_OptLightConfig.Name = "Gb_OptLightConfig";
            this.Gb_OptLightConfig.Size = new System.Drawing.Size(476, 554);
            this.Gb_OptLightConfig.TabIndex = 1;
            this.Gb_OptLightConfig.TabStop = false;
            this.Gb_OptLightConfig.Text = "OptLightConfig";
            // 
            // Ppg_OptLightConfig
            // 
            this.Ppg_OptLightConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ppg_OptLightConfig.Location = new System.Drawing.Point(3, 17);
            this.Ppg_OptLightConfig.Name = "Ppg_OptLightConfig";
            this.Ppg_OptLightConfig.Size = new System.Drawing.Size(470, 534);
            this.Ppg_OptLightConfig.TabIndex = 0;
            // 
            // Gb_OptLightController
            // 
            this.Gb_OptLightController.Controls.Add(this.tableLayoutPanel7);
            this.Gb_OptLightController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_OptLightController.Location = new System.Drawing.Point(3, 3);
            this.Gb_OptLightController.Name = "Gb_OptLightController";
            this.Gb_OptLightController.Size = new System.Drawing.Size(476, 554);
            this.Gb_OptLightController.TabIndex = 0;
            this.Gb_OptLightController.TabStop = false;
            this.Gb_OptLightController.Text = "OptLightController";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 321F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.Btn_OptLightOpen, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.OptLightController, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.Btn_OptLightClose, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(470, 534);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // Btn_OptLightOpen
            // 
            this.Btn_OptLightOpen.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tableLayoutPanel7.SetColumnSpan(this.Btn_OptLightOpen, 3);
            this.Btn_OptLightOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_OptLightOpen.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_OptLightOpen.ForeColor = System.Drawing.Color.White;
            this.Btn_OptLightOpen.Location = new System.Drawing.Point(3, 502);
            this.Btn_OptLightOpen.Name = "Btn_OptLightOpen";
            this.Btn_OptLightOpen.Size = new System.Drawing.Size(464, 29);
            this.Btn_OptLightOpen.TabIndex = 2;
            this.Btn_OptLightOpen.Text = "OptLightOpen";
            this.Btn_OptLightOpen.UseVisualStyleBackColor = false;
            this.Btn_OptLightOpen.Click += new System.EventHandler(this.Btn_OptLightOpen_Click);
            // 
            // OptLightController
            // 
            this.OptLightController.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OptLightController.BackColor = System.Drawing.Color.White;
            this.OptLightController.Ch1Value = 0;
            this.OptLightController.Ch2Value = 0;
            this.OptLightController.Ch3Value = 0;
            this.OptLightController.Ch4Value = 0;
            this.OptLightController.Channel1Text = "通道1";
            this.OptLightController.Channel2Text = "通道2";
            this.OptLightController.Channel3Text = "通道3";
            this.OptLightController.Channel4Text = "通道4";
            this.OptLightController.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OptLightController.Location = new System.Drawing.Point(77, 90);
            this.OptLightController.Name = "OptLightController";
            this.OptLightController.Size = new System.Drawing.Size(315, 284);
            this.OptLightController.TabIndex = 0;
            // 
            // Btn_OptLightClose
            // 
            this.Btn_OptLightClose.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tableLayoutPanel7.SetColumnSpan(this.Btn_OptLightClose, 3);
            this.Btn_OptLightClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_OptLightClose.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_OptLightClose.ForeColor = System.Drawing.Color.White;
            this.Btn_OptLightClose.Location = new System.Drawing.Point(3, 467);
            this.Btn_OptLightClose.Name = "Btn_OptLightClose";
            this.Btn_OptLightClose.Size = new System.Drawing.Size(464, 29);
            this.Btn_OptLightClose.TabIndex = 1;
            this.Btn_OptLightClose.Text = "OptLightClose";
            this.Btn_OptLightClose.UseVisualStyleBackColor = false;
            this.Btn_OptLightClose.Click += new System.EventHandler(this.Btn_OptLightClose_Click);
            // 
            // Tp_IODebug
            // 
            this.Tp_IODebug.Controls.Add(this.Tblp_IODebug);
            this.Tp_IODebug.Location = new System.Drawing.Point(4, 22);
            this.Tp_IODebug.Name = "Tp_IODebug";
            this.Tp_IODebug.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_IODebug.Size = new System.Drawing.Size(970, 566);
            this.Tp_IODebug.TabIndex = 3;
            this.Tp_IODebug.Text = "IODebug       ";
            this.Tp_IODebug.UseVisualStyleBackColor = true;
            // 
            // Tblp_IODebug
            // 
            this.Tblp_IODebug.ColumnCount = 1;
            this.Tblp_IODebug.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_IODebug.Controls.Add(this.Gb_Output, 0, 1);
            this.Tblp_IODebug.Controls.Add(this.Gb_Input, 0, 0);
            this.Tblp_IODebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tblp_IODebug.Location = new System.Drawing.Point(3, 3);
            this.Tblp_IODebug.Name = "Tblp_IODebug";
            this.Tblp_IODebug.RowCount = 2;
            this.Tblp_IODebug.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_IODebug.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_IODebug.Size = new System.Drawing.Size(964, 560);
            this.Tblp_IODebug.TabIndex = 0;
            // 
            // Gb_Output
            // 
            this.Gb_Output.Controls.Add(this.Tblp_Output);
            this.Gb_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_Output.Location = new System.Drawing.Point(3, 283);
            this.Gb_Output.Name = "Gb_Output";
            this.Gb_Output.Size = new System.Drawing.Size(958, 274);
            this.Gb_Output.TabIndex = 1;
            this.Gb_Output.TabStop = false;
            this.Gb_Output.Text = "Output";
            // 
            // Tblp_Output
            // 
            this.Tblp_Output.ColumnCount = 3;
            this.Tblp_Output.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tblp_Output.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.Tblp_Output.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.Tblp_Output.Controls.Add(this.Belt_D02_Direction, 1, 1);
            this.Tblp_Output.Controls.Add(this.Belt_D01_Direction, 0, 1);
            this.Tblp_Output.Controls.Add(this.Belt_D02_Enable, 1, 0);
            this.Tblp_Output.Controls.Add(this.Belt_D01_Enable, 0, 0);
            this.Tblp_Output.Controls.Add(this.Belt_D03_Enable, 2, 0);
            this.Tblp_Output.Controls.Add(this.Belt_D03_Direction, 2, 1);
            this.Tblp_Output.Controls.Add(this.Belt_D01_Run, 0, 2);
            this.Tblp_Output.Controls.Add(this.Belt_D02_Run, 1, 2);
            this.Tblp_Output.Controls.Add(this.Belt_D03_Run, 2, 2);
            this.Tblp_Output.Controls.Add(this.Beacon_Lamp_Red, 0, 3);
            this.Tblp_Output.Controls.Add(this.Beacon_Lamp_Yellow, 1, 3);
            this.Tblp_Output.Controls.Add(this.Beacon_Lamp_Green, 2, 3);
            this.Tblp_Output.Controls.Add(this.Beacon_Buzzer, 0, 4);
            this.Tblp_Output.Controls.Add(this.Station_GetReady_Output, 2, 4);
            this.Tblp_Output.Controls.Add(this.Station_NotPaste, 0, 5);
            this.Tblp_Output.Controls.Add(this.Station_GetReady_Input, 1, 4);
            this.Tblp_Output.Controls.Add(this.Station_LabelType, 1, 5);
            this.Tblp_Output.Controls.Add(this.Station_SKUChange, 2, 5);
            this.Tblp_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tblp_Output.Location = new System.Drawing.Point(3, 17);
            this.Tblp_Output.Name = "Tblp_Output";
            this.Tblp_Output.RowCount = 7;
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Output.Size = new System.Drawing.Size(952, 254);
            this.Tblp_Output.TabIndex = 0;
            // 
            // Belt_D02_Direction
            // 
            this.Belt_D02_Direction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Belt_D02_Direction.CardNo = ((ushort)(1));
            this.Belt_D02_Direction.Checked = false;
            this.Belt_D02_Direction.IOName = "Belt_D02_Direction";
            this.Belt_D02_Direction.IOText = "Belt_D02_Direction";
            this.Belt_D02_Direction.Location = new System.Drawing.Point(320, 47);
            this.Belt_D02_Direction.Name = "Belt_D02_Direction";
            this.Belt_D02_Direction.Size = new System.Drawing.Size(311, 26);
            this.Belt_D02_Direction.TabIndex = 3;
            this.Belt_D02_Direction.TabStop = false;
            this.Belt_D02_Direction.Value = ((ushort)(0));
            this.Belt_D02_Direction.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Belt_D01_Direction
            // 
            this.Belt_D01_Direction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Belt_D01_Direction.CardNo = ((ushort)(1));
            this.Belt_D01_Direction.Checked = false;
            this.Belt_D01_Direction.IOName = "Belt_D01_Direction";
            this.Belt_D01_Direction.IOText = "Belt_D01_Direction";
            this.Belt_D01_Direction.Location = new System.Drawing.Point(3, 47);
            this.Belt_D01_Direction.Name = "Belt_D01_Direction";
            this.Belt_D01_Direction.Size = new System.Drawing.Size(311, 26);
            this.Belt_D01_Direction.TabIndex = 2;
            this.Belt_D01_Direction.TabStop = false;
            this.Belt_D01_Direction.Value = ((ushort)(0));
            this.Belt_D01_Direction.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Belt_D02_Enable
            // 
            this.Belt_D02_Enable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Belt_D02_Enable.CardNo = ((ushort)(1));
            this.Belt_D02_Enable.Checked = false;
            this.Belt_D02_Enable.IOName = "Belt_D02_Enable";
            this.Belt_D02_Enable.IOText = "Belt_D02_Enable";
            this.Belt_D02_Enable.Location = new System.Drawing.Point(320, 7);
            this.Belt_D02_Enable.Name = "Belt_D02_Enable";
            this.Belt_D02_Enable.Size = new System.Drawing.Size(311, 26);
            this.Belt_D02_Enable.TabIndex = 1;
            this.Belt_D02_Enable.TabStop = false;
            this.Belt_D02_Enable.Value = ((ushort)(0));
            this.Belt_D02_Enable.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Belt_D01_Enable
            // 
            this.Belt_D01_Enable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Belt_D01_Enable.CardNo = ((ushort)(1));
            this.Belt_D01_Enable.Checked = false;
            this.Belt_D01_Enable.IOName = "Belt_D01_Enable";
            this.Belt_D01_Enable.IOText = "Belt_D01_Enable";
            this.Belt_D01_Enable.Location = new System.Drawing.Point(3, 7);
            this.Belt_D01_Enable.Name = "Belt_D01_Enable";
            this.Belt_D01_Enable.Size = new System.Drawing.Size(311, 26);
            this.Belt_D01_Enable.TabIndex = 0;
            this.Belt_D01_Enable.TabStop = false;
            this.Belt_D01_Enable.Value = ((ushort)(0));
            this.Belt_D01_Enable.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Belt_D03_Enable
            // 
            this.Belt_D03_Enable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Belt_D03_Enable.CardNo = ((ushort)(1));
            this.Belt_D03_Enable.Checked = false;
            this.Belt_D03_Enable.IOName = "Belt_D03_Enable";
            this.Belt_D03_Enable.IOText = "Belt_D03_Enable";
            this.Belt_D03_Enable.Location = new System.Drawing.Point(637, 7);
            this.Belt_D03_Enable.Name = "Belt_D03_Enable";
            this.Belt_D03_Enable.Size = new System.Drawing.Size(312, 26);
            this.Belt_D03_Enable.TabIndex = 4;
            this.Belt_D03_Enable.TabStop = false;
            this.Belt_D03_Enable.Value = ((ushort)(0));
            this.Belt_D03_Enable.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Belt_D03_Direction
            // 
            this.Belt_D03_Direction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Belt_D03_Direction.CardNo = ((ushort)(1));
            this.Belt_D03_Direction.Checked = false;
            this.Belt_D03_Direction.IOName = "Belt_D03_Direction";
            this.Belt_D03_Direction.IOText = "Belt_D03_Direction";
            this.Belt_D03_Direction.Location = new System.Drawing.Point(637, 47);
            this.Belt_D03_Direction.Name = "Belt_D03_Direction";
            this.Belt_D03_Direction.Size = new System.Drawing.Size(312, 26);
            this.Belt_D03_Direction.TabIndex = 5;
            this.Belt_D03_Direction.TabStop = false;
            this.Belt_D03_Direction.Value = ((ushort)(0));
            this.Belt_D03_Direction.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Belt_D01_Run
            // 
            this.Belt_D01_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Belt_D01_Run.CardNo = ((ushort)(1));
            this.Belt_D01_Run.Checked = false;
            this.Belt_D01_Run.IOName = "Belt_D01_Run";
            this.Belt_D01_Run.IOText = "Belt_D01_Run";
            this.Belt_D01_Run.Location = new System.Drawing.Point(3, 87);
            this.Belt_D01_Run.Name = "Belt_D01_Run";
            this.Belt_D01_Run.Size = new System.Drawing.Size(311, 26);
            this.Belt_D01_Run.TabIndex = 8;
            this.Belt_D01_Run.TabStop = false;
            this.Belt_D01_Run.Value = ((ushort)(0));
            this.Belt_D01_Run.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Belt_D02_Run
            // 
            this.Belt_D02_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Belt_D02_Run.CardNo = ((ushort)(1));
            this.Belt_D02_Run.Checked = false;
            this.Belt_D02_Run.IOName = "Belt_D02_Run";
            this.Belt_D02_Run.IOText = "Belt_D02_Run";
            this.Belt_D02_Run.Location = new System.Drawing.Point(320, 87);
            this.Belt_D02_Run.Name = "Belt_D02_Run";
            this.Belt_D02_Run.Size = new System.Drawing.Size(311, 26);
            this.Belt_D02_Run.TabIndex = 9;
            this.Belt_D02_Run.TabStop = false;
            this.Belt_D02_Run.Value = ((ushort)(0));
            this.Belt_D02_Run.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Belt_D03_Run
            // 
            this.Belt_D03_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Belt_D03_Run.CardNo = ((ushort)(1));
            this.Belt_D03_Run.Checked = false;
            this.Belt_D03_Run.IOName = "Belt_D03_Run";
            this.Belt_D03_Run.IOText = "Belt_D03_Run";
            this.Belt_D03_Run.Location = new System.Drawing.Point(637, 87);
            this.Belt_D03_Run.Name = "Belt_D03_Run";
            this.Belt_D03_Run.Size = new System.Drawing.Size(312, 26);
            this.Belt_D03_Run.TabIndex = 7;
            this.Belt_D03_Run.TabStop = false;
            this.Belt_D03_Run.Value = ((ushort)(0));
            this.Belt_D03_Run.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Beacon_Lamp_Red
            // 
            this.Beacon_Lamp_Red.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Beacon_Lamp_Red.CardNo = ((ushort)(0));
            this.Beacon_Lamp_Red.Checked = false;
            this.Beacon_Lamp_Red.IOName = "Beacon_Lamp_Red";
            this.Beacon_Lamp_Red.IOText = "Beacon_Lamp_Red";
            this.Beacon_Lamp_Red.Location = new System.Drawing.Point(3, 127);
            this.Beacon_Lamp_Red.Name = "Beacon_Lamp_Red";
            this.Beacon_Lamp_Red.Size = new System.Drawing.Size(311, 26);
            this.Beacon_Lamp_Red.TabIndex = 15;
            this.Beacon_Lamp_Red.TabStop = false;
            this.Beacon_Lamp_Red.Value = ((ushort)(0));
            this.Beacon_Lamp_Red.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Beacon_Lamp_Yellow
            // 
            this.Beacon_Lamp_Yellow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Beacon_Lamp_Yellow.CardNo = ((ushort)(0));
            this.Beacon_Lamp_Yellow.Checked = false;
            this.Beacon_Lamp_Yellow.IOName = "Beacon_Lamp_Yellow";
            this.Beacon_Lamp_Yellow.IOText = "Beacon_Lamp_Yellow";
            this.Beacon_Lamp_Yellow.Location = new System.Drawing.Point(320, 127);
            this.Beacon_Lamp_Yellow.Name = "Beacon_Lamp_Yellow";
            this.Beacon_Lamp_Yellow.Size = new System.Drawing.Size(311, 26);
            this.Beacon_Lamp_Yellow.TabIndex = 13;
            this.Beacon_Lamp_Yellow.TabStop = false;
            this.Beacon_Lamp_Yellow.Value = ((ushort)(0));
            this.Beacon_Lamp_Yellow.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Beacon_Lamp_Green
            // 
            this.Beacon_Lamp_Green.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Beacon_Lamp_Green.CardNo = ((ushort)(0));
            this.Beacon_Lamp_Green.Checked = false;
            this.Beacon_Lamp_Green.IOName = "Beacon_Lamp_Green";
            this.Beacon_Lamp_Green.IOText = "Beacon_Lamp_Green";
            this.Beacon_Lamp_Green.Location = new System.Drawing.Point(637, 127);
            this.Beacon_Lamp_Green.Name = "Beacon_Lamp_Green";
            this.Beacon_Lamp_Green.Size = new System.Drawing.Size(312, 26);
            this.Beacon_Lamp_Green.TabIndex = 11;
            this.Beacon_Lamp_Green.TabStop = false;
            this.Beacon_Lamp_Green.Value = ((ushort)(0));
            this.Beacon_Lamp_Green.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Beacon_Buzzer
            // 
            this.Beacon_Buzzer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Beacon_Buzzer.CardNo = ((ushort)(0));
            this.Beacon_Buzzer.Checked = false;
            this.Beacon_Buzzer.IOName = "Beacon_Buzzer";
            this.Beacon_Buzzer.IOText = "Beacon_Buzzer";
            this.Beacon_Buzzer.Location = new System.Drawing.Point(3, 167);
            this.Beacon_Buzzer.Name = "Beacon_Buzzer";
            this.Beacon_Buzzer.Size = new System.Drawing.Size(311, 26);
            this.Beacon_Buzzer.TabIndex = 10;
            this.Beacon_Buzzer.TabStop = false;
            this.Beacon_Buzzer.Value = ((ushort)(0));
            this.Beacon_Buzzer.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Station_GetReady_Output
            // 
            this.Station_GetReady_Output.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Station_GetReady_Output.CardNo = ((ushort)(1));
            this.Station_GetReady_Output.Checked = false;
            this.Station_GetReady_Output.IOName = "Station_GetReady_Output";
            this.Station_GetReady_Output.IOText = "Station_GetReady_Output";
            this.Station_GetReady_Output.Location = new System.Drawing.Point(637, 167);
            this.Station_GetReady_Output.Name = "Station_GetReady_Output";
            this.Station_GetReady_Output.Size = new System.Drawing.Size(312, 26);
            this.Station_GetReady_Output.TabIndex = 17;
            this.Station_GetReady_Output.TabStop = false;
            this.Station_GetReady_Output.Value = ((ushort)(0));
            this.Station_GetReady_Output.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Station_NotPaste
            // 
            this.Station_NotPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Station_NotPaste.CardNo = ((ushort)(1));
            this.Station_NotPaste.Checked = false;
            this.Station_NotPaste.IOName = "Station_NotPaste";
            this.Station_NotPaste.IOText = "Station_NotPaste";
            this.Station_NotPaste.Location = new System.Drawing.Point(3, 207);
            this.Station_NotPaste.Name = "Station_NotPaste";
            this.Station_NotPaste.Size = new System.Drawing.Size(311, 26);
            this.Station_NotPaste.TabIndex = 12;
            this.Station_NotPaste.TabStop = false;
            this.Station_NotPaste.Value = ((ushort)(0));
            this.Station_NotPaste.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Station_GetReady_Input
            // 
            this.Station_GetReady_Input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Station_GetReady_Input.CardNo = ((ushort)(1));
            this.Station_GetReady_Input.Checked = false;
            this.Station_GetReady_Input.IOName = "Station_GetReady_Input";
            this.Station_GetReady_Input.IOText = "Station_GetReady_Input";
            this.Station_GetReady_Input.Location = new System.Drawing.Point(320, 167);
            this.Station_GetReady_Input.Name = "Station_GetReady_Input";
            this.Station_GetReady_Input.Size = new System.Drawing.Size(311, 26);
            this.Station_GetReady_Input.TabIndex = 16;
            this.Station_GetReady_Input.TabStop = false;
            this.Station_GetReady_Input.Value = ((ushort)(0));
            this.Station_GetReady_Input.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Station_LabelType
            // 
            this.Station_LabelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Station_LabelType.CardNo = ((ushort)(1));
            this.Station_LabelType.Checked = false;
            this.Station_LabelType.IOName = "Station_LabelType";
            this.Station_LabelType.IOText = "Station_LabelType";
            this.Station_LabelType.Location = new System.Drawing.Point(320, 207);
            this.Station_LabelType.Name = "Station_LabelType";
            this.Station_LabelType.Size = new System.Drawing.Size(311, 26);
            this.Station_LabelType.TabIndex = 14;
            this.Station_LabelType.TabStop = false;
            this.Station_LabelType.Value = ((ushort)(0));
            this.Station_LabelType.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Station_SKUChange
            // 
            this.Station_SKUChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Station_SKUChange.CardNo = ((ushort)(1));
            this.Station_SKUChange.Checked = false;
            this.Station_SKUChange.IOName = "Station_SKUChange";
            this.Station_SKUChange.IOText = "Station_SKUChange";
            this.Station_SKUChange.Location = new System.Drawing.Point(637, 207);
            this.Station_SKUChange.Name = "Station_SKUChange";
            this.Station_SKUChange.Size = new System.Drawing.Size(312, 26);
            this.Station_SKUChange.TabIndex = 6;
            this.Station_SKUChange.TabStop = false;
            this.Station_SKUChange.Value = ((ushort)(0));
            this.Station_SKUChange.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Gb_Input
            // 
            this.Gb_Input.Controls.Add(this.Tblp_Input);
            this.Gb_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_Input.Location = new System.Drawing.Point(3, 3);
            this.Gb_Input.Name = "Gb_Input";
            this.Gb_Input.Size = new System.Drawing.Size(958, 274);
            this.Gb_Input.TabIndex = 0;
            this.Gb_Input.TabStop = false;
            this.Gb_Input.Text = "Input";
            // 
            // Tblp_Input
            // 
            this.Tblp_Input.ColumnCount = 3;
            this.Tblp_Input.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tblp_Input.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.Tblp_Input.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.Tblp_Input.Controls.Add(this.Signal_Stop, 0, 2);
            this.Tblp_Input.Controls.Add(this.Station_Next_GetBox, 1, 0);
            this.Tblp_Input.Controls.Add(this.Station_Next_Ready, 0, 0);
            this.Tblp_Input.Controls.Add(this.Signal_EMG, 0, 1);
            this.Tblp_Input.Controls.Add(this.Signal_Reset, 1, 1);
            this.Tblp_Input.Controls.Add(this.Signal_Run, 2, 1);
            this.Tblp_Input.Controls.Add(this.Belt_D01_Alarm, 0, 5);
            this.Tblp_Input.Controls.Add(this.Belt_D02_Alarm, 1, 5);
            this.Tblp_Input.Controls.Add(this.Belt_D03_Alarm, 2, 5);
            this.Tblp_Input.Controls.Add(this.Signal_SafeGuard, 2, 4);
            this.Tblp_Input.Controls.Add(this.Signal_NG_Second, 1, 4);
            this.Tblp_Input.Controls.Add(this.Signal_NG_First, 0, 4);
            this.Tblp_Input.Controls.Add(this.Signal_D01_Enter, 0, 3);
            this.Tblp_Input.Controls.Add(this.Signal_D02_Enter, 1, 3);
            this.Tblp_Input.Controls.Add(this.Signal_D03_Enter, 2, 3);
            this.Tblp_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tblp_Input.Location = new System.Drawing.Point(3, 17);
            this.Tblp_Input.Name = "Tblp_Input";
            this.Tblp_Input.RowCount = 7;
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tblp_Input.Size = new System.Drawing.Size(952, 254);
            this.Tblp_Input.TabIndex = 0;
            // 
            // Signal_Stop
            // 
            this.Signal_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Signal_Stop.CardNo = ((ushort)(0));
            this.Signal_Stop.Checked = false;
            this.Signal_Stop.IOName = "Signal_Stop";
            this.Signal_Stop.IOText = "Signal_Stop";
            this.Signal_Stop.Location = new System.Drawing.Point(3, 87);
            this.Signal_Stop.Name = "Signal_Stop";
            this.Signal_Stop.Size = new System.Drawing.Size(311, 26);
            this.Signal_Stop.TabIndex = 14;
            this.Signal_Stop.Value = ((ushort)(0));
            // 
            // Station_Next_GetBox
            // 
            this.Station_Next_GetBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Station_Next_GetBox.CardNo = ((ushort)(0));
            this.Station_Next_GetBox.Checked = false;
            this.Station_Next_GetBox.IOName = "Station_Next_GetBox";
            this.Station_Next_GetBox.IOText = "Station_Next_GetBox";
            this.Station_Next_GetBox.Location = new System.Drawing.Point(320, 7);
            this.Station_Next_GetBox.Name = "Station_Next_GetBox";
            this.Station_Next_GetBox.Size = new System.Drawing.Size(311, 26);
            this.Station_Next_GetBox.TabIndex = 1;
            this.Station_Next_GetBox.Value = ((ushort)(0));
            // 
            // Station_Next_Ready
            // 
            this.Station_Next_Ready.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Station_Next_Ready.CardNo = ((ushort)(0));
            this.Station_Next_Ready.Checked = false;
            this.Station_Next_Ready.IOName = "Station_Next_Ready";
            this.Station_Next_Ready.IOText = "Station_Next_Ready";
            this.Station_Next_Ready.Location = new System.Drawing.Point(3, 7);
            this.Station_Next_Ready.Name = "Station_Next_Ready";
            this.Station_Next_Ready.Size = new System.Drawing.Size(311, 26);
            this.Station_Next_Ready.TabIndex = 3;
            this.Station_Next_Ready.Value = ((ushort)(0));
            // 
            // Signal_EMG
            // 
            this.Signal_EMG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Signal_EMG.CardNo = ((ushort)(0));
            this.Signal_EMG.Checked = false;
            this.Signal_EMG.IOName = "Signal_EMG";
            this.Signal_EMG.IOText = "Signal_EMG";
            this.Signal_EMG.Location = new System.Drawing.Point(3, 47);
            this.Signal_EMG.Name = "Signal_EMG";
            this.Signal_EMG.Size = new System.Drawing.Size(311, 26);
            this.Signal_EMG.TabIndex = 6;
            this.Signal_EMG.Value = ((ushort)(0));
            // 
            // Signal_Reset
            // 
            this.Signal_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Signal_Reset.CardNo = ((ushort)(0));
            this.Signal_Reset.Checked = false;
            this.Signal_Reset.IOName = "Signal_Reset";
            this.Signal_Reset.IOText = "Signal_Reset";
            this.Signal_Reset.Location = new System.Drawing.Point(320, 47);
            this.Signal_Reset.Name = "Signal_Reset";
            this.Signal_Reset.Size = new System.Drawing.Size(311, 26);
            this.Signal_Reset.TabIndex = 5;
            this.Signal_Reset.Value = ((ushort)(0));
            // 
            // Signal_Run
            // 
            this.Signal_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Signal_Run.CardNo = ((ushort)(0));
            this.Signal_Run.Checked = false;
            this.Signal_Run.IOName = "Signal_Run";
            this.Signal_Run.IOText = "Signal_Run";
            this.Signal_Run.Location = new System.Drawing.Point(637, 47);
            this.Signal_Run.Name = "Signal_Run";
            this.Signal_Run.Size = new System.Drawing.Size(312, 26);
            this.Signal_Run.TabIndex = 11;
            this.Signal_Run.Value = ((ushort)(0));
            // 
            // Belt_D01_Alarm
            // 
            this.Belt_D01_Alarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Belt_D01_Alarm.CardNo = ((ushort)(1));
            this.Belt_D01_Alarm.Checked = false;
            this.Belt_D01_Alarm.IOName = "Belt_D01_Alarm";
            this.Belt_D01_Alarm.IOText = "Belt_D01_Alarm";
            this.Belt_D01_Alarm.Location = new System.Drawing.Point(3, 207);
            this.Belt_D01_Alarm.Name = "Belt_D01_Alarm";
            this.Belt_D01_Alarm.Size = new System.Drawing.Size(311, 26);
            this.Belt_D01_Alarm.TabIndex = 0;
            this.Belt_D01_Alarm.Value = ((ushort)(0));
            // 
            // Belt_D02_Alarm
            // 
            this.Belt_D02_Alarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Belt_D02_Alarm.CardNo = ((ushort)(1));
            this.Belt_D02_Alarm.Checked = false;
            this.Belt_D02_Alarm.IOName = "Belt_D02_Alarm";
            this.Belt_D02_Alarm.IOText = "Belt_D02_Alarm";
            this.Belt_D02_Alarm.Location = new System.Drawing.Point(320, 207);
            this.Belt_D02_Alarm.Name = "Belt_D02_Alarm";
            this.Belt_D02_Alarm.Size = new System.Drawing.Size(311, 26);
            this.Belt_D02_Alarm.TabIndex = 9;
            this.Belt_D02_Alarm.Value = ((ushort)(0));
            // 
            // Belt_D03_Alarm
            // 
            this.Belt_D03_Alarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Belt_D03_Alarm.CardNo = ((ushort)(1));
            this.Belt_D03_Alarm.Checked = false;
            this.Belt_D03_Alarm.IOName = "Belt_D03_Alarm";
            this.Belt_D03_Alarm.IOText = "Belt_D03_Alarm";
            this.Belt_D03_Alarm.Location = new System.Drawing.Point(637, 207);
            this.Belt_D03_Alarm.Name = "Belt_D03_Alarm";
            this.Belt_D03_Alarm.Size = new System.Drawing.Size(312, 26);
            this.Belt_D03_Alarm.TabIndex = 2;
            this.Belt_D03_Alarm.Value = ((ushort)(0));
            // 
            // Signal_SafeGuard
            // 
            this.Signal_SafeGuard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Signal_SafeGuard.CardNo = ((ushort)(0));
            this.Signal_SafeGuard.Checked = false;
            this.Signal_SafeGuard.IOName = "Signal_SafeGuard";
            this.Signal_SafeGuard.IOText = "Signal_SafeGuard";
            this.Signal_SafeGuard.Location = new System.Drawing.Point(637, 167);
            this.Signal_SafeGuard.Name = "Signal_SafeGuard";
            this.Signal_SafeGuard.Size = new System.Drawing.Size(312, 26);
            this.Signal_SafeGuard.TabIndex = 13;
            this.Signal_SafeGuard.Value = ((ushort)(0));
            // 
            // Signal_NG_Second
            // 
            this.Signal_NG_Second.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Signal_NG_Second.CardNo = ((ushort)(0));
            this.Signal_NG_Second.Checked = false;
            this.Signal_NG_Second.IOName = "Signal_NG_Second";
            this.Signal_NG_Second.IOText = "Signal_NG_Second";
            this.Signal_NG_Second.Location = new System.Drawing.Point(320, 167);
            this.Signal_NG_Second.Name = "Signal_NG_Second";
            this.Signal_NG_Second.Size = new System.Drawing.Size(311, 26);
            this.Signal_NG_Second.TabIndex = 12;
            this.Signal_NG_Second.Value = ((ushort)(0));
            // 
            // Signal_NG_First
            // 
            this.Signal_NG_First.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Signal_NG_First.CardNo = ((ushort)(0));
            this.Signal_NG_First.Checked = false;
            this.Signal_NG_First.IOName = "Signal_NG_First";
            this.Signal_NG_First.IOText = "Signal_NG_First";
            this.Signal_NG_First.Location = new System.Drawing.Point(3, 167);
            this.Signal_NG_First.Name = "Signal_NG_First";
            this.Signal_NG_First.Size = new System.Drawing.Size(311, 26);
            this.Signal_NG_First.TabIndex = 10;
            this.Signal_NG_First.Value = ((ushort)(0));
            // 
            // Signal_D01_Enter
            // 
            this.Signal_D01_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Signal_D01_Enter.CardNo = ((ushort)(1));
            this.Signal_D01_Enter.Checked = false;
            this.Signal_D01_Enter.IOName = "Signal_D01_Enter";
            this.Signal_D01_Enter.IOText = "Signal_D01_Enter";
            this.Signal_D01_Enter.Location = new System.Drawing.Point(3, 127);
            this.Signal_D01_Enter.Name = "Signal_D01_Enter";
            this.Signal_D01_Enter.Size = new System.Drawing.Size(311, 26);
            this.Signal_D01_Enter.TabIndex = 8;
            this.Signal_D01_Enter.Value = ((ushort)(0));
            // 
            // Signal_D02_Enter
            // 
            this.Signal_D02_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Signal_D02_Enter.CardNo = ((ushort)(1));
            this.Signal_D02_Enter.Checked = false;
            this.Signal_D02_Enter.IOName = "Signal_D02_Enter";
            this.Signal_D02_Enter.IOText = "Signal_D02_Enter";
            this.Signal_D02_Enter.Location = new System.Drawing.Point(320, 127);
            this.Signal_D02_Enter.Name = "Signal_D02_Enter";
            this.Signal_D02_Enter.Size = new System.Drawing.Size(311, 26);
            this.Signal_D02_Enter.TabIndex = 7;
            this.Signal_D02_Enter.Value = ((ushort)(0));
            // 
            // Signal_D03_Enter
            // 
            this.Signal_D03_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Signal_D03_Enter.CardNo = ((ushort)(1));
            this.Signal_D03_Enter.Checked = false;
            this.Signal_D03_Enter.IOName = "Signal_D03_Enter";
            this.Signal_D03_Enter.IOText = "Signal_D03_Enter";
            this.Signal_D03_Enter.Location = new System.Drawing.Point(637, 127);
            this.Signal_D03_Enter.Name = "Signal_D03_Enter";
            this.Signal_D03_Enter.Size = new System.Drawing.Size(312, 26);
            this.Signal_D03_Enter.TabIndex = 4;
            this.Signal_D03_Enter.Value = ((ushort)(0));
            // 
            // Tp_CylinderDebug
            // 
            this.Tp_CylinderDebug.Controls.Add(this.Tblp_CylinderDebug);
            this.Tp_CylinderDebug.Location = new System.Drawing.Point(4, 22);
            this.Tp_CylinderDebug.Name = "Tp_CylinderDebug";
            this.Tp_CylinderDebug.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_CylinderDebug.Size = new System.Drawing.Size(970, 566);
            this.Tp_CylinderDebug.TabIndex = 4;
            this.Tp_CylinderDebug.Text = "CylinderDebug ";
            this.Tp_CylinderDebug.UseVisualStyleBackColor = true;
            // 
            // Tblp_CylinderDebug
            // 
            this.Tblp_CylinderDebug.ColumnCount = 2;
            this.Tblp_CylinderDebug.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tblp_CylinderDebug.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.Tblp_CylinderDebug.Controls.Add(this.Gb_Output_D03, 0, 1);
            this.Tblp_CylinderDebug.Controls.Add(this.Gb_Output_D02, 1, 0);
            this.Tblp_CylinderDebug.Controls.Add(this.Gb_Output_D01, 0, 0);
            this.Tblp_CylinderDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tblp_CylinderDebug.Location = new System.Drawing.Point(3, 3);
            this.Tblp_CylinderDebug.Name = "Tblp_CylinderDebug";
            this.Tblp_CylinderDebug.RowCount = 2;
            this.Tblp_CylinderDebug.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.15827F));
            this.Tblp_CylinderDebug.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.84173F));
            this.Tblp_CylinderDebug.Size = new System.Drawing.Size(964, 560);
            this.Tblp_CylinderDebug.TabIndex = 0;
            // 
            // Gb_Output_D03
            // 
            this.Tblp_CylinderDebug.SetColumnSpan(this.Gb_Output_D03, 2);
            this.Gb_Output_D03.Controls.Add(this.Tblp_Output_D03);
            this.Gb_Output_D03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_Output_D03.Location = new System.Drawing.Point(3, 155);
            this.Gb_Output_D03.Name = "Gb_Output_D03";
            this.Gb_Output_D03.Size = new System.Drawing.Size(958, 402);
            this.Gb_Output_D03.TabIndex = 4;
            this.Gb_Output_D03.TabStop = false;
            this.Gb_Output_D03.Text = "groupBox11";
            // 
            // Tblp_Output_D03
            // 
            this.Tblp_Output_D03.ColumnCount = 3;
            this.Tblp_Output_D03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tblp_Output_D03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.Tblp_Output_D03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Carry, 1, 3);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Lifter, 0, 3);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Forward, 2, 0);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Rotate, 1, 0);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Clamp_Org, 0, 1);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Clamp_On, 0, 2);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Rotate_Org, 1, 1);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Rotate_On, 1, 2);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Forward_Org, 2, 1);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Forward_On, 2, 2);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Lifter_Org, 0, 4);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Lifter_On, 0, 5);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Carry_Org, 1, 4);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Carry_On, 1, 5);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Adjust_Right_Org, 1, 7);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Adjust_Left_Org, 0, 7);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Adjust_Left_On, 0, 8);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Adjust_Right_On, 1, 8);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Clamp, 0, 0);
            this.Tblp_Output_D03.Controls.Add(this.Cyl_D03Adjust, 0, 6);
            this.Tblp_Output_D03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tblp_Output_D03.Location = new System.Drawing.Point(3, 17);
            this.Tblp_Output_D03.Name = "Tblp_Output_D03";
            this.Tblp_Output_D03.RowCount = 11;
            this.Tblp_Output_D03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tblp_Output_D03.Size = new System.Drawing.Size(952, 382);
            this.Tblp_Output_D03.TabIndex = 1;
            // 
            // Cyl_D03Carry
            // 
            this.Cyl_D03Carry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Carry.CardNo = ((ushort)(0));
            this.Cyl_D03Carry.Checked = false;
            this.Cyl_D03Carry.IOName = "Cyl_D03Carry";
            this.Cyl_D03Carry.IOText = "Cyl_D03Carry";
            this.Cyl_D03Carry.Location = new System.Drawing.Point(320, 127);
            this.Cyl_D03Carry.Name = "Cyl_D03Carry";
            this.Cyl_D03Carry.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Carry.TabIndex = 18;
            this.Cyl_D03Carry.TabStop = false;
            this.Cyl_D03Carry.Value = ((ushort)(0));
            this.Cyl_D03Carry.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Cyl_D03Lifter
            // 
            this.Cyl_D03Lifter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Lifter.CardNo = ((ushort)(0));
            this.Cyl_D03Lifter.Checked = false;
            this.Cyl_D03Lifter.IOName = "Cyl_D03Lifter";
            this.Cyl_D03Lifter.IOText = "Cyl_D03Lifter";
            this.Cyl_D03Lifter.Location = new System.Drawing.Point(3, 127);
            this.Cyl_D03Lifter.Name = "Cyl_D03Lifter";
            this.Cyl_D03Lifter.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Lifter.TabIndex = 17;
            this.Cyl_D03Lifter.TabStop = false;
            this.Cyl_D03Lifter.Value = ((ushort)(0));
            this.Cyl_D03Lifter.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Cyl_D03Forward
            // 
            this.Cyl_D03Forward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Forward.CardNo = ((ushort)(0));
            this.Cyl_D03Forward.Checked = false;
            this.Cyl_D03Forward.IOName = "Cyl_D03Forward";
            this.Cyl_D03Forward.IOText = "Cyl_D03Forward";
            this.Cyl_D03Forward.Location = new System.Drawing.Point(637, 7);
            this.Cyl_D03Forward.Name = "Cyl_D03Forward";
            this.Cyl_D03Forward.Size = new System.Drawing.Size(312, 26);
            this.Cyl_D03Forward.TabIndex = 16;
            this.Cyl_D03Forward.TabStop = false;
            this.Cyl_D03Forward.Value = ((ushort)(0));
            this.Cyl_D03Forward.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Cyl_D03Rotate
            // 
            this.Cyl_D03Rotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Rotate.CardNo = ((ushort)(0));
            this.Cyl_D03Rotate.Checked = false;
            this.Cyl_D03Rotate.IOName = "Cyl_D03Rotate";
            this.Cyl_D03Rotate.IOText = "Cyl_D03Rotate";
            this.Cyl_D03Rotate.Location = new System.Drawing.Point(320, 7);
            this.Cyl_D03Rotate.Name = "Cyl_D03Rotate";
            this.Cyl_D03Rotate.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Rotate.TabIndex = 15;
            this.Cyl_D03Rotate.TabStop = false;
            this.Cyl_D03Rotate.Value = ((ushort)(0));
            this.Cyl_D03Rotate.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Cyl_D03Clamp_Org
            // 
            this.Cyl_D03Clamp_Org.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Clamp_Org.CardNo = ((ushort)(0));
            this.Cyl_D03Clamp_Org.Checked = false;
            this.Cyl_D03Clamp_Org.IOName = "Cyl_D03Clamp_Org";
            this.Cyl_D03Clamp_Org.IOText = "Cyl_D03Clamp_Org";
            this.Cyl_D03Clamp_Org.Location = new System.Drawing.Point(3, 47);
            this.Cyl_D03Clamp_Org.Name = "Cyl_D03Clamp_Org";
            this.Cyl_D03Clamp_Org.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Clamp_Org.TabIndex = 0;
            this.Cyl_D03Clamp_Org.Value = ((ushort)(0));
            // 
            // Cyl_D03Clamp_On
            // 
            this.Cyl_D03Clamp_On.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Clamp_On.CardNo = ((ushort)(0));
            this.Cyl_D03Clamp_On.Checked = false;
            this.Cyl_D03Clamp_On.IOName = "Cyl_D03Clamp_On";
            this.Cyl_D03Clamp_On.IOText = "Cyl_D03Clamp_On";
            this.Cyl_D03Clamp_On.Location = new System.Drawing.Point(3, 87);
            this.Cyl_D03Clamp_On.Name = "Cyl_D03Clamp_On";
            this.Cyl_D03Clamp_On.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Clamp_On.TabIndex = 1;
            this.Cyl_D03Clamp_On.Value = ((ushort)(0));
            // 
            // Cyl_D03Rotate_Org
            // 
            this.Cyl_D03Rotate_Org.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Rotate_Org.CardNo = ((ushort)(0));
            this.Cyl_D03Rotate_Org.Checked = false;
            this.Cyl_D03Rotate_Org.IOName = "Cyl_D03Rotate_Org";
            this.Cyl_D03Rotate_Org.IOText = "Cyl_D03Rotate_Org";
            this.Cyl_D03Rotate_Org.Location = new System.Drawing.Point(320, 47);
            this.Cyl_D03Rotate_Org.Name = "Cyl_D03Rotate_Org";
            this.Cyl_D03Rotate_Org.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Rotate_Org.TabIndex = 2;
            this.Cyl_D03Rotate_Org.Value = ((ushort)(0));
            // 
            // Cyl_D03Rotate_On
            // 
            this.Cyl_D03Rotate_On.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Rotate_On.CardNo = ((ushort)(0));
            this.Cyl_D03Rotate_On.Checked = false;
            this.Cyl_D03Rotate_On.IOName = "Cyl_D03Rotate_On";
            this.Cyl_D03Rotate_On.IOText = "Cyl_D03Rotate_On";
            this.Cyl_D03Rotate_On.Location = new System.Drawing.Point(320, 87);
            this.Cyl_D03Rotate_On.Name = "Cyl_D03Rotate_On";
            this.Cyl_D03Rotate_On.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Rotate_On.TabIndex = 3;
            this.Cyl_D03Rotate_On.Value = ((ushort)(0));
            // 
            // Cyl_D03Forward_Org
            // 
            this.Cyl_D03Forward_Org.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Forward_Org.CardNo = ((ushort)(0));
            this.Cyl_D03Forward_Org.Checked = false;
            this.Cyl_D03Forward_Org.IOName = "Cyl_D03Forward_Org";
            this.Cyl_D03Forward_Org.IOText = "Cyl_D03Forward_Org";
            this.Cyl_D03Forward_Org.Location = new System.Drawing.Point(637, 47);
            this.Cyl_D03Forward_Org.Name = "Cyl_D03Forward_Org";
            this.Cyl_D03Forward_Org.Size = new System.Drawing.Size(312, 26);
            this.Cyl_D03Forward_Org.TabIndex = 4;
            this.Cyl_D03Forward_Org.Value = ((ushort)(0));
            // 
            // Cyl_D03Forward_On
            // 
            this.Cyl_D03Forward_On.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Forward_On.CardNo = ((ushort)(0));
            this.Cyl_D03Forward_On.Checked = false;
            this.Cyl_D03Forward_On.IOName = "Cyl_D03Forward_On";
            this.Cyl_D03Forward_On.IOText = "Cyl_D03Forward_On";
            this.Cyl_D03Forward_On.Location = new System.Drawing.Point(637, 87);
            this.Cyl_D03Forward_On.Name = "Cyl_D03Forward_On";
            this.Cyl_D03Forward_On.Size = new System.Drawing.Size(312, 26);
            this.Cyl_D03Forward_On.TabIndex = 5;
            this.Cyl_D03Forward_On.Value = ((ushort)(0));
            // 
            // Cyl_D03Lifter_Org
            // 
            this.Cyl_D03Lifter_Org.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Lifter_Org.CardNo = ((ushort)(0));
            this.Cyl_D03Lifter_Org.Checked = false;
            this.Cyl_D03Lifter_Org.IOName = "Cyl_D03Lifter_Org";
            this.Cyl_D03Lifter_Org.IOText = "Cyl_D03Lifter_Org";
            this.Cyl_D03Lifter_Org.Location = new System.Drawing.Point(3, 167);
            this.Cyl_D03Lifter_Org.Name = "Cyl_D03Lifter_Org";
            this.Cyl_D03Lifter_Org.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Lifter_Org.TabIndex = 6;
            this.Cyl_D03Lifter_Org.Value = ((ushort)(0));
            // 
            // Cyl_D03Lifter_On
            // 
            this.Cyl_D03Lifter_On.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Lifter_On.CardNo = ((ushort)(0));
            this.Cyl_D03Lifter_On.Checked = false;
            this.Cyl_D03Lifter_On.IOName = "Cyl_D03Lifter_On";
            this.Cyl_D03Lifter_On.IOText = "Cyl_D03Lifter_On";
            this.Cyl_D03Lifter_On.Location = new System.Drawing.Point(3, 207);
            this.Cyl_D03Lifter_On.Name = "Cyl_D03Lifter_On";
            this.Cyl_D03Lifter_On.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Lifter_On.TabIndex = 7;
            this.Cyl_D03Lifter_On.Value = ((ushort)(0));
            // 
            // Cyl_D03Carry_Org
            // 
            this.Cyl_D03Carry_Org.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Carry_Org.CardNo = ((ushort)(0));
            this.Cyl_D03Carry_Org.Checked = false;
            this.Cyl_D03Carry_Org.IOName = "Cyl_D03Carry_Org";
            this.Cyl_D03Carry_Org.IOText = "Cyl_D03Carry_Org";
            this.Cyl_D03Carry_Org.Location = new System.Drawing.Point(320, 167);
            this.Cyl_D03Carry_Org.Name = "Cyl_D03Carry_Org";
            this.Cyl_D03Carry_Org.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Carry_Org.TabIndex = 8;
            this.Cyl_D03Carry_Org.Value = ((ushort)(0));
            // 
            // Cyl_D03Carry_On
            // 
            this.Cyl_D03Carry_On.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Carry_On.CardNo = ((ushort)(0));
            this.Cyl_D03Carry_On.Checked = false;
            this.Cyl_D03Carry_On.IOName = "Cyl_D03Carry_On";
            this.Cyl_D03Carry_On.IOText = "Cyl_D03Carry_On";
            this.Cyl_D03Carry_On.Location = new System.Drawing.Point(320, 207);
            this.Cyl_D03Carry_On.Name = "Cyl_D03Carry_On";
            this.Cyl_D03Carry_On.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Carry_On.TabIndex = 9;
            this.Cyl_D03Carry_On.Value = ((ushort)(0));
            // 
            // Cyl_D03Adjust_Right_Org
            // 
            this.Cyl_D03Adjust_Right_Org.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Adjust_Right_Org.CardNo = ((ushort)(0));
            this.Cyl_D03Adjust_Right_Org.Checked = false;
            this.Cyl_D03Adjust_Right_Org.IOName = "Cyl_D03Adjust_Right_Org";
            this.Cyl_D03Adjust_Right_Org.IOText = "Cyl_D03Adjust_Right_Org";
            this.Cyl_D03Adjust_Right_Org.Location = new System.Drawing.Point(320, 287);
            this.Cyl_D03Adjust_Right_Org.Name = "Cyl_D03Adjust_Right_Org";
            this.Cyl_D03Adjust_Right_Org.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Adjust_Right_Org.TabIndex = 11;
            this.Cyl_D03Adjust_Right_Org.Value = ((ushort)(0));
            // 
            // Cyl_D03Adjust_Left_Org
            // 
            this.Cyl_D03Adjust_Left_Org.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Adjust_Left_Org.CardNo = ((ushort)(0));
            this.Cyl_D03Adjust_Left_Org.Checked = false;
            this.Cyl_D03Adjust_Left_Org.IOName = "Cyl_D03Adjust_Left_Org";
            this.Cyl_D03Adjust_Left_Org.IOText = "Cyl_D03Adjust_Left_Org";
            this.Cyl_D03Adjust_Left_Org.Location = new System.Drawing.Point(3, 287);
            this.Cyl_D03Adjust_Left_Org.Name = "Cyl_D03Adjust_Left_Org";
            this.Cyl_D03Adjust_Left_Org.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Adjust_Left_Org.TabIndex = 10;
            this.Cyl_D03Adjust_Left_Org.Value = ((ushort)(0));
            // 
            // Cyl_D03Adjust_Left_On
            // 
            this.Cyl_D03Adjust_Left_On.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Adjust_Left_On.CardNo = ((ushort)(0));
            this.Cyl_D03Adjust_Left_On.Checked = false;
            this.Cyl_D03Adjust_Left_On.IOName = "Cyl_D03Adjust_Left_On";
            this.Cyl_D03Adjust_Left_On.IOText = "Cyl_D03Adjust_Left_On";
            this.Cyl_D03Adjust_Left_On.Location = new System.Drawing.Point(3, 327);
            this.Cyl_D03Adjust_Left_On.Name = "Cyl_D03Adjust_Left_On";
            this.Cyl_D03Adjust_Left_On.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Adjust_Left_On.TabIndex = 12;
            this.Cyl_D03Adjust_Left_On.Value = ((ushort)(0));
            // 
            // Cyl_D03Adjust_Right_On
            // 
            this.Cyl_D03Adjust_Right_On.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Adjust_Right_On.CardNo = ((ushort)(0));
            this.Cyl_D03Adjust_Right_On.Checked = false;
            this.Cyl_D03Adjust_Right_On.IOName = "Cyl_D03Adjust_Right_On";
            this.Cyl_D03Adjust_Right_On.IOText = "Cyl_D03Adjust_Right_On";
            this.Cyl_D03Adjust_Right_On.Location = new System.Drawing.Point(320, 327);
            this.Cyl_D03Adjust_Right_On.Name = "Cyl_D03Adjust_Right_On";
            this.Cyl_D03Adjust_Right_On.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Adjust_Right_On.TabIndex = 13;
            this.Cyl_D03Adjust_Right_On.Value = ((ushort)(0));
            // 
            // Cyl_D03Clamp
            // 
            this.Cyl_D03Clamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Clamp.CardNo = ((ushort)(0));
            this.Cyl_D03Clamp.Checked = false;
            this.Cyl_D03Clamp.IOName = "Cyl_D03Clamp";
            this.Cyl_D03Clamp.IOText = "Cyl_D03Clamp";
            this.Cyl_D03Clamp.Location = new System.Drawing.Point(3, 7);
            this.Cyl_D03Clamp.Name = "Cyl_D03Clamp";
            this.Cyl_D03Clamp.Size = new System.Drawing.Size(311, 26);
            this.Cyl_D03Clamp.TabIndex = 14;
            this.Cyl_D03Clamp.TabStop = false;
            this.Cyl_D03Clamp.Value = ((ushort)(0));
            this.Cyl_D03Clamp.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Cyl_D03Adjust
            // 
            this.Cyl_D03Adjust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D03Adjust.CardNo = ((ushort)(0));
            this.Cyl_D03Adjust.Checked = false;
            this.Tblp_Output_D03.SetColumnSpan(this.Cyl_D03Adjust, 2);
            this.Cyl_D03Adjust.IOName = "Cyl_D03Adjust";
            this.Cyl_D03Adjust.IOText = "Cyl_D03Adjust";
            this.Cyl_D03Adjust.Location = new System.Drawing.Point(3, 247);
            this.Cyl_D03Adjust.Name = "Cyl_D03Adjust";
            this.Cyl_D03Adjust.Size = new System.Drawing.Size(628, 26);
            this.Cyl_D03Adjust.TabIndex = 19;
            this.Cyl_D03Adjust.TabStop = false;
            this.Cyl_D03Adjust.Value = ((ushort)(0));
            this.Cyl_D03Adjust.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Gb_Output_D02
            // 
            this.Gb_Output_D02.Controls.Add(this.Tblp_Output_D02);
            this.Gb_Output_D02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_Output_D02.Location = new System.Drawing.Point(324, 3);
            this.Gb_Output_D02.Name = "Gb_Output_D02";
            this.Gb_Output_D02.Size = new System.Drawing.Size(637, 146);
            this.Gb_Output_D02.TabIndex = 3;
            this.Gb_Output_D02.TabStop = false;
            this.Gb_Output_D02.Text = "groupBox10";
            // 
            // Tblp_Output_D02
            // 
            this.Tblp_Output_D02.ColumnCount = 2;
            this.Tblp_Output_D02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_Output_D02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_Output_D02.Controls.Add(this.Cyl_D02Weigh_On, 1, 2);
            this.Tblp_Output_D02.Controls.Add(this.Cyl_D02Intercept_On, 0, 2);
            this.Tblp_Output_D02.Controls.Add(this.Cyl_D02Weigh_Org, 1, 1);
            this.Tblp_Output_D02.Controls.Add(this.Cyl_D02Intercept_Org, 0, 1);
            this.Tblp_Output_D02.Controls.Add(this.Cyl_D02Intercept, 0, 0);
            this.Tblp_Output_D02.Controls.Add(this.Cyl_D02Weigh, 1, 0);
            this.Tblp_Output_D02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tblp_Output_D02.Location = new System.Drawing.Point(3, 17);
            this.Tblp_Output_D02.Name = "Tblp_Output_D02";
            this.Tblp_Output_D02.RowCount = 4;
            this.Tblp_Output_D02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tblp_Output_D02.Size = new System.Drawing.Size(631, 126);
            this.Tblp_Output_D02.TabIndex = 0;
            // 
            // Cyl_D02Weigh_On
            // 
            this.Cyl_D02Weigh_On.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D02Weigh_On.CardNo = ((ushort)(0));
            this.Cyl_D02Weigh_On.Checked = false;
            this.Cyl_D02Weigh_On.IOName = "Cyl_D02Weigh_On";
            this.Cyl_D02Weigh_On.IOText = "Cyl_D02Weigh_On";
            this.Cyl_D02Weigh_On.Location = new System.Drawing.Point(318, 87);
            this.Cyl_D02Weigh_On.Name = "Cyl_D02Weigh_On";
            this.Cyl_D02Weigh_On.Size = new System.Drawing.Size(310, 26);
            this.Cyl_D02Weigh_On.TabIndex = 7;
            this.Cyl_D02Weigh_On.Value = ((ushort)(0));
            // 
            // Cyl_D02Intercept_On
            // 
            this.Cyl_D02Intercept_On.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D02Intercept_On.CardNo = ((ushort)(0));
            this.Cyl_D02Intercept_On.Checked = false;
            this.Cyl_D02Intercept_On.IOName = "Cyl_D02Intercept_On";
            this.Cyl_D02Intercept_On.IOText = "Cyl_D02Intercept_On";
            this.Cyl_D02Intercept_On.Location = new System.Drawing.Point(3, 87);
            this.Cyl_D02Intercept_On.Name = "Cyl_D02Intercept_On";
            this.Cyl_D02Intercept_On.Size = new System.Drawing.Size(309, 26);
            this.Cyl_D02Intercept_On.TabIndex = 6;
            this.Cyl_D02Intercept_On.Value = ((ushort)(0));
            // 
            // Cyl_D02Weigh_Org
            // 
            this.Cyl_D02Weigh_Org.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D02Weigh_Org.CardNo = ((ushort)(0));
            this.Cyl_D02Weigh_Org.Checked = false;
            this.Cyl_D02Weigh_Org.IOName = "Cyl_D02Weigh_Org";
            this.Cyl_D02Weigh_Org.IOText = "Cyl_D02Weigh_Org";
            this.Cyl_D02Weigh_Org.Location = new System.Drawing.Point(318, 47);
            this.Cyl_D02Weigh_Org.Name = "Cyl_D02Weigh_Org";
            this.Cyl_D02Weigh_Org.Size = new System.Drawing.Size(310, 26);
            this.Cyl_D02Weigh_Org.TabIndex = 5;
            this.Cyl_D02Weigh_Org.Value = ((ushort)(0));
            // 
            // Cyl_D02Intercept_Org
            // 
            this.Cyl_D02Intercept_Org.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D02Intercept_Org.CardNo = ((ushort)(0));
            this.Cyl_D02Intercept_Org.Checked = false;
            this.Cyl_D02Intercept_Org.IOName = "Cyl_D02Intercept_Org";
            this.Cyl_D02Intercept_Org.IOText = "Cyl_D02Intercept_Org";
            this.Cyl_D02Intercept_Org.Location = new System.Drawing.Point(3, 47);
            this.Cyl_D02Intercept_Org.Name = "Cyl_D02Intercept_Org";
            this.Cyl_D02Intercept_Org.Size = new System.Drawing.Size(309, 26);
            this.Cyl_D02Intercept_Org.TabIndex = 4;
            this.Cyl_D02Intercept_Org.Value = ((ushort)(0));
            // 
            // Cyl_D02Intercept
            // 
            this.Cyl_D02Intercept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D02Intercept.CardNo = ((ushort)(0));
            this.Cyl_D02Intercept.Checked = false;
            this.Cyl_D02Intercept.IOName = "Cyl_D02Intercept";
            this.Cyl_D02Intercept.IOText = "Cyl_D02Intercept";
            this.Cyl_D02Intercept.Location = new System.Drawing.Point(3, 7);
            this.Cyl_D02Intercept.Name = "Cyl_D02Intercept";
            this.Cyl_D02Intercept.Size = new System.Drawing.Size(309, 26);
            this.Cyl_D02Intercept.TabIndex = 1;
            this.Cyl_D02Intercept.TabStop = false;
            this.Cyl_D02Intercept.Value = ((ushort)(0));
            this.Cyl_D02Intercept.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Cyl_D02Weigh
            // 
            this.Cyl_D02Weigh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D02Weigh.CardNo = ((ushort)(0));
            this.Cyl_D02Weigh.Checked = false;
            this.Cyl_D02Weigh.IOName = "Cyl_D02Weigh";
            this.Cyl_D02Weigh.IOText = "Cyl_D02Weigh";
            this.Cyl_D02Weigh.Location = new System.Drawing.Point(318, 7);
            this.Cyl_D02Weigh.Name = "Cyl_D02Weigh";
            this.Cyl_D02Weigh.Size = new System.Drawing.Size(310, 26);
            this.Cyl_D02Weigh.TabIndex = 2;
            this.Cyl_D02Weigh.TabStop = false;
            this.Cyl_D02Weigh.Value = ((ushort)(0));
            this.Cyl_D02Weigh.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Gb_Output_D01
            // 
            this.Gb_Output_D01.Controls.Add(this.Tblp_Output_D01);
            this.Gb_Output_D01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_Output_D01.Location = new System.Drawing.Point(3, 3);
            this.Gb_Output_D01.Name = "Gb_Output_D01";
            this.Gb_Output_D01.Size = new System.Drawing.Size(315, 146);
            this.Gb_Output_D01.TabIndex = 2;
            this.Gb_Output_D01.TabStop = false;
            this.Gb_Output_D01.Text = "groupBox9";
            // 
            // Tblp_Output_D01
            // 
            this.Tblp_Output_D01.ColumnCount = 1;
            this.Tblp_Output_D01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tblp_Output_D01.Controls.Add(this.Cyl_D01Intercept_On, 0, 2);
            this.Tblp_Output_D01.Controls.Add(this.Cyl_D01Intercept, 0, 0);
            this.Tblp_Output_D01.Controls.Add(this.Cyl_D01Intercept_Org, 0, 1);
            this.Tblp_Output_D01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tblp_Output_D01.Location = new System.Drawing.Point(3, 17);
            this.Tblp_Output_D01.Name = "Tblp_Output_D01";
            this.Tblp_Output_D01.RowCount = 4;
            this.Tblp_Output_D01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Tblp_Output_D01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tblp_Output_D01.Size = new System.Drawing.Size(309, 126);
            this.Tblp_Output_D01.TabIndex = 1;
            // 
            // Cyl_D01Intercept_On
            // 
            this.Cyl_D01Intercept_On.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D01Intercept_On.CardNo = ((ushort)(0));
            this.Cyl_D01Intercept_On.Checked = false;
            this.Cyl_D01Intercept_On.IOName = "Cyl_D01Intercept_On";
            this.Cyl_D01Intercept_On.IOText = "Cyl_D01Intercept_On";
            this.Cyl_D01Intercept_On.Location = new System.Drawing.Point(3, 87);
            this.Cyl_D01Intercept_On.Name = "Cyl_D01Intercept_On";
            this.Cyl_D01Intercept_On.Size = new System.Drawing.Size(303, 26);
            this.Cyl_D01Intercept_On.TabIndex = 4;
            this.Cyl_D01Intercept_On.Value = ((ushort)(0));
            // 
            // Cyl_D01Intercept
            // 
            this.Cyl_D01Intercept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D01Intercept.CardNo = ((ushort)(0));
            this.Cyl_D01Intercept.Checked = false;
            this.Cyl_D01Intercept.IOName = "Cyl_D01Intercept";
            this.Cyl_D01Intercept.IOText = "Cyl_D01Intercept";
            this.Cyl_D01Intercept.Location = new System.Drawing.Point(3, 7);
            this.Cyl_D01Intercept.Name = "Cyl_D01Intercept";
            this.Cyl_D01Intercept.Size = new System.Drawing.Size(303, 26);
            this.Cyl_D01Intercept.TabIndex = 0;
            this.Cyl_D01Intercept.TabStop = false;
            this.Cyl_D01Intercept.Value = ((ushort)(0));
            this.Cyl_D01Intercept.TabStopChanged += new System.EventHandler(this.OutputClick);
            // 
            // Cyl_D01Intercept_Org
            // 
            this.Cyl_D01Intercept_Org.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cyl_D01Intercept_Org.CardNo = ((ushort)(0));
            this.Cyl_D01Intercept_Org.Checked = false;
            this.Cyl_D01Intercept_Org.IOName = "Cyl_D01Intercept_Org";
            this.Cyl_D01Intercept_Org.IOText = "Cyl_D01Intercept_Org";
            this.Cyl_D01Intercept_Org.Location = new System.Drawing.Point(3, 47);
            this.Cyl_D01Intercept_Org.Name = "Cyl_D01Intercept_Org";
            this.Cyl_D01Intercept_Org.Size = new System.Drawing.Size(303, 26);
            this.Cyl_D01Intercept_Org.TabIndex = 3;
            this.Cyl_D01Intercept_Org.Value = ((ushort)(0));
            // 
            // Tp_StepDebug
            // 
            this.Tp_StepDebug.Controls.Add(this.Tblp_StepDebug);
            this.Tp_StepDebug.Location = new System.Drawing.Point(4, 22);
            this.Tp_StepDebug.Name = "Tp_StepDebug";
            this.Tp_StepDebug.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_StepDebug.Size = new System.Drawing.Size(970, 566);
            this.Tp_StepDebug.TabIndex = 5;
            this.Tp_StepDebug.Text = "StepDebug     ";
            this.Tp_StepDebug.UseVisualStyleBackColor = true;
            // 
            // Tblp_StepDebug
            // 
            this.Tblp_StepDebug.ColumnCount = 3;
            this.Tblp_StepDebug.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tblp_StepDebug.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tblp_StepDebug.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tblp_StepDebug.Controls.Add(this.Gb_Step_D02, 1, 0);
            this.Tblp_StepDebug.Controls.Add(this.Gb_Step_D03, 2, 0);
            this.Tblp_StepDebug.Controls.Add(this.Gb_Step_D01, 0, 0);
            this.Tblp_StepDebug.Controls.Add(this.Gb_Step_Belt, 0, 1);
            this.Tblp_StepDebug.Controls.Add(this.Gb_Step_Beacon, 1, 1);
            this.Tblp_StepDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tblp_StepDebug.Location = new System.Drawing.Point(3, 3);
            this.Tblp_StepDebug.Name = "Tblp_StepDebug";
            this.Tblp_StepDebug.RowCount = 2;
            this.Tblp_StepDebug.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.3703F));
            this.Tblp_StepDebug.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.62969F));
            this.Tblp_StepDebug.Size = new System.Drawing.Size(964, 560);
            this.Tblp_StepDebug.TabIndex = 0;
            // 
            // Gb_Step_D02
            // 
            this.Gb_Step_D02.Controls.Add(this.tableLayoutPanel3);
            this.Gb_Step_D02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_Step_D02.Location = new System.Drawing.Point(324, 3);
            this.Gb_Step_D02.Name = "Gb_Step_D02";
            this.Gb_Step_D02.Size = new System.Drawing.Size(315, 147);
            this.Gb_Step_D02.TabIndex = 2;
            this.Gb_Step_D02.TabStop = false;
            this.Gb_Step_D02.Text = "Step_D02";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.Btn_VirtualAction_D02, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.Btn_Cyl_D02Intercept, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Btn_Cyl_D02Weigh, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(309, 127);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // Btn_VirtualAction_D02
            // 
            this.Btn_VirtualAction_D02.BackColor = System.Drawing.Color.Aqua;
            this.Btn_VirtualAction_D02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_VirtualAction_D02.Location = new System.Drawing.Point(3, 83);
            this.Btn_VirtualAction_D02.Name = "Btn_VirtualAction_D02";
            this.Btn_VirtualAction_D02.Size = new System.Drawing.Size(303, 34);
            this.Btn_VirtualAction_D02.TabIndex = 2;
            this.Btn_VirtualAction_D02.Text = "Btn_VirtualAction_D02";
            this.Btn_VirtualAction_D02.UseVisualStyleBackColor = false;
            this.Btn_VirtualAction_D02.Click += new System.EventHandler(this.Btn_VirtualAction_D02_Click);
            // 
            // Btn_Cyl_D02Intercept
            // 
            this.Btn_Cyl_D02Intercept.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Cyl_D02Intercept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cyl_D02Intercept.Location = new System.Drawing.Point(3, 3);
            this.Btn_Cyl_D02Intercept.Name = "Btn_Cyl_D02Intercept";
            this.Btn_Cyl_D02Intercept.Size = new System.Drawing.Size(303, 34);
            this.Btn_Cyl_D02Intercept.TabIndex = 0;
            this.Btn_Cyl_D02Intercept.Text = "Btn_Cyl_D02Intercept";
            this.Btn_Cyl_D02Intercept.UseVisualStyleBackColor = false;
            this.Btn_Cyl_D02Intercept.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Cyl_D02Weigh
            // 
            this.Btn_Cyl_D02Weigh.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Cyl_D02Weigh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cyl_D02Weigh.Location = new System.Drawing.Point(3, 43);
            this.Btn_Cyl_D02Weigh.Name = "Btn_Cyl_D02Weigh";
            this.Btn_Cyl_D02Weigh.Size = new System.Drawing.Size(303, 34);
            this.Btn_Cyl_D02Weigh.TabIndex = 1;
            this.Btn_Cyl_D02Weigh.Text = "Btn_Cyl_D02Weigh";
            this.Btn_Cyl_D02Weigh.UseVisualStyleBackColor = false;
            this.Btn_Cyl_D02Weigh.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Gb_Step_D03
            // 
            this.Gb_Step_D03.Controls.Add(this.tableLayoutPanel6);
            this.Gb_Step_D03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_Step_D03.Location = new System.Drawing.Point(645, 3);
            this.Gb_Step_D03.Name = "Gb_Step_D03";
            this.Tblp_StepDebug.SetRowSpan(this.Gb_Step_D03, 2);
            this.Gb_Step_D03.Size = new System.Drawing.Size(316, 554);
            this.Gb_Step_D03.TabIndex = 1;
            this.Gb_Step_D03.TabStop = false;
            this.Gb_Step_D03.Text = "Step_D03";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.Btn_VirtualAction_D03, 0, 12);
            this.tableLayoutPanel6.Controls.Add(this.Btn_PassAction, 0, 11);
            this.tableLayoutPanel6.Controls.Add(this.Btn_NGAction, 0, 10);
            this.tableLayoutPanel6.Controls.Add(this.Btn_Station_SKUChange, 0, 9);
            this.tableLayoutPanel6.Controls.Add(this.Btn_Station_LabelType, 0, 8);
            this.tableLayoutPanel6.Controls.Add(this.Btn_Station_NotPaste, 0, 7);
            this.tableLayoutPanel6.Controls.Add(this.Btn_Station_GetReady_Output, 0, 6);
            this.tableLayoutPanel6.Controls.Add(this.Btn_Cyl_D03Carry, 0, 5);
            this.tableLayoutPanel6.Controls.Add(this.Btn_Cyl_D03Rotate, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.Btn_Cyl_D03Clamp, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.Btn_Cyl_D03Forward, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.Btn_Cyl_D03Lifter, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.Btn_Cyl_D03Adjust, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 14;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(310, 534);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // Btn_VirtualAction_D03
            // 
            this.Btn_VirtualAction_D03.BackColor = System.Drawing.Color.Aqua;
            this.Btn_VirtualAction_D03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_VirtualAction_D03.Location = new System.Drawing.Point(3, 483);
            this.Btn_VirtualAction_D03.Name = "Btn_VirtualAction_D03";
            this.Btn_VirtualAction_D03.Size = new System.Drawing.Size(304, 34);
            this.Btn_VirtualAction_D03.TabIndex = 12;
            this.Btn_VirtualAction_D03.Text = "Btn_VirtualAction_D03";
            this.Btn_VirtualAction_D03.UseVisualStyleBackColor = false;
            this.Btn_VirtualAction_D03.Click += new System.EventHandler(this.Btn_VirtualAction_D03_Click);
            // 
            // Btn_PassAction
            // 
            this.Btn_PassAction.BackColor = System.Drawing.Color.Aqua;
            this.Btn_PassAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_PassAction.Location = new System.Drawing.Point(3, 443);
            this.Btn_PassAction.Name = "Btn_PassAction";
            this.Btn_PassAction.Size = new System.Drawing.Size(304, 34);
            this.Btn_PassAction.TabIndex = 11;
            this.Btn_PassAction.Text = "Btn_PassAction";
            this.Btn_PassAction.UseVisualStyleBackColor = false;
            this.Btn_PassAction.Click += new System.EventHandler(this.Btn_PassAction_Click);
            // 
            // Btn_NGAction
            // 
            this.Btn_NGAction.BackColor = System.Drawing.Color.Aqua;
            this.Btn_NGAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_NGAction.Location = new System.Drawing.Point(3, 403);
            this.Btn_NGAction.Name = "Btn_NGAction";
            this.Btn_NGAction.Size = new System.Drawing.Size(304, 34);
            this.Btn_NGAction.TabIndex = 10;
            this.Btn_NGAction.Text = "Btn_NGAction";
            this.Btn_NGAction.UseVisualStyleBackColor = false;
            this.Btn_NGAction.Click += new System.EventHandler(this.Btn_NGAction_Click);
            // 
            // Btn_Station_SKUChange
            // 
            this.Btn_Station_SKUChange.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Station_SKUChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Station_SKUChange.Location = new System.Drawing.Point(3, 363);
            this.Btn_Station_SKUChange.Name = "Btn_Station_SKUChange";
            this.Btn_Station_SKUChange.Size = new System.Drawing.Size(304, 34);
            this.Btn_Station_SKUChange.TabIndex = 9;
            this.Btn_Station_SKUChange.Text = "Btn_Station_SKUChange";
            this.Btn_Station_SKUChange.UseVisualStyleBackColor = false;
            this.Btn_Station_SKUChange.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Station_LabelType
            // 
            this.Btn_Station_LabelType.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Station_LabelType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Station_LabelType.Location = new System.Drawing.Point(3, 323);
            this.Btn_Station_LabelType.Name = "Btn_Station_LabelType";
            this.Btn_Station_LabelType.Size = new System.Drawing.Size(304, 34);
            this.Btn_Station_LabelType.TabIndex = 8;
            this.Btn_Station_LabelType.Text = "Btn_Station_LabelType";
            this.Btn_Station_LabelType.UseVisualStyleBackColor = false;
            this.Btn_Station_LabelType.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Station_NotPaste
            // 
            this.Btn_Station_NotPaste.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Station_NotPaste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Station_NotPaste.Location = new System.Drawing.Point(3, 283);
            this.Btn_Station_NotPaste.Name = "Btn_Station_NotPaste";
            this.Btn_Station_NotPaste.Size = new System.Drawing.Size(304, 34);
            this.Btn_Station_NotPaste.TabIndex = 7;
            this.Btn_Station_NotPaste.Text = "Btn_Station_NotPaste";
            this.Btn_Station_NotPaste.UseVisualStyleBackColor = false;
            this.Btn_Station_NotPaste.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Station_GetReady_Output
            // 
            this.Btn_Station_GetReady_Output.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Station_GetReady_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Station_GetReady_Output.Location = new System.Drawing.Point(3, 243);
            this.Btn_Station_GetReady_Output.Name = "Btn_Station_GetReady_Output";
            this.Btn_Station_GetReady_Output.Size = new System.Drawing.Size(304, 34);
            this.Btn_Station_GetReady_Output.TabIndex = 6;
            this.Btn_Station_GetReady_Output.Text = "Btn_Station_GetReady_Output";
            this.Btn_Station_GetReady_Output.UseVisualStyleBackColor = false;
            this.Btn_Station_GetReady_Output.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Cyl_D03Carry
            // 
            this.Btn_Cyl_D03Carry.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Cyl_D03Carry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cyl_D03Carry.Location = new System.Drawing.Point(3, 203);
            this.Btn_Cyl_D03Carry.Name = "Btn_Cyl_D03Carry";
            this.Btn_Cyl_D03Carry.Size = new System.Drawing.Size(304, 34);
            this.Btn_Cyl_D03Carry.TabIndex = 5;
            this.Btn_Cyl_D03Carry.Text = "Btn_Cyl_D03Carry";
            this.Btn_Cyl_D03Carry.UseVisualStyleBackColor = false;
            this.Btn_Cyl_D03Carry.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Cyl_D03Rotate
            // 
            this.Btn_Cyl_D03Rotate.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Cyl_D03Rotate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cyl_D03Rotate.Location = new System.Drawing.Point(3, 163);
            this.Btn_Cyl_D03Rotate.Name = "Btn_Cyl_D03Rotate";
            this.Btn_Cyl_D03Rotate.Size = new System.Drawing.Size(304, 34);
            this.Btn_Cyl_D03Rotate.TabIndex = 4;
            this.Btn_Cyl_D03Rotate.Text = "Btn_Cyl_D03Rotate";
            this.Btn_Cyl_D03Rotate.UseVisualStyleBackColor = false;
            this.Btn_Cyl_D03Rotate.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Cyl_D03Clamp
            // 
            this.Btn_Cyl_D03Clamp.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Cyl_D03Clamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cyl_D03Clamp.Location = new System.Drawing.Point(3, 123);
            this.Btn_Cyl_D03Clamp.Name = "Btn_Cyl_D03Clamp";
            this.Btn_Cyl_D03Clamp.Size = new System.Drawing.Size(304, 34);
            this.Btn_Cyl_D03Clamp.TabIndex = 3;
            this.Btn_Cyl_D03Clamp.Text = "Btn_Cyl_D03Clamp";
            this.Btn_Cyl_D03Clamp.UseVisualStyleBackColor = false;
            this.Btn_Cyl_D03Clamp.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Cyl_D03Forward
            // 
            this.Btn_Cyl_D03Forward.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Cyl_D03Forward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cyl_D03Forward.Location = new System.Drawing.Point(3, 83);
            this.Btn_Cyl_D03Forward.Name = "Btn_Cyl_D03Forward";
            this.Btn_Cyl_D03Forward.Size = new System.Drawing.Size(304, 34);
            this.Btn_Cyl_D03Forward.TabIndex = 2;
            this.Btn_Cyl_D03Forward.Text = "Btn_Cyl_D03Forward";
            this.Btn_Cyl_D03Forward.UseVisualStyleBackColor = false;
            this.Btn_Cyl_D03Forward.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Cyl_D03Lifter
            // 
            this.Btn_Cyl_D03Lifter.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Cyl_D03Lifter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cyl_D03Lifter.Location = new System.Drawing.Point(3, 43);
            this.Btn_Cyl_D03Lifter.Name = "Btn_Cyl_D03Lifter";
            this.Btn_Cyl_D03Lifter.Size = new System.Drawing.Size(304, 34);
            this.Btn_Cyl_D03Lifter.TabIndex = 1;
            this.Btn_Cyl_D03Lifter.Text = "Btn_Cyl_D03Lifter";
            this.Btn_Cyl_D03Lifter.UseVisualStyleBackColor = false;
            this.Btn_Cyl_D03Lifter.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Cyl_D03Adjust
            // 
            this.Btn_Cyl_D03Adjust.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Cyl_D03Adjust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cyl_D03Adjust.Location = new System.Drawing.Point(3, 3);
            this.Btn_Cyl_D03Adjust.Name = "Btn_Cyl_D03Adjust";
            this.Btn_Cyl_D03Adjust.Size = new System.Drawing.Size(304, 34);
            this.Btn_Cyl_D03Adjust.TabIndex = 0;
            this.Btn_Cyl_D03Adjust.Text = "Btn_Cyl_D03Adjust";
            this.Btn_Cyl_D03Adjust.UseVisualStyleBackColor = false;
            this.Btn_Cyl_D03Adjust.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Gb_Step_D01
            // 
            this.Gb_Step_D01.Controls.Add(this.tableLayoutPanel2);
            this.Gb_Step_D01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_Step_D01.Location = new System.Drawing.Point(3, 3);
            this.Gb_Step_D01.Name = "Gb_Step_D01";
            this.Gb_Step_D01.Size = new System.Drawing.Size(315, 147);
            this.Gb_Step_D01.TabIndex = 0;
            this.Gb_Step_D01.TabStop = false;
            this.Gb_Step_D01.Text = "Step_D01";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.Btn_VirtualAction_D01, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.Btn_Cyl_D01Intercept, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Btn_Station_GetReady_Input, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(309, 127);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // Btn_VirtualAction_D01
            // 
            this.Btn_VirtualAction_D01.BackColor = System.Drawing.Color.Aqua;
            this.Btn_VirtualAction_D01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_VirtualAction_D01.Location = new System.Drawing.Point(3, 83);
            this.Btn_VirtualAction_D01.Name = "Btn_VirtualAction_D01";
            this.Btn_VirtualAction_D01.Size = new System.Drawing.Size(303, 34);
            this.Btn_VirtualAction_D01.TabIndex = 2;
            this.Btn_VirtualAction_D01.Text = "Btn_VirtualAction_D01";
            this.Btn_VirtualAction_D01.UseVisualStyleBackColor = false;
            this.Btn_VirtualAction_D01.Click += new System.EventHandler(this.Btn_VirtualAction_D01_Click);
            // 
            // Btn_Cyl_D01Intercept
            // 
            this.Btn_Cyl_D01Intercept.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Cyl_D01Intercept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cyl_D01Intercept.Location = new System.Drawing.Point(3, 3);
            this.Btn_Cyl_D01Intercept.Name = "Btn_Cyl_D01Intercept";
            this.Btn_Cyl_D01Intercept.Size = new System.Drawing.Size(303, 34);
            this.Btn_Cyl_D01Intercept.TabIndex = 0;
            this.Btn_Cyl_D01Intercept.Text = "Btn_Cyl_D01Intercept";
            this.Btn_Cyl_D01Intercept.UseVisualStyleBackColor = false;
            this.Btn_Cyl_D01Intercept.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Station_GetReady_Input
            // 
            this.Btn_Station_GetReady_Input.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Station_GetReady_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Station_GetReady_Input.Location = new System.Drawing.Point(3, 43);
            this.Btn_Station_GetReady_Input.Name = "Btn_Station_GetReady_Input";
            this.Btn_Station_GetReady_Input.Size = new System.Drawing.Size(303, 34);
            this.Btn_Station_GetReady_Input.TabIndex = 1;
            this.Btn_Station_GetReady_Input.Text = "Btn_Station_GetReady_Input";
            this.Btn_Station_GetReady_Input.UseVisualStyleBackColor = false;
            this.Btn_Station_GetReady_Input.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Gb_Step_Belt
            // 
            this.Gb_Step_Belt.Controls.Add(this.tableLayoutPanel8);
            this.Gb_Step_Belt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_Step_Belt.Location = new System.Drawing.Point(3, 156);
            this.Gb_Step_Belt.Name = "Gb_Step_Belt";
            this.Gb_Step_Belt.Size = new System.Drawing.Size(315, 401);
            this.Gb_Step_Belt.TabIndex = 3;
            this.Gb_Step_Belt.TabStop = false;
            this.Gb_Step_Belt.Text = "Step_Belt";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.Btn_Belt_D03_Run, 0, 8);
            this.tableLayoutPanel8.Controls.Add(this.Btn_Belt_D03_Direction, 0, 7);
            this.tableLayoutPanel8.Controls.Add(this.Btn_Belt_D03_Enable, 0, 6);
            this.tableLayoutPanel8.Controls.Add(this.Btn_Belt_D02_Run, 0, 5);
            this.tableLayoutPanel8.Controls.Add(this.Btn_Belt_D02_Direction, 0, 4);
            this.tableLayoutPanel8.Controls.Add(this.Btn_Belt_D02_Enable, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.Btn_Belt_D01_Run, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.Btn_Belt_D01_Direction, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.Btn_Belt_D01_Enable, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 10;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(309, 381);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // Btn_Belt_D03_Run
            // 
            this.Btn_Belt_D03_Run.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Belt_D03_Run.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Belt_D03_Run.Location = new System.Drawing.Point(3, 323);
            this.Btn_Belt_D03_Run.Name = "Btn_Belt_D03_Run";
            this.Btn_Belt_D03_Run.Size = new System.Drawing.Size(303, 34);
            this.Btn_Belt_D03_Run.TabIndex = 8;
            this.Btn_Belt_D03_Run.Text = "Btn_Belt_D03_Run";
            this.Btn_Belt_D03_Run.UseVisualStyleBackColor = false;
            this.Btn_Belt_D03_Run.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Belt_D03_Direction
            // 
            this.Btn_Belt_D03_Direction.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Belt_D03_Direction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Belt_D03_Direction.Location = new System.Drawing.Point(3, 283);
            this.Btn_Belt_D03_Direction.Name = "Btn_Belt_D03_Direction";
            this.Btn_Belt_D03_Direction.Size = new System.Drawing.Size(303, 34);
            this.Btn_Belt_D03_Direction.TabIndex = 7;
            this.Btn_Belt_D03_Direction.Text = "Btn_Belt_D03_Direction";
            this.Btn_Belt_D03_Direction.UseVisualStyleBackColor = false;
            this.Btn_Belt_D03_Direction.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Belt_D03_Enable
            // 
            this.Btn_Belt_D03_Enable.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Belt_D03_Enable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Belt_D03_Enable.Location = new System.Drawing.Point(3, 243);
            this.Btn_Belt_D03_Enable.Name = "Btn_Belt_D03_Enable";
            this.Btn_Belt_D03_Enable.Size = new System.Drawing.Size(303, 34);
            this.Btn_Belt_D03_Enable.TabIndex = 6;
            this.Btn_Belt_D03_Enable.Text = "Btn_Belt_D03_Enable";
            this.Btn_Belt_D03_Enable.UseVisualStyleBackColor = false;
            this.Btn_Belt_D03_Enable.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Belt_D02_Run
            // 
            this.Btn_Belt_D02_Run.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Belt_D02_Run.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Belt_D02_Run.Location = new System.Drawing.Point(3, 203);
            this.Btn_Belt_D02_Run.Name = "Btn_Belt_D02_Run";
            this.Btn_Belt_D02_Run.Size = new System.Drawing.Size(303, 34);
            this.Btn_Belt_D02_Run.TabIndex = 5;
            this.Btn_Belt_D02_Run.Text = "Btn_Belt_D02_Run";
            this.Btn_Belt_D02_Run.UseVisualStyleBackColor = false;
            this.Btn_Belt_D02_Run.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Belt_D02_Direction
            // 
            this.Btn_Belt_D02_Direction.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Belt_D02_Direction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Belt_D02_Direction.Location = new System.Drawing.Point(3, 163);
            this.Btn_Belt_D02_Direction.Name = "Btn_Belt_D02_Direction";
            this.Btn_Belt_D02_Direction.Size = new System.Drawing.Size(303, 34);
            this.Btn_Belt_D02_Direction.TabIndex = 4;
            this.Btn_Belt_D02_Direction.Text = "Btn_Belt_D02_Direction";
            this.Btn_Belt_D02_Direction.UseVisualStyleBackColor = false;
            this.Btn_Belt_D02_Direction.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Belt_D02_Enable
            // 
            this.Btn_Belt_D02_Enable.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Belt_D02_Enable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Belt_D02_Enable.Location = new System.Drawing.Point(3, 123);
            this.Btn_Belt_D02_Enable.Name = "Btn_Belt_D02_Enable";
            this.Btn_Belt_D02_Enable.Size = new System.Drawing.Size(303, 34);
            this.Btn_Belt_D02_Enable.TabIndex = 3;
            this.Btn_Belt_D02_Enable.Text = "Btn_Belt_D02_Enable";
            this.Btn_Belt_D02_Enable.UseVisualStyleBackColor = false;
            this.Btn_Belt_D02_Enable.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Belt_D01_Run
            // 
            this.Btn_Belt_D01_Run.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Belt_D01_Run.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Belt_D01_Run.Location = new System.Drawing.Point(3, 83);
            this.Btn_Belt_D01_Run.Name = "Btn_Belt_D01_Run";
            this.Btn_Belt_D01_Run.Size = new System.Drawing.Size(303, 34);
            this.Btn_Belt_D01_Run.TabIndex = 2;
            this.Btn_Belt_D01_Run.Text = "Btn_Belt_D01_Run";
            this.Btn_Belt_D01_Run.UseVisualStyleBackColor = false;
            this.Btn_Belt_D01_Run.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Belt_D01_Direction
            // 
            this.Btn_Belt_D01_Direction.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Belt_D01_Direction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Belt_D01_Direction.Location = new System.Drawing.Point(3, 43);
            this.Btn_Belt_D01_Direction.Name = "Btn_Belt_D01_Direction";
            this.Btn_Belt_D01_Direction.Size = new System.Drawing.Size(303, 34);
            this.Btn_Belt_D01_Direction.TabIndex = 1;
            this.Btn_Belt_D01_Direction.Text = "Btn_Belt_D01_Direction";
            this.Btn_Belt_D01_Direction.UseVisualStyleBackColor = false;
            this.Btn_Belt_D01_Direction.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Belt_D01_Enable
            // 
            this.Btn_Belt_D01_Enable.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Belt_D01_Enable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Belt_D01_Enable.Location = new System.Drawing.Point(3, 3);
            this.Btn_Belt_D01_Enable.Name = "Btn_Belt_D01_Enable";
            this.Btn_Belt_D01_Enable.Size = new System.Drawing.Size(303, 34);
            this.Btn_Belt_D01_Enable.TabIndex = 0;
            this.Btn_Belt_D01_Enable.Text = "Btn_Belt_D01_Enable";
            this.Btn_Belt_D01_Enable.UseVisualStyleBackColor = false;
            this.Btn_Belt_D01_Enable.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Gb_Step_Beacon
            // 
            this.Gb_Step_Beacon.Controls.Add(this.tableLayoutPanel9);
            this.Gb_Step_Beacon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_Step_Beacon.Location = new System.Drawing.Point(324, 156);
            this.Gb_Step_Beacon.Name = "Gb_Step_Beacon";
            this.Gb_Step_Beacon.Size = new System.Drawing.Size(315, 401);
            this.Gb_Step_Beacon.TabIndex = 4;
            this.Gb_Step_Beacon.TabStop = false;
            this.Gb_Step_Beacon.Text = "Step_Beacon";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.Btn_BeltAction, 0, 4);
            this.tableLayoutPanel9.Controls.Add(this.Btn_Beacon_Buzzer, 0, 3);
            this.tableLayoutPanel9.Controls.Add(this.Btn_Beacon_Lamp_Green, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.Btn_Beacon_Lamp_Yellow, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.Btn_Beacon_Lamp_Red, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 10;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(309, 381);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // Btn_BeltAction
            // 
            this.Btn_BeltAction.BackColor = System.Drawing.Color.Aqua;
            this.Btn_BeltAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_BeltAction.Location = new System.Drawing.Point(3, 163);
            this.Btn_BeltAction.Name = "Btn_BeltAction";
            this.Btn_BeltAction.Size = new System.Drawing.Size(303, 34);
            this.Btn_BeltAction.TabIndex = 4;
            this.Btn_BeltAction.Text = "Btn_BeltAction";
            this.Btn_BeltAction.UseVisualStyleBackColor = false;
            this.Btn_BeltAction.Click += new System.EventHandler(this.Btn_BeltAction_Click);
            // 
            // Btn_Beacon_Buzzer
            // 
            this.Btn_Beacon_Buzzer.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Beacon_Buzzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Beacon_Buzzer.Location = new System.Drawing.Point(3, 123);
            this.Btn_Beacon_Buzzer.Name = "Btn_Beacon_Buzzer";
            this.Btn_Beacon_Buzzer.Size = new System.Drawing.Size(303, 34);
            this.Btn_Beacon_Buzzer.TabIndex = 3;
            this.Btn_Beacon_Buzzer.Text = "Btn_Beacon_Buzzer";
            this.Btn_Beacon_Buzzer.UseVisualStyleBackColor = false;
            this.Btn_Beacon_Buzzer.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Beacon_Lamp_Green
            // 
            this.Btn_Beacon_Lamp_Green.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Beacon_Lamp_Green.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Beacon_Lamp_Green.Location = new System.Drawing.Point(3, 83);
            this.Btn_Beacon_Lamp_Green.Name = "Btn_Beacon_Lamp_Green";
            this.Btn_Beacon_Lamp_Green.Size = new System.Drawing.Size(303, 34);
            this.Btn_Beacon_Lamp_Green.TabIndex = 2;
            this.Btn_Beacon_Lamp_Green.Text = "Btn_Beacon_Lamp_Green";
            this.Btn_Beacon_Lamp_Green.UseVisualStyleBackColor = false;
            this.Btn_Beacon_Lamp_Green.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Beacon_Lamp_Yellow
            // 
            this.Btn_Beacon_Lamp_Yellow.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Beacon_Lamp_Yellow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Beacon_Lamp_Yellow.Location = new System.Drawing.Point(3, 43);
            this.Btn_Beacon_Lamp_Yellow.Name = "Btn_Beacon_Lamp_Yellow";
            this.Btn_Beacon_Lamp_Yellow.Size = new System.Drawing.Size(303, 34);
            this.Btn_Beacon_Lamp_Yellow.TabIndex = 1;
            this.Btn_Beacon_Lamp_Yellow.Text = "Btn_Beacon_Lamp_Yellow";
            this.Btn_Beacon_Lamp_Yellow.UseVisualStyleBackColor = false;
            this.Btn_Beacon_Lamp_Yellow.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Btn_Beacon_Lamp_Red
            // 
            this.Btn_Beacon_Lamp_Red.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Beacon_Lamp_Red.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Beacon_Lamp_Red.Location = new System.Drawing.Point(3, 3);
            this.Btn_Beacon_Lamp_Red.Name = "Btn_Beacon_Lamp_Red";
            this.Btn_Beacon_Lamp_Red.Size = new System.Drawing.Size(303, 34);
            this.Btn_Beacon_Lamp_Red.TabIndex = 0;
            this.Btn_Beacon_Lamp_Red.Text = "Btn_Beacon_Lamp_Red";
            this.Btn_Beacon_Lamp_Red.UseVisualStyleBackColor = false;
            this.Btn_Beacon_Lamp_Red.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // Tp_OtherDebug
            // 
            this.Tp_OtherDebug.Controls.Add(this.Tblp_OtherDebug);
            this.Tp_OtherDebug.Location = new System.Drawing.Point(4, 22);
            this.Tp_OtherDebug.Name = "Tp_OtherDebug";
            this.Tp_OtherDebug.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_OtherDebug.Size = new System.Drawing.Size(970, 565);
            this.Tp_OtherDebug.TabIndex = 6;
            this.Tp_OtherDebug.Text = "OtherDebug    ";
            this.Tp_OtherDebug.UseVisualStyleBackColor = true;
            // 
            // Tblp_OtherDebug
            // 
            this.Tblp_OtherDebug.ColumnCount = 1;
            this.Tblp_OtherDebug.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_OtherDebug.Controls.Add(this.Gb_CCDDebug, 0, 0);
            this.Tblp_OtherDebug.Controls.Add(this.Gb_SFCDebug, 0, 1);
            this.Tblp_OtherDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tblp_OtherDebug.Location = new System.Drawing.Point(3, 3);
            this.Tblp_OtherDebug.Name = "Tblp_OtherDebug";
            this.Tblp_OtherDebug.RowCount = 2;
            this.Tblp_OtherDebug.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_OtherDebug.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tblp_OtherDebug.Size = new System.Drawing.Size(964, 559);
            this.Tblp_OtherDebug.TabIndex = 0;
            // 
            // Gb_CCDDebug
            // 
            this.Gb_CCDDebug.Controls.Add(this.tableLayoutPanel10);
            this.Gb_CCDDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_CCDDebug.Location = new System.Drawing.Point(3, 3);
            this.Gb_CCDDebug.Name = "Gb_CCDDebug";
            this.Gb_CCDDebug.Size = new System.Drawing.Size(958, 273);
            this.Gb_CCDDebug.TabIndex = 0;
            this.Gb_CCDDebug.TabStop = false;
            this.Gb_CCDDebug.Text = "CCDDebug";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 5;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel10.Controls.Add(this.Btn_CCD3_SavePicture, 2, 5);
            this.tableLayoutPanel10.Controls.Add(this.Btn_CCD2_SavePicture, 2, 3);
            this.tableLayoutPanel10.Controls.Add(this.Btn_CCD3_ReadPicture, 1, 5);
            this.tableLayoutPanel10.Controls.Add(this.Btn_CCD2_ReadPicture, 1, 3);
            this.tableLayoutPanel10.Controls.Add(this.Btn_BarCode_Retail, 3, 3);
            this.tableLayoutPanel10.Controls.Add(this.Btn_Date_BOB, 4, 4);
            this.tableLayoutPanel10.Controls.Add(this.Btn_Price_BOB, 3, 4);
            this.tableLayoutPanel10.Controls.Add(this.Btn_Type_BOB, 4, 3);
            this.tableLayoutPanel10.Controls.Add(this.Btn_Color_Retail, 4, 2);
            this.tableLayoutPanel10.Controls.Add(this.Btn_Memory_Retail, 3, 2);
            this.tableLayoutPanel10.Controls.Add(this.Btn_Type_Retail, 4, 1);
            this.tableLayoutPanel10.Controls.Add(this.Btn_GLabel_Retail, 3, 1);
            this.tableLayoutPanel10.Controls.Add(this.Tb_CCD1_EXTime, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.Tb_CCD2_EXTime, 1, 2);
            this.tableLayoutPanel10.Controls.Add(this.Tb_CCD3_EXTime, 1, 4);
            this.tableLayoutPanel10.Controls.Add(this.Btn_CCD1_TakePicture, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.Btn_CCD2_TakePicture, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.Btn_CCD3_TakePicture, 0, 5);
            this.tableLayoutPanel10.Controls.Add(this.Label_CCD1_EXTime, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.Label_CCD2_EXTime, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.Label_CCD3_EXTime, 0, 4);
            this.tableLayoutPanel10.Controls.Add(this.Btn_Type_Front, 3, 0);
            this.tableLayoutPanel10.Controls.Add(this.Btn_Color_Front, 4, 0);
            this.tableLayoutPanel10.Controls.Add(this.Btn_CCD1_ReadPicture, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.Btn_CCD1_SavePicture, 2, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 6;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(952, 253);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // Btn_CCD3_SavePicture
            // 
            this.Btn_CCD3_SavePicture.BackColor = System.Drawing.Color.Gray;
            this.Btn_CCD3_SavePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CCD3_SavePicture.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_CCD3_SavePicture.Location = new System.Drawing.Point(383, 213);
            this.Btn_CCD3_SavePicture.Name = "Btn_CCD3_SavePicture";
            this.Btn_CCD3_SavePicture.Size = new System.Drawing.Size(184, 37);
            this.Btn_CCD3_SavePicture.TabIndex = 24;
            this.Btn_CCD3_SavePicture.Text = "Btn_CCD3_SavePicture";
            this.Btn_CCD3_SavePicture.UseVisualStyleBackColor = false;
            this.Btn_CCD3_SavePicture.Click += new System.EventHandler(this.Btn_CCD3_SavePicture_Click);
            // 
            // Btn_CCD2_SavePicture
            // 
            this.Btn_CCD2_SavePicture.BackColor = System.Drawing.Color.Gray;
            this.Btn_CCD2_SavePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CCD2_SavePicture.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_CCD2_SavePicture.Location = new System.Drawing.Point(383, 129);
            this.Btn_CCD2_SavePicture.Name = "Btn_CCD2_SavePicture";
            this.Btn_CCD2_SavePicture.Size = new System.Drawing.Size(184, 36);
            this.Btn_CCD2_SavePicture.TabIndex = 23;
            this.Btn_CCD2_SavePicture.Text = "Btn_CCD2_SavePicture";
            this.Btn_CCD2_SavePicture.UseVisualStyleBackColor = false;
            this.Btn_CCD2_SavePicture.Click += new System.EventHandler(this.Btn_CCD2_SavePicture_Click);
            // 
            // Btn_CCD3_ReadPicture
            // 
            this.Btn_CCD3_ReadPicture.BackColor = System.Drawing.Color.Gray;
            this.Btn_CCD3_ReadPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CCD3_ReadPicture.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_CCD3_ReadPicture.Location = new System.Drawing.Point(193, 213);
            this.Btn_CCD3_ReadPicture.Name = "Btn_CCD3_ReadPicture";
            this.Btn_CCD3_ReadPicture.Size = new System.Drawing.Size(184, 37);
            this.Btn_CCD3_ReadPicture.TabIndex = 21;
            this.Btn_CCD3_ReadPicture.Text = "Btn_CCD3_ReadPicture";
            this.Btn_CCD3_ReadPicture.UseVisualStyleBackColor = false;
            this.Btn_CCD3_ReadPicture.Click += new System.EventHandler(this.Btn_CCD3_ReadPicture_Click);
            // 
            // Btn_CCD2_ReadPicture
            // 
            this.Btn_CCD2_ReadPicture.BackColor = System.Drawing.Color.Gray;
            this.Btn_CCD2_ReadPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CCD2_ReadPicture.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_CCD2_ReadPicture.Location = new System.Drawing.Point(193, 129);
            this.Btn_CCD2_ReadPicture.Name = "Btn_CCD2_ReadPicture";
            this.Btn_CCD2_ReadPicture.Size = new System.Drawing.Size(184, 36);
            this.Btn_CCD2_ReadPicture.TabIndex = 20;
            this.Btn_CCD2_ReadPicture.Text = "Btn_CCD2_ReadPicture";
            this.Btn_CCD2_ReadPicture.UseVisualStyleBackColor = false;
            this.Btn_CCD2_ReadPicture.Click += new System.EventHandler(this.Btn_CCD2_ReadPicture_Click);
            // 
            // Btn_BarCode_Retail
            // 
            this.Btn_BarCode_Retail.BackColor = System.Drawing.Color.Gray;
            this.Btn_BarCode_Retail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_BarCode_Retail.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_BarCode_Retail.Location = new System.Drawing.Point(573, 129);
            this.Btn_BarCode_Retail.Name = "Btn_BarCode_Retail";
            this.Btn_BarCode_Retail.Size = new System.Drawing.Size(184, 36);
            this.Btn_BarCode_Retail.TabIndex = 15;
            this.Btn_BarCode_Retail.Text = "Btn_BarCode_Retail";
            this.Btn_BarCode_Retail.UseVisualStyleBackColor = false;
            this.Btn_BarCode_Retail.Click += new System.EventHandler(this.Btn_BarCode_Retail_Click);
            // 
            // Btn_Date_BOB
            // 
            this.Btn_Date_BOB.BackColor = System.Drawing.Color.Gray;
            this.Btn_Date_BOB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Date_BOB.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_Date_BOB.Location = new System.Drawing.Point(763, 171);
            this.Btn_Date_BOB.Name = "Btn_Date_BOB";
            this.Btn_Date_BOB.Size = new System.Drawing.Size(186, 36);
            this.Btn_Date_BOB.TabIndex = 18;
            this.Btn_Date_BOB.Text = "Btn_Date_BOB";
            this.Btn_Date_BOB.UseVisualStyleBackColor = false;
            this.Btn_Date_BOB.Click += new System.EventHandler(this.Btn_Date_BOB_Click);
            // 
            // Btn_Price_BOB
            // 
            this.Btn_Price_BOB.BackColor = System.Drawing.Color.Gray;
            this.Btn_Price_BOB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Price_BOB.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_Price_BOB.Location = new System.Drawing.Point(573, 171);
            this.Btn_Price_BOB.Name = "Btn_Price_BOB";
            this.Btn_Price_BOB.Size = new System.Drawing.Size(184, 36);
            this.Btn_Price_BOB.TabIndex = 17;
            this.Btn_Price_BOB.Text = "Btn_Price_BOB";
            this.Btn_Price_BOB.UseVisualStyleBackColor = false;
            this.Btn_Price_BOB.Click += new System.EventHandler(this.Btn_Price_BOB_Click);
            // 
            // Btn_Type_BOB
            // 
            this.Btn_Type_BOB.BackColor = System.Drawing.Color.Gray;
            this.Btn_Type_BOB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Type_BOB.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_Type_BOB.Location = new System.Drawing.Point(763, 129);
            this.Btn_Type_BOB.Name = "Btn_Type_BOB";
            this.Btn_Type_BOB.Size = new System.Drawing.Size(186, 36);
            this.Btn_Type_BOB.TabIndex = 16;
            this.Btn_Type_BOB.Text = "Btn_Type_BOB";
            this.Btn_Type_BOB.UseVisualStyleBackColor = false;
            this.Btn_Type_BOB.Click += new System.EventHandler(this.Btn_Type_BOB_Click);
            // 
            // Btn_Color_Retail
            // 
            this.Btn_Color_Retail.BackColor = System.Drawing.Color.Gray;
            this.Btn_Color_Retail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Color_Retail.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_Color_Retail.Location = new System.Drawing.Point(763, 87);
            this.Btn_Color_Retail.Name = "Btn_Color_Retail";
            this.Btn_Color_Retail.Size = new System.Drawing.Size(186, 36);
            this.Btn_Color_Retail.TabIndex = 14;
            this.Btn_Color_Retail.Text = "Btn_Color_Retail";
            this.Btn_Color_Retail.UseVisualStyleBackColor = false;
            this.Btn_Color_Retail.Click += new System.EventHandler(this.Btn_Color_Retail_Click);
            // 
            // Btn_Memory_Retail
            // 
            this.Btn_Memory_Retail.BackColor = System.Drawing.Color.Gray;
            this.Btn_Memory_Retail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Memory_Retail.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_Memory_Retail.Location = new System.Drawing.Point(573, 87);
            this.Btn_Memory_Retail.Name = "Btn_Memory_Retail";
            this.Btn_Memory_Retail.Size = new System.Drawing.Size(184, 36);
            this.Btn_Memory_Retail.TabIndex = 13;
            this.Btn_Memory_Retail.Text = "Btn_Memory_Retail";
            this.Btn_Memory_Retail.UseVisualStyleBackColor = false;
            this.Btn_Memory_Retail.Click += new System.EventHandler(this.Btn_Memory_Retail_Click);
            // 
            // Btn_Type_Retail
            // 
            this.Btn_Type_Retail.BackColor = System.Drawing.Color.Gray;
            this.Btn_Type_Retail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Type_Retail.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_Type_Retail.Location = new System.Drawing.Point(763, 45);
            this.Btn_Type_Retail.Name = "Btn_Type_Retail";
            this.Btn_Type_Retail.Size = new System.Drawing.Size(186, 36);
            this.Btn_Type_Retail.TabIndex = 12;
            this.Btn_Type_Retail.Text = "Btn_Type_Retail";
            this.Btn_Type_Retail.UseVisualStyleBackColor = false;
            this.Btn_Type_Retail.Click += new System.EventHandler(this.Btn_Type_Retail_Click);
            // 
            // Btn_GLabel_Retail
            // 
            this.Btn_GLabel_Retail.BackColor = System.Drawing.Color.Gray;
            this.Btn_GLabel_Retail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_GLabel_Retail.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_GLabel_Retail.Location = new System.Drawing.Point(573, 45);
            this.Btn_GLabel_Retail.Name = "Btn_GLabel_Retail";
            this.Btn_GLabel_Retail.Size = new System.Drawing.Size(184, 36);
            this.Btn_GLabel_Retail.TabIndex = 11;
            this.Btn_GLabel_Retail.Text = "Btn_GLabel_Retail";
            this.Btn_GLabel_Retail.UseVisualStyleBackColor = false;
            this.Btn_GLabel_Retail.Click += new System.EventHandler(this.Btn_GLabel_Retail_Click);
            // 
            // Tb_CCD1_EXTime
            // 
            this.Tb_CCD1_EXTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_CCD1_EXTime.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel10.SetColumnSpan(this.Tb_CCD1_EXTime, 2);
            this.Tb_CCD1_EXTime.Location = new System.Drawing.Point(193, 10);
            this.Tb_CCD1_EXTime.MaxLength = 4;
            this.Tb_CCD1_EXTime.Name = "Tb_CCD1_EXTime";
            this.Tb_CCD1_EXTime.Size = new System.Drawing.Size(374, 21);
            this.Tb_CCD1_EXTime.TabIndex = 3;
            this.Tb_CCD1_EXTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EXTime_KeyPress);
            // 
            // Tb_CCD2_EXTime
            // 
            this.Tb_CCD2_EXTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_CCD2_EXTime.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel10.SetColumnSpan(this.Tb_CCD2_EXTime, 2);
            this.Tb_CCD2_EXTime.Location = new System.Drawing.Point(193, 94);
            this.Tb_CCD2_EXTime.MaxLength = 4;
            this.Tb_CCD2_EXTime.Name = "Tb_CCD2_EXTime";
            this.Tb_CCD2_EXTime.Size = new System.Drawing.Size(374, 21);
            this.Tb_CCD2_EXTime.TabIndex = 4;
            this.Tb_CCD2_EXTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EXTime_KeyPress);
            // 
            // Tb_CCD3_EXTime
            // 
            this.Tb_CCD3_EXTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_CCD3_EXTime.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel10.SetColumnSpan(this.Tb_CCD3_EXTime, 2);
            this.Tb_CCD3_EXTime.Location = new System.Drawing.Point(193, 178);
            this.Tb_CCD3_EXTime.MaxLength = 4;
            this.Tb_CCD3_EXTime.Name = "Tb_CCD3_EXTime";
            this.Tb_CCD3_EXTime.Size = new System.Drawing.Size(374, 21);
            this.Tb_CCD3_EXTime.TabIndex = 5;
            this.Tb_CCD3_EXTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EXTime_KeyPress);
            // 
            // Btn_CCD1_TakePicture
            // 
            this.Btn_CCD1_TakePicture.BackColor = System.Drawing.Color.Gray;
            this.Btn_CCD1_TakePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CCD1_TakePicture.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_CCD1_TakePicture.Location = new System.Drawing.Point(3, 45);
            this.Btn_CCD1_TakePicture.Name = "Btn_CCD1_TakePicture";
            this.Btn_CCD1_TakePicture.Size = new System.Drawing.Size(184, 36);
            this.Btn_CCD1_TakePicture.TabIndex = 0;
            this.Btn_CCD1_TakePicture.Text = "Btn_CCD1_TakePicture";
            this.Btn_CCD1_TakePicture.UseVisualStyleBackColor = false;
            this.Btn_CCD1_TakePicture.Click += new System.EventHandler(this.Btn_CCD1_TakePicture_Click);
            // 
            // Btn_CCD2_TakePicture
            // 
            this.Btn_CCD2_TakePicture.BackColor = System.Drawing.Color.Gray;
            this.Btn_CCD2_TakePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CCD2_TakePicture.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_CCD2_TakePicture.Location = new System.Drawing.Point(3, 129);
            this.Btn_CCD2_TakePicture.Name = "Btn_CCD2_TakePicture";
            this.Btn_CCD2_TakePicture.Size = new System.Drawing.Size(184, 36);
            this.Btn_CCD2_TakePicture.TabIndex = 1;
            this.Btn_CCD2_TakePicture.Text = "Btn_CCD2_TakePicture";
            this.Btn_CCD2_TakePicture.UseVisualStyleBackColor = false;
            this.Btn_CCD2_TakePicture.Click += new System.EventHandler(this.Btn_CCD2_TakePicture_Click);
            // 
            // Btn_CCD3_TakePicture
            // 
            this.Btn_CCD3_TakePicture.BackColor = System.Drawing.Color.Gray;
            this.Btn_CCD3_TakePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CCD3_TakePicture.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_CCD3_TakePicture.Location = new System.Drawing.Point(3, 213);
            this.Btn_CCD3_TakePicture.Name = "Btn_CCD3_TakePicture";
            this.Btn_CCD3_TakePicture.Size = new System.Drawing.Size(184, 37);
            this.Btn_CCD3_TakePicture.TabIndex = 2;
            this.Btn_CCD3_TakePicture.Text = "Btn_CCD3_TakePicture";
            this.Btn_CCD3_TakePicture.UseVisualStyleBackColor = false;
            this.Btn_CCD3_TakePicture.Click += new System.EventHandler(this.Btn_CCD3_TakePicture_Click);
            // 
            // Label_CCD1_EXTime
            // 
            this.Label_CCD1_EXTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_CCD1_EXTime.AutoSize = true;
            this.Label_CCD1_EXTime.Location = new System.Drawing.Point(3, 15);
            this.Label_CCD1_EXTime.Name = "Label_CCD1_EXTime";
            this.Label_CCD1_EXTime.Size = new System.Drawing.Size(184, 12);
            this.Label_CCD1_EXTime.TabIndex = 6;
            this.Label_CCD1_EXTime.Text = "CCD1_EXTime";
            // 
            // Label_CCD2_EXTime
            // 
            this.Label_CCD2_EXTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_CCD2_EXTime.AutoSize = true;
            this.Label_CCD2_EXTime.Location = new System.Drawing.Point(3, 99);
            this.Label_CCD2_EXTime.Name = "Label_CCD2_EXTime";
            this.Label_CCD2_EXTime.Size = new System.Drawing.Size(184, 12);
            this.Label_CCD2_EXTime.TabIndex = 7;
            this.Label_CCD2_EXTime.Text = "CCD2_EXTime";
            // 
            // Label_CCD3_EXTime
            // 
            this.Label_CCD3_EXTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_CCD3_EXTime.AutoSize = true;
            this.Label_CCD3_EXTime.Location = new System.Drawing.Point(3, 183);
            this.Label_CCD3_EXTime.Name = "Label_CCD3_EXTime";
            this.Label_CCD3_EXTime.Size = new System.Drawing.Size(184, 12);
            this.Label_CCD3_EXTime.TabIndex = 8;
            this.Label_CCD3_EXTime.Text = "CCD3_EXTime";
            // 
            // Btn_Type_Front
            // 
            this.Btn_Type_Front.BackColor = System.Drawing.Color.Gray;
            this.Btn_Type_Front.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Type_Front.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_Type_Front.Location = new System.Drawing.Point(573, 3);
            this.Btn_Type_Front.Name = "Btn_Type_Front";
            this.Btn_Type_Front.Size = new System.Drawing.Size(184, 36);
            this.Btn_Type_Front.TabIndex = 9;
            this.Btn_Type_Front.Text = "Btn_Type_Front";
            this.Btn_Type_Front.UseVisualStyleBackColor = false;
            this.Btn_Type_Front.Click += new System.EventHandler(this.Btn_Type_Front_Click);
            // 
            // Btn_Color_Front
            // 
            this.Btn_Color_Front.BackColor = System.Drawing.Color.Gray;
            this.Btn_Color_Front.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Color_Front.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_Color_Front.Location = new System.Drawing.Point(763, 3);
            this.Btn_Color_Front.Name = "Btn_Color_Front";
            this.Btn_Color_Front.Size = new System.Drawing.Size(186, 36);
            this.Btn_Color_Front.TabIndex = 10;
            this.Btn_Color_Front.Text = "Btn_Color_Front";
            this.Btn_Color_Front.UseVisualStyleBackColor = false;
            this.Btn_Color_Front.Click += new System.EventHandler(this.Btn_Color_Front_Click);
            // 
            // Btn_CCD1_ReadPicture
            // 
            this.Btn_CCD1_ReadPicture.BackColor = System.Drawing.Color.Gray;
            this.Btn_CCD1_ReadPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CCD1_ReadPicture.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_CCD1_ReadPicture.Location = new System.Drawing.Point(193, 45);
            this.Btn_CCD1_ReadPicture.Name = "Btn_CCD1_ReadPicture";
            this.Btn_CCD1_ReadPicture.Size = new System.Drawing.Size(184, 36);
            this.Btn_CCD1_ReadPicture.TabIndex = 19;
            this.Btn_CCD1_ReadPicture.Text = "Btn_CCD1_ReadPicture";
            this.Btn_CCD1_ReadPicture.UseVisualStyleBackColor = false;
            this.Btn_CCD1_ReadPicture.Click += new System.EventHandler(this.Btn_CCD1_ReadPicture_Click);
            // 
            // Btn_CCD1_SavePicture
            // 
            this.Btn_CCD1_SavePicture.BackColor = System.Drawing.Color.Gray;
            this.Btn_CCD1_SavePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CCD1_SavePicture.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_CCD1_SavePicture.Location = new System.Drawing.Point(383, 45);
            this.Btn_CCD1_SavePicture.Name = "Btn_CCD1_SavePicture";
            this.Btn_CCD1_SavePicture.Size = new System.Drawing.Size(184, 36);
            this.Btn_CCD1_SavePicture.TabIndex = 22;
            this.Btn_CCD1_SavePicture.Text = "Btn_CCD1_SavePicture";
            this.Btn_CCD1_SavePicture.UseVisualStyleBackColor = false;
            this.Btn_CCD1_SavePicture.Click += new System.EventHandler(this.Btn_CCD1_SavePicture_Click);
            // 
            // Gb_SFCDebug
            // 
            this.Gb_SFCDebug.Controls.Add(this.tableLayoutPanel11);
            this.Gb_SFCDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_SFCDebug.Location = new System.Drawing.Point(3, 282);
            this.Gb_SFCDebug.Name = "Gb_SFCDebug";
            this.Gb_SFCDebug.Size = new System.Drawing.Size(958, 274);
            this.Gb_SFCDebug.TabIndex = 1;
            this.Gb_SFCDebug.TabStop = false;
            this.Gb_SFCDebug.Text = "SFCDebug";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 3;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.92878F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.07122F));
            this.tableLayoutPanel11.Controls.Add(this.Tb_Weight, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.Rtb_GetData, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel12, 2, 0);
            this.tableLayoutPanel11.Controls.Add(this.Tb_DSN, 0, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(952, 254);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // Tb_Weight
            // 
            this.Tb_Weight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_Weight.BackColor = System.Drawing.SystemColors.Info;
            this.Tb_Weight.Location = new System.Drawing.Point(626, 225);
            this.Tb_Weight.Name = "Tb_Weight";
            this.Tb_Weight.Size = new System.Drawing.Size(114, 21);
            this.Tb_Weight.TabIndex = 3;
            this.Tb_Weight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_Weight_KeyPress);
            // 
            // Rtb_GetData
            // 
            this.Rtb_GetData.BackColor = System.Drawing.SystemColors.Info;
            this.Rtb_GetData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel11.SetColumnSpan(this.Rtb_GetData, 2);
            this.Rtb_GetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rtb_GetData.Location = new System.Drawing.Point(3, 3);
            this.Rtb_GetData.Name = "Rtb_GetData";
            this.Rtb_GetData.ReadOnly = true;
            this.Rtb_GetData.Size = new System.Drawing.Size(737, 211);
            this.Rtb_GetData.TabIndex = 0;
            this.Rtb_GetData.Text = "";
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.Btn_UpLoadPass, 0, 4);
            this.tableLayoutPanel12.Controls.Add(this.Btn_GetClosure, 0, 3);
            this.tableLayoutPanel12.Controls.Add(this.Btn_GetBOBData, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.Btn_GetRetailData, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.Btn_CheckPath, 0, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(746, 3);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 5;
            this.tableLayoutPanel11.SetRowSpan(this.tableLayoutPanel12, 2);
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(203, 248);
            this.tableLayoutPanel12.TabIndex = 1;
            // 
            // Btn_UpLoadPass
            // 
            this.Btn_UpLoadPass.BackColor = System.Drawing.SystemColors.GrayText;
            this.Btn_UpLoadPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_UpLoadPass.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_UpLoadPass.Location = new System.Drawing.Point(3, 199);
            this.Btn_UpLoadPass.Name = "Btn_UpLoadPass";
            this.Btn_UpLoadPass.Size = new System.Drawing.Size(197, 46);
            this.Btn_UpLoadPass.TabIndex = 4;
            this.Btn_UpLoadPass.Text = "Btn_UpLoadPass";
            this.Btn_UpLoadPass.UseVisualStyleBackColor = false;
            this.Btn_UpLoadPass.Visible = false;
            this.Btn_UpLoadPass.Click += new System.EventHandler(this.Btn_UpLoadPass_Click);
            // 
            // Btn_GetClosure
            // 
            this.Btn_GetClosure.BackColor = System.Drawing.SystemColors.GrayText;
            this.Btn_GetClosure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_GetClosure.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_GetClosure.Location = new System.Drawing.Point(3, 150);
            this.Btn_GetClosure.Name = "Btn_GetClosure";
            this.Btn_GetClosure.Size = new System.Drawing.Size(197, 43);
            this.Btn_GetClosure.TabIndex = 3;
            this.Btn_GetClosure.Text = "Btn_GetClosure";
            this.Btn_GetClosure.UseVisualStyleBackColor = false;
            this.Btn_GetClosure.Click += new System.EventHandler(this.Btn_GetClosure_Click);
            // 
            // Btn_GetBOBData
            // 
            this.Btn_GetBOBData.BackColor = System.Drawing.SystemColors.GrayText;
            this.Btn_GetBOBData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_GetBOBData.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_GetBOBData.Location = new System.Drawing.Point(3, 101);
            this.Btn_GetBOBData.Name = "Btn_GetBOBData";
            this.Btn_GetBOBData.Size = new System.Drawing.Size(197, 43);
            this.Btn_GetBOBData.TabIndex = 2;
            this.Btn_GetBOBData.Text = "Btn_GetBOBData";
            this.Btn_GetBOBData.UseVisualStyleBackColor = false;
            this.Btn_GetBOBData.Click += new System.EventHandler(this.Btn_GetBOBData_Click);
            // 
            // Btn_GetRetailData
            // 
            this.Btn_GetRetailData.BackColor = System.Drawing.SystemColors.GrayText;
            this.Btn_GetRetailData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_GetRetailData.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_GetRetailData.Location = new System.Drawing.Point(3, 52);
            this.Btn_GetRetailData.Name = "Btn_GetRetailData";
            this.Btn_GetRetailData.Size = new System.Drawing.Size(197, 43);
            this.Btn_GetRetailData.TabIndex = 1;
            this.Btn_GetRetailData.Text = "Btn_GetRetailData";
            this.Btn_GetRetailData.UseVisualStyleBackColor = false;
            this.Btn_GetRetailData.Click += new System.EventHandler(this.Btn_GetRetailData_Click);
            // 
            // Btn_CheckPath
            // 
            this.Btn_CheckPath.BackColor = System.Drawing.SystemColors.GrayText;
            this.Btn_CheckPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_CheckPath.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_CheckPath.Location = new System.Drawing.Point(3, 3);
            this.Btn_CheckPath.Name = "Btn_CheckPath";
            this.Btn_CheckPath.Size = new System.Drawing.Size(197, 43);
            this.Btn_CheckPath.TabIndex = 0;
            this.Btn_CheckPath.Text = "Btn_CheckPath";
            this.Btn_CheckPath.UseVisualStyleBackColor = false;
            this.Btn_CheckPath.Click += new System.EventHandler(this.Btn_CheckPath_Click);
            // 
            // Tb_DSN
            // 
            this.Tb_DSN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_DSN.BackColor = System.Drawing.SystemColors.Info;
            this.Tb_DSN.Location = new System.Drawing.Point(3, 225);
            this.Tb_DSN.Name = "Tb_DSN";
            this.Tb_DSN.Size = new System.Drawing.Size(617, 21);
            this.Tb_DSN.TabIndex = 2;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 6;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Controls.Add(this.Btn_UserManagement, 5, 0);
            this.tableLayoutPanel16.Controls.Add(this.Status_Level_03, 4, 0);
            this.tableLayoutPanel16.Controls.Add(this.Status_Level_02, 3, 0);
            this.tableLayoutPanel16.Controls.Add(this.Label_AccessLevel, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.Btn_UserAccess, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.Status_Level_01, 2, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(978, 34);
            this.tableLayoutPanel16.TabIndex = 2;
            // 
            // Btn_UserManagement
            // 
            this.Btn_UserManagement.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_UserManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_UserManagement.ForeColor = System.Drawing.SystemColors.Info;
            this.Btn_UserManagement.Location = new System.Drawing.Point(853, 3);
            this.Btn_UserManagement.Name = "Btn_UserManagement";
            this.Btn_UserManagement.Size = new System.Drawing.Size(122, 28);
            this.Btn_UserManagement.TabIndex = 5;
            this.Btn_UserManagement.Text = "User Management";
            this.Btn_UserManagement.UseVisualStyleBackColor = false;
            this.Btn_UserManagement.Visible = false;
            this.Btn_UserManagement.Click += new System.EventHandler(this.Btn_UserManagement_Click);
            // 
            // Status_Level_03
            // 
            this.Status_Level_03.BackColor = System.Drawing.Color.Red;
            this.Status_Level_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Status_Level_03.ForeColor = System.Drawing.Color.White;
            this.Status_Level_03.Location = new System.Drawing.Point(653, 3);
            this.Status_Level_03.Name = "Status_Level_03";
            this.Status_Level_03.Size = new System.Drawing.Size(194, 28);
            this.Status_Level_03.TabIndex = 4;
            this.Status_Level_03.TabStop = false;
            this.Status_Level_03.Text = "CCDConfig";
            this.Status_Level_03.UseVisualStyleBackColor = false;
            // 
            // Status_Level_02
            // 
            this.Status_Level_02.BackColor = System.Drawing.Color.Red;
            this.Status_Level_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Status_Level_02.ForeColor = System.Drawing.Color.White;
            this.Status_Level_02.Location = new System.Drawing.Point(453, 3);
            this.Status_Level_02.Name = "Status_Level_02";
            this.Status_Level_02.Size = new System.Drawing.Size(194, 28);
            this.Status_Level_02.TabIndex = 3;
            this.Status_Level_02.TabStop = false;
            this.Status_Level_02.Text = "IOConfig";
            this.Status_Level_02.UseVisualStyleBackColor = false;
            // 
            // Label_AccessLevel
            // 
            this.Label_AccessLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_AccessLevel.AutoSize = true;
            this.Label_AccessLevel.Location = new System.Drawing.Point(3, 11);
            this.Label_AccessLevel.Name = "Label_AccessLevel";
            this.Label_AccessLevel.Size = new System.Drawing.Size(84, 12);
            this.Label_AccessLevel.TabIndex = 0;
            this.Label_AccessLevel.Text = "Access Level:";
            // 
            // Btn_UserAccess
            // 
            this.Btn_UserAccess.BackColor = System.Drawing.Color.White;
            this.Btn_UserAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_UserAccess.Location = new System.Drawing.Point(93, 3);
            this.Btn_UserAccess.Name = "Btn_UserAccess";
            this.Btn_UserAccess.Size = new System.Drawing.Size(154, 28);
            this.Btn_UserAccess.TabIndex = 1;
            this.Btn_UserAccess.Text = "Administrator";
            this.Btn_UserAccess.UseVisualStyleBackColor = false;
            this.Btn_UserAccess.Click += new System.EventHandler(this.Btn_UserAccess_Click);
            // 
            // Status_Level_01
            // 
            this.Status_Level_01.BackColor = System.Drawing.Color.Red;
            this.Status_Level_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Status_Level_01.ForeColor = System.Drawing.Color.White;
            this.Status_Level_01.Location = new System.Drawing.Point(253, 3);
            this.Status_Level_01.Name = "Status_Level_01";
            this.Status_Level_01.Size = new System.Drawing.Size(194, 28);
            this.Status_Level_01.TabIndex = 2;
            this.Status_Level_01.TabStop = false;
            this.Status_Level_01.Text = "MachineConfig";
            this.Status_Level_01.UseVisualStyleBackColor = false;
            // 
            // timer_IOFalsh
            // 
            this.timer_IOFalsh.Tick += new System.EventHandler(this.timer_IOFalsh_Tick);
            // 
            // timer_CylinderFalsh
            // 
            this.timer_CylinderFalsh.Tick += new System.EventHandler(this.timer_CylinderFalsh_Tick);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 682);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1000, 721);
            this.MinimumSize = new System.Drawing.Size(1000, 721);
            this.Name = "FormSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting&Debug";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSetting_FormClosing);
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSetting_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Tc_Setting.ResumeLayout(false);
            this.Tp_MachineConfig.ResumeLayout(false);
            this.Tblp_MachineConfig.ResumeLayout(false);
            this.Gb_MachineConfig.ResumeLayout(false);
            this.Gb_CCDConfig.ResumeLayout(false);
            this.Tp_SerialConfig.ResumeLayout(false);
            this.Tblp_SerialConfig.ResumeLayout(false);
            this.Gb_ScannerConfig.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.Gb_ScalesConfig.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.Tp_OptLightConfig.ResumeLayout(false);
            this.Tblp_OptLightConfig.ResumeLayout(false);
            this.Gb_OptLightConfig.ResumeLayout(false);
            this.Gb_OptLightController.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.Tp_IODebug.ResumeLayout(false);
            this.Tblp_IODebug.ResumeLayout(false);
            this.Gb_Output.ResumeLayout(false);
            this.Tblp_Output.ResumeLayout(false);
            this.Gb_Input.ResumeLayout(false);
            this.Tblp_Input.ResumeLayout(false);
            this.Tp_CylinderDebug.ResumeLayout(false);
            this.Tblp_CylinderDebug.ResumeLayout(false);
            this.Gb_Output_D03.ResumeLayout(false);
            this.Tblp_Output_D03.ResumeLayout(false);
            this.Gb_Output_D02.ResumeLayout(false);
            this.Tblp_Output_D02.ResumeLayout(false);
            this.Gb_Output_D01.ResumeLayout(false);
            this.Tblp_Output_D01.ResumeLayout(false);
            this.Tp_StepDebug.ResumeLayout(false);
            this.Tblp_StepDebug.ResumeLayout(false);
            this.Gb_Step_D02.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.Gb_Step_D03.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.Gb_Step_D01.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.Gb_Step_Belt.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.Gb_Step_Beacon.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.Tp_OtherDebug.ResumeLayout(false);
            this.Tblp_OtherDebug.ResumeLayout(false);
            this.Gb_CCDDebug.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.Gb_SFCDebug.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Btn_SaveConfig;
        private System.Windows.Forms.TabControl Tc_Setting;
        private System.Windows.Forms.TabPage Tp_MachineConfig;
        private System.Windows.Forms.TabPage Tp_SerialConfig;
        private System.Windows.Forms.TabPage Tp_OptLightConfig;
        private System.Windows.Forms.TabPage Tp_IODebug;
        private System.Windows.Forms.TabPage Tp_CylinderDebug;
        private System.Windows.Forms.TableLayoutPanel Tblp_MachineConfig;
        private System.Windows.Forms.GroupBox Gb_MachineConfig;
        private System.Windows.Forms.PropertyGrid Ppg_MachineConfig;
        private System.Windows.Forms.GroupBox Gb_CCDConfig;
        private System.Windows.Forms.PropertyGrid Ppg_CCDConfig;
        private System.Windows.Forms.TableLayoutPanel Tblp_SerialConfig;
        private System.Windows.Forms.GroupBox Gb_ScannerConfig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button Btn_GetScannerResult;
        private System.Windows.Forms.PropertyGrid Ppg_ScannerConfig;
        private System.Windows.Forms.Button Btn_ScannerOpen;
        private System.Windows.Forms.TextBox Tb_ScannerResult;
        private System.Windows.Forms.GroupBox Gb_ScalesConfig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button Btn_GetScalesResult;
        private System.Windows.Forms.PropertyGrid Ppg_ScalesConfig;
        private System.Windows.Forms.Button Btn_ScalesOpen;
        private System.Windows.Forms.TextBox Tb_ScalesResult;
        private System.Windows.Forms.TableLayoutPanel Tblp_OptLightConfig;
        private System.Windows.Forms.GroupBox Gb_OptLightConfig;
        private System.Windows.Forms.PropertyGrid Ppg_OptLightConfig;
        private System.Windows.Forms.GroupBox Gb_OptLightController;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private OptLightController.OptLightController OptLightController;
        private System.Windows.Forms.Button Btn_OptLightClose;
        private System.Windows.Forms.TableLayoutPanel Tblp_IODebug;
        private System.Windows.Forms.GroupBox Gb_Output;
        private System.Windows.Forms.TableLayoutPanel Tblp_Output;
        private HelperCmd.Output Station_GetReady_Output;
        private HelperCmd.Output Station_GetReady_Input;
        private HelperCmd.Output Beacon_Lamp_Red;
        private HelperCmd.Output Station_LabelType;
        private HelperCmd.Output Beacon_Lamp_Yellow;
        private HelperCmd.Output Station_NotPaste;
        private HelperCmd.Output Beacon_Lamp_Green;
        private HelperCmd.Output Beacon_Buzzer;
        private HelperCmd.Output Belt_D02_Run;
        private HelperCmd.Output Belt_D01_Run;
        private HelperCmd.Output Belt_D03_Run;
        private HelperCmd.Output Station_SKUChange;
        private HelperCmd.Output Belt_D03_Direction;
        private HelperCmd.Output Belt_D03_Enable;
        private HelperCmd.Output Belt_D02_Direction;
        private HelperCmd.Output Belt_D01_Direction;
        private HelperCmd.Output Belt_D02_Enable;
        private HelperCmd.Output Belt_D01_Enable;
        private System.Windows.Forms.GroupBox Gb_Input;
        private System.Windows.Forms.TableLayoutPanel Tblp_Input;
        private HelperCmd.Input Signal_SafeGuard;
        private HelperCmd.Input Signal_NG_Second;
        private HelperCmd.Input Signal_Run;
        private HelperCmd.Input Signal_NG_First;
        private HelperCmd.Input Belt_D02_Alarm;
        private HelperCmd.Input Signal_D01_Enter;
        private HelperCmd.Input Signal_D02_Enter;
        private HelperCmd.Input Signal_EMG;
        private HelperCmd.Input Signal_Reset;
        private HelperCmd.Input Signal_D03_Enter;
        private HelperCmd.Input Station_Next_Ready;
        private HelperCmd.Input Belt_D03_Alarm;
        private HelperCmd.Input Belt_D01_Alarm;
        private HelperCmd.Input Station_Next_GetBox;
        private System.Windows.Forms.TableLayoutPanel Tblp_CylinderDebug;
        private System.Windows.Forms.GroupBox Gb_Output_D02;
        private System.Windows.Forms.GroupBox Gb_Output_D01;
        private System.Windows.Forms.GroupBox Gb_Output_D03;
        private System.Windows.Forms.TableLayoutPanel Tblp_Output_D03;
        private HelperCmd.Output Cyl_D03Carry;
        private HelperCmd.Output Cyl_D03Lifter;
        private HelperCmd.Output Cyl_D03Forward;
        private HelperCmd.Output Cyl_D03Rotate;
        private HelperCmd.Input Cyl_D03Clamp_Org;
        private HelperCmd.Input Cyl_D03Clamp_On;
        private HelperCmd.Input Cyl_D03Rotate_Org;
        private HelperCmd.Input Cyl_D03Rotate_On;
        private HelperCmd.Input Cyl_D03Forward_Org;
        private HelperCmd.Input Cyl_D03Forward_On;
        private HelperCmd.Input Cyl_D03Lifter_Org;
        private HelperCmd.Input Cyl_D03Lifter_On;
        private HelperCmd.Input Cyl_D03Carry_Org;
        private HelperCmd.Input Cyl_D03Carry_On;
        private HelperCmd.Input Cyl_D03Adjust_Right_Org;
        private HelperCmd.Input Cyl_D03Adjust_Left_Org;
        private HelperCmd.Input Cyl_D03Adjust_Left_On;
        private HelperCmd.Input Cyl_D03Adjust_Right_On;
        private HelperCmd.Output Cyl_D03Clamp;
        private HelperCmd.Output Cyl_D03Adjust;
        private System.Windows.Forms.TableLayoutPanel Tblp_Output_D02;
        private HelperCmd.Input Cyl_D02Weigh_On;
        private HelperCmd.Input Cyl_D02Intercept_On;
        private HelperCmd.Input Cyl_D02Weigh_Org;
        private HelperCmd.Input Cyl_D02Intercept_Org;
        private HelperCmd.Output Cyl_D02Intercept;
        private HelperCmd.Output Cyl_D02Weigh;
        private System.Windows.Forms.TableLayoutPanel Tblp_Output_D01;
        private HelperCmd.Input Cyl_D01Intercept_On;
        private HelperCmd.Output Cyl_D01Intercept;
        private HelperCmd.Input Cyl_D01Intercept_Org;
        private System.Windows.Forms.TabPage Tp_StepDebug;
        private System.Windows.Forms.TabPage Tp_OtherDebug;
        private System.Windows.Forms.TableLayoutPanel Tblp_StepDebug;
        private System.Windows.Forms.GroupBox Gb_Step_D03;
        private System.Windows.Forms.GroupBox Gb_Step_D01;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.Label Label_AccessLevel;
        private System.Windows.Forms.Button Btn_UserAccess;
        private System.Windows.Forms.Button Btn_UserManagement;
        private System.Windows.Forms.Button Status_Level_03;
        private System.Windows.Forms.Button Status_Level_02;
        private System.Windows.Forms.Button Status_Level_01;
        private System.Windows.Forms.Timer timer_IOFalsh;
        private System.Windows.Forms.Timer timer_CylinderFalsh;
        private System.Windows.Forms.Button Btn_ScannerClose;
        private System.Windows.Forms.Button Btn_ScalesClose;
        private System.Windows.Forms.Button Btn_OptLightOpen;
        private System.Windows.Forms.TableLayoutPanel Tblp_OtherDebug;
        private System.Windows.Forms.GroupBox Gb_Step_D02;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button Btn_Cyl_D02Intercept;
        private System.Windows.Forms.Button Btn_Cyl_D02Weigh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Btn_Cyl_D01Intercept;
        private System.Windows.Forms.Button Btn_Station_GetReady_Input;
        private System.Windows.Forms.Button Btn_PassAction;
        private System.Windows.Forms.Button Btn_NGAction;
        private System.Windows.Forms.Button Btn_Station_SKUChange;
        private System.Windows.Forms.Button Btn_Station_LabelType;
        private System.Windows.Forms.Button Btn_Station_NotPaste;
        private System.Windows.Forms.Button Btn_Station_GetReady_Output;
        private System.Windows.Forms.Button Btn_Cyl_D03Carry;
        private System.Windows.Forms.Button Btn_Cyl_D03Rotate;
        private System.Windows.Forms.Button Btn_Cyl_D03Clamp;
        private System.Windows.Forms.Button Btn_Cyl_D03Forward;
        private System.Windows.Forms.Button Btn_Cyl_D03Lifter;
        private System.Windows.Forms.Button Btn_Cyl_D03Adjust;
        private System.Windows.Forms.GroupBox Gb_Step_Belt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button Btn_Belt_D03_Run;
        private System.Windows.Forms.Button Btn_Belt_D03_Direction;
        private System.Windows.Forms.Button Btn_Belt_D03_Enable;
        private System.Windows.Forms.Button Btn_Belt_D02_Run;
        private System.Windows.Forms.Button Btn_Belt_D02_Direction;
        private System.Windows.Forms.Button Btn_Belt_D02_Enable;
        private System.Windows.Forms.Button Btn_Belt_D01_Run;
        private System.Windows.Forms.Button Btn_Belt_D01_Direction;
        private System.Windows.Forms.Button Btn_Belt_D01_Enable;
        private System.Windows.Forms.GroupBox Gb_Step_Beacon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button Btn_Beacon_Buzzer;
        private System.Windows.Forms.Button Btn_Beacon_Lamp_Green;
        private System.Windows.Forms.Button Btn_Beacon_Lamp_Yellow;
        private System.Windows.Forms.Button Btn_Beacon_Lamp_Red;
        private System.Windows.Forms.Button Btn_VirtualAction_D02;
        private System.Windows.Forms.Button Btn_VirtualAction_D03;
        private System.Windows.Forms.Button Btn_VirtualAction_D01;
        private System.Windows.Forms.GroupBox Gb_CCDDebug;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.GroupBox Gb_SFCDebug;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.RichTextBox Rtb_GetData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Button Btn_GetClosure;
        private System.Windows.Forms.Button Btn_GetBOBData;
        private System.Windows.Forms.Button Btn_GetRetailData;
        private System.Windows.Forms.Button Btn_CheckPath;
        private System.Windows.Forms.Button Btn_UpLoadPass;
        private System.Windows.Forms.TextBox Tb_DSN;
        private System.Windows.Forms.TextBox Tb_CCD1_EXTime;
        private System.Windows.Forms.TextBox Tb_CCD2_EXTime;
        private System.Windows.Forms.TextBox Tb_CCD3_EXTime;
        private System.Windows.Forms.Button Btn_CCD1_TakePicture;
        private System.Windows.Forms.Button Btn_CCD2_TakePicture;
        private System.Windows.Forms.Button Btn_CCD3_TakePicture;
        private System.Windows.Forms.Label Label_CCD1_EXTime;
        private System.Windows.Forms.Label Label_CCD2_EXTime;
        private System.Windows.Forms.Label Label_CCD3_EXTime;
        private System.Windows.Forms.Button Btn_Type_Front;
        private System.Windows.Forms.Button Btn_Date_BOB;
        private System.Windows.Forms.Button Btn_Price_BOB;
        private System.Windows.Forms.Button Btn_Type_BOB;
        private System.Windows.Forms.Button Btn_BarCode_Retail;
        private System.Windows.Forms.Button Btn_Color_Retail;
        private System.Windows.Forms.Button Btn_Memory_Retail;
        private System.Windows.Forms.Button Btn_Type_Retail;
        private System.Windows.Forms.Button Btn_GLabel_Retail;
        private System.Windows.Forms.Button Btn_Color_Front;
        private System.Windows.Forms.Button Btn_BeltAction;
        private HelperCmd.Input Signal_Stop;
        private System.Windows.Forms.Button Btn_CCD3_ReadPicture;
        private System.Windows.Forms.Button Btn_CCD2_ReadPicture;
        private System.Windows.Forms.Button Btn_CCD1_ReadPicture;
        private System.Windows.Forms.Button Btn_CCD3_SavePicture;
        private System.Windows.Forms.Button Btn_CCD2_SavePicture;
        private System.Windows.Forms.Button Btn_CCD1_SavePicture;
        private System.Windows.Forms.TextBox Tb_Weight;
    }
}
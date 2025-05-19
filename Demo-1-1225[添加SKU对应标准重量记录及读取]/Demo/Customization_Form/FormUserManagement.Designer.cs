namespace Machine
{
    partial class FormUserManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserManagement));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_Title = new System.Windows.Forms.Label();
            this.Cbb_UserSelect = new System.Windows.Forms.ComboBox();
            this.Label_OldPassword = new System.Windows.Forms.Label();
            this.Tb_OldPassWord = new System.Windows.Forms.TextBox();
            this.Tb_NewPassWord = new System.Windows.Forms.TextBox();
            this.Label_NewPassword = new System.Windows.Forms.Label();
            this.Btn_Modification = new System.Windows.Forms.Button();
            this.Cb_DefaultUser = new System.Windows.Forms.CheckBox();
            this.timer_Flash = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.84366F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.15634F));
            this.tableLayoutPanel1.Controls.Add(this.Label_Title, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cbb_UserSelect, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label_OldPassword, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Tb_OldPassWord, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Tb_NewPassWord, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Label_NewPassword, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Modification, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Cb_DefaultUser, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(339, 192);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Label_Title
            // 
            this.Label_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.Label_Title, 2);
            this.Label_Title.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_Title.Location = new System.Drawing.Point(3, 4);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(333, 23);
            this.Label_Title.TabIndex = 0;
            this.Label_Title.Text = "请选择需要更改的账户类型:";
            this.Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cbb_UserSelect
            // 
            this.Cbb_UserSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cbb_UserSelect.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.SetColumnSpan(this.Cbb_UserSelect, 2);
            this.Cbb_UserSelect.FormattingEnabled = true;
            this.Cbb_UserSelect.Items.AddRange(new object[] {
            "Guest",
            "Normal",
            "Administrator"});
            this.Cbb_UserSelect.Location = new System.Drawing.Point(50, 36);
            this.Cbb_UserSelect.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.Cbb_UserSelect.Name = "Cbb_UserSelect";
            this.Cbb_UserSelect.Size = new System.Drawing.Size(239, 20);
            this.Cbb_UserSelect.TabIndex = 1;
            this.Cbb_UserSelect.SelectedIndexChanged += new System.EventHandler(this.Cbb_UserSelect_SelectedIndexChanged);
            this.Cbb_UserSelect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cbb_UserSelect_KeyPress);
            // 
            // Label_OldPassword
            // 
            this.Label_OldPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_OldPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_OldPassword.Location = new System.Drawing.Point(3, 66);
            this.Label_OldPassword.Name = "Label_OldPassword";
            this.Label_OldPassword.Size = new System.Drawing.Size(85, 23);
            this.Label_OldPassword.TabIndex = 2;
            this.Label_OldPassword.Text = "旧密码:";
            this.Label_OldPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tb_OldPassWord
            // 
            this.Tb_OldPassWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_OldPassWord.BackColor = System.Drawing.Color.Lime;
            this.Tb_OldPassWord.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Tb_OldPassWord.Location = new System.Drawing.Point(94, 67);
            this.Tb_OldPassWord.Name = "Tb_OldPassWord";
            this.Tb_OldPassWord.PasswordChar = '*';
            this.Tb_OldPassWord.Size = new System.Drawing.Size(242, 21);
            this.Tb_OldPassWord.TabIndex = 3;
            // 
            // Tb_NewPassWord
            // 
            this.Tb_NewPassWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_NewPassWord.BackColor = System.Drawing.Color.Lime;
            this.Tb_NewPassWord.Location = new System.Drawing.Point(94, 98);
            this.Tb_NewPassWord.Name = "Tb_NewPassWord";
            this.Tb_NewPassWord.PasswordChar = '*';
            this.Tb_NewPassWord.Size = new System.Drawing.Size(242, 21);
            this.Tb_NewPassWord.TabIndex = 4;
            // 
            // Label_NewPassword
            // 
            this.Label_NewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_NewPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_NewPassword.Location = new System.Drawing.Point(3, 97);
            this.Label_NewPassword.Name = "Label_NewPassword";
            this.Label_NewPassword.Size = new System.Drawing.Size(85, 23);
            this.Label_NewPassword.TabIndex = 5;
            this.Label_NewPassword.Text = "新密码:";
            this.Label_NewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Modification
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Btn_Modification, 2);
            this.Btn_Modification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Modification.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btn_Modification.Location = new System.Drawing.Point(3, 158);
            this.Btn_Modification.Name = "Btn_Modification";
            this.Btn_Modification.Size = new System.Drawing.Size(333, 31);
            this.Btn_Modification.TabIndex = 6;
            this.Btn_Modification.Text = "确认修改";
            this.Btn_Modification.UseVisualStyleBackColor = true;
            this.Btn_Modification.Click += new System.EventHandler(this.Btn_Modification_Click);
            // 
            // Cb_DefaultUser
            // 
            this.Cb_DefaultUser.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.Cb_DefaultUser, 2);
            this.Cb_DefaultUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cb_DefaultUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Cb_DefaultUser.Location = new System.Drawing.Point(3, 127);
            this.Cb_DefaultUser.Name = "Cb_DefaultUser";
            this.Cb_DefaultUser.Size = new System.Drawing.Size(333, 25);
            this.Cb_DefaultUser.TabIndex = 7;
            this.Cb_DefaultUser.Text = "是否设置为默认登录权限";
            this.Cb_DefaultUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Cb_DefaultUser.UseVisualStyleBackColor = true;
            // 
            // timer_Flash
            // 
            this.timer_Flash.Interval = 10;
            this.timer_Flash.Tick += new System.EventHandler(this.timer_Flash_Tick);
            // 
            // FormUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(339, 192);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(355, 231);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(355, 231);
            this.Name = "FormUserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUserManagement";
            this.Load += new System.EventHandler(this.FormUserManagement_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.ComboBox Cbb_UserSelect;
        private System.Windows.Forms.Label Label_OldPassword;
        private System.Windows.Forms.TextBox Tb_OldPassWord;
        private System.Windows.Forms.TextBox Tb_NewPassWord;
        private System.Windows.Forms.Label Label_NewPassword;
        private System.Windows.Forms.Button Btn_Modification;
        private System.Windows.Forms.CheckBox Cb_DefaultUser;
        private System.Windows.Forms.Timer timer_Flash;
    }
}
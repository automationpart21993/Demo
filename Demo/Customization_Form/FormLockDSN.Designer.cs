namespace Machine
{
    partial class FormLockDSN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLockDSN));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Tb_LockDSN = new System.Windows.Forms.TextBox();
            this.Btn_Confirm = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Tb_LockDSN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Confirm, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(252, 73);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Tb_LockDSN
            // 
            this.Tb_LockDSN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_LockDSN.BackColor = System.Drawing.SystemColors.Info;
            this.Tb_LockDSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tb_LockDSN.Location = new System.Drawing.Point(10, 7);
            this.Tb_LockDSN.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Tb_LockDSN.MaxLength = 20;
            this.Tb_LockDSN.Name = "Tb_LockDSN";
            this.Tb_LockDSN.Size = new System.Drawing.Size(232, 21);
            this.Tb_LockDSN.TabIndex = 0;
            this.Tb_LockDSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormLockDSN_KeyDown);
            // 
            // Btn_Confirm
            // 
            this.Btn_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Confirm.BackColor = System.Drawing.Color.Lime;
            this.Btn_Confirm.Location = new System.Drawing.Point(50, 43);
            this.Btn_Confirm.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.Btn_Confirm.Name = "Btn_Confirm";
            this.Btn_Confirm.Size = new System.Drawing.Size(152, 23);
            this.Btn_Confirm.TabIndex = 1;
            this.Btn_Confirm.Text = "确认";
            this.Btn_Confirm.UseVisualStyleBackColor = false;
            this.Btn_Confirm.Click += new System.EventHandler(this.Btn_Confirm_Click);
            // 
            // FormLockDSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(252, 73);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLockDSN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLockDSN";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLockDSN_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormLockDSN_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox Tb_LockDSN;
        private System.Windows.Forms.Button Btn_Confirm;
    }
}
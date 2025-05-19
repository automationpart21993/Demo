namespace Machine
{
    partial class FormMsgBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMsgBox));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_DSN = new System.Windows.Forms.Label();
            this.rtb_msg = new System.Windows.Forms.RichTextBox();
            this.Info_DSN = new System.Windows.Forms.TextBox();
            this.timer_AutoClose = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_DSN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtb_msg, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Info_DSN, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 236);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label_DSN
            // 
            this.label_DSN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_DSN.AutoSize = true;
            this.label_DSN.Location = new System.Drawing.Point(3, 15);
            this.label_DSN.Name = "label_DSN";
            this.label_DSN.Size = new System.Drawing.Size(90, 13);
            this.label_DSN.TabIndex = 0;
            this.label_DSN.Text = "DSN:";
            // 
            // rtb_msg
            // 
            this.rtb_msg.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.SetColumnSpan(this.rtb_msg, 2);
            this.rtb_msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_msg.Location = new System.Drawing.Point(3, 47);
            this.rtb_msg.Name = "rtb_msg";
            this.rtb_msg.ReadOnly = true;
            this.rtb_msg.Size = new System.Drawing.Size(395, 186);
            this.rtb_msg.TabIndex = 2;
            this.rtb_msg.Text = "";
            // 
            // Info_DSN
            // 
            this.Info_DSN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Info_DSN.BackColor = System.Drawing.SystemColors.Info;
            this.Info_DSN.Location = new System.Drawing.Point(99, 12);
            this.Info_DSN.Name = "Info_DSN";
            this.Info_DSN.ReadOnly = true;
            this.Info_DSN.Size = new System.Drawing.Size(299, 20);
            this.Info_DSN.TabIndex = 3;
            // 
            // timer_AutoClose
            // 
            this.timer_AutoClose.Interval = 1000;
            this.timer_AutoClose.Tick += new System.EventHandler(this.timer_AutoClose_Tick);
            // 
            // FormMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(401, 236);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(417, 275);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(417, 275);
            this.Name = "FormMsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NGMsgBox";
            this.Load += new System.EventHandler(this.FormMsgBox_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_DSN;
        private System.Windows.Forms.RichTextBox rtb_msg;
        private System.Windows.Forms.TextBox Info_DSN;
        private System.Windows.Forms.Timer timer_AutoClose;
    }
}
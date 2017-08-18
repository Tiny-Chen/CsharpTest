namespace 客户端
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ZhenDong = new System.Windows.Forms.Button();
            this.SeletFile = new System.Windows.Forms.Button();
            this.SendMsn = new System.Windows.Forms.Button();
            this.SendFile = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.texMsg = new System.Windows.Forms.TextBox();
            this.LogText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PointNumber = new System.Windows.Forms.TextBox();
            this.IpNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ZhenDong
            // 
            this.ZhenDong.Location = new System.Drawing.Point(888, 454);
            this.ZhenDong.Name = "ZhenDong";
            this.ZhenDong.Size = new System.Drawing.Size(91, 36);
            this.ZhenDong.TabIndex = 19;
            this.ZhenDong.Text = "震动";
            this.ZhenDong.UseVisualStyleBackColor = true;
            // 
            // SeletFile
            // 
            this.SeletFile.Location = new System.Drawing.Point(561, 598);
            this.SeletFile.Name = "SeletFile";
            this.SeletFile.Size = new System.Drawing.Size(91, 36);
            this.SeletFile.TabIndex = 18;
            this.SeletFile.Text = "选择文件";
            this.SeletFile.UseVisualStyleBackColor = true;
            // 
            // SendMsn
            // 
            this.SendMsn.Location = new System.Drawing.Point(888, 378);
            this.SendMsn.Name = "SendMsn";
            this.SendMsn.Size = new System.Drawing.Size(91, 36);
            this.SendMsn.TabIndex = 17;
            this.SendMsn.Text = "发送消息";
            this.SendMsn.UseVisualStyleBackColor = true;
            this.SendMsn.Click += new System.EventHandler(this.SendMsn_Click);
            // 
            // SendFile
            // 
            this.SendFile.Location = new System.Drawing.Point(692, 598);
            this.SendFile.Name = "SendFile";
            this.SendFile.Size = new System.Drawing.Size(91, 36);
            this.SendFile.TabIndex = 16;
            this.SendFile.Text = "发送文件";
            this.SendFile.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(80, 598);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(446, 36);
            this.textBox5.TabIndex = 15;
            // 
            // texMsg
            // 
            this.texMsg.Location = new System.Drawing.Point(80, 378);
            this.texMsg.Multiline = true;
            this.texMsg.Name = "texMsg";
            this.texMsg.Size = new System.Drawing.Size(713, 197);
            this.texMsg.TabIndex = 14;
            // 
            // LogText
            // 
            this.LogText.Location = new System.Drawing.Point(80, 157);
            this.LogText.Multiline = true;
            this.LogText.Name = "LogText";
            this.LogText.Size = new System.Drawing.Size(713, 197);
            this.LogText.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(366, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 36);
            this.button1.TabIndex = 12;
            this.button1.Text = "开始连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PointNumber
            // 
            this.PointNumber.Location = new System.Drawing.Point(237, 96);
            this.PointNumber.Multiline = true;
            this.PointNumber.Name = "PointNumber";
            this.PointNumber.Size = new System.Drawing.Size(75, 36);
            this.PointNumber.TabIndex = 11;
            this.PointNumber.Text = "50000";
            // 
            // IpNumber
            // 
            this.IpNumber.Location = new System.Drawing.Point(80, 96);
            this.IpNumber.Multiline = true;
            this.IpNumber.Name = "IpNumber";
            this.IpNumber.Size = new System.Drawing.Size(151, 36);
            this.IpNumber.TabIndex = 10;
            this.IpNumber.Text = "192.168.100.33";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 731);
            this.Controls.Add(this.ZhenDong);
            this.Controls.Add(this.SeletFile);
            this.Controls.Add(this.SendMsn);
            this.Controls.Add(this.SendFile);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.texMsg);
            this.Controls.Add(this.LogText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PointNumber);
            this.Controls.Add(this.IpNumber);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ZhenDong;
        private System.Windows.Forms.Button SeletFile;
        private System.Windows.Forms.Button SendMsn;
        private System.Windows.Forms.Button SendFile;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox texMsg;
        private System.Windows.Forms.TextBox LogText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PointNumber;
        private System.Windows.Forms.TextBox IpNumber;
    }
}


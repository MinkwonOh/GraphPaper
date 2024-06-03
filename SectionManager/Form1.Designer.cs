
namespace SectionManager {
    partial class Form1 {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.tbxIp = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.nmrcPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.sectionDrawerControl1 = new SectionManager.SectionDrawerControl();
            ((System.ComponentModel.ISupportInitialize)(this.tbxIp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcPort)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxIp
            // 
            this.tbxIp.Location = new System.Drawing.Point(56, 13);
            this.tbxIp.Name = "tbxIp";
            this.tbxIp.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.tbxIp.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.tbxIp.Properties.MaskSettings.Set("MaskManagerSignature", "isOptimistic=False");
            this.tbxIp.Properties.MaskSettings.Set("mask", "(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(" +
        "25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[" +
        "0-4][0-9])|(25[0-5]))");
            this.tbxIp.Size = new System.Drawing.Size(100, 20);
            this.tbxIp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP : ";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(349, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(430, 12);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 4;
            this.btnDisconnect.Text = "연결해제";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(959, 12);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "전송";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // nmrcPort
            // 
            this.nmrcPort.Location = new System.Drawing.Point(235, 13);
            this.nmrcPort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nmrcPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrcPort.Name = "nmrcPort";
            this.nmrcPort.Size = new System.Drawing.Size(68, 21);
            this.nmrcPort.TabIndex = 6;
            this.nmrcPort.Value = new decimal(new int[] {
            7531,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "PORT : ";
            // 
            // sectionDrawerControl1
            // 
            this.sectionDrawerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sectionDrawerControl1.BackColor = System.Drawing.SystemColors.Control;
            this.sectionDrawerControl1.Location = new System.Drawing.Point(12, 60);
            this.sectionDrawerControl1.Name = "sectionDrawerControl1";
            this.sectionDrawerControl1.Size = new System.Drawing.Size(1041, 685);
            this.sectionDrawerControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 757);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nmrcPort);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxIp);
            this.Controls.Add(this.sectionDrawerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tbxIp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SectionDrawerControl sectionDrawerControl1;
        private DevExpress.XtraEditors.TextEdit tbxIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.NumericUpDown nmrcPort;
        private System.Windows.Forms.Label label2;
    }
}



namespace SectionManager {
    partial class SectionDrawerControl {
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.pnl_GraphPaper = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.nmrcBoxWidth = new System.Windows.Forms.NumericUpDown();
            this.nmrcBoxHeight = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_GraphPaper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBoxWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBoxHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_GraphPaper
            // 
            this.pnl_GraphPaper.Controls.Add(this.panel1);
            this.pnl_GraphPaper.Location = new System.Drawing.Point(3, 41);
            this.pnl_GraphPaper.Name = "pnl_GraphPaper";
            this.pnl_GraphPaper.Size = new System.Drawing.Size(812, 506);
            this.pnl_GraphPaper.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(852, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // nmrcBoxWidth
            // 
            this.nmrcBoxWidth.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nmrcBoxWidth.Location = new System.Drawing.Point(852, 147);
            this.nmrcBoxWidth.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nmrcBoxWidth.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nmrcBoxWidth.Name = "nmrcBoxWidth";
            this.nmrcBoxWidth.Size = new System.Drawing.Size(71, 21);
            this.nmrcBoxWidth.TabIndex = 2;
            this.nmrcBoxWidth.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // nmrcBoxHeight
            // 
            this.nmrcBoxHeight.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nmrcBoxHeight.Location = new System.Drawing.Point(939, 147);
            this.nmrcBoxHeight.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nmrcBoxHeight.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nmrcBoxHeight.Name = "nmrcBoxHeight";
            this.nmrcBoxHeight.Size = new System.Drawing.Size(71, 21);
            this.nmrcBoxHeight.TabIndex = 3;
            this.nmrcBoxHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(15, 19);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 487);
            this.panel1.TabIndex = 0;
            // 
            // SectionDrawerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.nmrcBoxHeight);
            this.Controls.Add(this.nmrcBoxWidth);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pnl_GraphPaper);
            this.Name = "SectionDrawerControl";
            this.Size = new System.Drawing.Size(1080, 550);
            this.pnl_GraphPaper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBoxWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBoxHeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_GraphPaper;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown nmrcBoxWidth;
        private System.Windows.Forms.NumericUpDown nmrcBoxHeight;
        private System.Windows.Forms.Panel panel1;
    }
}

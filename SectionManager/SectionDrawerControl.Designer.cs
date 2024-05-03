
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.nmrcBoxWidth = new System.Windows.Forms.NumericUpDown();
            this.nmrcBoxHeight = new System.Windows.Forms.NumericUpDown();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.btnDeleteBox = new System.Windows.Forms.Button();
            this.btnClearBox = new System.Windows.Forms.Button();
            this.btnLRTB = new System.Windows.Forms.Button();
            this.btnRLTB = new System.Windows.Forms.Button();
            this.btnRLBT = new System.Windows.Forms.Button();
            this.btnLRBT = new System.Windows.Forms.Button();
            this.btnBTRL = new System.Windows.Forms.Button();
            this.btnTBRL = new System.Windows.Forms.Button();
            this.btnBTLR = new System.Windows.Forms.Button();
            this.btnTBLR = new System.Windows.Forms.Button();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblPosY = new System.Windows.Forms.Label();
            this.lblPosX = new System.Windows.Forms.Label();
            this.nmrcPosY = new System.Windows.Forms.NumericUpDown();
            this.nmrcPosX = new System.Windows.Forms.NumericUpDown();
            this.lblRow = new System.Windows.Forms.Label();
            this.nmrcRow = new System.Windows.Forms.NumericUpDown();
            this.lblCol = new System.Windows.Forms.Label();
            this.nmrcCol = new System.Windows.Forms.NumericUpDown();
            this.lblBoxHeight = new System.Windows.Forms.Label();
            this.lblBoxWidth = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.cbxLan1 = new System.Windows.Forms.CheckBox();
            this.cbxLan2 = new System.Windows.Forms.CheckBox();
            this.sectionCtrl = new SectionManager.SectionControl();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBoxWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBoxHeight)).BeginInit();
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(911, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 39);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "박스 추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // nmrcBoxWidth
            // 
            this.nmrcBoxWidth.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nmrcBoxWidth.Location = new System.Drawing.Point(819, 194);
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
            this.nmrcBoxHeight.Location = new System.Drawing.Point(950, 194);
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
            // pnlBackground
            // 
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackground.Controls.Add(this.sectionCtrl);
            this.pnlBackground.Location = new System.Drawing.Point(3, 63);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(747, 456);
            this.pnlBackground.TabIndex = 4;
            // 
            // btnDeleteBox
            // 
            this.btnDeleteBox.Location = new System.Drawing.Point(793, 231);
            this.btnDeleteBox.Name = "btnDeleteBox";
            this.btnDeleteBox.Size = new System.Drawing.Size(97, 29);
            this.btnDeleteBox.TabIndex = 5;
            this.btnDeleteBox.Text = "박스 삭제";
            this.btnDeleteBox.UseVisualStyleBackColor = true;
            // 
            // btnClearBox
            // 
            this.btnClearBox.Location = new System.Drawing.Point(906, 231);
            this.btnClearBox.Name = "btnClearBox";
            this.btnClearBox.Size = new System.Drawing.Size(94, 29);
            this.btnClearBox.TabIndex = 6;
            this.btnClearBox.Text = "박스 전체삭제";
            this.btnClearBox.UseVisualStyleBackColor = true;
            // 
            // btnLRTB
            // 
            this.btnLRTB.Location = new System.Drawing.Point(775, 364);
            this.btnLRTB.Name = "btnLRTB";
            this.btnLRTB.Size = new System.Drawing.Size(57, 23);
            this.btnLRTB.TabIndex = 7;
            this.btnLRTB.Text = "LRTB";
            this.btnLRTB.UseVisualStyleBackColor = true;
            // 
            // btnRLTB
            // 
            this.btnRLTB.Location = new System.Drawing.Point(838, 364);
            this.btnRLTB.Name = "btnRLTB";
            this.btnRLTB.Size = new System.Drawing.Size(57, 23);
            this.btnRLTB.TabIndex = 8;
            this.btnRLTB.Text = "RLTB";
            this.btnRLTB.UseVisualStyleBackColor = true;
            // 
            // btnRLBT
            // 
            this.btnRLBT.Location = new System.Drawing.Point(964, 364);
            this.btnRLBT.Name = "btnRLBT";
            this.btnRLBT.Size = new System.Drawing.Size(57, 23);
            this.btnRLBT.TabIndex = 10;
            this.btnRLBT.Text = "RLBT";
            this.btnRLBT.UseVisualStyleBackColor = true;
            // 
            // btnLRBT
            // 
            this.btnLRBT.Location = new System.Drawing.Point(901, 364);
            this.btnLRBT.Name = "btnLRBT";
            this.btnLRBT.Size = new System.Drawing.Size(57, 23);
            this.btnLRBT.TabIndex = 9;
            this.btnLRBT.Text = "LRBT";
            this.btnLRBT.UseVisualStyleBackColor = true;
            // 
            // btnBTRL
            // 
            this.btnBTRL.Location = new System.Drawing.Point(964, 393);
            this.btnBTRL.Name = "btnBTRL";
            this.btnBTRL.Size = new System.Drawing.Size(57, 23);
            this.btnBTRL.TabIndex = 14;
            this.btnBTRL.Text = "BTRL";
            this.btnBTRL.UseVisualStyleBackColor = true;
            // 
            // btnTBRL
            // 
            this.btnTBRL.Location = new System.Drawing.Point(901, 393);
            this.btnTBRL.Name = "btnTBRL";
            this.btnTBRL.Size = new System.Drawing.Size(57, 23);
            this.btnTBRL.TabIndex = 13;
            this.btnTBRL.Text = "TBRL";
            this.btnTBRL.UseVisualStyleBackColor = true;
            // 
            // btnBTLR
            // 
            this.btnBTLR.Location = new System.Drawing.Point(838, 393);
            this.btnBTLR.Name = "btnBTLR";
            this.btnBTLR.Size = new System.Drawing.Size(57, 23);
            this.btnBTLR.TabIndex = 12;
            this.btnBTLR.Text = "BTLR";
            this.btnBTLR.UseVisualStyleBackColor = true;
            // 
            // btnTBLR
            // 
            this.btnTBLR.Location = new System.Drawing.Point(775, 393);
            this.btnTBLR.Name = "btnTBLR";
            this.btnTBLR.Size = new System.Drawing.Size(57, 23);
            this.btnTBLR.TabIndex = 11;
            this.btnTBLR.Text = "TBLR";
            this.btnTBLR.UseVisualStyleBackColor = true;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(778, 196);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 12);
            this.lblWidth.TabIndex = 15;
            this.lblWidth.Text = "Width";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(904, 196);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(40, 12);
            this.lblHeight.TabIndex = 16;
            this.lblHeight.Text = "Height";
            // 
            // lblPosY
            // 
            this.lblPosY.AutoSize = true;
            this.lblPosY.Location = new System.Drawing.Point(904, 169);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(35, 12);
            this.lblPosY.TabIndex = 20;
            this.lblPosY.Text = "PosY";
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.Location = new System.Drawing.Point(778, 169);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(35, 12);
            this.lblPosX.TabIndex = 19;
            this.lblPosX.Text = "PosX";
            // 
            // nmrcPosY
            // 
            this.nmrcPosY.Location = new System.Drawing.Point(950, 167);
            this.nmrcPosY.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nmrcPosY.Name = "nmrcPosY";
            this.nmrcPosY.Size = new System.Drawing.Size(71, 21);
            this.nmrcPosY.TabIndex = 18;
            // 
            // nmrcPosX
            // 
            this.nmrcPosX.Location = new System.Drawing.Point(819, 167);
            this.nmrcPosX.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nmrcPosX.Name = "nmrcPosX";
            this.nmrcPosX.Size = new System.Drawing.Size(71, 21);
            this.nmrcPosX.TabIndex = 17;
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(778, 142);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(30, 12);
            this.lblRow.TabIndex = 22;
            this.lblRow.Text = "Row";
            // 
            // nmrcRow
            // 
            this.nmrcRow.Location = new System.Drawing.Point(819, 140);
            this.nmrcRow.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nmrcRow.Name = "nmrcRow";
            this.nmrcRow.Size = new System.Drawing.Size(71, 21);
            this.nmrcRow.TabIndex = 21;
            // 
            // lblCol
            // 
            this.lblCol.AutoSize = true;
            this.lblCol.Location = new System.Drawing.Point(909, 142);
            this.lblCol.Name = "lblCol";
            this.lblCol.Size = new System.Drawing.Size(24, 12);
            this.lblCol.TabIndex = 24;
            this.lblCol.Text = "Col";
            // 
            // nmrcCol
            // 
            this.nmrcCol.Location = new System.Drawing.Point(950, 140);
            this.nmrcCol.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nmrcCol.Name = "nmrcCol";
            this.nmrcCol.Size = new System.Drawing.Size(71, 21);
            this.nmrcCol.TabIndex = 23;
            // 
            // lblBoxHeight
            // 
            this.lblBoxHeight.AutoSize = true;
            this.lblBoxHeight.Location = new System.Drawing.Point(904, 284);
            this.lblBoxHeight.Name = "lblBoxHeight";
            this.lblBoxHeight.Size = new System.Drawing.Size(40, 12);
            this.lblBoxHeight.TabIndex = 30;
            this.lblBoxHeight.Text = "Height";
            // 
            // lblBoxWidth
            // 
            this.lblBoxWidth.AutoSize = true;
            this.lblBoxWidth.Location = new System.Drawing.Point(778, 284);
            this.lblBoxWidth.Name = "lblBoxWidth";
            this.lblBoxWidth.Size = new System.Drawing.Size(35, 12);
            this.lblBoxWidth.TabIndex = 29;
            this.lblBoxWidth.Text = "Width";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(950, 282);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(71, 21);
            this.numericUpDown1.TabIndex = 28;
            this.numericUpDown1.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(819, 282);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(71, 21);
            this.numericUpDown2.TabIndex = 27;
            this.numericUpDown2.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // cbxLan1
            // 
            this.cbxLan1.AutoSize = true;
            this.cbxLan1.Location = new System.Drawing.Point(780, 25);
            this.cbxLan1.Name = "cbxLan1";
            this.cbxLan1.Size = new System.Drawing.Size(54, 16);
            this.cbxLan1.TabIndex = 31;
            this.cbxLan1.Text = "LAN1";
            this.cbxLan1.UseVisualStyleBackColor = true;
            // 
            // cbxLan2
            // 
            this.cbxLan2.AutoSize = true;
            this.cbxLan2.Location = new System.Drawing.Point(901, 25);
            this.cbxLan2.Name = "cbxLan2";
            this.cbxLan2.Size = new System.Drawing.Size(54, 16);
            this.cbxLan2.TabIndex = 32;
            this.cbxLan2.Text = "LAN2";
            this.cbxLan2.UseVisualStyleBackColor = true;
            // 
            // sectionCtrl
            // 
            this.sectionCtrl.BackColor = System.Drawing.Color.White;
            this.sectionCtrl.Location = new System.Drawing.Point(18, 17);
            this.sectionCtrl.Name = "sectionCtrl";
            this.sectionCtrl.Size = new System.Drawing.Size(729, 439);
            this.sectionCtrl.TabIndex = 0;
            this.sectionCtrl.Text = "sectionCtrl";
            // 
            // SectionDrawerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.cbxLan2);
            this.Controls.Add(this.cbxLan1);
            this.Controls.Add(this.lblBoxHeight);
            this.Controls.Add(this.lblBoxWidth);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.lblCol);
            this.Controls.Add(this.nmrcCol);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.nmrcRow);
            this.Controls.Add(this.lblPosY);
            this.Controls.Add(this.lblPosX);
            this.Controls.Add(this.nmrcPosY);
            this.Controls.Add(this.nmrcPosX);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.btnBTRL);
            this.Controls.Add(this.btnTBRL);
            this.Controls.Add(this.btnBTLR);
            this.Controls.Add(this.btnTBLR);
            this.Controls.Add(this.btnRLBT);
            this.Controls.Add(this.btnLRBT);
            this.Controls.Add(this.btnRLTB);
            this.Controls.Add(this.btnLRTB);
            this.Controls.Add(this.btnClearBox);
            this.Controls.Add(this.btnDeleteBox);
            this.Controls.Add(this.pnlBackground);
            this.Controls.Add(this.nmrcBoxHeight);
            this.Controls.Add(this.nmrcBoxWidth);
            this.Controls.Add(this.btnAdd);
            this.Name = "SectionDrawerControl";
            this.Size = new System.Drawing.Size(1036, 526);
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBoxWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBoxHeight)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmrcPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown nmrcBoxWidth;
        private System.Windows.Forms.NumericUpDown nmrcBoxHeight;
        private System.Windows.Forms.Panel pnlBackground;
        private SectionControl sectionCtrl;
        private System.Windows.Forms.Button btnDeleteBox;
        private System.Windows.Forms.Button btnClearBox;
        private System.Windows.Forms.Button btnLRTB;
        private System.Windows.Forms.Button btnRLTB;
        private System.Windows.Forms.Button btnRLBT;
        private System.Windows.Forms.Button btnLRBT;
        private System.Windows.Forms.Button btnBTRL;
        private System.Windows.Forms.Button btnTBRL;
        private System.Windows.Forms.Button btnBTLR;
        private System.Windows.Forms.Button btnTBLR;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblPosY;
        private System.Windows.Forms.Label lblPosX;
        private System.Windows.Forms.NumericUpDown nmrcPosY;
        private System.Windows.Forms.NumericUpDown nmrcPosX;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.NumericUpDown nmrcRow;
        private System.Windows.Forms.Label lblCol;
        private System.Windows.Forms.NumericUpDown nmrcCol;
        private System.Windows.Forms.Label lblBoxHeight;
        private System.Windows.Forms.Label lblBoxWidth;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.CheckBox cbxLan1;
        private System.Windows.Forms.CheckBox cbxLan2;
    }
}

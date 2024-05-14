
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
            this.nmrcBaseHeight = new System.Windows.Forms.NumericUpDown();
            this.nmrcBaseWidth = new System.Windows.Forms.NumericUpDown();
            this.btnAlignLeft = new System.Windows.Forms.Button();
            this.btnAlignRight = new System.Windows.Forms.Button();
            this.btnAlignTop = new System.Windows.Forms.Button();
            this.btnAlignBottom = new System.Windows.Forms.Button();
            this.lblAlignSide = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblAlignRow = new System.Windows.Forms.Label();
            this.btnLeftBot = new System.Windows.Forms.Button();
            this.btnLeftTop = new System.Windows.Forms.Button();
            this.btnRightBot = new System.Windows.Forms.Button();
            this.btnRightTop = new System.Windows.Forms.Button();
            this.btnBottomLeft = new System.Windows.Forms.Button();
            this.btnTopLeft = new System.Windows.Forms.Button();
            this.btnBottomRight = new System.Windows.Forms.Button();
            this.btnTopRight = new System.Windows.Forms.Button();
            this.lblAlignCol = new System.Windows.Forms.Label();
            this.rdoPort1 = new System.Windows.Forms.RadioButton();
            this.rdoPort2 = new System.Windows.Forms.RadioButton();
            this.grpPort = new System.Windows.Forms.GroupBox();
            this.cbxZoom = new System.Windows.Forms.ComboBox();
            this.lblZoom = new System.Windows.Forms.Label();
            this.sectionCtrl = new SectionManager.SectionControl();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBoxWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBoxHeight)).BeginInit();
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBaseHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBaseWidth)).BeginInit();
            this.grpPort.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(911, 63);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 39);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "박스 추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // nmrcBoxWidth
            // 
            this.nmrcBoxWidth.Location = new System.Drawing.Point(819, 166);
            this.nmrcBoxWidth.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nmrcBoxWidth.Minimum = new decimal(new int[] {
            8,
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
            this.nmrcBoxHeight.Location = new System.Drawing.Point(950, 166);
            this.nmrcBoxHeight.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nmrcBoxHeight.Minimum = new decimal(new int[] {
            8,
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
            this.btnDeleteBox.Location = new System.Drawing.Point(793, 203);
            this.btnDeleteBox.Name = "btnDeleteBox";
            this.btnDeleteBox.Size = new System.Drawing.Size(97, 29);
            this.btnDeleteBox.TabIndex = 5;
            this.btnDeleteBox.Text = "박스 삭제";
            this.btnDeleteBox.UseVisualStyleBackColor = true;
            // 
            // btnClearBox
            // 
            this.btnClearBox.Location = new System.Drawing.Point(906, 203);
            this.btnClearBox.Name = "btnClearBox";
            this.btnClearBox.Size = new System.Drawing.Size(94, 29);
            this.btnClearBox.TabIndex = 6;
            this.btnClearBox.Text = "박스 전체삭제";
            this.btnClearBox.UseVisualStyleBackColor = true;
            // 
            // btnLRTB
            // 
            this.btnLRTB.Location = new System.Drawing.Point(775, 318);
            this.btnLRTB.Name = "btnLRTB";
            this.btnLRTB.Size = new System.Drawing.Size(57, 23);
            this.btnLRTB.TabIndex = 7;
            this.btnLRTB.Text = "LRTB";
            this.btnLRTB.UseVisualStyleBackColor = true;
            // 
            // btnRLTB
            // 
            this.btnRLTB.Location = new System.Drawing.Point(838, 318);
            this.btnRLTB.Name = "btnRLTB";
            this.btnRLTB.Size = new System.Drawing.Size(57, 23);
            this.btnRLTB.TabIndex = 8;
            this.btnRLTB.Text = "RLTB";
            this.btnRLTB.UseVisualStyleBackColor = true;
            // 
            // btnRLBT
            // 
            this.btnRLBT.Location = new System.Drawing.Point(964, 318);
            this.btnRLBT.Name = "btnRLBT";
            this.btnRLBT.Size = new System.Drawing.Size(57, 23);
            this.btnRLBT.TabIndex = 10;
            this.btnRLBT.Text = "RLBT";
            this.btnRLBT.UseVisualStyleBackColor = true;
            // 
            // btnLRBT
            // 
            this.btnLRBT.Location = new System.Drawing.Point(901, 318);
            this.btnLRBT.Name = "btnLRBT";
            this.btnLRBT.Size = new System.Drawing.Size(57, 23);
            this.btnLRBT.TabIndex = 9;
            this.btnLRBT.Text = "LRBT";
            this.btnLRBT.UseVisualStyleBackColor = true;
            // 
            // btnBTRL
            // 
            this.btnBTRL.Location = new System.Drawing.Point(964, 347);
            this.btnBTRL.Name = "btnBTRL";
            this.btnBTRL.Size = new System.Drawing.Size(57, 23);
            this.btnBTRL.TabIndex = 14;
            this.btnBTRL.Text = "BTRL";
            this.btnBTRL.UseVisualStyleBackColor = true;
            // 
            // btnTBRL
            // 
            this.btnTBRL.Location = new System.Drawing.Point(901, 347);
            this.btnTBRL.Name = "btnTBRL";
            this.btnTBRL.Size = new System.Drawing.Size(57, 23);
            this.btnTBRL.TabIndex = 13;
            this.btnTBRL.Text = "TBRL";
            this.btnTBRL.UseVisualStyleBackColor = true;
            // 
            // btnBTLR
            // 
            this.btnBTLR.Location = new System.Drawing.Point(838, 347);
            this.btnBTLR.Name = "btnBTLR";
            this.btnBTLR.Size = new System.Drawing.Size(57, 23);
            this.btnBTLR.TabIndex = 12;
            this.btnBTLR.Text = "BTLR";
            this.btnBTLR.UseVisualStyleBackColor = true;
            // 
            // btnTBLR
            // 
            this.btnTBLR.Location = new System.Drawing.Point(775, 347);
            this.btnTBLR.Name = "btnTBLR";
            this.btnTBLR.Size = new System.Drawing.Size(57, 23);
            this.btnTBLR.TabIndex = 11;
            this.btnTBLR.Text = "TBLR";
            this.btnTBLR.UseVisualStyleBackColor = true;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(778, 168);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 12);
            this.lblWidth.TabIndex = 15;
            this.lblWidth.Text = "Width";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(904, 168);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(40, 12);
            this.lblHeight.TabIndex = 16;
            this.lblHeight.Text = "Height";
            // 
            // lblPosY
            // 
            this.lblPosY.AutoSize = true;
            this.lblPosY.Location = new System.Drawing.Point(904, 141);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(35, 12);
            this.lblPosY.TabIndex = 20;
            this.lblPosY.Text = "PosY";
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.Location = new System.Drawing.Point(778, 141);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(35, 12);
            this.lblPosX.TabIndex = 19;
            this.lblPosX.Text = "PosX";
            // 
            // nmrcPosY
            // 
            this.nmrcPosY.Location = new System.Drawing.Point(950, 139);
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
            this.nmrcPosX.Location = new System.Drawing.Point(819, 139);
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
            this.lblRow.Location = new System.Drawing.Point(778, 114);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(30, 12);
            this.lblRow.TabIndex = 22;
            this.lblRow.Text = "Row";
            // 
            // nmrcRow
            // 
            this.nmrcRow.Location = new System.Drawing.Point(819, 112);
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
            this.lblCol.Location = new System.Drawing.Point(909, 114);
            this.lblCol.Name = "lblCol";
            this.lblCol.Size = new System.Drawing.Size(24, 12);
            this.lblCol.TabIndex = 24;
            this.lblCol.Text = "Col";
            // 
            // nmrcCol
            // 
            this.nmrcCol.Location = new System.Drawing.Point(950, 112);
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
            this.lblBoxHeight.Location = new System.Drawing.Point(899, 261);
            this.lblBoxHeight.Name = "lblBoxHeight";
            this.lblBoxHeight.Size = new System.Drawing.Size(40, 12);
            this.lblBoxHeight.TabIndex = 30;
            this.lblBoxHeight.Text = "Height";
            // 
            // lblBoxWidth
            // 
            this.lblBoxWidth.AutoSize = true;
            this.lblBoxWidth.Location = new System.Drawing.Point(773, 261);
            this.lblBoxWidth.Name = "lblBoxWidth";
            this.lblBoxWidth.Size = new System.Drawing.Size(35, 12);
            this.lblBoxWidth.TabIndex = 29;
            this.lblBoxWidth.Text = "Width";
            // 
            // nmrcBaseHeight
            // 
            this.nmrcBaseHeight.Location = new System.Drawing.Point(945, 259);
            this.nmrcBaseHeight.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nmrcBaseHeight.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nmrcBaseHeight.Name = "nmrcBaseHeight";
            this.nmrcBaseHeight.Size = new System.Drawing.Size(71, 21);
            this.nmrcBaseHeight.TabIndex = 28;
            this.nmrcBaseHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // nmrcBaseWidth
            // 
            this.nmrcBaseWidth.Location = new System.Drawing.Point(814, 259);
            this.nmrcBaseWidth.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nmrcBaseWidth.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nmrcBaseWidth.Name = "nmrcBaseWidth";
            this.nmrcBaseWidth.Size = new System.Drawing.Size(71, 21);
            this.nmrcBaseWidth.TabIndex = 27;
            this.nmrcBaseWidth.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // btnAlignLeft
            // 
            this.btnAlignLeft.Location = new System.Drawing.Point(901, 496);
            this.btnAlignLeft.Name = "btnAlignLeft";
            this.btnAlignLeft.Size = new System.Drawing.Size(57, 23);
            this.btnAlignLeft.TabIndex = 33;
            this.btnAlignLeft.Text = "좌";
            this.btnAlignLeft.UseVisualStyleBackColor = true;
            // 
            // btnAlignRight
            // 
            this.btnAlignRight.Location = new System.Drawing.Point(964, 496);
            this.btnAlignRight.Name = "btnAlignRight";
            this.btnAlignRight.Size = new System.Drawing.Size(57, 23);
            this.btnAlignRight.TabIndex = 34;
            this.btnAlignRight.Text = "우";
            this.btnAlignRight.UseVisualStyleBackColor = true;
            // 
            // btnAlignTop
            // 
            this.btnAlignTop.Location = new System.Drawing.Point(775, 496);
            this.btnAlignTop.Name = "btnAlignTop";
            this.btnAlignTop.Size = new System.Drawing.Size(55, 23);
            this.btnAlignTop.TabIndex = 35;
            this.btnAlignTop.Text = "상";
            this.btnAlignTop.UseVisualStyleBackColor = true;
            // 
            // btnAlignBottom
            // 
            this.btnAlignBottom.Location = new System.Drawing.Point(838, 496);
            this.btnAlignBottom.Name = "btnAlignBottom";
            this.btnAlignBottom.Size = new System.Drawing.Size(57, 23);
            this.btnAlignBottom.TabIndex = 36;
            this.btnAlignBottom.Text = "하";
            this.btnAlignBottom.UseVisualStyleBackColor = true;
            // 
            // lblAlignSide
            // 
            this.lblAlignSide.AutoSize = true;
            this.lblAlignSide.Location = new System.Drawing.Point(773, 481);
            this.lblAlignSide.Name = "lblAlignSide";
            this.lblAlignSide.Size = new System.Drawing.Size(45, 12);
            this.lblAlignSide.TabIndex = 37;
            this.lblAlignSide.Text = "축 정렬";
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(773, 303);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(57, 12);
            this.lblLine.TabIndex = 38;
            this.lblLine.Text = "라인 설정";
            // 
            // lblAlignRow
            // 
            this.lblAlignRow.AutoSize = true;
            this.lblAlignRow.Location = new System.Drawing.Point(773, 381);
            this.lblAlignRow.Name = "lblAlignRow";
            this.lblAlignRow.Size = new System.Drawing.Size(85, 12);
            this.lblAlignRow.TabIndex = 43;
            this.lblAlignRow.Text = "행 모서리 정렬";
            // 
            // btnLeftBot
            // 
            this.btnLeftBot.Location = new System.Drawing.Point(901, 396);
            this.btnLeftBot.Name = "btnLeftBot";
            this.btnLeftBot.Size = new System.Drawing.Size(57, 23);
            this.btnLeftBot.TabIndex = 47;
            this.btnLeftBot.Text = "좌하";
            this.btnLeftBot.UseVisualStyleBackColor = true;
            // 
            // btnLeftTop
            // 
            this.btnLeftTop.Location = new System.Drawing.Point(775, 396);
            this.btnLeftTop.Name = "btnLeftTop";
            this.btnLeftTop.Size = new System.Drawing.Size(55, 23);
            this.btnLeftTop.TabIndex = 46;
            this.btnLeftTop.Text = "좌상";
            this.btnLeftTop.UseVisualStyleBackColor = true;
            // 
            // btnRightBot
            // 
            this.btnRightBot.Location = new System.Drawing.Point(964, 396);
            this.btnRightBot.Name = "btnRightBot";
            this.btnRightBot.Size = new System.Drawing.Size(57, 23);
            this.btnRightBot.TabIndex = 45;
            this.btnRightBot.Text = "우하";
            this.btnRightBot.UseVisualStyleBackColor = true;
            // 
            // btnRightTop
            // 
            this.btnRightTop.Location = new System.Drawing.Point(838, 396);
            this.btnRightTop.Name = "btnRightTop";
            this.btnRightTop.Size = new System.Drawing.Size(57, 23);
            this.btnRightTop.TabIndex = 44;
            this.btnRightTop.Text = "우상";
            this.btnRightTop.UseVisualStyleBackColor = true;
            // 
            // btnBottomLeft
            // 
            this.btnBottomLeft.Location = new System.Drawing.Point(901, 442);
            this.btnBottomLeft.Name = "btnBottomLeft";
            this.btnBottomLeft.Size = new System.Drawing.Size(57, 23);
            this.btnBottomLeft.TabIndex = 52;
            this.btnBottomLeft.Text = "하좌";
            this.btnBottomLeft.UseVisualStyleBackColor = true;
            // 
            // btnTopLeft
            // 
            this.btnTopLeft.Location = new System.Drawing.Point(775, 442);
            this.btnTopLeft.Name = "btnTopLeft";
            this.btnTopLeft.Size = new System.Drawing.Size(55, 23);
            this.btnTopLeft.TabIndex = 51;
            this.btnTopLeft.Text = "상좌";
            this.btnTopLeft.UseVisualStyleBackColor = true;
            // 
            // btnBottomRight
            // 
            this.btnBottomRight.Location = new System.Drawing.Point(964, 442);
            this.btnBottomRight.Name = "btnBottomRight";
            this.btnBottomRight.Size = new System.Drawing.Size(57, 23);
            this.btnBottomRight.TabIndex = 50;
            this.btnBottomRight.Text = "하우";
            this.btnBottomRight.UseVisualStyleBackColor = true;
            // 
            // btnTopRight
            // 
            this.btnTopRight.Location = new System.Drawing.Point(838, 442);
            this.btnTopRight.Name = "btnTopRight";
            this.btnTopRight.Size = new System.Drawing.Size(57, 23);
            this.btnTopRight.TabIndex = 49;
            this.btnTopRight.Text = "상우";
            this.btnTopRight.UseVisualStyleBackColor = true;
            // 
            // lblAlignCol
            // 
            this.lblAlignCol.AutoSize = true;
            this.lblAlignCol.Location = new System.Drawing.Point(773, 427);
            this.lblAlignCol.Name = "lblAlignCol";
            this.lblAlignCol.Size = new System.Drawing.Size(85, 12);
            this.lblAlignCol.TabIndex = 48;
            this.lblAlignCol.Text = "열 모서리 정렬";
            // 
            // rdoPort1
            // 
            this.rdoPort1.AutoSize = true;
            this.rdoPort1.Location = new System.Drawing.Point(40, 20);
            this.rdoPort1.Name = "rdoPort1";
            this.rdoPort1.Size = new System.Drawing.Size(66, 16);
            this.rdoPort1.TabIndex = 53;
            this.rdoPort1.TabStop = true;
            this.rdoPort1.Tag = "1";
            this.rdoPort1.Text = "PORT 1";
            this.rdoPort1.UseVisualStyleBackColor = true;
            // 
            // rdoPort2
            // 
            this.rdoPort2.AutoSize = true;
            this.rdoPort2.Location = new System.Drawing.Point(159, 20);
            this.rdoPort2.Name = "rdoPort2";
            this.rdoPort2.Size = new System.Drawing.Size(66, 16);
            this.rdoPort2.TabIndex = 54;
            this.rdoPort2.TabStop = true;
            this.rdoPort2.Tag = "2";
            this.rdoPort2.Text = "PORT 2";
            this.rdoPort2.UseVisualStyleBackColor = true;
            // 
            // grpPort
            // 
            this.grpPort.Controls.Add(this.rdoPort2);
            this.grpPort.Controls.Add(this.rdoPort1);
            this.grpPort.Location = new System.Drawing.Point(752, 3);
            this.grpPort.Name = "grpPort";
            this.grpPort.Size = new System.Drawing.Size(269, 54);
            this.grpPort.TabIndex = 55;
            this.grpPort.TabStop = false;
            this.grpPort.Text = "LAN Port";
            // 
            // cbxZoom
            // 
            this.cbxZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxZoom.FormattingEnabled = true;
            this.cbxZoom.Location = new System.Drawing.Point(682, 24);
            this.cbxZoom.Name = "cbxZoom";
            this.cbxZoom.Size = new System.Drawing.Size(58, 20);
            this.cbxZoom.TabIndex = 56;
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(606, 27);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(66, 12);
            this.lblZoom.TabIndex = 57;
            this.lblZoom.Text = "Zoom(%) :";
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
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.cbxZoom);
            this.Controls.Add(this.btnBottomLeft);
            this.Controls.Add(this.btnTopLeft);
            this.Controls.Add(this.btnBottomRight);
            this.Controls.Add(this.btnTopRight);
            this.Controls.Add(this.lblAlignCol);
            this.Controls.Add(this.btnLeftBot);
            this.Controls.Add(this.btnLeftTop);
            this.Controls.Add(this.btnRightBot);
            this.Controls.Add(this.btnRightTop);
            this.Controls.Add(this.lblAlignRow);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblAlignSide);
            this.Controls.Add(this.btnAlignBottom);
            this.Controls.Add(this.btnAlignTop);
            this.Controls.Add(this.btnAlignRight);
            this.Controls.Add(this.btnAlignLeft);
            this.Controls.Add(this.lblBoxHeight);
            this.Controls.Add(this.lblBoxWidth);
            this.Controls.Add(this.nmrcBaseHeight);
            this.Controls.Add(this.nmrcBaseWidth);
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
            this.Controls.Add(this.grpPort);
            this.Name = "SectionDrawerControl";
            this.Size = new System.Drawing.Size(1036, 526);
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBoxWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBoxHeight)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmrcPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBaseHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBaseWidth)).EndInit();
            this.grpPort.ResumeLayout(false);
            this.grpPort.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown nmrcBaseHeight;
        private System.Windows.Forms.NumericUpDown nmrcBaseWidth;
        private System.Windows.Forms.Button btnAlignLeft;
        private System.Windows.Forms.Button btnAlignRight;
        private System.Windows.Forms.Button btnAlignTop;
        private System.Windows.Forms.Button btnAlignBottom;
        private System.Windows.Forms.Label lblAlignSide;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblAlignRow;
        private System.Windows.Forms.Button btnLeftBot;
        private System.Windows.Forms.Button btnLeftTop;
        private System.Windows.Forms.Button btnRightBot;
        private System.Windows.Forms.Button btnRightTop;
        private System.Windows.Forms.Button btnBottomLeft;
        private System.Windows.Forms.Button btnTopLeft;
        private System.Windows.Forms.Button btnBottomRight;
        private System.Windows.Forms.Button btnTopRight;
        private System.Windows.Forms.Label lblAlignCol;
        private System.Windows.Forms.RadioButton rdoPort1;
        private System.Windows.Forms.RadioButton rdoPort2;
        private System.Windows.Forms.GroupBox grpPort;
        private System.Windows.Forms.ComboBox cbxZoom;
        private System.Windows.Forms.Label lblZoom;
    }
}

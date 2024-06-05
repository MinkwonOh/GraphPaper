
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
            this.btnRightBot = new System.Windows.Forms.Button();
            this.btnRightTop = new System.Windows.Forms.Button();
            this.btnBottomLeft = new System.Windows.Forms.Button();
            this.btnTopLeft = new System.Windows.Forms.Button();
            this.btnBottomRight = new System.Windows.Forms.Button();
            this.btnTopRight = new System.Windows.Forms.Button();
            this.lblAlignCol = new System.Windows.Forms.Label();
            this.c = new System.Windows.Forms.RadioButton();
            this.rdoPort2 = new System.Windows.Forms.RadioButton();
            this.grpPort = new System.Windows.Forms.GroupBox();
            this.cbxZoom = new System.Windows.Forms.ComboBox();
            this.lblZoom = new System.Windows.Forms.Label();
            this.btnLeftTop = new System.Windows.Forms.Button();
            this.btnBTRL = new System.Windows.Forms.Button();
            this.btnTBRL = new System.Windows.Forms.Button();
            this.btnBTLR = new System.Windows.Forms.Button();
            this.btnTBLR = new System.Windows.Forms.Button();
            this.btnRLBT = new System.Windows.Forms.Button();
            this.btnLRBT = new System.Windows.Forms.Button();
            this.btnRLTB = new System.Windows.Forms.Button();
            this.btnLRTB = new System.Windows.Forms.Button();
            this.tbxRctX = new System.Windows.Forms.TextBox();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.btnSetPosDragbox = new System.Windows.Forms.Button();
            this.tbxRctY = new System.Windows.Forms.TextBox();
            this.lblModule = new System.Windows.Forms.Label();
            this.cbxModule = new System.Windows.Forms.ComboBox();
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
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(916, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 48);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "박스 추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // nmrcBoxWidth
            // 
            this.nmrcBoxWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nmrcBoxWidth.Location = new System.Drawing.Point(824, 254);
            this.nmrcBoxWidth.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nmrcBoxWidth.Name = "nmrcBoxWidth";
            this.nmrcBoxWidth.Size = new System.Drawing.Size(71, 21);
            this.nmrcBoxWidth.TabIndex = 2;
            // 
            // nmrcBoxHeight
            // 
            this.nmrcBoxHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nmrcBoxHeight.Location = new System.Drawing.Point(955, 254);
            this.nmrcBoxHeight.Maximum = new decimal(new int[] {
            65535,
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
            this.pnlBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBackground.AutoScroll = true;
            this.pnlBackground.Controls.Add(this.sectionCtrl);
            this.pnlBackground.Location = new System.Drawing.Point(3, 63);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(747, 595);
            this.pnlBackground.TabIndex = 4;
            // 
            // btnDeleteBox
            // 
            this.btnDeleteBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteBox.Location = new System.Drawing.Point(798, 281);
            this.btnDeleteBox.Name = "btnDeleteBox";
            this.btnDeleteBox.Size = new System.Drawing.Size(97, 29);
            this.btnDeleteBox.TabIndex = 5;
            this.btnDeleteBox.Text = "박스 삭제";
            this.btnDeleteBox.UseVisualStyleBackColor = true;
            // 
            // btnClearBox
            // 
            this.btnClearBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearBox.Location = new System.Drawing.Point(911, 281);
            this.btnClearBox.Name = "btnClearBox";
            this.btnClearBox.Size = new System.Drawing.Size(94, 29);
            this.btnClearBox.TabIndex = 6;
            this.btnClearBox.Text = "박스 전체삭제";
            this.btnClearBox.UseVisualStyleBackColor = true;
            // 
            // lblWidth
            // 
            this.lblWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(783, 256);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 12);
            this.lblWidth.TabIndex = 15;
            this.lblWidth.Text = "Width";
            // 
            // lblHeight
            // 
            this.lblHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(909, 256);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(40, 12);
            this.lblHeight.TabIndex = 16;
            this.lblHeight.Text = "Height";
            // 
            // lblPosY
            // 
            this.lblPosY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosY.AutoSize = true;
            this.lblPosY.Location = new System.Drawing.Point(909, 229);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(35, 12);
            this.lblPosY.TabIndex = 20;
            this.lblPosY.Text = "PosY";
            // 
            // lblPosX
            // 
            this.lblPosX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosX.AutoSize = true;
            this.lblPosX.Location = new System.Drawing.Point(783, 229);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(35, 12);
            this.lblPosX.TabIndex = 19;
            this.lblPosX.Text = "PosX";
            // 
            // nmrcPosY
            // 
            this.nmrcPosY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nmrcPosY.Location = new System.Drawing.Point(955, 227);
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
            this.nmrcPosX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nmrcPosX.Location = new System.Drawing.Point(824, 227);
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
            this.lblRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(783, 202);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(30, 12);
            this.lblRow.TabIndex = 22;
            this.lblRow.Text = "Row";
            // 
            // nmrcRow
            // 
            this.nmrcRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nmrcRow.Location = new System.Drawing.Point(824, 200);
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
            this.lblCol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCol.AutoSize = true;
            this.lblCol.Location = new System.Drawing.Point(914, 202);
            this.lblCol.Name = "lblCol";
            this.lblCol.Size = new System.Drawing.Size(24, 12);
            this.lblCol.TabIndex = 24;
            this.lblCol.Text = "Col";
            // 
            // nmrcCol
            // 
            this.nmrcCol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nmrcCol.Location = new System.Drawing.Point(955, 200);
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
            this.lblBoxHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBoxHeight.AutoSize = true;
            this.lblBoxHeight.Location = new System.Drawing.Point(778, 124);
            this.lblBoxHeight.Name = "lblBoxHeight";
            this.lblBoxHeight.Size = new System.Drawing.Size(40, 12);
            this.lblBoxHeight.TabIndex = 30;
            this.lblBoxHeight.Text = "Height";
            // 
            // lblBoxWidth
            // 
            this.lblBoxWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBoxWidth.AutoSize = true;
            this.lblBoxWidth.Location = new System.Drawing.Point(783, 97);
            this.lblBoxWidth.Name = "lblBoxWidth";
            this.lblBoxWidth.Size = new System.Drawing.Size(35, 12);
            this.lblBoxWidth.TabIndex = 29;
            this.lblBoxWidth.Text = "Width";
            // 
            // nmrcBaseHeight
            // 
            this.nmrcBaseHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nmrcBaseHeight.Location = new System.Drawing.Point(824, 122);
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
            this.nmrcBaseWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nmrcBaseWidth.Location = new System.Drawing.Point(824, 95);
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
            this.btnAlignLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlignLeft.BackColor = System.Drawing.Color.White;
            this.btnAlignLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAlignLeft.Location = new System.Drawing.Point(901, 608);
            this.btnAlignLeft.Name = "btnAlignLeft";
            this.btnAlignLeft.Size = new System.Drawing.Size(57, 50);
            this.btnAlignLeft.TabIndex = 33;
            this.btnAlignLeft.Text = "좌";
            this.btnAlignLeft.UseVisualStyleBackColor = false;
            // 
            // btnAlignRight
            // 
            this.btnAlignRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlignRight.BackColor = System.Drawing.Color.White;
            this.btnAlignRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAlignRight.Location = new System.Drawing.Point(964, 608);
            this.btnAlignRight.Name = "btnAlignRight";
            this.btnAlignRight.Size = new System.Drawing.Size(57, 50);
            this.btnAlignRight.TabIndex = 34;
            this.btnAlignRight.Text = "우";
            this.btnAlignRight.UseVisualStyleBackColor = false;
            // 
            // btnAlignTop
            // 
            this.btnAlignTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlignTop.BackColor = System.Drawing.Color.White;
            this.btnAlignTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAlignTop.Location = new System.Drawing.Point(775, 608);
            this.btnAlignTop.Name = "btnAlignTop";
            this.btnAlignTop.Size = new System.Drawing.Size(55, 50);
            this.btnAlignTop.TabIndex = 35;
            this.btnAlignTop.Text = "상";
            this.btnAlignTop.UseVisualStyleBackColor = false;
            // 
            // btnAlignBottom
            // 
            this.btnAlignBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlignBottom.BackColor = System.Drawing.Color.White;
            this.btnAlignBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAlignBottom.Location = new System.Drawing.Point(838, 608);
            this.btnAlignBottom.Name = "btnAlignBottom";
            this.btnAlignBottom.Size = new System.Drawing.Size(57, 50);
            this.btnAlignBottom.TabIndex = 36;
            this.btnAlignBottom.Text = "하";
            this.btnAlignBottom.UseVisualStyleBackColor = false;
            // 
            // lblAlignSide
            // 
            this.lblAlignSide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlignSide.AutoSize = true;
            this.lblAlignSide.Location = new System.Drawing.Point(773, 593);
            this.lblAlignSide.Name = "lblAlignSide";
            this.lblAlignSide.Size = new System.Drawing.Size(45, 12);
            this.lblAlignSide.TabIndex = 37;
            this.lblAlignSide.Text = "축 정렬";
            // 
            // lblLine
            // 
            this.lblLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(773, 321);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(57, 12);
            this.lblLine.TabIndex = 38;
            this.lblLine.Text = "라인 설정";
            // 
            // lblAlignRow
            // 
            this.lblAlignRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlignRow.AutoSize = true;
            this.lblAlignRow.Location = new System.Drawing.Point(773, 457);
            this.lblAlignRow.Name = "lblAlignRow";
            this.lblAlignRow.Size = new System.Drawing.Size(85, 12);
            this.lblAlignRow.TabIndex = 43;
            this.lblAlignRow.Text = "행 모서리 정렬";
            // 
            // btnLeftBot
            // 
            this.btnLeftBot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeftBot.BackColor = System.Drawing.Color.White;
            this.btnLeftBot.BackgroundImage = global::SectionManager.Properties.Resources.Arrow_7to5;
            this.btnLeftBot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeftBot.Location = new System.Drawing.Point(901, 472);
            this.btnLeftBot.Name = "btnLeftBot";
            this.btnLeftBot.Size = new System.Drawing.Size(57, 50);
            this.btnLeftBot.TabIndex = 47;
            this.btnLeftBot.UseVisualStyleBackColor = false;
            // 
            // btnRightBot
            // 
            this.btnRightBot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRightBot.BackColor = System.Drawing.Color.White;
            this.btnRightBot.BackgroundImage = global::SectionManager.Properties.Resources.Arrow_5to7;
            this.btnRightBot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRightBot.Location = new System.Drawing.Point(964, 472);
            this.btnRightBot.Name = "btnRightBot";
            this.btnRightBot.Size = new System.Drawing.Size(57, 50);
            this.btnRightBot.TabIndex = 45;
            this.btnRightBot.UseVisualStyleBackColor = false;
            // 
            // btnRightTop
            // 
            this.btnRightTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRightTop.BackColor = System.Drawing.Color.White;
            this.btnRightTop.BackgroundImage = global::SectionManager.Properties.Resources.Arrow_1to11;
            this.btnRightTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRightTop.Location = new System.Drawing.Point(838, 472);
            this.btnRightTop.Name = "btnRightTop";
            this.btnRightTop.Size = new System.Drawing.Size(57, 50);
            this.btnRightTop.TabIndex = 44;
            this.btnRightTop.UseVisualStyleBackColor = false;
            // 
            // btnBottomLeft
            // 
            this.btnBottomLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBottomLeft.BackColor = System.Drawing.Color.White;
            this.btnBottomLeft.BackgroundImage = global::SectionManager.Properties.Resources.Arrow_7to11;
            this.btnBottomLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBottomLeft.Location = new System.Drawing.Point(901, 540);
            this.btnBottomLeft.Name = "btnBottomLeft";
            this.btnBottomLeft.Size = new System.Drawing.Size(57, 50);
            this.btnBottomLeft.TabIndex = 52;
            this.btnBottomLeft.UseVisualStyleBackColor = false;
            // 
            // btnTopLeft
            // 
            this.btnTopLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTopLeft.BackColor = System.Drawing.Color.White;
            this.btnTopLeft.BackgroundImage = global::SectionManager.Properties.Resources.Arrow_11to7;
            this.btnTopLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTopLeft.Location = new System.Drawing.Point(775, 540);
            this.btnTopLeft.Name = "btnTopLeft";
            this.btnTopLeft.Size = new System.Drawing.Size(55, 50);
            this.btnTopLeft.TabIndex = 51;
            this.btnTopLeft.UseVisualStyleBackColor = false;
            // 
            // btnBottomRight
            // 
            this.btnBottomRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBottomRight.BackColor = System.Drawing.Color.White;
            this.btnBottomRight.BackgroundImage = global::SectionManager.Properties.Resources.Arrow_5to1;
            this.btnBottomRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBottomRight.Location = new System.Drawing.Point(964, 540);
            this.btnBottomRight.Name = "btnBottomRight";
            this.btnBottomRight.Size = new System.Drawing.Size(57, 50);
            this.btnBottomRight.TabIndex = 50;
            this.btnBottomRight.UseVisualStyleBackColor = false;
            // 
            // btnTopRight
            // 
            this.btnTopRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTopRight.BackColor = System.Drawing.Color.White;
            this.btnTopRight.BackgroundImage = global::SectionManager.Properties.Resources.Arrow_1to5;
            this.btnTopRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTopRight.Location = new System.Drawing.Point(838, 540);
            this.btnTopRight.Name = "btnTopRight";
            this.btnTopRight.Size = new System.Drawing.Size(57, 50);
            this.btnTopRight.TabIndex = 49;
            this.btnTopRight.UseVisualStyleBackColor = false;
            // 
            // lblAlignCol
            // 
            this.lblAlignCol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlignCol.AutoSize = true;
            this.lblAlignCol.Location = new System.Drawing.Point(773, 525);
            this.lblAlignCol.Name = "lblAlignCol";
            this.lblAlignCol.Size = new System.Drawing.Size(85, 12);
            this.lblAlignCol.TabIndex = 48;
            this.lblAlignCol.Text = "열 모서리 정렬";
            // 
            // c
            // 
            this.c.AutoSize = true;
            this.c.Location = new System.Drawing.Point(40, 20);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(66, 16);
            this.c.TabIndex = 53;
            this.c.TabStop = true;
            this.c.Tag = "1";
            this.c.Text = "PORT 1";
            this.c.UseVisualStyleBackColor = true;
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
            this.grpPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPort.Controls.Add(this.rdoPort2);
            this.grpPort.Controls.Add(this.c);
            this.grpPort.Location = new System.Drawing.Point(757, 3);
            this.grpPort.Name = "grpPort";
            this.grpPort.Size = new System.Drawing.Size(269, 48);
            this.grpPort.TabIndex = 55;
            this.grpPort.TabStop = false;
            this.grpPort.Text = "LAN Port";
            // 
            // cbxZoom
            // 
            this.cbxZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxZoom.FormattingEnabled = true;
            this.cbxZoom.Location = new System.Drawing.Point(682, 24);
            this.cbxZoom.Name = "cbxZoom";
            this.cbxZoom.Size = new System.Drawing.Size(58, 20);
            this.cbxZoom.TabIndex = 56;
            // 
            // lblZoom
            // 
            this.lblZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(606, 27);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(66, 12);
            this.lblZoom.TabIndex = 57;
            this.lblZoom.Text = "Zoom(%) :";
            // 
            // btnLeftTop
            // 
            this.btnLeftTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeftTop.BackColor = System.Drawing.Color.White;
            this.btnLeftTop.BackgroundImage = global::SectionManager.Properties.Resources.Arrow_11to1;
            this.btnLeftTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeftTop.Location = new System.Drawing.Point(775, 472);
            this.btnLeftTop.Name = "btnLeftTop";
            this.btnLeftTop.Size = new System.Drawing.Size(55, 50);
            this.btnLeftTop.TabIndex = 46;
            this.btnLeftTop.UseVisualStyleBackColor = false;
            // 
            // btnBTRL
            // 
            this.btnBTRL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBTRL.BackColor = System.Drawing.Color.White;
            this.btnBTRL.BackgroundImage = global::SectionManager.Properties.Resources.BTRL;
            this.btnBTRL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBTRL.Location = new System.Drawing.Point(964, 392);
            this.btnBTRL.Name = "btnBTRL";
            this.btnBTRL.Size = new System.Drawing.Size(57, 50);
            this.btnBTRL.TabIndex = 14;
            this.btnBTRL.UseVisualStyleBackColor = false;
            // 
            // btnTBRL
            // 
            this.btnTBRL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTBRL.BackColor = System.Drawing.Color.White;
            this.btnTBRL.BackgroundImage = global::SectionManager.Properties.Resources.TBRL;
            this.btnTBRL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTBRL.Location = new System.Drawing.Point(901, 392);
            this.btnTBRL.Name = "btnTBRL";
            this.btnTBRL.Size = new System.Drawing.Size(57, 50);
            this.btnTBRL.TabIndex = 13;
            this.btnTBRL.UseVisualStyleBackColor = false;
            // 
            // btnBTLR
            // 
            this.btnBTLR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBTLR.BackColor = System.Drawing.Color.White;
            this.btnBTLR.BackgroundImage = global::SectionManager.Properties.Resources.BTLR;
            this.btnBTLR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBTLR.Location = new System.Drawing.Point(838, 392);
            this.btnBTLR.Name = "btnBTLR";
            this.btnBTLR.Size = new System.Drawing.Size(57, 50);
            this.btnBTLR.TabIndex = 12;
            this.btnBTLR.UseVisualStyleBackColor = false;
            // 
            // btnTBLR
            // 
            this.btnTBLR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTBLR.BackColor = System.Drawing.Color.White;
            this.btnTBLR.BackgroundImage = global::SectionManager.Properties.Resources.TBLR;
            this.btnTBLR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTBLR.Location = new System.Drawing.Point(775, 392);
            this.btnTBLR.Name = "btnTBLR";
            this.btnTBLR.Size = new System.Drawing.Size(57, 50);
            this.btnTBLR.TabIndex = 11;
            this.btnTBLR.UseVisualStyleBackColor = false;
            // 
            // btnRLBT
            // 
            this.btnRLBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRLBT.BackColor = System.Drawing.Color.White;
            this.btnRLBT.BackgroundImage = global::SectionManager.Properties.Resources.RLBT;
            this.btnRLBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRLBT.Location = new System.Drawing.Point(964, 336);
            this.btnRLBT.Name = "btnRLBT";
            this.btnRLBT.Size = new System.Drawing.Size(57, 50);
            this.btnRLBT.TabIndex = 10;
            this.btnRLBT.UseVisualStyleBackColor = false;
            // 
            // btnLRBT
            // 
            this.btnLRBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLRBT.BackColor = System.Drawing.Color.White;
            this.btnLRBT.BackgroundImage = global::SectionManager.Properties.Resources.LRBT;
            this.btnLRBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLRBT.Location = new System.Drawing.Point(901, 336);
            this.btnLRBT.Name = "btnLRBT";
            this.btnLRBT.Size = new System.Drawing.Size(57, 50);
            this.btnLRBT.TabIndex = 9;
            this.btnLRBT.UseVisualStyleBackColor = false;
            // 
            // btnRLTB
            // 
            this.btnRLTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRLTB.BackColor = System.Drawing.Color.White;
            this.btnRLTB.BackgroundImage = global::SectionManager.Properties.Resources.RLTB;
            this.btnRLTB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRLTB.Location = new System.Drawing.Point(838, 336);
            this.btnRLTB.Name = "btnRLTB";
            this.btnRLTB.Size = new System.Drawing.Size(57, 50);
            this.btnRLTB.TabIndex = 8;
            this.btnRLTB.UseVisualStyleBackColor = false;
            // 
            // btnLRTB
            // 
            this.btnLRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLRTB.BackColor = System.Drawing.Color.White;
            this.btnLRTB.BackgroundImage = global::SectionManager.Properties.Resources.LRTB;
            this.btnLRTB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLRTB.Location = new System.Drawing.Point(775, 336);
            this.btnLRTB.Name = "btnLRTB";
            this.btnLRTB.Size = new System.Drawing.Size(57, 50);
            this.btnLRTB.TabIndex = 7;
            this.btnLRTB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnLRTB.UseVisualStyleBackColor = false;
            // 
            // tbxRctX
            // 
            this.tbxRctX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRctX.Location = new System.Drawing.Point(808, 154);
            this.tbxRctX.MaxLength = 5;
            this.tbxRctX.Name = "tbxRctX";
            this.tbxRctX.ShortcutsEnabled = false;
            this.tbxRctX.Size = new System.Drawing.Size(49, 21);
            this.tbxRctX.TabIndex = 58;
            // 
            // lblX
            // 
            this.lblX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(784, 158);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(13, 12);
            this.lblX.TabIndex = 60;
            this.lblX.Text = "X";
            // 
            // lblY
            // 
            this.lblY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(865, 158);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(13, 12);
            this.lblY.TabIndex = 61;
            this.lblY.Text = "Y";
            // 
            // btnSetPosDragbox
            // 
            this.btnSetPosDragbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetPosDragbox.Location = new System.Drawing.Point(955, 150);
            this.btnSetPosDragbox.Name = "btnSetPosDragbox";
            this.btnSetPosDragbox.Size = new System.Drawing.Size(71, 29);
            this.btnSetPosDragbox.TabIndex = 62;
            this.btnSetPosDragbox.Text = "좌표 설정";
            this.btnSetPosDragbox.UseVisualStyleBackColor = true;
            // 
            // tbxRctY
            // 
            this.tbxRctY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRctY.Location = new System.Drawing.Point(889, 154);
            this.tbxRctY.MaxLength = 5;
            this.tbxRctY.Name = "tbxRctY";
            this.tbxRctY.ShortcutsEnabled = false;
            this.tbxRctY.Size = new System.Drawing.Size(49, 21);
            this.tbxRctY.TabIndex = 63;
            // 
            // lblModule
            // 
            this.lblModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModule.AutoSize = true;
            this.lblModule.Location = new System.Drawing.Point(872, 66);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(55, 12);
            this.lblModule.TabIndex = 64;
            this.lblModule.Text = "Module :";
            // 
            // cbxModule
            // 
            this.cbxModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxModule.FormattingEnabled = true;
            this.cbxModule.Location = new System.Drawing.Point(945, 63);
            this.cbxModule.Name = "cbxModule";
            this.cbxModule.Size = new System.Drawing.Size(81, 20);
            this.cbxModule.TabIndex = 65;
            // 
            // sectionCtrl
            // 
            this.sectionCtrl.AutoScroll = true;
            this.sectionCtrl.BackColor = System.Drawing.Color.White;
            this.sectionCtrl.Location = new System.Drawing.Point(24, 33);
            this.sectionCtrl.Model = null;
            this.sectionCtrl.Name = "sectionCtrl";
            this.sectionCtrl.Size = new System.Drawing.Size(480, 422);
            this.sectionCtrl.TabIndex = 0;
            // 
            // SectionDrawerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.cbxModule);
            this.Controls.Add(this.lblModule);
            this.Controls.Add(this.tbxRctY);
            this.Controls.Add(this.btnSetPosDragbox);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.tbxRctX);
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
            this.Size = new System.Drawing.Size(1036, 661);
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
        private System.Windows.Forms.RadioButton c;
        private System.Windows.Forms.RadioButton rdoPort2;
        private System.Windows.Forms.GroupBox grpPort;
        private System.Windows.Forms.ComboBox cbxZoom;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.TextBox tbxRctX;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Button btnSetPosDragbox;
        private System.Windows.Forms.TextBox tbxRctY;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.ComboBox cbxModule;
    }
}

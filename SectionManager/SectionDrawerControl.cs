using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SectionManager.Drawer;
using SectionManager.Models;

namespace SectionManager {
    public partial class SectionDrawerControl : UserControl {

        private static readonly int MINIMUM_SIZE = 16;

        private DrawerModel model;

        public SectionDrawerControl() {
            InitializeComponent();
            InitializeEvent();
            InitializeValue();
        }

        private void InitializeValue() {
            DoubleBuffered = true;

            LoadValue();
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            CreateView();
        }

        private void InitializeEvent() {
            btnAdd.Click += (s, e) => CreateBox();
            nmrcBoxWidth.ValueChanged += (s, e) => BoxSizeValueChanged(s);
            nmrcBoxHeight.ValueChanged += (s, e) => BoxSizeValueChanged(s);
            nmrcBaseWidth.ValueChanged += (s, e) => BaseBoxValueChanged(s);
            nmrcBaseHeight.ValueChanged += (s, e) => BaseBoxValueChanged(s);
            sectionCtrl.BoxInfoRefreshEvent += (s, e) => BoxInfoChanged(e);

            btnLRTB.Click += (s, e) => sectionCtrl.QuickBridge(LineDirection.LRTB);
            btnRLTB.Click += (s, e) => sectionCtrl.QuickBridge(LineDirection.RLTB);
            btnLRBT.Click += (s, e) => sectionCtrl.QuickBridge(LineDirection.LRBT);
            btnRLBT.Click += (s, e) => sectionCtrl.QuickBridge(LineDirection.RLBT);
            btnTBLR.Click += (s, e) => sectionCtrl.QuickBridge(LineDirection.TBLR);
            btnBTLR.Click += (s, e) => sectionCtrl.QuickBridge(LineDirection.BTLR);
            btnTBRL.Click += (s, e) => sectionCtrl.QuickBridge(LineDirection.TBRL);
            btnBTRL.Click += (s, e) => sectionCtrl.QuickBridge(LineDirection.BTRL);

            btnDeleteBox.Click += (s, e) => sectionCtrl.DelBox();
            btnClearBox.Click += (s, e) => { sectionCtrl.ClearBox(); nmrcCol.Value = nmrcRow.Value = 0; };

            btnAlignTop.Click += (s, e) => sectionCtrl.QuickAlign(AlignDirection.Top);
            btnAlignBottom.Click += (s, e) => sectionCtrl.QuickAlign(AlignDirection.Bottom);
            btnAlignLeft.Click += (s, e) => sectionCtrl.QuickAlign(AlignDirection.Left);
            btnAlignRight.Click += (s, e) => sectionCtrl.QuickAlign(AlignDirection.Right);

            btnLeftTop.Click += (s, e) => sectionCtrl.QuickAlign(AlignDirection.LeftTop);
            btnRightTop.Click += (s, e) => sectionCtrl.QuickAlign(AlignDirection.RightTop);
            btnLeftBot.Click += (s, e) => sectionCtrl.QuickAlign(AlignDirection.LeftBottom);
            btnRightBot.Click += (s, e) => sectionCtrl.QuickAlign(AlignDirection.RightBottom);

            btnTopLeft.Click += (s, e) => sectionCtrl.QuickAlign(AlignDirection.TopLeft);
            btnTopRight.Click += (s, e) => sectionCtrl.QuickAlign(AlignDirection.TopRight);
            btnBottomLeft.Click += (s, e) => sectionCtrl.QuickAlign(AlignDirection.BottomLeft);
            btnBottomRight.Click += (s, e) => sectionCtrl.QuickAlign(AlignDirection.BottomRight);

            nmrcRow.ValueChanged += (s, e) => sectionCtrl.ResetGroup((int)nmrcRow.Value, (int)nmrcCol.Value, (int)nmrcBaseWidth.Value, (int)nmrcBaseHeight.Value);
            nmrcCol.ValueChanged += (s, e) => sectionCtrl.ResetGroup((int)nmrcRow.Value, (int)nmrcCol.Value, (int)nmrcBaseWidth.Value, (int)nmrcBaseHeight.Value);
        }

        private void BoxInfoChanged(Box box) {
            if (box.Description != string.Empty) { 
                nmrcPosX.Value = box != null ? box.RctX : 0;
                nmrcPosY.Value = box != null ? box.RctY : 0;
                nmrcBoxWidth.Value = box != null ? box.RctW : MINIMUM_SIZE;
                nmrcBoxHeight.Value = box != null ? box.RctH : MINIMUM_SIZE;
            }
        }

        private void BoxSizeValueChanged(object s) {
            if (s is NumericUpDown nmrc)
                nmrc.Value = ((int)nmrc.Value + MINIMUM_SIZE / 2) / MINIMUM_SIZE * MINIMUM_SIZE;
        }

        private void BaseBoxValueChanged(object s ) {
            if (s is NumericUpDown nmrc)
                nmrc.Value = ((int)nmrc.Value + MINIMUM_SIZE / 2) / MINIMUM_SIZE * MINIMUM_SIZE;
        }

        private void LoadValue() {
            // set value from saved file to model.

            // else
            if (model == null)
                model = new DrawerModel();

        }

        private void CreateView() {
            sectionCtrl.SetModelValue(model);
            sectionCtrl.SetViewSize(sectionCtrl.Width, sectionCtrl.Height);
            sectionCtrl.SetLayerSize(sectionCtrl.Width, sectionCtrl.Height);
        }

        // 새 Box 생성
        private void CreateBox() {
            sectionCtrl.RegistBox((int)nmrcBaseWidth.Value, (int)nmrcBaseHeight.Value);
        }

        // 새 박스 등록
        private void RegistBox() {
            
        }

        // 선택 박스 삭제
        private void DeleteBox() { 

        }

        protected override void OnHandleDestroyed(EventArgs e) {
            base.OnHandleDestroyed(e);
            sectionCtrl.RunThread = false;
            Thread.Sleep(50);
        }
    }
}

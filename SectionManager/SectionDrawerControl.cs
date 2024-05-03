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
            sectionCtrl.BoxInfoRefreshEvent += (s, e) => BoxInfoChanged(e);

            btnLRTB.Click += (s, e) => sectionCtrl.QuickBridgeLRTB();
            btnRLTB.Click += (s, e) => sectionCtrl.QuickBridgeRLTB();
            btnLRBT.Click += (s, e) => sectionCtrl.QuickBridgeLRBT();
            btnRLBT.Click += (s, e) => sectionCtrl.QuickBridgeRLBT();
            btnTBLR.Click += (s, e) => sectionCtrl.QuickBridgeTBLR();
            btnBTLR.Click += (s, e) => sectionCtrl.QuickBridgeBTLR();
            btnTBRL.Click += (s, e) => sectionCtrl.QuickBridgeTBRL();
            btnBTRL.Click += (s, e) => sectionCtrl.QuickBridgeBTRL();

            btnDeleteBox.Click += (s, e) => sectionCtrl.DelBox();
            btnClearBox.Click += (s, e) => sectionCtrl.ClearBox();
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
            sectionCtrl.RegistBox((int)nmrcBoxWidth.Value, (int)nmrcBoxHeight.Value);
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

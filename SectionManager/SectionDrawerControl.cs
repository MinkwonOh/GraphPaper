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

        internal DrawerModel Model { get => model; }

        private DrawerModel model;
        private BindingSource bs = new BindingSource();

        public SectionDrawerControl() {
            InitializeComponent();
            InitializeEvent();
            InitializeValue();
        }

        public SectionDrawerControl(DrawerModel model) : this() {
            this.model = model;
        }

        private void InitializeValue() {
            DoubleBuffered = true;

            sectionCtrl.Location = new Point(0,0);
            sectionCtrl.Size = new Size(pnlBackground.ClientSize.Width, pnlBackground.ClientSize.Height);
            sectionCtrl.SetBaseSize(sectionCtrl.Size);

            List<int> zoomVals = Enum.GetValues(typeof(ZoomPer)).Cast<int>().ToList();
            bs.DataSource = zoomVals;
            cbxZoom.DataSource = bs;
            cbxZoom.SelectedItem = (int)ZoomPer.z100;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            LoadValue();
            CreateView();
        }

        private void InitializeEvent() {
            btnAdd.Click += (s, e) => CreateBox();
            sectionCtrl.BoxInfoRefreshEvent += (s, e) => BoxInfoChanged(e);
            var rbList = grpPort.Controls.OfType<RadioButton>().ToList();
            sectionCtrl.PortAddedEvent += (s, e) => { var rb = rbList.Where(i => Int32.Parse(i.Tag.ToString()) == e+1).FirstOrDefault(); if(rb!=null) rb.Checked = true; };
            foreach (var rb in rbList) {
                rb.CheckedChanged += (s, e) => {
                    if (rb.Checked) {
                        sectionCtrl.SetModelPort(Int32.Parse(rb.Tag.ToString())-1);
                    }
                };
            }

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

        protected override void OnHandleDestroyed(EventArgs e) {
            base.OnHandleDestroyed(e);
            sectionCtrl.RunThread = false;
            Thread.Sleep(50);

        }
    }
}

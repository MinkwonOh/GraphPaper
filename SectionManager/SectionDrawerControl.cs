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

        [Browsable(false)]
        public DrawerModel Model { get { if (sectionCtrl == null) return null; else return sectionCtrl.Model; } set => sectionCtrl.Model = value; }

        //private DrawerModel model;
        private BindingSource bs = new BindingSource();
        private List<int> ListModuleIdx = new List<int>();

        public SectionDrawerControl() {
            InitializeComponent();
            InitializeEvent();
            InitializeValue();
        }

        public SectionDrawerControl(ref DrawerModel model) : this() {
            nmrcBaseWidth.Value = model.BoxWidth;
            nmrcBaseHeight.Value = model.BoxHeight;
            sectionCtrl.SetModelValue(ref model);
        }

        private void InitializeValue() {
            DoubleBuffered = true;
            for (int i = 0; i < 100; i++)
            {
                ListModuleIdx.Add(i);
            }
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
            var rbList = grpPort.Controls.OfType<RadioButton>().ToList();
            var rb = rbList.Where(i => (Model.SelectedPort > 0 ? Model.SelectedPort.ToString() : "1").Equals(i.Tag)).FirstOrDefault();
            if (rb != null)
                rb.Checked = true;

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

            nmrcBaseWidth.ValueChanged += (s, e) => sectionCtrl.SetBoxWidth((int)nmrcBaseWidth.Value);
            nmrcBaseHeight.ValueChanged += (s, e) => sectionCtrl.SetBoxHeight((int)nmrcBaseHeight.Value);

            pnlBackground.SizeChanged += (s, e) => SetControlSize(pnlBackground.ClientSize.Width, pnlBackground.ClientSize.Height);

            nmrcRow.ValueChanged += (s, e) => sectionCtrl.ResetGroup((int)nmrcRow.Value, (int)nmrcCol.Value, (int)nmrcBaseWidth.Value, (int)nmrcBaseHeight.Value);
            nmrcCol.ValueChanged += (s, e) => sectionCtrl.ResetGroup((int)nmrcRow.Value, (int)nmrcCol.Value, (int)nmrcBaseWidth.Value, (int)nmrcBaseHeight.Value);

            tbxRctX.KeyPress += (s, e) => OnlyNumberAllower(s, e);
            tbxRctY.KeyPress += (s, e) => OnlyNumberAllower(s, e);
            btnSetPosDragbox.Click += (s, e) => SetPositionOfDragbox();
            cbxModule.SelectedIndexChanged += (s, e) => ModuleIndexChanged();
        }
        
        private void ModuleIndexChanged()
        {
            int moduleIdx = cbxModule.SelectedIndex;
            if (moduleIdx == -1) return;

            if (sectionCtrl.Model != null)
            {
                sectionCtrl.Model.Module = moduleIdx;
            }
        }

        private void SetPositionOfDragbox() {
            sectionCtrl.SetPosOfDragbox(tbxRctX.Text.Length == 0 ? 0 : int.Parse(tbxRctX.Text), tbxRctY.Text.Length == 0 ? 0 : int.Parse(tbxRctY.Text));
        }

        private void OnlyNumberAllower(object s, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void BoxInfoChanged(Box box) {
            nmrcPosX.Value = box != null ? box.RctX : 0;
            nmrcPosY.Value = box != null ? box.RctY : 0;
            nmrcBoxWidth.Value = box != null ? box.RctW : MINIMUM_SIZE;
            nmrcBoxHeight.Value = box != null ? box.RctH : MINIMUM_SIZE;
        }

        private void LoadValue() {
            cbxModule.DataSource = ListModuleIdx;
            cbxModule.SelectedIndex = sectionCtrl?.Model?.Module ?? 0;
        }

        private void CreateView() {
            if (sectionCtrl.Model == null)
            {
                var dm = new DrawerModel();
                sectionCtrl.SetModelValue(ref dm);
            }
            sectionCtrl.SetViewSize(sectionCtrl.Width, sectionCtrl.Height);
            sectionCtrl.SetLayerSize(sectionCtrl.Width, sectionCtrl.Height);
        }

        // 새 Box 생성
        private void CreateBox() {
            sectionCtrl.RegistBox((int)nmrcBaseWidth.Value, (int)nmrcBaseHeight.Value);
        }

        public void SetControlSize(int w, int h) {
            var size = new Size(w, h);
            sectionCtrl.SetBaseSize(size);
            sectionCtrl.Size = size;
            sectionCtrl.SetViewSize(w, h);
            sectionCtrl.ModLayerSize(w, h);
        }

        protected override void OnHandleDestroyed(EventArgs e) {
            base.OnHandleDestroyed(e);
            sectionCtrl.RunThread = false;
            Thread.Sleep(50);

        }
    }
}

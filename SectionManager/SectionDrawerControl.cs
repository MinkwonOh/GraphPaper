using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SectionManager.Drawer;
using SectionManager.Models;

namespace SectionManager {
    public partial class SectionDrawerControl : UserControl {

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
        }

        private void LoadValue() {
            // set value from saved file to model.

            // else
            if (model == null) {
                model = new DrawerModel();
            }

        }

        private void CreateView() {
            sectionCtrl.SetModelValue(model);
            sectionCtrl.SetViewSize(Width,Height);
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
            sectionCtrl.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            model = new DrawerModel();
            LoadValue();

        }

        private void InitializeEvent() {
            btnAdd.Click += (s, e) => CreateBox();
        }

        private void LoadValue() { 
            // set value to model
        }

        // 새 Box 생성
        private void CreateBox() {
            
        }

        // 새 박스 등록
        private void RegistBox() {
            
        }

        // 선택 박스 삭제
        private void DeleteBox() { 

        }


    }
}

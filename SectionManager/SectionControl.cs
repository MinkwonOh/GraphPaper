using SectionManager.Drawer;
using SectionManager.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SectionManager {
    public class SectionControl : Control {

        private Layer layer;
        private BoxGroup boxGroup;
        private Bitmap bitmap;
        private Size boxSize;

        public SectionControl() {
            DoubleBuffered = true;
            boxGroup = new BoxGroup();
        }

        public SectionControl(BoxGroup boxGroup) : this() {
            this.boxGroup = boxGroup;
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            /*
            
            배경은 아무리 커도 이미지를 잘라서 표출, 
            그려지는 박스들의 사이즈 중 캔버스를 벗어나는 사이즈가 있으면 
            overflow되는 사이즈 + a 값만큼 캔버스 다시 그리고 해당 방향에 스크롤을 넣어준다.
            배경은 박스가 추가되거나 움직였을때 사이즈가 변동되었다는 이벤트를 발생시켜 SectionControl에서 감지한다
            

            */
        }

        public void RegistBox(int width, int height) { 

        }
        public void DeleteBox() { }

        public void SetBoxSize(int width, int height) {
            boxSize = new Size(width, height);

            // draw background
            // 그리드를 해당 사이즈로 조절
        }


    }
}

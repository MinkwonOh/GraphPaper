using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SectionManager.Models {

    // 파일로 저장할 전체 관리 데이터
    public class DrawerModel {

        // 박스그룹 리스트
        // 확대비율
        // standard모드? => 고정비율로 계산.
        // 

    }

    // 사각형 정보
    public class Box {
        public int NetPort { get; set; }
        public int CardIDX { get; set; }
        public Rectangle Rect { get; set; }
        public int RctX { get => Rect.X; set => Rect = new Rectangle(value < 0 ? 0 : value % int.MaxValue, Rect.Y, Rect.Width, Rect.Height); }
        public int RctY { get => Rect.Y; set => Rect = new Rectangle(Rect.X, value < 0 ? 0 : value % int.MaxValue, Rect.Width, Rect.Height); }
        public int RctW { get => Rect.Width; set => Rect = new Rectangle(Rect.X, Rect.Y, value < 0 ? 0 : value % int.MaxValue, Rect.Height); }
        public int RctH { get => Rect.Height; set => Rect = new Rectangle(Rect.X, Rect.Y, Rect.Width, value < 0 ? 0 : value % int.MaxValue); }
    }

    // 관리되는 사각형 리스트 정보
    public class BoxGroup {
        public IList<Box> BoxList;
        public Color BoxColor;
        public int LineLength;
        public int MaxLength;
        

    }

    /*// 그리는 객체
    public class BoxDrawer {



        public BoxDrawer() { 

        }

        // 빠른 설치
        // 1픽셀이라도 앞서있으면 라인변경 처리
        // 같은 라인이면 진행 방향 그대로 그리기
        public void DrawLRTB() {
            // left 1st 박스 그룹 선택

        }


        public void DrawRLTB() {
        }


        public void DrawLRBT() {
        }


        public void DrawRLBT() {
        }


        public void DrawTBLR() {
        }


        public void DrawBTLR() {
        }


        public void DrawTBRL() {
        }


        public void DrawBTRL() {
        }
    }*/
}

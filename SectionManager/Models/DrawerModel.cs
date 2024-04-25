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
        public List<BoxGroup> BoxGroupList;
        public int selectedIndex { get; set; }

        // 확대비율(100% 기준)
        public ZoomPer viewSize = ZoomPer.z100;

        // standard모드? => 고정비율로 계산.
        private bool isStandardMode;

        // 현재 정보
        private int _row;
        private int _col;
        private Rectangle _rect;

        // 박스 정보
        private int _boxWidth;
        private int _boxHeight;

        // 숨김 여부
        private bool isGroupHide;
    }

    // 관리되는 사각형 리스트 정보
    public class BoxGroup {
        public static readonly int MAX_LENGTH = 655360;
        public int Port;
        public List<Box> BoxList;
        public int[] selectedIndex;
        public int[] order;
        public Color BoxColor = Color.LemonChiffon;
        public int LineLength { get => BoxList.ToList().Sum(i => i.RctW); }
        public float PortRoagd { get => LineLength / MAX_LENGTH; }
    }

    // 사각형 정보
    public class Box {
        public Rectangle Rect { get; set; }
        public Box() {}
        public int RctX { get => Rect.X; set => Rect = new Rectangle(value < 0 ? 0 : value % int.MaxValue, Rect.Y, Rect.Width, Rect.Height); }
        public int RctY { get => Rect.Y; set => Rect = new Rectangle(Rect.X, value < 0 ? 0 : value % int.MaxValue, Rect.Width, Rect.Height); }
        public int RctW { get => Rect.Width; set => Rect = new Rectangle(Rect.X, Rect.Y, value < 0 ? 0 : value % int.MaxValue, Rect.Height); }
        public int RctH { get => Rect.Height; set => Rect = new Rectangle(Rect.X, Rect.Y, Rect.Width, value < 0 ? 0 : value % int.MaxValue); }
        public int tagPort { get; set; }
        public int tagCard { get; set; }
        public string description { get; set; }

    }

    public enum ZoomPer { 
        z20 = 20,
        z30 = 30,
        z40 = 40,
        z50 = 50,
        z60 = 60,
        z70 = 70,
        z80 = 80,
        z90 = 90,
        z100 = 100,
        z110 = 110,
        z120 = 120,
        z130 = 130,
        z140 = 140,
        z150 = 150,
        z160 = 160,
        z170 = 170,
        z180 = 180,
        z190 = 190,
        z200 = 200,
        z300 = 300,
        z500 = 500,
    }
}

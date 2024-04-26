using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SectionManager.Models {

    // 파일로 저장할 전체 관리 데이터
    public class DrawerModel {

        #region Vars

        // 박스그룹 리스트
        private List<BoxGroup> _boxGroupList;
        private int _index = -1;
        // 확대비율(100% 기준)
        public ZoomPer zoom = ZoomPer.z100;
        // standard모드? => 고정비율로 계산.
        private bool _isStandardMode;
        // 현재 정보
        private int _row;
        private int _col;
        private Rectangle _rect;
        // 박스 정보
        private int _boxWidth = 16;
        private int _boxHeight = 16;
        // 숨김 여부
        private bool _isGroupHide;

        #endregion


        #region Properties
        public List<BoxGroup> BoxGroupList { get => _boxGroupList; set => _boxGroupList = value; }
        public int SelectedIndex { get => _index; set => _index = value; }
        public bool IsStandardMode { get => _isStandardMode; set => _isStandardMode = value; }
        public int Row { get => _row; set => _row = value; }
        public int Col { get => _col; set => _col = value; }
        public Rectangle Rectangle { get => _rect; set => _rect = value; }
        public int BoxWidth { get => _boxWidth; set => _boxWidth = value; }
        public int BoxHeight { get => _boxHeight; set => _boxHeight = value; }
        public bool IsGroupHide { get => _isGroupHide; set => _isGroupHide = value; }

        #endregion

        public DrawerModel() {
            _boxGroupList = new List<BoxGroup>();
        }

        public void AppendBoxGroup() {
            AppendBoxGroup(_boxGroupList.Count);
        }

        public void AppendBoxGroup(int idx) {
            var boxGroup = new BoxGroup(idx);
            _boxGroupList.Add(boxGroup);
            SelectedIndex = _boxGroupList.IndexOf(boxGroup);
        }

        public void AppendBox() {
            if (_boxGroupList.Count == 0) { 
                AppendBoxGroup(0);
            }
            _boxGroupList[SelectedIndex].AppendBox();
        }

        public void AppendBox(int width, int height) {
            AppendBox();
            var box = _boxGroupList[SelectedIndex].BoxList.Last();
            box.RctW = width;
            box.RctH = height;
        }
    }

    // 관리되는 사각형 리스트 정보
    public class BoxGroup {
        public static readonly int MAX_LENGTH = 655360;
        public int Port;
        public List<Box> BoxList;
        public Queue<int> selectedIndex = new Queue<int>();
        public Queue<int> order = new Queue<int>();
        public Color BoxColor = Color.LemonChiffon;
        public int LineLength { get => BoxList.ToList().Sum(i => i.RctW); }
        public float PortRoagd { get => LineLength / MAX_LENGTH; }

        public BoxGroup(int port) {
            Port = port;
            BoxList = new List<Box>(port);
        }

        public void AppendBox(int port) {
            BoxList.Add(new Box(port));
            selectedIndex.Append(port);
            //selectedindex changed 될때 이벤트 처리 피요
        }

        public void AppendBox() {
            AppendBox(BoxList.Count);
        }
    }

    // 사각형 정보
    public class Box {
        private static readonly int MINIMUM_SIZE = 16;
        public Rectangle Rect { get; set; }
        public Box(int port) {
            Rect = new Rectangle(0, 0, MINIMUM_SIZE, MINIMUM_SIZE);
            tagPort = port;
        }
        public int RctX { get => Rect.X; set => Rect = new Rectangle(value < 0 ? 0 : value % int.MaxValue, Rect.Y, Rect.Width, Rect.Height); }
        public int RctY { get => Rect.Y; set => Rect = new Rectangle(Rect.X, value < 0 ? 0 : value % int.MaxValue, Rect.Width, Rect.Height); }
        public int RctW { get => Rect.Width; set => Rect = new Rectangle(Rect.X, Rect.Y, value < 0 ? 0 : value % int.MaxValue, Rect.Height); }
        public int RctH { get => Rect.Height; set => Rect = new Rectangle(Rect.X, Rect.Y, Rect.Width, value < 0 ? 0 : value % int.MaxValue); }
        public int tagPort { get; set; }
        public int tagCard { get; set; }
        public string Description { get => $"Port:{tagPort}\nCard:{tagCard},\nX:{RctX}\nY:{RctY}\nWidth:{RctW}\nHeight:{RctH}\n"; }

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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SectionManager.Models {

    // 파일로 저장할 전체 관리 데이터
    public class DrawerModel {

        #region
        public EventHandler<int> PortAddedEvent;
        #endregion

        #region Vars
        private static readonly int MINIMUM_SIZE = 16;

        // 박스그룹 리스트
        private List<BoxGroup> _boxGroupList;
        private int _port = -1;
        // 확대비율(100% 기준)
        public ZoomPer zoom = ZoomPer.z100;
        // standard모드? => 고정비율로 계산.
        private bool _isStandardMode;
        // 현재 정보
        private int _row;
        private int _col;
        private Rectangle _rect;
        // 박스 정보
        private int _boxWidth = MINIMUM_SIZE;
        private int _boxHeight = MINIMUM_SIZE;
        // 숨김 여부
        private bool _isGroupHide;

        #endregion


        #region Properties
        public List<BoxGroup> BoxGroupList { get => _boxGroupList; set => _boxGroupList = value; }
        public int SelectedPort { get => _port; set => _port = value; }
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
            SelectedPort = _boxGroupList.IndexOf(boxGroup);
            PortAddedEvent.Invoke(this, SelectedPort);
        }

        public void AppendBox() {
            if (_boxGroupList.Count == 0) 
                AppendBoxGroup(0);

            if (_boxGroupList.Count <= SelectedPort)
                AppendBoxGroup(SelectedPort);
            _boxGroupList[SelectedPort].AppendBox();
        }

        public void AppendBox(int width, int height) {
            AppendBox();
            var box = _boxGroupList[SelectedPort].BoxList.Last();
            box.RctW = width;
            box.RctH = height;
        }

        public void AppendBox(Rectangle rect) {
            AppendBox(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void AppendBox(int x, int y, int w, int h) {
            AppendBox();
            var box = _boxGroupList[SelectedPort].BoxList.Last();
            box.RctX = x;
            box.RctY = y;
            box.RctW = w;
            box.RctH = h;
        }
    }

    // 관리되는 사각형 리스트 정보
    public class BoxGroup {
        public static readonly int MAX_LENGTH = 655360;
        public int Port;
        public List<Box> BoxList;
        public List<(int, int)> _lstLinker = new List<(int, int)>();
        public Color BoxColor = Color.LemonChiffon;
        public int LineLength { get => BoxList.ToList().Sum(i => i.RctW); }
        public float PortRoagd { get => LineLength / MAX_LENGTH; }

        public BoxGroup(int port) {
            Port = port;
            BoxList = new List<Box>(port);
        }

        public void AppendBox(int port) {
            var box = new Box(port) { tagCard = BoxList.Count};
            for (int i = 0; i < BoxList.Count; i++) {
                if (BoxList.Where(j => j.tagCard == i).FirstOrDefault() == null) {
                    box.tagCard = i;
                    break;
                };
            }
            BoxList.Add(box);
        }

        public void AddLinker() {
            //int lastCardIdx = _lstLinker.Count <= 0 ? -1 : _lstLinker[newIdx - 1].Item1;

            /*for (int i = 0; i < BoxList.Count; i++) {
                var existBox = BoxList.Where(j => j.tagCard == i).FirstOrDefault();
                if (existBox == null) { 
                    newIdx = i;
                    break;
                }
            }*/
            var _lastBox = BoxList.LastOrDefault();
            
            (int, int) linker = (_lastBox == null ? 0 : _lastBox.tagCard, -1);

            if (_lstLinker.Count > 0) {
                var lastItem = _lstLinker.LastOrDefault();
                if (!(lastItem.Item1 == 0 && lastItem.Item2 == 0)) { 
                    lastItem.Item2 = linker.Item1;
                    _lstLinker[_lstLinker.Count - 1] = lastItem;
                }
            }

            _lstLinker.Add(linker);

        }

        public void DelLinker(Box box) {
            if (box == null) return;

            int card = box.tagCard;

            var self = _lstLinker.Where(i => i.Item1 == card).FirstOrDefault();
            if (!(self.Item1 == 0 && self.Item2 == 0)) {

                int selfIdx = _lstLinker.IndexOf(self);

                if (selfIdx != 0){
                    var child = _lstLinker.Where(i => i.Item2 == card).FirstOrDefault();
                    if (!(child.Item1 == 0 && child.Item2 == 0)) {
                        int childIdx = _lstLinker.IndexOf(child);

                        var newChild = _lstLinker[childIdx];
                        // 마지막노드, 중간노드 삭제
                        newChild.Item2 = selfIdx == _lstLinker.Count - 1 ? -1 : self.Item2;
                        _lstLinker[childIdx] = newChild;
                    }
                }
                
                _lstLinker.Remove(self);

                Reorder();
            }
        }

        public void DelLinker() { 

        }

        public void ClearBoxLinker() {
            _lstLinker.Clear();
        }

        public void AppendBox() {
            AppendBox(Port);
        }

        public void ToTop(Box box) {
            if (BoxList.Contains(box) && BoxList.Count >= 2) {
                var tmp = BoxList.Last();
                int srcIdx = BoxList.IndexOf(box);
                BoxList[BoxList.Count - 1] = box;
                BoxList[srcIdx] = tmp;
            }
        }

        public void ToTop(int idx) {
            if (BoxList.Count > idx && BoxList.Count >= 2) {
                var tmp = BoxList.Last();
                BoxList[BoxList.Count - 1] = BoxList[idx];
                BoxList[idx] = tmp;
            }
        }

        public Rectangle SelectionRect() {
            var resultRect = new Rectangle();
            int maxX, maxY;

            var selBoxList = BoxList.Where(i => i.Selected).ToList();
            if (selBoxList != null || selBoxList.Count != 0) {
                resultRect = selBoxList[0].Rect;
                maxX = resultRect.X + resultRect.Width;
                maxY = resultRect.Y + resultRect.Height;
                foreach (var box in selBoxList) {
                    if (box.Rect.X < resultRect.X)
                        resultRect.X = box.Rect.X;
                    if (box.Rect.Y < resultRect.Y)
                        resultRect.Y = box.Rect.Y;
                    if (resultRect.Width < box.Rect.X + box.Rect.Width)
                        resultRect.Width = box.Rect.X + box.Rect.Width;
                    if (resultRect.Height < box.Rect.Y + box.Rect.Height)
                        resultRect.Height = box.Rect.Y + box.Rect.Height;
                    //maxX = box.Rect.X + box.Rect.Width
                    //maxY
                }
            }


            return resultRect;
        }

        private void Reorder() {
            for (int i = 0; i < _lstLinker.Count; i++) {
                var box = BoxList.Where(p => p.tagCard == _lstLinker[i].Item1).FirstOrDefault();
                var newChild = _lstLinker[i];
                newChild.Item1 = i;
                newChild.Item2 = i == _lstLinker.Count ? -1 : i + 1;
                _lstLinker[i] = newChild;

                if (box != null) {
                    box.tagCard = i;
                }
            }
        }
    }

    // 사각형 정보
    public class Box {
        public Bitmap Bitmap { get {  return _bitmap; } }
        public Color BorderColor { get => _borderColor; set => _borderColor = value; }
        public Color FillColor { get => _fillColor; set => _fillColor = value; }
        public SolidBrush TxtBrush { get => _txtBrush; set => _txtBrush = value; }
        public int BorderWidth { get => _borderWidth; set => _borderWidth = value; }


        private Bitmap _bitmap;
        private Color _borderColor = Color.Black;
        private Color _fillColor = Color.Transparent;
        public SolidBrush _txtBrush = new SolidBrush(Color.Black);
        private int _borderWidth = 1;


        private StringFormat sf = new StringFormat()
        {
            LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };

        private static readonly int MINIMUM_SIZE = 16;

        public Rectangle Rect { get; set; }
        public Box(int port) {
            Rect = new Rectangle(0, 0, MINIMUM_SIZE, MINIMUM_SIZE);
            var colorName = Enum.GetName(typeof(ColorSpec), port >= Enum.GetNames(typeof(ColorSpec)).Length ? 1 : port+1);

            _bitmap = new Bitmap(MINIMUM_SIZE, MINIMUM_SIZE);

            if (colorName != null)
                _fillColor = Color.FromName(colorName);

            tagPort = port;

            DrawFullBmp();

        }

        private void RefreshBitmap() {
            _bitmap = new Bitmap(Rect.X, Rect.Y);
            DrawFullBmp();
        }

        private void DrawFullBmp() {
            if(tagPort >= 0)
                Console.WriteLine("DrawFullBmp");
            _bitmap = new Bitmap(Rect.Width, Rect.Height);
            using (var g = Graphics.FromImage(_bitmap))
            {
                g.Clear(FillColor);
                g.DrawRectangle(new Pen(new SolidBrush(_borderColor), _borderWidth), new Rectangle(0,0,Rect.Width, Rect.Height));
                //g.FillRectangle(new SolidBrush(_fillColor), new Rectangle(0,0,Rect.Width,Rect.Height));
            }
        }

        public bool Selected { get; set; }
        public int RctX { get => Rect.X; set => Rect = new Rectangle(value < 0 ? 0 : value % int.MaxValue, Rect.Y, Rect.Width, Rect.Height); }
        public int RctY { get => Rect.Y; set => Rect = new Rectangle(Rect.X, value < 0 ? 0 : value % int.MaxValue, Rect.Width, Rect.Height); }
        public int RctW { 
            get => Rect.Width; 
            set {
                //value = value < 0 ? MINIMUM_SIZE : value;
                int x = RctW > RctX + value ? RctW - value : Rect.X;
                Rect = new Rectangle(x, Rect.Y, value % int.MaxValue, Rect.Height); 
                if(Rect.Width > 0 && Rect.Height > 0)
                    DrawFullBmp();
            } 
        }
        public int RctH { 
            get => Rect.Height; 
            set {
                //value = value < 0 ? MINIMUM_SIZE : value;
                int y = RctH > RctY + value ? RctH - value : Rect.Y;
                Rect = new Rectangle(Rect.X, y, Rect.Width,value % int.MaxValue);
                if (Rect.Width > 0 && Rect.Height > 0)
                    DrawFullBmp();
            } 
        }
        public int MidX { get => RctX + RctW / 2; }
        public int MidY { get => RctY + RctH / 2; }

        public int tagPort { get; set; }
        public int tagCard { get ; set; }
        public string Description { get => tagPort == -1 ? string.Empty : $"Port:{tagPort}\nCard:{tagCard+1}\nX:{RctX}\nY:{RctY}\nWidth:{RctW}\nHeight:{RctH}\n"; }
        public bool HasPoint(Point pt) {

            int x = pt.X;
            int y = pt.Y;

            bool hasPoint = false;

            if ((RctX <= x && x <= RctX + RctW) && (RctY <= y && y <= RctY+RctH)) {
                hasPoint = true;
            }

            return hasPoint;
        }

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

    public enum BoxState {
        None,
        Select,
        Move
    }

    public enum LineDirection { 
        LRTB,
        RLTB,
        RLBT,
        LRBT,
        TBLR,
        BTLR,
        TBRL,
        BTRL
    }

    public enum AlignDirection { 
        Top,
        Bottom,
        Left,
        Right,
        LeftTop,
        RightTop,
        LeftBottom,
        RightBottom,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    public enum ColorSpec { 
        Transparent,
        Aquamarine,
        Beige,
        Bisque,
        Brown,
        //BurlyWood,
        CadetBlue,
        //Chartreuse,
        Crimson,
        //Gold,
        Olive,
        DodgerBlue,
        Violet,
        //Yellow,
        //Green
    }
}

using SectionManager.Drawer;
using SectionManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SectionManager {
    public class SectionControl : UserControl, IDisposable {

        private static readonly int MINIMUM_SIZE = 16;

        public EventHandler<Box> BoxInfoRefreshEvent;
        public EventHandler<(int, int)> LayerSizeChangeEvent;
        public EventHandler<int> PortAddedEvent;
        public DrawerModel Model { get => _model; set => _model = value; }

        private Bitmap StartImg = Properties.Resources.Start;
        private Bitmap FinishImg = Properties.Resources.Finish;
        private int[] drawingOrder;

        private Layer layer;
        private Rectangle box;
        private ZoomPer zoom = ZoomPer.z100;
        private DrawerModel _model;
        private Box _dradBox;
        private bool _mousePressed;
        private Point _pressedPoint;
        private Size _baseSize;
        public ZoomPer Zoom { set => zoom = value; }

        private bool thRunning;
        private Thread thUpdate;

        private object paintLock = new object();
        private object thLock = new object();

        public bool RunThread { set => thRunning = value; }

        private BoxState _boxState = BoxState.None;
        private Stack Z_Index = new Stack();
        private Pen BlackPen, PinkPen, BluePen, RedPen;
        private Pen BlackBorderPen, PinkBorderPen, BlueBorderPen, RedBorderPen, RedBorderPenHalf, BlueBorderDashPen;
        private SolidBrush BlackBrush, BlueBrush;
        private Size GapXY;
        private StringFormat sf;
        private List<Color> ColorList = new List<Color> { 
            Color.Transparent, Color.Aquamarine, Color.Beige, Color.Bisque, Color.CadetBlue,
            Color.Crimson,  Color.Olive,  Color.DodgerBlue,  Color.Violet
        };

        public SectionControl() {
            DoubleBuffered = true;
            AutoScroll = true;

            box = new Rectangle(0,0, MINIMUM_SIZE, MINIMUM_SIZE);

            InitializeEvent();
            InitializeValue();

            thRunning = true;
            thUpdate = new Thread(() => BoxUpdate());
            thUpdate.Name = "THUPDATE";
            thUpdate.Start();
        }

        

        private void InitializeEvent() {
        }

        private void InitializeValue() {
            // pens
            BlackPen = new Pen(Color.Black, 1);
            PinkPen = new Pen(Color.Pink, 1);
            BluePen = new Pen(Color.Blue, 1);
            RedPen = new Pen(Color.Red, 1);

            BlackBorderPen = new Pen(Color.Black, 2);
            PinkBorderPen = new Pen(Color.Pink, 2);
            BlueBorderPen = new Pen(Color.Blue, 2);
            RedBorderPen = new Pen(Color.Red, 2);
            RedBorderPenHalf = new Pen(Color.Red, 2);

            BlueBorderDashPen = new Pen(Color.Blue, 2) { DashStyle = DashStyle.Dash };

            BlackPen.Alignment = PinkPen.Alignment = RedPen.Alignment = BluePen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

            // brushes
            BlackBrush = new SolidBrush(Color.Black);
            BlueBrush = new SolidBrush(Color.Blue);

            // stringformat
            sf = new StringFormat() { 
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };

            _dradBox = new Box(-1) { RctW = 0, RctH = 0};
            _pressedPoint = new Point(0,0);
        }

        /*//
             * 
             * 선택 > 마우스 다운,업 포인트 동일, 
             * 움직임 > 
             * 정지 > 마우스 업
             * 
             * 
        //*/

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            _mousePressed = true;
            _pressedPoint.X = e.X;
            _pressedPoint.Y = e.Y;
            if (e.Button == MouseButtons.Left) {
                _dradBox.Selected = false;
                Point pt = e.Location;
                // 리스트 역순으로 area 먼저 겹치는 객체를 move
                switch (_boxState) {
                    case BoxState.None:
                        if (_model.BoxGroupList == null || _model.BoxGroupList.Count <= 0) return;
                        var lstBox = _model.BoxGroupList[_model.SelectedPort].BoxList;

                        // 마우스 다운 경우의수
                        // drag상자 선택 안되고 Contain 상자도 없음 > 영역 밖
                        // drag 상자 선택 안되고 Contain 상자 > 새 단일 상자 선택
                        //  > ***** 드래그 상자 없어져야함
                        // drag상자 선택 > 영역 내

                        if (!_dradBox.Rect.Contains(pt)) {
                            if (lstBox.Where(i => i.Rect.Contains(pt)).ToList().Count == 0) {
                                // 영역 밖
                                _dradBox.Rect = new Rectangle { 
                                    X = e.X,
                                    Y = e.Y,
                                    Width = 0,
                                    Height = 0
                                };
                                
                                BoxInfoRefreshEvent?.Invoke(this, _dradBox);
                            }
                            else {
                                // 새 단일 상자 선택
                                _boxState = BoxState.Move;
                                //var lastBox = lstBox.Where(i => i.Rect.Contains(pt)).LastOrDefault();

                                lstBox.ForEach(i => i.Selected = false);
                                var selectBox = lstBox.Where(i => i.Rect.Contains(pt)).LastOrDefault();
                                if (selectBox != null) {
                                    lstBox.Remove(selectBox);
                                    lstBox.Add(selectBox);
                                    selectBox.Selected = true;
                                    GapXY = new Size(pt.X - selectBox.RctX, pt.Y - selectBox.RctY);
                                }
                                _dradBox.Rect = selectBox.Rect;
                                _dradBox.Selected = true;
                                BoxInfoRefreshEvent?.Invoke(this,selectBox);
                            }
                        }
                        else {
                            // 영역 내
                            _boxState = BoxState.Move;
                            var rects = lstBox.Where(i => _dradBox.Rect.Contains(i.Rect)).ToList();

                            //lstBox.ForEach(i => i.Selected = false);

                            GapXY = new Size(pt.X - _dradBox.RctX, pt.Y - _dradBox.RctY);
                            
                            //lstBox.Where(i => _dradBox.Rect.Contains(i.Rect)).ToList().ForEach(i => i.Selected = true);
                            _dradBox.Selected = true;
                            BoxInfoRefreshEvent?.Invoke(this, _dradBox);
                        }

                        break;
                    case BoxState.Select:
                        break;
                    case BoxState.Move:
                        // 나중에 수정.. 아예 switch 위쪽에서 선처리?
                        _boxState = BoxState.None;
                        break;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left) { 
                Point pt = e.Location;
                switch (_boxState) {
                    case BoxState.None:
                        if (_mousePressed) {
                            _dradBox.RctX = Math.Min(e.X < 0 ? 0 : e.X, _pressedPoint.X);
                            _dradBox.RctY = Math.Min(e.Y < 0 ? 0 : e.Y, _pressedPoint.Y);
                            _dradBox.RctW = Math.Max(e.X < 0 ? 0 : e.X, _pressedPoint.X) - Math.Min(e.X < 0 ? 0 : e.X, _pressedPoint.X);
                            _dradBox.RctH = Math.Max(e.Y < 0 ? 0 : e.Y, _pressedPoint.Y) - Math.Min(e.Y < 0 ? 0 : e.Y, _pressedPoint.Y);
                            BoxInfoRefreshEvent?.Invoke(this, _dradBox);
                        }
                        break;
                    case BoxState.Select:
                        break;
                    case BoxState.Move:
                        // 드래그상자, 그냥 박스 누르고 있을때
                        // 드래그상자 있으면 드래그 상자 움직임,
                        // selected된 상자들은 GapXY 계산해서 옮기기
                        var bgl = _model.BoxGroupList[_model.SelectedPort];
                        var lstBox = bgl.BoxList;

                        if (_mousePressed) {

                            var lstSelBox = lstBox.Where(i => i.Selected == true).ToList();

                            Point prvDragPt = new Point(_dradBox.RctX, _dradBox.RctY);

                            _dradBox.RctX = pt.X - GapXY.Width;
                            _dradBox.RctY = pt.Y - GapXY.Height;

                            int mvX = _dradBox.RctX - prvDragPt.X;
                            int mvY = _dradBox.RctY - prvDragPt.Y;

                            foreach (var selBox in lstSelBox) {
                                selBox.RctX += mvX;
                                selBox.RctY += mvY;
                            }
                            BoxInfoRefreshEvent?.Invoke(this, _dradBox);
                        }
                        
                        Invalidate(false);
                        break;
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left) {
                Point pt = e.Location;
                switch (_boxState) {
                    case BoxState.None:
                        if (_model.SelectedPort < 0 || _model.BoxGroupList.Count == 0) {
                            _dradBox.Rect = new Rectangle();
                            return;
                        }

                        _dradBox.RctX = Math.Min(e.X < 0 ? 0 : e.X, _pressedPoint.X);
                        _dradBox.RctY = Math.Min(e.Y < 0 ? 0 : e.Y, _pressedPoint.Y);
                        _dradBox.RctW = Math.Max(e.X < 0 ? 0 : e.X, _pressedPoint.X) - Math.Min(e.X < 0 ? 0 : e.X, _pressedPoint.X);
                        _dradBox.RctH = Math.Max(e.Y < 0 ? 0 : e.Y, _pressedPoint.Y) - Math.Min(e.Y < 0 ? 0 : e.Y, _pressedPoint.Y);

                        var bgl = _model.BoxGroupList[_model.SelectedPort];
                        for (int i = 0; i < bgl.BoxList.Count; i++) {
                            var box = bgl.BoxList[i];
                            box.Selected = _dradBox.Rect.Contains(box.Rect);
                        }
                        List<Box> _lstChildBox = bgl.BoxList.Where(i => i.Selected).ToList();

                        if (_lstChildBox.Count > 0) {
                            Rectangle subRct = _lstChildBox[0].Rect;
                            int endX = subRct.X + subRct.Width;
                            int endY = subRct.Y + subRct.Height;
                            foreach (var childBox in _lstChildBox) {
                                if (endX < childBox.RctX + childBox.RctW)
                                    endX = childBox.RctX + childBox.RctW;
                                if (endY < childBox.RctY + childBox.RctH)
                                    endY = childBox.RctY + childBox.RctH;
                                if (childBox.RctX < subRct.X)
                                    subRct.X = childBox.RctX;
                                if (childBox.RctY < subRct.Y)
                                    subRct.Y = childBox.RctY;
                            }
                            subRct.Width = endX - subRct.X;
                            subRct.Height = endY - subRct.Y;

                            _dradBox.Rect = subRct;
                            _dradBox.Selected = true;
                        }
                        else {
                            _dradBox.Rect = new Rectangle();
                            _dradBox.Selected = false;
                        }

                        BoxInfoRefreshEvent?.Invoke(this, _dradBox);
                        break;
                    case BoxState.Select:
                        break;
                    case BoxState.Move:
                        if (_dradBox.RctW == 0 && _dradBox.RctH == 0) { 

                            _dradBox.RctX = pt.X - GapXY.Width;
                            _dradBox.RctY = pt.Y - GapXY.Height;

                            
                        }
                        // 현재박스의 너비,높이가 캔버스를 벗어나면 캔버스를 늘리고 스크롤바를 + 알파만큼 이동시켜줘야 함.
                        // 전체 박스의 너비, 높이가 확장된 캔버스보다 더 축소된다면 캔버스를 줄이고 스크롤바를 - 알파만큼 이동시켜줌
                        var boxGroupList = _model.BoxGroupList[_model.SelectedPort];
                        List<Box> selectedBoxes = boxGroupList.BoxList.Where(i => i.Selected).ToList();
                        int maxX = selectedBoxes.Max(i => i.RctX + i.RctW);
                        int maxY = selectedBoxes.Max(i => i.RctY + i.RctH);

                        if (Width < maxX + 50)
                            Width = layer.Width = maxX + 50;
                        else if (_baseSize.Width < Width)
                            Width = layer.Width = _baseSize.Width < maxX + 50 ? maxX + 50 : _baseSize.Width;

                        if (Height < maxY + 50)
                            Height = layer.Height = maxY + 50;
                        else if (_baseSize.Height < Height)
                            Height = layer.Height = _baseSize.Height < maxY + 50 ? maxY + 50 : _baseSize.Height;

                        SetViewSize(Width, Height);
                        layer.SetLayerSize(Width, Height);

                        BoxInfoRefreshEvent?.Invoke(this, _dradBox);
                        //Invalidate(false);
                        _boxState = BoxState.None;
                        break;
                }
            }
            else {
                _dradBox.Rect = new Rectangle();
                BoxInfoRefreshEvent?.Invoke(this, _dradBox);
            }

            _mousePressed = false;
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            /*
            
            배경은 아무리 커도 현재 zoom 크기 대비하여 이미지를 해당 사이즈에 맞게 잘라서 표출, 
            그려지는 박스들의 사이즈 중 캔버스를 벗어나는 사이즈가 있으면 
            overflow되는 사이즈 + a 값만큼 캔버스 다시 그리고 해당 방향에 스크롤을 넣어준다.
            배경은 박스가 추가되거나 움직였을때 사이즈가 변동되었다는 이벤트를 발생시켜 SectionControl에서 감지한다

            */

            lock (thLock) { 
                try {

                    if (layer != null) {
                        var bitmap = layer.Bitmap;
                        e.Graphics.DrawImage(bitmap, ClientRectangle, box, GraphicsUnit.Pixel);

                        DrawTracker(e.Graphics);
                    }
                }
                catch (Exception ex) {
                    Debug.WriteLine($"err - SectionControl - OnPaint(PaintEventArgs)");
                    Debug.WriteLine($"msg : {ex.Message}");
                    layer.Bitmap.Dispose();
                }
            }
        }

        private void DrawBoxGroup(Layer layer) {
            try {
                Point halfPoint = new Point(0, 0);
                int imgSize = 40;
                var boxList = _model?.BoxGroupList;
                Color color = Color.FromName(Enum.GetName(typeof(ColorSpec), ColorSpec.Transparent));

                if (boxList?.Count >= 0) {
                    using (var g = Graphics.FromImage(layer.Bitmap)) {
                        int port = _model.SelectedPort;
                        if (port < 0) return;
                        for (int i = 0; i < port; i++) {
                            var boxGroup = boxList[i].BoxList;
                            for (int j = 0; j < boxGroup.Count; j++) {
                                string desc = boxGroup[j].RctW < MINIMUM_SIZE * 4 || boxGroup[j].RctH < MINIMUM_SIZE * 4 ? (boxGroup[j].tagCard + 1).ToString() : boxGroup[j].Description;
                                g.DrawImage(boxGroup[j].Bitmap, boxGroup[j].Rect.X, boxGroup[j].Rect.Y);
                                g.DrawString(desc, DefaultFont, BlackBrush, boxGroup[j].Rect, sf);

                                // 그룹핑 된 박스
                                g.DrawRectangle(_dradBox.Selected ? BlueBorderDashPen : PinkPen, _dradBox.Rect);

                                if (i == _model.SelectedPort && boxGroup[j].Selected)
                                    g.DrawRectangle(BlueBorderPen, boxGroup[j].Rect);
                            }
                            var _lstLinker = boxList[i]._lstLinker;
                            if (_lstLinker.Count > 0)
                            {
                                for (int j = 0; j < _lstLinker.Count - 1; j++)
                                {
                                    var rct1 = boxGroup.Where(p => p.tagCard == _lstLinker[j].Item1).FirstOrDefault();
                                    var rct2 = boxGroup.Where(p => p.tagCard == _lstLinker[j].Item2).FirstOrDefault();

                                    if (rct1 == null || rct2 == null) continue;
                                    RedBorderPenHalf.CustomEndCap = new AdjustableArrowCap(4, 4);

                                    if (j == 0)
                                        g.DrawImage(StartImg, new Rectangle(rct1.MidX - imgSize / 2, rct1.MidY - imgSize / 2, imgSize, imgSize));
                                    if (j + 1 == _lstLinker.Count - 1)
                                        g.DrawImage(FinishImg, new Rectangle(rct2.MidX - imgSize / 2, rct2.MidY - imgSize / 2, imgSize, imgSize));

                                    halfPoint = new Point(rct1.MidX + (rct2.MidX - rct1.MidX) / 2, rct1.MidY + (rct2.MidY - rct1.MidY) / 2);

                                    g.DrawLine(RedBorderPenHalf, new Point(rct1.MidX, rct1.MidY), halfPoint);
                                    g.DrawLine(RedBorderPen, halfPoint, new Point(rct2.MidX, rct2.MidY));
                                }
                            }
                        }

                        for (int i = boxList.Count - 1; i >= port; i--)
                        {
                            var boxGroup = boxList[i].BoxList;
                            for (int j = 0; j < boxGroup.Count; j++)
                            {
                                string desc = boxGroup[j].RctW < MINIMUM_SIZE * 4 || boxGroup[j].RctH < MINIMUM_SIZE * 4 ? (boxGroup[j].tagCard + 1).ToString() : boxGroup[j].Description;
                                g.DrawImage(boxGroup[j].Bitmap, boxGroup[j].Rect.X, boxGroup[j].Rect.Y);
                                g.DrawString(desc, DefaultFont, BlackBrush, boxGroup[j].Rect, sf);

                                // 그룹핑 된 박스
                                g.DrawRectangle(_dradBox.Selected ? BlueBorderDashPen : PinkPen, _dradBox.Rect);

                                if (i == _model.SelectedPort && boxGroup[j].Selected)
                                    g.DrawRectangle(BlueBorderPen, boxGroup[j].Rect);
                            }
                            var _lstLinker = boxList[i]._lstLinker;
                            if (_lstLinker.Count > 0)
                            {
                                for (int j = 0; j < _lstLinker.Count - 1; j++)
                                {
                                    var rct1 = boxGroup.Where(p => p.tagCard == _lstLinker[j].Item1).FirstOrDefault();
                                    var rct2 = boxGroup.Where(p => p.tagCard == _lstLinker[j].Item2).FirstOrDefault();

                                    if (rct1 == null || rct2 == null) continue;
                                    RedBorderPenHalf.CustomEndCap = new AdjustableArrowCap(4, 4);

                                    if (j == 0)
                                        g.DrawImage(StartImg, new Rectangle(rct1.MidX - imgSize / 2, rct1.MidY - imgSize / 2, imgSize, imgSize));
                                    if (j + 1 == _lstLinker.Count - 1)
                                        g.DrawImage(FinishImg, new Rectangle(rct2.MidX - imgSize / 2, rct2.MidY - imgSize / 2, imgSize, imgSize));

                                    halfPoint = new Point(rct1.MidX + (rct2.MidX - rct1.MidX) / 2, rct1.MidY + (rct2.MidY - rct1.MidY) / 2);

                                    g.DrawLine(RedBorderPenHalf, new Point(rct1.MidX, rct1.MidY), halfPoint);
                                    g.DrawLine(RedBorderPen, halfPoint, new Point(rct2.MidX, rct2.MidY));
                                }
                            }
                        }


                        /*for (int i = 0; i < boxList.Count; i++) {
                            var boxGroup = boxList[i].BoxList;
                            for (int j = 0; j < boxGroup.Count; j++) {

                                *//*g.DrawRectangle(BlackPen, boxGroup[j].Rect);
                                g.FillRectangle(new SolidBrush(ColorList[i+1]), boxGroup[j].Rect);*//*
                                string desc = boxGroup[j].RctW < MINIMUM_SIZE*4 || boxGroup[j].RctH < MINIMUM_SIZE*4 ? (boxGroup[j].tagCard+1).ToString() : boxGroup[j].Description;
                                g.DrawImage(boxGroup[j].Bitmap,boxGroup[j].Rect.X, boxGroup[j].Rect.Y);
                                g.DrawString(desc, DefaultFont, BlackBrush, boxGroup[j].Rect, sf);

                                // 그룹핑 된 박스
                                g.DrawRectangle(_dradBox.Selected ? BlueBorderDashPen: PinkPen , _dradBox.Rect);

                                if (i == _model.SelectedPort && boxGroup[j].Selected)
                                    g.DrawRectangle(BlueBorderPen, boxGroup[j].Rect);
                            }
                            var _lstLinker = boxList[i]._lstLinker;
                            if (_lstLinker.Count > 0) { 
                                for (int j = 0; j < _lstLinker.Count-1; j++) {
                                    var rct1 = boxGroup.Where(p => p.tagCard == _lstLinker[j].Item1).FirstOrDefault();
                                    var rct2 = boxGroup.Where(p => p.tagCard == _lstLinker[j].Item2).FirstOrDefault();
                                    
                                    if (rct1 == null || rct2 == null) continue;
                                    RedBorderPenHalf.CustomEndCap = new AdjustableArrowCap(4, 4);

                                    if (j == 0)
                                        g.DrawImage(StartImg, new Rectangle(rct1.MidX- imgSize/2, rct1.MidY- imgSize/2, imgSize, imgSize));
                                    if (j+1 == _lstLinker.Count - 1)
                                        g.DrawImage(FinishImg, new Rectangle(rct2.MidX- imgSize/2, rct2.MidY- imgSize/2, imgSize, imgSize));

                                    halfPoint = new Point(rct1.MidX + (rct2.MidX - rct1.MidX) / 2, rct1.MidY + (rct2.MidY - rct1.MidY) / 2);

                                    g.DrawLine(RedBorderPenHalf, new Point(rct1.MidX, rct1.MidY), halfPoint);
                                    g.DrawLine(RedBorderPen, halfPoint, new Point(rct2.MidX, rct2.MidY));
                                }
                            }
                        }*/

                        
                        if (_dradBox.RctX == 0 || _dradBox.RctY == 0) {
                            g.DrawRectangle(BlueBorderDashPen, _dradBox.Rect);
                        }
                    }
                }
            }
            catch (Exception ex) {
                Debug.WriteLine($"err - SectionControl - DrawBoxGroup(Layer)");
                Debug.WriteLine($"msg : {ex.Message}");
                Dispose(true);
            }
        }

        private void DrawTracker(Graphics g) {
            // zoom에 따라 변경
        }

        private void PullTheBoxUp() {
            if (_model.SelectedPort == -1) return;

            var boxGroupList = _model.BoxGroupList[_model.SelectedPort];
            var boxList = boxGroupList?.BoxList;
            var lastBox = boxGroupList?.BoxList?.LastOrDefault();
            if (boxList == null || lastBox == null) return;

            boxList.ForEach(i => i.Selected = false);
            boxGroupList.DelLinker(lastBox);
            boxGroupList.BoxList.Remove(lastBox);
            boxGroupList.BoxList.Add(lastBox);
            boxGroupList.AddLinker();
            lastBox.Selected = true;
            _dradBox.Rect = lastBox.Rect;
            BoxInfoRefreshEvent?.Invoke(this, _dradBox);
        }

        private void SetLineLRTB(ref List<Box> bridgeList, ref List<Box> boxList) {
            var bridgeGroup = boxList.OrderBy(i => i.RctY).GroupBy(i => i.RctY).ToList();
            for (int i = 0; i < bridgeGroup.Count(); i++) {
                bridgeList.AddRange(i % 2 == 0 ? bridgeGroup[i].OrderBy(p => p.RctX).ToList() : bridgeGroup[i].OrderByDescending(p => p.RctX).ToList());
            }
        }

        private void SetLineRLTB(ref List<Box> bridgeList, ref List<Box> boxList) {
            var bridgeGroup = boxList.OrderBy(i => i.RctY).GroupBy(i => i.RctY).ToList();
            for (int i = 0; i < bridgeGroup.Count(); i++) {
                bridgeList.AddRange(i % 2 == 0 ? bridgeGroup[i].OrderByDescending(p => p.RctX).ToList() : bridgeGroup[i].OrderBy(p => p.RctX).ToList());
            }
        }

        private void SetLineLRBT(ref List<Box> bridgeList, ref List<Box> boxList) {
            var bridgeGroup = boxList.OrderByDescending(i => i.RctY).GroupBy(i => i.RctY).ToList();
            for (int i = 0; i < bridgeGroup.Count(); i++) {
                bridgeList.AddRange(i % 2 == 0 ? bridgeGroup[i].OrderBy(p => p.RctX).ToList() : bridgeGroup[i].OrderByDescending(p => p.RctX).ToList());
            }
        }

        // 연산 속도 여부에 따라 차후 변경
        /*private void SetLineLRBT(ref List<int> indexes, ref List<Box> boxList) {
            var bridgeGroup = boxList.OrderByDescending(i => i.RctY).ThenBy(i => i.RctX).GroupBy(i => i.RctY).ToList();
            for (int i = 0; i < bridgeGroup.Count(); i++) {
                if (i % 2 == 0) {
                    for (int j = 0; j < bridgeGroup[i].Count(); j++) {
                        indexes.Add(boxList.IndexOf(bridgeGroup[i].ElementAt(j)));
                    }
                }
                else {
                    for (int j = bridgeGroup[i].Count()-1; j >= 0; j--) {
                        indexes.Add(boxList.IndexOf(bridgeGroup[i].ElementAt(j)));
                    }
                }
            }
        }*/

        private void SetLineRLBT(ref List<Box> bridgeList, ref List<Box> boxList) {
            var bridgeGroup = boxList.OrderByDescending(i => i.RctY).GroupBy(i => i.RctY).ToList();
            for (int i = 0; i < bridgeGroup.Count(); i++) {
                bridgeList.AddRange(i % 2 == 0 ? bridgeGroup[i].OrderByDescending(p => p.RctX).ToList() : bridgeGroup[i].OrderBy(p => p.RctX).ToList());
            }
        }

        private void SetLineTBLR(ref List<Box> bridgeList, ref List<Box> boxList) {
            var bridgeGroup = boxList.OrderBy(i => i.RctX).GroupBy(i => i.RctX).ToList();
            for (int i = 0; i < bridgeGroup.Count(); i++) {
                bridgeList.AddRange(i % 2 == 0 ? bridgeGroup[i].OrderBy(p => p.RctY).ToList() : bridgeGroup[i].OrderByDescending(p => p.RctY).ToList());
            }
        }

        private void SetLineBTLR(ref List<Box> bridgeList, ref List<Box> boxList) {
            var bridgeGroup = boxList.OrderBy(i => i.RctX).GroupBy(i => i.RctX).ToList();
            for (int i = 0; i < bridgeGroup.Count(); i++) {
                bridgeList.AddRange(i % 2 == 0 ? bridgeGroup[i].OrderByDescending(p => p.RctY).ToList() : bridgeGroup[i].OrderBy(p => p.RctY).ToList());
            }
        }

        private void SetLineTBRL(ref List<Box> bridgeList, ref List<Box> boxList) {
            var bridgeGroup = boxList.OrderByDescending(i => i.RctX).GroupBy(i => i.RctX).ToList();
            for (int i = 0; i < bridgeGroup.Count(); i++) {
                bridgeList.AddRange(i % 2 == 0 ? bridgeGroup[i].OrderBy(p => p.RctY).ToList() : bridgeGroup[i].OrderByDescending(p => p.RctY).ToList());
            }
        }

        private void SetLineBTRL(ref List<Box> bridgeList, ref List<Box> boxList) {
            var bridgeGroup = boxList.OrderByDescending(i => i.RctX).GroupBy(i => i.RctX).ToList();
            for (int i = 0; i < bridgeGroup.Count(); i++) {
                bridgeList.AddRange(i % 2 == 0 ? bridgeGroup[i].OrderByDescending(p => p.RctY).ToList() : bridgeGroup[i].OrderBy(p => p.RctY).ToList());
            }
        }

        public void SetPosOfDragbox(int x, int y) {
            if (_model == null && _model.SelectedPort < 0) return;

            var bgl = _model.BoxGroupList.Where(i => i.Port == _model.SelectedPort).FirstOrDefault();
            if (bgl != null) {
                List<Box> _lstChildBox = bgl.BoxList.Where(i => i.Selected == true).ToList();

                int drx = _dradBox.RctX;
                int dry = _dradBox.RctY;

                int gapx = x - drx;
                int gapy = y - dry;

                _lstChildBox.ForEach(i => { i.RctX = i.RctX + gapx; i.RctY = i.RctY + gapy; });
                _dradBox.RctX = x;
                _dradBox.RctY = y;
            }

        }

        public void SetBaseSize(Size size) {
            _baseSize = size;
        }

        public void SetModelValue(ref DrawerModel model) {
            _model = model;
            _model.PortAddedEvent += (s, e) => { PortAddedEvent?.Invoke(this, e); };
        }

        public void SetModelPort(int port) {
            if (_model == null) return;
            _model.SelectedPort = port;
            if (_model.BoxGroupList.Count > port)
            {
                _model.BoxGroupList.Where(i => i.DrawingOrder < _model.BoxGroupList[port].DrawingOrder).ToList().ForEach(i => i.DrawingOrder++);
                _model.BoxGroupList[port].DrawingOrder = 0;
            }
            _dradBox = new Box(-1) { Rect = new Rectangle() };
            var bgl = _model.BoxGroupList.Where(i => i.Port == port).FirstOrDefault();
            if (bgl == null) {
                _dradBox.Rect = new Rectangle();
                return; 
            }

            // 포트를 변경했을때 그 전에 선택되었던 박스를 가지고 있는게 편할지 or 전체 박스를 고르는게 편할지 결정할것.
            List<Box> _lstChildBox = bgl.BoxList.Where(i => i.Selected).ToList();
            // List<Box> _lstChildBox = bgl.BoxList;

            if (_lstChildBox.Count > 0) {
                Rectangle subRct = _lstChildBox[0].Rect;
                int endX = subRct.X + subRct.Width;
                int endY = subRct.Y + subRct.Height;
                foreach (var childBox in _lstChildBox) {
                    if (endX < childBox.RctX + childBox.RctW)
                        endX = childBox.RctX + childBox.RctW;
                    if (endY < childBox.RctY + childBox.RctH)
                        endY = childBox.RctY + childBox.RctH;
                    if (childBox.RctX < subRct.X)
                        subRct.X = childBox.RctX;
                    if (childBox.RctY < subRct.Y)
                        subRct.Y = childBox.RctY;
                }
                subRct.Width = endX - subRct.X;
                subRct.Height = endY - subRct.Y;

                _dradBox.Selected = true;
                _dradBox.Rect = subRct;
            }
        }

        public BoxGroup CurrentBoxGroup() {
            if (_model != null && _model.SelectedPort >= 0) return _model.BoxGroupList[_model.SelectedPort];
            else return null;
        }

        public void RegistBox(int width, int height, bool setCenter = true) {
            if (_model == null) return;
            _model.AppendBox(setCenter ? (Width-width)/2 : 0, setCenter ? (Height-height)/2 : 0, width, height);
            //AddLinker();
            PullTheBoxUp();
        }

        public void RegistBox(int x, int y, int width, int height, bool setCenter = true) {
            if (_model == null) return;
            _model.AppendBox(setCenter ? (Width - width) / 2 : x, setCenter ? (Height - height) / 2 : y, width, height);
            //AddLinker();
            PullTheBoxUp();
        }

        public void AddLinker() {

            int selIdx = _model.SelectedPort;

            if (selIdx < 0) return;

            var grpBox = _model.BoxGroupList[_model.SelectedPort];
            grpBox.AddLinker();

        }

        public void DelBox() {

            int selIdx = _model.SelectedPort;

            if (selIdx < 0 || (_dradBox.RctW == 0 && _dradBox.RctY == 0)) return;

            var grpBox = _model.BoxGroupList[_model.SelectedPort];
            // selectedbox 전부다 삭제하도록, 그냥 라인은 최근 라인 연결방법으로 고정.

            foreach (var selbox in grpBox.BoxList.Where(i => i.Selected == true).ToList()) {
                grpBox.DelLinker(selbox);
                grpBox.BoxList.Remove(selbox);
            }

            _dradBox.Rect = new Rectangle();
        }

        public void ClearBox() {
            foreach (var item in _model.BoxGroupList) {
                item.BoxList.Clear();
                item.ClearBoxLinker();
            }

            _dradBox.Rect = new Rectangle();
        }

        public void ClearBox(int port) {
            if (port < 0 || _model.BoxGroupList.Count <= port) return;
            _model.BoxGroupList[port].BoxList?.Clear();
            _model.BoxGroupList[port].ClearBoxLinker();

            _dradBox.Rect = new Rectangle();
        }

        /// <summary>
        /// 간편 연결
        /// L : Left
        /// R : Right
        /// T : Top
        /// B : Bottom
        /// </summary>
        public void QuickBridge(LineDirection ld) {
            if (_model == null && _model.SelectedPort >= _model.BoxGroupList.Count) return;

            var boxGroup = _model.BoxGroupList[_model.SelectedPort];
            if (boxGroup.BoxList.Count <= 1) return;
            boxGroup._lstLinker.Clear();

            List<Box> bridgeList = new List<Box>();
            // 연산 속도 여부에 따라 차후 변경
            //List<int> indexes = new List<int>();
            switch (ld) {
                case LineDirection.LRTB:
                    SetLineLRTB(ref bridgeList, ref boxGroup.BoxList);
                    break;
                case LineDirection.RLTB:
                    SetLineRLTB(ref bridgeList, ref boxGroup.BoxList);
                    break;
                case LineDirection.LRBT:
                    SetLineLRBT(ref bridgeList, ref boxGroup.BoxList);

                    // 연산 속도 여부에 따라 차후 변경
                    /*SetLineLRBT(ref indexes, ref boxGroup.BoxList);
                    for (int i = 0; i < indexes.Count; i++) {
                        bridgeList.Add(boxGroup.BoxList[indexes[i]]);
                    }*/
                    break;
                case LineDirection.RLBT:
                    SetLineRLBT(ref bridgeList, ref boxGroup.BoxList);
                    break;
                case LineDirection.TBLR:
                    SetLineTBLR(ref bridgeList, ref boxGroup.BoxList);
                    break;
                case LineDirection.BTLR:
                    SetLineBTLR(ref bridgeList, ref boxGroup.BoxList);
                    break;
                case LineDirection.TBRL:
                    SetLineTBRL(ref bridgeList, ref boxGroup.BoxList);
                    break;
                case LineDirection.BTRL:
                    SetLineBTRL(ref bridgeList, ref boxGroup.BoxList);
                    break;
            }

            for (int i = 0; i < bridgeList.Count; i++) {
                bridgeList[i].tagCard = i;
            }


            for (int i = 0; i < bridgeList.Count - 1; i++) {
                boxGroup._lstLinker.Add((bridgeList[i].tagCard, bridgeList[i + 1].tagCard));
            }
            boxGroup._lstLinker.Add((bridgeList.Last().tagCard, -1));

        }


        /// <summary>
        /// 간편 정렬
        /// </summary>

        public void QuickAlign(AlignDirection direction) {
            if (_model == null || _model.SelectedPort < 0) return;

            var boxGroup = _model.BoxGroupList[_model.SelectedPort];
            List<Box> _lstChildBox = boxGroup.BoxList.Where(i => i.Selected).ToList();

            if (_lstChildBox.Count <= 1) return;
            int topY = _dradBox.RctY ,botY = _dradBox.RctY + _dradBox.RctH, leftX = _dradBox.RctX, rightX = _dradBox.RctX + _dradBox.RctW;

            // base t,b,l,r
            switch (direction) {
                case AlignDirection.Top:
                case AlignDirection.LeftTop:
                case AlignDirection.RightTop:
                    topY = _lstChildBox.Min(i => i.RctY);
                    _lstChildBox.ForEach(i => i.RctY = topY);
                    break;
                case AlignDirection.Bottom:
                case AlignDirection.LeftBottom:
                case AlignDirection.RightBottom:
                    botY = _lstChildBox.Max(i => i.RctY + i.RctH);
                    _lstChildBox.ForEach(i => i.RctY = botY - i.RctH);
                    break;
                case AlignDirection.Left:
                case AlignDirection.TopLeft:
                case AlignDirection.BottomLeft:
                    leftX = _lstChildBox.Min(i => i.RctX);
                    _lstChildBox.ForEach(i => i.RctX = leftX);
                    break;
                case AlignDirection.Right:
                case AlignDirection.TopRight:
                case AlignDirection.BottomRight:
                    rightX = _lstChildBox.Max(i => i.RctX + i.RctW);
                    _lstChildBox.ForEach(i => i.RctX = rightX - i.RctW);
                    break;
            }

            // add lr / horizontal alignment
            switch (direction) {
                case AlignDirection.LeftTop:
                case AlignDirection.LeftBottom:
                    _lstChildBox.OrderBy(i => i.RctX).ThenBy(i => i.tagCard).ToList().ForEach(i => {
                        i.RctX = leftX;
                        leftX = i.RctX + i.RctW;
                    });
                    break;
                case AlignDirection.RightBottom:
                case AlignDirection.RightTop:
                    _lstChildBox.OrderBy(i => i.RctY).ThenBy(i => -i.tagCard).ToList().ForEach(i => {
                        i.RctX = rightX - i.RctW;
                        rightX = i.RctX;
                    });
                    break;
            }

            // add tb / vertical alignment
            switch (direction) {
                case AlignDirection.TopLeft:
                case AlignDirection.TopRight:
                    _lstChildBox.OrderBy(i => i.RctY).ThenBy(i => i.tagCard).ToList().ForEach(i => {
                        i.RctY = topY;
                        topY = i.RctY + i.RctH;
                    });
                    break;
                case AlignDirection.BottomLeft:
                case AlignDirection.BottomRight:
                    _lstChildBox.OrderBy(i => -(i.RctY + i.RctH)).ThenBy(i => -i.tagCard).ToList().ForEach(i => {
                        i.RctY = botY - i.RctH;
                        botY = i.RctY;
                    });
                    break;
            }

            Rectangle subRct = _lstChildBox[0].Rect;
            int endX = subRct.X + subRct.Width;
            int endY = subRct.Y + subRct.Height;

            foreach (var childBox in _lstChildBox) {
                if (endX < childBox.RctX + childBox.RctW)
                    endX = childBox.RctX + childBox.RctW;
                if (endY < childBox.RctY + childBox.RctH)
                    endY = childBox.RctY + childBox.RctH;
                if (childBox.RctX < subRct.X)
                    subRct.X = childBox.RctX;
                if (childBox.RctY < subRct.Y)
                    subRct.Y = childBox.RctY;
            }

            subRct.Width = endX - subRct.X;
            subRct.Height = endY - subRct.Y;

            _dradBox.Rect = subRct;

        }

        public void ResetGroup(int row, int col, int boxWidth, int boxHeight) {

            ClearBox(_model?.SelectedPort ?? -1);

            if (row <= 0 || col <= 0) return;

            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    RegistBox(j * boxWidth, i*boxHeight,boxWidth, boxHeight, false);
                }
            }

            QuickAlign(AlignDirection.LeftTop);

            var boxList = _model.BoxGroupList[_model.SelectedPort].BoxList;

            foreach (var box in boxList)
                box.Selected = true;

            _dradBox = new Box(-1) {
                RctX = boxList.Min(i => i.RctX),
                RctY = boxList.Min(i => i.RctY),
                RctW = boxList.Max(i => i.RctX + i.RctW),
                RctH = boxList.Max(i => i.RctY + i.RctH)
            };
        }



        public void SetViewSize(int width, int height) {
            box = new Rectangle(new Point(0,0), new Size(width, height));

            // draw background
            // 그리드를 해당 사이즈로 조절
        }

        public void SetLayerSize(int width, int height) {
            layer = new Layer(width, height);
        }

        public void BoxUpdate() {
            try {
                while (thRunning) {
                    if (InvokeRequired)
                    {
                        Invoke(new EventHandler(delegate {
                            if (layer != null)
                            {
                                layer.Clear();
                                DrawBoxGroup(layer);
                                Invalidate(false);
                            }
                        }));
                    }
                    else
                    {
                        if (layer != null)
                        {
                            layer.Clear();
                            DrawBoxGroup(layer);
                            Invalidate(false);
                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex) {
                Debug.WriteLine($"err - SectionControl - BoxUpdate()");
                Debug.WriteLine($"msg : {ex.Message}");
                Dispose(true);
            }
        }

        protected override void OnHandleDestroyed(EventArgs e) {
            Dispose(true);
            base.OnHandleDestroyed(e);
        }

        protected override void Dispose(bool disposing) {
            try {
                if (disposing) {
                    thRunning = false;
                    //thUpdate?.Join();
                    //layer?.Dispose();
                }
            }
            catch (Exception ex) {

                Debug.WriteLine($"Disposing {ex.Message}");
            }
            
            base.Dispose(disposing);
        }

    }
}

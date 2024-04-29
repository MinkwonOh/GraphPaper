﻿using SectionManager.Drawer;
using SectionManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SectionManager {
    public class SectionControl : Control, IDisposable {

        private static readonly int MINIMUM_SIZE = 16;

        public EventHandler<Box> BoxInfoRefreshEvent;

        private Layer layer;
        private Rectangle box;
        private ZoomPer zoom = ZoomPer.z100;
        private DrawerModel _model;
        public ZoomPer Zoom { set => zoom = value; }

        private bool thRunning;
        private Thread thUpdate;

        private object paintLock = new object();
        private object thLock = new object();

        public bool RunThread { set => thRunning = value; }

        private BoxState _boxState = BoxState.None;
        private Box CurrentBox = null;
        private Pen BlackPen, PinkPen, BluePen, RedPen;
        private SolidBrush BlackBrush;
        private Size GapXY;
        private StringFormat sf;

        public SectionControl() {
            DoubleBuffered = true;

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
            BlackPen = new Pen(Color.Black, 2);

            PinkPen = new Pen(Color.Pink, 2);

            BluePen = new Pen(Color.Blue, 2);

            RedPen = new Pen(Color.Red, 2);

            BlackPen.Alignment = PinkPen.Alignment = RedPen.Alignment = BluePen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

            // brushes
            BlackBrush = new SolidBrush(Color.Black);

            // stringformat
            sf = new StringFormat() { 
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
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
            Point pt = e.Location;
            // 리스트 역순으로 area 먼저 겹치는 객체를 move
            // 객체가 저장되어있는 리스트의 순서가 아니라 order로 설정되어 있는 순서여야 함.
            switch (_boxState) {
                case BoxState.None:
                    if (_model.BoxGroupList == null || _model.BoxGroupList.Count <= 0) return;
                    var lstBox = _model.BoxGroupList[_model.SelectedIndex].BoxList;
                    CurrentBox = null;
                    for (int i = lstBox.Count -1; i >=0; i--) {
                        if (lstBox[i].HasPoint(pt)) {
                            _boxState = BoxState.Move;
                            CurrentBox = lstBox[i];
                            Debug.WriteLine($"CurrentBoxRect : {CurrentBox.Rect}");
                            _model.BoxGroupList[_model.SelectedIndex].ToTop(CurrentBox);
                            GapXY = new Size(pt.X - CurrentBox.RctX, pt.Y - CurrentBox.RctY);
                            BoxInfoRefreshEvent?.Invoke(this, CurrentBox);
                            // order 후처리 해줘야함
                            // route에 포함되지 않은 ids라면 route의 마지막 idx로 추가시키고 end 처리
                            i = -1;
                        }
                    }
                    //CurrentBox = lstBox.Where(i => i.HasPoint(pt) == true).FirstOrDefault();
                    if (CurrentBox == null) {
                        BoxInfoRefreshEvent?.Invoke(this, CurrentBox);
                    }
                    break;
                case BoxState.Select:
                    break;
                case BoxState.Move:
                    _boxState = BoxState.None;
                    break;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            Point pt = e.Location;
            switch (_boxState) {
                case BoxState.None:
                    break;
                case BoxState.Select:
                    break;
                case BoxState.Move:
                    if (CurrentBox != null) {
                        CurrentBox.RctX = pt.X - GapXY.Width;
                        CurrentBox.RctY = pt.Y - GapXY.Height;
                    }
                    BoxInfoRefreshEvent?.Invoke(this, CurrentBox);
                    Invalidate(false);
                    _boxState = BoxState.Move;
                    break;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            Point pt = e.Location;
            switch (_boxState) {
                case BoxState.None:
                    break;
                case BoxState.Select:
                    break;
                case BoxState.Move:
                    if (CurrentBox != null) { 
                        CurrentBox.RctX = pt.X - GapXY.Width;
                        CurrentBox.RctY = pt.Y - GapXY.Height;

                        BoxInfoRefreshEvent?.Invoke(this, CurrentBox);

                        // 현재박스의 너비,높이가 캔버스를 벗어나면 캔버스를 늘리고 스크롤바를 + 알파만큼 이동시켜줘야 함.
                        // 전체 박스의 너비, 높이가 확장된 캔버스보다 더 축소된다면 캔버스를 줄이고 스크롤바를 - 알파만큼 이동시켜줌
                    }
                    Invalidate(false);
                    _boxState = BoxState.None;
                    break;
            }
        }


        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            /*
            
            배경은 아무리 커도 현재 zoom 크기 대비하여 이미지를 해당 사이즈에 맞게 잘라서 표출, 
            그려지는 박스들의 사이즈 중 캔버스를 벗어나는 사이즈가 있으면 
            overflow되는 사이즈 + a 값만큼 캔버스 다시 그리고 해당 방향에 스크롤을 넣어준다.
            배경은 박스가 추가되거나 움직였을때 사이즈가 변동되었다는 이벤트를 발생시켜 SectionControl에서 감지한다

            */


            try {

                if (layer != null) {
                    var bitmap = layer.Bitmap;

                    e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                    e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    e.Graphics.DrawImage(bitmap, ClientRectangle, box, GraphicsUnit.Pixel);

                    DrawTracker(e.Graphics);
                }
            }
            catch (Exception ex) {
                Debug.WriteLine($"err - SectionControl - OnPaint(PaintEventArgs)");
                Debug.WriteLine($"msg : {ex.Message}");
                layer.Bitmap.Dispose();
                throw;
            }
        }

        private void DrawBoxGroup(Layer layer) {
            try {
                var boxList = _model?.BoxGroupList;
                if (boxList?.Count >= 0) {
                    using (var g = Graphics.FromImage(layer.Bitmap)) {
                        for (int i = 0; i < boxList.Count; i++) {
                            var boxGroup = boxList[i].BoxList;
                            for (int j = 0; j < boxGroup.Count; j++) {
                                g.DrawRectangle(BlackPen, boxGroup[j].Rect);
                                string desc = boxGroup[j].RctW < MINIMUM_SIZE*4 || boxGroup[j].RctH < MINIMUM_SIZE*4 ? (boxGroup[j].tagCard+1).ToString() : boxGroup[j].Description;
                                g.DrawString(desc, DefaultFont, BlackBrush, boxGroup[j].Rect, sf);
                                if (CurrentBox != null) {
                                    g.DrawRectangle(PinkPen, CurrentBox.Rect);
                                }
                            }
                            var _lstLinker = boxList[i]._lstLinker;
                            if (_lstLinker.Count > 0) { 
                                for (int j = 0; j < _lstLinker.Count-1; j++) {
                                    var rct1 = boxGroup.Where(p => p.tagCard == _lstLinker[j].Item1).FirstOrDefault();
                                    var rct2 = boxGroup.Where(p => p.tagCard == _lstLinker[j].Item2).FirstOrDefault();
                                    if (rct1 == null || rct2 == null) continue;
                                    g.DrawLine(BluePen, new Point(rct1.MidX, rct1.MidY), new Point(rct2.MidX, rct2.MidY));
                                }
                            }
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

        public void SetModelValue(DrawerModel model) {
            _model = model;


        }

        public BoxGroup CurrentBoxGroup() {
            if (_model != null && _model.SelectedIndex >= 0) return _model.BoxGroupList[_model.SelectedIndex];
            else return null;
        }

        public void RegistBox(int width, int height) {
            if (_model == null) return;
            _model.AppendBox((Width-width)/2, (Height-height)/2, width, height);
            //_model.AppendBox(0, 0, width, height);
            AddLinker();
        }

        public void AddLinker() {

            int selIdx = _model.SelectedIndex;

            if (selIdx < 0) return;

            var grpBox = _model.BoxGroupList[_model.SelectedIndex];
            grpBox.AddLinker();

        }

        public void DelLinker() {

            int selIdx = _model.SelectedIndex;

            if (selIdx < 0 || CurrentBox == null) return;

            var grpBox = _model.BoxGroupList[_model.SelectedIndex];
            grpBox.DelLinker(grpBox.BoxList.Where(i => i.tagCard == CurrentBox.tagCard).FirstOrDefault());

            grpBox.BoxList.Remove(grpBox.BoxList.Where(i => i.tagCard == CurrentBox.tagCard).FirstOrDefault());

            CurrentBox = null;
        }

        public void DeleteBox() { }

        public void ClearBridge() { }

        /// <summary>
        /// 간편 연결
        /// L : Left
        /// R : Right
        /// T : Top
        /// B : Bottom
        /// </summary>
        public void QuickBridgeLRTB() { 
        }
        public void QuickBridgeRLTB() { 
        }
        public void QuickBridgeRLBT() { 
        }
        public void QuickBridgeLRBT() { 
        }
        public void QuickBridgeTBLR() { 
        }
        public void QuickBridgeBTLR() { 
        }
        public void QuickBridgeTBRL() { 
        }
        public void QuickBridgeBTRL() { 
        }


        /// <summary>
        /// 간편 정렬
        /// </summary>
        public void QuickAlignLeft() {
        }
        public void QuickAlignRight() {
        }
        public void QuickAlignTop() { 
        }
        public void QuickAlignBottom() { 
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
                    lock (thLock) {
                        if (InvokeRequired) {
                            Invoke(new EventHandler(delegate {
                                if (layer != null && CurrentBoxGroup() != null) {
                                    layer.Clear();
                                    DrawBoxGroup(layer);
                                    Invalidate(false);
                                }
                            }));
                        }
                        else {
                            if (layer != null && CurrentBoxGroup() != null) {
                                layer.Clear();
                                DrawBoxGroup(layer);
                                Invalidate(false);
                            }
                        }
                    }
                    Thread.Sleep(20);
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

using SectionManager.Drawer;
using SectionManager.Models;
using System;
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

        public SectionControl() {
            DoubleBuffered = true;

            box = new Rectangle(0,0,16,16);

            thRunning = true;
            thUpdate = new Thread(() => BoxUpdate());
            thUpdate.Start();
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
                Debug.WriteLine($"Draw Box");
                var boxList = _model?.BoxGroupList;
                if (boxList?.Count >= 0) {
                    Debug.WriteLine($"Box cnt >= 0");
                    using (var g = Graphics.FromImage(layer.Bitmap)) {
                        for (int i = 0; i < boxList.Count; i++) {
                            var boxGroup = boxList[i].BoxList;
                            for (int j = 0; j < boxGroup.Count; j++) {
                                Debug.WriteLine($"Draw Box rct");
                                g.DrawRectangle(new Pen(new SolidBrush(Color.Black),2 ), boxGroup[j].Rect);
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
            Debug.WriteLine($"_model?.SelectedIndex ? {_model?.SelectedIndex}");
            if (_model != null && _model.SelectedIndex >= 0) return _model.BoxGroupList[_model.SelectedIndex];
            else return null;
        }

        public void RegistBox(int width, int height) {
            if (_model == null) return;
            _model.AppendBox(width, height);
        }
        public void DeleteBox() { }

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
                        if (layer != null && CurrentBoxGroup() != null) {
                            layer.Clear();
                            DrawBoxGroup(layer);
                            Invalidate(false);
                        }
                    }
                }
            }
            catch (Exception ex) {
                Debug.WriteLine($"err - SectionControl - BoxUpdate()");
                Debug.WriteLine($"msg : {ex.Message}");
                Dispose(true);
            }
        }

        protected override void Dispose(bool disposing) {
            if (disposing) { 
                thRunning = false;
                thUpdate?.Join();
                layer.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}

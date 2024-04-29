using SectionManager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SectionManager.Drawer {
    public class Layer : IDisposable {

        private Bitmap mBitmap = null;
        private Pen WhitePen = new Pen(Color.White, 2);
        private SolidBrush WhiteBrush = new SolidBrush(Color.White);
        private Rectangle WhiteBoard = new Rectangle(0,0,1,1);
        
        public Bitmap Bitmap { get => mBitmap; }

        private object bmpLock = new object();

        public int Width { get; set; }
        public int Height { get; set; }
        public ZoomPer Zoom { get; set; }

        public Layer() { }
        public Layer(int width, int height): this() {
            InitValue(width, height, ZoomPer.z100);
            DrawGrid();
        }

        public Layer(int width, int height, ZoomPer zoom = ZoomPer.z100): this() {
            InitValue(width, height, zoom);
            DrawGrid();
        }

        private void InitValue(int w, int h, ZoomPer zoom) {
            Width = w;
            Height = h;
            Zoom = zoom;
            CreateLayer(w, h);
        }

        private void DrawGrid() {
        }

        public void CreateLayer(int width, int height) {
            if (mBitmap != null) {
                mBitmap.Dispose();
                mBitmap = null;
            }

            if (width > 0 && height > 0)
                mBitmap = new Bitmap(Math.Abs(Width % int.MaxValue), Math.Abs(Height % int.MaxValue));
        }

        public void Clear() {
            try {
                if (mBitmap != null) {
                    using (var g = Graphics.FromImage(mBitmap)) {
                        WhiteBoard.Width = Bitmap.Width;
                        WhiteBoard.Height = Bitmap.Height;
                        g.FillRectangle(WhiteBrush, WhiteBoard);
                    }
                }
            }
            catch (Exception ex) {
                Debug.WriteLine($"err - Layer - Clear()");
                Debug.WriteLine($"msg : {ex.Message}");
                mBitmap.Dispose();
            }
        }

        public void Dispose() {
            mBitmap?.Dispose();
            mBitmap = null;
        }



        /*private Bitmap ToBitmap() {
            if (Width > 0 && Height > 0) {
                var rc = new Rectangle(0, 0, Width, Height);
                BitmapData bmData = mBitmap.LockBits(rc, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                IntPtr scan0 = bmData.Scan0;

                unsafe {
                    for (int y = 0; y < bmData.Height; y++) {
                        UInt32* ptr = (UInt32*)scan0 + bmData.Width * y;
                        for (int x = 0; x < bmData.Width; x++)
                            ptr[x] = mBuffer[y][x].Color;
                    }
                }

                mBitmap.UnlockBits(bmData);
                return mBitmap;
            }
            return null;
        }*/
    }
}

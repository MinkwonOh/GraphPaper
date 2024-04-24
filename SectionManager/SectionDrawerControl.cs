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
        private bool duringAdd;
        private Bitmap emptyBox;
        private object emptyBoxLock = new object();

        public SectionDrawerControl() {
            InitializeComponent();
            InitializeEvent();
            InitializeValue();
        }

        private void InitializeValue() {
            DoubleBuffered = true;
        }

        private void InitializeEvent() {
            btnAdd.Click += (s, e) => AddBtnClicked();
            Paint += (s, e) => FormPaint();
            Click += (s, e) => ControlClicked(this);
            panel1.Click += (s, e) => ControlClicked(panel1);
        }

        private void FormPaint() {
            Point pt = panel1.PointToClient(new Point(MousePosition.X, MousePosition.Y));

            if (emptyBox != null) {
                if (duringAdd) {
                    DrawUnregisteredBox(pt);
                    Invalidate();
                }
                else  {
                    ClearBox();
                }
            }
        }

        private void DrawUnregisteredBox() {
            DrawUnregisteredBox(panel1.PointToClient(new Point(MousePosition.X,MousePosition.Y)));
        }

        private void DrawUnregisteredBox(Point pt) {
            lock (emptyBoxLock) {
                using (var g = panel1.CreateGraphics()) {
                    g.Clear(Color.White);
                    g.DrawImage(emptyBox,new Rectangle(pt,emptyBox.Size));
                }
            }
        }

        private void ControlClicked(Control control) {
            Point pt = control.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            Console.WriteLine(pt);
            ClearBox();
        }

        private void AddBtnClicked() {
            duringAdd = false;
            ClearBox();
            Size size = new Size((int)nmrcBoxWidth.Value, (int)nmrcBoxHeight.Value);
            emptyBox = new Bitmap(size.Width, size.Height,System.Drawing.Imaging.PixelFormat.Format32bppRgb) { 
            };
            using (var g = Graphics.FromImage(emptyBox)) {
                g.DrawRectangle(new Pen(Color.Black,1),new Rectangle(0,0,size.Width,size.Height));
            }
                duringAdd = true;
        }

        private void ClearBox() {
            if (emptyBox != null) { 
                emptyBox.Dispose();
                emptyBox = null;
            }
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            // get model

            // draw
        }

        private void LoadData() {
            // model 가져와서 넣기
            model = new DrawerModel();

        }

        
    }
}

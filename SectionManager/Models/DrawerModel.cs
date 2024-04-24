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
        public BoxGroup CurrentGroup;

        // 확대비율(100% 기준)
        public int viewSize = 100;

        // standard모드? => 고정비율로 계산.
        //

        public DrawerModel() {
            BoxGroupList = new List<BoxGroup>();
        }

        public void AddGroup() {
            /*BoxGroupList.Add(new BoxGroup { 
                 
            });*/
        }
    }


    // 사각형 정보
    public class Box {
        public Rectangle Rect { get; set; }
        public int RctX { get => Rect.X; set => Rect = new Rectangle(value < 0 ? 0 : value % int.MaxValue, Rect.Y, Rect.Width, Rect.Height); }
        public int RctY { get => Rect.Y; set => Rect = new Rectangle(Rect.X, value < 0 ? 0 : value % int.MaxValue, Rect.Width, Rect.Height); }
        public int RctW { get => Rect.Width; set => Rect = new Rectangle(Rect.X, Rect.Y, value < 0 ? 0 : value % int.MaxValue, Rect.Height); }
        public int RctH { get => Rect.Height; set => Rect = new Rectangle(Rect.X, Rect.Y, Rect.Width, value < 0 ? 0 : value % int.MaxValue); }
    }

    // 관리되는 사각형 리스트 정보
    public class BoxGroup {
        public static readonly int MAX_LENGTH = 655360;
        public int Port;
        public List<Box> BoxList;
        public Box CurBox;
        public Color BoxColor;
        public int LineLength { get => BoxList.ToList().Sum(i => i.RctW); }

        public BoxGroup() {
            BoxList = new List<Box>();
        }

    }
}

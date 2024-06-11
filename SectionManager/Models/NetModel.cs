using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SectionManager.Models
{
    public class NetModel
    {

    }

    /// <summary>
    /// 헤더 + 섹션데이터s
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SectionPacket
    {
        // 테스트 해볼 부분 > 적용 or 미적용 할지
        [MarshalAs(UnmanagedType.ByValArray)]
        public CommonHeader commonHeader;
        [MarshalAs(UnmanagedType.ByValArray)]
        public SectionData[] sectionDatas;
    }

    /// <summary>
    /// 768 바이트
    /// 헤더? 데이터
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CommonHeader
    {

        // header : 0 - 고정
        public byte idx;
        // port : 랜포트 번호
        public byte port;

        // rsv1 : 헤더 리저브
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 - 2)]
        private byte[] rsv1;


        // 전체 너비/높이
        public byte totalWidth;
        public byte totalHeight;
        // 모듈번호
        public byte moduleIdx;
        // 섹션(SectionData)갯수
        public byte sectionCnt;

        // rsv2 : 데이터 리저브
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 768 - 16 - 4)]
        private byte[] rsv2;
    }

    /// <summary>
    /// 768 바이트
    /// 박스 데이터
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SectionData
    {

        // header : 0 - 고정 / Section 추가될때마다 +1
        public byte idx;
        // port : 랜포트 번호
        public byte port;
        // rsv1 : 헤더 리저브
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 - 2)]
        private byte[] rsv1;

        // 영역
        public byte sx;
        public byte sy;
        public byte width;
        public byte height;

        // 모듈번호
        public byte moduleIdx;

        //rsv2 : 데이터 리저브
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 768 - 16 - 5)]
        private byte[] rsv2;
    }
}

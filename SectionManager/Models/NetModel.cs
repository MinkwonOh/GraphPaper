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
    /// 64 바이트
    /// 패킷의 헤더
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CommonHeader
    {
        /// <summary>
        /// 2차 헤더 - CommonHeader의 idx는 0 고정, Section 부터 + 1
        /// </summary>
        public byte idx;

        /// <summary>
        /// port - 랜포트 번호 - 0번 부터? 1번 부터 ? 미정
        /// </summary>
        public byte port;

        /// <summary>
        /// 헤더 데이터의 2차 헤더 리저브
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 - 2)]
        private byte[] rsv1;

        /// <summary>
        /// 전체 너비, 최대 2048px -> 2바이트 사용
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] totalWidth;

        /// <summary>
        /// 전체 높이, 최대 2바이트 사용
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] totalHeight;

        /// <summary>
        /// 섹션에 설정할 모듈 번호, 0부터 시작
        /// </summary>
        public byte moduleIdx;

        /// <summary>
        /// 섹션(SectionData)의 갯수 - total 99개
        /// </summary>
        public byte sectionCnt;

        /// <summary>
        /// 헤더 데이터의 데이터 리저브
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64 - 16 - 6)]
        private byte[] rsv2;
    }

    /// <summary>
    /// 64 바이트
    /// 패킷의 박스 데이터
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SectionData
    {
        /// <summary>
        /// 2차 헤더 - CommonHeader의 idx는 0 고정, Section 부터 + 1
        /// </summary>
        public byte idx;

        /// <summary>
        /// port - 랜포트 번호
        /// </summary>
        public byte port;

        /// <summary>
        /// 헤더 데이터의 2차 헤더 리저브
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 - 2)]
        private byte[] rsv1;

        /// <summary>
        /// 영역 크기 데이터, 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] sx;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] sy;
        public byte width;
        public byte height;

        /// <summary>
        /// 섹션에 설정할 모듈 번호, 0부터 시작
        /// </summary>
        public byte moduleIdx;

        /// <summary>
        /// 헤더 데이터의 데이터 리저브
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64 - 16 - 7)]
        private byte[] rsv2;
    }
}

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
    /// HeaderData + SectionData[]
    /// </summary>
    public class SectionPacket
    {
        public HeaderData headerData;
        public SectionData[] sectionDatas;
    }

    /// <summary>
    /// 64 바이트
    /// 패킷의 헤더
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct HeaderData
    {
        /// <summary>
        /// 2차 헤더 - HeaderData의 idx는 0 고정, Section 부터 + 1
        /// </summary>
        public byte idx;

        /// <summary>
        /// port - 랜포트 번호 - 0번 부터? 1번 부터 ? 미정
        /// </summary>
        public byte port;

        /// <summary>
        /// HeaderData의 2차 헤더 리저브 16 - 2 = 14
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        private byte[] rsv1;

        /// <summary>
        /// 섹션에 설정할 모듈 번호, 0부터 시작
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] moduleIdx;

        /// <summary>
        /// 섹션(SectionData)의 갯수 - total 255개
        /// </summary>
        public byte sectionCnt;

        /// <summary>
        /// 전체 너비/높이, 최대 2048px -> 2바이트씩 사용
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] totalWidth;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] totalHeight;

        /// <summary>
        /// HeaderData의 데이터 리저브 64 - 16(2차 header) - 7(data) = 41
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 41)]
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
        /// 2차 헤더 - HeaderData의 idx는 0 고정, Section 부터 + 1
        /// </summary>
        public byte idx;

        /// <summary>
        /// port - 랜포트 번호
        /// </summary>
        public byte port;

        /// <summary>
        /// SectionData의 2차 헤더 리저브 16 - 2 = 14
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        private byte[] rsv1;

        /// <summary>
        /// 섹션에 설정할 모듈 번호, 0부터 시작
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] moduleIdx;

        /// <summary>
        /// 영역 크기 데이터, 2바이트씩 사용
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] sx;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] sy;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] width;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] height;

        /// <summary>
        /// SectionData의 데이터 리저브 64 - 16(2차 header) - 10(data) = 38
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 38)]
        private byte[] rsv2;
    }
}

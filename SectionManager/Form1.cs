using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MagiColor.IO;
using MagiColor.Net;
using Newtonsoft.Json;
using SectionManager.Models;
using SectionManager.StaticClass;

namespace SectionManager {
    public partial class Form1 : Form {

        private PacketManager packetManager = null;
        private bool isConn = false;
        private Preference preference;
        private SectionDrawerControl sdc;

        public Form1() {
            InitializeComponent();
            InitializeEvent();
            InitializeValue();
        }

        private void InitializeEvent() {
            btnConnect.Click += (s, e) => btnConnClicked();
            btnDisconnect.Click += (s, e) => btnDisConnClicked();
            btnSend.Click += (s, e) => btnSendClicked();
            btnSave.Click += (s, e) => btnSaveClicked();
            btnLoad.Click += (s, e) => btnLoadClicked();

            //sectionDrawerControl1.SaveEventFired += (s, e) => { Console.WriteLine("SaveEventFired"); };
        }

        private void btnLoadClicked()
        {

            btnDisConnClicked();

            string filePath = string.Empty;
            // filedialog > cfg파일 선택
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.InitialDirectory = "C:\\";
                ofd.Filter = "ccfg files (*.ccfg)|*.ccfg";
                ofd.FilterIndex = 0;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK) { 
                    filePath = ofd.FileName;
                
                    if (File.Exists(filePath))
                    {
                        preference = Preference.Load(filePath);

                        tbxIp.EditValue = preference.IPAddress;
                        nmrcPort.Value = preference.NetPort;
                        if (sdc != null) { 
                            sdc.Model = preference.DrawerModel;
                        }
                    }
                }
            }
        }

        private void btnSaveClicked()
        {
            if (preference == null) return;
            GetCurrentData();
            preference.Save();
        }

        private void btnSendClicked() {
            try
            {
                GetCurrentData();

                var drawerModel = preference.DrawerModel;
                var boxGroupList = drawerModel.BoxGroupList;

                List<SectionPacket> ListSectionPacket = new List<SectionPacket>();

                for (int i = 0; i < boxGroupList.Count; i++)
                {
                    var boxList = boxGroupList[i].BoxList;

                    SectionData[] SectionDataList = new SectionData[boxList.Count];

                    if (boxList.Count == 0) continue;

                    int minSX = boxList[i].Rect.X;
                    int minSY = boxList[i].Rect.Y;
                    int maxEX = boxList[i].Rect.X + boxList[i].Rect.Width;
                    int maxEY = boxList[i].Rect.Y + boxList[i].Rect.Height;

                    byte[] moduleBytes = new byte[] { (byte)(boxGroupList[i].Module >> 8), (byte)boxGroupList[i].Module };

                    // 포트별 섹션
                    for (int j = 0; j < boxList.Count; j++)
                    {
                        var box = boxList[j];

                        minSX = boxList[j].Rect.X < minSX ? boxList[i].Rect.X : minSX;
                        minSY = boxList[j].Rect.Y < minSY ? boxList[i].Rect.Y : minSY;
                        maxEX = boxList[j].Rect.X + boxList[j].Rect.Width > maxEX ? boxList[j].Rect.X + boxList[j].Rect.Width : maxEX;
                        maxEY = boxList[j].Rect.Y + boxList[j].Rect.Height > maxEY ? boxList[j].Rect.Y + boxList[j].Rect.Height : maxEY;

                        byte[] sxBytes = new byte[2] { (byte)(box.Rect.X >> 8), (byte)box.Rect.X };
                        byte[] syBytes = new byte[2] { (byte)(box.Rect.Y >> 8), (byte)box.Rect.Y };
                        byte[] wBytes = new byte[2] { (byte)(box.Rect.Width >> 8), (byte)box.Rect.Width };
                        byte[] hBytes = new byte[2] { (byte)(box.Rect.Height >> 8), (byte)box.Rect.Height };

                        SectionData sd = new SectionData
                        {
                            idx = (byte)(j + 1),
                            port = (byte)box.tagPort,
                            sx = sxBytes,
                            sy = syBytes,
                            width = wBytes,
                            height = hBytes,
                            moduleIdx = moduleBytes
                        };
                        SectionDataList[j]=sd;
                    }

                    // 순서 어떻게?
                    byte[] totW = new byte[2] { (byte)(maxEX - minSX >> 8), (byte)(maxEX - minSX)};
                    byte[] totH = new byte[2] { (byte)(maxEY - minSY >> 8), (byte)(maxEY - minSY)};

                    // 헤더
                    HeaderData sh = new HeaderData
                    {
                        idx = 0,
                        port = (byte)boxGroupList[i].BoxList[0].tagPort,
                        moduleIdx = moduleBytes,
                        sectionCnt = (byte)boxList.Count,
                        totalWidth = totW,
                        totalHeight = totH
                    };

                    ListSectionPacket.Add(new SectionPacket
                    {
                        headerData = sh,
                        sectionDatas = SectionDataList
                    });
                }

                foreach (var packet in ListSectionPacket) {
                    byte[] headerPacket = StructConverter.StructToByte(packet.headerData);
                    ///ShortPacket sp = new ShortPacket { CMD = (byte)MagiColor.Net.Command.AdvertAdd, DAT = packetbytes};
                    // 임시로 커맨드는 0x70
                    /*ShortPacket sp = new ShortPacket { CMD = 0x70, DAT = headerPacket };
                    Packet recvPacket = packetManager.SendWaitPacket(sp, repeat: 0);*/

                    for (int k = 0; k < packet.sectionDatas.Length; k++) {
                        byte[] sectionPacket = StructConverter.StructToByte(packet.sectionDatas[k]);
                        /*sp = new ShortPacket { CMD = 0x70, DAT = sectionPacket };
                        recvPacket = packetManager.SendWaitPacket(sp, repeat: 0);*/
                    }
                }
                

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Form1.cs - btnSendClicked - {ex.Message}");
                throw;
            }

        }

        private void btnConnClicked() {
            packetManager.IO = new Tcp { Host = tbxIp.EditValue.ToString(), Port = (int)nmrcPort.Value};

            isConn = true;
            EnableControl();
        }

        private void btnDisConnClicked() {
            if (packetManager.IO != null) {
                packetManager.Stop();
            }

            isConn = false;
            EnableControl();
        }

        private void EnableControl() {
            btnConnect.Enabled = !isConn;

            btnDisconnect.Enabled = isConn;
            btnSend.Enabled = isConn;
        }

        private void InitializeValue() {

            preference = Preference.Load();

            sdc = new SectionDrawerControl(ref preference.DrawerModel);
            sdc.Dock = DockStyle.Fill;
            //sectionDrawerControl1 = new SectionDrawerControl(preference.DrawerModel);
            tbxIp.EditValue = preference.IPAddress;
            nmrcPort.Value = preference.NetPort;
            //sdc.Model = preference.DrawerModel;

            pnlSectionCtrl.Controls.Add(sdc);

            packetManager = new PacketManager();
            packetManager.AddPacketType<ShortPacket>();

            this.MinimumSize = new Size(sdc.MinimumSize.Width + 50, sdc.MinimumSize.Height + 100);
        }
        private void GetCurrentData()
        {
            //preference.DrawerModel = sectionDrawerControl1.Model;
            // total width / height 정하는 부분

            preference.NetPort = (int)nmrcPort.Value;
            preference.IPAddress = tbxIp.EditValue.ToString();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            packetManager.Stop();

            /*preference.DrawerModel = sectionDrawerControl1.Model;
            preference.NetPort = (int)nmrcPort.Value;
            preference.IPAddress = tbxIp.EditValue.ToString();*/
            GetCurrentData();

            //sectionDrawerControl1.Dispose();
            preference.Dispose();
            preference = null;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MagiColor.IO;
using MagiColor.Net;
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
            
        }

        private void btnSaveClicked()
        {
            if (preference == null) return;
            GetCurrentData();
            preference.Save();
        }

        private void btnSendClicked() {
            
            GetCurrentData();

            var drawerModel = preference.DrawerModel;

            var boxGroupList = drawerModel.BoxGroupList;

            List<SectionPacket> ListSectionPacket = new List<SectionPacket>();
            
            for (int i = 0; i < boxGroupList.Count; i++) {

                var boxList = boxGroupList[i].BoxList;

                List<SectionData> SectionDataList = new List<SectionData>();

                if (boxList.Count == 0) continue;

                int minSX = boxList[i].Rect.X;
                int minSY = boxList[i].Rect.Y;
                int maxEX = boxList[i].Rect.X + boxList[i].Rect.Width;
                int maxEY = boxList[i].Rect.Y + boxList[i].Rect.Height;

                // 포트별 섹션
                for (int j =0; j < boxList.Count; j++) {
                    var box = boxList[j];

                    minSX = boxList[i].Rect.X < minSX ? boxList[i].Rect.X : minSX;
                    minSY = boxList[i].Rect.Y < minSY ? boxList[i].Rect.Y : minSY;
                    maxEX = boxList[i].Rect.X + boxList[i].Rect.Width > maxEX ? boxList[i].Rect.X + boxList[i].Rect.Width : maxEX;
                    maxEY = boxList[i].Rect.Y + boxList[i].Rect.Height > maxEY ? boxList[i].Rect.Y + boxList[i].Rect.Height : maxEY;

                    SectionData sd = new SectionData { 
                        idx = (byte)(j+1),
                        port = (byte)box.tagPort,
                        sx = (byte)box.Rect.X,
                        sy = (byte)box.Rect.Y,
                        width = (byte)box.Rect.Width,
                        height = (byte)box.Rect.Height,
                        moduleIdx = (byte)boxGroupList[i].Module
                    };
                    SectionDataList.Add(sd);
                }

                // 헤더
                CommonHeader sh = new CommonHeader
                {
                    idx = 0,
                    port = (byte)preference.NetPort,
                    moduleIdx = (byte)boxGroupList[i].Module,
                    sectionCnt = (byte)boxList.Count,
                    totalWidth = (byte)(maxEX - minSX), // total byte 몇 바이트로?
                    totalHeight = (byte)(maxEY- minSY) // total byte 몇 바이트로?
                };

                ListSectionPacket.Add(new SectionPacket { 
                    commonHeader = sh,
                    sectionDatas = SectionDataList.ToArray()
                });

            }

            byte[] packetbytes = StructConverter.StructToByte(ListSectionPacket.ToArray());

            //ShortPacket sp = new ShortPacket { CMD = (byte)MagiColor.Net.Command.AdvertAdd, DAT = packetbytes};
            // 임시로 커맨드는 0x70
            ShortPacket sp = new ShortPacket { CMD = 0x70, DAT = packetbytes };
            Packet recvPacket = packetManager.SendWaitPacket(sp, repeat:0);

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
            sdc = new SectionDrawerControl();
            sdc.Dock = DockStyle.Fill;

            tbxIp.EditValue = preference.IPAddress;
            nmrcPort.Value = preference.NetPort;
            sdc.Model = preference.DrawerModel;

            pnlSectionCtrl.Controls.Add(sdc);

            packetManager = new PacketManager();
            packetManager.AddPacketType<ShortPacket>();
            
        }

        private void GetCurrentData() {
            preference.DrawerModel = sdc.Model;
            // total width / height 정하는 부분

            preference.NetPort = (int)nmrcPort.Value;
            preference.IPAddress = tbxIp.EditValue.ToString();
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            packetManager.Stop();

            GetCurrentData();

            //sectionDrawerControl1.Dispose();
            preference.Dispose();
            preference = null;
        }
    }
}

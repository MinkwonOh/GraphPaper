using System;
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

namespace SectionManager {
    public partial class Form1 : Form {

        private PacketManager packetManager = null;
        private bool isConn = false;
        private Preference preference;

        public Form1() {
            InitializeComponent();
            InitializeEvent();
            InitializeValue();
        }

        private void InitializeEvent() {
            btnConnect.Click += (s, e) => btnConnClicked();
            btnDisconnect.Click += (s, e) => btnDisConnClicked();
            btnSend.Click += (s, e) => btnSendClicked();
        }

        private void btnSendClicked() {
            
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

            sectionDrawerControl1 = new SectionDrawerControl(preference.DrawerModel);
            tbxIp.EditValue = preference.IPAddress;
            nmrcPort.Value = preference.NetPort;

            packetManager = new PacketManager();
            packetManager.AddPacketType<ShortPacket>();
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            packetManager.Stop();

            preference.DrawerModel = sectionDrawerControl1.Model;
            preference.NetPort = (int)nmrcPort.Value;
            preference.IPAddress = tbxIp.EditValue.ToString();

            sectionDrawerControl1.Dispose();
            preference.Dispose();
            preference = null;
        }
    }
}

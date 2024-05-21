using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SectionManager.Models {

    public enum Model { 
        M51, M52, M91, M92
    }

    public class Preference : IDisposable {

        public static string PreferenceFilepath = Path.Combine(Application.StartupPath, $"{typeof(Preference).Name}.config");
        
        public Model Model;
        public int NetPort;
        public string IPAddress;
        public DrawerModel DrawerModel;

        public void Dispose() {
            Save();
        }

        internal static Preference Load() {
            if (File.Exists(PreferenceFilepath)) {
                var json = File.ReadAllText(PreferenceFilepath);
                return JsonConvert.DeserializeObject<Preference>(json);
            }
            else {
                return new Preference {
                    Model = Model.M51,
                    NetPort = 7531,
                    IPAddress = "192.168.0.1",
                    DrawerModel = new DrawerModel()
                };
            }
        }

        internal void Save() {
            var json = JsonConvert.SerializeObject(this, Formatting.None);
            File.WriteAllText(PreferenceFilepath, json);
        }
    }
}

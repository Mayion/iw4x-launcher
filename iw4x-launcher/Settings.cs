using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iw4x_launcher
{
    class SettingsClass
    {
        private static SettingsClass instance;
        public static SettingsClass Settings
        {
            get
            {
                if (instance == null)
                    instance = new SettingsClass();
                return instance;
            }
        }
        public int NotifiedServers = 0;
        public Dictionary<string, int> NotifyServers = new Dictionary<string, int>();
        public List<string> GameVersions = new List<string>();

    }
}

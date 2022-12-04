using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileTransfer
{
    public class EPreset
    {
        public string PRESETNAME { get; set; }
        public string IPADDR { get; set; }
        public string PORT { get; set; }

        public EPreset()
        {
            Clear();
        }

        public EPreset(string pPresetName, string pIpAddr, string pPort)
        {
            PRESETNAME = pPresetName;
            IPADDR = pIpAddr;   
            PORT = pPort;
        }

        public void Clear()
        {
            PRESETNAME = "Preset";
            IPADDR = "Empty";
            PORT = "Empty";
        }
    }
}

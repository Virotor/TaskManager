using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class NetworkAdapter
    {
        public string AdapterType { get; set; }

        public string MACAddress { get; set; }

        public string Manufacturer { get; set; }

        public UInt64 MaxSpeed { get; set; }

        public string Name { get; set; }

        public string[] NetworkAddresses { get; set; }

        public UInt64 Speed { get; set; }

    }
}

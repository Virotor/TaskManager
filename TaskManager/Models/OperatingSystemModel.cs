using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    internal class OperatingSystemModel
    {
        public string BuildNumber { get; set; }

        public string BuildType { get; set; }
        public string Caption { get; set; }
        public string Name { get; set; }
        public string OSArchitecture { get; set; }
        public UInt64 TotalSwapSpaceSize { get; set; }
        public UInt64 TotalVirtualMemorySize { get; set; }
        public Int16 CurrentTimeZone { get; set; }
        public string Version { get; set; }
        public string LastBootUpTime { get; set; }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class ProcessInfo
    {
        public event Action UpdateInfoMemoryUsage;
        public event Action UpdateInfoCPUUsage;


        private PerformanceCounter cpuCounter;
        public string Caption { get; set; }
        public string Name { get; set; }
        public string ProcessOwner { get; set; }
        public string CreationDate { get; set; }
        public string ExecutablePath { get; set; }
        public UInt32 ParentProcessId { get; set; }
        public string Status { get; set; }
        public UInt64 PeakVirtualSize { get; set; }
        public UInt32? Priority { get; set; }
        public UInt32 ProcessId { get; set; }

    }
}

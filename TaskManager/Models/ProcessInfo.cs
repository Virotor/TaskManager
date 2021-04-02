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
        private PerformanceCounter ramCounter; 
        private PerformanceCounter cpuCounter; 



        public string Caption { get; set; }
        public string Name { get; set; }
        public string ProcessOwner { get; set; }
        public string CreationDate { get; set; }
        public string ExecutablePath { get; set; }
        public UInt32 ParentProcessId { get; set; }
        public string Status { get; set; }
        public UInt64 WorkingSetSize { get; set; }
        public UInt32? Priority { get; set; }
        public UInt32 ProcessId { get; set; }


        public ProcessInfo(Int32 pid)
        {
            //ramCounter = new PerformanceCounter("Process", "Working Set", Process.GetProcessById(pid).ProcessName);
            //cpuCounter = new PerformanceCounter("Process", "% Processor Time", Process.GetProcessById(pid).ProcessName);
        }

    }


    class ProcessComparer : IEqualityComparer<Process>
    {

        public bool Equals(Process x, Process y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Process obj)
        {
            return (obj.Id.ToString() + obj.ProcessName).GetHashCode();
        }
    }

    class ProcessComparerMemoryUsage : IEqualityComparer<Process>
    {

        public bool Equals(Process x, Process y)
        {
            return (x.Id == y.Id && x.WorkingSet64 != y.WorkingSet64);
        }

        public int GetHashCode(Process obj)
        {
            return (obj.Id.ToString() + obj.ProcessName).GetHashCode();
        }
    }
}

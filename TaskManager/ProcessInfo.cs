using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class ProcessInfo
    {
        public event Action UpdateInfo;


        private PerformanceCounter cpuCounter;
        public string ProcessName { get; set; }

        public string ProcessOwner { get; set; }

        public DateTime ProcessTimeCreate { get; set; }

        public string ProcessStatus { get; set; }

        public double ProcessMemoryUsage { get; set; }

        public float ProcessProcessTimeUsage { get; set;}

        public string ProcessHandle { get; set; }

        public int ProcessPriority { get; set; }
        
        public ProcessInfo()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        public async void UpdateInfoMemory()
        {
            while (true)
            {
                await Task.Delay(2000);
                var temp = Process.GetProcessesByName(ProcessName).FirstOrDefault();               
                ProcessMemoryUsage = temp == null ? 0 :Math.Round((double)(temp.WorkingSet64 / (1024 * 1024)));
                if (ProcessName == "chrome")
                {
                    Console.WriteLine(String.Format("ProcessMemory = {0} ProcessName - {1}", ProcessMemoryUsage, ProcessName));
                    UpdateInfo?.Invoke();
                }
                   
            }
        }

        public async void UpdateCpuUsage()
        {

            while (true)
            {
                await Task.Delay(2000);
                ProcessProcessTimeUsage = cpuCounter.NextValue();
                if(ProcessName == "chrome")
                {
                    Console.WriteLine(String.Format("ProcessUsage = {0} ProcessName = {1}", ProcessProcessTimeUsage, ProcessName));
                   // UpdateInfo?.Invoke();
                }

            }
        }

    }
}

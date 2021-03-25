using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManager
{
    class ProcessManager
    {
        List<Process> processes = new List<Process>();

        public delegate void ProcessHandler(ProcessInfo process);

        public event ProcessHandler NotifyStartNewProcess;
        public event ProcessHandler NotifyStopProcess;
        

        ManagementEventWatcher startWatch;
        ManagementEventWatcher stopWatch;


        public ProcessManager()
        {
            //InitUpdate();
        }

/*        private async void InitUpdate()
        {
            while (true)
            {
                await Task.Delay(2000);
                NotifyUpdateProcess?.Invoke();
            }
        }*/
        public void InitStopStartProcess()
        {
           startWatch = new ManagementEventWatcher(
                new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            startWatch.EventArrived += StartProcessEvent;
            startWatch.Start();
             stopWatch = new ManagementEventWatcher(
                new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
            stopWatch.EventArrived += StopProcessEvent;
            stopWatch.Start();
        }


        public void EndStopStartProcess()
        {
            startWatch.Stop();
            stopWatch.Stop();
        }


        private IEnumerable<Process> GetProcesses()
        {
            processes.Clear();
            return Process.GetProcesses();
        }

        public List<ProcessInfo> GetProcessInfo()
        {
            List<Process> processes = GetProcesses().ToList();
            List<ProcessInfo> processInfos = new List<ProcessInfo>();
            DateTime now = DateTime.Now;
            processes.AsParallel().ForAll(elem =>
            {
                float cpuUsage = 0;
                using (PerformanceCounter pc = new PerformanceCounter("Process", "Working Set - Private", elem.ProcessName), cpu = new PerformanceCounter("Process", "% Processor Time", elem.ProcessName))
                {
                    
                }
                try
                {
                    var temp = new ProcessInfo()
                    {
                        ProcessName = elem.ProcessName,
                        ProcessHandle = elem.Id.ToString(),
                        ProcessMemoryUsage = Math.Round((double)elem.WorkingSet64 / (1024 * 1024)),
                        ProcessPriority = elem.BasePriority,
                        ProcessStatus = "",
                        ProcessOwner = "",
                        ProcessProcessTimeUsage = elem.UserProcessorTime.Ticks
                    };
                    temp.UpdateInfoMemory();
                    temp.UpdateCpuUsage();
                    processInfos.Add(temp);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            });
            Console.WriteLine(DateTime.Now.Subtract(now).TotalMilliseconds);
            return processInfos;
        }


        public void StartProcessEvent(object sender, EventArrivedEventArgs e)
        {
            NotifyStartNewProcess?.Invoke(new ProcessInfo()
            {
                ProcessName = e.NewEvent.Properties["ProcessName"].Value as string,
               // ProcessHandle = ((int)e.NewEvent.Properties["Id"].Value).ToString(),
               // ProcessMemoryUsage = Math.Round((double)e.NewEvent.Properties["WorkingSet64"].Value / (1024 * 1024)),
                //ProcessPriority = (int)e.NewEvent.Properties["BasePriority"].Value,
                //ProcessStatus = "",
               //ProcessOwner = "",
               // ProcessProcessTimeUsage = ((TimeSpan)e.NewEvent.Properties["UserProcessorTime"].Value).Ticks
            });
        }

        public void StopProcessEvent(object sender, EventArrivedEventArgs e)
        {

        }


    }
}

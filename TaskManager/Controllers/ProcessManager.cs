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
        List<ProcessInfo> processes = new List<ProcessInfo>();

        public delegate void ProcessHandler(UInt32 processId);

        public event ProcessHandler NotifyStartNewProcess;
        public event ProcessHandler NotifyStopProcess;

        public event Action NotifyToUpdate;


        ManagementEventWatcher startWatch;
        ManagementEventWatcher stopWatch;




        public ProcessManager()
        {
            //InitUpdate();
        }


        public void DeleteProcess(int pid)
        {
            if(processes.Any(x=>x.ProcessId == pid))
            {
                processes.Remove(processes.Find(x => x.ProcessId == pid));
            }
        }

        public void InitStopStartProcess()
        {
            startWatch = new ManagementEventWatcher(
                new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace WITHIN 1"));
            startWatch.EventArrived += StartProcessEvent;
            startWatch.Start();
            //startThread.Start();
             stopWatch = new ManagementEventWatcher(
                new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
            stopWatch.EventArrived += StopProcessEvent;
            stopWatch.Start();
            //stopThread.Start();
        }


        public void EndStopStartProcess()
        {
            startWatch.Stop();
            stopWatch.Stop();
        }

        private async void InvokeUpdate()
        {
            while (true)
            {
                await Task.Delay(2000);
                NotifyToUpdate?.Invoke();
            }
        }

        public List<ProcessInfo> GetProcessInfo()
        {
            processes = new List<ProcessInfo>();
            using (var process = new ManagementObjectSearcher("Select Caption,CreationDate,ExecutablePath, Status,ParentProcessId,PeakVirtualSize,Priority,ProcessId,Name from Win32_Process").Get())
            {
                foreach(var _ in process)
                {
                    ProcessInfo temp = TakeInfoAboutProcess(_);
                    processes.Add(temp);
                }
            }

            return processes;
        }

        private ProcessInfo TakeInfoAboutProcess(ManagementBaseObject _)
        {
            return new ProcessInfo()
            {
                Caption = _["Caption"].ToString(),
                CreationDate = _["CreationDate"].ToString(),
                ExecutablePath = _["ExecutablePath"] == null ? "" : _["ExecutablePath"].ToString(),
                Status = _["Status"] == null ? "" : _["Status"].ToString(),
                ParentProcessId = Convert.ToUInt32(_["ParentProcessId"]),
                PeakVirtualSize = Convert.ToUInt64(_["PeakVirtualSize"]),
                Priority = Convert.ToUInt32(_["Priority"]),
                ProcessId = Convert.ToUInt32(_["ProcessId"]),
                Name = _["Name"].ToString()
            };
        }

        public void StartProcessEvent(object sender, EventArrivedEventArgs e)
        {
            NotifyStartNewProcess?.Invoke(Convert.ToUInt32(e.NewEvent.Properties["ProcessId"].Value));
        }

        public void StopProcessEvent(object sender, EventArrivedEventArgs e)
        {
            NotifyStopProcess?.Invoke(Convert.ToUInt32(e.NewEvent.Properties["ProcessId"].Value));
            this.DeleteProcess(Convert.ToInt32(e.NewEvent.Properties["ProcessId"].Value));
        }

        public  List<ProcessInfo> TakeProcessById()
        {
            List<ProcessInfo> processInfos = new List<ProcessInfo>();
            using (var process = new ManagementObjectSearcher($"Select Caption,CreationDate,ExecutablePath, Status,ParentProcessId,PeakVirtualSize,Priority,ProcessId from Win32_Process ").Get())
            {
                foreach (var _ in process)
                {
                    //processInfos.Add(TakeInfoAboutProcess(_));
                }
            }
            processInfos = processInfos.Except(processes).ToList();

            processes.AddRange(processInfos);

            return processInfos;
        }


        public void KillProcess(Process process)
        {
            try
            {
                process.Kill();
                process.WaitForExit();
            }
            catch (ArgumentException) { }
        }

        public void KillProcessAndChild(Int32 pid)
        {
         
            if (pid == 0)
            {
                return;
            }

            dynamic parentIdList = processes.Where(x => x.ProcessId == pid).ToList();
            if(parentIdList == null || parentIdList.Count == 0)
            {
                return;
            }
            var parentId = parentIdList[0].ParentProcessId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher($"Select ParentProcessID From Win32_Process where ParentProcessID = {parentId}");

            foreach (var process in searcher.Get())
            {
                KillProcessAndChild(Convert.ToInt32(process["ParentProcessID"]) );
            }
            try
            {
                Process p = Process.GetProcessById(pid);
                p.Kill();
                p.WaitForExit();
            }
            catch (ArgumentException) { }
        }

        public int GetProcessParentId(Process p)
        {
            int processParentID = 0;
            try
            {
                ManagementObject managementObject = new ManagementObject($"win32_process.handle='{p.Id}'");
                managementObject.Get();
                processParentID = Convert.ToInt32(managementObject["ParentProcessId"]);
            }
            catch (ArgumentException e) {}
            return processParentID;
        }

    }
}

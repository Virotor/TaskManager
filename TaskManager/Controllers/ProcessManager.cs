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
        private List<ProcessInfo> processes = new List<ProcessInfo>();
        List<Process> processesOld = new List<Process>();

        public IEnumerable<Process> CurrentRunProcess { get
            {
                return Process.GetProcesses().Intersect(processesOld,new ProcessComparerMemoryUsage()).ToList();
            } }

        public List<ProcessInfo> Processes { 
            get {
                processes = GetProcessInfo();
                return processes;
            } 
            private set {
                processes = value;
            }
        }

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
            if (processesOld.Any(x => x.Id == pid))
            {
                processesOld.Remove(processesOld.Find(x => x.Id == pid));
            }
        }

        public void InitStopStartProcess()
        {
            startWatch = new ManagementEventWatcher(
                new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace WITHIN 1"));
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
            processesOld = Process.GetProcesses().ToList();
            using (var process = new ManagementObjectSearcher("Select Caption,CreationDate,ExecutablePath, Status,ParentProcessId,WorkingSetSize,Priority,ProcessId,Name from Win32_Process").Get())
            {
                foreach(var _ in process)
                {
                    ProcessInfo temp = TakeInfoAboutProcess(_);
                    temp.WorkingSetSize =(ulong) processesOld.Where(x => x.Id == temp.ProcessId).FirstOrDefault().WorkingSet64;
                    processes.Add(temp);
                }
            }
            
            return processes;
        }

        private ProcessInfo TakeInfoAboutProcess(ManagementBaseObject _)
        {
            return new ProcessInfo(Convert.ToInt32(_["ProcessId"]))
            {
                Caption = _["Caption"].ToString(),
                CreationDate = _["CreationDate"].ToString(),
                ExecutablePath = _["ExecutablePath"] == null ? "" : _["ExecutablePath"].ToString(),
                Status = _["Status"] == null ? "" : _["Status"].ToString(),
                ParentProcessId = Convert.ToUInt32(_["ParentProcessId"]),
               // WorkingSetSize =_["WorkingSetSize"] is null ? 0 : Convert.ToUInt64(_["WorkingSetSize"]),
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

        public  List<Process> TakeNewProcesses()
        {
            List<Process> processNew = Process.GetProcesses().ToList();
            processNew = processNew.Except(processesOld,new ProcessComparer()).ToList();
            processesOld.AddRange(processNew);
            TakeNewProcessesInfo(processNew);
            return processNew;
        }

        public void TakeNewProcessesInfo(List<Process> processes)
        {
            if (processes.Count == 0)
            {
                return;
            }
            List<ProcessInfo>  newProcesses = new List<ProcessInfo>();
            foreach(var elem in processes)
            {
               using (var process = new ManagementObjectSearcher($"Select Caption,CreationDate,ExecutablePath," +
                   $" Status,ParentProcessId,PeakVirtualSize,Priority,ProcessId," +
                   $" Name from Win32_Process where ProcessId = {elem.Id}").Get())
                {
                    foreach (var _ in process)
                    {
                        ProcessInfo temp = TakeInfoAboutProcess(_);
                        newProcesses.Add(temp);
                    }
                }
            }
           

            this.processes.AddRange(newProcesses);
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

        public void EndProcessTree(Int32 imageName)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = $"/PID {imageName} /f /t",
                CreateNoWindow = true,
                UseShellExecute = false
            }).WaitForExit();
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

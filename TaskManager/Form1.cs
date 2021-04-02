using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TaskManager.Controllers;

namespace TaskManager
{
    

    public partial class Form1 : Form
    {

        private readonly double fromKBtoGB = 1024*1024;
        private ProcessManager processManager = null;
        DataTable dataTable = new DataTable();
        List<ProcessInfo> runningProcess = new List<ProcessInfo>();
        private Dictionary<ProcessInfo, ListViewItem> processInfoListView = new Dictionary<ProcessInfo, ListViewItem>();
        private RAMInfo ramInfo;
        private ProcessorInfo processorInfo;
        private VideoInfo videoInfo;
        private OSInfo osInfo;
        private DataGridViewCellEventArgs mouseLocation;

        public Form1()
        {
            InitializeComponent();
        }

        private  void Form1_Load(object sender, EventArgs e)
        {
            osInfo = new OSInfo();
            ramInfo = new RAMInfo();
            videoInfo = new VideoInfo();
            processorInfo = new ProcessorInfo();
            processManager = new ProcessManager();
          
            processManager.InitStopStartProcess();
            processManager.NotifyStopProcess += DeleteProcess;
            processManager.NotifyStartNewProcess += StartNewProcess;
            
            InitCharts();
            RefreshMemory();
            InitDataTable();
            UpdateChartRAM();
            TakeInfoAboutOS();
            TakeInfoAboutRAM();
            UpdateChartProcessor();
            TakeInfoAboutProcessor();
            TakeInfoAboutVideoAdapter();
        }


        private async void RefreshMemory()
        {
            while (true)
            {
                await Task.Delay(1000);
                foreach(var process in processManager.CurrentRunProcess)
                {
                    foreach(DataRow elem in dataTable.Rows)
                    {
                        if (elem.Field<UInt32>("ID") ==process.Id)
                        {
                            elem.SetField("Память MB",Math.Round( Convert.ToDouble(process.PrivateMemorySize64) / (1024 * 1024),2));
                            break;
                        }
                    }
                }
                dataGridView1.Update();
            }
        }

        private void StartNewProcess(uint processId)
        {

                var _ = processManager.TakeNewProcesses();
                if (_ is null || _.Count is 0)
                {
                    return;
                }
                Invoke(new Action(() =>
                {
                    foreach(var p  in _)
                    {
                        dataTable.Rows.Add(p.ProcessName, p.Id, " ", p.BasePriority, p.PeakVirtualMemorySize64 / (1024 * 1024));
                        //dataGridView1.Update();
                    }
                }));
        }
       
        private void DeleteProcess(uint processId)
        {
            foreach(DataGridViewRow elem in dataGridView1.Rows)
            {
                var _ = Convert.ToUInt32(elem.Cells["ID"].Value);
                if (_ == processId)
                {
                    Invoke(new Action(() =>
                    {
                        dataGridView1.Rows.Remove(elem);
                        dataGridView1.Update();
                    }));
                    return;
                }
            }
        }

        private  void TakeInfoAboutVideoAdapter()
        {
            var videoInfos = videoInfo.TakeInfoAboutDivice();
            panelVideoAdapter.RowCount = videoInfo.TakeInfoAboutDivice().Count;
            if (panelVideoAdapter.RowCount == 0)
            {
                return;
            }
            videoAdapterInfo.Text = String.Format("{0}\n{1}MB\n{2}\n{3}\n{4}\n", videoInfos[0].AdapterCompatibility, videoInfos[0].AdapterRAM/(1024 * 1024), videoInfos[0].Name, videoInfos[0].VideoMemoryType, videoInfos[0].VideoProcessor);
            for (int i=1; i< panelVideoAdapter.RowCount; i++)
            {
                Label tempDescription = videoAdapterDiscriprion;
                panelVideoAdapter.SetCellPosition(tempDescription,new TableLayoutPanelCellPosition(0,i-1));
                Label tempInfo = videoAdapterInfo;
                tempInfo.Text = String.Format("{0}\n{1}MB\n{2}\n{3}\n{4}\n", videoInfos[i].AdapterCompatibility, videoInfos[i].AdapterRAM/(1024*1024),videoInfos[i].Name,  videoInfos[i].VideoMemoryType, videoInfos[i].VideoProcessor);
                panelVideoAdapter.SetCellPosition(tempInfo, new TableLayoutPanelCellPosition(1, i - 1));
            }

        }

        private void RefreshMemoryUsageCell(ProcessInfo processInfo)
        {
/*          dataTable.AsEnumerable().Where(x => x.Field<string>("ID") == processInfo.ProcessId).FirstOrDefault().SetField("Память", processInfo.ProcessMemoryUsage);*/
            dataGridView1.DataSource = dataTable;
        }

        private void RefreshCPUUsageCell(ProcessInfo processInfo)
        {
            try
            {
              /*dataTable.AsEnumerable().Where(x => x.Field<string>("ID") == processInfo.ProcessHandle).FirstOrDefault().SetField("ЦП%", processInfo.ProcessCPUUsage);*/
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        private void InitDataTable()
        {
            dataTable.Rows.Clear();
            runningProcess = processManager.GetProcessInfo();
            foreach (var elem in runningProcess)
            {
                dataTable.Rows.Add(elem.Caption, elem.ProcessId,
                    $"{elem.CreationDate.Substring(8, 2)}.{elem.CreationDate.Substring(10, 2)}.{elem.CreationDate.Substring(12, 2)}    {elem.CreationDate.Substring(6, 2)}.{elem.CreationDate.Substring(4, 2)}.{elem.CreationDate.Substring(0, 4)}",
                    elem.Priority, elem.WorkingSetSize / (1024 * 1024));
            }
            dataGridView1.DataSource = dataTable;
        }

        private void InitCharts()
        {     
            for(int x = 0; x < 60; x++)
            {
                chartRAM.Series[0].Points.AddXY(x, 0.1);
                chartProcessor.Series[0].Points.AddXY(x, 0.1);
            }
            chartRAM.ChartAreas[0].AxisY.Minimum = 0;
            chartRAM.ChartAreas[0].AxisY.Maximum = 100;
            chartRAM.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chartRAM.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chartProcessor.ChartAreas[0].AxisY.Minimum = 0;
            chartProcessor.ChartAreas[0].AxisY.Maximum = 100;
            chartProcessor.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chartProcessor.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            dataTable.Columns.Add("Имя", typeof(string));
            dataTable.Columns.Add("ID", typeof(UInt32));
            dataTable.Columns.Add("Время создания", typeof(string));
            dataTable.Columns.Add("Приоритет", typeof(UInt32));
            dataTable.Columns.Add("Память MB", typeof(double));
        }


        private async void UpdateChartRAM()
        {
            while (true)
            {
                await Task.Run(() =>
                {
                    var useMemory = Convert.ToDouble(ramInfo.Points.Last().Item2);
                    var totalMemory = Convert.ToDouble(ramInfo.Points.Last().Item1);
                    Invoke(new Action(() => {
                        ramUsage.Text = String.Format("Общий объём памяти: {0:F2} GB Использованная память: {1:F2} GB Доступная память: {2:F2} GB", totalMemory/fromKBtoGB, useMemory/fromKBtoGB, (totalMemory-useMemory)/fromKBtoGB);
                        chartRAM.Series[0].Points.RemoveAt(0);
                        chartRAM.Series[0].Points.AddXY(59, useMemory / totalMemory * 100);
                    }));
                });
                await Task.Delay(1000);
            }
        }

        private async void UpdateChartProcessor()
        {
            while (true)
            {
                await Task.Run(() =>
                {  
                    Invoke(new Action(() => {
                        processorSpeed.Text = String.Format("{0} MHz", processorInfo.CurrentClockSpeed);
                        chartProcessor.Series[0].Points.RemoveAt(0);
                        chartProcessor.Series[0].Points.AddXY(59, processorInfo.Points.Last());
                    }));
                });
                await Task.Delay(1000);
            }
        }

        private async void TakeInfoAboutRAM()
        {
            var info =  ramInfo.TakeInfoAboutDivice();
            await Task.Delay(1100);
            ComputerInfo computerInfo = new ComputerInfo();
            infoAdoutRAM.Text = String.Format("{0}\n{1}МГц\n{2:F2}GB\n{3}\n{4:F2}MB\n",info.First().FormFactor, info.Min(x=>x.SpeedOfRam), info.Sum(x=>x.SizeOfRAM), info.Count,(Convert.ToDouble(info.Sum(x=>x.SizeOfRAM)) - ramInfo.Points.Last().Item1/fromKBtoGB)*1024);
        }

        private async void TakeInfoAboutProcessor()
        {
            var info = processorInfo.TakeInfoAboutDivice();
            await Task.Delay(1000);
            var _ = processorInfo.TakeInfoAboutDivice().First();
            processorInfoLabel.Text = String.Format("{0}\n{1}/{2}\n{3}\n{4}\n{5}\n{6}KB\n{7}KB",_.MaxClockSpeed, _.NumberOfEnabledCore, _.NumberOfLogicalProcessors,_.ProcesorArchitecture, _.Name.Substring(0,60>_.Name.Length ?  _.Name.Length-1:60),_.AddressWidth,_.L2CacheSize, _.L3CacheSize);
        }

        private void TakeInfoAboutOS()
        {
            var res = osInfo.TakeInfoAboutDivice();
            var _ = res.First();
            infoOS.Text = $"{_.Caption}\n{_.BuildNumber}\n{_.BuildType}" +
                $"\n{(_.CurrentTimeZone<0 ? "":"+")}{Convert.ToDouble(_.CurrentTimeZone) / 60} GMT" +
                $"\n{_.LastBootUpTime.Substring(8,2)}.{_.LastBootUpTime.Substring(10, 2)}.{_.LastBootUpTime.Substring(12,2)}    {_.LastBootUpTime.Substring(6, 2)}.{_.LastBootUpTime.Substring(4, 2)}.{_.LastBootUpTime.Substring(0, 4)}" +
                $"\n{_.OSArchitecture}\n{(Convert.ToDouble(_.TotalSwapSpaceSize) / (1024 * 1024)):f2} GB\n{(Convert.ToDouble(_.TotalVirtualMemorySize)/(1024*1024)):.##} GB\n{_.Version}";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void KillOneProcess(object sender, EventArgs e)
        {
            Int32 data = Convert.ToInt32( dataGridView1.Rows[mouseLocation.RowIndex].Cells["ID"].Value);
            processManager.KillProcess(Process.GetProcessById(data));
        }

        private void KillTreeProcess(object sender, EventArgs e)
        {
            Int32 data = Convert.ToInt32(dataGridView1.Rows[mouseLocation.RowIndex].Cells["ID"].Value);
            processManager.EndProcessTree(processManager.GetProcessParentId(Process.GetProcessById(data)));
        }

        private void OpenFilePlace(object sender, EventArgs e)
        {
            var pid = Convert.ToInt32(dataGridView1.Rows[mouseLocation.RowIndex].Cells["ID"].Value);
            string path = processManager.Processes.Find(x => x.ProcessId == pid).ExecutablePath;
            if (File.Exists(path))
            {
                Process.Start(new ProcessStartInfo("explorer.exe", " /select, " +path ));
            }
        }

        private void ExitFromApp(object sender, EventArgs e)
        {
            Application.Exit();   
        }

        private void RunProcessByOpenFile(object sender, EventArgs e)
        {
            using(var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter ="Execution files(*.exe)|*.exe";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Process.Start(openFileDialog.FileName);
                }
            }
        }


        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            mouseLocation = e;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(processName.Text);
        }
    }
}

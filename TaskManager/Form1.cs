using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {

        private ProcessManager processManager = null;
        DataTable dataTable = new DataTable();
        private Dictionary<ProcessInfo, ListViewItem> processInfoListView = new Dictionary<ProcessInfo, ListViewItem>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            processManager = new ProcessManager();
            //this.RefreshListView();
            InitDataTable();
            processManager.InitStopStartProcess();
            processManager.NotifyStartNewProcess += ((ProcessInfo info) => {
                Console.WriteLine(info.ProcessName);
                });
            //processManager.NotifyStopProcess += ((ProcessInfo processInfo) => { processInfoListView.Remove(processInfo); });
            //processManager.NotifyUpdateProcess +=(()=> RefreshItemListView());
            
        }

        private void RefreshDataTable()
        {
            foreach (var elem in processManager.GetProcessInfo())
            {
                dataTable.Rows.Add(elem.ProcessName, elem.ProcessPriority.ToString(), elem.ProcessTimeCreate.ToString(), elem.ProcessProcessTimeUsage.ToString(), elem.ProcessMemoryUsage.ToString());
            }
            dataGridView1.DataSource = dataTable;
        }

        private void InitDataTable()
        {
            dataTable.Columns.Add("Имя", typeof(string));
            dataTable.Columns.Add("Статус", typeof(string));
            dataTable.Columns.Add("Пользователь", typeof(string));
            dataTable.Columns.Add("ЦП%", typeof(float));
            dataTable.Columns.Add("Память", typeof(double));

            RefreshDataTable();
        }
        private void RefreshListView()
        {
          /*  listView1.Items.Clear();
            foreach (var elem in processManager.GetProcessInfo())
            {
                var temp = new ListViewItem(new string[] { elem.ProcessName, elem.ProcessPriority.ToString(), elem.ProcessTimeCreate.ToString(), elem.ProcessMemoryUsage.ToString(), elem.ProcessProcessTimeUsage.ToString() });
                temp.Name = elem.ProcessName + DateTime.Now.Millisecond.ToString();
                listView1.Items.Add(temp);
                elem.UpdateInfo += (() =>RefreshItemListView(elem));
                processInfoListView.Add(elem, temp);
            }*/
        }

        private void RefreshItemListView(ProcessInfo processInfo)
        {
            Invoke(new Action(() =>
            {
                var newListView = new ListViewItem(new string[] { processInfo.ProcessName, processInfo.ProcessPriority.ToString(), processInfo.ProcessTimeCreate.ToString(), processInfo.ProcessMemoryUsage.ToString(), processInfo.ProcessProcessTimeUsage.ToString() });
                var temp = listView1.Items[processInfoListView[processInfo].Name];
                newListView.Name = temp.Name;
                listView1.Items.Remove(temp);
                listView1.Items.Add(newListView);
            }));
        }


    }
}

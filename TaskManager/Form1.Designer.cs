namespace TaskManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.завершитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.завершитьДревоПроцессовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.расположениеФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panelVideoAdapter = new System.Windows.Forms.TableLayoutPanel();
            this.videoAdapterDiscriprion = new System.Windows.Forms.Label();
            this.videoAdapterInfo = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.processorInfoLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.processorSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chartProcessor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.infoAdoutRAM = new System.Windows.Forms.Label();
            this.labelRAM1 = new System.Windows.Forms.Label();
            this.ramUsage = new System.Windows.Forms.Label();
            this.chartRAM = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.запуститьНовыйПроцессToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запуститьНовыйПроцессToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поНазваниюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.infoOS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panelVideoAdapter.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProcessor)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRAM)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.завершитьToolStripMenuItem,
            this.завершитьДревоПроцессовToolStripMenuItem,
            this.toolStripSeparator1,
            this.расположениеФайлаToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(233, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // завершитьToolStripMenuItem
            // 
            this.завершитьToolStripMenuItem.Name = "завершитьToolStripMenuItem";
            this.завершитьToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.завершитьToolStripMenuItem.Text = "Завершить";
            this.завершитьToolStripMenuItem.Click += new System.EventHandler(this.KillOneProcess);
            // 
            // завершитьДревоПроцессовToolStripMenuItem
            // 
            this.завершитьДревоПроцессовToolStripMenuItem.Name = "завершитьДревоПроцессовToolStripMenuItem";
            this.завершитьДревоПроцессовToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.завершитьДревоПроцессовToolStripMenuItem.Text = "Завершить древо процессов";
            this.завершитьДревоПроцессовToolStripMenuItem.Click += new System.EventHandler(this.KillTreeProcess);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
            // 
            // расположениеФайлаToolStripMenuItem
            // 
            this.расположениеФайлаToolStripMenuItem.Name = "расположениеФайлаToolStripMenuItem";
            this.расположениеФайлаToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.расположениеФайлаToolStripMenuItem.Text = "Расположение файла";
            this.расположениеФайлаToolStripMenuItem.Click += new System.EventHandler(this.OpenFilePlace);
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.Controls.Add(this.panelVideoAdapter);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(582, 438);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Видеокарта";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panelVideoAdapter
            // 
            this.panelVideoAdapter.AutoSize = true;
            this.panelVideoAdapter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelVideoAdapter.ColumnCount = 2;
            this.panelVideoAdapter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelVideoAdapter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.panelVideoAdapter.Controls.Add(this.videoAdapterDiscriprion, 0, 0);
            this.panelVideoAdapter.Controls.Add(this.videoAdapterInfo, 1, 0);
            this.panelVideoAdapter.Location = new System.Drawing.Point(6, 29);
            this.panelVideoAdapter.Name = "panelVideoAdapter";
            this.panelVideoAdapter.RowCount = 1;
            this.panelVideoAdapter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelVideoAdapter.Size = new System.Drawing.Size(569, 113);
            this.panelVideoAdapter.TabIndex = 0;
            // 
            // videoAdapterDiscriprion
            // 
            this.videoAdapterDiscriprion.Location = new System.Drawing.Point(3, 0);
            this.videoAdapterDiscriprion.Name = "videoAdapterDiscriprion";
            this.videoAdapterDiscriprion.Size = new System.Drawing.Size(93, 113);
            this.videoAdapterDiscriprion.TabIndex = 0;
            this.videoAdapterDiscriprion.Text = "Контроллер:\r\nОбъём памяти:\r\nНазвание:\r\nТип памяти:\r\nПроцессор:";
            // 
            // videoAdapterInfo
            // 
            this.videoAdapterInfo.Location = new System.Drawing.Point(145, 0);
            this.videoAdapterInfo.Name = "videoAdapterInfo";
            this.videoAdapterInfo.Size = new System.Drawing.Size(421, 113);
            this.videoAdapterInfo.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.processorInfoLabel);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.processorSpeed);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.chartProcessor);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(582, 438);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Процессор";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // processorInfoLabel
            // 
            this.processorInfoLabel.Location = new System.Drawing.Point(273, 334);
            this.processorInfoLabel.Name = "processorInfoLabel";
            this.processorInfoLabel.Size = new System.Drawing.Size(300, 101);
            this.processorInfoLabel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(60, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 101);
            this.label2.TabIndex = 4;
            this.label2.Text = "Максимальная номинальная частота:\r\nКоличество ядер/потоков\r\nАрхитектура:\r\nНазвани" +
    "е:\r\nРазрядность:\r\nL2 cache:\r\nL3 cache:";
            // 
            // processorSpeed
            // 
            this.processorSpeed.AutoSize = true;
            this.processorSpeed.Location = new System.Drawing.Point(115, 306);
            this.processorSpeed.Name = "processorSpeed";
            this.processorSpeed.Size = new System.Drawing.Size(0, 13);
            this.processorSpeed.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Частота:";
            // 
            // chartProcessor
            // 
            this.chartProcessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartProcessor.BorderSkin.BackColor = System.Drawing.Color.Black;
            this.chartProcessor.BorderSkin.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Cross;
            this.chartProcessor.BorderSkin.BackSecondaryColor = System.Drawing.Color.DarkRed;
            this.chartProcessor.BorderSkin.BorderColor = System.Drawing.Color.Maroon;
            this.chartProcessor.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX2.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.BackColor = System.Drawing.Color.Aqua;
            chartArea1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Cross;
            chartArea1.Name = "ChartArea1";
            this.chartProcessor.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartProcessor.Legends.Add(legend1);
            this.chartProcessor.Location = new System.Drawing.Point(3, 3);
            this.chartProcessor.MinimumSize = new System.Drawing.Size(550, 300);
            this.chartProcessor.Name = "chartProcessor";
            this.chartProcessor.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.BorderWidth = 0;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series1.Color = System.Drawing.Color.DarkSlateBlue;
            series1.EmptyPointStyle.BorderWidth = 0;
            series1.EmptyPointStyle.MarkerSize = 0;
            series1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsXValueIndexed = true;
            series1.LabelBorderWidth = 0;
            series1.Legend = "Legend1";
            series1.Name = "RAM";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartProcessor.Series.Add(series1);
            this.chartProcessor.Size = new System.Drawing.Size(570, 300);
            this.chartProcessor.TabIndex = 1;
            this.chartProcessor.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.AutoScrollMinSize = new System.Drawing.Size(500, 400);
            this.tabPage2.Controls.Add(this.infoAdoutRAM);
            this.tabPage2.Controls.Add(this.labelRAM1);
            this.tabPage2.Controls.Add(this.ramUsage);
            this.tabPage2.Controls.Add(this.chartRAM);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(582, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Оперативная память";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // infoAdoutRAM
            // 
            this.infoAdoutRAM.Location = new System.Drawing.Point(178, 327);
            this.infoAdoutRAM.Name = "infoAdoutRAM";
            this.infoAdoutRAM.Size = new System.Drawing.Size(95, 76);
            this.infoAdoutRAM.TabIndex = 2;
            // 
            // labelRAM1
            // 
            this.labelRAM1.Location = new System.Drawing.Point(54, 327);
            this.labelRAM1.Name = "labelRAM1";
            this.labelRAM1.Size = new System.Drawing.Size(118, 76);
            this.labelRAM1.TabIndex = 2;
            this.labelRAM1.Text = "Форм-фактор: \r\nЧастота:\r\nОбщий объём:\r\nКоличество плашек: \r\nЗарезирвиравано:";
            // 
            // ramUsage
            // 
            this.ramUsage.Location = new System.Drawing.Point(54, 298);
            this.ramUsage.Name = "ramUsage";
            this.ramUsage.Size = new System.Drawing.Size(490, 20);
            this.ramUsage.TabIndex = 1;
            // 
            // chartRAM
            // 
            this.chartRAM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartRAM.BorderSkin.BackColor = System.Drawing.Color.Black;
            this.chartRAM.BorderSkin.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Cross;
            this.chartRAM.BorderSkin.BackSecondaryColor = System.Drawing.Color.DarkRed;
            this.chartRAM.BorderSkin.BorderColor = System.Drawing.Color.Maroon;
            this.chartRAM.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX2.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            chartArea2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Cross;
            chartArea2.Name = "ChartArea1";
            this.chartRAM.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartRAM.Legends.Add(legend2);
            this.chartRAM.Location = new System.Drawing.Point(6, 6);
            this.chartRAM.MinimumSize = new System.Drawing.Size(550, 300);
            this.chartRAM.Name = "chartRAM";
            this.chartRAM.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series2.BorderWidth = 0;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series2.Color = System.Drawing.Color.Purple;
            series2.EmptyPointStyle.BorderWidth = 0;
            series2.EmptyPointStyle.MarkerSize = 0;
            series2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsXValueIndexed = true;
            series2.LabelBorderWidth = 0;
            series2.Legend = "Legend1";
            series2.Name = "RAM";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartRAM.Series.Add(series2);
            this.chartRAM.Size = new System.Drawing.Size(570, 300);
            this.chartRAM.TabIndex = 0;
            this.chartRAM.Text = "chart1";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.menuStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(582, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Процессы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(3, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Size = new System.Drawing.Size(576, 408);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запуститьНовыйПроцессToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(576, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // запуститьНовыйПроцессToolStripMenuItem
            // 
            this.запуститьНовыйПроцессToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запуститьНовыйПроцессToolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.запуститьНовыйПроцессToolStripMenuItem.Name = "запуститьНовыйПроцессToolStripMenuItem";
            this.запуститьНовыйПроцессToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.запуститьНовыйПроцессToolStripMenuItem.Text = "Файл";
            // 
            // запуститьНовыйПроцессToolStripMenuItem1
            // 
            this.запуститьНовыйПроцессToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьФайлToolStripMenuItem,
            this.поНазваниюToolStripMenuItem});
            this.запуститьНовыйПроцессToolStripMenuItem1.Name = "запуститьНовыйПроцессToolStripMenuItem1";
            this.запуститьНовыйПроцессToolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.запуститьНовыйПроцессToolStripMenuItem1.Text = "Запустить новый процесс";
            // 
            // выбратьФайлToolStripMenuItem
            // 
            this.выбратьФайлToolStripMenuItem.Name = "выбратьФайлToolStripMenuItem";
            this.выбратьФайлToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.выбратьФайлToolStripMenuItem.Text = "Выбрать файл";
            this.выбратьФайлToolStripMenuItem.Click += new System.EventHandler(this.RunProcessByOpenFile);
            // 
            // поНазваниюToolStripMenuItem
            // 
            this.поНазваниюToolStripMenuItem.Name = "поНазваниюToolStripMenuItem";
            this.поНазваниюToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.поНазваниюToolStripMenuItem.Text = "По названию";
            this.поНазваниюToolStripMenuItem.Click += new System.EventHandler(this.RunProcessByName);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ExitFromApp);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(2, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(590, 464);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.infoOS);
            this.tabPage6.Controls.Add(this.label3);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(582, 438);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Система";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // infoOS
            // 
            this.infoOS.Location = new System.Drawing.Point(168, 18);
            this.infoOS.Name = "infoOS";
            this.infoOS.Size = new System.Drawing.Size(408, 123);
            this.infoOS.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 123);
            this.label3.TabIndex = 0;
            this.label3.Text = "ОС:\r\nНомер сборки:\r\nТип сборки:\r\nЧасовой пояс:\r\nВремя работы:\r\nАрхитектура:\r\nРазм" +
    "ер файла подкачки:\r\nРазмер виртуальной памяти:\r\nВерсия:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(596, 488);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panelVideoAdapter.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProcessor)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRAM)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel panelVideoAdapter;
        private System.Windows.Forms.Label videoAdapterDiscriprion;
        private System.Windows.Forms.Label videoAdapterInfo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label processorInfoLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label processorSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProcessor;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label infoAdoutRAM;
        private System.Windows.Forms.Label labelRAM1;
        private System.Windows.Forms.Label ramUsage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRAM;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label infoOS;
        private System.Windows.Forms.ToolStripMenuItem завершитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem завершитьДревоПроцессовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расположениеФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem запуститьНовыйПроцессToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запуститьНовыйПроцессToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выбратьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поНазваниюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}


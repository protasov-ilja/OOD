namespace lab9._1.ChartDrawer.Views
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.harmonicsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.chartPage1 = new System.Windows.Forms.TabPage();
			this.tablePage2 = new System.Windows.Forms.TabPage();
			this.harmonicsTable = new System.Windows.Forms.DataGridView();
			this.Editor = new System.Windows.Forms.GroupBox();
			this.phaseText = new System.Windows.Forms.TextBox();
			this.frequencyText = new System.Windows.Forms.TextBox();
			this.amplitudeText = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cosButton = new System.Windows.Forms.RadioButton();
			this.sinButton = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.harmonicsList = new System.Windows.Forms.ListBox();
			this.addButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.columnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.harmonicsChart)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.chartPage1.SuspendLayout();
			this.tablePage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.harmonicsTable)).BeginInit();
			this.Editor.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// harmonicsChart
			// 
			chartArea5.Name = "ChartArea1";
			this.harmonicsChart.ChartAreas.Add(chartArea5);
			legend5.Name = "Legend1";
			this.harmonicsChart.Legends.Add(legend5);
			this.harmonicsChart.Location = new System.Drawing.Point(-4, 10);
			this.harmonicsChart.Name = "harmonicsChart";
			series5.ChartArea = "ChartArea1";
			series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series5.Legend = "Legend1";
			series5.Name = "ResultChar";
			this.harmonicsChart.Series.Add(series5);
			this.harmonicsChart.Size = new System.Drawing.Size(781, 306);
			this.harmonicsChart.TabIndex = 0;
			this.harmonicsChart.Text = "chart1";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.chartPage1);
			this.tabControl1.Controls.Add(this.tablePage2);
			this.tabControl1.Location = new System.Drawing.Point(1, 309);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(780, 341);
			this.tabControl1.TabIndex = 2;
			// 
			// chartPage1
			// 
			this.chartPage1.Controls.Add(this.harmonicsChart);
			this.chartPage1.Location = new System.Drawing.Point(4, 25);
			this.chartPage1.Name = "chartPage1";
			this.chartPage1.Padding = new System.Windows.Forms.Padding(3);
			this.chartPage1.Size = new System.Drawing.Size(772, 312);
			this.chartPage1.TabIndex = 0;
			this.chartPage1.Text = "Chart";
			this.chartPage1.UseVisualStyleBackColor = true;
			// 
			// tablePage2
			// 
			this.tablePage2.Controls.Add(this.harmonicsTable);
			this.tablePage2.Location = new System.Drawing.Point(4, 25);
			this.tablePage2.Name = "tablePage2";
			this.tablePage2.Padding = new System.Windows.Forms.Padding(3);
			this.tablePage2.Size = new System.Drawing.Size(772, 312);
			this.tablePage2.TabIndex = 1;
			this.tablePage2.Text = "Table";
			this.tablePage2.UseVisualStyleBackColor = true;
			this.tablePage2.Click += new System.EventHandler(this.tabPage2_Click);
			// 
			// harmonicsTable
			// 
			this.harmonicsTable.AllowUserToAddRows = false;
			this.harmonicsTable.AllowUserToDeleteRows = false;
			this.harmonicsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.harmonicsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnX,
            this.columnY});
			this.harmonicsTable.Location = new System.Drawing.Point(-4, 0);
			this.harmonicsTable.Name = "harmonicsTable";
			this.harmonicsTable.ReadOnly = true;
			this.harmonicsTable.RowTemplate.Height = 24;
			this.harmonicsTable.Size = new System.Drawing.Size(773, 316);
			this.harmonicsTable.TabIndex = 0;
			// 
			// Editor
			// 
			this.Editor.Controls.Add(this.phaseText);
			this.Editor.Controls.Add(this.frequencyText);
			this.Editor.Controls.Add(this.amplitudeText);
			this.Editor.Controls.Add(this.groupBox1);
			this.Editor.Controls.Add(this.label3);
			this.Editor.Controls.Add(this.label2);
			this.Editor.Controls.Add(this.label1);
			this.Editor.Location = new System.Drawing.Point(374, 30);
			this.Editor.Name = "Editor";
			this.Editor.Size = new System.Drawing.Size(387, 288);
			this.Editor.TabIndex = 3;
			this.Editor.TabStop = false;
			this.Editor.Text = "Editor";
			// 
			// phaseText
			// 
			this.phaseText.Location = new System.Drawing.Point(216, 241);
			this.phaseText.Name = "phaseText";
			this.phaseText.Size = new System.Drawing.Size(100, 22);
			this.phaseText.TabIndex = 10;
			this.phaseText.Leave += new System.EventHandler(this.phaseText_TextChanged);
			// 
			// frequencyText
			// 
			this.frequencyText.Location = new System.Drawing.Point(216, 170);
			this.frequencyText.Name = "frequencyText";
			this.frequencyText.Size = new System.Drawing.Size(100, 22);
			this.frequencyText.TabIndex = 9;
			this.frequencyText.Leave += new System.EventHandler(this.frequencyText_TextChanged);
			// 
			// amplitudeText
			// 
			this.amplitudeText.Location = new System.Drawing.Point(216, 39);
			this.amplitudeText.Name = "amplitudeText";
			this.amplitudeText.Size = new System.Drawing.Size(100, 22);
			this.amplitudeText.TabIndex = 8;
			this.amplitudeText.Leave += new System.EventHandler(this.amplitudeText_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cosButton);
			this.groupBox1.Controls.Add(this.sinButton);
			this.groupBox1.Location = new System.Drawing.Point(0, 82);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(387, 57);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			// 
			// cosButton
			// 
			this.cosButton.AutoSize = true;
			this.cosButton.Location = new System.Drawing.Point(248, 21);
			this.cosButton.Name = "cosButton";
			this.cosButton.Size = new System.Drawing.Size(51, 21);
			this.cosButton.TabIndex = 7;
			this.cosButton.TabStop = true;
			this.cosButton.Text = "cos";
			this.cosButton.UseVisualStyleBackColor = true;
			this.cosButton.CheckedChanged += new System.EventHandler(this.cosButton_CheckedChanged);
			// 
			// sinButton
			// 
			this.sinButton.AutoSize = true;
			this.sinButton.Location = new System.Drawing.Point(53, 21);
			this.sinButton.Name = "sinButton";
			this.sinButton.Size = new System.Drawing.Size(47, 21);
			this.sinButton.TabIndex = 6;
			this.sinButton.TabStop = true;
			this.sinButton.Text = "sin";
			this.sinButton.UseVisualStyleBackColor = true;
			this.sinButton.CheckedChanged += new System.EventHandler(this.sinButton_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(50, 241);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Phase";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(50, 170);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Frequency";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(50, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Amplitude";
			// 
			// harmonicsList
			// 
			this.harmonicsList.FormattingEnabled = true;
			this.harmonicsList.ItemHeight = 16;
			this.harmonicsList.Location = new System.Drawing.Point(12, 18);
			this.harmonicsList.Name = "harmonicsList";
			this.harmonicsList.Size = new System.Drawing.Size(338, 212);
			this.harmonicsList.TabIndex = 4;
			this.harmonicsList.SelectedIndexChanged += new System.EventHandler(this.harmonicsList_SelectedIndexChanged);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(12, 264);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(145, 23);
			this.addButton.TabIndex = 5;
			this.addButton.Text = "Add new";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(225, 264);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(125, 23);
			this.deleteButton.TabIndex = 6;
			this.deleteButton.Text = "Delete selected";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// columnX
			// 
			this.columnX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.columnX.HeaderText = "X";
			this.columnX.Name = "columnX";
			this.columnX.ReadOnly = true;
			// 
			// columnY
			// 
			this.columnY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.columnY.HeaderText = "Y";
			this.columnY.Name = "columnY";
			this.columnY.ReadOnly = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 653);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.harmonicsList);
			this.Controls.Add(this.Editor);
			this.Controls.Add(this.tabControl1);
			this.MaximumSize = new System.Drawing.Size(800, 700);
			this.MinimumSize = new System.Drawing.Size(800, 700);
			this.Name = "MainForm";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.harmonicsChart)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.chartPage1.ResumeLayout(false);
			this.tablePage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.harmonicsTable)).EndInit();
			this.Editor.ResumeLayout(false);
			this.Editor.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart harmonicsChart;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage chartPage1;
		private System.Windows.Forms.TabPage tablePage2;
		private System.Windows.Forms.GroupBox Editor;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton cosButton;
		private System.Windows.Forms.RadioButton sinButton;
		private System.Windows.Forms.ListBox harmonicsList;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.DataGridView harmonicsTable;
		private System.Windows.Forms.TextBox phaseText;
		private System.Windows.Forms.TextBox frequencyText;
		private System.Windows.Forms.TextBox amplitudeText;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnX;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnY;
	}
}


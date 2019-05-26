using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;
using lab9._1.ChartDrawer.Controllers;

namespace lab9._1.ChartDrawer.Views
{
	public partial class MainForm : Form
	{
		private const string ChartName = "ResultChar";
		private const float MinChartBorder = 0;
		private const float MaxChartBorder = 4.5f;
		private const float StepSize = 0.5f;

		private IMainFormController _mainFormPresenter;
		private IHarmonicsManager _harmonicManager;
		private bool _blockEvents = false;

		public MainForm(IHarmonicsManager harmonicManager)
		{
			InitializeComponent();
			_harmonicManager = harmonicManager;
			_mainFormPresenter = new MainFormController(harmonicManager);
			harmonicManager.HarmonicsChanged += UpdateView;
			harmonicManager.ActiveHarmonicChanged += UpdateSelectedHarmonic;
			ActivateReadonly(false);
		}

		private void UpdateSelectedHarmonic(Harmonic harmonic)
		{
			if (harmonicsList.SelectedItems.Count != 0)
			{
				_blockEvents = true;
				harmonicsList.SelectedItem = harmonic;
				amplitudeText.Text = harmonic.Amplitude.ToString();
				frequencyText.Text = harmonic.Frequency.ToString();
				phaseText.Text = harmonic.Phase.ToString();
				switch (harmonic.Type)
				{
					case HarmonicType.Cos:
						cosButton.Checked = true;
						break;
					case HarmonicType.Sin:
						sinButton.Checked = true;
						break;
				}

				_blockEvents = false;
			}
		}

		private void ActivateReadonly(bool activate)
		{
			amplitudeText.Enabled = activate;
			frequencyText.Enabled = activate;
			phaseText.Enabled = activate;
			radioButtonsGroup.Enabled = activate;
		}

		private void UpdateView(List<Harmonic> harmonics)
		{
			var isItemsSelected = harmonicsList.SelectedItems.Count != 0;
			var selectedIndex = harmonicsList.SelectedIndex;
			harmonicsList.Items.Clear();
			for (var i = 0; i < harmonics.Count; ++i)
			{
				harmonicsList.Items.Add(harmonics[i]);
				if (isItemsSelected && i == harmonicsList.SelectedIndex)
				{
					harmonicsList.SetSelected(i, true);
				}
			}

			FillChart(harmonics);
			FillTable(harmonics);
			if (harmonicsList.SelectedItems.Count == 0 && harmonics.Count != 0) 
			{
				harmonicsList.SetSelected(harmonics.Count - 1, true);
			}
			else if (harmonicsList.SelectedItems.Count == 0 && harmonics.Count == 0)
			{
				amplitudeText.Text = "";
				frequencyText.Text = "";
				phaseText.Text = "";
				sinButton.Checked = false;
				cosButton.Checked = false;
			}

			ActivateReadonly(harmonicsList.SelectedItems.Count != 0);
		}

		private void FillTable(List<Harmonic> harmonics)
		{
			harmonicsTable.Rows.Clear();
			if (harmonics.Count > 0)
			{
				for (float x = MinChartBorder; x <= MaxChartBorder; x += StepSize)
				{
					DataGridViewCell cellX = new DataGridViewTextBoxCell();
					DataGridViewCell cellY = new DataGridViewTextBoxCell();
					cellX.Value = x;
					cellY.Value = GetResultY(x, harmonics);
					DataGridViewRow row = new DataGridViewRow();
					row.Cells.AddRange(cellX, cellY);
					harmonicsTable.Rows.Add(row);
				}
			}
		}

		private void FillChart(List<Harmonic> harmonics)
		{
			harmonicsChart.Series[ChartName].Points.Clear();
			for (float x = MinChartBorder; x <= MaxChartBorder; x += StepSize)
			{
				harmonicsChart.Series[ChartName].Points.AddXY(x, GetResultY(x, harmonics));
			}
		}

		private double GetResultY(float x, List<Harmonic> harmonics)
		{
			double result = 0;
			foreach (var harmonic in harmonics)
			{
				result += GetYValue(x, harmonic);
			}

			return result;
		}

		private double GetYValue(float x, Harmonic harmonic)
		{
			return harmonic.Type == HarmonicType.Sin
				? harmonic.Amplitude * Math.Sin(harmonic.Frequency * x + harmonic.Phase)
				: harmonic.Amplitude * Math.Cos(harmonic.Frequency * x + harmonic.Phase);
		}

		private void amplitudeText_TextChanged(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0 && !_blockEvents)
			{
				var text = amplitudeText.Text;
				var isEmplty = text.Length == 0;
				if (!isEmplty && float.TryParse(text, out var value))
				{
					_mainFormPresenter.UpdateSelectedHarmonicAmplitude(harmonicsList.SelectedIndex, value);
				}
				else
				{
					MessageBox.Show("Error, please input float value");
					if (!isEmplty)
					{
						amplitudeText.Text = "";
					}
				}				
			}
		}

		private void cosButton_CheckedChanged(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0 && !_blockEvents)
			{
				if (cosButton.Checked)
				{
					_mainFormPresenter.UpdateSelectedHarmonicType(harmonicsList.SelectedIndex, HarmonicType.Cos);
				}
			}
		}

		private void frequencyText_TextChanged(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0 && !_blockEvents)
			{
				var text = frequencyText.Text;
				var isEmplty = text.Length == 0;
				if (!isEmplty && float.TryParse(text, out var value))
				{
					_mainFormPresenter.UpdateSelectedHarmonicFrequency(harmonicsList.SelectedIndex, value);
				}
				else
				{
					MessageBox.Show("Error, please input float value");
					if (!isEmplty)
					{
						frequencyText.Text = "";
					}
				}
			}
		}

		private void phaseText_TextChanged(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0 && !_blockEvents)
			{
				var text = phaseText.Text;
				var isEmplty = text.Length == 0;
				if (!isEmplty && float.TryParse(text, out var value))
				{
					_mainFormPresenter.UpdateSelectedHarmonicPhase(harmonicsList.SelectedIndex, value);
				}
				else
				{
					MessageBox.Show("Error, please input float value");
					if (!isEmplty)
					{
						phaseText.Text = "";
					}
				}
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			var harmonicForm = new HarmonicCreatorForm(_harmonicManager);
			harmonicForm.Show();
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0)
			{
				_mainFormPresenter.DeleteSelectedHarmonic(harmonicsList.SelectedIndex);
			}
		}

		private void harmonicsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			_mainFormPresenter.GetSelectedHarmonic(harmonicsList.SelectedIndex);
		}

		private void sinButton_CheckedChanged(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0 && !_blockEvents)
			{
				if (sinButton.Checked)
				{
					_mainFormPresenter.UpdateSelectedHarmonicType(harmonicsList.SelectedIndex, HarmonicType.Sin);
				}
			}
		}

		private void tabPage2_Click(object sender, EventArgs e)
		{

		}
	}
}

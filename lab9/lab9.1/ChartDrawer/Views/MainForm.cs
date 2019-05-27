using System;
using System.Collections.Generic;
using System.Windows.Forms;
using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;
using lab9._1.ChartDrawer.Controllers;
using lab9._1.ChartDrawer.Utils;

namespace lab9._1.ChartDrawer.Views
{
	public partial class MainForm : Form
	{
		private IMainFormController _mainFormController;
		private IHarmonicsManager _harmonicManager;
		private HarmonicsChart _chart;
		private HarmonicsTable _table;
		private bool _blockEvents = false;

		public MainForm(IHarmonicsManager harmonicManager)
		{
			InitializeComponent();
			_chart = new HarmonicsChart(harmonicsChart);
			_table = new HarmonicsTable(harmonicsTable);
			_harmonicManager = harmonicManager;
			_mainFormController = new MainFormController(harmonicManager);
			_harmonicManager.HarmonicAdded += AddInList;
			_harmonicManager.HarmonicDeleted += RemoveFromListByIndex;
			harmonicManager.ActiveHarmonicChanged += SelectedHarmonicChanged;
			ActivateInput(false);
		}

		private void ActivateInput(bool activate)
		{
			amplitudeText.Enabled = activate;
			frequencyText.Enabled = activate;
			phaseText.Enabled = activate;
			radioButtonsGroup.Enabled = activate;
		}

		private void RemoveFromListByIndex(int index)
		{
			harmonicsList.Items.RemoveAt(index);

			_chart.RemoveHarmonicDataAtIndex(index);
			_table.RemoveHarmonicDataAtIndex(index);

			if (harmonicsList.Items.Count == 0)
			{
				ActivateInput(false);
			}
		}

		private void AddInList(int index)
		{
			if (harmonicsList.Items.Count == 0)
			{
				ActivateInput(true);
			}

			var data = _mainFormController.GetActiveHarmonicData();
			_mainFormController.SubscribeToActiveHarmonicEvents(OnHarmonicParametersChanged);
			harmonicsList.Items.Add(Converter.GetStringRepresentation(data));

			_chart.AddHarmonicData(data);
			_table.AddHarmonicData(data);
		}

		private void SelectedHarmonicChanged(int index)
		{
			if (index != -1)
			{
				_blockEvents = true;
				harmonicsList.SetSelected(index, true);
				UpdateActiveHarmonicParameters();
				_blockEvents = false;
			}
			else
			{
				ResetHarmonicParamenters();
			}
		}

		private void OnHarmonicParametersChanged()
		{
			_blockEvents = true;
			var data = _mainFormController.GetActiveHarmonicData();
			harmonicsList.Items[harmonicsList.SelectedIndex] = Converter.GetStringRepresentation(data);
			_blockEvents = false;

			_chart.UpdateHarmonicData(harmonicsList.SelectedIndex, data);
			_table.UpdateHarmonicData(harmonicsList.SelectedIndex, data);
		}

		private void UpdateActiveHarmonicParameters()
		{
			var data = _mainFormController.GetActiveHarmonicData();
			amplitudeText.Text = data.Amplitude.ToString();
			frequencyText.Text = data.Frequency.ToString();
			phaseText.Text = data.Phase.ToString();
			switch (data.Type)
			{
				case HarmonicType.Cos:
					cosButton.Checked = true;
					break;
				case HarmonicType.Sin:
					sinButton.Checked = true;
					break;
			}
		}

		private void ResetHarmonicParamenters()
		{
			_blockEvents = true;
			amplitudeText.Text = "";
			frequencyText.Text = "";
			phaseText.Text = "";
			sinButton.Checked = true;
			_blockEvents = false;
		}

		private void amplitudeText_TextChanged(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0 && !_blockEvents)
			{
				var text = amplitudeText.Text;
				var isEmplty = text.Length == 0;
				if (!isEmplty && float.TryParse(text, out var value))
				{
					_mainFormController.UpdateSelectedHarmonicAmplitude(value);
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
					_mainFormController.UpdateSelectedHarmonicType(HarmonicType.Cos);
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
					_mainFormController.UpdateSelectedHarmonicFrequency(value);
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
					_mainFormController.UpdateSelectedHarmonicPhase(value);
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
				_mainFormController.DeleteSelectedHarmonic(harmonicsList.SelectedIndex);
			}
		}

		private void harmonicsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_blockEvents && harmonicsList.SelectedItems.Count != 0)
			{
				_mainFormController.ChangeSelectedHarmonic(harmonicsList.SelectedIndex);
			}
		}

		private void sinButton_CheckedChanged(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0 && !_blockEvents)
			{
				if (sinButton.Checked)
				{
					_mainFormController.UpdateSelectedHarmonicType(HarmonicType.Sin);
				}
			}
		}

		private void tabPage2_Click(object sender, EventArgs e)
		{

		}
	}
}

using System;
using System.Windows.Forms;
using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;
using lab9._1.ChartDrawer.Controllers;
using lab9._1.ChartDrawer.Utils;

namespace lab9._1.ChartDrawer.Views
{
	public partial class MainForm : Form
	{
		private const string ERROR_MESSAGE = "Error, please input float value";

		private IMainFormController _mainFormController;
		private IHarmonicsContainer _harmonicContainer;
		private HarmonicsChart _chart;
		private HarmonicsTable _table;
		private bool _blockChangeEvents = false;

		public MainForm(IHarmonicsContainer harmonicContainer)
		{
			InitializeComponent();
			_chart = new HarmonicsChart(harmonicContainer, harmonicsChart);
			_table = new HarmonicsTable(harmonicContainer, harmonicsTable);
			_harmonicContainer = harmonicContainer;
			_mainFormController = new MainFormController(harmonicContainer);
			_harmonicContainer.HarmonicAdded += AddInList;
			_harmonicContainer.HarmonicDeleted += RemoveFromListByIndex;
			harmonicContainer.ActiveHarmonicChanged += SelectedHarmonicChanged;
			ActivateInput(false);
		}

		private void ActivateInput(bool activate)
		{
			amplitudeText.Enabled = activate;
			frequencyText.Enabled = activate;
			phaseText.Enabled = activate;
			radioButtonsGroup.Enabled = activate;
			deleteButton.Enabled = activate;
		}

		private void RemoveFromListByIndex(int index)
		{
			harmonicsList.Items.RemoveAt(index);

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
		}

		private void SelectedHarmonicChanged(int index)
		{
			if (index != -1)
			{
				_blockChangeEvents = true;
				harmonicsList.SetSelected(index, true);
				UpdateActiveHarmonicParameters();
				_blockChangeEvents = false;
			}
			else
			{
				ResetHarmonicParamenters();
			}
		}

		private void OnHarmonicParametersChanged()
		{
			_blockChangeEvents = true;
			var data = _mainFormController.GetActiveHarmonicData();
			harmonicsList.Items[harmonicsList.SelectedIndex] = Converter.GetStringRepresentation(data);
			_blockChangeEvents = false;
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
			_blockChangeEvents = true;
			amplitudeText.Text = "";
			frequencyText.Text = "";
			phaseText.Text = "";
			sinButton.Checked = true;
			_blockChangeEvents = false;
		}

		private void amplitudeText_TextChanged(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0 && !_blockChangeEvents)
			{
				if (Validator.TryValidateTextBox(amplitudeText, out var value))
				{
					_mainFormController.UpdateSelectedHarmonicAmplitude(value);
				}
				else
				{
					MessageBox.Show(ERROR_MESSAGE);
				}
			}
		}

		private void cosButton_CheckedChanged(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0 && !_blockChangeEvents)
			{
				if (cosButton.Checked)
				{
					_mainFormController.UpdateSelectedHarmonicType(HarmonicType.Cos);
				}
			}
		}

		private void frequencyText_TextChanged(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0 && !_blockChangeEvents)
			{
				if (Validator.TryValidateTextBox(frequencyText, out var value))
				{
					_mainFormController.UpdateSelectedHarmonicFrequency(value);
				}
				else
				{
					MessageBox.Show(ERROR_MESSAGE);
				}
			}
		}

		private void phaseText_TextChanged(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0 && !_blockChangeEvents)
			{
				if (Validator.TryValidateTextBox(phaseText, out var value))
				{
					_mainFormController.UpdateSelectedHarmonicPhase(value);
				}
				else
				{
					MessageBox.Show(ERROR_MESSAGE);
				}
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			var harmonicForm = new HarmonicCreatorForm(_harmonicContainer);
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
			if (!_blockChangeEvents && harmonicsList.SelectedItems.Count != 0)
			{
				_mainFormController.ChangeSelectedHarmonic(harmonicsList.SelectedIndex);
			}
		}

		private void sinButton_CheckedChanged(object sender, EventArgs e)
		{
			if (harmonicsList.SelectedItems.Count != 0 && !_blockChangeEvents)
			{
				if (sinButton.Checked)
				{
					_mainFormController.UpdateSelectedHarmonicType(HarmonicType.Sin);
				}
			}
		}
	}
}

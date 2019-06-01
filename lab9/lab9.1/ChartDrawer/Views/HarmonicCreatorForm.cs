using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;
using lab9._1.ChartDrawer.Controllers;
using System;
using System.Windows.Forms;
using lab9._1.ChartDrawer.Utils;

namespace lab9._1.ChartDrawer.Views
{
	public partial class HarmonicCreatorForm : Form
	{
		private const string ERROR_MESSAGE = "Error, please input float value";

		private IHarmonicCreatorController _harmonicCreatorController;

		public HarmonicCreatorForm(IHarmonicsContainer harmonicsManager)
		{
			InitializeComponent();
			_harmonicCreatorController = new HarmonicCreatorController(harmonicsManager);
			UpdateViewFields();
			_harmonicCreatorController.SubscribeToHarmonicChanges(UpdateViewFields);
		}

		private void UpdateViewFields()
		{
			var data = _harmonicCreatorController.GetHarmonicData();
			resultHarmonicText.Text = Converter.GetStringRepresentation(data);
			amplitudeText.Text = data.Amplitude.ToString();
			frequencyText.Text = data.Frequency.ToString();
			phaseText.Text = data.Phase.ToString();
			switch (data.Type)
			{
				case HarmonicType.Sin:
					sinButton.Checked = true;
					break;
				case HarmonicType.Cos:
					cosButton.Checked = true;
					break;
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			_harmonicCreatorController.AddNewHarmonic();
			Close();
		}

		private void frequencyText_TextChanged(object sender, EventArgs e)
		{
			if (Validator.TryValidateTextBox(frequencyText, out var value))
			{
				_harmonicCreatorController.ChangeHarmonicFrequency(value);
			}
			else
			{
				MessageBox.Show(ERROR_MESSAGE);
			}
		}

		private void phaseText_TextChanged(object sender, EventArgs e)
		{
			if (Validator.TryValidateTextBox(phaseText, out var value))
			{
				_harmonicCreatorController.ChangeHarmonicPhase(value);
			}
			else
			{
				MessageBox.Show(ERROR_MESSAGE);
			}
		}

		private void amplitudeText_TextChanged(object sender, EventArgs e)
		{
			if (Validator.TryValidateTextBox(amplitudeText, out var value))
			{
				_harmonicCreatorController.ChangeHarmonicAmplitude(value);
			}
			else
			{
				MessageBox.Show(ERROR_MESSAGE);
			}
		}

		private void cosButton_CheckedChanged(object sender, EventArgs e)
		{
			if (cosButton.Checked)
			{
				_harmonicCreatorController.ChangeHarmonicType(HarmonicType.Cos);
			}
		}

		private void sinButton_CheckedChanged(object sender, EventArgs e)
		{
			if (sinButton.Checked)
			{
				_harmonicCreatorController.ChangeHarmonicType(HarmonicType.Sin);
			}
		}
	}
}

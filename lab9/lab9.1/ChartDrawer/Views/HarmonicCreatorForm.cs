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
		private IHarmonicsManager _mainWindow;
		private IHarmonicCreatorController _harmonicCreatorController;

		public HarmonicCreatorForm(IHarmonicsManager harmonicsManager)
		{
			InitializeComponent();
			_mainWindow = harmonicsManager;
			_harmonicCreatorController = new HarmonicCreatorController(harmonicsManager);
			UpdateViewFields();
			_harmonicCreatorController.SubscribeToHarmonicChanges(UpdateViewFields);
		}

		private void OnHarmonicChanged()
		{
			_harmonicCreatorController.SubscribeToHarmonicChanges(UpdateViewFields);
		}

		private void UpdateViewFields()
		{
			var data = _harmonicCreatorController.GetHarmonicView();
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
			var text = frequencyText.Text;
			var isEmplty = text.Length == 0;
			if (!isEmplty && float.TryParse(text, out var value))
			{
				_harmonicCreatorController.ChangeHarmonicFrequency(value);
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

		private void phaseText_TextChanged(object sender, EventArgs e)
		{
			var text = phaseText.Text;
			var isEmplty = text.Length == 0;
			if (!isEmplty && float.TryParse(text, out var value))
			{
				_harmonicCreatorController.ChangeHarmonicPhase(value);
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

		private void amplitudeText_TextChanged(object sender, EventArgs e)
		{
			var text = amplitudeText.Text;
			var isEmplty = text.Length == 0;
			if (!isEmplty && float.TryParse(text, out var value))
			{
				_harmonicCreatorController.ChangeHarmonicAmplitude(value);
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

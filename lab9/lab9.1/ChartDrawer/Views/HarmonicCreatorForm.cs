using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;
using lab9._1.ChartDrawer.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9._1.ChartDrawer.Views
{
	public partial class HarmonicCreatorForm : Form, IHarmonicCreatorView
	{
		private IHarmonic _harmonic;
		private IMainWindow _mainWindow;
		private IHarmonicCreatorController _harmonicCreatorPresenter;

		public HarmonicCreatorForm(IMainWindow mainWindow)
		{
			InitializeComponent();
			_mainWindow = mainWindow;
			_harmonicCreatorPresenter = new HarmonicCreatorController(mainWindow);
			_harmonic = new Harmonic();
			resultHarmonicText.Text = _harmonic.ToString();
			amplitudeText.Text = _harmonic.Amplitude.ToString();
			frequencyText.Text = _harmonic.Frequency.ToString();
			phaseText.Text = _harmonic.Phase.ToString();
			switch (_harmonic.Type)
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
			_harmonicCreatorPresenter.AddNewHarmonic(_harmonic);
			Close();
		}

		private void frequencyText_TextChanged(object sender, EventArgs e)
		{
			var text = frequencyText.Text;
			var isEmplty = text.Length == 0;
			if (!isEmplty && float.TryParse(text, out var value))
			{
				_harmonic.Frequency = value;
				resultHarmonicText.Text = _harmonic.ToString();
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
				_harmonic.Phase = value;
				resultHarmonicText.Text = _harmonic.ToString();
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
				_harmonic.Amplitude = value;
				resultHarmonicText.Text = _harmonic.ToString();
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
				_harmonic.Type = HarmonicType.Cos;
				resultHarmonicText.Text = _harmonic.ToString();
			}
		}

		private void sinButton_CheckedChanged(object sender, EventArgs e)
		{
			if (sinButton.Checked)
			{
				_harmonic.Type = HarmonicType.Sin;
				resultHarmonicText.Text = _harmonic.ToString();
			}
		}
	}
}

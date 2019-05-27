
using System;
using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;
using lab9._1.ChartDrawer.Views;

namespace lab9._1.ChartDrawer.Controllers
{
	public sealed class MainFormController : IMainFormController
	{
		private IHarmonicsManager _mainWindow;

		public MainFormController(IHarmonicsManager mainWindow)
		{
			_mainWindow = mainWindow;
		}

		public void DeleteSelectedHarmonic(int index)
		{
			_mainWindow.DeleteHarmonicByIndex(index);
		}

		public void ChangeSelectedHarmonic(int index)
		{
			_mainWindow.SelectHarmonicByIndex(index);
		}

		public void UpdateSelectedHarmonicAmplitude(float amplitude)
		{
			var harmonics = _mainWindow.GetAllHarmonics();
			if (harmonics.Count != 0)
			{
				harmonics[_mainWindow.ActiveHarmonicIndex].Amplitude = amplitude;
			}	
		}

		public void UpdateSelectedHarmonicFrequency(float frequency)
		{
			var harmonics = _mainWindow.GetAllHarmonics();
			if (harmonics.Count != 0)
			{
				harmonics[_mainWindow.ActiveHarmonicIndex].Frequency = frequency;
			}
		}

		public void UpdateSelectedHarmonicPhase(float phase)
		{
			var harmonics = _mainWindow.GetAllHarmonics();
			if (harmonics.Count != 0)
			{
				harmonics[_mainWindow.ActiveHarmonicIndex].Phase = phase;
			}
		}

		public void UpdateSelectedHarmonicType(HarmonicType type)
		{
			var harmonics = _mainWindow.GetAllHarmonics();
			if (harmonics.Count != 0)
			{
				harmonics[_mainWindow.ActiveHarmonicIndex].Type = type;
			}
		}

		public HarmonicData GetActiveHarmonicData()
		{
			var harmonics = _mainWindow.GetAllHarmonics();
			var activeHarmonicIndex = _mainWindow.ActiveHarmonicIndex;
			if (activeHarmonicIndex < 0)
			{
				return null;
			}

			var harmonic = harmonics[activeHarmonicIndex];
			return new HarmonicData(harmonic);
			
		}

		public void SubscribeToActiveHarmonicEvents(Action action)
		{
			var harmonics = _mainWindow.GetAllHarmonics();
			harmonics[_mainWindow.ActiveHarmonicIndex].ParametersChanged += action;
		}
	}
}

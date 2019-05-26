
using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;

namespace lab9._1.ChartDrawer.Controllers
{
	public sealed class MainFormController : IMainFormController
	{
		private IHarmonicsManager _mainWindow;
		private int _lastSelected = -1;

		public MainFormController(IHarmonicsManager mainWindow)
		{
			_mainWindow = mainWindow;
		}

		public void DeleteSelectedHarmonic(int index)
		{
			_lastSelected = -1;
			_mainWindow.DeleteHarmonicByIndex(index);
		}

		public void GetSelectedHarmonic(int index)
		{
			if (_lastSelected != index)
			{
				_lastSelected = index;
				_mainWindow.SelectHarmonicByIndex(index);
			}
		}

		public void UpdateSelectedHarmonicAmplitude(int index, float amplitude)
		{
			_mainWindow.ChangeSelectedHarmonicAmplitude(index, amplitude);
		}

		public void UpdateSelectedHarmonicFrequency(int index, float frequency)
		{
			_mainWindow.ChangeSelectedHarmonicFrequency(index, frequency);
		}

		public void UpdateSelectedHarmonicPhase(int index, float phase)
		{
			_mainWindow.ChangeSelectedHarmonicPhase(index, phase);
		}

		public void UpdateSelectedHarmonicType(int index, HarmonicType type)
		{
			_mainWindow.ChangeSelectedHarmonicType(index, type);
		}
	}
}

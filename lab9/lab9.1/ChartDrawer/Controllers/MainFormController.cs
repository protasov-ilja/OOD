using System;
using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;
using lab9._1.ChartDrawer.Views;

namespace lab9._1.ChartDrawer.Controllers
{
	public sealed class MainFormController : IMainFormController
	{
		private IHarmonicsContainer _harmonicsContainer;

		public MainFormController(IHarmonicsContainer harmonicsContainer)
		{
			_harmonicsContainer = harmonicsContainer;
		}

		public void DeleteActiveHarmonic()
		{
			_harmonicsContainer.DeleteActiveHarmonic();
		}

		public void ChangeSelectedHarmonic(int index)
		{
			_harmonicsContainer.SelectHarmonicByIndex(index);
		}

		public void UpdateSelectedHarmonicAmplitude(float amplitude)
		{
			if (!_harmonicsContainer.IsEmpty())
			{
				_harmonicsContainer.GetHarmonicByIndex(_harmonicsContainer.ActiveHarmonicIndex).Amplitude = amplitude;
			}
		}

		public void UpdateSelectedHarmonicFrequency(float frequency)
		{
			if (!_harmonicsContainer.IsEmpty())
			{
				_harmonicsContainer.GetHarmonicByIndex(_harmonicsContainer.ActiveHarmonicIndex).Frequency = frequency;
			}
		}

		public void UpdateSelectedHarmonicPhase(float phase)
		{
			if (!_harmonicsContainer.IsEmpty())
			{
				_harmonicsContainer.GetHarmonicByIndex(_harmonicsContainer.ActiveHarmonicIndex).Phase = phase;
			}
		}

		public void UpdateSelectedHarmonicType(HarmonicType type)
		{
			if (!_harmonicsContainer.IsEmpty())
			{
				_harmonicsContainer.GetHarmonicByIndex(_harmonicsContainer.ActiveHarmonicIndex).Type = type;
			}
		}

		public HarmonicData GetActiveHarmonicData()
		{
			var activeHarmonicIndex = _harmonicsContainer.ActiveHarmonicIndex;
			if (activeHarmonicIndex < 0)
			{
				return null;
			}

			var harmonic = _harmonicsContainer.GetHarmonicByIndex(activeHarmonicIndex);

			return new HarmonicData(harmonic);
		}

		public void SubscribeToActiveHarmonicEvents(Action action)
		{
			_harmonicsContainer.GetHarmonicByIndex(_harmonicsContainer.ActiveHarmonicIndex).ParametersChanged += action;
		}
	}
}

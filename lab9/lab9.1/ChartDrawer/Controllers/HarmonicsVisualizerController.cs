using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Views;
using System;

namespace lab9._1.ChartDrawer.Controllers
{
	public sealed class HarmonicsVisualizerController : IHarmonicsVisualizerController
	{
		private IHarmonicsContainer _harmonicsContainer;

		public HarmonicsVisualizerController(IHarmonicsContainer harmonicsContainer)
		{
			_harmonicsContainer = harmonicsContainer;
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

		public int GetIndexOfActiveHarmonic()
		{
			return _harmonicsContainer.ActiveHarmonicIndex;
		}

		public void SubscribeToActiveHarmonicEvents(Action action)
		{
			_harmonicsContainer.GetHarmonicByIndex(_harmonicsContainer.ActiveHarmonicIndex).ParametersChanged += action;
		}
	}
}

using lab9._1.ChartDrawer.Views;
using System;

namespace lab9._1.ChartDrawer.Controllers
{
	public interface IHarmonicsVisualizerController
	{
		HarmonicData GetActiveHarmonicData();
		int GetIndexOfActiveHarmonic();
		void SubscribeToActiveHarmonicEvents(Action action);
	}
}

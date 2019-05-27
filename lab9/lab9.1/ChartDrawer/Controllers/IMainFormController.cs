using lab9._1.ChartDrawer.Models.Enums;
using lab9._1.ChartDrawer.Views;
using System;

namespace lab9._1.ChartDrawer.Controllers
{
	public interface IMainFormController
	{
		void DeleteSelectedHarmonic(int index);
		void UpdateSelectedHarmonicAmplitude(float amplitude);
		void UpdateSelectedHarmonicType(HarmonicType type);
		void UpdateSelectedHarmonicFrequency(float frequency);
		void UpdateSelectedHarmonicPhase(float phase);
		void ChangeSelectedHarmonic(int index);

		HarmonicData GetActiveHarmonicData();
		void SubscribeToActiveHarmonicEvents(Action action);
	}
}

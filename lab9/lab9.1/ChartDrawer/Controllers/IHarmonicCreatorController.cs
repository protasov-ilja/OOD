using lab9._1.ChartDrawer.Models.Enums;
using lab9._1.ChartDrawer.Views;
using System;

namespace lab9._1.ChartDrawer.Controllers
{
	public interface IHarmonicCreatorController
	{
		void AddNewHarmonic();
		string GetHarmonicStringRepresentation();
		HarmonicViewData GetHarmonicView();
		void SubscribeToHarmonicChanges(Action action);
		void ChangeHarmonicFrequency(float value);
		void ChangeHarmonicAmplitude(float value);
		void ChangeHarmonicPhase(float value);
		void ChangeHarmonicType(HarmonicType value);
	}
}

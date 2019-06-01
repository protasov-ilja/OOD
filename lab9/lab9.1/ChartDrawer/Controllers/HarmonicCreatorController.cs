using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;
using lab9._1.ChartDrawer.Views;
using System;

namespace lab9._1.ChartDrawer.Controllers
{
	public sealed class HarmonicCreatorController : IHarmonicCreatorController
	{
		private IHarmonicsContainer _harmonicsContainer;
		private Harmonic _harmonic;

		public HarmonicCreatorController(IHarmonicsContainer harmonicsContainer)
		{
			_harmonic = new Harmonic();
			_harmonicsContainer = harmonicsContainer;
		}

		public void SubscribeToHarmonicChanges(Action action)
		{
			_harmonic.ParametersChanged += action;
		}

		public HarmonicData GetHarmonicData()
		{
			return new HarmonicData(_harmonic.Type, _harmonic.Amplitude, _harmonic.Frequency, _harmonic.Phase);
		}

		public void AddNewHarmonic()
		{
			_harmonicsContainer.AddNewHarmonic(_harmonic);
		}

		public void ChangeHarmonicFrequency(float value)
		{
			_harmonic.Frequency = value;
		}

		public void ChangeHarmonicAmplitude(float value)
		{
			_harmonic.Amplitude = value;
		}

		public void ChangeHarmonicPhase(float value)
		{
			_harmonic.Phase = value;
		}

		public void ChangeHarmonicType(HarmonicType value)
		{
			_harmonic.Type = value;
		}
	}
}

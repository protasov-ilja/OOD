using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;
using lab9._1.ChartDrawer.Views;
using System;

namespace lab9._1.ChartDrawer.Controllers
{
	public sealed class HarmonicCreatorController : IHarmonicCreatorController
	{
		private IHarmonicsManager _mainWindow;
		private Harmonic _harmonic;

		public HarmonicCreatorController(IHarmonicsManager mainWindow)
		{
			_harmonic = new Harmonic();
			_mainWindow = mainWindow;
		}

		public void SubscribeToHarmonicChanges(Action action)
		{
			_harmonic.ParametersChanged += action;
		}

		public HarmonicViewData GetHarmonicView()
		{
			return new HarmonicViewData(_harmonic.Type, _harmonic.Amplitude, _harmonic.Frequency, _harmonic.Phase);
		}

		public string GetHarmonicStringRepresentation()
		{
			return $"{ _harmonic.Amplitude } * { (_harmonic.Type == HarmonicType.Cos ? "cos" : "sin") }({ _harmonic.Frequency } * x + { _harmonic.Phase })";
		}

		public void AddNewHarmonic()
		{
			_mainWindow.AddNewHarmonic(_harmonic);
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

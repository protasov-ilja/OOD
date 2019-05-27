using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab9Tests.ChartDrawer
{
	[TestClass]
	public sealed class HarmonicTests
	{
		public string GetHarmonicStringRepresentation(HarmonicType t, float a, float f, float p)
		{
			return $"{ a } * { (t == HarmonicType.Cos ? "cos" : "sin") }({ f } * x + { p })";
		}

		[TestMethod]
		public void CanCreateSinHarmonicAndReturnItsStringRepresentationWithValueParametersEvent()
		{
			var hType = HarmonicType.Sin;
			float hAmplitude = 1;
			float hFrequency = 2;
			float hPhase = 3;
			var h = new Harmonic(hType, hAmplitude, hFrequency, hPhase);
			Assert.AreEqual(h.Type, hType);
			Assert.AreEqual(h.Amplitude, hAmplitude);
			Assert.AreEqual(h.Frequency, hFrequency);
			Assert.AreEqual(h.Phase, hPhase);
			Assert.AreEqual(h.ToString(), GetHarmonicStringRepresentation(hType, hAmplitude, hFrequency, hPhase));
		}

		[TestMethod]
		public void CanCreateCosHarmonicAndReturnItsStringRepresentation()
		{
			var hType = HarmonicType.Cos;
			float hAmplitude = 1;
			float hFrequency = 2;
			float hPhase = 3;
			var h = new Harmonic(hType, hAmplitude, hFrequency, hPhase);
			Assert.AreEqual(h.Type, hType);
			Assert.AreEqual(h.Amplitude, hAmplitude);
			Assert.AreEqual(h.Frequency, hFrequency);
			Assert.AreEqual(h.Phase, hPhase);
			Assert.AreEqual(h.ToString(), GetHarmonicStringRepresentation(hType, hAmplitude, hFrequency, hPhase));
		}

		[TestMethod]
		public void CanCreateSinHarmonicWith1ParametersAnd0PhaseByDefault()
		{
			var hType = HarmonicType.Sin;
			float hAmplitude = 1;
			float hFrequency = 1;
			float hPhase = 0;
			var h = new Harmonic();
			Assert.AreEqual(h.Type, hType);
			Assert.AreEqual(h.Amplitude, hAmplitude);
			Assert.AreEqual(h.Frequency, hFrequency);
			Assert.AreEqual(h.Phase, hPhase);
			Assert.AreEqual(h.ToString(), GetHarmonicStringRepresentation(hType, hAmplitude, hFrequency, hPhase));
		}
	}
}

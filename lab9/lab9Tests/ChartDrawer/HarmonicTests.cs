using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab9Tests.ChartDrawer
{
	[TestClass]
	public sealed class HarmonicTests
	{
		[TestMethod]
		public void CanCreateSinHarmonic()
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
		}

		[TestMethod]
		public void CanCreateCosHarmonic()
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
		}

		[TestMethod]
		public void CanInvokeParametersChangedEvenIfHarmonicParametersChanged()
		{
			{ // type changed
				var textObject = new TestObject();
				var hType = HarmonicType.Cos;
				var h = new Harmonic();
				h.ParametersChanged += textObject.OnHarmonicsChanged;
				h.Type = hType;
				Assert.AreEqual(h.Type, hType);
				Assert.IsTrue(textObject.IsEventHarmonicParametersChangedInvoked);
			}

			{ // type Amplitude
				var textObject = new TestObject();
				float hAmplitude = 2;
				var h = new Harmonic();
				h.ParametersChanged += textObject.OnHarmonicsChanged;
				h.Amplitude = hAmplitude;
				Assert.AreEqual(h.Amplitude, hAmplitude);
				Assert.IsTrue(textObject.IsEventHarmonicParametersChangedInvoked);
			}

			{ // type Frequency
				var textObject = new TestObject();
				float hFrequency = 3;
				var h = new Harmonic();
				h.ParametersChanged += textObject.OnHarmonicsChanged;
				h.Frequency = hFrequency;
				Assert.AreEqual(h.Frequency, hFrequency);
				Assert.IsTrue(textObject.IsEventHarmonicParametersChangedInvoked);
			}

			{ // type Frequency
				var textObject = new TestObject();
				float hPhase = 2;
				var h = new Harmonic();
				h.ParametersChanged += textObject.OnHarmonicsChanged;
				h.Phase = hPhase;
				Assert.AreEqual(h.Phase, hPhase);
				Assert.IsTrue(textObject.IsEventHarmonicParametersChangedInvoked);
			}
		}
	}
}

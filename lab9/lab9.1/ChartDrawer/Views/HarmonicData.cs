using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;

namespace lab9._1.ChartDrawer.Views
{
	public sealed class HarmonicData
	{
		public HarmonicType Type { get; private set; }
		public float Amplitude { get; private set; }
		public float Frequency { get; private set; }
		public float Phase { get; private set; }

		public HarmonicData(HarmonicType type, float amplitude, float frequency, float phase)
		{
			Type = type;
			Amplitude = amplitude;
			Frequency = frequency;
			Phase = phase;
		}

		public HarmonicData(Harmonic harmonic)
		{
			Type = harmonic.Type;
			Amplitude = harmonic.Amplitude;
			Frequency = harmonic.Frequency;
			Phase = harmonic.Phase;
		}
	}
}

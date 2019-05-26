using lab9._1.ChartDrawer.Models.Enums;

namespace lab9._1.ChartDrawer.Views
{
	public sealed class HarmonicViewData
	{
		public HarmonicType Type { get; private set; }
		public float Amplitude { get; private set; }
		public float Frequency { get; private set; }
		public float Phase { get; private set; }

		public HarmonicViewData(HarmonicType type, float amplitude, float frequency, float phase)
		{
			Type = type;
			Amplitude = amplitude;
			Frequency = frequency;
			Phase = phase;
		}
	}
}

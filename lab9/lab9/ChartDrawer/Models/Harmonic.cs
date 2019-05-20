using lab9.ChartDrawer.Models.Enums;

namespace lab9.ChartDrawer.Models
{
	public sealed class Harmonic : IHarmonic
	{
		public HarmonicType Type { get; set; } = HarmonicType.Sin;
		public float Amplitude { get; set; } = 1;
		public float Frequency { get; set; } = 1;
		public float Phase { get; set; } = 0;

		public Harmonic() { }

		public Harmonic(HarmonicType type, float amplitude, float frequency, float phase)
		{
			Type = type;
			Amplitude = amplitude;
			Frequency = frequency;
			Phase = phase;
		}

		public override string ToString()
		{
			return $"{ Amplitude } * { HarmonicTypeToString() }({ Frequency } * x + { Phase })";
		}

		private string HarmonicTypeToString()
		{
			return Type == HarmonicType.Cos ? "cos" : "sin";
		}
	}
}

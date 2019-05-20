using lab9.ChartDrawer.Models.Enums;

namespace lab9.ChartDrawer.Models
{
	public interface IHarmonic
	{
		HarmonicType Type { get; set; }
		float Amplitude { get; set; }
		float Frequency { get; set; }
		float Phase { get; set; }
	}
}

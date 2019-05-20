using lab9._1.ChartDrawer.Models.Enums;

namespace lab9._1.ChartDrawer.Controllers
{
	public interface IMainFormController
	{
		void DeleteSelectedHarmonic(int index);
		void UpdateSelectedHarmonicAmplitude(int index, float amplitude);
		void UpdateSelectedHarmonicType(int index, HarmonicType type);
		void UpdateSelectedHarmonicFrequency(int index, float frequency);
		void UpdateSelectedHarmonicPhase(int index, float phase);
		void GetSelectedHarmonic(int index);
	}
}

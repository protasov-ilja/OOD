using System;

namespace lab9.ChartDrawer.Models
{
	public interface IMainWindow
	{
		event Action HarmonicsChanged;

		void AddNewHarmonic(IHarmonic hurmonic);
		void DeleteHarmonicById(int id);
		void ChangeHarmonicValues(int id, IHarmonic harmonic);
	}
}

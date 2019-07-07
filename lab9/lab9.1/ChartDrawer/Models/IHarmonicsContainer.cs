using System;

namespace lab9._1.ChartDrawer.Models
{
	public interface IHarmonicsContainer
	{
		event Action<int> ActiveHarmonicChanged;
		event Action<int> HarmonicDeleted;
		event Action<int> HarmonicAdded;

		int ActiveHarmonicIndex { get; }

		void AddNewHarmonic(Harmonic hurmonic);
		void DeleteActiveHarmonic();
		Harmonic GetHarmonicByIndex(int index);
		bool IsEmpty();
		void SelectHarmonicByIndex(int index);
	}
}

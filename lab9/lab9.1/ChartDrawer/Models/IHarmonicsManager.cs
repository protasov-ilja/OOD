using System;
using System.Collections.Generic;

namespace lab9._1.ChartDrawer.Models
{
	public interface IHarmonicsManager
	{
		event Action<int> ActiveHarmonicChanged;
		event Action<int> HarmonicDeleted;
		event Action<int> HarmonicAdded;

		int ActiveHarmonicIndex { get; }

		void AddNewHarmonic(Harmonic hurmonic);
		void DeleteHarmonicByIndex(int index);
		List<Harmonic> GetAllHarmonics();
		void SelectHarmonicByIndex(int index);
	}
}

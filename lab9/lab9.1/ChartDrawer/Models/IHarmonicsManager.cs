using lab9._1.ChartDrawer.Models.Enums;
using System;
using System.Collections.Generic;

namespace lab9._1.ChartDrawer.Models
{
	public interface IHarmonicsManager
	{
		event Action<List<Harmonic>> HarmonicsChanged;
		event Action<Harmonic> ActiveHarmonicChanged;

		void AddNewHarmonic(Harmonic hurmonic);
		void DeleteHarmonicByIndex(int index);
		void ChangeSelectedHarmonicAmplitude(int index, float amplitude);
		void ChangeSelectedHarmonicType(int index, HarmonicType type);
		void ChangeSelectedHarmonicFrequency(int index, float frequency);
		void ChangeSelectedHarmonicPhase(int index, float phase);
		void SelectHarmonicByIndex(int index);
	}
}

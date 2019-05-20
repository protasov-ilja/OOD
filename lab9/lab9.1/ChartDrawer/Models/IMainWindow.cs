using lab9._1.ChartDrawer.Models.Enums;
using System;
using System.Collections.Generic;

namespace lab9._1.ChartDrawer.Models
{
	public interface IMainWindow
	{
		event Action<List<IHarmonic>> HarmonicsChanged;
		event Action<IHarmonic> SelectedHarmonicChanged;

		void AddNewHarmonic(IHarmonic hurmonic);
		void DeleteHarmonicById(int id);
		void ChangeSelectedHarmonicAmplitude(int id, float amplitude);
		void ChangeSelectedHarmonicType(int id, HarmonicType type);
		void ChangeSelectedHarmonicFrequency(int id, float frequency);
		void ChangeSelectedHarmonicPhase(int id, float phase);
		void GetHarmonicById(int id);
	}
}

using lab9._1.ChartDrawer.Models;
using System.Collections.Generic;

namespace lab9Tests.ChartDrawer
{
	public class TestObject
	{
		public bool IsEventHarmonicsChangedInvoked { get; private set; } = false;
		public bool IsEventHarmonicChangedInvoked { get; private set; } = false;
		public List<Harmonic> Harmonics { get; private set; }
		public Harmonic SelectedHarmonic { get; private set; }

		public void OnHarmonicsChanged(List<Harmonic> harmonics)
		{
			Harmonics = harmonics;
			IsEventHarmonicsChangedInvoked = true;
		}

		public void OnSelectedHarmonicChanged(Harmonic harmonic)
		{
			IsEventHarmonicChangedInvoked = true;
			SelectedHarmonic = harmonic;
		}
	}
}

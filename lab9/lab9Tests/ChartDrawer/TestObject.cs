using lab9._1.ChartDrawer.Models;
using System.Collections.Generic;

namespace lab9Tests.ChartDrawer
{
	public class TestObject
	{
		public bool IsEventHarmonicsChangedInvoked { get; private set; } = false;
		public bool IsEventHarmonicChangedInvoked { get; private set; } = false;
		public List<IHarmonic> Harmonics { get; private set; }
		public IHarmonic SelectedHarmonic { get; private set; }

		public void OnHarmonicsChanged(List<IHarmonic> harmonics)
		{
			Harmonics = harmonics;
			IsEventHarmonicsChangedInvoked = true;
		}

		public void OnSelectedHarmonicChanged(IHarmonic harmonic)
		{
			IsEventHarmonicChangedInvoked = true;
			SelectedHarmonic = harmonic;
		}
	}
}

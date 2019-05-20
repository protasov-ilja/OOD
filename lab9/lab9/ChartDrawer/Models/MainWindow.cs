using System;
using System.Collections.Generic;

namespace lab9.ChartDrawer.Models
{
	public sealed class MainWindow : IMainWindow
	{
		private Dictionary<int, IHarmonic> _harmonics;
		private int _maxId = 0;
		
		public event Action HarmonicsChanged;

		public void AddNewHarmonic(IHarmonic harmonic)
		{
			_harmonics.Add(_maxId, harmonic);
			_maxId++;
			HarmonicsChanged?.Invoke();
		}

		public void DeleteHarmonicById(int id)
		{
			if (_harmonics.ContainsKey(id))
			{
				_harmonics.Remove(id);
				HarmonicsChanged?.Invoke();
			}
		}

		public void ChangeHarmonicValues(int id, IHarmonic harmonic)
		{
			if (_harmonics.ContainsKey(id))
			{
				_harmonics[id] = harmonic;
				HarmonicsChanged?.Invoke();
			}
		}
	}
}

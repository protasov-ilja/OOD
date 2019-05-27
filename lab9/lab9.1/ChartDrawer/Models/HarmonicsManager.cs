using System;
using System.Collections.Generic;
using lab9._1.ChartDrawer.Models.Enums;

namespace lab9._1.ChartDrawer.Models
{
	public sealed class HarmonicsManager : IHarmonicsManager
	{
		private List<Harmonic> _harmonics = new List<Harmonic>();
		public int ActiveHarmonicIndex { get; private set; } = -1;

		public event Action<int> ActiveHarmonicChanged;
		public event Action<int> HarmonicDeleted;
		public event Action<int> HarmonicAdded;

		public void AddNewHarmonic(Harmonic harmonic)
		{
			_harmonics.Add(harmonic);
			ActiveHarmonicIndex = _harmonics.Count - 1;
			HarmonicAdded?.Invoke(ActiveHarmonicIndex);
			ActiveHarmonicChanged?.Invoke(ActiveHarmonicIndex);
		}

		public void DeleteHarmonicByIndex(int index)
		{
			if (index >= _harmonics.Count || index < 0)
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			_harmonics.RemoveAt(index);
			HarmonicDeleted?.Invoke(index);
			if (!(ActiveHarmonicIndex == 0 && _harmonics.Count > 0))
			{
				ActiveHarmonicIndex--;
			}

			ActiveHarmonicChanged?.Invoke(ActiveHarmonicIndex);
		}

		public List<Harmonic> GetAllHarmonics()
		{
			return _harmonics;
		}

		public void SelectHarmonicByIndex(int index)
		{
			if (index >= _harmonics.Count || index < 0)
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			ActiveHarmonicIndex = index;
			ActiveHarmonicChanged?.Invoke(ActiveHarmonicIndex);
		}
	}
}

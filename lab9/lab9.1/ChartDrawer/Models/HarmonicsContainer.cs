using System;
using System.Collections.Generic;

namespace lab9._1.ChartDrawer.Models
{
	public sealed class HarmonicsContainer : IHarmonicsContainer
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
			if (!(ActiveHarmonicIndex == 0 && _harmonics.Count > 0))
			{
				ActiveHarmonicIndex--;
			}

			HarmonicDeleted?.Invoke(index);
			ActiveHarmonicChanged?.Invoke(ActiveHarmonicIndex);
		}

		public Harmonic GetHarmonicByIndex(int index)
		{
			if (index >= _harmonics.Count || index < 0)
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			return _harmonics[index];
		}

		public bool IsEmpty()
		{
			return _harmonics.Count == 0;
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

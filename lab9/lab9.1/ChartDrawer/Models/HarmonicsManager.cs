using System;
using System.Collections.Generic;
using lab9._1.ChartDrawer.Models.Enums;

namespace lab9._1.ChartDrawer.Models
{
	public sealed class HarmonicsManager : IHarmonicsManager
	{
		private List<Harmonic> _harmonics = new List<Harmonic>();
		private int _selectedHarmonicIndex = 0;

		public event Action<List<Harmonic>> HarmonicsChanged;
		public event Action<Harmonic> ActiveHarmonicChanged;

		public void AddNewHarmonic(Harmonic harmonic)
		{
			_harmonics.Add(harmonic);
			HarmonicsChanged?.Invoke(_harmonics);
		}

		public void DeleteHarmonicByIndex(int index)
		{
			if (index >= _harmonics.Count || index < 0)
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			_harmonics.RemoveAt(index);
			HarmonicsChanged?.Invoke(_harmonics);
		}

		public void ChangeSelectedHarmonicAmplitude(int index, float amplitude)
		{
			if (index >= _harmonics.Count || index < 0)
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			_harmonics[index].Amplitude = amplitude;
			HarmonicsChanged?.Invoke(_harmonics);
		}

		public void ChangeSelectedHarmonicType(int index, HarmonicType type)
		{
			if (index >= _harmonics.Count || index < 0)
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			_harmonics[index].Type = type;
			HarmonicsChanged?.Invoke(_harmonics);
		}

		public void ChangeSelectedHarmonicFrequency(int index, float frequency)
		{
			if (index >= _harmonics.Count || index < 0)
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			_harmonics[index].Frequency = frequency;
			HarmonicsChanged?.Invoke(_harmonics);
		}

		public void ChangeSelectedHarmonicPhase(int index, float phase)
		{
			if (index >= _harmonics.Count || index < 0)
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			_harmonics[index].Phase = phase;
			HarmonicsChanged?.Invoke(_harmonics);
		}

		public void SelectHarmonicByIndex(int index)
		{
			if (index >= _harmonics.Count || index < 0)
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			_selectedHarmonicIndex = index;
			ActiveHarmonicChanged?.Invoke(_harmonics[_selectedHarmonicIndex]);
		}
	}
}

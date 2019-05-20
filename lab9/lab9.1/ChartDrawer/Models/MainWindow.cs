using System;
using System.Collections.Generic;
using lab9._1.ChartDrawer.Models.Enums;

namespace lab9._1.ChartDrawer.Models
{
	public sealed class MainWindow : IMainWindow
	{
		private List<IHarmonic> _harmonics = new List<IHarmonic>();

		public event Action<List<IHarmonic>> HarmonicsChanged;
		public event Action<IHarmonic> SelectedHarmonicChanged;

		public void AddNewHarmonic(IHarmonic harmonic)
		{
			_harmonics.Add(harmonic);
			HarmonicsChanged?.Invoke(_harmonics);
		}

		public void DeleteHarmonicById(int id)
		{
			if (id >= _harmonics.Count || id < 0)
			{
				throw new IndexOutOfRangeException("id out of range");
			}

			_harmonics.RemoveAt(id);
			HarmonicsChanged?.Invoke(_harmonics);
		}

		public void ChangeSelectedHarmonicAmplitude(int id, float amplitude)
		{
			if (id >= _harmonics.Count || id < 0)
			{
				throw new IndexOutOfRangeException("id out of range");
			}

			_harmonics[id].Amplitude = amplitude;
			HarmonicsChanged?.Invoke(_harmonics);
		}

		public void ChangeSelectedHarmonicType(int id, HarmonicType type)
		{
			if (id >= _harmonics.Count || id < 0)
			{
				throw new IndexOutOfRangeException("id out of range");
			}

			_harmonics[id].Type = type;
			HarmonicsChanged?.Invoke(_harmonics);
		}

		public void ChangeSelectedHarmonicFrequency(int id, float frequency)
		{
			if (id >= _harmonics.Count || id < 0)
			{
				throw new IndexOutOfRangeException("id out of range");
			}

			_harmonics[id].Frequency = frequency;
			HarmonicsChanged?.Invoke(_harmonics);
		}

		public void ChangeSelectedHarmonicPhase(int id, float phase)
		{
			if (id >= _harmonics.Count || id < 0)
			{
				throw new IndexOutOfRangeException("id out of range");
			}

			_harmonics[id].Phase = phase;
			HarmonicsChanged?.Invoke(_harmonics);
		}

		public void GetHarmonicById(int id)
		{
			if (id >= _harmonics.Count || id < 0)
			{
				throw new IndexOutOfRangeException("id out of range");
			}

			SelectedHarmonicChanged?.Invoke(_harmonics[id]);
		}
	}
}

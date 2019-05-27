using lab9._1.ChartDrawer.Models.Enums;
using System;
using System.Collections.Generic;

namespace lab9._1.ChartDrawer.Views
{
	public abstract class HarmonicsVisualizer
	{
		protected List<HarmonicData> _harmonicsData = new List<HarmonicData>();

		public void AddHarmonicData(HarmonicData data)
		{
			_harmonicsData.Add(data);
			Update();
		}

		public void RemoveHarmonicDataAtIndex(int index)
		{
			_harmonicsData.RemoveAt(index);
			Update();
		}

		public void UpdateHarmonicData(int index, HarmonicData data)
		{
			_harmonicsData[index] = data;
			Update();
		}

		protected abstract void Update();

		protected double GetResultY(float x, List<HarmonicData> harmonics)
		{
			double result = 0;
			foreach (var harmonic in harmonics)
			{
				result += GetYValue(x, harmonic);
			}

			return result;
		}

		private double GetYValue(float x, HarmonicData harmonic)
		{
			return harmonic.Type == HarmonicType.Sin
				? harmonic.Amplitude * Math.Sin(harmonic.Frequency * x + harmonic.Phase)
				: harmonic.Amplitude * Math.Cos(harmonic.Frequency * x + harmonic.Phase);
		}
	}
}

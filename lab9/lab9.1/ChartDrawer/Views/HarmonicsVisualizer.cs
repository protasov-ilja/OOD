using lab9._1.ChartDrawer.Controllers;
using lab9._1.ChartDrawer.Models;
using lab9._1.ChartDrawer.Models.Enums;
using System;
using System.Collections.Generic;

namespace lab9._1.ChartDrawer.Views
{
	public abstract class HarmonicsVisualizer
	{
		protected List<HarmonicData> _harmonicsData = new List<HarmonicData>();

		private IHarmonicsContainer _harmonicsContainer;
		private IHarmonicsVisualizerController _harmonicsVisualizerController;

		public HarmonicsVisualizer(IHarmonicsContainer harmonicsContainer)
		{
			_harmonicsContainer = harmonicsContainer;
			_harmonicsVisualizerController = new HarmonicsVisualizerController(harmonicsContainer);
			_harmonicsContainer.HarmonicAdded += AddHarmonicDataByIndex;
			_harmonicsContainer.HarmonicDeleted += RemoveHarmonicDataByIndex;
		}

		private void AddHarmonicDataByIndex(int index)
		{
			var data = _harmonicsVisualizerController.GetActiveHarmonicData();
			_harmonicsVisualizerController.SubscribeToActiveHarmonicEvents(UpdateHarmonicData);
			_harmonicsData.Add(data);
			UpdateVisualization();
		}

		private void RemoveHarmonicDataByIndex(int index)
		{
			_harmonicsData.RemoveAt(index);
			UpdateVisualization();
		}

		private void UpdateHarmonicData()
		{
			var activeHarmonicIndex = _harmonicsVisualizerController.GetIndexOfActiveHarmonic();
			var data = _harmonicsVisualizerController.GetActiveHarmonicData();
			_harmonicsData[activeHarmonicIndex] = data;
			UpdateVisualization();
		}

		protected abstract void UpdateVisualization();

		protected double GetResultY(float x)
		{
			double result = 0;
			foreach (var harmonic in _harmonicsData)
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

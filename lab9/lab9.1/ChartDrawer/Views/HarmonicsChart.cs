using lab9._1.ChartDrawer.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab9._1.ChartDrawer.Views
{
	public sealed class HarmonicsChart : HarmonicsVisualizer
	{
		private const string ChartName = "ResultChar";
		private const float MinChartBorder = 0;
		private const float MaxChartBorder = 4.5f;
		private const float StepSize = 0.5f;

		private Chart _chart;

		public HarmonicsChart(IHarmonicsContainer harmonicsContainer, Chart chart)
			: base(harmonicsContainer)
		{
			_chart = chart;
			_chart.ChartAreas[0].AxisX.Minimum = MinChartBorder;
			_chart.ChartAreas[0].AxisX.Maximum = MaxChartBorder;
		}

		protected override void UpdateVisualization()
		{
			_chart.Series[ChartName].Points.Clear();
			for (float x = MinChartBorder; x <= MaxChartBorder; x += StepSize)
			{
				_chart.Series[ChartName].Points.AddXY(x, GetResultY(x));
			}
		}
	}
}

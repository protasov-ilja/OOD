using System;

namespace WeatherStationProDuo.WeatherStationProDuo.WeatherData
{
	public sealed class CStatisticalDataOfAngles : CStatisticalData
	{
		private double m_accXValue = 0;
		private double m_accYValue = 0;

		public override double AverageValue
		{
			get
			{
				var averageValue = Math.Atan2((m_accYValue / m_countAcc), (m_accXValue / m_countAcc)) * (180 / Math.PI);

				return (averageValue < 0) ? averageValue + 360 : averageValue;
			}
		}

		protected override void Accumulate(double data)
		{
			m_accXValue += Math.Cos(data * (Math.PI / 180));
			m_accYValue += Math.Sin(data * (Math.PI / 180));
		}
	}
}

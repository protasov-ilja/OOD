using System;

namespace WeatherStationProDuo.WeatherStationProDuo.WeatherData
{
	public sealed class CStatisticalDataOfAngles : IStatisticalData
	{
		private double m_accXValue = 0;
		private double m_accYValue = 0;
		private uint m_countAcc = 0;
		private double m_windSpeed = 0;
		private string m_name;

		public CStatisticalDataOfAngles(string name)
		{
			m_name = name;
		}

		public double AverageValue
		{
			get
			{
				var averageValue = Math.Atan2((m_accYValue / m_countAcc), (m_accXValue / m_countAcc)) * (180 / Math.PI);

				return (averageValue < 0) ? averageValue + 360 : averageValue;
			}
		}

		private void Accumulate(double data)
		{
			m_accXValue += Math.Cos(data * (Math.PI / 180)) * m_windSpeed;
			m_accYValue += Math.Sin(data * (Math.PI / 180)) * m_windSpeed;
		}

		public void Display()
		{
			Console.WriteLine("Average {0} {1} ", m_name, AverageValue);
		}

		public void SetWindSpeed(double windSpeed)
		{
			m_windSpeed = windSpeed;
		}

		public void Update(double data)
		{
			Accumulate(data);
			++m_countAcc;
		}
	}
}

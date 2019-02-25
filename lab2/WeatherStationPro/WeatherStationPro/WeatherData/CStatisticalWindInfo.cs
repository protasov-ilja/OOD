using System;

namespace WeatherStationPro.WeatherStationPro.WeatherData
{
	public sealed class CStatisticalWindInfo
	{
		private double m_minSpeed = double.PositiveInfinity;
		private double m_maxSpeed = double.NegativeInfinity;
		private double m_accSpeed = 0;

		private double m_accXValue = 0;
		private double m_accYValue = 0;
		
		private uint m_countAcc = 0;

		public double MinSpeed
		{
			get
			{
				return m_minSpeed;
			}

			private set
			{
				if (m_minSpeed > value)
				{
					m_minSpeed = value;
				}
			}
		}

		public double MaxSpeed
		{
			get
			{
				return m_maxSpeed;
			}

			private set
			{
				if (m_maxSpeed < value)
				{
					m_maxSpeed = value;
				}
			}
		}

		public double AverageWindSpeed
		{
			get { return (m_accSpeed / m_countAcc); }
		}

		private double AverageWindDirection
		{
			get
			{
				if (IsZeroDirection())
				{
					return -1;
				}

				var averageValue = Math.Atan2((m_accYValue / m_countAcc), (m_accXValue / m_countAcc)) * (180 / Math.PI);

				return (averageValue < 0) ? averageValue + 360 : averageValue;
			}
		}

		private void Accumulate(CWindInfo windInfo)
		{
			m_accSpeed += windInfo.windSpeed;
			m_accXValue += Math.Cos(windInfo.windDirection * (Math.PI / 180)) * windInfo.windSpeed;
			m_accYValue += Math.Sin(windInfo.windDirection * (Math.PI / 180)) * windInfo.windSpeed;
		}

		private bool IsZeroDirection()
		{
			return (Math.Abs(m_accXValue) < 0.01f) && (Math.Abs(m_accYValue) < 0.01f);
		}

		public void Display()
		{
			Console.WriteLine("Max WindSpeed {0} ", MaxSpeed);
			Console.WriteLine("Min WindSpeed {0}", MinSpeed);
			Console.WriteLine("Average WindSpeed {0} ", AverageWindSpeed);
			Console.WriteLine("Average WindDirection {0} ", AverageWindDirection);
		}

		public void Update(CWindInfo windInfo)
		{
			MinSpeed = windInfo.windSpeed;
			MaxSpeed = windInfo.windSpeed;
			Accumulate(windInfo);
			++m_countAcc;
		}
	}
}

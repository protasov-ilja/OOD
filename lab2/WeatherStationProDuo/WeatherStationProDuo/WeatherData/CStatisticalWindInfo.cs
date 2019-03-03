using System;

namespace WeatherStationProDuo.WeatherStationProDuo.WeatherData
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
				if (IsZeroDirection(m_accXValue, m_accYValue))
				{
					return -1;
				}

				var averageValue = Math.Atan2((m_accYValue / m_countAcc), (m_accXValue / m_countAcc)) * (180 / Math.PI);

				return (averageValue < 0) ? averageValue + 360 : averageValue;
			}
		}

		private void Accumulate(CWindInfo windInfo)
		{
			m_accSpeed += windInfo.WindSpeed;
			m_accXValue += Math.Cos(windInfo.WindDirection * (Math.PI / 180)) * windInfo.WindSpeed;
			m_accYValue += Math.Sin(windInfo.WindDirection * (Math.PI / 180)) * windInfo.WindSpeed;
		}

		private bool IsZeroDirection(double x, double y)
		{
			return Math.Abs(x) < 0.01 && Math.Abs(y) < 0.01;
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
			MinSpeed = windInfo.WindSpeed;
			MaxSpeed = windInfo.WindSpeed;
			Accumulate(windInfo);
			++m_countAcc;
		}
	}
}

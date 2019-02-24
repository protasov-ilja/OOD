﻿
namespace WeatherStationPro.WeatherStationPro.WeatherData
{
    public class CStatisticalData
    {
		private double m_minValue = double.PositiveInfinity;
		private double m_maxValue = double.NegativeInfinity;
		private double m_accValue = 0;

		protected uint m_countAcc = 0;

		public double MinValue
		{
			get
			{
				return m_minValue;
			}

			private set
			{
				if (m_minValue > value)
				{
					m_minValue = value;
				}
			}
		}

		public double MaxValue
		{
			get
			{
				return m_maxValue;
			}

			private set
			{
				if (m_maxValue < value)
				{
					m_maxValue = value;
				}
			}
		}

		public virtual double AverageValue
		{
			get { return (m_accValue / m_countAcc); }
		}

		public void Update(double data)
		{
			MinValue = data;
			MaxValue = data;
			Accumulate(data);
			++m_countAcc;
		}

		protected virtual void Accumulate(double data)
		{
			m_accValue += data;
		}
	}
}

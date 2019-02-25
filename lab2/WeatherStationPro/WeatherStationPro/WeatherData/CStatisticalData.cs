
namespace WeatherStationPro.WeatherStationPro.WeatherData
{
    public class CStatisticalData
	{
		private double m_minValue = double.PositiveInfinity;
		private double m_maxValue = double.NegativeInfinity;
		private double m_accValue = 0;
		private uint m_countAcc = 0;
		private string m_name;

		public CStatisticalData(string name)
		{
			m_name = name;
		}

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

		public void Display()
		{
			System.Console.WriteLine("Max {0} {1} ", m_name, MaxValue);
			System.Console.WriteLine("Min {0} {1}", m_name, MinValue);
			System.Console.WriteLine("Average {0} {1} ", m_name, AverageValue);
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

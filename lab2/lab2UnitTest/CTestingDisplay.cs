
using lab2.WeatherStation.Observer;
using lab2.WeatherStation.WeatherData;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab2UnitTest
{
	public class CTestingDisplay : IObserver<SWeatherInfo>
	{
		private static int m_counter;
		private static int m_updateCounter;

		private double m_currCounter;
		private double m_currUpdateCounter;

		private double m_temp;
		private double m_hum;
		private double m_pressure;

		public CTestingDisplay()
		{
			m_currCounter = m_counter;
			m_counter++;
		}

		public static void ResetUpdateCounter()
		{
			m_updateCounter = 0;
		}

		public void SetTestingValues(double temp, double hum, double pressure)
		{
			m_temp = temp;
			m_hum = hum;
			m_pressure = pressure;
		}

		public void CheckUpdateCounter(int value)
		{
			System.Console.WriteLine(m_currUpdateCounter + " : " + value);
			Assert.AreEqual(m_currUpdateCounter, value);
		}

		public void Update(SWeatherInfo data)
		{
			m_currUpdateCounter = m_updateCounter;
			m_updateCounter++;
			Assert.AreEqual(data.temperature, m_temp);
			Assert.AreEqual(data.humidity, m_hum);
			Assert.AreEqual(data.pressure, m_pressure);
		}
	}
}

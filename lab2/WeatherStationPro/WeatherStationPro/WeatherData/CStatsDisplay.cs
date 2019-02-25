using WeatherStationPro.WeatherStationPro.Observer;

namespace WeatherStationPro.WeatherStationPro.WeatherData
{
	public class CStatsDisplay : IObserver<CWeatherInfo>
	{
		private CStatisticalData m_temperature = new CStatisticalData("temperature");
		private CStatisticalData m_humidity =  new CStatisticalData("humidity");
		private CStatisticalData m_pressure = new CStatisticalData("pressure");
		private CStatisticalWindInfo m_windPrameters = new CStatisticalWindInfo();

		public CStatsDisplay()
		{
		}

		public void Update(CWeatherInfo data)
		{
			m_temperature.Update(data.temperature);
			m_humidity.Update(data.humidity);
			m_pressure.Update(data.pressure);
			m_windPrameters.Update(data.windInfo);

			Display();
		}

		public void Display()
		{
			m_temperature.Display();
			m_humidity.Display();
			m_pressure.Display();
			m_windPrameters.Display();

			System.Console.WriteLine("----------------");
		}
	}
}

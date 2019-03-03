using WeatherStationPro.WeatherStationPro.Observer;

namespace WeatherStationPro.WeatherStationPro.WeatherData
{
	public class CStatsDisplay : IObserver<CWeatherInfo>
	{
		private CStatisticalData m_temperature = new CStatisticalData("temperature");
		private CStatisticalData m_humidity =  new CStatisticalData("humidity");
		private CStatisticalData m_pressure = new CStatisticalData("pressure");
		private CStatisticalWindInfo m_windPrameters = new CStatisticalWindInfo();

		public void Update(CWeatherInfo data)
		{
			m_temperature.Update(data.Temperature);
			m_humidity.Update(data.Humidity);
			m_pressure.Update(data.Pressure);
			m_windPrameters.Update(data.WindInfo);

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

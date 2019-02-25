using WeatherStationPro.WeatherStationPro.Observer;

using System.Collections.Generic;

namespace WeatherStationPro.WeatherStationPro.WeatherData
{
	public class CStatsDisplay : IObserver<CWeatherInfo>
	{
		private KeyValuePair<string, IStatisticalData> m_temperature = new KeyValuePair<string, IStatisticalData>("temperature", new CStatisticalData());
		private KeyValuePair<string, IStatisticalData> m_humidity = new KeyValuePair<string, IStatisticalData>("humidity", new CStatisticalData());
		private KeyValuePair<string, IStatisticalData> m_pressure = new KeyValuePair<string, IStatisticalData>("pressure", new CStatisticalData());
		private KeyValuePair<string, IStatisticalData> m_windSpeed = new KeyValuePair<string, IStatisticalData>("windSpeed", new CStatisticalData());
		private KeyValuePair<string, IStatisticalData> m_windDirection = new KeyValuePair<string, IStatisticalData>("windDirection", new CStatisticalDataOfAngles());

		public CStatsDisplay()
		{
		}

		public void Update(CWeatherInfo data)
		{
			m_temperature.Value.Update(data.temperature);
			m_humidity.Value.Update(data.humidity);
			m_pressure.Value.Update(data.pressure);
			m_windSpeed.Value.Update(data.windInfo.windSpeed);
			((CStatisticalDataOfAngles)m_windDirection.Value).SetWindSpeed(data.windInfo.windSpeed);
			m_windDirection.Value.Update(data.windInfo.windDirection);

			Display();
		}

		public void Display()
		{
			DispalyValue(m_temperature);
			DispalyValue(m_humidity);
			DispalyValue(m_pressure);
			DispalyValue(m_windSpeed);
			DispalyValue(m_windDirection);

			System.Console.WriteLine("----------------");
		}

		private void DispalyValue(KeyValuePair<string, IStatisticalData> data)
		{
			data.Value.Display(data.Key);
		}
	}
}

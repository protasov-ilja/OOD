using WeatherStationProDuo.WeatherStationProDuo.Observer;

using System.Collections.Generic;

namespace WeatherStationProDuo.WeatherStationProDuo.WeatherData
{
	public class CStatsDisplay : ObserverDuo<CWeatherInfo>
	{
		private KeyValuePair<string, IStatisticalData> m_temperature = new KeyValuePair<string, IStatisticalData>("temperature", new CStatisticalData());
		private KeyValuePair<string, IStatisticalData> m_humidity = new KeyValuePair<string, IStatisticalData>("humidity", new CStatisticalData());
		private KeyValuePair<string, IStatisticalData> m_pressure = new KeyValuePair<string, IStatisticalData>("pressure", new CStatisticalData());
		private KeyValuePair<string, IStatisticalData> m_windSpeed = new KeyValuePair<string, IStatisticalData>("windSpeed", new CStatisticalData());
		private KeyValuePair<string, IStatisticalData> m_windDirection = new KeyValuePair<string, IStatisticalData>("windDirection", new CStatisticalDataOfAngles());

		public CStatsDisplay(IObservable<CWeatherInfo> insideSubject, IObservable<CWeatherInfo> outsideSubject)
			: base(insideSubject, outsideSubject)
		{
		}

		public override void Update(CWeatherInfo data, IObservable<CWeatherInfo> subject)
		{
			m_temperature.Value.Update(data.temperature);
			m_humidity.Value.Update(data.humidity);
			m_pressure.Value.Update(data.pressure);
			var isLocatedOutside = subject == m_observedSubjectLocatedOutside;
			if (isLocatedOutside)
			{
				m_windSpeed.Value.Update(data.windInfo.windSpeed);
				((CStatisticalDataOfAngles)m_windDirection.Value).SetWindSpeed(data.windInfo.windSpeed);
				m_windDirection.Value.Update(data.windInfo.windDirection);
			}

			Display(subject, isLocatedOutside);
		}

		public void Display(IObservable<CWeatherInfo> subject, bool isLocatedOutside)
		{
			System.Console.WriteLine(GetLocation(subject));
			DispalyValue(m_temperature);
			DispalyValue(m_humidity);
			DispalyValue(m_pressure);
			if (isLocatedOutside)
			{
				DispalyValue(m_windSpeed);
				DispalyValue(m_windDirection);
			}

			System.Console.WriteLine("----------------");
		}

		private void DispalyValue(KeyValuePair<string, IStatisticalData> data)
		{
			data.Value.Display(data.Key);
		}
	}
}

using WeatherStationProDuo.WeatherStationProDuo.Observer;

namespace WeatherStationProDuo.WeatherStationProDuo.WeatherData
{
	public class CStatsDisplay : ObserverDuo<CWeatherInfo>
	{
		private IStatisticalData m_temperature = new CStatisticalData("temperature");
		private IStatisticalData m_humidity = new CStatisticalData("humidity");
		private IStatisticalData m_pressure = new CStatisticalData("pressure");
		private IStatisticalData m_windSpeed = new CStatisticalData("windSpeed");
		private IStatisticalData m_windDirection = new CStatisticalDataOfAngles("windDirection");

		public CStatsDisplay(IObservable<CWeatherInfo> insideSubject, IObservable<CWeatherInfo> outsideSubject)
			: base(insideSubject, outsideSubject)
		{
		}

		public override void Update(CWeatherInfo data, IObservable<CWeatherInfo> subject)
		{
			m_temperature.Update(data.temperature);
			m_humidity.Update(data.humidity);
			m_pressure.Update(data.pressure);
			var isLocatedOutside = subject == m_observedSubjectLocatedOutside;
			if (isLocatedOutside)
			{
				m_windSpeed.Update(data.windInfo.windSpeed);
				((CStatisticalDataOfAngles)m_windDirection).SetWindSpeed(data.windInfo.windSpeed);
				m_windDirection.Update(data.windInfo.windDirection);
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

		private void DispalyValue(IStatisticalData data)
		{
			data.Display();
		}
	}
}

using WeatherStationProDuo.WeatherStationProDuo.Observer;

namespace WeatherStationProDuo.WeatherStationProDuo.WeatherData
{
	public class CStatsDisplay : ObserverDuo<CWeatherInfo>
	{
		private CStatisticalData m_temperature = new CStatisticalData("temperature");
		private CStatisticalData m_humidity = new CStatisticalData("humidity");
		private CStatisticalData m_pressure = new CStatisticalData("pressure");
		private CStatisticalWindInfo m_windPrameters = new CStatisticalWindInfo();

		public CStatsDisplay(IObservable<CWeatherInfo> insideSubject, IObservable<CWeatherInfo> outsideSubject)
			: base(insideSubject, outsideSubject)
		{
		}

		public override void Update(CWeatherInfo data, IObservable<CWeatherInfo> subject)
		{
			m_temperature.Update(data.Temperature);
			m_humidity.Update(data.Humidity);
			m_pressure.Update(data.Pressure);
			var isLocatedOutside = subject == m_observedSubjectLocatedOutside;
			if (isLocatedOutside)
			{
				m_windPrameters.Update(data.WindInfo);
			}

			Display(subject, isLocatedOutside);
		}

		public void Display(IObservable<CWeatherInfo> subject, bool isLocatedOutside)
		{
			System.Console.WriteLine(GetLocation(subject));
			m_temperature.Display();
			m_humidity.Display();
			m_pressure.Display();
			if (isLocatedOutside)
			{
				m_windPrameters.Display();
			}

			System.Console.WriteLine("----------------");
		}
	}
}

﻿using WeatherStationProDuo.WeatherStationProDuo.Observer;

namespace WeatherStationProDuo.WeatherStationProDuo.WeatherData
{
	public class CDisplay : ObserverDuo<CWeatherInfo>
	{
		public CDisplay(IObservable<CWeatherInfo> insideSubject, IObservable<CWeatherInfo> outsideSubject)
			: base(insideSubject, outsideSubject)
		{

		}

		public override void Update(CWeatherInfo data, IObservable<CWeatherInfo> subject)
		{
			System.Console.WriteLine(GetLocation(subject));
			System.Console.WriteLine("Current Temp " + data.temperature);
			System.Console.WriteLine("Current Hum " + data.humidity);
			System.Console.WriteLine("Current Pressure " + data.pressure);
			if (subject == m_observedSubjectLocatedOutside)
			{
				var outsideInfo = data as CWeatherInfoOutside;
				System.Console.WriteLine("Current Wind Speed " + outsideInfo.windSpeed);
				System.Console.WriteLine("Current Wind Direction " + outsideInfo.windDirection);
			}

			System.Console.WriteLine("----------------");
		}
	}
}

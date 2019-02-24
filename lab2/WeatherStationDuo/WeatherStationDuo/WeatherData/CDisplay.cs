using WeatherStationDuo.WeatherStationDuo.Observer;

namespace WeatherStationDuo.WeatherStationDuo.WeatherData
{
	public class CDisplay : ObserverDuo<SWeatherInfo>
	{
		public CDisplay(IObservable<SWeatherInfo> insideSubject, IObservable<SWeatherInfo> outsideSubject)
			: base(insideSubject, outsideSubject)
		{
		}

		public override void Update(SWeatherInfo data, IObservable<SWeatherInfo> subject)
		{
			System.Console.WriteLine(GetLocation(subject));
			System.Console.WriteLine("Current Temp " + data.temperature);
			System.Console.WriteLine("Current Hum " + data.humidity);
			System.Console.WriteLine("Current Pressure " + data.pressure);
			
			System.Console.WriteLine("----------------");
		}
	}
}

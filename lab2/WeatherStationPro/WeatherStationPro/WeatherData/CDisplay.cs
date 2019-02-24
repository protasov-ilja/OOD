using WeatherStationPro.WeatherStationPro.Observer;

namespace WeatherStationPro.WeatherStationPro.WeatherData
{
	public class CDisplay : IObserver<SWeatherInfo>
	{
		public void Update(SWeatherInfo data)
		{
			System.Console.WriteLine("Current Temp " + data.temperature);
			System.Console.WriteLine("Current Hum " + data.humidity);
			System.Console.WriteLine("Current Pressure " + data.pressure);
			System.Console.WriteLine("Current Wind Speed " + data.windSpeed);
			System.Console.WriteLine("Current Wind Direction " + data.windDirection);
			System.Console.WriteLine("----------------");
		}
	}
}

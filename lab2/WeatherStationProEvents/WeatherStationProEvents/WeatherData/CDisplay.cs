using WeatherStationProEvents.WeatherStationProEvents.Observer;

namespace WeatherStationProEvents.WeatherStationProEvents.WeatherData
{
	public class CDisplay : IObserver<CWeatherInfo>
	{
		public void Update(CWeatherInfo data)
		{
			System.Console.WriteLine("Current Temp " + data.temperature);
			System.Console.WriteLine("Current Hum " + data.humidity);
			System.Console.WriteLine("Current Pressure " + data.pressure);
			System.Console.WriteLine("Current Wind Speed " + data.windInfo.windSpeed);
			System.Console.WriteLine("Current Wind Direction " + data.windInfo.windDirection);
			System.Console.WriteLine("----------------");
		}

		public void UpdateTemperature(double temperature)
		{
			System.Console.WriteLine("Current Temp " + temperature + "-----");
		}
	}
}

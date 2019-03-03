using WeatherStationPro.WeatherStationPro.Observer;

namespace WeatherStationPro.WeatherStationPro.WeatherData
{
	public class CDisplay : IObserver<CWeatherInfo>
	{
		public void Update(CWeatherInfo data)
		{
			System.Console.WriteLine("Current Temp " + data.Temperature);
			System.Console.WriteLine("Current Hum " + data.Humidity);
			System.Console.WriteLine("Current Pressure " + data.Pressure);
			System.Console.WriteLine("Current Wind Speed " + data.WindInfo.WindSpeed);
			System.Console.WriteLine("Current Wind Direction " + data.WindInfo.WindDirection);
			System.Console.WriteLine("----------------");
		}
	}
}

using lab2.WeatherStation.Observer;

namespace lab2.WeatherStation.WeatherData
{
	public class CDisplay : IObserver<SWeatherInfo>
	{
		public void Update(SWeatherInfo data)
		{
			System.Console.WriteLine("Current Temp " + data.temperature);
			System.Console.WriteLine("Current Hum " + data.humidity);
			System.Console.WriteLine("Current Pressure " + data.pressure);
			System.Console.WriteLine("----------------");
		}
	}
}

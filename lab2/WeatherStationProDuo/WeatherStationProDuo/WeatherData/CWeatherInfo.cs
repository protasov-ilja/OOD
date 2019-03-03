
namespace WeatherStationProDuo.WeatherStationProDuo.WeatherData
{
    public class CWeatherInfo
    {
		public double Temperature { get; set; }
		public double Humidity { get; set; }
		public double Pressure { get; set; }
		public CWindInfo WindInfo { get; set; } = null;

		public CWeatherInfo(CWindInfo windInfo = null)
		{
			WindInfo = windInfo;
		}
	}
}

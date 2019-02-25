
namespace WeatherStationProDuo.WeatherStationProDuo.WeatherData
{
    public class CWeatherInfo
    {
		public double temperature;
		public double humidity;
		public double pressure;
		public CWindInfo windInfo = null;

		public CWeatherInfo(bool hasWindInfo)
		{
			if (hasWindInfo)
			{
				windInfo = new CWindInfo();
			}
		}
	}
}

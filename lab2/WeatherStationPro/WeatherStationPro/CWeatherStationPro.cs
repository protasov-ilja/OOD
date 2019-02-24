using WeatherStationPro.WeatherStationPro.WeatherData;

namespace WeatherStationPro.WeatherStationPro
{
    public class CWeatherStationPro
    {
		public CWeatherStationPro()
		{
			CWeatherData wd = new CWeatherData();
			CDisplay display = new CDisplay();
			wd.RegisterObserver(display);

			CStatsDisplay statsDisplay = new CStatsDisplay();
			wd.RegisterObserver(statsDisplay);

			wd.SetMeasurements(3, 0.7, 760, 10, 0);
			wd.SetMeasurements(4, 0.8, 761, 8, 630);
		}
    }
}

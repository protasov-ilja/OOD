using WeatherStationProEvents.WeatherStationProEvents.WeatherData;

namespace WeatherStationProEvents.WeatherStationProEvents
{
    public class CWeatherStationProEvents
    {
		public CWeatherStationProEvents()
		{
			CWeatherData wd = new CWeatherData();
			CDisplay display = new CDisplay();
			wd.RegisterObserver(display);
			wd.OnTemperatureChanged += display.UpdateTemperature;
			wd.Temperature = 200;
			CStatsDisplay statsDisplay = new CStatsDisplay();
			wd.RegisterObserver(statsDisplay);

			wd.SetMeasurements(3, 0.7, 760, 10, 0);
			wd.SetMeasurements(4, 0.8, 761, 8, 630);
		}
    }
}

using WeatherStationDuo.WeatherStationDuo.WeatherData;

namespace WeatherStationDuo.WeatherStationDuo
{
    public class CWeatherStationDuo
    {
		public CWeatherStationDuo()
		{
			CWeatherData wdIn = new CWeatherData(LocationType.INSIDE);
			CWeatherData wdOut = new CWeatherData(LocationType.OUTSIDE);
			CDisplay display = new CDisplay(wdIn, wdOut);
			CStatsDisplay statsDisplay = new CStatsDisplay(wdIn, wdOut);

			wdIn.SetMeasurements(3, 0.7, 760);
			wdOut.SetMeasurements(4, 0.8, 761);

			wdIn.RemoveObserver(statsDisplay);
			wdIn.SetMeasurements(5, 0.9, 762);
		}
    }
}

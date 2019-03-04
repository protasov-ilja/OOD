using WeatherStationProDuo.WeatherStationProDuo.WeatherData;

namespace WeatherStationProDuo.WeatherStationProDuo
{
    public class CWeatherStationProDuo
    {
		public CWeatherStationProDuo()
		{
			CWeatherDataInside wdIn = new CWeatherDataInside(LocationType.INSIDE);
			CWeatherDataOutside wdOut = new CWeatherDataOutside(LocationType.OUTSIDE);
			CDisplay display = new CDisplay(wdIn, wdOut);
			CStatsDisplay statsDisplay = new CStatsDisplay(wdIn, wdOut);

			wdIn.SetMeasurements(3, 0.7, 760);
			wdOut.SetMeasurements(4, 0.8, 761, 10, 90);
			wdIn.SetMeasurements(5, 0.9, 762);
		}
    }
}

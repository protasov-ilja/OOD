using WeatherStationDuo.WeatherStationDuo.WeatherData;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab2UnitTest
{
	[TestClass]
	public class WeatherStationDuoTests
	{
		[TestMethod]
		public void Can_create_observer_with_inside_and_outside_observable_subjects()
		{
			CWeatherData wdIn = new CWeatherData(LocationType.INSIDE);
			CWeatherData wdOut = new CWeatherData(LocationType.OUTSIDE);
			WeatherStationDuoTestingDisplay display = new WeatherStationDuoTestingDisplay(wdIn, wdOut);

			display.SetTestingValues(3, 0.7, 760);
			display.SetTestLocationType(LocationType.INSIDE);
			wdIn.SetMeasurements(3, 0.7, 760);
			display.CheckUpdatesCount(1);

			display.SetTestingValues(4, 0.8, 761);
			display.SetTestLocationType(LocationType.OUTSIDE);
			wdOut.SetMeasurements(4, 0.8, 761);
			display.CheckUpdatesCount(2);
		}
	}
}

using lab2.WeatherStation.WeatherData;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab2UnitTest
{
	[TestClass]
	public class PriorityObserversTests
	{
		[TestMethod]
		public void Can_add_observer()
		{
			CTestingDisplay.ResetUpdateCounter();

			CWeatherData wd = new CWeatherData();
			CTestingDisplay display1 = new CTestingDisplay();

			wd.RegisterObserver(display1);

			display1.SetTestingValues(3, 0.7, 760);
			wd.SetMeasurements(3, 0.7, 760);
			display1.CheckUpdateCounter(0);
		}

		[TestMethod]
		public void Can_remove_observer()
		{
			CTestingDisplay.ResetUpdateCounter();

			CWeatherData wd = new CWeatherData();
			CTestingDisplay display1 = new CTestingDisplay();

			wd.RegisterObserver(display1);

			display1.SetTestingValues(3, 0.7, 760);
			wd.SetMeasurements(3, 0.7, 760);
			display1.CheckUpdateCounter(0);

			wd.RemoveObserver(display1);
		}

		[TestMethod]
		public void Cant_remove_not_added_observer()
		{
			CTestingDisplay.ResetUpdateCounter();

			CWeatherData wd = new CWeatherData();
			CTestingDisplay display1 = new CTestingDisplay();

			display1.SetTestingValues(3, 0.7, 760);
			wd.SetMeasurements(3, 0.7, 760);

			wd.RemoveObserver(display1);
		}

		[TestMethod]
		public void When_priority_isnt_set_observers_updates_in_order_of_addition()
		{
			CTestingDisplay.ResetUpdateCounter();

			CWeatherData wd = new CWeatherData();

			CTestingDisplay display1 = new CTestingDisplay();
			CTestingDisplay display2 = new CTestingDisplay();
			CTestingDisplay display3 = new CTestingDisplay();

			wd.RegisterObserver(display1);
			wd.RegisterObserver(display2);
			wd.RegisterObserver(display3);

			display1.SetTestingValues(3, 0.7, 760);
			display2.SetTestingValues(3, 0.7, 760);
			display3.SetTestingValues(3, 0.7, 760);

			wd.SetMeasurements(3, 0.7, 760);

			display1.CheckUpdateCounter(0);
			display2.CheckUpdateCounter(1);
			display3.CheckUpdateCounter(2);
		}

		[TestMethod]
		public void When_priority_is_set_observers_updates_in_order_of_priority()
		{
			CTestingDisplay.ResetUpdateCounter();

			CWeatherData wd = new CWeatherData();

			CTestingDisplay display1 = new CTestingDisplay();
			CTestingDisplay display2 = new CTestingDisplay();
			CTestingDisplay display3 = new CTestingDisplay();

			wd.RegisterObserver(display2, 2);
			wd.RegisterObserver(display1, 1);
			wd.RegisterObserver(display3, 3);

			display1.SetTestingValues(3, 0.7, 760);
			display2.SetTestingValues(3, 0.7, 760);
			display3.SetTestingValues(3, 0.7, 760);

			wd.SetMeasurements(3, 0.7, 760);

			display1.CheckUpdateCounter(0);
			display2.CheckUpdateCounter(1);
			display3.CheckUpdateCounter(2);
		}

		[TestMethod]
		public void When_identical_observers_are_set_next_one_isnt_added()
		{
			CTestingDisplay.ResetUpdateCounter();

			CWeatherData wd = new CWeatherData();
			CTestingDisplay display1 = new CTestingDisplay();

			wd.RegisterObserver(display1, 2);
			wd.RegisterObserver(display1, 1);

			display1.SetTestingValues(3, 0.7, 760);
			wd.SetMeasurements(3, 0.7, 760);
			display1.CheckUpdateCounter(0);
		}
	}
}

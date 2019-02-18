
using lab2.WeatherStation.WeatherData;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab2UnitTest
{
	[TestClass]
	public class RemoveObserverTests
    {
		[TestMethod]
		public void Can_remove_observer_on_update()
		{
			CWeatherData wd = new CWeatherData();
			CTestRemovebleObserver display1 = new CTestRemovebleObserver(wd);

			wd.RegisterObserver(display1);
			wd.SetMeasurements(3, 0.7, 760);

			Assert.IsTrue(display1.IsRemoved);
			display1.IsRemoved = false;
			wd.SetMeasurements(4, 0.8, 761);
			Assert.IsFalse(display1.IsRemoved);
		}
	}
}

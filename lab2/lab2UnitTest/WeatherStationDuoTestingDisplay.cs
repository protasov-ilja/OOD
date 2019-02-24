using WeatherStationDuo.WeatherStationDuo.Observer;
using WeatherStationDuo.WeatherStationDuo.WeatherData;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab2UnitTest
{
	public class WeatherStationDuoTestingDisplay : ObserverDuo<SWeatherInfo>
	{
		private double m_temp;
		private double m_hum;
		private double m_pressure;
		private LocationType m_location;

		private static int m_updatesCount = 0;

		public WeatherStationDuoTestingDisplay(IObservable<SWeatherInfo> insideSubject, IObservable<SWeatherInfo> outsideSubject)
			: base(insideSubject, outsideSubject)
		{
			Assert.IsTrue(m_observedSubjectLocatedInside != null);
			Assert.IsTrue(GetLocation(m_observedSubjectLocatedInside) == LocationType.INSIDE);

			Assert.IsTrue(m_observedSubjectLocatedOutside != null);
			Assert.IsTrue(GetLocation(m_observedSubjectLocatedOutside) == LocationType.OUTSIDE);
		}

		public void SetTestingValues(double temp, double hum, double pressure)
		{
			m_temp = temp;
			m_hum = hum;
			m_pressure = pressure;
		}

		public void SetTestLocationType(LocationType location)
		{
			m_location = location;
		}

		public void CheckUpdatesCount(int count)
		{
			Assert.AreEqual(m_updatesCount, count);
		}

		public override void Update(SWeatherInfo data, IObservable<SWeatherInfo> subject)
		{
			m_updatesCount++;
			Assert.AreEqual(GetLocation(subject), m_location);
			Assert.AreEqual(data.temperature, m_temp);
			Assert.AreEqual(data.humidity, m_hum);
			Assert.AreEqual(data.pressure, m_pressure);
		}
	}
}

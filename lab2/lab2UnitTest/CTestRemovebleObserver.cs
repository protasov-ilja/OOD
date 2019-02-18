
using lab2.WeatherStation.Observer;
using lab2.WeatherStation.WeatherData;

namespace lab2UnitTest
{
	public class CTestRemovebleObserver : IObserver<SWeatherInfo>
	{
		public bool IsRemoved { get; set; }

		private IObservable<SWeatherInfo> m_observableObject;

		public CTestRemovebleObserver(IObservable<SWeatherInfo> observableObject)
		{
			m_observableObject = observableObject;
		}

		public void Update(SWeatherInfo data)
		{
			m_observableObject.RemoveObserver(this);
			IsRemoved = true;
		}
	}
}


using WeatherStationDuo.WeatherStationDuo.Observer;

namespace WeatherStationDuo.WeatherStationDuo.WeatherData
{
    public class CWeatherData : CObservable<SWeatherInfo>
	{
		private double m_temperature = 0.0;
		private double m_humidity = 0.0;
		private double m_pressure = 760.0;
		private LocationType m_location;

		public double Temperature
		{
			get { return m_temperature; }
		}

		public double Pressure
		{
			get { return m_pressure; }
		}

		public double Humidity
		{
			get { return m_humidity; }
		}

		public LocationType Location
		{
			get { return m_location; }
		}

		public CWeatherData(LocationType location)
		{
			m_location = location;
		}

		public void MeasurementsChanged()
		{
			NotifyObservers();
		}

		public void SetMeasurements(double temp, double humidity, double pressure)
		{
			m_humidity = humidity;
			m_temperature = temp;
			m_pressure = pressure;

			MeasurementsChanged();
		}

		protected override SWeatherInfo GetChangedData()
		{
			SWeatherInfo info;
			info.temperature = Temperature;
			info.humidity = Humidity;
			info.pressure = Pressure;

			return info;
		}
	}
}

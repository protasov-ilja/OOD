
using WeatherStationProDuo.WeatherStationProDuo.Observer;

namespace WeatherStationProDuo.WeatherStationProDuo.WeatherData
{
    public class CWeatherDataOutside : CObservable<CWeatherInfo>
	{
		private double m_temperature = 0.0;
		private double m_humidity = 0.0;
		private double m_pressure = 760.0;
		private double m_windSpeed = 0.0;
		private double m_windDirection = 0.0;
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

		public double WindSpeed
		{
			get { return m_windSpeed; }
		}

		public double WindDirection
		{
			get { return m_windDirection; }
		}

		public LocationType Location
		{
			get { return m_location; }
		}

		public CWeatherDataOutside(LocationType location)
		{
			m_location = location;
		}

		public void MeasurementsChanged()
		{
			NotifyObservers();
		}

		public void SetMeasurements(double temp, double humidity, double pressure, double windSpeed, double windDirection)
		{
			m_humidity = humidity;
			m_temperature = temp;
			m_pressure = pressure;
			m_windSpeed = windSpeed;
			m_windDirection = windDirection;

			MeasurementsChanged();
		}

		protected override CWeatherInfo GetChangedData()
		{
			CWeatherInfo info = new CWeatherInfo(true)
			{
				temperature = Temperature,
				humidity = Humidity,
				pressure = Pressure
			};
			info.windInfo.windSpeed = WindSpeed;
			info.windInfo.windDirection = WindDirection;

			return info;
		}
	}
}

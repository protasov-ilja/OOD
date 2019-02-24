
using WeatherStationPro.WeatherStationPro.Observer;

namespace WeatherStationPro.WeatherStationPro.WeatherData
{
    public class CWeatherData : CObservable<SWeatherInfo>
	{
		private double m_temperature = 0.0;
		private double m_humidity = 0.0;
		private double m_pressure = 760.0;
		private double m_windSpeed = 0.0;
		private double m_windDirection = 0.0;

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

		protected override SWeatherInfo GetChangedData()
		{
			SWeatherInfo info;
			info.temperature = Temperature;
			info.humidity = Humidity;
			info.pressure = Pressure;
			info.windSpeed = WindSpeed;
			info.windDirection = WindDirection;

			return info;
		}
	}
}

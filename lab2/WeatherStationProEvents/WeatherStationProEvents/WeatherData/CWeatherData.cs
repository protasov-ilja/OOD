
using System;
using WeatherStationProEvents.WeatherStationProEvents.Observer;

namespace WeatherStationProEvents.WeatherStationProEvents.WeatherData
{
    public class CWeatherData : CObservable<CWeatherInfo>
	{
		private double m_temperature = 0.0;
		private double m_humidity = 0.0;
		private double m_pressure = 760.0;
		private double m_windSpeed = 0.0;
		private double m_windDirection = 0.0;

		public double Temperature
		{
			get { return m_temperature; }
			set
			{
				m_temperature = value;
				OnTemperatureChanged(m_temperature);
			}
		}

		public double Pressure
		{
			get { return m_pressure; }
			set
			{
				m_pressure = value;
				OnPressureChanged(m_pressure);
			}
		}

		public double Humidity
		{
			get { return m_humidity; }
			set
			{
				m_humidity = value;
				OnHumidityChanged(m_humidity);
			}
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

		public Action<double> OnTemperatureChanged;
		public Action<double> OnPressureChanged;
		public Action<double> OnHumidityChanged;

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
			CWeatherInfo info = new CWeatherInfo
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

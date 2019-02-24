using WeatherStationPro.WeatherStationPro.Observer;

using System.Reflection;
using System.Collections.Generic;

namespace WeatherStationPro.WeatherStationPro.WeatherData
{
	public class CStatsDisplay : IObserver<SWeatherInfo>
	{
		private Dictionary<string, CStatisticalData> m_statisticalData = new Dictionary<string, CStatisticalData>();
		private FieldInfo[] m_fieldsInfo;

		public CStatsDisplay()
		{
			m_fieldsInfo = typeof(SWeatherInfo).GetFields();
			for (var i = 0; i < m_fieldsInfo.Length; ++i)
			{
				if (m_fieldsInfo[i].Name == "windDirection")
				{
					m_statisticalData.Add(m_fieldsInfo[i].Name, new CStatisticalDataOfAngles());
				}
				else
				{
					m_statisticalData.Add(m_fieldsInfo[i].Name, new CStatisticalData());
				}
			}
		}

		public void Update(SWeatherInfo data)
		{
			for (var i = 0; i < m_fieldsInfo.Length; ++i)
			{
				m_statisticalData[m_fieldsInfo[i].Name].Update((double)m_fieldsInfo[i].GetValue(data));
			}

			Display();
		}

		public void Display()
		{
			foreach (var data in m_statisticalData)
			{
				System.Console.WriteLine("Max {0} {1} ", data.Key, data.Value.MaxValue);
				System.Console.WriteLine("Min {0} {1}", data.Key, data.Value.MinValue);
				System.Console.WriteLine("Average {0} {1} ", data.Key, data.Value.AverageValue);
			}

			System.Console.WriteLine("----------------");
		}
	}
}

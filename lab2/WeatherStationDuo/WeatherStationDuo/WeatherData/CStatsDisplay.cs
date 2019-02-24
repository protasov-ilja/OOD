using WeatherStationDuo.WeatherStationDuo.Observer;

using System.Reflection;
using System.Collections.Generic;

namespace WeatherStationDuo.WeatherStationDuo.WeatherData
{
	public class CStatsDisplay : ObserverDuo<SWeatherInfo>
	{
		private Dictionary<string, CStatisticalData> m_statisticalData = new Dictionary<string, CStatisticalData>();
		
		private readonly FieldInfo[] m_fieldsInfo;

		public CStatsDisplay(IObservable<SWeatherInfo> insideSubject, IObservable<SWeatherInfo> outsideSubject)
			: base(insideSubject, outsideSubject)
		{ 
			m_fieldsInfo = typeof(SWeatherInfo).GetFields();
			for (var i = 0; i < m_fieldsInfo.Length; ++i)
			{
				m_statisticalData.Add(m_fieldsInfo[i].Name, new CStatisticalData());
			}
		}

		public override void Update(SWeatherInfo data, IObservable<SWeatherInfo> subject)
		{
			for (var i = 0; i < m_fieldsInfo.Length; ++i)
			{
				m_statisticalData[m_fieldsInfo[i].Name].Update((double)m_fieldsInfo[i].GetValue(data));
			}

			Display(subject);
		}

		public void Display(IObservable<SWeatherInfo> subject)
		{
			System.Console.WriteLine(GetLocation(subject));
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

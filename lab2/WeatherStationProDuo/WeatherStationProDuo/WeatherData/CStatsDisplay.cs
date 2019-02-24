using WeatherStationProDuo.WeatherStationProDuo.Observer;

using System.Reflection;
using System.Collections.Generic;

namespace WeatherStationProDuo.WeatherStationProDuo.WeatherData
{
	public class CStatsDisplay : ObserverDuo<CWeatherInfo>
	{
		public CStatsDisplay(IObservable<CWeatherInfo> insideSubject, IObservable<CWeatherInfo> outsideSubject)
			: base(insideSubject, outsideSubject)
		{ 
		}

		public override void Update(CWeatherInfo data, IObservable<CWeatherInfo> subject)
		{
			var fieldsInfo = (subject == m_observedSubjectLocatedInside) ? typeof(CWeatherInfo).GetFields() : typeof(CWeatherInfoOutside).GetFields();
			var statisticalData = GenerateStatisticalData(fieldsInfo);
			for (var i = 0; i < fieldsInfo.Length; ++i)
			{
				statisticalData[fieldsInfo[i].Name].Update((double)fieldsInfo[i].GetValue(data));
			}

			Display(subject, statisticalData);
		}

		private void Display(IObservable<CWeatherInfo> subject, Dictionary<string, CStatisticalData> statisticalData)
		{
			System.Console.WriteLine(GetLocation(subject));
			foreach (var data in statisticalData)
			{
				System.Console.WriteLine("Max {0} {1} ", data.Key, data.Value.MaxValue);
				System.Console.WriteLine("Min {0} {1}", data.Key, data.Value.MinValue);
				System.Console.WriteLine("Average {0} {1} ", data.Key, data.Value.AverageValue);
			}

			System.Console.WriteLine("----------------");
		}

		private Dictionary<string, CStatisticalData> GenerateStatisticalData(FieldInfo[] fieldsInfo)
		{
			var data = new Dictionary<string, CStatisticalData>();
			for (var i = 0; i < fieldsInfo.Length; ++i)
			{
				if (fieldsInfo[i].Name == "windDirection")
				{
					data.Add(fieldsInfo[i].Name, new CStatisticalDataOfAngles());
				}
				else
				{
					data.Add(fieldsInfo[i].Name, new CStatisticalData());
				}
			}

			return data;
		}
	}
}

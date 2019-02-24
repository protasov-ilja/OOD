using WeatherStationProDuo.WeatherStationProDuo.WeatherData;

namespace WeatherStationProDuo.WeatherStationProDuo.Observer
{
	public abstract class ObserverDuo<T> : IObserver<T>
	{
		protected IObservable<T> m_observedSubjectLocatedInside;
		protected IObservable<T> m_observedSubjectLocatedOutside;

		public ObserverDuo(IObservable<T> insideSubject, IObservable<T> outsideSubject)
		{
			m_observedSubjectLocatedInside = insideSubject;
			m_observedSubjectLocatedInside.RegisterObserver(this);
			m_observedSubjectLocatedOutside = outsideSubject;
			m_observedSubjectLocatedOutside.RegisterObserver(this);
		}

		public abstract void Update(T data, IObservable<T> subject);

		protected LocationType GetLocation(IObservable<T> subject)
		{
			if (subject == m_observedSubjectLocatedInside)
			{
				return LocationType.INSIDE;
			}
			else if (subject == m_observedSubjectLocatedOutside)
			{
				return LocationType.OUTSIDE;
			}

			return LocationType.OTHER;
		}
	}
}

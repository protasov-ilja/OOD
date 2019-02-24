using System.Collections.Generic;

namespace WeatherStationDuo.WeatherStationDuo.Observer
{
    public abstract class CObservable<T> : IObservable<T>
	{
		private SortedSet<PriorityObserver<T>> m_observers = new SortedSet<PriorityObserver<T>>(new PriorityObserverComparer<T>());

		public void RegisterObserver(IObserver<T> observer, int priority = 0)
		{
			m_observers.Add(new PriorityObserver<T>(observer, priority));
		}

		public void NotifyObservers()
		{
			T data = GetChangedData();
			foreach (var observer in m_observers)
			{
				observer.Observer.Update(data, this);
			}
		}

		public void RemoveObserver(IObserver<T> observer) 
		{
			PriorityObserver<T> obs = null;
			foreach (var observerPair in m_observers)
			{
				if (observerPair.Observer == observer)
				{
					obs = observerPair;
					break;
				}
			}

			if (obs != null)
			{
				m_observers.Remove(obs);
			}
		}

		protected abstract T GetChangedData();
	}
}

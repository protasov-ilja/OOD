using System.Collections.Generic;

namespace WeatherStationPro.WeatherStationPro.Observer
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
			var tempObesrevers = new List<PriorityObserver<T>>(m_observers);
			T data = GetChangedData();
			foreach (var observer in tempObesrevers)
			{
				observer.Observer.Update(data);
			}
		}

		public void RemoveObserver(IObserver<T> observer) 
		{
			foreach (var observerPair in m_observers)
			{
				if (observerPair.Observer == observer)
				{
					m_observers.Remove(observerPair);
					break;
				}
			}
		}

		protected abstract T GetChangedData();
	}
}

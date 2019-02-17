using System.Collections.Generic;

namespace lab2.WeatherStation.Observer
{
    public class PriorityObserver<T>
	{
		private int m_priority;
		private IObserver<T> m_observer;

		public int Priority
		{
			get { return m_priority; }
		}

		public IObserver<T> Observer
		{
			get { return m_observer; }
		}

		public PriorityObserver(IObserver<T> observer, int priority = 0)
		{
			m_observer = observer;
			m_priority = priority;
		}
	}

	public class PriorityObserverComparer<T> : IComparer<PriorityObserver<T>>
	{
		public int Compare(PriorityObserver<T> x, PriorityObserver<T> y)
		{
			if (x.Observer != y.Observer)
			{
				if (x.Priority > y.Priority)
				{
					return 1;
				}
				else if (x.Priority < y.Priority)
				{
					return -1;
				}
				else if (x.Priority == y.Priority)
				{
					return 1;
				}
			}

			return 0;
		}
	}
}

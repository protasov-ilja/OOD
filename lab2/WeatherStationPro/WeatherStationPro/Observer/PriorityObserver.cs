using System.Collections.Generic;

namespace WeatherStationPro.WeatherStationPro.Observer
{
    public class PriorityObserver<T>
	{
		public int Priority { get; private set; }
		public IObserver<T> Observer { get; private set; }

		public PriorityObserver(IObserver<T> observer, int priority = 0)
		{
			Observer = observer;
			Priority = priority;
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

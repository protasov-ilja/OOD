﻿
namespace lab2.WeatherStation.Observer
{
    public interface IObservable<T>
    {
		void RegisterObserver(IObserver<T> observer, int priority = 0);

		void RemoveObserver(IObserver<T> observer);

		void NotifyObservers();
	}
}

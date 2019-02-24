
namespace WeatherStationProDuo.WeatherStationProDuo.Observer
{
    public interface IObserver<T>
    {
		void Update(T data, IObservable<T> subject);
    }
}

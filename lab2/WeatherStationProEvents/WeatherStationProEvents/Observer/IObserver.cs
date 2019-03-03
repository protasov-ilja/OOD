
namespace WeatherStationProEvents.WeatherStationProEvents.Observer
{
    public interface IObserver<T>
    {
		void Update(T data);
    }
}


namespace WeatherStationPro.WeatherStationPro.Observer
{
    public interface IObserver<T>
    {
		void Update(T data);
    }
}


namespace lab2.WeatherStation.Observer
{
    public interface IObserver<T>
    {
		void Update(T data);
    }
}

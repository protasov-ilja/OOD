namespace task2.Utils
{
	public interface IQuartersController
	{
		uint GetQuartersCount();
		bool HasQuarters();
		void InsertQuarter();
		void EjectQuarters();
		void UseQuarter();
	}
}

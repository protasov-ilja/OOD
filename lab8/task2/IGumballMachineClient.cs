namespace task2
{
	public interface IGumballMachine
	{
		void EjectQuarters();
		void InsertQuarter();
		void TurnCrank();
		void Refill(uint numBalls);
	}
}

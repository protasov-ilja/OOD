namespace task2
{
	public interface IGumballMachineClient
	{
		void EjectQuarters();
		void InsertQuarter();
		void TurnCrank();
		void Refill(uint numBalls);
	}
}

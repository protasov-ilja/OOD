namespace task2.GumballMachineWithState.States
{
	public interface IState
	{
		void InsertQuarter();
		void EjectQuarters();
		void TurnCrank();
		void Dispense();
		void Refill(uint ballsCount);
	}
}

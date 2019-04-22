namespace task1.GumballMachineWithState
{
	public interface IGumballMachine
	{
		void ReleaseBall();
		uint GetBallCount();
		void SetSoldOutState();
		void SetNoQuarterState();
		void SetSoldState();
		void SetHasQuarterState();

		void EjectQuarter();
		void InsertQuarter();
		void TurnCrank();
	}
}

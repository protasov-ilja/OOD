namespace task1.GumballMachineWithState
{
	public interface IGumballMachineContext
	{
		void EjectQuarter();
		void InsertQuarter();
		void TurnCrank();

		void ReleaseBall();
		uint GetBallCount();

		void SetSoldOutState();
		void SetNoQuarterState();
		void SetSoldState();
		void SetHasQuarterState();
	}
}

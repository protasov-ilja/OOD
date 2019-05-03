using task2.Utils;

namespace task2.GumballMachineWithState
{
	public interface IGumballMachine
	{
		void ReleaseBall();
		uint GetBallCount();
		void AddBalls(uint count);
		IQuartersController GetQuartersController();

		void SetSoldOutState();
		void SetNoQuarterState();
		void SetSoldState();
		void SetHasQuarterState();
	}
}

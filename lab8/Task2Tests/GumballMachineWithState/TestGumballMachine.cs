using task2.GumballMachineWithState;
using task2.Utils;

namespace Task2Tests.GumballMachineWithState
{
	public class TestGumballMachine : IGumballMachine
	{
		public bool NoQuarterState { get; private set; } = false;
		public bool HasQuarterState { get; private set; } = false;
		public bool SoldOutState { get; private set; } = false;
		public bool SoldState { get; private set; } = false;

		private IQuartersController _quarterController = new QuartersController(5);

		public uint BallsCount { get; set; }

		public void AddBalls(uint count)
		{
			BallsCount += count;
		}

		public uint GetBallCount()
		{
			return BallsCount;
		}

		public uint GetQuartersCount()
		{
			return _quarterController.GetQuartersCount();
		}

		public void ReleaseBall()
		{
			BallsCount--;
		}

		public void SetHasQuarterState()
		{
			HasQuarterState = true;
		}

		public void SetNoQuarterState()
		{
			NoQuarterState = true;
		}

		public void SetSoldOutState()
		{
			SoldOutState = true;
		}

		public void SetSoldState()
		{
			SoldState = true;
		}

		public IQuartersController GetQuartersController()
		{
			return _quarterController;
		}
	}
}

using task2.GumballMachineNaive.Enums;
using task2.GumballMachineWithState;
using task2.Utils;

namespace Task2Tests.GumballMachineWithState
{
	public class TestGumballMachine : IGumballMachineContext
	{
		public State State { get; private set; }

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
			State = State.HasQuarter;
		}

		public void SetNoQuarterState()
		{
			State = State.NoQuarter;
		}

		public void SetSoldOutState()
		{
			State = State.SoldOut;
		}

		public void SetSoldState()
		{
			State = State.Sold;
		}

		public IQuartersController GetQuartersController()
		{
			return _quarterController;
		}

		public void EjectQuarters()
		{
			throw new System.NotImplementedException();
		}

		public void InsertQuarter()
		{
			throw new System.NotImplementedException();
		}

		public void TurnCrank()
		{
			throw new System.NotImplementedException();
		}

		public void Refill(uint numBalls)
		{
			throw new System.NotImplementedException();
		}
	}
}

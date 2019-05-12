using task1.GumballMachineWithState;
using task1Tests.GumballMachineWithState.Enums;

namespace task1Tests.GumballMachineWithState
{ 
	public class TestGumballMachine : IGumballMachineContext
	{
		public TestState State { get; private set; }

		public uint BallsCount { get; set; }

		public void EjectQuarter()
		{
			throw new System.NotImplementedException();
		}

		public uint GetBallCount()
		{
			return BallsCount;
		}

		public void InsertQuarter()
		{
			throw new System.NotImplementedException();
		}

		public void ReleaseBall()
		{
			BallsCount--;
		}

		public void SetHasQuarterState()
		{
			State = TestState.HasQuarter;
		}

		public void SetNoQuarterState()
		{
			State = TestState.NoQuarter;
		}

		public void SetSoldOutState()
		{
			State = TestState.SoldOut;
		}

		public void SetSoldState()
		{
			State = TestState.Sold;
		}

		public void TurnCrank()
		{
			throw new System.NotImplementedException();
		}
	}
}

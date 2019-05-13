using task1.GumballMachineWithState;
using task1Tests.GumballMachineWithState.Enums;

namespace task1Tests.GumballMachineWithState
{ 
	public class TestGumballMachine : IGumballMachineContext
	{
		public State State { get; private set; }

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
			State = State.HasQuarter;
		}

		public void SetNoQuarterState()
		{
			State = State.NoQuarter;
		}

		public void SetSoldOutState()
		{
			State = Enums.State.SoldOut;
		}

		public void SetSoldState()
		{
			State = Enums.State.Sold;
		}

		public void TurnCrank()
		{
			throw new System.NotImplementedException();
		}
	}
}

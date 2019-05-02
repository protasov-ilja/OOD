using System;
using task1.GumballMachineWithState;

namespace task1Tests.GumballMachineWithState
{ 
	public class TestGumballMachine : IGumballMachine
	{
		public bool NoQuarterState { get; private set; } = false;
		public bool HasQuarterState { get; private set; } = false;
		public bool SoldOutState { get; private set; } = false;
		public bool SoldState { get; private set; } = false;

		public uint BallsCount { get; set; }

		public uint GetBallCount()
		{
			return BallsCount;
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
	}
}

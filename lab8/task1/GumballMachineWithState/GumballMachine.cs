﻿namespace task1.GumballMachineWithState
{
	public sealed class GumballMachine : IGumballMachine
	{
		private readonly IGumballMachineContext _gumballMachineContext;

		public GumballMachine(uint numBalls = 0)
		{
			_gumballMachineContext = new GumballMachineContext(numBalls);
		}

		public void EjectQuarter()
		{
			_gumballMachineContext.EjectQuarter();
		}

		public void InsertQuarter()
		{
			_gumballMachineContext.InsertQuarter();
		}

		public void TurnCrank()
		{
			_gumballMachineContext.TurnCrank();
		}
	}
}

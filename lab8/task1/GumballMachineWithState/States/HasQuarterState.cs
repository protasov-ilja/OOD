using System;

namespace task1.GumballMachineWithState.States
{
	public sealed class HasQuarterState : IState
	{
		private IGumballMachine _gumballMachine;

		public HasQuarterState(IGumballMachine gumballMachine)
		{
			_gumballMachine = gumballMachine;
		}

		public void Dispense()
		{
			Console.WriteLine("No gumball dispensed");
		}

		public void EjectQuarter()
		{
			Console.WriteLine("Quarter returned");
			_gumballMachine.SetNoQuarterState();
		}

		public void InsertQuarter()
		{
			Console.WriteLine("You can't insert another quarter");
		}

		public void TurnCrank()
		{
			Console.WriteLine("You turned...");
			_gumballMachine.SetSoldState();
		}

		public override string ToString()
		{
			return "waiting for turn of crank";
		}
}
}

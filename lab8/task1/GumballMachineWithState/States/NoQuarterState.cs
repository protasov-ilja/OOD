using System;

namespace task1.GumballMachineWithState.States
{
	public sealed class NoQuarterState : IState
	{
		private readonly IGumballMachineContext _gumballMachine;

		public NoQuarterState(IGumballMachineContext gumballMachine)
		{
			_gumballMachine = gumballMachine;
		}

		public void Dispense()
		{
			Console.WriteLine("You need to pay first");
		}

		public void EjectQuarter()
		{
			Console.WriteLine("You haven't inserted a quarter");
		}

		public void InsertQuarter()
		{
			Console.WriteLine("You inserted a quarter");
			_gumballMachine.SetHasQuarterState();
		}

		public void TurnCrank()
		{
			Console.WriteLine("You turned but there's no quarter");
		}

		public override string ToString()
		{
			return "waiting for quarter";
		}
	}
}

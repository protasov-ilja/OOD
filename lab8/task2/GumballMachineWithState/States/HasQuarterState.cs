using System;

namespace task2.GumballMachineWithState.States
{
	public sealed class HasQuarterState : IState
	{
		private readonly IGumballMachineContext _gumballMachine;

		public HasQuarterState(IGumballMachineContext gumballMachine)
		{
			_gumballMachine = gumballMachine;
		}

		public void Dispense()
		{
			Console.WriteLine("No gumball dispensed");
		}

		public void EjectQuarters()
		{
			_gumballMachine.GetQuartersController().EjectQuarters();
			Console.WriteLine("Quarter returned");
			_gumballMachine.SetNoQuarterState();
		}

		public void InsertQuarter()
		{
			try
			{
				_gumballMachine.GetQuartersController().InsertQuarter();
				Console.WriteLine("You insert another quarter");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
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

		public void Refill(uint ballsCount)
		{
			_gumballMachine.AddBalls(ballsCount);
		}
	}
}

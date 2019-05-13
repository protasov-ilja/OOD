using System;

namespace task2.GumballMachineWithState.States
{
	public sealed class SoldOutState : IState
	{
		private readonly IGumballMachineContext _gumballMachine;

		public SoldOutState(IGumballMachineContext gumballMachine)
		{
			_gumballMachine = gumballMachine;
		}

		public void Dispense()
		{
			Console.WriteLine("No gumball dispensed");
		}

		public void EjectQuarters()
		{
			Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
		}

		public void InsertQuarter()
		{
			Console.WriteLine("You can't insert a quarter, the machine is sold out");
		}

		public void TurnCrank()
		{
			Console.WriteLine("You turned but there's no gumballs");
		}

		public override string ToString()
		{
			return "sold out";
		}

		public void Refill(uint ballsCount)
		{
			_gumballMachine.AddBalls(ballsCount);
			if (_gumballMachine.GetBallCount() > 0)
			{
				_gumballMachine.SetNoQuarterState();
			}	
		}
	}
}

using System;

namespace task2.GumballMachineWithState.States
{
	public sealed class SoldState : IState
	{
		private readonly IGumballMachineContext _gumballMachine;

		public SoldState(IGumballMachineContext gumballMachine)
		{
			_gumballMachine = gumballMachine;
		}

		public void Dispense()
		{
			_gumballMachine.ReleaseBall();
			_gumballMachine.GetQuartersController().UseQuarter();
			if (_gumballMachine.GetBallCount() == 0)
			{
				Console.WriteLine("Oops, out of gumballs");
				if (_gumballMachine.GetQuartersController().HasQuarters())
				{
					Console.WriteLine("returning unused quarters");
					_gumballMachine.GetQuartersController().EjectQuarters();
				}

				_gumballMachine.SetSoldOutState();
			}
			else
			{
				if (_gumballMachine.GetQuartersController().HasQuarters())
				{
					_gumballMachine.SetHasQuarterState();
				}
				else
				{
					_gumballMachine.SetNoQuarterState();
				}
			}
		}

		public void EjectQuarters()
		{
			Console.WriteLine("Sorry you already turned the crank");
		}

		public void InsertQuarter()
		{
			Console.WriteLine("Please wait, we're already giving you a gumball");
		}

		public void TurnCrank()
		{
			Console.WriteLine("Turning twice doesn't get you another gumball");
		}

		public override string ToString()
		{
			return "delivering a gumball";
		}

		public void Refill(uint ballsCount)
		{
			Console.WriteLine("Can't Refill Gumballs in sold state");
		}
	}
}

using System;
using task2.GumballMachineNaive.Enums;
using task2.Utils;

namespace task2.GumballMachineNaive
{
	public sealed class GumballMachine : IGumballMachine
	{
		private const uint MaxQuartersLimit = 5;

		private uint _count; 
		private State _state = State.SoldOut;
		private IQuartersController _quartersController;

		public GumballMachine(uint count = 0)
		{
			_quartersController = new QuartersController(MaxQuartersLimit);
			_state = (count > 0 ? State.NoQuarter : State.SoldOut);
			_count = count;
		}

		public uint GetBallCount()
		{
			return _count;
		}

		public uint GetQuartersCount()
		{
			return _quartersController.GetQuartersCount();
		}

		public void InsertQuarter()
		{
			try
			{
				switch (_state)
				{
					case State.SoldOut:
						Console.WriteLine("You can't insert a quarter, the machine is sold out");
						break;
					case State.NoQuarter:
						_quartersController.InsertQuarter();
						Console.WriteLine("You inserted a quarter");
						_state = State.HasQuarter;
						break;
					case State.HasQuarter:
						_quartersController.InsertQuarter();
						Console.WriteLine("You inserted a new quarter");
						break;
					case State.Sold:
						Console.WriteLine("Please wait, we're already giving you a gumball");
						break;
				}
			}
			catch (ArgumentOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void EjectQuarters()
		{
			switch (_state)
			{
				case State.HasQuarter:
					Console.WriteLine("Quarter returned");
					_quartersController.EjectQuarters();
					_state = State.NoQuarter;
					break;
				case State.NoQuarter:
					Console.WriteLine("You haven't inserted a quarter");
					break;
				case State.Sold:
					Console.WriteLine("Sorry you already turned the crank");
					break;
				case State.SoldOut:
					Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
					break;
			}
		}

		public void TurnCrank()
		{
			switch (_state)
			{
				case State.SoldOut:
					Console.WriteLine("You turned but there's no gumballs");
					break;
				case State.NoQuarter:
					Console.WriteLine("You turned but there's no quarter");
					break;
				case State.HasQuarter:
					Console.WriteLine("You turned...");
					_state = State.Sold;
					Dispense();
					break;
				case State.Sold:
					Console.WriteLine("Turning twice doesn't get you another gumball");
					break;
			}
		}

		public void Refill(uint numBalls)
		{
			_count += numBalls;
			switch (_state)
			{
				case State.SoldOut:
					if (numBalls > 0)
					{
						_state = State.NoQuarter;
					}

					break;
			}
		}

		public override string ToString()
		{
			string state =
				(_state == State.SoldOut) ? "sold out" :
				(_state == State.NoQuarter) ? "waiting for quarter" :
				(_state == State.HasQuarter) ? "waiting for turn of crank"
											   : "delivering a gumball";
			var fmt = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 Inventory: { _count } gumball{ (_count != 1 ? "s" : "") } Machine is { state })";
			return fmt;
		}

		public void Dispense()
		{
			switch (_state)
			{
				case State.Sold:
					Console.WriteLine("A gumball comes rolling out the slot");
					--_count;
					_quartersController.UseQuarter();
					if (_count == 0)
					{
						Console.WriteLine("Oops, out of gumballs");
						if (_quartersController.HasQuarters())
						{
							_quartersController.EjectQuarters();
							Console.WriteLine("returning unused quarters");
						}
						
						_state = State.SoldOut;
					}
					else
					{
						_state = _quartersController.HasQuarters() ? State.HasQuarter : State.NoQuarter;
					}

					break;
				case State.NoQuarter:
					Console.WriteLine("You need to pay first");
					break;
				case State.SoldOut:
				case State.HasQuarter:
					Console.WriteLine("No gumball dispensed");
					break;
			}
		}
	}
}

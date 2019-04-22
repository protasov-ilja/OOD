using System;
namespace task2.GumballMachineNaive
{
	public class GumballMachine
	{
		private uint m_count;   // Количество шариков
		private State m_state = State.SoldOut;

		public enum State
		{
			SoldOut,		// Жвачка закончилась
			NoQuarter,		// Нет монетки
			HasQuarter,		// Есть монетка
			Sold,			// Монетка выдана
		};

		public GumballMachine(uint count)
		{
			m_state = (count > 0 ? State.NoQuarter : State.SoldOut);
			m_count = count;
		}

		void InsertQuarter()
		{
			switch (m_state)
			{
				case State.SoldOut:
					Console.WriteLine("You can't insert a quarter, the machine is sold out");
					break;
				case State.NoQuarter:
					Console.WriteLine("You inserted a quarter");
					m_state = State.HasQuarter;
					break;
				case State.HasQuarter:
					Console.WriteLine("You can't insert another quarter");
					break;
				case State.Sold:
					Console.WriteLine("Please wait, we're already giving you a gumball");
					break;
			}
		}

		void EjectQuarter()
		{
			switch (m_state)
			{
			case State.HasQuarter:
				Console.WriteLine("Quarter returned");
				m_state = State.NoQuarter;
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
			switch (m_state)
			{
			case State.SoldOut:
				Console.WriteLine("You turned but there's no gumballs");
				break;
			case State.NoQuarter:
				Console.WriteLine("You turned but there's no quarter");
				break;
			case State.HasQuarter:
				Console.WriteLine("You turned...");
				m_state = State.Sold;
				Dispense();
				break;
			case State.Sold:
				Console.WriteLine("Turning twice doesn't get you another gumball");
				break;
			}
		}

		public void Refill(uint numBalls)
		{
			m_count = numBalls;
			m_state = numBalls > 0 ? State.NoQuarter : State.SoldOut;
		}

		public override string ToString()
		{
			string state =
				(m_state == State.SoldOut) ? "sold out" :
				(m_state == State.NoQuarter) ? "waiting for quarter" :
				(m_state == State.HasQuarter) ? "waiting for turn of crank"
											   : "delivering a gumball";
			var fmt = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 Inventory: { m_count } gumball{ (m_count != 1 ? "s" : "") } Machine is { state })";
			return fmt;
		}

		void Dispense()
		{
			switch (m_state)
			{
			case State.Sold:
				Console.WriteLine("A gumball comes rolling out the slot");
				--m_count;
				if (m_count == 0)
				{
					Console.WriteLine("Oops, out of gumballs");
					m_state = State.SoldOut;
				}
				else
				{
					m_state = State.NoQuarter;
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

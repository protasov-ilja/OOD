using System;
using task1.GumballMachineWithState;

namespace task1
{
    class Program
    {
		static void TestGumballMachineWithState()
		{
			IGumballMachineClient m = new GumballMachine(5);
			TestGumballMachine(m);
		}

		static void Main(string[] args)
        {
			TestGumballMachineWithState();
		}

		static void TestGumballMachine(IGumballMachineClient m)
		{
			Console.WriteLine(m.ToString());

			m.InsertQuarter();
			m.TurnCrank();

			Console.WriteLine(m.ToString());

			m.InsertQuarter();
			m.EjectQuarter();
			m.TurnCrank();

			Console.WriteLine(m.ToString());

			m.InsertQuarter();
			m.TurnCrank();
			m.InsertQuarter();
			m.TurnCrank();
			m.EjectQuarter();

			Console.WriteLine(m.ToString());

			m.InsertQuarter();
			m.InsertQuarter();
			m.TurnCrank();
			m.InsertQuarter();
			m.TurnCrank();
			m.InsertQuarter();
			m.TurnCrank();

			Console.WriteLine(m.ToString());
		}
	}
}

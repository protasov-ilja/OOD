using System;
using task2.Menu;
using GumballMachineNaiv = task2.GumballMachineNaive.GumballMachine;
using GumballMachineWithStates = task2.GumballMachineWithState.GumballMachine;

namespace task2
{
	class Program
	{
		static void Main(string[] args)
		{
			TestGumballMachineWithState();
			//TestGumballMachineNaive();
		}

		static void TestGumballMachineWithState()
		{
			var m = new GumballMachineWithStates(5);
			Client client = new Client();
			client.Run(Console.In, Console.Out, m);
		}

		static void TestGumballMachineNaive()
		{
			var m = new GumballMachineNaiv(5);
			Client client = new Client();
			client.Run(Console.In, Console.Out, m);
		}
	}
}

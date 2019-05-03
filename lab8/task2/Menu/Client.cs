using System.IO;
using task2.GumballMachineNaive;

namespace task2.Menu
{
	public sealed class Client
	{
		private const string HelpCommand = "help";
		private const string ExitCommand = "exit";
		private const string InsertCoinCommand = "insert";
		private const string EjectCoinsCommand = "eject";
		private const string RefillCommand = "refill";
		private const string TurnCrankCommand = "turn";

		private Menu _menu = new Menu();
		private IGumballMachineClient _gumballMachine;
		private TextWriter _out;

		public Client()
		{
			_menu.AddItem(InsertCoinCommand, "insert coin", InsertCoin);
			_menu.AddItem(EjectCoinsCommand, "eject all coins", EjectCoins);
			_menu.AddItem(RefillCommand, "refill gumball machine <amount>", Refill);
			_menu.AddItem(TurnCrankCommand, "turning crank", TurnCrank);
			_menu.AddItem(HelpCommand, "show help", ShowHelp);
			_menu.AddItem(ExitCommand, "exit programm", Exit);
		}

		public void Run(TextReader inputData, TextWriter outputData, IGumballMachineClient machine)
		{
			_gumballMachine = machine;
			_out = outputData;
			_menu.Run(inputData);
		}

		private void Exit(IInputHandler argsHandler)
		{
			_menu.Exit();
		}

		private void InsertCoin(IInputHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft != 0)
			{
				_out.WriteLine($"Not Enougth arguments {argsHandler.ArgumentsLeft}");
				return;
			}

			_gumballMachine.InsertQuarter();
		}

		private void EjectCoins(IInputHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft != 0)
			{
				_out.WriteLine($"Not Enougth arguments {argsHandler.ArgumentsLeft}");
				return;
			}

			_gumballMachine.EjectQuarters();
		}

		private void Refill(IInputHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft != 1)
			{
				_out.WriteLine($"Not Enougth arguments {argsHandler.ArgumentsLeft}");
				return;
			}

			_gumballMachine.Refill((uint)argsHandler.GetNextIntArg());
		}

		private void TurnCrank(IInputHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft != 0)
			{
				_out.WriteLine($"Not Enougth arguments {argsHandler.ArgumentsLeft}");
				return;
			}

			_gumballMachine.TurnCrank();
		}

		private void ShowHelp(IInputHandler argsHandler)
		{
			_menu.ShowInstructions();
		}
	}
}

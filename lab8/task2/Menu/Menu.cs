using System;
using System.Collections.Generic;
using System.IO;

namespace task2.Menu
{
	public sealed class Menu
	{
		private class Item
		{
			public string Shortcut { get; private set; }
			public string Description { get; private set; }
			public Action<IInputHandler> Command { get; private set; }

			public Item(string shortcut, string description, Action<IInputHandler> command)
			{
				Shortcut = shortcut;
				Description = description;
				Command = command;
			}
		};

		private List<Item> _items = new List<Item>();
		private bool _exit = false;

		public void AddItem(string shortcut, string description, Action<IInputHandler> command)
		{
			_items.Add(new Item(shortcut, description, command));
		}

		public void Run(TextReader inputData)
		{
			ShowInstructions();
			while (!_exit)
			{
				Console.Write("> ");
				var command = inputData.ReadLine().ToLower();
				if (!ExecuteCommand(command))
				{
					return;
				}
			}
		}

		public void ShowInstructions()
		{
			Console.WriteLine("Commands list:");
			foreach (var item in _items)
			{
				Console.WriteLine($"-- {item.Shortcut}: {item.Description}");
			}
		}

		public void Exit()
		{
			_exit = true;
		}

		private bool ExecuteCommand(string command)
		{
			_exit = false;
			var argsHandler = new ArgumentsHandler(command);
			Item it = FindItemByShortcut(argsHandler.GetNextStringArg());
			if (it != null)
			{
				it.Command(argsHandler);
			}
			else
			{
				Console.WriteLine("Unknown command");
			}

			return !_exit;
		}

		private Item FindItemByShortcut(string shortcut)
		{
			foreach (var item in _items)
			{
				if (item.Shortcut == shortcut)
				{
					return item;
				}
			}

			return null;
		}
	}
}

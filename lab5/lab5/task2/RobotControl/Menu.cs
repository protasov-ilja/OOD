using System;

namespace task2.RobotControl
{
    class Menu
    {
		//public void AddItem(string shortcut, string description, ICommand command)
		//{
		//	m_items.emplace_back(shortcut, description, command);
		//}

		//public void Run()
		//{
		//	ShowInstructions();

		//	string command;
		//	while ((std::cout << ">") && getline(std::cin, command) && ExecuteCommand(command))
		//	{
		//	}
		//}

		//public void ShowInstructions()
		//{
		//	Console.WriteLine("Commands list:");
		//	foreach (var item in m_items)
		//	{
		//		Console.WriteLine($"  {item.shortcut}: {item.description}");
		//	}
		//}

		//public void Exit()
		//{
		//	m_exit = true;
		//}

		//private bool ExecuteCommand(string command)
		//{
		//	m_exit = false;

		//	auto it = boost::find_if(m_items, [&](Item item) {
		//		return item.shortcut == command;
		//	});

		//	if (it != m_items.end())
		//	{
		//		it.command.Execute();
		//	}
		//	else
		//	{
		//		Console.WriteLine("Unknown command");
		//	}

		//	return !m_exit;
		//}

		//private struct Item
		//{
		//	Item(string shortcut, string description, ICommand command)
		//	{
		//		this.shortcut = shortcut;
		//		this.description = description;
		//		this.command = command;
		//	}

		//	string shortcut;
		//	string description;
		//	ICommand command;
		//};

		//private std::vector<Item> m_items;
		//private bool m_exit = false;
    }
}

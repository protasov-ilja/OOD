using System.Collections.Generic;

namespace task1.DocumentEditor.Commands
{
	public class History : IExecutor
	{
		private const int MAX_COMMANDS_STACK_SIZE = 10;

		private List<ICommand> _commands;
		private int _nextActionIndex = 0;

		public History()
		{
			_commands = new List<ICommand>();
		}

		public bool CanUndo()
		{
			return _nextActionIndex > 0;
		}

		public bool CanRedo()
		{
			return _nextActionIndex != _commands.Count;
		}

		public void Undo()
		{
			if (CanUndo())
			{
				_commands[_nextActionIndex - 1].Unexecute();
				_nextActionIndex--;
			}
		}

		public void Redo()
		{
			if (CanRedo())
			{
				_commands[_nextActionIndex].Execute();
				_nextActionIndex++;
			}
		}

		public void AddAndExecuteCommand(ICommand command)
		{
			if (_commands.Count >= MAX_COMMANDS_STACK_SIZE)
			{
				_commands[0].Delete();
				_commands.RemoveAt(0);
				_nextActionIndex--;
			}

			if (CanRedo())
			{
				var commandsCount = _commands.Count - 1;
				for (var i = commandsCount; i >= _nextActionIndex; --i)
				{
					_commands[i].Delete();
					_commands.RemoveAt(i);
				}
			}

			command.Execute();
			_commands.Add(command);
			_nextActionIndex++;
		}
	}
}

using System.Collections.Generic;

namespace task2.Menu
{
	public sealed class ArgumentsHandler : IInputHandler
	{
		private List<string> _arguments;

		private int _index = 0;

		public int ArgumentsLeft
		{
			get { return _arguments.Count - _index; }
		}

		public ArgumentsHandler(string args)
		{
			_arguments = new List<string>(args.Split(separator: " "));
		}

		public string GetNextStringArg()
		{
			return _arguments[_index++];
		}
	}
}

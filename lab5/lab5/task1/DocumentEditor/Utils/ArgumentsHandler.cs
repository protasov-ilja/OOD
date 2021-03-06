﻿using System.Collections.Generic;

namespace task1.DocumentEditor.Utils
{
    public class ArgumentsHandler : IInputHandler
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

		public int GetNextIntArg()
		{
			return int.Parse(_arguments[_index++]);
		}

		public float GetNextFloatArg()
		{
			return float.Parse(_arguments[_index++]);
		}

		public string GetNextStringArg()
		{
			return _arguments[_index++];
		}
	}
}

using System;

namespace task1.Utils.Exceptions
{
    public class LogicErrorException : Exception
    {
		public LogicErrorException(string message)
			: base(message)
		{ }
    }
}

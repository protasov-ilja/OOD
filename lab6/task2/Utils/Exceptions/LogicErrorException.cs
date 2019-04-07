using System;

namespace task2.Utils.Exceptions
{
    public class LogicErrorException : Exception
    {
		public LogicErrorException(string message)
			: base (message)
		{

		}
    }
}

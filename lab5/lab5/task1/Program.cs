using System;
using task1.DocumentEditor;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
			Editor editor = new Editor();
			editor.Run(Console.In, Console.Out);
		}
    }
}

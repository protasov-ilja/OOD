using System;
using task3.Streams;

namespace task3
{
    class Program
    {
		private const string INPUT_FILE_NAME = "input.txt";
		private const string OUTPUT_FILE_NAME = "output.txt";

        static void Main(string[] args)
        {
			if (args.Length < 3)
			{
				Console.WriteLine($"error input, please write: transform.exe [options] <input-file> <output-file>");
			}

			var inputFileName = args[1];
			var outputFileName = args[2];
			var hnadler = new InputHandler();
		}
    }
}

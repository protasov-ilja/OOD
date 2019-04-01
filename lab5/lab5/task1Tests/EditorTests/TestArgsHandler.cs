
using task1.DocumentEditor.Utils;

namespace task1Tests.EditorTests
{
	public class TestArgsHandler : IInputHandler
	{
		public int ArgumentsLeft { get; set; }

		public float GetNextFloatArg()
		{
			throw new System.NotImplementedException();
		}

		public int GetNextIntArg()
		{
			throw new System.NotImplementedException();
		}

		public string GetNextStringArg()
		{
			throw new System.NotImplementedException();
		}
	}
}

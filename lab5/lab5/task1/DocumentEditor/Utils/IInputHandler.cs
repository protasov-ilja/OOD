namespace task1.DocumentEditor.Utils
{
    public interface IInputHandler
    {
		int ArgumentsLeft { get; }

		string GetNextStringArg();

		int GetNextIntArg();

		float GetNextFloatArg();
	}
}

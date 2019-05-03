namespace task2.Menu
{
	public interface IInputHandler
	{
		int ArgumentsLeft { get; }
		string GetNextStringArg();
		int GetNextIntArg();
		float GetNextFloatArg();
	}
}

namespace task2.Menu
{
	public static class IInputHandlerExtensions
	{
		public static int GetNextIntArg(this IInputHandler handler)
		{
			return int.Parse(handler.GetNextStringArg());
		}
	}
}

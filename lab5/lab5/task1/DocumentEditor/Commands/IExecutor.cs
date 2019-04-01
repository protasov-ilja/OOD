namespace task1.DocumentEditor.Commands
{
	public interface IExecutor
    {
		void AddAndExecuteCommand(ICommand command);
	}
}

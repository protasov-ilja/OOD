namespace task1.DocumentEditor.Commands
{
	public interface ICommand
    {
		void Execute();
		void Unexecute();
	}
}

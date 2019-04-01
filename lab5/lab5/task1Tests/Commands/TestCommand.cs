using task1.DocumentEditor.Commands;

namespace task1Tests.Commands
{
	public class TestCommand : ICommand
	{
		public bool IsExecuted { get; private set; } = false;
		public bool IsDeleted { get; private set; } = false;

		public void Delete()
		{
			IsDeleted = true;
		}

		public void Execute()
		{
			IsExecuted = true;
		}

		public void Unexecute()
		{
			IsExecuted = false;
		}
	}
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.DocumentEditor.Commands;

namespace task1Tests.Items.ImageTests
{
	public class TestExecutor : IExecutor
	{
		public void AddAndExecuteCommand(ICommand command)
		{
			Assert.IsTrue(command is ResizeImageCommand);
		}
	}
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.DocumentEditor.Commands;

namespace task1Tests.Commands
{
	[TestClass]
    public class HistoryTests
    {
		[TestMethod]
		public void CanCreateEmptyHistory()
		{
			History history = new History();
			Assert.IsFalse(history.CanRedo());
			Assert.IsFalse(history.CanUndo());
		}

		[TestMethod]
		public void CanAddComandInHistoryAndExecuteIt()
		{
			TestCommand c = new TestCommand();
			History history = new History();
			Assert.IsFalse(c.IsExecuted);
			history.AddAndExecuteCommand(c);
			Assert.IsTrue(c.IsExecuted);
		}

		[TestMethod]
		public void CanRedoCommand()
		{
			TestCommand c = new TestCommand();
			History history = new History();
			Assert.IsFalse(c.IsExecuted);
			history.AddAndExecuteCommand(c);
			Assert.IsTrue(c.IsExecuted);
			history.Undo();
			Assert.IsFalse(c.IsExecuted);
		}

		[TestMethod]
		public void CanUndoCommand()
		{
			TestCommand c = new TestCommand();
			History history = new History();
			Assert.IsFalse(c.IsExecuted);
			history.AddAndExecuteCommand(c);
			Assert.IsTrue(c.IsExecuted);
			history.Undo();
			Assert.IsFalse(c.IsExecuted);
			history.Redo();
			Assert.IsTrue(c.IsExecuted);
		}

		[TestMethod]
		public void DeletesAllCommandsUpToCurrentCommandWhenInsertsNewCommand()
		{
			TestCommand c1= new TestCommand();
			TestCommand c2 = new TestCommand();
			TestCommand c3 = new TestCommand();
			TestCommand c4 = new TestCommand();
			TestCommand cNew2 = new TestCommand();
			History history = new History();
			history.AddAndExecuteCommand(c1);
			history.AddAndExecuteCommand(c2);
			history.AddAndExecuteCommand(c3);
			history.AddAndExecuteCommand(c4);

			history.Undo();
			history.Undo();
			history.AddAndExecuteCommand(cNew2);
			Assert.IsTrue(c3.IsDeleted);
			Assert.IsTrue(c4.IsDeleted);
			Assert.IsTrue(cNew2.IsExecuted);
		}

		[TestMethod]
		public void DeleteFirstCommandIfCommandMoreThan10()
		{
			History history = new History();
			TestCommand c1 = new TestCommand();
			TestCommand c2 = new TestCommand();
			TestCommand c3 = new TestCommand();
			TestCommand c4 = new TestCommand();
			TestCommand c5 = new TestCommand();
			TestCommand c6 = new TestCommand();
			TestCommand c7 = new TestCommand();
			TestCommand c8 = new TestCommand();
			TestCommand c9 = new TestCommand();
			TestCommand c10 = new TestCommand();
			TestCommand c11 = new TestCommand();

			history.AddAndExecuteCommand(c1);
			history.AddAndExecuteCommand(c2);
			history.AddAndExecuteCommand(c3);
			history.AddAndExecuteCommand(c4);
			history.AddAndExecuteCommand(c5);
			history.AddAndExecuteCommand(c6);
			history.AddAndExecuteCommand(c7);
			history.AddAndExecuteCommand(c8);
			history.AddAndExecuteCommand(c9);
			history.AddAndExecuteCommand(c10);
			history.AddAndExecuteCommand(c11);

			while (history.CanUndo())
			{
				history.Undo();
			}

			Assert.IsTrue(c1.IsExecuted);
			Assert.IsFalse(c11.IsExecuted);
		}
	}
}

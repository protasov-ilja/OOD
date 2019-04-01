using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.DocumentEditor.Commands;

namespace task1Tests.Commands
{
	[TestClass]
    public class ReplaceTextCommandTests
    {
		[TestMethod]
		public void CanCreateCommandAndReplaceItemText()
		{
			var i = new TestReplacable();
			i.Text = "test";
			string str = "sth";
			var c = new ReplaceTextCommand(i, str);
			c.Execute();
			Assert.AreEqual(i.Text, str);
		}

		[TestMethod]
		public void CanReturnTextBackToPreviousState()
		{
			var i = new TestReplacable();
			string oldText = "test";
			i.Text = oldText;
			string str = "sth";
			var c = new ReplaceTextCommand(i, str);
			c.Execute();
			Assert.AreEqual(i.Text, str);
			c.Unexecute();
			Assert.AreEqual(i.Text, oldText);
		}
	}
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using task1.DocumentEditor.Commands;
using task1.DocumentEditor.Documents.Items;

namespace task1Tests.Commands
{
	[TestClass]
	public class DeleteItemTests
    {
		[TestMethod]
		public void CanCreateCommandAndDeleteItemOnExecute()
		{
			var items = new List<DocumentItem>
			{
				new DocumentItem(new TestParagraph()),
			};
			Assert.AreEqual(items.Count, 1);
			DeleteItemCommand c = new DeleteItemCommand(0, items);
			c.Execute();
			Assert.AreEqual(items.Count, 0);
		}

		[TestMethod]
		public void CanUndoDeleteItemCommand()
		{
			var items = new List<DocumentItem>
			{
				new DocumentItem(new TestParagraph()),
			};
			Assert.AreEqual(items.Count, 1);
			DeleteItemCommand c = new DeleteItemCommand(0, items);
			c.Execute();
			Assert.AreEqual(items.Count, 0);
			c.Unexecute();
			Assert.AreEqual(items.Count, 1);
		}
	}
}

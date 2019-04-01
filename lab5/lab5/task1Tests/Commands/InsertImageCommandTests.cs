using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using task1.DocumentEditor.Commands;
using task1.DocumentEditor.Documents.Items;

namespace task1Tests.Commands
{
	[TestClass]
	public class InsertImageCommandTests
    {
		[TestMethod]
		public void CanCreateCommandAndInsertImageAtEndOfListIfPosIsNull()
		{
			var items = new List<DocumentItem>
			{
				new DocumentItem(new TestParagraph()),
			};

			var i = new TestImage();
			var c = new InsertImageCommand(items, i, null);
			c.Execute();
			Assert.AreEqual(i, items[1].Image);
		}

		[TestMethod]
		public void CanCreateCommandAndInsertImageInListIfPosIsNotNull()
		{
			var items = new List<DocumentItem>
			{
				new DocumentItem(new TestParagraph()),
				new DocumentItem(new TestParagraph()),
			};

			var i = new TestImage();
			var c = new InsertImageCommand(items, i, 1);
			c.Execute();
			Assert.AreEqual(i, items[1].Image);
		}

		[TestMethod]
		public void CanRemoveInsertedIfCallUnexecuteMethod()
		{
			var oldI = new TestImage();
			var items = new List<DocumentItem>
			{
				new DocumentItem(new TestParagraph()),
				new DocumentItem(oldI),
			};

			var i = new TestImage();
			var c = new InsertImageCommand(items, i, 1);
			c.Execute();
			Assert.AreEqual(i, items[1].Image);

			c.Unexecute();
			Assert.AreEqual(oldI, items[1].Image);
		}
	}
}

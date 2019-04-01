using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using task1.DocumentEditor.Commands;
using task1.DocumentEditor.Documents.Items;

namespace task1Tests.Commands
{
	[TestClass]
    public class InsertParagraphCommandTests
    {
		[TestMethod]
		public void CanCreateCommandAndInsertParagraphAtEndOfListIfPosIsNull()
		{
			var items = new List<DocumentItem>
			{
				new DocumentItem(new TestParagraph()),
			};

			var p = new TestParagraph();
			var c = new InsertParagraphCommand(items, p, null);
			c.Execute();
			Assert.AreEqual(p, items[1].Paragraph);
		}

		[TestMethod]
		public void CanCreateCommandAndInsertParagraphAtEndOfListIListIsEmpty()
		{
			var items = new List<DocumentItem>
			{
			};

			var p = new TestParagraph();
			var c = new InsertParagraphCommand(items, p, 0);
			c.Execute();
			Assert.AreEqual(p, items[0].Paragraph);
		}

		[TestMethod]
		public void CanCreateCommandAndInsertParagraphAInListIfPosIsNotNull()
		{
			var items = new List<DocumentItem>
			{
				new DocumentItem(new TestParagraph()),
				new DocumentItem(new TestParagraph()),
			};

			var p = new TestParagraph();
			var c = new InsertParagraphCommand(items, p, 1);
			c.Execute();
			Assert.AreEqual(p, items[1].Paragraph);
		}

		[TestMethod]
		public void CanRemoveInsertedIfCallUnexecuteMethod()
		{
			var oldP = new TestParagraph();
			var items = new List<DocumentItem>
			{
				new DocumentItem(new TestParagraph()),
				new DocumentItem(oldP),
			};

			var p = new TestParagraph();
			var c = new InsertParagraphCommand(items, p, 1);
			c.Execute();
			Assert.AreEqual(p, items[1].Paragraph);

			c.Unexecute();
			Assert.AreEqual(oldP, items[1].Paragraph);
		}
	}
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.DocumentEditor.Documents.Items;

namespace task1Tests.Items.DocumentItemTests
{
	[TestClass]
    public class DocumentItemTests
    {
		[TestMethod]
		public void CanCreateDocumentItemWithPragraph()
		{
			var p = new TestParagraph();
			DocumentItem item = new DocumentItem(p);
			Assert.AreEqual(p, item.Paragraph);
		}

		[TestMethod]
		public void CanCreateDocumentItemWithImage()
		{
			var i = new TestImage();
			DocumentItem item = new DocumentItem(i);
			Assert.AreEqual(i, item.Image);
		}

		[TestMethod]
		public void ReturnNullIfItemDoesntHaveParagraph()
		{
			var i = new TestImage();
			DocumentItem item = new DocumentItem(i);
			Assert.AreEqual(i, item.Image);
			Assert.AreEqual(null, item.Paragraph);
		}

		[TestMethod]
		public void ReturnNullIfItemDoesntHaveImage()
		{
			var p = new TestParagraph();
			DocumentItem item = new DocumentItem(p);
			Assert.AreEqual(p, item.Paragraph);
			Assert.AreEqual(null, item.Image);
		}

		[TestMethod]
		public void CanReturnImageIfItemHasIt()
		{
			var i = new TestImage();
			DocumentItem item = new DocumentItem(i);
			Assert.AreEqual(i, item.Image);
		}

		[TestMethod]
		public void CanReturnParagraphIfItemHasIt()
		{
			var p = new TestParagraph();
			DocumentItem item = new DocumentItem(p);
			Assert.AreEqual(p, item.Paragraph);
		}
	}
}

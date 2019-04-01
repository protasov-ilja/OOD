using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.DocumentEditor.Documents.Items;

namespace task1Tests.ParagraphTests
{
	[TestClass]
	public class ParagraphTests
    {
		[TestMethod]
		public void CanCreateParagraph()
		{
			string text = "test";
			TestExecutor executor = new TestExecutor();
			Paragraph paragraph = new Paragraph(text, executor);
			Assert.AreEqual(text, paragraph.GetParagraphText());
		}

		[TestMethod]
		public void CanGetParagraphText()
		{
			string text = "test";
			TestExecutor executor = new TestExecutor();
			Paragraph paragraph = new Paragraph(text, executor);
			Assert.AreEqual(text, paragraph.GetParagraphText());
			Assert.AreEqual(text, paragraph.Text);
		}

		[TestMethod]
		public void CanChangeParagraphText()
		{
			string text = "test";
			string newText = "sth";
			TestExecutor executor = new TestExecutor();
			Paragraph paragraph = new Paragraph(text, executor);
			paragraph.SetParagraphText(newText);
			paragraph.Text = newText;
			Assert.AreEqual(newText, paragraph.Text);
		}
    }
}

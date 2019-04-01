using task1.DocumentEditor.Documents.Items;

namespace task1Tests.Items.DocumentItemTests
{
	public class TestParagraph : IParagraph
	{
		public string GetParagraphText()
		{
			return "test";
		}

		public void SetParagraphText(string text)
		{
		}
	}
}

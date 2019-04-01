using task1.DocumentEditor.Commands;

namespace task1.DocumentEditor.Documents.Items
{
	public class Paragraph : IParagraph, IReplacable
	{
		private IExecutor _executor;

		public string Text { get; set; }

		public Paragraph(string text, IExecutor executor)
		{
			Text = text;
			_executor = executor;
		}

		public void SetParagraphText(string text)
		{
			_executor.AddAndExecuteCommand(new ReplaceTextCommand(this, text));
		}

		public string GetParagraphText()
		{
			return Text;
		}
	}
}

using task1.DocumentEditor.Commands;

namespace task1.DocumentEditor.Documents.Items
{
	public class Title : IReplacable
	{
		public string Text { get; set; } = "";
	}
}

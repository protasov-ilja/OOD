namespace task1.DocumentEditor.Documents.Items
{
    public class DocumentItem
    {
		public IParagraph Paragraph { get; private set; } = null;
		public IImage Image { get; private set; } = null;

		public DocumentItem(IParagraph paragraph)
		{
			Paragraph = paragraph;
		}

		public DocumentItem(IImage image)
		{
			Image = image;
		}
	}
}

namespace task1.DocumentEditor.Documents.Items
{
	public interface IImage
	{
		int Width { get; set; }
		int Height { get; set; }
		string Path { get; }

		IImageHandler ImageHandler { get; }

		void Resize(int width, int height);
    }
}

using task1.DocumentEditor.Documents;
using task1.DocumentEditor.Documents.Items;

namespace task1Tests.Commands
{
	public class TestImage : IImage
	{
		public int Width { get; set; }
		public int Height { get; set; }

		public string Path { get; }

		public TestImage()
		{
			ImageHandler = new TestImageHandler();
		}

		public IImageHandler ImageHandler { get; }

		public void Resize(int width, int height)
		{
			throw new System.NotImplementedException();
		}
	}
}

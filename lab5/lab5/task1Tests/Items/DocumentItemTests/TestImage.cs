using System;
using task1.DocumentEditor.Documents;
using task1.DocumentEditor.Documents.Items;

namespace task1Tests.Items.DocumentItemTests
{
	public class TestImage : IImage
	{
		public int Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public string Path => throw new NotImplementedException();

		public IImageHandler ImageHandler => throw new NotImplementedException();

		public void Resize(int width, int height)
		{
			throw new NotImplementedException();
		}
	}
}

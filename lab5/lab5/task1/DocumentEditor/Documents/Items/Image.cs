using System;
using task1.DocumentEditor.Commands;

namespace task1.DocumentEditor.Documents.Items
{
	public class Image : IImage
	{
		private const int MAX_IMAGE_SIZE = 10000;
		private const int MIN_IMAGE_SIZE = 1;

		public int Width { get; set; }
		public int Height { get; set; }
		public string Path { get; private set; }

		public IImageHandler ImageHandler { get; private set; }
		private IExecutor _executor;

		public Image(int width, int height, string path, IExecutor executor, IImageHandler handler)
		{
			CheckImageSize(width, height);
			Width = width;
			Height = height;
			Path = path;
			_executor = executor;
			ImageHandler = handler;
		}

		public void Resize(int width, int height)
		{
			CheckImageSize(width, height);
			_executor.AddAndExecuteCommand(new ResizeImageCommand(this, width, height));
		}

		private void CheckImageSize(int width, int height)
		{
			if (width < MIN_IMAGE_SIZE || width > MAX_IMAGE_SIZE)
			{
				throw new ArgumentOutOfRangeException("width");
			}
			
			if (height < MIN_IMAGE_SIZE || height > MAX_IMAGE_SIZE)
			{
				throw new ArgumentOutOfRangeException("height");
			}
		}
	}
}

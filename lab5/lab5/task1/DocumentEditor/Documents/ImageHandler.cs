using System.Collections.Generic;
using System.IO;

namespace task1.DocumentEditor.Documents
{
	public class ImageHandler : IImageHandler
	{
		private string _directory;
		private int _imageIndex = 0;

		private List<string> _images = new List<string>();
		private List<string> _imagesForDeletion = new List<string>();

		public ImageHandler(string directory)
		{
			_directory = directory + "\\image";

			if (!Directory.Exists(_directory))
			{
				Directory.CreateDirectory(_directory);
			}
		}

		public string AddImage(string path)
		{
			var imagePath = _directory + $"\\{_imageIndex}.jpg";
			if (File.Exists(path))
			{
				File.Copy(path, imagePath, true);
				_imageIndex++;
				_images.Add(imagePath);
			}

			return imagePath;
		}

		public void DeleteImage(string path)
		{
			if (_imagesForDeletion.Contains(path))
			{
				if (File.Exists(path))
				{
					File.Delete(path);
					_imagesForDeletion.Remove(path);
				}
			}
		}

		public void RemoveFromDeletedImages(string path)
		{
			_images.Remove(path);
			_imagesForDeletion.Add(path);
		}

		public void AddToDeletedImages(string path)
		{
			_imagesForDeletion.Remove(path);
			_images.Add(path);
		}

		public void MoveImagesToDirectory(string path)
		{
			foreach (var imagePath in _images)
			{
				FileInfo info = new FileInfo(imagePath);
				File.Copy(imagePath, path + $"\\image\\{info.Name}", true);
			}
		}
	}
}

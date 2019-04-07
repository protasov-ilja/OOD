using System.Collections.Generic;
using System.IO;

namespace task1.DocumentEditor.Documents
{
	public class ImageHandler : IImageHandler
	{
		private string _directory;
		private int _imageIndex = 0;

		private List<string> _imagesForSave = new List<string>();
		private List<string> _imagesForDeletion = new List<string>();

		public ImageHandler(string directory)
		{
			_directory = directory;

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
				_imagesForSave.Add(imagePath);
			}

			return imagePath;
		}

		public void DeleteImage(string path)
		{
			if (File.Exists(path) && _imagesForDeletion.Remove(path))
			{
				File.Delete(path);
			}
		}

		public void RemoveFromDeletedImages(string path)
		{
			if (!_imagesForSave.Contains(path))
			{
				_imagesForSave.Add(path);
				_imagesForDeletion.Remove(path);
			}
		}

		public void AddToDeletedImages(string path)
		{
			if (!_imagesForDeletion.Contains(path))
			{
				_imagesForSave.Remove(path);
				_imagesForDeletion.Add(path);
			}
		}

		public void CopyImagesToDirectory(string path)
		{
			var directory = path;
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			foreach (var imagePath in _imagesForSave)
			{
				FileInfo info = new FileInfo(imagePath);
				File.Copy(imagePath, $"{directory}\\{ info.Name}", true);
			}
		}
	}
}

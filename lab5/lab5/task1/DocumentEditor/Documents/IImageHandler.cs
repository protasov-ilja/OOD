namespace task1.DocumentEditor.Documents
{
    public interface IImageHandler
    {
		string AddImage(string path);

		void DeleteImage(string path);

		void AddToDeletedImages(string path);

		void RemoveFromDeletedImages(string path);

		void CopyImagesToDirectory(string path);
	}
}

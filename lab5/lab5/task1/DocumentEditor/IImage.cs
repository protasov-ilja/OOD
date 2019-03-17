namespace task1.DocumentEditor
{
	public interface IImage
    {
		// Возвращает путь относительно каталога документа
		Path GetPath();

		// Ширина изображения в пикселях
		 int GetWidth();
		// Высота изображения в пикселях
		 int GetHeight();

		// Изменяет размер изображения
		 void Resize(int width, int height);
    }
}

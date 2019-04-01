using task1.DocumentEditor.Documents.Items;

namespace task1.DocumentEditor.Documents
{
    public interface IDocument
    {
		// Вставляет параграф текста в указанную позицию (сдвигая последующие элементы)
		// Если параметр position не указан, вставка происходит в конец документа
		IParagraph InsertParagraph(string text, int? position = null);

		// Вставляет изображение в указанную позицию (сдвигая последующие элементы)
		// Параметр path задает путь к вставляемому изображению
		// При вставке изображение должно копироваться в подкаталог images 
		// под автоматически сгенерированным именем
		IImage InsertImage(string path, int width, int height, int? position = null);

		// Возвращает количество элементов в документе
		int GetItemsCount();

		// Доступ к элементам изображения
		DocumentItem GetItem(int index);

		// Удаляет элемент из документа
		void DeleteItem(int index);

		// Возвращает заголовок документа
		string GetTitle();

		// Изменяет заголовок документа
		void SetTitle(string title);

		// Сообщает о доступности операции Undo
		bool CanUndo();

		// Отменяет команду редактирования
		void Undo();

		// Сообщает о доступности операции Redo
		bool CanRedo();

		// Выполняет отмененную команду редактирования
		void Redo();

		// Сохраняет документ в формате html. Изображения сохраняются в подкаталог images
		// пути к изображениям указываются относительно пути к сохраняемому HTML файлу
		void Save(string path);
    }
}

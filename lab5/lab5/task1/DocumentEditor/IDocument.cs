namespace task1.DocumentEditor
{
    public interface IDocument
    {
		// Вставляет параграф текста в указанную позицию (сдвигая последующие элементы)
		// Если параметр position не указан, вставка происходит в конец документа
		IParagraph InsertParagraph(string text/*, 
		optional<size_t> position = none*/);

		// Вставляет изображение в указанную позицию (сдвигая последующие элементы)
		// Параметр path задает путь к вставляемому изображению
		// При вставке изображение должно копироваться в подкаталог images 
		// под автоматически сгенерированным именем
		IImage InsertImage(Path path, int width, int height/*,
			optional<size_t> position = none*/);

		// Возвращает количество элементов в документе
		uint GetItemsCount();

		// Доступ к элементам изображения
		ConstDocumentItem GetItem(uint index);

		DocumentItem GetItem(uint index);

		// Удаляет элемент из документа
		void DeleteItem(uint index);

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
		void Save(Path path);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using task1.DocumentEditor.Commands;
using task1.DocumentEditor.Documents.Items;

namespace task1.DocumentEditor.Documents
{
	public sealed class Document : IDocument
	{
		private const string HTML_FILE_NAME = "\\index.html";
		private const string IMAGE_FOLDER = "\\image";

		private Title _title = new Title();
		private History _history = new History();
		private List<DocumentItem> _documentItems = new List<DocumentItem>();
		private IImageHandler _imageHandler;

		public Document()
		{
			_imageHandler = new ImageHandler(Directory.GetCurrentDirectory() + IMAGE_FOLDER);
		}

		public void SetTitle(string titleText)
		{
			_history.AddAndExecuteCommand(new ReplaceTextCommand(_title, titleText));
		}

		public IParagraph InsertParagraph(string text, int? position = null)
		{
			if (position.HasValue && (position < 0 || position > _documentItems.Count))
			{
				throw new IndexOutOfRangeException($"Wrong position: {position}");
			}

			var paragraph = new Paragraph(text, _history);
			_history.AddAndExecuteCommand(new InsertParagraphCommand(_documentItems, paragraph, position));

			return paragraph;
		}

		public IImage InsertImage(string path, int width, int height, int? position = null)
		{
			if (position.HasValue && (position < 0 || position > _documentItems.Count))
			{
				throw new IndexOutOfRangeException($"Wrong position: {position}");
			}

			string newPath = _imageHandler.AddImage(path);
			IImage image = new Image(width, height, newPath, _history, _imageHandler);
			_history.AddAndExecuteCommand(new InsertImageCommand(_documentItems, image, position));

			return image;
		}

		public bool CanRedo()
		{
			return _history.CanRedo();
		}

		public bool CanUndo()
		{
			return _history.CanUndo();
		}

		public void DeleteItem(int index)
		{
			_history.AddAndExecuteCommand(new DeleteItemCommand(index, _documentItems));
		}

		public DocumentItem GetItem(int index)
		{
			if (index < 0 || _documentItems.Count <= index)
			{
				throw new IndexOutOfRangeException("document item index out of range");
			}

			return _documentItems[index];
		}

		public int GetItemsCount()
		{
			return _documentItems.Count;
		}

		public string GetTitle()
		{
			return _title.Text;
		}

		public void Redo()
		{
			_history.Redo();
		}

		public void Save(string path)
		{
			var fullPath = path + HTML_FILE_NAME;
			try
			{
				_imageHandler.CopyImagesToDirectory(path + IMAGE_FOLDER);
				HTMLDocumentSaver saver = new HTMLDocumentSaver(fullPath, _documentItems, GetTitle());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void Undo()
		{
			_history.Undo();
		}
	}
}

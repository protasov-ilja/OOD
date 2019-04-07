using System;
using System.IO;
using task1.DocumentEditor.Documents;
using task1.DocumentEditor.Documents.Items;
using task1.DocumentEditor.Utils;

namespace task1.DocumentEditor
{
	public class Editor
	{
		private const string HELP_COMMAND = "help";
		private const string EXIT_COMMAND = "exit";
		private const string INSERT_PARAGRAPH_COMMAND = "i-p";
		private const string INSERT_IMAGE_COMMAND = "i-i";
		private const string SET_TITLE_COMMAND = "set-title";
		private const string LIST_COMMAND = "list";
		private const string REPLACE_TEXT_COMMAND = "replace";
		private const string RESIZE_IMAGE_COMMAND = "resize";
		private const string DELETE_ITEM_COMMAND = "del";
		private const string UNDO_COMMAND = "undo";
		private const string REDO_COMMAND = "redo";
		private const string SAVE_COMMAND = "save";

		private Menu _menu = new Menu();
		private IDocument _document = new Document();
		private TextWriter _out;

		public Editor()
		{
			_menu.AddItem(INSERT_PARAGRAPH_COMMAND, "insert paragraph <position>/end <text>", InsertParagraph);
			_menu.AddItem(INSERT_IMAGE_COMMAND, "insert image <position>/end <width> <height> <path>", InsertImage);
			_menu.AddItem(SET_TITLE_COMMAND, "set title of document <document title>", SetTitle);
			_menu.AddItem(LIST_COMMAND, "show document on list", ShowDocumentAsList);
			_menu.AddItem(REPLACE_TEXT_COMMAND, "replace text in paragraph <position>/end <text>", ReplaceText);
			_menu.AddItem(RESIZE_IMAGE_COMMAND, "resize image <position>/end <width> <height>", ResizeImage);
			_menu.AddItem(DELETE_ITEM_COMMAND, "delete item in document <position>", DeleteItem);
			_menu.AddItem(HELP_COMMAND, "show help", ShowHelp);
			_menu.AddItem(EXIT_COMMAND, "exit programm", Exit);
			_menu.AddItem(UNDO_COMMAND, "undo last action", UndoCommand);
			_menu.AddItem(REDO_COMMAND, "redo action", RedoCommand);
			_menu.AddItem(SAVE_COMMAND, "save document in html <path>", SaveDocumentInHtml);
		}

		public void Run(TextReader inputData, TextWriter outputData)
		{
			_out = outputData;
			_menu.Run(inputData);
		}

		private void Exit(IInputHandler argsHandler)
		{
			_menu.Exit();
		}

		private void InsertParagraph(IInputHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft < 2)
			{
				_out.WriteLine($"Not Enougth arguments {argsHandler.ArgumentsLeft}");
				return;
			}

			try
			{
				var position = GetItemPositionFormStr(argsHandler.GetNextStringArg());
				var text = CreateTextFromArr(argsHandler);
				_document.InsertParagraph(text, position);
			}
			catch (Exception ex)
			{
				_out.WriteLine(ex.Message);
			}
		}

		private int GetItemPositionFormStr(string str)
		{
			const string END_POSITION = "end";
			if (str == END_POSITION)
			{
				return _document.GetItemsCount();
			}

			var position = int.Parse(str);
			if (position > 0 && position < _document.GetItemsCount() || position == 0)
			{
				return position;
			}
			else
			{
				throw new ArgumentOutOfRangeException("position");
			}
		}

		private string CreateTextFromArr(IInputHandler argsHandler)
		{
			string text = "";
			while (argsHandler.ArgumentsLeft != 0)
			{
				text += argsHandler.GetNextStringArg() + " ";
			}

			return text;
		}

		private void InsertImage(IInputHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft != 4)
			{
				_out.WriteLine($"Not Enougth arguments {argsHandler.ArgumentsLeft}");
				return;
			}

			try
			{
				var position = GetItemPositionFormStr(argsHandler.GetNextStringArg());
				var width = argsHandler.GetNextIntArg();
				var height = argsHandler.GetNextIntArg();
				_document.InsertImage(argsHandler.GetNextStringArg(), width, height, position);
			}
			catch (Exception ex)
			{
				_out.WriteLine(ex.Message);
			}
		}

		private void SetTitle(IInputHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft < 1)
			{
				_out.WriteLine($"Not Enougth arguments {argsHandler.ArgumentsLeft}");
				return;
			}

			try
			{
				_document.SetTitle(CreateTextFromArr(argsHandler));
			}
			catch (Exception ex)
			{
				_out.WriteLine(ex.Message);
			}
		}

		private void ShowDocumentAsList(IInputHandler argsHandler)
		{
			try
			{
				_out.WriteLine($"Title: {_document.GetTitle()}");
				for (var i = 0; i < _document.GetItemsCount(); ++i)
				{
					var info = $"{i}. ";
					DocumentItem item = _document.GetItem(i);
					IImage image = item.Image;
					IParagraph paragraph = item.Paragraph;

					if (image != null)
					{
						info += $"Image: { image.Width } { image.Height }  { image.Path }";
					}
					else if (paragraph != null)
					{
						info += $"Paragraph: { paragraph.GetParagraphText() }";
					}

					_out.WriteLine(info);
				}

				_out.WriteLine();
			}
			catch (Exception ex)
			{
				_out.WriteLine(ex.Message);
			}
		}

		private void ReplaceText(IInputHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft < 2)
			{
				_out.WriteLine($"Not Enougth arguments {argsHandler.ArgumentsLeft}");
				return;
			}

			try
			{
				var position = GetItemPositionFormStr(argsHandler.GetNextStringArg());
				var item = _document.GetItem(position);
				var paragraph = item.Paragraph;
				if (paragraph != null)
				{
					var text = CreateTextFromArr(argsHandler);
					paragraph.SetParagraphText(text);
				}
				else
				{
					throw new ArgumentException("paragraph not found");
				}
			}
			catch (Exception ex)
			{
				_out.WriteLine(ex.Message);
			}
		}

		private void ResizeImage(IInputHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft != 3)
			{
				_out.WriteLine($"Not Enougth arguments {argsHandler.ArgumentsLeft}");
				return;
			}

			try
			{
				var position = GetItemPositionFormStr(argsHandler.GetNextStringArg());
				var width = argsHandler.GetNextIntArg();
				var height = argsHandler.GetNextIntArg();
				var item = _document.GetItem(position);
				var image = item.Image;
				if (image != null)
				{
					image.Resize(width, height);
				}
				else
				{
					throw new ArgumentException("image not found");
				}
			}
			catch (Exception ex)
			{
				_out.WriteLine(ex.Message);
			}
		}

		private void DeleteItem(IInputHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft != 1)
			{
				_out.WriteLine($"Not Enougth arguments {argsHandler.ArgumentsLeft}");
				return;
			}

			try
			{
				var position = GetItemPositionFormStr(argsHandler.GetNextStringArg());
				_document.DeleteItem(position);
			}
			catch (Exception ex)
			{
				_out.WriteLine(ex.Message);
			}
		}

		private void ShowHelp(IInputHandler argsHandler)
		{
			_menu.ShowInstructions();
		}

		private void UndoCommand(IInputHandler argsHandler)
		{
			if (_document.CanUndo())
			{
				_document.Undo();
			}
			else
			{
				_out.WriteLine("Can't Undo");
			}
		}

		private void RedoCommand(IInputHandler argsHandler)
		{
			if (_document.CanRedo())
			{
				_document.Redo();
			}
			else
			{
				_out.WriteLine("Can't Redo");
			}
		}

		private void SaveDocumentInHtml(IInputHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft != 1)
			{
				_out.WriteLine($"Not Enougth arguments {argsHandler.ArgumentsLeft}");
				return;
			}

			_document.Save(argsHandler.GetNextStringArg());
		}
	}
}

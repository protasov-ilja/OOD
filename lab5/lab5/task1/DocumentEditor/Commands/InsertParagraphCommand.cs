using System.Collections.Generic;
using task1.DocumentEditor.Documents.Items;

namespace task1.DocumentEditor.Commands
{
	public class InsertParagraphCommand : AbstarctCommand
	{
		private List<DocumentItem> _items;
		private IParagraph _paragraph;
		private int? _position;

		public InsertParagraphCommand(List<DocumentItem> items, IParagraph paragraph, int? position)
		{
			_items = items;
			_position = position;
			_paragraph = paragraph;
		}

		protected override void DoExecute()
		{
			if (!_position.HasValue)
			{
				_items.Add(new DocumentItem(_paragraph));
			}
			else
			{
				_items.Insert((int)_position, new DocumentItem(_paragraph));
			}
		}

		protected override void DoUnexecute()
		{
			if (!_position.HasValue)
			{
				_items.RemoveAt(_items.Count - 1);
			}
			else
			{
				_items.RemoveAt((int)_position);
			}
		}
	}
}

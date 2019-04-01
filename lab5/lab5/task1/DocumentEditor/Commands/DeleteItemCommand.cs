using System.Collections.Generic;
using task1.DocumentEditor.Documents.Items;

namespace task1.DocumentEditor.Commands
{
	public class DeleteItemCommand : AbstarctCommand
	{
		private List<DocumentItem> _items;
		private DocumentItem _item;
		private int _position;

		public DeleteItemCommand(int position, List<DocumentItem> items)
		{
			_items = items;
			_position = position;
			_item = items[position];
		}

		protected override void DoExecute()
		{
			IImage image = _item.Image;
			if (image != null)
			{
				image.ImageHandler.AddToDeletedImages(image.Path);
			}

			_items.RemoveAt(_position);
		}

		protected override void DoUnexecute()
		{
			_items.Insert(_position, _item);
			IImage image = _item.Image;
			if (image != null)
			{
				image.ImageHandler.RemoveFromDeletedImages(image.Path);
			}
		}
	}
}

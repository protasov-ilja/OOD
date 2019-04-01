using System.Collections.Generic;
using task1.DocumentEditor.Documents.Items;

namespace task1.DocumentEditor.Commands
{
	public class InsertImageCommand : AbstarctCommand
	{
		List<DocumentItem> _items;
		private IImage _image;
		private int? _position;

		public InsertImageCommand(List<DocumentItem> items, IImage image, int? position)
		{
			_position = position;
			_image = image;
			_items = items;
		}

		public override void Delete()
		{
			_image.ImageHandler.DeleteImage(_image.Path);
		}

		protected override void DoExecute()
		{
			if (!_position.HasValue)
			{
				_items.Add(new DocumentItem(_image));
			}
			else
			{
				_items.Insert((int)_position, new DocumentItem(_image));
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

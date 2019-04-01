using task1.DocumentEditor.Documents.Items;

namespace task1.DocumentEditor.Commands
{
	public class ResizeImageCommand : AbstarctCommand
	{
		private IImage _image;
		private int _newWidth;
		private int _newHeight;
		private int _prevWidth;
		private int _prevHeight;

		public ResizeImageCommand(IImage image, int newWidth, int newHeight)
		{
			_image = image;
			_newHeight = newHeight;
			_newWidth = newWidth;
		}

		protected override void DoExecute()
		{
			_prevWidth = _image.Width;
			_prevHeight = _image.Height;
			_image.Width = _newWidth;
			_image.Height = _newHeight;
		}

		protected override void DoUnexecute()
		{
			_image.Width = _prevWidth;
			_image.Height = _prevHeight;
		}
	}
}

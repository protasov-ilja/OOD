namespace task1.DocumentEditor.Commands
{
	public class ReplaceTextCommand : AbstarctCommand
	{
		private string _newText = "";
		private string _prevText = "";
		private IReplacable _replacableObject;

		public ReplaceTextCommand(IReplacable replacableObject, string text)
		{
			_replacableObject = replacableObject;
			_newText = text;
		}

		protected override void DoExecute()
		{
			_prevText = _replacableObject.Text;
			_replacableObject.Text = _newText;
		}

		protected override void DoUnexecute()
		{
			_replacableObject.Text = _prevText;
		}
	}
}

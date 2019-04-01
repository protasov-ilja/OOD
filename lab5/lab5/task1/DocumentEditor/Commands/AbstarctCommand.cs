namespace task1.DocumentEditor.Commands
{
    public abstract class AbstarctCommand : ICommand
	{
		private bool _executed = false;

		public virtual void Delete()
		{
		}

		public void Execute()
		{
			if (!_executed)
			{
				DoExecute();
				_executed = true;
			}
		}

		public void Unexecute()
		{
			if (_executed)
			{
				DoUnexecute();
				_executed = false;
			}
		}

		protected abstract void DoExecute();
		protected abstract void DoUnexecute();
	}
}

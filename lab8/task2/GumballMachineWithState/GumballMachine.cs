namespace task2.GumballMachineWithState
{
	public sealed class GumballMachine : IGumballMachine
	{
		private IGumballMachineContext _gumballMachineContext;

		public GumballMachine(uint ballsNumber = 0)
		{
			_gumballMachineContext = new GumballMachineContext(ballsNumber);
		}

		public void EjectQuarters()
		{
			_gumballMachineContext.EjectQuarters();
		}

		public void InsertQuarter()
		{
			_gumballMachineContext.InsertQuarter();
		}

		public void Refill(uint numBalls)
		{
			_gumballMachineContext.Refill(numBalls);
		}

		public void TurnCrank()
		{
			_gumballMachineContext.TurnCrank();
		}
	}
}

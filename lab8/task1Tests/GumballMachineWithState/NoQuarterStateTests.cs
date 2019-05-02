using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.GumballMachineWithState.States;

namespace task1Tests.GumballMachineWithState
{
	[TestClass]
	public class NoQuarterStateTests
	{
		[TestMethod]
		public void SetMachineInHasQuarterStateWhenInsertQuarter()
		{
			var machine = new TestGumballMachine();
			var state = new NoQuarterState(machine);
			state.InsertQuarter();
			Assert.IsTrue(machine.HasQuarterState);
			Assert.IsFalse(machine.NoQuarterState);
			Assert.IsFalse(machine.SoldOutState);
			Assert.IsFalse(machine.SoldState);
		}
	}
}

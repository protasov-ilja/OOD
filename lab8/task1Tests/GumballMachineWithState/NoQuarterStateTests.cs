using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.GumballMachineWithState.States;
using task1Tests.GumballMachineWithState.Enums;

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
			Assert.AreEqual(machine.State, TestState.HasQuarter);
		}
	}
}

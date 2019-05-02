using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.GumballMachineWithState.States;

namespace task1Tests.GumballMachineWithState
{
	[TestClass]
	public class HasQuarterStateTests
	{
		[TestMethod]
		public void SetMachineInNoQuarterStateWhenEjectQuarter()
		{
			var machine = new TestGumballMachine();
			var state = new HasQuarterState(machine);
			state.EjectQuarter();
			Assert.IsTrue(machine.NoQuarterState);
			Assert.IsFalse(machine.HasQuarterState);
			Assert.IsFalse(machine.SoldOutState);
			Assert.IsFalse(machine.SoldState);
		}

		[TestMethod]
		public void SetMachineInSoldStateWhenTurnCrank()
		{
			var machine = new TestGumballMachine();
			var state = new HasQuarterState(machine);
			state.TurnCrank();
			Assert.IsTrue(machine.SoldState);
			Assert.IsFalse(machine.HasQuarterState);
			Assert.IsFalse(machine.NoQuarterState);
			Assert.IsFalse(machine.SoldOutState);
		}
	}
}

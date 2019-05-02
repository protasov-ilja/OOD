using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.GumballMachineWithState.States;

namespace task1Tests.GumballMachineWithState
{
	[TestClass]
	public class SoldStateTests
	{
		[TestMethod]
		public void SetGumballMachineInSoldOutStateIfCallDispenseWith1BallInMachine()
		{
			var machine = new TestGumballMachine();
			uint ballsAmount = 1;
			machine.BallsCount = ballsAmount;
			var state = new SoldState(machine);
			state.Dispense();
			Assert.AreEqual((uint)0, machine.BallsCount);
			Assert.IsTrue(machine.SoldOutState);
			Assert.IsFalse(machine.HasQuarterState);
			Assert.IsFalse(machine.NoQuarterState);
			Assert.IsFalse(machine.SoldState);
		}

		[TestMethod]
		public void SetGumballMachineInNoQuarterStateIfCallDispenseWithMoreThan1BallsInMachine()
		{
			var machine = new TestGumballMachine();
			uint ballsAmount = 2;
			machine.BallsCount = ballsAmount;
			var state = new SoldState(machine);
			state.Dispense();
			Assert.AreEqual((uint)1, machine.BallsCount);
			Assert.IsTrue(machine.NoQuarterState);
			Assert.IsFalse(machine.HasQuarterState);
			Assert.IsFalse(machine.SoldOutState);
			Assert.IsFalse(machine.SoldState);
		}
	}
}

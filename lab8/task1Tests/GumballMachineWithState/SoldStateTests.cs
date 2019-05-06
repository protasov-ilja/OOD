using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.GumballMachineWithState.States;
using task1Tests.GumballMachineWithState.Enums;

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
			Assert.AreEqual(machine.State, TestState.SoldOut);
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
			Assert.AreEqual(machine.State, TestState.NoQuarter);
		}
	}
}

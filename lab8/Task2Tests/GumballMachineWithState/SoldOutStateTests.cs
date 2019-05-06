using Microsoft.VisualStudio.TestTools.UnitTesting;
using task2.GumballMachineWithState.States;
using Task2Tests.Enums;

namespace Task2Tests.GumballMachineWithState
{
	[TestClass]
	public class SoldOutStateTests
	{
		[TestMethod]
		public void SetMachineInNoQuarterStateWhenRefillItWithMoreThan0Balls()
		{
			var machine = new TestGumballMachine();
			var state = new SoldOutState(machine);
			state.Refill(1);
			Assert.AreEqual(machine.GetBallCount(), (uint)1);
			Assert.AreEqual(machine.State, TestState.NoQuarter);
		}

		[TestMethod]
		public void StayMachineInSoldOutStateWhenRefillItWith0Balls()
		{
			var machine = new TestGumballMachine();
			var state = new SoldOutState(machine);
			machine.SetSoldOutState();
			state.Refill(0);
			Assert.AreEqual(machine.GetBallCount(), (uint)0);
			Assert.AreEqual(machine.State, TestState.SoldOut);
		}
	}
}

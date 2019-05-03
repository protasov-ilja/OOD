using Microsoft.VisualStudio.TestTools.UnitTesting;
using task2.GumballMachineWithState.States;

namespace Task2Tests.GumballMachineWithState
{
	[TestClass]
	public class NoQuarterStateTests
	{
		[TestMethod]
		public void StayMachineInNoQuarterStateWhenRefillIt()
		{
			{
				var machine = new TestGumballMachine();
				machine.SetNoQuarterState();
				machine.BallsCount = 1;
				var state = new NoQuarterState(machine);
				state.Refill(1);
				Assert.AreEqual(machine.GetBallCount(), (uint)2);
				Assert.IsTrue(machine.NoQuarterState);
				Assert.IsFalse(machine.HasQuarterState);
				Assert.IsFalse(machine.SoldOutState);
				Assert.IsFalse(machine.SoldState);
			}

			{
				var machine = new TestGumballMachine();
				machine.SetNoQuarterState();
				machine.BallsCount = 1;
				var state = new NoQuarterState(machine);
				state.Refill(0);
				Assert.AreEqual(machine.GetBallCount(), (uint)1);
				Assert.IsTrue(machine.NoQuarterState);
				Assert.IsFalse(machine.HasQuarterState);
				Assert.IsFalse(machine.SoldOutState);
				Assert.IsFalse(machine.SoldState);
			}
		}

		[TestMethod]
		public void SetMachineInHasQuarterStateWhenInsertQuarter()
		{
			var machine = new TestGumballMachine();
			var state = new NoQuarterState(machine);
			state.InsertQuarter();
			Assert.AreEqual(machine.GetQuartersController().GetQuartersCount(), (uint)1);
			Assert.IsTrue(machine.HasQuarterState);
			Assert.IsFalse(machine.NoQuarterState);
			Assert.IsFalse(machine.SoldOutState);
			Assert.IsFalse(machine.SoldState);
		}
	}
}

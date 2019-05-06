using Microsoft.VisualStudio.TestTools.UnitTesting;
using task2.GumballMachineWithState.States;
using Task2Tests.Enums;

namespace Task2Tests.GumballMachineWithState
{
	[TestClass]
	public class HasQuarterStateTests
	{
		[TestMethod]
		public void StayMachineInHasQuarterStateWhenRefillIt()
		{
			{
				var machine = new TestGumballMachine();
				machine.SetHasQuarterState();
				machine.BallsCount = 1;
				var state = new HasQuarterState(machine);
				state.Refill(1);
				Assert.AreEqual(machine.GetBallCount(), (uint)2);
				Assert.AreEqual(machine.State, TestState.HasQuarter);
			}

			{
				var machine = new TestGumballMachine();
				machine.SetHasQuarterState();
				machine.BallsCount = 1;
				var state = new HasQuarterState(machine);
				state.Refill(0);
				Assert.AreEqual(machine.GetBallCount(), (uint)1);
				Assert.AreEqual(machine.State, TestState.HasQuarter);
			}
		}

		[TestMethod]
		public void SetMachineInNoQuarterStateWhenEjectQuarters()
		{
			var machine = new TestGumballMachine();
			machine.GetQuartersController().InsertQuarter();
			var state = new HasQuarterState(machine);
			state.EjectQuarters();
			Assert.IsFalse(machine.GetQuartersController().HasQuarters());
			Assert.AreEqual(machine.State, TestState.NoQuarter);
		}

		[TestMethod]
		public void StayMachineInHasQuarterStateWhenInsertQuarter()
		{
			var machine = new TestGumballMachine();
			machine.SetHasQuarterState();
			machine.GetQuartersController().InsertQuarter();
			var state = new HasQuarterState(machine);
			state.InsertQuarter();
			Assert.IsTrue(machine.GetQuartersController().HasQuarters());
			Assert.AreEqual(machine.GetQuartersController().GetQuartersCount(), (uint)2);
			Assert.AreEqual(machine.State, TestState.HasQuarter);
		}

		[TestMethod]
		public void CantInsertMoreThan5Quarters()
		{
			var machine = new TestGumballMachine();
			machine.SetHasQuarterState();
			machine.GetQuartersController().InsertQuarter();
			var state = new HasQuarterState(machine);
			state.InsertQuarter();
			state.InsertQuarter();
			state.InsertQuarter();
			state.InsertQuarter();
			state.InsertQuarter();
			Assert.IsTrue(machine.GetQuartersController().HasQuarters());
			Assert.AreEqual(machine.GetQuartersController().GetQuartersCount(), (uint)5);
			Assert.AreEqual(machine.State, TestState.HasQuarter);
		}

		[TestMethod]
		public void SetMachineInSoldStateWhenTurnCrank()
		{
			var machine = new TestGumballMachine();
			var state = new HasQuarterState(machine);
			state.TurnCrank();
			Assert.AreEqual(machine.State, TestState.Sold);
		}
	}
}

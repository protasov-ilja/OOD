using Microsoft.VisualStudio.TestTools.UnitTesting;
using task2.GumballMachineWithState.States;

namespace Task2Tests.GumballMachineWithState
{
	[TestClass]
	public class SoldStateTests
	{
		[TestMethod]
		public void CantRefillMachine()
		{
			{
				var machine = new TestGumballMachine();
				machine.SetSoldState();
				machine.BallsCount = 1;
				var state = new SoldState(machine);
				state.Refill(1);
				Assert.AreEqual(machine.GetBallCount(), (uint)1);
				Assert.IsTrue(machine.SoldState);
				Assert.IsFalse(machine.NoQuarterState);
				Assert.IsFalse(machine.SoldOutState);
				Assert.IsFalse(machine.HasQuarterState);
			}

			{
				var machine = new TestGumballMachine();
				machine.SetSoldState();
				machine.BallsCount = 1;
				var state = new SoldState(machine);
				state.Refill(0);
				Assert.AreEqual(machine.GetBallCount(), (uint)1);
				Assert.IsTrue(machine.SoldState);
				Assert.IsFalse(machine.NoQuarterState);
				Assert.IsFalse(machine.SoldOutState);
				Assert.IsFalse(machine.HasQuarterState);
			}
		}

		[TestMethod]
		public void SetGumballMachineInSoldOutStateIfDispenseWith1BallAnd1QuarterInMachine()
		{
			var machine = new TestGumballMachine();
			uint ballsAmount = 1;
			machine.GetQuartersController().InsertQuarter();
			machine.BallsCount = ballsAmount;
			var state = new SoldState(machine);
			state.Dispense();
			Assert.AreEqual((uint)0, machine.BallsCount);
			Assert.IsFalse(machine.GetQuartersController().HasQuarters());
			Assert.IsTrue(machine.SoldOutState);
			Assert.IsFalse(machine.HasQuarterState);
			Assert.IsFalse(machine.NoQuarterState);
			Assert.IsFalse(machine.SoldState);
		}

		[TestMethod]
		public void SetGumballMachineInNoQuarterStateIfDispenseWithMoreThan1BallsAnd1QuarterInMachine()
		{
			var machine = new TestGumballMachine();
			machine.GetQuartersController().InsertQuarter();
			uint ballsAmount = 2;
			machine.BallsCount = ballsAmount;
			var state = new SoldState(machine);
			state.Dispense();
			Assert.IsFalse(machine.GetQuartersController().HasQuarters());
			Assert.AreEqual((uint)1, machine.BallsCount);
			Assert.IsTrue(machine.NoQuarterState);
			Assert.IsFalse(machine.HasQuarterState);
			Assert.IsFalse(machine.SoldOutState);
			Assert.IsFalse(machine.SoldState);
		}

		[TestMethod]
		public void SetGumballMachineInHasQuarterStateIfDispenseWithMoreThan1BallsAndMoreThan1QuarterInMachine()
		{
			var machine = new TestGumballMachine();
			machine.GetQuartersController().InsertQuarter();
			machine.GetQuartersController().InsertQuarter();
			uint ballsAmount = 2;
			machine.BallsCount = ballsAmount;
			var state = new SoldState(machine);
			state.Dispense();
			Assert.IsTrue(machine.GetQuartersController().HasQuarters());
			Assert.AreEqual(machine.GetQuartersController().GetQuartersCount(), (uint)1);
			Assert.AreEqual((uint)1, machine.BallsCount);
			Assert.IsTrue(machine.HasQuarterState);
			Assert.IsFalse(machine.NoQuarterState);
			Assert.IsFalse(machine.SoldOutState);
			Assert.IsFalse(machine.SoldState);
		}
	}
}

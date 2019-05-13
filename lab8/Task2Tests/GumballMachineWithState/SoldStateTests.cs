using Microsoft.VisualStudio.TestTools.UnitTesting;
using task2.GumballMachineNaive.Enums;
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
				Assert.AreEqual(machine.State, State.Sold);
			}

			{
				var machine = new TestGumballMachine();
				machine.SetSoldState();
				machine.BallsCount = 1;
				var state = new SoldState(machine);
				state.Refill(0);
				Assert.AreEqual(machine.GetBallCount(), (uint)1);
				Assert.AreEqual(machine.State, State.Sold);
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
			Assert.AreEqual(machine.State, State.SoldOut);
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
			Assert.AreEqual(machine.State, State.NoQuarter);
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
			Assert.AreEqual(machine.State, State.HasQuarter);
		}
	}
}

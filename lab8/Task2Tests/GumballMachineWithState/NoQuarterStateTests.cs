﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using task2.GumballMachineWithState.States;
using Task2Tests.Enums;

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
				Assert.AreEqual(machine.State, TestState.NoQuarter);
			}

			{
				var machine = new TestGumballMachine();
				machine.SetNoQuarterState();
				machine.BallsCount = 1;
				var state = new NoQuarterState(machine);
				state.Refill(0);
				Assert.AreEqual(machine.GetBallCount(), (uint)1);
				Assert.AreEqual(machine.State, TestState.NoQuarter);
			}
		}

		[TestMethod]
		public void SetMachineInHasQuarterStateWhenInsertQuarter()
		{
			var machine = new TestGumballMachine();
			var state = new NoQuarterState(machine);
			state.InsertQuarter();
			Assert.AreEqual(machine.GetQuartersController().GetQuartersCount(), (uint)1);
			Assert.AreEqual(machine.State, TestState.HasQuarter);
		}
	}
}

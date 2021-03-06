﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.GumballMachineWithState.States;
using task1Tests.GumballMachineWithState.Enums;

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
			Assert.AreEqual((Enums.State)machine.State, Enums.State.NoQuarter);
		}

		[TestMethod]
		public void SetMachineInSoldStateWhenTurnCrank()
		{
			var machine = new TestGumballMachine();
			var state = new HasQuarterState(machine);
			state.TurnCrank();
			Assert.AreEqual((Enums.State)machine.State, Enums.State.Sold);
		}
	}
}

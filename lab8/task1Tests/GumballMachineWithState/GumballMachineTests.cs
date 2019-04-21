using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.GumballMachineWithState;

namespace task1Tests.GumballMachineWithState
{
	[TestClass]
	public class GumballMachineTests
	{
		[TestMethod]
		public void CanCreateGumballMachineWithoutAddingGumballsInSoldOutState()
		{
			var strState = "sold out";
			var gumballs = 0;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanGetBallsCount()
		{
			GumballMachine gM = new GumballMachine();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
		}

		[TestMethod]
		public void CantReleaseBallIfGumballsCountIs0()
		{
			GumballMachine gM = new GumballMachine();
			gM.ReleaseBall();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
		}

		[TestMethod]
		public void CanSetNoQuarterState()
		{
			var strState = "waiting for quarter";
			var gumballs = 0;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine();
			gM.SetNoQuarterState();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanSetHasQuarterState()
		{
			var strState = "waiting for turn of crank";
			var gumballs = 0;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine();
			gM.SetHasQuarterState();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanSetSoldState()
		{
			var strState = "delivering a gumball";
			var gumballs = 0;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine();
			gM.SetSoldState();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantInsertQuarterInSoldOutState()
		{
			var strState = "sold out";
			var gumballs = 0;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine();
			gM.InsertQuarter();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantEjectQuarterInSoldOutState()
		{
			var strState = "sold out";
			var gumballs = 0;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine();
			gM.EjectQuarter();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantTurnCrankInSoldOutState()
		{
			var strState = "sold out";
			var gumballs = 0;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine();
			gM.TurnCrank();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanCreateGumballMachineWithAdding1GumballInNoQuarterState()
		{
			var strState = "waiting for quarter";
			var gumballs = 1;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumball Machine is {strState})";
			GumballMachine gM = new GumballMachine(1);
			Assert.AreEqual(gM.GetBallCount(), (uint)1);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanSetSoldOutState()
		{
			var strState = "sold out";
			var gumballs = 1;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumball Machine is {strState})";
			GumballMachine gM = new GumballMachine(1);
			gM.SetSoldOutState();
			Assert.AreEqual(gM.GetBallCount(), (uint)1);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanReleaseBallIfGumballsCountMoreThan0()
		{
			GumballMachine gM = new GumballMachine(1);
			Assert.AreEqual(gM.GetBallCount(), (uint)1);
			gM.ReleaseBall();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
		}

		[TestMethod]
		public void CanCreateGumballMachineWithAdding5GumballsInNoQuarterState()
		{
			var strState = "waiting for quarter";
			var gumballs = 5;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine(5);
			Assert.AreEqual(gM.GetBallCount(), (uint)5);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantTurnCrankInNoQuarterState()
		{
			var strState = "waiting for quarter";
			var gumballs = 5;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine(5);
			gM.TurnCrank();
			Assert.AreEqual(gM.GetBallCount(), (uint)5);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantEjectQuarterInNoQuarterState()
		{
			var strState = "waiting for quarter";
			var gumballs = 5;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine(5);
			gM.EjectQuarter();
			Assert.AreEqual(gM.GetBallCount(), (uint)5);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanInsertQuarterInGumballInNoQuarterStateAndGoToQuarterState()
		{
			var strState = "waiting for turn of crank";
			var gumballs = 5;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine(5);
			gM.InsertQuarter();
			Assert.AreEqual(gM.GetBallCount(), (uint)5);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanEjectQuarterInGumballInHasQuarterStateAndGoToNoQuarterState()
		{
			var strState = "waiting for quarter";
			var gumballs = 5;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine(5);
			gM.InsertQuarter();
			gM.EjectQuarter();
			Assert.AreEqual(gM.GetBallCount(), (uint)5);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantInsertQuarternGumballInHasQuarterState()
		{
			var strState = "waiting for turn of crank";
			var gumballs = 5;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine(5);
			gM.InsertQuarter();
			gM.InsertQuarter();
			Assert.AreEqual(gM.GetBallCount(), (uint)5);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanTurnCrankInHasQuarterStateAndGoToNoQuarterStateIfAmountOfGumballsBeforeTurningCrankMoreThan1()
		{
			var strState = "waiting for quarter";
			var gumballs = 1;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumball Machine is {strState})";
			GumballMachine gM = new GumballMachine(2);
			gM.InsertQuarter();
			gM.TurnCrank();
			Assert.AreEqual(gM.GetBallCount(), (uint)1);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanTurnCrankInHasQuarterStateAndGoToNoQuarterStateIfAmountOfGumballsIs1BeforeTurningCrank()
		{
			var strState = "sold out";
			var gumballs = 0;
			var testStr = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: {gumballs} gumballs Machine is {strState})";
			GumballMachine gM = new GumballMachine(1);
			gM.InsertQuarter();
			gM.TurnCrank();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}
	}
}

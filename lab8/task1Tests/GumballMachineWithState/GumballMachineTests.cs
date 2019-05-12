using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.GumballMachineWithState;

namespace task1Tests.GumballMachineWithState
{
	[TestClass]
	public class GumballMachineTests
	{
		private string GetGumballMachineTestParsedString(uint gumballs, string strState)
		{
			return $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: { gumballs  } gumball{ (gumballs == 1 ? "" : "s") } Machine is {strState})";
		}

		[TestMethod]
		public void CanCreateGumballMachineWithoutAddingGumballsInSoldOutState()
		{
			var strState = "sold out";
			uint gumballs = 0;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanGetBallsCount()
		{
			var gM = new GumballMachineContext();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
		}

		[TestMethod]
		public void CantReleaseBallIfGumballsCountIs0()
		{
			var gM = new GumballMachineContext();
			gM.ReleaseBall();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
		}

		[TestMethod]
		public void CanSetNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 0;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext();
			gM.SetNoQuarterState();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanSetHasQuarterState()
		{
			var strState = "waiting for turn of crank";
			uint gumballs = 0;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext();
			gM.SetHasQuarterState();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanSetSoldState()
		{
			var strState = "delivering a gumball";
			uint gumballs = 0;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext();
			gM.SetSoldState();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantInsertQuarterInSoldOutState()
		{
			var strState = "sold out";
			uint gumballs = 0;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext();
			gM.InsertQuarter();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantEjectQuarterInSoldOutState()
		{
			var strState = "sold out";
			uint gumballs = 0;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext();
			gM.EjectQuarter();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantTurnCrankInSoldOutState()
		{
			var strState = "sold out";
			uint gumballs = 0;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext();
			gM.TurnCrank();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanCreateGumballMachineWithAdding1GumballInNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 1;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(1);
			Assert.AreEqual(gM.GetBallCount(), (uint)1);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanSetSoldOutState()
		{
			var strState = "sold out";
			uint gumballs = 1;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(1);
			gM.SetSoldOutState();
			Assert.AreEqual(gM.GetBallCount(), (uint)1);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanReleaseBallIfGumballsCountMoreThan0()
		{
			var gM = new GumballMachineContext(1);
			Assert.AreEqual(gM.GetBallCount(), (uint)1);
			gM.ReleaseBall();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
		}

		[TestMethod]
		public void CanCreateGumballMachineWithAdding5GumballsInNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 5;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(5);
			Assert.AreEqual(gM.GetBallCount(), (uint)5);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantTurnCrankInNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 5;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(5);
			gM.TurnCrank();
			Assert.AreEqual(gM.GetBallCount(), (uint)5);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantEjectQuarterInNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 5;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(5);
			gM.EjectQuarter();
			Assert.AreEqual(gM.GetBallCount(), (uint)5);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanInsertQuarterInGumballInNoQuarterStateAndGoToQuarterState()
		{
			var strState = "waiting for turn of crank";
			uint gumballs = 5;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(5);
			gM.InsertQuarter();
			Assert.AreEqual(gM.GetBallCount(), (uint)5);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanEjectQuarterInGumballInHasQuarterStateAndGoToNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 5;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(5);
			gM.InsertQuarter();
			gM.EjectQuarter();
			Assert.AreEqual(gM.GetBallCount(), (uint)5);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantInsertQuarternGumballInHasQuarterState()
		{
			var strState = "waiting for turn of crank";
			uint gumballs = 5;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(5);
			gM.InsertQuarter();
			gM.InsertQuarter();
			Assert.AreEqual(gM.GetBallCount(), (uint)5);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanTurnCrankInHasQuarterStateAndGoToNoQuarterStateIfAmountOfGumballsBeforeTurningCrankMoreThan1()
		{
			var strState = "waiting for quarter";
			uint gumballs = 1;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(2);
			gM.InsertQuarter();
			gM.TurnCrank();
			Assert.AreEqual(gM.GetBallCount(), (uint)1);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanTurnCrankInHasQuarterStateAndGoToNoQuarterStateIfAmountOfGumballsIs1BeforeTurningCrank()
		{
			var strState = "sold out";
			uint gumballs = 0;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(1);
			gM.InsertQuarter();
			gM.TurnCrank();
			Assert.AreEqual(gM.GetBallCount(), (uint)0);
			Assert.AreEqual(gM.ToString(), testStr);
		}
	}
}

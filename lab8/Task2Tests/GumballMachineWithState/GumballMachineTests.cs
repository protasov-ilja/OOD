using Microsoft.VisualStudio.TestTools.UnitTesting;
using task2.GumballMachineWithState;

namespace Task2Tests.GumballMachineWithState
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
		public void CanCreateGumballMachineWithAdding1GumballInNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 1;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(gumballs);
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanCreateGumballMachineWithAddingMoreThan1GumballsInNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 2;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(gumballs);
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanRefillGumballMachineWithAdding0GumballsInSoldOutState()
		{
			var strState = "sold out";
			uint gumballs = 0;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(gumballs);
			gM.Refill(0);
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanRefillGumballMachineWithAddingMoreThan0GumballsInSoldOutStateAndMoveToNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 1;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext();
			gM.Refill(gumballs);
			Assert.AreEqual(gM.GetBallCount(), gumballs);
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
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantEjectQuartersInSoldOutState()
		{
			var strState = "sold out";
			uint gumballs = 0;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext();
			gM.EjectQuarters();
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanRefillGumballMachineWithAdding0GumballsInNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 1;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(gumballs);
			gM.Refill(0);
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanRefillGumballMachineWithAddingMoreThan0GumballsInNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 2;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(1);
			gM.Refill(1);
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantEjectQuartersInNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 2;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(gumballs);
			gM.EjectQuarters();
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanInsertQuarterInNoQuarterStateAndMoveToHasQuarterState()
		{
			var strState = "waiting for turn of crank";
			uint gumballs = 1;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(gumballs);
			gM.InsertQuarter();
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanInsertQuarterInHasQuarterState()
		{
			var strState = "waiting for turn of crank";
			uint gumballs = 1;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(gumballs);
			gM.InsertQuarter();
			gM.InsertQuarter();
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanEjectAllQuartersInHasQuarterStateAndMoveToNoQuarterState()
		{
			var strState = "waiting for quarter";
			uint gumballs = 1;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(gumballs);
			gM.InsertQuarter();
			gM.InsertQuarter();
			gM.EjectQuarters();
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CantInsertMoreThan5Quarters()
		{
			uint gumballs = 1;
			var gM = new GumballMachineContext(gumballs);
			gM.InsertQuarter();
			gM.InsertQuarter();
			gM.InsertQuarter();
			gM.InsertQuarter();
			gM.InsertQuarter();
			gM.InsertQuarter();
			Assert.AreEqual(gM.GetQuartersController().GetQuartersCount(), (uint)5);
		}

		[TestMethod]
		public void CanRefillMachineInHasQuarterState()
		{
			var strState = "waiting for turn of crank";
			uint gumballs = 2;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(1);
			gM.InsertQuarter();
			gM.Refill(1);
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanInsertQuarterTurnCrankInHasQuarterStateAndDespenseBallAndMovetoNoQuarterStateIfBallsMoreThan0()
		{
			var strState = "waiting for quarter";
			uint gumballs = 1;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(2);
			gM.InsertQuarter();
			gM.TurnCrank();
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanInsertQuarterTurnCrankInHasQuarterStateAndDespenseBallAndMovetoSoldOutStateIfBalls0()
		{
			var strState = "sold out";
			uint gumballs = 0;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(1);
			gM.InsertQuarter();
			gM.TurnCrank();
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanInsert2QuartersTurnCrankInHasQuarterStateAndDespenseBallAndMovetoHasQuarterStateIfBallsMoreThan0()
		{
			var strState = "waiting for turn of crank";
			uint gumballs = 1;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(2);
			gM.InsertQuarter();
			gM.InsertQuarter();
			gM.TurnCrank();
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
		}

		[TestMethod]
		public void CanInsert2QuartersTurnCrankInHasQuarterStateAndDespenseBallAndMoveToSoldOutStateIfBalls0AndReturnQuarters()
		{
			var strState = "sold out";
			uint gumballs = 0;
			var testStr = GetGumballMachineTestParsedString(gumballs, strState);
			var gM = new GumballMachineContext(1);
			gM.InsertQuarter();
			gM.InsertQuarter();
			gM.TurnCrank();
			Assert.AreEqual(gM.GetBallCount(), gumballs);
			Assert.AreEqual(gM.ToString(), testStr);
			Assert.AreEqual(gM.GetQuartersController().GetQuartersCount(), (uint)0);
		}
	}
}

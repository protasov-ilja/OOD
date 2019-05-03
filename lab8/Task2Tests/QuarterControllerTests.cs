using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using task2.Utils;

namespace Task2Tests
{
	[TestClass]
	public class QuarterControllerTests
	{
		[TestMethod]
		public void CanCreateQuartersControllerWithLimit5AndAddQuarterInIt()
		{
			uint maxLimit = 5;
			var qC = new QuartersController(maxLimit);
			Assert.AreEqual(qC.GetQuartersCount(), (uint)0);
			qC.InsertQuarter();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)1);
			Assert.IsTrue(qC.HasQuarters());
		}

		[TestMethod]
		public void CanInsertMoreThan1QuartersAndLessThanMaxQuarterLimit5()
		{
			uint maxLimit = 5;
			var qC = new QuartersController(maxLimit);
			Assert.AreEqual(qC.GetQuartersCount(), (uint)0);
			qC.InsertQuarter();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)1);
			qC.InsertQuarter();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)2);
			qC.InsertQuarter();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)3);
			qC.InsertQuarter();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)4);
			qC.InsertQuarter();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)5);
		}

		[TestMethod]
		public void CantInsertMoreThanMaxLimit5AndThrowException()
		{
			uint maxLimit = 5; 
			var qC = new QuartersController(maxLimit);
			Assert.AreEqual(qC.GetQuartersCount(), (uint)0);
			qC.InsertQuarter();
			qC.InsertQuarter();
			qC.InsertQuarter();
			qC.InsertQuarter();
			qC.InsertQuarter();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)5);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => qC.InsertQuarter());
		}

		[TestMethod]
		public void CanEjectAllQuartersIfQuartersCountMoreThan0()
		{
			uint maxLimit = 5;
			var qC = new QuartersController(maxLimit);
			Assert.AreEqual(qC.GetQuartersCount(), (uint)0);
			qC.InsertQuarter();
			qC.InsertQuarter();
			qC.InsertQuarter();
			qC.InsertQuarter();
			qC.InsertQuarter();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)5);
			qC.EjectQuarters();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)0);
			qC.InsertQuarter();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)1);
			qC.EjectQuarters();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)0);
		}

		[TestMethod]
		public void CantEjectAllQuartersIfQuartersCount0AndThrowException()
		{
			uint maxLimit = 5;
			var qC = new QuartersController(maxLimit);
			Assert.AreEqual(qC.GetQuartersCount(), (uint)0);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => qC.EjectQuarters());
		}

		[TestMethod]
		public void CanUseQuarterIfQuartersCountMoreThan0()
		{
			uint maxLimit = 5;
			var qC = new QuartersController(maxLimit);
			Assert.AreEqual(qC.GetQuartersCount(), (uint)0);
			qC.InsertQuarter();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)1);
			qC.UseQuarter();
			Assert.AreEqual(qC.GetQuartersCount(), (uint)0);
		}

		[TestMethod]
		public void CantUseQuarterIfQuartersCount0AndThrowException()
		{
			uint maxLimit = 5;
			var qC = new QuartersController(maxLimit);
			Assert.AreEqual(qC.GetQuartersCount(), (uint)0);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => qC.UseQuarter());
		}
	}
}

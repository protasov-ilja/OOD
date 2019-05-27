using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab9._1.ChartDrawer.Models;
using System;

namespace lab9Tests.ChartDrawer
{
	[TestClass]
	public sealed class MainWindowTests
	{
		[TestMethod]
		public void CanAddNewHarmonicAndThenInvokeHarmonicAddedAndActiveChangedEvents()
		{
			var testObj = new TestObject();
			var main = new HarmonicsManager();
			main.HarmonicAdded += testObj.OnHarmonicAdded;
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;

			var h = new Harmonic();
			main.AddNewHarmonic(h);

			Assert.IsTrue(testObj.IsEventHarmonicAddedInvoked);
			Assert.AreEqual(testObj.addedIndex, 0);
			Assert.IsTrue(testObj.IsEventActiveHarmonicChangedInvoked);
			Assert.AreEqual(testObj.activeIndex, 0);
		}

		[TestMethod]
		public void CanSelectHarmonicByIndexAndThenInvokeActiveHarmonicChangedEvent()
		{
			var testObj = new TestObject();
			var main = new HarmonicsManager();
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.SelectHarmonicByIndex(0);

			Assert.IsTrue(testObj.IsEventActiveHarmonicChangedInvoked);
			Assert.AreEqual(testObj.activeIndex, 0);
		}

		[TestMethod]
		public void CantSelectHarmonicByIndexAndIfIndexLessThan0OrEqualsOrMoreThanCountAndThrowsException()
		{
			var testObj = new TestObject();
			var main = new HarmonicsManager();
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.SelectHarmonicByIndex(0);

			Assert.ThrowsException<IndexOutOfRangeException>(() => main.SelectHarmonicByIndex(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.SelectHarmonicByIndex(1));
		}

		[TestMethod]
		public void CanRemovedHarmonicByIndexAndThenInvokeHarmonicDeltedAndActiveHarmonicsChangedEvents()
		{
			var testObj = new TestObject();
			var main = new HarmonicsManager();
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.HarmonicDeleted += testObj.OnHarmonicDeleted;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.DeleteHarmonicByIndex(0);

			Assert.IsTrue(testObj.IsEventHarmonicDeletedInvoked);
			Assert.AreEqual(testObj.deltedIndex, 0);

			Assert.IsTrue(testObj.IsEventActiveHarmonicChangedInvoked);
			Assert.AreEqual(testObj.activeIndex, -1);
			Assert.AreEqual(main.GetAllHarmonics().Count, 0);
		}

		[TestMethod]
		public void CanRemovedFirstHarmonicInNotEmptyListHarmonicByIndexAndIfSetAfterThanNotEmptyThenInvokeHarmonicDeltedAndActiveHarmonicsChangedEvents()
		{
			var testObj = new TestObject();
			var main = new HarmonicsManager();
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.HarmonicDeleted += testObj.OnHarmonicDeleted;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.AddNewHarmonic(h);
			main.DeleteHarmonicByIndex(0);

			Assert.IsTrue(testObj.IsEventHarmonicDeletedInvoked);
			Assert.AreEqual(testObj.deltedIndex, 0);

			Assert.IsTrue(testObj.IsEventActiveHarmonicChangedInvoked);
			Assert.AreEqual(testObj.activeIndex, 0);
			Assert.AreEqual(main.GetAllHarmonics().Count, 1);
		}

		[TestMethod]
		public void CanRemovedNotFistHarmonicInNotEmptyListByIndexAndIfSetAfterThanNotEmptyThenInvokeHarmonicDeltedAndActiveHarmonicsChangedEvents()
		{
			var testObj = new TestObject();
			var main = new HarmonicsManager();
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.HarmonicDeleted += testObj.OnHarmonicDeleted;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.AddNewHarmonic(h);
			main.DeleteHarmonicByIndex(1);

			Assert.IsTrue(testObj.IsEventHarmonicDeletedInvoked);
			Assert.AreEqual(testObj.deltedIndex, 1);

			Assert.IsTrue(testObj.IsEventActiveHarmonicChangedInvoked);
			Assert.AreEqual(testObj.activeIndex, 0);
			Assert.AreEqual(main.GetAllHarmonics().Count, 1);
		}

		[TestMethod]
		public void CantRemovedHarmonicFromNotEmptyListAndByIndexIfIndexLessThen0AndMoreEqualesThanCountAndThrowException()
		{
			var testObj = new TestObject();
			var main = new HarmonicsManager();
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.HarmonicDeleted += testObj.OnHarmonicDeleted;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.DeleteHarmonicByIndex(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.DeleteHarmonicByIndex(1));
		}

		[TestMethod]
		public void CantRemovedHarmonicFromEmptyListByIndexIfCount0AndThrowException()
		{
			var testObj = new TestObject();
			var main = new HarmonicsManager();
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.HarmonicDeleted += testObj.OnHarmonicDeleted;
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.DeleteHarmonicByIndex(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.DeleteHarmonicByIndex(1));
		}
	}
}

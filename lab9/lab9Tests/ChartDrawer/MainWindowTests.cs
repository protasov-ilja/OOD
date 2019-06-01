using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab9._1.ChartDrawer.Models;
using System;

namespace lab9Tests.ChartDrawer
{
	[TestClass]
	public sealed class MainWindowTests
	{
		[TestMethod]
		public void CanAddNewHarmonicAndThenInvokeHarmonicAddedAndActiveHarmonicChangedEvents()
		{
			var testObj = new TestObject();
			var main = new HarmonicsContainer();
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
			var main = new HarmonicsContainer();
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.SelectHarmonicByIndex(0);

			Assert.IsTrue(testObj.IsEventActiveHarmonicChangedInvoked);
			Assert.AreEqual(testObj.activeIndex, 0);
		}

		[TestMethod]
		public void CantSelectHarmonicByIndexFromNonEmptyListIfIndexLessThan0OrEqualsToOrMoreThanCountAndThrowsException()
		{
			var testObj = new TestObject();
			var main = new HarmonicsContainer();
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.SelectHarmonicByIndex(0);

			Assert.ThrowsException<IndexOutOfRangeException>(() => main.SelectHarmonicByIndex(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.SelectHarmonicByIndex(1));
		}


		[TestMethod]
		public void CantSelectHarmonicByIndexFromEmptyListAndThrowsException()
		{
			var testObj = new TestObject();
			var main = new HarmonicsContainer();
			var h = new Harmonic();
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.SelectHarmonicByIndex(0));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.SelectHarmonicByIndex(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.SelectHarmonicByIndex(1));
		}

		[TestMethod]
		public void CanRemoveHarmonicByIndexAndThenInvokeHarmonicDeltedAndActiveHarmonicChangedEvents()
		{
			var testObj = new TestObject();
			var main = new HarmonicsContainer();
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.HarmonicDeleted += testObj.OnHarmonicDeleted;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.DeleteHarmonicByIndex(0);

			Assert.IsTrue(testObj.IsEventHarmonicDeletedInvoked);
			Assert.AreEqual(testObj.deltedIndex, 0);

			Assert.IsTrue(testObj.IsEventActiveHarmonicChangedInvoked);
			Assert.AreEqual(testObj.activeIndex, -1);
			Assert.IsTrue(main.IsEmpty());
		}

		[TestMethod]
		public void CanRemoveFirstHarmonicFromNonEmptyListByIndexAndThenInvokeHarmonicDeltedAndActiveHarmonicsChangedEventsIfListAfterThatNotEmpty()
		{
			var testObj = new TestObject();
			var main = new HarmonicsContainer();
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
			Assert.IsFalse(main.IsEmpty());
		}

		[TestMethod]
		public void CanRemoveNotFirstHarmonicFromNonEmptyListByIndexAndThenInvokeHarmonicDeletedAndActiveHarmonicsChangedEventsIfListAfterThatNotEmpty()
		{
			var testObj = new TestObject();
			var main = new HarmonicsContainer();
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
			Assert.IsFalse(main.IsEmpty());
		}

		[TestMethod]
		public void SaveHarmonicsContainerInValidStateWhenItstateHasChangedSinceHarmonicDeletedEvent()
		{
			var main = new HarmonicsContainer();
			var testObj = new TestObject(main);
			var newActiveIndex = 2;
			testObj.newActiveIndex = newActiveIndex;

			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.HarmonicDeleted += testObj.ChangeHarmonicSelectedIndexOnHarmonicDeleted;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.AddNewHarmonic(h);
			main.AddNewHarmonic(h);
			main.DeleteHarmonicByIndex(2);

			Assert.IsTrue(testObj.IsEventHarmonicDeletedInvoked);
			Assert.AreEqual(testObj.deltedIndex, 2);

			Assert.IsTrue(testObj.ExceptionWasThrownInSelectActiveHarmonicMethod);

			Assert.IsTrue(testObj.IsEventActiveHarmonicChangedInvoked);
			Assert.AreEqual(testObj.activeIndex, 1);
			Assert.IsFalse(main.IsEmpty());
		}

		[TestMethod]
		public void CantRemoveHarmonicFromNotEmptyListByIndexIfIndexLessThen0OrEqualesOrMoreThanCountAndThrowsException()
		{
			var testObj = new TestObject();
			var main = new HarmonicsContainer();
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.HarmonicDeleted += testObj.OnHarmonicDeleted;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.DeleteHarmonicByIndex(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.DeleteHarmonicByIndex(1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.DeleteHarmonicByIndex(2));
		}

		[TestMethod]
		public void CantRemoveHarmonicFromEmptyListByIndexAndThrowException()
		{
			var testObj = new TestObject();
			var main = new HarmonicsContainer();
			main.ActiveHarmonicChanged += testObj.OnActiveHarmonicChanged;
			main.HarmonicDeleted += testObj.OnHarmonicDeleted;
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.DeleteHarmonicByIndex(0));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.DeleteHarmonicByIndex(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.DeleteHarmonicByIndex(1));
		}

		[TestMethod]
		public void CanGetHarmonicFromNonEmptyListByIndexAndReturnHarmonic()
		{
			var testObj = new TestObject();
			var main = new HarmonicsContainer();
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			var h1 = main.GetHarmonicByIndex(0);

			Assert.AreEqual(h1, h);
		}

		[TestMethod]
		public void CantGetHarmonicFromEmptyListByIndexAndThrowsException()
		{
			var testObj = new TestObject();
			var main = new HarmonicsContainer();
			var h = new Harmonic();

			Assert.ThrowsException<IndexOutOfRangeException>(() => main.GetHarmonicByIndex(0));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.GetHarmonicByIndex(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.GetHarmonicByIndex(1));
		}

		[TestMethod]
		public void CantGetHarmonicFromNonEmptyListByIndexIfIndexLessThan0OrEqualsOrMoreThanCountAndThrowsException()
		{
			var testObj = new TestObject();
			var main = new HarmonicsContainer();
			var h = new Harmonic();
			main.AddNewHarmonic(h);

			Assert.ThrowsException<IndexOutOfRangeException>(() => main.GetHarmonicByIndex(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.GetHarmonicByIndex(1));
		}
	}
}

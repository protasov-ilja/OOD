using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab9._1.ChartDrawer.Models;
using System;
using lab9._1.ChartDrawer.Models.Enums;

namespace lab9Tests.ChartDrawer
{
	[TestClass]
	public sealed class MainWindowTests
	{
		[TestMethod]
		public void CanAddNewHarmonicAndThenInvokeHarmonicsChangedEvent()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.HarmonicsChanged += testObj.OnHarmonicsChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);

			Assert.IsTrue(testObj.IsEventHarmonicsChangedInvoked);
			Assert.AreEqual(testObj.Harmonics.Count, 1);
		}

		[TestMethod]
		public void CanGetHarmonicByIdAndThenInvokeSelectedHarmonicChangedEvent()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.SelectedHarmonicChanged += testObj.OnSelectedHarmonicChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.GetHarmonicById(0);

			Assert.IsTrue(testObj.IsEventHarmonicChangedInvoked);
			Assert.AreEqual(h, testObj.SelectedHarmonic);
		}

		[TestMethod]
		public void CantGetHarmonicByIdAndIfIndexLessThan0OrEqualsOrMoreThanCountAndThrowsException()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.SelectedHarmonicChanged += testObj.OnSelectedHarmonicChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.GetHarmonicById(0);

			Assert.ThrowsException<IndexOutOfRangeException>(() => main.GetHarmonicById(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.GetHarmonicById(1));
		}

		[TestMethod]
		public void CanRemovedHarmonicByIdAndThenInvokeHarmonicsChangedEvent()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.HarmonicsChanged += testObj.OnHarmonicsChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.DeleteHarmonicById(0);

			Assert.IsTrue(testObj.IsEventHarmonicsChangedInvoked);
			Assert.AreEqual(testObj.Harmonics.Count, 0);
		}

		[TestMethod]
		public void CantRemovedHarmonicByIdIfIdLessThen0AndMoreEqualesThanCountAndThrowException()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.HarmonicsChanged += testObj.OnHarmonicsChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.DeleteHarmonicById(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.DeleteHarmonicById(1));
		}

		[TestMethod]
		public void CanChangeHarmonicAmplitudeByIdAndThenInvokeHarmonicsChangedEvent()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.HarmonicsChanged += testObj.OnHarmonicsChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.ChangeSelectedHarmonicAmplitude(0, 3);

			Assert.IsTrue(testObj.IsEventHarmonicsChangedInvoked);
			Assert.AreEqual(testObj.Harmonics.Count, 1);
			Assert.AreEqual(h.Amplitude, 3);
		}

		[TestMethod]
		public void CantChangeHarmonicAmplitudeByIdIfIdLessThen0AndMoreEqualesThanCountAndThrowException()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.HarmonicsChanged += testObj.OnHarmonicsChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.ChangeSelectedHarmonicAmplitude(-1, 3));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.ChangeSelectedHarmonicAmplitude(1, 3));
		}

		[TestMethod]
		public void CanChangeHarmonicFrequencyByIdAndThenInvokeHarmonicsChangedEvent()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.HarmonicsChanged += testObj.OnHarmonicsChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.ChangeSelectedHarmonicFrequency(0, 3);

			Assert.IsTrue(testObj.IsEventHarmonicsChangedInvoked);
			Assert.AreEqual(testObj.Harmonics.Count, 1);
			Assert.AreEqual(h.Frequency, 3);
		}

		[TestMethod]
		public void CantChangeHarmonicFrequencyByIdIfIdLessThen0AndMoreEqualesThanCountAndThrowException()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.HarmonicsChanged += testObj.OnHarmonicsChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.ChangeSelectedHarmonicFrequency(-1, 3));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.ChangeSelectedHarmonicFrequency(1, 3));
		}

		[TestMethod]
		public void CanChangeHarmonicPhaseByIdAndThenInvokeHarmonicsChangedEvent()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.HarmonicsChanged += testObj.OnHarmonicsChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.ChangeSelectedHarmonicPhase(0, 3);

			Assert.IsTrue(testObj.IsEventHarmonicsChangedInvoked);
			Assert.AreEqual(testObj.Harmonics.Count, 1);
			Assert.AreEqual(h.Phase, 3);
		}

		[TestMethod]
		public void CantChangeHarmonicPhaseByIdIfIdLessThen0AndMoreEqualesThanCountAndThrowException()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.HarmonicsChanged += testObj.OnHarmonicsChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.ChangeSelectedHarmonicPhase(-1, 3));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.ChangeSelectedHarmonicPhase(1, 3));
		}

		[TestMethod]
		public void CanChangeHarmonicTypeByIdAndThenInvokeHarmonicsChangedEvent()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.HarmonicsChanged += testObj.OnHarmonicsChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			main.ChangeSelectedHarmonicType(0, HarmonicType.Cos);

			Assert.IsTrue(testObj.IsEventHarmonicsChangedInvoked);
			Assert.AreEqual(testObj.Harmonics.Count, 1);
			Assert.AreEqual(h.Type, HarmonicType.Cos);
		}

		[TestMethod]
		public void CantChangeHarmonicTypeByIdIfIdLessThen0AndMoreEqualesThanCountAndThrowException()
		{
			var testObj = new TestObject();
			var main = new MainWindow();
			main.HarmonicsChanged += testObj.OnHarmonicsChanged;
			var h = new Harmonic();
			main.AddNewHarmonic(h);
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.ChangeSelectedHarmonicType(-1, HarmonicType.Cos));
			Assert.ThrowsException<IndexOutOfRangeException>(() => main.ChangeSelectedHarmonicType(1, HarmonicType.Cos));
		}
	}
}

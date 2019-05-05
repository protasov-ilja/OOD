using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFML.Graphics;
using task1.Composite.Styles;

namespace task1Tests.Styles
{
	[TestClass]
	public class OutlineStyleTests
	{
		[TestMethod]
		public void CanCreateSimpleOutlineStyleWithEnambleStyle()
		{
			var s = new OutlineStyle(Color.Red, true, 2);

			Assert.AreEqual(s.GetColor(), Color.Red);
			Assert.AreEqual(s.LineThickness, 2);
			Assert.IsTrue(s.IsEnabled().Value);
			Assert.IsFalse(s.IsComposite());
		}

		[TestMethod]
		public void CanCreateSimpleOutlineStyleWithLineThickness1ByDefault()
		{
			var s = new OutlineStyle(Color.Red, true);

			Assert.AreEqual(s.GetColor(), Color.Red);
			Assert.AreEqual(s.LineThickness, 1);
			Assert.IsTrue(s.IsEnabled().Value);
			Assert.IsFalse(s.IsComposite());
		}

		[TestMethod]
		public void CanCreateSimpleOutlineStyleWithDisableStyleAndReturnTransparentColor()
		{
			var s = new OutlineStyle(Color.Red, false);

			Assert.AreEqual(s.GetColor(), Color.Transparent);
			Assert.AreEqual(s.LineThickness, 1);
			Assert.IsFalse(s.IsEnabled().Value);
			Assert.IsFalse(s.IsComposite());
		}

		[TestMethod]
		public void CanChangeSimpleStyleColor()
		{
			var s = new OutlineStyle(Color.Red, true);

			Assert.AreEqual(s.GetColor(), Color.Red);
			Assert.AreEqual(s.LineThickness, 1);
			Assert.IsTrue(s.IsEnabled().Value);
			Assert.IsFalse(s.IsComposite());

			s.SetColor(Color.Green);
			Assert.AreEqual(s.GetColor(), Color.Green);
			Assert.IsTrue(s.IsEnabled().Value);
		}

		[TestMethod]
		public void CanEnableSimpleStyle()
		{
			var s = new OutlineStyle(Color.Red, false);

			Assert.AreEqual(s.GetColor(), Color.Transparent);
			Assert.AreEqual(s.LineThickness, 1);
			Assert.IsFalse(s.IsEnabled().Value);
			Assert.IsFalse(s.IsComposite());

			s.Enable(true);
			Assert.AreEqual(s.GetColor(), Color.Red);
			Assert.IsTrue(s.IsEnabled().Value);
		}
	}
}

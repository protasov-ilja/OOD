using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFML.Graphics;
using task1.Composite.Styles;

namespace task1Tests
{
	[TestClass]
	public class FillStyleTests
	{
		[TestMethod]
		public void CanCreateSimpleFillStyleWithEnambleStyle()
		{
			var s = new FillStyle(Color.Red, true);

			Assert.AreEqual(s.GetColor(), Color.Red);
			Assert.IsTrue(s.IsEnabled().Value);
			Assert.IsFalse(s.IsComposite());
		}

		[TestMethod]
		public void CanCreateSimpleFillStyleWithDisambleStyleAndReturnTransparentColor()
		{
			var s = new FillStyle(Color.Red, false);

			Assert.AreEqual(s.GetColor(), Color.Transparent);
			Assert.IsFalse(s.IsEnabled().Value);
			Assert.IsFalse(s.IsComposite());
		}

		[TestMethod]
		public void CanChangeSimpleStyleColor()
		{
			var s = new FillStyle(Color.Red, true);

			Assert.AreEqual(s.GetColor(), Color.Red);
			Assert.IsTrue(s.IsEnabled().Value);
			Assert.IsFalse(s.IsComposite());

			s.SetColor(Color.Green);
			Assert.AreEqual(s.GetColor(), Color.Green);
			Assert.IsTrue(s.IsEnabled().Value);
		}

		[TestMethod]
		public void CanEnableSimpleStyle()
		{
			var s = new FillStyle(Color.Red, false);

			Assert.AreEqual(s.GetColor(), Color.Transparent);
			Assert.IsFalse(s.IsEnabled().Value);
			Assert.IsFalse(s.IsComposite());

			s.Enable(true);
			Assert.AreEqual(s.GetColor(), Color.Red);
			Assert.IsTrue(s.IsEnabled().Value);
		}
	}
}

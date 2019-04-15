using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFML.Graphics;
using task1;
using task1.Composite;
using task1.Shapes;

namespace task1Tests
{
	[TestClass]
	public class GroupTests
    {
		[TestMethod]
		public void CanCreateEmptyGroupOnSlide()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var group = new Group(oStyle, fStyle, 1);

			Assert.AreEqual(1, group.LineThickness);
			Assert.AreEqual(oStyle, group.OutlineStyle);
			Assert.AreEqual(fStyle, group.FillStyle);
		}

		[TestMethod]
		public void CanCreateEmptyGroupAndAddRectangleInIt()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var group = new Group(oStyle, fStyle, 1);

			var rect = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, oStyle, fStyle, 1);
			group.InsertShape(rect, 0);
			Assert.AreEqual(rect.Frame, group.Frame);
			Assert.AreEqual(1, group.LineThickness);
			Assert.AreEqual(rect.OutlineStyle, group.OutlineStyle);
			Assert.AreEqual(rect.FillStyle, group.FillStyle);
		}

		[TestMethod]
		public void CanReturnNullIfParametersAreNotEquals()
		{
			var slide = new Slide(500, 500);
			var gFStyle = new Style(Color.Red, true);
			var gOStyle = new Style(Color.Black, true);
			var group = new Group(gOStyle, gFStyle, 1);

			var fStyle = new Style(Color.Yellow, true);
			var oStyle = new Style(Color.Yellow, true);

			var rect = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, oStyle, fStyle, 2);
			group.InsertShape(rect, 0);

			Assert.AreEqual(rect.Frame, group.Frame);
			Assert.AreEqual(null, group.LineThickness);
			Assert.AreEqual(null, group.OutlineStyle);
			Assert.AreEqual(null, group.FillStyle);
		}

		[TestMethod]
		public void CanCreateGroupAndChangeFrameSize()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var group = new Group(oStyle, fStyle, 1);

			var rect = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, oStyle, fStyle, 1);
			group.InsertShape(rect, 0);
			group.Frame = new Rect<float> { Top = 1, Left = 1, Width = 5, Height = 5 };

			Assert.AreEqual(rect.Frame, group.Frame);
			Assert.AreEqual(1, group.LineThickness);
			Assert.AreEqual(oStyle, group.OutlineStyle);
			Assert.AreEqual(fStyle, group.FillStyle);
		}

		[TestMethod]
		public void CanCreateSomeShapesAndAddGroupThem()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var group = new Group(oStyle, fStyle, 1);

			var rect = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, oStyle, fStyle, 1);
			group.InsertShape(rect, 0);
			group.Frame = new Rect<float> { Top = 1, Left = 1, Width = 5, Height = 5 };
		}
	}
}

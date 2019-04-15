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
			slide.InsertShape(group, 0);
			Assert.AreEqual(1, slide.ShapeCount);
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
			Assert.AreEqual(group.GetShapesCount(), 1);
			Assert.AreEqual(rect.Frame, group.Frame);
			Assert.AreEqual(1, group.LineThickness);
			Assert.AreEqual(rect.OutlineStyle, group.OutlineStyle);
			Assert.AreEqual(rect.FillStyle, group.FillStyle);
		}

		[TestMethod]
		public void CanGetShapeInGroupByIndex()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var group = new Group(oStyle, fStyle, 1);

			var rect = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, oStyle, fStyle, 1);
			group.InsertShape(rect, 0);
			Assert.AreEqual(group.GetShapeAtIndex(0), rect);
			Assert.AreEqual(group.GetShapesCount(), 1);
			Assert.AreEqual(rect.Frame, group.Frame);
			Assert.AreEqual(1, group.LineThickness);
			Assert.AreEqual(rect.OutlineStyle, group.OutlineStyle);
			Assert.AreEqual(rect.FillStyle, group.FillStyle);
		}

		[TestMethod]
		public void CanRemoveShapeInGroupByIndex()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var group = new Group(oStyle, fStyle, 1);

			var rect = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, oStyle, fStyle, 1);
			group.InsertShape(rect, 0);
			Assert.AreEqual(group.GetShapeAtIndex(0), rect);
			Assert.AreEqual(group.GetShapesCount(), 1);
			group.RemoveShapeAtIndex(0);
			Assert.AreEqual(group.GetShapesCount(), 0);
		}

		[TestMethod]
		public void CanReturnNullIfShapesParametersInGroupAreNotEqualWithGroup()
		{
			var slide = new Slide(500, 500);
			var gFStyle = new Style(Color.Red, true);
			var gOStyle = new Style(Color.Black, true);
			var group = new Group(gOStyle, gFStyle, 1);

			var fStyle = new Style(Color.Yellow, true);
			var oStyle = new Style(Color.Yellow, true);

			var rect = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, oStyle, fStyle, 2);
			group.InsertShape(rect, 0);
			Assert.AreEqual(group.GetShapesCount(), 1);
			Assert.AreEqual(rect.Frame, group.Frame);
			Assert.AreEqual(null, group.LineThickness);
			Assert.AreEqual(null, group.OutlineStyle);
			Assert.AreEqual(null, group.FillStyle);
		}

		[TestMethod]
		public void CanReturnNullIfShapesParametersInGroupAreNotEquals()
		{
			var slide = new Slide(500, 500);
			var gFStyle = new Style(Color.Red, true);
			var gOStyle = new Style(Color.Black, true);
			var group = new Group(gOStyle, gFStyle, 1);

			var fStyle = new Style(Color.Yellow, true);
			var oStyle = new Style(Color.Yellow, true);

			var rect = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, oStyle, fStyle, 2);
			var rect1 = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, gOStyle, gFStyle, 3);

			group.InsertShape(rect, 0);
			Assert.AreEqual(group.GetShapesCount(), 1);
			group.InsertShape(rect1, 1);
			Assert.AreEqual(rect.Frame, group.Frame);
			Assert.AreEqual(null, group.LineThickness);
			Assert.AreEqual(null, group.OutlineStyle);
			Assert.AreEqual(null, group.FillStyle);
		}

		[TestMethod]
		public void CanSetShapesParametersInGroupThatChangeAllGroup()
		{
			var slide = new Slide(500, 500);
			var gFStyle = new Style(Color.Red, true);
			var gOStyle = new Style(Color.Black, true);
			var group = new Group(gOStyle, gFStyle, 1);

			var fStyle = new Style(Color.Yellow, true);
			var oStyle = new Style(Color.Yellow, true);

			var rect = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, oStyle, fStyle, 2);
			var rect1 = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, gOStyle, gFStyle, 3);

			group.InsertShape(rect, 0);
			Assert.AreEqual(group.GetShapesCount(), 1);
			group.InsertShape(rect1, 1);
			group.OutlineStyle = gOStyle;
			group.FillStyle = gFStyle;
			group.LineThickness = 1;
			Assert.AreEqual(rect.Frame, group.Frame);
			Assert.AreEqual(rect1.LineThickness, group.LineThickness);
			Assert.AreEqual(rect1.OutlineStyle, group.OutlineStyle);
			Assert.AreEqual(rect1.FillStyle, group.FillStyle);
		}

		[TestMethod]
		public void CanCreateSomeShapesAndGroupThem()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var group = new Group(oStyle, fStyle, 1);

			var rect = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, oStyle, fStyle, 1);
			var ellipse = new Rectangle(new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 }, oStyle, fStyle, 1);
			group.InsertShape(rect, 0);
			Assert.AreEqual(group.GetShapesCount(), 1);
			group.InsertShape(ellipse, 1);
			group.Frame = new Rect<float> { Top = 1, Left = 1, Width = 5, Height = 5 };
			Assert.AreEqual(group.GetShapesCount(), 2);
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
			Assert.AreEqual(group.GetShapesCount(), 1);
			Assert.AreEqual(rect.Frame, group.Frame);
			Assert.AreEqual(1, group.LineThickness);
			Assert.AreEqual(oStyle, group.OutlineStyle);
			Assert.AreEqual(fStyle, group.FillStyle);
		}
	}
}

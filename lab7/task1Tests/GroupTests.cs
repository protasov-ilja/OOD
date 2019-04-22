using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFML.Graphics;
using System;
using task1;
using task1.Composite;
using task1.Shapes;

namespace task1Tests
{
	[TestClass]
	public class GroupTests
    {
		[TestMethod]
		public void CanCreateSimpleShape()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var f = new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle, 1);
			Assert.AreEqual(rect.Parent, null);
			Assert.AreEqual(rect.LineThickness, 1);
			Assert.AreEqual(rect.OutlineStyle, oStyle);
			Assert.AreEqual(rect.FillStyle, fStyle);
			Assert.AreEqual(rect.Frame, f);
		}

		[TestMethod]
		public void CanChangeSimpleShapeFrame()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var newF = new Rect<float> { Top = 3, Left = 2, Width = 4, Height = 4 };
			var f = new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle, 1);
			Assert.AreEqual(rect.Parent, null);
			Assert.AreEqual(rect.LineThickness, 1);
			Assert.AreEqual(rect.OutlineStyle, oStyle);
			Assert.AreEqual(rect.FillStyle, fStyle);
			Assert.AreEqual(rect.Frame, f);

			rect.Frame = newF;
			Assert.AreEqual(rect.Frame, newF);
		}

		[TestMethod]
		public void CanChangeSimpleShapeFillStyle()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var newF = new Style(Color.Red, false);
			var f = new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle, 1);
			Assert.AreEqual(rect.Parent, null);
			Assert.AreEqual(rect.LineThickness, 1);
			Assert.AreEqual(rect.OutlineStyle, oStyle);
			Assert.AreEqual(rect.FillStyle, fStyle);
			Assert.AreEqual(rect.Frame, f);

			rect.FillStyle = newF;
			Assert.AreEqual(rect.FillStyle, newF);
		}

		[TestMethod]
		public void CanChangeSimpleShapeOutlineStyle()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var newO = new Style(Color.Yellow, false);
			var f = new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle, 1);
			Assert.AreEqual(rect.Parent, null);
			Assert.AreEqual(rect.LineThickness, 1);
			Assert.AreEqual(rect.OutlineStyle, oStyle);
			Assert.AreEqual(rect.FillStyle, fStyle);
			Assert.AreEqual(rect.Frame, f);

			rect.OutlineStyle = newO;
			Assert.AreEqual(rect.OutlineStyle, newO);
		}

		[TestMethod]
		public void CanChangeSimpleShapeLineThickness()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var newL = 4;
			var f = new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle, 1);
			Assert.AreEqual(rect.Parent, null);
			Assert.AreEqual(rect.LineThickness, 1);
			Assert.AreEqual(rect.OutlineStyle, oStyle);
			Assert.AreEqual(rect.FillStyle, fStyle);
			Assert.AreEqual(rect.Frame, f);

			rect.LineThickness = newL;
			Assert.AreEqual(rect.LineThickness, newL);
		}

		[TestMethod]
		public void CanCreateGroupWithRectangleOnSlide()
		{	
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var f = new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle, 2);

			var group = new Group(rect);

			Assert.AreEqual(rect.Parent, group);
			Assert.AreEqual(2, group.LineThickness);
			Assert.AreEqual(oStyle, group.OutlineStyle);
			Assert.AreEqual(fStyle, group.FillStyle);
			slide.InsertShape(group, 0);
			Assert.AreEqual(1, slide.ShapeCount);
			Assert.AreEqual(rect.OutlineStyle, group.OutlineStyle);
			Assert.AreEqual(rect.FillStyle, group.FillStyle);
		}

		[TestMethod]
		public void CanAddShapeInGroupByIndex()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle, 2);

			var group = new Group(rect);

			var f2 = new Rect<float> { Top = 5, Left = 5, Width = 10, Height = 10 };
			var rect2 = new Rectangle(f2, oStyle, fStyle, 2);
			group.InsertShape(rect2, 0);

			Assert.AreEqual(rect.Parent, group);
			Assert.AreEqual(rect2.Parent, group);
			Assert.AreEqual(group.GetShapesCount(), 2);
			Assert.AreEqual(new Rect<float>(0, 0, 15, 15), group.Frame);
			
			Assert.AreEqual(2, group.LineThickness);
			Assert.AreEqual(oStyle, group.OutlineStyle);
			Assert.AreEqual(fStyle, group.FillStyle);
		}

		[TestMethod]
		public void CanRemoveShapeInGroupByIndex()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle, 2);
			var group = new Group(rect);

			Assert.AreEqual(rect.Parent, group);
			Assert.AreEqual(group.GetShapesCount(), 1);
			group.RemoveShapeAtIndex(0);

			Assert.AreEqual(rect.Parent, null);
			Assert.AreEqual(group.GetShapesCount(), 0);
			Assert.ThrowsException<IndexOutOfRangeException>(() => group.RemoveShapeAtIndex(0));
		}

		[TestMethod]
		public void CanChangeShapeSizeInsideGroup()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle, 2);

			var group = new Group(rect);

			var f2 = new Rect<float> { Top = 5, Left = 5, Width = 10, Height = 10 };
			var rect2 = new Rectangle(f2, oStyle, fStyle, 2);
			group.InsertShape(rect2, 0);

			Assert.AreEqual(rect.Parent, group);
			Assert.AreEqual(rect2.Parent, group);
			Assert.AreEqual(group.GetShapesCount(), 2);
			Assert.AreEqual(new Rect<float>(0, 0, 15, 15), group.Frame);

			Assert.AreEqual(2, group.LineThickness);
			Assert.AreEqual(oStyle, group.OutlineStyle);
			Assert.AreEqual(fStyle, group.FillStyle);

			rect2.Frame = new Rect<float>(1, 1, 11, 11);
			Assert.AreEqual(new Rect<float>(0, 0, 12, 12), group.Frame);
		}

		[TestMethod]
		public void CanChangeGroupSizeShapesSizeInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle, 2);

			var group = new Group(rect);

			Assert.AreEqual(rect.Parent, group);
			Assert.AreEqual(group.GetShapesCount(), 1);
			Assert.AreEqual(new Rect<float>(0, 0, 10, 10), group.Frame);

			Assert.AreEqual(2, group.LineThickness);
			Assert.AreEqual(oStyle, group.OutlineStyle);
			Assert.AreEqual(fStyle, group.FillStyle);

			group.Frame = new Rect<float>(1, 1, 11, 11);
			Assert.AreEqual(new Rect<float>(1, 1, 11, 11), rect.Frame);
			Assert.AreEqual(new Rect<float>(1, 1, 11, 11), group.Frame);
		}

		[TestMethod]
		public void CanChangeGroupFillStyleShapesFillInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle, 2);
			var newF = new Style(Color.White, false);

			var group = new Group(rect);
			group.FillStyle = newF;

			Assert.AreEqual(rect.Parent, group);
			Assert.AreEqual(newF, group.FillStyle);
			Assert.AreEqual(newF, rect.FillStyle);
		}

		[TestMethod]
		public void CanChangeShapeInsideGroupFillStyleGroupFillChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle, 2);
			var newF = new Style(Color.White, false);

			var group = new Group(rect);
			rect.FillStyle = newF;

			Assert.AreEqual(rect.Parent, group);
			Assert.AreEqual(newF, group.FillStyle);
			Assert.AreEqual(newF, rect.FillStyle);
		}

		[TestMethod]
		public void GetNullIfStylesInsideGroupNotSimular()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var otherS = new Style(Color.White, false);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle, 2);
			var rect2 = new Rectangle(f, otherS, otherS, 3);
			
			var group = new Group(rect);
			group.InsertShape(rect2, 0);

			Assert.AreEqual(rect.Parent, group);
			Assert.AreEqual(rect2.Parent, group);
			Assert.AreEqual(null, group.FillStyle);
			Assert.AreEqual(null, group.OutlineStyle);
			Assert.AreEqual(null, group.LineThickness);

			rect2.OutlineStyle = oStyle;
			rect2.FillStyle = fStyle;
			rect2.LineThickness = 2;

			Assert.AreEqual(fStyle, group.FillStyle);
			Assert.AreEqual(oStyle, group.OutlineStyle);
			Assert.AreEqual(2, group.LineThickness);

			rect.FillStyle = otherS;
			Assert.AreEqual(null, group.FillStyle);
		}

		[TestMethod]
		public void CanAddGroupInGroup()
		{
			var slide = new Slide(500, 500);
			var fStyle = new Style(Color.Red, true);
			var oStyle = new Style(Color.Black, true);
			var otherS = new Style(Color.White, false);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle, 2);
			var rect2 = new Rectangle(f, otherS, otherS, 3);

			var group1 = new Group(rect);
			var group2 = new Group(rect2);
			group1.InsertShape(group2, 1);

			Assert.AreEqual(group1.GetShapesCount(), 2);
			Assert.AreEqual(group2.GetShapesCount(), 1);
		}
	}
}

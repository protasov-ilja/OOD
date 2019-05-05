using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFML.Graphics;
using System;
using task1;
using task1.Composite;
using task1.Composite.Styles;
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
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var f = new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			Assert.AreEqual(rect.OutlineStyle, oStyle);
			Assert.AreEqual(rect.FillStyle, fStyle);
			Assert.AreEqual(rect.Frame, f);
			Assert.IsFalse(rect.IsComposite());
		}

		[TestMethod]
		public void CanChangeSimpleShapeFrame()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var newF = new Rect<float> { Top = 3, Left = 2, Width = 4, Height = 4 };
			var f = new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			Assert.AreEqual(rect.OutlineStyle, oStyle);
			Assert.AreEqual(rect.FillStyle, fStyle);
			Assert.AreEqual(rect.Frame, f);

			rect.Frame = newF;
			Assert.AreEqual(rect.Frame, newF);
		}

		[TestMethod]
		public void CanChangeSimpleShapeFillStyleColor()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var newColor = Color.Yellow;
			var f = new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			Assert.AreEqual(rect.OutlineStyle, oStyle);
			Assert.AreEqual(rect.FillStyle, fStyle);
			Assert.AreEqual(rect.Frame, f);

			rect.FillStyle.SetColor(newColor);
			Assert.AreEqual(rect.FillStyle.GetColor(), newColor);
		}

		[TestMethod]
		public void CanChangeSimpleShapeOutlineStyleColor()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var newColor = Color.Yellow;
			var f = new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			Assert.AreEqual(rect.OutlineStyle, oStyle);
			Assert.AreEqual(rect.FillStyle, fStyle);
			Assert.AreEqual(rect.Frame, f);

			rect.OutlineStyle.SetColor(newColor);
			Assert.AreEqual(rect.OutlineStyle.GetColor(), newColor);
		}

		[TestMethod]
		public void CanChangeSimpleShapeOutlineStyleLineThickness()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var newLT = 4;
			var f = new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			Assert.AreEqual(rect.OutlineStyle.LineThickness, 1);
			Assert.AreEqual(rect.OutlineStyle, oStyle);
			Assert.AreEqual(rect.FillStyle, fStyle);
			Assert.AreEqual(rect.Frame, f);

			rect.OutlineStyle.LineThickness = newLT;
			Assert.AreEqual(rect.OutlineStyle.LineThickness, newLT);
		}

		[TestMethod]
		public void CanCreateGroupWithRectangleOnSlide()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var f = new Rect<float> { Top = 1, Left = 1, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);

			var group = new Group(rect);

			Assert.AreEqual(1, group.OutlineStyle.LineThickness);
			Assert.AreEqual(oStyle.GetColor(), group.OutlineStyle.GetColor());
			Assert.AreEqual(oStyle.IsEnabled(), group.OutlineStyle.IsEnabled());
			Assert.AreEqual(oStyle.LineThickness, group.OutlineStyle.LineThickness);
			Assert.AreEqual(fStyle.GetColor(), group.FillStyle.GetColor());
			Assert.AreEqual(fStyle.IsEnabled(), group.FillStyle.IsEnabled());

			slide.InsertShape(group, 0);

			Assert.AreEqual(1, slide.ShapeCount);
			Assert.AreEqual(rect.OutlineStyle.GetColor(), group.OutlineStyle.GetColor());
			Assert.AreEqual(rect.OutlineStyle.IsEnabled(), group.OutlineStyle.IsEnabled());
			Assert.AreEqual(rect.OutlineStyle.LineThickness, group.OutlineStyle.LineThickness);
			Assert.AreEqual(rect.FillStyle.GetColor(), group.FillStyle.GetColor());
			Assert.AreEqual(rect.FillStyle.IsEnabled(), group.FillStyle.IsEnabled());
		}

		[TestMethod]
		public void CanAddShapeInGroupByIndex()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);

			var group = new Group(rect);

			var f2 = new Rect<float> { Top = 5, Left = 5, Width = 10, Height = 10 };
			var rect2 = new Rectangle(f2, oStyle, fStyle);
			group.InsertShape(rect2, 0);

			Assert.AreEqual(group.GetShapesCount(), 2);
			Assert.AreEqual(oStyle.GetColor(), group.OutlineStyle.GetColor());
			Assert.AreEqual(oStyle.IsEnabled(), group.OutlineStyle.IsEnabled());
			Assert.AreEqual(oStyle.LineThickness, group.OutlineStyle.LineThickness);
			Assert.AreEqual(fStyle.GetColor(), group.FillStyle.GetColor());
			Assert.AreEqual(fStyle.IsEnabled(), group.FillStyle.IsEnabled());
			Assert.AreEqual(2, group.OutlineStyle.LineThickness);
		}

		[TestMethod]
		public void CanRemoveShapeInGroupByIndex()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			var group = new Group(rect);

			Assert.AreEqual(group.GetShapesCount(), 1);
			group.RemoveShapeAtIndex(0);

			Assert.AreEqual(group.GetShapesCount(), 0);
		}

		[TestMethod]
		public void CantRemoveShapeInEmptyGroupAndThrowException()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			var group = new Group(rect);

			Assert.AreEqual(group.GetShapesCount(), 1);
			group.RemoveShapeAtIndex(0);

			Assert.AreEqual(group.GetShapesCount(), 0);
			Assert.ThrowsException<IndexOutOfRangeException>(() => group.RemoveShapeAtIndex(0));
		}

		[TestMethod]
		public void ReturnNullSizeIfGroupIsEmpty()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);

			var group = new Group(rect);

			var f2 = new Rect<float> { Top = 5, Left = 5, Width = 10, Height = 10 };
			var rect2 = new Rectangle(f2, oStyle, fStyle);
			group.InsertShape(rect2, 0);

			group.RemoveShapeAtIndex(0);
			group.RemoveShapeAtIndex(0);

			Assert.AreEqual(group.GetShapesCount(), 0);
			Assert.AreEqual(null, group.Frame);
		}

		[TestMethod]
		public void ReturnShapeSizeIfGroupConsitsOnlyThisShape()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);

			var group = new Group(rect);

			Assert.AreEqual(group.GetShapesCount(), 1);
			Assert.AreEqual(new Rect<float>(0, 0, 10, 10), group.Frame);

			Assert.AreEqual(2, group.OutlineStyle.LineThickness);
		}

		[TestMethod]
		public void ReturnSumGroupSizeIfGroupMoreThan1Shape()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var f2 = new Rect<float> { Top = 2, Left = 2, Width = 10, Height = 10 };
			var rect2 = new Rectangle(f2, oStyle, fStyle);
			var group = new Group(rect);
			group.InsertShape(rect2, 0);

			Assert.AreEqual(group.GetShapesCount(), 2);
			Assert.AreEqual(new Rect<float>(0, 0, 12, 12), group.Frame);

			Assert.AreEqual(2, group.OutlineStyle.LineThickness);
		}

		[TestMethod]
		public void CanChangeShapeSizeInsideGroup()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);

			var group = new Group(rect);

			var f2 = new Rect<float> { Top = 5, Left = 5, Width = 10, Height = 10 };
			var rect2 = new Rectangle(f2, oStyle, fStyle);
			group.InsertShape(rect2, 0);

			Assert.AreEqual(group.GetShapesCount(), 2);
			Assert.AreEqual(new Rect<float>(0, 0, 15, 15), group.Frame);

			Assert.AreEqual(2, group.OutlineStyle.LineThickness);

			rect2.Frame = new Rect<float>(1, 1, 11, 11);
			Assert.AreEqual(new Rect<float>(0, 0, 12, 12), group.Frame);
		}

		[TestMethod]
		public void CanChangeGroupSizeShapesSizeInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);

			var group = new Group(rect);

			Assert.AreEqual(group.GetShapesCount(), 1);
			Assert.AreEqual(new Rect<float>(0, 0, 10, 10), group.Frame);

			Assert.AreEqual(2, group.OutlineStyle.LineThickness);

			group.Frame = new Rect<float>(1, 1, 11, 11);
			Assert.AreEqual(new Rect<float>(1, 1, 11, 11), rect.Frame);
			Assert.AreEqual(new Rect<float>(1, 1, 11, 11), group.Frame);
		}

		[TestMethod]
		public void WhenChangeGroupFillStyleColorShapesFillColorInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newC = Color.White;

			var group = new Group(rect);
			group.FillStyle.SetColor(newC);

			Assert.AreEqual(newC, group.FillStyle.GetColor());
			Assert.AreEqual(newC, rect.FillStyle.GetColor());
		}

		[TestMethod]
		public void WhenChangeRemotelyGroupFillStyleColorShapesFillColorInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newC = Color.White;

			var group = new Group(rect);
			var fillStyleGroup =  group.FillStyle;
			fillStyleGroup.SetColor(newC);

			Assert.AreEqual(newC, group.FillStyle.GetColor());
			Assert.AreEqual(newC, rect.FillStyle.GetColor());
		}

		[TestMethod]
		public void WhenChangeShapeInsideGroupFillColorGroupFillColorChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newC = Color.White;

			var group = new Group(rect);
			rect.FillStyle.SetColor(newC);

			Assert.AreEqual(newC, group.FillStyle.GetColor());
			Assert.AreEqual(newC, rect.FillStyle.GetColor());
		}

		[TestMethod]
		public void WhenChangeGroupFillStyleEnableShapesStateInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newE = false;

			var group = new Group(rect);
			group.FillStyle.Enable(newE);

			Assert.AreEqual(newE, group.FillStyle.IsEnabled());
			Assert.AreEqual(newE, rect.FillStyle.IsEnabled());
		}

		[TestMethod]
		public void WhenChangeRemotelyGroupFillStyleEnableShapesStateInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newE = false;

			var otherFS = new FillStyle(Color.Red, true);
			var rect2 = new Rectangle(f, oStyle, otherFS);

			var group = new Group(rect);
			group.InsertShape(rect2, 0);

			var fillStyleGroup = group.FillStyle;
			fillStyleGroup.Enable(newE);

			Assert.AreEqual(newE, group.FillStyle.IsEnabled());
			Assert.AreEqual(newE, rect.FillStyle.IsEnabled());
			Assert.AreEqual(newE, rect2.FillStyle.IsEnabled());
		}

		[TestMethod]
		public void WhenChangeShapeInsideGroupFillEnableGroupFillStateChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newE = false;

			var group = new Group(rect);
			

			rect.FillStyle.Enable(newE);

			Assert.AreEqual(newE, group.FillStyle.IsEnabled());
			Assert.AreEqual(newE, rect.FillStyle.IsEnabled());
		}

		[TestMethod]
		public void GetNullIfFillColorInsideGroupNotSimular()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var otherFC = Color.White;
			var otherFS = new FillStyle(otherFC, true);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			var rect2 = new Rectangle(f, oStyle, otherFS);

			var group = new Group(rect);
			group.InsertShape(rect2, 0);

			Assert.AreEqual(null, group.FillStyle.GetColor());
		}

		[TestMethod]
		public void GetNullIfFillEnableInsideGroupNotSimular()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var otherFC = Color.White;
			var otherFS = new FillStyle(otherFC, false);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			var rect2 = new Rectangle(f, oStyle, otherFS);

			var group = new Group(rect);
			group.InsertShape(rect2, 0);

			Assert.AreEqual(null, group.FillStyle.IsEnabled());
		}

		[TestMethod]
		public void WhenChangeGroupOutlineStyleColorShapesOutlineColorInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newC = Color.White;

			var group = new Group(rect);
			group.OutlineStyle.SetColor(newC);

			Assert.AreEqual(newC, group.OutlineStyle.GetColor());
			Assert.AreEqual(newC, rect.OutlineStyle.GetColor());
		}

		[TestMethod]
		public void WhenChangeRemotelyGroupOutlineColorShapesOutlineColorInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newC = Color.White;

			var group = new Group(rect);
			var outlineStyleGroup = group.OutlineStyle;
			outlineStyleGroup.SetColor(newC);

			Assert.AreEqual(newC, group.OutlineStyle.GetColor());
			Assert.AreEqual(newC, rect.OutlineStyle.GetColor());
		}

		[TestMethod]
		public void WhenChangeShapeInsideGroupOutlineColorGroupOutlineColorChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newC = Color.White;

			var group = new Group(rect);
			rect.OutlineStyle.SetColor(newC);

			Assert.AreEqual(newC, group.OutlineStyle.GetColor());
			Assert.AreEqual(newC, rect.OutlineStyle.GetColor());
		}

		[TestMethod]
		public void WhenChangeGroupOutlineStyleEnableShapesStateInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newE = false;

			var group = new Group(rect);
			group.OutlineStyle.Enable(newE);

			Assert.AreEqual(newE, group.OutlineStyle.IsEnabled());
			Assert.AreEqual(newE, rect.OutlineStyle.IsEnabled());
		}

		[TestMethod]
		public void WhenChangeRemotelyGroupOutlineStyleEnableShapesStateInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newE = false;

			var otherOS = new OutlineStyle(Color.Red, true, 2);
			var rect2 = new Rectangle(f, otherOS, fStyle);

			var group = new Group(rect);
			group.InsertShape(rect2, 0);

			var outlineStyleGroup = group.OutlineStyle;
			outlineStyleGroup.Enable(newE);

			Assert.AreEqual(newE, group.OutlineStyle.IsEnabled());
			Assert.AreEqual(newE, rect.OutlineStyle.IsEnabled());
			Assert.AreEqual(newE, rect2.OutlineStyle.IsEnabled());
		}

		[TestMethod]
		public void WhenChangeShapeInsideGroupOutlineEnableGroupOutlineStateChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newE = false;

			var group = new Group(rect);
			rect.OutlineStyle.Enable(newE);

			Assert.AreEqual(newE, group.OutlineStyle.IsEnabled());
			Assert.AreEqual(newE, rect.OutlineStyle.IsEnabled());
		}

		[TestMethod]
		public void WhenChangeGroupOutlineThicknessShapesStateInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newT = 3;

			var group = new Group(rect);
			group.OutlineStyle.LineThickness = newT;

			Assert.AreEqual(newT, group.OutlineStyle.LineThickness);
			Assert.AreEqual(newT, rect.OutlineStyle.LineThickness);
		}

		[TestMethod]
		public void WhenChangeRemotelyGroupOutlineThicknessShapesStateInsideGroupChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newT = 3;

			var otherOS = new OutlineStyle(Color.Red, true, 2);
			var rect2 = new Rectangle(f, otherOS, fStyle);

			var group = new Group(rect);
			group.InsertShape(rect2, 0);

			var outlineStyleGroup = group.OutlineStyle;
			outlineStyleGroup.LineThickness = newT;

			Assert.AreEqual(newT, group.OutlineStyle.LineThickness);
			Assert.AreEqual(newT, rect.OutlineStyle.LineThickness);
			Assert.AreEqual(newT, rect2.OutlineStyle.LineThickness);
		}

		[TestMethod]
		public void WhenChangeShapeInsideGroupOutlineThicknessGroupOutlineStateChagedToo()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };
			var rect = new Rectangle(f, oStyle, fStyle);
			var newT = 3;

			var group = new Group(rect);
			rect.OutlineStyle.LineThickness = newT;

			Assert.AreEqual(newT, group.OutlineStyle.LineThickness);
			Assert.AreEqual(newT, rect.OutlineStyle.LineThickness);
		}

		[TestMethod]
		public void GetNullIfOulineEnableInsideGroupNotSimular()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var otherFC = Color.White;
			var otherOS = new OutlineStyle(otherFC, false);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			var rect2 = new Rectangle(f, otherOS, fStyle);

			var group = new Group(rect);
			group.InsertShape(rect2, 0);

			Assert.AreEqual(null, group.OutlineStyle.IsEnabled());
		}

		[TestMethod]
		public void GetNullIfOulineColorInsideGroupNotSimular()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var otherFC = Color.White;
			var otherOS = new OutlineStyle(otherFC, false);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			var rect2 = new Rectangle(f, otherOS, fStyle);

			var group = new Group(rect);
			group.InsertShape(rect2, 0);

			Assert.AreEqual(null, group.OutlineStyle.GetColor());
		}

		[TestMethod]
		public void GetNullIfOulineThicknessInsideGroupNotSimular()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true);
			var otherFC = Color.White;
			var otherOS = new OutlineStyle(otherFC, false, 2);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			var rect2 = new Rectangle(f, otherOS, fStyle);

			var group = new Group(rect);
			group.InsertShape(rect2, 0);

			Assert.AreEqual(null, group.OutlineStyle.LineThickness);
		}

		[TestMethod]
		public void CanAddGroupInGroup()
		{
			var slide = new Slide(500, 500);
			var fStyle = new FillStyle(Color.Red, true);
			var oStyle = new OutlineStyle(Color.Black, true, 2);
			var otherFS = new FillStyle(Color.White, false);
			var otherOS = new OutlineStyle(Color.White, false, 3);
			var f = new Rect<float> { Top = 0, Left = 0, Width = 10, Height = 10 };

			var rect = new Rectangle(f, oStyle, fStyle);
			var rect2 = new Rectangle(f, otherOS, otherFS);

			var group1 = new Group(rect);
			var group2 = new Group(rect2);
			group1.InsertShape(group2, 1);

			Assert.AreEqual(group1.GetShapesCount(), 2);
			Assert.AreEqual(group2.GetShapesCount(), 1);
		}
	}
}

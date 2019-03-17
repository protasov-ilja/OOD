using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task1.Painter;
using Task1.Painter.Enums;
using Task1.Painter.Shapes;

namespace Task1Tests.FactoriesTests
{
	[TestClass]
	public class ShapeFactoryTests
    {
		[TestMethod]
		public void CantCreateShapeAndThrowsExceptionIfShapeTypeNotFoundInActionMap()
		{
			var shapeFactory = new ShapeFactory();
			Assert.ThrowsException<Exception>(() => shapeFactory.CreateShape("shape 1 2 3 4"));
			Assert.ThrowsException<Exception>(() => shapeFactory.CreateShape("ellipses 1 2 3 4"));
			Assert.ThrowsException<Exception>(() => shapeFactory.CreateShape("_ellipse 1 2 3 4"));
		}

		[TestMethod]
		public void CantCreateEllipseAndThrowsExceptionIfArgsLessThan4()
		{
			var shapeFactory = new ShapeFactory();

			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("ellipse 1 2 3"));
			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("ellipse 1 2"));
			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("ellipse 1"));
			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("ellipse"));
		}

		[TestMethod]
		public void CantCreateEllipseAndThrowsExceptionIfTypesOfArgsAreWrong()
		{
			var shapeFactory = new ShapeFactory();
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("ellipse q 2 3 4"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("ellipse 1 w 3 4"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("ellipse 1 2 e 4"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("ellipse 1 2 3 r"));
		}

		[TestMethod]
		public void CantCreateTriangleAndThrowsExceptionIfTypesOfArgsAreWrong()
		{
			var shapeFactory = new ShapeFactory();
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("triangle q 2 3 4 3 3"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("triangle 1 w 3 4 4 4 "));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("triangle 1 2 e 4 3 3"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("triangle 1 2 3 r 3 3"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("triangle 1 2 3 3 t 3"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("triangle 1 2 3 4 4 y"));
		}

		[TestMethod]
		public void CantCreateTriangleAndThrowsExceptionIfArgsLessThan6()
		{
			var shapeFactory = new ShapeFactory();

			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("triangle 1 2 3 4 5"));
			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("triangle 1 2 3"));
			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("triangle 1 2"));
			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("triangle 1"));
			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("triangle"));
		}

		[TestMethod]
		public void CantCreateRectangleAndThrowsExceptionIfTypesOfArgsAreWrong()
		{
			var shapeFactory = new ShapeFactory();
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("rectangle q 2 3 4"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("rectangle 1 w 3 4"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("rectangle 1 2 e 4"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("rectangle 1 2 3 r"));
		}

		[TestMethod]
		public void CantCreateRectangleAndThrowsExceptionIfArgsLessThan4()
		{
			var shapeFactory = new ShapeFactory();

			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("rectangle 1 2 3"));
			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("rectangle 1 2"));
			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("rectangle 1"));
		}

		[TestMethod]
		public void CantCreatePolygonAndThrowsExceptionIfTypesOfArgsAreWrong()
		{
			var shapeFactory = new ShapeFactory();
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("polygon q 2 3 4"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("polygon 1 w 3 4"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("polygon 1 2 e 4"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("polygon 1 2 3 r"));
			Assert.ThrowsException<FormatException>(() => shapeFactory.CreateShape("polygon 1.2 2 3 3"));
		}

		[TestMethod]
		public void CantCreatePolygonAndThrowsExceptionIfArgsLessThan4()
		{
			var shapeFactory = new ShapeFactory();

			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("polygon 1 2 3"));
			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("polygon 1 2"));
			Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape("polygon 1"));
		}

		[TestMethod]
		public void CanCreatePolygonWithColor()
		{
			var shapeFactory = new ShapeFactory();

			var vertexCount = 3;
			var center = new Point(4, 4);
			var radius = 3;
			var color = Color.Red;

			var regularPolygon = new RegularPolygon(vertexCount, center, radius, color);

			var shape = shapeFactory.CreateShape($"polygon {vertexCount} {center.X} {center.Y} {radius} red");
			ArePolygonsEquals((RegularPolygon)shape, regularPolygon);
		}

		[TestMethod]
		public void CanCreatePolygonWithDefaultColor()
		{
			var shapeFactory = new ShapeFactory();

			var vertexCount = 3;
			var center = new Point(4, 4);
			var radius = 3;
			var color = Color.Black;

			var regularPolygon = new RegularPolygon(vertexCount, center, radius, color);

			var shape = shapeFactory.CreateShape($"polygon {vertexCount} {center.X} {center.Y} {radius}");
			ArePolygonsEquals((RegularPolygon)shape, regularPolygon);
		}

		[TestMethod]
		public void CanCreateRectangleWithColor()
		{
			var shapeFactory = new ShapeFactory();

			var leftTop = new Point(0, 6);
			var rightBottom = new Point(2, 0);
			var color = Color.Red;

			var rectangle = new Rectangle(leftTop, rightBottom, color);

			var shape = shapeFactory.CreateShape($"rectangle {leftTop.X} {leftTop.Y} {rightBottom.X} {rightBottom.Y} red");
			AraRectanglesEquals((Rectangle)shape, rectangle);
		}

		[TestMethod]
		public void CanCreateRectangleWithDefaultColor()
		{
			var shapeFactory = new ShapeFactory();

			var leftTop = new Point(0, 6);
			var rightBottom = new Point(2, 0);
			var color = Color.Black;

			var rectangle = new Rectangle(leftTop, rightBottom, color);

			var shape = shapeFactory.CreateShape($"rectangle {leftTop.X} {leftTop.Y} {rightBottom.X} {rightBottom.Y}");
			AraRectanglesEquals((Rectangle)shape, rectangle);
		}

		[TestMethod]
		public void CanCreateTriangleWithColor()
		{
			var shapeFactory = new ShapeFactory();

			var v1 = new Point(1, 2);
			var v2 = new Point(4, 5);
			var v3 = new Point(0, 5);
			var color = Color.Red;

			var triangle = new Triangle(v1, v2, v3, color);

			var shape = shapeFactory.CreateShape($"triangle {v1.X} {v1.Y} {v2.X} {v2.Y} {v3.X} {v3.Y} red");
			AreTrianglesEquals((Triangle)shape, triangle);
		}

		[TestMethod]
		public void CanCreateTriangleWithDefaultColor()
		{
			var shapeFactory = new ShapeFactory();

			var v1 = new Point(1, 2);
			var v2 = new Point(4, 5);
			var v3 = new Point(0, 5);
			var color = Color.Black;

			var triangle = new Triangle(v1, v2, v3, color);

			var shape = shapeFactory.CreateShape($"triangle {v1.X} {v1.Y} {v2.X} {v2.Y} {v3.X} {v3.Y}");
			AreTrianglesEquals((Triangle)shape, triangle);
		}

		[TestMethod]
		public void CanCreateEllipseWithColor()
		{
			var shapeFactory = new ShapeFactory();

			var center = new Point(3, 3);
			var horizontalRadius = 2;
			var verticalRadius = 3;
			var color = Color.Red;

			var ellipse = new Ellipse(center, horizontalRadius, verticalRadius, color);

			var shape = shapeFactory.CreateShape($"ellipse {center.X} {center.Y} {horizontalRadius} {verticalRadius} red");
			AraEllipsesEquals((Ellipse)shape, ellipse);
		}

		[TestMethod]
		public void CanCreateEllipseWithDefaultColor()
		{
			var shapeFactory = new ShapeFactory();

			var center = new Point(3, 3);
			var horizontalRadius = 2;
			var verticalRadius = 3;
			var color = Color.Black;

			var ellipse = new Ellipse(center, horizontalRadius, verticalRadius, color);

			var shape = shapeFactory.CreateShape($"ellipse {center.X} {center.Y} {horizontalRadius} {verticalRadius}");
			AraEllipsesEquals((Ellipse)shape, ellipse);
		}

		private void ArePolygonsEquals(RegularPolygon p1, RegularPolygon p2)
		{
			Assert.IsTrue(p1.Center == p2.Center);
			Assert.IsTrue(p1.Radius == p2.Radius);
			Assert.IsTrue(p1.VertexCount == p2.VertexCount);
			Assert.IsTrue(p1.Color == p2.Color);
		}

		private void AreTrianglesEquals(Triangle t1, Triangle t2)
		{
			Assert.IsTrue(t1.Vertex1 == t2.Vertex1);
			Assert.IsTrue(t1.Vertex2 == t2.Vertex2);
			Assert.IsTrue(t1.Vertex3 == t2.Vertex3);
			Assert.IsTrue(t1.Color == t2.Color);
		}

		private void AraRectanglesEquals(Rectangle r1, Rectangle r2)
		{
			Assert.IsTrue(r1.LeftTop == r1.LeftTop);
			Assert.IsTrue(r1.RightBottom == r1.RightBottom);
			Assert.IsTrue(r1.Color == r1.Color);
		}

		private void AraEllipsesEquals(Ellipse e1, Ellipse e2)
		{
			Assert.IsTrue(e1.Center == e2.Center);
			Assert.IsTrue(e1.HorizontalRadius == e2.HorizontalRadius);
			Assert.IsTrue(e1.VerticalRadius == e2.VerticalRadius);
			Assert.IsTrue(e1.Color == e2.Color);
		}
	}
}

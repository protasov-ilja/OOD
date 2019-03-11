using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using Task1.Painter.Enums;
using Task1.Painter.Shapes;

namespace task1Tests
{
    [TestClass]
    public class TestShapes
    {
        [TestMethod]
        public void CanCreateTriangle()
        {
			var v1 = new Vector2(1, 2);
			var v2 = new Vector2(4, 5);
			var v3 = new Vector2(0, 5);
			var color = Color.Red;

			var triangle = new Triangle(v1, v2, v3, color);

			Assert.AreEqual(v1, triangle.Vertex1);
			Assert.AreEqual(v2, triangle.Vertex2);
			Assert.AreEqual(v3, triangle.Vertex3);
			Assert.AreEqual(color, triangle.GetColor());
		}

		[TestMethod]
		public void CanCreateRectangle()
		{
			var leftTop = new Vector2(0, 6);
			var rightBottom = new Vector2(2, 0);
			var color = Color.Red;

			var rectangle = new Rectangle(leftTop, rightBottom, color);

			Assert.AreEqual(leftTop, rectangle.LeftTop);
			Assert.AreEqual(rightBottom, rectangle.RightBottom);
			Assert.AreEqual(color, rectangle.GetColor());
		}

		[TestMethod]
		public void CanCreateEllipse()
		{
			var center = new Vector2(3, 3);
			var horizontalRadius = 2;
			var verticalRadius = 3;
			var color = Color.Red;

			var ellipse = new Ellipse(center, horizontalRadius, verticalRadius, color);

			Assert.AreEqual(center, ellipse.Center);
			Assert.AreEqual(horizontalRadius, ellipse.HorizontalRadius);
			Assert.AreEqual(verticalRadius, ellipse.VerticalRadius);
			Assert.AreEqual(color, ellipse.GetColor());
		}

		[TestMethod]
		public void CanCreateRegularPolygonWith3Vertexes()
		{
			var vertexCount = 3;
			var center = new Vector2(4, 4);
			var radius = 3;
			var color = Color.Red;

			var regularPolygon = new RegularPolygon(vertexCount, center, radius, color);

			Assert.AreEqual(vertexCount, regularPolygon.VertexCount);
			Assert.AreEqual(center, regularPolygon.Center);
			Assert.AreEqual(radius, regularPolygon.Radius);
			Assert.AreEqual(color, regularPolygon.GetColor());
		}

		[TestMethod]
		public void CanCreateRegularPolygonWith5Vertexes()
		{
			var vertexCount = 5;
			var center = new Vector2(4, 4);
			var radius = 3;
			var color = Color.Red;

			var regularPolygon = new RegularPolygon(vertexCount, center, radius, color);

			Assert.AreEqual(vertexCount, regularPolygon.VertexCount);
			Assert.AreEqual(center, regularPolygon.Center);
			Assert.AreEqual(radius, regularPolygon.Radius);
			Assert.AreEqual(color, regularPolygon.GetColor());
		}
	}
}

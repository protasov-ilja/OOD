using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task1.Painter;
using Task1.Painter.Enums;
using Task1.Painter.Shapes;
using Task1Tests.Shapes;

namespace Task1Tests
{
	[TestClass]
	public class RegularPolygonTests
    {
		[TestMethod]
		public void CanCreateRegularPolygonWith3Vertexes()
		{
			var vertexCount = 3;
			var center = new Point(4, 4);
			var radius = 3;
			var color = Color.Red;

			var regularPolygon = new RegularPolygon(vertexCount, center, radius, color);

			Assert.AreEqual(vertexCount, regularPolygon.VertexCount);
			Assert.AreEqual(center, regularPolygon.Center);
			Assert.AreEqual(radius, regularPolygon.Radius);
			Assert.AreEqual(color, regularPolygon.Color);
		}

		[TestMethod]
		public void CanCreateRegularPolygonWith5Vertexes()
		{
			var vertexCount = 5;
			var center = new Point(4, 4);
			var radius = 3;
			var color = Color.Red;

			var regularPolygon = new RegularPolygon(vertexCount, center, radius, color);

			Assert.AreEqual(vertexCount, regularPolygon.VertexCount);
			Assert.AreEqual(center, regularPolygon.Center);
			Assert.AreEqual(radius, regularPolygon.Radius);
			Assert.AreEqual(color, regularPolygon.Color);
		}

		[TestMethod]
		public void CanDrawRegularPolygon()
		{
			var vertexCount = 3;
			var center = new Point(4, 4);
			var radius = 3;
			var color = Color.Red;

			var regularPolygon = new RegularPolygon(vertexCount, center, radius, color);

			TestCanvas canvas = new TestCanvas();

			var angle = 360f / vertexCount;
			var vertex1 = GetVertexByAngle(angle * 0);

			for (var i = 1; i < vertexCount; ++i)
			{
				var vertex2 = GetVertexByAngle(angle * i);
				canvas.ExpectedData.Add($"{vertex1} {vertex2}");
				vertex1 = vertex2;
			}

			regularPolygon.Draw(canvas);
		}

		private Point GetVertexByAngle(float angle)
		{
			var angleInRadians = DegToRad(angle);
			var x = (float)Math.Cos(angleInRadians);
			var y = (float)Math.Sin(angleInRadians);

			return new Point(x, y);
		}

		private float DegToRad(float angle)
		{
			return (float)(Math.PI / 180) * angle;
		}
	}
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Painter;
using Task1.Painter.Enums;
using Task1.Painter.Shapes;
using Task1Tests.Shapes;

namespace Task1Tests
{
	[TestClass]
	public class TriangleTests
    {
		[TestMethod]
		public void CanCreateTriangle()
		{
			var v1 = new Point(1, 2);
			var v2 = new Point(4, 5);
			var v3 = new Point(0, 5);
			var color = Color.Red;

			var triangle = new Triangle(v1, v2, v3, color);

			Assert.AreEqual(new Point(1, 2), triangle.Vertex1);
			Assert.AreEqual(v2, triangle.Vertex2);
			Assert.AreEqual(v3, triangle.Vertex3);
			Assert.AreEqual(color, triangle.Color);
		}

		[TestMethod]
		public void CanDrawTriangle()
		{
			var v1 = new Point(1, 2);
			var v2 = new Point(4, 5);
			var v3 = new Point(0, 5);
			var color = Color.Red;

			var triangle = new Triangle(v1, v2, v3, color);

			TestCanvas canvas = new TestCanvas();

			canvas.ExpectedData.Add($"{v1} {v2}");
			canvas.ExpectedData.Add($"{v2} {v3}");
			canvas.ExpectedData.Add($"{v3} {v1}");

			triangle.Draw(canvas);
		}
	}
}

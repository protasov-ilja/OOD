using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Painter;
using Task1.Painter.Enums;
using Task1.Painter.Shapes;

namespace Task1Tests.Shapes
{
	[TestClass]
	public class EllipseTests
    {
		[TestMethod]
		public void CanCreateEllipse()
		{
			var center = new Point(3, 3);
			var horizontalRadius = 2;
			var verticalRadius = 3;
			var color = Color.Red;

			var ellipse = new Ellipse(center, horizontalRadius, verticalRadius, color);

			Assert.AreEqual(center, ellipse.Center);
			Assert.AreEqual(horizontalRadius, ellipse.HorizontalRadius);
			Assert.AreEqual(verticalRadius, ellipse.VerticalRadius);
			Assert.AreEqual(color, ellipse.Color);
		}

		[TestMethod]
		public void CanDrawEllipse()
		{
			var center = new Point(3, 3);
			var horizontalRadius = 2;
			var verticalRadius = 3;
			var color = Color.Red;

			var ellipse = new Ellipse(center, horizontalRadius, verticalRadius, color);

			TestCanvas canvas = new TestCanvas();

			canvas.ExpectedData.Add($"{center.X - horizontalRadius} {center.Y - verticalRadius} {horizontalRadius * 2} {verticalRadius * 2}");

			ellipse.Draw(canvas);
		}
	}
}

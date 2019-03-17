using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Painter;
using Task1.Painter.Enums;
using Task1.Painter.Shapes;
using Task1Tests.Shapes;

namespace Task1Tests
{
	[TestClass]
	public class RectangleTests
    {
		[TestMethod]
		public void CanCreateRectangle()
		{
			var leftTop = new Point(0, 6);
			var rightBottom = new Point(2, 0);
			var color = Color.Red;

			var rectangle = new Rectangle(leftTop, rightBottom, color);

			Assert.AreEqual(leftTop, rectangle.LeftTop);
			Assert.AreEqual(rightBottom, rectangle.RightBottom);
			Assert.AreEqual(color, rectangle.Color);
		}

		[TestMethod]
		public void CanDrawRectangle()
		{
			var leftTop = new Point(0, 6);
			var rightBottom = new Point(2, 0);
			var color = Color.Red;

			var rectangle = new Rectangle(leftTop, rightBottom, color);

			TestCanvas canvas = new TestCanvas();

			var rightTop = new Point(rightBottom.X, leftTop.Y);
			var leftBottom = new Point(leftTop.X, rightBottom.Y);
			canvas.ExpectedData.Add($"{leftTop} {rightTop}");
			canvas.ExpectedData.Add($"{rightTop} {rightBottom}");
			canvas.ExpectedData.Add($"{rightBottom} {leftBottom}");
			canvas.ExpectedData.Add($"{leftBottom} {leftTop}");

			rectangle.Draw(canvas);
		}
	}
}

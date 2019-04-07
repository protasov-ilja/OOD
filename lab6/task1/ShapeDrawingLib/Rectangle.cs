using task1.GraphicsLib;

namespace task1.ShapeDrawingLib
{
	public class Rectangle : ICanvasDrawable
	{
		public Point LeftTop { get; private set; }
		public int Width{ get; private set; }
		public int Height { get; private set; }

		public Rectangle(Point leftTop, int width, int height)
		{
			LeftTop = leftTop;
			Width = width;
			Height = height;
		}

		public void Draw(ICanvas canvas)
		{
			canvas.MoveTo(LeftTop.X, LeftTop.Y);
			canvas.LineTo(LeftTop.X + Width, LeftTop.Y);
			canvas.LineTo(LeftTop.X + Width, LeftTop.Y - Height);
			canvas.LineTo(LeftTop.X, LeftTop.Y - Height);
			canvas.LineTo(LeftTop.X, LeftTop.Y);
		}
	}
}

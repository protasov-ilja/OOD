using System.Drawing;
using task2.GraphicsLib;

namespace task2.ShapeDrawingLib
{
	public class Rectangle : ICanvasDrawable
	{
		public Point LeftTop { get; private set; }
		public int Width{ get; private set; }
		public int Height { get; private set; }
		public uint Color { get; private set; }

		public Rectangle(Point leftTop, int width, int height, uint color)
		{
			LeftTop = leftTop;
			Width = width;
			Height = height;
			Color = color;
		}

		public void Draw(ICanvas canvas)
		{
			canvas.SetColor(Color);
			canvas.MoveTo(LeftTop.X, LeftTop.Y);
			canvas.LineTo(LeftTop.X + Width, LeftTop.Y);
			canvas.LineTo(LeftTop.X + Width, LeftTop.Y - Height);
			canvas.LineTo(LeftTop.X, LeftTop.Y - Height);
			canvas.LineTo(LeftTop.X, LeftTop.Y);
		}
	}
}

using System.Drawing;
using task2.GraphicsLib;

namespace task2.ShapeDrawingLib
{
	public class Triangle : ICanvasDrawable
	{
		public Point Vertex1 { get; private set; }
		public Point Vertex2 { get; private set; }
		public Point Vertex3 { get; private set; }
		public uint Color { get; private set; }

		public Triangle(Point p1, Point p2, Point p3, uint color)
		{
			Vertex1 = p1;
			Vertex2 = p2;
			Vertex3 = p3;
			Color = color;
		}

		public void Draw(ICanvas canvas)
		{
			canvas.SetColor(Color);
			canvas.MoveTo(Vertex1.X, Vertex1.Y);
			canvas.LineTo(Vertex2.X, Vertex2.Y);
			canvas.LineTo(Vertex3.X, Vertex3.Y);
			canvas.LineTo(Vertex1.X, Vertex1.Y);
		}
	}
}

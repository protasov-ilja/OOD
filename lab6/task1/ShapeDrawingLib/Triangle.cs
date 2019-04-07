using task1.GraphicsLib;

namespace task1.ShapeDrawingLib
{
	public class Triangle : ICanvasDrawable
	{
		public Point Vertex1 { get; private set; }
		public Point Vertex2 { get; private set; }
		public Point Vertex3 { get; private set; }

		public Triangle(Point p1, Point p2, Point p3)
		{
			Vertex1 = p1;
			Vertex2 = p2;
			Vertex3 = p3;
		}

		public void Draw(ICanvas canvas)
		{
			canvas.MoveTo(Vertex1.X, Vertex1.Y);
			canvas.LineTo(Vertex2.X, Vertex2.Y);
			canvas.LineTo(Vertex3.X, Vertex3.Y);
			canvas.LineTo(Vertex1.X, Vertex1.Y);
		}
	}
}

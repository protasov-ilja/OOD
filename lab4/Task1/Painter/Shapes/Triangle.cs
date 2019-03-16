using Task1.Painter.Enums;

namespace Task1.Painter.Shapes
{
	public class Triangle : Shape
	{
		public Point Vertex1 { get; private set; }
		public Point Vertex2 { get; private set; }
		public Point Vertex3 { get; private set; }

		public Triangle(Point v1, Point v2, Point v3, Color color)
			: base(color)
		{
			Vertex1 = v1;
			Vertex2 = v2;
			Vertex3 = v3;
		}

		public override void Draw(ICanvas canvas)
		{
			canvas.Color = Color;
			canvas.DrawLine(Vertex1, Vertex2);
			canvas.DrawLine(Vertex2, Vertex3);
			canvas.DrawLine(Vertex3, Vertex1);
		}
	}
}

using System.Numerics;
using Task1.Painter.Enums;

namespace Task1.Painter.Shapes
{
	public class Triangle : IShape
	{
		public Vector2 Vertex1 { get; private set; }
		public Vector2 Vertex2 { get; private set; }
		public Vector2 Vertex3 { get; private set; }

		private Color _color;
		private Vector2 v1;
		private Vector2 v2;
		private Vector2 v3;
		private object color;

		public Triangle(Vector2 v1, Vector2 v2, Vector2 v3, Enums.Color color)
		{
			Vertex1 = v1;
			Vertex2 = v2;
			Vertex3 = v3;
			_color = color;
		}

		public Triangle(Vector2 v1, Vector2 v2, Vector2 v3, object color)
		{
			this.v1 = v1;
			this.v2 = v2;
			this.v3 = v3;
			this.color = color;
		}

		public void Draw(ICanvas canvas)
		{
			canvas.Color = _color;
			canvas.DrawLine(Vertex1, Vertex2);
			canvas.DrawLine(Vertex2, Vertex3);
			canvas.DrawLine(Vertex3, Vertex1);
		}

		public Color GetColor()
		{
			return _color;
		}
	}
}

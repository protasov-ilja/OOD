using System;
using System.Numerics;
using Task1.Painter.Enums;

namespace Task1.Painter.Shapes
{
	public class RegularPolygon : IShape
	{
		public int VertexCount { get; private set; }
		public Vector2 Center { get; private set; }
		public float Radius { get; private set; }

		private Color _color;

		public RegularPolygon(int vertexCount, Vector2 center, float radius, Color color)
		{
			VertexCount = vertexCount;
			Center = center;
			Radius = radius;
			_color = color;
		}

		public Color GetColor()
		{
			return _color;
		}

		public void Draw(ICanvas canvas)
		{
			canvas.Color = _color;
			var angle = 360f / VertexCount;

			var angleInRadians = DegToRad(angle * 0);
			var x = (float)Math.Cos(angleInRadians);
			var y = (float)Math.Sin(angleInRadians);
			var vertex1 = new Vector2(x, y);

			for (var i = 1; i < VertexCount; ++i)
			{
				angleInRadians = DegToRad(angle * i);
				x = (float)Math.Cos(angleInRadians);
				y = (float)Math.Sin(angleInRadians);
				var vertex2 = new Vector2(x, y);
				canvas.DrawLine(vertex1, vertex2);
				vertex1 = vertex2;
			}
		}

		private float DegToRad(float angle)
		{
			return (float)(Math.PI / 180) * angle;
		}
	}
}

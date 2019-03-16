using System;
using Task1.Painter.Enums;

namespace Task1.Painter.Shapes
{
	public class RegularPolygon : Shape
	{
		public int VertexCount { get; private set; }
		public Point Center { get; private set; }
		public float Radius { get; private set; }

		public RegularPolygon(int vertexCount, Point center, float radius, Color color)
			: base(color)
		{
			VertexCount = vertexCount;
			Center = center;
			Radius = radius;
		}

		public override void Draw(ICanvas canvas)
		{
			canvas.Color = Color;
			var angle = 360f / VertexCount;
			var vertex1 = GetVertexByAngle(angle * 0);

			for (var i = 1; i < VertexCount; ++i)
			{
				var vertex2 = GetVertexByAngle(angle * i);
				canvas.DrawLine(vertex1, vertex2);
				vertex1 = vertex2;
			}
		}

		private Point GetVertexByAngle(float angle)
		{
			var angleInRadians = DegToRad(angle);
			var x = (float)Math.Cos(angleInRadians);
			var y = (float)Math.Sin(angleInRadians);

			return new Point(x, y);
		}

		private float DegToRad(float angle)
		{
			return (float)(Math.PI / 180) * angle;
		}
	}
}

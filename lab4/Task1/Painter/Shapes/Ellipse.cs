using System.Numerics;
using Task1.Painter.Enums;

namespace Task1.Painter.Shapes
{
	public class Ellipse : IShape
    {
		public Vector2 Center { get; private set; }
		public float HorizontalRadius { get; private set; }
		public float VerticalRadius { get; private set; }

		private Color _color;

		public Ellipse(Vector2 center, float horizontalRadius, float verticalRadius, Color color)
		{
			Center = center;
			HorizontalRadius = horizontalRadius;
			VerticalRadius = verticalRadius;
			_color = color;
		}

		public void Draw(ICanvas canvas)
		{
			canvas.Color = _color;
			canvas.DrawEllipse(
				Center.X - HorizontalRadius,
				Center.Y - VerticalRadius,
				HorizontalRadius * 2,
				VerticalRadius * 2
			);
		}

		public Color GetColor()
		{
			return _color;
		}
    }
}

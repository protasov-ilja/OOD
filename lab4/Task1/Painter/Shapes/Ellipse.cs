using Task1.Painter.Enums;

namespace Task1.Painter.Shapes
{
	public class Ellipse : Shape
    {
		public Point Center { get; private set; }
		public float HorizontalRadius { get; private set; }
		public float VerticalRadius { get; private set; }

		public Ellipse(Point center, float horizontalRadius, float verticalRadius, Color color)
			: base(color)
		{
			Center = center;
			HorizontalRadius = horizontalRadius;
			VerticalRadius = verticalRadius;
		}

		public override void Draw(ICanvas canvas)
		{
			canvas.Color = Color;
			canvas.DrawEllipse(
				Center.X - HorizontalRadius,
				Center.Y - VerticalRadius,
				HorizontalRadius * 2,
				VerticalRadius * 2
			);
		}
    }
}

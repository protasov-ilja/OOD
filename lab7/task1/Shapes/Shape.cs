using task1.Composite;

namespace task1.Shapes
{
	public abstract class Shape : IShape
	{
		public Rect<float> Frame { get; set; }
		public Style OutlineStyle { get; set; }
		public Style FillStyle { get; set; }
		public float? LineThickness { get; set; }

		public Shape(Rect<float> frame, Style outlineStyle, Style fillStyle, float lineThickness)
		{
			Frame = frame;
			OutlineStyle = outlineStyle;
			FillStyle = fillStyle;
			LineThickness = lineThickness;
		}

		public abstract void Draw(ICanvas canvas);
	}
}

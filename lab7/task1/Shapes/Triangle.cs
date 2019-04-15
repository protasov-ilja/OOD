using task1.Composite;

namespace task1.Shapes
{
	public class Triangle : Shape
	{
		public Triangle(Rect<float> frame, Style outlineStyle, Style fillStyle, float lineThickness)
			: base(frame, outlineStyle, fillStyle, lineThickness)
		{
		}

		public override void Draw(ICanvas canvas)
		{
			var v1 = new Point(Frame.Left + Frame.Width / 2, Frame.Top);
			var v2 = new Point(Frame.Left + Frame.Width, Frame.Top - Frame.Height);
			var v3 = new Point(Frame.Left, Frame.Top - Frame.Height);

			canvas.BeginFill(FillStyle.Color);
			canvas.SetLineColor(OutlineStyle.Color);
			canvas.SetLineThickness(LineThickness.Value);

			canvas.MoveTo(v1.X, v1.Y);
			canvas.LineTo(v2.X, v2.Y);
			canvas.LineTo(v3.X, v3.Y);
			canvas.LineTo(v1.X, v1.Y);

			canvas.EndFill();
		}
	}
}

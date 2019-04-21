using task1.Composite;

namespace task1.Shapes
{
	public class Ellipse : Shape
	{
		public Ellipse(Rect<float> frame, Style outlineStyle, Style fillStyle, float lineThickness)
			: base(frame, outlineStyle, fillStyle, lineThickness)
		{
		}

		public override void Draw(ICanvas canvas)
		{
			SetParametersInCanvas(canvas);

			canvas.DrawEllipse(Frame.Left, Frame.Top, Frame.Width, Frame.Height);

			canvas.EndFill();
		}
	}
}

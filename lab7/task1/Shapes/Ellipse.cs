using task1.Composite;
using task1.Composite.Styles;

namespace task1.Shapes
{
	public class Ellipse : Shape
	{
		public Ellipse(Rect<float> frame, IOutlineStyle outlineStyle, IStyle fillStyle)
			: base(frame, outlineStyle, fillStyle)
		{
		}

		public override void Draw(ICanvas canvas)
		{
			SetParametersInCanvas(canvas);

			canvas.DrawEllipse(Frame.Value.Left, Frame.Value.Top, Frame.Value.Width, Frame.Value.Height);

			canvas.EndFill();
		}
	}
}

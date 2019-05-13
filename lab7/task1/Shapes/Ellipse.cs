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

			canvas.DrawEllipse(GetFrame().Value.Left, GetFrame().Value.Top, GetFrame().Value.Width, GetFrame().Value.Height);

			canvas.EndFill();
		}
	}
}

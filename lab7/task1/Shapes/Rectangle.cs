using task1.Composite;
using task1.Composite.Styles;

namespace task1.Shapes
{
    public class Rectangle : Shape
    {
		public Rectangle(Rect<float> frame, IOutlineStyle outlineStyle, IStyle fillStyle)
			: base(frame, outlineStyle, fillStyle)
		{
		}

		public override void Draw(ICanvas canvas)
		{
			var leftTop = new Point(Frame.Value.Left, Frame.Value.Top);
			var rightTop = new Point(Frame.Value.Left + Frame.Value.Width, Frame.Value.Top);
			var rightBottom = new Point(Frame.Value.Left + Frame.Value.Width, Frame.Value.Top + Frame.Value.Height);
			var leftBottom = new Point(Frame.Value.Left, Frame.Value.Top + Frame.Value.Height);

			SetParametersInCanvas(canvas);

			canvas.MoveTo(leftTop.X, leftTop.Y);
			canvas.LineTo(rightTop.X, rightTop.Y);
			canvas.LineTo(rightBottom.X, rightBottom.Y);
			canvas.LineTo(leftBottom.X, leftBottom.Y);
			canvas.LineTo(leftTop.X, leftTop.Y);

			canvas.EndFill();
		}
	}
}

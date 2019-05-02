﻿using task1.Composite;

namespace task1.Shapes
{
    public class Rectangle : Shape
    {
		public Rectangle(Rect<float> frame, Style outlineStyle, Style fillStyle, float lineThickness)
			: base(frame, outlineStyle, fillStyle, lineThickness)
		{
		}

		public override void Draw(ICanvas canvas)
		{
			var leftTop = new Point(Frame.Left, Frame.Top);
			var rightTop = new Point(Frame.Left + Frame.Width, Frame.Top);
			var rightBottom = new Point(Frame.Left + Frame.Width, Frame.Top + Frame.Height);
			var leftBottom = new Point(Frame.Left, Frame.Top + Frame.Height);

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
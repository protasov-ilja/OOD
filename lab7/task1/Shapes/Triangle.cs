using task1.Composite;
using task1.Composite.Styles;

namespace task1.Shapes
{
	public class Triangle : Shape
	{
		public Triangle(Rect<float> frame, IOutlineStyle outlineStyle, IStyle fillStyle)
			: base(frame, outlineStyle, fillStyle)
		{
		}

		public override void Draw(ICanvas canvas)
		{
			var v1 = new Point(GetFrame().Value.Left + GetFrame().Value.Width / 2, GetFrame().Value.Top);
			var v2 = new Point(GetFrame().Value.Left + GetFrame().Value.Width, GetFrame().Value.Top + GetFrame().Value.Height);
			var v3 = new Point(GetFrame().Value.Left, GetFrame().Value.Top + GetFrame().Value.Height);

			SetParametersInCanvas(canvas);

			canvas.MoveTo(v1.X, v1.Y);
			canvas.LineTo(v2.X, v2.Y);
			canvas.LineTo(v3.X, v3.Y);
			canvas.LineTo(v1.X, v1.Y);

			canvas.EndFill();
		}
	}
}

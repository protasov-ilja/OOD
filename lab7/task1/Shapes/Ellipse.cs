using SFML.Graphics;
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
			canvas.BeginFill(FillStyle.IsEnabled() ? FillStyle.Color : Color.Transparent);
			canvas.SetLineColor(FillStyle.IsEnabled() ? FillStyle.Color : Color.Black);
			canvas.SetLineThickness(LineThickness.HasValue ? LineThickness.Value : 1);



			canvas.DrawEllipse(Frame.Left, Frame.Top, Frame.Width, Frame.Height);

			canvas.EndFill();
		}
	}
}

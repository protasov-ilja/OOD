using Task1.Painter.Enums;

namespace Task1.Painter
{
	public interface ICanvas
    {
		Color Color { get; set; }

		void DrawLine(Point from, Point to);
		void DrawEllipse(double l, double t, double width, double height);
    }
}

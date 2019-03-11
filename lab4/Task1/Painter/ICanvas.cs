using System.Numerics;
using Task1.Painter.Enums;

namespace Task1.Painter
{
	public interface ICanvas
    {
		Color Color { get; set; }

		void DrawLine(Vector2 from, Vector2 to);
		void DrawEllipse(double l, double t, double width, double height);
    }
}

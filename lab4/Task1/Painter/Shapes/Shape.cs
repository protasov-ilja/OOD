using Task1.Painter.Enums;

namespace Task1.Painter.Shapes
{
	public abstract class Shape
    {
		public Color Color { get; private set; }

		public Shape(Color color)
		{
			Color = color;
		}

		public abstract void Draw(ICanvas canvas);
    }
}

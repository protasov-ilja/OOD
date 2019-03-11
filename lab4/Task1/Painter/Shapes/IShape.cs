using Task1.Painter.Enums;

namespace Task1.Painter
{
	public interface IShape
    {
		Color GetColor();
		void Draw(ICanvas canvas);
    }
}

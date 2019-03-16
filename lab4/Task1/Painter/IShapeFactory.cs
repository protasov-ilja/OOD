using Task1.Painter.Shapes;

namespace Task1.Painter
{
	public interface IShapeFactory
    {
		Shape CreateShape(string description);
	}
}

using task1.Composite;
using task1.Composite.Styles;

namespace task1.Shapes
{
    public interface IShape : IDrawable
    {
		Rect<float>? Frame { get; set; }
		IOutlineStyle OutlineStyle { get; }
		IStyle FillStyle { get; }
	}
}

using task1.Composite;
using task1.Composite.Styles;

namespace task1.Shapes
{
    public interface IShape : IDrawable
    {
		Rect<float>? GetFrame();
		void SetFrame(Rect<float> frame);

		IOutlineStyle OutlineStyle { get; }
		IStyle FillStyle { get; }
	}
}

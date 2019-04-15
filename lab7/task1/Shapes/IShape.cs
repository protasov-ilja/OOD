using task1.Composite;

namespace task1.Shapes
{
    public interface IShape : IDrawable
    {
		Rect<float> Frame { get; set; }
		Style OutlineStyle { get; set; }
		Style FillStyle { get; set; }
		float? LineThickness { get; set; }
	}
}

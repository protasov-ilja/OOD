
using SFML.Graphics;

namespace task1.Composite
{
    public interface ICanvas
    {
		void SetLineColor(Color color);
		void BeginFill(Color color);
		void EndFill();
		void MoveTo(float x, float y);
		void LineTo(float x, float y);
		void DrawEllipse(float left, float top, float width, float height);
		void SetLineThickness(float thickness);
	}
}

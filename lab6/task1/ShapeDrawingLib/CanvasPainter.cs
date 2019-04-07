using task1.GraphicsLib;

namespace task1.ShapeDrawingLib
{
    public class CanvasPainter
    {
		private ICanvas _canvas;

		public CanvasPainter(ICanvas canvas)
		{
			_canvas = canvas;
		}

		public void Draw(ICanvasDrawable drawable)
		{
			drawable.Draw(_canvas);
		}
	}
}

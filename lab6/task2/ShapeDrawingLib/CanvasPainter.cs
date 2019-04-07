using task2.GraphicsLib;

namespace task2.ShapeDrawingLib
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

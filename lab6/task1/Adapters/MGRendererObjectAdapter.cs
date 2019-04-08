using System;
using task1.GraphicsLib;
using task1.ModernGraphicsLib;
using task1.Utils.Exceptions;

namespace task1.Adapters
{
    public class MGRendererObjectAdapter : ICanvas
    {
		public ModernGraphicsRenderer Renderer { get; private set; }
		private Point _startPoint;

		public MGRendererObjectAdapter(ModernGraphicsRenderer renderer)
		{
			_startPoint = new Point(0, 0);
			Renderer = renderer;
		}

		public void MoveTo(int x, int y)
		{
			_startPoint = new Point(x, y);
		}

		public void LineTo(int x, int y)
		{
			var newPoint = new Point(x, y);
			Renderer.DrawLine(_startPoint, newPoint);
			_startPoint = newPoint;
		}
	}
}

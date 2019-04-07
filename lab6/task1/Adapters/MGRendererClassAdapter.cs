using System;
using System.IO;
using task1.GraphicsLib;
using task1.ModernGraphicsLib;
using task1.Utils.Exceptions;

namespace task1.Adapters
{
	public class MGRendererClassAdapter : ModernGraphicsRenderer, ICanvas
	{
		private Point _startPoint;

		public MGRendererClassAdapter(TextWriter strm)
			: base(strm)
		{
			_startPoint = new Point(0, 0);
		}

		public void LineTo(int x, int y)
		{
			try
			{
				var newPoint = new Point(x, y);
				DrawLine(_startPoint, newPoint);
				_startPoint = newPoint;
			}
			catch (LogicErrorException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void MoveTo(int x, int y)
		{
			_startPoint = new Point(x, y);
		}
	}
}

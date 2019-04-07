using System;
using System.Drawing;
using System.IO;
using task2.GraphicsLib;
using task2.ModernGraphicsLib;
using task2.Utils.Exceptions;

using Point = task2.ModernGraphicsLib.Point;

namespace task2.Adapters
{
	public class MGRendererClassAdapter : ModernGraphicsRenderer, ICanvas
	{
		private Point _startPoint = new Point(0, 0);
		private Color _color = Color.Black;

		public MGRendererClassAdapter(TextWriter strm)
			: base(strm)
		{
		}

		public void LineTo(int x, int y)
		{
			try
			{
				var newPoint = new Point(x, y);
				DrawLine(_startPoint, newPoint, _color);
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

		public void SetColor(uint rgbColor)
		{
			_color = Color.FromArgb((int)rgbColor);
		}
	}
}

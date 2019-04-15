using System.IO;
using task1.Utils.Exceptions;

namespace task1.ModernGraphicsLib
{
    public class ModernGraphicsRenderer
    {
		private bool _drawing = false;
		private TextWriter _out;

		public ModernGraphicsRenderer(TextWriter strm)
		{
			_out = strm;
		}

		~ModernGraphicsRenderer()
		{
			if (_drawing)
			{
				EndDraw();
			}
		}

		// Этот метод должен быть вызван в начале рисования
		public void BeginDraw()
		{
			if (_drawing)
			{
				throw new LogicErrorException("Drawing has already begun");
			}

			_out.WriteLine("<draw>");
			_drawing = true;
		}

		// Выполняет рисование линии
		public void DrawLine(Point start, Point end)
		{
			if (!_drawing)
			{
				throw new LogicErrorException("DrawLine is allowed between BeginDraw()/EndDraw() only");
			}

			_out.WriteLine($"<line fromX={start.X} fromY={start.Y} toX={end.X} toY={end.Y}/>");
		}

		// Этот метод должен быть вызван в конце рисования
		public void EndDraw()
		{
			if (!_drawing)
			{
				throw new LogicErrorException("Drawing has not been started");
			}

			_out.WriteLine("</draw>");
			_drawing = false;
		}
	}
}

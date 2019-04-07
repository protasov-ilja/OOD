using System.Drawing;
using System.IO;
using task2.Utils.Exceptions;

namespace task2.ModernGraphicsLib
{
    public class ModernGraphicsRenderer
    {
		private bool _drawing = false;
		private TextWriter _out;

		public ModernGraphicsRenderer(TextWriter strm)
		{
			_out = strm;
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
		public void DrawLine(Point start, Point end, Color color)
		{
			if (!_drawing)
			{
				throw new LogicErrorException("DrawLine is allowed between BeginDraw()/EndDraw() only");
			}

			_out.WriteLine($"<line fromX={start.X} fromY={start.Y} toX={end.X} toY={end.Y}>");
			_out.WriteLine($"<color r={color.R} g={color.G} b={color.B} a={color.A} />");
			_out.WriteLine($"</line>");
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

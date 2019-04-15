using SFML.Graphics;
using SFML.System;
using System.IO;
using task1.Utils.Exceptions;

namespace task1.Composite
{
	public class Canvas : ICanvas
	{
		private TextWriter _out;
		private Color _lineColor = Color.Black;
		private Color _fillColor = Color.Transparent;
		private float _lineThickness = 1;
		private bool _isFillStart = false;
		private RenderTarget _renderer;

		private Vector2f _startPoint = new Vector2f(0, 0);

		public Canvas(TextWriter output, RenderWindow renderer)
		{
			_out = output;
		}

		public void BeginFill(Color color)
		{
			if (_isFillStart)
			{
				throw new LogicErrorException("Filling has already begun");
			}

			_out.WriteLine($"Filling begin {color}");
			_fillColor = color;
			_isFillStart = true;
		}

		public void DrawEllipse(float left, float top, float width, float height)
		{
			_out.WriteLine($"l: {left} t: {top} width: {width} height: {height}");
		}

		public void EndFill()
		{
			if (!_isFillStart)
			{
				throw new LogicErrorException("Filling has already end");
			}

			_out.WriteLine($"Filling end");
			_fillColor = Color.Transparent;
			_isFillStart = false;
		}

		public void LineTo(float x, float y)
		{
			var newLine = new Vector2f(x, y);
			
			_out.WriteLine($"LineTo ({ x }, { y })");
		}

		public void MoveTo(float x, float y)
		{
			_startPoint = new Vector2f(x, y);
			_out.WriteLine($"MoveTo ({ x }, { y })");
		}

		public void SetLineColor(Color color)
		{
			_out.WriteLine($"LineColor {color}");
			_lineColor = color;
		}

		public void SetLineThickness(float thickness)
		{
			_out.WriteLine($"thickness {thickness}");
			_lineThickness = thickness;
		}
	}
}

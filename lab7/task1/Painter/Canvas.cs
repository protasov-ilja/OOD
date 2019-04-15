using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
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
		private List<Vector2f> _points = new List<Vector2f>();

		private Vector2f _startPoint = new Vector2f(0, 0);

		public Canvas(TextWriter output, RenderWindow renderer)
		{
			//_renderer = renderer;
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
			var quality = 70;
			for (var i = 0; i < quality; ++i)
			{
				var rad = (360 / quality * i) / (360 / Math.PI / 2);
				var x = Math.Cos(rad) * width;
				var y = Math.Sin(rad) * height;

				_points.Add(new Vector2f((float)x, (float)y));
			}

			_out.WriteLine($"l: {left} t: {top} width: {width} height: {height}");
		}

		public void EndFill()
		{
			if (!_isFillStart)
			{
				throw new LogicErrorException("Filling has already end");
			}

			// RENDER
			//var shape = new ConvexShape((uint)_points.Count);
			//for (var i = 0; i < _points.Count; ++i)
			//{
			//	shape.SetPoint((uint)i, _points[i]);
			//}
			
			//shape.FillColor = _fillColor;
			//shape.OutlineColor = _lineColor;
			//shape.OutlineThickness = _lineThickness;
			//shape.Position = new Vector2f(2, 2);
			//_renderer.Draw(shape);

			_out.WriteLine($"Filling end");
			_fillColor = Color.Transparent;
			_isFillStart = false;
		}

		public void LineTo(float x, float y)
		{
			_points = new List<Vector2f>();
			var newPoint = new Vector2f(x, y);
			_points.Add(newPoint);
			_out.WriteLine($"LineTo ({ x }, { y })");
		}

		public void MoveTo(float x, float y)
		{
			var point = new Vector2f(x, y);
			_points = new List<Vector2f>();
			_points.Add(point);
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

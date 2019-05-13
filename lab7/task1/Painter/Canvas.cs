using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using task1.Utils.Exceptions;

namespace task1.Composite
{
	public class Canvas : ICanvas
	{
		private Color _lineColor = Color.Black;
		private Color _fillColor = Color.Transparent;
		private float _lineThickness = 1;
		private bool _isFillStart = false;
		private RenderTarget _renderer;
		private List<Vector2f> _points = new List<Vector2f>();

		private Vector2f _startPoint = new Vector2f(0, 0);

		public Canvas(RenderTarget renderer)
		{
			_renderer = renderer;
		}

		public void BeginFill(Color color)
		{
			if (_isFillStart)
			{
				throw new LogicErrorException("Filling has already begun");
			}

			_fillColor = color;
			_isFillStart = true;
		}

		public void DrawEllipse(float left, float top, float width, float height)
		{
			_points = new List<Vector2f>();
			var quality = 70;
			for (var i = 0; i < quality; ++i)
			{
				var radPerStep = (360 / quality * i) / (360 / Math.PI / 2);
				var x = Math.Cos(radPerStep) * width;
				var y = Math.Sin(radPerStep) * height;

				_points.Add(new Vector2f((float)x + left + width, (float)y + top + height));
			}
		}

		public void EndFill()
		{
			if (!_isFillStart)
			{
				throw new LogicErrorException("Filling has already end");
			}

			// RENDER
			var shape = new ConvexShape((uint)_points.Count);
			for (var i = 0; i < _points.Count; ++i)
			{
				shape.SetPoint((uint)i, _points[i]);
			}

			shape.FillColor = _fillColor;
			shape.OutlineColor = _lineColor;
			shape.OutlineThickness = _lineThickness;
			
			_renderer.Draw(shape);
			// RENDER

			_fillColor = Color.Transparent;
			_isFillStart = false;
		}

		public void LineTo(float x, float y)
		{
			var newPoint = new Vector2f(x, y);
			_points.Add(newPoint);
		}

		public void MoveTo(float x, float y)
		{
			var point = new Vector2f(x, y);
			_points = new List<Vector2f>();
			_points.Add(point);
		}

		public void SetLineColor(Color color)
		{
			_lineColor = color;
		}

		public void SetLineThickness(float thickness)
		{
			_lineThickness = thickness;
		}
	}
}

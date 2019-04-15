using System;
using System.Collections.Generic;
using task1.Shapes;

namespace task1.Composite
{
	public class Group : IGroup
	{
		private Style _outlineStyle = null;
		private Style _fillStyle = null;
		private float? _lineThickness = 1;
		private Rect<float> _frame;

		private List<Shape> _shapes = new List<Shape>();

		public Rect<float> Frame
		{
			get
			{
				var frame = new Rect<float> {
					Top = float.MaxValue,
					Left = float.MaxValue,
					Width = 0,
					Height = -float.MinValue
				};

				float maxRight = 0;
				float maxBottom = 0;
				foreach (var shape in _shapes)
				{
					var shapeFrame = shape.Frame;
					frame.Left = Math.Min(shapeFrame.Left, frame.Left);
					frame.Top = Math.Min(shapeFrame.Top, frame.Top);
					maxRight = Math.Max(shapeFrame.Width + shapeFrame.Left, maxRight);
					maxBottom = Math.Max(shapeFrame.Height + shapeFrame.Top, maxBottom);
				}

				frame.Width = maxRight - frame.Left;
				frame.Height = maxBottom - frame.Top;

				_frame = frame;

				return frame;
			}

			set
			{
				var oldFrame = Frame;

				float deltaX = value.Width / oldFrame.Width;
				float deltaY = value.Height / oldFrame.Height;

				foreach(var shape in _shapes)
				{
					var shapeFrame = shape.Frame;
					var offsetX = shapeFrame.Left - oldFrame.Left;
					var offsetY = shapeFrame.Top - oldFrame.Top;

					shapeFrame.Left = value.Left + offsetX * deltaX;
					shapeFrame.Top = value.Top + offsetY * deltaY;
					shapeFrame.Width = shapeFrame.Width * deltaX;
					shapeFrame.Height = shapeFrame.Height * deltaY;
				}
			}
		}

		public Style FillStyle
		{
			get
			{
				foreach (var shape in _shapes)
				{
					if (shape.FillStyle != _fillStyle)
					{
						return null;
					}
				}

				return _fillStyle;
			}

			set
			{
				_fillStyle = value;
				foreach (var shape in _shapes)
				{
					shape.OutlineStyle = value;
				}
			}
		}

		public Style OutlineStyle
		{
			get
			{
				foreach (var shape in _shapes)
				{
					if (shape.OutlineStyle != _outlineStyle)
					{
						return null;
					}
				}

				return _outlineStyle;
			}

			set
			{
				_outlineStyle = value;
				foreach (var shape in _shapes)
				{
					shape.OutlineStyle = value;
				}
			}
		}

		public float? LineThickness
		{
			get
			{
				foreach (var shape in _shapes)
				{
					if (shape.LineThickness != _lineThickness)
					{
						return null;
					}
				}

				return _lineThickness;
			}

			set
			{
				_lineThickness = value.Value;
				foreach (var shape in _shapes)
				{
					shape.LineThickness = value.Value;
				}
			}
		}

		public Group(Style outlineStile, Style fillStyle, float lineThickness)
		{
			OutlineStyle = outlineStile;
			FillStyle = fillStyle;
			LineThickness = lineThickness;
		}

		public IGroup GetGroup()
		{
			return this;
		}

		public Shape GetShapeAtIndex(int index)
		{
			if ((index >= _shapes.Count) || (index < 0))
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			return _shapes[index];
		}

		public int GetShapesCount()
		{
			return _shapes.Count;
		}

		public void InsertShape(Shape shape, int position)
		{
			if ((position > _shapes.Count) || (position < 0))
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			_shapes.Insert(position, shape);
		}

		public void RemoveShapeAtIndex(int index)
		{
			if ((index >= _shapes.Count) || (index < 0))
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			_shapes.RemoveAt(index);
		}

		public void Draw(ICanvas canvas)
		{
			foreach(var shape in _shapes)
			{
				shape.Draw(canvas);
			}
		}
	}
}

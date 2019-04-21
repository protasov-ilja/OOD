using System;
using System.Collections.Generic;
using task1.Shapes;

namespace task1.Composite
{
	public class Group : IComponent
	{
		private Style? _outlineStyle = null;
		private Style? _fillStyle = null;
		private float? _lineThickness = 1;
		private Rect<float> _frame;

		public IComponent Parent { get; set; }

		private List<IComponent> _shapes = new List<IComponent>();

		public Rect<float> Frame
		{
			get => _frame;

			set
			{
				var oldFrame = _frame;

				float deltaX = value.Width / oldFrame.Width;
				float deltaY = value.Height / oldFrame.Height;
				Console.WriteLine(deltaX + " " + deltaY);

				foreach(var shape in _shapes)
				{
					var shapeFrame = shape.Frame;
					var offsetX = shapeFrame.Left - oldFrame.Left;
					var offsetY = shapeFrame.Top - oldFrame.Top;

					Console.WriteLine(offsetX + " " + offsetY);
					shapeFrame.Left = value.Left + offsetX * deltaX;
					shapeFrame.Top = value.Top + offsetY * deltaY;
					shapeFrame.Width *= deltaX;
					shapeFrame.Height *= deltaY;
					shape.Frame = shapeFrame;
				}

				RecalculateFrame();
				Parent?.RecalculateFrame();
			}
		}

		public Style? FillStyle
		{
			get => _fillStyle;

			set
			{
				_fillStyle = value;
				foreach (var shape in _shapes)
				{
					shape.FillStyle = value.Value;
				}

				Parent?.RecalculateFillStyle();
			}
		}

		public Style? OutlineStyle
		{
			get => _outlineStyle;

			set
			{
				_outlineStyle = value;
				foreach (var shape in _shapes)
				{
					shape.OutlineStyle = value.Value;
				}

				Parent?.RecalculateOutlineStyle();
			}
		}

		public float? LineThickness
		{
			get => _lineThickness;

			set
			{
				_lineThickness = value.Value;
				foreach (var shape in _shapes)
				{
					shape.LineThickness = value.Value;
				}

				Parent?.RecalculateLineThickness();
			}
		}

		public Group(IComponent component)
		{
			component.Parent = this;
			_shapes.Add(component);

			_frame = component.Frame;
			_fillStyle = component.FillStyle;
			_outlineStyle = component.OutlineStyle;
			_lineThickness = component.LineThickness;
		}

		public int GetShapesCount()
		{
			return _shapes.Count;
		}

		public void InsertShape(IComponent shape, int position)
		{
			if ((position > _shapes.Count) || (position < 0))
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			shape.Parent = this;
			_shapes.Insert(position, shape);

			RecalculateFillStyle();
			RecalculateOutlineStyle();
			RecalculateLineThickness();
			RecalculateFrame();
		}

		public void RemoveShapeAtIndex(int index)
		{
			if ((index >= _shapes.Count) || (index < 0))
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			_shapes[index].Parent = null;
			_shapes.RemoveAt(index);

			RecalculateFillStyle();
			RecalculateOutlineStyle();
			RecalculateLineThickness();
			RecalculateFrame();
		}

		public void RecalculateFillStyle()
		{
			var fillStyle = (GetShapesCount() != 0) ? _shapes[0].FillStyle : null;
			foreach (var shape in _shapes)
			{
				if (fillStyle != shape.FillStyle)
				{
					fillStyle = null;
				}
			}

			var isChanged = _fillStyle != fillStyle;
			_fillStyle = fillStyle;
			if (isChanged)
			{
				Parent?.RecalculateFillStyle();
			}
		}

		public void RecalculateOutlineStyle()
		{
			var outlineStyle = (GetShapesCount() != 0) ? _shapes[0].OutlineStyle : null;
			foreach (var shape in _shapes)
			{
				if (outlineStyle != shape.OutlineStyle)
				{
					outlineStyle = null;
				}
			}

			var isChanged = _outlineStyle != outlineStyle;
			_outlineStyle = outlineStyle;
			if (isChanged)
			{
				Parent?.RecalculateOutlineStyle();
			}
		}

		public void RecalculateFrame()
		{
			var frame = new Rect<float>
			{
				Left = float.MaxValue,
				Top = float.MaxValue,
				Width = 0,
				Height = 0
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
			Console.WriteLine(maxRight + " " + maxBottom);
			frame.Width = Math.Abs(maxRight - frame.Left);
			frame.Height = Math.Abs(maxBottom - frame.Top);

			_frame = frame;
		}

		public void RecalculateLineThickness()
		{
			var lineThickness = (GetShapesCount() != 0) ? _shapes[0].LineThickness : null;
			foreach (var shape in _shapes)
			{
				if (lineThickness != shape.LineThickness)
				{
					lineThickness = null;
				}
			}

			var isChanged = _lineThickness != lineThickness;
			_lineThickness = lineThickness;
			if (isChanged)
			{
				Parent?.RecalculateLineThickness();
			}
		}

		public void Draw(ICanvas canvas)
		{
			Console.WriteLine("------Group------");
			foreach (var shape in _shapes)
			{
				shape.Draw(canvas);
			}
			Console.WriteLine("------End------");
		}
	}
}

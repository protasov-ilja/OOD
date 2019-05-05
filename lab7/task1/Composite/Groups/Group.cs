using System;
using System.Collections.Generic;
using task1.Composite.Styles;
using task1.Shapes;

namespace task1.Composite
{
	public class Group : IComponent
	{
		private List<IComponent> _shapes = new List<IComponent>();

		private IOutlineStyle _outlineStyle;
		private IStyle _fillStyle;

		public Rect<float>? Frame
		{
			get => CalculateFrame();
			set => RecalculateFrame(value);
		}

		public IStyle FillStyle => _fillStyle;

		public IOutlineStyle OutlineStyle => _outlineStyle;

		public Group(IComponent component)
		{
			_shapes.Add(component);
			_fillStyle = new FillStyleGroup(GetFillStyle());
			_outlineStyle = new OutlineStyleGroup(GetOutlineStyle());
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

		private Rect<float>? CalculateFrame()
		{
			float left = 0;
			float top = 0;
			float maxX = 0;
			float maxY = 0;
			float width = 0;
			float height = 0;

			Rect<float>? frame = null;
			bool isFirstFound = false;
			foreach (var shape in _shapes)
			{
				if (shape.Frame.HasValue)
				{
					if (!isFirstFound)
					{
						isFirstFound = true;
						
						left = shape.Frame.Value.Left;
						top = shape.Frame.Value.Top;
						width = shape.Frame.Value.Width;
						height = shape.Frame.Value.Height;

						maxX = width + left;
						maxY = height + top;
					}
					else
					{
						var shapeFrame = shape.Frame.Value;

						left = Math.Min(shapeFrame.Left, left);
						top = Math.Min(shapeFrame.Top, top);
						maxX = Math.Max(shapeFrame.Width + shapeFrame.Left, maxX);
						maxY = Math.Max(shapeFrame.Height + shapeFrame.Top, maxY);
					}

					frame = shape.Frame;
				}
			}

			if (isFirstFound)
			{
				width = maxX - left;
				height = maxY - top;

				frame = new Rect<float>(top, left, width, height);
			}

			return frame;
		}

		private void RecalculateFrame(Rect<float>? frame)
		{
			var old = Frame;
			if (old.HasValue)
			{
				var oldFrame = old.Value;
				float deltaX = frame.Value.Width / oldFrame.Width;
				float deltaY = frame.Value.Height / oldFrame.Height;
				Console.WriteLine(deltaX + " " + deltaY);

				foreach (var shape in _shapes)
				{
					if (shape.Frame.HasValue)
					{
						var shapeFrame = shape.Frame.Value;
						var offsetX = shapeFrame.Left - oldFrame.Left;
						var offsetY = shapeFrame.Top - oldFrame.Top;

						Console.WriteLine(offsetX + " " + offsetY);
						shapeFrame.Left = frame.Value.Left + offsetX * deltaX;
						shapeFrame.Top = frame.Value.Top + offsetY * deltaY;
						shapeFrame.Width *= deltaX;
						shapeFrame.Height *= deltaY;
						shape.Frame = shapeFrame;
					}
				}
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

		private IEnumerable<IStyle> GetFillStyle()
		{
			foreach (var shape in _shapes)
			{
				yield return shape.FillStyle;
			}
		}

		private IEnumerable<IOutlineStyle> GetOutlineStyle()
		{
			foreach (var shape in _shapes)
			{
				yield return shape.OutlineStyle;
			}
		}

		public bool IsComposite()
		{
			return true;
		}
	}
}

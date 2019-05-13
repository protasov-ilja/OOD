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

		public Group GetGroup()
		{
			return this;
		}

		public IComponent GetComponentByIndex(int index)
		{
			if ((index >= _shapes.Count) || (index < 0))
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			return _shapes[index];
		}

		public Rect<float>? GetFrame()
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
				if (shape.GetFrame().HasValue)
				{
					var shapeFrame = shape.GetFrame().Value;
					if (!isFirstFound)
					{
						isFirstFound = true;

						left = shapeFrame.Left;
						top = shapeFrame.Top;
						width = shapeFrame.Width;
						height = shapeFrame.Height;

						maxX = width + left;
						maxY = height + top;
					}
					else
					{
						left = Math.Min(shapeFrame.Left, left);
						top = Math.Min(shapeFrame.Top, top);
						maxX = Math.Max(shapeFrame.Width + shapeFrame.Left, maxX);
						maxY = Math.Max(shapeFrame.Height + shapeFrame.Top, maxY);
					}

					frame = shape.GetFrame();
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

		public void SetFrame(Rect<float> frame)
		{
			var old = GetFrame();
			if (old.HasValue)
			{
				var oldFrame = old.Value;
				float scaleX = frame.Width / oldFrame.Width;
				float scaleY = frame.Height / oldFrame.Height;

				foreach (var shape in _shapes)
				{
					if (shape.GetFrame().HasValue)
					{
						var shapeFrame = shape.GetFrame().Value;
						var offsetX = shapeFrame.Left - oldFrame.Left;
						var offsetY = shapeFrame.Top - oldFrame.Top;

						shapeFrame.Left = frame.Left + offsetX * scaleX;
						shapeFrame.Top = frame.Top + offsetY * scaleY;
						shapeFrame.Width *= scaleX;
						shapeFrame.Height *= scaleY;
						shape.SetFrame(shapeFrame);
					}
				}
			}
		}
	}
}

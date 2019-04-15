using System;
using System.Collections.Generic;
using System.Drawing;
using task1.Composite;
using task1.Shapes;

namespace task1
{
	public class Slide
	{
		public float Width { get; private set; }
		public float Height { get; private set; }
		public int ShapeCount
		{
			get { return _shapes.Count; }
		}

		public Color BackgroundCoor { get; set; }

		private List<IShape> _shapes = new List<IShape>();

		public Slide(float width, float height)
		{
			Width = width;
			Height = height;
		}

		public IShape GetShapeAtIndex(int index)
		{
			if ((index >= _shapes.Count) || (index < 0))
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			return _shapes[index];
		}

		public void InsertShape(IShape shape, int index)
		{
			if ((index > _shapes.Count) || (index < 0))
			{
				throw new IndexOutOfRangeException("index out of range");
			}

			_shapes.Insert(index, shape);
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
			foreach (var shape in _shapes)
			{
				shape.Draw(canvas);
			}
		}
    }
}

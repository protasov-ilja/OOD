using System.Collections.Generic;
using Task1.Painter.Shapes;

namespace Task1.Painter
{
	public class PictureDraft
	{
		private List<Shape> _shapes = new List<Shape>();

		public int ShapeCount
		{
			get { return _shapes.Count; }
		}

		public void AddShape(Shape shape)
		{
			_shapes.Add(shape);
		}

		public Shape GetShapeByIndex(int index)
		{
			if ((index >= _shapes.Count) && (index < 0))
			{
				throw new System.ArgumentOutOfRangeException("IndexOutOfRange");
			}

			return _shapes[index];
		}
	}
}

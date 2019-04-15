using System.Collections.Generic;
using task1.Shapes;

namespace task1.Composite
{
    public interface IGroup : IShape
	{
		int GetShapesCount();
		Shape GetShapeAtIndex(int index);
		void InsertShape(Shape shape, int position);
		void RemoveShapeAtIndex(int index);
		IGroup GetGroup();
	}
}

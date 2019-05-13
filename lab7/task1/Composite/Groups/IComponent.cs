using task1.Shapes;

namespace task1.Composite
{
	public interface IComponent : IShape
	{
		void InsertShape(IComponent shape, int position);
		void RemoveShapeAtIndex(int index);
		IComponent GetComponentByIndex(int index);
		int GetShapesCount();
		Group GetGroup();
	}
}

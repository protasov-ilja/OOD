using task1.Shapes;

namespace task1.Composite
{
	public interface IComponent : IShape
	{
		void InsertShape(IComponent shape, int position);
		void RemoveShapeAtIndex(int index);
		int GetShapesCount();
		bool IsComposite();
	}
}
